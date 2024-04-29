using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy_Store_System
{
    public partial class ResetPassword : Form
    {
        public ResetPassword()
        {
            InitializeComponent();
        }

        private void title1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void resetbutton_Click(object sender, EventArgs e)
        {
            string phonenum = this.textBox1.Text;

            if (string.IsNullOrWhiteSpace(this.textBox1.Text))
            {
                MessageBox.Show("Please Enter Phone Number.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBox1.Focus();
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
                string sql = "SELECT COUNT(*) from employee where emp_phone_number = @phonenum";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@phonenum", phonenum);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    string newPassword = textBox2.Text;
                    sql = "UPDATE employee SET password = @newPassword WHERE emp_phone_number = @phonenum";
                    cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@newPassword", newPassword);
                    cmd.Parameters.AddWithValue("@phonenum", phonenum);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Reset Successfully.", "Reset", MessageBoxButtons.OK);
                    Form1 form1 = new Form1();
                    form1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Phone Number is incorrect. Please enter valid Phone Number", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cancelreset_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
