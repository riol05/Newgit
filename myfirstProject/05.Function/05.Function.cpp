// 05.Function.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//

#include <iostream>

using namespace std;


    /****************************************************************
 * 함수 (Function /Procedure)
 *
 * 미리 정해진 동작을 수행하는 코드 묶음
 * 어떤 처리를 미리 함수로 만들어 두면 다시 반복적으로 사용 가능
 ****************************************************************/

 // <함수 구성>
 //// 반환형 함수이름(매개변수목록) { 함수내용 }
    int Add1(int left, int right) { return left + right; }
    void Func1() {}     // 매개변수가 없는 경우 빈괄호 

    // <함수 사용>
    // 작성한 함수의 이름에 괄호를 붙이며, 괄호안에 매개변수들을 넣어 사용
    void Main1()  // 이게 함수라고한다.
    {
        Add1(1, 2);
        Add1(3, 4);

        Func1();
    }
    void ThreeMain1() // 함수 이름은 직관적으로 정해두자.
    {
        Main1();// 함수를 사용 할때
        Main1();
        Main1();// 함수안에 다른 함수를 여러개 넣을수 있다.
    }
    
   // cout 또한 함수로 생각할수 있다. (이게 함수가 중요한 이유 우린 그 원리에 대해 자세히 알지 못해도 사용하는데 전혀 무리가 없다.)
    // 절차적 프로그래밍 : 처음부터 끝까지의 실행 순서를 감안해서 작성하는 방법
    //함수형 프로그래밍 : 행동 단위를 묶어서 직관적으로 프로그래밍 하는 기법

// <반환형 (Return Type)>
// 함수의 결과(출력) 데이터의 자료형
// 함수의 결과 데이터가 없는 경우 반환형은 void
// <return>
// 함수가 끝나기 전까지 반드시 return으로 반환형에 맞는 데이터를 return 해야함
// 함수 진행 중 return을 만났을 경우 그 결과 데이터를 반환하고 함수를 탈출함
// void 반환형 함수의 return은 생략 가능

    int Bigger(int left, int right)
    {
        int result = left > right ? left : right;
        return result; // return 이 결과를 주는것임   // 여기선 둘중에 더 큰 수를 꺼내겠다 라는뜻 e) 삼항 연산자
    }
    int main()
    {
        int num1 = 10;
        int num2 = 20;
        int bigger = Bigger(num1, num2);
        cout << "둘중 더 큰수는 ? : " << bigger << endl;

    } // 반환형은 이런식으로 사용할수있다.

    string RPCinput()
    {
        cout << "가위 바위 보 중에 입력해주세요" << endl;
        string command;
        cin >> command;
        return command;

    }
    int main()
    {
        string usercommand = RPCinput();
        cout << "사용자가 입력한 내용은? : " << endl;


    }// 원하는 기능 자체를 만들어 줄수있다.

int IntReturnFunc2()
{
    cout << "return 전" << endl;
    return 10;                      // return 을 통해 10 값을 가지고 함수가 완료됨
    cout << "return 후" << endl;     // return 에서 함수가 완료되므로 실행되지 않음
}

void VoidReturnFunc2()
{
    cout << "return 전" << endl;
    // void 반환형은 함수 내용 중 return 을 생략 가능하나 함수를 종료하고 싶을때도 사용가능
    return;                         // void 반환형은 return 데이터가 없음
    cout << "return 후" << endl;
}

void Main2()
{
    int value = IntReturnFunc2();       // IntReturnFunc2 함수가 10 값을 반환하므로 value는 10이 됨
    VoidReturnFunc2();                  // 반환값이 없는 void 함수는 일반적으로 함수내에서 행동이 의미 있음
    // int value = VoidReturnFunc2();   // error : VoidReturnFunc2 함수가 void 반환형이므로 반환데이터가 없음
}



// <매개변수 (Parameter)>
// 함수에 추가(입력)할 데이터의 자료형과 변수명
// 같은 함수에서도 매개변수 입력이 다름에 따라 다른 처리가 가능

