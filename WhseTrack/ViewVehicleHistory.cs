/* Title:           View Vehicle History
 * Date:            10-13-16
 * Author:          Terry Holmes
 * 
 * Description:     This form is used to view the vehicle history */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VehicleHistoryDLL;
using VehiclesDLL;
using NewEmployeeDLL;
using NewEventLogDLL;
using DataValidationDLL;
using DateSearchDLL;

namespace WhseTrack
{
    public partial class ViewVehicleHistory : Form
    {
        //setting up the classes
        MessagesClass TheMessagesClass = new MessagesClass();
        VehicleHistoryClass TheVehicleHistoryClass = new VehicleHistoryClass();
        VehicleClass TheVehicleClass = new VehicleClass();
        EmployeeClass TheEmployeeClass = new EmployeeClass();
        PleaseWait PleaseWait = new PleaseWait();
        EventLogClass TheEventLogClass = new EventLogClass();
        DateSearchClass TheDateSearchClass = new DateSearchClass();
        DataValidationClass TheDataValidationClass = new DataValidationClass();

        //setting up the data
        FindEmployeeByEmployeeIDDataSet TheFindEmployeeByEmployeeID = new FindEmployeeByEmployeeIDDataSet();
        VehiclesDataSet TheVehiclesDataSet;
        VehicleHistoryDataSet TheVehicleHistoryDataSet;
        VehicleHistoryDataSet TheSearchedHistoryDataSet = new VehicleHistoryDataSet();
        SearchResultsDataSet TheSearchResultsDataSet = new SearchResultsDataSet();

        //setting global variables
        string gstrErrorMessage;
        int gintEmployeeNumberOfRecords;
        int gintVehicleNumberOfRecords;
        
        public ViewVehicleHistory()
        {
            InitializeComponent();
        }

        private void btnVehicleMenu_Click(object sender, EventArgs e)
        {
            VehicleMenu VehicleMenu = new VehicleMenu();
            VehicleMenu.Show();
            this.Close();
        }

        private void btnMainMenuj_Click(object sender, EventArgs e)
        {
            MainMenu MainMenu = new MainMenu();
            MainMenu.Show();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //this will close the applicaiton
            TheMessagesClass.CloseTheProgram();
        }

        private void ViewVehicleHistory_Load(object sender, EventArgs e)
        {
            //setting local variables
            bool blnFatalError = false;

            PleaseWait.Show();

            //loading the data sets
            blnFatalError = LoadVehicleDataSet();
            if (blnFatalError == false)
                blnFatalError = LoadHistoryDataSet();

            PleaseWait.Hide();

            btnPrintReport.Enabled = false;
            dgvSearchResults.Visible = false;
            
            //Message To User
            if(blnFatalError == true)
            {
                TheMessagesClass.ErrorMessage(gstrErrorMessage);
            }
        }
        private bool LoadHistoryDataSet()
        {
            //setting local variables
            bool blnFatalError = false;
            int intCounter;
            int intNumberOfRecords;
            DateTime datTransactionDate;
            bool blnDateIsNull;

            try
            {
                //getting the vehicle history loaded
                TheVehicleHistoryDataSet = TheVehicleHistoryClass.GetVehicleHistoryInfo();

                //getting ready for the loop
                intNumberOfRecords = TheVehicleHistoryDataSet.vehiclehistory.Rows.Count - 1;
                
                //performing the loop
                for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    blnDateIsNull = TheVehicleHistoryDataSet.vehiclehistory[intCounter].IsDateNull();

                    if(blnDateIsNull == true)
                    {
                        datTransactionDate = TheDateSearchClass.RemoveTime(TheVehicleHistoryDataSet.vehiclehistory[intCounter - 1].Date);
                    }
                    else
                    {
                        datTransactionDate = TheDateSearchClass.RemoveTime(TheVehicleHistoryDataSet.vehiclehistory[intCounter].Date);
                    }
                    

                    if(Logon.gdatStartDate <= datTransactionDate)
                        if(Logon.gdatEndDate >= datTransactionDate)
                        {
                            //loading records into new table
                            VehicleHistoryDataSet.vehiclehistoryRow NewTableRow = TheSearchedHistoryDataSet.vehiclehistory.NewvehiclehistoryRow();

                            //filling the fields
                            NewTableRow.BJCNumber = TheVehicleHistoryDataSet.vehiclehistory[intCounter].BJCNumber;


                            NewTableRow.Date = datTransactionDate;
                            NewTableRow.EmployeeID = TheVehicleHistoryDataSet.vehiclehistory[intCounter].EmployeeID;
                            NewTableRow.Notes = TheVehicleHistoryDataSet.vehiclehistory[intCounter].Notes;
                            NewTableRow.RemoteVehicle = TheVehicleHistoryDataSet.vehiclehistory[intCounter].RemoteVehicle;
                            NewTableRow.TransactionID = TheVehicleHistoryDataSet.vehiclehistory[intCounter].TransactionID;
                            NewTableRow.VehicleID = TheVehicleHistoryDataSet.vehiclehistory[intCounter].VehicleID;
                            NewTableRow.WarehouseEmployeeID = TheVehicleHistoryDataSet.vehiclehistory[intCounter].WarehouseEmployeeID;

                            //adding the row to the table
                            TheSearchedHistoryDataSet.vehiclehistory.Rows.Add(NewTableRow);
                        }
                }
            }
            catch (Exception Ex)
            {
                //message to user
                gstrErrorMessage = Ex.ToString();

                //log entry
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "View Vehicle History Load History Data Set " + Ex.Message);

