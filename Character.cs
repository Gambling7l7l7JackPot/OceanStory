using OceanStory.Interfaces;
using OceanStory.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory
{
    internal abstract class Character
    {
        public int Level { get; set; } = 1;
        public string Name { get; set; }
        public string Job { get; set; }
        public float Atk { get; set; } 
        public float Def { get; set; } 
        public int Hp { get; set; } 
        public int Gold { get; set; } = 1500;
        public int MaxHp { get; set; } 
        public int Exp { get; set; } = 0;
        public int Mp { get; set; }
        public int MaxMp { get; set; } 
        public bool CharacterDead { get; set; }
        public Character(string name, string job, float atk, float def, int hp, int maxHp, int mp, int maxMp )
        {
            Name = name;
            Job = job;
            Atk = atk;
            Def = def;
            Hp = hp;
            Mp = mp;
            MaxHp = maxHp;
            MaxMp = maxMp;
        }
    }
}
