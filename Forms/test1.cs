﻿using MyUtils.Case;
using MyUtils.Function;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyUtils.Forms
{
    public partial class test1 : Form
    {
        public test1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new DelegateDemo();
        }
    }
}
