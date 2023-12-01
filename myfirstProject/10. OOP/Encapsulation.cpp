#include <iostream>

using namespace std;
/**************************************************************************************
*캡슐화: 
* 
* 객체를 상태와 기능으로 묶는 것을 의미하며, 객체의 내부 상태와 기능을 숨기고, 허용한 상태와 기능만의 액세스 허용 
* 
**************************************************************************************/

//<캡슐화>

//객체를 상태와 기능으로 묶는것, 객체의 상태와 기능을 멤버라고 표현함
// 현실세계의 객체를 표현하기 위해 객체가 가지는 정보와 행동을 묶어 구현하며, 이를 통해 객체간 상호작용

// class 일때 바깥에서 쓰기 원하는 기능은 public 을 넣는다 // 의도한것만 public 으로 풀자. 아니면 꼬여서 힘들어짐
// struct일때 이것만큼은 쓰는것을 원하지 않을때 private 기능을 넣는다.
class AccessSpecifier
{
public: //public 접근 제한자 : 외부에서도 접근 가능
	int publicValue;

private : // private 접근 제한자 : 내부에서만 접근가능 // 정보 은닉 가능
	int privateValue;

protected: // protected 접근제한자 : 외부접근은 private, 상속한 클래스는 public 
	int protectedValue;
	void PrivateFunction()
	{
		publicValue; // 접근가능
		privateValue; // 내부에선 접근가능, 외부에선 불가하다.
	}
};

class capsule
{

	int variable; // 멤버 변수 : 객체의 상태를 표현
	void fuction() {} // 멤버 함수 : 객체의 기능을 표현
};

//<접근 제한자>
// 외부에서 접근이 가능한 변수와 함수를 지정하는 기능
//
// public : 외부에서도 접근 가능
// private : 내부에서만 접근가능
// protected: 외부접근은 private, 상속한 클래스는 public


// <정보은닉>
// 객체 구성에 있어서 외부에서 사용하기 원하는 기능과 사용하기 원하지 않는 기능을 구분하기 위해 사용
// 사용자가 객체를 사용하는데 있어서 필요한 기능만을 확인하기 위한 용도이며
// 외부에 의해 영향을 받지 않길 원하는 기능을 감추기 위한 용도이기도 함

class Bank
{
    int balance;// 정보 은닉을 위해 public에는 두지않는다

public:
    
    void setBalance(int balance) // 잔고 설정
    {
        this->balance = balance;
    }
    int getBalance() // 잔고 확인가능
    {
        return balance;
    }

    void Save(int money)
    {
        balance += money;
    }
    void Load(int money)
    {
        balance -= money;
    }
};

void Encapsulation_Main2()
{
    Bank bank;
    // 외부에서 Bank의 balance를 직접적으로 접근불가
    // bank.balance = 1000000;
    // 
    // 외부에서는 Bank에서 의도한 Save와 Load를 통해 Bank를 다루게 유도
    bank.Save(20000);
    bank.Load(10000);
}


// <캡슐화 사용의미 1 - 복잡성 감소>
// 캡슐화된 클래스는 외부에서 사용하기 위한 인터페이스만을 제공
// 즉, 캡슐화된 클래스는 내부적으로 어떻게 구현되었는지 몰라도 사용가능

class VeryComplicatedObject
{
    // 캡슐화된 클래스의 private는 외부에서 접근불가하므로 사용할 수 없음
    int veryComplicatedValue1;
    int veryComplicatedValue2;
    int veryComplicatedValue3;

    void VeryComplicatedFunction1() {}
    void VeryComplicatedFunction2() {}
    void VeryComplicatedFunction3() {}

public:
    // 캡슐화된 클래스의 public은 외부에서 접근가능하므로 사용을 권장하는 기능
    void UseThisFunction() {}
};


// <캡슐화 사용의미 2 - 오용 방지>
// 캡슐화된 클래스는 외부에서 원하지 않는 사용법으로부터 보호할 수 있음

class IntArray
{
    int array[10]; // 클래스에 배열을 쓰는방법

public:
    void SetValue(int index, int value)
    {
        if (index < 0 || index >= 10)
            return;

        array[index] = value;
    }
};