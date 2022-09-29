using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace MyUtils.Case
{
    /// <summary>
    /// 反射
    /// </summary>
    public class ReflectionDemo
    {
        public ReflectionDemo()
        {
            Type type = typeof(Entity.brxx);    
            Console.WriteLine(type.Name);
            Console.WriteLine(type.FullName);
            Console.WriteLine(type.IsClass);
            Console.WriteLine("-----------------------");
            FieldInfo[] fieldinfo = type.GetFields();
            foreach (FieldInfo item in fieldinfo)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("-----------------------");
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (PropertyInfo item in propertyInfos)
            {
               Console.WriteLine(item.Name);
            }
            Console.WriteLine("-----------------------");
            MethodInfo[] methodInfo = type.GetMethods();
            foreach (MethodInfo item in methodInfo)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
