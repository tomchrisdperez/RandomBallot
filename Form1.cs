using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Forms;

namespace RandomBallot
{
    public partial class Form1 : Form
    {
        Dictionary<int, string> hashMap = new Dictionary<int, string>();
        int i = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            if(!comboBox1.Items.Contains(str)) {
                hashMap.Add(i++, str);
                comboBox1.Items.Add(str);
                comboBox1.Text = str;
            } else {
                MessageBox.Show("You've already added this value into the ComboBox list!","Attention!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hashMap.Clear();
            comboBox1.Items.Clear();
            textBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(comboBox1.Items.Count != 0)
            {
                comboBox1.Items.Remove(hashMap.Last().Value);
                hashMap.Remove(hashMap.Last().Key);
                i--;
                if (comboBox1.Items.Count != 0) comboBox1.Text = hashMap.Last().Value;
                else comboBox1.Text = "";
            }
            else
            {
                MessageBox.Show("The list is NULL!", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int n = 1;
            Random ran = new Random();
            do
            {
                n = ran.Next(comboBox1.Items.Count+1);
            } while (!hashMap.ContainsKey(n));
            textBox2.Text = "Number " + n + " is " + hashMap[n];
            System.GC.Collect();
        }
    }
}
