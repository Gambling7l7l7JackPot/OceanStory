using OceanStory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory.Monsters
{
    internal class CanonMinion : IMonster
    {
        public string Name { get; }
        public int Hp { get; set; }
        public int Level { get; }
        public float Atk { get; }
        public double MaxHp { get; set; }
        public bool MonsterDead { get; set; }
        public CanonMinion(string name)
        {
            Name = name;
            Hp = 25;
            Level = 5;
            Atk = 8;
            MaxHp = 25;
            MonsterDead = false;
        }
    }
}
