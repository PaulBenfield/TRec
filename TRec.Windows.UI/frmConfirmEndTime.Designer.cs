namespace TRec.Windows.UI
{
    partial class frmConfirmEndTime
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
            this.components = new System.ComponentModel.Container();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errProv = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpPrevious = new System.Windows.Forms.GroupBox();
            this.pnlEntry = new System.Windows.Forms.Panel();
            this.lblTaskVal = new System.Windows.Forms.Label();
            this.lblProjectVal = new System.Windows.Forms.Label();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.lblProject1 = new System.Windows.Forms.Label();
            this.lblTask = new System.Windows.Forms.Label();
            this.lblDetails = new System.Windows.Forms.Label();
            this.txtExc1 = new System.Windows.Forms.TextBox();
            this.nudExc1 = new System.Windows.Forms.NumericUpDown();
            this.lblExc1Text = new System.Windows.Forms.Label();
            this.lblException = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.lblStartTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errProv)).BeginInit();
            this.grpPrevious.SuspendLayout();
            this.pnlEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExc1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.Location = new System.Drawing.Point(250, 209);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.Location = new System.Drawing.Point(169, 209);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "C&onfirm";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errProv
            // 
            this.errProv.ContainerControl = this;
            // 
            // grpPrevious
            // 
            this.grpPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPrevious.Controls.Add(this.pnlEntry);
            this.grpPrevious.Location = new System.Drawing.Point(12, 12);
            this.grpPrevious.Name = "grpPrevious";
            this.grpPrevious.Size = new System.Drawing.Size(472, 186);
            this.grpPrevious.TabIndex = 7;
            this.grpPrevious.TabStop = false;
            this.grpPrevious.Text = "Previous entry details";
            // 
            // pnlEntry
            // 
            this.pnlEntry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEntry.Controls.Add(this.lblTaskVal);
            this.pnlEntry.Controls.Add(this.lblProjectVal);
            this.pnlEntry.Controls.Add(this.txtDetails);
            this.pnlEntry.Controls.Add(this.lblProject1);
            this.pnlEntry.Controls.Add(this.lblTask);
            this.pnlEntry.Controls.Add(this.lblDetails);
            this.pnlEntry.Controls.Add(this.txtExc1);
            this.pnlEntry.Controls.Add(this.nudExc1);
            this.pnlEntry.Controls.Add(this.lblExc1Text);
            this.pnlEntry.Controls.Add(this.lblException);
            this.pnlEntry.Controls.Add(this.dtpEnd);
            this.pnlEntry.Controls.Add(this.lblEndTime);
            this.pnlEntry.Controls.Add(this.dtpStart);
            this.pnlEntry.Controls.Add(this.lblStartTime);
            this.pnlEntry.Location = new System.Drawing.Point(6, 19);
            this.pnlEntry.Name = "pnlEntry";
            this.pnlEntry.Size = new System.Drawing.Size(457, 161);
            this.pnlEntry.TabIndex = 17;
            // 
            // lblTaskVal
            // 
            this.lblTaskVal.AutoSize = true;
            this.lblTaskVal.Location = new System.Drawing.Point(88, 31);
            this.lblTaskVal.Name = "lblTaskVal";
            this.lblTaskVal.Size = new System.Drawing.Size(35, 13);
            this.lblTaskVal.TabIndex = 29;
            this.lblTaskVal.Text = "label1";
            // 
            // lblProjectVal
            // 
            this.lblProjectVal.AutoSize = true;
            this.lblProjectVal.Location = new System.Drawing.Point(88, 9);
            this.lblProjectVal.Name = "lblProjectVal";
            this.lblProjectVal.Size = new System.Drawing.Size(35, 13);
            this.lblProjectVal.TabIndex = 28;
            this.lblProjectVal.Text = "label1";
            // 
            // txtDetails
            // 
            this.txtDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDetails.Location = new System.Drawing.Point(83, 53);
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetails.Size = new System.Drawing.Size(348, 47);
            this.txtDetails.TabIndex = 19;
            // 
            // lblProject1
            // 
            this.lblProject1.AutoSize = true;
            this.lblProject1.Location = new System.Drawing.Point(34, 9);
            this.lblProject1.Name = "lblProject1";
            this.lblProject1.Size = new System.Drawing.Size(43, 13);
            this.lblProject1.TabIndex = 18;
            this.lblProject1.Text = "Project:";
            this.lblProject1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTask
            // 
            this.lblTask.AutoSize = true;
            this.lblTask.Location = new System.Drawing.Point(41, 31);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size(34, 13);
            this.lblTask.TabIndex = 18;
            this.lblTask.Text = "Task:";
            this.lblTask.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Location = new System.Drawing.Point(35, 56);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(42, 13);
            this.lblDetails.TabIndex = 18;
            this.lblDetails.Text = "Details:";
            this.lblDetails.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtExc1
            // 
            this.txtExc1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExc1.Location = new System.Drawing.Point(215, 134);
            this.txtExc1.Multiline = true;
            this.txtExc1.Name = "txtExc1";
            this.txtExc1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtExc1.Size = new System.Drawing.Size(216, 20);
            this.txtExc1.TabIndex = 27;
            // 
            // nudExc1
            // 
            this.nudExc1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudExc1.Location = new System.Drawing.Point(81, 135);
            this.nudExc1.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nudExc1.Name = "nudExc1";
            this.nudExc1.Size = new System.Drawing.Size(37, 20);
            this.nudExc1.TabIndex = 25;
            // 
            // lblExc1Text
            // 
            this.lblExc1Text.AutoSize = true;
            this.lblExc1Text.Location = new System.Drawing.Point(124, 137);
            this.lblExc1Text.Name = "lblExc1Text";
            this.lblExc1Text.Size = new System.Drawing.Size(87, 13);
            this.lblExc1Text.TabIndex = 26;
            this.lblExc1Text.Text = "minutes spent on";
            // 
            // lblException
            // 
            this.lblException.AutoSize = true;
            this.lblException.Location = new System.Drawing.Point(28, 137);
            this.lblException.Name = "lblException";
            this.lblException.Size = new System.Drawing.Size(47, 13);
            this.lblException.TabIndex = 24;
            this.lblException.Text = "Subtract";
            this.lblException.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "HH:mm yyyy-MM-dd";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(301, 108);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.ShowUpDown = true;
            this.dtpEnd.Size = new System.Drawing.Size(130, 20);
            this.dtpEnd.TabIndex = 23;
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(240, 111);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(55, 13);
            this.lblEndTime.TabIndex = 22;
            this.lblEndTime.Text = "End Time:";
            this.lblEndTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "HH:mm yyyy-MM-dd";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(83, 108);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.ShowUpDown = true;
            this.dtpStart.Size = new System.Drawing.Size(130, 20);
            this.dtpStart.TabIndex = 21;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(19, 111);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(58, 13);
            this.lblStartTime.TabIndex = 20;
            this.lblStartTime.Text = "Start Time:";
            this.lblStartTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frmConfirmEndTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 244);
            this.Controls.Add(this.grpPrevious);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.MinimumSize = new System.Drawing.Size(496, 144);
            this.Name = "frmConfirmEndTime";
            this.Text = "Confirm Previous Entry";
            ((System.ComponentModel.ISupportInitialize)(this.errProv)).EndInit();
            this.grpPrevious.ResumeLayout(false);
            this.pnlEntry.ResumeLayout(false);
            this.pnlEntry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExc1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errProv;
        private System.Windows.Forms.GroupBox grpPrevious;
        private System.Windows.Forms.Panel pnlEntry;
        private System.Windows.Forms.TextBox txtDetails;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.TextBox txtExc1;
        private System.Windows.Forms.NumericUpDown nudExc1;
        private System.Windows.Forms.Label lblExc1Text;
        private System.Windows.Forms.Label lblException;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblTaskVal;
        private System.Windows.Forms.Label lblProjectVal;
        private System.Windows.Forms.Label lblProject1;
        private System.Windows.Forms.Label lblTask;
    }
}