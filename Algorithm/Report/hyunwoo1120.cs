
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST
{
    public class TestClass
    {

        public int Max_int = 0;
        public int i_min = 0;
        public int i_max = 0;
        public int Max_Number(int[] arr, int n)
        {
            int temp = 0;

            if (n < arr.Length)
            {
                for (int i = 0; i + n < arr.Length; i++)
                {
                    temp += arr[i + n];

                    if (temp > Max_int && temp != arr[i])
                    {
                        Max_int = temp;
                        i_max = i + n;
                        i_min = n;
                    }
                }

            }
            else
            {
                return 1;
            }

            return Max_Number(arr, n + 1);
        }



    }

    public class Hanoi
    {
        Stack<int> Hanoi1 = new Stack<int>();
        Stack<int> Hanoi2 = new Stack<int>();
        Stack<int> Hanoi3 = new Stack<int>();

        public Hanoi()
        {

        }
        public void Move(int Start, int to)
        {
            Console.WriteLine("{0}번 기둥에 있던 원판을 {1}로 옮깁니다.", Start, to);
        }
        public void HanoiAlgo(int n, int Start, int to, int end)
        {
            if (n == 1)
            {
                Move(Start, to);
            }
            else
            {
                HanoiAlgo(n - 1, Start, end, to);
                Move(Start, to);
                HanoiAlgo(n - 1, to, Start, end);
            }

        }

    }
}