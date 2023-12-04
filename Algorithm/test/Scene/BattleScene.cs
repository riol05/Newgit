using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class BattleScene : Scene
    {
        private Monster monster;
        private Player player;
        
        
        Inventory invenList = Inventory.GetInstance();
        public BattleScene(Game game) : base(game)
        {
        }

        public override void Render()
        {
            // 적 정보 ( 체력 )
            Console.WriteLine($"{monster.name}    HP : {monster.curHp} / {monster.maxHp}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            // 적 이미지
            // 내 정보 ( 체력, 공격력 , 레벨 )
            Console.WriteLine($"플레이어 체력 :       {DataClass.Instance.player.CurHp} / {DataClass.Instance.player.MaxHp}");
            Console.WriteLine();
            // 내 이미지
        }

        public override void Update()
        {
            Console.WriteLine("  1. 공격 ");
            Console.WriteLine("  2. 방어 ");
            Console.WriteLine("  3. 인벤토리 ");
            Console.WriteLine("  4. 도망 ");
            Console.Write(" 명령을 입력 하세요 : ");
            string input = Console.ReadLine();

            int command;

            if (false == int.TryParse(input, out command))//
            {
                Console.WriteLine("잘못 입력 하였습니다.");
                return;
            }
            bool isDefence = false;

            switch (command)// 커맨드가 입력이 되었으니 
            {
                case 1:
                    //공격
                    // 플레이어가 몬스터에게 행동!
                    Console.WriteLine($"플레이어가 {monster.name} 을/를 공격!");
                    Thread.Sleep(1000);
                    Console.WriteLine($"{monster.name}에게 {player.Damage} 만큼 데미지를 입혔습니다!");
                    Thread.Sleep(1000);
                    
                    monster.curHp -= player.Damage; // 몬스터의 현재 체력에 플레이어의 데미지 만큼 뺀다!
                    break;
                case 2:
                    //방어
                    Console.WriteLine("플레이어가 방어 자세!");
                    Thread.Sleep(1000);
                    isDefence = true;
                    break;
                case 3:
                    Console.WriteLine("플레이어의 인벤토리를 열어서 확인합니다.");
                    Thread.Sleep(1000);
                    game.InvenOpen();
                    break;
                case 4:
                    Console.WriteLine("플레이어가 도망갑니다!");
                    Thread.Sleep(1000);
                    game.OpenPrev();
                    break;
                default:
                    Console.WriteLine("잘못 입력하였습니다.");
                    break;
            }

            // 플레이어의 행동후 몬스터 행동 하기전에 몬스터 상태 판단.
            if (monster.curHp <= 0)
            {
                Console.WriteLine("몬스터가 쓰러졌다!");
                Thread.Sleep(1000);
                EndBattle();
                return;
            }

            // 몬스터가 죽지 않았으면 몬스터 행동
            if (false == isDefence) //!isDefence로도 가능 //업계에선 true 와 false를 먼저 쓰게된다.
            {
                Console.WriteLine($"{monster.name}이 플레이어에게 공격을 합니다!");
                Thread.Sleep(1000);
                player.CurHp -= monster.Damage;
                Console.WriteLine($"{monster.name}가 플레이어에게 {monster.Damage}만큼 피해를 입힙니다!!");
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine($"플레이어가 {monster.name}의 공격을 방어 하였습니다!");
                Thread.Sleep(1000);
            }
            if (player.CurHp <= 0)
            { //게임 오버
                game.GameOver();
                Thread.Sleep(1000);
                return;
            }

        }

        public void StartBattle(Monster monster)
        {
            Console.Clear();
            this.monster = monster;
            player = DataClass.Instance.player;

            Console.WriteLine($"{monster.name} 과/와 의 전투 시작!");
            Thread.Sleep(1000);

        }
        public void EndBattle()
        {
            Console.Clear();
            DataClass.Instance.monsters.Remove(monster); //몬스터를 없애준다

            Console.WriteLine($"{monster.name}과 의 전투에서 승리!");

            Thread.Sleep(1000);
            player.gainExp(monster.rewardExp); //컨트롤 R 두번 하면 참조한 모든게 바껴짐
            invenList.AddGold(monster.rewardgold);
            monster.Getreward();
            Thread.Sleep(1000);
            game.Map();
        }
    }
}
