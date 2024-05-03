using OceanStory.Interfaces;
using OceanStory.Monsters;

namespace OceanStory
{
    // 전투 관련 매니저
    internal class BattleManager
    {
        public List<IMonster> monsters = new List<IMonster>();                       // 몬스터 리스트   
        public int TargetIndex, TargetDamage, SoloTarget;
        public int[] TargetBothIndexLevel, TargetBothIndexHp, BothTargetBeforeHp;    // 공격 목표 몬스터와 입힌 데미지 저장  // 공격 전 체력 저장
        public string[] TargetBothIndexName;
        public double TargetBeforeHp, PlayerBeforeHp, PlayerStartHp, PlayerBeforeMp, PlayerStartMp;
        public string skillName;                                
        public int Winner, DeadCount;                                                // 승리자, 전투에서 쓰러트린 몬스터 수                      
        public int attackDamage;                                                     // 플레이어가 입히는 데미지                                     
        public bool isMoving = false;                                                // 회피
        public bool isCriticle = false;                                              // 크리티컬
        enum EnemyType // 몬스터 모음
        {
            Minion,
            Voidling,
            CanonMinion,
            RedGolem,
            BlueGolem,
            Wyvern,
            Diablo
        }

        // 최초 몬스터 생성
        public void MakeEnemy(int Cave)
        {
            PlayerStartHp = Program.Character.Hp;
            PlayerStartMp = Program.Character.Mp;
            monsters.Clear();
            Random random = new Random();
            List<EnemyType> enemies = new List<EnemyType>();
            int randomMake = 0;
            switch (Cave) // 선택된 던전에 따라 난이도 조정 
            {
                case 1:
                    randomMake = new Random().Next(1, 4);
                    enemies.Add(EnemyType.Minion);
                    enemies.Add(EnemyType.Voidling);
                    break;
                case 2:
                    randomMake = new Random().Next(2, 5);
                    enemies.Add(EnemyType.Voidling);
                    enemies.Add(EnemyType.CanonMinion);
                    break;
                case 3:
                    randomMake = new Random().Next(1, 5);
                    enemies.Add(EnemyType.BlueGolem);
                    enemies.Add(EnemyType.CanonMinion);
                    enemies.Add(EnemyType.RedGolem);
                    break;
                case 4:
                    randomMake = new Random().Next(1, 3);
                    enemies.Add(EnemyType.Wyvern);
                    break;
                case 5:
                    randomMake = new Random().Next(1, 2);
                    enemies.Add(EnemyType.Diablo);
                    break;
            }

            for (int i = 0; i < randomMake; i++)
            {
                int targetIndex = random.Next(enemies.Count);
                switch (enemies[targetIndex]) // 몬스터 리스트에 랜덤으로 받아온 몬스터들 타켓으로 찾아 추가
                {
                    case EnemyType.Minion:
                        Minion minion = new("미니언");
                        monsters.Add(minion);
                        break;
                    case EnemyType.Voidling:
                        Voidling voidling = new("공허충");
                        monsters.Add(voidling);
                        break;
                    case EnemyType.CanonMinion:
                        CanonMinion canonMinion = new("대포미니언");
                        monsters.Add(canonMinion);
                        break;
                    case EnemyType.RedGolem:
                        RedGolem redGolem = new("레드골렘");
                        monsters.Add(redGolem);
                        break;
                    case EnemyType.BlueGolem:
                        BlueGolem blueGolem = new("블루골렘");
                        monsters.Add(blueGolem);
                        break;
                    case EnemyType.Wyvern:
                        Wyvern wyvern = new("와이번");
                        monsters.Add(wyvern);
                        break;
                    case EnemyType.Diablo:
                        Diablo diablo = new("魔王 [Boss]디아블로");
                        monsters.Add(diablo);
                        break;
                }
                InitTargetMoster();
            }
        }

        // 플레이어 데미지 계산 
        public void AttackDamage(int input) 
        {
            TargetIndex = input - 1;
            TargetBeforeHp = monsters[input - 1].Hp;
            // 회피 체크
            Moving();
            if (isMoving)
            {
                Program.SceneManager.ChangeScene("AttackScene");
                return;
            }
            // 데미지 계산
            attackDamage = new Random().Next((int)Program.Character.Atk - (int)Math.Ceiling(Program.Character.Atk / 10), (int)Program.Character.Atk + (int)Math.Ceiling(Program.Character.Atk / 10));
            AttackCri(ref attackDamage);
            TargetDamage = attackDamage;
            monsters[input - 1].Hp -= attackDamage;
            // 몬스터 처치
            if (monsters[input - 1].Hp <= 0)
            {
                monsters[input - 1].MonsterDead = true;
                Program.QuestManager.ProgressQuest(0); // 몬스터 처치 퀘스트 진행도 증가
            }

            if (isMoving)
            {
                Program.SceneManager.ChangeScene("AttackScene");
                return;
            }
            else
            {
                monsters[input - 1].Hp -= attackDamage;
            }

            QuestCheack(input); // 퀘스트 체크

            Program.SceneManager.ChangeScene("AttackScene");
            // 승부가 정해질 시 전투결과 화면
            Winner = WinnerCheck(input);
            if (Winner == 1)
            {
                Program.SceneManager.ChangeScene("BattleResultScene");
            }
        }

