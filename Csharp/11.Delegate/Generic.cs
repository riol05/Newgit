using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._Delegate.Basic
{
    internal class Generic
    {
        public static float Plus(float left, float right) { return left + right; }
        public float Minus(float left, float right) { return left - right; }
        public float Multi(float left, float right) { return left * right; }
        public float Devide(float left, float right) { return left / right; }
        public static int test(double d1, float d2, string d3) { return 0; }
        public static float test2(int value) { }
        public static void test111(string str) { Console.WriteLine(str); }
        public static void test222(int value1, float value2) { }
        public static void test333() { }
        public static float test1234() { return 0; }
        public static void Main1()
        {
            Func<float, float, float> func = Plus;
            Func<double, float, string, int> func1 = test;
            Func<int, float> func3 = test2;
            Func func4 = test1234();
            Action<string> act1 = test111;// void는 Action 델리게이트 사용
            Action<int, float> act2 = test222;
            Action act3 = test333;
            
        }
        // <일반화 델리게이트>
        // 개발과정에서 많이 사용되는 델리게이트의 경우 일반화된 델리게이트를 사용

        // <Func 델리게이트>
        // 반환형과 매개변수를 지정한 델리게이트
        // Func<매개변수들..., 반환형>
        static Func<int, int, int> funcDelegate;
        static int Func1(int left, int right) { return left + right; }

        public static void Test1()
        {
            funcDelegate = Func1;
        }

        // <Action 델리게이트>
        // 반환형이 void 이며 매개변수들만 써주는 델리게이트
        // Action<매개변수들...>
        static Action<string> actionDelegate;
        static void Func2(string str) { Console.WriteLine(str); }

        public static void Test2()
        {
            actionDelegate = Func2;
        }

        // <Predicate 델리게이트>
        // 반환형이 bool, 매개변수가 하나인 델리게이트
        // Func이 더욱 확장성 있기 때문에 잘 사용되지는 않음 (.Net 2.0에서 사용함)
        static Predicate<string> predicateDelegate;
        static bool Func3(string str) { return str.Contains(' '); }
        public static void Test3()
        {
            predicateDelegate = Func3;
        }
    }
}
