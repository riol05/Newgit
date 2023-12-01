using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Potion : Item
    {
        private int healPoint = 30;
        public Player player;
        public Potion()
        {
            name = "포션";
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
