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
    public partial class VideoRentalMenuForm : Form
    {
        CustomerLibraryButtonAction formButtonAction = new CustomerLibraryButtonAction();
        GlobalSharedButtonAction globalSharedButtonAction = new GlobalSharedButtonAction();

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
            globalSharedButtonAction.globalButtonExitAction(this);
        }

        private void btnVideoReturn_Click(object sender, EventArgs e)
        {
            VideoReturnForm videoReturn = new VideoReturnForm();
            videoReturn.Show();this.Close();
            
        }
    }
}
