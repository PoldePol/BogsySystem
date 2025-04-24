using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BogsySystem.Methods;

namespace BogsySystem
{
    public partial class VideoRentalForm : Form
    {
        CustomerLibraryButtonAction formButtonAction = new CustomerLibraryButtonAction();
        VideoLibraryButtonAction videoLibraryButtonAction = new VideoLibraryButtonAction();
        VideoRentalButtonAction videoRentalButtonAction = new VideoRentalButtonAction();

        private int selectedRowIndex = -1;

        public VideoRentalForm()
        {
            InitializeComponent();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            videoRentalButtonAction.btnRentalExitAction(this);
        }

        private void VideoRentalForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bogsyDatabaseDataSet.VideoLibrary' table. You can move, or remove it, as needed.
            this.videoLibraryTableAdapter.Fill(this.bogsyDatabaseDataSet.VideoLibrary);
            // TODO: This line of code loads data into the 'bogsyDatabaseDataSet.CustomerLibrary' table. You can move, or remove it, as needed.
            this.customerLibraryTableAdapter.Fill(this.bogsyDatabaseDataSet.CustomerLibrary);

            txtRentalDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            videoRentalButtonAction.btnAddRentalAction(dataGridView1, dataGridView3, selectedRowIndex);
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }


        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            formButtonAction.btnSelectCustomerAction(e, dataGridView2, txtFname, txtLname, bDayPicker, txtPNumber, txtEaddress, txtHaddress);
            
            string firstName = txtFname.Text.Trim();
            string secondName = txtLname.Text.Trim();

            txtFullName.Text = $"{firstName} {secondName}";
            
            string pnumber = txtPNumber.Text.Trim();

            txtPhoneNumber.Text = pnumber;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            videoLibraryButtonAction.btnSelectVideoAction(e, dataGridView3, txtTitle, comboBoxCategory, comboBoxPrice, txtQuan, comboBoxMaxRent);
            if (e.RowIndex >= 0)
            {
                selectedRowIndex = e.RowIndex;
            }

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
