using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework8
{
    public partial class Form2 : Form
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public List<Order> orderList = new List<Order>();

        public Form2()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            orderList.Add(new Order(this.id,this.name,this.price));
           // orderList.Add(new Order(4,"423",454));
            bindingSource1.ResetBindings(false);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            orderList.Add(new Order(001, "水果", 4.6));
            orderList.Add(new Order(002, "大米", 2.5));
            orderList.Add(new Order(003, "手机", 3999));
            bindingSource1.DataSource = orderList;
            textBox1.DataBindings.Add("Text", this, "id");
            textBox2.DataBindings.Add("Text", this, "name");
            textBox3.DataBindings.Add("Text", this, "price");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
