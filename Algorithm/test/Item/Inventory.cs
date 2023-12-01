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
            itemList.Sort();
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
