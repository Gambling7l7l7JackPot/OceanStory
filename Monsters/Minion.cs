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
            Level = new Random().Next(1, 4);
            Name = name;
            Hp = 12 + Level;
            Atk = 3 + Level;
            MaxHp = 12 + Level;
            MonsterDead = false;
            Exp = 3 + Level;
        }
    }
}
