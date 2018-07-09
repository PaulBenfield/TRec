namespace TRec.Windows.UI
{
    partial class frmExtract
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
            this.bgwGenerate = new System.ComponentModel.BackgroundWorker();
            this.pnlRpt = new System.Windows.Forms.Panel();
            this.tcType = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grpFilters = new System.Windows.Forms.GroupBox();
            this.lblFiles = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGoalFilesRemove = new System.Windows.Forms.Button();
            this.btnGoalFilesAdd = new System.Windows.Forms.Button();
            this.lstGoalFiles = new System.Windows.Forms.ListBox();
            this.dtpGoalEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpGoalStart = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.lblReportType = new System.Windows.Forms.Label();
            this.cbxReportTypes = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExtract = new System.Windows.Forms.Button();
            this.tcType.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grpFilters.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgwGenerate
            // 
            this.bgwGenerate.DoWork += new System.ComponentModel.DoWorkEventHandler( this.bgwGenerate_DoWork );
            this.bgwGenerate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler( this.bgwGenerate_RunWorkerCompleted );
            // 
            // pnlRpt
            // 
            this.pnlRpt.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.pnlRpt.Location = new System.Drawing.Point( 12, 190 );
            this.pnlRpt.Name = "pnlRpt";
            this.pnlRpt.Size = new System.Drawing.Size( 538, 346 );
            this.pnlRpt.TabIndex = 1;
            // 
            // tcType
            // 
            this.tcType.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.tcType.Controls.Add( this.tabPage1 );
            this.tcType.Controls.Add( this.tabPage2 );
            this.tcType.Location = new System.Drawing.Point( 12, 3 );
            this.tcType.Name = "tcType";
            this.tcType.SelectedIndex = 0;
            this.tcType.Size = new System.Drawing.Size( 538, 158 );
            this.tcType.TabIndex = 2;
            this.tcType.SelectedIndexChanged += new System.EventHandler( this.tcType_SelectedIndexChanged );
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add( this.grpFilters );
            this.tabPage1.Location = new System.Drawing.Point( 4, 22 );
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding( 3 );
            this.tabPage1.Size = new System.Drawing.Size( 530, 132 );
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Time Recording";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grpFilters
            // 
            this.grpFilters.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.grpFilters.Controls.Add( this.lblFiles );
            this.grpFilters.Controls.Add( this.btnDelete );
            this.grpFilters.Controls.Add( this.btnAdd );
            this.grpFilters.Controls.Add( this.lstFiles );
            this.grpFilters.Controls.Add( this.dtpEnd );
            this.grpFilters.Controls.Add( this.lblEndDate );
            this.grpFilters.Controls.Add( this.dtpStart );
            this.grpFilters.Controls.Add( this.lblStartDate );
            this.grpFilters.Location = new System.Drawing.Point( 9, 2 );
            this.grpFilters.Name = "grpFilters";
            this.grpFilters.Size = new System.Drawing.Size( 513, 127 );
            this.grpFilters.TabIndex = 1;
            this.grpFilters.TabStop = false;
            this.grpFilters.Text = "Filter by";
            // 
            // lblFiles
            // 
            this.lblFiles.AutoSize = true;
            this.lblFiles.Location = new System.Drawing.Point( 28, 70 );
            this.lblFiles.Name = "lblFiles";
            this.lblFiles.Size = new System.Drawing.Size( 81, 13 );
            this.lblFiles.TabIndex = 9;
            this.lblFiles.Text = "Time Entry Files";
            this.lblFiles.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnDelete.Location = new System.Drawing.Point( 477, 94 );
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size( 20, 23 );
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "-";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler( this.btnDelete_Click );
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnAdd.Location = new System.Drawing.Point( 477, 65 );
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size( 20, 23 );
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler( this.btnAdd_Click );
            // 
            // lstFiles
            // 
            this.lstFiles.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.Location = new System.Drawing.Point( 115, 65 );
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size( 356, 56 );
            this.lstFiles.TabIndex = 6;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point( 115, 38 );
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size( 196, 20 );
            this.dtpEnd.TabIndex = 3;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point( 57, 44 );
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size( 52, 13 );
            this.lblEndDate.TabIndex = 2;
            this.lblEndDate.Text = "End Date";
            this.lblEndDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point( 115, 12 );
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size( 196, 20 );
            this.dtpStart.TabIndex = 1;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point( 54, 18 );
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size( 55, 13 );
            this.lblStartDate.TabIndex = 0;
            this.lblStartDate.Text = "Start Date";
            this.lblStartDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add( this.groupBox1 );
            this.tabPage2.Location = new System.Drawing.Point( 4, 22 );
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding( 3 );
            this.tabPage2.Size = new System.Drawing.Size( 530, 132 );
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Goals";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.groupBox1.Controls.Add( this.label1 );
            this.groupBox1.Controls.Add( this.btnGoalFilesRemove );
            this.groupBox1.Controls.Add( this.btnGoalFilesAdd );
            this.groupBox1.Controls.Add( this.lstGoalFiles );
            this.groupBox1.Controls.Add( this.dtpGoalEnd );
            this.groupBox1.Controls.Add( this.label2 );
            this.groupBox1.Controls.Add( this.dtpGoalStart );
            this.groupBox1.Controls.Add( this.label3 );
            this.groupBox1.Location = new System.Drawing.Point( 9, 2 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 513, 127 );
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter by";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 28, 70 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 81, 13 );
            this.label1.TabIndex = 9;
            this.label1.Text = "Time Entry Files";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnGoalFilesRemove
            // 
            this.btnGoalFilesRemove.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnGoalFilesRemove.Location = new System.Drawing.Point( 477, 94 );
            this.btnGoalFilesRemove.Name = "btnGoalFilesRemove";
            this.btnGoalFilesRemove.Size = new System.Drawing.Size( 20, 23 );
            this.btnGoalFilesRemove.TabIndex = 8;
            this.btnGoalFilesRemove.Text = "-";
            this.btnGoalFilesRemove.UseVisualStyleBackColor = true;
            this.btnGoalFilesRemove.Click += new System.EventHandler( this.btnGoalFilesRemove_Click );
            // 
            // btnGoalFilesAdd
            // 
            this.btnGoalFilesAdd.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnGoalFilesAdd.Location = new System.Drawing.Point( 477, 65 );
            this.btnGoalFilesAdd.Name = "btnGoalFilesAdd";
            this.btnGoalFilesAdd.Size = new System.Drawing.Size( 20, 23 );
            this.btnGoalFilesAdd.TabIndex = 7;
            this.btnGoalFilesAdd.Text = "+";
            this.btnGoalFilesAdd.UseVisualStyleBackColor = true;
            this.btnGoalFilesAdd.Click += new System.EventHandler( this.btnGoalFilesAdd_Click );
            // 
            // lstGoalFiles
            // 
            this.lstGoalFiles.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.lstGoalFiles.FormattingEnabled = true;
            this.lstGoalFiles.Location = new System.Drawing.Point( 115, 65 );
            this.lstGoalFiles.Name = "lstGoalFiles";
            this.lstGoalFiles.Size = new System.Drawing.Size( 356, 56 );
            this.lstGoalFiles.TabIndex = 6;
            // 
            // dtpGoalEnd
            // 
            this.dtpGoalEnd.Location = new System.Drawing.Point( 115, 38 );
            this.dtpGoalEnd.Name = "dtpGoalEnd";
            this.dtpGoalEnd.Size = new System.Drawing.Size( 196, 20 );
            this.dtpGoalEnd.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 57, 44 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 52, 13 );
            this.label2.TabIndex = 2;
            this.label2.Text = "End Date";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dtpGoalStart
            // 
            this.dtpGoalStart.Location = new System.Drawing.Point( 115, 12 );
            this.dtpGoalStart.Name = "dtpGoalStart";
            this.dtpGoalStart.Size = new System.Drawing.Size( 196, 20 );
            this.dtpGoalStart.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 54, 18 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 55, 13 );
            this.label3.TabIndex = 0;
            this.label3.Text = "Start Date";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblReportType
            // 
            this.lblReportType.AutoSize = true;
            this.lblReportType.Location = new System.Drawing.Point( 68, 168 );
            this.lblReportType.Name = "lblReportType";
            this.lblReportType.Size = new System.Drawing.Size( 66, 13 );
            this.lblReportType.TabIndex = 19;
            this.lblReportType.Text = "Report Type";
            this.lblReportType.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbxReportTypes
            // 
            this.cbxReportTypes.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.cbxReportTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxReportTypes.FormattingEnabled = true;
            this.cbxReportTypes.Location = new System.Drawing.Point( 140, 163 );
            this.cbxReportTypes.Name = "cbxReportTypes";
            this.cbxReportTypes.Size = new System.Drawing.Size( 194, 21 );
            this.cbxReportTypes.TabIndex = 18;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point( 421, 163 );
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size( 75, 23 );
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler( this.btnCancel_Click );
            // 
            // btnExtract
            // 
            this.btnExtract.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnExtract.Location = new System.Drawing.Point( 340, 163 );
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size( 75, 23 );
            this.btnExtract.TabIndex = 16;
            this.btnExtract.Text = "&Run Report";
            this.btnExtract.UseVisualStyleBackColor = true;
            this.btnExtract.Click += new System.EventHandler( this.btnExtract_Click );
            // 
            // frmExtract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 562, 548 );
            this.Controls.Add( this.lblReportType );
            this.Controls.Add( this.cbxReportTypes );
            this.Controls.Add( this.btnCancel );
            this.Controls.Add( this.btnExtract );
            this.Controls.Add( this.tcType );
            this.Controls.Add( this.pnlRpt );
            this.MinimumSize = new System.Drawing.Size( 578, 584 );
            this.Name = "frmExtract";
            this.Text = "Report On Time Entries";
            this.tcType.ResumeLayout( false );
            this.tabPage1.ResumeLayout( false );
            this.grpFilters.ResumeLayout( false );
            this.grpFilters.PerformLayout();
            this.tabPage2.ResumeLayout( false );
            this.groupBox1.ResumeLayout( false );
            this.groupBox1.PerformLayout();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bgwGenerate;
        private System.Windows.Forms.Panel pnlRpt;
        private System.Windows.Forms.TabControl tcType;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox grpFilters;
        private System.Windows.Forms.Label lblFiles;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblReportType;
        private System.Windows.Forms.ComboBox cbxReportTypes;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGoalFilesRemove;
        private System.Windows.Forms.Button btnGoalFilesAdd;
        private System.Windows.Forms.ListBox lstGoalFiles;
        private System.Windows.Forms.DateTimePicker dtpGoalEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpGoalStart;
        private System.Windows.Forms.Label label3;
    }
}