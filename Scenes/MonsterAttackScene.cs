namespace OceanStory.Scenes
{
    // 몬스터 공격 화면
    internal class MonsterAttackScene : Scene
    {
        public override void RunScene()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Battle!!");
                Console.WriteLine("\nLv.{0} {1} 의 공격!", Program.BattleManager.monsters[Program.BattleManager.TargetIndex].Level,
                    Program.BattleManager.monsters[Program.BattleManager.TargetIndex].Name);
                Console.WriteLine("{0} {1} {2}]",
                    Program.Character.Name,
                    Program.BattleManager.isMoving != true ? "을(를) 맞췄습니다. [데미지:" : "이(가) 회피했습니다. [데미지: ",
                    Program.BattleManager.isMoving == true ? "0" : 
                    Program.BattleManager.monsters[Program.BattleManager.TargetIndex].Atk - Program.Character.Def);
                Console.WriteLine("\nLv.{0} {1}",
                    Program.Character.Level,
                    Program.Character.Name);
                Console.WriteLine("HP {0} -> {1}",
                    Program.BattleManager.PlayerBeforeHp,
                    Program.Character.CharacterDead ?
                    "Dead" : Program.Character.Hp);
                Console.WriteLine("\n0. 다음");
                int input = Program.SceneManager.GetUserInput(0);
                if (input == 0) return;
            }
        }
    }
}
