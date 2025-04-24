namespace BogsySystem
{
    partial class MainMenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            this.btnVideoReport = new System.Windows.Forms.Button();
            this.btnVideoLibrary = new System.Windows.Forms.Button();
            this.btnCustomerLibrary = new System.Windows.Forms.Button();
            this.btnVideoRental = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnVideoReport
            // 
            this.btnVideoReport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVideoReport.BackgroundImage")));
            this.btnVideoReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVideoReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVideoReport.Location = new System.Drawing.Point(257, 580);
            this.btnVideoReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnVideoReport.Name = "btnVideoReport";
            this.btnVideoReport.Size = new System.Drawing.Size(294, 57);
            this.btnVideoReport.TabIndex = 8;
            this.btnVideoReport.Text = "REPORT";
            this.btnVideoReport.UseVisualStyleBackColor = true;
            this.btnVideoReport.Click += new System.EventHandler(this.btnVideoReport_Click);
            // 
            // btnVideoLibrary
            // 
            this.btnVideoLibrary.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVideoLibrary.BackgroundImage")));
            this.btnVideoLibrary.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVideoLibrary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVideoLibrary.Location = new System.Drawing.Point(257, 515);
            this.btnVideoLibrary.Margin = new System.Windows.Forms.Padding(4);
            this.btnVideoLibrary.Name = "btnVideoLibrary";
            this.btnVideoLibrary.Size = new System.Drawing.Size(294, 57);
            this.btnVideoLibrary.TabIndex = 7;
            this.btnVideoLibrary.Text = "VIDEO LIBRARY";
            this.btnVideoLibrary.UseVisualStyleBackColor = true;
            this.btnVideoLibrary.Click += new System.EventHandler(this.btnVideoLibrary_Click);
            // 
            // btnCustomerLibrary
            // 
            this.btnCustomerLibrary.BackgroundImage = global::BogsySystem.Properties.Resources.text_bg2;
            this.btnCustomerLibrary.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCustomerLibrary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomerLibrary.Location = new System.Drawing.Point(257, 450);
            this.btnCustomerLibrary.Margin = new System.Windows.Forms.Padding(4);
            this.btnCustomerLibrary.Name = "btnCustomerLibrary";
            this.btnCustomerLibrary.Size = new System.Drawing.Size(294, 57);
            this.btnCustomerLibrary.TabIndex = 6;
            this.btnCustomerLibrary.Text = "CUSTOMER LIBRARY";
            this.btnCustomerLibrary.UseVisualStyleBackColor = true;
            this.btnCustomerLibrary.Click += new System.EventHandler(this.btnCustomerLibrary_Click);
            // 
            // btnVideoRental
            // 
            this.btnVideoRental.BackgroundImage = global::BogsySystem.Properties.Resources.text_bg2;
            this.btnVideoRental.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVideoRental.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVideoRental.Location = new System.Drawing.Point(257, 386);
            this.btnVideoRental.Margin = new System.Windows.Forms.Padding(4);
            this.btnVideoRental.Name = "btnVideoRental";
            this.btnVideoRental.Size = new System.Drawing.Size(294, 57);
            this.btnVideoRental.TabIndex = 5;
            this.btnVideoRental.Text = "VIDEO RENTAL";
            this.btnVideoRental.UseVisualStyleBackColor = true;
            this.btnVideoRental.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BogsySystem.Properties.Resources.bogsy_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(787, 663);
            this.Controls.Add(this.btnVideoReport);
            this.Controls.Add(this.btnVideoLibrary);
            this.Controls.Add(this.btnCustomerLibrary);
            this.Controls.Add(this.btnVideoRental);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BOGSY VIDEO STORE";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVideoReport;
        private System.Windows.Forms.Button btnVideoLibrary;
        private System.Windows.Forms.Button btnCustomerLibrary;
        private System.Windows.Forms.Button btnVideoRental;
    }
}

