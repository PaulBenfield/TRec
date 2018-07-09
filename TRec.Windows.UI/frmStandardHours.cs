using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TRec.Windows.UI
{
    public partial class frmStandardHours : Form
    {
        public frmStandardHours()
        {
            InitializeComponent();
        }




        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //TODO: Update the user's settings
        }
    }
}
