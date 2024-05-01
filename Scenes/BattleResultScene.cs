using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory.Scenes
{
    internal class BattleResultScene : Scene
    {
        public override void RunScene()
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("Battle!! - Result");
                if (Program.BattleManager.Winner == 1)
                {
                    Console.WriteLine("\nVictory");
                    Console.WriteLine("\n던전에서 몬스터 {0}마리를 잡았습니다.", Program.BattleManager.monsters.Count());
                    Console.WriteLine("\nLv.{0} {1}", Program.Character.Level, Program.Character.Name);
                    Console.WriteLine("HP {0} -> {1}", Program.Character.MaxHp, Program.Character.Hp);
                }
                else
                {
                    Console.WriteLine("\nYou Lose");
                    Console.WriteLine("\nLv.{0} {1}", Program.Character.Level, Program.Character.Name);
                    Console.WriteLine("HP {0} -> {1}", Program.Character.MaxHp, "0");
                }
                Console.WriteLine("\n0. 다음");
                int input = Program.SceneManager.GetUserInput(1);
                if(input == 0) return;
            }
        }
    }
}
