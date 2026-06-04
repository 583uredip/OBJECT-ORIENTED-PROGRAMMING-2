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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        List<Panel> ListPanel = new List<Panel>();
        private void label1_Click(object sender, EventArgs e)
        {

        }
        int seconds = 60;
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            //label1.Text = seconds--.ToString();
            //if (seconds < 0)
            //{
            //    timer1.Stop();
            //    MessageBox.Show("Time's Up");
            //}
            if(progressBar1.Value<100)
            {
                progressBar1.Value += 10;

                label3.Text = progressBar1.Value.ToString() + "%";
            }
            else
            {
                timer1.Stop();
                label2.Text = "Download Completed";
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
       
        private void progressBar1_Click(object sender, EventArgs e)
        {
           
        }
        int index = 0;
        private void Form3_Load(object sender, EventArgs e)
        {
            //timer1.Start();
            ListPanel.Add(panel1);
            ListPanel.Add(panel2);
            ListPanel.Add(panel3);
            ListPanel[index].BringToFront();
        }

        int img_num = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images[img_num++];
            if (img_num == 5)
                img_num = 0;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(index < ListPanel.Count-1)
            ListPanel[++index].BringToFront();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (index > 0)
                ListPanel[--index].BringToFront();
        }
    }
}
