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
    public partial class frmAdminUser : Form
    {
        public frmAdminUser()
        {
            InitializeComponent();
        }

        User m_user = null;

        public void PopulateScreen( User item )
        {
            m_user = item;

            txtUserId.Text = m_user.UserId.ToString();
            txtUserName.Text = m_user.UserName;
            txtDisplayName.Text = m_user.DisplayName;
        }

        private void btnSave_Click( object sender, EventArgs e )
        {
            errProv.Clear();

            //validate
            List<ValidationMessage> errors = OperationsReadWrite.SaveUserDetails(
                                                new ValidatableParameter<Guid> { Value = m_user.UserId, Source = txtUserId },
                                                new ValidatableParameter<string> { Value = m_user.UserName, Source = txtUserName },
                                                new ValidatableParameter<string> { Value = txtDisplayName.Text, Source = txtDisplayName } );


            if ( errors.Count > 0 )
            {
                //set up the list of controls that may have errors associated
                List<Control> validatableControls = new List<Control>();
                validatableControls.Add( txtUserId );
                validatableControls.Add( txtUserName );
                validatableControls.Add( txtDisplayName );

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
                this.Close();
            }
        }

        private void btnCancel_Click( object sender, EventArgs e )
        {
            this.Close();
        }


    }
}
