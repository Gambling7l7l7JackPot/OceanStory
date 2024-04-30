using OceanStory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory
{
    internal class BattleManager
    {
        public void AttackDamage(List<IMonster> monsters, int input)
        {
            double monstersHp = monsters[input - 1].MaxHp;
            int attackDamage = new Random().Next((int)Program.Character.Atk - (int)Math.Ceiling(monstersHp / Program.Character.Atk), (int)Program.Character.Atk + (int)Math.Ceiling(monstersHp / Program.Character.Atk));
            monsters[input - 1].GetDamage(attackDamage);
        }
    }
}
