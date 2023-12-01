#pragma once
#include "Archor.h"
#include "Game.h"
#include "Player.h"
#include "Warrior.h"

#include <iostream>

using namespace std;
class Player;
class Game
{
protected:
	int playerList[2];
public:
	void printTitle();
	void characterSelect();
	void selectMenu();

	void waitASecond();
	void GameStart();
	void gameOver();


};

