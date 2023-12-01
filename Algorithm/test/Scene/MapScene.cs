using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class MapScene : Scene
    {
        
        public MapScene(Game game) : base(game)
        {
        }
        public override void Render()
        {
            PrintMap();
            // 체력과 레벨 상태창을 볼수있게 해자
            PrintInfo();
        }

        public override void Update()
        {

            // 입력
            ConsoleKeyInfo input = Console.ReadKey();
            switch (input.Key) // 플레이어를 이동
            {
                case ConsoleKey.UpArrow:
                    DataClass.Instance.player.Move(Direction.UP);
                    break;
                case ConsoleKey.DownArrow:
                    DataClass.Instance.player.Move(Direction.DOWN);
                    break;
                case ConsoleKey.LeftArrow:
                    DataClass.Instance.player.Move(Direction.LEFT);
                    break;
                case ConsoleKey.RightArrow:
                    DataClass.Instance.player.Move(Direction.RIGHT);
                    break;
                case ConsoleKey.I:
                    game.InvenOpen();

                    break;
            }
            // 몬스터 이동
            foreach (Monster monster1 in DataClass.Instance.monsters)
            {
                monster1.MoveAction();
            }
            //몬스터가 플레이어랑 만나면 전투씬 호출
            Monster monster = DataClass.Instance.GetMonsterInPosition(DataClass.Instance.player.pos);
            if (monster != null)
            {
                // 플레이어 위치에 몬스터가 있으므로 전투 시작!
                game.BattleStart(monster);

            }
            Shop shop = DataClass.Instance.ShopInPosition(DataClass.Instance.player.pos);
            if (shop != null)
            {
                // 플레이어 위치에 몬스터가 있으므로 전투 시작!
                game.EntertheShop(shop);

            }
        }

        public void GenerateMap()
        {
            DataClass.Instance.LoadLevel();
        }

        private void PrintMap()
        {
            StringBuilder sb = new StringBuilder();
            for (int y = 0; y < DataClass.Instance.map.GetLength(0); y++)
            {
                for (int x = 0; x < DataClass.Instance.map.GetLength(1); x++)
                {
                    if (DataClass.Instance.map[y, x])
                    {
                        // true면 땅 그리기
                        sb.Append(' ');
                    }
                    else
                    {
                        // false면 벽 그리기
                        sb.Append('X');
                    }
                }
                sb.AppendLine(); //줄 그어준다
            }
            Console.ForegroundColor = ConsoleColor.White; // 지도는 하얀색
            Console.Write(sb.ToString());// 지도 그려주기

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(DataClass.Instance.shop.pos.x, DataClass.Instance.shop.pos.y);
            Console.Write(DataClass.Instance.shop.icon);
            Console.ForegroundColor = ConsoleColor.Green; // 몬스터는 초록색
            foreach (Monster monster in DataClass.Instance.monsters) // 몬스터 그려주기
            {
                Console.SetCursorPosition(monster.pos.x, monster.pos.y);
                Console.Write(monster.icon);
            }
            Console.ForegroundColor = ConsoleColor.Red; // 곧 그려줄 플레이어는 빨강색
            Console.SetCursorPosition(DataClass.Instance.player.pos.x, DataClass.Instance.player.pos.y); // 플레이어의 위치를 찾아서
            Console.Write(DataClass.Instance.player.icon);// 플레이어를 렌더링한다.

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void PrintInfo()
        {
            Inventory invenList = Inventory.GetInstance();

            Console.SetCursorPosition(DataClass.Instance.map.GetLength(1), 0);
            Console.Write($"  Lv.{DataClass.Instance.player.Level}");
            Console.SetCursorPosition(DataClass.Instance.map.GetLength(1), 1);
            Console.Write($"  Hp  :{DataClass.Instance.player.CurHp} / {DataClass.Instance.player.MaxHp}");
            Console.SetCursorPosition(DataClass.Instance.map.GetLength(1), 2);
            // 현재 레벨의 경험치 출력
            Console.Write($"  exp : {DataClass.Instance.player.exp}");
            Console.SetCursorPosition(DataClass.Instance.map.GetLength(1), 3);
            Console.Write($"  gold : {invenList.gold}G");
            Console.SetCursorPosition(DataClass.Instance.map.GetLength(1), 4);
            Console.Write($"  ATK  : {DataClass.Instance.player.Damage}");
            Console.SetCursorPosition(DataClass.Instance.map.GetLength(1), 5);
            Console.Write($"  i. 인벤토리 열기");

        }
    }
}
