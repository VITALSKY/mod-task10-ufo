using System;
using System.Windows.Forms;

namespace ten_lab
{
    public partial class Form1 : Form
    {
        public static double x1, x2, y1, y2;
        public static double step = 1;
        public static int n = 10;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            int s1 = Int32.Parse(textBox1.Text);
            x1 = Convert.ToDouble(s1);
            int s2 = Int32.Parse(textBox2.Text);
            y1 = Convert.ToDouble(s2);
            int s3 = Int32.Parse(textBox3.Text);
            x2 = Convert.ToDouble(s3);
            int s4 = Int32.Parse(textBox4.Text);
            y2 = Convert.ToDouble(s4);
            Form2 f = new Form2();
            f.Hide();
            f.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }
        
       


    }
}
