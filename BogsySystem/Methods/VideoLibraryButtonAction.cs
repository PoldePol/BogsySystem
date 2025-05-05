using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BogsySystem.Database;

namespace BogsySystem.Methods
{
    internal class VideoLibraryButtonAction
    {
        DatabaseConnection connection = new DatabaseConnection();

        SqlConnection cnBogsy;
        SqlDataAdapter da;

        public string videoID;
        private string originalTitle;

        public void videoLibraryComboBox(ComboBox comboBoxCategory, ComboBox comboBoxPrice)
        {
            if (comboBoxCategory.SelectedItem != null)
            {

                string selectedVideo = comboBoxCategory.SelectedItem.ToString();

                switch (selectedVideo)
                {
                    case "DVD":
                        comboBoxPrice.SelectedItem = "50";
                        break;

                    case "VCD":
                        comboBoxPrice.SelectedItem = "25";
                        break;

                    default:
                        comboBoxPrice.SelectedIndex = -1;
                        break;

                }
            }
        }
        
        public void LoadVideoLibraryData(DataGridView dataGridView2)
        {
            da = new SqlDataAdapter("Select * FROM VideoLibrary", cnBogsy);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
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

                originalTitle = txtTitle.Text;
            }

            
        }
        public void videoSearchBarDataSource(DataGridView dataGridView3)
        {
            SqlConnection cnBogsy = new SqlConnection("Data Source=.\\MSSQL2025;Initial Catalog=bogsyDatabase;User ID=sa;Password=12345678;TrustServerCertificate=True");
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM VideoLibrary", cnBogsy);
            da.Fill(dt);

            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dataGridView3.DataSource = bs;

        }


        public void videoSearchBar(DataGridView dataGridView3, TextBox txtSearchBar2, SqlConnection cnBogsy)
        {

            try
            {

                // Re-fetch data from the database
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM VideoLibrary", cnBogsy);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Apply the filter
                string search = txtSearchBar2.Text.Replace("'", "''"); // Escape single quotes
                DataView dv = dt.DefaultView;
                dv.RowFilter = $"Title LIKE '%{search}%' OR Category LIKE '%{search}%'";

                // Bind the filtered view
                dataGridView3.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search failed: " + ex.Message);
            }
        }

