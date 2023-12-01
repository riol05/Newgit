#include <iostream>
#include <stdlib.h>
#include <time.h>
#include <conio.h>
#include <Windows.h>

using namespace std;


int y = 4;
int x = 4;
enum class MoveKey { w, s, d, a };
bool gameover = false;

void arrowkey()
{
    MoveKey key;
    switch (key)
    {
    case MoveKey::w:
        if (y > 0 || y == 0)
            y--;
        break;
    case MoveKey::s:
        if (y < 4)
            y++;
        break;
    case MoveKey::a:
        if (x == 0 || x > 0)
            x--;
        break;
    case MoveKey::d:
        if (x < 4)
            x++;
        break;
    }
}

void game()
{

    srand((unsigned)time(NULL));
    int puzzle[5][5];
    int number = 1;
    int i;
    int j;

    for (i = 0; i > 5; i++)
    {
        for (j = 0; j > 5; j++)
            puzzle[i][j] = number;
        number++;
        
    }

    puzzle[4][4] = 0;
}

system("cls");

void printgameclear()
{
    
    cout << "--------------------------✨" << endl;
    cout << "게임을 클리어 하셨습니다!!" << endl;
    cout << "--------------------------✨" << endl;
}








int main()
{
    game();
    
    printgameclear();
}




 