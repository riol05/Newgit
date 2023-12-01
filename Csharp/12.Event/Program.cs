using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _12._Event
{
    internal class Event
    {
        public class Player
        {
            
            public event Action Oncoinget; // event를 붙이면 외부에서 개입이 불가능하다. -= 나 +=만 가능하게됨
            //UI UI = new UI (); 플레이어 클래스에 이렇게 클래스를 대입하게 되면 델리게이트 이벤트로 구현하는거보다 훨씬 비효율적이게됨.  // 플레이어 클래스를 수정해야 하기 때문임
            public void Getcoin()
            {
                Console.WriteLine("플레이어가 동전을 얻습니다.");
                if(Oncoinget != null)
                {
                    Oncoinget();
                }
            }
        }
        public class UI
        {
            public void SetcoinUI()
            {
                Console.WriteLine("UI가 동전 갯수를 체크합니다.");
                    }

        }
        public class SFX
        {
            public void Coinsound()
            {
                Console.WriteLine("띠리링");
            }
        }
        public class VFX
        {
            public void Coineffect()
            {
                Console.WriteLine("코인 떳다");
            }
        }
        public class Monster
        {
            
            public event Action<int> Onchangehp;
        }
        public class HPbar
        {
            public void setHP()
            { }
        }

        static void Main(string[] args)
        {
            Player player = new Player();
            UI ui = new UI();
            SFX sfx = new SFX();
            VFX vfx = new VFX();
            player.Oncoinget += ui.SetcoinUI;// 코인 먹으면 반응하게 델리게이트를 짜놨다.
            player.Oncoinget += sfx.Coinsound;
            player.Oncoinget += vfx.Coineffect; 

            player.Getcoin(); // 코인만 먹어도 위에 3가지 함수가 모두 호출된다.
            player.Getcoin();
            player.Getcoin();
            player.Oncoinget -= sfx.Coinsound; // 코인 먹을때 띠리링 이 빠지게됨
            player.Getcoin();
           HPbar playerhp = new HPbar();
            HPbar Monsterhp = new HPbar();
            playerhp.Onchangehp; // 함수를 안해서 오류 뜬거 귀찮아서 안함 나중에 하던가
            Monsterhp.Onchangehp;
            //player.Oncoinget(); // event 키워드가 델리게이트 변수 앞에 있기 때문에 이벤트 용도로만 사용하게 된다. // 외부에서는 이 이벤트를 발생시킬수 없게 만들었다. 대입또한 불가능하게된다.
        }
       /* public class Monster
        {
            private string Name;
            private Player target;
            private int AttackPoint;
            public Monster(string Name)
            {
                this.Name = Name;
                AttackPoint = 10;
            }
           
      
            public void SetTarget(Player player)
            {
                target = player;
                target.Ondied -= OnPlayerdied;
                target.Ondied += OnPlayerdied;
            }
            private void OnPlayerdied()
            {
                Console.WriteLine(Name);
                Console.WriteLine("플레이어가 죽은 사실을 확인했습니다.");
                    target = null;
            }
            public void Attack()
            {
                if(target != null)
                {
                    Console.WriteLine(Name);
                    Console.WriteLine("가 공격합니다");
                    target.TakeHit(AttackPoint);
                }
                else
                {
                    Console.WriteLine(Name);
                    Console.WriteLine("는 공격할 대상이 없습니다");
                }
            }

        }

        public class Player
        {
            private int hp;
            public Action Ondied; //델리게이트 만듬
            public Player()
            {
                hp = 35;
            }
                
        public void set Hp()
       {
        Console.WriteLine ("플레이어의 체력은 {0} 입니다. ,hp"); //{0} 은 hp가 대입된다.
       }
            public void TakeHit(int damage)
            {
                Console.WriteLine("공격받는다");
                hp -= damage;
                
                if(hp< 0)
                {
                    hp = 0;
                    Die();
                }
                else
                {
                    Console.WriteLine("플레이어의 체력은");
                    Console.WriteLine(hp);

                }
            }
            public void Die() 
            {
                Console.WriteLine("플레이어가 쓰러집니다.");
                    if (Ondied != null)
                {
                    Ondied();
                }
                    }

        }
        static void Main(string[] args)
        {
            Player player = new Player();
            Monster[] monsters = new Monster[3];
            monsters[0] = new Monster("드래곤");
            monsters[1] = new Monster("슬라임");
            monsters[2] = new Monster("오크");
            

            for (int i = 0; i< monsters.Length; i++)
            {
                monsters[i].SetTarget(player);
            }
            for (int i = 0; i < monsters.Length; i++)
            {
                monsters[i].SetTarget(player);
            }
            for (int i = 0; i < monsters.Length; i++)
            {
                monsters[i].SetTarget(player);
            }

        }*/
        /****************************************************************
		 * 이벤트 (Event)
		 * 
		 * 이벤트 : 일련을 사건이 발생했다는 사실을 다른 개체에게 전달
		 * 델리게이트의 일부 기능을 제한하여 이벤트의 용도로 사용
		 ****************************************************************/

        public class EventBroadCaster
        {
            // 이벤트
            public delegate void EventDelegate(string message);
            public event EventDelegate OnEvent;     // 이벤트 변수 : 델리게이트 변수앞에 event 키워드 추가

            public void Progress(string message)
            {
                if (OnEvent != null)
                {
                    OnEvent(message);               // 이벤트 발생
                }
            }
        }

        public class EventListener
        {
            public string name;

            public EventListener(string name)
            {
                this.name = name;
            }

            public void ReceiveMessage(string message)
            {
                Console.WriteLine("{0}이 {1} 이벤트를 받음", name, message);
            }
        }

        internal class EventClass
        {
            public static void Test()
            {
                EventBroadCaster broadCaster = new EventBroadCaster();

                EventListener listener1 = new EventListener("리스너1");
                EventListener listener2 = new EventListener("리스너2");

                // <이벤트 제약사항 1 : = 을 통한 할당 불가>
                // 이벤트는 += 과 -= 을 통해 추가 할당과 할당 제거만이 가능
                // Why? = 을 통한 할당의 경우 이전 함수들의 할당이 사라짐
                // 객체가 이벤트에 반응할 것을 기대하고 추가하였지만 반응하지 않는 것을 방지
                broadCaster.OnEvent += listener1.ReceiveMessage;
                broadCaster.OnEvent += listener2.ReceiveMessage;
                broadCaster.OnEvent -= listener2.ReceiveMessage;
                // broadCaster.OnEvent = listener2.ReceiveMessage;	// error : = 을 통한 할당 불가

                // <이벤트 제약사항 2 : 외부에서 이벤트 발생 불가>
                // 이벤트는 이벤트가 포함된 클래스 내에서만 발생 가능
                // Why? 일련을 사건이 발생했다는 사실을 다른 개체에게 전달 용도로 사용하기 위해
                // 외부에서 이벤트를 발생시킨다면 개체가 사건이 발생하지 않은 경우에도 호출할 수 있음
                broadCaster.Progress("메세지");
                // broadCaster.OnEvent("메세지");					// error : 외부에서 이벤트 발생 불가
            }
        }
    }
}