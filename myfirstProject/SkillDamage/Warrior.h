
#include <iostream>
#include "Player.h"
using namespace std;
class Warrior :
    public Player
{
public:
    Warrior()
    {
       name = "������";
       hp = 30;
       mp = 10 ;
       attack = 30;
       defence = 30;
    };


};
