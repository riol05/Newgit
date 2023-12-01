using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report
{
    internal class Player
    {
        private string name;
        private int hp;

        public int HP { get { return hp; } }

        public Player()
        {
            name = "플레이어";
            hp = 100;
        }

        public void Heal(int hp)
        {
            Console.WriteLine("{0} 만큼 치료합니다", hp);
            this.hp =+ hp;
                      
        }
    }

}
