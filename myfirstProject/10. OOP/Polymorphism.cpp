#include <iostream>

using namespace std;

/***************************************************************************
 * 다형성 (Polymorphism)
 *
 * 객체의 속성이나 기능이 상황에 따라 여러가지 형태를 가질 수 있는 성질
 ****************************************************************************/

 // <다형성>
 // 부모클래스의 함수를 자식클래스에서 재정의하여 자식클래스의 서로 다른 반응을 구현

class Skill
{
    int coolTime;

public:
    void Excute()
    {
        cout << "스킬 재사용 대기시간을 진행시킴" << endl;
    }
}; // 재정의 하기 위한 작업을 해야한다.

class FireArrow : public Skill
{   
    int cooltime = 50;
public:
    void Excute() // 서로 다른 함수다 // 상위 클래스에서 만든 함수와 같은 함수를 자식 클래스에서 만들수 있는것이 오버라이딩이다
    {
        Skill::Excute(); // 스킬과 파이어 애로우 에있는 함수는 다른 함수

        cout << "불화살 스킬을 사용함" << endl;
        cout << "쿨타임" << FireArrow::cooltime << "남음" << endl;
    }
};

// 오버로딩 // 매개 변수가 다른데 같은 함수를 쓸수 있는것이 오버로딩
int add(int left, int right) { return left + right; }
float add(float left, float right) { return left + right; }

class Smash : public Skill
{
public:
    void Excute()
    {
        Skill::Excute();
        cout << "강타 스킬을 사용함" << endl;
    }
};


void PolymorphismMain1()
{
    FireArrow fireArrow = FireArrow();
    Smash smash = Smash();
    fireArrow.Excute();
    smash.Excute();
}


class player
{
protected:
        Skill skill;
public:
    void UseSkill()
    {
        skill.Excute();

    }

    static void AAA() // 정적함수
    {
        // 언제든 인스턴스 없이 쓸수 있는 함수   Archor:: AAA(); // 왜씀?? 아래
    }
};
class Math
{
public:
    float differ(float aa) // 대충 미분기능
    {
        return aa; // 이럴때 Math::differ(10); 까지 할 필요 없다.
    }
};
class Warrior : public player
{
public:
    Warrior()
    {
        skill = Smash();
    }
};
class Archor : public player
{
public:
    Archor()
    {
        skill = FireArrow();

    }

};
void poly()
{
    FireArrow* fireArrow = new FireArrow();
    fireArrow->Excute(); // 파이어 애로우가 나간다.
    Skill* skill = new FireArrow();
    skill->Excute(); // 반대로 스킬로 쓰면 엑스큐트가 나간다.
    Smash smash = Smash();
}
void Poly()
{
    Archor archor = Archor();
    archor.UseSkill();
    Warrior warrior = Warrior();
    warrior.UseSkill();
}



// <가상함수와 오버라이딩>
// 가상함수 : 부모클래스의 함수 중 자식클래스에 의해 재정의 할 수 있는 함수를 지정
// 오버라이딩 : 부모클래스의 함수를 같은 함수이름과 같은 매개변수로 재정의

class Vehicle
{
public:
    virtual void Move() // 가상함수 재정의 할수 있는 함수로 지정해준다.
    {
        cout << "도로 위로 이동합니다." << endl;
    }
};

class AirPlane : public Vehicle
{
public:
    void Move() override // 오버라이딩 부모 클래스의 함수와 같은 함수 이름으로 재정의
    {
        cout << "공중으로 이동합니다." << endl;
    }
};

class Bus : public Vehicle
{
public:
    void Move() override
    {
        Vehicle::Move();
        cout << "정류장에 도착하면 승하차 후 출발합니다." << endl;
    }
};

void PolymorphismMain2()
{
    // <정적바인딩>
    // 컴파일 당시에 호출될 함수가 결정
    // 변수의 자료형을 기반으로 호출할 함수를 결정
    Vehicle vValue = Vehicle();
    Vehicle aValue = AirPlane();
    Vehicle bValue = Bus();
    vValue.Move();      //Vehicle::Move()를 호출함 자동적으로 결정되있음
    aValue.Move();      //
    bValue.Move();
    //  정적 바인딩은 결과가 정해져있다. 클래스의 부모의 결과값을 가짐 퀵스탠딩, 백스텝같은 스킬로 쓸수있다.
    
    // <동적바인딩>
    // 런타임 당시에 호출될 함수가 결정
    // virtual 함수를 포함하는 객체는 가상함수테이블을 포함함
    // 가상함수를 재정의하는 경우 가상함수테이블의 주소값을 재정의한 함수의 주소로 변경
    // 호출시 가상함수테이블에 있는 함수 주소를 읽어 함수를 진행
    //런타임마다 다르게 하기 위해선 동적 바인딩을 사용하자
    // 가상함수를 만들고 동적 바인딩을 하여야한다.
    Vehicle* selectVehicle;

    string select;
    cout << "탑승물을 선택하십쇼";
    cin >> select;
    if (select == "버스")
    {
        selectVehicle = new Bus();
    }
    else if (select == "비행기")
    {
        selectVehicle = new AirPlane();
    }
    (*selectVehicle).Move();

    Vehicle* vPtr = new Vehicle();
    Vehicle* aPtr = new AirPlane();
    Vehicle* bPtr = new Bus();
    vPtr->Move();    // *(vPtr).move();   // 가상함수테이블에 연결된 함수를 호출함
    aPtr->Move();    // *(aPtr).move();  // 동적 할당을 사용하면 다형성은 된다.
    bPtr->Move();    // *(bPtr).move();

    delete vPtr;
    delete aPtr;
    delete bPtr; // 변수는 다시 삭제해주자
}// 동적 바인딩은 다형성을 확보하기위한 작업을 할때 유리하다. 클래스 객체를 만들땐 동적바인딩을 쓰는것만 기억하자

// <다형성 사용의미>
// 부모클래스를 설계할 당시 기본적인 기능을 구현하며
// 자식클래스를 설계할 당시 자식클래스만의 기능을 고려하여 구현가능


