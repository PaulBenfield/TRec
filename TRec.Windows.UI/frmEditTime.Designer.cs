namespace TRec.Windows.UI
{
    partial class frmEditTime
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDeleteEntry = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errProv = new System.Windows.Forms.ErrorProvider( this.components );
            this.tcEntries = new System.Windows.Forms.TabControl();
            this.tabPrevious = new System.Windows.Forms.TabPage();
            this.tabCurrent = new System.Windows.Forms.TabPage();
            this.gbxTimeDetail = new System.Windows.Forms.GroupBox();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.lblDetails = new System.Windows.Forms.Label();
            this.txtExc1 = new System.Windows.Forms.TextBox();
            this.nudExc1 = new System.Windows.Forms.NumericUpDown();
            this.lblExc1Text = new System.Windows.Forms.Label();
            this.lblException = new System.Windows.Forms.Label();
            this.cbxProjects = new System.Windows.Forms.ComboBox();
            this.cbxTasks = new System.Windows.Forms.ComboBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblTask = new System.Windows.Forms.Label();
            this.lblProject = new System.Windows.Forms.Label();
            this.tabNext = new System.Windows.Forms.TabPage();
            ( (System.ComponentModel.ISupportInitialize)( this.errProv ) ).BeginInit();
            this.tcEntries.SuspendLayout();
            this.tabCurrent.SuspendLayout();
            this.gbxTimeDetail.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.nudExc1 ) ).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.Location = new System.Drawing.Point( 127, 235 );
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size( 75, 23 );
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save Changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler( this.btnSave_Click );
            // 
            // btnDeleteEntry
            // 
            this.btnDeleteEntry.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDeleteEntry.Location = new System.Drawing.Point( 208, 235 );
            this.btnDeleteEntry.Name = "btnDeleteEntry";
            this.btnDeleteEntry.Size = new System.Drawing.Size( 75, 23 );
            this.btnDeleteEntry.TabIndex = 2;
            this.btnDeleteEntry.Text = "&Delete";
            this.btnDeleteEntry.UseVisualStyleBackColor = true;
            this.btnDeleteEntry.Click += new System.EventHandler( this.btnDeleteEntry_Click );
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.Location = new System.Drawing.Point( 289, 235 );
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size( 75, 23 );
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler( this.btnCancel_Click );
            // 
            // errProv
            // 
            this.errProv.ContainerControl = this;
            // 
            // tcEntries
            // 
            this.tcEntries.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.tcEntries.Controls.Add( this.tabPrevious );
            this.tcEntries.Controls.Add( this.tabCurrent );
            this.tcEntries.Controls.Add( this.tabNext );
            this.tcEntries.Location = new System.Drawing.Point( 7, 0 );
            this.tcEntries.Name = "tcEntries";
            this.tcEntries.SelectedIndex = 0;
            this.tcEntries.Size = new System.Drawing.Size( 462, 228 );
            this.tcEntries.TabIndex = 4;
            // 
            // tabPrevious
            // 
            this.tabPrevious.Location = new System.Drawing.Point( 4, 22 );
            this.tabPrevious.Name = "tabPrevious";
            this.tabPrevious.Padding = new System.Windows.Forms.Padding( 3 );
            this.tabPrevious.Size = new System.Drawing.Size( 454, 202 );
            this.tabPrevious.TabIndex = 0;
            this.tabPrevious.Text = "Previous";
            this.tabPrevious.UseVisualStyleBackColor = true;
            // 
            // tabCurrent
            // 
            this.tabCurrent.Controls.Add( this.gbxTimeDetail );
            this.tabCurrent.Location = new System.Drawing.Point( 4, 22 );
            this.tabCurrent.Name = "tabCurrent";
            this.tabCurrent.Padding = new System.Windows.Forms.Padding( 3 );
            this.tabCurrent.Size = new System.Drawing.Size( 454, 202 );
            this.tabCurrent.TabIndex = 1;
            this.tabCurrent.Text = "Current (Editable)";
            this.tabCurrent.UseVisualStyleBackColor = true;
            // 
            // gbxTimeDetail
            // 
            this.gbxTimeDetail.Controls.Add( this.txtDetails );
            this.gbxTimeDetail.Controls.Add( this.lblDetails );
            this.gbxTimeDetail.Controls.Add( this.txtExc1 );
            this.gbxTimeDetail.Controls.Add( this.nudExc1 );
            this.gbxTimeDetail.Controls.Add( this.lblExc1Text );
            this.gbxTimeDetail.Controls.Add( this.lblException );
            this.gbxTimeDetail.Controls.Add( this.cbxProjects );
            this.gbxTimeDetail.Controls.Add( this.cbxTasks );
            this.gbxTimeDetail.Controls.Add( this.dtpEnd );
            this.gbxTimeDetail.Controls.Add( this.lblEndTime );
            this.gbxTimeDetail.Controls.Add( this.dtpStart );
            this.gbxTimeDetail.Controls.Add( this.lblStartTime );
            this.gbxTimeDetail.Controls.Add( this.lblTask );
            this.gbxTimeDetail.Controls.Add( this.lblProject );
            this.gbxTimeDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxTimeDetail.Location = new System.Drawing.Point( 3, 3 );
            this.gbxTimeDetail.Name = "gbxTimeDetail";
            this.gbxTimeDetail.Size = new System.Drawing.Size( 448, 196 );
            this.gbxTimeDetail.TabIndex = 1;
            this.gbxTimeDetail.TabStop = false;
            this.gbxTimeDetail.Text = "Edit Time Entry";
            // 
            // txtDetails
            // 
            this.txtDetails.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.txtDetails.Location = new System.Drawing.Point( 72, 78 );
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetails.Size = new System.Drawing.Size( 346, 47 );
            this.txtDetails.TabIndex = 19;
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Location = new System.Drawing.Point( 24, 81 );
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size( 42, 13 );
            this.lblDetails.TabIndex = 18;
            this.lblDetails.Text = "Details:";
            this.lblDetails.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtExc1
            // 
            this.txtExc1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.txtExc1.Location = new System.Drawing.Point( 204, 157 );
            this.txtExc1.Name = "txtExc1";
            this.txtExc1.Size = new System.Drawing.Size( 214, 20 );
            this.txtExc1.TabIndex = 27;
            // 
            // nudExc1
            // 
            this.nudExc1.Increment = new decimal( new int[] {
            5,
            0,
            0,
            0} );
            this.nudExc1.Location = new System.Drawing.Point( 70, 158 );
            this.nudExc1.Maximum = new decimal( new int[] {
            120,
            0,
            0,
            0} );
            this.nudExc1.Name = "nudExc1";
            this.nudExc1.Size = new System.Drawing.Size( 37, 20 );
            this.nudExc1.TabIndex = 25;
            // 
            // lblExc1Text
            // 
            this.lblExc1Text.AutoSize = true;
            this.lblExc1Text.Location = new System.Drawing.Point( 113, 160 );
            this.lblExc1Text.Name = "lblExc1Text";
            this.lblExc1Text.Size = new System.Drawing.Size( 87, 13 );
            this.lblExc1Text.TabIndex = 26;
            this.lblExc1Text.Text = "minutes spent on";
            // 
            // lblException
            // 
            this.lblException.AutoSize = true;
            this.lblException.Location = new System.Drawing.Point( 17, 160 );
            this.lblException.Name = "lblException";
            this.lblException.Size = new System.Drawing.Size( 47, 13 );
            this.lblException.TabIndex = 24;
            this.lblException.Text = "Subtract";
            this.lblException.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbxProjects
            // 
            this.cbxProjects.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.cbxProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProjects.FormattingEnabled = true;
            this.cbxProjects.Location = new System.Drawing.Point( 72, 19 );
            this.cbxProjects.Name = "cbxProjects";
            this.cbxProjects.Size = new System.Drawing.Size( 348, 21 );
            this.cbxProjects.TabIndex = 15;
            this.cbxProjects.SelectedIndexChanged += new System.EventHandler( this.cbxProjects_SelectedIndexChanged );
            // 
            // cbxTasks
            // 
            this.cbxTasks.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.cbxTasks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTasks.FormattingEnabled = true;
            this.cbxTasks.Location = new System.Drawing.Point( 72, 50 );
            this.cbxTasks.Name = "cbxTasks";
            this.cbxTasks.Size = new System.Drawing.Size( 348, 21 );
            this.cbxTasks.TabIndex = 17;
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "HH:mm yyyy-MM-dd";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point( 285, 131 );
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.ShowUpDown = true;
            this.dtpEnd.Size = new System.Drawing.Size( 135, 20 );
            this.dtpEnd.TabIndex = 23;
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point( 227, 134 );
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size( 55, 13 );
            this.lblEndTime.TabIndex = 22;
            this.lblEndTime.Text = "End Time:";
            this.lblEndTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "HH:mm yyyy-MM-dd";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point( 72, 131 );
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.ShowUpDown = true;
            this.dtpStart.Size = new System.Drawing.Size( 130, 20 );
            this.dtpStart.TabIndex = 21;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point( 8, 134 );
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size( 58, 13 );
            this.lblStartTime.TabIndex = 20;
            this.lblStartTime.Text = "Start Time:";
            this.lblStartTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTask
            // 
            this.lblTask.AutoSize = true;
            this.lblTask.Location = new System.Drawing.Point( 32, 53 );
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size( 34, 13 );
            this.lblTask.TabIndex = 16;
            this.lblTask.Text = "Task:";
            this.lblTask.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Location = new System.Drawing.Point( 23, 22 );
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size( 43, 13 );
            this.lblProject.TabIndex = 14;
            this.lblProject.Text = "Project:";
            this.lblProject.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tabNext
            // 
            this.tabNext.Location = new System.Drawing.Point( 4, 22 );
            this.tabNext.Name = "tabNext";
            this.tabNext.Padding = new System.Windows.Forms.Padding( 3 );
            this.tabNext.Size = new System.Drawing.Size( 454, 202 );
            this.tabNext.TabIndex = 2;
            this.tabNext.Text = "Next";
            this.tabNext.UseVisualStyleBackColor = true;
            // 
            // frmEditTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 482, 270 );
            this.Controls.Add( this.tcEntries );
            this.Controls.Add( this.btnCancel );
            this.Controls.Add( this.btnDeleteEntry );
            this.Controls.Add( this.btnSave );
            this.MinimumSize = new System.Drawing.Size( 490, 277 );
            this.Name = "frmEditTime";
            this.Text = "Edit Entry";
            ( (System.ComponentModel.ISupportInitialize)( this.errProv ) ).EndInit();
            this.tcEntries.ResumeLayout( false );
            this.tabCurrent.ResumeLayout( false );
            this.gbxTimeDetail.ResumeLayout( false );
            this.gbxTimeDetail.PerformLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.nudExc1 ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDeleteEntry;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider errProv;
        private System.Windows.Forms.TabControl tcEntries;
        private System.Windows.Forms.TabPage tabPrevious;
        private System.Windows.Forms.TabPage tabCurrent;
        private System.Windows.Forms.GroupBox gbxTimeDetail;
        private System.Windows.Forms.TextBox txtDetails;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.TextBox txtExc1;
        private System.Windows.Forms.NumericUpDown nudExc1;
        private System.Windows.Forms.Label lblExc1Text;
        private System.Windows.Forms.Label lblException;
        private System.Windows.Forms.ComboBox cbxProjects;
        private System.Windows.Forms.ComboBox cbxTasks;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblTask;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.TabPage tabNext;

    }
}