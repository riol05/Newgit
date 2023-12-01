using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class InventoryScene : Scene
    {
        Inventory inv = Inventory.GetInstance();
        
        public InventoryScene(Game game) : base(game){}

        public override void Render()
        {
            Console.Clear();
            Console.WriteLine("--------------인벤토리-------------");
            Console.WriteLine();
            Console.WriteLine();
            Thread.Sleep(1500);
            StringBuilder sb = new StringBuilder();            
            for (int i = 0; i < inv.itemList.Count; i++)
            {
                //sb.Append($"{i + 1} ."); // 주의 하자!! inv 는 인스턴스!
               
                sb.AppendLine($" {inv.itemList[i].name} : {inv.Des(inv.itemList[i])} ");
            }
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("1 . 아이템 사용하기");
            sb.AppendLine("2 . 아이템 버리기");
            sb.AppendLine("3 . 인벤토리창 나가기");
            Console.Write(sb.ToString());            
        }

        public override void Update()
        {
            Console.Write("행동을 먼저 선택해주세요");
            string input = Console.ReadLine();

            int command;

            if (false == int.TryParse(input, out command))//
            {
                Console.WriteLine("잘못 입력 하였습니다.");
                return;
            }
            Console.Clear();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < inv.itemList.Count; i++)
            {
                
                sb.Append($"{i+1} ."); // 주의 하자!! inv 는 인스턴스!
                
                sb.AppendLine($" {inv.itemList[i].name} : {inv.Des(inv.itemList[i])} ");
            }
            Console.Write(sb.ToString());
            switch (command)
            {
                case 1:
                    Console.WriteLine("사용할 아이템을 선택해주세요.");
                    input = Console.ReadLine();
                    if (false == int.TryParse(input, out command))
                    {
                        Console.WriteLine("잘못 입력하였습니다.");
                        return;
                    }
                    else if (command > inv.itemList.Count)
                    {
                        Console.WriteLine("이 인덱스엔 아이템이 존재하지 않습니다.");
                        return;
                    }
                    Console.WriteLine($"{command+1}.");
                    Console.WriteLine($" {inv.itemList[command - 1].name} 을 사용합니다");
                    if (command < 0 ||  command > inv.itemList.Count)
                    {
                        Console.WriteLine("잘못된 선택입니다.");
                        Console.WriteLine("다시 맵 화면으로 나갑니다");
                        Thread.Sleep(1500);
                        return;
                    }
                    Thread.Sleep(1500);

                   Item selectedMyItem = inv.itemList[command -1];
                   selectedMyItem.Use(command);
                    Console.WriteLine("다시 맵 화면으로 나갑니다");
                    Thread.Sleep(1500);
                    Console.Clear();
                    game.Map();
                    break;
                case 2:
                    Console.WriteLine("버릴 아이템을 선택해주세요.");                    
                    input = Console.ReadLine();
                    if (false == int.TryParse(input, out command))
                    {
                        Console.WriteLine("잘못 입력하였습니다.");
                        return;
                    }
                    Console.WriteLine($"{inv.itemList[command].name}을 버립니다. 다신 돌려받을수 없습니다");
                    Console.Write("어떻게 하시겠습니까? Y/N");
                    ConsoleKeyInfo info = Console.ReadKey();
                    ConsoleKey key = info.Key;
                    switch (key)
                    {
                        case ConsoleKey.Y:
                            Console.WriteLine("아이템을 버립니다.");
                            Console.WriteLine("{0} 을/를 버렸습니다.", inv.itemList[command].name);
                            inv.deleteItem(command );
                            break;
                        case ConsoleKey.N:
                            Console.WriteLine("아이템을 버리지 않습니다.");
                            break;
                    }
                    Console.WriteLine("다시 맵 화면으로 나갑니다");
                    Thread.Sleep(1500);
                    game.Map();
                    break;
                    case 3:
                        Console.WriteLine("다시 맵 화면으로 나갑니다");
                    Thread.Sleep(1500);
                    game.Map();
                    break;
                default:
                    Console.WriteLine("잘못 입력하였습니다.");
                    break;
            }
            
        }
    }
}
