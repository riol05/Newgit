#include <iostream>
#include <stdlib.h>
#include <stdio.h>
#include <conio.h>
#include <Windows.h>
#define pch_h 

using namespace std;

class Driver
{
    
    
public:
    string* input;
    string getname()
    {
        cout << "레이싱 게임에 오신것을 환영합니다." << endl;
        cout << "플레이어의 이름을 적어주세요. : ";
        cin >> *input;

        cout << endl;
        cout << "어서 오십시오 " << *input << "님 환영합니다. " << endl;

        return *input;
    }
    string name()
    {
        return *input;
    }

};

class Car abstract
{
protected:
    string name;
    int breaking;
    double gasok;
    int accel;

public:
    /*
    class skill;
    //string skill [3] = {BMW, porche, hyundai} // 이런식으로도 가능
    skill fast(int rabbit)
    {

    };
    */

    const int* speed;
    int sp = *speed;
    Car() {}
    Car(int _breaking, double _gasok, int _accel, string name)
    {
        this->name = name;
        this->accel = _accel;
        this->breaking = _breaking;
        this->gasok = _gasok;

    };
    int start(Driver driver)
    {
        cout << "플레이어" << driver.name() << "님의" << name << "이/가 출발합니다.";
        cout << "현재 속력은 " << accel << "km/h 입니다.";
        accel = sp;
        return sp;
    };
    int gasoking(Driver driver)
    {
        sp = *speed;
        sp = (int)(gasok * *speed);
        cout << "플레이어" << driver.name() << "님의" << name << "이/가 가속합니다.";
        cout << "현재 속력은 " << sp << "km/h 입니다.";
        return sp;

    };
    int breakSpeed(Driver driver)
    {
        sp = *speed;
        sp = *speed / breaking;
        cout << "플레이어" << driver.name() << "님의" << name << "이/가 감속합니다.";
        cout << "현재 속력은 " << sp << "km/h 입니다.";
        return sp;

    };
    int speed(int sp)
    {
        return sp;
    };
    virtual void print() = 0;
    virtual int skill(const int* _speed) = 0;
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
    }
  void print()override
    {
        cout << "포르쉐를 선택하였습니다." << endl;
    }
     int skill(const int* _speed)override
    {
        cout << "포르쉐가 질주합니다." << endl;
        sp = *_speed * 3;
        return sp;
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
        gasok = 1.7;
    }
   void print()override
    {
        cout << "BMW 를 선택하였습니다." << endl;
    }
    int skill(const int* _speed)override
    {
        cout << "BMW의 슈퍼 감속." << endl;
        sp = (int)(*_speed * 0.1);
        return sp;
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
    }
    void print() override
    {
        cout << "현대를 선택하였습니다." << endl;
    }
    int skill(const int* _speed)override
    {
        cout << "이것이 국산의 힘이다." << endl;
        sp = *_speed * 50;
        return sp;
    }
};

void Carskill(int *_speed)
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
    case 0:
    {
        Car* my = new porche();
        my->print();
        /*delete w1;*/
        break;
    }
    case 1:
    {
        Car* my = new BMW();
        my->print();
       /* delete w2;*/
        break;
    }
    case 2:
    {
        Car* my = new Hyundai();
        my->print();
       /* delete w3;*/
        break;
    }
    }
}

int main()
{
    //오버로딩으로 스킬
    //동적 바인딩으로 
    Car* car = new BMW;
    Car* car = new porche;
    Car* car = new Hyundai;
    Driver* driver = new Driver;
    Driver getname();
    string name;
    int inputnum = 1;
    int carinput = 1;
    cout << "레이싱을 시작합니다." << endl;
    cout << "당신의 자동차를 선택해주세요" << endl;
    cout << "0.포르쉐" << endl;
    cout << "속도 : 빠름" << endl;
    cout << "속도 제어 : 낮음 " << endl << endl;
    cout << "1.BMW" << endl;
    cout << "속도 : 중간" << endl;
    cout << "속도 제어 : 중간 " << endl << endl;
    cout << "2.현대" << endl;
    cout << "속도 : 느림" << endl;
    cout << "속도 제어 : 높음 " << endl << endl;
    cin >> carinput;
    createCar(carinput);

    
    while (1)
    {
        /*cout << "움직일 방향의 숫자를 입력하세요." << endl;
        cout << "↑(가속), ↓(감속),  스킬키 (space)" << endl;
        cin >> inputnum;
        if (inputnum == 1)
        {
            if ((*car).speed(1) == 0);
        }
        else
        {
            cout << "잘못된 키를 입력하셨습니다." << endl;
            continue;*/
        }
        while (1)
        {
            system("cls");
            cout << "현재 속력은 " << car->speed() << "KM/H 입니다." << endl; //동적 바인딩으로 해볼수 있을거같다
            cout << "움직일 방향의 숫자를 입력하세요." << endl;
            cout << "↑(가속), ↓(감속),  스킬키 (space)" << endl;
            cin >> inputnum;
            int key;
            key = _getch();
            if (key == 224)
            {
                key = _getch();
            }
            switch (key)
            {
            case 72:
                if (car.speed() = 0)
                    car->start(driver->name());
                else
                {
                    car->gasoking(driver->name());
                }
                break;
            case 80:
                if (Car.*speed() = 0)
                {
                    car->breakSpeed(Car.*speed, driver->name());
                    cout << "차가 멈췄습니다." << endl;
                }
                else
                {
                    car->breakSpeed(Car.speed, driver.name());
                }
                break;

            default:
                cout << "잘못된 키를 입력하였습니다." << endl;

                continue;
            }
        }
    }
    
}