        // 몬스터 데미지 계산
        public void EnemyAttack() 
        {
            for (int i = 0; i < monsters.Count; i++)
            {
                if (!monsters[i].MonsterDead && !Program.Character.CharacterDead)
                {
                    TargetIndex = i;
                    PlayerBeforeHp = Program.Character.Hp;
                    // 회피 체크
                    Moving();
                    if (isMoving)
                    {
                        Program.SceneManager.ChangeScene("MonsterAttackScene");
                        continue;
                    }
                    Program.Character.Hp -= ((int)monsters[i].Atk - (int)Program.Character.Def); // 몬스터의 데미지 캐릭터의 방어력 만큼 반감
                    // 플레이어 사망
                    if (Program.Character.Hp <= 0)
                    {
                        Program.Character.CharacterDead = true;
                    }
                    Program.SceneManager.ChangeScene("MonsterAttackScene");
                    // 승부가 정해질 시 전투결과 화면
                    Winner = WinnerCheck(i);
                    if (Winner == 2)
                    {
                        Program.SceneManager.ChangeScene("BattleResultScene");
                        break;
                    }
                }
            }
        }

        // 캐릭터와 몬스터 승자 체크
        public int WinnerCheck(int input)
        {
            DeadCount = 0;

            for (int i = 0; i < monsters.Count; i++)
            {
                if (monsters[i].MonsterDead)
                {
                    DeadCount++;
                }
            }

            if (DeadCount == monsters.Count)
            {
                return 1;
            }

            if (Program.Character.CharacterDead)
            {
                return 2;
            }

            return 0;
        }

        // 크리티컬 데미지(캐릭터만 적용)
        public void AttackCri(ref int damage) 
        {
            int critical = new Random().Next(1, 100);
            if (critical <= 15)
            {
                isCriticle = true;
                double cri = damage * 1.6;
                damage = (int)Math.Ceiling(cri);
            }
            else
            {
                isCriticle = false;
            }
        }

        // 회피 확률(캐릭터 몬스터 모두 적용)
        public void Moving()
        {
            int moving = new Random().Next(1, 100); 
            if (moving <= 10)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }
        }
        public void SkillDamage(int skill) // 플레이어 스킬 데미지 계산 
        {
            int input = 0;
            if (Program.Character.Job == "전사")
            {
                switch (skill)
                {
                    case 1:
                        SoloTarget = 1;
                        while (true)
                        {
                            input = Program.SkillManager.GetSkillUse(Program.BattleManager.monsters.Count(), "대상을 선택해주세요.", 1);
                            if (input == -1)
                            {
                                return;
                            }
                            else
                            {
                                break;
                            }
                        }
                        TargetIndex = input - 1;
                        TargetBeforeHp = monsters[input - 1].Hp;
                        attackDamage = (Program.Character.Level * 2) + 20;
                        skillName = "Decisive Strike";
                        Program.Character.Mp -= 5;
                        TargetDamage = attackDamage;
                        monsters[input - 1].Hp -= attackDamage;
                        QuestCheack(input);
                        break;
                    case 2:
                        Program.Character.Hp += 15;
                        skillName = "Courage";
                        Program.Character.Mp -= 5;
                        if (Program.Character.Hp >= Program.Character.MaxHp)
                        {
                            Program.Character.Hp = Program.Character.MaxHp;
                        }
                        TargetIndex = 100;
                        break;
                    case 3:
                        SoloTarget = 0;
                        attackDamage = (Program.Character.Level * 2) + 10;
                        skillName = "Judgement";
                        Program.Character.Mp -= 10;
                        TargetDamage = attackDamage;
                        for (int i = 0; i < monsters.Count; i++)
                        {
                            TargetBothIndexLevel[i] = monsters[i].Level;
                            TargetBothIndexName[i] = monsters[i].Name;
                            TargetBothIndexHp[i] = monsters[i].Hp;
                            BothTargetBeforeHp[i] = monsters[i].Hp;
                            monsters[i].Hp -= attackDamage;
                            if (monsters[i].Hp <= 0)
                            {
                                monsters[i].MonsterDead = true;
                                Program.QuestManager.ProgressQuest(0); // 몬스터 처치 퀘스트 진행도 증가
                            }
                        }
                        break;
                    case 4:
                        while (true)
                        {
                            input = Program.SkillManager.GetSkillUse(Program.BattleManager.monsters.Count(), "대상을 선택해주세요.", 1);
                            if (input == -1)
                            {
                                return;
                            }
                            else
                            {
                                break;
                            }
                        }
                        TargetIndex = input - 1;
                        SoloTarget = 1;
                        TargetBeforeHp = monsters[input - 1].Hp;
                        attackDamage = (Program.Character.Level*2) + 50;
                        skillName = "Demacian Justice";
                        Program.Character.Mp -= 30;
                        TargetDamage = attackDamage;
                        monsters[input - 1].Hp -= attackDamage;
                        QuestCheack(input);
                        break;

                }
            }

            Program.SceneManager.ChangeScene("SkillScene");

            Winner = WinnerCheck(input);
            if (Winner == 1)
            {
                Program.SceneManager.ChangeScene("BattleResultScene");
            }
        }
        public void QuestCheack(int input)
        {
            if (monsters[input-1].Hp <= 0)
            {
                monsters[input - 1].MonsterDead = true;
                Program.QuestManager.ProgressQuest(0); // 몬스터 처치 퀘스트 진행도 증가
            }
        }
        public void InitTargetMoster()
        {
            TargetBothIndexHp = new int[monsters.Count];
            TargetBothIndexLevel = new int[monsters.Count];
            TargetBothIndexName = new string[monsters.Count];
            BothTargetBeforeHp = new int[monsters.Count];
        }

    }
}
