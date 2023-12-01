using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Goblin : Monster
    {
        private Random random = new Random();
        private int moveTurn = 0;
        public Goblin() 
        {
            icon = '고';
            name = "고블린";
            curHp = maxHp = 40;
            Damage = 6;
            rewardExp = 100;
            rewardgold = 20;            

        }

        public override void Getreward()
        {
            Inventory invenList = Inventory.GetInstance();
            invenList.AddItem(new Potion());
        }

        public override void MoveAction()
        {
            moveTurn++;
            if (moveTurn < 2) // 3보다 작으면
            {
                return; // 안한다.
            }
            int randomNumber = random.Next(0, 5); // 0보다 크고 4보다 작음 

            Move((Direction)randomNumber); // 이렇게 하면 굳이 스위치문을 안써도 된다

            moveTurn = 0;
        }
    }
}
