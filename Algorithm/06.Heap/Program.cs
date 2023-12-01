using System;
using System.Collections.Generic;

namespace _06._Heap
{
    internal class Program
    {
        /******************************************************
		 * 우선 순위 큐 - 힙 (Heap)
		 * 
		 * 힙 자료 구조와 힙 메모리는 다르다.
		 * 부모 노드가 항상 자식노드보다 우선순위가 높은 속성을 만족하는 트리기반의 자료구조
		 * 많은 자료 중 우선순위가 가장 높은 요소를 빠르게 가져오기 위해 사용
		 * 힙에 새로운 데이터를 추가하는 방법이 필요하다.
		 * 힙에 데이터를 추가하면 우선순위를 확인하고 우선순위가 높은 속성은 위로 올라간다.
		 * 삽입은 맨뒤로 넣고 아래에서 올라가는식으로 작업
		 * 삭제는 맨위에서 빼고 아래에서 올라가는식으로 작업
		 * 이진적인 처리가 가능하여 추가 삭제가 말도 안되는 작업 속도로 끝난다.
		 * 힙에서 최상단의 우선순위가 먼저 Dequeue로 빠지게 될경우 노드중 가장 아래에 있는 순서대로
		 * 힙의 최상단으로 다시 올라가게된다. 힙에 최상단에 노드가 있을경우 다시 우선순위가 높은 순서대로
		 *다시 정렬하게 된다.
		 ******************************************************/

        //<우선순위 큐 시간 복잡도>
        //최우선순위 데이터 확인    추가          삭제
        //          0(1)          0(log N)      0(log N)// 
        // 데이터를 추가, 삭제하는 속도가 굉장히 빠르다.

        //배열 기반이었을 경우
     //최우선 순위 데이터 확인    추가      삭제
        //       0(1)             0(n)      0(n)   // 비효율적이다. 우선순위 큐가 더 빠름
        void PriorityQueue()
        {
            // 기본 int 우선순위(오름차순) 적용
            PriorityQueue<string, int> pq1 = new PriorityQueue<string, int>();

            pq1.Enqueue("데이터1", 1);     // 우선순위와 데이터를 추가
            pq1.Enqueue("데이터2", 3);
            pq1.Enqueue("데이터3", 5);
            pq1.Enqueue("데이터4", 2);
            pq1.Enqueue("데이터5", 4);

            while (pq1.Count > 0) Console.WriteLine(pq1.Dequeue()); 
            // 우선순위가 높은 순서대로 데이터 출력


            // 수정 int 우선순위 적용
            PriorityQueue<string, int> pq2 = new PriorityQueue<string, int>(Comparer<int>.Create((a, b) => b - a));

            pq2.Enqueue("데이터1", 1);     // 우선순위와 데이터를 추가
            pq2.Enqueue("데이터2", 3);
            pq2.Enqueue("데이터3", 5);
            pq2.Enqueue("데이터4", 2);
            pq2.Enqueue("데이터5", 4);

            while (pq2.Count > 0) Console.WriteLine(pq2.Dequeue()); 
            // 우선순위가 높은 순서대로 데이터 출력
        }

        static void Main(string[] args)
        {
            // 기본 int 우선순위(오름차순) 적용
            DataStructure.PriorityQueue<string, int> pq1 = new DataStructure.PriorityQueue<string, int>();

            pq1.Enqueue("데이터1", 1);     // 우선순위와 데이터를 추가
            pq1.Enqueue("데이터2", 3);
            pq1.Enqueue("데이터3", 5);
            pq1.Enqueue("데이터4", 2);
            pq1.Enqueue("데이터5", 4);

            while (pq1.Count > 0) Console.WriteLine(pq1.Dequeue()); 
            // 우선순위가 높은 순서대로 데이터 출력


            // 수정 int 우선순위 적용
            DataStructure.PriorityQueue<string, int> pq2 = new DataStructure.PriorityQueue<string, int>(Comparer<int>.Create((a, b) => b - a));

            pq2.Enqueue("데이터1", 1);     // 우선순위와 데이터를 추가
            pq2.Enqueue("데이터2", 3);
            pq2.Enqueue("데이터3", 5);
            pq2.Enqueue("데이터4", 2);
            pq2.Enqueue("데이터5", 4);

            while (pq2.Count > 0) Console.WriteLine(pq2.Dequeue()); 
            // 우선순위가 높은 순서대로 데이터 출력
        }
    }
}