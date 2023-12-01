using System.Collections.Generic;
using System;
using System.Collections;
using System.Security.Cryptography;

namespace _08._HashTable
{
    internal class Program
    {
        /******************************************************
		 * 해시테이블 (HashTable)
		 * 
		 * 키 값을 해시함수로 해싱 과정을 통하여 해시테이블의 특정 위치로 직접 엑세스하도록 만든 방식
		 * 키 값을 단순한 숫자인 해시 함수로 뭉게서 해시 테이블의 특정 위치로 변환하여 직접 엑세스하는것
		 * 해시 : 임의의 길이를 가진 데이터를 고정된 길이를 가진 데이터로 매핑
		 * 시간 복잡도가 낮은 대신 공간 복잡도가 올라가게된다.
		 ******************************************************/

        // <해시테이블의 시간복잡도>
        // 접근			탐색			삽입			삭제
        // X			O(1)	       0(1)		        O(1)

        //해시의 

        // <해시함수의 조건>
        // 키 값을 해시함수를 통해 처리한 결과가 항상 동일한 값이어야 함
        // 나눗셈 값으로 해싱을 하여 해시 테이블에 넣는다.
        // EX) 숫자를 키값으로 할때에는
        // 주소 = 입력 값 % 테이블의 크기
        // "파이리"가 아스키코드 1107 일때 107 = 1107 % 1000(테이블의 크기) 
        
        // <해시함수의 효율>
        // 1. 해시함수의 처리속도가 빠를수록 효율이 좋음
        // 2. 해시함수의 결과가 밀집도가 낮아야 함
        // 3. 해시테이블의 크기가 클수록 빠르지만 메모리가 부담됨
        

        // <해시테이블 주의점 - 충돌>
        // 해시함수가 서로 다른 입력 값에 대해 동일한 해시테이블 주소를 반환하는 것
        // 모든 입력 값에 대해 고유한 해시 값을 만드는 것은 불가능하며 충돌은 피할 수 없음
        // 대표적인 충돌 해결방안으로 체이닝과 개방주소법이 있음
        // EX)"파이리" 아스키코드 11107 이라 하고 "꼬부기" 아스키코드 81107 이라 했을때
        // 해시 테이블의 크기가 1000일 경우 서로 107로 같은 주소를 갖는다.
        // 이럴 경우엔 해결 방안이 필요하다.

        // <충돌해결방안 - 체이닝> // C#에선 효율이 떨어진다. (노드기반이기 때문에)
        // 해시 충돌이 발생하면 연결리스트로 데이터들을 연결하는 방식
        // 장점 : 해시테이블에 자료가 많아지더라도 성능저하가 적음
        // 단점 : 해시테이블 외 추가적인 저장공간이 필요
        //        겹칠 때마다 연결리스트로 추가 공간을 만들어야하기 떄문에 그건 어쩔수 없는 단점이다.

        // <충돌해결방안 - 개방주소법> 
        // C#은(체이닝쓰지않고) 개방 주소법 쓴다. 최적화가 잘되있어 더 빠르기 때문
        // 해시 충돌이 발생하면 다른 빈 공간에 데이터를 삽입하는 방식
        // 해시 충돌시 선형탐색, 제곱탐색, 이중해시 등을 통해 다른 빈 공간을 선정
        // 장점 : 추가적인 저장공간이 필요하지 않음, 삽입삭제시 오버헤드가 적음
        // 단점 : 해시테이블에 자료가 많아질수록 성능저하가 많음
        // 해시테이블의 공간 사용률이 높을 경우 성능저하가 발생하므로 재해싱 과정을 진행함
        // 재해싱 : 해시테이블의 크기를 늘리고 테이블 내의 모든 데이터를 다시 해싱 
        

        void Dictionary()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            dictionary.Add("txt", "텍스트 파일");
            dictionary.Add("bmp", "이미지 파일");
            dictionary.Add("mp3", "오디오 파일");

            Console.WriteLine(dictionary["txt"]);       // 키값은 인덱서를 통해 접근

            if (dictionary.ContainsKey("mp3"))
                Console.WriteLine("mp3 키 값의 데이터가 있음");
            else
                Console.WriteLine("mp3 키 값의 데이터가 없음");

            if (dictionary.Remove("mp3"))
                Console.WriteLine("mp3 키 값에 해당하는 데이터를 지움");
            else
                Console.WriteLine("mp3 키 값에 해당하는 데이터를 못지움");

