﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05._Queue
{/*
    public class Myqueue<T>
    {
        private List<T> list;
    public Myqueue()
        {
            list = new List<T>();
        }
        public void Enqueue(T item)
        {
            list.Add(item);
        }
        public T Dequeque()
        {
            T item = list[0];
            list.RemoveAt(0); // ? n개 데이터 있으면 n 번 수행
            // 리스트로 큐를 구현하니까 문제가 생겼다.
            // 뒤에있는걸 땡겨야 하는데 그게 되지 않는다.
            // 비효율적이다.
            return item;
        }
        */
    /*
        public class Myqueue<T>// 이번엔 연결리스트를 이용해 dequeue를 구현한다
        {
            private LinkedList<T> list; 
            public Myqueue()
            {
                list = new LinkedList<T>();
            }
            public void Enqueue(T item)
            {
                list.AddLast(item);
            }
            public T Dequeque()
            {
                T item = list.First.Value;
                list.RemoveFirst(); 
            // dequeue 할때마다 가비지 컬렉터에 노드가 추가된다
            // 이것도 비효율적이다.
            }
        */
    /* 큐의 이론,큐의 구현 원리
     * 큐의 경우 리스트를 이용하면 하나를 뺴면 리스트 전부를 한칸씩 끌어와야 한다.
     * 그걸 막기 위해서는 원형 배열(맨 앞과 맨 뒤가 서로 붙어있는 배열)을 만들어 구성해준다.
     원형 배열을 만들어 head와 tail을 돌리며 구현한다.
    head 옆의 마지막 배열 칸에 tail이 들어올시 그칸은 쓰지 않는다.
    head 와 tail이 옆에 있을시 꽉차있을시 늘려주는 작업을 해준다.
    늘려줄때는 갖고 있는 데이터를 head부터 먼저 복사해 앞으로 보내고 그후 tail까지 복사해 앞에 넣는다.
    배열의 마지막칸은 항상 쓰지 않는다.
    늘려 지면 head는 다시 맨 앞 배열로 가게된다.
    비어있다 . 판정은 head 와 tail 이 같은칸에 있을시에 비어있다. 판정
    꽉차 있다. 판정은 head왼쪽 한칸 전에 tail이 있을시에 꽉차있다 판정을 한다.
    스택과 큐에 대한 비교를 할때
    선입 선출 선입 후출에 대해 말한다.
    스택은 구현 원리에 대해 물어보지 않지만
    큐는 구현 원리에 대해 자주 물어보게 한다.{ 꼭 외워두자 }
     */
    public class Myqueue<T>
    {
        private const int DefaultCapacity = 4; //capacity 구간 설정
        private T[] array;
        private int head; // 헤드 설정
        private int tail; // 테일 설정

        public Myqueue()
        {
            array = new T[DefaultCapacity];
            head = 0;
            tail = 0;
        }
        public void Enqueue (T item)
        {
            if (IsFull()) // 꽉차 있으면
            {
                Grow(); // 크게 늘려준다.
            }
            array[tail] = item;
            // tail을 다음칸으로 가게되면
            // tail++ 하게 되면 원형 배열이 안된다.
            MoveNext(ref tail);
        }
        public T Dequeue()
        {
            if (IsEmpty())// 비어있을때 꺼내는건 안되기에 조건문
            {
                throw new InvalidOperationException(); // 비정상적인 동작 예외
            }
            T result = array[head];
            MoveNext(ref head);
            return result;
        }
        private void Grow() // 꽉차 있을땐 늘려주는 작업
        {
            int newCapacity = array.Length* 2; // 새로운 허용량은 2배로 만든다
            T[] newArray = new T[newCapacity];
/*
            if (head < tail)
            {
                Array.Copy(array, head, newArray, 0, tail);
            }
            else
            {
                Array.Copy(array, head, newArray, 0, tail);
                Array.Copy(array, head, newArray, 0, tail);
            } // 6:17분 영상 보자 이렇게 하는것도 가능하다고함
*/
            int i = 0;
            while (head != tail)
            {
                newArray[i] = array[head];
                i++;
                MoveNext(ref head); // 원래 있던 배열에 새로운 배열을 만들어준뒤
            }
            head = 0;
            tail = Count; // 이번엔 카운트 구현
            array = newArray;
        }
        
        public int Count // 갯수를 알아보자
        {
            get
            {
                if (head <= tail)
                {
                    return tail - head; // 테일 - 헤드 앞에있는 배열의 갯수가 나온다.
                }
                else // 테일이 앞에 있을때
                {
                    return tail +(array.Length - head); 
                }
            }
            
        }
        private bool IsFull() // 꽉차 있는지 확인하는 작업
        {
            if (head == 0)
 // head가 0일땐 tail 에 +1을 하면 4나 5가 되기에 그 경우도 만들어준다
            {
                return tail == array.Length - 1;// head가 
            }
            else
            {
                return head == tail + 1; // tail이 한칸 전 일때
                // 원형 배열에서 head가 tail 바로 오른쪽에 있을때
            }
            
        }
        private bool IsEmpty() // 비어있는지 확인하는 작업
        {
            return head == tail;
            // 원형 배열에서 head가 tail 과 같이 있을때 비어있다.
        }
        private void MoveNext(ref int index) // call by value 이기 때문에 ref로 원본을 바꿔준다 
            // tail ++ 하게되면 원형배열이 안될수도 있다.
            // 이동하게 만들어주는 함수를 만들어준다 
        {
            if (index == array.Length -1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
        }
    static void Main(string[] args)
        {
            
        }
    }
    
}
