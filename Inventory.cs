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
        public List<Item> itemList = new List<Item>();
        public List<Item> equipList = new List<Item>();

        string infoAtk = "  공격력 ";
        string infoDef = "  방어력 ";

        public Inventory()
        {
            itemList.Add(new Item("도란검", "굵고 짧은 검", 5, null, ItemType.WEAPON));
            itemList.Add(new Item("도란링", "마법의 힘이 담긴 반지", 5, null, ItemType.WEAPON));
            itemList.Add(new Item("천갑옷", "천으로 만들어진 갑옷", null, 2, ItemType.ARMOR));
            itemList.Add(new Item("적응형투구", "적응 하라고 만든 투구", 3, 3, ItemType.HELM));
        }
        
        public void Check()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n< Inventory >\n");

                for (int i = 0; i < itemList.Count; i++)
                {
                    string equipMark = equipList.Contains(itemList[i]) ? "[E] " : ""; // 장착중이면 [E]표시 , 노장착중이면 아무런표시 없음
                    Console.WriteLine($"{equipMark}{itemList[i].Name} ({itemList[i].Description}){(itemList[i].Atk != null ? infoAtk + itemList[i].Atk : "")}{(itemList[i].Def != null ? infoDef + itemList[i].Def : "")}");
                    // 장착 유무 + 템이름 + 템설명 + 공격력이 있는 아이템이면 공격력 출력하고 공격력 없는템이면 공백이 뜨도록 함 + 방어력아이템일 경우에만 방어력 수치 뜨도록 함
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
                    string equipMark = equipList.Contains(itemList[i]) ? "[E] " : ""; // 장착중이면 [E]표시 , 노장착중이면 아무런표시 없음
                    Console.WriteLine($"{i+1}. {equipMark}{itemList[i].Name} ({itemList[i].Description}){(itemList[i].Atk != null ? infoAtk + itemList[i].Atk : "")}{(itemList[i].Def != null ? infoDef + itemList[i].Def : "")}");
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

                    if (equipList.Contains(selected)) //  이미 장착된 아이템을 입력한 것이라면
                    {
                        equipList.Remove(selected); // 장착된 아이템이면 해제

                        float setAtkBonus = (float)selected.Atk;
                        Program.Character.Atk -= setAtkBonus;
                    }
                    else // 장착된 아이템을 입력한것이 아니었다면
                    {
                        foreach (var equippedItem in equipList) // 중복된 타입은 피하기위해서,  장착된 아이템들의 리스트를 나열한 다음
                        {
                            if(equippedItem.Type == selected.Type) //  장착한 아이템들 중에서 아이템 타입이 == 입력한 아이템타입과 같은게 있따면
                            {
                                equipList.Remove(equippedItem); // 기존에 착용한 아이템을 해제해라
                                break; // 루프 종료
                            }
                        }
                        equipList.Add(selected); // 선택한 아이템을 장착 ( 기존에 착용했던 템중에서 중복된 아이템 타입을 해제후 착용 or 굳이 같은타입 안끼고 있었다 하더라도 착용 )

                        if()
                        float getAtkBonus = (float)selected.Atk;
                        Program.Character.Atk += getAtkBonus;
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
