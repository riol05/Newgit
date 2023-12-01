using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_S
{
    enum MoveDir { Up, Down, Left, Right, None } // 디폴트로 None를 받기 위해서
    internal class Game
    {
        private bool GameOver = false;
        // private bool running = true; // 런닝으로 게임오버를 하는 경우도 있다.
        private int playerPosx = 1;
        private int playerPosy = 1;

        private MoveDir input; // 입력을 받기 위해서

        char[,] startMap =
        // 그 위치에 돌이면 돌 벽이면 벽이다 라고 표현하기 위해 bool 보단 char를 쓴다
        {
            {'▦','▦','▦','▦','▦','▦','▦' },
            {'▦', ' ', ' ', ' ','▦','▦','▦' },
            {'▦', ' ','▦', ' ','▦','▦','▦' },
            {'▦', ' ','▦', ' ', ' ', ' ','▦' },
            {'▦', ' ','▦', 'B', ' ', ' ','▦' },
            {'▦', ' ','▦', ' ', ' ', 'B','▦' },
            {'▦', ' ', ' ', ' ', 'G', 'G','▦' },
            {'▦','▦','▦','▦','▦','▦','▦' },
        };
        public void Run() // 게임 루프
        {
            Init(); // 게임이 시작할때 초기화 작업 .Init

            while (!GameOver)
            {
                Input(); // 입력하고
                Update(); // 컴퓨터가 받아주고
                Render(); // 출력하는 루프가 완성이 된다.
            }
            Release(); // 게임이 게임오버 됐을때 마무리 작업 Release 이로써 게임의 5단 구성이 끝났다
        }

        private void Init()
        {
            Console.Title = ("Project-S"); // 타이틀이 바뀌었다.
            Console.CursorVisible = false; // 커서가 깜빡 거리는게 안보이게 하기위해
            // Cursorvisible 을 사용한다.
            Render(); // 게임 시작전에 한번 그려주고 시작한다.
        }
        private void Release()
        {
            Console.Clear();
            Console.WriteLine("게임 클리어! 게임이 곧 종료됩니다.");
        }
        private void Input()
        {
            ConsoleKeyInfo info = Console.ReadKey();
            ConsoleKey key = info.Key;
            switch (key)
            {
                case ConsoleKey.UpArrow: // 콘솔키로 입력을 받아냄
                    {
                        input = MoveDir.Up; // 설정해둔 input
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        input = MoveDir.Down;
                        break;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        input = MoveDir.Left; break;
                    }
                case ConsoleKey.RightArrow:
                    {
                        input = MoveDir.Right; break;
                    }
                default:
                    {
                        input = MoveDir.None;
                        break;
                    }
            }
        }
        private void Update() // 플레이어 이동 구현
        {
            int prevPosX = playerPosx;
            int prevPosY = playerPosy;
            switch (input)
            {
                case MoveDir.Up:
                    {
                        playerPosy--; // 세팅을 하지않으면 위 아래 방향이 데카르트 좌표계와 윈도우 좌표계가 아예 반대다.
                        break;         // 따라서 UP를 하면 playerPosy 를 --로 해줘야함.
                    }
                case MoveDir.Down:// 따라서 Down 일때 playerPosx 는 ++
                    {
                        playerPosx++;
                        break;
                    }
                case MoveDir.Left:
                    {
                        playerPosx--;
                        break; ;
                    }
                case MoveDir.Right:
                    {
                        playerPosx++;
                        break;
                    }
            }
            // 이동한 자리가 벽일경우
            if (startMap[playerPosy, playerPosx] == '▦')
            {
                // 원위치 시킨다.
                playerPosy = prevPosY;
                playerPosx = prevPosX;
            }
            else if (startMap[playerPosy, playerPosx] == 'B')
            {
                int nextPosX = 0;
                int nextPosY = 0; // 갈 방향의 위치 확인
                switch (input)
                {
                case MoveDir.Up:
                    {
                        nextPosX = playerPosx;
                        nextPosY = playerPosy - 1;
                        break;
                    }
                case MoveDir.Down:
                    {
                        nextPosX = playerPosx;
                        nextPosY = playerPosy + 1;
                        break;
                    }
                case MoveDir.Left:
                    {
                        nextPosX = playerPosx - 1;
                        nextPosY = playerPosy;
                        break;
                    }
                case MoveDir.Right:
                    {
                        nextPosX = playerPosx + 1;
                        nextPosY = playerPosy;
                        break;
                    }
                }
                if (startMap[nextPosX, nextPosY] == ' ')
                {
                    //박스가 밀린다
                    startMap[playerPosy, playerPosx] = ' ';
                    startMap[nextPosY, nextPosX] = 'B';
                }
                else if (startMap[nextPosX, nextPosY] == 'G')
                {
                    // 박스가 밀린다.
                    startMap[playerPosy, playerPosx] = ' ';
                    startMap[nextPosY, nextPosX] = '*';
                }
                else if (startMap[nextPosX, nextPosY] == 'G')
                {
                    // 박스가 밀린다.
                    startMap[playerPosy, playerPosx] = 'G';
                    startMap[nextPosY, nextPosX] = '*';
                }
                
                // 벽이나 박스일때
                else
                {
                    //박스가 안밀리고 플레이어를 밀어낸다.
                    playerPosx = prevPosX;
                    playerPosy = prevPosY;
                }

            }

            // 플레이어가 이동한 자리가 골위에 박스가 올라가 있을 경우
            
            // 이동을 마친후 승리 조건을 달성
            int goalCount = 0;
            for (int y = 0; y < startMap.GetLength(0); y++)
            {
                for (int x = 0; x < startMap.GetLength(1); x++)
                {
                    if (startMap[y, x] == 'G')
                    { goalCount++; }
                }
            }
            if (goalCount == 0)
            {
                GameOver = true;
            }
        }
            private void Render()
            {
                Console.Clear(); // 콘솔로 쫙 지워주고 그려주기 위해
                for (int y = 0; y < startMap.GetLength(0); y++)
                {
                    for (int x = 0; x < startMap.GetLength(1); x++)
                    {
                        Console.Write(startMap[y, x]);//한줄 씩 그려준다                    
                    }
                    Console.WriteLine(); // 한줄씩 끝날때마다 writeLine 해준다.
                }
                Console.SetCursorPosition(playerPosx, playerPosy); // 커서의 위치를 바꿔준다
                Console.Write('P');// 플레이어는 P로 렌더링
            }
        }
   }


