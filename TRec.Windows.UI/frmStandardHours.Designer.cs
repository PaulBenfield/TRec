namespace TRec.Windows.UI
{
    partial class frmStandardHours
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
            this.lblTip = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.dtStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblStandardEndTime = new System.Windows.Forms.Label();
            this.dtEndTime = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblInfo2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Location = new System.Drawing.Point(12, 21);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(236, 13);
            this.lblTip.TabIndex = 0;
            this.lblTip.Text = "Enter your normal daily shift start and finish times.";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(51, 53);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(79, 13);
            this.lblStartTime.TabIndex = 1;
            this.lblStartTime.Text = "Shift Start Time";
            // 
            // dtStartTime
            // 
            this.dtStartTime.CustomFormat = "HHH:mm tt";
            this.dtStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartTime.Location = new System.Drawing.Point(136, 49);
            this.dtStartTime.Name = "dtStartTime";
            this.dtStartTime.ShowUpDown = true;
            this.dtStartTime.Size = new System.Drawing.Size(86, 20);
            this.dtStartTime.TabIndex = 2;
            this.dtStartTime.Value = new System.DateTime(2008, 1, 1, 8, 0, 0, 0);
            // 
            // lblStandardEndTime
            // 
            this.lblStandardEndTime.AutoSize = true;
            this.lblStandardEndTime.Location = new System.Drawing.Point(54, 83);
            this.lblStandardEndTime.Name = "lblStandardEndTime";
            this.lblStandardEndTime.Size = new System.Drawing.Size(76, 13);
            this.lblStandardEndTime.TabIndex = 3;
            this.lblStandardEndTime.Text = "Shift End Time";
            // 
            // dtEndTime
            // 
            this.dtEndTime.CustomFormat = "HHH:mm tt";
            this.dtEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEndTime.Location = new System.Drawing.Point(136, 79);
            this.dtEndTime.Name = "dtEndTime";
            this.dtEndTime.ShowUpDown = true;
            this.dtEndTime.Size = new System.Drawing.Size(86, 20);
            this.dtEndTime.TabIndex = 4;
            this.dtEndTime.Value = new System.DateTime(2008, 1, 1, 16, 0, 0, 0);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(126, 168);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(213, 168);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblInfo2
            // 
            this.lblInfo2.AutoSize = true;
            this.lblInfo2.Location = new System.Drawing.Point(31, 140);
            this.lblInfo2.Name = "lblInfo2";
            this.lblInfo2.Size = new System.Drawing.Size(332, 13);
            this.lblInfo2.TabIndex = 5;
            this.lblInfo2.Text = "The clock will automatically start and stop outside of the above hours";
            // 
            // frmStandardHours
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 208);
            this.Controls.Add(this.lblInfo2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtEndTime);
            this.Controls.Add(this.dtStartTime);
            this.Controls.Add(this.lblStandardEndTime);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.lblTip);
            this.Name = "frmStandardHours";
            this.Text = "Standard Start & Finish Times";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.DateTimePicker dtStartTime;
        private System.Windows.Forms.Label lblStandardEndTime;
        private System.Windows.Forms.DateTimePicker dtEndTime;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblInfo2;

    }
}