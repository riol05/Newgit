using System;
using System.Collections.Generic;

namespace _04._Stack
{
    internal class Program
    {
        /******************************************************
		 * 스택 (Stack)
		 * 
		 * 스택과 큐 같은 경우 특정 상황에 따라 쓸수밖에 없는 자료 구조이다.
		 * 
		 * 선입후출(FILO), 후입선출(LIFO) 방식의 자료구조
		 * 가장 최신 입력된 순서대로 처리해야 하는 상황에 이용
		 * 효율보단 역할때문에 쓰는 자료구조
		 * 먼저 진행했던 것을의 순서를 결정해주는 큐
		 * 역순처리를 해주는 스택
		 * 쓸만한 곳은 UI나 설정창같은곳/ 뒤로가기 버튼/ctrl z 를 이용해 실행 취소를 하는 기능을 만들때
		 ******************************************************/

        void Stack()
        {
            Stack<int> stack = new Stack<int>(); // 11 /15 3 50분

            for (int i = 0; i < 5; i++)
            {
                stack.Push(i);  // 입력순서 : 0 1 2 3 4
                Console.WriteLine(stack.Peek());   // 최상단 : 4가 제일 먼저 나온다

            }

            for (int i = 0; i < 3; i++)
            {
                int value = stack.Pop(); // 출력 순서 : 4. 3 .2
                Console.WriteLine(value);
            }
            for (int i = 5; i < 10; i++)
            {
                stack.Push(i);
                Console.WriteLine(stack.Peek()); // 입력 순서: 0 1 5 6 7 8 9
            }

            while (stack.Count > 0)
            {
                int value = stack.Pop();          // 출력순서 :  1 0 
                Console.WriteLine(value); 
            }
        }


        static void Main(string[] args)
        {
            DataStructure.Stack<int> stack = new DataStructure.Stack<int>();

            for (int i = 0; i < 5; i++) stack.Push(i);  // 입력순서 : 0 1 2 3 4

            Console.WriteLine(stack.Peek());            // 최상단 : 4

            while (stack.Count > 0)
            {
                
                Console.WriteLine(stack.Pop());         // 출력순서 : 4 3 2 1 0
            }
        }
    }
}