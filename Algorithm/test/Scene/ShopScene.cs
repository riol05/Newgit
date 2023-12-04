using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class ShopScene : Scene
    {
        List<Item> item = new List<Item>();
        public Inventory inv = Inventory.GetInstance();
        public ShopScene(Game game) : base(game)
        {
        }

        public override void Render()
        {
            PrintShopMenu();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public void EnterShop(Shop shop)
        {
            Console.WriteLine("상점에 입장했습니다.");
            Console.WriteLine("아이템을 구매/ 판매 할수있습니다.");
            Thread.Sleep(1000);
            Render();
        }
        public void ExitShop()
        {
            game.OpenPrev();
        }
        private void PrintShopMenu()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1.아이템을 구매/ 2.아이템 판매");
            Console.WriteLine();
            Console.Write("행동을 선택해주세요");
            string input;
            int command;
            input = Console.ReadLine();
            if (false == int.TryParse(input, out command))
            {
                Console.WriteLine("잘못 입력하였습니다");
                return;
            }
            switch(command)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("구매하실 아이템을 선택해주세요");
                    Console.WriteLine("\t 아이템 이름 \t 가격 \t 설명");
                    for(int i =0; i < item.Count; i++)
                    {
                        Console.WriteLine(i + 1);
                        Console.Write($"\t{item[i].name}");
                        Console.Write($"\t{item[i].amount}");
                        Console.WriteLine($"\t{item[i].Description}");
                    }
                    Console.Write("구매할 아이템 선택 : ");
                    input = Console.ReadLine();
                    if (false == int.TryParse(input, out command) || command >= item.Count)
                    {
                        Console.WriteLine("잘못 입력하였습니다");
                        return;
                    }
                    else if (inv.gold < item[command].amount)
                    {
                        Console.WriteLine("아이템을 구매할 골드가 없습니다.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("아이템을 구매합니다.");
                        Console.WriteLine($"{item[command].name} 을 구매하여 {item[command].amount} 만큼 소지 골드에서 소비합니다.");
                        inv.itemList.Add(item[command]);
                        inv.gold = inv.gold - item[command].amount;
                        game.Map();
                    }
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("판매하실 아이템을 선택해주세요");
                    Console.WriteLine("\t 아이템 이름 \t 가격 \t 설명");
                    for (int i = 0; i < item.Count; i++)
                    {
                        Console.WriteLine(i + 1);
                        Console.Write($"\t{inv.itemList[i].name}");
                        Console.Write($"\t{inv.itemList[i].amount}");
                        Console.WriteLine($"\t{inv.itemList[i].Description}");
                    }
                    Console.Write("판매할 아이템 선택 : ");
                    input = Console.ReadLine();
                    if (false == int.TryParse(input, out command) || command >= inv.itemList.Count)
                    {
                        Console.WriteLine("잘못 입력하였습니다");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("아이템을 구매합니다.");
                        Console.WriteLine($"{inv.itemList[command].name} 을 구매하여 {inv.itemList[command].amount} 만큼 소지 골드에서 소비합니다.");
                        inv.deleteItem(command);
                        inv.gold = inv.gold - inv.itemList[command].amount;
                        game.Map();
                    }
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    break;
            }

        }
    }
}
