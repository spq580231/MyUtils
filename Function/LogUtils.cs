using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace MyUtils.Function
{
    /// <summary>
    /// 写日志
    /// </summary>
    public static class LogUtils
    {
        static string FileName;
        static LogUtils()
        {
            FileName = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(FileName))
                Directory.CreateDirectory(FileName);
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="type">属性</param>
        /// <param name="a">类别</param>
        /// <param name="b">内容</param>
        private static void Write(string type, string a, string b)
        {
            string filename = string.Format("{0}\\{1}_{2}.log", FileName, DateTime.Now.ToString("yyyy-MM-dd"), type);
            FileStream fs = new FileStream(filename, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            sw.WriteLine(string.Format("{0}==>[{1}]:\r\n{2}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"), a, b));
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        /// <summary>
        /// 消息日志
        /// </summary>
        /// <param name="a">类别</param>
        /// <param name="b">内容</param>
        public static void Info(string a, string b)
        {
            Write("info", a, b);
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="a">类别</param>
        /// <param name="b">内容</param>
        public static void Error(string a, string b)
        {
            Write("error", a, b);
        }

        /// <summary>
        /// 警告日志
        /// </summary>
        /// <param name="a">类别</param>
        /// <param name="b">内容</param>
        public static void Warning(string a, string b)
        {
            Write("warning", a, b);
        }

        /// <summary>
        /// 签到日志
        /// </summary>
        /// <param name="a">类别</param>
        /// <param name="b">内容</param>
        public static void Qiandao(string a, string b)
        {
            Write("qiandao", a, b);
        }

        /// <summary>
        /// 签到日志
        /// </summary>
        /// <param name="a">类别</param>
        /// <param name="b">内容</param>
        public static void QianDao(string a, string b)
        {
            Write("qiandao", a, b);
        }

        /// <summary>
        /// 保存导入失败日志
        /// </summary>
        /// <param name="lb">类别</param>
        /// <param name="inStr">行记录</param>
        public static void SetError(string lb, string inStr)
        {
           
            string filename = FileName + string.Format("\\Error_{0}.txt", lb);
            FileStream fs = new FileStream(filename, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            sw.WriteLine(inStr);
            sw.Flush();
            sw.Close();
            fs.Close();
            
          
        }
       
    }
}
