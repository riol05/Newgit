using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report
{
    internal class Test

    {
        public delegate void cal(int a, int b);
        public void plus(int a, int b)
        {
            Console.WriteLine(a + b);
        }
        public void minus(int a, int b)
        {
            Console.WriteLine(a - b);
        }
        public void multi(int a, int b)
        {
            Console.WriteLine(a * b);
        }
        public void devide(int a, int b)
        {
            Console.WriteLine(a / b);
        }
        public Test()
        {

            cal p = new cal(plus);
            cal m = new cal(minus);
            cal mt = new cal(multi);
            cal d = new cal(devide);

            Console.Write("계산기 입니다. + ,- ,* ,/ 원하는 연산자를 선택해주세요");
            Console.Write("입력: ");
            string input = Console.ReadLine();
            while (true)
            {
                Console.WriteLine("끝내고 싶으면 영어로 채팅창에 esc를 눌러주세요");
                if (input == "+")
                {
                    Console.WriteLine("숫자를 입력하세요.");
                    int input1;
                    input1 = int.Parse(Console.ReadLine());
                    int input2; input2 = int.Parse(Console.ReadLine());
                    p(input1, input2);
                    
                }
                else if (input == "-")
                {
                    Console.WriteLine("숫자를 입력하세요.");
                    int input1;
                    input1 = int.Parse(Console.ReadLine());
                    int input2;
                    input2 = int.Parse(Console.ReadLine());
                    m(input1, input2);
                    
                }
                else if (input == "*") 
                {
                    Console.WriteLine("숫자를 입력하세요.");
                    int input1;
                    input1 = int.Parse(Console.ReadLine());
                    int input2;
                    input2 = int.Parse(Console.ReadLine());
                    mt(input1, input2);
                    
                }
                else if (input == "/")
                {
                    Console.WriteLine("숫자를 입력하세요.");
                    int input1;
                    input1 = int.Parse(Console.ReadLine());
                    int input2; 
                    input2 = int.Parse(Console.ReadLine());
                    d(input1, input2);
                    
                }
                else if (input == "esc")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("잘못입력");
                    continue;
                }
            }
            
        }
       
    }
        
 }

