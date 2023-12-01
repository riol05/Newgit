using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._DesignTechnique
{
    internal class DivideAndConquer
    {
        /******************************************************
		 * 분할정복 (Divide and Conquer)
		 * 
		 * 큰 문제를 작은 문제로 나눠서 푸는 하향식 접근 방식
		 * 분할을 통해서 해결하기 쉬운 작은 문제로 나눈 후 정복한 후 병합하는 과정
		 * 분할 정복은 재귀함수로 구현하는 경우가 많다 보통
		 ******************************************************/

        // 예시 1 - 폴더 삭제
        struct Directory
        {
            public List<Directory> childDir;
        }
        void RemoveDir(Directory directory)
        {
            foreach (Directory dir in directory.childDir)
            {
                RemoveDir(dir);
            }

            Console.WriteLine("폴더 내 파일 모두 삭제");
        }

        // 예시 2 - 거듭 제곱 계산
        // x ^n = x * x * x .... (n 번 반복)
        // x ^n = x^(n/2) * x^(n/2) // 반으로 나눠서 계산한다.
        int Pow1(int x , int n)
        {
            int result = 1;
            for (int i = 0; i < n; i ++)
            {

            }
            return ;
        }
        public int Pow(int x, int n)
        {
            // x^n = (x)^(n / 2) * (x)^(n / 2)

            if (n == 0)
            {
                return 1;
            }
            int result;
            if (n % 2 == 0)
                result = Pow(x, n / 2); // 큰문제를 쪼갰다.
            else
            { 
                result = x * Pow(x, (n - 1) / 2);
        }
            return result*result;
        }
    }
}