namespace TRec.Windows.UI
{
    partial class frmAddProject
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
            this.txtProjName = new System.Windows.Forms.TextBox();
            this.lblProjDesc = new System.Windows.Forms.Label();
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
            this.grpProj.Controls.Add(this.txtProjName);
            this.grpProj.Controls.Add(this.lblProjDesc);
            this.grpProj.Location = new System.Drawing.Point(12, 12);
            this.grpProj.Name = "grpProj";
            this.grpProj.Size = new System.Drawing.Size(456, 51);
            this.grpProj.TabIndex = 0;
            this.grpProj.TabStop = false;
            this.grpProj.Text = "Project Details";
            // 
            // txtProjName
            // 
            this.txtProjName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProjName.Location = new System.Drawing.Point(87, 19);
            this.txtProjName.Name = "txtProjName";
            this.txtProjName.Size = new System.Drawing.Size(346, 20);
            this.txtProjName.TabIndex = 5;
            // 
            // lblProjDesc
            // 
            this.lblProjDesc.AutoSize = true;
            this.lblProjDesc.Location = new System.Drawing.Point(7, 22);
            this.lblProjDesc.Name = "lblProjDesc";
            this.lblProjDesc.Size = new System.Drawing.Size(74, 13);
            this.lblProjDesc.TabIndex = 4;
            this.lblProjDesc.Text = "Project Name:";
            this.lblProjDesc.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.Location = new System.Drawing.Point(243, 73);
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
            this.btnSave.Location = new System.Drawing.Point(162, 73);
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
            // frmAddProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 110);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpProj);
            this.MinimumSize = new System.Drawing.Size(496, 144);
            this.Name = "frmAddProject";
            this.Text = "Add Project";
            this.grpProj.ResumeLayout(false);
            this.grpProj.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpProj;
        private System.Windows.Forms.TextBox txtProjName;
        private System.Windows.Forms.Label lblProjDesc;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errProv;
    }
}