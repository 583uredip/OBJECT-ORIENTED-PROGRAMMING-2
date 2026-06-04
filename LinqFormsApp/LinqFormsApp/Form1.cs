using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqFormsApp
{
    public partial class Form1 : Form
     
    {
        StudentDbDataContext db;
        List<Student> std_list;
        int indx_no = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //StudentDbDataContext db = new StudentDbDataContext();
            // dataGridView1.DataSource = db.Students;
            db = new StudentDbDataContext();
            std_list = db.Students.ToList();
            DisplayData();
        }
        private void DisplayData()
        {
            IDtextBox.Text = std_list[indx_no].Id.ToString();
            NAMEtextBox.Text = std_list[indx_no].name;
            GENDERtextBox.Text = std_list[indx_no].gender;
            AGEtextBox.Text = std_list[indx_no].age.ToString();
            CLASStextBox.Text = std_list[indx_no].standard.ToString();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void NEXTbutton_Click(object sender, EventArgs e)
        {
           if(indx_no<std_list.Count()-1)
            {
                indx_no += 1;
                DisplayData();
            }
           else
            {
                MessageBox.Show("This Is Last Record");
            }
        }

        private void PREVIOUSbutton_Click(object sender, EventArgs e)
        {
            if(indx_no>0)
            {
                indx_no -= 1;
                DisplayData();
            }    
            else
            {
                MessageBox.Show("This Is The 1st Record");
            }
        }
    }
}
