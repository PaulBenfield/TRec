using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TRec.BusinessLayer;
using System.Diagnostics;


namespace TRec.Windows.UI
{
    public partial class frmMain : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public frmMain()
        {
            InitializeComponent();

            Process currentProc = Process.GetCurrentProcess();

            bool continueProcessing = true;

            Process[] existingProcesses = Process.GetProcessesByName( currentProc.ProcessName, currentProc.MachineName );
            if ( existingProcesses.Count() > 0 )
            {
                Process sameProc = null;
                int currIndex = 0;
                while ( sameProc == null && currIndex < existingProcesses.Count() )
                {
                    if ( existingProcesses[ currIndex ].Id != currentProc.Id && string.Equals( existingProcesses[ currIndex ].StartInfo.FileName, currentProc.StartInfo.FileName, StringComparison.CurrentCultureIgnoreCase ) )
                    {
                        sameProc = existingProcesses[ currIndex ];
                    }
                    currIndex++;
                }

                if ( sameProc != null )
                {
                    MessageBox.Show( string.Format( "Error: The file {0} is already running, you cannot run it more than once.  If you cannot see it, kill the process in task manager (ctrl+alt+del).  Process Id = {1} Process Name = {2}", sameProc.StartInfo.FileName, sameProc.Id.ToString(), sameProc.ProcessName ), "Error - Program already running", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    continueProcessing = false;
                    Application.Exit();
                    this.Close();
                    this.Dispose();
                }
            }

            if ( continueProcessing )
            {
                //todo: popup a window and ask for either windows identity or login with username and password
                m_currUser = OperationsReadOnly.CreateOrGetUser( System.Security.Principal.WindowsIdentity.GetCurrent() );

                //Turn this on for initialising one project and task on entry
                //OperationsReadWrite.TempInit();

                this.ShowInTaskbar = false;
                this.WindowState = FormWindowState.Minimized;

                //set the last reminder so that it will show straight away the first time
                m_dtLastReminder = DateTime.Now.AddMilliseconds( -m_reminderMilliseconds );

                //set the last entry initially - taken out as it can be annoying when days apart, need to think about this
                //m_lastEntry = OperationsReadOnly.GetLatestTimeEntry( m_currUser );


                //instead, get from settings
                LocalSettings settings = OperationsReadOnly.GetLocalSettings();
                if ( settings != null )
                {
                    if ( settings.LastTimeEntryId != Guid.Empty )
                    {
                        m_lastEntry = OperationsReadOnly.GetTimeEntryById( settings.LastTimeEntryId, m_currUser );
                    }

                    if ( settings.LastReminderPeriodInMilliseconds > 0 )
                    {
                        m_reminderMilliseconds = settings.LastReminderPeriodInMilliseconds;
                    }

                }
            }
        }

        /// <summary>
        /// Determines if this has been run for the first time
        /// </summary>
        bool m_hasBeenRun = false;

        /// <summary>
        /// Indicates if the reminder balloon is open or not
        /// </summary>
        bool m_bIsReminderOpen = false;

        /// <summary>
        /// Stores the time entry form instance
        /// </summary>
        frmTimeEntry m_timeForm = null;

        /// <summary>
        /// Stores the last time a reminder was shown
        /// </summary>
        DateTime m_dtLastReminder = DateTime.Now;

        /// <summary>
        /// Stores the last start date entered
        /// </summary>
        DateTime m_dfLastStartDate = DateTime.Now;

        /// <summary>
        /// Stores the current logged in user instance
        /// </summary>
        User m_currUser = null;

        /// <summary>
        /// Stores the current project
        /// </summary>
        Project m_currProject = null;

        /// <summary>
        /// Stores the current task
        /// </summary>
        Task m_currTask = null;

        /// <summary>
        /// Stores the last location of the time entry form
        /// </summary>
        private Point m_lastLocation = Point.Empty;

        /// <summary>
        /// Stores the last size of the time entry form
        /// </summary>
        private Size m_lastSize = Size.Empty;

        /// <summary>
        /// Sets the number of minutes to re-show the balloon if it was ignored
        /// </summary>
        private int m_nIgnoreMilliseconds = 60000;

        /// <summary>
        /// Stored whether the last action taken was an ignore
        /// </summary>
        private bool m_bWasIgnored = false;

        private DateTime m_dtLastShow = DateTime.Now;

        private int m_reminderMilliseconds = 60000;

        //remember the last entry used
        TimeEntry m_lastEntry = null;

