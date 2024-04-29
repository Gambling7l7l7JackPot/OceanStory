namespace OceanStory
{
    internal class Program
    {
        public static SceneManager SceneManager;
        public static SystemMessage SystemMessage;
        public static Character Character;
        static void Main(string[] args)
        {
            SceneManager = new SceneManager();
            SystemMessage = new SystemMessage();
            Character = new Character(1, "Chad", "전사", 10, 5, 100, 1500);
            Monsters.Minion minion = new Monsters.Minion("미니언");
            Monsters.Voidling voidling = new Monsters.Voidling("공허충");
            Monsters.CanonMinion canonMinion = new Monsters.CanonMinion("대포미니언");
            SceneManager.ChangeScene("StartScene");
        }
    }
}
