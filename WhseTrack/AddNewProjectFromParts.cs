/* Title:           Add New Projects From Part Entry
 * Date:            11-07-16
 * Author:          Terry Holmes
 * 
 * Description:     This form is used to add a new project */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectsDLL;
using DataValidationDLL;
using NewEventLogDLL;

namespace WhseTrack
{
    public partial class AddNewProjectFromParts : Form
    {
        //setting up the classes
        MessagesClass TheMessagesClass = new MessagesClass();
        ProjectClass TheProjectClass = new ProjectClass();
        DataValidationClass TheDataValidationClass = new DataValidationClass();
        EventLogClass TheEventLogClass = new EventLogClass();

        public AddNewProjectFromParts()
        {
            InitializeComponent();
        }

        private void AddNewProjectFromParts_Load(object sender, EventArgs e)
        {
            //setting date
            txtDate.Text = Convert.ToString(DateTime.Now);
            txtMSRNumber.Text = Logon.gstrMSRNumber;
            txtProjectID.Text = Logon.gstrTWCProjectID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool blnFatalError = false;
            string strErrorMessage = "";
            bool blnThereIsAProblem = false;
            string strValueForValidation;

            try
            {
                Logon.gstrTWCProjectID = txtProjectID.Text;
                Logon.gstrMSRNumber = txtMSRNumber.Text;
                strValueForValidation = txtDate.Text;

                //data validation
                blnFatalError = TheDataValidationClass.VerifyTextData(Logon.gstrTWCProjectID);
                if(blnFatalError == true)
                {
                    blnThereIsAProblem = true;
                    strErrorMessage = strErrorMessage + "The TWC Project ID Was Not Entered\n";
                }
                blnFatalError = TheDataValidationClass.VerifyDateData(strValueForValidation);
                if(blnFatalError == true)
                {
                    blnThereIsAProblem = true;
                    strErrorMessage = strErrorMessage + "The Date is not in the Correct Form\n";
                }
                else
                {
                    Logon.gdatStartDate = Convert.ToDateTime(strValueForValidation);
                }
                if(blnThereIsAProblem == true)
                {
                    TheMessagesClass.ErrorMessage(strErrorMessage);
                    return;
                }

                if(Logon.gstrMSRNumber == "")
                {
                    Logon.gstrMSRNumber = "NO MSR NUMBER PROVIDED";
                }

                //adding the records
                blnFatalError = TheProjectClass.CreateNewProject(Logon.gstrTWCProjectID, Logon.gstrMSRNumber);

                if (blnFatalError == false)
                {
                    TheMessagesClass.InformationMessage("The Project Was Saved");
                    btnClose.PerformClick();
                }                    
                else if (blnFatalError == true)
                    TheMessagesClass.ErrorMessage("The Project Was Not Saved, Contact IT");
                
            }
            catch (Exception Ex)
            {
                //message to the user
                TheMessagesClass.ErrorMessage(Ex.ToString());

                //event log entry
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Add New Project From Parts Save " + Ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
