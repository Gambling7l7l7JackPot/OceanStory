using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory.Scenes
{
    internal class StatusScene : Scene
    {
        public override void RunScene()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("상태 보기");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.");
                Console.WriteLine($"Lv. {Program.Character.Level.ToString("D2")}");
                Console.WriteLine($"{Program.Character.Name} ( {Program.Character.Job} )");
                Console.WriteLine($"공격력 : {Program.Character.Atk} (+{Program.Character.AtkBonus})");
                Console.WriteLine($"방어력 : {Program.Character.Def} (+{Program.Character.DefBonus})");
                Console.WriteLine($"체 력  : {Program.Character.Hp}");
                Console.WriteLine($"Gold   : {Program.Character.Gold} G");
                Console.WriteLine($"Exp    : {Program.Character.Exp}");
                Console.WriteLine("");
                Console.WriteLine("0. 나가기");

                switch (Program.SceneManager.GetUserInput(1))
                {
                    case 0:
                        return;
                    case 1:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
