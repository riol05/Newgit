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
        public ChainArmor()
        {
            name = "철 갑옷";
            Description = $"사용자의 방어력을 {point} 상승 시켜줍니다";
            CanUse = 1;
            amount = 30;
            weight = 7;
            point = 20;
        }
        public override void Use(Player player, int command)
        {
            if (CanUse == 1)
            {
                inv.deleteItem(command - 1);
            }
            player.EquipArmor(point);
        }
    }
}
