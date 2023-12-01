// Loop test.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//

#include <iostream>
#include <string>

using namespace std;

//1111111111111111111111111111111111111111111111111111
//int main()                  
//{
//	for (int n = 0; n < 5; n++)
//	{
//		if(n !=5)
//		cout << "*";
//		else
// 
//		{
//			cout << endl;
//			break;
//		}
//		for (int a = 2; a <= 5; a++)
//		{
//			cout << "*";
//			if (a == 5)
//			{
//				cout << endl;
//				break;
//			}
//		}
//
//	}
//}

//
//int main()
//{
//
//
//	for (int n = 0; n < 5; n++)
//	{
//		for (int m = 0; m <= n; m++)
//		{
//			cout << "*";
//		}
//		cout << endl;
//	}
//}


//int main()
//{
//
//
//	for (int n = 0; n < 5; n++)
//	{
//		
//		for (int m = 5; m > n; m--)
//		{
//			cout << "*";
//		}
//		cout << endl;
//	}
//}


int main()
{
	for (int n = -4; n < 4; n++)
	{
			for (int a = -4; a < 4; a++)
			{
				int absa = a>0?a|-a:
				int absn = n>0?n|-n:

				cout << "*";
			}
		else
		{
			for (int m = 4; m > n; m--)
			{
				cout << "*";
			}
		}
		cout << endl;
	}
}
