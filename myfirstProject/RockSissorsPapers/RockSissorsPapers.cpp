﻿/*
<과제>
컴퓨터와 가위바위보를 진행하자

규칙.
플레이어는 가위, 바위, 보 중에서 하나를 선택하여 입력하도록 하자
랜덤으로 컴퓨터가 가위, 바위, 보 중에 하나를 선택하게 하자
승패를 계산해서 플레이어가 이긴 횟수, 컴퓨터가 이긴 횟수를 보여주도록 하자
둘 중 한쪽이 3번 이겼을 때 누가 이겼는지 출력하고 게임을 종료하도록 하	자

++A) 플레이어가 잘못된 오타가 있을 때 다시입력해주세요 라고 고 다시 진행하는 로직
*/

#include <iostream>
#include <cstdlib> 
#include <time.h>

using namespace std;



//int main()
//{
//    string input;
//    int user = 0;
//    int com = 0;
//    int win = 0;
//    int lose = 0;
//    int comGbv;
//    int userGbv;
//
//    srand(time(NULL)); //0보다 NULL을 넣는게 잘 나올수도 // 시간으로 랜덤의 시드값을 결정
//    comGbv = rand() % 3;
//
//
//    /* 바  가  보
//       1   2   3
//    *  4   5   6
//    *  7   8   9
//    */
//
//    cout << "컴퓨터와 가위바위보 게임!" << endl;
//    cout << "가위, 바위, 보 셋중에 하나를 내서 이기면 승리입니다. 3선승제 입니다." << endl;
//
//
//    while (1)
//    {
//
//
//
//
//
//        cout << "가위 바위 보!! : ";
//        cin >> input;
//
//        if (input == "가위")
//        {
//            cout << "가위를 입력" << endl;
//            userGbv = 1;
//        }
//        else if (input == "바위")
//        {
//            cout << "바위를 입력" << endl;
//            userGbv = 0;
//        }
//        else if (input == "보")
//        {
//            cout << "보를 입력" << endl;
//            userGbv = 2;
//        }
//        else
//        {
//            cout << "다시 입력해주세요." << endl;
//            continue;
//
//        }
//
//
//        if (userGbv == comGbv)
//        {
//            cout << "무승부입니다." << endl;
//
//        }
//        else if ((userGbv + 1) % 3 == comGbv)
//        {
//            cout << "유저 패" << endl;
//            cout << "컴퓨터 승   : " << ++com << endl;
//        }
//        else
//        {
//            cout << "유저 승!!" << endl;
//            cout << "유저 승 : " << ++user << endl;
//        }
//
//
//        cout << "유저 승 : " << user << endl;
//        cout << "컴퓨터 승   : " << com << endl;
//
//
//        if (user == 3)
//        {
//            win = 1;
//        }
//        else if (com == 3)
//        {
//            lose = 1;
//        }
//
//        if (win == 1)
//        {
//
//            cout << "플레이어 승!! 축하드립니다." << endl;
//            break;
//
//        }
//        else if (lose == 1)
//        {
//            cout << "컴퓨터 승!! 운이 좋지 않았네요." << endl;
//            break;
//
//        }
//
//
//
//    }
//}

//교수님 답안

int main()
{
	srand(time(NULL));//0보다 NULL을 넣는게 잘 나올수도 // 시간으로 랜덤의 시드값을 결정
	int lose = 0;
	int win = 0;
	while (win < 3 && lose < 3)
	{
		string user;
		do
		{
			cout << "가위 바위 보 중 하나를 선택해주세요 :";
			
			cin >> user;
			cout << endl;
		} while (user != "가위" && user != "바위" && user != "보");

		int random = rand() % 3;
		string com;
		switch (random)
		{
		case 0:
		{
			com = "가위";
			break;
		}
		case 1:
		{
			com = "바위";
			break;
		}
		case 2:
		{
			com = "보";
			break;
		}


		}   // 랜덤값을 switch 를 이용하여 
		cout << "컴퓨터가 고른것은 " << com << "입니다.\n";


		if (user == "가위")
		{
			if (com == "가위")
			{
				cout << "무승부!" << endl;
			}
			else if (com == "바위")
			{
				cout << "패배!" << endl;
				++lose;
			}
			else
			{
				cout << "승리!" << endl;
				++win;
			}
		}
		else if (user == "바위")
		{
			if (com == "가위")
			{
				cout << "승리!" << endl;
				++win;
			}
			else if (com == "바위")
			{
				cout << "무승부!" << endl;
			}
			else
			{
				cout << "패배!!" << endl;
				++lose;
			}
			}
		else if (user == "보")
		{
			if (com == "가위")
			{
				cout << "패배!" << endl;
				++lose;
			}
			else if (com == "바위")
			{
				cout << "승리!" << endl;
				++win;
			}
			else
			{
				cout << "무승부!!" << endl;
			}
		}

		cout << "유저의 승리수 : " << win << endl;
		cout << "컴퓨터의 승리수 : " << lose << endl;

		if (win == 3)
		{
			cout << "플레이어 승리!!";
			
		}
		else if (lose == 3)
		{
			cout << "컴퓨터 승리!!";
			
		}
	}


}