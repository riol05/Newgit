#include <iostream>

using namespace std;

/***************************************************************************
 * ������ (Polymorphism)
 *
 * ��ü�� �Ӽ��̳� ����� ��Ȳ�� ���� �������� ���¸� ���� �� �ִ� ����
 ****************************************************************************/

 // <������>
 // �θ�Ŭ������ �Լ��� �ڽ�Ŭ�������� �������Ͽ� �ڽ�Ŭ������ ���� �ٸ� ������ ����

class Skill
{
    int coolTime;

public:
    void Excute()
    {
        cout << "��ų ���� ���ð��� �����Ŵ" << endl;
    }
}; // ������ �ϱ� ���� �۾��� �ؾ��Ѵ�.

class FireArrow : public Skill
{   
    int cooltime = 50;
public:
    void Excute() // ���� �ٸ� �Լ��� // ���� Ŭ�������� ���� �Լ��� ���� �Լ��� �ڽ� Ŭ�������� ����� �ִ°��� �������̵��̴�
    {
        Skill::Excute(); // ��ų�� ���̾� �ַο� ���ִ� �Լ��� �ٸ� �Լ�

        cout << "��ȭ�� ��ų�� �����" << endl;
        cout << "��Ÿ��" << FireArrow::cooltime << "����" << endl;
    }
};

// �����ε� // �Ű� ������ �ٸ��� ���� �Լ��� ���� �ִ°��� �����ε�
int add(int left, int right) { return left + right; }
float add(float left, float right) { return left + right; }

class Smash : public Skill
{
public:
    void Excute()
    {
        Skill::Excute();
        cout << "��Ÿ ��ų�� �����" << endl;
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

    static void AAA() // �����Լ�
    {
        // ������ �ν��Ͻ� ���� ���� �ִ� �Լ�   Archor:: AAA(); // �־�?? �Ʒ�
    }
};
class Math
{
public:
    float differ(float aa) // ���� �̺б��
    {
        return aa; // �̷��� Math::differ(10); ���� �� �ʿ� ����.
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
    fireArrow->Excute(); // ���̾� �ַο찡 ������.
    Skill* skill = new FireArrow();
    skill->Excute(); // �ݴ�� ��ų�� ���� ����ťƮ�� ������.
    Smash smash = Smash();
}
void Poly()
{
    Archor archor = Archor();
    archor.UseSkill();
    Warrior warrior = Warrior();
    warrior.UseSkill();
}



// <�����Լ��� �������̵�>
// �����Լ� : �θ�Ŭ������ �Լ� �� �ڽ�Ŭ������ ���� ������ �� �� �ִ� �Լ��� ����
// �������̵� : �θ�Ŭ������ �Լ��� ���� �Լ��̸��� ���� �Ű������� ������

class Vehicle
{
public:
    virtual void Move() // �����Լ� ������ �Ҽ� �ִ� �Լ��� �������ش�.
    {
        cout << "���� ���� �̵��մϴ�." << endl;
    }
};

class AirPlane : public Vehicle
{
public:
    void Move() override // �������̵� �θ� Ŭ������ �Լ��� ���� �Լ� �̸����� ������
    {
        cout << "�������� �̵��մϴ�." << endl;
    }
};

class Bus : public Vehicle
{
public:
    void Move() override
    {
        Vehicle::Move();
        cout << "�����忡 �����ϸ� ������ �� ����մϴ�." << endl;
    }
};

void PolymorphismMain2()
{
    // <�������ε�>
    // ������ ��ÿ� ȣ��� �Լ��� ����
    // ������ �ڷ����� ������� ȣ���� �Լ��� ����
    Vehicle vValue = Vehicle();
    Vehicle aValue = AirPlane();
    Vehicle bValue = Bus();
    vValue.Move();      //Vehicle::Move()�� ȣ���� �ڵ������� ����������
    aValue.Move();      //
    bValue.Move();
    //  ���� ���ε��� ����� �������ִ�. Ŭ������ �θ��� ������� ���� �����ĵ�, �齺�ܰ��� ��ų�� �����ִ�.
    
    // <�������ε�>
    // ��Ÿ�� ��ÿ� ȣ��� �Լ��� ����
    // virtual �Լ��� �����ϴ� ��ü�� �����Լ����̺��� ������
    // �����Լ��� �������ϴ� ��� �����Լ����̺��� �ּҰ��� �������� �Լ��� �ּҷ� ����
    // ȣ��� �����Լ����̺� �ִ� �Լ� �ּҸ� �о� �Լ��� ����
    //��Ÿ�Ӹ��� �ٸ��� �ϱ� ���ؼ� ���� ���ε��� �������
    // �����Լ��� ����� ���� ���ε��� �Ͽ����Ѵ�.
    Vehicle* selectVehicle;

    string select;
    cout << "ž�¹��� �����Ͻʼ�";
    cin >> select;
    if (select == "����")
    {
        selectVehicle = new Bus();
    }
    else if (select == "�����")
    {
        selectVehicle = new AirPlane();
    }
    (*selectVehicle).Move();

    Vehicle* vPtr = new Vehicle();
    Vehicle* aPtr = new AirPlane();
    Vehicle* bPtr = new Bus();
    vPtr->Move();    // *(vPtr).move();   // �����Լ����̺� ����� �Լ��� ȣ����
    aPtr->Move();    // *(aPtr).move();  // ���� �Ҵ��� ����ϸ� �������� �ȴ�.
    bPtr->Move();    // *(bPtr).move();

    delete vPtr;
    delete aPtr;
    delete bPtr; // ������ �ٽ� ����������
}// ���� ���ε��� �������� Ȯ���ϱ����� �۾��� �Ҷ� �����ϴ�. Ŭ���� ��ü�� ���鶩 �������ε��� ���°͸� �������

// <������ ����ǹ�>
// �θ�Ŭ������ ������ ��� �⺻���� ����� �����ϸ�
// �ڽ�Ŭ������ ������ ��� �ڽ�Ŭ�������� ����� ����Ͽ� ��������


