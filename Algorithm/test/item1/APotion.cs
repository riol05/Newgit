using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Potion : Item1
    {
        
        public Potion()
        {
            name = "포션";
            Description = $"사용자의 체력을 {Point} 상승 시켜줍니다";
            CanUse = 1;
            amount = 20;
            Point = 60;
        }

        public override void Use()
        {
            Console.WriteLine($"포션을 사용하여 {Point} 만큼 체력을 채웁니다");

            DataClass.Instance.player.CurHp =  DataClass.Instance.player.CurHp + Point;
        }
    }
}