                blnFatalError = true;
            }

            //returning value
            return blnFatalError;
        }
        private bool LoadVehicleDataSet()
        {
            //setting local variables
            bool blnFatalError = false;

            try
            {
                //filling the data set
                TheVehiclesDataSet = TheVehicleClass.GetVehiclesInfo();

                //setting the records
                gintVehicleNumberOfRecords = TheVehiclesDataSet.vehicles.Rows.Count - 1;
            }
            catch (Exception Ex)
            {
                //message to user
                gstrErrorMessage = Ex.ToString();

                //log entry
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "View Vehicle History Load Vehicle Data Set " + Ex.Message);

                blnFatalError = true;
            }

            //returning value
            return blnFatalError;
        }
        
        private void btnFindVehicle_Click(object sender, EventArgs e)
        {
            //setting local variables
            int intVehicleCounter = 0;
            int intHistoryCounter = 0;
            int intEmployeeCounter = 0;
            int intHistoryUpperLimit;
            bool blnFatalError = false;
            string strValueForValidation;
            int intBJCNumber;
            int intVehicleID;
            int intEmployeeID;

            try
            {
                //Data Validation
                strValueForValidation = txtEnterBJCNumber.Text;
                blnFatalError = TheDataValidationClass.VerifyIntegerData(strValueForValidation);
                if (blnFatalError == true)
                {
                    TheMessagesClass.ErrorMessage("The BJC Number Entered is not an Integer");
                    return;
                }
                else
                {
                    intBJCNumber = Convert.ToInt32(strValueForValidation);
                }

                //getting ready for the loop
                intHistoryUpperLimit = TheSearchedHistoryDataSet.vehiclehistory.Rows.Count - 1;

                TheSearchResultsDataSet.searchresults.Rows.Clear();

                //vehicle loop
                for (intVehicleCounter = 0; intVehicleCounter <= gintVehicleNumberOfRecords; intVehicleCounter++)
                {
                    if (intBJCNumber == TheVehiclesDataSet.vehicles[intVehicleCounter].BJCNumber)
                    {
                        //getting the vehicle id
                        intVehicleID = TheVehiclesDataSet.vehicles[intVehicleCounter].VehicleID;

                        //beginning history counter
                        for (intHistoryCounter = 0; intHistoryCounter <= intHistoryUpperLimit; intHistoryCounter++)
                        {
                            if (intVehicleID == TheSearchedHistoryDataSet.vehiclehistory[intHistoryCounter].VehicleID)
                            {
                                intEmployeeID = TheSearchedHistoryDataSet.vehiclehistory[intHistoryCounter].EmployeeID;

                                //employee loop
                                TheFindEmployeeByEmployeeID = TheEmployeeClass.FindEmployeeByEmployeeID(intEmployeeCounter);
                                        
                                //creating new row
                                SearchResultsDataSet.searchresultsRow NewTableRow = TheSearchResultsDataSet.searchresults.NewsearchresultsRow();

                                //filling the fields
                                NewTableRow.BJCNumber = TheSearchedHistoryDataSet.vehiclehistory[intHistoryCounter].BJCNumber;
                                NewTableRow.Date = TheSearchedHistoryDataSet.vehiclehistory[intHistoryCounter].Date;
                                NewTableRow.FirstName = TheFindEmployeeByEmployeeID.FindEmployeeByEmployeeID[intEmployeeCounter].FirstName;
                                NewTableRow.LastName = TheFindEmployeeByEmployeeID.FindEmployeeByEmployeeID[intEmployeeCounter].LastName;
                                NewTableRow.Make = TheVehiclesDataSet.vehicles[intVehicleCounter].Make;
                                NewTableRow.Model = TheVehiclesDataSet.vehicles[intVehicleCounter].Model;
                                NewTableRow.TransasctionID = TheSearchedHistoryDataSet.vehiclehistory[intHistoryCounter].TransactionID;
                                NewTableRow.Year = Convert.ToInt32(TheVehiclesDataSet.vehicles[intVehicleCounter].Year);
                                NewTableRow.Transaction = TheSearchedHistoryDataSet.vehiclehistory[intVehicleCounter].Notes;

                                //adding the row
                                TheSearchResultsDataSet.searchresults.Rows.Add(NewTableRow);
                                   
                            }
                        }
                    }
                }

                dgvSearchResults.Visible = true;
                dgvSearchResults.DataSource = TheSearchResultsDataSet.searchresults;
            }
            catch (Exception ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track View Vehicle History Find Vehicle Button " + ex.Message);

                TheMessagesClass.ErrorMessage(ex.ToString());
            }

            
        }
    }
}
