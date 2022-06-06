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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        Portal portal = new Portal();

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Поле пустое");
                return;
            }
            else
            {
                if (portal.getLen() > 4)
                    MessageBox.Show("Больше добавить нельзя! (макс 5)");
                else
                {
                    portal.addSection(textBox1.Text);
                    listBox1.Items.Add(portal.getSectionName(portal.getLast()));
                    label4.Text = "Добавлен " + portal.getSectionName(portal.getLen() - 1);
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (portal.getLast() == -1)
                MessageBox.Show("Пусто!");
            else
            {
                label4.Text = "Удалён " + portal.getSectionName(portal.getLen() - 1);
                listBox1.Items.RemoveAt(portal.getLast());
                portal.deleteSection();
                listBox2.Items.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (portal.getLen() == 0)
                MessageBox.Show("Добавьте раздел!");
            else if (listBox1.SelectedIndex == -1)
                MessageBox.Show("Выберите раздел!");
            else
            {
                listBox2.Items.Clear();
                if (portal.openSection(listBox1.SelectedIndex) == null)
                    label4.Text = "Открыт " + portal.getSectionName(listBox1.SelectedIndex) + "[" + portal.getCurrent() + "]" + ", но там пусто(\nНаверное, нужно что-нибудь добавить сперва";
                else
                {
                    listBox2.Items.AddRange(portal.openSection(listBox1.SelectedIndex).Split());
                    label4.Text = "Открыт " + portal.getSectionName(listBox1.SelectedIndex) + "[" + portal.getCurrent() + "]";
                }
                
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
             if (textBox1.Text == "" || dateTimePicker1.Text == "" || textBox3.Text == "")
             {
                 MessageBox.Show("Введите текст");
                 return;
             }
             else if (portal.getCurrent() == -1)
             {
                MessageBox.Show("Откройте раздел!");
             }
             else
             {
                listBox2.Items.Clear();
                portal.addNews(textBox2.Text, dateTimePicker1.Value.ToShortDateString().ToString(), textBox3.Text);
                label4.Text = "Добавлена новая тема: " + textBox2.Text;
                listBox2.Items.AddRange(portal.openSection(listBox1.SelectedIndex).Split(';'));
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (portal.getCurrent() == -1)
            {
                MessageBox.Show("Чтобы удалить, откройте раздел!");
            }
            else if (portal.getLen() == 0)
            {
                MessageBox.Show("Чтобы удалить, добавьте раздел!");
            }
            else if (portal.getNewsLen() == 0)
            {
                MessageBox.Show("Чтобы удалить, добавьте тему!");
            }
            else
            {
                label4.Text = "Удалена тема: " + portal.getLastTitle();
                portal.deleteNews();
                listBox2.Items.Clear();
                if (portal.getNewsLen() != 0)
                    listBox2.Items.AddRange(portal.openSection(listBox1.SelectedIndex).Split(';'));
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (portal.getCurrent() == -1)
            {
                MessageBox.Show("Чтобы читай, откройте раздел!");
            }
            else if (portal.getLen() == 0)
            {
                MessageBox.Show("Чтобы читать, добавьте раздел!");
            }
            else if (portal.getNewsLen() == 0)
            {
                MessageBox.Show("Чтобы читать, добавьте тему!");
            }
            else if (listBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Чтобы читать, выберите тему!");
            }
            else
            {
                Form2 form2 = new Form2(portal.getTitle(listBox2.SelectedIndex), portal.getDate(listBox2.SelectedIndex), portal.getText(listBox2.SelectedIndex));
                form2.Text = portal.getTitle(listBox2.SelectedIndex);
                form2.Show();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (portal.getCurrent() == -1)
            {
                MessageBox.Show("Чтобы читай, откройте раздел!");
            }
            else if (portal.getLen() == 0)
            {
                MessageBox.Show("Чтобы читать, добавьте раздел!");
            }
            else if (portal.getNewsLen() == 0)
            {
                MessageBox.Show("Чтобы читать, добавьте тему!");
            }
            else if (listBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Чтобы читать, выберите тему!");
            }
            else if (textBox1.Text == "" || dateTimePicker1.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Введите текст");
            }
            portal.setTitle(textBox2.Text, listBox2.SelectedIndex);
            portal.setDate(dateTimePicker1.Value.ToShortDateString().ToString(), listBox2.SelectedIndex);
            portal.setText(textBox3.Text, listBox2.SelectedIndex);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Общее число новостей: " + portal.getFullLen().ToString());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Общее число: " + portal.getCurrentLen().ToString());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (portal.getLen() == 0)
            {
                MessageBox.Show("Нечего сохранять");
                return;
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            System.IO.File.WriteAllLines(filename, listBox1.Items.Cast<string>());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (portal.getLen() == 0)
            {
                MessageBox.Show("Нечего сохранять");
                return;
            }
            else if (portal.getCurrent() == -1)
            {
                MessageBox.Show("Нечего сохранять");
                return;
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            System.IO.File.WriteAllLines(filename, listBox2.Items.Cast<string>());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                string file = System.IO.File.ReadAllText(filename);
                string[] files = file.Split('\n');
                foreach (string s in files)
                {
                    portal.addSection(s);
                    listBox1.Items.Add(s);
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (portal.getLen() == 0)
            {
                MessageBox.Show("Добавьте раздел!");
                return;
            }
            else if (portal.getCurrent() == -1)
            {
                MessageBox.Show("Откройте раздел!");
                return;
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                string file = System.IO.File.ReadAllText(filename);
                string[] files = file.Split('\n');
                foreach (string s in files)
                {
                    portal.addSection(s);
                    listBox2.Items.Add(s);
                }
            }
        }
    }
}
