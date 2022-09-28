using MyUtils.Entity;
using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUtils.Case
{
    public delegate bool MyDel(Students str);
    public delegate void degTest1(string str);
    public class DelegateDemo
    {
        public DelegateDemo()
        {
            degTest1 degTest1 = func1;
            degTest1("888");

            Action action1 = func2;
            action1();

            Action<string> action2 = func1;
            action2("999");

            Action<string, int> action3 = func3;
            action3("test", 2);

            Func<string> fun1 = func4;
            fun1();

            Func<string, string> fun2 = func5;
            fun2("88");



            List<Students> StudentsList = new Students().GetStudents();
            StudentsList = Filter(StudentsList, sex);
            foreach (var item in StudentsList)
            {
                item.toString();
            }

            Console.WriteLine("---------------------");

            Students students = new Students();
            Students[] arrStud = students.GetStudents().ToArray();
            Sort(arrStud, ageCompare);
            for (int i = 0; i < arrStud.Length; i++)
            {
                arrStud[i].toString();
            }
        }

        private bool ageCompare(Students s1, Students s2)
        {
            return s1.Age > s2.Age;
        }

        public static void Sort<T>(T[] data, Func<T, T, bool> compare)
        {
            bool swapped ;
            do
            {
                swapped = false;
                for (int i = 0; i < data.Length - 1; i++)
                {
                    if (compare(data[i], data[i + 1]))
                    {
                        T temp = data[i];
                        data[i] = data[i + 1];
                        data[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }


        private void func1(string str)
        {
            Console.WriteLine("func1:" + str);

        }

        private void func2()
        {
            Console.WriteLine("func2:");
        }

        private void func3(string str, int i)
        {
            Console.WriteLine("func3:" + str + i);

        }

        private string func4()
        {
            return "func4:";
        }
        private string func5(string str)
        {
            return "func4:" + str;
        }
        private bool sex(Students s)
        {
            return s.Sex == "女";
        }
        public List<Students> Filter(List<Students> students, MyDel myDel)
        {
            List<Students> StudentsList = new List<Students>();
            foreach (var item in students)
            {
                if (myDel(item))
                {
                    StudentsList.Add(item);
                }
            }
            return StudentsList;
        }
    }
}
