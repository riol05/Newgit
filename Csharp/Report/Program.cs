using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace Report
{
    internal class Program
    {
      
        internal interface ILock
        {
            void Lock1();           
        }
        internal interface ILockOff
        {
            void Lockoff();
        }
        internal interface IEnter
        {
            void Enter(); void Exit();
        }
        internal interface IRide
        {
            void Ride(Player player); void Rideoff(Player player);
        }

        public class Object 
        {
            public int a = 0;
            public int b = 1;
            public void close()
            {
                Console.WriteLine("문을 닫습니다");
                if (a == 0)
                    Console.WriteLine("문이 이미 닫혀있습니다.");
                else
                {
                    a = 0;
                }
            }

            public virtual void open()
            {
                Console.WriteLine("문을 엽니다");
                if (a == 1)
                    Console.WriteLine("문이 이미 열려있습니다.");
                else
                {
                    a = 1;
                }
            }
            public virtual void Lock1()
            {
               
                Console.WriteLine("물체가 잠겨있습니다.");
                
            }
        }
        public class dungeon : Object, IEnter
        {
            public override void open()
            {
                base.open();
                
            }
            public void Enter()
            {
                Console.WriteLine("던전에 진입합니다.");
             if(a != 1)
                {
                    Console.WriteLine("문이 닫혀있어 들어갈수없습니다.");
                }
            }

            public void Exit()
            {
                Console.WriteLine("던전에서 탈출합니다.");
            }
        }
        public class chest : Object, ILock
        {
            Object b = new Object();
            public override void open()
            {
                if (b.b == 0)
                base.open();
                Console.WriteLine("상자에 있는 아이템을 획득했습니다");
            }
            public override void Lock1()
            {
                base.Lock1();
                Console.WriteLine("상자의 잠금을 해제해주세요. ");
            }

        }
        public class Door : Object, IEnter
        {
            public override void Lock1()
            {
                base.Lock1();
            }
            public override void open()
            {
                base.open();

            }
            public void Enter()
            {
                Console.WriteLine("건물안에 입장합니다.");
                if (a != 1)
                {
                    Console.WriteLine("문이 닫혀있어 들어갈수없습니다.");
                    
                }
                

            }

            public void Exit()
            {
                Console.WriteLine("건물밖으로 나갑니다.");
            }
        }
        public class Bike : IRide , ILock
        {
            Object b = new Object();
            
            public void Lock1()
            {
                Console.WriteLine("자전거가 잠겨있습니다.");
                b.b = 1;
            }

            public void Ride(Player player)
            {
                Console.WriteLine("플레이어가 자전거에 탑승합니다");
                if(b.b == 1)
                {
                    Console.WriteLine("자전거가 잠겨있어 앞으로 나아갈수 없습니다.");
                }
            }
            public void Rideoff(Player player)
            {

                Console.WriteLine("플레이어가 자전거에서 내립니다.");

            }
        }
        public class Player : ILockOff
        {
            Object b = new Object();
            public void Lockoff()
            {
                Console.WriteLine("플레이어가 잠금을 해제합니다");
                b.b = 0;
            }
        }

        static void Main(string[] args)
        {
            Player player = new Player();
            dungeon dungeon = new dungeon();
            Object objects = new Object();
            Bike bike = new Bike();
            int r;
            while (true)
            {
                Console.WriteLine("당신은 던전에 오셨습니다.");
                Console.WriteLine("던전에 입장하세요");
                Console.WriteLine("던전진입 1, 게임 종료 2");
                int f = Console.Read();
                if (f == 1)
                {
                    Console.WriteLine(dungeon.open);
                }
                else if(f == 2)
                {
                    break;
                }
                
                else
                {
                    Console.WriteLine("잘못 입력하셨습니다.");
                    continue;
                }
                Console.WriteLine("던전에 들어왔더니 문이 있습니다.");
                Console.WriteLine("어떻게 하시겠습니까?");
                Console.WriteLine("방을 들어간다");
                Console.WriteLine(dungeon.Enter);
            }
        }
    }
}