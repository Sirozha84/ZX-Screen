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
        Color[] Col;
        byte[] Data;
        string[] Files;
        int index;
        byte Type;

        public FormView(string File)
        {
            InitializeComponent();
            Text = File;
            Palette.GetPal(ref Col);
            OpenPicture(File);
            //Получим список файлов в текущей директории, количество файлов и индекс текущего.
            Files = Directory.GetFiles(Directory.GetParent(File).ToString());
            index = Array.IndexOf(Files, File);
        }

        /// <summary>
        /// Открываем файл и рисуем картинку
        /// </summary>
        /// <param name="File">Файл</param>
        void OpenPicture(string File)
        {
            Data = new byte[0];
            try
            {
                Data = System.IO.File.ReadAllBytes(File);
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при загрузке файла " + File,
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Abort;
                Close();
            }
            Type = 1;
            if (Path.GetExtension(File).ToLower() == ".img") Type = 2;
            DrawPicture();
        }

        /// <summary>
        /// Рисуем (перерисовываем) картинку
        /// </summary>
        void DrawPicture()
        {
            Bitmap Screen = new Bitmap(256, 192);
            //Сделаем разные загрузки исходя из типа (на вырост, если повезёт)
            if (Type == 1 | Type == 2)
            {
                //Подготовка поля (на случай если данных меньше чем входит в видеопамять
                byte[,] m = new byte[Type, 6912];
                for (int s = 0; s < Type; s++)
                {
                    for (int i = 6144; i < 6912; i++) m[s, i] = 56;
                    for (int i = 0; i < 6912; i++)
                    {
                        int a = i + s * 6912;
                        if (a >= 0 & a <= Data.Count() - 1)
                            m[s, i] = Data[a];
                    }
                }
                //Составление матрицы точек
                int[,,] Pixels = new int[Type, 256, 192];
                for (int s = 0; s < Type; s++)
                {
                    byte C = 0;
                    for (int y = 0; y < 192; y++)
                    {
                        for (int x = 0; x < 32; x++)
                        {
                            byte B = m[s, Adresses[y] - 16384 + x];
                            C = m[s, 6144 + x + (y / 8) * 32];
                            Pixels[s, x * 8, y] = Pixel(C, (B & 128) == 128);
                            Pixels[s, x * 8 + 1, y] = Pixel(C, (B & 64) == 64);
                            Pixels[s, x * 8 + 2, y] = Pixel(C, (B & 32) == 32);
                            Pixels[s, x * 8 + 3, y] = Pixel(C, (B & 16) == 16);
                            Pixels[s, x * 8 + 4, y] = Pixel(C, (B & 8) == 8);
                            Pixels[s, x * 8 + 5, y] = Pixel(C, (B & 4) == 4);
                            Pixels[s, x * 8 + 6, y] = Pixel(C, (B & 2) == 2);
                            Pixels[s, x * 8 + 7, y] = Pixel(C, (B & 1) == 1);
                        }
                    }
                }
                //Собственно, рисование
                if (Type == 1)
                    for (int x = 0; x < 256; x++)
                        for (int y = 0; y < 192; y++)
                            Screen.SetPixel(x, y, Col[Pixels[0, x, y]]);
                else
                    for (int x = 0; x < 256; x++)
                        for (int y = 0; y < 192; y++)
                            Screen.SetPixel(x, y, AVCol(Pixels[0, x, y], Pixels[1, x, y]));
            }
            pictureBox1.Image = Screen;
        }

        /// <summary>
        /// Возвращает смешанный цвет по двум индексам
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <returns></returns>
        Color AVCol(int i1, int i2)
        {
            return Color.FromArgb((Col[i1].R + Col[i2].R) / 2,
                                  (Col[i1].G + Col[i2].G) / 2,
                                  (Col[i1].B + Col[i2].B) / 2);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Возвращает цвет точки по атрибуту (в зависимости включен пиксель или нет)
        int Pixel(byte attr, bool PixelON)
        {
            if (PixelON)
                if ((attr & 64) == 0)
                    return attr & 7;
                else
                    return (attr & 7) + 8;
            else
                if ((attr & 64) == 0)
                return (attr & 56) / 8;
            else
                return (attr & 56) / 8 + 8;
        }

        private void FormView_KeyDown(object sender, KeyEventArgs e)
        {
            //Листание картинок если их больше одной
            if (Files.Count() < 2) return;
            if (e.KeyCode == Keys.Left | e.KeyCode == Keys.PageUp)
            {
                index--;
                if (index < 0) index = Files.Count() - 1;
                OpenPicture(Files[index]);
                return;
            }
            if (e.KeyCode == Keys.Right | e.KeyCode == Keys.PageDown)
            {
                index++;
                if (index > Files.Count() - 1) index = 0;
                OpenPicture(Files[index]);
                return;
            }
            if (e.KeyCode == Keys.Home)
            {
                index = 0;
                OpenPicture(Files[index]);
                return;
            }
            if (e.KeyCode == Keys.End)
            {
                index = Files.Count() - 1;
                OpenPicture(Files[index]);
                return;
            }

            //Изменение пресета палитры
            if (e.KeyCode == Keys.D1)
            {
                Palette.GetPal(ref Col, 0);
                DrawPicture();
                return;
            }
            if (e.KeyCode == Keys.D2)
            {
                Palette.GetPal(ref Col, 1);
                DrawPicture();
                return;
            }
            if (e.KeyCode == Keys.D3)
            {
                Palette.GetPal(ref Col, 2);
                DrawPicture();
                return;
            }
            if (e.KeyCode == Keys.D4)
            {
                Palette.GetPal(ref Col, 3);
                DrawPicture();
                return;
            }
            Close();
        }
    }
}
