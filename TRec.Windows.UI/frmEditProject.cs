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
    public partial class frmEditProject : Form
    {
        public frmEditProject()
        {
            InitializeComponent();
        }

        Project m_item = null;

        public void PopulateScreen( Project item )
        {
            m_item = item;

            txtProjId.Text = m_item.Id.ToString();
            txtProjName.Text = m_item.Description.ToString();
            chkProjActive.Checked = m_item.Active;
        }

        private void btnSave_Click( object sender, EventArgs e )
        {
            errProv.Clear();

            //validate
            List<ValidationMessage> errors = OperationsReadWrite.SaveProject(
                                                new ValidatableParameter<string> { Value = txtProjId.Text.Trim(), Source = txtProjId },
                                                new ValidatableParameter<string> { Value = txtProjName.Text.Trim(), Source = txtProjName },
                                                new ValidatableParameter<bool> { Value = chkProjActive.Checked, Source = chkProjActive } );


            if ( errors.Count > 0 )
            {
                //set up the list of controls that may have errors associated
                List<Control> validatableControls = new List<Control>();
                validatableControls.Add( txtProjId );
                validatableControls.Add( txtProjName );
                validatableControls.Add( chkProjActive );

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
