#pragma once
#include "Archor.h"
#include "Game.h"
#include "Player.h"
#include "Warrior.h"
#include <iostream>
#include <iostream>

using namespace std;
class Game;

class Player
{
protected:
	string name;
	int hp;
	int mp;
	int attack;
	int defence;// struct �ε� �����ϴ�.

	
public:
	void getName();
	void Attack();

};


