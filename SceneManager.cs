namespace OceanStory
{
    // 유저 입력 받고 화면 전환하는 매니저
    internal class SceneManager
    {
        public SceneManager() { }

        // 화면 전환
        public void ChangeScene(string sceneName)
        {
            Type sceneType = Type.GetType("OceanStory.Scenes." + sceneName);
            object obj = Activator.CreateInstance(sceneType);
        }

        // 유저 입력 받기(maxNum = 입력 가능한 최대 숫자)
        public int GetUserInput(int maxNum)
        {
            Program.SystemMessage.PrintMessage();
            Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
            string s = Console.ReadLine();
            int input = -1;
            bool b = int.TryParse(s, out input);
            if (b && (0 <= input && input <= maxNum))
            {
                return input;
            }
            else
            {
                Program.SystemMessage.SetMessage("잘못된 입력입니다.");
                return -1;
            }
        }

        // 유저 입력 받기(maxNum = 입력 가능한 최대 숫자, message = 출력 문구, error = 에러 시 출력 문구)
        public int GetUserInput(int maxNum, string message, int error)
        {
            Program.SystemMessage.PrintMessage();
            Console.Write("\n" + message +"\n>> ");
            string s = Console.ReadLine();
            int input = -1;
            bool b = int.TryParse(s, out input);
            if (b && (0 <= input && input <= maxNum))
            {
                if (error == 1 && input > 0 && Program.BattleManager.monsters[input - 1].MonsterDead)
                    Program.SystemMessage.SetMessage("이미 죽은 몬스터입니다.");
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
