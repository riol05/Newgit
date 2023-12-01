using System;

namespace Project// 수업은 최상위문 사용 안함으로 진행된다.
{
    // void a() { };
    // int a; // C++ 처럼 전역 변수나 전역 함수로 사용하지 않는다. 대신 static변수 로 어디서든 접근할수 있는 변수를 만들수있다.  
    internal class Program //C# 은 완전 객체 지향 언어이기 때문에 전역 함수나 전역 변수를 사용할수 없다.
    {
        /* Main 함수
		 * 
		 * 프로그램의 처음시작 지점이 되는 함수
		 * 모든 C# 프로그램은 Main이라는 시작 함수가 단 1개만 있어야 함
		 */
        static void Main(string[] args) //args는 신경쓰지 않아도 된다. 유니티 쓸땐 args를 쓸일이 없다. 포함하고있음.static변수 로 어디서든 접근할수 있는 변수를 만들수있다.
            //static 은 인스턴스를 생략할수있다.
        {
            // 프로그램은 Main 함수를 시작으로 순서대로 처리됨

            /* Console 클래스
			 * 
			 * 콘솔 프로그램을 다루기 위해 사용하는 클래스
			 * Console.WriteLine	: 콘솔에 출력하고 줄 바꿈
			 * Console.Write		: 콘솔에 출력하고 줄을 바꾸지 않음
			 * Console.ReadLine		: 콘솔을 통해 한줄 입력받음
			 * Console.ReadKey		: 콘솔을 통해 키 입력받음
			 */

            /*
            static void Main(string[] args) // 메인 함수도 인스턴스 없이 시작할수 있게 스태틱이 붙어있다.
            {
                Console.Write("이름을 입력해주세요 : "); // 그냥 한줄 출력

                Console.WriteLine("Hello, World!");// 한줄 출력. 엔터까지 쳐준다.

                string text = Console.ReadLine();// 입력은 콘솔 리드라인으로 가능하다.

            }
        }*/
    }