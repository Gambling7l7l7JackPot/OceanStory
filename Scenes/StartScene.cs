using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory.Scenes
{
    internal class StartScene : Scene
    {

        public override void RunScene()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.\n이제 전투를 시작할 수 있습니다.");
                Console.WriteLine("\n1. 상태 보기\n2. 전투 시작\n3. 체력 회복");
                int input = Program.SceneManager.GetUserInput(3);
                switch (input)
                {
                    case 1:
                        Program.SceneManager.ChangeScene("StatusScene");
                        break;
                    case 2:
                        Program.SceneManager.ChangeScene("BattleScene");
                        break;
                    case 3:
                        Program.Character.Hp = Program.Character.MaxHp;
                        Program.Character.CharacterDead = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
