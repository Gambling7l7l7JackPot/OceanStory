using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory
{
    internal class Character
    {
        public int Level { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public float Atk { get; set; }
        public float Def { get; set; }
        public int Hp { get; set; }
        public int Gold { get; set; }
        public bool CharacterDead => Hp <= 0; // 참, 거짓 값으로 Hp가 0보다 작거나 같을때
        public Character(int level, string name, string job, float atk, float def, int hp, int gold)
        {
            Level = level;
            Name = name;
            Job = job;
            Atk = atk;
            Def = def;
            Hp = hp;
            Gold = gold;
        }
    }
}
