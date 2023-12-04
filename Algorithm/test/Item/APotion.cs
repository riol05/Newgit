using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class APotion : Item
    {
        public APotion()
        {
            name = "고급 포션";
            Description = $"사용자의 체력을 {point} 상승 시켜줍니다";
            CanUse = 1;
            amount = 20;
            weight = 3;
            point = 60;
        }

        public override void Use(Player player, int command)
        {
            if (CanUse == 1)
            {
                inv.deleteItem(command - 1);
            }
            player.heal(point);
        }
    }
}
