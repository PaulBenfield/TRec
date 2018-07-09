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
    public partial class frmEditTime : Form
    {
        public frmEditTime()
        {
            InitializeComponent();
            cbxProjects.DisplayMember = "Description";
            cbxTasks.DisplayMember = "Description";
        }

        TimeEntry m_item = null;
        TimeEntry m_prevItem = null;
        TimeEntry m_nextItem = null;
        User m_currUser = null;

        public TimeEntry EditedItem
        {
            get
            {
                return m_item;
            }
        }

        public void PopulateScreen( TimeEntry item, TimeEntry previousItem, TimeEntry nextItem, User usr )
        {
            m_item = item;
            m_prevItem = previousItem;
            m_nextItem = nextItem;
            m_currUser = usr;

            if ( m_prevItem != null )
            {
                UserControls.ReadOnlyEntry ucItem = new UserControls.ReadOnlyEntry();
                ucItem.Dock = DockStyle.Fill;
                ucItem.PopulateScreen( m_prevItem );
                tabPrevious.Controls.Add( ucItem );
            }

            if ( m_nextItem != null )
            {
                UserControls.ReadOnlyEntry ucItem = new UserControls.ReadOnlyEntry();
                ucItem.Dock = DockStyle.Fill;
                ucItem.PopulateScreen( m_nextItem );
                tabNext.Controls.Add( ucItem );
            }

            //ensure we are back to an empty state for consistency
            ResetScreen();

            //populate & default drop downs
            List<Project> projs = OperationsReadOnly.GetProjectsForUser( m_currUser.UserId, true );
            cbxProjects.Items.AddRange( projs.ToArray() );

            

            if ( item.ProjectId != Guid.Empty )
            {
                bool found = false;
                int currIndex = 0;
                while ( !found && currIndex < projs.Count )
                {
                    if ( projs[ currIndex ].Id == item.ProjectId )
                    {
                        found = true;
                        cbxProjects.SelectedIndex = currIndex;
                    }
                    currIndex++;
                }
            }

            List<Task> tsks = OperationsReadOnly.GetTasksForProjectAndUser( item.ProjectId, m_currUser.UserId, true );
            if ( cbxTasks.Items.Count == 0 )
            {
                cbxTasks.Items.AddRange( tsks.ToArray() );
            }

            if ( item.TaskId != Guid.Empty )
            {
                bool found = false;
                int currIndex = 0;
                while ( !found && currIndex < tsks.Count )
                {
                    if ( tsks[ currIndex ].Id == item.TaskId )
                    {
                        found = true;
                        cbxTasks.SelectedIndex = currIndex;
                    }
                    currIndex++;
                }
            }

            //detault to first task if there is one and one is not selected
            if ( cbxTasks.Items.Count > 0 && cbxTasks.SelectedIndex < 0 )
            {
                //default to first task as per issue 2884
                cbxTasks.SelectedIndex = 0;
            }



            txtDetails.Text = item.Details;

            dtpStart.Value = item.StartDateTime;
            dtpEnd.Value = item.EndDateTime;

            nudExc1.Value = Convert.ToInt32( item.ExceptionMinutes );
            txtExc1.Text = item.ExceptionDetails;

            //select the current tab initially
            tcEntries.SelectedTab = tabCurrent;

        }

        private void ResetScreen()
        {
            cbxProjects.Items.Clear();
            cbxTasks.Items.Clear();
        }

        private void btnSave_Click( object sender, EventArgs e )
        {
            errProv.Clear();

            List<ValidatableIntStringPair> exceptionItems = new List<ValidatableIntStringPair>();

            TimeEntry savedItem = null;

            //validate
            List<ValidationMessage> errors = OperationsReadWrite.SaveTimeEntry(
                                                new ValidatableParameter<Guid> { Value = m_item == null ? Guid.Empty : m_item.TimeEntryId, Source = null },
                                                new ValidatableParameter<Guid> { Value = m_currUser.UserId, Source = null },
                                                new ValidatableParameter<Guid> { Value = cbxProjects.SelectedItem == null ? Guid.Empty : ( (Project)cbxProjects.SelectedItem ).Id, Source = cbxProjects },
                                                new ValidatableParameter<Guid> { Value = cbxTasks.SelectedItem == null ? Guid.Empty : ( (Task)cbxTasks.SelectedItem ).Id, Source = cbxTasks },
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
                validatableControls.Add( cbxProjects );
                validatableControls.Add( cbxTasks );
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
                //set the saved item
                m_item = savedItem;

                //close the form
                this.Close();
            }
        }

        private void btnDeleteEntry_Click( object sender, EventArgs e )
        {
            if ( MessageBox.Show( "Are you sure you want to delete this entry?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2 ) == DialogResult.OK )
            {
                if ( m_item.TimeEntryId != Guid.Empty )
                {
                    List<ValidationMessage> errors = OperationsReadWrite.RemoveTimeEntry( new ValidatableParameter<Guid> { Value = m_item.TimeEntryId } );

                    if ( errors.Count > 0 )
                    {
                        throw new ApplicationException( string.Format( "Error deleting time entry with Id '{0}': '{1}'", m_item.TimeEntryId, errors[ 0 ].MessageText ) );
                    }
                }

                this.Close();
            }
        }

        private void btnCancel_Click( object sender, EventArgs e )
        {
            //close the form
            this.Close();
        }

        private void cbxProjects_SelectedIndexChanged( object sender, EventArgs e )
        {
            Project SelectedProject = cbxProjects.SelectedItem == null ? null : (Project)cbxProjects.SelectedItem;
            cbxTasks.Items.Clear();
            cbxTasks.SelectedItem = null;
            if ( SelectedProject != null )
            {
                List<Task> tsks = OperationsReadOnly.GetTasksForProjectAndUser( SelectedProject.Id, m_currUser.UserId, true );
                cbxTasks.Items.AddRange( tsks.ToArray() );
            }

            //detault to first task if there is one and one is not selected
            if ( cbxTasks.Items.Count > 0 && cbxTasks.SelectedIndex < 0 )
            {
                //default to first task as per issue 2884
                cbxTasks.SelectedIndex = 0;
            }
        }

    }
}
