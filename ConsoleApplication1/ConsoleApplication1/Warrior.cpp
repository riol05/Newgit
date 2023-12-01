#include "Warrior.h"

inline Warrior::Warrior()
{
	name = "워리어";
	hp = 200;
	mp = 50;
	attack = 30;
	defence = 40;
}

void Warrior::smash()
{
	cout << "워리어의 스킬 사용! 스매쉬! " << endl;
	cout << attack*2 << "만큼의 데미지를 가했다." << endl;
}
