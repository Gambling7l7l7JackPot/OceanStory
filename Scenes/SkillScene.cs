using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory.Scenes
{
    internal class SkillScene : Scene
    {
        public override void RunScene()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Battle!!");
                Console.WriteLine("\n{0}의 {1}!!", Program.Character.Name,Program.BattleManager.skillName);
                if (Program.BattleManager.TargetIndex == 100)
                {
                    Console.WriteLine($"\n플레이어의 체력이 회복되었습니다. 현재 체력 : {Program.Character.Hp}");
                    Console.WriteLine("\n0. 다음");
                    int getOut = Program.SceneManager.GetUserInput(0);
                    if (getOut == 0)
                    {
                        Program.BattleManager.EnemyAttack();
                        break;
                    }
                }
                if (Program.BattleManager.SoloTarget == 1)
                {
                    Program.ColorManager.CheckName(Program.BattleManager.TargetIndex);
                    Console.WriteLine("Lv.{0} {1} 을(를) 맞췄습니다. [데미지 :{2}]",
                        Program.BattleManager.monsters[Program.BattleManager.TargetIndex].Level,
                        Program.BattleManager.monsters[Program.BattleManager.TargetIndex].Name,
                        Program.BattleManager.TargetDamage);
                    Program.ColorManager.ColorText(0);
                    Console.WriteLine("\nLv.{0} {1}",
                        Program.BattleManager.monsters[Program.BattleManager.TargetIndex].Level,
                        Program.BattleManager.monsters[Program.BattleManager.TargetIndex].Name);
                    Console.WriteLine("HP {0} -> {1}",
                        Program.BattleManager.TargetBeforeHp,
                        Program.BattleManager.monsters[Program.BattleManager.TargetIndex].MonsterDead ?
                        "Dead" : Program.BattleManager.monsters[Program.BattleManager.TargetIndex].Hp);
                    Console.WriteLine("\n0. 다음");
                }
                else
                {
                    for (int i = 0; i < Program.BattleManager.monsters.Count; i++)
                    {
                        if (Program.BattleManager.monsters[i].MonsterDead)
                        {
                            continue;
                        }
                        Program.ColorManager.CheckName(i);
                        Console.WriteLine("\nLv.{0} {1} 을(를) 맞췄습니다. [데미지 :{2}]",
                        Program.BattleManager.monsters[i].Level,
                        Program.BattleManager.monsters[i].Name,
                        Program.BattleManager.TargetDamage);
                        Program.ColorManager.ColorText(0);
                        Console.WriteLine("HP {0} -> {1}\n",
                        Program.BattleManager.BothTargetBeforeHp[i],
                        Program.BattleManager.monsters[i].MonsterDead ?
                        "Dead" : Program.BattleManager.monsters[i].Hp);
                    }
                    Console.WriteLine("\n0. 다음");
                }
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
