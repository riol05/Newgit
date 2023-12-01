// 06.Pointer.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
// 포인터는 뉴비 커터기... 어렵지 않고 헷갈리는 녀석이니 조심하자

#include <iostream>
using namespace std;

/****************************************************************
 * 포인터 (Pointer)
 *
 * 프로그램은 메모리를 사용하며 메모리는 변수를 저장한 주소를 가지고 있음
 * 프로그램의 메모리 주소값을 통한 접근방법으로 다양한 작업이 가능
 ****************************************************************/

 // <주소연산자>
 // 변수명 앞 &를 붙여 변수가 메모리에 할당된 주소를 확인할 수 있음
void Main1()
{
    int num = 5;
    cout << "num에 저장된 데이터 " << num << endl;
    cout << "num이 저장된 메모리 주소 " << &num << endl; // 엔퍼센드
}


// <포인터 변수>
// 포인터 변수는 메모리 주소를 저장하는 변수
// 자료형 뒤 *을 붙여 포인터 변수를 선언함
// 포인터 변수의 자료형은 가리키고 있는 변수의 자료형과 동일하게 함

void Main2()
{
    int num = 100;
    int* ptr = &num;        // 포인터 변수에 주소값을 대입 // 자료형을 저장하는데 주소를 자료형 뒤에 *을 붙이는 이유는  그 주소에 있는 자료형 후에 써주는것이다.

    cout << "num이 저장된 메모리 주소 " << &num << endl;
    cout << "ptr이 가지는 데이터 주소값 " << ptr << endl;
}

// <포인터 역참조>
// 포인터 변수가 가지는 주소값을 역으로 따라갈 수 있음
// 포인터 변수 앞 *을 붙여 포인터 변수가 가지고 있는 주소값에 저장된 데이터를 확인
// 주소값에 저장된 데이터를 변경하는 경우 주소값을 제공한 변수의 원본 데이터를 변경함
void Main3()
{
    int num = 10;
    int* ptr = &num;
    // 이미지 파일 같은 경우에 포인터를 사용하는게 유리하다. ptr 를 쓰면 집 주소 *ptr 이나 num은 집을 그대로 들고 나온 경우
    cout << "num이 저장된 데이터 " << num << endl;
    cout << "ptr이 가지는 주소값을 역참조하여 확인한 데이터 " << *ptr << endl;

    *ptr = 20; // num = 20; 을 한적이 없는데 num 의 결과까지 바뀌어버렸다.
    cout << "num이 저장된 데이터 " << num << endl;
    cout << "ptr이 가지는 주소값을 역참조하여 확인한 데이터 " << *ptr << endl;
} 


// <포인터 변수 사용시 주의사항>
// 포인터 변수를 초기화 없이 사용하게 된다면 쓰레기값을 주소값으로 판단하여 프로그램을 손상시킬 수 있음
// 반드시 포인터 변수가 주소값을 가지고 있지 않는 경우에는 nullptr로 초기화 해주도록 함
void Main4()
{
    int* ptr1;               // 의도했던 주소값만 건드리자 포인터 변수에서 아무것도 집어넣지 않은 상황에선 nullptr 를 넣어주고 초기화 해주자
    // *ptr1 = 20;          // 주의! 프로그램을 손상시킬 수 있음

    int* ptr2 = nullptr;    // 주소값을 가지고 있지 않은 포인터 변수는 nullptr로 초기화하여 안전하게 사용
    *ptr2 = 20;             // 예외처리가 발생
}


// <포인터의 크기>
// 포인터의 크기는 주소값의 크기로 메모리가 주소값을 표현하는 단위가 됨
// 32비트 프로그램은 포인터 크기를 32비트, 64비트 프로그램은 포인터 크기를 64비트를 사용한다.
// 포인터 변수의 크기는 항상 같다. 주소값만 포함하고 있기 때문에.
void Main5()
{
    int* iPtr;
    float* fPtr;
    double* dPtr;

    cout << sizeof(iPtr) << endl;
    cout << sizeof(fPtr) << endl;
    cout << sizeof(dPtr) << endl; // x64 는 64비트  x86 은 32비트 x86 ibm에서 8086 이란 컴퓨터가 나왔다. x86은 ibm 에서 썼던 전통적인 숫자. 
}

