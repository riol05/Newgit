#pragma once
#include <iostream> // 헤더파일 쓰면 소스에는 안써두 됨
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
