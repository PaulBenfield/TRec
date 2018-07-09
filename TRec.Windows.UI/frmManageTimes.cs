using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TRec.BusinessLayer;

namespace TRec.Windows.UI
{
    public partial class frmManageTimes : Form
    {
        public frmManageTimes()
        {
            InitializeComponent();
        }

        UserControls.TimeEditGrid ucTimes = null;
        User m_currUser = null;

        public void PopulateScreen( User usr )
        {
            dtpFilterDate.Value = OperationsReadOnly.RoundToMinute( DateTime.Now );
            m_currUser = usr;
        }

        private void SetupGrid()
        {
            if ( ucTimes == null )
            {
                ucTimes = new UserControls.TimeEditGrid();
                ucTimes.Dock = DockStyle.Fill;
                ucTimes.EditFormClosing += new FormClosingEventHandler( ucTimes_EditFormClosing );
                pnlGrid.Controls.Add( ucTimes );
            }

            ucTimes.SetupGrid( OperationsReadOnly.GetTimeEntryForDate( dtpFilterDate.Value, m_currUser ), m_currUser );
        }

        void ucTimes_EditFormClosing( object sender, FormClosingEventArgs e )
        {
            SetupGrid();
        }

        private void btnRetrieve_Click( object sender, EventArgs e )
        {
            //use button not selected date changed, because it changes too often (e.g. on month switching)
            SetupGrid();
        }
    }
}
