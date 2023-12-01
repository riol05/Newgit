using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report
{
    internal class MList<T>
    {
        private const int DefaultCapacity = 20;

        private T[] items;
        private int size;

        public MList()
        {
            items = new T[DefaultCapacity];
            size = 0;
        }

        public int Capacity { get { return items.Length; } }
        public int Count { get { return size; } }


        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException();

                return items[index];
            }
            set
            {
                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException();

                items[index] = value;
            }
        }

        public void Add(T item)
        {
            
            Console.Write(item);
            Console.WriteLine(" 을/ 를 획득 하였습니다.");
            Console.Write("현재 ");
            Console.Write(Count);
            Console.WriteLine("째 칸에 획득하였습니다");
            if (size >= items.Length)
                Grow();

            items[size++] = item;
        }

        public void Clear()
        {
            items = new T[DefaultCapacity];
            size = 0;
        }


        public int IndexOf(T item)
        {
            
            Console.Write("찾으시는 아이템 ");
            Console.Write(item);
            Console.Write("은/는");
            if (item == null)
            {
                Console.WriteLine("현재 인벤토리에 없습니다.");
                return 0;
            }
            Console.Write(Count);
            Console.WriteLine("째 칸에 있습니다.");
            return Array.IndexOf(items, item, 0, size);
        }

        public bool Remove(T item)
        {

            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }
        public void Contains()
        {

        }
        public void SelectMenu()
        {
            bool parse;
            int value;
            do
            {
                string? command = Console.ReadLine();
                parse 
            }while (parse);
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException();

            size--;
            Array.Copy(items, index + 1, items, index, size - index);
        }

        private void Grow()
        {
            int newCapacity = items.Length * 2;
            T[] newItems = new T[newCapacity];
            Array.Copy(items, 0, newItems, 0, size);
            items = newItems;
        }
    }
    internal class Program { 
        static void Run(string[] args)
        {
            
            MList<string> inven = new MList<string>();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("***********");
                Console.WriteLine("  인벤토리  ");
                Console.WriteLine("***********");

                inven.Add("물약");
                inven.Add("한손검");
                inven.Add("두손검");
                inven.Add("방패");
                inven.Add("지도");
                inven.Add("투구");
                inven.IndexOf("방패");

                int menu = SelectMenu();

                switch(menu)
                    {
                    case 1:
                        inven.Add(new.Potion);
                            break;
                        case 2:
                        inven.Add(new.Herb);
                        case 3:

                }
                Thread.Sleep(1000);// 시간 지연 걸어주기
            }
        }
    }
    
}
