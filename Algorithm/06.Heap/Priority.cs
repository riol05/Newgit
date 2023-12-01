using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _06.Heap
{
    internal class Priority

    { /*******************************************
     * 우선 순위 큐
     * 
     * Queue 였다면 하나씩 넣었어야 했지만 우선순위 큐는 한번에 스피드와 이름의 변수를 전부 넣었다.
     * 데이터를 집어 넣을 당시에 우선순위를 설정 해주면 우선 순위가 가장 빠른것부터 출력되게 된다.
     * 우선 순위가 같으면 상황에 따라 다르게 나오게 된다. 순서가 보장되지 않는다.
     * 우선 순위 큐는 들어가 있는 순서가 우선되기 때문에
     * 나중에 큐 안에 있는 숫자를 바꿔준다해도 이미 순서가 정해져 있기 때문에 바뀌지 않는다.
     * 우선 순위 큐는 배열로 보관한다.
     * 배열일때 k번 인덱스에 위치한 노드의 양쪽 자식 노드들이 위치한 인덱스
     * 왼쪽 : 2k +1 // 오른쪽 : 2k +2
     * k번 인덱스의 위치한 노드의 부모 노드의 위치 : (K-1) /2
     * 캐시 적중률이 좋지가 않다. // 대신 삽입 삭제가 미칠듯이 빠르기 떄문에 그정도는 감안o
     * 어차피 캐시 적중률은 100%가 나올일이 드물기 떄문에 캐시 적중률이 낮은 상황에서도 힙은 사용한다.
      ********************************************/
        public enum Tier {Iron , Silver, Gold, Platinum, Diamond };
        // enum 을 쓰면숫자로 1, 2, 3, 4, 5 가 붙은걸 볼수있다. 
        public static void PQ()
        {

            PriorityQueue<string, Tier> pq2 = new PriorityQueue<string, Tier>();

            
            pq2.Enqueue("슬라임", Tier.Gold );
            pq2.Enqueue("드래곤",Tier.Iron);
            pq2.Enqueue("오크", Tier.Diamond);
            pq2.Enqueue("고블린", Tier.Silver);
             // enum에서 넣어둔 순서대로 출력되는걸 볼수있다.
            while (pq2.Count > 0)
            {
                string monsterName = pq2.Dequeue();
                Console.WriteLine(monsterName);
            }
                PriorityQueue<string, int> pq = new PriorityQueue<string, int>();
            

            pq.Enqueue("슬라임", 5);
            pq.Enqueue("드래곤", 100);
            pq.Enqueue("오크", 20);
            pq.Enqueue("고블린", 50);
            while (pq.Count > 0) 
            {
                string monsterName = pq.Dequeue();
                Console.WriteLine(monsterName);
                // 우선순위가 앞인 몬스터부터 오름차순으로 나오게된다
                // 슬라임, 오크 , 고블린, 드래곤 순서대로 나오게 된다.
                // 입력 순서와 상관없이 출력은 우선순위 순서가 낮은 순서대로 나오게됨.
            }
            PriorityQueue<string, int> pq1 = new PriorityQueue<string, int>();

            pq1.Enqueue("슬라임", -1 *5);
            pq1.Enqueue("드래곤", -1 *100); // 오름 차순으로 뽑고 싶을땐 마이너스를 붙여준다.
            pq1.Enqueue("오크", -1 *20);// 이럴시에는 슬라임, 오크 , 고블린, 드래곤이 반대 차순으로 나오게된다.
            pq1.Enqueue("고블린", -1 *50); 

            while (pq1.Count > 0)
            {
                string monsterName = pq1.Dequeue();
                Console.WriteLine(monsterName);
            }
            }
        public void Main(string[] args)
        {
            PQ();
        }
    }
}
