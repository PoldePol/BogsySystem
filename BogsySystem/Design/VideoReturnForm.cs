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
    }
}
