/* Title:           Sign Out Vehicle
 * Date:            12-27-16
 * Author:          Terry Holmes
 * 
 * Description:     This form is used to sign vehicles in or out */            

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewEmployeeDLL;
using VehiclesDLL;
using VehicleHistoryDLL;
using NewEventLogDLL;
using DataValidationDLL;
using InspectionsDLL;

namespace WhseTrack
{
    public partial class SignOutVehicle : Form
    {
        //setting up the classes
        MessagesClass TheMessagesClass = new MessagesClass();
        EmployeeClass TheEmployeeClass = new EmployeeClass();
        VehicleClass TheVehicleClass = new VehicleClass();
        VehicleHistoryClass TheVehicleHistoryClass = new VehicleHistoryClass();
        EventLogClass TheEventLogClass = new EventLogClass();
        DataValidationClass TheDataValidationClass = new DataValidationClass();
        InspectionsClass TheInspectionsClass = new InspectionsClass();

        VehicleSignedOutDataSet TheVehicleSignedOutDataSet;

        ComboEmployeeDataSet TheComboEmployeeDataSet = new ComboEmployeeDataSet();
        VehiclesDataSet TheVehiclesDataSet;
        
        public SignOutVehicle()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //this will close the program
            TheMessagesClass.CloseTheProgram();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            MainMenu MainMenu = new MainMenu();
            MainMenu.Show();
            this.Close();
        }

        private void btnVehicleMenu_Click(object sender, EventArgs e)
        {
            VehicleMenu VehicleMenu = new VehicleMenu();
            VehicleMenu.Show();
            this.Close();
        }

        private void SignOutVehicle_Load(object sender, EventArgs e)
        {
            //setting local varibles
            try
            {
                chkLocalVehicle.Checked = true;
                chkSignOut.Checked = true;

                
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Sign Out Vehicle Form Load " + Ex.Message);

                TheMessagesClass.ErrorMessage(Ex.ToString());
            }

        }

