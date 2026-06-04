using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1_st_gui_class
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
        string tex1, text2, text3;

        private void button1_Click(object sender, EventArgs e)
        {
            guna2ComboBox1.Items.Add(textBox1);
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            MessageBox.Show(e.ClickedItem.Text);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show(dateTimePicker1.Value.ToShortDateString());
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(guna2CheckBox1.Checked==true)
            {
                tex1 = guna2CheckBox1.Text;
            }
            else if(guna2CheckBox1.Checked==false)
            {
                tex1 = "";
            }
           if(guna2CheckBox2.Checked==true)
            {
                text2 = guna2CheckBox2.Text;
            }
           else if(guna2CheckBox2.Checked==false)
            {
                text2 = "";
            }
            if (guna2CheckBox3.Checked == true)
            {
                text3 = guna2CheckBox3.Text;
            }
            else if (guna2CheckBox3.Checked == false)
            {
                text3 = "";
            }
            MessageBox.Show("Your selected subject are" + tex1 + " " + text2 + "" + text3);
        }
        
    }
}
