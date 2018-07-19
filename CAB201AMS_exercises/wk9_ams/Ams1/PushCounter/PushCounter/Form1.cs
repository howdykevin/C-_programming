using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PushCounter
{
    public partial class Form1 : Form
    {

        int counter = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            counter += 1;
            label2.Text = string.Format("{0} times", counter).ToString();
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            counter = 0;
            label2.Text = string.Format("{0} times", counter).ToString();
            button2.Enabled = false;
        }
    }
}
