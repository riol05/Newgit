#include "Game.h"
#include <iostream> // 헤더파일 쓰면 소스에는 안써두 됨

using namespace std;
class Player;


void Game::PrintTitle()
{
	cout << "■■■■■■■■■■■■■■■■■" << endl;
	cout << "■■■■게임 타이틀 ■■■■■■■" << endl;
	cout << "■■■■■■■■■■■■■■■■■" << endl;

}

void Game::characterSelect()
{
	cout << "캐릭터를 선택해주세요" << endl;
	playerList[0] = new Warrior();
		
	cout << "선택 : ";
	int select;
		cin >> select;
		cout << playerList[select]->Getname() << "을 선택하셨습니다.";

}

int Game::SelectMenu()
{
	cout << "어디로 가?" << endl;
	cout << "1 던전" << endl;
	cout << "2 상점" << endl;
	int select;
	cout << "선택 : ";
	cin >> select;
	return select;
}

void Game::WaitASecond()
{
}

void Game::GameStart()
{
	PrintTitle();
	characterSelect();
	while (!GameOver)
	{
		SelectMenu();

	}

}

void Game::GameOver()
{

}
