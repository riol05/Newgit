using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class SingleTon<T> where T : new ()
    {
        protected SingleTon() { }
        private static T instance;

        public static T Getinstance()
        {
            if (instance == null)
            {
                instance = new T();
            }
            return instance;
        }
    }
    public class Item 
    {
        Player player = new Player();
        public string Name;
        public string Description;
        public int Amount;
        public virtual void Use()
        {
            Console.WriteLine("{0} 을/를 사용합니다", Name);
        }
    }
    public class Potion : Item
    {
        int healPoint = 10;
        public Potion()
        {
            Name = "포션";
            Description = $"사용자의 체력을 {healPoint} 만큼 회복시켜줍니다";
            Amount = 10;
        }
        public virtual int Use(Player player)
        {
            Console.WriteLine("체력을 {0} 만큼 회복합니다", healPoint);
            return healPoint + player.Hp;
        }
    }
    public class Sword : Item
    {
        private int Damage = 10;
        
        public Sword()
        {
            Name = "한손검";
            Description = $"사용자의 공격력을 {Damage} 만큼 더 강력하게 만들어줍니다(장착시 사용불가)";
            Amount = 30;
        }
        public virtual int Use(Player player)
        {
            if (player.equipsword == true)
            {
                Console.WriteLine("이미 무기를 장착하고 있습니다");
                return player.Damage;
            }
            Console.WriteLine("{0}를 장착합니다.", this.Name);
            Console.WriteLine("공격력이 {0} 만큼 올라갑니다 ", Damage);
            return Damage + player.Damage;
        }
    }
    public class MonsterBone : Item
    {
        public MonsterBone()
        {
            Name = "몬스터의 뼈";
            Description = "몬스터를 잡고 나온 몬스터의 뼈다";
            Amount = 3;
        }
        public override void Use()
        {
            Console.WriteLine("이 아이템은 사용하지 못하는 아이템입니다");
        }

    }

    public class Inventory
    {

        private static int MaxCount = 6;
        public List<Item> inv;
        private bool Full = false;
        
        protected Inventory() {
            inv = new List<Item>();
        }
        private static Inventory instance;
        public static Inventory GetInstance()
        {
            if (instance == null)
            {
                instance = new Inventory();
            }
            return instance;
        }
        public int gold = 100;
        List<Item> Item1 = new List<Item>();
        
        public int CanBuy = 1;
        public void checkFull()
        {
            
            if (inv.Count >= MaxCount )
            {
                Console.WriteLine("아이템이 가득 찼습니다.");
                Full = true;
            }
        }

        public void DescriptionItem(Item item)
        {
            Console.WriteLine($"{item.Description}");
        }
        public void AddItem(Item item)
        {
            checkFull();
            if (Full == false)
            {
                inv.Add(item);
                Console.WriteLine($"{item.Name}을 획득 하였습니다.");
            }
            else   // Full = true;
            {
                Console.WriteLine("아이템이 가득찼습니다.");
                Console.WriteLine("아이템을 획득할수 없습니다.");
                return;
            }
        }
        public void RemoveItem(Item item)
        {
            int input;
            input = Console.Read();
            Console.WriteLine($"{inv[input].Name}을 버립니다. 다신 돌려받을수 없습니다");
            Console.Write("어떻게 하시겠습니까? Y/N");
            ConsoleKeyInfo info = Console.ReadKey();
            ConsoleKey key = info.Key;
            switch (key)
            {
                case ConsoleKey.Y:
                    Console.WriteLine("아이템을 버립니다.");
                    Console.WriteLine("{0} 을/를 버렸습니다.", inv[input].Name);
                    deleteItem(input);
                    break;
                case ConsoleKey.N:
                    Console.WriteLine("아이템을 버리지 않습니다.");
                    break;
            }
        }
        public void deleteItem(int num)
        {
           inv.RemoveAt(num);            
        }
        public int SpendGold(int amount)
        {
            if (amount < gold)
            {
                Console.WriteLine("아이템을 구매할수없습니다");
                Console.WriteLine("현재 잔액 {0} 골드, 구매 아이템 가격인 {1} 골드 보다 모자랍니다", gold, amount);
                CanBuy = 0;
                return gold;

            } 
            Console.WriteLine("아이템을 구매하였습니다");
            Console.WriteLine("골드를 {0} 골드 만큼 사용하여 현재 잔액은 {1} 골드 입니다", amount, gold - amount);
            return gold - amount;
        }
        public int AddGold(int amount)
        {
            Console.WriteLine("{0} 골드 획득 하였습니다 ", amount);
            return gold + amount;
        }
    }

    public class Player
    {
        public int Damage = 10;
        public int Hp = 50;
        public bool equipsword = false;
        List<Item> Item = new List<Item>();
        public void UseItem(Item item)
        {
            Console.WriteLine("{0}아이템을 사용합니다", item.Name) ;
            item.Use();
        }
    }
    public class Monster
    {
        private int DropGold = 20;
        Inventory inven = Inventory.GetInstance();
        
        List<Item> Item1 = new List<Item>();
        public int DropItem(Item item)
        {
            Console.WriteLine($"몬스터가 {item.Name}을 드랍합니다");
            inven.AddItem(item);
            Console.WriteLine($"몬스터가 {DropGold} 골드를 드랍합니다");
            return inven.gold + DropGold;
        }
    }
    public class Shop
    {
        Inventory inven = Inventory.GetInstance();
        
        List<Item> Item1 = new List<Item>();
        public void SellItem(Item item)
        {
            Console.WriteLine($"{item.Name} 을/를 {item.Amount} 골드로 구매합니다.");
            inven.SpendGold(item.Amount);
            if (inven.CanBuy == 0)
            {
                inven.CanBuy = 1;
                return;
            }
            inven.AddItem(item);
            return;
        }
    }
}
