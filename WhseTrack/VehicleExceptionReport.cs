/* Title:           Vehicle Exception Report
 * Date:            2-9-17
 * Author:          Terry Holmes
 * 
 * Description:     This form is used to create the vehicle exception report */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DateSearchDLL;
using InspectionsDLL;
using KeyWordDLL;
using NewEventLogDLL;
using NewEmployeeDLL;
using VehiclesDLL;
using DataValidationDLL;
using VehicleHistoryDLL;

namespace WhseTrack
{
    public partial class VehicleExceptionReport : Form
    {
        //setting up the classes
        MessagesClass TheMessagesClass = new MessagesClass();
        DateSearchClass TheDateSearchClass = new DateSearchClass();
        InspectionsClass TheInspectionsClass = new InspectionsClass();
        KeyWordClass TheKeyWordClass = new KeyWordClass();
        EventLogClass TheEventLogClass = new EventLogClass();
        EmployeeClass TheEmployeeClass = new EmployeeClass();
        VehicleClass TheVehicleClass = new VehicleClass();
        PleaseWait PleaseWait = new PleaseWait();
        DataValidationClass TheDataValidationClass = new DataValidationClass();
        VehicleHistoryClass TheVehicleHistoryClass = new VehicleHistoryClass();

        //setting up the data
        VehicleDailyInspectionDataSet TheVehicleDailyInspectionDataSet;
        VehicleInventorySheetDataSet TheVehicleInventorySheetDataSet;
        VehicleSignedOutDataSet TheVehicleSignedOutDataSet;
        VehiclesDataSet TheVehiclesDataSet;
        VehicleExceptionDataSet TheVehicleExceptionDataSet = new VehicleExceptionDataSet();
        VehicleHistoryDataSet TheVehicleHistoryDataSet = new VehicleHistoryDataSet();
        FindEmployeeByEmployeeIDDataSet TheFindEmployeeByEmployeeID = new FindEmployeeByEmployeeIDDataSet();
        VehicleExceptionDataSet TheViolatorsDataSet = new VehicleExceptionDataSet();
        VehicleInYardDataSet TheVehicleInYardDataSet;
                
        DateTime gdatStartDate;
        DateTime gdatEndDate;
        string gstrErrorMessage;
        int gintVehicleNumberOfRecords;
        int gintSignedOutNumberOfRecords;
        int gintInspectionNumberOfRecords;
        int gintDOTNumberOfRecords;
        int gintHistoryNumberOfRecords;
        int gintExceptionNumberOfRecords;
        int gintYardNumberOfRecords;
        int gintNewPrintCounter;
        int gintViolaterUpperLimit;

        public VehicleExceptionReport()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            TheMessagesClass.CloseTheProgram();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            MainMenu MainMenu = new MainMenu();
            MainMenu.Show();
            this.Close();
        }

        private void btnReportMenu_Click(object sender, EventArgs e)
        {
            ReportMenu ReportMenu = new ReportMenu();
            ReportMenu.Show();
            this.Close();
        }

        private void btnVehicleReports_Click(object sender, EventArgs e)
        {
            VehicleReportMenu VehicleReportMenu = new VehicleReportMenu();
            VehicleReportMenu.Show();
            this.Close();
        }

