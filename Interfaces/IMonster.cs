using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory.Interfaces
{
    internal interface IMonster
    {
        string Name { get; }
        int Hp { get; set; }
        int Level { get; }
        int Atk { get; }
        bool MosterDead { get; }
        void GetDamage (int damage);
    }
}
