using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace test
{
    internal class hanoiTower
        // 하노이의 탑
    {/* n개를 시작- > 목적지 하기위해
      * n-1개를 시작 -> 중간
      * 1개를 시작 -> 목적지
      * n-1개를 중간 -> 목적지
      */
        int hanoi(int start, int end, int count)

        {
            int other;
            hanoi(start, other, count - 1);
            hanoi(start, end, 1);
            hanoi(other, end,count - 1);
            return;
        }
        private void Move(int start, int end, int count)
        {
            if (count ==1)
            {
                int value = pins(start).Pop();
                pins[end].Push(value);
                Console.WriteLine("{value} 원판을 {start} 기둥에서 {end} 기둥으로 옮기기");

                return;
            }
        }
    }
}