        private void txtEnterLastName_TextChanged(object sender, EventArgs e)
        {
            //setting local variables
            int intCounter;
            int intNumberOfRecords;
            string strLastNameEntered;
            
            try
            {
                //getting the last name
                strLastNameEntered = txtEnterLastName.Text;

                cboSelectEmployee.Items.Clear();
                cboSelectEmployee.Items.Add("Select Employee");

                TheComboEmployeeDataSet = TheEmployeeClass.FillEmployeeComboBox(strLastNameEntered);

                intNumberOfRecords = TheComboEmployeeDataSet.employees.Rows.Count - 1;

                if(intNumberOfRecords == -1)
                {
                    TheMessagesClass.InformationMessage("Employee Not Found");
                }
                else
                {
                    for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                    {
                        cboSelectEmployee.Items.Add(TheComboEmployeeDataSet.employees[intCounter].FullName);
                    }
                }

                cboSelectEmployee.SelectedIndex = 0;

            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Sign Out Vehicle txtEnterLastName Event " + Ex.Message);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            //this will process the transaction
            //setting local variables
            int intVehicleID = 0;
            int intBJCNumber = 0;
            int intEmployeeID = 0;
            DateTime datTransactionDate = DateTime.Now;
            string strAvailable = "";
            string strErrorMessage = "";
            bool blnFatalError;
            bool blnThereIsAProblem = false;
            string strValueForValidation;
            string strFullName;
            int intEmployeeCounter;
            int intEmployeeUpperLimit;
            string strVehicleNotes = "";
            string strRemoteVehicle = "";
            int intRecordsReturned = 0;
            
            try
            {
                //beginning data validation
                strValueForValidation = txtEnterBJCNumber.Text;
                blnFatalError = TheDataValidationClass.VerifyIntegerData(strValueForValidation);
                if(blnFatalError == true)
                {
                    blnThereIsAProblem = true;
                    strErrorMessage += "The BJC Number is not an Integer\n";
                }
                else
                {
                    intBJCNumber = Convert.ToInt32(strValueForValidation);
                    TheVehiclesDataSet = TheVehicleClass.GetActiveVehicleByBJCNumber(intBJCNumber);
                    intRecordsReturned = TheVehiclesDataSet.vehicles.Rows.Count;
                    if(intRecordsReturned == 0)
                    {
                        strErrorMessage += "The BJC Number Entered Does Not Exist\n";
                    }
                    else
                    {
                        intVehicleID = TheVehiclesDataSet.vehicles[0].VehicleID;
                    }
                    
                }
                if(txtEnterLastName.Text == "")
                {
                    blnThereIsAProblem = true;
                    strErrorMessage += "Last Name Was Not Entered\n";
                }
                strFullName = cboSelectEmployee.Text;
                if(strFullName == "Select Employee")
                {
                    blnThereIsAProblem = true;
                    strErrorMessage += "The Employee Last Name Was Not Selected\n";
                }
                if(blnThereIsAProblem == true)
                {
                    TheMessagesClass.ErrorMessage(strErrorMessage);
                    return;
                }

                //setting the range
                intEmployeeUpperLimit = TheComboEmployeeDataSet.employees.Rows.Count - 1;

                //loop
                for(intEmployeeCounter = 0; intEmployeeCounter <= intEmployeeUpperLimit; intEmployeeCounter++)
                {
                    if(strFullName == TheComboEmployeeDataSet.employees[intEmployeeCounter].FullName)
                    {
                        intEmployeeID = TheComboEmployeeDataSet.employees[intEmployeeCounter].EmployeeID;
                    }
                }

                //checking check box
                if(chkSignOut.Checked == true)
                {
                    if(TheVehiclesDataSet.vehicles[0].Available == "NO")
                    {
                        TheMessagesClass.InformationMessage("Vehicle Is Signed Out, Please Sign In Vehicle");
                        return;
                    }
                    else
                    {
                        strAvailable = "NO";
                        strVehicleNotes = "VEHICLE SIGNED OUT";
                        TheInspectionsClass.CreateVehicleSignedOutEntry(intBJCNumber, "YES");
                    }
                }
                if(chkSignOut.Checked == false)
                {
                    if (TheVehiclesDataSet.vehicles[0].Available == "YES")
                    {
                        TheMessagesClass.InformationMessage("VEHICLE IS ALREADY SIGNED IN");
                        return;
                    }
                    else
                    {
                        strAvailable = "YES";
                        strVehicleNotes = "VEHICLE SIGNED IN";
                    }
                }
                if(chkLocalVehicle.Checked == true)
                {
                    strRemoteVehicle = "NO";
                }
                else
                {
                    strRemoteVehicle = "YES";
                }

                blnFatalError = TheVehicleClass.UpdateVehicleSignInByVehicleID(intVehicleID, intEmployeeCounter, datTransactionDate, strAvailable);

                if(blnFatalError == true)
                {
                    TheMessagesClass.ErrorMessage("There Has Been a Problem, Contact IT");
                    return;
                }
                else
                {
                    TheVehicleHistoryClass.CreateVehicleHistoryTransaction(intVehicleID, intBJCNumber, intEmployeeID, Logon.TheVerifyLogonDataSet.VerifyLogon[0].EmployeeID, strVehicleNotes, strRemoteVehicle);
                    TheVehicleClass.UpdateVehicleEmployeeID(intBJCNumber, intEmployeeID);
                }

                

                txtEnterBJCNumber.Text = "";
                txtEnterLastName.Text = "";
                cboSelectEmployee.Items.Clear();
                chkLocalVehicle.Checked = true;
                chkSignOut.Checked = true;

                TheMessagesClass.InformationMessage("The Vehicle Has Been Signed Out");
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Sign Out Vehicle Process Button " + Ex.Message);

                TheMessagesClass.ErrorMessage(Ex.ToString());
            }
        }
    }
}
