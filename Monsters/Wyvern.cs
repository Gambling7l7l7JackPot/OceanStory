using OceanStory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory.Monsters
{
    internal class Wyvern : IMonster
    {
        public string Name { get; }
        public int Hp { get; set; }
        public int Level { get; }
        public float Atk { get; }
        public double MaxHp { get; set; }
        public bool MonsterDead { get; set; }
        public int Exp { get; set; }
        public int Gold { get; set; }
        public Wyvern(string name)
        {
            Level = new Random().Next(36,45);
            Name = name;
            Hp = 100 + Level;
            Atk = 20 + Level;
            MaxHp = 100 + Level;
            MonsterDead = false;
            Exp = 2000 + Level;
            Gold = Level * 5;
        }
    }
}
