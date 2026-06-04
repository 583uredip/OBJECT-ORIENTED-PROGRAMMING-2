using System;

using System.Collections.Generic;

using System.ComponentModel;

using System.Data;

using System.Drawing;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using System.Windows.Forms;

namespace Lab_Final_Opp2

{

    public partial class Form1 : Form

    {

        int playerScore = 0;

        int computerScore = 0;

        int count = 0;

        int currentGuess = 1;

        public Form1()

        {

            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)

        {

            

        }

        private void label5_Click(object sender, EventArgs e)

        {
            
        }

        private void button3_Click(object sender, EventArgs e)

        {

            Application.Exit();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)

        {

        }

        private void button1_Click(object sender, EventArgs e)

        {

        }

        private void Form1_Load(object sender, EventArgs e)

        {

            label1.Text = currentGuess.ToString();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)

        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }

}

