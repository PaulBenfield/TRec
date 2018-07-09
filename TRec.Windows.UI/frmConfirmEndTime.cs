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
    public partial class frmConfirmEndTime : Form
    {
        public frmConfirmEndTime()
        {
            InitializeComponent();

            WasConfirmed = false;
        }

        TimeEntry m_lastTimeEntry = null;
        User m_currUser = null;

        public bool WasConfirmed { get; set; }

        public TimeEntry SavedEntry { get; set; }

        public void PopulateScreen( TimeEntry lastEntry, User usr )
        {
            m_lastTimeEntry = lastEntry;
            m_currUser = usr;

            //populate & default drop downs
            lblProjectVal.Text = m_lastTimeEntry.ProjectName;
            lblTaskVal.Text = m_lastTimeEntry.TaskName;

            dtpStart.Value = m_lastTimeEntry.StartDateTime;
            dtpEnd.Value = lastEntry.EndDateTime;

            txtDetails.Text = m_lastTimeEntry.Details;
            nudExc1.Value = m_lastTimeEntry.ExceptionMinutes;
            txtExc1.Text = m_lastTimeEntry.ExceptionDetails;
        }

        private void btnSave_Click( object sender, EventArgs e )
        {
            errProv.Clear();

            List<ValidatableIntStringPair> exceptionItems = new List<ValidatableIntStringPair>();

            TimeEntry savedItem = null;

            //validate
            List<ValidationMessage> errors = OperationsReadWrite.SaveTimeEntry(
                                                new ValidatableParameter<Guid> { Value = m_lastTimeEntry == null ? Guid.Empty : m_lastTimeEntry.TimeEntryId, Source = null },
                                                new ValidatableParameter<Guid> { Value = m_currUser.UserId, Source = null },
                                                new ValidatableParameter<Guid> { Value = m_lastTimeEntry.ProjectId, Source = lblProjectVal },
                                                new ValidatableParameter<Guid> { Value = m_lastTimeEntry.TaskId, Source = lblTaskVal },
                                                new ValidatableParameter<string> { Value = txtDetails.Text, Source = txtDetails },
                                                new ValidatableParameter<DateTime?> { Value = dtpStart.Value, Source = dtpStart },
                                                new ValidatableParameter<DateTime?> { Value = dtpEnd.Value, Source = dtpEnd },
                                                new ValidatableParameter<int> { Value = Convert.ToInt32( nudExc1.Value ), Source = nudExc1 },
                                                new ValidatableParameter<string> { Value = txtExc1.Text, Source = txtExc1 },
                                                out savedItem );

            if ( errors.Count > 0 )
            {
                //set up the list of controls that may have errors associated
                List<Control> validatableControls = new List<Control>();
                validatableControls.Add( lblProjectVal );
                validatableControls.Add( lblTaskVal );
                validatableControls.Add( dtpStart );
                validatableControls.Add( dtpEnd );
                validatableControls.Add( nudExc1 );
                validatableControls.Add( txtExc1 );

                //hook up errors to controls
                foreach ( ValidationMessage currError in errors )
                {
                    if ( currError.Source != null )
                    {
                        bool found = false;
                        int currIndex = 0;
                        while ( !found && currIndex < validatableControls.Count )
                        {
                            if ( validatableControls[ currIndex ] == currError.Source )
                            {
                                found = true;
                                errProv.SetError( validatableControls[ currIndex ], currError.MessageText );
                            }
                            currIndex++;
                        }

                        if ( !found )
                        {
                            errProv.SetError( btnSave, currError.MessageText );
                        }
                    }
                    else
                    {
                        errProv.SetError( btnSave, currError.MessageText );
                    }
                }
            }
            else
            {
                SavedEntry = savedItem;
                WasConfirmed = true;
                this.Close();
            }
        }


        private void btnCancel_Click( object sender, EventArgs e )
        {
            this.Close();
        }

    }
}
