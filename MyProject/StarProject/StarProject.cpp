// StarProject.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//

#include <iostream>

using namespace std;

// 1번
//int main()                  
//{
//   for (int n = 0; n < 5; n++)
//   {
//      if(n !=5)
//      cout << "*";
//      else
// 
//      {
//         cout << endl;
//         break;
//      }
//      for (int a = 2; a <= 5; a++)
//      {
//         cout << "*";
//         if (a == 5)
//         {
//            cout << endl;
//            break;
//         }
//      }
//
//   }
//}

//1번 정석 풀이 방법
//int main()
//{
//	for (int n = 1; n <= 5; n++)
//	{
//		for (int m = 1; m <= 5; m++)
//		{
//			cout << "*";
//		}
//		cout << endl;
//	}
//}

// 2번
//int main()
//{
//
//
//   for (int n = 0; n < 5; n++)
//   {
//      for (int m = 0; m <= n; m++)
//      {
//         cout << "*";
//      }
//      cout << endl;
//   }
//}

// 3번
//int main()
//{
//
//
//   for (int n = 0; n < 5; n++)
//   {
//      
//      for (int m = 5; m > n; m--)
//      {
//         cout << "*";
//      }
//      cout << endl;
//   }
//}






// 4번
//int main()
//{
// 
//	for (int y = -4; y <= 4; y++)
//	{
//		for (int x = -4; x <= 4; x++)
//		{
//			int absX = x > 0 ? x : -x;
//			int absY = y > 0 ? y : -y;
//			if (absX + absY >= 5)
//			{
//				cout << " ";
//			}
//			else
//			{
//				cout << "*";
//			}
//		}
//		cout << endl;
//	}
//}
