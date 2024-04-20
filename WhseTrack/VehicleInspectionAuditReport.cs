/* Title:           Vehicle Inspection Audit Report
 * Date:            10-16-16
 * Author:          Terry Holmes
 * 
 * Description:     This form is used to generate a report regarding vehicle audits */

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
using NewEventLogDLL;
using InspectionsDLL;
using DateSearchDLL;
using DataValidationDLL;
using CSVFileDLL;

namespace WhseTrack
{
    public partial class VehicleInspectionAuditReport : Form
    {
        //setting up the classes
        MessagesClass TheMessagesClass = new MessagesClass();
        VehicleHistoryClass TheVehicleHistoryClass = new VehicleHistoryClass();
        VehicleClass TheVehicleClass = new VehicleClass();
        EventLogClass TheEventLogClass = new EventLogClass();
        InspectionsClass TheInspectionClass = new InspectionsClass();
        PleaseWait PleaseWait = new PleaseWait();
        DateSearchClass TheDateSearchClass = new DateSearchClass();
        DataValidationClass TheDataValidationClass = new DataValidationClass();
        
        //setting up the data
        VehiclesDataSet TheVehicleDataSet;
        VehicleHistoryDataSet TheVehicleHistoryDataSet;
        VehicleHistoryDataSet TheSortedVehicleHistoryDataSet = new VehicleHistoryDataSet();
        VehicleDailyInspectionDataSet TheVehicleDailyInspectionDataSet;
        VehicleDailyInspectionDataSet TheSortedVehicleDailyInspectionDataSet = new VehicleDailyInspectionDataSet();
        VehicleInventorySheetDataSet TheVehicleInventorySheetDataSet;
        VehicleInventorySheetDataSet TheSortedVehicleInventorySheetDataSet = new VehicleInventorySheetDataSet();
        VehicleSignedOutDataSet TheVehicleSignedOutDataSet;
        VehicleSignedOutDataSet TheSortedVehicleSignedOutDataSet = new VehicleSignedOutDataSet();
        WeeklyVehicleInspectionsDataSet TheWeeklyVehicleInspectionsDataSet;
        WeeklyVehicleInspectionsDataSet TheSortedWeeklyVehicleInspectionDataSet = new WeeklyVehicleInspectionsDataSet();
        VehicleAuditDataSet TheVehicleAuditDataSet = new VehicleAuditDataSet();

        //setting global variables
        string gstrErrorMessage;
        int gintVehicleNumberOfRecords;
        int gintHistoryUpperLimit;
        int gintDailyInspectionUpperLimit;
        int gintInventoryUpperLimit;
        int gintEmployeeNumberOfRecords;
        int gintSignedOutUpperLimit;
        int gintWeeklyUpperLimit;
        DateTime gdatStartDate;
        DateTime gdatEndDate;
        
        public VehicleInspectionAuditReport()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //this will close the application
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

