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
                        RedGolem redGolem = new("레드 골렘");
                        monsters.Add(redGolem);
                        break;
                    case EnemyType.BlueGolem:
                        BlueGolem blueGolem = new("블루 골렘");
                        monsters.Add(blueGolem);
                        break;
                    case EnemyType.Wyvern:
                        Wyvern wyvern = new("와이번");
                        monsters.Add(wyvern);
                        break;
                    case EnemyType.Diablo:
                        Diablo diablo = new("魔王 [Boss] 디아블로");
                        monsters.Add(diablo);
                        break;
                }
            }
        }
        public void AttackDamage(int input)
        {
            TargetIndex = input - 1;
            TargetBeforeHp = monsters[input - 1].Hp;
            double monstersHp = monsters[input - 1].MaxHp;
            int attackDamage = new Random().Next((int)Program.Character.Atk - (int)Math.Ceiling(monstersHp / Program.Character.Atk), (int)Program.Character.Atk + (int)Math.Ceiling(monstersHp / Program.Character.Atk));
            TargetDamage = attackDamage;
            monsters[input - 1].Hp -= attackDamage;
            if (monsters[input - 1].Hp <= 0)
            {
                monsters[input - 1].MonsterDead = true;
            }
            Program.SceneManager.ChangeScene("AttackScene");
            Winner = WinnerCheck(input);
            if (Winner == 1)
            {
                Program.SceneManager.ChangeScene("BattleResultScene");
            }
        }

        public void EnemyAttack()
        {
            for (int i = 0; i < monsters.Count; i++)
            {
                if (!monsters[i].MonsterDead && !Program.Character.CharacterDead)
                {
                    TargetIndex = i;
                    PlayerBeforeHp = Program.Character.Hp;
                    Program.Character.Hp -= (int)monsters[i].Atk;
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

        public int WinnerCheck(int input)
        {
            DeadCount = 0;

            for (int i = 0;i < monsters.Count;i++)
            {
                if (monsters[i].MonsterDead)
                {
                    DeadCount++;
                }
            }

            if( DeadCount == monsters.Count) 
            {
                return 1;
            }

            if (Program.Character.CharacterDead)
            {
                return 2;
            }

            return 0;
        }
    }
}
