using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{

    public class Shop
    {
        public Position pos;
        public char icon;
        Inventory inven = Inventory.GetInstance();
        public Shop()
        {
            icon = '샵';
        }


        List<Item> Item1 = new List<Item>();
        public void SellItem(Item item)
        {
            //for (int i = 0; i < item1.Count; i++)
            //{

            //}
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
