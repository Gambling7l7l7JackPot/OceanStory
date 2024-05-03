using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory
{
    internal class Skill
    {
        public string Name { get; }
        public string Option { get; }
        public int SkillMp { get; set; }

        public Skill(string name, int skillMp, string option)
        {
            Name = name;
            Option = option;
            SkillMp = skillMp;
        }
    }
}
