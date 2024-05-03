using OceanStory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory.Monsters
{
    internal class Diablo : IMonster
    {
        public string Name { get; }
        public int Hp { get; set; }
        public int Level { get; }
        public float Atk { get; }
        public double MaxHp { get; set; }
        public bool MonsterDead { get; set; }
        public int Exp { get; set; }
        public int Gold { get; set; }
        public Diablo(string name)
        {
            Level = new Random().Next(98, 99);
            Name = name;
            Hp = 900 + Level;
            Atk = 1 + Level;
            MaxHp = 900 + Level;
            MonsterDead = false;
            Exp = 900 + Level;
            Gold = 9999 + Level;
        }
    }
}
