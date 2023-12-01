using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._ShortestPath
{
    internal class Dijkstra
    {
        /******************************************************
		 * 다익스트라 알고리즘 (Dijkstra Algorithm)
		 * 
		 * 특정한 노드에서 출발하여 다른 노드로 가는 각각의 최단 경로를 구함
		 * 방문하지 않은 노드 중에서 최단 거리가 가장 짧은 노드를 선택 후,
		 * 해당 노드를 거쳐 다른 노드로 가는 비용 계산
		 * 하나의 정점을 거쳐 탐색 할 경우에 더 거리가 짧아지는 최단 거리가 있을경우, 기존의 경로에서 그 짧은 경로로 대체한다.
		 ******************************************************/
        // 시간 복잡도 O(n^2)

        const int INF = 99999;
        
       

            public static void ShortestPath(in int[,] graph, in int start, out bool[] visited ,out int[] distance, out int[] parent)
        {
            int size = graph.GetLength(0);
            visited = new bool[size];
            distance = new int[size];
            parent = new int[size];

            for (int i = 0; i < size; i++)
            {
                distance[i] = INF;
                parent[i] = -1;
                visited[i] = false;
            }
            distance[start] = 0; // 0부터 시작해야하기 때문에 start는 0
      
            for (int i = 0; i < size; i++) // 정점의 갯수만큼 돌리기위한 i
            {
                // 1. 방문하지 않은 정점 중 가장 가까운 정점부터 탐색
                int minindex = -1;             // 다음으로 탐색할 가장 가까운 정점
                int minCost = INF;             // 가장 가까운 정점의 거리
                for (int j = 0; j < size; j++) // 제일 가까운 정점 탐색
                {
                    if (!visited[j] &&         // 방문하지 않은 정점 이면서 동시에
                        distance[j] < minCost) // 지금 거리중에서 가장 짧은 거리 가 나오기 전까지
                    {
                        minindex = j; // 방문하지 않았으면서 제일 짧은 거리 minindex 가 나오게된다.
                        minCost = distance[j];
                    }
                   
                }
                if (minindex < 0) // 돌렸는데도 -1이면 탐색할 정점이 없단 뜻이니 관두자
                    break;

                // 2. 직접연결된 거리보다 거쳐서 더 짧아진다면 직접 연결된 거리를 갱신.
                // Ex) 서울에서 부산까지 5시간 이었는데 대전을 경유해서 가면
                // 2시간 2시간으로 4시간이 나온다 할떄 거리를 최단 거리로 갱신하자
                for (int j = 0; j < size; j++)
                {
                    // c distance[j] : 목적지까지 직접 연결된 거리
                    // a distance[minindex] : 탐색중인 정점까지 거리 // 여기서 제일 짧은 거리
                    // b graph[minindex, j] : 탐색중인 정점부터 목적지의 거리
                    // c가 a와 b를 합쳐서 더 작다면
                    // 직접가는 거리가 거쳐서 가는 거리보다 더 크다면(느리다면)
                    if (distance[j] > distance[minindex] + graph[minindex, j]) //직접가는 거리보다, 중간 지점을 거쳐서 더 짧아지는 경우
                    {
                        distance[j] = distance[minindex] + graph[minindex, j]; // 중간 지점을 거쳐서 나온 거리를 직접 연결된 거리로 갱신
                        parent[j] = minindex; //그 경로를 최단 경로로 갱신한다. // 탐색한 정점(부모)을 갱신
                    }
                }
                visited[minindex] = true;
            }
        }
    }
}