        public void btnStatusUpdate(string VideoTitle, Button btnStatusVideo, DataGridViewCellEventArgs e, DataGridView dataGridView2)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView2.Rows.Count)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                if (row.Cells["titleDataGridViewTextBoxColumn"].Value == null ||
                    string.IsNullOrWhiteSpace(row.Cells["titleDataGridViewTextBoxColumn"].Value.ToString()))
                {
                    MessageBox.Show("PLEASE SELECT TITLE.", "BOGSY VIDEO STORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                VideoTitle = row.Cells["titleDataGridViewTextBoxColumn"].Value.ToString();

                if (row.Cells["Status"].Value != null)
                {
                    string status = row.Cells["Status"].Value.ToString();
                    btnStatusVideo.Text = status == "Active" ? "Inactive" : "Active";
                }
            }
            else
            {
                MessageBox.Show("PLEASE SELECT TITLE.", "BOGSY VIDEO STORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        public void btnAddVideoAction(TextBox txtTitle, ComboBox comboBoxCategory, ComboBox comboBoxPrice, TextBox txtQuan, ComboBox comboBoxMaxRent, DataGridView dataGridView2, Button btnAddVideo) 
        {
            if (txtTitle.Text != "" && comboBoxCategory.Text != "" && comboBoxPrice.Text != "" && txtQuan.Text != "" && comboBoxMaxRent.Text != "")
            {
                SaveInfo( txtTitle, comboBoxCategory, comboBoxPrice, txtQuan, comboBoxMaxRent);
                LoadVideoLibraryData(dataGridView2);
                btnClearAction(txtTitle, comboBoxCategory, comboBoxPrice, txtQuan, comboBoxMaxRent, btnAddVideo);

                MessageBox.Show("Video Successfully Added.", "BOGSY VIDEO STORE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("FILL OUT EMPTY BOXES!","BOGSY VIDEO STORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            

        }

        protected void SaveInfo(TextBox txtTitle, ComboBox comboBoxCategory, ComboBox comboBoxPrice, TextBox txtQuan, ComboBox comboBoxMaxRent)
        {
            connection.DBConnect(ref cnBogsy);
            cnBogsy.Open();

            //Add to Video Library
            string videoLibraryQUERY = "INSERT INTO VideoLibrary" +
                "" + "(Title, Category, Price, Stock_Quantity, Max_Days_Rent, Status) " +
                "VALUES ( @Title, @Category, @Price, @Stock_Quantity, @Max_Days_Rent, @Status)";

            SqlCommand CMD = new SqlCommand(videoLibraryQUERY, cnBogsy);
            CMD.Parameters.AddWithValue("@Title", txtTitle.Text);
            CMD.Parameters.AddWithValue("@Category", comboBoxCategory.Text);
            CMD.Parameters.AddWithValue("@Price", comboBoxPrice.Text);
            CMD.Parameters.AddWithValue("@Stock_Quantity", txtQuan.Text);
            CMD.Parameters.AddWithValue("@Max_Days_Rent", comboBoxMaxRent.Text);
            CMD.Parameters.AddWithValue("@Status", "Active");
            CMD.ExecuteNonQuery();

            //Add to Video Report
            string videoReportQuery = "INSERT INTO VideoReport" +
                "" + "(Title, Category, Video_In, Video_Out) " +
                "Values( @Title, @Category, @Video_In, 0)";

            SqlCommand cmd = new SqlCommand(videoReportQuery, cnBogsy);

            cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
            cmd.Parameters.AddWithValue("@Category", comboBoxCategory.Text);
            cmd.Parameters.AddWithValue("@Video_In", txtQuan.Text);
            cmd.ExecuteNonQuery();
            cnBogsy.Close();
        }

        public void btnEditVideoAction(TextBox txtTitle, ComboBox comboBoxCategory, ComboBox comboBoxPrice, TextBox txtQuan, ComboBox comboBoxMaxRent, Button btnAddVideo, DataGridView dataGridView2)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Edit the selected row?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(txtTitle.Text))
                {
                    connection.DBConnect(ref cnBogsy);
                    cnBogsy.Open();

                    //Update to Video Library
                    string QUERY = "UPDATE VideoLibrary SET " +
                        "Title = @Title, " +
                        "Category = @Category, " +
                        "Price = @Price, " +
                        "Stock_Quantity = @Stock_Quantity, " +
                        "Max_Days_Rent = @Max_Days_Rent " +
                        " WHERE Title = @OriginalTitle";


                    SqlCommand CMD = new SqlCommand(QUERY, cnBogsy);
                    CMD.Parameters.AddWithValue("@Title", txtTitle.Text);
                    CMD.Parameters.AddWithValue("@Category", comboBoxCategory.Text);
                    CMD.Parameters.AddWithValue("@Price", comboBoxPrice.Text);
                    CMD.Parameters.AddWithValue("@Stock_Quantity", txtQuan.Text);
                    CMD.Parameters.AddWithValue("@Max_Days_Rent", comboBoxMaxRent.Text);
                    CMD.Parameters.AddWithValue("@OriginalTitle", originalTitle);
                    CMD.ExecuteNonQuery();

                    //Update to Video Report
                    string videoReportQuery = "UPDATE VideoReport SET " +
                    "Title = @Title, " +
                    "Category = @Category, " +
                    "Video_In = @Video_In " +
                    " WHERE Title = @OriginalTitle";

                    SqlCommand cmd = new SqlCommand(videoReportQuery, cnBogsy);

                    cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                    cmd.Parameters.AddWithValue("@Category", comboBoxCategory.Text);
                    cmd.Parameters.AddWithValue("@Video_In", txtQuan.Text);
                    cmd.Parameters.AddWithValue("@OriginalTitle", originalTitle);
                    cmd.ExecuteNonQuery();

                    btnClearAction(txtTitle, comboBoxCategory, comboBoxPrice, txtQuan, comboBoxMaxRent, btnAddVideo);

                    LoadVideoLibraryData(dataGridView2);

                    cnBogsy.Close();

                    MessageBox.Show("Edit Success.", "BOGSY VIDEO STORE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                else { MessageBox.Show("TEXT BOX EMPTY!", "BOGSY VIDEO STORE", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

            }
        }

        public void btnVideoStatusAction(Button btnStatusVideo, TextBox txtTitle, ComboBox comboBoxCategory, ComboBox comboBoxPrice, TextBox txtQuan, ComboBox comboBoxMaxRent, Button btnAddVideo, DataGridView dataGridView2)
        {
            if (txtTitle.Text != "" && comboBoxCategory.Text != "" && comboBoxPrice.Text != "" && txtQuan.Text != "" && comboBoxMaxRent.Text != "")
            {
            
            connection.DBConnect(ref cnBogsy);
            cnBogsy.Open();

            string QUERY = "UPDATE VideoLibrary SET " +
                "Status = @Status " +
                " WHERE Title = @Title";

            string buttonlabel = btnStatusVideo.Text;

            SqlCommand CMD = new SqlCommand(QUERY, cnBogsy);
            CMD.Parameters.AddWithValue("@Status", buttonlabel);
            CMD.Parameters.AddWithValue("@Title", txtTitle.Text);
            CMD.ExecuteNonQuery();

            btnClearAction(txtTitle, comboBoxCategory, comboBoxPrice, txtQuan, comboBoxMaxRent, btnAddVideo);
            LoadVideoLibraryData(dataGridView2);

            cnBogsy.Close();

            MessageBox.Show("Video Set " + buttonlabel, "BOGSY VIDEO STORE", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else { MessageBox.Show("PLEASE SELECT TITLE.", "BOGSY VIDEO STORE", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

            
        }
        

    }
}
