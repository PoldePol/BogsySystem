namespace BogsySystem.Design
{
    partial class VideoRentalMenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoRentalMenuForm));
            this.btnVideoReturn = new System.Windows.Forms.Button();
            this.btnVideoRental = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnVideoReturn
            // 
            this.btnVideoReturn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVideoReturn.BackgroundImage")));
            this.btnVideoReturn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVideoReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVideoReturn.Location = new System.Drawing.Point(257, 451);
            this.btnVideoReturn.Margin = new System.Windows.Forms.Padding(4);
            this.btnVideoReturn.Name = "btnVideoReturn";
            this.btnVideoReturn.Size = new System.Drawing.Size(294, 57);
            this.btnVideoReturn.TabIndex = 11;
            this.btnVideoReturn.Text = "VIDEO RETURN";
            this.btnVideoReturn.UseVisualStyleBackColor = true;
            this.btnVideoReturn.Click += new System.EventHandler(this.btnVideoReturn_Click);
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
            this.btnVideoRental.TabIndex = 10;
            this.btnVideoRental.Text = "VIDEO RENTAL";
            this.btnVideoRental.UseVisualStyleBackColor = true;
            this.btnVideoRental.Click += new System.EventHandler(this.btnVideoRental_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBack.BackgroundImage")));
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(257, 516);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(294, 57);
            this.btnBack.TabIndex = 12;
            this.btnBack.Text = "BACK";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // VideoRentalMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BogsySystem.Properties.Resources.bogsy_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(787, 663);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnVideoReturn);
            this.Controls.Add(this.btnVideoRental);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VideoRentalMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BOGSY VIDEO STORE";
            this.Load += new System.EventHandler(this.VideoRentalMenuForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVideoReturn;
        private System.Windows.Forms.Button btnVideoRental;
        private System.Windows.Forms.Button btnBack;
    }
}