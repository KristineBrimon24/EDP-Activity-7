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
using System.IO;

namespace Pharmacy_Store_System
{
    public partial class AddAccount : Form
    {
        public AddAccount()
        {
            InitializeComponent();
        }

        private void AddRecordToDatabase(string accntName, string accntAddress, string accntPhoneNum, string accntRole, string username, string password)
        {
            MySql.Data.MySqlClient.MySqlConnection conn = null;
            string myConnectionString;
            myConnectionString = "server=127.0.0.1;uid=root;" +
                "pwd=ella11;database=pharmacy_store_system";
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
                conn.Open();

  

                string sql = "INSERT INTO employee (emp_name, emp_address, emp_phone_number, emp_role, username, password) VALUES (@accntName, @accntAddress, @accntPhoneNum, @accntRole, @username, @password )";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

               
                cmd.Parameters.AddWithValue("@accntName", accntName);
                cmd.Parameters.AddWithValue("@accntAddress", accntAddress);
                cmd.Parameters.AddWithValue("@accntPhoneNum", accntPhoneNum);
                cmd.Parameters.AddWithValue("@accntRole", accntRole);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                

                cmd.ExecuteNonQuery();

                MessageBox.Show("New record added successfully!");
                Accounts Accounts= new Accounts();
                Accounts.Show();
                this.Hide();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn?.Close();
            }
        }


        private void pass_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void upd_Click(object sender, EventArgs e)
        {
  
            string accntName = nametxtbx.Text;
            string accntAddress = addresstxtbx.Text;
            string accntPhoneNum = phonentxtbx.Text;
            string accntRole = roletxtbx.Text;
            string username = usernametxtbx.Text;
            string password = passtxtbx.Text;




            if (string.IsNullOrWhiteSpace(accntName) || string.IsNullOrWhiteSpace(accntPhoneNum) || string.IsNullOrWhiteSpace(accntAddress) || string.IsNullOrWhiteSpace(accntRole) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all fields. or Upload a Picture", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {

                // Call AddRecordToDatabase with imagePath as parameter
                AddRecordToDatabase(accntName, accntAddress, accntPhoneNum, accntRole, username, password);
            }
            catch (Exception)
            {
                MessageBox.Show("Please Upload a Picture", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            AddAccount addAccount = new AddAccount();
            addAccount.Show();
            this.Hide();
        }
    }
}
