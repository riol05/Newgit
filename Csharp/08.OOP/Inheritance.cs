﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.OOP
{
    /****************************************************************
      * 상속 (Inheritance)
      * 
      * 부모클래스의 모든 기능을 가지는 자식클래스를 설계하는 방법
      * is-a 관계 : 부모클래스가 자식클래스를 포함하는 상위개념일 경우 상속관계가 적합함
      ****************************************************************/

    // <상속>
    // 부모클래스를 상속하는 자식클래스에게 부모클래스의 모든 기능을 부여
    // class 자식클래스 : 부모클래스

    public class Person
    {
        protected string name;

        public Person(string name)
        {
            this.name = name;
        }

        public void SayName()
        {
            Console.WriteLine("이름은 {0} 입니다.", name);
        }
    }

    public class Student : Person // 바로 상속이 된다. : 만 써도 상속
    {
        private int id;

        public Student(string name, int id) : base(name)
        {
            this.id = id;
        }

        public void Study()
        {
            Console.WriteLine("{0} 학생이 공부함", name);
        }
    }

    public class Worker : Person
    {
        public Worker(string name) : base(name)
        {

        }

        public void Work()
        {
            Console.WriteLine("{0} 근무자가 일을 함", name);
        }
    }


    public static class Inheritance
    {
        public static void Test()
        {
            Person person = new Person("Kim");
            Student student = new Student("Lee", 1);
            Worker worker = new Worker("Park");

            // 부모클래스 Person을 상속한 자식클래스는 모두 부모클래스의 기능을 가지고 있음
            person.SayName();
            student.SayName();
            worker.SayName();

            // 자식클래스는 부모클래스의 기능에 자식만의 기능을 더욱 추가하여 구현 가능
            student.Study();
            worker.Work();

            // 부모클래스에 자식 인스턴스를 담아둘 수 있음
            Person studentInPerson = new Student("Choi", 2);
            Person workerInPerson = new Worker("Jung");

            // 자식클래스는 부모클래스의 모든 기능이 있기 때문에 부모의 기능 사용 가능
            studentInPerson.SayName();
            workerInPerson.SayName();

            // 부모클래스에 담은 자식 인스턴스는 자식 인스턴스만의 기능을 사용할 수 없음
            // studentInPerson.Study();		// error : studentInPerson은 Person에 담겨 있어 Study가 없음
            // workerInPerson.Work();		// error : workerInPerson은 Person에 담겨 있어 Worker가 없음

            // is : 담겨있는 인스턴스가 형변환이 가능한지 확인
            if (studentInPerson is Student) // 자식으로 형변환이 가능한지 확인한다 가능하면 True 불가능하면 false
            {
                Console.WriteLine("{0} 인스턴스는 Student로 형변환 가능");
                Student isStudent = (Student)studentInPerson;
            }
            else // false 일때
            {
                Console.WriteLine("{0} 인스턴스는 Student로 형변환 불가");
            }

            if (studentInPerson is Worker)
            {
                Console.WriteLine("{0} 인스턴스는 Worker로 형변환 가능");
                Worker isStudent = (Worker)studentInPerson;
            }
            else
            {
                Console.WriteLine("{0} 인스턴스는 Worker로 형변환 불가");
            }

            // as : 담겨있는 인스턴스가 형변환이 가능하다면 형변환 결과를 불가하다면 null을 반환
            Student asStudent = studentInPerson as Student;     // 형변환
            Worker asWorker = studentInPerson as Worker;        // null 반환
            if (asStudent == null)
            {
                // is나 as 로 검증 해는
            }
        }
    }
}