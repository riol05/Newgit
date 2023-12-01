#include <iostream>

using namespace std;

/***************************************************************************
 * ��� (Inheritance)
 *
 * �θ�Ŭ������ ��� ����� ������ �ڽ�Ŭ������ �����ϴ� ���
 * is-a ���� : �θ�Ŭ������ �ڽ�Ŭ������ �����ϴ� ���������� ��� ��Ӱ��谡 ������
 ****************************************************************************/

 // <���>
 // �θ�Ŭ������ ����ϴ� �ڽ�Ŭ�������� �θ�Ŭ������ ��� ����� �ο�
 // class �ڽ�Ŭ���� : public �θ�Ŭ����

class Monster
{
protected:   // �ܺο����� private ������ ����� class  �ڽĿ��� public
    string name;
    int hp;

public:

    string getName()
    {
        return name;
    } // ������ �̸��� ��� �ϱ�����
    void TakeHit(int damage, int hp)
    {
        hp -= damage;
        cout << name << "��/�� " << damage << "�� �޾� ü���� " << hp << " �� �Ǿ����ϴ�." << endl;
    }
    void die() {}
};

class Slime : public Monster // public �� ��� . �������� ���Ϳ� ��ӵǾ� �θ�Ŭ������ �ִ� TakeHit ����� �ο� �޴´�.
{
public:
    Slime()
    {
        name = "������";
        hp = 100;
    }
    void split() {}
};

class Dragon : public Monster
{
public:
    Dragon()
    {
        name = "�巡��";
        hp = 300;
    }

    void Breath()
    {
        cout << name << "��/�� �극���� �ս��ϴ�." << endl;
    }
};

class Hero
{
    int damage;
public:
    void Attack(Monster monster)
    {
        monster.TakeHit(damage);
        cout << "������ " << monster.getName() << "��/�� �����ϴ�." << endl;

    }
};

void Inheritance_Main1()
{
    Slime slime;
    Dragon dragon;

    // �θ�Ŭ���� Monster�� ����� �ڽ�Ŭ������ ��� �θ�Ŭ������ ����� ������ ����
    slime.TakeHit(10);
    dragon.TakeHit(10);


    // �ڽ�Ŭ������ �θ�Ŭ������ ��ɿ� �ڽĸ��� ����� ���� �߰��Ͽ� ���� ����
    dragon.Breath();


    // ��ĳ���� : �ڽ�Ŭ������ �θ�Ŭ���� �ڷ������� ����ȯ ����
    Hero hero;
    hero.Attack(slime);
    hero.Attack(dragon);

    Monster monster = Dragon(); // ��ӱ�� ��� �Ҷ��� ���谡 �´��� Ȯ���ϰ� �������
    hero.Attack(monster);
}


// <��� ����ǹ� 1>
// �ڵ��� ����


// <��� ����ǹ� 2>
// ��Ŀ�ú� ġȯ
// �θ� �ڸ��� �ڽ� �ν��Ͻ��� ��ü �ص� ��� ��� ������ �����ϴ�.

class Parent {};
class Child1 : public Parent {};
class Child2 : public Parent {};
class Child3 : public Parent {};
class Child4 : public Parent {};
void useParent(Parent& parent) {} // ���� �ִ� ��� �Լ��� ��� ����Ҽ��ִ�.

void inheritnaceMain1()
{
    Child1 child1 = Child1();
    Child2 child2 = Child2();
    Child3 child3 = Child3();

    useParent(child1);
    useParent(child2);
    useParent(child3);

    

}