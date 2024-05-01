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
            RewardManager = new RewardManager();
            BattleManager = new BattleManager();
            SceneManager.ChangeScene("LoginScene");
        }
    }
}
