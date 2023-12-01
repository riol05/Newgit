using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project_S
{
    enum Move { Up, Down, Left, Right, None}
    
    internal class Sokoban
    {
        private bool Gameover = false;
        private Move input;
        private int CurX= 1;
        private int CurY= 1;
        
        char[,] map =
            {
            {'#','#','#','#','#','#','#','#'},
            {'#',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ','B',' ',' ','#'},
            {'#',' ',' ',' ','G',' ',' ','#'},
            {'#',' ',' ','B',' ',' ','G','#'},
            {'#',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ','#'},
            {'#','#','#','#','#','#','#','#'},
        };

        public void Run()
        {
            Init();
            while (!Gameover)
            {
                Input();
                update();
                Render();
            }
            Release();
        }
        private void Init()
        {
            Console.Title =("Sokoban - 1");
            Console.CursorVisible = false;
            Render();
        }
        private void Release()
        {
            Console.Clear();
            Console.WriteLine("게임 클리어! 게임이 종료됩니다.");
            Thread.Sleep(1000);
            Console.WriteLine("다음에 또봐요~");
            Thread.Sleep(1000);
        }
        private void Input()
        {
            ConsoleKeyInfo info = Console.ReadKey();
            ConsoleKey key = info.Key;
            switch(key)
            {
                case ConsoleKey.UpArrow:
                    {
                        input = Move.Up;
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        input = Move.Down;
                        break;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        input = Move.Left;
                        break;
                    }
                case ConsoleKey.RightArrow:
                    {
                        input = Move.Right;
                        break;
                    }
                case ConsoleKey.Spacebar:
                    {
                        input = Move.None;
                        break;
                    }
            }
        }
        private void update()
        {
            int prevX = CurX;
            int prevY = CurY;

            switch (input)
            {
                case Move.Up:
                    {
                        CurX--;
                        break;
                    }
                case Move.Down:
                    {
                        CurX++;
                        break;
                    }
                case Move.Left:
                    {
                        CurY--;
                        break;
                    }
                case Move.Right:
                    {
                        CurY++;
                        break;
                    }
                case Move.None:
                    {
                        Console.WriteLine("게임을 종료합니다");
                        Gameover = true;
                        break;
                    }
            }
            if (map[CurX, CurY] == '#')
            {
                CurX = prevX;
                CurY = prevY;
            }
            else if (map[CurX, CurY] == 'B')
            {
                int nextX = 0;
                int nextY = 0;

                switch (input)
                {
                    case Move.Up:
                        {
                            nextX = CurX - 1;
                            nextY = CurY;
                            break;
                        }
                    case Move.Down:
                        {
                            nextX = CurX + 1;
                            nextY = CurY;
                            break;
                        }
                    case Move.Left:
                        {
                            nextX = CurX;
                            nextY = CurY - 1;
                            break;
                        }
                    case Move.Right:
                        {
                            nextX = CurX;
                            nextY = CurY + 1;
                            break;
                        }

                }
                if (map[nextX, nextY] == ' ')
                {
                    map[CurX, CurY] = ' ';
                    map[nextX, nextY] = 'B';
                }
                else if (map[nextX, nextY] == 'G')
                {
                    map[CurX, CurY] = ' ';
                    map[nextX, nextY] = '*';
                }
                else if (map[nextX, nextY] == 'G')
                {
                    map[CurX, CurY] = 'G';
                    map[nextX, nextY] = '*';
                }
                else
                {
                    CurX = prevX;
                    CurY = prevY;
                }
                
            }
            else if (map[CurX, CurY] == '*')
            {
                int nextX = 0;
                int nextY = 0;

                switch (input)
                {
                    case Move.Up:
                        {
                            nextX = CurX - 1;
                            nextY = CurY;
                            break;
                        }
                    case Move.Down:
                        {
                            nextX = CurX + 1;
                            nextY = CurY;
                            break;
                        }
                    case Move.Left:
                        {
                            nextX = CurX;
                            nextY = CurY - 1;
                            break;
                        }
                    case Move.Right:
                        {
                            nextX = CurX;
                            nextY = CurY + 1;
                            break;
                        }

                }
                if (map[nextX, nextY] == ' ')
                {
                    map[CurX, CurY] = 'G';
                    map[nextX, nextY] = 'B';
                }
                else if (map[nextX, nextY] == 'G')
                {
                    map[CurX, CurY] = 'G';
                    map[nextX, nextY] = '*';
                }
                else
                {
                    CurX = prevX;
                    CurY = prevY;
                }
                int goal = 0;
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    for (int x = 0; x < map.GetLength(1); x++)
                    {
                        if (map[y, x] == 'G')
                        {
                            goal++;
                        }
                    }
                }
                if (goal == 0) // goal 포인트를 세주는 조건문이 밖에 있어야 정상적으로 게임오버가 가능하다. 
                {
                    Gameover = true;
                }
            }
        } 
        private void Render()
        {
            Console.Clear();
            for(int y = 0; y < map.GetLength(0); y++)
            {
                for(int x = 0; x < map.GetLength(1); x++)
                {
                    Console.Write(map[y, x]);
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition( CurY, CurX);
            Console.Write('P');


        }

    }
}
