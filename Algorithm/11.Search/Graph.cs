using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._Searching
{
    internal class Graph
    {
        /******************************************************
		 * 그래프 (Graph)
		 * 
		 * 정점의 모음과 이 정점을 잇는 간선의 모음의 결합
		 * 한 노드에서 출발하여 다시 자기 자신의 노드로 돌아오는 순환구조를 가짐
		 * 간선의 방향성에 따라 단방향 그래프, 양방향 그래프가 있음
		 * 간선의 가중치에 따라   연결 그래프, 가중치 그래프가 있음
		 * 계층적인 자료 구조가 가능한게 트리
		 * 순환구조를 가질수 없는 트리와 다르게 그래프는 순환구조를 가진다.
		 ******************************************************/


        // <인접행렬 그래프>
        // 그래프 내의 각 정점의 인접 관계를 나타내는 행렬
        // 2차원 배열을 [출발정점, 도착정점] 으로 표현
        // 장점 : 인접여부 접근이 빠름  - 시간 복잡도 0(1)
        // 단점 : 메모리 사용량이 많음 - 공간 복잡도 0(n^2)

        // 예시 - 양방향 연결 그래프
        bool[,] matrixGraph1 = new bool[5, 5]// 무조건 25개의 데이터 공간이 필요하다.
        {//                                  이렇기 때문에 메모리 사용량이 많아짐
            { false, false, false, false,  true }, // 특징 : 대각선을 기준으로 좌우 대칭이다.
            { false, false,  true, false, false },
            { false,  true, false,  true, false },
            { false, false,  true, false,  true },
            {  true, false, false,  true, false }, 
        };


        const int INF = int.MaxValue;

        // 예시 - 단방향 가중치 그래프 (단절은 최대값으로 표현)
        int[,] matrixGraph2 = new int[5, 5]
        {
            {   0, 132, INF, INF,  16 }, // 너무 큰값은 단절시킨다.
            {  12,   0, INF, INF, INF }, // 나에서 나까지 가는건 보통 0
            { INF,  38,   0, INF, INF },
            { INF,  12, INF,   0,  54 },
            { INF, INF, INF, INF,   0 },
        };
        // <인접리스트 그래프>
        // 그래프 내의 각 정점의 인접 관계를 표현하는 리스트
        // 인접한 간선만을 리스트에 추가하여 관리
        // 장점 : 메모리 사용량이 적음//  공간 복잡도 - 0(n)
        // 단점 : 인접여부를 확인하기 위해 리스트 탐색이 필요//시간 복잡도 - 0(n)
        //         여부 확인을 위해 탐색을 하다보니 느려진다.
        // 잘 안쓰니까 잊어버려 (??)

        // 예시
        List<List<int>> listGraph1;             // 연결 그래프
        List<List<(int, int)>> listGraph2;      // 가중치 그래프
        public void ListGraph()
        {
           

            for (int i = 0; i < 5; i++)
                listGraph1.Add(new List<int>());

            listGraph1[0].Add(1); // 0번이 1번과 이어진다.
            listGraph1[0].Add(4);
            listGraph1[1].Add(3);
            listGraph1[2].Add(3);
            listGraph1[2].Add(1);
            listGraph1[2].Add(4);
            listGraph1[3].Add(1);
            listGraph1[4].Add(3);
        }
        
    }
}