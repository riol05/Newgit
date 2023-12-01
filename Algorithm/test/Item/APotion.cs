using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class APotion : Item
    {
        private int healPoint = 60;
        public APotion()
        {
            name = "고급 포션";
            Description = $"사용자의 체력을 {healPoint} 상승 시켜줍니다";
            CanUse = 1;
            amount = 20;
        }

        public override void Use(Player player, int command)
        {
            if (CanUse == 1)
            {
                inv.deleteItem(command - 1);
            }
            player.heal(healPoint);
        }
    }
}
