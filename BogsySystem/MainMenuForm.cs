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
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            VideoRentalForm videoRental = new VideoRentalForm();
            videoRental.Show();

        }

        private void btnCustomerLibrary_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerLibraryForm customerLibrary = new CustomerLibraryForm();
            customerLibrary.Show();
        }

        private void btnVideoLibrary_Click(object sender, EventArgs e)
        {
            this.Hide();
            VideoLibraryForm videoLibrary = new VideoLibraryForm();
            videoLibrary.Show();
        }

        private void btnVideoReport_Click(object sender, EventArgs e)
        {

        }
    }
}
