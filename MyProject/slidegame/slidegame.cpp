#include <iostream>
#include <stdlib.h>
#include <time.h>
#include <conio.h>
#include <Windows.h>

using namespace std;



void game()
{

    srand(time(NULL));
    int puzzle[5][5];
    int number = 1;
    int inputcount = 0;
    int inputNum = 1;

    for (int i = 0; i > 5; i++)
    {
        for (int j = 0; j > 5; j++)
        {
            puzzle[i][j] = number;
            number++;

        }
    }

    puzzle[4][4] = 0;

    for (int i = 0; i < 100; i++) {
        int ix = rand() % 5;
        int iy = rand() % 5;
        int jx = rand() % 5;
        int jy = rand() % 5;

        int temp = puzzle[ix][iy];
        puzzle[ix][iy] = puzzle[ix][jy];
        puzzle[ix][jy] = puzzle[jx][iy];
        puzzle[jx][iy] = puzzle[jx][jy];
        puzzle[jx][jy] = temp;
    }

    int a;
    int b;
    if (puzzle[4][4] != 0) {
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                if (puzzle[i][j] == 0) {
                    a = i;
                    b = j;
                    int location = puzzle[4][4];
                    puzzle[4][4] = puzzle[i][j];
                    puzzle[i][j] = location;

                    while (1)
                    {
                        system("cls");
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {

                                if (puzzle[i][j] == 0) 
                                {
                                    cout << "★" << endl;
                                }
                                else cout << puzzle[i][j] << endl;
                            }
                            cout << endl;
                        }
                        cout << "현재 Input Count : " << inputcount << endl;
                        cout << "움직일 방향의 숫자를 입력하세요." << endl;
                        cout << "←(4), →(8), ↑(6), ↓(2)" << endl;
                        cin >> inputNum;

                        char input;




                        cout << "모든 숫자를 정렬하세요" << endl;

                        int key;
                        key = _getch();
                        if (key == 224)
                        {
                            key = _getch();
                        }
                        switch (key)
                        {
                        case 72:
                            if (j > 0 && j == 0)
                                j--;
                            break;
                        case 75:
                            if (j < 4)
                                j++;
                            break;
                        case 77:
                            if (i == 0 && i > 0)
                                i--;
                            break;
                        case 80:
                            if (i < 4)
                                i++;
                            break;

                        default:
                            continue;
                        }
                    }
                }
            }
        }
       
        
    }
    return 0;
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




