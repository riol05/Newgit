using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public struct Position
    {
        public int x; 
        public int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public enum Direction
    {
        UP= 1,
        DOWN = 2,
        LEFT = 3,
        RIGHT =4

    }
}
