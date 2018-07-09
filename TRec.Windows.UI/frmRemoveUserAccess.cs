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
    public partial class frmRemoveUserAccess : Form
    {
        public frmRemoveUserAccess()
        {
            InitializeComponent();

        }

        Project m_proj = null;
        Task m_task = null;
        User m_user = null;

        public void PopulateScreen( Project proj, Task tsk, User usr )
        {
            m_proj = proj;
            m_task = tsk;
            m_user = usr;

            txtProjName.Text = m_proj.Description;
            txtTaskName.Text = m_task.Description;
            txtUserName.Text = string.Format( "{0} ({1})", usr.DisplayName, usr.UserName );
        }

        private void btnRemove_Click( object sender, EventArgs e )
        {
            errProv.Clear();

            //validate
            List<ValidationMessage> errors = OperationsReadWrite.RemoveUserAccess(
                                                new ValidatableParameter<string> { Value = m_proj.Id.ToString(), Source = txtProjName },
                                                new ValidatableParameter<string> { Value = m_task.Id.ToString(), Source = txtTaskName },
                                                new ValidatableParameter<Guid> { Value = m_user.UserId, Source = txtUserName } );


            if ( errors.Count > 0 )
            {
                //set up the list of controls that may have errors associated
                List<Control> validatableControls = new List<Control>();
                validatableControls.Add( txtProjName );
                validatableControls.Add( txtTaskName );
                validatableControls.Add( txtUserName );

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
                            errProv.SetError( btnRemove, currError.MessageText );
                        }
                    }
                    else
                    {
                        errProv.SetError( btnRemove, currError.MessageText );
                    }
                }
            }
            else
            {
                this.Close();
            }
        }


        private void btnCancel_Click( object sender, EventArgs e )
        {
            this.Close();
        }

    }
}
