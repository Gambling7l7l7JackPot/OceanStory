using OceanStory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory.Monsters
{
    internal class Voidling : IMonster
    {
        public string Name { get; }
        public int Hp { get; set; }
        public int Level { get; }
        public float Atk { get; }
        public double MaxHp { get; set; }
        public bool MonsterDead { get; set; }
        public int Exp { get; set; }
        public Voidling(string name)
        {
            Name = name;
            Hp = 10;
            Level = 3;
            Atk = 9;
            MaxHp = 10;
            MonsterDead = false;
            Exp = 7;
        }
    }
}
