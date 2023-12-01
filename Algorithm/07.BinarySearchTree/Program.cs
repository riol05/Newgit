using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static _07._BinarySearchTree.Program;

namespace _07._BinarySearchTree
{
    internal class Program
    {
        /******************************************************
		 * 트리 (Tree)
		 * 
		 * 계층적인 자료를 나타내는데 자주 사용되는 자료구조(회장 - 사장 - 부장 - 팀장) 계층구조
		 * 부모노드가 0개 이상의 자식노드들을 가질 수 있음
		 * 한 노드에서 출발하여 다시 자기 자신의 노드로 돌아오는 순환구조를 가질 수 없음
		 * c드라이브에서 하위폴더로 가다가 하위폴더에서 c 드라이브로 돌아올수 없듯이 트리도 그러하다
		 ******************************************************/

        /******************************************************
		 * 이진탐색트리 (BinarySearchTree)
		 * 
		 * 두가지 자식을 가질수있는 이진속성과 탐색속성을 적용한 트리
		 * 이진탐색을 통한 탐색영역을 절반으로 줄여가며 탐색 가능
		 * 이진 : 부모노드는 최대 2개의 자식노드들을 가질 수 있음
		 * 네개까지 들고 있으면 쿼드 ,8개는 옥타, 6개는 헥타트리라고 한다.
		 * 탐색 : 자신의 노드보다 작은 값들은 **왼쪽, 큰 값들은 **오른쪽에 위치
		 ******************************************************/


        // <이진탐색트리의 시간복잡도>
        // 접근			탐색			삽입			삭제
        // O(logN)		O(logN)	      O(logN)	      O(logN)
        // 최악의 경우 (노드가 순서대로 계속 한쪽으로만 치우쳐질때(불균형))
        // 0(N)          0(N)          0(N)             0(N)
        // 하지만 이경우는 성립하지 않는다. 왜냐하면 자가 균형 트리가 불균형을 해결하기 떄문에



        // <이진탐색트리의 주의점> //면접 시험에 나옴//정말 주의하고 외워두자************************
        // 이진탐색트리의 노드들이 한쪽 자식으로만 추가되는 불균형 발생 가능
        // 이 경우 탐색영역이 절반으로 줄여지지 않기 때문에 시간복잡도 증가
        // 이경우 접근 추가 삭제 탐색 전부 Big O (N)이 되게 된다.  이진 탐색 트리의 효율이 전부 사라짐
        // 이러한 현상을 막기 위해 자가균형기능을 추가한 트리의 사용이 일반적(반드시 추가해야 한다.)
        // 대표적인 방식으로 Red-Black Tree, AVL Tree 등을 통해 불균형상황을 파악
        // ****자가균형트리는 회전을 이용하여 불균형이 있는 상황을 해결
        // 안자라난 곳에 넣어주고 너무 많이 자란 트리쪽은 빼주며 상황을 해결한다.
        // C#은 Red Black Tree 파이썬은 AVL Tree 를 사용한다.


        // <트리순회>
        // 트리는 비선형 자료구조로 반복자의 순서에 대해 정의하는데 규칙을 선정해야 함
        // 순회의 방식은 크게 전위, 중위, 후위 순회가 있음
        // 전위순회 : 노드, 왼쪽, 오른쪽
        // 중위순회 : 왼쪽, 노드, 오른쪽   <- 이진탐색트리에서 중위순회시 오름차순으로 데이터를 순회가능
        // 후위순회 : 왼쪽, 오른쪽, 노드

        // 이진 탐색 트리의 탐색과 삭제@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // 이진 탐색 트리에서 자식이 없는 경우 노드의 삭제는 그냥 삭제만 해도 문제가 없다.
        // 자식이 하나만 있었을 경우에 노드의 삭제는 삭제한후 하나의 자식만 그자리를 대체해준다
        // 하지만 자식이 둘이 있는 노드의 경우엔 그냥 삭제만 해서 문제가 사라지지 않는다.
        //그 경우엔 대신 삭제해줄 값을 찾아야한다
        //그 값은 오른 자식 노드에서 가장 작은값이나, 왼쪽 자식 노드에서 가장 큰 값으로 해준다


