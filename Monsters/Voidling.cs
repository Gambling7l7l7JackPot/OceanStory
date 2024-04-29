using OceanStory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory.Monsters
{
    internal class Voidling : IMonster
    {
        public string Name { get; }
        public int Hp { get; set; }
        public int Level { get; }
        public float Atk { get; }
        public bool MosterDead => Hp <= 0; // 참, 거짓 값으로 Hp가 0보다 작거나 같을때
        public Voidling(string name)
        {
            Name = name;
            Hp = 10;
            Level = 3;
            Atk = 9;
        }
        public void GetDamage(int damage)
        {
            Hp -= damage;
            if (MosterDead) // MosterDead가 true일때
            {
                Console.WriteLine($"{Name}이 쓰러졌습니다. ");

            }
            else // false 일때
            {
                Console.WriteLine($"{Name}이 {damage}데미지를 받았다. ");
            }
        }
    }
}
