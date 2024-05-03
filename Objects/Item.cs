namespace OceanStory.Objects
{
    // 장착 부위
    enum ItemType
    {
        WEAPON = 1,
        ARMOR,
        HELM
    }

    internal class Item
    {
        public string Name { get; }         // 아이템 이름
        public string Description { get; }  // 아이템 설명
        public float? Atk { get; set; }     // 아이템 공격력
        public float? Def { get; set; }     // 아이템 방어력
        public ItemType Type { get; }       // 장착 부위



        public Item(string name, string description, int? atk, int? def, ItemType type)
        {
            Name = name;
            Description = description;
            Atk = atk;
            Def = def;
            Type = type;

        }
    }
}
