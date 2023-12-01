using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report
{
    internal class _11
    {
        public interface IAttack
        {
            public void getattack();
            public void gethit();
        }


        public interface Ihit
        {
            public void getattack();
            public void gethit();
        }
        public class Player : IAttack
        {
            public int AP = 30;
            public void getattack(Ihit ihit)
            {
                Console.WriteLine("플레이어가 몬스터를 공격합니다.");
                ihit.gethit();
            }

            public void gethit(Ihit ihit)
            {
                Console.WriteLine("플레이어가 몬스터에게 공격당합니다.");
                ihit.getattack();


            }

            public void Sethpp(int hp)
            {
                Console.WriteLine(":  플레이어의 체력량");
            }
        }
        public class Monster : Ihit
        {

            public int AP = 20;
            public void getattack(IAttack attack)
            {
                Console.WriteLine("몬스터가 플레이어를 공격합니다.");
                attack.gethit();

            }

            public void gethit(IAttack attack)
            {
                Console.WriteLine("몬스터가 플레이어를 공격합니다.");
                attack.getattack();
            }

            public void Sethpm()
            {
                Console.WriteLine(":  몬스터의 체력량 ");
            }
        }

        public class Hpbar
        {
            public event Action<int> Onchangehp;
            public int hp = 100;


            public void Sethp(int hp)
            {

                Console.WriteLine("현재 체력량을 나타냅니다.");
                Console.Write(hp);
                if (Onchangehp != null)
                {
                    Onchangehp(hp);
                }
            }
        }
        static void Main(string[] args)
        {
            Player player = new Player();
            Monster monster = new Monster();
            Hpbar phbar = new Hpbar();
            Hpbar mhbar = new Hpbar();
            phbar.Onchangehp += player.Sethpp;
            mhbar.Onchangehp += monster.Sethpm;
            phbar.Sethp(phbar.hp);
            mhbar.Sethp(mhbar.hp);


        }
    }

}


