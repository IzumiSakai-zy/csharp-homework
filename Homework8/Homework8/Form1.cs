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
    public partial class Form1 : Form
    {
        public List<OrderItem> orderItemsList = new List<OrderItem>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            orderItemsList.Add(new OrderItem(new Order(001, "水果", 4.6), 1, "IzumiSakai", 2));
            orderItemsList.Add(new OrderItem(new Order(002, "大米", 2.5), 2, "IzumiSakai", 6));
            orderItemsList.Add(new OrderItem(new Order(003, "手机", 3999), 3, "IzumiSakai", 5));
            orderItembindingSource.DataSource = orderItemsList;

        }
    }
}
