using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.List1
{
    internal class list<T>
    {
        private const int DefaultCapacity = 20; // 미리 크게 만들고 그 안에서 써내려가는 타입의 리스트
        private T[] items; // 실제론 일부만 사용하는것
        private int size; // 우리가 느끼기엔 늘렸다 줄였다 하는거처럼 느끼지만 
// 데이터를 20개에서 추가적으로 데이터를 더 늘리면 리스트는 더큰 배열 만들어준다
//그후 그 배열에 데이터를 복사한후 더 작은 배열은 삭제해준다.
        public int Count { get { return size;  } }
        public int Capacity { get { return Count; } }
        public list()
        {
            items = new T[DefaultCapacity];
            size = 0;
            
        }
        //public MyList()
        //{
        //    items = new T[DefaultCapacity];
        //    size = 0;
        //}
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= size)
                {
                    throw new IndexOutOfRangeException();
                }
                return items[index];
            }
            set
            {
                if (index < 0 || index >= size)
                {
                    throw new IndexOutOfRangeException();
                }
                items[index] = value;
            }
        }
        public void add(T item)
        {
            if (size >= items.Length)
            {
                Grow();
            }
                items[size] = item;
                size++; // 일부분만 사용한다.
            
        }
      
        private void Grow() // 사이즈를 늘려주는 방법
        {
            int newCapacity = items.Length * 2; // 원래 있던 배열보다 2배 큰 배열을 만들어주고
            T[] newItems = new T[newCapacity]; // 새로 더큰 배열을 늘어난 크기 만큼으로 만든다.
        
            for (int i = 0; i < size; i++)
            {
                newItems[i] = items[i]; // 가지고 있던 만큼 전부 복사

            }
            items = newItems; // items를 새로운 배열에 복사한다.
        }

        public void Clear()
        {
            items = new T[DefaultCapacity];
            size = 0; // 싹다 치워주는 기능의 clear
        }
        public bool Remove(T item) // 반환형은 bool로 
        {
            // 찾는기능부터 만든다
            int index = IndexOf(item); //item변수의 위치를 찾아줘라
            if (index < 0)
            {
                
                return false;
            }
            else
            {
                RemoveAt(index);
                return true;

            }
            // TODO : 이거 구현합시다.
            // 보기/작업 목록에 들어가면 TODO 리스트가 보인다.
        }
        public void RemoveAt(int index) // remove 는 찾아서 지워줘, removeat[2] 은 이거 지워줘 라는뜻  
        {
            if (index < 0 || index >= size)
            {
                Console.WriteLine("범위를 벗어나는 삭제는 불가능하다");
                return;
                // throw new IndexOutOfRangeException(); // 예외 발생을 던지는상황
            }
            size--; // 11 / 10일 7시 강의
            Array.Copy(items, index + 1, items, index, size - index);
            //for (int i = index; i< size - index; i++)
            //{
             //   items[index] = items[index + 1];
            //}
        }
        

        public int IndexOf(T item) // 찾는 기능
        { // 배열 기반이기때문에 Array. Indexof 를 쓴다.

            return Array.IndexOf(items, item , 0 , size); // 배열에 있는 기능을 쓴다. 
                            // item중에 items를 찾아줘라
                            // 0부터 size까지 만 찾아줘라. 쓰고 있는 범위(size)까지만 찾는다
                            // IndexOf로 못찾으면 값은 -1로 나온다
        }

        static public void Main()
        {
            List<int> list = new List<int>();
            list.Capacity = 150; // 리스트의 구현 원리를 알고 있으니 Capacity를 미리 구현해놓는다.
             // Capacity를 지정 해놔도 Grow를 하면 사이즈는 늘어난다.
            for (int i = 0; i < 20; i++)
            {
                list.Add(i);
                Console.WriteLine("{ 0 } 데이터 추가", i);
                Console.WriteLine("리스트의 카운트 {0}", list.Count);
                Console.WriteLine("리스트의 Capacity {0}", list.Capacity);

                int removeIndex = 7;
                if (removeIndexIndex < 0||) //11 월 10일 7시 22분
            }
            list[10] = 1; // 인덱스를 구현하면 인덱스를 쓰는거처럼 접근할수 있게된다.
            
        }
        
    }
}
