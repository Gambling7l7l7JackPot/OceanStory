using OceanStory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory.Monsters
{
    internal class Minion : IMonster
    {
        public string Name { get; }
        public int Hp { get; set; }
        public int Level { get; }
        public float Atk { get; }
        public double MaxHp { get; set; }
        public bool MonsterDead { get; set; }
        public int Exp {  get; set; }
        public Minion(string name)
        {
            Name = name;
            Hp = 15;
            Level = 2;
            Atk = 9;
            MaxHp = 15;
            MonsterDead = false;
            Exp = 5;
        }
    }
}
