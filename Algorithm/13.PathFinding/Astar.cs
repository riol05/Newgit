using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace _13._PathFinding
{
    internal class AStar
    {
        /******************************************************
		 * A* 알고리즘****************매우 중요****************
		 * 
		 * 다익스트라 알고리즘을 확장하여 만든 최단경로 탐색알고리즘
		 * 경로 탐색의 우선순위를 두고 유망한 해부터 우선적으로 탐색
		 * 목적지까지 최단 경로일거 같은 경로로 우선적으로 탐색한다.
		 * 3D 유니티 에선 네이게이션 기능이 있어서 3D에선 그걸 사용해주는것이 좋다.
		 * 하지만 2D에선 A* 알고리즘이 필요하기 때문에 필수!
		 ******************************************************/
          /* f : g+h = 총 예상거리  
           * g : 지금까지 이동한 거리 . 탐색한 정점까지의 거리 +한칸
(휴리스틱) * h : 예상남은거리 : 1. 유클리드 거리 : 직선거리 로그 사용+
                                유클리드를 사용해서 대각선 이동을 하게되면 로그연산이 필수이기 때문에 경로가 줄어들었음에도 더 느려지게 된다.
* (둘중 하나 선택)           2. 맨하튼 거리 : x로 가도 y로 가도 똑같을때 그 값만 구하자는게 맨하튼 거리
*           탐색 우선순위는 f가 같으면 g가 큰쪽을 먼저 탐색한다. 맨하튼 거리를 쓰면 경로가 너무 많아진다.
         */
        const int CostStraight = 10;
        const int CostDiagonal = 14;

        static Point[] Direction =
        {
            new Point(  0, +1 ),			// 상
			new Point(  0, -1 ),			// 하
			new Point( -1,  0 ),			// 좌
			new Point( +1,  0 ),			// 우
			//new Point( -1, +1 ),		    // 좌상 // 대각선 a*를 구현할때
			//new Point( -1, -1 ),		    // 좌하
			//new Point( +1, +1 ),		    // 우상
			//new Point( +1, -1 )		    // 우하
		};

        public static bool PathFinding(in bool[,] tileMap, in Point start, in Point end, in bool cross, out List<Point> path)
        {
            int ySize = tileMap.GetLength(0);
            int xSize = tileMap.GetLength(1);

            ASNode[,] nodes = new ASNode[ySize, xSize]; // 
            bool[,] visited = new bool[ySize, xSize]; // 탐색했다는걸 표현하기 위한 visited
            PriorityQueue<ASNode, int> nextPointPQ = new PriorityQueue<ASNode, int>();
// 우선순위 큐를 쓰기 좋은!! 가장 f가 낮은 정점을 빨리 찾아야 하니까 f값을 기준치로 넣고 가장 작은 정점이 나오도록 우선순위 큐 사용

            // 0. 시작 정점을 생성하여 추가
            ASNode startNode = new ASNode(start, new Point(), 0, Heuristic(start, end)); //g값은 0 h를 계산하는인 휴리스틱
            nodes[startNode.point.y, startNode.point.x] = startNode;
            nextPointPQ.Enqueue(startNode, startNode.f);
            // 우선순위에 f정점을 인큐
            while (nextPointPQ.Count > 0) // 우선순위 큐가 빌떄까지 탐색 // 우선순위 큐에서 바로 나온 정점이 제일 작은 정점일거니까
            {
                // 1. 다음으로 탐색할 정점 꺼내기
                ASNode nextNode = nextPointPQ.Dequeue(); // 제일 작은 정점만 먼저 탐색

                // 2. 방문한 정점은 방문표시
                visited[nextNode.point.y, nextNode.point.x] = true; // 탐색한 표시를 한다

                // 3. 다음으로 탐색할 정점이 도착지인 경우 // 그럼 안해도 된다.
                // 도착했다고 판단해서 경로 반환
                if (nextNode.point.x == end.x && nextNode.point.y == end.y)
                {
                    path = new List<Point>(); // 역순으로 가면서 parnent를 넣어주는것을 반복

                    Point point = end;
                    while (!(point.x == start.x && point.y == start.y))
                    {
                        path.Add(point);
                        point = nodes[point.y, point.x].parent;
                    }
                    path.Add(start);

                    path.Reverse(); // 경로를 반전 시켜준다
                    return true;
                }
                // 아니었다 하면 다시 탐색을 반복해준다.
                // 4. AStar 탐색을 진행
                // 방향 탐색
                for (int i = 0; i < Direction.Length; i++) // 위 오른쪽 왼쪽 아래 정점을
                {
                    int x = nextNode.point.x + Direction[i].x;
                    int y = nextNode.point.y + Direction[i].y;

                    // 4-1. 탐색하면 안되는 경우
                    // 맵을 벗어났을 경우
                    if (x < 0 || x >= xSize || y < 0 || y >= ySize) // 맵을 벗어나는 상황
                        continue; // 돌아가자
                    // 탐색할 수 없는 정점일 경우
                    else if (tileMap[y, x] == false) // 타일맵의 위치가 false 일 경우(벽일경우?)
                        continue; // 돌아갑시다~

                    // 이미 방문한 정점일 경우
                    else if (visited[y, x]) 
                        continue;
                    // 대각선으로 이동이 불가능 지역인 경우
                    //else if (i >= 4) // 대각선 기준으로 오른쪽과 왼쪽 하나는 뚫려있을때만 이동할수 있다고 해준다
                    //{                // 둘다 막혀있으면 갈수 없게 한다. 이건 직선도 안됨
                    //    if (!tileMap[y, nextNode.point.x] && !tileMap[nextNode.point.y, x])
                    //        continue;
                    //    if (cross && tileMap[y, nextNode.point.x] ^ tileMap[nextNode.point.y, x])
                    //        continue;
                    //} // 교수님은 대각선 이동 사용 안했음

                    // 4-2. 점수 구하기 (g랑 h값을 구해보자)
                    int g = nextNode.g + CostStraight;//CostStraight(직선거리);가 대신사용 ((nextNode.point.x == x || nextNode.point.y == y) ? CostStraight : CostDiagonal);// 이건 대각선으로 갈경우에
                    int h = Heuristic(new Point(x, y), end); //휴리스틱으로 구해준다 목적지까지의 도착 정점까지 h값
                    ASNode newNode = new ASNode(new Point(x, y), nextNode.point, g, h); // 대각선 개수와 직선 개수로
                    

                    // 4-3. 정점의 갱신이 필요한 경우 새로운 정점으로 할당
                    // 기본의 정점과 새로운 정점을 갱신해준다.(그 거리가 더 가까운 상황일떄)
                    // ex) 탐색 하고 있던 상황이 
                    if (nodes[y, x] == null ||      // 탐색하지 않은 정점이거나
                        nodes[y, x].f > newNode.f)  // 가중치가 높은 정점인 경우
                    {
                        nodes[y, x] = newNode; // 탐색한 정점에 의해서 더 짧은 거리가 발견되면 그거리로 갱신시켜준다
                        nextPointPQ.Enqueue(newNode, newNode.f); // 
                    }
                }
            }

            path = null;
            return false;
        }

        // 휴리스틱 (Heuristic) : 최상의 경로를 추정하는 순위값, 휴리스틱에 의해 경로탐색 효율이 결정됨
        private static int Heuristic(Point start, Point end)
        {
            int xSize = Math.Abs(start.x - end.x);  // 가로로 가야하는 횟수
            int ySize = Math.Abs(start.y - end.y);  // 세로로 가야하는 횟수

            // 맨해튼 거리 : 직선을 통해 이동하는 거리
            // return CostStraight * (xSize + ySize);
            // 여러 경로가 생기는게 단점

            // 유클리드 거리 : 대각선을 통해 이동하는 거리
            // return CostStraight * (int)Math.Sqrt(xSize * xSize + ySize * ySize);
            // 루트 연산을 이용해서 대각선의 거리를 이동
            // 이땐 여러 후보 경로가 생기는게 아니라 경로는 줄어들지만
            // 루트 연산에서 시간이 오래 걸리게된다.

            // 타일맵용 유클리드 거리 : 직선과 대각선을 통해 이동하는 거리
            int straightCount = Math.Abs(xSize - ySize);
            int diagonalCount = Math.Max(xSize, ySize) - straightCount;
            return CostStraight * straightCount + CostDiagonal * diagonalCount;
        }

        private class ASNode
        {
            public Point point;     // 현재 정점의 위치
            public Point parent;    // 현재 정점(나)을 탐색한 정점

            public int g;           // 현재까지의 값, 즉 지금까지 경로 가중치
            public int h;           // 앞으로 예상되는 값, 목표까지 추정 경로 가중치
            public int f;           // f(x) = g(x) + h(x);
            // A* 정점만들어준다

            public ASNode(Point point, Point parent, int g, int h)
            {
                this.point = point;
                this.parent = parent;
                this.g = g;
                this.h = h;
                this.f = g + h;
            }
        }
    }

    public struct Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}