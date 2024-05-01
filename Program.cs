using OceanStory.Interfaces;
using OceanStory.Scenes;
using System.Threading;
using System.Xml.Linq;

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
        public static Inventory Inventory;
        public static Item Item;


        public static string nickName;
        List<Item> inventory = new List<Item>();
        static void Main(string[] args)
        {
            SceneManager = new SceneManager();
            SystemMessage = new SystemMessage();
            RewardManager = new RewardManager();
            Inventory = new Inventory();
            
            SceneManager.ChangeScene("LoginScene");
        }
    }
}
