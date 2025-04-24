using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BogsySystem.Design
{
    public partial class VideoRentalMenuForm : Form
    {
        CustomerLibraryButtonAction formButtonAction = new CustomerLibraryButtonAction();
        public VideoRentalMenuForm()
        {
            InitializeComponent();
        }

        private void VideoRentalMenuForm_Load(object sender, EventArgs e)
        {

        }

        private void btnVideoRental_Click(object sender, EventArgs e)
        {
            this.Close();
            VideoRentalForm videoRental = new VideoRentalForm();
            videoRental.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            formButtonAction.btnExitAction(this);
        }

        private void btnVideoReturn_Click(object sender, EventArgs e)
        {
            this.Close();
            VideoReturnForm videoReturn = new VideoReturnForm();
            videoReturn.Show();
        }
    }
}
