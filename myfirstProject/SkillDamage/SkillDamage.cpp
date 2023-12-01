#include <iostream>
#include <stdlib.h>
#include <stdio.h>
#include <conio.h>
#include <Windows.h>
#define pch_h 

using namespace std;

class driver
{
public:
    string name;
    void getname()
    {
        cout << "레이싱 게임에 오신것을 환영합니다." << endl;
        cout << "플레이어의 이름을 적어주세요. : ";
        cin >>  name;

        cout << endl;
        cout << "어서 오십시오 " << name << "님 환영합니다. " << endl;
    }
};

class Car
{
protected:
    string name;
    int breaking;
    float gasok;
    int accel;
public:
    int speed;
    /*
    class skill;
    //string skill [3] = {BMW, porche, hyundai} // 이런식으로도 가능
    skill fast(int rabbit)
    {

    };
    */
    Car() {}
    Car(int _breaking, float _gasok, int _accel, string name)
    {
        this->name = name;
        this->accel = _accel;
        this->breaking = _breaking;
        this->gasok = _gasok;

    };
    int start(driver driver)
    {
        cout << "플레이어" << driver.name << "님의" << name << "이/가 출발합니다.";
        cout << "현재 속력은 " << accel << "km/h 입니다.";
        accel = speed;
        return speed;
    };
    int gasoking(driver driver)
    {

        speed = (int)(gasok * speed);
        cout << "플레이어" << driver.name << "님의" << name << "이/가 가속합니다.";
        cout << "현재 속력은 " << speed << "km/h 입니다.";
        return speed;

    };
    int breakSpeed(driver driver)
    {
        speed = speed / breaking;
        cout << "플레이어" << driver.name << "님의" << name << "이/가 감속합니다.";
        cout << "현재 속력은 " << speed << "km/h 입니다.";
        return speed;

    };
    //int speed()
    //{
    //    return *speed;
    //};
    int skill(const int* _speed) {
        return 0;
    }
    void print() {
        cout << "당신의 차는 : " << name << endl;
    }
};

class porche : public Car
{
public:
    porche()
    {
        name = "포르쉐";
        accel = 50;
        breaking = 2;
        gasok = 1.5;
        speed = 20;
    }
    void print() 
    {
        cout << "포르쉐를 선택하였습니다." << endl;
    }
    int skill(const int* _speed)
    {
        cout << "포르쉐가 질주합니다." << endl;
        speed *= 3;
        return speed;
    }
};

class BMW : public Car
{
public:
    BMW()
    {
        name = "BMW";
        accel = 40;
        breaking = 4;
        gasok = 1.7f;
        speed = 20;
    }
    void print()
    {
        cout << "BMW 를 선택하였습니다." << endl;
    }
    int skill(const int* _speed)
    {
        cout << "BMW의 슈퍼 감속." << endl;
        speed = (int)(*_speed * 0.1);
        return speed;
    }
};

class Hyundai : public Car
{
public:
    Hyundai()
    {
        name = "국산의 힘";
        accel = 30;
        breaking = 5;
        gasok = 2;
        speed = 20;
    }
    void print()
    {
        cout << "현대를 선택하였습니다." << endl;
    }
    int skill(const int* _speed)
    {
        cout << "이것이 국산의 힘이다." << endl;
        speed = *_speed * 50;
        return speed;
    }
};

//초기화
Car* MyCar = new Car();
driver player = driver();
//초기화

void Carskill(int* _speed)
{
    switch (*_speed)
    {
    case 1:
    {
        Car* w1 = new porche();
        w1->skill(_speed);
        delete w1;
        break;
    }
    case 2:
    {
        Car* w2 = new BMW();
        w2->skill(_speed);
        delete w2;
        break;
    }
    case 3:
    {
        Car* w3 = new Hyundai();
        w3->skill(_speed);
        delete w3;
        break;
    }
    }
}

void createCar(int inputcar)
{
    
    switch (inputcar)
    {
    case 1:
        {
        MyCar = new porche();
        MyCar->print();
//        delete w1;
        break;
        }
    case 2:
        {
        MyCar = new BMW();
        MyCar->print();
 //       delete w2;
        break;
        }
    case 3:
        {
        MyCar = new Hyundai();
        MyCar->print();
//        delete w3;
        break;
        }
    }
}

int main()
{
    //오버로딩으로 스킬
    //동적 바인딩으로 
    driver getname();
    int carinput = 1;
    int inputnum;
    cout << "레이싱을 시작합니다." << endl;
    cout << "당신의 자동차를 선택해주세요" << endl;
    cout << "1.포르쉐" << endl;
    cout << "속도 : 빠름" << endl;
    cout << "속도 제어 : 낮음 " << endl << endl;
    cout << "2.BMW" << endl;
    cout << "속도 : 중간" << endl;
    cout << "속도 제어 : 중간 " << endl << endl;
    cout << "3.현대" << endl;
    cout << "속도 : 느림" << endl;
    cout << "속도 제어 : 높음 " << endl << endl;
    cin >> carinput;
    createCar(carinput);

    while (true)
    {
        //cout << "움직일 방향의 숫자를 입력하세요." << endl;
        //cout << "↑(가속), ↓(감속),  스킬키 (space)" << endl;
        //cin >> inputnum;
        //if (inputnum == 0)
        //{
        ////==============//
        //}
        //else
        //{
        //    cout << "잘못된 키를 입력하셨습니다." << endl;
        //    system("cls");
        //    continue;
        //}

        cout << "현재 속력은 " << MyCar->speed << "KM/H 입니다." << endl; //동적 바인딩으로 해볼수 있을거같다
        cout << "움직일 방향의 숫자를 입력하세요." << endl;
        cout << "↑(가속), ↓(감속),  스킬키 (space)" << endl;
        int key;
        key = _getch();
        if (key == 224)
        {
            key = _getch();
        }
        switch (key)
        {
        case 72:
            if (MyCar->speed = 0)
                MyCar->start(player);
            else
            {
                MyCar->gasoking(player);
            }
            break;
        case 80:
            if (MyCar->speed = 0)
            {
                MyCar->breakSpeed(player);
                cout << "차가 멈췄습니다." << endl;
            }
            else
            {
                MyCar->breakSpeed(player);
            }
            break;

        default:
            cout << "잘못된 키를 입력하였습니다." << endl;
            system("cls");
            continue;
        }

    }
    

}