            if (dictionary.ContainsKey("mp3"))
                Console.WriteLine("mp3 키 값의 데이터가 있음");
            else
                Console.WriteLine("mp3 키 값의 데이터가 없음");

            string output;
            if (dictionary.TryGetValue("bmp", out output))
                Console.WriteLine(output);
            else
                Console.WriteLine("bmp 키 값의 데이터가 없음");
        }
        public class Monster
        {
            public string name;
            Monster(string name)
            {
                this.name = name;
            }

        }

        public static void test()
        {
            Hashtable ht = new Hashtable();// 해쉬 테이블은 일반화가 되어있지않다.
            //ht.Add("파이리", new Monster("파이리"));// key값과 value 값을 둘다 오브젝트 타입을 쓴다.
            //ht.Add(123,new MOnster "꼬부기");// 박싱 언박싱 개념, 언박싱으로 객체를 꺼내온다.
            //ht.Add(3.2f, "문자열");

            //Monster pairy = (Monster)ht["파이리"];
            //bool b = (bool)ht
            HashSet<Monster> set = new HashSet<Monster>();//
            set.Add(new Monster("파이리"));

            Dictionary<string, Monster> dic = new Dictionary<string, Monster>();// Dictionary의 경우 키값이 정해져있다.
            dic.Add("꼬부기", new Monster("꼬부기"));
            dic.Add("이상해씨", new Monster("이상해씨"));

            Monster d = dic["파이리"]; // 지정한 타입의 데이터만 갖다 쓸수있다.
            dic.Remove("파이리");
            // 여러번 빈번하게 리스트처럼 지웠다 붙였다 할 경우 개방 주소의 충돌이 발생할 확률이 생기고 효율이 낮아질수 있다.
            // 자주 add remove 할꺼면 리스트를 써라
        }

        static void Main(string[] args)
        {
            DataStructure.Dictionary<string, string> hashTable = new DataStructure.Dictionary<string, string>();

            hashTable.Add("txt", "텍스트 파일");
            hashTable.Add("bmp", "이미지 파일");
            hashTable.Add("mp3", "오디오 파일");

            Console.WriteLine(hashTable["txt"]);       // 키값은 인덱서를 통해 접근

            if (hashTable.ContainsKey("mp3"))
                Console.WriteLine("mp3 키 값의 데이터가 있음");
            else
                Console.WriteLine("mp3 키 값의 데이터가 없음");

            if (hashTable.Remove("mp3"))
                Console.WriteLine("mp3 키 값에 해당하는 데이터를 지움");
            else
                Console.WriteLine("mp3 키 값에 해당하는 데이터를 못지움");

            if (hashTable.ContainsKey("mp3"))
                Console.WriteLine("mp3 키 값의 데이터가 있음");
            else
                Console.WriteLine("mp3 키 값의 데이터가 없음");

            string output;
            if (hashTable.TryGetValue("bmp", out output))
                Console.WriteLine(output);
            else
                Console.WriteLine("bmp 키 값의 데이터가 없음");
        }
        static void Main(string[] args)
        {
            // 배열 : 크기가 정해진 자료집합 ex ) 장비창
            int[] array = new int[5];
            // 리스트 : 크기가 유동적인 자료집합 (접근도 좋고, 삽입 삭제도 좋은편)
            // ex) 유동적인 자료집합
            List<int> list = new List<int>();

            //해시 테이블 기반 자료 구조 : 탐색이 매우 빠른 자료집합     ex) (대규모 자료 저장소) -> 초 대규모는 (데이터 베이스로)
            Hashtable ht;
            HashSet<int> set;
            Dictionary<int, Monster> dic;

            // 상황 용도에 따라 
            // 스택 : 선입 후출이 필요할때 쓰는 자료집합 ex) 실행취소, 명령수집,UI
            Stack<int> stack = new Stack<int>();
            // 큐 : 선입 선출이 필요할때 자료집합  ex) 대기열, 진행순서
            Queue<int> queue = new Queue<int>();
            //우선 순위 큐 : 기준에 따라 먼저 처리할 필요가 있을때 자료 집합 ex ) 가중치에 따른 처리 순서
            PriorityQueue<string, int> pq = new PriorityQueue<string, int>();

            // <C# 특징상 상대적으로 많이 쓰지 않지만 이론적으로 중요한 자료구조>
            //연결 리스트
            // 이진 탐색 트리
         }
    }
    
}