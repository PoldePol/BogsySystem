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
    public partial class BogsyReport : Form
    {   GlobalSharedButtonAction globaSharedButtonAction = new GlobalSharedButtonAction();
        public BogsyReport()
        {
            InitializeComponent();
        }

        private void BogsyReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bogsyDatabaseDataSet.VideoReport' table. You can move, or remove it, as needed.
            this.videoReportTableAdapter.Fill(this.bogsyDatabaseDataSet.VideoReport);
            // TODO: This line of code loads data into the 'bogsyDatabaseDataSet.BogsyReport' table. You can move, or remove it, as needed.
            this.bogsyReportTableAdapter.Fill(this.bogsyDatabaseDataSet.BogsyReport);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            globaSharedButtonAction.globalButtonExitAction(this);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
