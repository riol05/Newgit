using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05._Queue
{
    internal class Program
    {
        /******************************************************
		 * 큐 (Queue)
		 * 
		 * 선입선출(FIFO), 후입후출(LILO) 방식의 자료구조
		 * 입력된 순서대로 처리해야 하는 상황에 이용
		 * 순차적인 자료구조
		 ******************************************************/
        // 연속기 : 평타 , 2타, 3타 구현하는데도 사용 가능
        
        void Queue()
        {
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < 5; i++)
            {
                queue.Enqueue(i); // 입력순서 : 0, 1, 2, 3, 4 // 넣을땐 Enqueue 로 넣는다
                Console.WriteLine(queue.Peek());        // 최전방 : 0
            }
            queue.Peek(); // 가장 앞에 있는 숫자 확인하기
            // stack 에선 가장 위에 있는 숫자 확인하기. 꺼내는건 아니고 확인만.

            while (queue.Count > 0)
            {
                int value =queue.Dequeue();
                Console.WriteLine(value); // 꺼낼땐 Dequeue로 꺼낸다
            }// 출력순서 : 0, 1, 2, 3, 4
        }
        
        static void Main(string[] args)
        {
            DataStructure.Queue<int> queue = new DataStructure.Queue<int>();

            for (int i = 0; i < 5; i++) queue.Enqueue(i);

            Console.WriteLine(queue.Peek());

            while (queue.Count > 0) Console.WriteLine(queue.Dequeue());     // 출력순서 : 0, 1, 2, 3, 4
        }
    }
}