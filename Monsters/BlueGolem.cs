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
        public BlueGolem(string name)
        {
            Level = new Random().Next(9, 13);
            Name = name;
            Hp = 30 + Level;
            Atk = 10 + Level;
            MaxHp = 30 + Level;
            MonsterDead = false;
            Exp = 20 + Level;
        }
    }
}
