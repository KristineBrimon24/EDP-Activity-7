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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Pharmacy_Store_System
{

    public partial class UpdateAccount : Form
    {
        private void UpdateAccount_Load(object sender, EventArgs e)
        {

        }
        public UpdateAccount()
        {
            InitializeComponent();
        }
      

        public UpdateAccount(string name, string address, string phone, string role, string username, string password)
        {
            InitializeComponent();

            // Initialize form with received user details
           
            // Populate input boxes with user details
            
            upname.Text = name;
            upadd.Text = address;
            upphone.Text = phone;
            uprole.Text = role;
            upusern.Text = username;
            uppass.Text = password;

        }





        private void pass_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void empname_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void phonenum_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void usern_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void addr_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void role_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void upd_Click(object sender, EventArgs e)
        {
            string accntName = upname.Text;
            string accntAddress = upadd.Text;
            string accntPhoneNum = upphone.Text;
            string accntRole = uprole.Text;
            string username = upusern.Text;
            string password = uppass.Text;




            if (string.IsNullOrWhiteSpace(accntName) || string.IsNullOrWhiteSpace(accntPhoneNum) || string.IsNullOrWhiteSpace(accntAddress) || (string.IsNullOrWhiteSpace(accntRole) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)))
            {
                MessageBox.Show("Please fill in all fields. or Upload a Picture", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                //tring imagePath = openFileDialog1.FileName;

                UpdateRecordToDatabase(accntName, accntAddress, accntPhoneNum, accntRole, username, password);
            }
            catch (Exception)
            {
                //MessageBox.Show("Please Upload a Picture Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateRecordToDatabase(accntName, accntAddress, accntPhoneNum, accntRole, username, password);
          //  ReloadUserDetailsOnAccountForm(username);

        }

        private void UpdateRecordToDatabase(string accntName, string accntPhoneNum, string accntAddress, string accntRole, string username, string password)
        {
            MySql.Data.MySqlClient.MySqlConnection conn = null;
            string myConnectionString;
            myConnectionString = "server=127.0.0.1;uid=root;" +
                "pwd=ella11;database=pharmacy_store_system";
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
                conn.Open();

                

                string sql = "UPDATE employee SET emp_name = @accntName, emp_address = @accntAddress, emp_phone_number = @accntPhoneNum, emp_role = @accntRole, username = @username, password = @password WHERE username = @username;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@accntName", accntName);
                cmd.Parameters.AddWithValue("@accntPhoneNum", accntPhoneNum);
                cmd.Parameters.AddWithValue("@accntAddress", accntAddress);
                cmd.Parameters.AddWithValue("@accntRole", accntRole);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);


                cmd.ExecuteNonQuery();

                MessageBox.Show("Record updated successfully!");
               

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
    
}
}
