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

namespace BogsySystem.Design
{
    public partial class ReportMenu : Form
    {
        GlobalSharedButtonAction globalSharedButtonAction = new GlobalSharedButtonAction();

        public ReportMenu()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            globalSharedButtonAction.globalButtonExitAction(this);
        }

        private void ReportMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnVideoRental_Click(object sender, EventArgs e)
        {
            this.Close();
            BogsyReport BogsyReport = new BogsyReport();
            BogsyReport.Show();
        }

        private void btnVideoReturn_Click(object sender, EventArgs e)
        {
            this.Close();
            CustomerReport CustomerReport = new CustomerReport();
            CustomerReport.Show();
        }
    }
}
