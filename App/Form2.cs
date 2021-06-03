using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Math;
using System.Drawing.Drawing2D;

namespace ten_lab
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Paint += new PaintEventHandler(Line);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        static int factorial(int x)
        {
            if (x <= 0) return 1;
            return x * factorial(x - 1);
        }
        double sin(double x, int n)
        {
            double sin = 0;
            for (int i = 1; i < n + 1; i++)
            {
                if (i - 1 % 2 == 0)
                {
                    sin += Pow(x, 2 * i - 1) / factorial(2 * i - 1);
                }
                else
                {
                    sin += (-1) * Pow(x, 2 * i - 1) / factorial(2 * i - 1);
                }
            }
            return sin;
        }
        double cos(double x, int n)
        {
            double cos = 0;
            for (int i = 1; i < n + 1; i++)
            {
                if (i - 1 % 2 == 0)
                {
                    cos += Pow(x, 2 * i - 2) / factorial(2 * i - 2);
                }
                else 
                {
                    cos += (-1) * Pow(x, 2 * i - 2) / factorial(2 * i - 2);
                }
            }
            return cos;
        }
        double atan(double arg, int n)
        {
            double atan = 0;
            if (-1 <= arg && arg <= 1)
            {
                for (int i = 1; i < n + 1; i++)
                {
                    if (i - 1 % 2 == 0)
                    {
                        atan +=  Pow(arg, 2 * i - 1) / (2 * i - 1);
                    }
                    else
                    {
                        atan += Pow(-1, i - 1) * Pow(arg, 2 * i - 1) / (2 * i - 1);
                    }
                }
            }
            else
            {
                if (arg >= 1)
                {
                    atan += PI / 2;
                    for (int i = 0; i < n; i++)
                    {
                        if (i % 2 == 0)
                        {
                            atan -=  ((2 * i + 1) * Pow(arg, 2 * i + 1));
                        }
                        else
                        {
                            atan -= Pow(-1, i) / ((2 * i + 1) * Pow(arg, 2 * i + 1));
                        }
                    }
                }
                else
                {
                    atan -= PI / 2;
                    for (int i = 0; i < n; i++)
                    {
                        if (i % 2 == 0)
                        {
                            atan -= ((2 * i + 1) * Pow(arg, 2 * i + 1));
                        }
                        else
                        {
                            atan -= Pow(-1, i) / ((2 * i + 1) * Pow(arg, 2 * i + 1));
                        }
                    }
                }
            }
            return atan;
        }
        void Line(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;
            Pen pencil = new Pen(Color.Brown, 3);
            g.DrawEllipse(new Pen(Color.Blue, 3), (int)Form1.x1, (int)Form1.y1, 3, 3);
            g.DrawEllipse(new Pen(Color.Blue, 3), (int)Form1.x2, (int)Form1.y2, 3, 3);
            GraphicsState gs;
            gs = g.Save();
            double a = Abs(Form1.x1 - Form1.x2);
            double b = Abs(Form1.y1 - Form1.y2);
            double value = a + b;
            double angle = atan((Form1.y2 - Form1.y1) / (Form1.x1 - Form1.x2), Form1.n);
            double gypotenuza = 0;
            double x = Form1.x1;
            double y = Form1.y1;
            bool flag = false;
            while (flag == false)
            {
                Form1.y1 -= Form1.step * sin(angle, Form1.n);
                Form1.x1 += Form1.step * cos(angle, Form1.n);
                g.DrawEllipse(pencil, (int)Form1.x1, (int)Form1.y1, 1, 1);
                a = Abs(Form1.x1 - Form1.x2);
                b = Abs(Form1.y1 - Form1.y2);
                gypotenuza = Sqrt(Pow((a), 2) + Pow((b), 2));
                if (gypotenuza > value)
                {
                    RectangleF rectf = new RectangleF(150, 0, 250, 250);
                    string output = value.ToString();
                    g.DrawString("Погрешность " + output , new Font("Tahoma", 25), Brushes.Black, rectf);
                    flag = true;
                }
                else
                    value = gypotenuza;
                g.Restore(gs);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
