#include "Warrior.h"

inline Warrior::Warrior()
{
	name = "������";
	hp = 200;
	mp = 50;
	attack = 30;
	defence = 40;
}

void Warrior::smash()
{
	cout << "�������� ��ų ���! ���Ž�! " << endl;
	cout << attack*2 << "��ŭ�� �������� ���ߴ�." << endl;
}
