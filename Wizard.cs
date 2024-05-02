using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory
{
    internal class Wizard : Character
    {
        public Wizard(string name, string job, float atk, float def, int hp, int maxHp, int mp, int maxMp) : base(name, job, atk, def, hp, maxHp, mp, maxMp)
        {
            Job = "마법사";
        }
    }
}
