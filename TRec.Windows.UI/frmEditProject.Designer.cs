namespace TRec.Windows.UI
{
    partial class frmEditProject
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
            this.grpProj = new System.Windows.Forms.GroupBox();
            this.chkProjActive = new System.Windows.Forms.CheckBox();
            this.lblProjActive = new System.Windows.Forms.Label();
            this.txtProjName = new System.Windows.Forms.TextBox();
            this.lblProjDesc = new System.Windows.Forms.Label();
            this.txtProjId = new System.Windows.Forms.TextBox();
            this.lblProjId = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errProv = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpProj.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProv)).BeginInit();
            this.SuspendLayout();
            // 
            // grpProj
            // 
            this.grpProj.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpProj.Controls.Add(this.chkProjActive);
            this.grpProj.Controls.Add(this.lblProjActive);
            this.grpProj.Controls.Add(this.txtProjName);
            this.grpProj.Controls.Add(this.lblProjDesc);
            this.grpProj.Controls.Add(this.txtProjId);
            this.grpProj.Controls.Add(this.lblProjId);
            this.grpProj.Location = new System.Drawing.Point(12, 12);
            this.grpProj.Name = "grpProj";
            this.grpProj.Size = new System.Drawing.Size(456, 101);
            this.grpProj.TabIndex = 0;
            this.grpProj.TabStop = false;
            this.grpProj.Text = "Project Details";
            // 
            // chkProjActive
            // 
            this.chkProjActive.AutoSize = true;
            this.chkProjActive.Location = new System.Drawing.Point(86, 79);
            this.chkProjActive.Name = "chkProjActive";
            this.chkProjActive.Size = new System.Drawing.Size(15, 14);
            this.chkProjActive.TabIndex = 7;
            this.chkProjActive.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkProjActive.UseVisualStyleBackColor = true;
            // 
            // lblProjActive
            // 
            this.lblProjActive.AutoSize = true;
            this.lblProjActive.Location = new System.Drawing.Point(34, 79);
            this.lblProjActive.Name = "lblProjActive";
            this.lblProjActive.Size = new System.Drawing.Size(46, 13);
            this.lblProjActive.TabIndex = 6;
            this.lblProjActive.Text = "Active?:";
            this.lblProjActive.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtProjName
            // 
            this.txtProjName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProjName.Location = new System.Drawing.Point(86, 52);
            this.txtProjName.Name = "txtProjName";
            this.txtProjName.Size = new System.Drawing.Size(346, 20);
            this.txtProjName.TabIndex = 5;
            // 
            // lblProjDesc
            // 
            this.lblProjDesc.AutoSize = true;
            this.lblProjDesc.Location = new System.Drawing.Point(6, 55);
            this.lblProjDesc.Name = "lblProjDesc";
            this.lblProjDesc.Size = new System.Drawing.Size(74, 13);
            this.lblProjDesc.TabIndex = 4;
            this.lblProjDesc.Text = "Project Name:";
            this.lblProjDesc.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtProjId
            // 
            this.txtProjId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProjId.Enabled = false;
            this.txtProjId.Location = new System.Drawing.Point(86, 26);
            this.txtProjId.Name = "txtProjId";
            this.txtProjId.Size = new System.Drawing.Size(346, 20);
            this.txtProjId.TabIndex = 3;
            // 
            // lblProjId
            // 
            this.lblProjId.AutoSize = true;
            this.lblProjId.Location = new System.Drawing.Point(25, 29);
            this.lblProjId.Name = "lblProjId";
            this.lblProjId.Size = new System.Drawing.Size(55, 13);
            this.lblProjId.TabIndex = 2;
            this.lblProjId.Text = "Project Id:";
            this.lblProjId.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.Location = new System.Drawing.Point(243, 126);
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
            this.btnSave.Location = new System.Drawing.Point(162, 126);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Save Changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errProv
            // 
            this.errProv.ContainerControl = this;
            // 
            // frmEditProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 163);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpProj);
            this.MinimumSize = new System.Drawing.Size(496, 197);
            this.Name = "frmEditProject";
            this.Text = "Edit Project";
            this.grpProj.ResumeLayout(false);
            this.grpProj.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpProj;
        private System.Windows.Forms.TextBox txtProjId;
        private System.Windows.Forms.Label lblProjId;
        private System.Windows.Forms.TextBox txtProjName;
        private System.Windows.Forms.Label lblProjDesc;
        private System.Windows.Forms.CheckBox chkProjActive;
        private System.Windows.Forms.Label lblProjActive;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errProv;
    }
}