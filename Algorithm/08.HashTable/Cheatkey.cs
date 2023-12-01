using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace _08.HashTable
{
    internal class Cheatkey
    {
        public Dictionary<string, Action> cheatDic;

        public void Run(string CheatKey)
        {
            var comparer = StringComparer.OrdinalIgnoreCase;
            Cheatkey cheat = new Cheatkey();
            cheatDic = new Dictionary<string, Action>(comparer);
            cheatDic.Add("showmethemoney", cheat.ShowMeTheMoney);
            cheatDic.Add("thereisnocowlever", cheat.ThereIsNoCowLever);
            cheatDic.Add("operationcwal", cheat.OperationCWAL);
            cheatDic.Add("pweroverwhelming", cheat.PowerOverwhelming);



            if (cheatDic.TryGetValue(CheatKey, out Action action))
            {
                cheatDic[CheatKey]();
                action();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }




        }

        public void ShowMeTheMoney()
        {
            Console.WriteLine("골드를 늘려주는 치트키 발동!");
        }
        public void ThereIsNoCowLever()
        {
            Console.WriteLine("바로 승리 합니다. 치트키 발동");
        }

        public void OperationCWAL()
        {
            Console.WriteLine("발전속도가 빨라지는 치트키 발동!");
        }
        public void PowerOverwhelming()
        {
            Console.WriteLine("무적 치트키 발동!");
        }

        static void Main(string[] args)
        {

            Cheatkey cheatkey = new Cheatkey();
            string? str;
            str = Console.ReadLine();
            cheatkey.Run(str);


        }
    }
}
