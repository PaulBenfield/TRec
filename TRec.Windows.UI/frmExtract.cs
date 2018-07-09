using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TRec.BusinessLayer;
using System.Configuration;
using Microsoft.Reporting.WinForms;

namespace TRec.Windows.UI
{
    public partial class frmExtract : Form
    {
        private const string cstrCSVDataExtract = "CSV Data Extract";

        private const string cstrTimeAgainstProjects = "Time Against Projects";
        private const string cstrTimeAgainstTasks = "Time Against Tasks";
        private const string cstrTimeAgainstProjectsAndTasks = "Time Against Projects and Tasks Combined";
        private const string cstrExceptionTime = "Exception Time";
        private const string cstrGenericTimesheet = "Generic Timesheet (Start, Finish, Breaks)";
        private const string cstrCompletedGoals = "Completed Goals";

        public frmExtract()
        {
            InitializeComponent();

            string defaultFile1 = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyTimeEntryFile ];
            if ( !string.IsNullOrEmpty( defaultFile1 ) )
            {
                if ( !defaultFile1.Contains( ":" ) )
                {
                    //this is a relative path, append the app directory
                    defaultFile1 = AppDomain.CurrentDomain.BaseDirectory + defaultFile1;
                }
                lstFiles.Items.Add( defaultFile1 );
            }

            string defaultFile2 = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyGoalsFile ];
            if ( !string.IsNullOrEmpty( defaultFile2 ) )
            {
                if ( !defaultFile2.Contains( ":" ) )
                {
                    //this is a relative path, append the app directory
                    defaultFile2 = AppDomain.CurrentDomain.BaseDirectory + defaultFile2;
                }
                lstGoalFiles.Items.Add( defaultFile2 );
            }

