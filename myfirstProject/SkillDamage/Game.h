#pragma once
#include <iostream> // ������� ���� �ҽ����� �Ƚ�� ��
#include "Player.h"

using namespace std;

class Player;

class Game
{
	string name;
	Player* playerList[3];
private:
	void PrintTitle();
	void characterSelect();
	
		void SelectMenu();
		void WaitASecond();

	


public:
	void GameStart();
	void GameOver();
	void item();
	

};
