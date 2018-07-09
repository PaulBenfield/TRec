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
    public partial class frmEditGoal : Form
    {
        public frmEditGoal()
        {
            InitializeComponent();
        }

        private Goal m_item = null;

        public void PopulateScreen( Goal item, User currUser )
        {
            m_item = item;
            if ( item == null )
            {
                m_item = new Goal();
                m_item.GoalId = Guid.Empty;
                m_item.UserId = currUser.UserId;
                m_item.ActualCompletionDate = OperationsReadOnly.RoundToMinute( DateTime.Now );
                m_item.TargetCompletionDate = OperationsReadOnly.RoundToMinute( DateTime.Now );
            }

            txtDescription.Text = m_item.Description;
            txtMeasure.Text = m_item.TargetMeasure;
            dtpTarget.Value = m_item.TargetCompletionDate;

            chkClosed.Checked = m_item.Completed;
            txtResultMeasure.Text = m_item.ResultMeasure;
            trkMeasure.Value = m_item.ResultMeasureRating;
            dtpResultDate.Value = m_item.ActualCompletionDate;
            trkTimeliness.Value = m_item.ResultTimelinessRating;
            txtPositives.Text = m_item.Positives;
            txtImprovements.Text = m_item.Improvements;

            SetupCompleted();
        }

        private void chkClosed_CheckedChanged( object sender, EventArgs e )
        {
            SetupCompleted();
        }

        private void SetupCompleted()
        {
            pnlCompleted.Enabled = chkClosed.Checked;
            dtpResultDate.Visible = chkClosed.Checked;
        }

        private void btnSave_Click( object sender, EventArgs e )
        {
            errProv.Clear();

            List<ValidatableIntStringPair> exceptionItems = new List<ValidatableIntStringPair>();

            if (m_item == null){
                throw new InvalidOperationException("PopualteScreen not called, invalid operation");
            }

            //validate
            List<ValidationMessage> errors = OperationsReadWrite.SaveGoal(
                                                new ValidatableParameter<Guid> { Value = m_item.GoalId, Source = null },
                                                new ValidatableParameter<Guid> { Value = m_item.UserId, Source = null },
                                                new ValidatableParameter<string> { Value = txtDescription.Text.Trim(), Source = txtDescription },
                                                new ValidatableParameter<string> { Value = txtMeasure.Text.Trim(), Source = txtMeasure },
                                                new ValidatableParameter<DateTime> { Value = dtpTarget.Value, Source = dtpTarget },
                                                new ValidatableParameter<bool> { Value = chkClosed.Checked, Source = chkClosed },
                                                new ValidatableParameter<string> { Value = txtResultMeasure.Text.Trim(), Source = txtResultMeasure },
                                                new ValidatableParameter<int> { Value = trkMeasure.Value, Source = trkMeasure },
                                                new ValidatableParameter<DateTime> { Value = dtpResultDate.Value, Source = dtpResultDate },
                                                new ValidatableParameter<int> { Value = trkTimeliness.Value, Source = trkTimeliness },
                                                new ValidatableParameter<string> { Value = txtPositives.Text.Trim(), Source = txtPositives },
                                                new ValidatableParameter<string> { Value = txtImprovements.Text.Trim(), Source = txtImprovements }
                                                 );

            if ( errors.Count > 0 )
            {
                //set up the list of controls that may have errors associated
                List<Control> validatableControls = new List<Control>();
                validatableControls.Add( txtDescription );
                validatableControls.Add( txtMeasure );
                validatableControls.Add( dtpTarget );
                validatableControls.Add( chkClosed );
                validatableControls.Add( txtResultMeasure );
                validatableControls.Add( trkMeasure );
                validatableControls.Add( dtpResultDate );
                validatableControls.Add( trkTimeliness );
                validatableControls.Add( txtPositives );
                validatableControls.Add( txtImprovements );

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
                            errProv.SetError( txtDescription, currError.MessageText );
                        }
                    }
                    else
                    {
                        errProv.SetError( txtDescription, currError.MessageText );
                    }
                }
            }
            else
            {
                //close the form
                this.Close();
            }
        }

        private void btnDeleteEntry_Click( object sender, EventArgs e )
        {
            if ( MessageBox.Show( "Are you sure you want to delete this entry?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2 ) == DialogResult.OK )
            {
                if ( m_item.GoalId != Guid.Empty )
                {
                    List<ValidationMessage> errors = OperationsReadWrite.RemoveGoal( new ValidatableParameter<Guid> { Value = m_item.GoalId } );

                    if ( errors.Count > 0 )
                    {
                        throw new ApplicationException( string.Format( "Error deleting Goal with Id '{0}': '{1}'", m_item.GoalId, errors[ 0 ].MessageText ) );
                    }
                }

                this.Close();
            }
        }

        private void btnCancel_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        private void frmEditGoal_Load( object sender, EventArgs e )
        {

        }
    }
}
