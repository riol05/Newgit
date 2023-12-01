using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Delegate
{
    internal class Specifier
    {
        
        public static void Sort(int[] array)// 오름차순 정렬 // 델리게이트 변수에 함수의 주소값을 포함하고 있다.//c++ 의 함수 포인터와 비슷하다 델리게이터엔 추가 기능이 더 있음
        {
            // 정렬 알고리즘 Bubble sort
            for(int i = 0; i < array.Length; i++)
            {
                for (int j = 1; j < array.Length; j++)
                {
                    if (array[i] > array[j]) // 크면 바꿔준다.
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
        public static void DesendingSort(int[] array) // 내림차순 정렬 [4, 3, 2, 1] 순서로 정렬
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 1; j < array.Length; j++)
                {
                    if (array[i] < array[j]) // 작으면 바꿔준다.
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
        public delegate bool Compare(int left, int right);

        public static void Sort(int[] array, Compare comparer)// 대리자를 
        {
            // 정렬 알고리즘 Bubble sort 버블 정렬
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 1; j < array.Length; j++)
                {
                    if (comparer(array[i], array[j])) // 크면 바꿔준다. 11/ 08 16시 50분 참조
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
        public static bool AscendingOrder1(int left, int right)
        {
            return left > right;
        } // 불 함수를 써서 이렇게도 가능하다
        public static int AscendingOrder(int left, int right)
        {
            if (left > right)
                return 1;
            else if (left < right)
                return -1;
            else return 0;
        }

        public static bool DesendingOrder1(int left, int right)
        {
           return (left < right);
        }

        public static int DesendingOrder(int left, int right)
        {
            if (left < right)
                return 1;
            else if (left > right)
                return -1;
            else return 0;
        }
        public static int AbsoluteOrder(int left, int right)
        {
            if (Math.Abs(left) > Math.Abs(right))
                return 1;
            else if (Math.Abs(left) < Math.Abs(right))
                return -1;
            else return 0;
        }
        public static void Test2()
        {
            int[] array = { 3, 2, -1, 1, -2, -3, 9, 8 };
            Sort(array, AscendingOrder);
            Sort(array, DesendingOrder);
            Sort(array);
                DesendingSort(array);

        }
        public class Item
        {
            public string Name;
            public int Level;
            public int Weight;

        }

        public static int Find(Item[] items, string name)
        {
            for(int i =0; i < items.Length; i++)
            {
                if (items[i].Level)
            }
        }
}
}
    
