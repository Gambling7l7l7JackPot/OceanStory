using OceanStory.Objects;

namespace OceanStory.Scenes
{
    // 퀘스트 정보 화면
    internal class QuestDetailScene : Scene
    {
        public override void RunScene()
        {
            // 전역 변수 반복 접근을 줄이기 위한 변수
            List<Quest> questList = Program.QuestManager.QuestList;
            int questIndex = Program.QuestManager.QuestIndex;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Quest!!\n");
                Console.WriteLine(questList[questIndex].QuestName + "\n");
                Console.WriteLine(questList[questIndex].Description + "\n");
                Console.WriteLine("- {0} ({1}/{2})\n",
                    questList[questIndex].QuestObjective,
                    questList[questIndex].QuestProgressCount,
                    questList[questIndex].QuestObjectiveCount);
                Console.WriteLine("- 보상");
                // 보상 아이템 리스트 표시
                foreach(Item reward in questList[questIndex].QuestRewardItem)
                {
                    Console.WriteLine(reward.Name);
                }
                Console.WriteLine("{0} G", questList[questIndex].QuestRewardGold);

                // 퀘스트가 완료 상태라면
                if (questList[questIndex].IsCleared)
                {
                    Console.WriteLine("\n완료된 퀘스트입니다.");
                    Console.WriteLine("\n0. 뒤로 가기");
                    int input = Program.SceneManager.GetUserInput(0);
                    if (input == 0) break;
                }
                else
                {
                    // 퀘스트가 진행 중이 아니라면
                    if (!questList[questIndex].IsAccepted)
                    {
                        Console.WriteLine("\n1. 수락\n2. 거절");
                        int input = Program.SceneManager.GetUserInput(2);
                        if (input == 1)
                            questList[questIndex].IsAccepted = true;
                        break;
                    }
                    // 퀘스트가 진행 중이라면
                    else
                    {
                        Console.WriteLine("\n현재 진행중인 퀘스트입니다.");
                        Console.WriteLine("\n0. 뒤로 가기");
                        int input = Program.SceneManager.GetUserInput(0);
                        if (input == 0) break;
                    }
                }
                
            }
        }
    }
}
