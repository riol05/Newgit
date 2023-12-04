using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Inventory
    {
        private static int MaxCount = 6;
        public List<Item> itemList;
        private bool Full = false;
        public int CanBuy = 1;
        public int gold = 100;
        protected Inventory() 
        {
            itemList = new List<Item>();

        }
        
        private static Inventory instance;        
        public static Inventory GetInstance()
        {
            if (instance == null)
            {
                instance = new Inventory();
            }
            return instance;
        }

        public void checkFull()
        {

            if (itemList.Count >= MaxCount)
            {
                Console.WriteLine("아이템이 가득 찼습니다.");
                Full = true;
            }
        }
        public string Des(Item item)
        {
            return item.Des();
        }
        public void AddItem(Item item)
        {
            checkFull();
            if (Full == false)
            {
                itemList.Add(item);
               Console.WriteLine($"{itemList[itemList.Count() - 1].name}을 획득 하였습니다.");
            }/*[itemList.Where(x => x.Equals(item)).Count() - 1 */
            else   // Full = true;
            {
                Console.WriteLine("아이템이 가득찼습니다.");
                Console.WriteLine("아이템을 획득할수 없습니다.");
                return;
            }
        }
        public void sortedList()
        {
            Console.WriteLine("1. 이름순 정렬\t 2. 무게순 정렬");
            string input = Console.ReadLine();
            int command;
            if (false == int.TryParse(input, out command))
            {
                Console.WriteLine("잘못 입력하셨습니다.");
                return;
            }
            switch (command)
            {
                case 1:
                    // 이름순 정렬
                    itemList.Sort(
                        Comparer<Item>.Create((a, b)
                        =>
                        { return a.name.CompareTo(b.name); })); // sort 하고 싶은 내용을 넣어준다
                                                                // => 가 람다식 연산자 
                    break; // Comparer<Item1>.Create((a, b) 이부분을 CompareTo 함수를 만들어 대체해도 된다.
                case 2:
                    //무게순 정렬
                    itemList.Sort(
                        Comparer<Item>.Create((a, b)
                        =>
                        { return a.weight - b.weight; })); // 무게순 정렬 인트로 weight을 결정했다

                    break;
                default:
                    Console.WriteLine("잘못 입력하셨습니다.");
                    Thread.Sleep(1000);
                    break;

            }
        }
        public void deleteItem(int num)
        {
            itemList.RemoveAt(num);
        }
        public void SpendGold(int amount)
        {
            if (amount < this.gold)
            {
                Console.WriteLine("아이템을 구매할수없습니다");
                Console.WriteLine("현재 잔액 {0} 골드, 구매 아이템 가격인 {1} 골드 보다 모자랍니다", gold, amount);
                CanBuy = 0;
            }
            Console.WriteLine("아이템을 구매하였습니다");
            Console.WriteLine("골드를 {0} 골드 만큼 사용하여 현재 잔액은 {1} 골드 입니다", amount, gold - amount);
            this.gold -= amount;
        }
        public void AddGold(int amount)
        {
            Console.WriteLine("{0} 골드 획득 하였습니다 ", amount);
            this.gold  += amount;
        }

    }
}