        private void VehicleInspectionAuditReport_Load(object sender, EventArgs e)
        {
            //this is the form load event
            //setting local variables
            bool blnFatalError = false;

            PleaseWait.Show();

            //loading the global date variables
            gdatEndDate = Logon.gdatEndDate;
            gdatStartDate = Logon.gdatStartDate;

            //loading the data sets
            blnFatalError = LoadVehicleDataSet();
            if (blnFatalError == false)
                blnFatalError = LoadVehicleHistoryDataSet();
            if (blnFatalError == false)
                blnFatalError = LoadDOTForms();
            if (blnFatalError == false)
                blnFatalError = LoadInventoryDataSet();
            if (blnFatalError == false)
                blnFatalError = LoadSignInDataSet();
            if (blnFatalError == false)
                blnFatalError = LoadWeeklyInspectionsDataSet();

            PleaseWait.Hide();

            if(blnFatalError == true)
            {
                TheMessagesClass.ErrorMessage(gstrErrorMessage);
            }
        }
        private bool LoadWeeklyInspectionsDataSet()
        {
            bool blnFatalError = false;
            int intCounter;
            int intNumberOfRecords;
            bool blnFieldIsNull;
            DateTime datTransactionDate;
            string strNotes;

            try
            {
                //loading the data set
                TheWeeklyVehicleInspectionsDataSet = TheInspectionClass.GetWeeklyVehicleInspectionsInfo();

                //getting the number of records
                intNumberOfRecords = TheWeeklyVehicleInspectionsDataSet.WeeklyVehicleInspections.Rows.Count - 1;

                //loop
                for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    blnFieldIsNull = TheWeeklyVehicleInspectionsDataSet.WeeklyVehicleInspections[intCounter].IsInspectionDateNull();

                    if(blnFieldIsNull == true)
                    {
                        datTransactionDate = TheDateSearchClass.RemoveTime(TheWeeklyVehicleInspectionsDataSet.WeeklyVehicleInspections[intCounter - 1].InspectionDate);
                    }
                    else
                    {
                        datTransactionDate = TheDateSearchClass.RemoveTime(TheWeeklyVehicleInspectionsDataSet.WeeklyVehicleInspections[intCounter].InspectionDate);
                    }
                    blnFieldIsNull = TheWeeklyVehicleInspectionsDataSet.WeeklyVehicleInspections[intCounter].IsInspectionNotesNull();
                    if(blnFieldIsNull == true)
                    {
                        strNotes = "NO NOTES ENTERED";
                    }
                    else
                    {
                        strNotes = TheWeeklyVehicleInspectionsDataSet.WeeklyVehicleInspections[intCounter].InspectionNotes;
                    }
                    
                    if(datTransactionDate >= gdatStartDate)
                        if(datTransactionDate <= gdatEndDate)
                        {
                            //setting up the row
                            WeeklyVehicleInspectionsDataSet.WeeklyVehicleInspectionsRow NewTableRow = TheSortedWeeklyVehicleInspectionDataSet.WeeklyVehicleInspections.NewWeeklyVehicleInspectionsRow();

                            //loading the fields
                            NewTableRow.BJCNumber = TheWeeklyVehicleInspectionsDataSet.WeeklyVehicleInspections[intCounter].BJCNumber;
                            NewTableRow.CurrentOdometer = TheWeeklyVehicleInspectionsDataSet.WeeklyVehicleInspections[intCounter].CurrentOdometer;
                            NewTableRow.EmployeeID = TheWeeklyVehicleInspectionsDataSet.WeeklyVehicleInspections[intCounter].EmployeeID;
                            NewTableRow.InspectionDate = datTransactionDate;
                            NewTableRow.InspectionID = TheWeeklyVehicleInspectionsDataSet.WeeklyVehicleInspections[intCounter].InspectionID;
                            NewTableRow.InspectionNotes = strNotes;
                            NewTableRow.NextOilChangeOdometer = TheWeeklyVehicleInspectionsDataSet.WeeklyVehicleInspections[intCounter].NextOilChangeOdometer;
                            NewTableRow.PPEInspected = TheWeeklyVehicleInspectionsDataSet.WeeklyVehicleInspections[intCounter].PPEInspected;
                            NewTableRow.ToolsInspected = TheWeeklyVehicleInspectionsDataSet.WeeklyVehicleInspections[intCounter].ToolsInspected;
                            NewTableRow.VehicleCleanliness = TheWeeklyVehicleInspectionsDataSet.WeeklyVehicleInspections[intCounter].VehicleCleanliness;
                            NewTableRow.VehicleID = TheWeeklyVehicleInspectionsDataSet.WeeklyVehicleInspections[intCounter].VehicleID;
                            NewTableRow.VehicleServiceability = TheWeeklyVehicleInspectionsDataSet.WeeklyVehicleInspections[intCounter].VehicleServiceability;

                            //adding the row
                            TheSortedWeeklyVehicleInspectionDataSet.WeeklyVehicleInspections.Rows.Add(NewTableRow);
                        }
                }

                gintWeeklyUpperLimit = TheSortedWeeklyVehicleInspectionDataSet.WeeklyVehicleInspections.Rows.Count - 1;
            }
            catch (Exception Ex)
            {
                //message to user
                gstrErrorMessage = Ex.ToString();

                //event log entry
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vehicle Inspection Audit Report Load Weekly Inspections Data Set " + Ex.Message);
                //setting the variable
                blnFatalError = true;
            }

