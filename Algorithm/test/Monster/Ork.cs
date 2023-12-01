using System;
using System.Collections.Generic;
using System.Linq;
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
            curHp = maxHp = 20;
            Damage = 4;
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
            if (moveTurn < 2) // 3보다 작으면
            {
                return; // 안한다.
            }
            int randomNumber = random.Next(0, 4); // 0보다 크고 4보다 작음 

            Move((Direction)randomNumber); // 이렇게 하면 굳이 스위치문을 안써도 된다

            moveTurn = 0;
        }
    }
}
