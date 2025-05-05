using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BogsySystem.Database;
using BogsySystem.Design;

namespace BogsySystem.Methods
{
    internal class VideoRentalButtonAction
    {
        DatabaseConnection connection = new DatabaseConnection();

        SqlConnection cnBogsy;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;

        public void clearRentalAction(TextBox txtFname, TextBox txtLname, TextBox txtPNumber, TextBox txtEaddress, TextBox txtHaddress, TextBox txtTitle, TextBox txtQuan, ComboBox comboBoxCategory, ComboBox comboBoxPrice, ComboBox comboBoxMaxRent)
        {
            txtFname.Clear();
            txtLname.Clear();
            txtPNumber.Clear();
            txtEaddress.Clear();
            txtHaddress.Clear();
            txtTitle.Clear();
            txtQuan.Clear();

            comboBoxCategory.SelectedIndex = -1;
            comboBoxPrice.SelectedIndex = -1;
            comboBoxMaxRent.SelectedIndex = -1;
        }
        public void btnRentalExitAction(Form currentForm) //Goes Back to main menu
        {
            currentForm.Close();
            VideoRentalMenuForm rentalMenu = new VideoRentalMenuForm();
            rentalMenu.Show();
        }
        public void txtboxChangeCalculate(TextBox txtAmount, TextBox txtAmountRecieve, TextBox txtAmountChange)
        {
            decimal amount;
            int amountReceived;

            if (decimal.TryParse(txtAmount.Text.Trim(), out amount) &&
                int.TryParse(txtAmountRecieve.Text.Trim(), out amountReceived))
            {
                decimal change = amountReceived - amount;
                txtAmountChange.Text = change.ToString();
            }
            else
            {
                MessageBox.Show("Please enter valid numeric values.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void CustomerFullName(TextBox txtFullName, TextBox txtFname, TextBox txtLname, TextBox txtPNumber, TextBox txtPhoneNumber )
        {
            string firstName = txtFname.Text.Trim();
            string secondName = txtLname.Text.Trim();

            txtFullName.Text = $"{firstName} {secondName}";

            string pnumber = txtPNumber.Text.Trim();

            txtPhoneNumber.Text = pnumber;
        }
        public void btnRowRentalDelete(DataGridView dataGridView1)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected row?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (dataGridView1.DataSource is DataTable dt)
                    {
                        int rowIndex = dataGridView1.SelectedRows[0].Index;
                        if (rowIndex >= 0 && rowIndex < dt.Rows.Count)
                        {
                            dt.Rows[rowIndex].Delete();
                        }
                    }
                    else
                    {
                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            if (!row.IsNewRow)
                                dataGridView1.Rows.Remove(row);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("SELECT ROW TO DELETE.", "BOGSY VIDEO STORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void RentalTotal(DataGridView dataGridView1, TextBox textBox10, TextBox txtTotalQuantity)
        {
            decimal total = 0;
            int itemtotal = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["RentedPrice"].Value != null && decimal.TryParse(row.Cells["RentedPrice"].Value.ToString(), out decimal price) && row.Cells["RentedQuantity"].Value != null && int.TryParse(row.Cells["RentedQuantity"].Value.ToString(), out int quantity))
                {
                    total += price;
                    itemtotal += quantity;
                }


            }

            textBox10.Text = total.ToString("N2");
            txtTotalQuantity.Text = itemtotal.ToString();
        }
        public void btnAddRentalAction(DataGridView dataGridView1, DataGridView dataGridView3,  int selectedRowIndex, ComboBox comboBoxMaxRent )
        {
            if (selectedRowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView3.Rows[selectedRowIndex];
                string selectedTitle = selectedRow.Cells["titleDataGridViewTextBoxColumn"].Value.ToString();

                bool exists = false;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["RentedTitle"].Value != null && row.Cells["RentedTitle"].Value.ToString() == selectedTitle)
                    {
                        exists = true;
                        break;
                    }
                }

                if (exists)
                {
                    MessageBox.Show("This item is already added.");
                }
                else
                {
                    int newRowIndex = dataGridView1.Rows.Add();
                    DataGridViewRow newRow = dataGridView1.Rows[newRowIndex];

                    newRow.Cells["RentedTitle"].Value = selectedRow.Cells["titleDataGridViewTextBoxColumn"].Value;
                    newRow.Cells["RentedQuantity"].Value = "1";
                    newRow.Cells["RentedCategory"].Value = selectedRow.Cells["categoryDataGridViewTextBoxColumn"].Value;
                    newRow.Cells["RentedPrice"].Value = selectedRow.Cells["priceDataGridViewTextBoxColumn"].Value;
                    newRow.Cells["RentalDueDate"].Value = DateTime.Now.AddDays(Convert.ToInt32(comboBoxMaxRent.Text)).ToString("MM/dd/yyyy");

                }

                selectedRowIndex = -1;
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
        }

        public void btnRentalRentAction(DataGridView DataGridView1, TextBox txtFullName, TextBox txtPhoneNumber, TextBox txtRentalDate, TextBox txtAmountReceive, TextBox txtAmount, TextBox txtAmountChange, TextBox txtFname, TextBox txtLname, TextBox txtPNumber, TextBox txtEaddress, TextBox txtHaddress, TextBox txtTitle, TextBox txtQuan, ComboBox comboBoxCategory, ComboBox comboBoxPrice, ComboBox comboBoxMaxRent)
        {
            if (string.IsNullOrWhiteSpace(txtAmountReceive.Text))
            {
                MessageBox.Show("AMOUNT RECIEVE BOX EMPTY!", "BOGSY VIDEO STORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Convert.ToInt16(txtAmountReceive.Text) < Convert.ToDecimal(txtAmount.Text))
            {
                MessageBox.Show("INSUFFICIENT AMOUNT!", "BOGSY VIDEO STORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Please enter your full name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                connection.DBConnect(ref cnBogsy);

                foreach (DataGridViewRow row in DataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {

                        string Title = row.Cells["RentedTitle"].Value?.ToString();
                        int Quantity = Convert.ToInt32(row.Cells["RentedQuantity"].Value);
                        string Category = row.Cells["RentedCategory"].Value?.ToString();
                        int Price = Convert.ToInt32(row.Cells["RentedPrice"].Value);
                        string DueDate = row.Cells["RentalDueDate"].Value?.ToString();

                        if (!string.IsNullOrEmpty(Title))
                        {
                            cnBogsy.Open();

                            string QUERY = "INSERT INTO RentalInformation" + "" +
                                "(Customer_Name, Phone_Number, Title, Quantity, Category, Price, Rental_Date, Due_Date) " +
                                "VALUES ( @Customer_Name, @Phone_Number, @Title, @Quantity, @Category, @Price, @Rental_Date, @Due_Date)";
                            SqlCommand cmd = new SqlCommand(QUERY, cnBogsy);

                            cmd.Parameters.AddWithValue("@Customer_Name", txtFullName.Text);
                            cmd.Parameters.AddWithValue("@Phone_Number", txtPhoneNumber.Text);
                            cmd.Parameters.AddWithValue("@Title", Title);
                            cmd.Parameters.AddWithValue("@Quantity", Quantity);
                            cmd.Parameters.AddWithValue("@Category", Category);
                            cmd.Parameters.AddWithValue("@Price", Price);
                            cmd.Parameters.AddWithValue("@Rental_Date", txtRentalDate.Text);
                            cmd.Parameters.AddWithValue("@Due_Date", DueDate);
                            cmd.ExecuteNonQuery();

                            string query = "UPDATE VideoLibrary SET Stock_Quantity = Stock_Quantity - 1 WHERE title = @title";

                            using (SqlCommand CMD = new SqlCommand(query, cnBogsy))
                            {
                                CMD.Parameters.AddWithValue("@title", Title);

                                int rowsAffected = CMD.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    clearRentalAction(txtFname, txtLname, txtPNumber, txtEaddress, txtHaddress, txtTitle, txtQuan, comboBoxCategory, comboBoxPrice, comboBoxMaxRent);
                                    txtAmount.Text = "0";
                                    txtAmountChange.Text = "0";
                                    txtAmountReceive.Text = "0";
                                }
                                else
                                {
                                    MessageBox.Show("No matching title found.");
                                }
                            }

                            //Add and subtract Video Report
                            string videoReportQuery = "UPDATE VideoReport " +
                               "SET Video_In = Video_In - 1, " +
                               "Video_Out = Video_Out + 1 " +
                              "WHERE Title = @Title AND Category = @Category";

                            SqlCommand cmd1 = new SqlCommand(videoReportQuery, cnBogsy);

                            cmd1.Parameters.AddWithValue("@Title", Title);
                            cmd1.Parameters.AddWithValue("@Category", Category);
                            cmd1.ExecuteNonQuery();
                            MessageBox.Show("TRANSACTION SUCCESS!", "BOGSY VIDEO STORE", MessageBoxButtons.OK, MessageBoxIcon.Information);


                            cnBogsy.Close();
                        }
                    }
                    

                }
            }
            
            DataGridView1.DataSource = null;
            DataGridView1.Rows.Clear();

        }

        public void btnRentalSelectAction(DataGridViewCellEventArgs e, DataGridView dataGridView1, TextBox txtCustomerName, TextBox txtPhoneNumber, TextBox txtTitle, TextBox txtQuantity, TextBox txtCategory, TextBox txtPrice, TextBox txtRentalDate, TextBox txtDueDate, TextBox txtODDays, TextBox txtTODCharge )
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtCustomerName.Text = row.Cells["customerNameDataGridViewTextBoxColumn"].Value.ToString();
                txtPhoneNumber.Text = row.Cells["phoneNumberDataGridViewTextBoxColumn"].Value.ToString();
                txtTitle.Text = row.Cells["titleDataGridViewTextBoxColumn"].Value.ToString();
                txtQuantity.Text = row.Cells["quantityDataGridViewTextBoxColumn"].Value.ToString();
                txtCategory.Text = row.Cells["categoryDataGridViewTextBoxColumn"].Value.ToString();
                txtPrice.Text= row.Cells["priceDataGridViewTextBoxColumn"].Value.ToString();
                txtRentalDate.Text = row.Cells["rentalDateDataGridViewTextBoxColumn"].Value.ToString();
                txtDueDate.Text = row.Cells["dueDateDataGridViewTextBoxColumn"].Value.ToString();


            }
            else { MessageBox.Show("Select Row With Value"); 
            
            };

           
            DateTime RentDueDate = DateTime.ParseExact(txtDueDate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            DateTime CurrentDate = DateTime.Now.Date;
            if (CurrentDate > RentDueDate)
            {
                TimeSpan OverDueNumDays = RentDueDate - CurrentDate;

                int totalDays = Math.Abs(OverDueNumDays.Days);
                int weeks = totalDays / 7;
                int days = totalDays % 7;

                txtODDays.Text = $"{days}";

                int totalCharge = days * 5;

                txtTODCharge.Text = $"{totalCharge}";
            }
            else { txtTODCharge.Text = $"0"; txtODDays.Text = $"0"; }
        }

        //--------------------------------------Return code section

        public void txtBoxReturnChangeCalculate(TextBox txtTODCharge, TextBox txtAmountReceive, TextBox txtChange)
        {
            decimal amount;
            int amountReceived;

            if (decimal.TryParse(txtTODCharge.Text.Trim(), out amount) &&
                int.TryParse(txtAmountReceive.Text.Trim(), out amountReceived))
            {
                decimal change = amountReceived - amount;
                txtChange.Text = change.ToString();
            }
            else
            {
                MessageBox.Show("Please enter valid numeric values.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void btnReturnAction(TextBox txtAmountReceive, TextBox txtTODCharge, Button btnReturn, TextBox txtTitle, TextBox txtCategory, TextBox txtCustomerName, DataGridView dataGridView1)
        {
            if (string.IsNullOrWhiteSpace(txtAmountReceive.Text))
            {
                MessageBox.Show("AMOUNT RECIEVE BOX EMPTY!", "BOGSY VIDEO STORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Convert.ToInt16(txtAmountReceive.Text) < Convert.ToInt16(txtTODCharge.Text))
            {
                MessageBox.Show("INSUFFICIENT AMOUNT!", "BOGSY VIDEO STORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                btnReturn.Enabled = true;

                    connection.DBConnect(ref cnBogsy);
                    string queryVideoLibrary = "UPDATE VideoLibrary SET Stock_Quantity = Stock_Quantity + 1 WHERE title = @title";
                using (SqlCommand cmd = new SqlCommand(queryVideoLibrary, cnBogsy))
                    {
                    cnBogsy.Open();
                    cmd.Parameters.AddWithValue("@title", txtTitle.Text.Trim());
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("TRANSACTION SUCCESS!", "BOGSY VIDEO STORE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No matching title found.");
                    }

                    //Update to Video Report
                    string videoReportQuery = "UPDATE VideoReport SET " +
                    "Title = @Title, " +
                    "Category = @Category, " +
                    "Video_In = Video_In + 1, " +
                    "Video_Out = Video_Out - 1 " +
                    "WHERE Title = @Title";

                    SqlCommand CMD = new SqlCommand(videoReportQuery, cnBogsy);
                    CMD.Parameters.AddWithValue("@Title", txtTitle.Text);
                    CMD.Parameters.AddWithValue("@Category", txtCategory.Text);
                    CMD.ExecuteNonQuery();

                    string query = "DELETE FROM RentalInformation WHERE Customer_Name = @Customer_Name AND Title = @Title";
                    SqlCommand cmd1 = new SqlCommand(query, cnBogsy);
                    cmd1.Parameters.AddWithValue("@Customer_Name", txtCustomerName.Text);
                    cmd1.Parameters.AddWithValue("@Title", txtTitle.Text);
                    cmd1.ExecuteNonQuery();

                    LoadRentalData(dataGridView1);

                    cnBogsy.Close();

                       
                    }

            }
        }

        private void LoadRentalData(DataGridView dataGridView1)
        {
            da = new SqlDataAdapter("Select * FROM RentalInformation", cnBogsy);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

    }
}
