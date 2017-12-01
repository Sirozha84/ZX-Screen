using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZX_Screen
{
    public partial class FormView: Form
    {
        //public string File;
        public FormView(string File)
        {
            InitializeComponent();
            Text = File;
        }
    }
}
