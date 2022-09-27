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
    public class DelegateDemo
    {
        List<Students> StudentsList = new Students().GetStudents();
        public  DelegateDemo()
        {
            List<Students> StudentsList = new Students().GetStudents();
            StudentsList = Filter(StudentsList, sex);
            foreach (var item in StudentsList)
            {
               item.toString();
            }
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
