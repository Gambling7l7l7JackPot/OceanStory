using OceanStory.Interfaces;
using OceanStory.Monsters;
using System.Security.Cryptography.X509Certificates;

namespace OceanStory.Scenes
{
    internal class BattleScene : Scene
    {
        public override void RunScene()
        {
            Random random = new Random();
            List<IMonster> monsters = new List<IMonster>();
            int randomMake = new Random().Next(1, 5);
            for (int i = 0; i < randomMake; i++)
            {
                int makeMonsters = random.Next(1, 4);
                switch (makeMonsters)
                    {
                    case 1:
                        Minion minion = new("미니언");
                        monsters.Add(minion);
                        break;
                    case 2:
                        Voidling voidling = new("공허충");
                        monsters.Add(voidling);
                        break;
                    case 3:
                        CanonMinion canonMinion = new("대포미니언");
                        monsters.Add(canonMinion);
                        break;
                    }
                }
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Battle!!");
                Console.WriteLine("");
                foreach (IMonster monster in monsters)
                {
                    Console.WriteLine($"Lv.{monster.Level} {monster.Name} HP {monster.Hp}");
                }
                Console.WriteLine("");
                Console.WriteLine("[내정보]");
                Console.WriteLine($"Lv.{Program.Character.Level} {Program.Character.Name} {(Program.Character.Job)}");
                Console.WriteLine($"HP 100/{Program.Character.Hp}");
                Console.WriteLine("");
                Console.WriteLine("1. 공격");
                Console.WriteLine("2. 아이템 사용");
                Console.WriteLine("3. 도망가기");
                int input = Program.SceneManager.GetUserInput(3);
                switch (input)
                {
                    case 1: Program.AttackScene.BattleStart(monsters);
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
