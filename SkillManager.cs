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
        public List<string> getMonster = new List<string>();
        public void WarriorSkill()
        {
            skillList.Add(new Skill("[1] Decisive Strike  ㅣ 마나 :",5 , "  ㅣ  검에 기를 모아 적을 내려친다"));
            skillList.Add(new Skill("[2] Courage          ㅣ 마나 :",5 , "  ㅣ  데마시아의 가호를 통해 체력을 15 회복한다"));
            skillList.Add(new Skill("[3] Judgement        ㅣ 마나 :",10, " ㅣ  빙글빙글 돌며 여러적에게 타격을 준다 "));
            skillList.Add(new Skill("[4] Demacian Justice ㅣ 마나 :",30, " ㅣ  데마시아의 힘을 받아 큰 데미지를 준다 "));
        }
        public void WizardSkill()
        {
            skillList.Add(new Skill("[1] Light Binding      ㅣ 마나 :", 10, " ㅣ  빛의 힘으로 적에게 공격을 한다"));
            skillList.Add(new Skill("[2] Prismatic Barrier  ㅣ 마나 :", 10, " ㅣ  빛의 가호를 통해 체력을 20 회복한다"));
            skillList.Add(new Skill("[3] Lucent Singularity ㅣ 마나 :", 20, " ㅣ  빛의 구체를 발사하여 두명의 적에게 타격을 준다 "));
            skillList.Add(new Skill("[4] Final Spark        ㅣ 마나 :", 50, " ㅣ  눈부신 광선을 발사하여 앞에 있는 모든 적에게 데미지를 준다 "));
        }
        public void CharacterSkillList()
        {
            Console.WriteLine("[Skill]\n");
            foreach (Skill skill in skillList)
            {
                Program.ColorManager.ColorText(3);
                Console.WriteLine($"{skill.Name}{skill.SkillMp}{skill.Option}");
                Program.ColorManager.ColorText(0);
            }
        }
        public int GetSkillInput(int maxNum)
        {
            Program.SystemMessage.PrintMessage();
            Console.Write("\n사용할 스킬을 입력해주세요. \n>> ");
            string s = Console.ReadLine();
            int input = -1;
            bool b = int.TryParse(s, out input);
            if (b && (0 <= input && input <= maxNum))
            {
                return input;
            }
            else
            {
                Program.SystemMessage.SetMessage("잘못된 입력입니다.");
                return -1;
            }
        }
        public int GetSkillUse(int maxNum, string message, int error)
        {
            Program.SystemMessage.PrintMessage();
            Console.Write("\n" + message + "\n>> ");
            string s = Console.ReadLine();
            int input = -1;
            bool b = int.TryParse(s, out input);
            if (error == 1 && input > 0 && Program.BattleManager.monsters[input - 1].MonsterDead)
            {
                Program.SystemMessage.SetMessage("이미 죽은 몬스터입니다.");
                return -1;
            }
            if (b && (0 <= input && input <= maxNum))
            {
                if (!getMonster.Contains(Program.BattleManager.monsters[input - 1].Name))
                {
                    getMonster.Add(Program.BattleManager.monsters[input - 1].Name);
                    getMonster.Add(Program.BattleManager.monsters[input - 1].Name);
                    getMonster.Add(Program.BattleManager.monsters[input - 1].Name);

                }
                else
                {
                    Program.SystemMessage.SetMessage("이미 선택한 몬스터입니다.");
                }
                return input;
            }
            else
            {
                Program.SystemMessage.SetMessage("잘못된 입력입니다.");
                return -1;
            }
        }
    }
}
