using OceanStory.Objects;

namespace OceanStory.Scenes
{
    // 퀘스트 화면
    internal class QuestScene : Scene
    {
        public override void RunScene()
        {
            List<Quest> questList = Program.QuestManager.QuestList;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Quest!!\n");
                // 퀘스트 리스트 표시
                if (questList != null)
                {
                    for (int i = 0; i < questList.Count(); i++)
                    {
                        Console.WriteLine("{1}. {0}{2}", questList[i].IsCleared?"[완]":"", i + 1, questList[i].QuestName);
                    }
                }
                Console.WriteLine("\n0. 돌아가기");
                // 퀘스트 선택 입력 받기
                int input = Program.SceneManager.GetUserInput(questList.Count(), "원하시는 퀘스트를 선택해주세요", 0);
                Program.QuestManager.QuestIndex = input - 1;
                if (input == 0 || input == -1) return;
                // 입력받은 퀘스트 정보 화면으로 이동
                else Program.SceneManager.ChangeScene("QuestDetailScene");
            }
        }
    }
}
