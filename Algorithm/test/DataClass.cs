using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class DataClass
    {
        private static DataClass instance;// 싱글톤 구현
        
        public static DataClass Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataClass();
                }
                return instance;
            }
        } // set을 쓸필요가 없음
        private DataClass()
        {

        }
        public bool[,] map; // 갈수 있는 타일과 없는 타일만 설정 할거기 때문에 bool 형식으로 맵을 만든다
        public bool[,] invenmap;
        public Player player;// 플레이어를 맵에 호출하기 위해
        public Shop shop;
        public List<Monster> monsters;

        public int[] playerLeveltable;        

        // 아이템
        
        // 인벤토리
        
        public void Init()
        {
            player = new Player();
            monsters = new List<Monster>();
            shop = new Shop();
            playerLeveltable = new int[10]
            {100,200,300,400,500,600,700,800,900,1000};
        }

        public void LoadLevel()
        {
            player.pos = new Position(1, 1);
            shop.pos = new Position(1, 8);            
            Slime slime = new Slime();
            slime.pos = new Position(7, 6);
            monsters.Add(slime);

            Ork ork = new Ork();
            ork.pos = new Position(7, 9);
            monsters.Add(ork);            
            Goblin gob = new Goblin();
            gob.pos = new Position(9, 9);
            monsters.Add(gob);
            map = new bool[,] // [y.x] 배열에선 y가 앞에 가게된다.
            {
                { false, false, false, false, false, false, false, false,false,false,false,false, false},
                { false,  true,  true,  true,  true,  true,  true,  true, true, true, true, true, false},
                { false, false, false, false, false,  true, false, false,false, true, true, true, false},
                { false,  true, false,  true,  true,  true,  true,  true, true, true, true, true, false},
                { false,  true,  true,  true,  true,  true,  true,  true, true, true, true, true, false},
                { false,  true,  true,  true,  true,  true,  true,  true, true, true, true, true, false},
                { false, false,  true,  true, false,  true,  true,  true, true, true, true, true, false},
                { false, false,  true,  true, false,  true,  true,  true, true, true, true, true, false},
                { false,  true,  true,  true, false,  true,  true,  true, true, true, true, true, false},
                { false,  true,  true,  true, false, false,  true,  true, true, true, true, true, false},
                { false,  true,  true,  true,  true,  true,  true,  true, true, true, true, true, false},
                { false,  true,  true,  true,  true,  true,  true,  true, true, true, true, true, false},
                { false,  true,  true,  true,  true,  true,  true,  true, true, true, true, true, false},
                { false,  true,  true,  true,  true,  true,  true,  true, true, true, true, true, false},
                { false,  true,  true,  true,  true,  true,  true,  true, true, true, true, true, false},
                { false,  true,  true,  true,  true,  true,  true,  true, true, true, true, true, false},
                { false, false, false, false, false, false, false, false,false,false,false,false, false},
            };
        }

        //public void Inventory()
        //{
        //    player.pos = new Position(8, 8);
        //    invenmap = new bool[,] // [y.x] 배열에선 y가 앞에 가게된다.
        //    {
        //        { false, false, false, false, false, false, false, false, false, false},
        //        { false,  true,  true,  true,  true,  true,  true,  true,  true, false},
        //        { false,  true,  true,  true,  true,  true,  true,  true,  true, false},
        //        { false,  true,  true,  true,  true,  true,  true,  true,  true, false},
        //        { false,  true,  true,  true,  true,  true,  true,  true,  true, false},
        //        { false,  true,  true,  true,  true,  true,  true,  true,  true, false},
        //        { false,  true,  true,  true,  true,  true,  true,  true,  true, false},
        //        { false,  true,  true,  true,  true,  true,  true,  true,  true, false},
        //        { false,  true,  true,  true,  true,  true,  true,  true,  true, false},               
        //        { false, false, false, false, false, false, false, false, false, false},
        //    };
        //}
        public Monster GetMonsterInPosition(Position pos) // 이 위치의 몬스터가 누구냐!!
        {
            foreach (Monster monster in monsters)
            {
                if (pos.x == monster.pos.x && pos.y == monster.pos.y)
                {
                    return monster;
                }
            }
            return null;
        }
    }
    
}
