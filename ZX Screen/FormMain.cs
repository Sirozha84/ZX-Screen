using System;
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
                if (Path.GetExtension(file).ToLower() == ".img")
                {
                    ListViewItem item = new ListViewItem(Path.GetFileNameWithoutExtension(file));
                    item.ImageIndex = 1;
                    item.SubItems.Add("IMG");
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
                if (view.ShowDialog() == DialogResult.Abort)
                    ReadDir();
            }
            if (item.SubItems[1].Text == "IMG")
            {
                FormView view = new FormView(Locate + "\\" + item.Text + ".img");
                if (view.ShowDialog() == DialogResult.Abort)
                    ReadDir();
            }
        }


        private void Explorer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Explorer_MouseDoubleClick(null, null);
            if (e.KeyCode == Keys.Back) вверхToolStripMenuItem1_Click(null, null);
        }

        private void вверхToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Path.GetDirectoryName(Locate) != null)
            {
                Locate = Path.GetDirectoryName(Locate);
                ReadDir();
            }
        }

        private void выборПапкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK) ChangeDir(dialog.SelectedPath);

        }

        void ChangeDir(string dir)
        {
            if (dir.Length < 3) dir += "\\";
            if (Directory.Exists(dir))
            {
                Locate = dir;
            }
            ReadDir();
        }

        private void toolStripButton1_Click(object sender, EventArgs e) { вверхToolStripMenuItem1_Click(null, null); }
        private void toolStripButton2_Click(object sender, EventArgs e) { выборПапкиToolStripMenuItem_Click(null, null); }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ChangeDir(toolStripTextBox1.Text);
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout about = new FormAbout();
            about.ShowDialog();
        }

        private void параметрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOptions options = new FormOptions();
            options.ShowDialog();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Dir = Locate;
            Properties.Settings.Default.Left = Left;
            Properties.Settings.Default.Top = Top;
            Properties.Settings.Default.Width = Width;
            Properties.Settings.Default.Height = Height;
            Properties.Settings.Default.Save();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Locate = Properties.Settings.Default.Dir;
            Left = Properties.Settings.Default.Left;
            Top = Properties.Settings.Default.Top;
            Width = Properties.Settings.Default.Width;
            Height = Properties.Settings.Default.Height;
            if (Locate == "") Locate = Directory.GetCurrentDirectory();
            ReadDir();
        }
    }
}
