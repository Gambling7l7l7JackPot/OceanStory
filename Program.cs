using OceanStory.Characters;
using OceanStory.Interfaces;
using OceanStory.Objects;

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
        public static SkillManager SkillManager;
        public static QuestManager QuestManager;
        public static Inventory Inventory;
        public static Item Item;
        public static ColorManager ColorManager;
        public static SaveManager SaveManager;
        public static string nickName;

        static void Main(string[] args)
        {
            SceneManager = new SceneManager();
            SystemMessage = new SystemMessage();
            RewardManager = new RewardManager();
            SkillManager = new SkillManager();
            QuestManager = new QuestManager();
            Inventory = new Inventory();
            BattleManager = new BattleManager();
            ColorManager = new ColorManager();
            SaveManager = new SaveManager();
            // 초기화가 끝나면 로그인 화면 시작
            SceneManager.ChangeScene("LoginScene");
        }
    }
}
