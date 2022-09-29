#define IsShowLogs//声明宏执行ShowLogs方法
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyUtils.Case
{
    /// <summary>
    /// 特性
    /// </summary>
    public class AttributeDemo
    {
        public AttributeDemo()
        {
            test();
            ShowLogs("test1");
            ShowLogs("test2");
            ShowLogs("test3");
            ShowLineNumber();
            ShowFilePaht();
            ShowMemberName();
        }

        [Obsolete("该方法已经弃用")]
        public static void test()
        {
            Console.WriteLine("该方法已经弃用");
        }

        [Conditional("IsShowLogs")]
        public static void ShowLogs(string log)
        {
            Console.WriteLine(log);
        }

        /// <summary>
        /// 显示在第几行调用该方法
        /// </summary>
        /// <param name="lineNumber"></param>
        public static void ShowLineNumber([CallerLineNumber] int lineNumber = 0)
        {
            Console.WriteLine(lineNumber);
        }


        /// <summary>
        /// 显示文件路径
        /// </summary>
        /// <param name="lineNumber"></param>
        public static void ShowFilePaht([CallerFilePath] string FilePath = "")
        {
            Console.WriteLine(FilePath);
        }

        /// <summary>
        /// 显示哪个方法调用的
        /// </summary>
        /// <param name="lineNumber"></param>
        public static void ShowMemberName([CallerMemberName] string MemberName = "")
        {
            Console.WriteLine(MemberName);
        }
    }
}
