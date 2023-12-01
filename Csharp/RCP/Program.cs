using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace RCP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int player;
            Random ran = new Random();
            int comgvb = ran.Next(0, 2);

            int win = 0;
            int lose = 0;

            Console.WriteLine("가위 바위 보 게임");
            Console.WriteLine("컴퓨터와 가위 바위 보");
            Console.WriteLine("3판 2선승제 입니다.");
            Console.WriteLine();
            while (true)
            {
             if (win != 0 || lose != 0)
                {
                    Console.Clear();
                }
                if (win < 3 && lose < 3)
                {
                    Console.Write("플레이어 win");
                    Console.WriteLine(win);
                    Console.WriteLine();
                    Console.Write("컴퓨터 win");
                    Console.WriteLine(lose);
                    Console.WriteLine();
                    Console.WriteLine("가위 바위 보 중에 내고싶은것을 골라주세요");

                    
                    string command = Console.ReadLine();
                    switch (command)
                    {
                        case "가위": // 

                            Console.WriteLine("가위를 냈습니다.");
                            player = 1;
                            break;

                        case "바위":
                            Console.WriteLine("바위를 냈습니다.");
                            player = 2;
                            break;
                        case "보":
                            Console.WriteLine("보를 냈습니다.");
                            player = 0;
                            break;

                        default:
                            Console.WriteLine("잘못된 방식입니다.");

                            continue;
                    }
                    if (player == comgvb)
                    {
                        Console.WriteLine("무승부입니다.");
                        Console.WriteLine();
                        continue;
                    }
                    else if (player == 0)
                    {
                        if (comgvb == 2)
                        {
                            Console.WriteLine("플레이어 승!");
                            Console.WriteLine();
                            win++;
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("플레이어 패!");
                            Console.WriteLine();
                            lose++;
                            continue;
                        }
                    }
                    else if (player == 1)
                    {
                        if (comgvb > player)
                        {
                            Console.WriteLine("플레이어 패!");
                            Console.WriteLine();
                            lose++;
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("플레이어 승!");
                            Console.WriteLine();
                            win++;
                            continue;
                        }
                    }
                    else if (player == 2)
                    {
                        if (comgvb == 1)
                        { 
                            Console.WriteLine("플레이어 승!!");
                        Console.WriteLine();
                        win++;
                        continue;
                    }
                    else
                    {
                            Console.WriteLine("플레이어 패!!");
                            Console.WriteLine();
                            lose++;
                            continue;
                        }
                    }
                    

                }


                else if (win == 3)
                {
                    Console.WriteLine("플레이어의 승리입니다!");
                    break;
                }
                else if (lose == 3)
                {
                    Console.WriteLine("플레이어의 패배입니다.");
                    break;
                }

            }
        }
    }
}
        
    
