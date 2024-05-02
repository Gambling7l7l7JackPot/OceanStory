using OceanStory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory.Scenes
{
    internal class AttackScene : Scene
    {
        public override void RunScene()
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("Battle!!");
                Console.WriteLine("\n{0}의 {1}", 
                    Program.Character.Name,
                    Program.BattleManager.isCriticle != true ? "공격!" : "크리티컬 공격!!");
                Console.WriteLine("Lv.{0} {1} {2} {3}]",
                    Program.BattleManager.monsters[Program.BattleManager.TargetIndex].Level,
                    Program.BattleManager.monsters[Program.BattleManager.TargetIndex].Name,
                    Program.BattleManager.isMoving != true ? "을(를) 맞췄습니다. [데미지 :" : "이(가) 회피했습니다. [데미지 :",
                    Program.BattleManager.TargetDamage);
                Console.WriteLine("\nLv.{0} {1}",
                    Program.BattleManager.monsters[Program.BattleManager.TargetIndex].Level,
                    Program.BattleManager.monsters[Program.BattleManager.TargetIndex].Name);
                Console.WriteLine("HP {0} -> {1}",
                    Program.BattleManager.TargetBeforeHp,
                    Program.BattleManager.monsters[Program.BattleManager.TargetIndex].MonsterDead ?
                    "Dead" : Program.BattleManager.monsters[Program.BattleManager.TargetIndex].Hp);
                Console.WriteLine("\n0. 다음");
                int input = Program.SceneManager.GetUserInput(0);
                if (input == 0)
                {
                    Program.BattleManager.EnemyAttack();
                    break;
                }
            }
        }
    }
}
