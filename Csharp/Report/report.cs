using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report
{
    internal class report
    {
        public interface Iopen
        {
            void open();
            void close();
        }
        public interface IEnter
        {
            void enter();
            void Exit();
        }
        public interface ILock
        {
            void Unlock();
        }
        public class Player 
        {
            public void Enter(IEnter enter) // 인터페이스를 넣어주면 해당 인터페이스에 대해 상호작용
            {
                enter Enter();
            }
            public void Exit(IEnter exit)
            {
                exit Exit();
            }
            public void Unlock(ILock ock)
            {
                ock Unlock(); 
            }
            public class Door : IEnter, Iopen
            {
                public void open()
                {
                    Console.WriteLine("문을 엽니다.");
                }
                public void close()
                {
                    Console.WriteLine("문을 닫습니다.");
                }
                public void enter()
                {
                    Console.WriteLine("문을 들어옵니다.");
                }
                public void exit() { Console.WriteLine("문을 나갑니다."); }
            }
            public class Dungeon : IEnter
            {
                public void Enter()
                {
                    Console.WriteLine("던전에 들어옵니다.");
                }
                public void Exit()
                {
                    Console.WriteLine("던전을 나갑니다.");
                }
            }
            public class Box : Iopen
            {
                public void open()
                {
                    Console.WriteLine("박스를 엽니다.");
                }
                public void close()
                {
                    Console.WriteLine("박스를 닫습니다.");
                }
            }
            public class Bike : IEnter
            {
                public void Enter()
                {
                    Console.WriteLine("자전거를 탑니다.");
                }
                public void Exit()
                {
                    Console.WriteLine("자전거에서 내립니다.");
                }

                
        static void Main(string[] args)
        {
                Player player = new Player();
                Door door = new Door();
                Dungeon dungeon = new Dungeon();
                Box box = new Box();
                Bike bike = new Bike();

                player.Enter(door);
                player.Exit(door);
                
                player.Enter(dungeon);
                player.Exit(dungeon);

                player.Enter(bike);
                player.Exit(bike);


        }
    }
}
