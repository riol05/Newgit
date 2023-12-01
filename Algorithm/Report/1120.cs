using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace test
{/*연속적인 합으로 최대값이 되는 수 구하기 (동적계획법)
n개의 숫자(-100 ~ 100) 있을 때 연속적으로 더해서 최대값이 되는 시작지점과 끝지점 구하기

ex) 51, -17, -31,  8,  9, 21, -16,  9,  1 => 0 ~ 5 까지 더한 41이 최대값
*/
    internal class Program
    {
        static int test1(int x)
        {
            int[] test1 = { 51, -17, -31, 8, 9, 21, -16, 9, 1 };
            int[] test2 = new int[x];
            

            x = 0;
            for (int i = 0; i <= x; i++)
            {
                test1[i] = test1[i] + test1[i+1];
                test1[i] = test1[x];
            }
            Console.WriteLine(test1[x]);
            for (int i = 0; i >= 0; i--)
            {
               
                test1[i] = test1[x];
             test1[x] = test1[x] - test1[test1.Length -1];
                if (test1[x] < test1[i])
                {
                    test1[i] = test1[x];
                }
                else
                {
                    test1[x] = test1[i];
                }
            }
            Console.WriteLine(test1);
            return test1[x];

        }
        static void Main(string[] args)
        {
            test1(0);
        }
    }
}
