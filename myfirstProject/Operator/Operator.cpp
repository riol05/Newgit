﻿// Operator.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//

#include <iostream>
using namespace std;

/**************************************************************
   * 연산자 (Operator)
   *
   * 프로그래밍 언어에서는 일반적인 수학 연산과 유사한 연산자들이 지원됨
   * C++는 여러 연산자를 제공하며 기본 연산을 수행할 수 있음
   **************************************************************/


int main()
{
    bool bValue = false;
    int iValue = 0;
    float fValue = 0.0f;
    /**************************************************************
     * 산술 연산자
     **************************************************************/

     // <이진 연산자>
    iValue = 1 + 2;     // +(더하기)
    iValue = 3 - 1;     // -(빼기)
    iValue = 4 * 2;     // *(곱하기)
    fValue = 5.f / 3;   // /(나누기) : 주의! 5 / 3 과 같이 int의 나눗셈은 소수점을 버림 5.0 / 3.0 식으로 소수점을 표현한다.
    //혹은 (double) 5 / 3 식으로 표현 더블은 느리기 때문에 5.0f / 3.0f 로 하게되면 조금더 빠름. 0으로 나누기는 오류가 뜬다.
    iValue = 13 % 3;    // %(나머지)	: a - (a / b) * b 와 동일

    // <단항 연산자>
    iValue = +iValue;   // + 단항연산자(양수)	: 값을 반환; : 뒤에 값 그대로 갖다 쓰는거라 잘 안쓰임
    iValue = -iValue;   // - 단항연산자(음수)	: 값의 마이너스를 반환; 
    ++iValue;           // ++ 전위증가연산자	: 값을 1 증가
    iValue++;           // ++ 후위증가연산자	: 값을 1 증가
    --iValue;           // -- 전위감소연산자	: 값을 1 감소
    iValue--;           // -- 후위감소연산자	: 값을 1 감소

    // <전위연산자와 후위연산자>
  // 전위연산자 : 값을 반환하기 전에 연산
    iValue = 0;
    cout << iValue << endl;      // output: 0
    cout << ++iValue << endl;    // output: 1 증가가 된 결과가 출력이 된다.
    cout << iValue << endl;      // output: 1						
    // 후위연산자 : 값을 반환한 후에 연산
    iValue = 0;
    cout << iValue << endl;      // output: 0
    cout << iValue++ << endl;    // output: 0 출력이 먼저 되고 그다음에 증가가 된다.
    cout << iValue << endl;      // output: 1


    /**************************************************************
    * 대입 연산자
    **************************************************************/

    // <대입 연산자>
    iValue = 10;        // = : 오른쪽의 값을 왼쪽 변수에 대입

    // <복합 대입 연산자>
    // 이진 연산자(op)의 경우
    // x op= y 는 x = x op y 와 동일
    iValue += 5;        // iValue = iValue + 5; 와 동일
    iValue -= 5;
    iValue *= 5;
    iValue /= 3.0f;


    /****************************************************************
     * 비교 연산자
     ****************************************************************/

     // <비교 연산자>
    bValue = 3 > 1;     // > : 왼쪽 피연산자가 더 클 경우 true // bValue = true; 로 바뀜
    bValue = 3 < 1;     // < : 왼쪽 피연산자가 더 작을 경우 true // 이경우 false; 로 바뀜
    bValue = 3 >= 1;    // >= : 왼쪽 피연산자가 더 크거나 같은 경우 true
    bValue = 3 <= 1;    // <= : 왼쪽 피연산자가 더 작거나 같은 경우 true
    bValue = 3 == 1;    // == : 두 피연산자가 같은 경우 true
    bValue = 3 != 1;    // != : 두 피연산자가 다를 경우 true 똑같을 경우 false;

    /****************************************************************
     * 논리 연산자
     ****************************************************************/

     // <논리 연산자>
    bValue = !false;        // !(Not) : 피연산자의 논리를 반대로// false의 부정은 true. 반대의 경우도 반대로
    bValue = true && false; // &&(And) : 두 피연산자가 모두 true 일 경우 true //하나라도 false 거나 둘다 false면 false 값을 가진다.
    bValue = true || false; // ||(Or) : 두 피연산자가 모두 false 일 경우 false //| 는 역슬래쉬를 쉬프트로 누른다. or 연산자.// 둘다 false 일 경우에만 false 값을 가짐.
    bValue = true ^ false;  // ^(Xor) : 두 피연산자가 다를 경우 true // 이경우엔 둘만 있을때 //캐럿 (몰라도 된다.)

    // <조건부 논리 연산자>
    // 조건부 논리 And 연산자 &&
    // 빠른 계산을 위해 false && x(논리자료형) 의 경우 어떠한 논리자료형이 있어도
    // 결과는 항상 false이기 때문에 false && x 에서 x는 무시하게 됨
    iValue = 10;
    bValue = false && (++iValue > 5); // 결과가 늘어나지 않는다. 앞의 결과만 바뀌게 된다. 뒤에 결과를 계산하지 않아도 false로 나오기 때문.
    cout << iValue << endl;  // output : 10

    // 조건부 논리 Or 연산자 ||
    // 빠른 계산을 위해 true || x(논리자료형) 의 경우 어떠한 논리자료형이 있어도
    // 결과는 항상 true이기 때문에 true || x 에서 x는 무시하게 됨
    iValue = 10;
    bValue = true || (++iValue > 5); // 마찬가지로 결과는 늘어나지 않는다. 무시되었기 때문에.
    cout << iValue << endl;  // output : 10

    /****************************************************************
     * sizeof 연산자
     ****************************************************************/

     // <sizeof 연산자>
     // 자료형의 메모리 크기를 확인할 수 있음. 자료형의 크기가 얼마나 나올지 확인하기 위해서 배열을 만들때 사용된다.
    cout << " char형 데이터에 할당되는 메모리의 크기는 " << sizeof(char) << " 바이트입니다." << endl;
    cout << " short형 데이터에 할당되는 메모리의 크기는 " << sizeof(short) << " 바이트입니다." << endl;
    cout << " int형 데이터에 할당되는 메모리의 크기는 " << sizeof(int) << " 바이트입니다." << endl;
    cout << " long long형 데이터에 할당되는 메모리의 크기는 " << sizeof(long long) << " 바이트입니다." << endl;
    cout << " float형 데이터에 할당되는 메모리의 크기는 " << sizeof(float) << " 바이트입니다." << endl;
    cout << " double형 데이터에 할당되는 메모리의 크기는 " << sizeof(double) << " 바이트입니다." << endl;

    /****************************************************************
   * 비트 연산자
   ****************************************************************/

   // <단항 연산자>
   //8bit == 1byte
    //1024byte == 킬로바이트
    //1024 킬로바이트= 기가바이트
    // 0과 1이 bit  
    //8
    //      물  불  풀  드래곤  
    //0000  0   1   0    1
    // 이렇게 비트 연산자를 사용하면 bool 명령어를 여러개 쓰지않고 true false를 판단할수있다.  // 유니티의 레이어 마스크
    iValue = ~0x35;         // ~(비트 보수) : 데이터를 비트단위로 보수 연산(바꾼다.) (보수 : 0->1, 1->0)

    // <이진 연산자>

    iValue = 0x11 & 0x83;   // &(And) : 데이터를 비트단위로 And 연산 // iValue = 10 & 20; ex) 특정 비트들의 공통점을 빠르게 찾아준다. 파이리는 용족 불타입이다. 파이리는 불 타입 포켓몬이다.
    iValue = 0x11 | 0x83;// |(Or) : 데이터를 비트단위로 Or 연산 ex) 플레이어의 상태에 화상상태가 중첩된다.
    iValue = 0x11 ^ 0x83;   // ^(Xor) : 데이터를 비트단위로 Xor 연산 ex) 만병 통치약으로 화상, 독상태가 사라진다.

    
    // <비트 쉬프트 연산자>
    iValue = 0x20 << 2;     // << : 왼쪽의 피연산자의 비트를 오른쪽 피연산자만큼 왼쪽으로 이동 ex) 13 << 1 = 130; 이건 13*10 =130; 과 같다. 곱하기
    iValue = 0x20 >> 2;     // >> : 왼쪽의 피연산자의 비트를 오른쪽 피연산자만큼 오른쪽으로 이동 ex ) 10 >> 1 = 5; 10 * 0.5 = 5; 10 / 2 = 5; 나누기
    //나누기보다 곱하기가, 곱하기보다,  비트 쉬프트 연산이 나누기와 곱하기보다 빠르다.

// 0b110101 이진수에 0b를 붙여서 쓴다.
// 01234567 0을 붙여서 쓰면 8진수가 된다. (잘 쓰지않음.)
// 0x를 붙여 쓰면 16진수 ABCDEF
//0.1f를 하면 float가 되듯이 다른 진법들도 사용가능하다.
// iValue = 5 | 1 ; 는 iValue = 0b0101 | 0b0001; 와 같다.  

    //int result = 0b1101'0110 & 0b0011'1111; //int 를 쓰면 32비트를 모두 써줘야한다.
    // 1101 0110
    //&0011 1111
    //==========
    // 0001 0110 -> 2 + 4 + 16 = 22
    // 비트 쉬프트를 잘못 쓰면 오버 플로우 언더 플로우가 생길 가능성이 생긴다. 그때 unsigned를 사용해 이것을 방지할수있다.

        /****************************************************************
     * 연산자 우선순위
     *
     * 여러 연산자가 있는 식에서 우선 순위가 높은 연산자가 먼저 계산
     ****************************************************************/

     // <연산자 우선순위>
     // 1. 기본 연산        : a[i], x++, x--
     // 2. 단항 연산        : +x, -x, !x, ~x, ++x, --x, (Type)x
     // 3. 곱하기 연산       : x * y, x / y, x % y
     // 4. 더하기 연산       : x + y, x - y
     // 5. 시프트 연산       : x << y, x >> y
     // 6. 비교 연산	        : x < y, x > y, x <= y, x >= y
     // 7. 같음 연산	        : x == y, x != y
     // 8. 논리 AND 연산    : x & y, x && y
     // 9. 논리 XOR 연산    : x ^ y
     // 10. 논리 OR 연산    : x | y, x || y
     // 11. 대입 연산       : x = y, x op= y

    // 뭐가 먼저 되는지 헷갈릴땐 괄호를 쳐서 사용하자.

    /* <비트 마스크> // 비트 연산 자체는 자주 사용하지 않는다.
    * 유니티에선 레이어 마스크
    * 비트 연산자를 이용해서 처리할 경우, 메모리 소모가 빠르고 연산 속도가 빠르다. bool 변수를 사용한다면 32개를 써야한다
    * const int FIRE    = 1 << 0 = 1;
    * const int WATER   = 1 << 1 = 2;
    * const int GRASS   = 1 << 2 = 3;
    * const int DRAGON  = 1 << 3 = 4;
    * 
    * int 파이리 = FIRE = 1;
    * int 꼬부기 = WATER = 2;
    * int 이상해씨 = GRASS = 3; 으로 숫자로 바꿔줘야 한다.
    * int 리자몽 = FIRE + DRAGON = FIRE | DRAGON // |(or) 를 이용해서도 가능하다. +를 사용하면 실수
    * 직관적으로 볼수있는 비트 마스크가 더 편한
    * 
    * int playerState = NONE;
    * playerstate |= STURN;             //스턴 걸기 : 비트 마스크 항목추가.
    * playerstate &= ~STURN;            //스턴 풀기 : 비트 마스크 항목삭제.
    * playerstate &= STURN;            //항목 확인: 스턴이 1이었던 상황이면 1이 나오고 0이었도 1이 나온다.
    * 
    * bool isSturned = playerstate & Sturn ; // 스턴 여부 확인 : 비트 마스크 항목 확인.
    * 
    */

}