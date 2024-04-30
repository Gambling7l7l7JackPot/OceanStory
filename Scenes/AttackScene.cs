using OceanStory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory.Scenes
{
    internal class AttackScene
    {
        public void BattleStart(List<IMonster> monsters)
        {
            Console.Clear();
            int count = 0;
            Console.WriteLine("Battle!!");
            Console.WriteLine("");
            foreach (IMonster monster in monsters)
            {
                count++;
                Console.WriteLine($"[{count}]  Lv.{monster.Level} {monster.Name} HP {monster.Hp}");
            }
            Console.WriteLine("");
            Console.WriteLine("[내정보]");
            Console.WriteLine($"Lv.{Program.Character.Level} {Program.Character.Name} {Program.Character.Job}");
            Console.WriteLine($"HP 100/{Program.Character.Hp}");
            Console.WriteLine("");
            Console.WriteLine("0. 취소");

            int input = GetUserAttackInput(3);
            switch (input)
            {
                case 0:
                    return;
                case 1:
                    Program.BattleManager.AttackDamage(monsters, input);
                    break;
                case 2:
                    Program.BattleManager.AttackDamage(monsters, input);
                    break;
                case 3:
                    Program.BattleManager.AttackDamage(monsters, input);

                    break;
                default:
                    break;
            }
        }
        public int GetUserAttackInput(int maxNum)
        {
            Program.SystemMessage.PrintMessage();
            Console.Write("\n대상을 선택해주세요.\n>> ");
            string s = Console.ReadLine();
            int input = -1;
            bool b = int.TryParse(s, out input);
            if (b && 0 <= input && input <= maxNum)
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
