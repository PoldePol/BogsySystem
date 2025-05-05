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
    public partial class CustomerLibraryForm : Form
    {
        CustomerLibraryButtonAction customerLibraryButtonAction = new CustomerLibraryButtonAction();
        GlobalSharedButtonAction globalSharedButtonAction = new GlobalSharedButtonAction();

        public CustomerLibraryForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            globalSharedButtonAction.globalButtonExitAction(this);
        }

        private void CustomerLibraryForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bogsyDatabaseDataSet.CustomerLibrary' table. You can move, or remove it, as needed.
            this.customerLibraryTableAdapter1.Fill(this.bogsyDatabaseDataSet.CustomerLibrary);


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            customerLibraryButtonAction.btnAddCustomerAction(txtFname,txtLname,txtEAddress, bdayPicker, txtPNumber,txtHAddress, dataGridView1, btnAddCustomer);
        }

        private void btnClearCustomer_Click(object sender, EventArgs e)
        {
            customerLibraryButtonAction.btnClearAction(txtFname, txtLname, bdayPicker, txtPNumber, txtEAddress, txtHAddress, btnAddCustomer);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAddCustomer.Enabled = false;
            customerLibraryButtonAction.btnSelectCustomerAction(e, dataGridView1, txtFname, txtLname, bdayPicker, txtPNumber, txtEAddress, txtHAddress);
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            customerLibraryButtonAction.btnEditCustomerAction(txtFname, txtLname, bdayPicker, txtPNumber, txtEAddress, txtHAddress, btnAddCustomer, dataGridView1);
        }
    }
}
