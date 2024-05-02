using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory
{
    internal class SkillManager
    {
        public List<Skill> skillList = new List<Skill>();
        public void WarriorSkill()
        {
            skillList.Add(new Skill("도란검", "굵고 짧은 검"));
            skillList.Add(new Skill("도란링", "마법의 힘이 담긴 반지"));
            skillList.Add(new Skill("천갑옷", "천으로 만들어진 갑옷"));
            skillList.Add(new Skill("적응형투구", "적응 하라고 만든 투구"));
        }
        public void WizardSkill()
        {
            skillList.Add(new Skill("도란검", "굵고 짧은 검"));
            skillList.Add(new Skill("도란링", "마법의 힘이 담긴 반지"));
            skillList.Add(new Skill("천갑옷", "천으로 만들어진 갑옷"));
            skillList.Add(new Skill("적응형투구", "적응 하라고 만든 투구"));
        }
        public void CharacterSkillList()
        {
            
        }
    }
}
