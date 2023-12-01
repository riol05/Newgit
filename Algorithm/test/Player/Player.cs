using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Player
    {
        public char icon = 'P';

        public Position pos; // 플레이어의 위치
        // 플레이어 체력
        public int CurHp;
        public int MaxHp;
        public bool equipSword = false;

        //플레이어 총경험치
        public int exp;

        //경험치 단계별로 정리된 테이블이 있을때
        // 현재 경험치가 몇 레벨의 경험치에 해당하는지 검사하여 레벨을 결정.
        public int Level;
        public int Damage;
        // 방어력 구현하고 싶으면 하자
        public Player()
        {
            CurHp = 100; MaxHp = 150;
            exp = 0;
            Level = 1;
            Damage = 50;
        }
       
        public void Move(Direction dir) //파라미터로 뭘 받지? // enum으로 방향을 설정하고 이걸 넣자!@
        {
            Position prevpos = pos;
            Game game = new Game();
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
            if (false == DataClass.Instance.map[pos.y, pos.x]) // 플레이어의 위치가 false라면?
            {
                pos = prevpos;// 포지션은 원래 위치로
            }
        }
        public void gainExp(int exp)
        {
            Console.WriteLine($"{exp}의 경험치를 얻었습니다.");
            Thread.Sleep(1000);
            this.exp += exp;

            for(int i =0; i < DataClass.Instance.playerLeveltable.Length;i++)
            {
                if(this.exp < DataClass.Instance.playerLeveltable[i])
                {
                    Level = i + 1;
                    break; // 
                }
            }
            if(this.Level != Level)
            {
                //레벨업
                Console.WriteLine($"플레이어가 {Level}로 레벨업했습니다!");
                Thread.Sleep(1000);
                this.Level = Level;
                Console.WriteLine("");
            }
        }
        public int EquipSword(int damage)
        {
            
            if (equipSword == true)
            {
                Console.WriteLine("이미 아이템을 장착하고 있습니다.");
                return this.Damage;
            }
            else
            {
                equipSword = true;
                Damage = Damage + damage;
                Console.WriteLine($"무기를 장착하여 {damage} 만큼 공격력이 상승했습니다.");
            }
            return this.Damage;
        }
        public int heal(int heal)
        {
            if (CurHp == MaxHp)
            {
                Console.WriteLine("캐릭터의 HP 가 이미 꽉차있어 물약을 마시지 않습니다");
                return this.CurHp;
            }            
            else
            {
                Console.WriteLine($"캐릭터의 Hp가 {heal} 만큼 회복됩니다.");
                CurHp = heal + CurHp;
            }
            if (CurHp > MaxHp)
            {                
                CurHp = MaxHp;
            }
            Console.WriteLine($"캐릭터의 Hp가 {CurHp} 가 되었습니다.");
            return this.CurHp;
        }
        private void LevelUp()
        {
            // 레벨업시 프로세스 구현
        }
    }
}
