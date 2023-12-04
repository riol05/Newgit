using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class LargePotion : Potion
    {
        public LargePotion() : base()
        {
            name = "큰 포션";
            Point = 60;
            weight = 3;
        }
    }
}
