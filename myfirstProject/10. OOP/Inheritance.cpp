#include <iostream>

using namespace std;

/***************************************************************************
 * 상속 (Inheritance)
 *
 * 부모클래스의 모든 기능을 가지는 자식클래스를 설계하는 방법
 * is-a 관계 : 부모클래스가 자식클래스를 포함하는 상위개념일 경우 상속관계가 적합함
 ****************************************************************************/

 // <상속>
 // 부모클래스를 상속하는 자식클래스에게 부모클래스의 모든 기능을 부여
 // class 자식클래스 : public 부모클래스

class Monster
{
protected:   // 외부에서는 private 이지만 상속한 class  자식에겐 public
    string name;
    int hp;

public:

    string getName()
    {
        return name;
    } // 몬스터의 이름을 출력 하기위함
    void TakeHit(int damage, int hp)
    {
        hp -= damage;
        cout << name << "이/가 " << damage << "를 받아 체력이 " << hp << " 이 되었습니다." << endl;
    }
    void die() {}
};

class Slime : public Monster // public 은 상속 . 슬라임은 몬스터에 상속되어 부모클래스에 있는 TakeHit 기능을 부여 받는다.
{
public:
    Slime()
    {
        name = "슬라임";
        hp = 100;
    }
    void split() {}
};

class Dragon : public Monster
{
public:
    Dragon()
    {
        name = "드래곤";
        hp = 300;
    }

    void Breath()
    {
        cout << name << "이/가 브레스를 뿜습니다." << endl;
    }
};

class Hero
{
    int damage;
public:
    void Attack(Monster monster)
    {
        monster.TakeHit(damage);
        cout << "영웅이 " << monster.getName() << "을/를 때립니다." << endl;

    }
};

void Inheritance_Main1()
{
    Slime slime;
    Dragon dragon;

    // 부모클래스 Monster을 상속한 자식클래스는 모두 부모클래스의 기능을 가지고 있음
    slime.TakeHit(10);
    dragon.TakeHit(10);


    // 자식클래스는 부모클래스의 기능에 자식만의 기능을 더욱 추가하여 구현 가능
    dragon.Breath();


    // 업캐스팅 : 자식클래스는 부모클래스 자료형으로 형변환 가능
    Hero hero;
    hero.Attack(slime);
    hero.Attack(dragon);

    Monster monster = Dragon(); // 상속기능 상속 할때는 관계가 맞는지 확인하고 사용하자
    hero.Attack(monster);
}


// <상속 사용의미 1>
// 코드의 재사용


// <상속 사용의미 2>
// 리커시브 치환
// 부모 자리를 자식 인스턴스로 대체 해도 모든 기능 수행이 가능하다.

class Parent {};
class Child1 : public Parent {};
class Child2 : public Parent {};
class Child3 : public Parent {};
class Child4 : public Parent {};
void useParent(Parent& parent) {} // 위에 있는 상속 함수를 모두 사용할수있다.

void inheritnaceMain1()
{
    Child1 child1 = Child1();
    Child2 child2 = Child2();
    Child3 child3 = Child3();

    useParent(child1);
    useParent(child2);
    useParent(child3);

    

}