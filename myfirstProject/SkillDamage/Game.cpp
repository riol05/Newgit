#include "Game.h"
#include <iostream> // ������� ���� �ҽ����� �Ƚ�� ��

using namespace std;
class Player;


void Game::PrintTitle()
{
	cout << "������������������" << endl;
	cout << "�������� Ÿ��Ʋ ��������" << endl;
	cout << "������������������" << endl;

}

void Game::characterSelect()
{
	cout << "ĳ���͸� �������ּ���" << endl;
	playerList[0] = new Warrior();
		
	cout << "���� : ";
	int select;
		cin >> select;
		cout << playerList[select]->Getname() << "�� �����ϼ̽��ϴ�.";

}

int Game::SelectMenu()
{
	cout << "���� ��?" << endl;
	cout << "1 ����" << endl;
	cout << "2 ����" << endl;
	int select;
	cout << "���� : ";
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
