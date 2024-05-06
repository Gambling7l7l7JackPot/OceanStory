using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory.Interfaces
{
    internal interface IMonster
    {
        string Name { get; }           // 몬스터 이름
        int Hp { get; set; }           // 몬스터 체력
        int Level { get; }             // 몬스터 레벨
        float Atk { get; }             // 몬스터 공격력
        bool MonsterDead { get; set; } // 몬스터 죽었는지 확인
        double MaxHp { get; set; }     // 몬스터 최대 체력

        int Gold { get; set; }         // 몬스터를 잡았을때 얻는 골드

        int Exp { get; set; }          // 몬스터를 잡았을때 얻는 경험치
    }
}
