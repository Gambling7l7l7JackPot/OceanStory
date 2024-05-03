namespace OceanStory.Scenes
{
    // 전투 시작 화면
    internal class BattleScene : Scene
    {
        public override void RunScene()
        {
            bool select = false; // 공격 대상을 선택해야 하는 상황이면 true
            bool useSkill = false;
            bool noMp = false;
            Program.BattleManager = new BattleManager();
            int Cave = Program.SceneManager.GetUserInput(5);
            Program.BattleManager.MakeEnemy(Cave);  // 입력에 맞는 던전 생성
            
            while (true)
            {
                Program.SkillManager.getMonster.Clear();  // 전투 결과가 정해졌으면 반복문 종료
                if (Program.BattleManager.Winner != 0)
                {
                    return;
                }
                Console.Clear();
                Program.ColorManager.ColorText(1);
                Console.WriteLine("Battle!!");
                Console.WriteLine("");
                for (int i = 0; i < Program.BattleManager.monsters.Count(); i++)
                {
                    Program.ColorManager.CheckName(i);
                    Console.WriteLine("{0} Lv.{1} {2} {3}",select? "[" + (i + 1).ToString() + "]": "",
                    Program.BattleManager.monsters[i].Level,
                    Program.BattleManager.monsters[i].Name,
                    Program.BattleManager.monsters[i].MonsterDead ? "Dead" : "HP " + Program.BattleManager.monsters[i].Hp.ToString());
                }
                Program.ColorManager.ColorText(0);
                Console.WriteLine("");
                Console.WriteLine("[내정보]");
                Console.WriteLine($"Lv.{Program.Character.Level} {Program.Character.Name} {(Program.Character.Job)}");
                Console.WriteLine($"HP {Program.Character.Hp}/{Program.Character.MaxHp}");
                Console.WriteLine($"MP {Program.Character.Mp}/{Program.Character.MaxMp}");
                Console.WriteLine("");

                int input;
                // 공격대상 선택 모드가 아닐 때
                if (!select)
                {
                    Program.ColorManager.ColorText(1);
                    Console.WriteLine("1. 공격");
                    Program.ColorManager.ColorText(0);
                    Program.ColorManager.ColorText(3);
                    Console.WriteLine("2. 스킬");
                    Program.ColorManager.ColorText(0);
                    Console.WriteLine("3. 아이템 사용");
                    Console.WriteLine("4. 도망가기");
                    input = Program.SceneManager.GetUserInput(4);
                    switch (input)
                    {
                        case 1:
                            select = true;
                            break;
                        case 2:
                            select = true;
                            useSkill = true;
                            break;
                        case 3:
                            break;
                        case 4:
                            return;
                    }
                }
                // 공격대상을 선택해야 할 때
                else
                {
                    if (useSkill)
                    {
                        Program.SkillManager.CharacterSkillList();
                        Console.WriteLine("\n 0. 취소");

                        input = Program.SkillManager.GetSkillInput(4);

                        if (0 <= input && input <= 4)
                        {
                            switch (input)
                            {
                                case 1: 
                                    if(Program.Character.Mp < 4)
                                    {
                                        Console.WriteLine("마나가 없습니다.");
                                        Thread.Sleep(1000);
                                        noMp = true;
                                    }
                                    break;
                                case 2:
                                    if (Program.Character.Mp < 4)
                                    {
                                        Console.WriteLine("마나가 없습니다.");
                                        Thread.Sleep(1000);
                                        noMp = true;
                                    }
                                    break;
                                case 3:;
                                    if (Program.Character.Mp < 9)
                                    {
                                        Console.WriteLine("마나가 없습니다.");
                                        Thread.Sleep(1000);
                                        noMp = true;
                                    }
                                    break;
                                case 4:
                                    if (Program.Character.Mp < 29)
                                    {
                                        Console.WriteLine("마나가 없습니다.");
                                        Thread.Sleep(1000);
                                        noMp = true;
                                    }
                                    break;
                            }
                            if (noMp)
                            {
                                noMp = false;
                                useSkill = false;
                                select = false;
                            }
                            else
                            {
                                if (input == 0)
                                {
                                    select = false;
                                    useSkill = false;
                                }
                                else
                                {
                                    Program.BattleManager.SkillDamage(input);
                                    select = false;
                                    useSkill = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n 0. 취소");

                        input = Program.SceneManager.GetUserInput(Program.BattleManager.monsters.Count(), "대상을 선택해주세요.", 1);
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
                                    select = false;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
