using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BogsySystem.Design;

namespace BogsySystem.Methods
{
    internal class VideoRentalButtonAction
    {
        public void btnAddRentalAction(DataGridView dataGridView1, DataGridView dataGridView3,  int selectedRowIndex)
        {
            if (selectedRowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView3.Rows[selectedRowIndex];
                string selectedTitle = selectedRow.Cells["titleDataGridViewTextBoxColumn"].Value.ToString();

                // Check if the title already exists in dataGridView1
                bool exists = false;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["RentedTitle"].Value != null && row.Cells["RentedTitle"].Value.ToString() == selectedTitle)
                    {
                        exists = true;
                        break;
                    }
                }

                if (exists)
                {
                    MessageBox.Show("This item is already added.");
                }
                else
                {
                    int newRowIndex = dataGridView1.Rows.Add();
                    DataGridViewRow newRow = dataGridView1.Rows[newRowIndex];

                    newRow.Cells["RentedTitle"].Value = selectedRow.Cells["titleDataGridViewTextBoxColumn"].Value;
                    newRow.Cells["RentedQuantity"].Value = "1";
                    newRow.Cells["RentedCategory"].Value = selectedRow.Cells["categoryDataGridViewTextBoxColumn"].Value;
                    newRow.Cells["RentedPrice"].Value = selectedRow.Cells["priceDataGridViewTextBoxColumn"].Value;
                }

                selectedRowIndex = -1;
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
        }
        public void btnRentalExitAction(Form currentForm) //Goes Back to main menu
        {
            currentForm.Close();
            VideoRentalMenuForm rentalMenu = new VideoRentalMenuForm();
            rentalMenu.Show();
        }
    }
}
