using OceanStory.Characters;

namespace OceanStory.Scenes
{
    // 로그인 + 이름/직업 선택 화면
    internal class LoginScene : Scene
    {
        public override void RunScene()
        {
            Program.ColorManager.ColorText(3);
            Console.WriteLine(@"________                                        _________  __");
            Console.WriteLine(@"_____  \    ____   ____  _____     ____       /   _____/_/  |_  ____ _______  ___.__. ");
            Console.WriteLine(@" /   |   \ _/ ___\_/ __ \ \__  \   /    \      \_____  \ \   __\/  _ \\_  __ \<   |  |");
            Console.WriteLine(@"/    |    \\  \___\  ___/  / __ \_|   |  \     /        \ |  | (  <_> )|  | \/ \___  |");
            Console.WriteLine(@"\_______  / \___  >\___  >(____  /|___|  /    /_______  / |__|  \____/ |__|    / ____|");
            Console.WriteLine(@"        \/      \/     \/      \/      \/             \/                       \/");
            Program.ColorManager.ColorText(0);
            Console.WriteLine("\n");
            Console.WriteLine(" OceanStory 베타 테스터로 참여해주셔서 감사합니다 \n");
            Console.WriteLine(" 당신이 지급받은 키 값입니다 \n\n ID : Ocean           Password : Story");
            Console.WriteLine();
            
            while (true)
            {
                Console.WriteLine("\n아이디를 입력하세요");
                Console.Write("▶");
                string inputID = Console.ReadLine();

                Console.WriteLine();
                Console.WriteLine("\n패스워드를 입력하세요");
                Console.Write("▶");
                string inputPassword = Console.ReadLine();

                if (inputID == "Ocean" && inputPassword == "Story")
                {
                    Console.Clear();
                    Console.WriteLine("1. 새로 시작하기\n2. 이전 게임 불러오기\n");
                    switch (Program.SceneManager.GetUserInput(2)) // 이전파일을 불러올지 새로만들지 선
                    {
                        case 2:
                            Console.Clear();
                            Console.WriteLine("불러오실 파일 이름을 적어주세요");
                            Console.Write("▶");
                            bool loadSucceed = Program.SaveManager.Load(Console.ReadLine());
                            if (loadSucceed)
                            {
                                Program.SceneManager.ChangeScene("StartScene");
                            }
                            else
                            {
                                Console.WriteLine("불러오기에 실패했습니다.");
                                Thread.Sleep(1000);
                            }
                            break;
                        default:
                            break;
                    }
                    Console.Clear();

                    Console.WriteLine("사용할 닉네임을 입력하세요 \n");
                    Console.Write("▶ ");
                    Program.nickName = Console.ReadLine();

                    Console.WriteLine("\n 직업을 선택하세요 \n\n 1. 전사          2. 마법사");
                    Console.WriteLine();
                    Console.Write("▶ ");
                    int choiceJob;
                    int.TryParse(Console.ReadLine(), out choiceJob);
                    Character character = null; // null로 초기화

                    switch (choiceJob) // 직업 선택
                    {
                        case 1:
                            character = new Warrior(Program.nickName, "전사", 10, 5, 100, 100, 50, 50);
                            Program.SkillManager.WarriorSkill();
                            break;
                        case 2:
                            character = new Wizard(Program.nickName, "마법사", 12, 3, 80, 80, 75, 75);
                            Program.SkillManager.WizardSkill();
                            break;
                        default:
                            Console.WriteLine("잘못된 선택입니다. 처음부터 다시 진행하세요.");
                            break;
                    }
                    if (character != null)
                    {
                        Program.Character = character;
                        Program.RewardManager.MakeLevel();
                        Program.SceneManager.ChangeScene("StartScene");
                    }
                }
                else
                {
                    Console.WriteLine("아이디 혹은 패스워드가 일치하지 않습니다");
                }
            }
        }
    }
}
