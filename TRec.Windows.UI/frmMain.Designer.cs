namespace TRec.Windows.UI
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( frmMain ) );
            this.notifier = new System.Windows.Forms.NotifyIcon( this.components );
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip( this.components );
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runAsDifferentUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrCheck = new System.Windows.Forms.Timer( this.components );
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifier
            // 
            this.notifier.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifier.BalloonTipText = "What are you working on?";
            this.notifier.BalloonTipTitle = "T-Rec Reminder";
            this.notifier.ContextMenuStrip = this.contextMenuStrip;
            this.notifier.Icon = ( (System.Drawing.Icon)( resources.GetObject( "notifier.Icon" ) ) );
            this.notifier.Text = "T-Rec";
            this.notifier.Visible = true;
            this.notifier.BalloonTipClosed += new System.EventHandler( this.notifier_BalloonTipClosed );
            this.notifier.BalloonTipClicked += new System.EventHandler( this.notifier_BalloonTipClicked );
            this.notifier.BalloonTipShown += new System.EventHandler( this.notifier_BalloonTipShown );
            this.notifier.MouseClick += new System.Windows.Forms.MouseEventHandler( this.notifier_MouseClick );
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.runAsDifferentUserToolStripMenuItem,
            this.eToolStripMenuItem} );
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size( 187, 70 );
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size( 186, 22 );
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler( this.openToolStripMenuItem_Click );
            // 
            // runAsDifferentUserToolStripMenuItem
            // 
            this.runAsDifferentUserToolStripMenuItem.Enabled = false;
            this.runAsDifferentUserToolStripMenuItem.Name = "runAsDifferentUserToolStripMenuItem";
            this.runAsDifferentUserToolStripMenuItem.Size = new System.Drawing.Size( 186, 22 );
            this.runAsDifferentUserToolStripMenuItem.Text = "Run As Different User";
            this.runAsDifferentUserToolStripMenuItem.Click += new System.EventHandler( this.runAsDifferentUserToolStripMenuItem_Click );
            // 
            // eToolStripMenuItem
            // 
            this.eToolStripMenuItem.Name = "eToolStripMenuItem";
            this.eToolStripMenuItem.Size = new System.Drawing.Size( 186, 22 );
            this.eToolStripMenuItem.Text = "Exit";
            this.eToolStripMenuItem.Click += new System.EventHandler( this.eToolStripMenuItem_Click );
            // 
            // tmrCheck
            // 
            this.tmrCheck.Enabled = true;
            this.tmrCheck.Interval = 1000;
            this.tmrCheck.Tick += new System.EventHandler( this.tmrCheck_Tick );
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 591, 355 );
            this.Name = "frmMain";
            this.Text = "T-Rec";
            this.Load += new System.EventHandler( this.frmMain_Load );
            this.KeyDown += new System.Windows.Forms.KeyEventHandler( this.frmMain_KeyDown );
            this.contextMenuStrip.ResumeLayout( false );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifier;
        private System.Windows.Forms.Timer tmrCheck;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runAsDifferentUserToolStripMenuItem;
    }
}

