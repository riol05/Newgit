using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SingleTon
{
    /********************************************
     * 디자인 패턴 singleTon 단일체 11/ 28일 방송
     *=========================================
     * 싱글톤 패턴 : 
     * 오직 한개의 클래스 인스턴스만을 갖도록 보장
     * 이에 대한 적역적인 접근점을 제공
     * 
     * 구현 :
     * 1. 전역에서 접근 가능한 인스턴스의 주소를 갖기 위해
     * 데이터 영역 메모리 공간을 활용 (전역변수 , 정적변수 ) // 데이터 영역을 활용해 싱글톤을 만들어주자
     * 2. 정적 변수를 활용하여 캡슐화를 진행
     * 3. 생성자의 접근 권한을 외부에서 생성할수 없도록 제한
     * 3. GetInstnace 함수를 통해 인스턴스에 접근할수 있도록 함
     * 4. instnace 변수는 단 하나만 있도록 유지
     * 
     * 장점 :
     * 1. 전역에서 접근가능한 하나뿐인 존재로 주요 클래스 , 관리자의 역할을함
     * 2. 다른 클래스의 인스턴스들이 데이터를 공유하기 쉬워짐
     * 
     * 단점 :
     * 1. 싱글톤 인스턴스가 너무 많은 책임을 짊어지는 경우를 주의해야함
     * 2. 싱글톤의 남발은 코드 결합도가 높아짐
     *   // 그러니까 싱글톤을 안써도 되면 쓰지말자
     *   // 두개이상 만들어야 하면 쓰면 안됨(단일체이기 때문에)
    ********************************************/
    public class SingleTon<T> where T : new() //일반화 쓰는 이유는 매번 만들면 귀찮으니까
    {
        protected SingleTon() // 단일 객체로(인스턴스를 하나만 만들고 싶다)
                              // 만들고 싶은데 Public을 하면 안되기 때문에 Private로 생성
                              // 하지만 private 일 경우엔 하나도 못만든다.
                              // 때문에 생성자는 외부에서 호출 못하게 Protected 를 사용한다.
        {}

        private static T instance; // 때문에 private인스턴스를 여기에 만들어준다
        public static T GetInstance() // getinstance도 만들어주자 getinstance를 통해 싱글톤을 갖다 쓴다
        {
            if (instance == null)// instance가 null이면
            {
                instance = new T(); // 인스턴스를 만들어준다
            }
            return instance; //그렇지 않으면 그냥 준다
                             //외부에서 쓰고 싶다면 Singleton single1 = SingleTon.GetInstance();를 통해 쓸수가 있다
                             // singleton을 쓸때 getinstance 만 이용하게 되어있다
                             // 때문에 없으면 만들어주고 있으면 그거만 가져오게 되어있기 때문에
                             // Singleton single2 = SingleTon.GetInstance(); 를해도 single1 인스턴스의 값을 그대로 가져온다
        }
    }
    public class Item // 아이템에 싱글톤을 사용하게되면 그 아이템은 하나 밖에 없는 아이템이 되기때문에 싱글톤을 사용하면 안된다!
    {
        public void Use()
        {

        }

    }

    public class Inventory// : SingleTon<Inventory> //일반화 상속하니까 잘 안되는거같다
                          // 그땐 클래스 안에 그대로 넣어주면됨
                          // 상속도 가능
    {

        protected Inventory() { }
        private static Inventory instance;
        public static Inventory GetInstance()
        {
            if (instance == null)
            {
                instance = new Inventory();
            }
            return instance;
        }

        List<Item> items = new List<Item>();
        int gold = 100;
        public void AddItem(Item item)
        {

        }
        public void RemoveItem(Item item)
        {
            items.Remove(item);
        }

        public void AddGold(int amount)
        {
            
        }
        public void spendGold(int amount)
        {

        }
    }

    public class Shop
    {
        Inventory inven = Inventory.GetInstance(); // 똑같다고 봐도 된다.
        public void SellItem(Item item) // 아이템을 사면
        {
            Inventory.GetInstance().spendGold(100); // 돈을쓰고
            Inventory.GetInstance().AddItem(item); // 아이템을 구매
            inven.spendGold(200); // 인벤토리 인스턴스를 이용해 똑같이 사용 가능
        }
    }

    public class Monster
    {
        
        public void Die(Item item)
        {
            Inventory.GetInstance().AddItem(item); // 몬스터가 죽었을때 아이템 추가
            Inventory.GetInstance().AddGold(100); // 골드도 추가
            
        }
    }

    public class Player
    {
        //public static Inventory inven = new Inventory; // static으로 하면 되는거 아냐? 
        // static 만 써주기엔 하나만 유지되는 단일체로 쓰고 싶은건데 static으로 쓰기엔
        // 캡슐화를 위해서 singleTon을 써주는거다
        public void UseItem(Item item)
        {
            item.Use();
            Inventory.GetInstance().RemoveItem(item); // 단일 객체에 접근하도록 도와준다
        }


    }

    public class SoundManager: SingleTon<SoundManager>
    {
        private int masterVolume;
        private int sfxvolume;
        private int bgmVolume;
        private int enviromentVolume;
        private int voiceVolume;

        public void SetMasterVolume(int  volume)
        {
            masterVolume = volume;
        }
        public void Mute()
        {
            masterVolume = 0;
        }
    }

}