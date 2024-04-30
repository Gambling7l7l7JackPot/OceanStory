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
        public double TargetBeforeHp;

        public void MakeEnemy()
        {
            monsters.Clear();
            Random random = new Random();
            
            int randomMake = new Random().Next(1, 5);
            for (int i = 0; i < randomMake; i++)
            {
                int makeMonsters = random.Next(1, 4);
                switch (makeMonsters)
                {
                    case 1:
                        Minion minion = new("미니언");
                        monsters.Add(minion);
                        break;
                    case 2:
                        Voidling voidling = new("공허충");
                        monsters.Add(voidling);
                        break;
                    case 3:
                        CanonMinion canonMinion = new("대포미니언");
                        monsters.Add(canonMinion);
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
            if (monsters[input - 1].Hp <= 0) monsters[input - 1].MonsterDead = true;
        }
    }
}
