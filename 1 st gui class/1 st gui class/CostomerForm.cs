using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1_st_gui_class
{
    public partial class CostomerForm : Form
    {

        string conStr = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=TestDb1;Integrated Security=True";

        public CostomerForm()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM dbo.login_Table";

            using (SqlConnection con = new SqlConnection(conStr))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string select_query = "SELECT * FROM dbo.login_Table " +
                                    "WHERE [User name] LIKE @search";
            using (SqlConnection con = new SqlConnection(conStr))
            using (SqlCommand cmd = new SqlCommand(select_query, con))
            {
                cmd.Parameters.AddWithValue("@search", "%" + guna2TextBox1.Text.Trim() + "%");

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*DataGridViewRow selectRow = dataGridView1.Rows[e.RowIndex];
            guna2TextBox2.Text = selectRow.Cells[1].Value.ToString();
            guna2TextBox3.Text = selectRow.Cells[2].Value.ToString();*/

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectRow = dataGridView1.Rows[e.RowIndex];
            guna2TextBox2.Text = selectRow.Cells[1].Value.ToString();
            guna2TextBox3.Text = selectRow.Cells[2].Value.ToString();
        }

        private void CostomerForm_Load(object sender, EventArgs e)
        {

        }
    }
}