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

        public Skill(string name, string option)
        {
            this.Name = name;
            this.Option = option;
        }
    }
}
