﻿using System;
using System.Windows.Forms;

namespace MyUtils.Forms
{
    public partial class test1 : Form
    {
        delegate void degTest1(string str);
        public test1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            degTest1 degTest1 = func1; 
            degTest1("888");

            Action action1 = func2;
            action1();

            Action<string> action2= func1;
            action2("999");

            Action<string,int> action3= func3;
            action3("test",2);

            Func<string> fun1 = func4;
            fun1();

            Func<string,string> fun2 = func5;
            fun2("88");
        }

        private void func1(string str)
        {
            Console.WriteLine("func1:" + str);

        }

        private void func2()
        {
            Console.WriteLine("func2:");
        }

        private void func3(string str,int i)
        {
            Console.WriteLine("func3:" + str+i);

        }

        private string func4()
        {
            return "func4:" ;
        }
        private string func5(string str)
        {
            return "func4:"+ str;
        }
    }
}
