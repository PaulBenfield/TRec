namespace TRec.Windows.UI
{
    partial class frmManageTimes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpFilterDate = new System.Windows.Forms.DateTimePicker();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(12, 9);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(33, 13);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Date:";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dtpFilterDate
            // 
            this.dtpFilterDate.Location = new System.Drawing.Point(51, 5);
            this.dtpFilterDate.Name = "dtpFilterDate";
            this.dtpFilterDate.Size = new System.Drawing.Size(190, 20);
            this.dtpFilterDate.TabIndex = 2;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGrid.Location = new System.Drawing.Point(12, 31);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(504, 283);
            this.pnlGrid.TabIndex = 3;
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Location = new System.Drawing.Point(247, 4);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(97, 23);
            this.btnRetrieve.TabIndex = 4;
            this.btnRetrieve.Text = "&Retrieve Times";
            this.btnRetrieve.UseVisualStyleBackColor = true;
            this.btnRetrieve.Click += new System.EventHandler(this.btnRetrieve_Click);
            // 
            // frmManageTimes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 326);
            this.Controls.Add(this.btnRetrieve);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.dtpFilterDate);
            this.Controls.Add(this.lblDate);
            this.Name = "frmManageTimes";
            this.Text = "Manage Times";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpFilterDate;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Button btnRetrieve;
    }
}