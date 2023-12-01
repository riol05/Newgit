using System;
using System.Collections.Generic;

namespace _01._List
{
    internal class Program
    {
        /******************************************************
		 * 배열 (Array)
		 * 
		 * 연속적인 메모리상에 동일한 타입의 요소를 일렬로 저장하는 자료구조
		 * 초기화때 정한 크기가 소멸까지 유지됨
		 * 배열의 요소는 인덱스를 사용하여 직접적으로 엑세스 가능
		 * 배열은 선형 리스트와 다르게 배열의 갯수를 지정해야한다.
		 * 장비의 갯수같은 경우엔 배열로 관리하는게 편할지도
		 ******************************************************/

        // <배열의 사용>
        void Array()
        {
            int[] intArray = new int[100]; // 100개의 배열이 확보된 상태 배열의 크기가 정해서 써야하기에 유동적이지 않아 원하는 갯수 만큼의 배열을 보관할수 없다.

            // 인덱스를 통한 접근
            intArray[0] = 10;
            int value = intArray[0];
        }

       
        // <배열의 시간복잡도>
        // 접근		탐색
        // O(1)		O(N)

    

        /******************************************************
		 * 선형리스트 (Linear List)
		 * 
		 * 런타임 중 크기를 확장할 수 있는 배열기반의 자료구조
		 * 배열요소의 갯수를 특정할 수 없는 경우 사용
		 * 크기가 유동적이라 언제 몇개를 만들어야할지 모를땐 선형 리스트
		 * 몬스터나 유저수를 사용할땐 선형 리스트가 유리하다. 
		 ******************************************************/
        //배열은 고정배열 list는 가변배열
        // List는 효율적인 자료구조중 하나기 때문에 알아놓자
        // <List의 사용>
        static void List()
        { 

            List<string> list = new List<string>();//리스트는 클래스로 되어있기 때문에 new는 사용한다.
            Array.Length; // 배열은 length로 길이를 판단하지만
            list.Count; // 리스트는 몇개 쓰는지를 확인하는 count를 사용한다.
            list.Capacity; //이 리스트의 허용량을 나타내는것이 Capacity이다.
            // 리스트는 일반화를 적용한다.
            // 배열 요소 삽입
            list.Add("0번 데이터"); // list.add로 추가해준다.
            list.Add("1번 데이터");
            list.Add("2번 데이터");
            //Console.WriteLine(list[0]);// 식으로 데이터에 접근해준다.
            // 배열 요소 삭제
            list.Remove("1번 데이터"); // list.Remove로 제거해준다.
            // Remove 는 bool 이 반환형 true면 지워주고 false면 제거해주는 기능
            list.Contains("2번 데이터"); // 이게 있는지 확인하는 Contains
            list.Insert(0, "-1번데이터"); // 중간에 끼워넣는 Insert
            //MSDN에 들어가서 기술문서를 읽어보자******************!!!!!!!!!!!!!!!!

            

            // 배열 요소 접근
            list[0] = "데이터0";
            string value = list[0];

            // 배열 요소 탐색
            string? findValue = list.Find(x => x.Contains('2'));
            int findIndex = list.FindIndex(x => x.Contains('0'));
        }
        

        // <List의 시간복잡도>
        // 접근		탐색		삽입		삭제
        // O(1)		O(N)	O(1)	O(N)     0(N)
            //              최선     최악
        static void Main(string[] args)
        {
            DataStructure.List<string> list = new DataStructure.List<string>();

            list.Add("1번 데이터");
            list.Add("2번 데이터");
            list.Add("3번 데이터");
            list.Add("4번 데이터");
            list.Add("5번 데이터");

            string value;
            value = list[0];
            value = list[1];
            value = list[2];
            value = list[3];
            value = list[4];

            list[0] = "5번 데이터";
            list[1] = "4번 데이터";
            list[2] = "3번 데이터";
            list[3] = "2번 데이터";
            list[4] = "1번 데이터";

            list.Remove("3번 데이터");
            list.Remove("2번 데이터");

            string? findValue = list.Find(x => x.Contains('4'));
            int findIndex = list.FindIndex(x => x.Contains('1'));
        }
    }
}