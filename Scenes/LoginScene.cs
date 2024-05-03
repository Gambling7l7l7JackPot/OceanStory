﻿using OceanStory.Characters;

namespace OceanStory.Scenes
{
    // 로그인 + 이름/직업 선택 화면
    internal class LoginScene : Scene
    {
        public override void RunScene()
        {
            Console.WriteLine("OceanStory 베타 테스터로 참여해주셔서 감사합니다 \n");
            Console.WriteLine("당신이 지급받은 키 값입니다 \n\n ID : Ocean           Password : Story");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("\n아이디를 입력하세요");
                string inputID = Console.ReadLine();

                Console.WriteLine();
                Console.WriteLine("\n패스워드를 입력하세요");
                string inputPassword = Console.ReadLine();

                if (inputID == "Ocean" && inputPassword == "Story")
                {
                    Console.Clear();
                    Console.WriteLine("1. 새로 시작하기\n2. 이전 게임 불러오기");
                    switch(Program.SceneManager.GetUserInput(2))
                    {
                        case 2:
                            Console.Clear();
                            Console.WriteLine("불러오실 파일 이름을 적어주세요");
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
                    Program.nickName = Console.ReadLine();

                    Console.WriteLine("\n 직업을 선택하세요 \n\n 1. 전사          2. 마법사");
                    int choiceJob;
                    int.TryParse(Console.ReadLine(), out choiceJob);
                    Character character = null; // null로 초기화

                    switch (choiceJob)
                    {
                        case 1:
                            character = new Warrior(1, Program.nickName, "전사", 10, 5, 100, 100,1500, 0);
                            break;
                        case 2:
                            character = new Wizard(1, Program.nickName, "마법사", 15, 3, 80, 80, 1500, 0);
                            break;
                        default:
                            Console.WriteLine("잘못된 선택입니다. 처음부터 다시 진행하세요.");
                            break;
                    }
                    if (character != null)
                    {
                        Program.Character = character;
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
