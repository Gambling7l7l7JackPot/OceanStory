using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory
{
    internal class SceneManager
    {
        public SceneManager() { }

        public void ChangeScene(string sceneName)
        {
            Type sceneType = Type.GetType("OceanStory.Scenes." + sceneName);
            object obj = Activator.CreateInstance(sceneType);
        }
        public int GetUserInput(int maxNum)
        {
            Program.SystemMessage.PrintMessage();
            Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
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
    }
}
