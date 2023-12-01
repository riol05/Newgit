﻿using System;

namespace _01._DataType
{
    internal class Program
    {
		static void Main(string[] args)
		{
			/**************************************************************
			 * 자료형 (Data Type)
			 * 
			 * 자료(데이터)의 형태를 지정
			 * 데이터가 메모리에 저장되는 형태와 처리되는 방식을 명시하는 역할
			 * 0과 1만으로 구성된 컴퓨터에게 여러 형태의 자료를 저장하기 위함
			 **************************************************************/

			// 자료형 종류
			// <논리형>
			// bool		(논리형 자료)			: true, false
			// 
			// <정수형>
			// byte		(1byte 부호없는 정수)		:     0	~ 255
			// int		(4byte 부호있는 정수)		: -2^31	~ 2^31 - 1
			// uint		(4byte 부호없는 정수)		:     0	~ 2^32 - 1 unsigned int 가 uint로 바뀜
			// long		(8byte 부호있는 정수)		: -2^63	~ 2^63 - 1
			// ulong	(8byte 부호없는 정수)		:     0	~ 2^64 - 1
			// 
			// <부동소수점형>
			// float	(4byte 부동소수)			: +-1.5e-45  ~ +-3.4e38
			// double	(8byte 부동소수)			: +-5.0e-324 ~ +-1.7e308
			// 
			// <문자형>
			// char		(16비트 유니코드)			: 'a', 'b', '한' ...	//여러 다른 다라의 언어도 사용가능 <-> c++에선 아스키코드
			// string	(유니코드 문자열)			: "abcd", "감자", ...
			char a = '한'; // 이 가능하다 // 유니코드로 쓰기 때문아

            /*******************************************************************
			 * 변수 (variable)
			 * 
			 * 데이터를 저장하기 위해 프로그램에 의해 이름을 할당받은 메모리 공간
			 * 데이터를 저장할 수 있는 메모리 공간을 의미하며, 저장된 값은 변경 가능
			 *******************************************************************/
            // <변수 선언 및 초기화>
            // 자료형의 선언하고 빈칸 뒤에 변수이름을 작성하여 변수 선언
            // 변수 선언과 동시에 초기화 과정을 진행할 수 있음
            int intValue = 10;                  // int 자료형의 이름이 inValue인 변수에 10의 데이터를 담아 메모리에 보관
            float floatValue;                   // float 자료형의 이름이 floatValue인 변수를 선언하지만 값을 보관하지 않음
                                                // int intValue;					// error : 같은 이름의 변수는 사용 불가
                                                // Console.WriteLine(floatValue);	// error : 선언한 변수에 값을 초기화하기 전까지 사용 불가

            // <변수에 데이터 저장>
            // {변수}를 좌측값으로 배치
            intValue = 5;                       // intValue 변수에 5의 데이터 저장
            floatValue = 1.2f;                  // floatValue 변수에 1.2f 데이터 초기화
            Console.WriteLine("intValue 변수에 보관된 데이터는 {0}", intValue);
            Console.WriteLine("floatValue 변수에 보관된 데이터는 {0}", floatValue);

            // <변수의 데이터 불러오기>
            // {변수}를 우측값으로 배치
            // {변수}를 데이터가 필요한 곳에 배치
            int otherIntValue = intValue;       // otherIntValue 변수에 intValue 변수에 있는 데이터(5)를 불러와서 저장
            Console.WriteLine("intValue 변수에 보관된 데이터는 {0}", otherIntValue);       // 콘솔에서 데이터 불러와서 출력


            /*******************************************************************
			 * 상수 (Constant)
			 * 
			 * 프로그램이 실행되는 동안 변경할 수 없는 데이터
			 * 프로그램에서 값이 변경되기를 원하지 않는 데이터가 있을 경우 사용
			 * 데이터에 불러오기만 가능
			 *******************************************************************/

            // <상수 선언 및 초기화>
            // 변수 선언 앞에 const 키워드를 추가하여 상수 선언
            const int MAX = 200;        // MAX 상수 변수를 선언하고 초기화
            Console.WriteLine("MAX 상수에 보관된 데이터는 {0}", MAX);
            // const int MIN;			// error : 상수는 초기화 없이 사용불가
            // MAX = 20;				// error : 상수의 데이터는 변경 불가


            /*******************************************************************
			 * 형변환 (Casting)
			 * 
			 * 데이터를 선언한 자료형에 맞는 형태로 변환하는 작업
			 * C#의 자료형은 엄격하게 관리되기에 다른 자료형의 데이터를 저장 불가
			 * 다른 자료형의 데이터를 저장하기 위해선 형변환 과정을 거쳐야하며,
			 * 이 과정에서 보관할 수 없는 데이터는 버려짐
			 *******************************************************************/

            // C#은 자료형은 엄격하게 관리 되기 때문에 int a = 1.2; 같은 다른 자료형의 데이터를 저장하지 않는다. 때문에 int a = (int) 1.2; 자료형을 변환해야 들어간다.
            // C#은 bool a = 1 이나 0으로 나타낼수 없다 무조건 true나 false로
            // <형변환 진행>
            // 변환할 데이터의 앞에 변환할 자료형을 괄호안에 넣어 형변환 진행
            int iValue = (int)1.2f;         // 형변환을 통해 데이터 변환, 1.2f를 int로 변환한 1이 저장
                                            // iValue = 1.2f;				// error : int 변수에는 float 자료형을 담을 수 없음
            Console.WriteLine("int 변수에 1.2f를 형변환하여 집어넣은 데이터는 {0}", iValue); // 담을수 없는 0.2는 버려짐

            // <자동형 변환>
            // 명시적으로 변환이 가능한 경우 자동으로 형변환이 진행됨
            float fValue = 3;               // 부동소수점형 변수에 정수형 데이터를 넣을 경우 자동형변환 가능
            double dValue = 1.2f;           // double은 float를 포함하는 큰 범위이니 자동형변환 가능 //float 를 double 로 변환 했을때 자료가 사라지지 않으니 변환 가능
            dValue = (float)iValue;         // 일반적으로 변수의 형변환 같은 경우 자동형변환이 가능하다 하더라도 형변환을 적어줌

            // <문자열 변환>
            // 문자열은 단순형변환이 불가능
            // 각 자료형의 Parse를 이용하여 문자열에서 자료형으로 변환
            // Parse를 이용하여 변환이 불가능한 경우 예외처리 발생

            string text = "142";
            // iValue = (int)text;			// error : string 자료형을 정수형 자료형으로 단순형변환은 불가능
            // c++ 은 stoi stof 식으로 문자열을 변환 시켰으나 c#은 Parse로 문자열변환을 시켜준다.
            iValue = int.Parse(text);       // int.Parse를 통해 string 자료형을 int로 변환
            text = "abc";
            //int.TryParse 안되면 바꾸지말고 되면 바꾸고 하는 문자열 변환 
            // iValue = int.Parse(text);	// error : 형변환이 불가능한 문자열을 변환하려 하는 경우 예외처리 발생
            string str = iValue.ToString();
            str = fValue.ToString();

            /*******************************************************************
			 * 배열 (Array)
			 * 
			 * 동일한 자료형의 요소들로 구성된 데이터 집합
			 * 인덱스를 통하여 개개의 배열요소(Element)에 접근할 수 있음
			 * 배열의 처음 요소의 인덱스는 0부터 시작함
			 * 정적 할당은 사용하지 않는다. 포인터도 없음 // C#에서 배열은 동적 할당으로만 진행된다./
			 *******************************************************************/

            // <1차원 배열>
            // 1차원 배열의 선언은 자료형뒤에 []괄호를 추가하여 배열로 사용함을 선언
            int[] iArray;                      // 자료형 뒤에 []를 추가             // int 배열 선언
            iArray = new int[10];             //C#에선 동적 할당으로만 만들수있다.              // int 데이터를 10개 가지는 배열 생성
            iArray[0] = 20;                                 // 1차원 배열의 0번째 배열요소에 접근
            float[] fArray = { 1.1f, 2.3f, 3.1f, 4.5f };    // 1차원 배열의 선언과 초기화, 배열의 크기는 초기화한 갯수만큼 자동으로 생성
            //동적할당이 원할때 삭제하는건대 가비지 컬렉터가 삭제하기까지 기다려야되나요					 답은 그렇다. C++은 수동으로 삭제했어야 했지만, C#은 자동으로 가비지 컬렉터가 삭제해준다.

            // <다차원 배열>
            // 다차원 배열의 선언은 자료형뒤에 []괄호를 추가하며, 추가하는 차원수만큼 ','를 추가
            int[,] iMatrix = new int[5, 4];                  //,를 허용해주니 다차원을 사용할땐 콤마를 쓰자       // 2차원 배열 선언
            int[,,] iCube = new int[3, 3, 3];                       // 3차원 배열 선언
            iMatrix[2, 2] = 10;                                     // 2차원 배열의 2x2번째 배열요소에 접근
            float[,] fMatrix = { { 1.1f, 2.3f }, { 3.1f, 4.5f } };  // 2차원 배열의 선언과 초기화, 배열의 크기는 초기화한 갯수만큼 자동으로 생성
        }
    }
}