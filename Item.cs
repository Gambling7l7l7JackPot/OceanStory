using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace OceanStory
{
    internal class Item
    {
        public string Name { get; }
        public string Description { get; }
        public int? Atk { get; }
        public int? Def { get; }
        public bool isEquipped { get; set; }


        public Item(string name, string description, int? atk, int? def, bool isEquipped = false)
        {
            this.Name = name;
            this.Description = description;
            this.Atk = atk;
            this.Def = def;
        }
    }
}
