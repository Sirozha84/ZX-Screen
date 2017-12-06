﻿using System;
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
            checkBoxSCR.Checked = Properties.Settings.Default.FilesSCR;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.FilesSCR != checkBoxSCR.Checked)
            {
                Properties.Settings.Default.FilesSCR = checkBoxSCR.Checked;
                //Тут делаем самое страшное...
                FILE_EXTENSION = ".scr";
                if (checkBoxSCR.Checked)
                    Associate("Изображение ZX Screen", "");
                else
                    Remove();
            }
            Properties.Settings.Default.Save();
            Close();
        }


        private static string FILE_EXTENSION;
        private const long SHCNE_ASSOCCHANGED = 0x8000000L;
        private const uint SHCNF_IDLIST = 0x0U;

        public static void Associate(string description, string icon)
        {
            Registry.ClassesRoot.CreateSubKey(FILE_EXTENSION).SetValue("", Application.ProductName);

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

        public static bool IsAssociated
        {
            get { return (Registry.ClassesRoot.OpenSubKey(FILE_EXTENSION, false) != null); }
        }

        public static void Remove()
        {
            Registry.ClassesRoot.DeleteSubKeyTree(FILE_EXTENSION);
            Registry.ClassesRoot.DeleteSubKeyTree(Application.ProductName);
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

    }
}
