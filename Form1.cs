using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Pharmacy_Store_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void login_Click(object sender, EventArgs e)
        {
            string myuser = this.username.Text;
            string mypass = this.password.Text;

            if (string.IsNullOrWhiteSpace(this.username.Text))
            {
                MessageBox.Show("Please Enter Username.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.username.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(this.password.Text))
            {
                MessageBox.Show("Please Enter Password.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.password.Focus();
                return;
            }

            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;
            myConnectionString = "server=127.0.0.1;uid=root;" +
                "pwd=ella11;database=pharmacy_store_system";


            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
                conn.Open();
                string sql = "SELECT COUNT(*) from employee where username = @myuser and password =@mypass";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@myuser", myuser);
                cmd.Parameters.AddWithValue("@mypass", mypass);


                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    string updatesql = "UPDATE employee SET status = 'Active' WHERE username = @myuser;";
                    cmd = new MySqlCommand(updatesql, conn);
                    cmd.Parameters.AddWithValue("@myuser", myuser);
                    cmd.ExecuteNonQuery();

                    dashboard dashboard = new dashboard(myuser);
                    dashboard.Show();
                    this.Hide();


                }
                else
                {
                    MessageBox.Show("Username or Password is incorrect. Please enter valid username and password", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            username.Text = "";
            password.Text="";
        }

        private void forgotpass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetPassword resetPassword = new ResetPassword();
            resetPassword.Show();
            this.Hide();
        }
    }
}
