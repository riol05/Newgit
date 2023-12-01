using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._DesignTechnique
{
    internal class Greedy
    {
        /******************************************************
		 * 탐욕 알고리즘 (Greedy Algorithm)
		 * 
		 * 문제를 해결하는데 사용되는 근시안(짧은시야)적 방법
		 * 문제를 직면한 당시에 당장 최적인 답을 선택하는 과정을 반복
		 * 단, 반드시 최적의 해를 구해준다는 보장이 없음
		 * 하지만 빨랐죠?
		 ******************************************************/

        // 예시 - 자판기 거스름돈
        void CoinMachine(int money)
        {
            int[] coinType = { 500, 100, 50, 10, 5, 1 };
            //  최적의 값이 반드시 나오진 않는다.
            // {100, 500 , 50 , 10 ,5, 1} 이 경우 100원만 와장창 나오게된다.
            // 그 경우 값은 맞지만 최적은 아님

            foreach (int coin in coinType)
            {
                while (money <= coin)
                {
                    Console.WriteLine("{0} 코인 배출", coin);
                    money -= coin;
                }
            }
        }
    }
}