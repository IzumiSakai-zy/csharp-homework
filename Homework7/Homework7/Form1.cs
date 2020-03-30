using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework7
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        double th1 = Math.PI ;
        double th2 =Math.PI;
        double per1 = 0.6;
        double per2 = 0.7;
        private Random rand = new Random();
        private int deepLenth;
        private Int32[] colorIntArray = new Int32[3] { 0,0,0};
        private Color color;
        private Pen pen = new Pen(Color.White,1);
        public Form1()
        {
            InitializeComponent();
        }

        void drawCayletTree(int n,double x0,double y0,double leng,double th)
        {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            drawLine(x0, y0, x1, y1);
            drawCayletTree(n - 1, x1, y1, per1 * leng, th + th1 / this.trackBar1.Value);
            drawCayletTree(n - 1, x1, y1, per2 * leng, th - th2 / this.trackBar1.Value);
        }

        void drawLine(double x0,double y0,double x1,double y1)
        {
            graphics.DrawLine(this.pen, (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.panel1.CreateGraphics();
            graphics.Clear(Color.White);
            try
            {
                drawCayletTree(this.deepLenth, 230, 350, Convert.ToInt32(textBox1.Text), -Math.PI / 2);
           }catch(FormatException )
            {
                this.label9.Text = "抱歉输入错误，请重新输入";
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            deepLenth=2+rand.Next(2, 9);
            this.label3.Text = $"{deepLenth}";
            for (int i= 0; i < 3; i++)
                this.colorIntArray[i] = rand.Next(0, 255);
            this.label4.Text = $"" +
                $"({this.colorIntArray[0]},{this.colorIntArray[1]}，{this.colorIntArray[2]})";
            try
            {
                this.color = Color.FromArgb
                (this.colorIntArray[0], this.colorIntArray[1],this.colorIntArray[2]);
                this.pen.Color = this.color;
            }catch(Exception )
            {
                Console.WriteLine("数组越界异常");
            }
            
        }

        
    }
}
