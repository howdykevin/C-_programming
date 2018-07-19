using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilesToKm
{
    public partial class Form1 : Form
    {
        double conversion;
        double formula = 1609.344/1000;
        double value;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Enabled = true;
            if (radioButton1.Checked)
            {
               
                bool present = double.TryParse(textBox1.Text, out conversion);
                if (present == false)
                {
                    label2.Text = "Invalid Input";
                }
                else
                {
                    value = conversion * formula;
                    label2.Text = String.Format("Distance in kilometres is {0:0.00}", value).ToString();
                }
                
            }

            if (radioButton2.Checked)
            {
                bool present = double.TryParse(textBox1.Text, out conversion);
                if (present == false)
                {
                    
                    label2.Text = "Invalid input";
                }
                else
                {
                    value = conversion / formula;
                    label2.Text = String.Format("Distance in miles is {0:0.00}", value).ToString();  
                }
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
