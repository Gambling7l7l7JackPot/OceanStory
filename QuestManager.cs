using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory
{
    internal class QuestManager
    {
        public int QuestIndex = 0;
        public List<Quest> QuestList = new List<Quest>();

        public QuestManager()
        {
            QuestList.Add(new Quest("퀘스트1", "1번 설명", "미니언 5마리 처치", 5, new List<Item>()));
            QuestList.Add(new Quest("퀘스트2", "2번 설명", "미니언 10마리 처치", 10, new List<Item>()));
            QuestList.Add(new Quest("퀘스트3", "3번 설명", "미니언 15마리 처치", 15, new List<Item>()));
        }
    }
}
