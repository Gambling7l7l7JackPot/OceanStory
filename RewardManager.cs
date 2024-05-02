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


        //public float EquippedAtkCaseOne() // 1. 아이템을 장착하는경우
        //{
        //    float getAtkBonus = Program.Character.Atk;

        //    foreach (var equippedItem in Program.Inventory.equipList)
        //    {
        //        if (equippedItem.Atk != null)
        //        {
        //            Program.Character.Atk += equippedItem.Atk.Value;
        //        }
        //    }

        //    return getAtkBonus;
        //}

        //public float EquippedAtkCaseTwo() // 2. 이미 장착했던걸 해제하는경우
        //{
        //    float setAtkBonus = Program.RewardManager.EquippedAtkCaseOne(); // 아이템 장착 시 증가된 공격력을 미리 계산하여 저장

        //    Program.Character.Atk -= setAtkBonus; // 저장된 증가된 공격력을 다시 빼줌

        //    return setAtkBonus;
        //}

        //public void EquippedAtkCaseThree() // 3. 다른 타입을 사용하게 되는경우
        //{

        //}
    }
}
