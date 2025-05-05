using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BogsySystem.Methods
{
    internal class GlobalSharedButtonAction
    {
        public void globalButtonExitAction(Form currentForm)
        {
            currentForm.Close();
            MainMenuForm mainMenuForm = new MainMenuForm();
            mainMenuForm.Show();
            
        }
    }
}
