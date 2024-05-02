using OceanStory.Interfaces;
using OceanStory.Scenes;
using System;
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
        public static ColorManager ColorManager;

        public static string nickName;
        static void Main(string[] args)
        {
            SceneManager = new SceneManager();
            SystemMessage = new SystemMessage();
            RewardManager = new RewardManager();
            BattleManager = new BattleManager();
            ColorManager = new ColorManager();
            SceneManager.ChangeScene("LoginScene");
        }
    }
}
