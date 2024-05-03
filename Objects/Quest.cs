namespace OceanStory.Objects
{
    internal class Quest
    {
        public string QuestName { get; set; }               // 퀘스트 제목
        public string Description { get; set; }             // 퀘스트 설명
        public string QuestObjective { get; set; }          // 퀘스트 수행조건
        public int QuestObjectiveCount { get; set; }        // 퀘스트 목표 진행도
        public int QuestProgressCount { get; set; }         // 퀘스트 현재 진행도
        public List<Item>? QuestRewardItem { get; set; }    // 퀘스트 완료시 보상 아이템 리스트
        public int QuestRewardGold { get; set; }           // 퀘스트 완료시 보상 골드
        public bool IsAccepted { get; set; }               // 퀘스트 진행 중 여부
        public bool IsCleared { get; set; }                 // 퀘스트 완료 여부

        public Quest(string questName, string description, string questObjective, int questObejctiveCount, int questProgressCount, List<Item> questRewardItem, int questRewardGold)
        {
            QuestName = questName;
            Description = description;
            QuestObjective = questObjective;
            QuestObjectiveCount = questObejctiveCount;
            QuestProgressCount = questProgressCount;
            QuestRewardItem = questRewardItem;
            QuestRewardGold = questRewardGold;
            IsAccepted = false;
            IsCleared = false;
        }
    }
}
