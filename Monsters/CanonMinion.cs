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
        public int Gold { get; set; }
        public CanonMinion(string name)
        {
            Level = new Random().Next(12, 17);
            Name = name;
            Hp = 30 + Level;
            Atk = 3 + Level;
            MaxHp = 30 + Level;
            MonsterDead = false;
            Exp = Level;
            Gold = Level * 5;
        }
    }
}
