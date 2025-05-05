using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Deployment.Internal;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BogsySystem.Database;

namespace BogsySystem
{
    internal class CustomerLibraryButtonAction
    {
        DatabaseConnection connection = new DatabaseConnection();

        SqlConnection cnBogsy;
        SqlDataAdapter da;

        public string customerID;
        private string originalCustomerName;

        //------------------------------ CUSTOMER LIBRARY SECTION ------------------------------
        public void loadCustomerLibraryData(DataGridView dataGridView1)
        {
            da = new SqlDataAdapter("Select * FROM CustomerLibrary", cnBogsy);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void CustomerLibrarySearchBar(DataGridView dataGridView2, TextBox txtSearchBar1)
        {
            try
            {
                // Initialize and open the connection
                connection.DBConnect(ref cnBogsy);
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM CustomerLibrary", cnBogsy);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Apply the filter
                string search = txtSearchBar1.Text.Replace("'", "''");
                DataView dv = dt.DefaultView;
                dv.RowFilter = $"First_Name LIKE '%{search}%' OR Last_Name LIKE '%{search}%'";

                // Bind the filtered view
                dataGridView2.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search failed: " + ex.Message);
            }
        }

        public void btnClearAction(TextBox txtFname, TextBox txtLname, DateTimePicker bdayPicker, TextBox txtPNumber, TextBox txtEAddress, TextBox txtHAddress, Button btnAddCustomer)
        {
            txtFname.Clear();
            txtLname.Clear();
            txtPNumber.Clear();
            txtEAddress.Clear();
            txtHAddress.Clear();
            bdayPicker.Value = new DateTime(2000, 1, 1);

            btnAddCustomer.Enabled = true;
        }

        public void btnExitAction(Form currentForm) //Goes Back to main menu
        {
            currentForm.Close();
            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.Show();
        }
        public void btnAddCustomerAction(TextBox txtFname, TextBox txtLname, TextBox txtEAddress, DateTimePicker bdayPicker, TextBox txtPNumber, TextBox txtHAddress, DataGridView dataGridView1, Button btnAddCustomer)
        {
            

            if (txtFname.Text != "" && txtLname.Text != "" && txtEAddress.Text != "" && txtPNumber.Text != "" && txtHAddress.Text != "")
            {
                SaveInfo(txtFname, txtLname, bdayPicker, txtPNumber, txtEAddress, txtHAddress);
                loadCustomerLibraryData(dataGridView1);
                btnClearAction(txtFname, txtLname, bdayPicker, txtPNumber, txtEAddress, txtHAddress, btnAddCustomer);

                MessageBox.Show("Customer Information Save Successfully", "BOGSY VIDEO STORE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Fill out empty space");
            }
        }

        public void btnSelectCustomerAction(DataGridViewCellEventArgs e, DataGridView dataGridView1, TextBox txtFname, TextBox txtLname, DateTimePicker bdayPicker, TextBox txtPNumber, TextBox txtEAddress, TextBox txtHAddress)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                if (row.Cells["birthdayDataGridViewTextBoxColumn"].Value != DBNull.Value)
                {
                txtFname.Text = row.Cells["firstNameDataGridViewTextBoxColumn"].Value.ToString();
                txtLname.Text = row.Cells["lastNameDataGridViewTextBoxColumn"].Value.ToString();
                bdayPicker.Value = Convert.ToDateTime(row.Cells["birthdayDataGridViewTextBoxColumn"].Value);
                txtPNumber.Text = row.Cells["phoneNumberDataGridViewTextBoxColumn"].Value.ToString();
                txtEAddress.Text = row.Cells["emailAddressDataGridViewTextBoxColumn"].Value.ToString();
                txtHAddress.Text = row.Cells["homeAddressDataGridViewTextBoxColumn"].Value.ToString();

                originalCustomerName = txtFname.Text;
                }
                else
                {
                    MessageBox.Show("PLEASE SELECT CUSTOMER NAME.", "BOGSY VIDEO STORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else { MessageBox.Show("PLEASE SELECT CUSTOMER NAME.", "BOGSY VIDEO STORE", MessageBoxButtons.OK, MessageBoxIcon.Warning); };

        }

        public void btnEditCustomerAction(TextBox txtFname, TextBox txtLname, DateTimePicker bdayPicker, TextBox txtPNumber, TextBox txtEAddress, TextBox txtHAddress, Button btnAddCustomer, DataGridView dataGridView1)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Edit the selected row?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(txtFname.Text))
                {
                    connection.DBConnect(ref cnBogsy);
                    cnBogsy.Open();

                    string QUERY = "UPDATE CustomerLibrary SET " +
                        "First_Name = @First_Name, " +
                        "Last_Name = @Last_Name, " +
                        "Birthday = @Birthday, " +
                        "Phone_Number = @Phone_Number, " +
                        "Email_Address = @Email_Address, " +
                        "Home_Address = @Home_Address " +
                        " WHERE First_Name = @originalCustomerName";

                    string formattedDate = bdayPicker.Value.ToString("MM/dd/yyyy");

                    SqlCommand CMD = new SqlCommand(QUERY, cnBogsy);
                    CMD.Parameters.AddWithValue("@First_Name", txtFname.Text);
                    CMD.Parameters.AddWithValue("@Last_Name", txtLname.Text);
                    CMD.Parameters.AddWithValue("@Birthday", formattedDate);
                    CMD.Parameters.AddWithValue("@Phone_Number", txtPNumber.Text);
                    CMD.Parameters.AddWithValue("@Email_Address", txtEAddress.Text);
                    CMD.Parameters.AddWithValue("@Home_Address", txtHAddress.Text);
                    CMD.Parameters.AddWithValue("@originalCustomerName", originalCustomerName);
                    CMD.ExecuteNonQuery();

                    btnClearAction(txtFname, txtLname, bdayPicker, txtPNumber, txtEAddress, txtHAddress, btnAddCustomer);
                    loadCustomerLibraryData(dataGridView1);
                    cnBogsy.Close();

                    MessageBox.Show("Edit Success", "BOGSY VIDEO STORE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else { MessageBox.Show("TEXT BOX EMPTY!"); }

            }
        }

        protected void SaveInfo(TextBox txtFname, TextBox txtLname, DateTimePicker bdayPicker, TextBox txtPNumber, TextBox txtEAddress, TextBox txtHAddress)
        {
            connection.DBConnect(ref cnBogsy);
            cnBogsy.Open();

            string QUERY = "INSERT INTO CustomerLibrary" +
                "" + "(First_Name, Last_Name, Birthday, Phone_Number, Email_Address, Home_Address) " +
                "VALUES ( @First_Name, @Last_Name, @Birthday, @Phone_Number, @Email_Address, @Home_Address)";

            string formattedDate = bdayPicker.Value.ToString("MM/dd/yyyy");

            SqlCommand CMD = new SqlCommand(QUERY, cnBogsy);
            CMD.Parameters.AddWithValue("@First_Name", txtFname.Text);
            CMD.Parameters.AddWithValue("@Last_Name", txtLname.Text);
            CMD.Parameters.AddWithValue("@Birthday", formattedDate);
            CMD.Parameters.AddWithValue("@Phone_Number", txtPNumber.Text);
            CMD.Parameters.AddWithValue("@Email_Address", txtEAddress.Text);
            CMD.Parameters.AddWithValue("@Home_Address", txtHAddress.Text);
            CMD.ExecuteNonQuery();

            cnBogsy.Close();
        }

        //------------------------------ END OF SECTION ------------------------------
    }
}
