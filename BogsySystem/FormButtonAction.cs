using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BogsySystem
{
    internal class FormButtonAction
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;


        //------------------------------ CUSTOMER LIBRARY SECTION ------------------------------
        public void btnAddCustomerAction(TextBox txtFname, TextBox txtLname, TextBox txtEAddress, DateTimePicker bdayPicker, TextBox txtPNumber, TextBox txtHAddress, Form currentForm)
        {
            if (txtFname.Text != "" && txtLname.Text != "" && txtEAddress.Text != "" && txtPNumber.Text != "" && txtHAddress.Text != "")
            {
                SaveInfo(txtFname, txtLname, bdayPicker, txtPNumber, txtEAddress, txtHAddress);
            }
            else
            {
                MessageBox.Show("Fill out empty space");
            }
            currentForm.Hide();
            CustomerLibraryForm customerLibrary = new CustomerLibraryForm();
            customerLibrary.ShowDialog();

        }

        protected void SaveInfo(TextBox txtFname, TextBox txtLname, DateTimePicker bdayPicker, TextBox txtPNumber, TextBox txtEAddress, TextBox txtHAddress)
        {
            cn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True");
            cn.Open();

            string QUERY = "INSERT INTO CustomerLibrary" +
                "" + "(First_Name, Last_Name, Birthday, Phone_Number, Email_Address, Home_Address) " +
                "VALUES ( @First_Name, @Last_Name, @Birthday, @Phone_Number, @Email_Address, @Home_Address)";

            SqlCommand CMD = new SqlCommand(QUERY, cn);
            CMD.Parameters.AddWithValue("@First_Name", txtFname.Text);
            CMD.Parameters.AddWithValue("@Last_Name", txtLname.Text);
            CMD.Parameters.AddWithValue("@Birthday", bdayPicker.Value);
            CMD.Parameters.AddWithValue("@Phone_Number", txtPNumber.Text);
            CMD.Parameters.AddWithValue("@Email_Address", txtEAddress.Text);
            CMD.Parameters.AddWithValue("@Home_Address", txtHAddress.Text);
            CMD.ExecuteNonQuery();

            cn.Close();
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
