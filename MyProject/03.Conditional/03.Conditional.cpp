// Conditional.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//

#include <iostream>
using namespace std;


int main()
{
    /****************************************************************
   * 조건문 (Conditional)
   *
   * 조건에 따라 실행이 달라지게 할 때 사용하는 문장
   ****************************************************************/



   /****************************************************************
    * if 조건문
    *
    * 조건식의 true, false에 따라 실행할 블록을 결정하는 조건문
    ****************************************************************/

    bool critical = true;
    if (critical)
    {
        cout << "쎄게 치기" << endl;
    }
    else
    {
        cout << "그냥치기" << endl;
    }
    // <if 조건문 기본>
    if (true)   // 조건이 true인 경우 바로 아래의 블록이 실행됨
    {
        cout << "실행되는 블록" << endl;
    }
    else
    {
        cout << "실행되지 않는 블록" << endl;
    }

    if (false)  // 조건이 false인 경우 else 블록이 있다면 실행됨
    {
        cout << "실행되지 않는 블록" << endl;
    }
    else
    {
        cout << "실행되는 블록" << endl;
    }

    // else 블록은 선택사항으로 필요없을 경우 추가하지 않아도 됨
    int studentCount = 30;
    if (studentCount > 20)
    {
        cout << "책상을 추가함" << endl;
    }
    /* else
    {
        // 아무것도 하지 않음;
    } */

    // else 블록에 if 문을 추가함으로 여러 조건을 확인할 수 있음

    string input = "바위";
    if (input == "가위")
    {
        cout << "가위를 입력" << endl;
    }
    else
    {
        if (input == "바위")
        {
            cout << "바위를 입력" << endl;
        }
        else
        {
            if (input == "보")  // else if 가 효율이 좋다. if 조건문에 경우의 수가 많다면 else if 를 이용하도록 하자.
            {
                cout << "보를 입력" << endl;
            }
            else
            {
                cout << "잘못된 값을 입력" << endl;
            }

        }
    }

    // else 블록에 if 문이 있다면 블록을 생략해도 동일한 효과
    // else if 키워드가 따로 있는 것이 아닌 else + if
    if (input == "가위")
    {
        cout << "가위를 입력" << endl;
    }
    else if (input == "바위")
    {
        cout << "바위를 입력" << endl;
    }
    else if (input == "보")
    {
        cout << "보를 입력" << endl;
    }
    else
    {
        cout << "잘못된 값을 입력" << endl;
    }

    /****************************************************************
        * switch 조건문
        *
        * 조건값에 따라 실행할 시작지점을 결정하는 조건문
        ****************************************************************/

        // <switch 조건문 기본>
    /*
    cout << "메뉴를 선택해주세요\n";
    cout << "1. 게임 시작\n";
    cout << "2. 게임 설정\n";
    cout << "3. 게임 종료\n";
    */

    /*
    * int menu;
    * cin >> menu;
    * switch(menu)
    * {
    * case 1:
    * cout << "게임을 시작합니다.\n";
    * break; // 스위치는 break로 끊어 주자
    */
    int command = 2;
    switch (command)      // 조건값 지정                        
    {
    case 1:                 // 조건값이 일치하지 않아 넘어감
        cout << "값은 1" << endl;
        break;
    case 2:                 // 조건값이 일치하는 case 부터 시작함
        cout << "값은 2" << endl;
        break;            // break가 있는 지점에서 switch 블록을 빠져나감 // break; 가 없는 경우 중간에 끝나지 않고 다음 케이스의 결과도 나오게된다.
    case 3:
        cout << "값은 3" << endl;
        break;
    }

    // 조건값이 일치하는 case가 없는 경우 default 가 실행지점이 됨
    int value = 7;
    switch (value)
    {
    case 1:
        cout << "값은 1" << endl;
        break;
    case 3:
        cout << "값은 3" << endl;
        break;
    default:        // 조건값이 case에 일치한 적이 없으니 default가 실행지점이 됨
        cout << "값은 그 외" << endl;
        break;
    }

    // 조건값에 따라 동일한 실행이 필요한 경우 묶어서 사용 가능
    char key = 'w';
    switch (key)
    {
    case 'w':
    case 'W':  //case 'w'|'W'나 'w'&'W'를 써도 가능하긴 하지만 추천하지 않는다.
        cout << "위쪽으로 이동" << endl;
        break;
    case 'a':
    case 'A':
        cout << "왼쪽으로 이동" << endl;
        break;
    case 's':
    case 'S':
        cout << "아래쪽으로 이동" << endl;
        break;
    case 'd':
    case 'D':
        cout << "오른쪽으로 이동" << endl;
        break;
    default:
        cout << "이동하지 않음" << endl;
        break;
    }

    // switch 조건문 주의사항
    // break; 를 생략하게 된다면 블록을 빠져나오지 않고 이후 다른 조건도 수행함
    int num = 2;
    switch (num)
    {
    case 1:
        cout << 1;
    case 2:
        cout << 2;         // break; 가 없기 때문에 블록을 빠져나가지 않고 이후 조건도 수행
    case 3:
        cout << 3;
    case 4:
        cout << 4;
    case 5:
        cout << 5;
    }   // 결과출력 : 2345

     /****************************************************************
     * 삼항연산자
     *
     * 간단한 조건문을 빠르게 작성
     ****************************************************************/
     // int value = 조건식 ? 맞을때 내용 : 틀릴때 내용;    // 한줄로 표현할수 있는것이 삼항 연산자
      // <삼항 연산자 기본>
      // 조건식 ? true인 경우 값 : false인 경우 값
    int leftValue = 20;
    int rightValue = 10;
    int bigger = leftValue > rightValue ? leftValue : rightValue;



    /*   위와 같은 조건문 삼항 연산자는 더 빠르고 직관적으로 작성할수 있다. // 대신 간단할때 쓸때 더 유리한 연산자. 쓸수는 있지만 조심하자.
    if (leftValue > rightValue)
    {
       bigger = leftValue;
    }
    else
    {
       bigger = rightValue;
    }
    */
    //if : 조건식으로 실행할지 안할지 결정하고싶으면               
    //switch : 값으로 맞을때 할지 안할지
    // 삼항 연산자 : 너무 간단할때는 삼항연산자를 사용하자.

}