/* Title:           Logon
 * Date:            4-25-16
 * Author:          Terry Holmes
 *
 * Description:     This is where the user log on */

using System;

using System.Windows.Forms;
using AutoSignInDLL;
using NewEmployeeDLL;
using NewEventLogDLL;
using LastTransactionDLL;
using VehicleHistoryDLL;
using VehiclesDLL;
using DataValidationDLL;

namespace WhseTrack
{
    public partial class Logon : Form
    {
        //setting up the classes
        MessagesClass TheMessagesClass = new MessagesClass();
        AutoSignInClass TheAutoSignInClass = new AutoSignInClass();
        EmployeeClass TheEmployeeClass = new EmployeeClass();
        EventLogClass TheEventLogClass = new EventLogClass();
        LastTransactionClass TheLastTransactionClass = new LastTransactionClass();
        PleaseWait PleaseWait = new PleaseWait();
        VehicleClass TheVehicleClass = new VehicleClass();
        VehicleHistoryClass TheVehicleHistoryClass = new VehicleHistoryClass();
        DataValidationClass TheDataValidationClass = new DataValidationClass();

        //setting the global variables
        public static int gintEmployeeID;
        public static DateTime gdatStartDate;
        public static DateTime gdatEndDate;
        public static string gstrMenuSelector;
        public static string gstrPartNumber;
        public static int gintInternalProjectID;
        public static string gstrTWCProjectID;
        public static string gstrMSRNumber;

        public static PartSelectDataSet ThePartSelectionDataSet = new PartSelectDataSet();
        public static InventoryEnteredDataSet TheInventoryEnteredDataSet = new InventoryEnteredDataSet();
        public static VerifyLogonDataSet TheVerifyLogonDataSet = new VerifyLogonDataSet();
        public static FindPartsWarehousesDataSet TheFindPartsWarehouseDataSet = new FindPartsWarehousesDataSet();
        public static FindWarehousesDataSet TheFindWarehousesDataSet = new FindWarehousesDataSet();

        public static int gintWarehouseID;
        public static string gstrWarehouseName;

        //other global variables
        int gintNumberOfMisses;
        
        public Logon()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //this will close the program
            TheMessagesClass.CloseTheProgram();
        }

        private void btnLogon_Click(object sender, EventArgs e)
        {
            //setting local variables
            string strValueForValidation;
            string strErrorMessage = "";
            bool blnFatalError = false;
            bool blnThereIsAProblem = false;
            string strLastName;
            int intEmployeeID = 0;
            int intRecordsReturned;

            //loading up variables
            strValueForValidation = txtEmployeeID.Text;
            strLastName = txtLogonLastName.Text;
            blnFatalError = TheDataValidationClass.VerifyIntegerData(strValueForValidation);
            if(blnFatalError == true)
            {
                blnThereIsAProblem = true;
                strErrorMessage = strErrorMessage + "The Employee ID Is not an Integer\n";
            }
            else
            {
                intEmployeeID = Convert.ToInt32(strValueForValidation);
            }
            blnFatalError = TheDataValidationClass.VerifyTextData(strLastName);
            if (blnFatalError == true)
            {
                blnThereIsAProblem = true;
                strErrorMessage = strErrorMessage + "The Last Name Was Not Entered\n";
            }
            if(blnThereIsAProblem == true)
            {
                TheMessagesClass.ErrorMessage(strErrorMessage);
                return;
            }

            TheVerifyLogonDataSet = TheEmployeeClass.VerifyLogon(intEmployeeID, strLastName);

            intRecordsReturned = TheVerifyLogonDataSet.VerifyLogon.Rows.Count;

            if(intRecordsReturned == 0)
            {
                LogonFailed();
            }
            else
            {
                MainMenu MainMenu = new MainMenu();
                MainMenu.Show();
                Hide();
            }
        }
        private void LogonFailed()
        {
            if(gintNumberOfMisses == 3)
            {
                //message to user
                TheMessagesClass.ErrorMessage("There Have Been Three Attempts to Log On\nThe Application Will Be Closed");

                //Event Log Entry
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "There Have Been Three Attemps to Log On To WhseTrac, The Application Was Closed");

                Application.Exit();
            }
            if(gintNumberOfMisses < 3)
            {
                //message to user
                TheMessagesClass.InformationMessage("The Log On Information Is Incorrect\nTry Again");

                //incrementing the number of misses
                gintNumberOfMisses++;
                return;
            }
        }
        private void Logon_Load(object sender, EventArgs e)
        {
            //setting local variables
            bool blnFatalError = false;

            PleaseWait.Show();

            //auto signing all vehicles
            blnFatalError = TheAutoSignInClass.AutoSignInProcess();
            if (blnFatalError == false)
                blnFatalError = LoadWarehouseDataSet();

            gintNumberOfMisses = 1;

            PleaseWait.Hide();
            
            if(blnFatalError == true)
            {
                TheMessagesClass.ErrorMessage("There Has Been a Problem, Please Contact IT");
            }
        }
        private bool LoadWarehouseDataSet()
        {
            //creating local variables
            bool blnFatalError = false;

            try
            {
                TheFindPartsWarehouseDataSet = TheEmployeeClass.FindPartsWarehouses();

                TheFindWarehousesDataSet = TheEmployeeClass.FindWarehouses();
            }
            catch (Exception Ex)
            {
                //event log entry
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Logon Load Warehouse Data Set " + Ex.Message);

                //setting boolean variable
                blnFatalError = true;
            }

            //returning value to calling sub routine
            return blnFatalError;
        }
    }
}
