using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public abstract class Item
    {
        public string Description;
        public string name;
        public int CanUse; // 사용 가능 여부
        public int amount;
        Inventory inv = Inventory.GetInstance();
        

        public string Des()
        {
            return Description;
        }

        public virtual void Use(int command)
        {
            if (CanUse == 1)
            {
                inv.deleteItem(command);
            }
            else
            {
                return;
            }
            
        }
    }
}