            SetupReportTypes();
        }

        private void SetupReportTypes()
        {
            cbxReportTypes.Items.Clear();
            cbxReportTypes.Items.Add( cstrCSVDataExtract );

            if ( tcType.SelectedTab == tabPage1 )
            {
                cbxReportTypes.Items.Add( cstrTimeAgainstProjects );
                cbxReportTypes.Items.Add( cstrTimeAgainstTasks );
                cbxReportTypes.Items.Add( cstrTimeAgainstProjectsAndTasks );
                cbxReportTypes.Items.Add( cstrExceptionTime );
                cbxReportTypes.Items.Add( cstrGenericTimesheet );
            }
            else
            {
                cbxReportTypes.Items.Add( cstrCompletedGoals );
            }

            cbxReportTypes.SelectedIndex = 0;
        }

        public User CurrentUser { get; set; }

        private const string cstrSeparator = ",";

        private string selectedReportType = string.Empty;

        private ReportViewer rptVw = null;

        private bool isTimeReport = false;

        private void btnExtract_Click( object sender, EventArgs e )
        {
            tcType.Enabled = false;
            btnExtract.Enabled = false;
            btnCancel.Enabled = true;

            //clear previous report
            pnlRpt.Controls.Clear();
            rptVw = null;

            //add new report
            rptVw = new ReportViewer();
            rptVw.Dock = DockStyle.Fill;
            pnlRpt.Controls.Add( rptVw );

            selectedReportType = cbxReportTypes.SelectedItem.ToString();
            isTimeReport = tcType.SelectedTab == tabPage1;

            bgwGenerate.RunWorkerAsync();
        }

        private void bgwGenerate_DoWork( object sender, DoWorkEventArgs e )
        {
            if ( isTimeReport )
            {
                //doing time entry report

                List<string> fnames = new List<string>();

                foreach ( string fileName in lstFiles.Items )
                {
                    fnames.Add( fileName );
                }

                List<ReportingItemSummary> reportItems = OperationsReadOnly.GetReportingItems( dtpStart.Value, dtpEnd.Value, fnames );

                if ( selectedReportType == cstrCSVDataExtract )
                {
                    StringBuilder stb = new StringBuilder();

                    stb.Append( "Time Entry Id" );
                    stb.Append( cstrSeparator );
                    stb.Append( "User Id" );
                    stb.Append( cstrSeparator );
                    stb.Append( "User Display Name" );
                    stb.Append( cstrSeparator );
                    stb.Append( "Project Id" );
                    stb.Append( cstrSeparator );
                    stb.Append( "Project Name" );
                    stb.Append( cstrSeparator );
                    stb.Append( "Task Id" );
                    stb.Append( cstrSeparator );
                    stb.Append( "Task Name" );
                    stb.Append( cstrSeparator );
                    stb.Append( "Start DateTime" );
                    stb.Append( cstrSeparator );
                    stb.Append( "End DateTime" );
                    stb.Append( cstrSeparator );
                    stb.Append( "Exception Minutes" );
                    stb.Append( cstrSeparator );
                    stb.Append( "Total TimeMinutes" );
                    stb.Append( cstrSeparator );
                    stb.Append( "Details" );
                    stb.Append( cstrSeparator );
                    stb.Append( "Exception Details" );
                    stb.Append( Environment.NewLine );

                    foreach ( ReportingItemSummary currItem in reportItems )
                    {
                        stb.Append( FormatResult( currItem.TimeEntryId ) );
                        stb.Append( cstrSeparator );

                        stb.Append( FormatResult( currItem.UserId ) );
                        stb.Append( cstrSeparator );
                        stb.Append( FormatResult( currItem.UserDisplayName ) );
                        stb.Append( cstrSeparator );

                        stb.Append( FormatResult( currItem.ProjectId ) );
                        stb.Append( cstrSeparator );
                        stb.Append( FormatResult( currItem.ProjectName ) );
                        stb.Append( cstrSeparator );

                        stb.Append( FormatResult( currItem.TaskId ) );
                        stb.Append( cstrSeparator );
                        stb.Append( FormatResult( currItem.TaskName ) );
                        stb.Append( cstrSeparator );

                        stb.Append( FormatResult( currItem.StartDateTime ) );
                        stb.Append( cstrSeparator );

                        stb.Append( FormatResult( currItem.EndDateTime ) );
                        stb.Append( cstrSeparator );

                        stb.Append( FormatResult( currItem.ExceptionMinutes ) );
                        stb.Append( cstrSeparator );

                        stb.Append( FormatResult( currItem.TotalMinutes ) );
                        stb.Append( cstrSeparator );

                        stb.Append( FormatResult( currItem.Details ) );
                        stb.Append( cstrSeparator );

                        stb.Append( FormatResult( currItem.ExceptionDetails ) );
                        stb.Append( cstrSeparator );

                        stb.Append( Environment.NewLine );
                    }

                    e.Result = stb.ToString();
                }
                else
                {
                    e.Result = reportItems;
                }

            }
            else
            {
                //doing goal report

                List<string> fnames = new List<string>();

                foreach ( string fileName in lstGoalFiles.Items )
                {
                    fnames.Add( fileName );
                }

                List<ReportingGoalSummary> reportItems = OperationsReadOnly.GetReportingGoals( dtpGoalStart.Value, dtpGoalEnd.Value, fnames );

                if ( selectedReportType == cstrCSVDataExtract )
                {
                    StringBuilder stb = new StringBuilder();

                    stb.Append( "Goal Id" );
                    stb.Append( cstrSeparator );
                    stb.Append( "User Id" );
                    stb.Append( cstrSeparator );
                    stb.Append( "User Display Name" );
                    stb.Append( cstrSeparator );
                    stb.Append( "Description" );
                    stb.Append( cstrSeparator );
                    stb.Append( "Target Measure" );
                    stb.Append( cstrSeparator );
                    stb.Append( "Target Completion Date" );
                    stb.Append( cstrSeparator );
                    stb.Append( "Completed" );
                    stb.Append( cstrSeparator );
                    stb.Append( "Result Measure" );
                    stb.Append( cstrSeparator );
                    stb.Append( "Result Measure Rating" );
                    stb.Append( cstrSeparator );
                    stb.Append( "Actual Completion Date" );
                    stb.Append( cstrSeparator );
                    stb.Append( "Result Timeliness Rating" );
                    stb.Append( cstrSeparator );
                    stb.Append( "Positives" );
                    stb.Append( cstrSeparator );
                    stb.Append( "Improvements" );
                    stb.Append( Environment.NewLine );

                    foreach ( ReportingGoalSummary currItem in reportItems )
                    {
                        stb.Append( FormatResult( currItem.GoalId ) );
                        stb.Append( cstrSeparator );

                        stb.Append( FormatResult( currItem.UserId ) );
                        stb.Append( cstrSeparator );
                        stb.Append( FormatResult( currItem.UserDisplayName ) );
                        stb.Append( cstrSeparator );

                        stb.Append( FormatResult( currItem.Description ) );
                        stb.Append( cstrSeparator );
                        stb.Append( FormatResult( currItem.TargetMeasure ) );
                        stb.Append( cstrSeparator );
                        stb.Append( FormatResult( currItem.TargetCompletionDate ) );
                        stb.Append( cstrSeparator );
                        stb.Append( FormatResult( currItem.Completed ) );
                        stb.Append( cstrSeparator );
                        stb.Append( FormatResult( currItem.ResultMeasure ) );
                        stb.Append( cstrSeparator );
                        stb.Append( FormatResult( currItem.ResultMeasureRating ) );
                        stb.Append( cstrSeparator );
                        stb.Append( FormatResult( currItem.ActualCompletionDate ) );
                        stb.Append( cstrSeparator );
                        stb.Append( FormatResult( currItem.ResultTimelinessRating ) );
                        stb.Append( cstrSeparator );
                        stb.Append( FormatResult( currItem.Positives ) );
                        stb.Append( cstrSeparator );
                        stb.Append( FormatResult( currItem.Improvements ) );
                        stb.Append( cstrSeparator );

                        stb.Append( Environment.NewLine );
                    }

                    e.Result = stb.ToString();
                }
                else
                {
                    e.Result = reportItems;
                }

            }
        }

        private string FormatResult( string current )
        {
            return string.IsNullOrEmpty( current ) ? string.Empty : current.Replace( cstrSeparator, string.Empty ).Replace( Environment.NewLine, " " ).Replace( @"\n", string.Empty ).Replace( @"\r", string.Empty );
        }

        private string FormatResult( Guid current )
        {
            return current.ToString();
        }

        private string FormatResult( int current )
        {
            return current.ToString();
        }

        private string FormatResult( bool current )
        {
            return current == true ? "yes" : "no";
        }

        private string FormatResult( DateTime current )
        {
            return current.ToString( "yyyy-MM-dd HH:mm" );
        }

        private void bgwGenerate_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
        {
            if ( !e.Cancelled )
            {
                if ( selectedReportType == cstrCSVDataExtract )
                {
                    SaveFileDialog dlg = new SaveFileDialog();
                    dlg.Title = "Save data to";
                    dlg.Filter = "CSV Files(*.csv)|*.csv";
                    DialogResult res = dlg.ShowDialog();
                    if ( res == DialogResult.OK )
                    {
                        FileInfo f = new FileInfo( dlg.FileName );
                        using ( FileStream fs = new FileStream( f.FullName, FileMode.Create ) )
                        {
                            byte[] b = System.Text.Encoding.ASCII.GetBytes( e.Result.ToString() );
                            fs.Write( b, 0, b.Length - 1 );
                            fs.Close();
                        }
                    }
                }
                else
                {
                    if ( e.Result != null )
                    {


                        if ( selectedReportType == cstrTimeAgainstProjects )
                        {
                            rptVw.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "ProjectTime.rdlc";
                            rptVw.LocalReport.DataSources.Clear();
                            rptVw.LocalReport.DataSources.Add( new ReportDataSource( "ReportingItemSummary", e.Result ) );
                            rptVw.RefreshReport();
                        }
                        else if ( selectedReportType == cstrTimeAgainstTasks )
                        {
                            rptVw.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "TaskTime.rdlc";
                            rptVw.LocalReport.DataSources.Clear();
                            rptVw.LocalReport.DataSources.Add( new ReportDataSource( "ReportingItemSummary", e.Result ) );
                            rptVw.RefreshReport();
                        }
                        else if ( selectedReportType == cstrTimeAgainstProjectsAndTasks )
                        {
                            rptVw.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "ProjectTaskTime.rdlc";
                            rptVw.LocalReport.DataSources.Clear();
                            rptVw.LocalReport.DataSources.Add( new ReportDataSource( "ReportingItemSummary", e.Result ) );
                            rptVw.RefreshReport();
                        }
                        else if ( selectedReportType == cstrExceptionTime )
                        {
                            rptVw.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "ExceptionTime.rdlc";
                            rptVw.LocalReport.DataSources.Clear();
                            rptVw.LocalReport.DataSources.Add( new ReportDataSource( "ReportingItemSummary", e.Result ) );
                            rptVw.RefreshReport();
                        }
                        else if ( selectedReportType == cstrGenericTimesheet )
                        {
                            rptVw.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "GenericTimesheetView.rdlc";
                            rptVw.LocalReport.DataSources.Clear();
                            rptVw.LocalReport.DataSources.Add( new ReportDataSource( "ReportingItemSummary", e.Result ) );
                            rptVw.RefreshReport();
                        }
                        else if ( selectedReportType == cstrCompletedGoals )
                        {
                            rptVw.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Goals.rdlc";
                            rptVw.LocalReport.DataSources.Clear();
                            rptVw.LocalReport.DataSources.Add( new ReportDataSource( "TRec_BusinessLayer_ReportingGoalSummary", e.Result ) );
                            rptVw.RefreshReport();
                        }
                    }
                }
            }
            tcType.Enabled = true;
            btnExtract.Enabled = true;
            btnCancel.Enabled = false;
            rptVw.Enabled = true;
        }

        private void btnCancel_Click( object sender, EventArgs e )
        {
            bgwGenerate.CancelAsync();
        }

        private void btnAdd_Click( object sender, EventArgs e )
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Select Time Entry File";
            dlg.Filter = "XML Files(*.xml)|*.xml";
            DialogResult res = dlg.ShowDialog();
            if ( res == DialogResult.OK )
            {
                FileInfo f = new FileInfo( dlg.FileName );
                if ( f.Exists )
                {
                    if ( !lstFiles.Items.Contains( f.FullName ) )
                    {
                        lstFiles.Items.Add( f.FullName );
                    }
                }
            }
        }

        private void btnDelete_Click( object sender, EventArgs e )
        {
            if ( lstFiles.SelectedItem != null )
            {
                lstFiles.Items.Remove( lstFiles.SelectedItem );
            }
        }

        private void btnGoalFilesAdd_Click( object sender, EventArgs e )
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Select Goal File";
            dlg.Filter = "XML Files(*.xml)|*.xml";
            DialogResult res = dlg.ShowDialog();
            if ( res == DialogResult.OK )
            {
                FileInfo f = new FileInfo( dlg.FileName );
                if ( f.Exists )
                {
                    if ( !lstGoalFiles.Items.Contains( f.FullName ) )
                    {
                        lstGoalFiles.Items.Add( f.FullName );
                    }
                }
            }
        }

        private void btnGoalFilesRemove_Click( object sender, EventArgs e )
        {
            if ( lstGoalFiles.SelectedItem != null )
            {
                lstGoalFiles.Items.Remove( lstGoalFiles.SelectedItem );
            }
        }

        private void tcType_SelectedIndexChanged( object sender, EventArgs e )
        {
            SetupReportTypes();
        }

    }
}
