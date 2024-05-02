using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory
{
    internal class Warrior : Character
    {
        public Warrior(string name, string job, float atk, float def, int hp, int maxHp, int mp, int maxMp) : base(name, job, atk, def, hp, maxHp, mp, maxMp)
        {
            Job = "전사";
        }
    }
}
