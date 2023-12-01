﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._Delegate
{
    /****************************************************************
	 * 대리자 (Delegate)
	 * 
	 * 특정 매개 변수 목록 및 반환 형식이 있는 함수에 대한 참조
	 * 대리자 인스턴스를 통해 함수를 호출 할 수 있음
	 ****************************************************************/

    internal class Delegate // 
    {
        public delegate float DelegateMethod1(float left, float right);
        public delegate void DelegateMethod2(string str);
        public delegate float DelegateMethod3(float left, float right);

        //public delegate void DelegateMethod2(string left, string right); // 매개 변수와 반환형이 일치하지 않으면 똑같지 않으면 오류가 일어난다.
        public float Plus(float left, float right) { return left + right; }
        public float Minus(float left, float right) { return left - right; }
        public float Multi(float left, float right) { return left * right; }
        public float Devide(float left, float right) { return left / right; }

        public static void Messege(string msg) { Console.WriteLine(msg); }

        static void Main(string[] args)
        {
            DelegateMethod1 delegate1;
                delegate1 = Plus; // 30
            Console.WriteLine(delegate1(20,10)); // 변수에 함수를 담아서 함수를 참조하게 만드는 방법이 delegate이다 변수를 함수처럼 쓸수 있게 되는것.
            delegate1 = Minus; // 10
            Console.WriteLine(delegate1(20,10));

            DelegateMethod2 delegate2;
            delegate2 = Messege;
            delegate2("메세지");
            delegate2 = Plus; // error : 반환형과 매개변수가 일치하지 않은 함수 할당 불가
            DelegateMethod3 delegate3;// 델리게이트 3도 1에 있는 함수를 모두 사용가능하다. 하지만 delegate3 변수에 = delegate1 변수를 넣는것은 불가능하다.
            delegate3 = Plus; // 이건 가능하다. 3도 1에 있는 함수를 사용가능하기때문에
          

        }
      
        // <델리게이트 정의>
        // delegate 반환형 델리게이트이름(매개변수들);
        public delegate float DelegateMethod1(float param1, float param2);
        public delegate void DelegateMethod2(string message);
        public delegate float DelegateMethod3(float param1, float param2);


        // <델리게이트 변수 생성>
        // 선언한 델리게이트의 변수 생성
        public static DelegateMethod1 delegate1;
        public static DelegateMethod2 delegate2;
        public static DelegateMethod3 delegate3;

        public static float Plus(float x, float y) { return x + y; }
        public static float Minus(float x, float y) { return x - y; }
        public static float Multi(float x, float y) { return x * y; }
        public static float Divide(float x, float y) { return x / y; }
        public static void Message(string message) { Console.WriteLine(message); }

        public static void Test()
        {
            // <델리게이트 사용>
            // 반환형과 매개변수가 일치하는 함수를 델리게이트 변수에 할당
            // 델리게이트 변수를 함수 호출방법과 동일하게 ()를 통해서 호출
            delegate1 = new DelegateMethod1(Plus);          // 델리게이트 인스턴스 생성
            delegate2 = Message;                            // 간략한 문법의 델리게이트 인스턴스 생성

            delegate1(20, 10);      // Plus(20, 10);		// 연결되어 있는 함수가 호출
            delegate2("메세지");       // Message("메세지");
            delegate1.Invoke(20, 10);                       // Invoke를 통해서 함수의 호출을 진행할 수도 있음
            delegate2.Invoke("메세지");

            delegate1 = Plus;
            Console.WriteLine(delegate1(20, 10));           // output : 30
            delegate1 = Minus;
            Console.WriteLine(delegate1(20, 10));           // output : 10
            delegate1 = Multi;
            Console.WriteLine(delegate1(20, 10));           // output : 200
            delegate1 = Divide;
            Console.WriteLine(delegate1(20, 10));           // output : 2

            // delegate2 = Plus;							// error : 반환형과 매개변수가 일치하지 않은 함수 할당 불가
            // delegate3 = delegate1;						// error : 델리게이트간의 할당은 같은 형식만 가능


        }
    }
}