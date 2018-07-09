﻿namespace TRec.Windows.UI
{
    partial class frmEditTask
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
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.lblTaskName = new System.Windows.Forms.Label();
            this.txtTaskId = new System.Windows.Forms.TextBox();
            this.lblTaskId = new System.Windows.Forms.Label();
            this.chkTaskActive = new System.Windows.Forms.CheckBox();
            this.lblProjActive = new System.Windows.Forms.Label();
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
            this.grpProj.Controls.Add(this.txtTaskName);
            this.grpProj.Controls.Add(this.lblTaskName);
            this.grpProj.Controls.Add(this.txtTaskId);
            this.grpProj.Controls.Add(this.lblTaskId);
            this.grpProj.Controls.Add(this.chkTaskActive);
            this.grpProj.Controls.Add(this.lblProjActive);
            this.grpProj.Controls.Add(this.txtProjName);
            this.grpProj.Controls.Add(this.lblProjDesc);
            this.grpProj.Location = new System.Drawing.Point(12, 12);
            this.grpProj.Name = "grpProj";
            this.grpProj.Size = new System.Drawing.Size(456, 120);
            this.grpProj.TabIndex = 0;
            this.grpProj.TabStop = false;
            this.grpProj.Text = "Project Details";
            // 
            // txtTaskName
            // 
            this.txtTaskName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTaskName.Location = new System.Drawing.Point(86, 71);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(346, 20);
            this.txtTaskName.TabIndex = 11;
            // 
            // lblTaskName
            // 
            this.lblTaskName.AutoSize = true;
            this.lblTaskName.Location = new System.Drawing.Point(15, 74);
            this.lblTaskName.Name = "lblTaskName";
            this.lblTaskName.Size = new System.Drawing.Size(65, 13);
            this.lblTaskName.TabIndex = 10;
            this.lblTaskName.Text = "Task Name:";
            this.lblTaskName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtTaskId
            // 
            this.txtTaskId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTaskId.Enabled = false;
            this.txtTaskId.Location = new System.Drawing.Point(86, 45);
            this.txtTaskId.Name = "txtTaskId";
            this.txtTaskId.Size = new System.Drawing.Size(346, 20);
            this.txtTaskId.TabIndex = 9;
            // 
            // lblTaskId
            // 
            this.lblTaskId.AutoSize = true;
            this.lblTaskId.Location = new System.Drawing.Point(34, 48);
            this.lblTaskId.Name = "lblTaskId";
            this.lblTaskId.Size = new System.Drawing.Size(46, 13);
            this.lblTaskId.TabIndex = 8;
            this.lblTaskId.Text = "Task Id:";
            this.lblTaskId.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkTaskActive
            // 
            this.chkTaskActive.AutoSize = true;
            this.chkTaskActive.Location = new System.Drawing.Point(86, 97);
            this.chkTaskActive.Name = "chkTaskActive";
            this.chkTaskActive.Size = new System.Drawing.Size(15, 14);
            this.chkTaskActive.TabIndex = 7;
            this.chkTaskActive.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTaskActive.UseVisualStyleBackColor = true;
            // 
            // lblProjActive
            // 
            this.lblProjActive.AutoSize = true;
            this.lblProjActive.Location = new System.Drawing.Point(34, 97);
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
            this.txtProjName.Enabled = false;
            this.txtProjName.Location = new System.Drawing.Point(86, 19);
            this.txtProjName.Name = "txtProjName";
            this.txtProjName.Size = new System.Drawing.Size(346, 20);
            this.txtProjName.TabIndex = 5;
            // 
            // lblProjDesc
            // 
            this.lblProjDesc.AutoSize = true;
            this.lblProjDesc.Location = new System.Drawing.Point(6, 22);
            this.lblProjDesc.Name = "lblProjDesc";
            this.lblProjDesc.Size = new System.Drawing.Size(74, 13);
            this.lblProjDesc.TabIndex = 4;
            this.lblProjDesc.Text = "Project Name:";
            this.lblProjDesc.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.Location = new System.Drawing.Point(243, 138);
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
            this.btnSave.Location = new System.Drawing.Point(162, 138);
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
            // frmEditTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 173);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpProj);
            this.MinimumSize = new System.Drawing.Size(496, 197);
            this.Name = "frmEditTask";
            this.Text = "Edit Project";
            this.grpProj.ResumeLayout(false);
            this.grpProj.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpProj;
        private System.Windows.Forms.TextBox txtProjName;
        private System.Windows.Forms.Label lblProjDesc;
        private System.Windows.Forms.CheckBox chkTaskActive;
        private System.Windows.Forms.Label lblProjActive;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errProv;
        private System.Windows.Forms.TextBox txtTaskName;
        private System.Windows.Forms.Label lblTaskName;
        private System.Windows.Forms.TextBox txtTaskId;
        private System.Windows.Forms.Label lblTaskId;
    }
}