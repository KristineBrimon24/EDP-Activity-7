using MySql.Data.MySqlClient;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Pharmacy_Store_System
{
    public partial class Accounts : Form
    {
        public Accounts()
        {
            InitializeComponent();
            LoadDataIntoDataGridView();
            SetupAutoComplete();
            dataGridView1.CellClick += dataGridView1_CellClick;

        }
        private void Accounts_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if a valid row is clicked
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count - 1)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Populate TextBoxes with selected row's data for updating
                textBox3.Text = selectedRow.Cells["emp_id"].Value.ToString();
                textBox2.Text = selectedRow.Cells["emp_name"].Value.ToString();
                textBox7.Text = selectedRow.Cells["emp_address"].Value.ToString();
                textBox5.Text = selectedRow.Cells["emp_phone_number"].Value.ToString();
                textBox8.Text = selectedRow.Cells["emp_role"].Value.ToString();
                textBox6.Text = selectedRow.Cells["username"].Value.ToString();
                textBox4.Text = selectedRow.Cells["password"].Value.ToString();
            }
        }
        private void SetupAutoComplete()
        {
            // Create a list to store suggestions
            List<string> suggestions = new List<string>();

            // Populate the list with unique values from the DataGridView
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    string value = cell.Value?.ToString();
                    if (!string.IsNullOrEmpty(value) && !suggestions.Contains(value))
                    {
                        suggestions.Add(value);
                    }
                }
            }

            // Configure AutoComplete mode and add suggestions to the TextBox
            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(suggestions.ToArray());
            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox1.AutoCompleteCustomSource = autoComplete;
        }

        private void LoadDataIntoDataGridView()
        {
            MySql.Data.MySqlClient.MySqlConnection conn = null;
            string myConnectionString;
            myConnectionString = "server=127.0.0.1;uid=root;" +
                "pwd=ella11;database=pharmacy_store_system";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
                conn.Open();

                string sql = "SELECT * FROM employee";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
            catch (MySqlException ex)//
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }





        private void button1_Click(object sender, EventArgs e)
        {
            string searchTerm = textBox1.Text.Trim(); // Trim extra whitespace from the search term

            MySql.Data.MySqlClient.MySqlConnection conn = null;
            string myConnectionString;
            myConnectionString = "server=127.0.0.1;uid=root;" +
                "pwd=ella11;database=pharmacy_store_system";
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
                conn.Open();

                string sql = "SELECT emp_id, emp_name, emp_address, emp_phone_number, emp_role, username, password FROM employee WHERE CONCAT_WS('','','', emp_name, emp_phone_number, emp_address, emp_role, '') LIKE @searchTerm";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%"); // Wildcard search
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Bind the filtered data to the DataGridView
                dataGridView1.DataSource = dataTable;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void update_Click(object sender, EventArgs e)
        {
            // Get the updated values from TextBoxes
            string ID = textBox3.Text;
            string updatedName = textBox2.Text;
            string updatedAddress = textBox7.Text;
            string updatedPhoneNumber = textBox5.Text;
            string updatedRole = textBox8.Text;
            string updatedUsername = textBox6.Text;
            string updatedPassword = textBox4.Text;
            MySql.Data.MySqlClient.MySqlConnection conn = null;
            string myConnectionString;
            myConnectionString = "server=127.0.0.1;uid=root;" +
                "pwd=ella11;database=pharmacy_store_system";
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
                conn.Open();

                string query = "UPDATE employee SET emp_name = @name, emp_address = @address, emp_phone_number = @phone, emp_role = @role, username = @username, password = @password WHERE emp_id = @emp_id";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@emp_id", ID);
                command.Parameters.AddWithValue("@name", updatedName);
                command.Parameters.AddWithValue("@address", updatedAddress);
                command.Parameters.AddWithValue("@phone", updatedPhoneNumber);
                command.Parameters.AddWithValue("@role", updatedRole);
                command.Parameters.AddWithValue("@username", updatedUsername);
                command.Parameters.AddWithValue("@password", updatedPassword);


                command.ExecuteNonQuery();

                MessageBox.Show("Record updated successfully!");

                LoadDataIntoDataGridView();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

        }

        private void add_Click(object sender, EventArgs e)
        {
            AddAccount addAccount = new AddAccount();
            addAccount.Show();
            this.Hide();
        }

        private void back_Click(object sender, EventArgs e)
        {
            dashboard dashboard = new dashboard(null);
            dashboard.Show();
            this.Hide();
        }
    }
}
