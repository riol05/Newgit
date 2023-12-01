using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Slime : Monster
    {
        // 매 업데이트 마다 랜덤 방향으로 이동.

        private Random random = new Random();
        private int moveTurn = 0;
        public Slime() // 생성자에서
        {
            icon = '슬';
            name = "슬라임";
            curHp = maxHp = 10;
            Damage = 2;
            rewardExp = 50;
            rewardgold = 10;
        }

        public override void Getreward()
        {
            Inventory invenList = Inventory.GetInstance();
            invenList.AddItem(new Sword());
        }

        public override void MoveAction()
        {
            moveTurn++;
            if (moveTurn < 3) // 3보다 작으면
            {
                return; // 안한다.
            }
            int randomNumber = random.Next(0, 4); // 0보다 크고 4보다 작음 

            Move((Direction)randomNumber); // 이렇게 하면 굳이 스위치문을 안써도 된다

            moveTurn = 0;            
        }
    }
}