        public class Monster
        {
            string name;
            int hp;
            int mp;
            public Monster(string name, int hp, int mp)
            {
                this.name = name;
                this.hp = hp;
                this.mp = mp;
            }
        }
        public static void BinarysearchTree()
        {
            SortedSet<int> sortedSet = new SortedSet<int>();
            // sorted = 저장 되있다 set = 정렬 정렬을 기반으로한 오브젝트들의 콜렉션
            sortedSet.Add(1);
            sortedSet.Add(2);
            sortedSet.Add(3);
            sortedSet.Add(4);
            sortedSet.Add(5);

            int search; // 찾을때
            sortedSet.TryGetValue(3, out search); // 탐색 시도 // 이렇게는 잘 안씀

            // key, value 이진 탐색 트리
            // key = 파이리, value = 나머지 데이터(new Monster) 
            SortedDictionary<string, Monster> sort = new SortedDictionary<string, Monster>();

            sort.Add("파이리", new Monster("파이리", 100, 20));// 저장소에 저장후 한번에 찾는다.
            sort.Add("꼬부기", new Monster("꼬부기", 100, 20));
            sort.Add("이상해씨", new Monster("이상해씨", 100, 20));
            //sort.Add("피카츄", new Monster("피카츄", 100, 20));// 피카츄는 뒤에서 찾자
            // 굉장히 많은 포켓몬이 있다 치면 저장소에 저장했을때 찾기 편하다.

            Monster pikachu;
            sort.TryGetValue("피카츄", out pikachu);// 피카츄를 찾는데 이렇게 찾아줘라 이러면 있으면 나오고 아니면 null이 나옴

            pikachu = sort["피카츄"]; // 위와 같은 기능인 문법이다. // 인덱서를 통한 탐색

            if (sort.ContainsKey("피카츄"))
            {
                pikachu = sort["피카츄"]; // 있는지 찾아보고 있으면 나와라
            }
            else // 찾을수 없었던 상황
            {
                Console.WriteLine("피카츄는 잡았던 적이 없었다...");
            }

        }

        public static void Test()
        {
            int count = 1000000;
            List<int> list = new List<int>();
            SortedSet<int> set = new SortedSet<int>();

            Random random = new Random();
            int rand;
            for (int i = 0; i < count; i++)
            {
                rand = random.Next();
                list[i] = rand;
                set.Add(rand);
            }
            list[count / 2] = -1;
            set.Add(-1);

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            list.Find((x) => x == -1);
            stopwatch.Stop();
            Console.WriteLine("배열 time : {0}", stopwatch.ElapsedTicks);

            stopwatch.Restart();
            int value;
            set.TryGetValue(-1, out value);
            stopwatch.Stop();
            Console.WriteLine("트리 time : {0}", stopwatch.ElapsedTicks);
        }
        void BinarySearchTree()
        {

            // value 이진탐색트리
            SortedSet<int> sortedSet = new SortedSet<int>();

            sortedSet.Add(1);
            sortedSet.Add(2);
            sortedSet.Add(3);
            sortedSet.Add(4);
            sortedSet.Add(5);

            int searchValue1;
            sortedSet.TryGetValue(3, out searchValue1);             // 탐색 시도

            // key, value 이진탐색트리
            SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>();

            sortedDictionary.Add("a", "a를 key로 한 데이터");
            sortedDictionary.Add("b", "b를 key로 한 데이터");
            sortedDictionary.Add("c", "c를 key로 한 데이터");
            sortedDictionary.Add("d", "d를 key로 한 데이터");
            sortedDictionary.Add("e", "e를 key로 한 데이터");

            string searchValue2;
            sortedDictionary.TryGetValue("c", out searchValue2);        // 탐색 시도
            string indexerValue2 = sortedDictionary["c"];             // 인덱서를 통한 탐색


            // 이진탐색 검색효율
            int count = 1000000;
            List<int> list = new List<int>();
            SortedSet<int> set = new SortedSet<int>();

            Random random = new Random();
            int rand;
            for (int i = 0; i < count; i++)
            {
                rand = random.Next();
                list[i] = rand;
                set.Add(rand);
            }
            list[count / 2] = -1;
            set.Add(-1);

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            list.Find((x) => x == -1);
            stopwatch.Stop();
            Console.WriteLine("배열 time : {0}", stopwatch.ElapsedTicks);

            stopwatch.Restart();
            int value;
            set.TryGetValue(-1, out value);
            stopwatch.Stop();
            Console.WriteLine("트리 time : {0}", stopwatch.ElapsedTicks);
        }

        static void Main(string[] args)
        {

            DataStructure.BinarySearchTree<int> bst = new DataStructure.BinarySearchTree<int>();

            bst.Add(3);
            bst.Add(1);
            bst.Add(5);
            bst.Add(2);
            bst.Add(4);
            bst.Add(6);

            bst.Remove(3);
            bst.Remove(4);

        }
    }
}
