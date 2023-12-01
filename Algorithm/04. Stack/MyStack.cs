using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{

    /***********************************
     * 어댑터 패턴 (Adapter)
     * 
     * 한 클래스의 인터페이스를 사용하고자 하는 다른 인터페이스로 변환
     ***********************************/
    public class MyStack<T> // 안에 <T>  리스트를 포함시켜버림 // 스택과 리스트는 비슷하기 때문에
    {
        private List<T> list; // 스택은 리스트에 있는 기능으로 빠르게 구현할수 있다. 
        
        public MyStack()
        {
            list = new List<T>();
        }

        public int Count { get { return list.Count; } }
        public void Push(T item) // 리스트의 add만 이용해서 끝에만 붙임
        {
            list.Add(item);
        }
        public T Pop() // 리스트에 선입 후출 기능만 넣어서 스택을 구현했다.
        {
            T item = list[list.Count - 1]; // 리스트 마지막만 가지고와서 꺼낸다.
            list.RemoveAt(list.Count - 1);// 맨뒤를 지운다.
            return item;
        }

        public int Count { get { return topIndex + 1; } }

        public void Clear()
        {
            array = new T[DefaultCapacity];
            topIndex = -1;
        }

        public T Peek() // peek은 리스트에 있는 값을 보여주는 함수(꺼내오는거 아님)
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            return array[topIndex];
        }

        public bool TryPeek(out T result)
        {
            if (IsEmpty())
            {
                result = default(T);
                return false;
            }
            else
            {
                result = array[topIndex];
                return true;
            }
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            return array[topIndex--];
        }

        public bool TryPop(out T result)
        {
            if (IsEmpty())
            {
                result = default(T);
                return false;
            }
            else
            {
                result = array[topIndex--];
                return true;
            }
        }

        public void Push(T item)
        {
            if (IsFull())
            {
                Grow();
            }
            array[++topIndex] = item;
        }

        private void Grow()
        {
            int newCapacity = array.Length * 2;
            T[] newArray = new T[newCapacity];
            Array.Copy(array, 0, newArray, 0, Count);
            array = newArray;
        }

        private bool IsEmpty()
        {
            return Count == 0;
        }

        private bool IsFull()
        {
            return Count == array.Length;
        }
    }
}