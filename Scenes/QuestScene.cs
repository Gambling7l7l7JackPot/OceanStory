using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory.Scenes
{
    internal class QuestScene : Scene
    {
        public override void RunScene()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Quest!!\n");
                if (Program.QuestManager.QuestList != null)
                {
                    for (int i = 0; i < Program.QuestManager.QuestList.Count(); i++)
                    {
                        Console.WriteLine("{0}. {1}", i + 1, Program.QuestManager.QuestList[i].QuestName);
                    }
                }
                int input = Program.SceneManager.GetUserInput(Program.QuestManager.QuestList.Count(), "원하시는 퀘스트를 선택해주세요", 0);
                Program.QuestManager.QuestIndex = input - 1;
                if (input == 0) return;
                else Program.SceneManager.ChangeScene("QuestDetailScene");
            }
        }
    }
}
