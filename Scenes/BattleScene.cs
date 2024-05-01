using OceanStory.Interfaces;
using OceanStory.Monsters;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace OceanStory.Scenes
{
    internal class BattleScene : Scene
    {
        public override void RunScene()
        {
            bool select = false;
            Program.BattleManager = new BattleManager();
            Program.BattleManager.MakeEnemy();

            while (true)
            {
                if (Program.BattleManager.Winner != 0)
                {
                    return;
                }
                Console.Clear();
                Console.WriteLine("Battle!!");
                Console.WriteLine("");
                for (int i = 0; i < Program.BattleManager.monsters.Count(); i++)
                {
                    Console.WriteLine("{0} Lv.{1} {2} {3}",select? "[" + (i + 1).ToString() + "]": "",
                        Program.BattleManager.monsters[i].Level,
                        Program.BattleManager.monsters[i].Name,
                        Program.BattleManager.monsters[i].MonsterDead ? "Dead" : "HP " + Program.BattleManager.monsters[i].Hp.ToString());
                }
                Console.WriteLine("");
                Console.WriteLine("[내정보]");
                Console.WriteLine($"Lv.{Program.Character.Level} {Program.Character.Name} {(Program.Character.Job)}");
                Console.WriteLine($"HP {Program.Character.Hp}/100");
                Console.WriteLine("");

                int input;
                if (!select)
                {
                    Console.WriteLine("1. 공격");
                    Console.WriteLine("2. 아이템 사용");
                    Console.WriteLine("3. 도망가기");
                    input = Program.SceneManager.GetUserInput(3);
                    switch (input)
                    {
                        case 1:
                            select = true;
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        default:
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("0. 취소");
                    input = Program.SceneManager.GetUserInput(Program.BattleManager.monsters.Count(), "대상을 선택해주세요.");
                    if (0 <= input && input <= Program.BattleManager.monsters.Count())
                    {
                        if (input == 0)
                        {
                            select = false;
                        }
                        else
                        {
                            if (!Program.BattleManager.monsters[input - 1].MonsterDead)
                            {
                                Program.BattleManager.AttackDamage(input);
                            }
                        }
                    }
                }
            }
        }
    }
}
