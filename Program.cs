﻿using OceanStory.Interfaces;
using OceanStory.Scenes;

namespace OceanStory
{
    internal class Program
    {
        public static SceneManager SceneManager;
        public static SystemMessage SystemMessage;
        public static AttackScene AttackScene;
        public static Character Character;
        public static IMonster Monster;
        public static BattleManager BattleManager;
        static void Main(string[] args)
        {
            SceneManager = new SceneManager();
            SystemMessage = new SystemMessage();
            AttackScene = new AttackScene();
            BattleManager = new BattleManager();
            Character = new Character(1, "Chad", "전사", 10, 5, 100, 1500);
            SceneManager.ChangeScene("StartScene");
        }
    }
}
