using OceanStory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory.Monsters
{
    internal class BlueGolem : IMonster
    {
        public string Name { get; }
        public int Hp { get; set; }
        public int Level { get; }
        public float Atk { get; }
        public double MaxHp { get; set; }
        public bool MonsterDead { get; set; }
        public int Exp { get; set; }
        public int Gold { get; set; }
        public BlueGolem(string name)
        {
            Level = new Random().Next(25, 35);
            Name = name;
            Hp = 50 + Level;
            Atk = 10 + Level;
            MaxHp = 50 + Level;
            MonsterDead = false;
            Exp = Level;
            Gold = Level * 5;
        }
    }
}
