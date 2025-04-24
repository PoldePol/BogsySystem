using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BogsySystem.Methods;

namespace BogsySystem
{
    public partial class VideoLibraryForm : Form
    {
        SqlConnection cnBogsy;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        public string videoID;

        CustomerLibraryButtonAction formButtonAction = new CustomerLibraryButtonAction();
        VideoLibraryButtonAction videoLibraryButtonAction = new VideoLibraryButtonAction();
        public VideoLibraryForm()
        {
            InitializeComponent();

            comboBoxPrice.Items.Add("25");
            comboBoxPrice.Items.Add("50");
            comboBoxCategory.Items.Add("DVD");
            comboBoxCategory.Items.Add("VCD");

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            formButtonAction.btnExitAction(this);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
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

        private void VideoLibraryForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bogsyDatabaseDataSet.VideoLibrary' table. You can move, or remove it, as needed.
            this.videoLibraryTableAdapter.Fill(this.bogsyDatabaseDataSet.VideoLibrary);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            videoLibraryButtonAction.btnAddVideoAction(txtTitle, comboBoxCategory, comboBoxPrice, txtQuan, comboBoxMaxRent, dataGridView2,btnAddVideo);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            videoLibraryButtonAction.btnClearAction(txtTitle, comboBoxCategory, comboBoxPrice, txtQuan, comboBoxMaxRent, btnAddVideo);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAddVideo.Enabled = false;

            videoLibraryButtonAction.btnSelectVideoAction(e, dataGridView2, txtTitle, comboBoxCategory, comboBoxPrice, txtQuan, comboBoxMaxRent);

            DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
            videoID = row.Cells["iDDataGridViewTextBoxColumn1"].Value.ToString();

            if (row.Cells["Status"].Value != null)
            {
                string status = row.Cells["Status"].Value.ToString();

                if (status == "Active")
                {
                    btnStatusVideo.Text = "Inactive";
                }
                else
                {
                    btnStatusVideo.Text = "Active";
                }
            }

            
                


        }

        private void btnEditVideo_Click(object sender, EventArgs e)
        {
            videoLibraryButtonAction.btnEditVideoAction(txtTitle, comboBoxCategory, comboBoxPrice, txtQuan, comboBoxMaxRent, btnAddVideo, dataGridView2);
        }

        private void btnStatusVideo_Click(object sender, EventArgs e)
        {
            

            cnBogsy = new SqlConnection("Data Source=.\\MSSQL2025;Initial Catalog=bogsyDatabase;User ID=sa;Password=12345678;TrustServerCertificate=True");
            cnBogsy.Open();

            string QUERY = "UPDATE VideoLibrary SET " +
                "Status = @Status " +
                " WHERE ID = @ID";

            string buttonlabel = btnStatusVideo.Text;

            SqlCommand CMD = new SqlCommand(QUERY, cnBogsy);
            CMD.Parameters.AddWithValue("@Status", buttonlabel);
            CMD.Parameters.AddWithValue("@ID", videoID);
            CMD.ExecuteNonQuery();

            cnBogsy.Close();

            videoLibraryButtonAction.btnClearAction( txtTitle,  comboBoxCategory,  comboBoxPrice,  txtQuan,  comboBoxMaxRent,  btnAddVideo);

            cnBogsy.Open();
            da = new SqlDataAdapter("Select * FROM VideoLibrary", cnBogsy);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
