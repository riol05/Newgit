using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class invenscene : Scene
    {
        public invenscene(Game game) : base(game)
        {
        }

        public override void Render()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("인벤토리");
            sb.AppendLine("\t이름\t무게\t설명");

            for (int i = 0; i < DataClass.Instance.inventory.Count; i++)
            {
                sb.AppendLine($"{i}");
                sb.Append($"\t{DataClass.Instance.inventory[i].name}\t");
                sb.Append($"{DataClass.Instance.inventory[i].weight}\t");
                sb.Append($"{DataClass.Instance.inventory[i].Description}");
                sb.AppendLine();

            }
            Console.WriteLine(sb);
        }

        public override void Update()
        {
            Console.WriteLine("0.뒤로가기\t 1. 아이텝 사용 \t 2. 아이템 정렬");
            Console.Write("선택 : ");
            string input = Console.ReadLine();
            int command;
            if (false == int.TryParse(input, out command))
            {
                Console.WriteLine("잘못 입력하셨습니다.");
                return;
            }
            switch (command)
            {
                case 0:
                    game.Map();
                    break;
                case 1:
                    UseItem();
                    break;
                    case 2:
                        sortItem(); break;
                default:
                    Console.WriteLine("잘못 입력하셨습니다.");
                    break;
            }
        }
        private void UseItem()
        {
            Console.WriteLine("어떤 아이템을 사용하시겠습니까? : ");
            string input = Console.ReadLine();
            int command;
            if (false == int.TryParse(input, out command) ||
                command >= DataClass.Instance.inventory.Count) // 인벤토리 갯수보다 많으면 안됨
            {
                Console.WriteLine("잘못 입력하셨습니다.");
                return;
            }
            DataClass.Instance.inventory[command].Use();

            DataClass.Instance.inventory.RemoveAt(command);
        }
        private void sortItem()
        {
            Console.WriteLine("1. 이름순 정렬\t 2. 무게순 정렬");
            string input = Console.ReadLine();
            int command;
            if (false == int.TryParse(input, out command))
            {
                Console.WriteLine("잘못 입력하셨습니다.");
                return;
            }
            switch(command)
            {
                case 1:
                    // 이름순 정렬
                    DataClass.Instance.inventory.Sort(
                        Comparer<Item1>.Create((a, b)
                        => { return a.name.CompareTo(b.name); })); // sort 하고 싶은 내용을 넣어준다
                    break;
                case 2:
                    //무게순 정렬
                    DataClass.Instance.inventory.Sort(
                        Comparer<Item1>.Create((a, b)
                        =>
                        { return a.weight - b.weight; })); // 무게순 정렬 인트로 weight을 결정했다
                        
                    break;
                default:
                    Console.WriteLine("잘못 입력하셨습니다.");
                    Thread.Sleep(1000);
                    break;
            }
        }
    }
}
