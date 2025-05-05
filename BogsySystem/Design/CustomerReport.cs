using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BogsySystem.Design
{
    public partial class CustomerReport : Form
    {
        public CustomerReport()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            ReportMenu ReportMenu = new ReportMenu();
            ReportMenu.Show();
        }

        private void CustomerReport_Load(object sender, EventArgs e)
        {
            
            this.rentalInformationTableAdapter.Fill(this.bogsyDatabaseDataSet.RentalInformation);
            using (SqlConnection cn = new SqlConnection("Data Source=.\\MSSQL2025;Initial Catalog=bogsyDatabase;User ID=sa;Password=12345678;TrustServerCertificate=True"))
            {
                string query = "SELECT DISTINCT Customer_Name FROM RentalInformation";
                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBox1.DisplayMember = "Customer_Name";
                comboBox1.ValueMember = "Customer_Name";
                comboBox1.DataSource = dt;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedName = comboBox1.SelectedValue.ToString();
            LoadCustomerData(selectedName);
        }

        private void LoadCustomerData(string customerName)
        {
            using (SqlConnection cn = new SqlConnection("Data Source=.\\MSSQL2025;Initial Catalog=bogsyDatabase;User ID=sa;Password=12345678;TrustServerCertificate=True"))
            {
                string query = "SELECT * FROM RentalInformation WHERE Customer_Name = @Customer_Name";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Customer_Name", customerName);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        private int currentRowIndex = 0; 

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            PrintDialog printDialog = new PrintDialog();
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();

            string customerName = comboBox1.Text;

            printDocument.PrintPage += (s, ev) =>
            {
                Font headerFont = new Font("Arial", 14, FontStyle.Bold);
                Font tableFont = new Font("Arial", 10);
                float lineHeight = tableFont.GetHeight();

                float pageWidth = ev.MarginBounds.Width;
                float pageHeight = ev.MarginBounds.Height;
                float x = ev.MarginBounds.Left; 
                float y = ev.MarginBounds.Top; 

                int numColumns = 6; 
                float colWidth = (pageWidth - 20) / numColumns; 

                string headerText = "BOGSY CUSTOMER REPORT";
                SizeF headerSize = ev.Graphics.MeasureString(headerText, headerFont);
                float centeredX = (ev.MarginBounds.Width - headerSize.Width) / 2 + ev.MarginBounds.Left;
                ev.Graphics.DrawString(headerText, headerFont, Brushes.Black, centeredX, y);
                y += headerFont.GetHeight() + 10;
                y += headerFont.GetHeight() * 3;

                ev.Graphics.DrawString($"Name: {customerName}", headerFont, Brushes.Black, x, y);
                y += headerFont.GetHeight() + 20;

                string[] headers = { "Title", "Quantity", "Category", "Price", "Rental Date", "Due Date" };
                for (int i = 0; i < headers.Length; i++)
                {
                    ev.Graphics.DrawString(headers[i], tableFont, Brushes.Black, x + i * colWidth, y);
                }
                y += lineHeight + 5;

                ev.Graphics.DrawLine(Pens.Black, x, y, x + numColumns * colWidth, y);
                y += 5;

                int rowsPerPage = (int)((pageHeight - y) / (lineHeight + 5));
                int rowCount = 0;

                for (int i = currentRowIndex; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    if (!row.IsNewRow) 
                    {
                        if (y + lineHeight + 5 > ev.MarginBounds.Bottom)
                        {
                            ev.HasMorePages = true;
                            currentRowIndex = i; 
                            return;
                        }

                        ev.Graphics.DrawString(row.Cells[2].Value?.ToString() ?? "", tableFont, Brushes.Black, x, y);
                        ev.Graphics.DrawString(row.Cells[3].Value?.ToString() ?? "", tableFont, Brushes.Black, x + colWidth, y);
                        ev.Graphics.DrawString(row.Cells[4].Value?.ToString() ?? "", tableFont, Brushes.Black, x + 2 * colWidth, y);
                        ev.Graphics.DrawString(string.Format("{0:C}", row.Cells[5].Value ?? 0.00), tableFont, Brushes.Black, x + 3 * colWidth, y);
                        ev.Graphics.DrawString(row.Cells[6].Value?.ToString() ?? "", tableFont, Brushes.Black, x + 4 * colWidth, y);
                        ev.Graphics.DrawString(row.Cells[7].Value?.ToString() ?? "", tableFont, Brushes.Black, x + 5 * colWidth, y);
                        y += lineHeight + 5;

                        rowCount++;
                    }
                }

                currentRowIndex = 0;
                ev.HasMorePages = false; 
            };

            printDialog.Document = printDocument;
            printPreviewDialog.Document = printDocument;

            
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printPreviewDialog.ShowDialog();
                printDocument.Print();
            }
        }
    }
}
