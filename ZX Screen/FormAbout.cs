using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ZX_Screen
{
    partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
            Text = "О " + Application.ProductName;
            label1.Text = Application.ProductName;
            label2.Text = "Версия: " + Application.ProductVersion + " (" + Program.Date + ")";
            label3.Text = "Автор программы: Сергей гордеев";
            linkLabel1.Text = Program.Site;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(Program.Url);
        }
    }
}