            return blnFatalError;
        }
        private bool LoadSignInDataSet()
        {
            bool blnFatalError = false;
            int intCounter;
            int intNumberOfRecords;
            bool blnFieldIsNull;
            DateTime datTransactionDate;

            try
            {
                //loading the data set
                TheVehicleSignedOutDataSet = TheInspectionClass.GetVehicleSignedOutInfo();

                //getting the number of records
                intNumberOfRecords = TheVehicleSignedOutDataSet.vehiclesignedout.Rows.Count - 1;

                //loop
                for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    blnFieldIsNull = TheVehicleSignedOutDataSet.vehiclesignedout[intCounter].IsDateNull();
                    if(blnFieldIsNull == true)
                    {
                        datTransactionDate = TheDateSearchClass.RemoveTime(TheVehicleSignedOutDataSet.vehiclesignedout[intCounter - 1].Date);
                    }
                    else
                    {
                        datTransactionDate = TheDateSearchClass.RemoveTime(TheVehicleSignedOutDataSet.vehiclesignedout[intCounter].Date);
                    }

                    if(datTransactionDate >= gdatStartDate)
                        if(datTransactionDate <= gdatEndDate)
                        {
                            //new row
                            VehicleSignedOutDataSet.vehiclesignedoutRow NewTableRow = TheSortedVehicleSignedOutDataSet.vehiclesignedout.NewvehiclesignedoutRow();

                            //filling the fields
                            NewTableRow.BJCNumber = TheVehicleSignedOutDataSet.vehiclesignedout[intCounter].BJCNumber;
                            NewTableRow.Date = datTransactionDate;
                            NewTableRow.TransactionID = TheVehicleSignedOutDataSet.vehiclesignedout[intCounter].TransactionID;
                            NewTableRow.VehicleSignedOut = TheVehicleSignedOutDataSet.vehiclesignedout[intCounter].VehicleSignedOut;

                            //adding the row
                            TheSortedVehicleSignedOutDataSet.vehiclesignedout.Rows.Add(NewTableRow);
                        }
                }

                gintSignedOutUpperLimit = TheSortedVehicleSignedOutDataSet.vehiclesignedout.Rows.Count - 1;
            }
            catch (Exception Ex)
            {
                //message to user
                gstrErrorMessage = Ex.ToString();

                //event log entry
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vehicle Inspection Audit Report Load Vehicle Signed Out Data Set " + Ex.Message);
                //setting the variable
                blnFatalError = true;
            }

