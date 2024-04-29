using System;
using System.Collections.Generic;
using static Dungeon.Program;

namespace Dungeon
{
    internal class Program
    {
        static Player player;
        static List<Item> StoreItemList = new List<Item>
        {
            new Item("수련자 갑옷", 1000, "방어력 +5 | 수련에 도움을 주는 갑옷입니다."),
            new Item("무쇠갑옷", 1800, "방어력 +9 | 무쇠로 만들어져 튼튼한 갑옷입니다."),
            new Item("스파르타의 갑옷", 3500, "방어력 +15 | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다."),
            new Item("낡은 검", 600, "공격력 +2 | 쉽게 볼 수 있는 낡은 검 입니다."),
            new Item("청동 도끼", 1500, "공격력 +5 | 어디선가 사용됐던거 같은 도끼입니다."),
            new Item("스파르타의 창", 2100, "공격력 +7 | 스파르타의 전사들이 사용했다는 전설의 창입니다.")
        };

        public class Item
        {
            public string Name { get; set; }
            public int Price { get; set; }
            public string Description { get; set; }
            public bool Equipped { get; set; }
            
            public Item(string name, int price, string description)
            {
                Name = name;
                Price = price;
                Description = description;
                Equipped = false;
               
            }
        }

        
        


        static int Gold = 500000; // 초기 골드 설정

        static void Main(string[] args)
        {
            player = new Player();
            village();
        }

        static void village()
        {
            
            
            Console.WriteLine("\n스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");

            

            while (true)
            {
                string act = Console.ReadLine();

                switch (act)
                {
                    case "1":
                        player.Status(); // 상태창 메서드 넘어가기
                        break;
                    case "2":
                        player.Inventory(); //인벤토리 메서드 넘어가기
                        break;
                    case "3":
                        player.Store(null); //상점 메서드 넘어가기
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        continue; // 잘못된 입력을 받으면 다시 반복문의 처음으로 돌아감
                }
                break;
            }
        } //마을 설명 + 어디갈지

        public class Player
        {
            
            private int LV = 1;
            private string Class = "전사";
            private string Name = "Rain";
            private int ATK = 10;
            private int DEF = 5;
            private int HP = 100;
            private List<Item> InventoryList = new List<Item>(); // 인벤토리 아이템 리스트

            public void Status()
            {
                Console.WriteLine("\n상태 보기");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.");
                Console.WriteLine($"\nLV: " + LV);
                Console.WriteLine(Name + " " + Class);
                Console.WriteLine($"공격력: " + ATK+" (+" + (ATK - 10) + ")");
                Console.WriteLine($"방어력: " + DEF+ " (+" + (DEF - 5) + ")");
                Console.WriteLine($"체력: " + HP);
                Console.WriteLine($"Gold: " + Gold + "G");                
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                while (true)
                {
                    string action = Console.ReadLine();
                    switch (action)
                    {
                        case "0":
                            village();
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            continue;
                    }
                    break;
                }
            }

