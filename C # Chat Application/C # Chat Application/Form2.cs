using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace C___Chat_Application
{
    public partial class ButtonLogin : Form
    {
        public ButtonLogin()
        {
            InitializeComponent();
        }

        internal static void PerformClick()
        {
            throw new NotImplementedException();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Region = new Region(gp);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ButtonLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
