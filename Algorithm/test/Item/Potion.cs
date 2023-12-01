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

        public Potion()
        {
            name = "포션";
            Description = $"사용자의 체력을 {healPoint} 상승 시켜줍니다";
            CanUse = 1;
            amount = 20;
        }

        public virtual void Use(Player player, int command)
        {
            

            if (player.CurHp == player.MaxHp)
            {
                Console.WriteLine("플레이어의 체력이 꽉 차 있어 물약을 마시지 않습니다.");
                base.Use(command- 1);
            }
            Console.WriteLine($"플레이어의 체력을 {healPoint} 만큼 회복합니다");
            player.CurHp = player.CurHp + healPoint;
            base.Use(command -1);
             player.CurHp += healPoint;
        }
    }
}
