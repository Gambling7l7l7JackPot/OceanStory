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
                Console.WriteLine("\n1. 상태 보기\n2. 전투 시작\n3. 체력 회복\n4. 인벤토리\n5. 퀘스트\n\n0. 게임 종료");
                int input = Program.SceneManager.GetUserInput(5);
                switch (input)
                {
                    case 0:
                        return;
                    case 1:
                        Program.SceneManager.ChangeScene("StatusScene");
                        break;
                    case 2:
                        if (Program.Character.Hp <= 0)
                        {
                            Console.WriteLine("\n체력이 없습니다! 체력을 회복해주세요. ");
                            Thread.Sleep(2000);
                            break ;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("들어갈 던전을 선택해주세요. \n별 갯수에 따라 난이도가 변경 됩니다.\n ");
                            Console.WriteLine("[★☆☆☆☆] 1. 스파르타의 신전 \n");
                            Console.WriteLine("[★★☆☆☆] 2. 고뇌의 분수     \n");
                            Console.WriteLine("[★★★☆☆] 3. 마감의 감옥     \n");
                            Console.WriteLine("[★★★★☆] 4. 천국의 계단     \n");
                            Console.WriteLine("[★★★★★] 5. 메니저님의 방   \n");
                            Program.SceneManager.ChangeScene("BattleScene");
                            break;
                        }
                    case 3:
                        Program.Character.Hp = Program.Character.MaxHp;
                        Program.Character.CharacterDead = false;
                        Console.WriteLine("\n체력이 회복됩니다.");
                        Thread.Sleep(1000);
                        break;
                    case 4:
                        Program.Inventory.Check();
                        break;
                    case 5:
                        Program.SceneManager.ChangeScene("QuestScene");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
