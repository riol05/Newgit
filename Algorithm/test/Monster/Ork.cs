using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Ork : Monster
    {
        private Random random = new Random();
        private int moveTurn = 0;
        public Ork()
        {
            icon = '오';
            name = "오크";
            curHp = maxHp = 50;
            Damage = 10;
            rewardExp = 80;
            rewardgold = 30;
        }

        public override void Getreward()
        {
            Inventory invenList = Inventory.GetInstance();
            invenList.AddItem(new APotion());
        }

        public override void MoveAction()
        {
            moveTurn++;
            if (moveTurn < 2) // 2보다 작으면
            {
                return; // 안한다.
            }
            if (GetDirection(out Direction direction))
            {
                Move(direction);
            }
            moveTurn = 0;
        }
        public bool GetDirection(out Direction direction)
        {
            List<Position> path;
            direction = Direction.UP;

            if (false == PathFinding(in DataClass.Instance.map,pos, DataClass.Instance.player.pos, out path))
            {
                return false;
            }
            if (path[1].x == pos.x) // 내 포지션의 x와 같다
            {
                if (path[1].y == pos.y -1)
                {
                    direction = Direction.UP;
                }
                else
                {
                    direction = Direction.DOWN;
                }
            }
            else
            {
                if (path[1].x == pos.x -1)
                {
                    direction = Direction.LEFT;
                }
                else
                {
                    direction = Direction.RIGHT;
                }
            }
            return true;
        }
        /***********************************************************
         * A* 알고리즘을 통해
         * 
         * 다익스트라 알고리즘을 확장하여 만든 최단경로 탐색 알고리즘
         * 경로 탐색의 우선순위를 두고 유망한 해부터 우선적으로 탐색
         * *********************************************************/
        const int Coststraight = 10;
        const int CostDiagonal = 14;

        static (int x, int y)[] direction =
        {
            (0,1),  // 상
            (0,-1), // 하
            (-1,0), // 좌
            (1,0)   // 우
        };

        public bool PathFinding(in bool[,] map, in Position start, in Position end, out List<Position> path)
        {
            int xSize = map.GetLength(0);
            int ySize = map.GetLength(1);

            //노드 구성
            AstarNode[,] nodes = new AstarNode[xSize, ySize];
            bool[,] visited = new bool[xSize, ySize];
            PriorityQueue<AstarNode, int> nextPotinPQ = new PriorityQueue<AstarNode, int>();

            AstarNode startNode = new AstarNode(start, null,0, Heuristic(start, end));
            nodes[startNode.point.y, startNode.point.x] = startNode;
            nextPotinPQ.Enqueue(startNode, startNode.f);

            while(nextPotinPQ.Count > 0)
            {
                // 다음으로 탐색할 정점 꺼내기.
                AstarNode nextnode = nextPotinPQ.Dequeue();
                // 방문한 정점 표시.
                visited[nextnode.point.y, nextnode.point.x] = true;
                // 탐색할 정점이 도착지인 경우
                if(nextnode.point.x == end.x && nextnode.point.y == end.y)
                {
                    Position? pathPoint = end;
                    path = new List<Position>();

                    while(pathPoint != null)
                    {
                        Position point = pathPoint.GetValueOrDefault();// 이게 nullable이 되기 때문에 Defualt를 사용
                        path.Add(point);
                        pathPoint = nodes[point.y, point.x].parent;
                    }

                    path.Reverse();
                    return true;
                }
                //탐색 진행
                // 방향 탐색

                for(int i = 0; i< direction.Length; i++)
                {
                    int x = nextnode.point.x + direction[i].x;
                    int y = nextnode.point.y + direction[i].y;
                    // 맵을 벗어났는지 확인
                    if(x < 0 || x >= xSize || y < 0 || y >= ySize)
                    {
                        continue;
                    }
                    //맵의 이동 불가 구역인지 확인
                    if (map[y,x] == false) // 맵의 map[y,x]가 갈수 없는곳이다
                    {
                        continue;
                    }
                    //이미 방문한 정점인지 확인
                    if (visited[y,x])
                    {
                        continue;
                    }
                    //탐색한 정점 생성
                    int g = nextnode.g + (nextnode.point.x == x || nextnode.point.y == y ?
                        Coststraight : CostDiagonal);// true면 straight false면 diagonal  // 일직선이란 뜻
                    int h = Heuristic(new Position(x, y), end);
                    AstarNode newNode = new AstarNode(new Position(x, y), nextnode.point, g, h);

                    //정점 갱신
                    if (nodes[y,x] == null ||
                        nodes[y,x].f > newNode.f)
                    {
                        nodes[y,x] = newNode;
                        nextPotinPQ.Enqueue(newNode, newNode.f);
                    }
                }
            }
            path = null;
            return false;
        }
        private class AstarNode
        {
            public Position point; // 현재의 정점
            public Position? parent;// 이 정점을 탐색한 정점: 없을수도 있으니 nullable ? 를 써준다
             // parent 가  없을수도 있는, nullable상태 일수도 있기때문에 ? 를 써준다.
            public int g; // 현재ㅔ까지의 값 (지금 까지 경로의 가중치)
            public int h; // 앞으로 예상되는 값 (목표까지 추정 경로 가중치)
            public int f; // f(x) = g(x) + h(x);

            public AstarNode(Position point, Position ? parent, int g, int h)
            {
                this.point = point;
                this.parent = parent;
                this.g = g;
                this.h = h;
                f = g + h;
            }
        }
        // 휴리스틱 (Heuristic) : 최상의 경로를 추정하는 순위값, 휴리스틱에 의해 경로탐색 효율이 결정됨
        private int Heuristic(Position start, Position end)
        {
            int xSize = Math.Abs(start.x - end.x); // 가로로 가야하는 거리
            int ySize = Math.Abs(start.y - end.y); //세로로 가야하는 거리
            //맨해튼 거리 계산법
            return Coststraight * (xSize + ySize);
            // 유클리드 거리 계산
            //return Coststraight * Math.Sqrt(Math.Pow(xSize, 2) + (ySize * ySize));// sqrt제곱근 // pow도 똑같이 제곱을 해주는 math 클래스의 함수
        }
    }
}
