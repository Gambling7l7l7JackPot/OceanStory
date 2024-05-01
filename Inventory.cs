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
        List<Item> equipItem = new List<Item>();

        string infoAtk = "  공격력";
        string infoDef = "  방어력";

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
                    string equipMark = equipItem.Contains(itemList[i]) ? "[E] " : ""; // 장착중이면 [E]표시 , 노장착중이면 아무런표시 없음
                    Console.WriteLine($"{equipMark}{itemList[i].Name} ({itemList[i].Description}){(itemList[i].Atk != null ? infoAtk + " " + itemList[i].Atk : "")}{(itemList[i].Def != null ? infoDef + " " + itemList[i].Def : "")}");
                }

                Console.WriteLine("\n\n0. 돌아가기");
                Console.WriteLine("1. 아이템 관리");
         
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
                Console.Clear();
                Console.WriteLine("\n관리하려는 아이템을 선택하세요\n");

                for(int i = 0; i < itemList.Count; i++)
                {
                    string equipMark = equipItem.Contains(itemList[i]) ? "[E] " : ""; // 장착중이면 [E]표시 , 노장착중이면 아무런표시 없음
                    Console.WriteLine($"{i+1}. {equipMark}{itemList[i].Name} ({itemList[i].Description}){(itemList[i].Atk != null ? infoAtk + " " + itemList[i].Atk : "")}{(itemList[i].Def != null ? infoDef + " " + itemList[i].Def : "")}");
                }
                Console.WriteLine("\n\n0. 돌아가기\n");

                int input = Program.SceneManager.GetUserInput(itemList.Count);

                if (input == 0)
                {
                    return ;
                }
                else if (input >= 1 && input <= itemList.Count)
                {
                    Item selected = itemList[input-1];

                    if (equipItem.Contains(selected)) // 만약 이미 장착된 아이템을 입력한 것이라면
                    {
                        equipItem.Remove(selected); // 장착된 아이템이면 해제
                    }
                    else // 장착된 아이템을 입력한것이 아니었다면
                    {
                        equipItem.Add(selected); // 해당 아이템을 장착해라
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }
    }
}
