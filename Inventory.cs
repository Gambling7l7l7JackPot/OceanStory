using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory
{
    internal class Inventory
    {
        List<Item> itemList = new List<Item>();
        List<Item> equipItems = new List<Item>();

        public Inventory()
        {
            itemList.Add(new Item("도란검", "굵고 짧은 검", 5, null));
            itemList.Add(new Item("도란링", "마법의 힘이 담긴 반지", 5, null));
            itemList.Add(new Item("천갑옷", "천으로 만들어진 갑옷", null, 2));
            itemList.Add(new Item("적응형투구", "적응 하라고 만든 투구", 3, 3));
        }

        public void Check()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n< Inventory >\n");

                for (int i = 0; i < itemList.Count; i++)
                {
                    string infoAtk = "  공격력";
                    string infoDef = "  방어력";
                    string equipMark = equippedItems.Contains(itemList[i]) ? "[E]" : ""; // 장착시킨건 인벤에서 뜨도록 
                    Console.WriteLine($"{itemList[i].Name} ({itemList[i].Description}){(itemList[i].Atk != null ? infoAtk + " " + itemList[i].Atk : "")}{(itemList[i].Def != null ? infoDef + " " + itemList[i].Def : "")}");
                }

                Console.WriteLine("\n\n0. 돌아가기");
                Console.WriteLine("1. 아이템")
         
                switch (Program.SceneManager.GetUserInput(1))
                {
                    case 0:
                        return;
                    case 1:
                        Equip();
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }
        }

        public void Equip()
        {
            while (true)
            {
                Console.WriteLine("장비창");
            }
        }
    }
}
