using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory.Scenes
{
    internal class MonsterAttackScene : Scene
    {
        public override void RunScene()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Battle!!");
                Console.WriteLine("\nLv.{0} {1} 의 공격!", Program.BattleManager.monsters[Program.BattleManager.TargetIndex].Level,
                    Program.BattleManager.monsters[Program.BattleManager.TargetIndex].Name);
                Console.WriteLine("{0} 을(를) 맞췄습니다. [데미지 : {1}]",
                    Program.Character.Name,
                    Program.BattleManager.monsters[Program.BattleManager.TargetIndex].Atk);
                Console.WriteLine("\nLv.{0} {1}",
                    Program.Character.Level,
                    Program.Character.Name);
                Console.WriteLine("HP {0} -> {1}",
                    Program.BattleManager.PlayerBeforeHp,
                    Program.Character.CharacterDead ?
                    "Dead" : Program.Character.Hp);
                Console.WriteLine("\n0. 다음");
                int input = Program.SceneManager.GetUserInput(0);
                if (input == 0) return;
            }
        }
    }
}
