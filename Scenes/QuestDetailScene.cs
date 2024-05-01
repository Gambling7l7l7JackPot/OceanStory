using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OceanStory.Scenes
{
    internal class QuestDetailScene : Scene
    {
        public override void RunScene()
        {
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
                    questList[questIndex].QuestClearedCount,
                    questList[questIndex].QuestObjectiveCount);
                Console.WriteLine("- 보상");
                foreach(Item reward in questList[questIndex].QuestRewards)
                {
                    Console.WriteLine(reward);
                }
                Console.WriteLine("\n1. 수락\n2. 거절");
                int input = Program.SceneManager.GetUserInput(2);
                if (input == 1)
                    questList[questIndex].IsAccepted = true;
                break;
            }
        }
    }
}
