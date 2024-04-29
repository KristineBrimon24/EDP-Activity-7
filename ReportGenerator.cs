using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Pharmacy_Store_System
{
    public partial class ReportGenerator : Form
    {
        private string name;
        public ReportGenerator(string name)
        {
            this.name = name;
            InitializeComponent();
            LoadDataIntoDataGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

                    string sql = "SELECT * FROM customer_transaction1";
                    string query = "SELECT * FROM product";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    // Changed this line to combine both queries into one command
                    cmd.CommandText = sql + ";" + query;

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    // Assuming the tables in the DataSet are named "Table1" and "Table2" respectively
                    dataGridView1.DataSource = dataSet.Tables[0]; // customer_transaction1
                    dataGridView2.DataSource = dataSet.Tables[1]; // product
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

        private void export_Click(object sender, EventArgs e)
        {
            MySql.Data.MySqlClient.MySqlConnection conn = null;
            string myConnectionString;
            myConnectionString = "server=127.0.0.1;uid=root;" +
                "pwd=ella11;database=pharmacy_store_system";
            
                try
                {
                // Load Excel Template
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook templateWorkbook = excelApp.Workbooks.Open(@"C:\Users\ASUS\Documents\BRIMON\template\Sales Transaction.xlsm");
                Excel.Worksheet templateWorksheet = templateWorkbook.Sheets[1];

                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
                conn.Open();

                string mergedCell = "C21:D21";

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
                        templateWorksheet.Range[mergedCell].Value = eName;
                    }
                }
               

                // Export DataGridView1 Data to Template
                int startRow1 = 1; // Assuming your data starts from row 2 in the DataGridView1
                int templateRow1 = 10; // Row in the template where data starts
                int templateColumn1 = 5; // Column in the template where data starts

                foreach (DataGridViewRow dgvRow in dataGridView1.Rows)
                {
                    int templateRowToUpdate = templateRow1 + startRow1 - 1;
                    int templateColToUpdate = templateColumn1;

                    foreach (DataGridViewCell dgvCell in dgvRow.Cells)
                    {
                        // Check if the column should be skipped
                        if (dgvCell.OwningColumn.HeaderText == "ColumnToSkip")
                            continue; // Skip this cell

                        templateWorksheet.Cells[templateRowToUpdate, templateColToUpdate].Value = dgvCell.Value;
                        templateColToUpdate++;
                    }

                    startRow1++;
                }

                // Save Sales Transaction File
                string newFileName = @"C:\Users\ASUS\Documents\BRIMON\template\New_Sales Transaction.xlsm";
                templateWorkbook.SaveAs(newFileName);

                // Close Excel Workbook
                templateWorkbook.Close();

                // Release COM objects to avoid memory leaks
                Marshal.ReleaseComObject(templateWorksheet);
                Marshal.ReleaseComObject(templateWorkbook);


                excelApp.Quit();
                Marshal.ReleaseComObject(excelApp);

                MessageBox.Show("Data exported to new Excel files successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySql.Data.MySqlClient.MySqlConnection conn = null;
            string myConnectionString;
            myConnectionString = "server=127.0.0.1;uid=root;" +
                "pwd=ella11;database=pharmacy_store_system";

            try {
                // Load Product Inventory Count Template
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook templateWorkbook1 = excelApp.Workbooks.Open(@"C:\Users\ASUS\Documents\BRIMON\template\Product Inventory Count.xlsm");
            Excel.Worksheet templateWorksheet1 = templateWorkbook1.Sheets[1];

                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
                conn.Open();

                string mergedCell = "C22:F22";

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
                        templateWorksheet1.Range[mergedCell].Value = eName;
                    }
                }


                // Export DataGridView2 Data to Template
                int startRow2 = 1; // Assuming your data starts from row 2 in the DataGridView2
            int templateRow2 = 10; // Row in the template where data for DataGridView2 starts
            int templateColumn2 = 3; // Column in the template where data starts

            foreach (DataGridViewRow dgvRow in dataGridView2.Rows)
            {
                int templateRowToUpdate = templateRow2 + startRow2 - 1;
                int templateColToUpdate = templateColumn2;

                foreach (DataGridViewCell dgvCell in dgvRow.Cells)
                {
                    // Check if the column should be skipped
                    if (dgvCell.OwningColumn.HeaderText == "product_price_tablet" || dgvCell.OwningColumn.HeaderText == "customer_id")
                        continue; // Skip this cell

                    templateWorksheet1.Cells[templateRowToUpdate, templateColToUpdate].Value = dgvCell.Value;
                    templateColToUpdate++;
                }

                startRow2++;
            }

            // Save Product Inventory Count File
            string newFileName1 = @"C:\Users\ASUS\Documents\BRIMON\template\New_Product Inventory Count.xlsm";
            templateWorkbook1.SaveAs(newFileName1);

            // Close Excel Workbook
            templateWorkbook1.Close();

            // Release COM objects to avoid memory leaks
            Marshal.ReleaseComObject(templateWorksheet1);
            Marshal.ReleaseComObject(templateWorkbook1);

            excelApp.Quit();
            Marshal.ReleaseComObject(excelApp);

            MessageBox.Show("Data exported to new Excel files successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        private void backBTN_Click(object sender, EventArgs e)
        {
            dashboard dashboard = new dashboard(name);
            dashboard.Show();
            this.Hide();
        }
    }

}
