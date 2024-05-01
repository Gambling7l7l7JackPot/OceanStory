using OceanStory.Interfaces;
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
                    int beforeExp = Program.RewardManager.CharacterExpUp();
                    int beforeLevel = Program.RewardManager.CharacterLevelUpCheck();
                    Console.WriteLine("\nVictory");
                    Console.WriteLine("\n던전에서 몬스터 {0}마리를 잡았습니다.", Program.BattleManager.monsters.Count());
                    Console.WriteLine("\n[캐릭터 정보]");
                    Console.WriteLine("Lv.{0} {1} -> Lv.{2} {3}", beforeLevel, Program.Character.Name, Program.Character.Level, Program.Character.Name);
                    Console.WriteLine("HP {0} -> {1}", Program.BattleManager.PlayerStartHp, Program.Character.Hp);
                    Console.WriteLine("Exp {0} -> {1}", beforeExp, Program.Character.Exp);
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
