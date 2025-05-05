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

        public string VideoTitle;

        CustomerLibraryButtonAction formButtonAction = new CustomerLibraryButtonAction();
        VideoLibraryButtonAction videoLibraryButtonAction = new VideoLibraryButtonAction();
        GlobalSharedButtonAction globalSharedButtonAction = new GlobalSharedButtonAction(); 
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
            globalSharedButtonAction.globalButtonExitAction(this);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            videoLibraryButtonAction.videoLibraryComboBox(comboBoxCategory, comboBoxPrice);
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
            videoLibraryButtonAction.btnStatusUpdate (VideoTitle, btnStatusVideo, e, dataGridView2);
        }

        private void btnEditVideo_Click(object sender, EventArgs e)
        {
            videoLibraryButtonAction.btnEditVideoAction(txtTitle, comboBoxCategory, comboBoxPrice, txtQuan, comboBoxMaxRent, btnAddVideo, dataGridView2);
        }

        private void btnStatusVideo_Click(object sender, EventArgs e)
        {
            videoLibraryButtonAction.btnVideoStatusAction(btnStatusVideo, txtTitle, comboBoxCategory, comboBoxPrice, txtQuan, comboBoxMaxRent, btnAddVideo, dataGridView2);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            videoLibraryButtonAction.videoLibrarySearchBar(dataGridView2, videlLibrarySearchBar);
        }
    }
}
