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
    public partial class VideoLibraryForm : Form
    {
        FormButtonAction formButtonAction = new FormButtonAction();

        public VideoLibraryForm()
        {
            InitializeComponent();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            formButtonAction.btnExitAction(this);
        }
    }
}
