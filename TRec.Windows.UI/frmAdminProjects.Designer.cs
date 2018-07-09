namespace TRec.Windows.UI
{
    partial class frmAdminProjects
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
            this.grpProjects = new System.Windows.Forms.GroupBox();
            this.btnAddProj = new System.Windows.Forms.Button();
            this.dgProjects = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activeDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectBindingSource = new System.Windows.Forms.BindingSource( this.components );
            this.dgTasks = new System.Windows.Forms.DataGridView();
            this.taskBindingSource = new System.Windows.Forms.BindingSource( this.components );
            this.grpTasks = new System.Windows.Forms.GroupBox();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.grpUsers = new System.Windows.Forms.GroupBox();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.dgUsers = new System.Windows.Forms.DataGridView();
            this.userBindingSource = new System.Windows.Forms.BindingSource( this.components );
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activeDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.displayNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpProjects.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.dgProjects ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.projectBindingSource ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.dgTasks ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.taskBindingSource ) ).BeginInit();
            this.grpTasks.SuspendLayout();
            this.grpUsers.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.dgUsers ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.userBindingSource ) ).BeginInit();
            this.SuspendLayout();
            // 
            // grpProjects
            // 
            this.grpProjects.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.grpProjects.Controls.Add( this.btnAddProj );
            this.grpProjects.Controls.Add( this.dgProjects );
            this.grpProjects.Location = new System.Drawing.Point( 13, 13 );
            this.grpProjects.Name = "grpProjects";
            this.grpProjects.Size = new System.Drawing.Size( 588, 163 );
            this.grpProjects.TabIndex = 0;
            this.grpProjects.TabStop = false;
            this.grpProjects.Text = "Projects";
            // 
            // btnAddProj
            // 
            this.btnAddProj.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnAddProj.Location = new System.Drawing.Point( 507, 134 );
            this.btnAddProj.Name = "btnAddProj";
            this.btnAddProj.Size = new System.Drawing.Size( 75, 23 );
            this.btnAddProj.TabIndex = 3;
            this.btnAddProj.Text = "Add &Project";
            this.btnAddProj.UseVisualStyleBackColor = true;
            this.btnAddProj.Click += new System.EventHandler( this.btnAddProj_Click );
            // 
            // dgProjects
            // 
            this.dgProjects.AllowUserToAddRows = false;
            this.dgProjects.AllowUserToDeleteRows = false;
            this.dgProjects.AllowUserToOrderColumns = true;
            this.dgProjects.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.dgProjects.AutoGenerateColumns = false;
            this.dgProjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProjects.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.activeDataGridViewCheckBoxColumn} );
            this.dgProjects.DataSource = this.projectBindingSource;
            this.dgProjects.Location = new System.Drawing.Point( 3, 16 );
            this.dgProjects.MultiSelect = false;
            this.dgProjects.Name = "dgProjects";
            this.dgProjects.ReadOnly = true;
            this.dgProjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProjects.Size = new System.Drawing.Size( 582, 112 );
            this.dgProjects.TabIndex = 0;
            this.dgProjects.DoubleClick += new System.EventHandler( this.dgProjects_DoubleClick );
            this.dgProjects.SelectionChanged += new System.EventHandler( this.dgProjects_SelectionChanged );
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 50;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Project Name";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // activeDataGridViewCheckBoxColumn
            // 
            this.activeDataGridViewCheckBoxColumn.DataPropertyName = "Active";
            this.activeDataGridViewCheckBoxColumn.HeaderText = "Active";
            this.activeDataGridViewCheckBoxColumn.Name = "activeDataGridViewCheckBoxColumn";
            this.activeDataGridViewCheckBoxColumn.ReadOnly = true;
            this.activeDataGridViewCheckBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.activeDataGridViewCheckBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.activeDataGridViewCheckBoxColumn.Width = 50;
            // 
            // projectBindingSource
            // 
            this.projectBindingSource.DataSource = typeof( TRec.BusinessLayer.Project );
            // 
            // dgTasks
            // 
            this.dgTasks.AllowUserToAddRows = false;
            this.dgTasks.AllowUserToDeleteRows = false;
            this.dgTasks.AllowUserToOrderColumns = true;
            this.dgTasks.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.dgTasks.AutoGenerateColumns = false;
            this.dgTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTasks.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.descriptionDataGridViewTextBoxColumn1,
            this.activeDataGridViewCheckBoxColumn1} );
            this.dgTasks.DataSource = this.taskBindingSource;
            this.dgTasks.Location = new System.Drawing.Point( 3, 16 );
            this.dgTasks.MultiSelect = false;
            this.dgTasks.Name = "dgTasks";
            this.dgTasks.ReadOnly = true;
            this.dgTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTasks.Size = new System.Drawing.Size( 582, 112 );
            this.dgTasks.TabIndex = 0;
            this.dgTasks.DoubleClick += new System.EventHandler( this.dgTasks_DoubleClick );
            this.dgTasks.SelectionChanged += new System.EventHandler( this.dgTasks_SelectionChanged );
            // 
            // taskBindingSource
            // 
            this.taskBindingSource.DataSource = typeof( TRec.BusinessLayer.Task );
            // 
            // grpTasks
            // 
            this.grpTasks.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.grpTasks.Controls.Add( this.btnAddTask );
            this.grpTasks.Controls.Add( this.dgTasks );
            this.grpTasks.Location = new System.Drawing.Point( 13, 182 );
            this.grpTasks.Name = "grpTasks";
            this.grpTasks.Size = new System.Drawing.Size( 588, 163 );
            this.grpTasks.TabIndex = 1;
            this.grpTasks.TabStop = false;
            this.grpTasks.Text = "Tasks for selected Project";
            // 
            // btnAddTask
            // 
            this.btnAddTask.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnAddTask.Location = new System.Drawing.Point( 507, 134 );
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size( 75, 23 );
            this.btnAddTask.TabIndex = 3;
            this.btnAddTask.Text = "Add &Task";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler( this.btnAddTask_Click );
            // 
            // grpUsers
            // 
            this.grpUsers.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.grpUsers.Controls.Add( this.btnAddUser );
            this.grpUsers.Controls.Add( this.dgUsers );
            this.grpUsers.Location = new System.Drawing.Point( 13, 351 );
            this.grpUsers.Name = "grpUsers";
            this.grpUsers.Size = new System.Drawing.Size( 588, 163 );
            this.grpUsers.TabIndex = 2;
            this.grpUsers.TabStop = false;
            this.grpUsers.Text = "Users assigned to selected Task";
            // 
            // btnAddUser
            // 
            this.btnAddUser.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnAddUser.Location = new System.Drawing.Point( 459, 134 );
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size( 123, 23 );
            this.btnAddUser.TabIndex = 3;
            this.btnAddUser.Text = "Add &User Access";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler( this.btnAddUser_Click );
            // 
            // dgUsers
            // 
            this.dgUsers.AllowUserToAddRows = false;
            this.dgUsers.AllowUserToDeleteRows = false;
            this.dgUsers.AllowUserToOrderColumns = true;
            this.dgUsers.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.dgUsers.AutoGenerateColumns = false;
            this.dgUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgUsers.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.userIdDataGridViewTextBoxColumn,
            this.userNameDataGridViewTextBoxColumn,
            this.displayNameDataGridViewTextBoxColumn} );
            this.dgUsers.DataSource = this.userBindingSource;
            this.dgUsers.Location = new System.Drawing.Point( 3, 16 );
            this.dgUsers.MultiSelect = false;
            this.dgUsers.Name = "dgUsers";
            this.dgUsers.ReadOnly = true;
            this.dgUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgUsers.Size = new System.Drawing.Size( 582, 112 );
            this.dgUsers.TabIndex = 0;
            this.dgUsers.DoubleClick += new System.EventHandler( this.dgUsers_DoubleClick );
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof( TRec.BusinessLayer.User );
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            this.idDataGridViewTextBoxColumn1.ReadOnly = true;
            this.idDataGridViewTextBoxColumn1.Width = 50;
            // 
            // descriptionDataGridViewTextBoxColumn1
            // 
            this.descriptionDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionDataGridViewTextBoxColumn1.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn1.HeaderText = "Task Name";
            this.descriptionDataGridViewTextBoxColumn1.Name = "descriptionDataGridViewTextBoxColumn1";
            this.descriptionDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // activeDataGridViewCheckBoxColumn1
            // 
            this.activeDataGridViewCheckBoxColumn1.DataPropertyName = "Active";
            this.activeDataGridViewCheckBoxColumn1.HeaderText = "Active";
            this.activeDataGridViewCheckBoxColumn1.Name = "activeDataGridViewCheckBoxColumn1";
            this.activeDataGridViewCheckBoxColumn1.ReadOnly = true;
            this.activeDataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.activeDataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.activeDataGridViewCheckBoxColumn1.Width = 50;
            // 
            // userIdDataGridViewTextBoxColumn
            // 
            this.userIdDataGridViewTextBoxColumn.DataPropertyName = "UserId";
            this.userIdDataGridViewTextBoxColumn.HeaderText = "UserId";
            this.userIdDataGridViewTextBoxColumn.Name = "userIdDataGridViewTextBoxColumn";
            this.userIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.userIdDataGridViewTextBoxColumn.Width = 50;
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "UserName";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            this.userNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.userNameDataGridViewTextBoxColumn.Width = 200;
            // 
            // displayNameDataGridViewTextBoxColumn
            // 
            this.displayNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.displayNameDataGridViewTextBoxColumn.DataPropertyName = "DisplayName";
            this.displayNameDataGridViewTextBoxColumn.HeaderText = "DisplayName";
            this.displayNameDataGridViewTextBoxColumn.Name = "displayNameDataGridViewTextBoxColumn";
            this.displayNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmAdminProjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 613, 524 );
            this.Controls.Add( this.grpUsers );
            this.Controls.Add( this.grpTasks );
            this.Controls.Add( this.grpProjects );
            this.MinimumSize = new System.Drawing.Size( 629, 560 );
            this.Name = "frmAdminProjects";
            this.Text = "Projects, Tasks & User Access";
            this.grpProjects.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.dgProjects ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.projectBindingSource ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.dgTasks ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.taskBindingSource ) ).EndInit();
            this.grpTasks.ResumeLayout( false );
            this.grpUsers.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.dgUsers ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.userBindingSource ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.GroupBox grpProjects;
        private System.Windows.Forms.DataGridView dgProjects;
        private System.Windows.Forms.BindingSource projectBindingSource;
        private System.Windows.Forms.Button btnAddProj;
        private System.Windows.Forms.DataGridView dgTasks;
        private System.Windows.Forms.GroupBox grpTasks;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.BindingSource taskBindingSource;
        private System.Windows.Forms.GroupBox grpUsers;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.DataGridView dgUsers;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn activeDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn activeDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn displayNameDataGridViewTextBoxColumn;
    }
}