using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using _3DGrafika.GeometrijskoTijelo;
using _3DGrafika.Matrica;

namespace _3DGrafika
{
    public partial class Form1 : Form
    {
        private static bool RUN = true;
        private static Graphics g;

        Matrica.Matrica m1 = new Matrica.Matrica(new double[,]
        {
                {3, 0, 0, 500 },
                {0, 3, 0, 500 },
                {0, 0, 3, 0 },
                {0, 0, 0, 1 },
        });

        private ObjektUProstoru koordinatniSustavObjektUProstoru = new ObjektUProstoru(new double[][]
            {
                new double[] {-500, 0, 0, 0},
                new double[] {500, 0, 0, 0},
                new double[] {0, 0, 0, 0},
                new double[] {0, 500, 0, 0},
                new double[] {0, -500, 0, 0},
                new double[] {0, 0, 0, 0},
                new double[] {0, 0, +500, 0},
                new double[] {0, 0, -500, 0},
                new double[] {0, 0, 0, 0},
            }
        );

        private ObjektUProstoru kucaObjektUProstoru = new ObjektUProstoru(new double[][]
            {
                new double[] {0, 0, 0, 0},
                new double[] {0, 100, 0, 0},
                new double[] {100, 100, 0, 0},
                new double[] {100, 0, 0, 0},
                new double[] {0, 0, 0, 0},
                new double[] {0, 0, 100, 0},
                new double[] {0, 100, 100, 0},
                new double[] {100, 100, 100, 0},
                new double[] {100, 0, 100, 0},
                new double[] {0, 0, 100, 0},
                new double[] {0, 100, 100, 0},
                new double[] {0, 100, 0, 0},
                new double[] {100, 100, 0, 0},
                new double[] {100, 100, 100, 0},
                new double[] {100, 0, 100, 0},
                new double[] {100, 0, 0, 0},
                new double[] {0, 0, 0, 0},
                new double[] {0, 100, 0, 0},
                new double[] {50, 150, 50, 0},
                new double[] {100, 100, 0, 0},
                new double[] {100, 100, 100, 0},
                new double[] {50, 150, 50, 0},
                new double[] {0, 100, 100, 0},
                new double[] {0, 100, 0, 0},
                new double[] {0, 0, 0, 0},
                new double[] {0, 0, 100, 0},
                new double[] {25, 0, 100, 0},
                new double[] {25, 75, 100, 0},
                new double[] {75, 75, 100, 0},
                new double[] {75, 0, 100, 0},
            }
        );

        Point lastKnownPoint = new Point(0,0);
        private bool kliknul = false;
        private Bitmap bmp;

        Matrica.Matrica kutPrikaza = new Matrica.Matrica();
        

        private Tocka[] kuca;
        private Tocka[] koordinatni;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            kuca = kucaObjektUProstoru.vrhovi3D;
            koordinatni = koordinatniSustavObjektUProstoru.vrhovi3D;
            Show();

            Thread th = new Thread(threadDraw);
            th.Start();
        }

        private void threadDraw()
        {
            RUN = true;
            while (RUN)
            {
                Draw();

                Thread.Sleep(1000/25);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        public void Draw()
        {
            if (pictureBox1.Size.Width <= 0 || pictureBox1.Size.Height <= 0)
                return;
            bmp = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);

            DrawToCanvas(koordinatni, Pens.RosyBrown);
            DrawToCanvas(kuca);

            pictureBox1.Image = bmp;
        }

        public void DrawToCanvas(Tocka[] tocke, Pen p = null)
        {
            if (p == null)
                p = Pens.Black;

            Point[] points = new Point[tocke.Length];

            for (int i = 0; i < tocke.Length; i++)
            {
                var t = tocke[i] * (kutPrikaza);
                t *= m1;
                points[i] = new Point((int)t[0], (int)t[1]);
            }
            g.DrawLines(p, points);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != 0)
            {
                if (kliknul)
                {
                    int deltaX = lastKnownPoint.X - e.X;
                    int deltaY = lastKnownPoint.Y - e.Y;
                    kutPrikaza *= Rotacija.YOsMatrica(deltaX / 1.9);
                    kutPrikaza *= Rotacija.XOsMatrica(deltaY / 1.9);
                    lastKnownPoint = e.Location;
                }
                else
                {
                    lastKnownPoint = e.Location;
                    kliknul = true;
                }
            }
            else
            {
                kliknul = false;
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            kutPrikaza *= Rotacija.YOsMatrica(2);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            kutPrikaza *= Rotacija.XOsMatrica(2);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            kutPrikaza *= Rotacija.YOsMatrica(2);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            kutPrikaza *= Rotacija.XOsMatrica(2);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            RUN = false;
        }
    }
}