        /// <summary>
        /// This even occurs every
        /// </summary>
        /// <param name="sender">object that raised the event - in this case a timer</param>
        /// <param name="e">arguments passed to the event</param>
        /// <remarks>
        /// Pre:
        /// - the reminder balloon may or may not be open
        /// - the time entry form may or may not be open
        /// - the specified reminder interval for the user may or may not ahve passed from the last reminder time
        /// Post:
        /// - notifier balloon may have tip text changed
        /// - notifier balloon may be displayed
        /// </remarks>
        private void tmrCheck_Tick( object sender, EventArgs e )
        {
            if ( !m_hasBeenRun ||
               ( !m_bIsReminderOpen && m_timeForm == null
                && ( DateTime.Now >= m_dtLastReminder.AddMilliseconds( m_reminderMilliseconds )
                    || ( m_bWasIgnored == true && DateTime.Now >= m_dtLastShow.AddMilliseconds( m_nIgnoreMilliseconds ) )
                   )
                )
                )
            {
                m_hasBeenRun = true;
                ShowBalloon();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifier_BalloonTipShown( object sender, EventArgs e )
        {
            m_bIsReminderOpen = true;
        }

        private void notifier_BalloonTipClosed( object sender, EventArgs e )
        {
            m_bIsReminderOpen = false;

            //update the last reminder time
            //this allows for an ignore, take it out to disallow ignores
            m_dtLastReminder = DateTime.Now;

            //set ignore to be same as last sleep
            m_nIgnoreMilliseconds = m_reminderMilliseconds;

            //indicate that it was ignored
            m_bWasIgnored = true;
            m_dtLastShow = DateTime.Now;
        }

        private void notifier_BalloonTipClicked( object sender, EventArgs e )
        {
            if ( m_timeForm != null )
            {
                m_timeForm.Activate();
                m_timeForm.BringToFront();
            }
            else
            {
                ShowForm();
            }

        }

        private void ShowForm()
        {
            m_bIsReminderOpen = false;

            m_timeForm = new frmTimeEntry();

            m_timeForm.FormClosed += new FormClosedEventHandler( m_timeForm_FormClosed );

            if ( tmrCheck.Enabled == false )
            {
                //if the timer has been stopped (end of day) then reset the last end date
                m_dfLastStartDate = DateTime.Now;
            }

            //TODO: Check for standard start / stop times and clock state

            m_timeForm.PopulateScreen( m_currUser, m_lastEntry, tmrCheck.Enabled, m_reminderMilliseconds );


            //sest the location of the form to be the last location
            if ( m_lastLocation != Point.Empty )
            {
                m_timeForm.Location = m_lastLocation;
            }

            //set the size of the form to be the last size
            if ( m_lastSize != Size.Empty )
            {
                m_timeForm.Size = m_lastSize;
            }


            m_timeForm.ShowDialog( this );
        }

        void m_timeForm_FormClosed( object sender, FormClosedEventArgs e )
        {
            FinaliseFormClose();
        }

        /// <summary>
        /// Finalisation of form closing procedure
        /// </summary>
        private void FinaliseFormClose()
        {
            if ( m_timeForm != null )
            {
                //remember the last saved entry
                m_lastEntry = m_timeForm.LastSavedEntry;

                if ( m_timeForm != null )
                {
                    //if we get more properties, might have to retrieve, but for now just construct a new one each time for efficiency
                    LocalSettings settings = new LocalSettings();

                    //if the save button was clicked, update the indicator values
                    if ( m_timeForm.LastSavedEntry != null )
                    {
                        m_currProject = m_timeForm.SelectedProject;
                        m_currTask = m_timeForm.SelectedTask;
                        m_dfLastStartDate = m_timeForm.StartTime;
                        settings.LastTimeEntryId = m_timeForm.LastSavedEntry.TimeEntryId;
                    }
                    else
                    {
                        if ( m_currProject != null )
                        {
                            //if we were previously working on something, set the last start date to now
                            //so that while the clock is stopped it keeps this time
                            m_dfLastStartDate = DateTime.Now;
                        }
                        m_currProject = null;
                        m_currTask = null;
                        settings.LastTimeEntryId = Guid.Empty;
                    }

                    //set the reminder interval
                    settings.LastReminderPeriodInMilliseconds = m_timeForm.ReminderMilliseconds;

                    OperationsReadWrite.SaveLocalSettings( settings );

                }

                //set the reminder milliseconds
                m_reminderMilliseconds = m_timeForm.ReminderMilliseconds;


                //set enabled status on timer
                tmrCheck.Enabled = m_timeForm.AreRemindersOn;


                //update the last reminder time
                m_dtLastReminder = DateTime.Now;

                m_bWasIgnored = false;
                m_dtLastShow = DateTime.Now;

                //remember the location and size
                if ( m_timeForm != null )
                {
                    m_lastLocation = m_timeForm.Location;
                    m_lastSize = m_timeForm.Size;

                    m_timeForm.Dispose();
                    m_timeForm = null;
                }
            }
        }

        /// <summary>
        /// Display the notifier on single click (if not already displayed)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifier_MouseClick( object sender, MouseEventArgs e )
        {
            if ( e.Button == MouseButtons.Left )
            {
                ShowBalloon();
            }
        }


        private void ShowBalloon()
        {
            string lastWorkedOn = "Nothing";
            string lastWorkedOnSince = m_dfLastStartDate.ToShortTimeString();
            if ( m_currProject != null )
            {
                lastWorkedOn = m_currProject.Description;
            }
            if ( m_currTask != null )
            {
                lastWorkedOn = string.Format( "{0} - {1}", lastWorkedOn, m_currTask.Description );
            }

            notifier.BalloonTipText = string.Format( "You have been working on {0} since {1}. Click here to change.", lastWorkedOn, lastWorkedOnSince );
            notifier.ShowBalloonTip( m_reminderMilliseconds );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eToolStripMenuItem_Click( object sender, EventArgs e )
        {
            this.Close();

        }

        /// <summary>
        /// Opens the application window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click( object sender, EventArgs e )
        {
            ShowForm();
        }

        private void runAsDifferentUserToolStripMenuItem_Click( object sender, EventArgs e )
        {

        }

        private void frmMain_Load( object sender, EventArgs e )
        {

        }

        private void frmMain_KeyDown( object sender, KeyEventArgs e )
        {
            //When the form has focus in the task bar and you hit enter,
            //the form will show up.  This prevents that from occurring.
            if ( e.KeyCode == Keys.Enter )
            {
                e.SuppressKeyPress = true; 
            }
        }





    }
}
