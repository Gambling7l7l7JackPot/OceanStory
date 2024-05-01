using OceanStory.Interfaces;
using OceanStory.Scenes;
using System.Threading;

namespace OceanStory
{
    internal class Program
    {
        public static SceneManager SceneManager;
        public static SystemMessage SystemMessage;
        public static Character Character;
        public static IMonster Monster;
        public static BattleManager BattleManager;
        public static RewardManager RewardManager;

        public static string nickName;
        static void Main(string[] args)
        {
            SceneManager = new SceneManager();
            SystemMessage = new SystemMessage();
            Character = new Warrior(1, nickName, "전사", 10, 5, 100, 100, 1500); // Character 속성에 Warrior 인스턴스 할당
            Character = new Wizard(1, nickName, "마법사", 15, 3, 80, 80, 1500); // Character 속성에 Wizard 인스턴스 할당
            SceneManager.ChangeScene("LoginScene");
        }
    }
}
