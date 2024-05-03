using OceanStory.Objects;
using System.Text.Json.Serialization;

namespace OceanStory
{
    // 퀘스트 관련 매니저
    internal class QuestManager
    {
        [JsonInclude]
        public int QuestIndex = 0;                                      // 외부에서 퀘스트 리스트 접근을 위한 인덱스
        [JsonInclude]
        public List<Quest> QuestList = new List<Quest>();               // 퀘스트 리스트
        [JsonInclude]
        public List<Item>[] QuestRewardItemList = new List<Item>[3];    // 퀘스트 보상 아이템 리스트

        public QuestManager()
        {
            for (int i = 0; i < 3; i++)
            {
                QuestRewardItemList[i] = new List<Item>();
            }

            QuestRewardItemList[0].Add(new Item("낡은 검", "마을 주민이 미니언을 잡아준 대가로 선물한 검이다.", 10, null, ItemType.WEAPON));
            QuestRewardItemList[1].Add(new Item("튼튼해보이는 옷", "못 입고 다니는 게 안타까웠던 주민이 선물한 옷이다.", null, 10, ItemType.ARMOR));

            QuestList.Add(new Quest("마을을 위협하는 미니언 처치", "이봐! 마을 근처에 미니언들이 너무 많아졌다고 생각하지 않나?\n" +
                "마을 주민의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고!\n" +
                "모험가인 자네가 좀 처치해주게!", "미니언 5마리 처치", 5, 0, QuestRewardItemList[0], 100));
            QuestList.Add(new Quest("장비를 장착해보자", "떼잉, 쯔쯧... 그렇게 약해빠진 장비를 가지고서 미니언이나 잡겠나?\n" +
                "좀 더 반듯한 장비를 마련해서 오라고!", "새로운 장비 아무거나 1개 장착", 1, 0, QuestRewardItemList[1], 100));
            QuestList.Add(new Quest("더욱 더 강해지기!", "무언갈 지키기 위해선 강해져야 하는 법이지.\n" +
                "몬스터를 사냥하고 지금보다 레벨을 올려서 오게나.", "현재보다 레벨 2 증가", 2, 0, QuestRewardItemList[2], 500));
        }

        // 퀘스트 진행도 증가
        public void ProgressQuest(int QuestIndex)
        {
            if (QuestList[QuestIndex].IsAccepted) // 퀘스트가 진행 중 상태이면
            {
                QuestList[QuestIndex].QuestProgressCount++; // 퀘스트 진행도 1 증가
                if (QuestList[QuestIndex].QuestProgressCount >= QuestList[QuestIndex].QuestObjectiveCount) // 목표 진행도에 도달하면 퀘스트 완료
                {
                    ClearQuest(QuestIndex);
                }
            }
        }

        // 퀘스트 완료
        public void ClearQuest(int QuestIndex)      
        {
            foreach (Item questRewardItem in QuestList[QuestIndex].QuestRewardItem) // 보상 아이템 지급
            {
                Program.Inventory.itemList.Add(questRewardItem);
            }
            Program.Character.Gold += QuestList[QuestIndex].QuestRewardGold; // 보상 골드 지급
            QuestList[QuestIndex].IsAccepted = false; // 퀘스트 진행중 -> 완료 표시
            QuestList[QuestIndex].IsCleared = true;
        }
    }
}
