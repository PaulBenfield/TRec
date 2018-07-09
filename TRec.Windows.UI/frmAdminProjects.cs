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
    public partial class frmAdminProjects : Form
    {
        List<Project> m_projs = null;
        DateTime m_projsRetrieved = DateTime.Now;

        List<Task> m_tasks = null;
        DateTime m_tasksRetrieved = DateTime.Now;

        List<User> m_users = null;
        DateTime m_usersRetrieved = DateTime.Now;

        public frmAdminProjects()
        {
            InitializeComponent();

            SetupProjects();
        }

        private void SetupProjects()
        {
            m_projs = OperationsReadOnly.GetAllProjects();
            m_projsRetrieved = DateTime.Now;
            dgProjects.DataSource = m_projs;
        }

        private void SetupTasks()
        {
            if ( dgProjects.SelectedRows.Count > 0 )
            {
                Project currItem = (Project)dgProjects.SelectedRows[ 0 ].DataBoundItem;

                m_tasks = OperationsReadOnly.GetAllTasksForProject( currItem.Id );
                m_tasksRetrieved = DateTime.Now;
                dgTasks.DataSource = m_tasks;
            }
        }

        private void SetupUserAccess()
        {
            if ( dgTasks.SelectedRows.Count > 0 )
            {
                Task currItem = (Task)dgTasks.SelectedRows[ 0 ].DataBoundItem;

                m_users = OperationsReadOnly.GetAllUsersForTask( currItem.ProjectId, currItem.Id );
                m_usersRetrieved = DateTime.Now;
                dgUsers.DataSource = m_users;
            }
        }

        private void btnAddProj_Click( object sender, EventArgs e )
        {
            frmAddProject frmChangeProj = new frmAddProject();
            frmChangeProj.StartPosition = FormStartPosition.CenterParent;
            frmChangeProj.BringToFront();
            frmChangeProj.FormClosing += new FormClosingEventHandler( frmChangeProj_FormClosing );
            frmChangeProj.ShowDialog( this );
        }

        private void dgProjects_DoubleClick( object sender, EventArgs e )
        {
            if ( dgProjects.SelectedRows.Count > 0 )
            {
                //ensure multi select is false so we only get one row selected
                Project currItem = (Project)dgProjects.SelectedRows[ 0 ].DataBoundItem;

                frmEditProject frmChangeProj = new frmEditProject();
                frmChangeProj.PopulateScreen( currItem );
                frmChangeProj.StartPosition = FormStartPosition.CenterParent;
                frmChangeProj.BringToFront();
                frmChangeProj.FormClosing += new FormClosingEventHandler( frmChangeProj_FormClosing );
                frmChangeProj.ShowDialog( this );
            }
        }

        void frmChangeProj_FormClosing( object sender, FormClosingEventArgs e )
        {
            SetupProjects();
        }

        private void dgProjects_SelectionChanged( object sender, EventArgs e )
        {
            SetupTasks();
        }

        private void btnAddTask_Click( object sender, EventArgs e )
        {
            frmAddTask frmChangeTask = new frmAddTask();
            frmChangeTask.PopulateScreen( (Project)dgProjects.SelectedRows[ 0 ].DataBoundItem );
            frmChangeTask.StartPosition = FormStartPosition.CenterParent;
            frmChangeTask.BringToFront();
            frmChangeTask.FormClosing += new FormClosingEventHandler( frmChangeTask_FormClosing );
            frmChangeTask.ShowDialog( this );
        }

        void frmChangeTask_FormClosing( object sender, FormClosingEventArgs e )
        {
            SetupTasks();
        }

        private void dgTasks_DoubleClick( object sender, EventArgs e )
        {
            if ( dgTasks.SelectedRows.Count > 0 )
            {
                //ensure multi select is false so we only get one row selected
                Task currItem = (Task)dgTasks.SelectedRows[ 0 ].DataBoundItem;

                frmEditTask frmChangeTask = new frmEditTask();
                frmChangeTask.PopulateScreen( (Project)dgProjects.SelectedRows[ 0 ].DataBoundItem, currItem );
                frmChangeTask.StartPosition = FormStartPosition.CenterParent;
                frmChangeTask.BringToFront();
                frmChangeTask.FormClosing += new FormClosingEventHandler( frmChangeTask_FormClosing );
                frmChangeTask.ShowDialog( this );
            }
        }

        private void dgTasks_SelectionChanged( object sender, EventArgs e )
        {
            SetupUserAccess();
        }

        private void btnAddUser_Click( object sender, EventArgs e )
        {
            if ( dgTasks.SelectedRows.Count > 0 )
            {
                //ensure multi select is false so we only get one row selected
                Task currItem = (Task)dgTasks.SelectedRows[ 0 ].DataBoundItem;

                frmAddUserAccess frmChangeUserAccess = new frmAddUserAccess();
                frmChangeUserAccess.PopulateScreen( (Project)dgProjects.SelectedRows[ 0 ].DataBoundItem, currItem );
                frmChangeUserAccess.StartPosition = FormStartPosition.CenterParent;
                frmChangeUserAccess.BringToFront();
                frmChangeUserAccess.FormClosing += new FormClosingEventHandler( frmChangeUserAccess_FormClosing );
                frmChangeUserAccess.ShowDialog( this );
            }
        }

        void frmChangeUserAccess_FormClosing( object sender, FormClosingEventArgs e )
        {
            SetupUserAccess();
        }

        private void dgUsers_DoubleClick( object sender, EventArgs e )
        {
            if ( dgUsers.SelectedRows.Count > 0 )
            {
                //ensure multi select is false so we only get one row selected
                User currItem = (User)dgUsers.SelectedRows[ 0 ].DataBoundItem;

                frmRemoveUserAccess frmChangeUserAccess = new frmRemoveUserAccess();
                frmChangeUserAccess.PopulateScreen( (Project)dgProjects.SelectedRows[ 0 ].DataBoundItem, (Task)dgTasks.SelectedRows[ 0 ].DataBoundItem, currItem );
                frmChangeUserAccess.StartPosition = FormStartPosition.CenterParent;
                frmChangeUserAccess.BringToFront();
                frmChangeUserAccess.FormClosing += new FormClosingEventHandler( frmChangeUserAccess_FormClosing );
                frmChangeUserAccess.ShowDialog( this );
            }
        }


    }
}
