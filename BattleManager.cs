using OceanStory.Interfaces;
using OceanStory.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace OceanStory
{
    internal class BattleManager
    {
        public List<IMonster> monsters = new List<IMonster>();
        public int TargetIndex, TargetDamage;
        public double TargetBeforeHp, PlayerBeforeHp, PlayerStartHp;
        public int Winner, DeadCount;
        public int attackDamage;
        public bool isMoving = false;
        public bool isCriticle = false;
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
        public void MakeEnemy(int Cave)
        {
            PlayerStartHp = Program.Character.Hp;
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
            }
        }
        public void AttackDamage(int input) // 플레이어 데미지 계산 
        {
            TargetIndex = input - 1;
            TargetBeforeHp = monsters[input - 1].Hp;
            Moving();
            if (isMoving)
            {
                Program.SceneManager.ChangeScene("AttackScene");
                return;
            }

            double monstersHp = monsters[input - 1].MaxHp;
            attackDamage = new Random().Next((int)Program.Character.Atk - (int)Math.Ceiling(Program.Character.Atk / 10), (int)Program.Character.Atk + (int)Math.Ceiling(Program.Character.Atk / 10));
 
            AttackCri(ref attackDamage);
            monsters[input - 1].Hp -= attackDamage;

            if (monsters[input - 1].Hp <= 0)
            {
                monsters[input - 1].MonsterDead = true;
            }

            TargetDamage = attackDamage;
            Program.SceneManager.ChangeScene("AttackScene");
            Winner = WinnerCheck(input);
            if (Winner == 1)
            {
                Program.SceneManager.ChangeScene("BattleResultScene");
            }
        }

        public void EnemyAttack() // 몬스터 데미지 계산
        {
            for (int i = 0; i < monsters.Count; i++)
            {
                if (!monsters[i].MonsterDead && !Program.Character.CharacterDead)
                {
                    TargetIndex = i;
                    PlayerBeforeHp = Program.Character.Hp;
                    Moving();
                    if (isMoving)
                    {
                        Program.SceneManager.ChangeScene("MonsterAttackScene");
                        continue;
                    }
                    Program.Character.Hp -= ((int)monsters[i].Atk - (int)Program.Character.Def); // 몬스터의 데미지 캐릭터의 방어력 만큼 반감
                    if (Program.Character.Hp <= 0)
                    {
                        Program.Character.CharacterDead = true;
                    }
                    Program.SceneManager.ChangeScene("MonsterAttackScene");
                    Winner = WinnerCheck(i);
                    if (Winner == 2)
                    {
                        Program.SceneManager.ChangeScene("BattleResultScene");
                        break;
                    }
                }
            }
        }

        public int WinnerCheck(int input) // 캐릭터와 몬스터 승자 체크
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
        public void AttackCri(ref int damage) // 크리티컬 데미지 캐릭터만 적용
        {
            int critical = new Random().Next(1, 30);
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
        public void Moving() // 회피 확률 캐릭터 몬스터 모두 적용
        {
            int moving = new Random().Next(1, 30); 
            if (moving <= 10)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }
        }
    }
}
