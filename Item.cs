using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace OceanStory
{
    enum ItemType
    {
        WEAPON = 1,
        ARMOR,
        HELM
    }

    internal class Item
    {
        public string Name { get; }
        public string Description { get; }
        public float? Atk { get; set; }
        public float? Def { get; set; }
        public ItemType Type { get; }
        


        public Item(string name, string description, int? atk, int? def, ItemType type)
        {
            this.Name = name;
            this.Description = description;
            this.Atk = atk;
            this.Def = def;
            this.Type = type;
                
        }
    }
}
