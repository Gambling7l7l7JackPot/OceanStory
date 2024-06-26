﻿namespace OceanStory.Scenes
{
    // 상태 보기 화면
    internal class StatusScene : Scene
    {
        public override void RunScene()
        {
            while (true) // 스테이터스 출력 씬
            {
                Console.Clear();
                Console.WriteLine("상태 보기");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.");
                Console.WriteLine("");
                Console.WriteLine($"Lv. {Program.Character.Level.ToString("D2")}");
                Console.WriteLine($"{Program.Character.Name} ( {Program.Character.Job} )");
                Console.WriteLine($"공격력 : {Program.Character.Atk} (+{Program.Character.AtkBonus})");
                Console.WriteLine($"방어력 : {Program.Character.Def} (+{Program.Character.DefBonus})");
                Console.WriteLine("체 력  : {0}", Program.Character.Hp <= 0 ? "0" : Program.Character.Hp);
                Console.WriteLine($"마 나  : {Program.Character.Mp}");
                Console.WriteLine($"Gold   : {Program.Character.Gold} G");
                Console.WriteLine($"Exp    : {Program.Character.Exp}");
                Console.WriteLine($"다음 레벨까지 남은 Exp : {Program.RewardManager.LevelFull[Program.Character.Level-1] - Program.Character.Exp}");
                Console.WriteLine("");
                Console.WriteLine("0. 나가기");

                switch (Program.SceneManager.GetUserInput(0))
                {
                    case 0:
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
