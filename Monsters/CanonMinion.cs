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
        public int Exp { get; set; }
        public CanonMinion(string name)
        {
            Level = new Random().Next(5, 8);
            Name = name;
            Hp = 19 + Level;
            Atk = 3 + Level;
            MaxHp = 19 + Level;
            MonsterDead = false;
            Exp = 4 + Level;
        }
    }
}
