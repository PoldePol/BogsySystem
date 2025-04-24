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

namespace BogsySystem
{
    internal class CustomerLibraryButtonAction
    {
        SqlConnection cnBogsy;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;

        public string customerID;

        //------------------------------ CUSTOMER LIBRARY SECTION ------------------------------
        public void btnAddCustomerAction(TextBox txtFname, TextBox txtLname, TextBox txtEAddress, DateTimePicker bdayPicker, TextBox txtPNumber, TextBox txtHAddress, DataGridView dataGridView1, Button btnAddCustomer)
        {
            if (txtFname.Text != "" && txtLname.Text != "" && txtEAddress.Text != "" && txtPNumber.Text != "" && txtHAddress.Text != "")
            {
                SaveInfo(txtFname, txtLname, bdayPicker, txtPNumber, txtEAddress, txtHAddress);

                cnBogsy.Open();
                da = new SqlDataAdapter("Select * FROM CustomerLibrary", cnBogsy);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                cnBogsy.Close();
                btnClearAction(txtFname, txtLname, bdayPicker, txtPNumber, txtEAddress, txtHAddress, btnAddCustomer);

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

                txtFname.Text = row.Cells["firstNameDataGridViewTextBoxColumn"].Value.ToString();
                txtLname.Text = row.Cells["lastNameDataGridViewTextBoxColumn"].Value.ToString();
                bdayPicker.Value = Convert.ToDateTime(row.Cells["birthdayDataGridViewTextBoxColumn"].Value);
                txtPNumber.Text = row.Cells["phoneNumberDataGridViewTextBoxColumn"].Value.ToString();
                txtEAddress.Text = row.Cells["emailAddressDataGridViewTextBoxColumn"].Value.ToString();
                txtHAddress.Text = row.Cells["homeAddressDataGridViewTextBoxColumn"].Value.ToString();
                customerID = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();


            }
            else { MessageBox.Show("Select Row With Value"); };

        }

        public void btnEditCustomerAction(TextBox txtFname, TextBox txtLname, DateTimePicker bdayPicker, TextBox txtPNumber, TextBox txtEAddress, TextBox txtHAddress, Button btnAddCustomer, DataGridView dataGridView1)
        {
            cnBogsy = new SqlConnection("Data Source=.\\MSSQL2025;Initial Catalog=bogsyDatabase;User ID=sa;Password=12345678;TrustServerCertificate=True");
            cnBogsy.Open();

            string QUERY = "UPDATE CustomerLibrary SET " +
                "First_Name = @First_Name, " +
                "Last_Name = @Last_Name, " +
                "Birthday = @Birthday, " +
                "Phone_Number = @Phone_Number, " +
                "Email_Address = @Email_Address, " +
                "Home_Address = @Home_Address " +
                " WHERE ID = @ID";

            string formattedDate = bdayPicker.Value.ToString("MM/dd/yyyy");

            SqlCommand CMD = new SqlCommand(QUERY, cnBogsy);
            CMD.Parameters.AddWithValue("@First_Name", txtFname.Text);
            CMD.Parameters.AddWithValue("@Last_Name", txtLname.Text);
            CMD.Parameters.AddWithValue("@Birthday", formattedDate);
            CMD.Parameters.AddWithValue("@Phone_Number", txtPNumber.Text);
            CMD.Parameters.AddWithValue("@Email_Address", txtEAddress.Text);
            CMD.Parameters.AddWithValue("@Home_Address", txtHAddress.Text);
            CMD.Parameters.AddWithValue("@ID", customerID);
            CMD.ExecuteNonQuery();

            cnBogsy.Close();

            btnAddCustomer.Enabled = true;

            txtFname.Clear();
            txtLname.Clear();
            txtPNumber.Clear();
            txtEAddress.Clear();
            txtHAddress.Clear();
            bdayPicker.Value = new DateTime(2000, 1, 1);

            cnBogsy.Open();
            da = new SqlDataAdapter("Select * FROM CustomerLibrary", cnBogsy);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cnBogsy.Close();
        }

        protected void SaveInfo(TextBox txtFname, TextBox txtLname, DateTimePicker bdayPicker, TextBox txtPNumber, TextBox txtEAddress, TextBox txtHAddress)
        {
            cnBogsy = new SqlConnection("Data Source=.\\MSSQL2025;Initial Catalog=bogsyDatabase;User ID=sa;Password=12345678;TrustServerCertificate=True");
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

        

        //------------------------------ END OF SECTION ------------------------------
    }
}