        private void VehicleExceptionReport_Load(object sender, EventArgs e)
        {
            //setting local variables
            bool blnFatalError = false;

            PleaseWait.Show();

            blnFatalError = LoadVehicleDataSet();
            if (blnFatalError == false)
                blnFatalError = LoadVehiclesSignedOut();
            if (blnFatalError == false)
                blnFatalError = LoadInspectionsDB();
            if (blnFatalError == false)
                blnFatalError = LoadDOTForms();
            if (blnFatalError == false)
                blnFatalError = LoadVehicleHistory();
            if (blnFatalError == false)
                blnFatalError = LoadInYard();

            dgvVehicleExceptions.DataSource = TheVehicleExceptionDataSet.exceptions;

            PleaseWait.Hide();

            if(blnFatalError == true)
            {
                TheMessagesClass.ErrorMessage(gstrErrorMessage);
            }
        }
        private bool LoadInYard()
        {
            bool blnFatalError = false;

            try
            {
                TheVehicleInYardDataSet = TheInspectionsClass.GetVehiclesInYardInfo();

                gintYardNumberOfRecords = TheVehicleInYardDataSet.vehicleinyard.Rows.Count - 1;
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Vehicle Exception Report Load In Yard " + Ex.Message);

                gstrErrorMessage = Ex.ToString();

                blnFatalError = true;
            }

            return blnFatalError;
        }
        private bool LoadVehicleHistory()
        {
            //setting local variable
            bool blnFatalError = false;

            try
            {
                TheVehicleHistoryDataSet = TheVehicleHistoryClass.GetVehicleHistoryInfo();

                gintHistoryNumberOfRecords = TheVehicleHistoryDataSet.vehiclehistory.Rows.Count - 1;
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Vehicle Exception Report Load Vehicle History " + Ex.Message);
            }

            return blnFatalError;
        }
        private bool LoadDOTForms()
        {
            //setting local varibles
            bool blnFatalError = false;

            try
            {
                TheVehicleDailyInspectionDataSet = TheInspectionsClass.GetDailyVehicleInspectionInfo();

                gintDOTNumberOfRecords = TheVehicleDailyInspectionDataSet.VehicleDailyInspection.Rows.Count - 1;
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Vehicle Exception Report Load DOT Form " + Ex.Message);

                gstrErrorMessage = Ex.ToString();

                blnFatalError = true;
            }

            return blnFatalError;
        }
        private bool LoadInspectionsDB()
        {
            bool blnFatalError = false;

            try
            {
                //loading the data set
                TheVehicleInventorySheetDataSet = TheInspectionsClass.GetVehicleInventorySheetInfo();

                gintInspectionNumberOfRecords = TheVehicleInventorySheetDataSet.vehicleinventorysheet.Rows.Count - 1;
            }
            catch (Exception Ex)
            {
                gstrErrorMessage = Ex.ToString();

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Vehicle Exception Report Load Inspections DB " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        private bool LoadVehiclesSignedOut()
        {
            bool blnFatalError = false;

            try
            {
                //loading the data set
                TheVehicleSignedOutDataSet = TheInspectionsClass.GetVehicleSignedOutInfo();

                gintSignedOutNumberOfRecords = TheVehicleSignedOutDataSet.vehiclesignedout.Rows.Count - 1;
            }
            catch (Exception Ex)
            {
                gstrErrorMessage = Ex.ToString();

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Vehicle Exception Report Load Vehicle Signed Out " + Ex.Message);

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
                TheVehiclesDataSet = TheVehicleClass.GetVehiclesInfo();

                gintVehicleNumberOfRecords = TheVehiclesDataSet.vehicles.Rows.Count - 1;
            }
            catch (Exception Ex)
            {
                gstrErrorMessage = Ex.ToString();

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Vehicle Exception Report Load Vehicle Data Set " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }

        private void btnFindVehicles_Click(object sender, EventArgs e)
        {
            //setting local variables
            string strValueForValidation;
            bool blnFatalError = false;
            bool blnThereIsAProblem = false;
            string strErrorMessage = "";
            DateTime datTransactionDate = DateTime.Now;
            int intVehicleCounter;
            string strDOTFormRequired = ""; 
            
            try
            {
                //beginning data validation
                TheVehicleExceptionDataSet.exceptions.Rows.Clear();
                strValueForValidation = txtStartDate.Text;
                blnFatalError = TheDataValidationClass.VerifyDateData(strValueForValidation);
                if(blnFatalError == true)
                {
                    blnThereIsAProblem = true;
                    strErrorMessage = strErrorMessage + "The Start Date Is Not a Date\n";
                }
                else
                {
                    gdatStartDate = Convert.ToDateTime(strValueForValidation);
                }
                strValueForValidation = txtEndDate.Text;
                blnFatalError = TheDataValidationClass.VerifyDateData(strValueForValidation);
                if (blnFatalError == true)
                {
                    blnThereIsAProblem = true;
                    strErrorMessage = strErrorMessage + "The End Date Is Not a Date\n";
                }
                else
                {
                    gdatEndDate = Convert.ToDateTime(strValueForValidation);
                }
                if(blnThereIsAProblem == true)
                {
                    TheMessagesClass.ErrorMessage(strErrorMessage);
                    return;
                }
                else
                {
                    blnFatalError = TheDataValidationClass.verifyDateRange(gdatStartDate, gdatEndDate);

                    if(blnFatalError == true)
                    {
                        TheMessagesClass.ErrorMessage("The Start Date is after the End Date");
                        return;
                    }
                }

                PleaseWait.Show();

                datTransactionDate = gdatStartDate;

                while(datTransactionDate <= gdatEndDate)
                {
                    for(intVehicleCounter = 0; intVehicleCounter <= gintVehicleNumberOfRecords; intVehicleCounter++)
                    {
                        if(TheVehiclesDataSet.vehicles[intVehicleCounter].Active == "YES")
                        {
                            if(TheVehiclesDataSet.vehicles[intVehicleCounter].DOTFormRequired == "YES")
                            {
                                strDOTFormRequired = "NO";
                            }
                            else
                            {
                                strDOTFormRequired = "N/A";
                            }
                            //creating new row
                            VehicleExceptionDataSet.exceptionsRow NewExceptionRow = TheVehicleExceptionDataSet.exceptions.NewexceptionsRow();

                            NewExceptionRow.BJCNumber = TheVehiclesDataSet.vehicles[intVehicleCounter].BJCNumber;
                            NewExceptionRow.DOTForm = strDOTFormRequired;
                            NewExceptionRow.DOTRequired = TheVehiclesDataSet.vehicles[intVehicleCounter].DOTFormRequired;
                            NewExceptionRow.Office = TheVehiclesDataSet.vehicles[intVehicleCounter].HomeOffice;
                            NewExceptionRow.FirstName = "NOT ENTERED";
                            NewExceptionRow.Inspection = "NO";
                            NewExceptionRow.LastName = "NOT ENTERED";
                            NewExceptionRow.SignedOut = "NO";
                            NewExceptionRow.InYard = "NO";
                            NewExceptionRow.Odometer = 0;
                            NewExceptionRow.TransactionDate = datTransactionDate;
                            NewExceptionRow.VehicleID = TheVehiclesDataSet.vehicles[intVehicleCounter].VehicleID;

                            //adding the row
                            TheVehicleExceptionDataSet.exceptions.Rows.Add(NewExceptionRow);
                        }
                    }

                    datTransactionDate = TheDateSearchClass.AddingDays(datTransactionDate, 1);
                }

                gintExceptionNumberOfRecords = TheVehicleExceptionDataSet.exceptions.Rows.Count - 1;

                CheckSignOut();
                CheckDOTFrom();
                CheckInspection();
                CheckInYard();
                CreateReport();
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Vehicle Exception Report Find Vehicles Button " + Ex.Message);

                TheMessagesClass.ErrorMessage(Ex.ToString());
            }

            PleaseWait.Hide();
          
        }
        private void CreateReport()
        {
            int intCounter;
            bool blnCreateRecord;

            TheViolatorsDataSet.exceptions.Rows.Clear();

            //beginning loop
            for(intCounter = 0; intCounter <= gintExceptionNumberOfRecords; intCounter++)
            {
                blnCreateRecord = true;

                if(TheVehicleExceptionDataSet.exceptions[intCounter].InYard == "YES")
                {
                    blnCreateRecord = false;
                }
                else
                {
                    if(TheVehicleExceptionDataSet.exceptions[intCounter].Inspection == "YES")
                    {
                        if(TheVehicleExceptionDataSet.exceptions[intCounter].SignedOut == "YES")
                        {
                            if(TheVehicleExceptionDataSet.exceptions[intCounter].DOTRequired == "YES")
                            {
                                if(TheVehicleExceptionDataSet.exceptions[intCounter].DOTForm == "YES")
                                {
                                    blnCreateRecord = false;
                                }
                            }
                            else
                            {
                                blnCreateRecord = false;
                            }
                        }
                    }
                }

                if(blnCreateRecord == true)
                {
                    VehicleExceptionDataSet.exceptionsRow NewExceptionRow = TheViolatorsDataSet.exceptions.NewexceptionsRow();

                    NewExceptionRow.BJCNumber = TheVehicleExceptionDataSet.exceptions[intCounter].BJCNumber;
                    NewExceptionRow.DOTForm = TheVehicleExceptionDataSet.exceptions[intCounter].DOTForm;
                    NewExceptionRow.DOTRequired = TheVehicleExceptionDataSet.exceptions[intCounter].DOTRequired;
                    NewExceptionRow.FirstName = TheVehicleExceptionDataSet.exceptions[intCounter].FirstName;
                    NewExceptionRow.Inspection = TheVehicleExceptionDataSet.exceptions[intCounter].Inspection;
                    NewExceptionRow.Office = TheVehicleExceptionDataSet.exceptions[intCounter].Office;
                    NewExceptionRow.InYard = TheVehicleExceptionDataSet.exceptions[intCounter].InYard;
                    NewExceptionRow.LastName = TheVehicleExceptionDataSet.exceptions[intCounter].LastName;
                    NewExceptionRow.Odometer = TheVehicleExceptionDataSet.exceptions[intCounter].Odometer;
                    NewExceptionRow.SignedOut = TheVehicleExceptionDataSet.exceptions[intCounter].SignedOut;
                    NewExceptionRow.TransactionDate = TheVehicleExceptionDataSet.exceptions[intCounter].TransactionDate;
                    NewExceptionRow.VehicleID = TheVehicleExceptionDataSet.exceptions[intCounter].VehicleID;

                    TheViolatorsDataSet.exceptions.Rows.Add(NewExceptionRow);
                }
            }

            dgvVehicleExceptions.DataSource = TheViolatorsDataSet.exceptions;
        }
        private void CheckInYard()
        {
            int intExceptionCounter;
            int intYardCounter;
            int intBJCNumber;
            DateTime datTransactionDate;

            try
            {
                for (intExceptionCounter = 0; intExceptionCounter <= gintExceptionNumberOfRecords; intExceptionCounter++)
                {
                    intBJCNumber = TheVehicleExceptionDataSet.exceptions[intExceptionCounter].BJCNumber;
                    datTransactionDate = TheVehicleExceptionDataSet.exceptions[intExceptionCounter].TransactionDate;

                    for (intYardCounter = 0; intYardCounter < gintYardNumberOfRecords; intYardCounter++)
                    {
                        if (datTransactionDate == TheDateSearchClass.RemoveTime(TheVehicleInYardDataSet.vehicleinyard[intYardCounter].Date))
                        {
                            if (intBJCNumber == TheVehicleInYardDataSet.vehicleinyard[intYardCounter].BJCNumber)
                            {
                                TheVehicleExceptionDataSet.exceptions[intExceptionCounter].InYard = "YES";
                            }
                        }
                    }
                }
            }
            catch (Exception EX)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Vehicle Exception Report Check In Yard " + EX.Message);

                TheMessagesClass.ErrorMessage(EX.ToString());
            }
            

        }
        private void CheckInspection()
        {
            int intInspectionCounter;
            int intBJCNumber;
            int intExceptionCounter;
            DateTime datTransactionDate;

            for(intExceptionCounter = 0; intExceptionCounter <= gintExceptionNumberOfRecords; intExceptionCounter++)
            {
                intBJCNumber = TheVehicleExceptionDataSet.exceptions[intExceptionCounter].BJCNumber;
                datTransactionDate = TheVehicleExceptionDataSet.exceptions[intExceptionCounter].TransactionDate;

                for(intInspectionCounter = 0; intInspectionCounter <= gintInspectionNumberOfRecords; intInspectionCounter++)
                {
                    if (datTransactionDate == TheDateSearchClass.RemoveTime(TheVehicleInventorySheetDataSet.vehicleinventorysheet[intInspectionCounter].Date))
                    {
                        if(intBJCNumber == TheVehicleInventorySheetDataSet.vehicleinventorysheet[intInspectionCounter].BJCNumber)
                        {
                            TheVehicleExceptionDataSet.exceptions[intExceptionCounter].Inspection = "YES";
                            TheVehicleExceptionDataSet.exceptions[intExceptionCounter].Odometer = TheVehicleInventorySheetDataSet.vehicleinventorysheet[intInspectionCounter].OdometerReading;
                        }
                    }
                }
            }
        }
        private void CheckDOTFrom()
        {
            //setting local variables
            int intDOTCounter;
            int intBJCNumber;
            int intExceptionCounter;
            DateTime datTransactionDate;

            for(intExceptionCounter = 0; intExceptionCounter <= gintExceptionNumberOfRecords; intExceptionCounter++)
            {
                intBJCNumber = TheVehicleExceptionDataSet.exceptions[intExceptionCounter].BJCNumber;
                datTransactionDate = TheVehicleExceptionDataSet.exceptions[intExceptionCounter].TransactionDate;

                for (intDOTCounter = 0; intDOTCounter <= gintDOTNumberOfRecords; intDOTCounter++)
                {
                    if (datTransactionDate == TheDateSearchClass.RemoveTime(TheVehicleDailyInspectionDataSet.VehicleDailyInspection[intDOTCounter].Date))
                    {
                        if(intBJCNumber == TheVehicleDailyInspectionDataSet.VehicleDailyInspection[intDOTCounter].BJCNumber)
                        {
                            TheVehicleExceptionDataSet.exceptions[intExceptionCounter].DOTForm = "YES";
                        }
                    }
                }
            }
        }
        private void CheckSignOut()
        {
            int intSignOutCounter;
            int intHistoryCounter;
            int intExceptionCounter;
            int intVehicleID;
            int intBJCNumber;
            DateTime datTransactionDate;

            //Exception Loop
            for(intExceptionCounter = 0; intExceptionCounter <= gintExceptionNumberOfRecords; intExceptionCounter++)
            {
                intVehicleID = TheVehicleExceptionDataSet.exceptions[intExceptionCounter].VehicleID;
                datTransactionDate = TheVehicleExceptionDataSet.exceptions[intExceptionCounter].TransactionDate;
                intBJCNumber = TheVehicleExceptionDataSet.exceptions[intExceptionCounter].BJCNumber;

                //sign out loop
                for(intSignOutCounter = 0; intSignOutCounter <= gintSignedOutNumberOfRecords; intSignOutCounter++)
                {
                    if(datTransactionDate == TheDateSearchClass.RemoveTime(TheVehicleSignedOutDataSet.vehiclesignedout[intSignOutCounter].Date))
                    {
                        if(intBJCNumber == TheVehicleSignedOutDataSet.vehiclesignedout[intSignOutCounter].BJCNumber)
                        {
                            TheVehicleExceptionDataSet.exceptions[intExceptionCounter].SignedOut = "YES";

                            //history counter
                            for(intHistoryCounter = 0; intHistoryCounter <= gintHistoryNumberOfRecords; intHistoryCounter++)
                            {
                                if(datTransactionDate == TheDateSearchClass.RemoveTime(TheVehicleHistoryDataSet.vehiclehistory[intHistoryCounter].Date))
                                {
                                    if(intVehicleID == TheVehicleHistoryDataSet.vehiclehistory[intHistoryCounter].VehicleID)
                                    {
                                        if(TheVehicleHistoryDataSet.vehiclehistory[intHistoryCounter].Notes == "VEHICLE SIGNED OUT")
                                        {
                                            TheFindEmployeeByEmployeeID = TheEmployeeClass.FindEmployeeByEmployeeID(TheVehicleHistoryDataSet.vehiclehistory[intHistoryCounter].EmployeeID);

                                            TheVehicleExceptionDataSet.exceptions[intExceptionCounter].FirstName = TheFindEmployeeByEmployeeID.FindEmployeeByEmployeeID[0].FirstName;
                                            TheVehicleExceptionDataSet.exceptions[intExceptionCounter].LastName = TheFindEmployeeByEmployeeID.FindEmployeeByEmployeeID[0].LastName;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    
                    printDocument1.PrinterSettings = printDialog1.PrinterSettings;
                    printDocument1.DefaultPageSettings.Landscape = true;

                    gintNewPrintCounter = 0;
                    gintViolaterUpperLimit = TheViolatorsDataSet.exceptions.Rows.Count - 1;

                    printDocument1.Print();

                }
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Vehicle Exception Report Print Report " + Ex.Message);

                TheMessagesClass.ErrorMessage(Ex.ToString());
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int intCounter;
            Font PrintHeaderFont = new Font("Arial", 14, FontStyle.Bold);
            Font PrintItemFont = new Font("Arial", 10, FontStyle.Regular);
            float PrintX = e.MarginBounds.Left;
            float PrintY = e.MarginBounds.Top;
            float HeadingLineHeight = PrintHeaderFont.GetHeight() + 18;
            int intStartingPageCounter;
            bool blnNewPage = false;
            float fltHeadingLineHeight = PrintHeaderFont.GetHeight() + 10;
            float fltItemLineHeight = PrintItemFont.GetHeight() + 5;
            string strDescription;
            int intStringLength;


            PrintX = 375;
            PrintY = 100;
            intStartingPageCounter = gintNewPrintCounter;


            //setting up the header
            e.Graphics.DrawString("Blue Jay Vehicle Exception Report", PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            PrintY = PrintY + fltHeadingLineHeight + 5;
            PrintX = 275;
            e.Graphics.DrawString("Between " + Convert.ToString(gdatStartDate) + " And " + Convert.ToString(gdatEndDate), PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            PrintY = PrintY + fltHeadingLineHeight + 10;

            PrintX = 50;
            e.Graphics.DrawString("BJC Number", PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            PrintX = 200;
            e.Graphics.DrawString("Odometer", PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            PrintX = 350;
            e.Graphics.DrawString("Home Office", PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            PrintX = 525;
            e.Graphics.DrawString("Signed Out", PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            PrintX = 675;
            e.Graphics.DrawString("Inspected", PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            PrintX = 825;
            e.Graphics.DrawString("DOT Form", PrintHeaderFont, Brushes.Black, PrintX, PrintY);

            PrintY = PrintY + fltHeadingLineHeight + 10;

            for (intCounter = intStartingPageCounter; intCounter <= gintViolaterUpperLimit; intCounter++)
            {
                PrintX = 50;
                e.Graphics.DrawString(Convert.ToString(TheViolatorsDataSet.exceptions[intCounter].BJCNumber), PrintItemFont, Brushes.Black, PrintX, PrintY);
                PrintX = 200;
                e.Graphics.DrawString(Convert.ToString(TheViolatorsDataSet.exceptions[intCounter].Odometer), PrintItemFont, Brushes.Black, PrintX, PrintY);
                PrintX = 350;
                e.Graphics.DrawString(TheViolatorsDataSet.exceptions[intCounter].Office, PrintItemFont, Brushes.Black, PrintX, PrintY);
                PrintX = 525;
                e.Graphics.DrawString(TheViolatorsDataSet.exceptions[intCounter].SignedOut, PrintItemFont, Brushes.Black, PrintX, PrintY);
                PrintX = 675;
                e.Graphics.DrawString(TheViolatorsDataSet.exceptions[intCounter].Inspection, PrintItemFont, Brushes.Black, PrintX, PrintY);
                PrintX = 825;
                e.Graphics.DrawString(TheViolatorsDataSet.exceptions[intCounter].DOTForm, PrintItemFont, Brushes.Black, PrintX, PrintY);

                PrintY = PrintY + fltItemLineHeight + 5;

                if (PrintY >= 800)
                {
                    if (intStartingPageCounter == gintViolaterUpperLimit)
                    {
                        e.HasMorePages = false;
                    }
                    else
                    {
                        e.HasMorePages = true;
                        blnNewPage = true;
                    }

                    if (blnNewPage == true)
                    {
                        gintNewPrintCounter = intCounter + 1;
                        intCounter = gintViolaterUpperLimit;
                    }
                }

            }
        }
    }
}
