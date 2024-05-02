using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory
{
    internal class RewardManager
    {
        public void CharacterLevelUp() // 캐릭터 레벨업 스텟
        {
            Program.Character.MaxHp += 5;
            Program.Character.Atk += 0.5f;
            Program.Character.Def += 1;
            Program.Character.Level += 1;
            Program.Character.Mp += 5;
            Program.QuestManager.ProgressQuest(2); // 레벨업 증가 퀘스트 진행도 증가
        }
        public int CharacterExpUp() // 몬스터 경험치를 통한 캐릭터 경험치 추가
        {
            int beforeExp = Program.Character.Exp;
            foreach(var monster in Program.BattleManager.monsters)
            {
                Program.Character.Exp += monster.Exp;
            }
            return beforeExp;
        }
        public int CharacterLevelUpCheck() // 캐릭터가 레벨업 했는지 확인하는 메서드
        {
            int beforeLevel = Program.Character.Level;
            int[] RequiredExp = { 10, 35, 65, 100 };
            while (RequiredExp[Program.Character.Level - 1] <= Program.Character.Exp)
            {
                Program.Character.Exp -= RequiredExp[Program.Character.Level - 1];
                CharacterLevelUp();
            }
            return beforeLevel;
        }
    }
}
