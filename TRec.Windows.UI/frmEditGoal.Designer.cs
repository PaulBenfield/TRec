namespace TRec.Windows.UI
{
    partial class frmEditGoal
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
            this.lblSMART = new System.Windows.Forms.Label();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.dtpTarget = new System.Windows.Forms.DateTimePicker();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.txtMeasure = new System.Windows.Forms.TextBox();
            this.lblMeasure = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.grpCompleted = new System.Windows.Forms.GroupBox();
            this.pnlCompleted = new System.Windows.Forms.Panel();
            this.dtpResultDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trkTimeliness = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.lblResultDate = new System.Windows.Forms.Label();
            this.lblMeasureExcellent = new System.Windows.Forms.Label();
            this.lblMeasurePoor = new System.Windows.Forms.Label();
            this.trkMeasure = new System.Windows.Forms.TrackBar();
            this.lblMeasureRating = new System.Windows.Forms.Label();
            this.txtResultMeasure = new System.Windows.Forms.TextBox();
            this.lblResultMeasure = new System.Windows.Forms.Label();
            this.chkClosed = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDeleteEntry = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errProv = new System.Windows.Forms.ErrorProvider( this.components );
            this.txtImprovements = new System.Windows.Forms.TextBox();
            this.lblImprovements = new System.Windows.Forms.Label();
            this.txtPositives = new System.Windows.Forms.TextBox();
            this.lblPositives = new System.Windows.Forms.Label();
            this.grpDetails.SuspendLayout();
            this.grpCompleted.SuspendLayout();
            this.pnlCompleted.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.trkTimeliness ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.trkMeasure ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.errProv ) ).BeginInit();
            this.SuspendLayout();
            // 
            // lblSMART
            // 
            this.lblSMART.AutoSize = true;
            this.lblSMART.Location = new System.Drawing.Point( 128, 14 );
            this.lblSMART.Name = "lblSMART";
            this.lblSMART.Size = new System.Drawing.Size( 441, 13 );
            this.lblSMART.TabIndex = 0;
            this.lblSMART.Text = "*Hint: Make your goals SMART (specific; measurable; achievable; realistic and tim" +
                "e specific)";
            // 
            // grpDetails
            // 
            this.grpDetails.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.grpDetails.Controls.Add( this.dtpTarget );
            this.grpDetails.Controls.Add( this.lblDueDate );
            this.grpDetails.Controls.Add( this.txtMeasure );
            this.grpDetails.Controls.Add( this.lblMeasure );
            this.grpDetails.Controls.Add( this.txtDescription );
            this.grpDetails.Controls.Add( this.lblDescription );
            this.grpDetails.Controls.Add( this.lblSMART );
            this.grpDetails.Location = new System.Drawing.Point( 12, 12 );
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size( 589, 109 );
            this.grpDetails.TabIndex = 1;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Goal Details";
            // 
            // dtpTarget
            // 
            this.dtpTarget.Location = new System.Drawing.Point( 131, 82 );
            this.dtpTarget.Name = "dtpTarget";
            this.dtpTarget.Size = new System.Drawing.Size( 196, 20 );
            this.dtpTarget.TabIndex = 6;
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Location = new System.Drawing.Point( 6, 85 );
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size( 119, 13 );
            this.lblDueDate.TabIndex = 5;
            this.lblDueDate.Text = "Target Completion Date";
            this.lblDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMeasure
            // 
            this.txtMeasure.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.txtMeasure.Location = new System.Drawing.Point( 131, 56 );
            this.txtMeasure.Name = "txtMeasure";
            this.txtMeasure.Size = new System.Drawing.Size( 433, 20 );
            this.txtMeasure.TabIndex = 4;
            // 
            // lblMeasure
            // 
            this.lblMeasure.AutoSize = true;
            this.lblMeasure.Location = new System.Drawing.Point( 43, 59 );
            this.lblMeasure.Name = "lblMeasure";
            this.lblMeasure.Size = new System.Drawing.Size( 82, 13 );
            this.lblMeasure.TabIndex = 3;
            this.lblMeasure.Text = "Target Measure";
            this.lblMeasure.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.txtDescription.Location = new System.Drawing.Point( 131, 30 );
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size( 433, 20 );
            this.txtDescription.TabIndex = 2;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point( 65, 33 );
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size( 60, 13 );
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "Description";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpCompleted
            // 
            this.grpCompleted.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.grpCompleted.Controls.Add( this.txtImprovements );
            this.grpCompleted.Controls.Add( this.lblImprovements );
            this.grpCompleted.Controls.Add( this.txtPositives );
            this.grpCompleted.Controls.Add( this.lblPositives );
            this.grpCompleted.Controls.Add( this.pnlCompleted );
            this.grpCompleted.Controls.Add( this.chkClosed );
            this.grpCompleted.Location = new System.Drawing.Point( 12, 127 );
            this.grpCompleted.Name = "grpCompleted";
            this.grpCompleted.Size = new System.Drawing.Size( 589, 377 );
            this.grpCompleted.TabIndex = 2;
            this.grpCompleted.TabStop = false;
            this.grpCompleted.Text = "Completed?";
            // 
            // pnlCompleted
            // 
            this.pnlCompleted.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.pnlCompleted.Controls.Add( this.dtpResultDate );
            this.pnlCompleted.Controls.Add( this.label1 );
            this.pnlCompleted.Controls.Add( this.label2 );
            this.pnlCompleted.Controls.Add( this.trkTimeliness );
            this.pnlCompleted.Controls.Add( this.label3 );
            this.pnlCompleted.Controls.Add( this.lblResultDate );
            this.pnlCompleted.Controls.Add( this.lblMeasureExcellent );
            this.pnlCompleted.Controls.Add( this.lblMeasurePoor );
            this.pnlCompleted.Controls.Add( this.trkMeasure );
            this.pnlCompleted.Controls.Add( this.lblMeasureRating );
            this.pnlCompleted.Controls.Add( this.txtResultMeasure );
            this.pnlCompleted.Controls.Add( this.lblResultMeasure );
            this.pnlCompleted.Location = new System.Drawing.Point( 3, 16 );
            this.pnlCompleted.Name = "pnlCompleted";
            this.pnlCompleted.Size = new System.Drawing.Size( 583, 150 );
            this.pnlCompleted.TabIndex = 22;
            // 
            // dtpResultDate
            // 
            this.dtpResultDate.Location = new System.Drawing.Point( 127, 80 );
            this.dtpResultDate.Name = "dtpResultDate";
            this.dtpResultDate.Size = new System.Drawing.Size( 196, 20 );
            this.dtpResultDate.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.label1.Location = new System.Drawing.Point( 447, 134 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 118, 13 );
            this.label1.TabIndex = 32;
            this.label1.Text = "(Excellent/Outstanding)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.label2.Location = new System.Drawing.Point( 124, 134 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 83, 13 );
            this.label2.TabIndex = 31;
            this.label2.Text = "(Poor/Very Bad)";
            // 
            // trkTimeliness
            // 
            this.trkTimeliness.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.trkTimeliness.LargeChange = 1;
            this.trkTimeliness.Location = new System.Drawing.Point( 127, 106 );
            this.trkTimeliness.Name = "trkTimeliness";
            this.trkTimeliness.Size = new System.Drawing.Size( 433, 45 );
            this.trkTimeliness.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 18, 110 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 102, 13 );
            this.label3.TabIndex = 29;
            this.label3.Text = "Rating of Timeliness";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblResultDate
            // 
            this.lblResultDate.AutoSize = true;
            this.lblResultDate.Location = new System.Drawing.Point( 36, 84 );
            this.lblResultDate.Name = "lblResultDate";
            this.lblResultDate.Size = new System.Drawing.Size( 85, 13 );
            this.lblResultDate.TabIndex = 28;
            this.lblResultDate.Text = "Completion Date";
            this.lblResultDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMeasureExcellent
            // 
            this.lblMeasureExcellent.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.lblMeasureExcellent.AutoSize = true;
            this.lblMeasureExcellent.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.lblMeasureExcellent.Location = new System.Drawing.Point( 447, 57 );
            this.lblMeasureExcellent.Name = "lblMeasureExcellent";
            this.lblMeasureExcellent.Size = new System.Drawing.Size( 118, 13 );
            this.lblMeasureExcellent.TabIndex = 27;
            this.lblMeasureExcellent.Text = "(Excellent/Outstanding)";
            // 
            // lblMeasurePoor
            // 
            this.lblMeasurePoor.AutoSize = true;
            this.lblMeasurePoor.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.lblMeasurePoor.Location = new System.Drawing.Point( 124, 57 );
            this.lblMeasurePoor.Name = "lblMeasurePoor";
            this.lblMeasurePoor.Size = new System.Drawing.Size( 83, 13 );
            this.lblMeasurePoor.TabIndex = 26;
            this.lblMeasurePoor.Text = "(Poor/Very Bad)";
            // 
            // trkMeasure
            // 
            this.trkMeasure.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.trkMeasure.LargeChange = 1;
            this.trkMeasure.Location = new System.Drawing.Point( 127, 29 );
            this.trkMeasure.Name = "trkMeasure";
            this.trkMeasure.Size = new System.Drawing.Size( 433, 45 );
            this.trkMeasure.TabIndex = 25;
            // 
            // lblMeasureRating
            // 
            this.lblMeasureRating.AutoSize = true;
            this.lblMeasureRating.Location = new System.Drawing.Point( 26, 32 );
            this.lblMeasureRating.Name = "lblMeasureRating";
            this.lblMeasureRating.Size = new System.Drawing.Size( 94, 13 );
            this.lblMeasureRating.TabIndex = 24;
            this.lblMeasureRating.Text = "Rating of Measure";
            this.lblMeasureRating.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtResultMeasure
            // 
            this.txtResultMeasure.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.txtResultMeasure.Location = new System.Drawing.Point( 127, 3 );
            this.txtResultMeasure.Name = "txtResultMeasure";
            this.txtResultMeasure.Size = new System.Drawing.Size( 433, 20 );
            this.txtResultMeasure.TabIndex = 23;
            // 
            // lblResultMeasure
            // 
            this.lblResultMeasure.AutoSize = true;
            this.lblResultMeasure.Location = new System.Drawing.Point( 39, 6 );
            this.lblResultMeasure.Name = "lblResultMeasure";
            this.lblResultMeasure.Size = new System.Drawing.Size( 81, 13 );
            this.lblResultMeasure.TabIndex = 22;
            this.lblResultMeasure.Text = "Result Measure";
            this.lblResultMeasure.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkClosed
            // 
            this.chkClosed.AutoSize = true;
            this.chkClosed.Location = new System.Drawing.Point( 72, 0 );
            this.chkClosed.Name = "chkClosed";
            this.chkClosed.Size = new System.Drawing.Size( 15, 14 );
            this.chkClosed.TabIndex = 0;
            this.chkClosed.UseVisualStyleBackColor = true;
            this.chkClosed.CheckedChanged += new System.EventHandler( this.chkClosed_CheckedChanged );
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.Location = new System.Drawing.Point( 350, 508 );
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size( 75, 23 );
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler( this.btnCancel_Click );
            // 
            // btnDeleteEntry
            // 
            this.btnDeleteEntry.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDeleteEntry.Location = new System.Drawing.Point( 269, 508 );
            this.btnDeleteEntry.Name = "btnDeleteEntry";
            this.btnDeleteEntry.Size = new System.Drawing.Size( 75, 23 );
            this.btnDeleteEntry.TabIndex = 5;
            this.btnDeleteEntry.Text = "&Delete";
            this.btnDeleteEntry.UseVisualStyleBackColor = true;
            this.btnDeleteEntry.Click += new System.EventHandler( this.btnDeleteEntry_Click );
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.Location = new System.Drawing.Point( 188, 508 );
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size( 75, 23 );
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Save Changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler( this.btnSave_Click );
            // 
            // errProv
            // 
            this.errProv.ContainerControl = this;
            // 
            // txtImprovements
            // 
            this.txtImprovements.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.txtImprovements.Location = new System.Drawing.Point( 130, 274 );
            this.txtImprovements.Multiline = true;
            this.txtImprovements.Name = "txtImprovements";
            this.txtImprovements.Size = new System.Drawing.Size( 433, 96 );
            this.txtImprovements.TabIndex = 41;
            // 
            // lblImprovements
            // 
            this.lblImprovements.AutoSize = true;
            this.lblImprovements.Location = new System.Drawing.Point( 36, 277 );
            this.lblImprovements.Name = "lblImprovements";
            this.lblImprovements.Size = new System.Drawing.Size( 87, 13 );
            this.lblImprovements.TabIndex = 40;
            this.lblImprovements.Text = "Areas to Improve";
            this.lblImprovements.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPositives
            // 
            this.txtPositives.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.txtPositives.Location = new System.Drawing.Point( 130, 172 );
            this.txtPositives.Multiline = true;
            this.txtPositives.Name = "txtPositives";
            this.txtPositives.Size = new System.Drawing.Size( 433, 96 );
            this.txtPositives.TabIndex = 39;
            // 
            // lblPositives
            // 
            this.lblPositives.AutoSize = true;
            this.lblPositives.Location = new System.Drawing.Point( 74, 175 );
            this.lblPositives.Name = "lblPositives";
            this.lblPositives.Size = new System.Drawing.Size( 49, 13 );
            this.lblPositives.TabIndex = 38;
            this.lblPositives.Text = "Positives";
            this.lblPositives.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmEditGoal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 613, 534 );
            this.Controls.Add( this.btnCancel );
            this.Controls.Add( this.btnDeleteEntry );
            this.Controls.Add( this.btnSave );
            this.Controls.Add( this.grpCompleted );
            this.Controls.Add( this.grpDetails );
            this.MinimumSize = new System.Drawing.Size( 629, 570 );
            this.Name = "frmEditGoal";
            this.Text = "Goal";
            this.Load += new System.EventHandler( this.frmEditGoal_Load );
            this.grpDetails.ResumeLayout( false );
            this.grpDetails.PerformLayout();
            this.grpCompleted.ResumeLayout( false );
            this.grpCompleted.PerformLayout();
            this.pnlCompleted.ResumeLayout( false );
            this.pnlCompleted.PerformLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.trkTimeliness ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.trkMeasure ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.errProv ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Label lblSMART;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtMeasure;
        private System.Windows.Forms.Label lblMeasure;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.DateTimePicker dtpTarget;
        private System.Windows.Forms.GroupBox grpCompleted;
        private System.Windows.Forms.CheckBox chkClosed;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDeleteEntry;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errProv;
        private System.Windows.Forms.Panel pnlCompleted;
        private System.Windows.Forms.DateTimePicker dtpResultDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trkTimeliness;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblResultDate;
        private System.Windows.Forms.Label lblMeasureExcellent;
        private System.Windows.Forms.Label lblMeasurePoor;
        private System.Windows.Forms.TrackBar trkMeasure;
        private System.Windows.Forms.Label lblMeasureRating;
        private System.Windows.Forms.TextBox txtResultMeasure;
        private System.Windows.Forms.Label lblResultMeasure;
        private System.Windows.Forms.TextBox txtImprovements;
        private System.Windows.Forms.Label lblImprovements;
        private System.Windows.Forms.TextBox txtPositives;
        private System.Windows.Forms.Label lblPositives;
    }
}