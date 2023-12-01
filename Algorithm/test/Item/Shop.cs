using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{

        public class Shop
        {
            Inventory inven = Inventory.GetInstance();

            List<Item> Item1 = new List<Item>();
            public void SellItem(Item item)
            {
                Console.WriteLine($"{item.name} 을/를 {item.amount} 골드로 구매합니다.");
                inven.SpendGold(item.amount);
                if (inven.CanBuy == 0)
                {
                    inven.CanBuy = 1;
                    return;
                }
                inven.AddItem(item);
                return;
            }
        }
    
}
