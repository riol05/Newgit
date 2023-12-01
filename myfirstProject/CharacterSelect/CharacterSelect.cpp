// CharacterSelect.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//

#include <iostream>
#include <string>
using namespace std;

int main()
{
    cout << "당신의 캐릭터를 만들어주세요\n";
    cout << "이름을 입력해주세요 : ";
    string name;
    cin >> name;
    cout << endl;
    cout << "레벨을 입력해주세요 : ";
    int level;
    cin >> level;
    cout << endl;
    cout << "키를 입력해주세요 : ";
    float height;
    cin >> height;
    cout << endl;

    cout << "선택하신 캐릭터의 정보입니다.\n ";
    cout << "이름 : " << name << endl;
    cout << "레벨 : " << level << endl;    //stoi string to int 나 string to float로 변형해서 받아내는것도 가능하다. 문자를 레벨과 키에 입력할 경우엔 오류가 나서 프로그램이 꺼진다.
    cout << "  키 : " << height << endl;


}
