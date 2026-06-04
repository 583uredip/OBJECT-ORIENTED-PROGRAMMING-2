using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _1_st_gui_class
{
    public partial class MainWindow : Form
    {
        string conStr = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=TestDb;Integrated Security=True";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string query = @"SELECT * FROM dbo.login_Table 
                             WHERE [User name]=@user AND [Password]=@pass";

            using (SqlConnection con = new SqlConnection(conStr))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@user", textBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@pass", textBox2.Text.Trim());

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    string role = dt.Rows[0]["Roll"].ToString();
                    string status = dt.Rows[0]["Statues"].ToString();

                    if (status == "True" || status == "1")
                    {
                        MessageBox.Show("Login Successful");

                        if (role == "admin")
                            new AdminForm().Show();
                        else if (role == "customer")
                            new CostomerForm().Show();
                        else if (role == "seller")
                            new UserForm().Show();

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Your Account is Inactive!");
                    }
                }
                else
                {
                    MessageBox.Show("Wrong Username or Password!");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = @"INSERT INTO dbo.login_Table 
                             ([User name], [Password], [Roll], [Statues]) 
                             VALUES (@user, @pass, @role, @status)";

            using (SqlConnection con = new SqlConnection(conStr))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@user", textBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@pass", textBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@role", guna2ComboBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@status", true);

                con.Open();
                int result = cmd.ExecuteNonQuery();

                MessageBox.Show(result > 0 ? "Registration Completed" : "Registration Failed");
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string query = @"UPDATE dbo.login_Table 
                             SET [Password]=@newPass 
                             WHERE [User name]=@user AND [Password]=@oldPass";

            using (SqlConnection con = new SqlConnection(conStr))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@newPass", textBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@user", textBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@oldPass", textBox2.Text.Trim());

                con.Open();
                int result = cmd.ExecuteNonQuery();

                MessageBox.Show(result > 0 ? "Update Completed" : "Username or Password Incorrect");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = @"DELETE FROM dbo.login_Table 
                             WHERE [User name]=@user AND [Password]=@pass";

            using (SqlConnection con = new SqlConnection(conStr))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@user", textBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@pass", textBox2.Text.Trim());

                con.Open();
                int result = cmd.ExecuteNonQuery();

                MessageBox.Show(result > 0 ? "Delete Completed" : "Username or Password Incorrect");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            guna2ComboBox1.SelectedIndex = -1;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkLabel2.Text == "Show")
            {
                linkLabel2.Text = "Hide";
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                linkLabel2.Text = "Show";
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are You Really Want To Close This Application?",
                "Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void MainWindow_Load_2(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }
    }
}