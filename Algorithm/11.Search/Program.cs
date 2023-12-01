namespace _11.Search
{
    internal class Program
    {
        // <순차 탐색> // 탐색? 하나하나 다 찾아보면 되잖아
        // 하나하나 찾으니 당연히 시간 복잡도가 늘어나게됨
        // 시간 복잡도 - O(N)
        public static int SequentialSearch<T>(in IList<T> list, in T item)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (item.Equals(list[i])) // 시작부터 끝까지 item 이랑 똑같은 데이터 찾으면 끝
                        return i;
                }
                return -1;
            }

            // <이진 탐색> // 순차 탐색보다 효율적/ 한가지 보장을 해줘야한다.
            // 내가 갖고 있는 배열이 정렬되어 있다 라고 할때 이진 탐색이 훨씬 빠르다
            // 중간 지정. 중간에 갖고 있는 값이 내가 가진 값보다 작거나, 크다 할때, 그 나머지 수들은 안봐도 됨
            // 시간 복잡도 - 0(logN)
            // 하지만 정렬이 되어있지 않으면 쓸수 없는 단점, 정렬이 되어 있지 않으면 당연히 순차 탐색을 쓴다.
            public static int BinarySearch<T>(IList<int> list, int item)
            {
                int low = 0;
                int high = list.Count - 1
                ;
                while (low <= high)
                {
                    int middle = (low + high) / 2;
                if (item > list[middle])
                {
                    low = middle + 1;
                }
                else if (item < list[middle])
                {
                    high = middle - 1;
                }
                else
                    return middle;
                }

                return -1;
            }

            // <깊이 우선 탐색 DFS : (Depth-First Search)>
            // 그래프의 분기를 만났을 때 최대한 깊이 내려간 뒤,
            // 더 이상 깊이 갈 곳이 없을 경우 다음 분기를 탐색
            // 깊이 우선 탐색이 너비 우선 탐색보다 간단하다. 
            // 깊이 우선 탐색은 분할 정복으로 구현 가능하다.
            // 스택 구조를 쓰면 정확하게 들어맞는다. 스택을 이용하여 구현하자
            // 스택을 이용하면 한쪽 분기의 탐색이 끝날때까지 다음 분기 탐색을 하지 않는다.
            // 스택을 통해 탐색하기 때문에 최단 경로가 아닐수도 있다.
            // searchnode함수 호출까지 쓰기에 너비 우선 탐색을 쓴다.
            // 깊이 우선 탐색의 경우 장거리 까지 더 빠르게 갈수는 있다.
        public static void DFS(in bool[,] graph, int start, out bool[] visited, out int[] path)
// 어디부터 시작할지 start, 시작 노드부터 다른곳으로 갈수 있는지 여부를 위해 visit, 경로를 알기위해(이노드에 도달하기 위해 어떤 노드를 통한 경로를 쓰는지) parents 
// return 값을 여러개 받기 위해 out parameter를 쓴다.
        {

            visited = new bool[graph.GetLength(0)];
            // 이차원 배열에선 graph.Length 라고 할때 총길이가 나오게된다.
            // (만약 2차원 배열의 크기가 [2,4] 일때 graph.Length를 쓰게되면 곱하기 하여 8 다시 2차원 배열의 값 [8,8]을 받게 된다. 그럼 배열의 크기가 더 늘어나게 되니 GetLength를 사용해주자 )
            // getLength[0]을 써서 2차원 배열의 맨 처음 값 [0,1]의 값으로 초기화를 시켜준다. 
            path = new int[graph.GetLength(0)];

                for (int i = 0; i < graph.GetLength(0); i++) // 반복하기 위해 초기값 세팅
                {
                    visited[i] = false;
                    path[i] = -1; // path의 경로도 연결 안된 상황 -1 설정
                }

                SearchNode(graph, start, visited, path); // 시작 지점부터 searchnode 한다.
            // 재귀를 통해
        }            
        private static void SearchNode(in bool[,] graph, int start, bool[] visited, int[] path)
        {
             visited[start] = true; // 시작지점부터 탐색 했다하면 visit 을 true로
             for (int i = 0; i < graph.GetLength(0); i++) // 그래프의 개수만큼
             { // 0번 정점을 기준으로 탐색해야할 정점은
                 if (graph[start, i] &&      // 연결되어 있는 정점이며,
                     !visited[i])            // 동시에 방문한적 없는 정점을 탐색해주자
                 {
                     path[i] = start; // path 같은 경우 이 탐색한 정점은 출발지로 설정
                    SearchNode(graph, i, visited, path); // 그 방식을 search node로 탐색해준다.
                    // 재귀 사용
                 }
             }
        }

            // <너비 우선 탐색 BFS : (Breadth-First Search)>
            // 최대한 넓게 이동한 다음, 더 이상 갈 수 없을때 아래로 이동
            // 그래프의 분기를 만났을 때 모든 분기를 저장한 뒤,
            // 저장한 분기를 하나씩 탐색
            // 너비 우선 탐색은 큐를 이용하여 구현한다.
            // 반드시 최단 경로가 나오게 된다.
            // 깊이나 너비나 캐시 적중률은 좋지않다.
            public static void BFS(in bool[,] graph, int start, out bool[] visited, out int[] parents)
            {
                visited = new bool[graph.GetLength(0)];
                parents = new int[graph.GetLength(0)];

                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    visited[i] = false; // out 매개변수 한정자를 썼으니,visited를 false로 전부 세팅해준다
                    parents[i] = -1;    // parents도 마찬가지 배열에 없는 숫자인 음수를 사용하여 세팅해준다.
                }

                Queue<int> bfsQueue = new Queue<int>(); // 큐를 이용하여 구현 시작

                bfsQueue.Enqueue(start); // 탐색을 위해 start를 할당시에 넣어준다
                while (bfsQueue.Count > 0) // 큐가 빌때까지 dequeue로 빼주기 위한 반복문
                {
                    int next = bfsQueue.Dequeue(); // 꺼내서 다음 i와 비교하기 위해 Dequeue 를 쓴다.
                    

                    for (int i = 0; i < graph.GetLength(0); i++) // 연결되어 있는 정점들 중에 탐색한적이 없는 정점들을 Enqueue 하기 위한 반복문
                    {
                        if (graph[next, i] &&       // 연결되어 있는 정점이며,
                            !visited[i])            // 탐색한적 없는 정점
                        {
                            visited[i] = true;          // 다음으로 탐색해야할 정점을 true로 설정
                            parents[i] = next;          // 얘를 통해 탐색했다.
                            bfsQueue.Enqueue(i);        // 그 정점을 다음 탐색 정점으로 
                    }
                    }
                }
            }
        }
    }