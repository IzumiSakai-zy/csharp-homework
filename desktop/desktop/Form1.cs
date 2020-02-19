using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = this.textBox2.Text;
            double a= Double.Parse(this.textBox1.Text);
            double b = Double.Parse(this.textBox3.Text);
            double result=0;
            switch (s)
            {
                case "+":result=a+b;break;
                case "-": result = a - b; break;
                case "*": result = a * b; break;
                case "/":result = a / b; break;
            }
            this.label4.Text = $"{result}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
