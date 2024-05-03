namespace OceanStory.Characters
{
    internal class Character
    {
        public int Level { get; set; }          // 플레이어 레벨
        public string Name { get; set; }        // 플레이어 이름
        public string Job { get; set; }         // 플레이어 직업
        public float Atk { get; set; }          // 플레이어 공격력
        public float AtkBonus { get; set; }     // 증가한 공격력
        public float Def { get; set; }          // 플레이어 방어력
        public float DefBonus { get; set; }     // 증가한 방어력
        public int Hp { get; set; }             // 플레이어 HP
        public int Gold { get; set; }           // 소유 골드
        public int MaxHp { get; set; }          // 최대 체력
        public int Exp { get; set; }            // 경험치
        public bool CharacterDead { get; set; } // 플레이어 사망 여부

        public Character(int level, string name, string job, float atk, float def, int hp, int maxHp, int gold, int exp)
        {
            Level = level;
            Name = name;
            Job = job;
            Atk = atk;
            AtkBonus = 0;
            Def = def;
            DefBonus = 0;
            Hp = hp;
            Gold = gold;
            MaxHp = maxHp;
            CharacterDead = false;
            Exp = exp;
        }
    }
}