// <값에 의한 호출, 주소에 의한 호출> //or 얕은 복사 깊은 복사 // call by value call by ref//     c++ 기술 면접 출제율 90%!!!!!!!!!!!!!!!!!////// 개중요!!!!!
// 함수의 매개변수로 전달되는 데이터는 변수 자체가 아닌 데이터를 복사하여 전달됨
// 만약 변수를 매개변수로 전달하는 경우 데이터를 복사하여 전달하므로 원본이 변경되지 않음
// 만약 변수의 주소를 매개변수로 전달하는 경우 주소를 복사하여 전달하므로 원본의 주소를 역참조하여 원본이 변경됨
void CallByValue(int value) { value = 10; }
void CallByAddress(int* ptr) { *ptr = 10; }
 // call by value

/*
void func(int bb)
{
    cout << "before : " << bb << endl;
    bb *= bb;
    cout << "after : " << bb << endl;

}
int main()
{
    int num = 10;
    func(num);
    cout << "call by value : " << num << endl;

}
함수 func 에 있는 변수 bb 는 매개 변수이기 때문에 함수 func 를 나온 순간 call by value 에 의해 num 의 결과 값은 다시 10이 된다.
주소 값을 보면 bb 와 num 은 같은 결과값을 가지고 있지만 주소값이 다르다 이러한 경우를 값 복사 라고 한다.
그냥 main 함수 안에 있는 변수 num 의 값이 매개 변수 bb 에 값에 복사 된것을 뜻한다. 


*/


// call by address 주소값을 가지고 바꿔주는것이기 때문에 temp의 값을 바꾸지 않고 left 와 right 의 위치를 바꿀수 있게된다./

//void Swap(int left, int right)
//{
//    
//    int temp = left; // 그냥 넣게되면 a = 10 , b = 20
//    left = right;
//    right = temp;
//    
//        /*
//    left = right;  // a = 20, b = 20 이 되어 버린다.
//    right = left; 
// }*/

void Swap(int *left, int *right)
{
    int temp = *left; // 포인터를 쓰게되면 그 주소에 있는 값을 가져오게 되므로 temp 엔 *left의 값이 나오게됨. 그후 *left 의 값을 *right의 값으로 바뀌고 *right는 temp 의 값을 가져가게된다.
    *left = *right; // 포인터를 쓰지 않으면 이 위치를 바꾸는것은 불가능하다.
    *right = temp;
}

int main()
{
    int a = 10;
    int b = 20;
    Swap(&a, &b);
    // a == 20, b == 10 으로 바꾸게 하고싶을때 쓰는 함수
}

void Main6()
{
    int value = 0;
    cout << "value의 값은 " << value << endl;      // 0
    CallByValue(value);
    cout << "value의 값은 " << value << endl;      // 0
    CallByAddress(&value);
    cout << "value의 값은 " << value << endl;      // 10
}

// <참조자>
// C++에 추가된 새로운 기능
// 참조자는 내부 구현은 포인터를 통해 구현되어 있지만 사용시에 원본을 변수에 가지도록 하는 기법
void Main7()
{
    int num = 10;
    int& ref = num; // 자료형 뒤에 & 을 붙여주면 참조자가 된다. 이러면 ref는 원본이 된다. int& 는 레퍼런스

    ref = 20;
    cout << "num이 저장된 데이터 " << num << endl;
    cout << "ref가 참조하고 있는 데이터 " << ref << endl;
}


// <참조에 의한 호출>
void CallbyReference(int& ref) { ref = 10; }

void Main8()
{
    int value = 0;
    cout << "value의 값은 " << value << endl;      // 0
    CallbyReference(value);
    cout << "value의 값은 " << value << endl;      // 10
}


int main()
{
    int Px = 0;
    int Py = 0; // player

    int* Mx = &Px; // monster
    int* My = &Py;
    int* Monpotion = new int;

    cout << "플레이어가 오른쪽으로 4칸 갑니다." << endl;
    Px++;
    Px++;
    Px += 2;

    cout << "몬스터가 플레이어를 따라갑니다" << Mx << My << endl;
    //<얕은 복사>
    int* Monpotion2 = Monpotion;
    (*Monpotion2)--; // Monpotion 도 같이 값이 바뀐다.
    delete Monpotion; // Monpotion2도 같이 delete 됨.

    //깊은 복사
    int* Monpotion2 = new int;
    *Monpotion2 = *Monpotion; //
    (*Monpotion2)--; // 깊은 복사를 사용해서 mon2만 값이 바뀜
    delete Monpotion;
    delete Monpotion2;
}

// call by reference

void Swap(int& left, int& right)
{
    int temp = left; 
    left = right; 
    right = temp; // call by address 와 같은 결과값 포인터와 레퍼런스는 같은 값이기 때문에 어떤걸 써도 좋다. 취향차이
}


int main()
{

}
