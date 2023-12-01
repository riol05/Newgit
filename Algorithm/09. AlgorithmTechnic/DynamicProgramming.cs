using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._DesignTechnique
{
    internal class DynamicProgramming
    {
        /******************************************************
		 * 동적계획법 (Dynamic Programming)
		 * 
		 * 작은문제의 해답을 큰문제의 해답의 부분으로 이용하는 상향식 접근 방식
		 * 주어진 문제를 해결하기 위해 부분 문제에 대한 답을 계속적으로 활용해 나가는 기법
		 * 있던것을 바로 추출해서 값을 빼오는 것이 동적 계획법이다.
		 * 상승식의 문제 해결 방식
		 * 작은 단위의 결과물을 모아놓고 그 상위의 문제를 풀떄 그 결과물을 갖다 쓴다.
		 * 더 큰문제는 중간에서 푼 문제를 모아서 푼다.
		 ******************************************************/

        // 예시 - 피보나치 수열
        //f(n) = f(n-2) = f(n-1);
        // f(1) = 1;
        // f(2) = 1;
        // 1 1 2 3 5 8 13 21 34
        int Fibonachi(int x)
        {
            int[] fibonachi = new int[x + 1];
            fibonachi[1] = 1;
            fibonachi[2] = 1;

            for (int i = 3; i <= x; i++)
            {
                fibonachi[i] = fibonachi[i - 1] + fibonachi[i - 2];
            }

            return fibonachi[x];
        }
    }
}