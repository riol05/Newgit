using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._Sorting
{
    internal class Sort
    {
        // <선택정렬>
        // 전체 데이터 중 가장 작은 값부터 하나씩 선택하여 앞으로 옮겨주는 정렬
        // 시간복잡도 -  평균 : O(N^2)     최악 : O(N^2)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  O
        public static void SelectionSort(IList<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j] < list[minIndex]) // 값이 컸을시 작은것과 교환한다.
                        minIndex = j;
                }
                Swap(list, i, minIndex);
            }
        }
        static void Main(string[] args) // 위의 선택정렬을 확인해보자
        {
            Random rnd = new Random();

            List<int> list = new List<int>();

            Console.WriteLine("랜덤 데이터 : ");
            for (int i = 0; i < 20; i++)
            {
                int rand = rnd.Next() % 100;
                Console.WriteLine("{0}", rand);

                list.Add(rand);
                
            }
            SelectionSort(list);
            Console.WriteLine("선택 정렬 결과 : ");
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write("{0}", list[i]);
            }
        }

        // <삽입정렬>
        // 데이터를 하나씩 꺼내어 정렬된 자료 중 적합한 위치에 삽입하여 정렬
        // 시간복잡도 -  평균 : O(N^2)   최악 : O(N^2)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  O
        public static void InsertionSort(IList<int> list)
        {
            for (int i = 0; i < list.Count; i++) // 전체를 반복
            {
                int key = list[i]; // 앞에서부터 중간에 끼워놓을 장치를 만든다. 끼워놓을 장치는 key
                int j;
                for (j = i - 1; j >= 0 && key < list[j]; j--) // 반복하면서
                {
                    list[j + 1] = list[j];// 키값을 밀어넣어준다.
                }
                list[j + 1] = key; 
            }
        }

        // <버블정렬>
        // 서로 인접한 데이터를 비교하여 정렬
        // 작으면 앞으로 크면 뒤로 정렬
        //정렬 시킬때 가장 큰값이 뒤로 올라가는게 있어서 거품이 올라가는거 같다 하여 버블 정렬
        // 시간복잡도 -  평균 : O(N^2)     최악 : O(N^2)  // 정렬들이 다 너무 느려~~
        // 공간복잡도 -  O(1)
        // 안정정렬   -  O
        // 다른 언어에서 가장 많이 쓰는 정렬, 캐시 메모리를 효율적으로 사용할수있고 쉽다.
        public static void BubbleSort(IList<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 1; j < list.Count; j++)
                {
                    if (list[j - 1] > list[j])
                        Swap(list, j - 1, j);
                }
            }
        }


        // <힙정렬>
        // 힙을 이용하여 우선순위가 가장 높은 요소가 가장 마지막 요소와 교체된 후 제거되는 방법을 이용
        // 배열에서 연속적인 데이터를 사용하지 않기 때문에 캐시 메모리를 효율적으로 사용할 수 없어 상대적으로 느림
        // 이론상 완벽하지만 캐시 적중률이 낮기 때문에 컴퓨터가 상대적으로 더 느리게 처리할수 밖에 없다.
        // 시간복잡도 -  평균 : O(NlogN)   최악 : O(NlogN)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  X
        // 캐시 적중률이 낮은 이유는 하나하나 순서대로가 아닌 왔다갔다 확인하기 때문에
        public static void HeapSort(IList<int> list)
        {
            MakeHeap(list);
            for (int i = list.Count - 1; i > 0; i--)
            {
                Swap(list, 0, i);
                Heapify(list, 0, i);
            }
        }

        private static void MakeHeap(IList<int> list)
        {
            for (int i = list.Count / 2 - 1; i >= 0; i--)
            {
                Heapify(list, i, list.Count);
            }
        }

        private static void Heapify(IList<int> list, int index, int size)
        {
            int left = index * 2 + 1;
            int right = index * 2 + 2;
            int max = index;
            if (left < size && list[left] > list[max])
                max = left;
            if (right < size && list[right] > list[max])
                max = right;

            if (max != index)
            {
                Swap(list, index, max);
                Heapify(list, max, size);
            }
        }

        // <병합정렬(MergeSort)>
        // 데이터를 2분할하여 정렬 후 합병
        // 데이터 갯수만큼의 추가적인 메모리가 필요
        // 분할 정복을 통한 정렬 방법(종료 조건이 있어줘야 한다)
        // 시간복잡도 -  평균 : O(NlogN)   최악 : O(NlogN) // 너무 빠르다~!
        // 2분할 하여 정렬하기 때문에 훨씬 빠를수 있다.
        // 다만 병합 정렬은 공간 복잡도가 아주 크다
        // 다른 정렬은 배열 안에서 충분 했지만 , 병합은 sorted list가 필요하기 때문에
        // 배열안에서 충분하지 않다. n개의 데이터를 정렬한다 했을때 n만큼의 sorted list가 필요하다. 때문에 공간 복잡도를 포기해야한다.
        // 공간복잡도 -  O(N) // 병합 정렬은 공간 효율이 좋은 언어들이 많이 쓴다. 메모리의 부담이 적은 언어 일수록 쓸때 시너지가 나온다!@!@
        // 안정정렬   -  O
        public static void MergeSort(IList<int> list, int left, int right)
        {
            if (left == right) return; // 하나짜리 일떄는 더이상 쪼개지 말자! 라는 조건문을 만들어준다.

            int mid = (left + right) / 2; // 중간 위치 확인( 반으로 나누기 위해서) // 계속 반으로 쪼갠다.
            MergeSort(list, left, mid); // 왼쪽 따로
            MergeSort(list, mid + 1, right); // 오른 쪽 따로
            Merge(list, left, mid, right);
        }

        private static void Merge(IList<int> list, int left, int mid, int right)
        {
            List<int> sortedList = new List<int>(); // 더 작은값을 앞에 써야하기 때문에 리스트를 쓴다.
            int leftIndex = left;
            int rightIndex = mid + 1;

            // 분할 정렬된 index를 병합
            while (leftIndex <= mid && rightIndex <= right) // 왼쪽꺼가 전부 소진되거나 오른쪽이 전부 소진될때까지
            {       // left index는 왼쪽 인덱스의 맨처음 right도 마찬가지
                if (list[leftIndex] < list[rightIndex]) // 왼쪽과 오른쪽 비교
                {
                    sortedList.Add(list[leftIndex]); // 왼쪽이 작았다
                    leftIndex++;
                }
                else
                {
                    sortedList.Add(list[rightIndex]); // 오른쪽이 작았을시
                    rightIndex++;
                }

            }

            if (leftIndex > mid)    // 왼쪽 index가 먼저 소진 됐을 경우
            { 
                for (int i = rightIndex; i <= right; i++)
                    sortedList.Add(list[i]);
            }
            else  // 오른쪽 index가 먼저 소진 됐을 경우
            {
                for (int i = leftIndex; i <= mid; i++) // left index가 전부 소진될때까지 넣는다.
                    sortedList.Add(list[i]); // 리스트를 전부 넣는다.
            }

            // 정렬된 sortedList를 list로 재복사
            for (int i = left; i <= right; i++)
            {
                list[i] = sortedList[i - left]; // 갖고 있는 값을 전부 넣어준다.
            }

        }
        

        // <퀵정렬>          @@@@@ C#은 이거씀 @@@@중요@@@@
        // 하나의 피벗을 기준으로 작은값과 큰값을 2분할하여 정렬 
        // 분할 정복을 이용한 정렬이다.
        // 최악의 경우(피벗이 최소값 또는 최대값)인 경우 시간복잡도가 O(N^2)
        // 피벗을 가운데에 놓고 큰 값과 작은 값을 계속 반분할한다. 반분할 하면 다시 피벗을 지정
        // 시간복잡도 -  평균 : O(NlogN)   최악 : O(N^2)
        // 공간복잡도 -  O(1) // 이용을 잘한다면 추가적인 배열을 필요로 하지 않는다.
        // 피벗을 기준을 잡고 왼쪽 인덱스와 오른쪽 인덱스를 설정 피벗보다 큰 값이 왼쪽 인덱스에,
        // 피벗보다 작은 값을 오른쪽 인덱스에서 찾을경우 서로 바꿔주는것을 반복,왼쪽과 오른쪽이 교차할때 둘중의 하나의 인덱스와 피벗을 바꿔준다.
        // 안정정렬   -  X
        public static void QuickSort(IList<int> list, int start, int end)
            // 데이터 량이 적을땐(임계치 16개 미만) 삽입 정렬이 더빠름 (함수 호출시간이 길기 떄문에)
        {
            if (start >= end) return;

            int pivot = start;
            int left = pivot + 1;
            int right = end;

            while (left <= right) // 엇갈릴때까지 반복
            {
                // left는 pivot보다 큰 값을 만날때까지, end보다 작을때 까지만
                while (list[left] <= list[pivot] && left < end)
                {
                    left++;
                }
                // right는 pivot보다 작은 값을 만날때까지, start보다 클때 까지만
                while (list[right] >= list[pivot] && right > start)
                {
                    right--;
                }

                if (left < right)     // left 와 right가 엇갈리지 않았다면
                    Swap(list, left, right);
                else    // 엇갈렸다면
                    Swap(list, pivot, right);
            }

            QuickSort(list, start, right - 1); // 분할 정복한다) 분할하여 다시한번 진행한다.
            QuickSort(list, right + 1, end); // 오른쪽도 마찬가지로 진행
         
            //인트로 소트 쓰는법 (수업관 무관)
            //인트로 소트는 최선의 정렬을모아둔 정렬 알고리즘이다.
            //            List<int> list = new List<int>();
            //            list.Sort();
            // 인트로 소트는 현업에서 자주 사용하게 될것
        }
        
      
        private static void Swap(IList<int> list, int left, int right)
        {
            int temp = list[left];
            list[left] = list[right];
            list[right] = temp;
        }
    }
}