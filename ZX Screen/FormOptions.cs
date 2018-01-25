using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace ZX_Screen
{
    public partial class FormOptions : Form
    {
        public FormOptions()
        {
            InitializeComponent();
        }

        private void FormOptions_Load(object sender, EventArgs e)
        {
            //Загрузка пропертисов
            comboBoxPal.SelectedIndex = Properties.Settings.Default.Palette;
            PaintButtons();
        }

        //Раскрасска кнопок
        void PaintButtons()
        {
            buttonCol00.BackColor = Palette.GetCol(0);
            buttonCol01.BackColor = Palette.GetCol(1);
            buttonCol02.BackColor = Palette.GetCol(2);
            buttonCol03.BackColor = Palette.GetCol(3);
            buttonCol04.BackColor = Palette.GetCol(4);
            buttonCol05.BackColor = Palette.GetCol(5);
            buttonCol06.BackColor = Palette.GetCol(6);
            buttonCol07.BackColor = Palette.GetCol(7);
            buttonCol10.BackColor = Palette.GetCol(8);
            buttonCol11.BackColor = Palette.GetCol(9);
            buttonCol12.BackColor = Palette.GetCol(10);
            buttonCol13.BackColor = Palette.GetCol(11);
            buttonCol14.BackColor = Palette.GetCol(12);
            buttonCol15.BackColor = Palette.GetCol(13);
            buttonCol16.BackColor = Palette.GetCol(14);
            buttonCol17.BackColor = Palette.GetCol(15);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            Close();
        }

        private const long SHCNE_ASSOCCHANGED = 0x8000000L;
        private const uint SHCNF_IDLIST = 0x0U;
        public static void Associate(string extention, string description, string icon)
        {
            Registry.ClassesRoot.CreateSubKey(extention).SetValue("", Application.ProductName);

            if (Application.ProductName != null && Application.ProductName.Length > 0)
            {
                using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(Application.ProductName))
                {
                    if (description != null)
                        key.SetValue("", description);

                    if (icon != null)
                        key.CreateSubKey("DefaultIcon").SetValue("", ToShortPathName(icon));

                    key.CreateSubKey(@"Shell\Open\Command").SetValue("", ToShortPathName(Application.ExecutablePath) + " \"%1\"");
                }
            }

            SHChangeNotify(SHCNE_ASSOCCHANGED, SHCNF_IDLIST, IntPtr.Zero, IntPtr.Zero);
        }

        [DllImport("shell32.dll", SetLastError = true)]
        private static extern void SHChangeNotify(long wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);

        [DllImport("Kernel32.dll")]
        private static extern uint GetShortPathName(string lpszLongPath, [Out]StringBuilder lpszShortPath, uint cchBuffer);

        private static string ToShortPathName(string longName)
        {
            StringBuilder s = new StringBuilder(1000);
            uint iSize = (uint)s.Capacity;
            uint iRet = GetShortPathName(longName, s, iSize);
            return s.ToString();
        }

        private void buttonAssociacion_Click(object sender, EventArgs e)
        {
            WindowsPrincipal principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            if (principal.IsInRole(WindowsBuiltInRole.Administrator))
            {
                try
                {
                    if (checkBoxSCR.Checked) Associate(".scr", "Изображение ZX Screen", "");
                    if (checkBoxSCR.Checked) Associate(".img", "Изображение ZX Screen", "");
                    MessageBox.Show("Ассоциация выполнена успешно.",
                        Application.ProductName);
                }
                catch
                {
                    MessageBox.Show("Произошла непредвиденная ошибка.",
                        Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Для этого запустите программу с правами администратора.",
                        Application.ProductName);
        }

        private void comboBoxPal_SelectedIndexChanged(object sender, EventArgs e)
        {
            Palette.SetPreset(comboBoxPal.SelectedIndex);
            PaintButtons();
        }

        void SetColor(byte num)
        {
            ColorDialog diag = new ColorDialog();
            if (diag.ShowDialog() == DialogResult.OK)
            {
                if (comboBoxPal.SelectedIndex != 3)
                {
                    //Копируем цвета из текущей палитры в пользовательскую
                    Palette.CopyPal(num);
                    comboBoxPal.SelectedIndex = 3;
                }
                Palette.SetColor(num, diag.Color);
                PaintButtons();
            }
        }

        private void buttonCol00_Click(object sender, EventArgs e) { SetColor(0); }
        private void buttonCol01_Click(object sender, EventArgs e) { SetColor(1); }
        private void buttonCol02_Click(object sender, EventArgs e) { SetColor(2); }
        private void buttonCol03_Click(object sender, EventArgs e) { SetColor(3); }
        private void buttonCol04_Click(object sender, EventArgs e) { SetColor(4); }
        private void buttonCol05_Click(object sender, EventArgs e) { SetColor(5); }
        private void buttonCol06_Click(object sender, EventArgs e) { SetColor(6); }
        private void buttonCol07_Click(object sender, EventArgs e) { SetColor(7); }
        private void buttonCol10_Click(object sender, EventArgs e) { SetColor(8); }
        private void buttonCol11_Click(object sender, EventArgs e) { SetColor(9); }
        private void buttonCol12_Click(object sender, EventArgs e) { SetColor(10); }
        private void buttonCol13_Click(object sender, EventArgs e) { SetColor(11); }
        private void buttonCol14_Click(object sender, EventArgs e) { SetColor(12); }
        private void buttonCol15_Click(object sender, EventArgs e) { SetColor(13); }
        private void buttonCol16_Click(object sender, EventArgs e) { SetColor(14); }
        private void buttonCol17_Click(object sender, EventArgs e) { SetColor(15); }
    }
}
