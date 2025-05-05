using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BogsySystem.Methods;

namespace BogsySystem.Design
{
    public partial class VideoReturnForm : Form
    {
        VideoRentalButtonAction videoRentalButtonAction = new VideoRentalButtonAction();
        public VideoReturnForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            videoRentalButtonAction.btnRentalExitAction(this);
        }

        private void VideoReturnForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bogsyDatabaseDataSet.RentalInformation' table. You can move, or remove it, as needed.
            this.rentalInformationTableAdapter.Fill(this.bogsyDatabaseDataSet.RentalInformation);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            videoRentalButtonAction.btnReturnAction( txtAmountReceive, txtTODCharge, btnReturn,  txtTitle, txtCategory,  txtCustomerName, dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            videoRentalButtonAction.btnRentalSelectAction(e, dataGridView1, txtCustomerName, txtPhoneNumber, txtTitle, txtQuantity, txtCategory, txtPrice, txtRentalDate, txtDueDate, txtODDay, txtTODCharge);
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            
        }

        private void txtAmountReceive_TextChanged(object sender, EventArgs e)
        {
            videoRentalButtonAction.txtBoxReturnChangeCalculate(txtTODCharge, txtAmountReceive, txtChange);
        }
    }
}
