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
    public partial class frmAddTask : Form
    {
        public frmAddTask()
        {
            InitializeComponent();
        }

        Project m_proj = null;

        public void PopulateScreen( Project proj )
        {
            m_proj = proj;
            txtProjName.Text = m_proj.Description;
        }

        private void btnSave_Click( object sender, EventArgs e )
        {
            errProv.Clear();

            //validate
            List<ValidationMessage> errors = OperationsReadWrite.SaveTask(
                                                new ValidatableParameter<string> { Value = m_proj.Id.ToString(), Source = txtProjName },
                                                new ValidatableParameter<string> { Value = Guid.Empty.ToString(), Source = null },
                                                new ValidatableParameter<string> { Value = txtTaskName.Text.Trim(), Source = txtTaskName },
                                                new ValidatableParameter<bool> { Value = true, Source = null } );


            if ( errors.Count > 0 )
            {
                //set up the list of controls that may have errors associated
                List<Control> validatableControls = new List<Control>();
                validatableControls.Add( txtProjName );
                validatableControls.Add( txtTaskName );

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