            return blnFatalError;
        }
        private bool LoadInventoryDataSet()
        {
            bool blnFatalError = false;
            int intCounter;
            int intNumberOfRecords;
            bool blnFieldIsNull;
            DateTime datTransactionDate;
            string strNotes;
            int intOdometer;
            string strProblemCritical;
            string strProblemReported;
            string strWorkOrderCreated;

            try
            {
                //loading the data set
                TheVehicleInventorySheetDataSet = TheInspectionClass.GetVehicleInventorySheetInfo();

                //getting the number of records
                intNumberOfRecords = TheVehicleInventorySheetDataSet.vehicleinventorysheet.Rows.Count - 1;

                //running the loop
                for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    //checking null value
                    blnFieldIsNull = TheVehicleInventorySheetDataSet.vehicleinventorysheet[intCounter].IsDateNull();
                    if(blnFieldIsNull == true)
                    {
                        datTransactionDate = TheDateSearchClass.RemoveTime(TheVehicleInventorySheetDataSet.vehicleinventorysheet[intCounter - 1].Date);
                    }
                    else
                    {
                        datTransactionDate = TheDateSearchClass.RemoveTime(TheVehicleInventorySheetDataSet.vehicleinventorysheet[intCounter].Date);
                    }
                    blnFieldIsNull = TheVehicleInventorySheetDataSet.vehicleinventorysheet[intCounter].IsNotesNull();
                    if(blnFieldIsNull == true)
                    {
                        strNotes = "NO NOTES ENTERED";
                    }
                    else
                    {
                        strNotes = TheVehicleInventorySheetDataSet.vehicleinventorysheet[intCounter].Notes;
                    }
                    blnFieldIsNull = TheVehicleInventorySheetDataSet.vehicleinventorysheet[intCounter].IsOdometerReadingNull();
                    if(blnFieldIsNull == true)
                    {
                        intOdometer = 0;
                    }
                    else
                    {
                        intOdometer = TheVehicleInventorySheetDataSet.vehicleinventorysheet[intCounter].OdometerReading;
                    }
                    blnFieldIsNull = TheVehicleInventorySheetDataSet.vehicleinventorysheet[intCounter].IsProblemCriticalNull();
                    if(blnFieldIsNull == true)
                    {
                        strProblemCritical = "NO";
                    }
                    else
                    {
                        strProblemCritical = TheVehicleInventorySheetDataSet.vehicleinventorysheet[intCounter].ProblemCritical;
                    }
                    blnFatalError = TheVehicleInventorySheetDataSet.vehicleinventorysheet[intCounter].IsProblemReportedNull();
                    if(blnFatalError == true)
                    {
                        strProblemReported = "NO";
                    }
                    else
                    {
                        strProblemReported = TheVehicleInventorySheetDataSet.vehicleinventorysheet[intCounter].ProblemReported;
                    }
                    blnFieldIsNull = TheVehicleInventorySheetDataSet.vehicleinventorysheet[intCounter].IsWorkOrderCreatedNull();
                    if(blnFieldIsNull == true)
                    {
                        strWorkOrderCreated = "NO";
                    }
                    else
                    {
                        strWorkOrderCreated = TheVehicleInventorySheetDataSet.vehicleinventorysheet[intCounter].WorkOrderCreated;
                    }

                    if(datTransactionDate >= gdatStartDate)
                        if(datTransactionDate <= gdatEndDate)
                        {
                            //creating new row
                            VehicleInventorySheetDataSet.vehicleinventorysheetRow NewTableRow = TheSortedVehicleInventorySheetDataSet.vehicleinventorysheet.NewvehicleinventorysheetRow();

                            //filling the field
                            NewTableRow.BJCNumber = TheVehicleInventorySheetDataSet.vehicleinventorysheet[intCounter].BJCNumber;
                            NewTableRow.Date = datTransactionDate;
                            NewTableRow.InventorySheet = TheVehicleInventorySheetDataSet.vehicleinventorysheet[intCounter].InventorySheet;
                            NewTableRow.Notes = strNotes;
                            NewTableRow.OdometerReading = intOdometer;
                            NewTableRow.ProblemCritical = strProblemCritical;
                            NewTableRow.ProblemReported = strProblemReported;
                            NewTableRow.TransactionID = TheVehicleInventorySheetDataSet.vehicleinventorysheet[intCounter].TransactionID;
                            NewTableRow.WorkOrderCreated = strWorkOrderCreated;

                            //adding to the data set
                            TheSortedVehicleInventorySheetDataSet.vehicleinventorysheet.Rows.Add(NewTableRow);
                        }
                }

                gintInventoryUpperLimit = TheSortedVehicleInventorySheetDataSet.vehicleinventorysheet.Rows.Count - 1;
            }
            catch (Exception Ex)
            {
                //message to user
                gstrErrorMessage = Ex.ToString();

                //event log entry
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vehicle Inspection Audit Report Inventory Data Set " + Ex.Message);
                //setting the variable
                blnFatalError = true;
            }

            return blnFatalError;
        }
        private bool LoadDOTForms()
        {
            //setting local variables
            bool blnFatalError = false;
            int intCounter;
            int intNumberOfRecords;
            bool blnFieldIsNull;
            DateTime datTransactionDate;
            string strNotes;

            try
            {
                //loading the data set
                TheVehicleDailyInspectionDataSet = TheInspectionClass.GetDailyVehicleInspectionInfo();

                //getting the number of records
                intNumberOfRecords = TheVehicleDailyInspectionDataSet.VehicleDailyInspection.Rows.Count - 1;

                //running loop
                for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    //checking for null value
                    blnFieldIsNull = TheVehicleDailyInspectionDataSet.VehicleDailyInspection[intCounter].IsDateNull();
                    
                    if(blnFieldIsNull == true)
                    {
                        datTransactionDate = TheDateSearchClass.RemoveTime(TheVehicleDailyInspectionDataSet.VehicleDailyInspection[intCounter - 1].Date);
                    }
                    else
                    {
                        datTransactionDate = TheDateSearchClass.RemoveTime(TheVehicleDailyInspectionDataSet.VehicleDailyInspection[intCounter].Date);
                    }
                    blnFieldIsNull = TheVehicleDailyInspectionDataSet.VehicleDailyInspection[intCounter].IsNotesNull();
                    if(blnFieldIsNull == true)
                    {
                        strNotes = "NOTES WERE NOT ENTERED";
                    }
                    else
                    {
                        strNotes = TheVehicleDailyInspectionDataSet.VehicleDailyInspection[intCounter].Notes;
                    }
                    if (datTransactionDate >= gdatStartDate)
                        if (datTransactionDate <= gdatEndDate)
                        {
                            //creating the new row
                            VehicleDailyInspectionDataSet.VehicleDailyInspectionRow NewTableRow = TheSortedVehicleDailyInspectionDataSet.VehicleDailyInspection.NewVehicleDailyInspectionRow();

                            //filling the fields
                            NewTableRow.BJCNumber = TheVehicleDailyInspectionDataSet.VehicleDailyInspection[intCounter].BJCNumber;
                            NewTableRow.Date = datTransactionDate;
                            NewTableRow.DOTFormTurnedIn = TheVehicleDailyInspectionDataSet.VehicleDailyInspection[intCounter].DOTFormTurnedIn;
                            NewTableRow.EmployeeID = TheVehicleDailyInspectionDataSet.VehicleDailyInspection[intCounter].EmployeeID;
                            NewTableRow.InspectionID = TheVehicleDailyInspectionDataSet.VehicleDailyInspection[intCounter].InspectionID;
                            NewTableRow.Notes = strNotes;
                            NewTableRow.NumberOfHoursDriven = TheVehicleDailyInspectionDataSet.VehicleDailyInspection[intCounter].NumberOfHoursDriven;
                            NewTableRow.Odometer = TheVehicleDailyInspectionDataSet.VehicleDailyInspection[intCounter].Odometer;
                            NewTableRow.VehicleID = TheVehicleDailyInspectionDataSet.VehicleDailyInspection[intCounter].VehicleID;

                            //adding the row
                            TheSortedVehicleDailyInspectionDataSet.VehicleDailyInspection.Rows.Add(NewTableRow);
                        }
                }

                gintDailyInspectionUpperLimit = TheSortedVehicleDailyInspectionDataSet.VehicleDailyInspection.Rows.Count - 1;
            }
            catch (Exception Ex)
            {
                //message to user
                gstrErrorMessage = Ex.ToString();

                //event log entry
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vehicle Inspection Audit Report Load Vehicle Data Set " + Ex.Message);
                //setting the variable
                blnFatalError = true;
            }

            return blnFatalError;
        }
        private bool LoadVehicleHistoryDataSet()
        {
            //setting local variables
            bool blnFatalError = false;
            int intCounter;
            int intNumberOfRecords;
            string strRemoteVehicle = "";
            bool blnFieldIsNull = false;
            DateTime datTransactionDate;

            try
            {
                //loading the history data set
                TheVehicleHistoryDataSet = TheVehicleHistoryClass.GetVehicleHistoryInfo();

                //getting ready for the loop
                intNumberOfRecords = TheVehicleHistoryDataSet.vehiclehistory.Rows.Count - 1;

                //loop
                for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    //checking for null values
                    blnFieldIsNull = TheVehicleHistoryDataSet.vehiclehistory[intCounter].IsRemoteVehicleNull();
                    if(blnFieldIsNull == true)
                    {
                        strRemoteVehicle = "NO";
                    }
                    else
                    {
                        strRemoteVehicle = TheVehicleHistoryDataSet.vehiclehistory[intCounter].RemoteVehicle;
                    }
                    blnFieldIsNull = TheVehicleHistoryDataSet.vehiclehistory[intCounter].IsDateNull();
                    if(blnFieldIsNull == true)
                    {
                        datTransactionDate = TheDateSearchClass.RemoveTime(TheVehicleHistoryDataSet.vehiclehistory[intCounter - 1].Date);
                    }
                    else
                    {
                        datTransactionDate = TheDateSearchClass.RemoveTime(TheVehicleHistoryDataSet.vehiclehistory[intCounter].Date);
                    }

                    //if statements
                    if(datTransactionDate >= gdatStartDate)
                        if(datTransactionDate <= gdatEndDate)
                        {
                            //creating a new table row
                            VehicleHistoryDataSet.vehiclehistoryRow NewTableRow = TheSortedVehicleHistoryDataSet.vehiclehistory.NewvehiclehistoryRow();

                            //filling the fields
                            NewTableRow.BJCNumber = TheVehicleHistoryDataSet.vehiclehistory[intCounter].BJCNumber;
                            NewTableRow.Date = datTransactionDate;
                            NewTableRow.EmployeeID = TheVehicleHistoryDataSet.vehiclehistory[intCounter].EmployeeID;
                            NewTableRow.Notes = TheVehicleHistoryDataSet.vehiclehistory[intCounter].Notes;
                            NewTableRow.RemoteVehicle = strRemoteVehicle;
                            NewTableRow.TransactionID = TheVehicleHistoryDataSet.vehiclehistory[intCounter].TransactionID;
                            NewTableRow.VehicleID = TheVehicleHistoryDataSet.vehiclehistory[intCounter].VehicleID;
                            NewTableRow.WarehouseEmployeeID = TheVehicleHistoryDataSet.vehiclehistory[intCounter].WarehouseEmployeeID;

                            //adding the row
                            TheSortedVehicleHistoryDataSet.vehiclehistory.Rows.Add(NewTableRow);
                        }
                }

                gintHistoryUpperLimit = TheSortedVehicleHistoryDataSet.vehiclehistory.Rows.Count - 1;
            }
            catch (Exception Ex)
            {
                //message to user
                gstrErrorMessage = Ex.ToString();

                //event log entry
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vehicle Inspection Audit Report Load Vehicle History Data Set " + Ex.Message);

                //setting the variable
                blnFatalError = true;
            }

            return blnFatalError;
        }

        private bool LoadVehicleDataSet()
        {
            //setting local variables
            bool blnFatalError = false;

            try
            {
                //loading the data set
                TheVehicleDataSet = TheVehicleClass.GetVehiclesInfo();

                //getting the number of records;
                gintVehicleNumberOfRecords = TheVehicleDataSet.vehicles.Rows.Count - 1;
            }
            catch (Exception Ex)
            {
                //message to user
                gstrErrorMessage = Ex.ToString();

                //event log entry
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vehicle Inspection Audit Report Load Vehicle Data Set " + Ex.Message);
                //setting the variable
                blnFatalError = true;
            }

            return blnFatalError;
        }
        private void btnFindVehicle_Click(object sender, EventArgs e)
        {
            //setting local variables
            DateTime datSearchDate;
            int intHistoryCounter;
            int intDailyCounter;
            int intInventoryCounter;
            string strValueForValidation;
            bool blnFatalError = false;
            int intBJCNumber;
            bool blnItemNotFound = true;
            int intSignedOutCounter;
            int intWeeklyCounter;

            try
            {
                PleaseWait.Show();

                TheVehicleAuditDataSet.vehicleaudit.Rows.Clear();

                //getting the data
                strValueForValidation = txtEnterBJCNumber.Text;
                blnFatalError = TheDataValidationClass.VerifyIntegerData(strValueForValidation);
                if(blnFatalError == true)
                {
                    TheMessagesClass.ErrorMessage("The Value Entered was not an Integer");
                    return;
                }
                else
                {
                    intBJCNumber = Convert.ToInt32(strValueForValidation);
                }

                //setting the search date
                datSearchDate = gdatStartDate;

                while(datSearchDate <= gdatEndDate)
                {
                    //history counter
                    for(intHistoryCounter = 0; intHistoryCounter <= gintHistoryUpperLimit; intHistoryCounter++)
                    {
                        if(datSearchDate == TheSortedVehicleHistoryDataSet.vehiclehistory[intHistoryCounter].Date)
                        {
                           if(intBJCNumber == TheSortedVehicleHistoryDataSet.vehiclehistory[intHistoryCounter].BJCNumber)
                            {
                                //creating the row
                                VehicleAuditDataSet.vehicleauditRow NewTableRow = TheVehicleAuditDataSet.vehicleaudit.NewvehicleauditRow();

                                NewTableRow.BJCNumber = TheSortedVehicleHistoryDataSet.vehiclehistory[intHistoryCounter].BJCNumber;
                                NewTableRow.Date = TheSortedVehicleHistoryDataSet.vehiclehistory[intHistoryCounter].Date;
                                NewTableRow.Notes = TheSortedVehicleHistoryDataSet.vehiclehistory[intHistoryCounter].Notes;
                                NewTableRow.TransactionType = "VEHICLE HISTORY";

                                //updating the dataset
                                TheVehicleAuditDataSet.vehicleaudit.Rows.Add(NewTableRow);
                                blnItemNotFound = false;
                            }
                        }
                    }

                    for(intDailyCounter = 0; intDailyCounter <= gintDailyInspectionUpperLimit; intDailyCounter++)
                    {
                        if(datSearchDate == TheSortedVehicleDailyInspectionDataSet.VehicleDailyInspection[intDailyCounter].Date)
                        {
                            if(intBJCNumber == TheSortedVehicleDailyInspectionDataSet.VehicleDailyInspection[intDailyCounter].BJCNumber)
                            {
                                //creating the row
                                VehicleAuditDataSet.vehicleauditRow NewTableRow = TheVehicleAuditDataSet.vehicleaudit.NewvehicleauditRow();

                                NewTableRow.BJCNumber = TheSortedVehicleDailyInspectionDataSet.VehicleDailyInspection[intDailyCounter].BJCNumber;
                                NewTableRow.Date = TheSortedVehicleDailyInspectionDataSet.VehicleDailyInspection[intDailyCounter].Date;
                                NewTableRow.Notes = TheSortedVehicleDailyInspectionDataSet.VehicleDailyInspection[intDailyCounter].Notes;
                                NewTableRow.TransactionType = "DOT FORM";

                                //updating the dataset
                                TheVehicleAuditDataSet.vehicleaudit.Rows.Add(NewTableRow);
                                blnItemNotFound = false;
                            }
                        }
                        
                    }

                    for (intInventoryCounter = 0; intInventoryCounter <= gintInventoryUpperLimit; intInventoryCounter++)
                    {
                        if (datSearchDate == TheSortedVehicleInventorySheetDataSet.vehicleinventorysheet[intInventoryCounter].Date)
                        {
                            if (intBJCNumber == TheSortedVehicleInventorySheetDataSet.vehicleinventorysheet[intInventoryCounter].BJCNumber)
                            {
                                //creating the row
                                VehicleAuditDataSet.vehicleauditRow NewTableRow = TheVehicleAuditDataSet.vehicleaudit.NewvehicleauditRow();

                                NewTableRow.BJCNumber = TheSortedVehicleInventorySheetDataSet.vehicleinventorysheet[intInventoryCounter].BJCNumber;
                                NewTableRow.Date = datSearchDate;
                                NewTableRow.Notes = TheSortedVehicleInventorySheetDataSet.vehicleinventorysheet[intInventoryCounter].Notes;
                                NewTableRow.TransactionType = "DAILY INSPECTION";

                                //updating the dataset
                                TheVehicleAuditDataSet.vehicleaudit.Rows.Add(NewTableRow);
                                blnItemNotFound = false;
                            }
                        }
                    }

                    for(intSignedOutCounter = 0; intSignedOutCounter <= gintSignedOutUpperLimit; intSignedOutCounter++)
                    {
                        if(datSearchDate == TheSortedVehicleSignedOutDataSet.vehiclesignedout[intSignedOutCounter].Date)
                        {
                            if(intBJCNumber == TheSortedVehicleSignedOutDataSet.vehiclesignedout[intSignedOutCounter].BJCNumber)
                            {
                                //creating the row
                                VehicleAuditDataSet.vehicleauditRow NewTableRow = TheVehicleAuditDataSet.vehicleaudit.NewvehicleauditRow();

                                NewTableRow.BJCNumber = TheSortedVehicleSignedOutDataSet.vehiclesignedout[intSignedOutCounter].BJCNumber;
                                NewTableRow.Date = datSearchDate;
                                NewTableRow.Notes = TheSortedVehicleSignedOutDataSet.vehiclesignedout[intSignedOutCounter].VehicleSignedOut;
                                NewTableRow.TransactionType = "SIGNED OUT";

                                //updating the dataset
                                TheVehicleAuditDataSet.vehicleaudit.Rows.Add(NewTableRow);
                                blnItemNotFound = false;
                            }
                        }
                    }

                    for(intWeeklyCounter = 0; intWeeklyCounter <= gintWeeklyUpperLimit; intWeeklyCounter++)
                    {
                        if(datSearchDate == TheSortedWeeklyVehicleInspectionDataSet.WeeklyVehicleInspections[intWeeklyCounter].InspectionDate)
                        {
                            if(intBJCNumber == TheSortedWeeklyVehicleInspectionDataSet.WeeklyVehicleInspections[intWeeklyCounter].BJCNumber)
                            {
                                //creating the row
                                VehicleAuditDataSet.vehicleauditRow NewTableRow = TheVehicleAuditDataSet.vehicleaudit.NewvehicleauditRow();

                                NewTableRow.BJCNumber = TheSortedWeeklyVehicleInspectionDataSet.WeeklyVehicleInspections[intWeeklyCounter].BJCNumber;
                                NewTableRow.Date = datSearchDate;
                                NewTableRow.Notes = TheSortedWeeklyVehicleInspectionDataSet.WeeklyVehicleInspections[intWeeklyCounter].InspectionNotes;
                                NewTableRow.TransactionType = "WEEKLY INSPECTION";

                                //updating the dataset
                                TheVehicleAuditDataSet.vehicleaudit.Rows.Add(NewTableRow);
                                blnItemNotFound = false;
                            }
                        }
                    }

                    datSearchDate = TheDateSearchClass.AddingDays(datSearchDate, 1);
                }
                if(blnItemNotFound == true)
                {
                    TheMessagesClass.InformationMessage("The BJC Number was not Found");
                    return;
                }

                PleaseWait.Hide();

                dgvSearchResults.DataSource = TheVehicleAuditDataSet.vehicleaudit;
            }
            catch (Exception Ex)
            {
                //message to the user
                TheMessagesClass.ErrorMessage(Ex.ToString());

                //event log entry
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vehicle Inspection Audit Report Find Vehicle " + Ex.Message);
            }

        }

        private void btnCSVFile_Click(object sender, EventArgs e)
        {
            //setting local variables
            int intCounter;
            int intNumberOfRecords;
            string strTransactionID;
            string strBJCNumber;
            string strDate;
            string strTransactionType;
            string strNotes;

            try
            {
                SaveFileDialog file = new SaveFileDialog();
                file.ShowDialog();
                ReadWirteCSV.CsvFileWriter TheCSVFile = new ReadWirteCSV.CsvFileWriter(file.FileName + ".csv");

                //getting ready for the loop
                intNumberOfRecords = TheVehicleAuditDataSet.vehicleaudit.Rows.Count - 1;

                //running loop
                for (intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    strTransactionID = Convert.ToString(TheVehicleAuditDataSet.vehicleaudit[intCounter].TransactionID);
                    strBJCNumber = Convert.ToString(TheVehicleAuditDataSet.vehicleaudit[intCounter].BJCNumber);
                    strDate = Convert.ToString(TheVehicleAuditDataSet.vehicleaudit[intCounter].Date);
                    strTransactionType = TheVehicleAuditDataSet.vehicleaudit[intCounter].TransactionType;
                    strNotes = TheVehicleAuditDataSet.vehicleaudit[intCounter].Notes;

                    ReadWirteCSV.CsvRow NewCSVRow = new ReadWirteCSV.CsvRow();

                    NewCSVRow.Add(strTransactionID);
                    NewCSVRow.Add(strBJCNumber);
                    NewCSVRow.Add(strDate);
                    NewCSVRow.Add(strTransactionType);
                    NewCSVRow.Add(strNotes);

                    //writing the new row
                    TheCSVFile.WriteRow(NewCSVRow);
                }
            }
            catch(Exception Ex)
            {
                TheMessagesClass.ErrorMessage(Ex.ToString());

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vehicle Inspection Audit Report CSV File " + Ex.Message);
            }
            
        }
    }
}
