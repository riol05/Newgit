#include "Game.h"
#include "Player.h"

void Game::printTitle()
{
	cout << "■■■■■■■■■■■■■■■■■" << endl;
	cout << "■■■■게임 타이틀 ■■■■■■■" << endl;
	cout << "■■■■■■■■■■■■■■■■■" << endl;

}

void Game::characterSelect()
{
	int input;
		cout << "클래스를 선택하여주세요." << endl;
		cout << "0 . 워리어" << endl;
		cout << "HP: 200" << endl;
		cout << "MP: 50" << endl;
		cout << "공격력: 30" << endl;
		cout << "방어력: 40" << endl;
		cout << "1 . 궁수" << endl;
		cout << "HP: 120" << endl;
		cout << "MP: 120" << endl;
		cout << "공격: 40" << endl;
		cout << "방어: 10" << endl;

		playerList[0] = new Warrior();
		playerList[1] = new Archor();
		cin >> input;
		cout << playerList[input]-> Getname() <<"을 선택하셨습니다."
		

}

void Game::selectMenu()
{
	int select;
	cout << "어디로 갈까?" << endl;
	cout << "1. 던전" << endl;
	cout << "2.상점" << endl;
	cout << "숫자를 입력해주세요" << endl;
	cin >> select;

}

void Game::GameStart()
{
	printTitle();
	characterSelect();
	while (!gameOver)
	{
		selectMenu();
	}
}

void Game::gameOver()
{
	cout << "     캐릭터가 죽었습니다." << endl;
	cout << "💔💔💔💔게임 오버💔💔💔💔" << endl;

}
