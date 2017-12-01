using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ZX_Screen
{
    public partial class FormMain : Form
    {
        string Locate;
        public FormMain()
        {
            InitializeComponent();
            Locate = "C:\\";
            ReadDir();
        }

        void ReadDir()
        {
            toolStripTextBox1.Text = Locate;
            Explorer.Items.Clear();
            foreach (string folder in Directory.GetDirectories(Locate))
            {
                ListViewItem item = new ListViewItem(Path.GetFileName(folder));
                item.ImageIndex = 0;
                item.SubItems.Add("Folder");
                Explorer.Items.Add(item);
            }
            foreach (string file in Directory.GetFiles(Locate))
            {
                if (Path.GetExtension(file).ToLower() == ".scr")
                {
                    ListViewItem item = new ListViewItem(Path.GetFileNameWithoutExtension(file));
                    item.ImageIndex = 1;
                    item.SubItems.Add("SCR");
                    Explorer.Items.Add(item);
                }
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Открывание папки или файла
        private void Explorer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Explorer.SelectedItems.Count < 1) return;
            ListViewItem item = Explorer.SelectedItems[0];
            if (item.SubItems[1].Text == "Folder")
            {
                if (Locate.Length > 3) Locate += "\\";
                Locate += item.Text;
                ReadDir();
            }
            if (item.SubItems[1].Text == "SCR")
            {
                FormView view = new FormView(Locate + "\\" + item.Text + ".scr");
                view.ShowDialog();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            вверхToolStripMenuItem_Click(null, null);
        }

        private void вверхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Path.GetDirectoryName(Locate) != null)
            {
                Locate = Path.GetDirectoryName(Locate);
                ReadDir();
            }
        }

        private void Explorer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Explorer_MouseDoubleClick(null, null);
            if (e.KeyCode == Keys.Back) вверхToolStripMenuItem_Click(null, null);
        }
    }
}
