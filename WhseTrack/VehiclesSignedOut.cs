/* Title:           Vehicles Signed Out
 * Date:            3-5-17
 * Author:          Terry Holmes
 * 
 * Description:     This form is used to print a vehicle report */

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
using DateSearchDLL;
using DataValidationDLL;
using KeyWordDLL;

namespace WhseTrack
{
    public partial class VehiclesSignedOut : Form
    {
        //setting up the classes
        MessagesClass TheMessagesClass = new MessagesClass();
        VehicleHistoryClass TheVehicleHistoryClass = new VehicleHistoryClass();
        VehicleClass TheVehicleClass = new VehicleClass();
        EmployeeClass TheEmployeeClass = new EmployeeClass();
        EventLogClass TheEventLogClass = new EventLogClass();
        DateSearchClass TheDateSearchClass = new DateSearchClass();
        DataValidationClass TheDataValidationClass = new DataValidationClass();
        KeyWordClass TheKeyWordClass = new KeyWordClass();

        //setting up the data sets
        VehicleHistoryDataSet TheSearchedHistoryDataSet = new VehicleHistoryDataSet();
        FindEmployeeByEmployeeIDDataSet TheFindEmployeeByEmployeeIDDataSet = new FindEmployeeByEmployeeIDDataSet();
        VehiclesSignedOutDataSet TheVehiclesSignedOutDataSet = new VehiclesSignedOutDataSet();

        //setting up global variables
        int gintNewPrintCounter;
        int gintUpperLimit;
        
        public VehiclesSignedOut()
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
            Close();
        }

        private void VehiclesSignedOut_Load(object sender, EventArgs e)
        {

        }

        private void btnFindDate_Click(object sender, EventArgs e)
        {
            //setting local variables
            string strValueForValidation;
            bool blnFatalError = false;
            DateTime datTransactionDate;
            int intHistoryCounter;
            int intHistoryNumberOfRecords;
            bool blnKeyWordNotFound = true;
            
            try
            {
                TheVehiclesSignedOutDataSet.vehiclesout.Rows.Clear();

                strValueForValidation = txtEnterDate.Text;
                blnFatalError = TheDataValidationClass.VerifyDateData(strValueForValidation);
                if(blnFatalError == true)
                {
                    TheMessagesClass.ErrorMessage("The Value Entered is not a Date");
                    return;
                }
                else
                {
                    datTransactionDate = Convert.ToDateTime(strValueForValidation);
                }

                TheSearchedHistoryDataSet = TheVehicleHistoryClass.FindVehicleHistoryByDate(datTransactionDate);

                //getting the record values
                intHistoryNumberOfRecords = TheSearchedHistoryDataSet.vehiclehistory.Rows.Count - 1;

                if(intHistoryNumberOfRecords == -1)
                {
                    TheMessagesClass.InformationMessage("No Transactions Were Found");
                    return;
                }
                else
                {
                    //getting ready for the loop
                    datTransactionDate = TheDateSearchClass.RemoveTime(datTransactionDate);

                    for (intHistoryCounter = 0; intHistoryCounter <= intHistoryNumberOfRecords; intHistoryCounter++)
                    {
                        if(datTransactionDate == TheDateSearchClass.RemoveTime(TheSearchedHistoryDataSet.vehiclehistory[intHistoryCounter].Date))
                        {
                            blnKeyWordNotFound = TheKeyWordClass.FindKeyWord("SIGNED OUT", TheSearchedHistoryDataSet.vehiclehistory[intHistoryCounter].Notes);

                            if(blnKeyWordNotFound == false)
                            {
                                //creating the row
                                VehiclesSignedOutDataSet.vehiclesoutRow NewReportRow = TheVehiclesSignedOutDataSet.vehiclesout.NewvehiclesoutRow();

                                TheFindEmployeeByEmployeeIDDataSet = TheEmployeeClass.FindEmployeeByEmployeeID(TheSearchedHistoryDataSet.vehiclehistory[intHistoryCounter].EmployeeID);

                                NewReportRow.BJCNumber = TheSearchedHistoryDataSet.vehiclehistory[intHistoryCounter].BJCNumber;
                                NewReportRow.FirstName = TheFindEmployeeByEmployeeIDDataSet.FindEmployeeByEmployeeID[0].FirstName;
                                NewReportRow.LastName = TheFindEmployeeByEmployeeIDDataSet.FindEmployeeByEmployeeID[0].LastName;
                                NewReportRow.TransactionDate = TheSearchedHistoryDataSet.vehiclehistory[intHistoryCounter].Date;

                                TheVehiclesSignedOutDataSet.vehiclesout.Rows.Add(NewReportRow);
                            }
                        }
                    }
                }

                dgvVehicles.DataSource = TheVehiclesSignedOutDataSet.vehiclesout;
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Vehicles Signed Out Find Date " + Ex.Message);

                TheMessagesClass.ErrorMessage(Ex.ToString());
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.PrinterSettings = printDialog1.PrinterSettings;
                gintNewPrintCounter = 0;
                gintUpperLimit = TheVehiclesSignedOutDataSet.vehiclesout.Rows.Count - 1;

                printDocument1.Print();

            }
        }
        
        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
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
            

            PrintX = 200;
            PrintY = 100;
            intStartingPageCounter = gintNewPrintCounter;


            //setting up the header
            e.Graphics.DrawString("Blue Jay Communications Vehicle Report", PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            PrintY = PrintY + fltHeadingLineHeight + 10;

            PrintX = 50;
            e.Graphics.DrawString("BJC Number", PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            PrintX = 200;
            e.Graphics.DrawString("First Name", PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            PrintX = 400;
            e.Graphics.DrawString("Last Name", PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            PrintX = 600;
            e.Graphics.DrawString("Date", PrintHeaderFont, Brushes.Black, PrintX, PrintY);

            PrintY = PrintY + fltHeadingLineHeight + 10;

            for (intCounter = intStartingPageCounter; intCounter <= gintUpperLimit; intCounter++)
            {
                PrintX = 50;
                e.Graphics.DrawString(Convert.ToString(TheVehiclesSignedOutDataSet.vehiclesout[intCounter].BJCNumber), PrintItemFont, Brushes.Black, PrintX, PrintY);
                PrintX = 200;
                e.Graphics.DrawString(TheVehiclesSignedOutDataSet.vehiclesout[intCounter].FirstName, PrintItemFont, Brushes.Black, PrintX, PrintY);
                PrintX = 400;
                e.Graphics.DrawString(TheVehiclesSignedOutDataSet.vehiclesout[intCounter].LastName, PrintItemFont, Brushes.Black, PrintX, PrintY);
                PrintX = 600;
                e.Graphics.DrawString(Convert.ToString(TheVehiclesSignedOutDataSet.vehiclesout[intCounter].TransactionDate), PrintItemFont, Brushes.Black, PrintX, PrintY);
                PrintY = PrintY + fltItemLineHeight + 5;

                if (PrintY >= 1000)
                {
                    if (intStartingPageCounter == gintUpperLimit)
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
                        intCounter = gintUpperLimit;
                    }
                }

            }
        }
    }
}
