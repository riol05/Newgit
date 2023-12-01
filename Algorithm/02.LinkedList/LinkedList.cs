using System;
using System.Collections.Generic;

namespace _02._LinkedList
{
    internal class Program
    {
        /******************************************************
		 * 연결리스트 (Linked List)
		 * 
		 * 데이터를 포함하는 노드들을 연결식으로 만든 자료구조
		 * 노드는 데이터와 이전/다음 노드 객체를 참조하고 있음
		 * 노드가 메모리에 연속적으로 배치되지 않고 이전/다음노드의 위치를 확인
		 * 배열에 비해서 삽입 삭제가 유용한 노드 기반의 자료구조
		 * 연속적으로 배치 한게 아니라 삽입과 삭제가 유용하다
		 ******************************************************/

        // <링크드리스트 사용>
        void LinkedList()
        {
            LinkedList<string> linkedList = new LinkedList<string>(); //string을 담을수 있는 연결 리스트 

            // 링크드리스트 요소 삽입
            linkedList.AddFirst("0번 앞데이터");
            linkedList.AddFirst("1번 앞데이터");// 연결 리스트는 앞에 붙이는것도 문제가 없다.
            linkedList.AddLast("0번 뒤데이터"); // 뒤에 붙이기 물론 가능하다.
            linkedList.AddLast("1번 뒤데이터");

            // 링크드리스트 요소 삭제
            linkedList.Remove("2번 뒤데이터"); 

            // 링크드리스트 요소 탐색
            LinkedListNode<string> findNode = linkedList.Find("0번 뒤데이터");

            // 링크드리스트 노드를 통한 노드 참조
            LinkedListNode<string> prevNode = findNode.Previous; // 이전 노드와 다음 노드를 확인할수있다.
            LinkedListNode<string> nextNode = findNode.Next;

            // 링크드리스트 노드를 통한 노드 삽입
            linkedList.AddBefore(findNode, "찾은노드 앞데이터"); // 이전 다음 노드의 추가또한 가능하다
            linkedList.AddAfter(findNode, "찾은노드 뒤데이터");

            // 링크드리스트 노드를 통한 삭제
            linkedList.Remove(findNode); // 연결 리스트에서 노드를 통해 삭제가 가능하다.
        }   // 인덱스 사용이 안되기때문에 접근에 있어서 시간이 오래걸리게 된다.

        // <LinkedList의 시간복잡도>
        // 접근		탐색		삽입		삭제
        // O(N)		O(N)	    O(1)	    O(1)
        // 삽입

        static void Main(string[] args)
        {
            DataStructure.LinkedList<string> linkedList = new DataStructure.LinkedList<string>();

            // 링크드리스트 요소 삽입
            linkedList.AddFirst("0번 앞데이터");
            linkedList.AddFirst("1번 앞데이터");
            linkedList.AddLast("0번 뒤데이터");
            linkedList.AddLast("1번 뒤데이터");

            // 링크드리스트 요소 삭제
            linkedList.Remove("1번 앞데이터");

            // 링크드리스트 요소 탐색
            DataStructure.LinkedListNode<string> findNode = linkedList.Find("0번 뒤데이터");

            // 링크드리스트 노드를 통한 노드 참조
            DataStructure.LinkedListNode<string> prevNode = findNode.Prev;
            DataStructure.LinkedListNode<string> nextNode = findNode.Next;

            // 링크드리스트 노드를 통한 노드 삽입
            linkedList.AddBefore(findNode, "찾은노드 앞데이터");
            linkedList.AddAfter(findNode, "찾은노드 뒤데이터");

            // 링크드리스트 노드를 통한 삭제
            linkedList.Remove(findNode);
        }
    }
}