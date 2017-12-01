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
        int[] Adresses = {16384,16640,16896,17152,17408,17664,17920,18176,
                          16416,16672,16928,17184,17440,17696,17952,18208,
                          16448,16704,16960,17216,17472,17728,17984,18240,
                          16480,16736,16992,17248,17504,17760,18016,18272,
                          16512,16768,17024,17280,17536,17792,18048,18304,
                          16544,16800,17056,17312,17568,17824,18080,18336,
                          16576,16832,17088,17344,17600,17856,18112,18368,
                          16608,16864,17120,17376,17632,17888,18144,18400,
                          //----------------------------------------------
                          18432,18688,18944,19200,19456,19712,19968,20224,
                          18464,18720,18976,19232,19488,19744,20000,20256,
                          18496,18752,19008,19264,19520,19776,20032,20288,
                          18528,18784,19040,19296,19552,19808,20064,20320,
                          18560,18816,19072,19328,19584,19840,20096,20352,
                          18592,18848,19104,19360,19616,19872,20128,20384,
                          18624,18880,19136,19392,19648,19904,20160,20416,
                          18656,18912,19168,19424,19680,19936,20192,20448,
                          //----------------------------------------------
                          20480,20736,20992,21248,21504,21760,22016,22272,
                          20512,20768,21024,21280,21536,21792,22048,22304,
                          20544,20800,21056,21312,21568,21824,22080,22336,
                          20576,20832,21088,21344,21600,21856,22112,22368,
                          20608,20864,21120,21376,21632,21888,22144,22400,
                          20640,20896,21152,21408,21664,21920,22176,22432,
                          20672,20928,21184,21440,21696,21952,22208,22464,
                          20704,20960,21216,21472,21728,21984,22240,22496};

        public FormView(string File)
        {
            InitializeComponent();
            Text = File;
            byte[] data = System.IO.File.ReadAllBytes(File);
            Bitmap screen = new Bitmap(256, 192);
            //Подготовка поля (на случай если данных меньше чем входит в видеопамять
            byte[] m = new byte[6912];
            for (int i = 6144; i < 6912; i++) m[i] = 56;
            int j = Math.Min(data.Count() - 1, 6913);
            for (int i = 0; i < 6912; i++)
            {
                int a = i;// + (int)numericUpDown2.Value;
                if (a >= 0 & a <= data.Count() - 2)
                    m[i] = data[a];
            }
            //Собственно, рисование
            byte C = 0;
            for (int y = 0; y < 191; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    byte B = m[Adresses[y] - 16384 + x];
                    C = m[6144 + x + (y / 8) * 32];
                    screen.SetPixel(x * 8, y, Pixel(C, (B & 128) == 128));
                    screen.SetPixel(x * 8 + 1, y, Pixel(C, (B & 64) == 64));
                    screen.SetPixel(x * 8 + 2, y, Pixel(C, (B & 32) == 32));
                    screen.SetPixel(x * 8 + 3, y, Pixel(C, (B & 16) == 16));
                    screen.SetPixel(x * 8 + 4, y, Pixel(C, (B & 8) == 8));
                    screen.SetPixel(x * 8 + 5, y, Pixel(C, (B & 4) == 4));
                    screen.SetPixel(x * 8 + 6, y, Pixel(C, (B & 2) == 2));
                    screen.SetPixel(x * 8 + 7, y, Pixel(C, (B & 1) == 1));
                }
            }
            pictureBox1.Image = screen;
        }

        private void FormView_KeyPress(object sender, KeyPressEventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Просмотр в виде картинки
        void ViewScreen()
        {
        }
        //Возвращает цвет точки по атрибуту (в зависимости включен пиксель или нет)
        Color Pixel(byte attr, bool PixelON)
        {
            Color[] palette = {Color.FromArgb(0,0,0), Color.FromArgb(0,0,210), Color.FromArgb(210,0,0), Color.FromArgb(210,0,210),
                               Color.FromArgb(0,210,0), Color.FromArgb(0,210,210), Color.FromArgb(210,210,0), Color.FromArgb(210,210,210),
                               Color.FromArgb(0,0,0), Color.FromArgb(0,0,255), Color.FromArgb(255,0,0), Color.FromArgb(255,0,255),
                               Color.FromArgb(0,255,0), Color.FromArgb(0,255,255), Color.FromArgb(255,255,0), Color.FromArgb(255,255,255)};
            if (PixelON)
                if ((attr & 64) == 0)
                    return palette[attr & 7];
                else
                    return palette[(attr & 7) + 8];
            else
                if ((attr & 64) == 0)
                return palette[(attr & 56) / 8];
            else
                return palette[(attr & 56) / 8 + 8];
        }
    }
}