// <전방선언(Forward Declaration)>
// 프로그램은 위에서 부터 차례대로 진행되기 때문에
// 아래서 구현한 함수 사용이 불가하다.
// 선언만 먼저 진행한후 아래에서 구현한 경우에는 사용 가능하다. 이경우 전방 선언을 얼마나 하던 상관없이 구현이 가능하다.
// 선언 : 반환형 함수이름(매개 변수 목록);
// 구현 : 반환형 함수이름(매개 변수 목록) {함수 내용}


int Add3(int left, int right) // 위에서 함수 전방 선언만 해주고 int main ()보다 아래에 함수 선언을 하면 문제없이 함수를 사용할수있다.
{
    // 함수의 입력으로 넣어준 매개변수 left, right 에 따라 함수가 동작
    return left + right;
}

void Main3()
{
    int value1 = Add3(10, 20);      // 매개변수 10, 20이 들어간 Add3 함수의 반환은 30
    int value2 = Add3(10, 10);      // 매개변수 10, 10이 들어간 Add3 함수의 반환은 20
}


// <함수 호출스택>
// 함수는 호출되었을 때 해당 함수블록으로 제어가 전송되며 완료되었을 때 원위치로 전송됨
// 이를 관리하기 위해 호출스택을 활용함
// 함수가 순환구조로 무한히 호출되어 더이상 스택에 빈공간이 없는 경우 StackOverflow가 발생
// 함수 안에 있는 변수는 지역 변수: 함수 내부에서 사용가능, 함수 시작부터 끝까지 살아있다.
// 전역 변수는 함수 밖에 있는 변수로 프로그램 전역에서 사용 가능하다. 프로그램의 시작부터 끝까지 살아있다.
// do while  반복문에서도 do {int i = 0}while(i == 1) 을 하지 못한다. 여기서 i 는 지역 변수이기 때문. do while 은 함수로 사용된다.
void Func4_2()
{                           // 1
    cout << "End" << endl;  // 2
}                           // 3

void Func4_1()
{                           // 4
    Func4_2();              // 5
}                           // 6

void Main4()
{                           // 7
    Func4_1();              // 8
}                           // 9
// 함수 호출 순서 : 7 -> 8 -> 4 -> 5 -> 1 -> 2 -> 3 -> 6 -> 9

// <함수 오버로딩>/////<오버 로딩> vs <오버 라이딩>        //   //*************** 기술 면접 출제율 개개개 높다. ✨✨✨✨✨✨✨✨ C++의 지식의 깊이에 대해 물어보는 문제
// 같은 이름의 함수를 매개변수를 달리하여 다른 함수로 재정의하는 기술
int Sub(int left, int right) { return left - right; }
float Sub(float left, float right) { return left - right; }
double Sub(double left, double right) { return left - right; }

void Main5()
{
    cout << Sub(5, 3) << endl;        // Sub(int, int) 가 호출됨
    cout << Sub(5.1f, 3.2f) << endl;  // Sub(float, float) 가 호출됨
    cout << Sub(3.1, 3.2) << endl;    // Sub(double, double) 가 호출됨
}

// <인라인 함수>
// 함수의 호출과정에서 발생하는 오버헤드를 줄이기 위해 함수의 모든 코드를 호출된 자리에 바로 삽입하는 방식의 함수
// 이는 반복적인 호출에서 걸리는 시간을 절약할 수 있으나, 함수 호출 과정으로 생기는 이점을 포기하게 됨
// 따라서 코드가 매우 간단하며 잦은 호출이 있는 함수만을 인라인 함수로 선언하는 것이 좋음
// 참고 : 인라인 함수를 알고 있어야 하지만 최신 컴파일러는 함수를 적절하게 인라인화 하므로 대부분 inline 키워드를 사용할 필요는 없다.
// 요즘은 자동화 되있다. 최신 컴파일러에는 자동.


inline int Bigger(int left, int right) { return left > right ? left : right; }


int main()
{
    
}