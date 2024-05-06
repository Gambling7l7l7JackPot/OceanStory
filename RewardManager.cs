namespace OceanStory
{
    // 경험치나 레벨업 관리 매니저
    internal class RewardManager
    {
        public int[] LevelFull = new int[100]; // 최대 레벨
        public void MakeLevel()
        {
            for (int i = 0; i < LevelFull.Length; i++)
            {
                LevelFull[i] = (i+(i+1)) * 10;
            }
        }
        // 경험치 증가
        public int CharacterExpUp()
        {
            int beforeExp = Program.Character.Exp;
            foreach(var monster in Program.BattleManager.monsters)
            {
                Program.Character.Exp += monster.Exp;
            }
            return beforeExp;
        }
        public int CharacterGoldUp() // 몬스터 경험치를 통한 캐릭터 경험치 추가
        {
            int beforeGold = Program.Character.Gold;
            foreach (var monster in Program.BattleManager.monsters)
            {
                Program.Character.Gold += monster.Gold;
            }
            return beforeGold;
        }
        // 레벨업 가능 여부 체크
        public int CharacterLevelUpCheck() 
        {
            int beforeLevel = Program.Character.Level;
            while (LevelFull[Program.Character.Level - 1] <= Program.Character.Exp)
            {
                Program.Character.Exp -= LevelFull[Program.Character.Level - 1];
                CharacterLevelUp();
            }
            return beforeLevel;
        }

        // 레벨업 (스탯 증가 등)
        public void CharacterLevelUp()
        {
            if (Program.Character.Job == "전사")
            {
                Program.Character.MaxHp += 10;
                Program.Character.Atk += 2.0f;
                Program.Character.Def += 1;
                Program.Character.Level += 1;
                Program.Character.MaxMp += 5;
                Program.QuestManager.ProgressQuest(2); // 레벨업 증가 퀘스트 진행도 증가
                Program.QuestManager.ProgressQuest(3); // 레벨업 증가 퀘스트 진행도 증가
            }
            else
            {
                Program.Character.MaxHp += 5;
                Program.Character.Atk += 0.5f;
                Program.Character.Def += 1;
                Program.Character.Level += 1;
                Program.Character.MaxMp += 10;
                Program.QuestManager.ProgressQuest(2); // 레벨업 증가 퀘스트 진행도 증가
                Program.QuestManager.ProgressQuest(3); // 레벨업 증가 퀘스트 진행도 증가
            }
        }
    }
}
