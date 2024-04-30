using OceanStory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory.Scenes
{
    internal class AttackDamageScene
    {
        public void AttackDamage(List<IMonster> monsters, int input)
        {
            if (input == 1)
            {
                double monstersHp = monsters[0].MaxHp;
                int attackDamage = new Random().Next((int)Program.Character.Atk - (int)Math.Ceiling(monstersHp / Program.Character.Atk), (int)Program.Character.Atk + (int)Math.Ceiling(monstersHp / Program.Character.Atk));
                Program.Character.SetAttackDamage(attackDamage);
            }
            else if (input == 2)
            {
                double monstersHp = monsters[1].MaxHp;
                int attackDamage = new Random().Next((int)Program.Character.Atk - (int)Math.Ceiling(monstersHp / Program.Character.Atk), (int)Program.Character.Atk + (int)Math.Ceiling(monstersHp / Program.Character.Atk));
                Program.Character.SetAttackDamage(attackDamage);
            }
            else if (input == 3)
            {
                double monstersHp = monsters[2].MaxHp;
                int attackDamage = new Random().Next((int)Program.Character.Atk - (int)Math.Ceiling(monstersHp / Program.Character.Atk), (int)Program.Character.Atk + (int)Math.Ceiling(monstersHp / Program.Character.Atk));
                Program.Character.SetAttackDamage(attackDamage);
            }
        }
    }
}
