using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory
{
    internal class Wizard : Character
    {
        public Wizard(int level, string name, string job, float atk, float def, int hp, int maxHp, int gold) : base(level, name, job, atk, def, hp, maxHp, gold)
        {
            Job = "마법사";
        }
    }
}
