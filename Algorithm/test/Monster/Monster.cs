using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public abstract class Monster
    {
        public char icon;
        public Position pos;
        public string name;
        //체력
        public int curHp;
        public int maxHp;
        public int Damage;
        public int rewardExp;
        public int rewardgold;
        
        

        // 방어력 구현 하고싶음 해
        //public float defence;
        public abstract void MoveAction();

        public abstract void Getreward();
        protected void Move(Direction dir)
        {
            Position prevpos = pos;
            
            switch (dir)
            {
                case Direction.LEFT:
                    pos.x--;
                    break;
                case Direction.RIGHT:
                    pos.x++;
                    break;
                case Direction.UP:
                    pos.y--;
                    break;
                case Direction.DOWN:
                    pos.y++;
                    break;
            }
            if (DataClass.Instance.map[pos.y, pos.x] == false) // 플레이어의 위치가 false라면?
            {
                pos = prevpos;// 포지션은 원래 위치로
            }

        }
    }
}