            public void Inventory()
            {
                Console.WriteLine("\n인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                for (int i = 0; i < InventoryList.Count; i++)
                {
                    string equipped = InventoryList[i].Equipped ? "[E]" : "";
                    Console.WriteLine($"{i + 1}. {InventoryList[i].Name} {equipped}");

                }
                Console.WriteLine("\n1. 장착관리");
                Console.WriteLine("0. 나가기");

                while (true)
                {
                    string action = Console.ReadLine();
                    switch (action)
                    {
                        case "0":
                            village(); // 메인으로 돌아가기
                            return; // 현재 메서드 종료
                        case "1":
                            Equipment(); // 장착관리 메서드 호출
                            return; // 현재 메서드 종료
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            continue;
                    }
                }
            }

            private void Equipment()
            {
                Console.WriteLine("\n장착 관리");
                
                Console.WriteLine("0. 나가기");
                for (int i = 0; i < InventoryList.Count; i++)
                {
                    string equipped = InventoryList[i].Equipped ? "[E]" : "";
                    Console.WriteLine($"{i + 1}. {InventoryList[i].Name} {equipped}");

                }

                while (true)
                {
                    string input = Console.ReadLine();
                    if (input == "0")
                    {
                        Inventory(); // 인벤토리로 돌아가기
                        return;
                    }

                    int itemIndex;
                    if (int.TryParse(input, out itemIndex) && itemIndex >= 1 && itemIndex <= InventoryList.Count)
                    {
                        Item selectedItem = InventoryList[itemIndex - 1];
                        selectedItem.Equipped = !selectedItem.Equipped; // 장착 상태 토글
                        DEF = 5;
                        ATK = 10;
                        for (int i = 0; i < InventoryList.Count; i++)
                        {
                            if (InventoryList[i] == selectedItem)
                            {
                                if (itemIndex == 1)
                                    DEF +=5;
                                    
                                else if (itemIndex == 2)
                                    DEF +=9;
                                    
                                else if (itemIndex == 3)
                                    DEF +=15;
                                    
                                else if (itemIndex == 4)
                                    ATK +=2;
                                    
                                else if (itemIndex == 5)
                                    ATK +=5;
                                    
                                else if (itemIndex == 6)
                                    ATK +=7;
                                    
                            }
                        }

                        Console.WriteLine($"[{selectedItem.Name}] 아이템을 {(selectedItem.Equipped ? "장착" : "해제")}하였습니다.");

                        // 장착 상태 변경 후 인벤토리 다시 표시
                        Inventory();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }
                    Console.WriteLine("장착 관리로 돌아갑니다.");
                    Equipment();
                }
            }

            public void Store(Item item)
            {
                Console.WriteLine("\n상점");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                Console.Write("\n[보유 골드]");
                Console.WriteLine(Gold + "G");
                Console.WriteLine("\n[아이템 목록]");
                for (int i = 0; i < StoreItemList.Count; i++)
                {
                    bool Buy = InventoryList.Any(item => item.Name == StoreItemList[i].Name);
                    string purchasedText = Buy ? " [구매완료]" : "";
                    Console.WriteLine($"{i + 1}. {StoreItemList[i].Name} | 가격: {StoreItemList[i].Price}G | 설명: {StoreItemList[i].Description} {purchasedText}"); 
                }
                Console.WriteLine("\n0. 나가기");

                while (true)
                {
                    string action = Console.ReadLine();
                    int itemIndex;
                    if (int.TryParse(action, out itemIndex))
                    {
                        if (itemIndex >= 1 && itemIndex <= StoreItemList.Count)
                        {
                            BuyItem(StoreItemList[itemIndex - 1]);
                        }
                        else if (itemIndex == 0)
                        {
                            village();
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다."); 
                            Store(item);
                        }
                    }
                    
                }
            }

            private void BuyItem(Item item)
            {
                if (Gold >= item.Price)
                {
                    Gold -= item.Price;

                    // 이미 보유한 아이템인지 확인
                    bool Buy = false;
                    foreach (var inventoryItem in InventoryList)
                    {
                        if (inventoryItem.Name == item.Name)
                        {
                            Buy = true;
                            break;
                        }
                    }

                    // 이미 보유한 아이템이 아니라면 인벤토리에 추가
                    if (!Buy)
                    {
                        // 구매한 아이템을 복제하여 인벤토리에 추가
                        Item newItem = new Item(item.Name, item.Price, item.Description);
                        InventoryList.Add(newItem);                        
                        Console.WriteLine($"[{item.Name}] 아이템을 구매했습니다.");
                    }
                    else
                    {
                        Console.WriteLine($"[{item.Name}] 아이템을 이미 구매했습니다.");
                        Gold += item.Price;
                    }

                    Console.WriteLine($"현재 골드: {Gold}G");
                }
                else
                {
                    Console.WriteLine("골드가 부족합니다.");
                }
                Console.WriteLine("상점으로 돌아갑니다.");
                Store(item);
            }



        }

       
    }
}
