using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BogsySystem
{
    public partial class CustomerLibraryForm : Form
    {
        FormButtonAction formButtonAction = new FormButtonAction();
        public CustomerLibraryForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formButtonAction.btnExitAction(this);
        }

        private void CustomerLibraryForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'modelDataSet.CustomerLibrary' table. You can move, or remove it, as needed.
            this.customerLibraryTableAdapter.Fill(this.modelDataSet.CustomerLibrary);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            formButtonAction.btnAddCustomerAction(txtFname,txtLname,txtEAddress, bdayPicker, txtPNumber,txtHAddress, this);
        }
    }
}
