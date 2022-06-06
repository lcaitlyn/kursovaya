using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursovaya
{
    public partial class Form2 : Form
    {
        public Form2(string name, string date, string text)
        {
            InitializeComponent();
            label1.Text = name;
            label2.Text = date;
            richTextBox1.Text = text;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
