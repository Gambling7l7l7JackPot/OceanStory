using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory
{
    internal class Warrior : Character
    {

        public Warrior(int level, string name, string job, float atk, float def, int hp, int maxHp, int gold, int exp) : base(level, name, job, atk, def, hp, maxHp, gold, exp)
        {
            Job = "전사";
        }
    }
}
