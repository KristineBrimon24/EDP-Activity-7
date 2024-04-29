using Microsoft.Office.Interop.Excel;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace Pharmacy_Store_System.Resources
{
    public partial class Receipt : Form
    {
        private string name;
        public Receipt(string name)
        {
            this.name = name;
            InitializeComponent();
        }

        private void addact_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void AddRecordToDatabase(string transaction_quantity_box, string transaction_payment, string product_id)
        {
            MySql.Data.MySqlClient.MySqlConnection conn = null;
            string myConnectionString;
            myConnectionString = "server=127.0.0.1;uid=root;" +
                "pwd=ella11;database=pharmacy_store_system";
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
                conn.Open();



                string sql = "INSERT INTO transaction (transaction_quantity_box, transaction_payment, product_id) VALUES (@transaction_quantity_box, @transaction_payment, @product_id)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);


                cmd.Parameters.AddWithValue("@transaction_quantity_box", transaction_quantity_box);
                cmd.Parameters.AddWithValue("@transaction_payment", transaction_payment);
                cmd.Parameters.AddWithValue("@product_id", product_id);


                cmd.ExecuteNonQuery();

                MessageBox.Show("New record added successfully!");

                string lastInsertIdSql = "SELECT LAST_INSERT_ID();";
                MySqlCommand lastInsertIdCmd = new MySqlCommand(lastInsertIdSql, conn);
                int transactionId = Convert.ToInt32(lastInsertIdCmd.ExecuteScalar());


                string selectSql = "SELECT p.product_name, p.product_price_tablet " +
                            "FROM product p " +
                            "WHERE p.product_id = @product_id";

                MySqlCommand selectCmd = new MySqlCommand(selectSql, conn);
                selectCmd.Parameters.AddWithValue("@product_id", product_id);

                try
                {
                    // Step 1: Open the Excel template
                    Excel.Application excelApp = new Excel.Application();
                    Excel.Workbook workbook = excelApp.Workbooks.Open(@"C:\Users\ASUS\Documents\BRIMON\template\Pharmacy Invoice.xlsx");
                    Excel.Worksheet worksheet = workbook.Worksheets[1]; // Assuming your data is on the first worksheet

                    // Step 2: Locate the cells where you want to insert the product name and price
                    // Change column and row references to cell names
                    string productNameCell = "C18";
                    string productPriceCell = "E18";
                    string productquantity = "D18";
                    string transactionpayment = "E29";
                    string transaction_id = "E10";
                    string empName = "C33";


                    string adminQuery = "SELECT emp_name FROM employee WHERE username = @name";
                    MySqlCommand cmdAdmin = new MySqlCommand(adminQuery, conn);
                    cmdAdmin.Parameters.AddWithValue("@name", name);

                    string eName = ""; // Initialize employee name variable

                    // Execute the admin query
                    using (MySqlDataReader adminReader = cmdAdmin.ExecuteReader())
                    {
                        if (adminReader.Read())
                        {
                            // Retrieve the employee name
                            eName = adminReader["emp_name"].ToString();
                        }
                    }


                    using (MySqlDataReader reader = selectCmd.ExecuteReader())
                    {
                        // Step 3: Write the retrieved values into those cells
                        if (reader.Read())
                        {
                            // Retrieve product name and price from the reader
                            string productName = reader["product_name"].ToString();
                            decimal productPrice = Convert.ToDecimal(reader["product_price_tablet"]);

                            // Write the values into the Excel cells
                            worksheet.Range[productNameCell].Value = productName;
                            worksheet.Range[productPriceCell].Value = productPrice;
                            worksheet.Range[productquantity].Value = transaction_quantity_box;
                            worksheet.Range[transactionpayment].Value = transaction_payment;
                            worksheet.Range[transaction_id].Value = transactionId;
                            worksheet.Range[empName].Value = eName;
                        }


                    }
                   
                    // Step 4: Save the modified Excel file
                    string newFileName = @"C:\Users\ASUS\Documents\BRIMON\template\New_Pharmacy Invoice.xlsx";
                    workbook.SaveAs(newFileName);
                    MessageBox.Show("Receipt successfully Generated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clean up Excel objects
                    workbook.Close();
                    excelApp.Quit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void upd_Click(object sender, EventArgs e)
        {

            string transaction_quantity_box = textBox1.Text;
            string transaction_payment = textBox2.Text;
            string product_id = textBox3.Text;


            if (string.IsNullOrWhiteSpace(transaction_quantity_box) || string.IsNullOrWhiteSpace(transaction_payment) || string.IsNullOrWhiteSpace(product_id))
            {
                MessageBox.Show("Please fill in all fields. or Upload a Picture", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {

                // Call AddRecordToDatabase with imagePath as parameter
                AddRecordToDatabase(transaction_quantity_box, transaction_payment, product_id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            textBox1.Text= "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void backBTN_Click(object sender, EventArgs e)
        {
            dashboard dashboard = new dashboard(name);
            dashboard.Show();
            this.Hide();
        }
    }
}
