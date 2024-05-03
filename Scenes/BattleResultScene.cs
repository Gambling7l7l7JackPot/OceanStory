namespace OceanStory.Scenes
{
    // 전투 결과 화면
    internal class BattleResultScene : Scene
    {
        public override void RunScene()
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("Battle!! - Result");
                // 전투 승리
                if (Program.BattleManager.Winner == 1) 
                {
                    int beforeExp = Program.RewardManager.CharacterExpUp(); // 메서드를 불러오기전에 이전 경험치를 저장
                    int beforeLevel = Program.RewardManager.CharacterLevelUpCheck(); // 메서드를 불러오기전에 이전 레벨을 저장
                    Console.WriteLine("\nVictory");
                    Console.WriteLine("\n던전에서 몬스터 {0}마리를 잡았습니다.", Program.BattleManager.monsters.Count());
                    Console.WriteLine("\n[캐릭터 정보]");
                    Console.WriteLine("Lv.{0} {1} -> Lv.{2} {3}", beforeLevel, Program.Character.Name, Program.Character.Level, Program.Character.Name);
                    Console.WriteLine("HP {0} -> {1}", Program.BattleManager.PlayerStartHp, Program.Character.Hp);
                    Console.WriteLine("Exp {0} -> {1}", beforeExp, Program.Character.Exp);
                }
                // 전투 패배
                else
                {
                    Console.WriteLine("\nYou Lose");
                    Console.WriteLine("\nLv.{0} {1}", Program.Character.Level, Program.Character.Name);
                    Console.WriteLine("HP {0} -> {1}", Program.BattleManager.PlayerStartHp, "0");
                }
                Console.WriteLine("\n0. 다음");
                int input = Program.SceneManager.GetUserInput(1);
                if(input == 0) return;
            }
        }
    }
}
