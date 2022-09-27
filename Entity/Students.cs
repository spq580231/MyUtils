using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUtils.Entity
{
    public class Students
    {
        private string name;
        private string sex;
        private int age;
        public Students(string name, string sex, int age)
        {
            this.name = name;
            this.sex = sex;
            this.age = age;
        }
        public Students()
        {
            
        }
        public List<Students> GetStudents()
        {
            List<Students> StudentsList = new List<Students>();
            StudentsList.Add(new Students("张三", "男", 16));
            StudentsList.Add(new Students("李四", "男", 19));
            StudentsList.Add(new Students("王五", "女", 21));
            StudentsList.Add(new Students("顺6", "男", 18));
            StudentsList.Add(new Students("要7", "女", 26));
            return StudentsList;
        }
        public string Name { get => name; set => name = value; }
        public string Sex { get => sex; set => sex = value; }
        public int Age { get => age; set => age = value; }
        public void toString()
        {
            Console.WriteLine($"name:{name},sex:{sex},age:{age}");
        }
    }
}
