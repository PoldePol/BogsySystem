using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BogsySystem.Methods
{
    internal class VideoLibraryButtonAction
    {
        SqlConnection cnBogsy;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        public string videoID;

        public void btnAddVideoAction(TextBox txtTitle, ComboBox comboBoxCategory, ComboBox comboBoxPrice, TextBox txtQuan, ComboBox comboBoxMaxRent, DataGridView dataGridView2, Button btnAddVideo) 
        {
            if (txtTitle.Text != "" && comboBoxCategory.Text != "" && comboBoxPrice.Text != "" && txtQuan.Text != "" && comboBoxMaxRent.Text != "")
            {
                SaveInfo( txtTitle, comboBoxCategory, comboBoxPrice, txtQuan, comboBoxMaxRent);

                cnBogsy.Open();
                da = new SqlDataAdapter("Select * FROM VideoLibrary", cnBogsy);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
                cnBogsy.Close();

                btnClearAction(txtTitle, comboBoxCategory, comboBoxPrice, txtQuan, comboBoxMaxRent, btnAddVideo);

            }
            else
            {
                MessageBox.Show("Fill out empty space");
            }


        }

        protected void SaveInfo(TextBox txtTitle, ComboBox comboBoxCategory, ComboBox comboBoxPrice, TextBox txtQuan, ComboBox comboBoxMaxRent)
        {
            cnBogsy = new SqlConnection("Data Source=.\\MSSQL2025;Initial Catalog=bogsyDatabase;User ID=sa;Password=12345678;TrustServerCertificate=True");
            cnBogsy.Open();

            string QUERY = "INSERT INTO VideoLibrary" +
                "" + "(Title, Category, Price, Stock_Quantity, Max_Days_Rent, Status) " +
                "VALUES ( @Title, @Category, @Price, @Stock_Quantity, @Max_Days_Rent, @Status)";

            SqlCommand CMD = new SqlCommand(QUERY, cnBogsy);
            CMD.Parameters.AddWithValue("@Title", txtTitle.Text);
            CMD.Parameters.AddWithValue("@Category", comboBoxCategory.Text);
            CMD.Parameters.AddWithValue("@Price", comboBoxPrice.Text);
            CMD.Parameters.AddWithValue("@Stock_Quantity", txtQuan.Text);
            CMD.Parameters.AddWithValue("@Max_Days_Rent", comboBoxMaxRent.Text);
            CMD.Parameters.AddWithValue("@Status", "Active");
            CMD.ExecuteNonQuery();

            cnBogsy.Close();
        }

        public void btnClearAction(TextBox txtTitle, ComboBox comboBoxCategory, ComboBox comboBoxPrice, TextBox txtQuan, ComboBox comboBoxMaxRent, Button btnAddVideo)
        {
            txtTitle.Clear();
            comboBoxCategory.SelectedIndex = -1;
            comboBoxPrice.SelectedIndex = -1;
            txtQuan.Clear();
            comboBoxMaxRent.SelectedIndex = -1;

            btnAddVideo.Enabled = true;
        }

        public void btnSelectVideoAction(DataGridViewCellEventArgs e, DataGridView dataGridView2, TextBox txtTitle, ComboBox comboBoxCategory, ComboBox comboBoxPrice, TextBox txtQuan, ComboBox comboBoxMaxRent)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                txtTitle.Text = row.Cells["titleDataGridViewTextBoxColumn"].Value.ToString();
                comboBoxCategory.Text = row.Cells["categoryDataGridViewTextBoxColumn"].Value.ToString();
                comboBoxPrice.Text = row.Cells["priceDataGridViewTextBoxColumn"].Value.ToString();
                txtQuan.Text = row.Cells["stockQuantityDataGridViewTextBoxColumn"].Value.ToString();
                comboBoxMaxRent.Text = row.Cells["maxDaysRentDataGridViewTextBoxColumn"].Value.ToString();
                videoID = row.Cells["iDDataGridViewTextBoxColumn1"].Value.ToString();

            }

        }

        public void btnEditVideoAction(TextBox txtTitle, ComboBox comboBoxCategory, ComboBox comboBoxPrice, TextBox txtQuan, ComboBox comboBoxMaxRent, Button btnAddVideo, DataGridView dataGridView2)
        {
            cnBogsy = new SqlConnection("Data Source=.\\MSSQL2025;Initial Catalog=bogsyDatabase;User ID=sa;Password=12345678;TrustServerCertificate=True");
            cnBogsy.Open();

            string QUERY = "UPDATE VideoLibrary SET " +
                "Title = @Title, " +
                "Category = @Category, " +
                "Price = @Price, " +
                "Stock_Quantity = @Stock_Quantity, " +
                "Max_Days_Rent = @Max_Days_Rent " +
                " WHERE ID = @ID";


            SqlCommand CMD = new SqlCommand(QUERY, cnBogsy);
            CMD.Parameters.AddWithValue("@Title", txtTitle.Text);
            CMD.Parameters.AddWithValue("@Category", comboBoxCategory.Text);
            CMD.Parameters.AddWithValue("@Price", comboBoxPrice.Text);
            CMD.Parameters.AddWithValue("@Stock_Quantity", txtQuan.Text);
            CMD.Parameters.AddWithValue("@Max_Days_Rent", comboBoxMaxRent.Text);
            CMD.Parameters.AddWithValue("@ID", videoID);
            CMD.ExecuteNonQuery();

            cnBogsy.Close();

            btnAddVideo.Enabled = true;

            txtTitle.Clear();
            comboBoxCategory.SelectedIndex = -1;
            comboBoxPrice.SelectedIndex = -1;
            txtQuan.Clear();
            comboBoxMaxRent.SelectedIndex = -1;

            cnBogsy.Open();
            da = new SqlDataAdapter("Select * FROM VideoLibrary", cnBogsy);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;

        }

    }
}
