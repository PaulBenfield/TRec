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
    public partial class frmTimeEntry : Form
    {
        public frmTimeEntry()
        {
            InitializeComponent();
            cbxProjects.DisplayMember = "Description";
            cbxTasks.DisplayMember = "Description";
        }

        User m_currUser = null;
        TimeEntry m_lastTimeEntry = null;
        int m_reminderMilliseconds = 0;
        bool m_isInSetupMode = false;
        UserControls.TimeEditGrid dgHistory = null;

        bool showAllForDay = false;

        public TimeEntry LastSavedEntry
        {
            get
            {
                return m_lastTimeEntry;
            }
        }

        public Project SelectedProject
        {
            get
            {
                return cbxProjects.SelectedItem == null ? null : (Project)cbxProjects.SelectedItem;
            }
        }

        public Task SelectedTask
        {
            get
            {
                return cbxTasks.SelectedItem == null ? null : (Task)cbxTasks.SelectedItem;
            }
        }

        public DateTime StartTime
        {
            get
            {
                return dtpStart.Value;
            }
        }

        public DateTime EndTime
        {
            get
            {
                return dtpEnd.Value;
            }
        }

        public int ReminderMilliseconds
        {
            get
            {
                return m_reminderMilliseconds;
            }
        }

        public bool SaveClicked { get; set; }

        public bool SleepClicked { get; set; }

        public bool AreRemindersOn { get; set; }

        public void PopulateScreen( User usr, TimeEntry lastTimeEntry, bool remindersOn, int reminderMilliseconds )
        {
            //indicate we are setting up the screen
            m_isInSetupMode = true;

            m_currUser = usr;
            m_lastTimeEntry = lastTimeEntry;
            m_reminderMilliseconds = reminderMilliseconds;

            if ( lastTimeEntry == null )
            {
                //change enabled status
                chkNothing.Checked = true;
                pnlEntry.Enabled = false;
                chkNothing.Image = global::TRec.Windows.UI.Properties.Resources.stopwatch_on;

                dtpStart.Visible = false;
            }
            else
            {
                if ( !m_isInSetupMode )
                {
                    chkNothing.Checked = false;
                }
                pnlEntry.Enabled = true;
                chkNothing.Image = global::TRec.Windows.UI.Properties.Resources.stopwatch_off;

                dtpStart.Visible = true;
            }

            //ensure we are back to an empty state for consistency
            ResetScreen();

            //populate & default drop downs
            Project currProj = m_lastTimeEntry == null ? null : OperationsReadOnly.GetProjectForUser( m_lastTimeEntry.ProjectId, m_currUser.UserId );
            Task currTask = m_lastTimeEntry == null ? null : OperationsReadOnly.GetTaskById( m_lastTimeEntry.TaskId, m_lastTimeEntry.ProjectId, m_currUser.UserId );
            SetupProjectAndTasks( currProj, currTask );

            dtpStart.Value = lastTimeEntry == null ? OperationsReadOnly.RoundToMinute( DateTime.Now ) : lastTimeEntry.StartDateTime;
            
            //if the start date is future, add 1 minute to that, otherwise add one minute to now
            DateTime greaterDate = dtpStart.Value > DateTime.Now ? dtpStart.Value : DateTime.Now;
            dtpEnd.Value = OperationsReadOnly.RoundToMinute( greaterDate.AddMinutes( 1 ) );

            txtDetails.Text = lastTimeEntry == null ? string.Empty : lastTimeEntry.Details;
            nudExc1.Value = lastTimeEntry == null ? 0 : lastTimeEntry.ExceptionMinutes;
            txtExc1.Text = lastTimeEntry == null ? string.Empty : lastTimeEntry.ExceptionDetails;

            AreRemindersOn = remindersOn;
            ToggleReminders();

            SetupGrid();

            //reset the last preferred reminder
            if ( reminderMilliseconds != 0 )
            {
                nudInterval.Value = reminderMilliseconds / 1000 / 60;
            }

            //indicate we have finished setting up the screen
            m_isInSetupMode = false;

            SetupBottomLink();
            SetupGoals();
        }

        private void SetupProjectAndTasks( Project currProject, Task currTask )
        {
            cbxProjects.Items.Clear();
            List<Project> projs = OperationsReadOnly.GetProjectsForUser( m_currUser.UserId, true );
            cbxProjects.Items.AddRange( projs.ToArray() );

            if ( currProject != null )
            {
                bool found = false;
                int currIndex = 0;
                while ( !found && currIndex < projs.Count )
                {
                    if ( projs[ currIndex ].Id == currProject.Id )
                    {
                        found = true;
                        cbxProjects.SelectedIndex = currIndex;
                    }
                    currIndex++;
                }
            }

            cbxTasks.Items.Clear();
            List<Task> tsks = OperationsReadOnly.GetTasksForProjectAndUser( currProject == null ? Guid.Empty : currProject.Id, m_currUser == null ? Guid.Empty : m_currUser.UserId, true );
            cbxTasks.Items.AddRange( tsks.ToArray() );

            if ( currTask != null )
            {
                bool found = false;
                int currIndex = 0;
                while ( !found && currIndex < tsks.Count )
                {
                    if ( tsks[ currIndex ].Id == currTask.Id )
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


        }

        /// <summary>
        /// Sets the Reminders On/Off toggle button state
        /// </summary>
        private void ToggleReminders()
        {
            if ( AreRemindersOn == true )
            {
                btnToggle.Text = "Turn Reminders Off";
                pnlSleep.Enabled = true;
                //btnToggle.BackColor = System.Drawing.Color.LawnGreen;
            }
            else
            {
                btnToggle.Text = "Turn Reminders On";
                pnlSleep.Enabled = false;
                //btnToggle.BackColor = System.Drawing.Color.IndianRed;
            }
        }

        /// <summary>
        /// Populate the times grid
        /// </summary>
        private void SetupGrid()
        {
            if ( dgHistory == null )
            {
                dgHistory = new UserControls.TimeEditGrid();
                //dgHistory.Anchor = ( (AnchorStyles)AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top );
                dgHistory.Dock = DockStyle.Fill;
                dgHistory.EditFormClosing += new FormClosingEventHandler( tmEdit_FormClosing );
                tabPage1.Controls.Add( dgHistory );
            }

            if ( showAllForDay )
            {
                dgHistory.SetupGrid( OperationsReadOnly.GetTimeEntryForDate( OperationsReadOnly.RoundToMinute( DateTime.Now ), m_currUser ), m_currUser );
            }
            else
            {
                dgHistory.SetupGrid( OperationsReadOnly.GetRecentTimeEntry( 5, m_currUser ), m_currUser );
            }
        }

        private void SetupGoals()
        {
            if ( lnkShowGoals.Text == cstrGridFilterTextCompleted )
            {
                gvGoals.DataSource = OperationsReadOnly.GetAllGoals( false );
            }
            else
            {
                gvGoals.DataSource = OperationsReadOnly.GetAllGoals( true );
            }
            SetupGoalContext();
        }

        private void ResetScreen()
        {
            cbxProjects.Items.Clear();
            cbxTasks.Items.Clear();
        }

        /// <summary>
        /// Saves the current selection
        /// </summary>
        private bool PerformSave()
        {
            errProv.Clear();

            bool savedSuccessfully = false;

            List<ValidatableIntStringPair> exceptionItems = new List<ValidatableIntStringPair>();

            TimeEntry savedItem = null;

            //validate
            List<ValidationMessage> errors = OperationsReadWrite.SaveTimeEntry(
                                                new ValidatableParameter<Guid> { Value = m_lastTimeEntry == null ? Guid.Empty : m_lastTimeEntry.TimeEntryId, Source = null },
                                                new ValidatableParameter<Guid> { Value = m_currUser.UserId, Source = null },
                                                new ValidatableParameter<Guid> { Value = cbxProjects.SelectedItem == null ? Guid.Empty : ( (Project)cbxProjects.SelectedItem ).Id, Source = cbxProjects },
                                                new ValidatableParameter<Guid> { Value = cbxTasks.SelectedItem == null ? Guid.Empty : ( (Task)cbxTasks.SelectedItem ).Id, Source = cbxTasks },
                                                new ValidatableParameter<string> { Value = txtDetails.Text, Source = txtDetails },
                                                new ValidatableParameter<DateTime?> { Value = dtpStart.Value, Source = dtpStart },
                                                new ValidatableParameter<DateTime?> { Value = dtpEnd.Value, Source = dtpEnd },
                                                new ValidatableParameter<int> { Value = Convert.ToInt32( nudExc1.Value ), Source = nudExc1 },
                                                new ValidatableParameter<string> { Value = txtExc1.Text, Source = txtExc1 },
                                                out savedItem );

            if ( savedItem != null )
            {
                m_lastTimeEntry = savedItem;
            }

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
                            errProv.SetError( cbxProjects, currError.MessageText );
                        }
                    }
                    else
                    {
                        errProv.SetError( cbxProjects, currError.MessageText );
                    }
                }
            }
            else
            {
                //indicate that save was clicked
                SaveClicked = true;
                SetupGrid();

                //indicate it saved OK
                savedSuccessfully = true;
            }

            return savedSuccessfully;
        }

        private void btnSleep_Click( object sender, EventArgs e )
        {
            if ( SaveClick() )
            {
                this.Close();
            }
        }

        private void btnSave_Click( object sender, EventArgs e )
        {
            SaveClick();
        }

        private bool SaveClick()
        {
            bool savedOk = true;


            SaveClicked = true;


            // if we are not recording nothing, save the current user selection
            if ( chkNothing.Checked == false )
            {
                savedOk = PerformSave();

                if ( savedOk )
                {
                    //set reminder
                    m_reminderMilliseconds = Convert.ToInt32( nudInterval.Value * 1000 * 60 );

                    // then close the form
                    SleepClicked = true;
                }
            }
            else
            {
                //set reminder
                m_reminderMilliseconds = Convert.ToInt32( nudInterval.Value * 1000 * 60 );

                // then close the form
                SleepClicked = true;
            }

            return savedOk;
        }

        private void btnCancel_Click( object sender, EventArgs e )
        {
            PopulateScreen( m_currUser, m_lastTimeEntry, AreRemindersOn, m_reminderMilliseconds );
        }

        void tmEdit_FormClosing( object sender, FormClosingEventArgs e )
        {
            TimeEntry savedItem = ( (frmEditTime)sender ).EditedItem;
            if ( savedItem != null && m_lastTimeEntry != null && savedItem.TimeEntryId == m_lastTimeEntry.TimeEntryId )
            {
                //they edited the current one, repopulate the screen
                PopulateScreen( m_currUser, savedItem, AreRemindersOn, m_reminderMilliseconds );
            }
            SetupGrid();
        }

        void tmManage_FormClosing( object sender, FormClosingEventArgs e )
        {
            SetupGrid();
        }


        private void exitToolStripMenuItem_Click( object sender, EventArgs e )
        {
            //this.Close();
            Application.Exit();
        }

        private void btnToggle_Click( object sender, EventArgs e )
        {
            AreRemindersOn = !AreRemindersOn;
            ToggleReminders();
        }

        private void administrationToolStripMenuItem_Click( object sender, EventArgs e )
        {
            frmAdminProjects fEdit = new frmAdminProjects();
            fEdit.StartPosition = FormStartPosition.CenterParent;
            fEdit.BringToFront();
            fEdit.FormClosing += new FormClosingEventHandler( fEdit_FormClosing );
            fEdit.ShowDialog( this );
        }

        private void administerUsersToolStripMenuItem_Click( object sender, EventArgs e )
        {
            frmAdminUser fEdit = new frmAdminUser();
            fEdit.PopulateScreen( m_currUser );
            fEdit.StartPosition = FormStartPosition.CenterParent;
            fEdit.BringToFront();
            fEdit.ShowDialog( this );
        }

        void fEdit_FormClosing( object sender, FormClosingEventArgs e )
        {
            //after the admin forms close, reset the projects and tasks
            //incase the previously selected ones on longer exist - this will clear them out
            SetupProjectAndTasks( SelectedProject, SelectedTask );
        }

        private void aboutToolStripMenuItem_Click( object sender, EventArgs e )
        {
            frmAbout fAbout = new frmAbout();
            fAbout.StartPosition = FormStartPosition.CenterParent;
            fAbout.BringToFront();
            //fAbout.FormClosing += new FormClosingEventHandler(fEdit_FormClosing);
            fAbout.ShowDialog( this );
        }

        private void standardStartStopTimesToolStripMenuItem_Click( object sender, EventArgs e )
        {
            frmStandardHours fStandardHours = new frmStandardHours();
            fStandardHours.StartPosition = FormStartPosition.CenterParent;
            fStandardHours.BringToFront();
            //fAbout.FormClosing += new FormClosingEventHandler(fEdit_FormClosing);
            fStandardHours.ShowDialog( this );
        }

        private void editEntriesToolStripMenuItem_Click( object sender, EventArgs e )
        {
            frmManageTimes fManage = new frmManageTimes();
            fManage.StartPosition = FormStartPosition.CenterParent;
            fManage.BringToFront();
            fManage.FormClosing += new FormClosingEventHandler( tmManage_FormClosing );
            fManage.PopulateScreen( m_currUser );
            fManage.ShowDialog( this );
        }

        private void chkNothing_CheckedChanged( object sender, EventArgs e )
        {
            if ( chkNothing.Checked )
            {
                StopClock();
            }
            else
            {
                StartClock( true );
            }
        }

        private void StartClock( bool createNewEntry )
        {
            startNewEntryToolStripMenuItem.Enabled = false;
            startAndContinuePreviousEntryToolStripMenuItem.Enabled = false;

            //set up the screen for a new entry
            if ( createNewEntry )
            {
                PopulateScreen( m_currUser, new TimeEntry { StartDateTime = OperationsReadOnly.RoundToMinute( DateTime.Now ), EndDateTime = OperationsReadOnly.RoundToMinute( DateTime.Now ) }, AreRemindersOn, m_reminderMilliseconds );
            }
            else
            {
                m_isInSetupMode = true;
                PopulateScreen( m_currUser, OperationsReadOnly.GetLatestTimeEntry( m_currUser ), AreRemindersOn, m_reminderMilliseconds );
                m_isInSetupMode = false;
            }

            chkNothing.Text = "Stop the Clock       ";
            chkNothing.Image = global::TRec.Windows.UI.Properties.Resources.stopwatch_off;
        }

        private void StopClock()
        {
            startNewEntryToolStripMenuItem.Enabled = true;
            startAndContinuePreviousEntryToolStripMenuItem.Enabled = true;

            bool performChange = false;

            if ( m_isInSetupMode )
            {
                performChange = true;
            }
            else
            {
                //check if we were updating a different one, if we confirmed
                performChange = m_lastTimeEntry == null || m_lastTimeEntry.TimeEntryId == Guid.Empty || ChangeEntry( false, false );
            }

            if ( !performChange )
            {
                chkNothing.Text = "Stop the Clock       ";
                chkNothing.Image = global::TRec.Windows.UI.Properties.Resources.stopwatch_off;

                //put the checkbox back to how it was
                m_isInSetupMode = true;
                chkNothing.Checked = false;
                m_isInSetupMode = false;
            }
            else
            {
                chkNothing.Text = "Start the Clock       ";
                chkNothing.Image = global::TRec.Windows.UI.Properties.Resources.stopwatch_on;
                pnlEntry.Enabled = false;
                dtpStart.Visible = false;
            }
        }

        private void startNewEntryToolStripMenuItem_Click( object sender, EventArgs e )
        {
            StartClock( true );
        }

        private void startAndContinuePreviousEntryToolStripMenuItem_Click( object sender, EventArgs e )
        {
            StartClock( false );
        }

        private void cbxProjects_SelectedIndexChanged( object sender, EventArgs e )
        {
            bool performChange = false;

            if ( m_isInSetupMode )
            {
                performChange = true;
            }
            else
            {
                //check if we were updating a different one, if we confirmed
                performChange = m_lastTimeEntry == null || m_lastTimeEntry.TimeEntryId == Guid.Empty || ChangeEntry( true, false );
            }

            if ( performChange )
            {
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
            else
            {
                //put the project and task back to how they were
                m_isInSetupMode = true;
                Project currProj = m_lastTimeEntry == null || m_lastTimeEntry.TimeEntryId == Guid.Empty ? null : OperationsReadOnly.GetProjectForUser( m_lastTimeEntry.ProjectId, m_currUser.UserId );
                Task currTask = m_lastTimeEntry == null || m_lastTimeEntry.TimeEntryId == Guid.Empty ? null : OperationsReadOnly.GetTaskById( m_lastTimeEntry.TaskId, m_lastTimeEntry.ProjectId, m_currUser.UserId );
                SetupProjectAndTasks( currProj, currTask );
                m_isInSetupMode = false;
            }
        }

        private void cbxTasks_SelectedIndexChanged( object sender, EventArgs e )
        {
            bool performChange = false;

            if ( m_isInSetupMode )
            {
                performChange = true;
            }
            else
            {
                //check if we were updating a different one, if we confirmed
                performChange = m_lastTimeEntry == null || m_lastTimeEntry.TimeEntryId == Guid.Empty || ChangeEntry( true, true );
            }

            if ( !performChange )
            {
                //put the project and task back to how they were
                m_isInSetupMode = true;
                Project currProj = m_lastTimeEntry == null || m_lastTimeEntry.TimeEntryId == Guid.Empty ? null : OperationsReadOnly.GetProjectForUser( m_lastTimeEntry.ProjectId, m_currUser.UserId );
                Task currTask = m_lastTimeEntry == null || m_lastTimeEntry.TimeEntryId == Guid.Empty ? null : OperationsReadOnly.GetTaskById( m_lastTimeEntry.TaskId, m_lastTimeEntry.ProjectId, m_currUser.UserId );
                SetupProjectAndTasks( currProj, currTask );
                m_isInSetupMode = false;
            }

        }


        private bool ChangeEntry( bool isProjectWork, bool isTaskChange )
        {
            //show popup and ask for date
            frmConfirmEndTime tmEdit = new frmConfirmEndTime();
            m_lastTimeEntry.EndDateTime = OperationsReadOnly.RoundToMinute( DateTime.Now );
            tmEdit.PopulateScreen( m_lastTimeEntry, m_currUser );
            tmEdit.StartPosition = FormStartPosition.CenterParent;
            tmEdit.BringToFront();
            tmEdit.ShowDialog( this );

            if ( tmEdit.WasConfirmed )
            {
                //change status
                if ( isProjectWork )
                {
                    //reset the screen with the newly selected project and task if possible
                    PopulateScreen( m_currUser, new TimeEntry { StartDateTime = tmEdit.SavedEntry.EndDateTime, EndDateTime = OperationsReadOnly.RoundToMinute( DateTime.Now ), ProjectId = cbxProjects.SelectedItem == null ? Guid.Empty : ( (Project)cbxProjects.SelectedItem ).Id, TaskId = cbxTasks.SelectedItem == null ? Guid.Empty : ( (Task)cbxTasks.SelectedItem ).Id }, AreRemindersOn, m_reminderMilliseconds );
                }
                else
                {
                    //set up the screen for a new entry
                    PopulateScreen( m_currUser, null, AreRemindersOn, m_reminderMilliseconds );
                }

                return true;
            }
            else
            {
                return false;
            }
        }


        private const string cstrGridFilterTextAll = "Show all for today";
        private const string cstrGridFilterTextRecent = "Show most recent";

        private void lnkShowForDay_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            if ( lnkShowForDay.Text == cstrGridFilterTextAll )
            {
                showAllForDay = true;
                lnkShowForDay.Text = cstrGridFilterTextRecent;
                SetupGrid();
            }
            else
            {
                showAllForDay = false;
                lnkShowForDay.Text = cstrGridFilterTextAll;
                SetupGrid();
            }

        }

        private void tabPage1_Click( object sender, EventArgs e )
        {

        }

        private void reportingToolStripMenuItem_Click( object sender, EventArgs e )
        {
            frmExtract tmExt = new frmExtract();
            tmExt.CurrentUser = m_currUser;
            tmExt.StartPosition = FormStartPosition.CenterParent;
            tmExt.BringToFront();
            tmExt.ShowDialog( this );
        }

        private void tabTimes_SelectedIndexChanged( object sender, EventArgs e )
        {
            SetupBottomLink();
        }

        private void SetupBottomLink()
        {
            lnkShowForDay.Visible = false;
            lnkShowGoals.Visible = false;

            if ( tabTimes.SelectedTab == tabPage1 )
            {
                lnkShowForDay.Visible = true;
            }
            else if ( tabTimes.SelectedTab == tabPage3 )
            {
                lnkShowGoals.Visible = true;
            }
        }

        private void editToolStripMenuItem1_Click( object sender, EventArgs e )
        {
            ShowEdit();
        }

        private void ShowEdit()
        {
            if ( gvGoals.SelectedRows.Count > 0 )
            {
                frmEditGoal editGoal = new frmEditGoal();
                editGoal.PopulateScreen( ( (Goal)gvGoals.SelectedRows[ 0 ].DataBoundItem ), m_currUser );
                editGoal.StartPosition = FormStartPosition.CenterParent;
                editGoal.BringToFront();
                editGoal.FormClosing += new FormClosingEventHandler( editGoal_FormClosing );
                editGoal.ShowDialog( this );
            }
        }

        private void addNewToolStripMenuItem_Click( object sender, EventArgs e )
        {
            frmEditGoal editGoal = new frmEditGoal();
            editGoal.PopulateScreen( null, m_currUser );
            editGoal.StartPosition = FormStartPosition.CenterParent;
            editGoal.BringToFront();
            editGoal.FormClosing += new FormClosingEventHandler( editGoal_FormClosing );
            editGoal.ShowDialog( this );
        }

        void editGoal_FormClosing( object sender, FormClosingEventArgs e )
        {
            SetupGoals();
        }

        private const string cstrGridFilterTextCompleted = "Show Completed Goals";
        private const string cstrGridFilterTextIncomplete = "Show Incomplete Goals";

        private void lnkShowGoals_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            if ( lnkShowGoals.Text == cstrGridFilterTextCompleted )
            {
                lnkShowGoals.Text = cstrGridFilterTextIncomplete;
            }
            else
            {
                lnkShowGoals.Text = cstrGridFilterTextCompleted;
            }
            SetupGoals();
        }

        private void gvGoals_SelectionChanged( object sender, EventArgs e )
        {
            SetupGoalContext();
        }

        private void SetupGoalContext()
        {
            editToolStripMenuItem1.Enabled = gvGoals.SelectedRows.Count > 0;
        }

        private void gvGoals_DoubleClick( object sender, EventArgs e )
        {
            ShowEdit();
        }








    }
}
