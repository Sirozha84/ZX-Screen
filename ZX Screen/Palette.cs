using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ZX_Screen
{
    static class Palette
    {
        static byte Preset;
        static Color[,] Col;

        //Инициализация палитр
        public static void Init()
        {
            Preset = Properties.Settings.Default.Palette;
            Col = new Color[,]
            {
                { Color.FromArgb(0, 0, 0), Color.FromArgb(0, 0, 206), Color.FromArgb(206, 0, 0), Color.FromArgb(206, 0, 206),
                  Color.FromArgb(0, 203, 0), Color.FromArgb(0, 203, 206), Color.FromArgb(206, 203, 0), Color.FromArgb(206, 203, 206),
                  Color.FromArgb(0, 0, 0), Color.FromArgb(0, 0, 255), Color.FromArgb(255, 0, 0), Color.FromArgb(255, 0, 255),
                  Color.FromArgb(0, 251, 0), Color.FromArgb(0, 251, 255), Color.FromArgb(255, 251, 0), Color.FromArgb(255, 251, 255)},
                { Color.FromArgb(0, 0, 0), Color.FromArgb(11, 11, 114), Color.FromArgb(134, 31, 31), Color.FromArgb(145, 42, 145),
                  Color.FromArgb(59, 161, 59), Color.FromArgb(71, 173, 174), Color.FromArgb(193, 192, 90), Color.FromArgb(205, 203, 205),
                  Color.FromArgb(0, 0, 0), Color.FromArgb(14, 14, 142), Color.FromArgb(165, 38, 38), Color.FromArgb(180, 52, 180),
                  Color.FromArgb(73, 199, 73), Color.FromArgb(88, 213, 215), Color.FromArgb(239, 237, 12), Color.FromArgb(254, 252, 254)},
                { Color.FromArgb(0, 0, 0), Color.FromArgb(23, 23, 23), Color.FromArgb(61, 61, 61), Color.FromArgb(85, 85, 85),
                  Color.FromArgb(119, 119, 119), Color.FromArgb(142, 142, 142), Color.FromArgb(180, 180, 180), Color.FromArgb(204, 204, 204),
                  Color.FromArgb(0, 0, 0), Color.FromArgb(29, 29, 29), Color.FromArgb(76, 76, 76), Color.FromArgb(105, 105, 105),
                  Color.FromArgb(147, 147, 147), Color.FromArgb(176, 176, 176), Color.FromArgb(223, 223, 223), Color.FromArgb(252, 252, 252)},
                { Properties.Settings.Default.Col00, Properties.Settings.Default.Col01, Properties.Settings.Default.Col02, Properties.Settings.Default.Col03,
                  Properties.Settings.Default.Col04, Properties.Settings.Default.Col05, Properties.Settings.Default.Col06, Properties.Settings.Default.Col07,
                  Properties.Settings.Default.Col10, Properties.Settings.Default.Col11, Properties.Settings.Default.Col12, Properties.Settings.Default.Col13,
                  Properties.Settings.Default.Col14, Properties.Settings.Default.Col15, Properties.Settings.Default.Col16, Properties.Settings.Default.Col17 }
            } ;
        }

        /// <summary>
        /// Инициализация палитры по умолчанию
        /// </summary>
        /// <param name="col"></param>
        public static void GetPal(ref Color[] col)
        {
            col = new Color[16];
            for (int i = 0; i < 15; i++)
                col[i] = Col[Preset, i];
        }

        /// <summary>
        /// Инициализация заданной палитры
        /// </summary>
        /// <param name="col"></param>
        /// <param name="num"></param>
        public static void GetPal(ref Color[] col, byte num)
        {
            Preset = num;
            GetPal(ref col);
            Properties.Settings.Default.Save();
        }
    }
}
