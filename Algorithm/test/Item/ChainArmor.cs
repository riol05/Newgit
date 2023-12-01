using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace test
{
    public class ChainArmor : Item
    {
        private int Defence = 10;
        public override void Use(Player player, int command)
        {
            if (CanUse == 1)
            {
                inv.deleteItem(command - 1);
            }
            player.EquipArmor(Defence);
        }
    }
}
