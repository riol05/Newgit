using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._Delegate.Basic
{
    internal class Chain
    {
        public delegate void DelegateChain();

        public static void Func1() { Console.WriteLine("Func1"); }
        public static void Func2() { Console.WriteLine("Func2"); }
        public static void Func3() { Console.WriteLine("Func3"); }
        public static void Func4(string str) { Console.WriteLine(str); }

        public static void test1()
        {
            
            /*Action action = Func1;
            action();// Func1 이 출력
            action = Func2;
            action(); // Func2 가 그다음 차례대로 출력*/

            // <델리게이트 체인>
            // 하나의 델리게이트 변수에 여러 개의 함수를 할당하는 것이 가능
            // +=, -= 연산자를 통해 할당을 추가하고 제거할 수 있음
            // = 연산자를 통해 할당할 경우 이전의 다른 함수들을 할당한 상황이 사라짐

            Action action;
            action = Func1;
            action += Func2;
            action += Func3;
            Action<string> action =Func4;
            // action -= Func2; 를 하게되면 Func2가 빠진 결과를 볼수 있게 된다. action += Func1 붙이면 또 호출하게 된다.
            // -= Func2 를 하게되면 앞에 붙인 변수가 아닌 마지막에 붙인 델리게이트 변수가 빠지게된다.

            // action -= Func2; 한번 붙이고 두번 빼게 되면 오류가 날거 같지만 Func2 는 무시되어 출력되게 된다.
            // action = Func2; 아예 Func2를 대입하게 되면 전에 붙여 놓은 데이터들은 싹 날아가고 Func2만 호출되게 된다.
            // action -=Func2; Func2만 출력되는 상황에 Func2를 빼어주게 되면 NULL이 되기 때문에 프로그램이 터지게된다.

            action(); // 붙어있는 모든 함수가 다같이 호출되어 출력된다.

            action -= Func2; // 델리게이트를 뺸다음 붙여주는것을 습관화 하면 델리게이터가 두번 호출되는것을 막을수 있다. // 초록줄은 NULL 일수도 있으니 주의하란 경고
            action += Func2;
            if (action != null) // NULL 체크없이 프로그램을 키면 터지기 때문에, NULL 체크를 해보고 델리게이트를 쓰는것을 권장
            {
                action();
            }
            
        }
        public static void Test()
        {
            // <델리게이트 체인>
            // 하나의 델리게이트 변수에 여러 개의 함수를 할당하는 것이 가능
            // +=, -= 연산자를 통해 할당을 추가하고 제거할 수 있음
            // = 연산자를 통해 할당할 경우 이전의 다른 함수들을 할당한 상황이 사라짐

            DelegateChain delegateVar;
            delegateVar = Func2;        // 델리게이트 인스턴스를 Func2 로 초기화
            delegateVar += Func1;       // 델리게이트 인스턴스에 Func1 추가 할당
            delegateVar += Func3;       // 델리게이트 인스턴스에 Func3 추가 할당
            delegateVar();              // Func2, Func1, Func3이 순서대로 호출됨

            delegateVar -= Func1;       // 델리게이트 인스턴스에 Func1 할당 제거
            if (delegateVar != null)    // 델리게이트 인스턴스에서 할당을 제거할 경우 null을 조심해야 함
                delegateVar();          // Func2, Func3이 순서대로 호출됨

            delegateVar += Func2;
            delegateVar += Func2;       // 같은 함수를 여러번 할당한 경우 여러번 호출됨
            delegateVar();              // Func2, Func3, Func2, Func2이 순서대로 호출됨

            delegateVar -= Func1;       // 델리게이트 인스턴스에 할당되지 않은 함수를 제거하는 경우 문제 없음

            delegateVar = Func1;        // 델리게이트 인스턴스에 = 을 통해 할당할 경우 이전의 할당된 상황이 사라짐
            delegateVar();              // Func1이 호출됨
        }
    }
}