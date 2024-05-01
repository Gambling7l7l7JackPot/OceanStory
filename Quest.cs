using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory
{
    internal class Quest
    {
        public string QuestName { get; set; }
        public string Description { get; set; }
        public string QuestObjective { get; set; }
        public int QuestObjectiveCount { get; set; }
        public int QuestClearedCount { get; set; }
        public List<Item>? QuestRewards { get; set; }
        public bool IsAccepted {  get; set; }

        public Quest(string questName, string description, string questObjective, int questObejctiveCount, List<Item> questRewards)
        {
            QuestName = questName;
            Description = description;
            QuestObjective = questObjective;
            QuestObjectiveCount = questObejctiveCount;
            QuestClearedCount = 0;
            QuestRewards = questRewards;
            IsAccepted = false;
        }
    }
}
