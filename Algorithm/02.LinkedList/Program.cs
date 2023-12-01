using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStructure
{
    public class LinkedListNode<T>
    {
        internal LinkedList<T> list;
        internal LinkedListNode<T> prev; // 이전 노드에 대해
        internal LinkedListNode<T> next; // 다음 노드에 대해
        private T item;

        public LinkedListNode(T value)
        {
            this.list = null;
            this.prev = null;
            this.next = null;
            this.item = value;
        }

        public LinkedListNode(LinkedList<T> list, T value)
        {
            this.list = list;
            this.prev = null;
            this.next = null;
            this.item = value;
        }

        public LinkedListNode(LinkedList<T> list, LinkedListNode<T> prev, LinkedListNode<T> next, T value)
        {
            this.list = list;
            this.prev = prev;
            this.next = next;
            this.item = value;
        }

        public LinkedList<T> List { get { return list; } }
        public LinkedListNode<T> Prev { get { return prev; } }
        public LinkedListNode<T> Next { get { return next; } }

        public T Item { get { return item; } set { item = value; } }
    }

    public class LinkedList<T>
    {
        private LinkedListNode<T> head; // 노드의 처음
        private LinkedListNode<T> tail; // 노드의 끝 // 효율적으로 관리하기 어렵기때문에 처음과 끝을 지정해둔다
        private int count;

        public LinkedList()
        {
            this.head = null;
            this.tail = null;
            count = 0;
        }

        public LinkedListNode<T> First { get { return head; } }
        public LinkedListNode<T> Last { get { return tail; } }
        public int Count { get { return count; } }

        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
        {
            ValidateNode(node);
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value); // 새로운 노드를 만든다.
            InsertNodeBefore(node, newNode);
            if (node != head)
            {
                node.prev.next = newNode;
                newNode.prev = node.prev;
            }
            else
            {
                head = newNode; // 새로운 노드가 헤드가 된다.
            }
            newNode.next = node; // 노드의 전노드 다음 노드를 설정한다.
            node.prev = newNode;
            count++;
            return newNode;
        }

        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
        {
            ValidateNode(node);
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);
            InsertNodeAfter(node, newNode);
            if (node != tail)
            {
                node.next.prev = newNode;
                newNode.next = node.next;
            }
            else
            {
                tail = newNode;
            }
            newNode.prev = node;
            node.next = newNode;
            count++;
            return newNode;
        }

        public LinkedListNode<T> AddFirst(T value) // 새로운 노드를 만들어주고
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);// 새로 만든 노드를 헤드 노드로
            if (head != null) 
            {
                InsertNodeBefore(head, newNode);  // 헤드가 없었을 경우엔 새로 만들어준다.
                head = newNode;
            }
            else 
            {
                InsertNodeToEmptyList(newNode);
            }
            return newNode;
        }

        public LinkedListNode<T> AddLast(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);
            if (tail != null) // 다른 노드가 있었던 상황
            {
                InsertNodeAfter(tail, newNode);
                tail = newNode;
            }
            else // 처음으로 추가하는 상황 ==  노드가 하나도 없었던 상황
            {
                InsertNodeToEmptyList(newNode);
            }
            return newNode;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T value)
        {
            return Find(value) != null;
        }

        public LinkedListNode<T> Find(T value) // 인덱스가 없기 때문에 맨앞부터 다음 다음 순서로 찾아야한다.
        {
            LinkedListNode<T>? node = head; // 처음 노드 선택
            EqualityComparer<T> c = EqualityComparer<T>.Default; // 둘이 같은지 확인해주는 클래스
            if (value != null)
            {
                while (node != null) // 반복한다.
                {
                    if (c.Equals(node.Item, value))
                        return node;
                    else
                        node = node.next; // 못찾으면 다음꺼
                }
            }
            else
            {
                while (node != null)
                {
                    if (node.Item == null)
                        return node;
                    else
                        node = node.next;
                }
            }
            return null; // null 일경우 못찾았다
        }

        public bool Remove(T value)
        {
            LinkedListNode<T>? node = Find(value); // 먼저 find를 통해 찾아보았다
            if (node.prev != null)
            {
                node.prev.next = node.next;
            }
            else
            {
                head = node.next;
            }
            if ( node.next != null)
            {
                node.next.prev = node.prev;
            }
            else
            {
                tail = node.prev;
             //   return false;// 못찾았음 == 데이터가 없었다. false를 통해 마무리
            }
            count--;
        }

        public void Remove(LinkedListNode<T> node)
        {
            ValidateNode(node);
            if (head == node)
                head = node.next;
            if (tail == node)
                tail = node.prev;
            RemoveNode(node);
        }

        public void RemoveFirst()
        {
            if (head == null)
                throw new InvalidOperationException();

            LinkedListNode<T> headNode = head;
            Remove(headNode);
        }

        public void RemoveLast()
        {
            if (tail == null)
                throw new InvalidOperationException();

            LinkedListNode<T> tailNode = tail;
            Remove(tailNode);
        }

        private void ValidateNode(LinkedListNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException();
            if (node.list != this)
                throw new InvalidOperationException();
        }

        private void InsertNodeBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            newNode.next = node;
            newNode.prev = node.prev;
            if (newNode.prev != null)
                newNode.prev.next = newNode;

            node.prev = newNode;

            count++;
        }

        private void InsertNodeAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            newNode.prev = node;
            newNode.next = node.next;
            if (newNode.next != null)
                newNode.next.prev = newNode;

            node.next = newNode;

            count++;
        }

        private void InsertNodeToEmptyList(LinkedListNode<T> newNode)
        {
            if (count != 0)
                throw new InvalidOperationException();

            head = newNode;
            tail = newNode;
            count++;
        }

        private void RemoveNode(LinkedListNode<T> node)
        {
            if (node.list != this)
                throw new InvalidOperationException();

            if (node.prev != null)
                node.prev.next = node.next;
            if (node.next != null)
                node.next.prev = node.prev;

            count--;
        }
    }
}