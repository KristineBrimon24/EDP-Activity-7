using MySql.Data.MySqlClient;
using Pharmacy_Store_System.Resources;
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
    public partial class dashboard : Form
    {
        private string name;
        public dashboard(string name)
        {
            InitializeComponent();
            this.name = name;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void employee_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Receipt Receipt = new Receipt(name);
            Receipt.Show();
            this.Hide();
        }

        private void accounts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var home = new Accounts();
            this.Hide();
            home.Show();
        }

        private void about_Click(object sender, EventArgs e)
        {
            string myname = name;
            MySql.Data.MySqlClient.MySqlConnection conn = null;
            string myConnectionString;
            myConnectionString = "server=127.0.0.1;uid=root;" +
                "pwd=ella11;database=pharmacy_store_system";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
                conn.Open();

                string sql = "UPDATE employee SET status = 'Not Active' WHERE username = @myuser;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

               
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@myuser", myname);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Log Out Successfully");

                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
            catch (MySqlException ex)//
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ReportGenerator ReportGenerator = new ReportGenerator(name);
            ReportGenerator.Show();
            this.Hide();
        }
    }
}
