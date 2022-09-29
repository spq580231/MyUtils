using MyUtils.Case;
using MyUtils.Forms;
using System;
using System.Windows.Forms;

namespace MyUtils
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Function.DBUtils.GetSqlData("select * from brxx where id= 1009029");
            new DelegateDemo();
            Application.Run(new test1());
          
        }
   
    }
}
