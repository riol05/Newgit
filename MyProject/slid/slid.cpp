#include <iostream>
#include <conio.h>
#include <time.h>
#include <Windows.h>

using namespace std;

void changeLocation(int dest, int sour, int* arr)
{
	int temp = arr[dest];
	arr[dest] = arr[sour];
	arr[sour] = temp;
}

void game()
{
	srand(time(NULL));
	int locationZero = 24;
	int arr[25];
	int inputcount = 0;

	for (int i = 0; i < 24; i++)
		arr[i] = i + 1;

	for (int i = 0; i < 77; i++)
	{
		int dest, sour, temp;

		dest = rand() % 24;
		sour = rand() % 24;

		changeLocation(dest, sour, arr);

	}
	arr[24] = 0;

	while (true)
	{
		system("cls");
		int locationZeroNow = locationZero;

		for (int i = 0; i < 25; i++)
		{
			cout << arr[i] << '\t';
			if ((i + 1) % 5 == 0) cout << endl << endl;
		}
		cout << "움직일 방향의 숫자를 입력하세요." << endl;
		cout << "←(4), →(8), ↑(6), ↓(2)" << endl;


		int key;
		key = _getch();
		if (key == 224)
			key = _getch();

		switch (key)
		{
		case 72:
			if (locationZero < 5) break;
			locationZero -= 5;
			break;
		case 75:
			if (locationZero % 5 == 0) break;
			locationZero -= 1;
			break;
		case 77:
			if (locationZero % 5 == 4) break;
			locationZero += 1;
			break;
		case 80:
			if (locationZero > 19) break;
			locationZero += 5;
			break;
		default:
			continue;
		}

		{
			int dest = locationZeroNow, sour = locationZero;
			changeLocation(dest, sour, arr);
		}

	}
}
void printgameclear()
{

	cout << "--------------------------✨" << endl;
	cout << "게임을 클리어 하셨습니다!!" << endl;
	cout << "--------------------------✨" << endl;
	return;
}

int main()
{
	game();
	printgameclear();
}
