#pragma once
#include <iostream> // 헤더파일 쓰면 소스에는 안써두 됨

using namespace std;

class Player
{
protected:
	string name;
	int hp;
	int mp;
	int attack;
	int defence;// struct 로도 가능하다.
public :
	void getName();

	
};

