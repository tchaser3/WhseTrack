/* Title:           Vehicles In Yard
 * Date:            3-16-17
 * Author:          Terry Holmes
 * 
 * Description:     This is the form to run the vehicles in the yard report*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewEventLogDLL;
using VehiclesDLL;
using InspectionsDLL;
using DataValidationDLL;
using DateSearchDLL;

namespace WhseTrack
{
    public partial class VehiclesInYardReport : Form
    {
        //setting up the classes
        MessagesClass TheMessagesClass = new MessagesClass();
        EventLogClass TheEventLogClass = new EventLogClass();
        VehicleClass TheVehicleClass = new VehicleClass();
        InspectionsClass TheInspectionsClass = new InspectionsClass();
        DataValidationClass TheDataValidationClass = new DataValidationClass();
        DateSearchClass TheDateSearchClass = new DateSearchClass();

        //setting up the data
        VehicleInYardDataSet TheVehiclesInYardDataSet = new VehicleInYardDataSet();
        VehiclesDataSet TheVehiclesDataSet = new VehiclesDataSet();
        YardReportDataSet TheYardReportDataSet = new YardReportDataSet();

        int gintNewPrintCounter;

        public VehiclesInYardReport()
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
            Close();
        }

        private void btnReportsMenu_Click(object sender, EventArgs e)
        {
            ReportMenu ReportMenu = new ReportMenu();
            ReportMenu.Show();
            Close();
        }

        private void btnVehicleReports_Click(object sender, EventArgs e)
        {
            VehicleReportMenu VehicleReportMenu = new VehicleReportMenu();
            VehicleReportMenu.Show();
            Close();
        }

        private void VehiclesInYardReport_Load(object sender, EventArgs e)
        {
            dgrResults.DataSource = TheYardReportDataSet.inyard;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            //this will find the vehicles
            //setting local variables
            string strValueForValidation;
            bool blnFatalError = false;
            DateTime datStartDate;
            DateTime datEndDate;
            int intNumberOfRecords;
            int intCounter;
            int intBJCNumber;
            int intRecordsReturned;

            try
            {
                TheVehiclesInYardDataSet.vehicleinyard.Rows.Clear();
                TheYardReportDataSet.inyard.Rows.Clear();

                strValueForValidation = txtEnterDate.Text;
                blnFatalError = TheDataValidationClass.VerifyDateData(strValueForValidation);
                if(blnFatalError == true)
                {
                    TheMessagesClass.ErrorMessage("The Data In is not a Date");
                    return;
                }
                else
                {
                    datStartDate = Convert.ToDateTime(strValueForValidation);
                }

                //setting up the check
                datStartDate = TheDateSearchClass.RemoveTime(datStartDate);
                datEndDate = TheDateSearchClass.AddingDays(datStartDate, 1);

                TheVehiclesInYardDataSet = TheInspectionsClass.FindVehiclesInYardByDate(datStartDate, datStartDate);

                intNumberOfRecords = TheVehiclesInYardDataSet.vehicleinyard.Rows.Count;

                if(intNumberOfRecords == 0)
                {
                    TheMessagesClass.InformationMessage("No Vehices Were Found");
                }
                else
                {
                    //for loop
                    for(intCounter = 0; intCounter < intNumberOfRecords; intCounter++)
                    {
                        intBJCNumber = TheVehiclesInYardDataSet.vehicleinyard[intCounter].BJCNumber;

                        TheVehiclesDataSet = TheVehicleClass.GetActiveVehicleByBJCNumber(intBJCNumber);

                        intRecordsReturned = TheVehiclesDataSet.vehicles.Rows.Count;

                        if (intRecordsReturned > 0)
                        {

                            YardReportDataSet.inyardRow NewTableRow = TheYardReportDataSet.inyard.NewinyardRow();

                            NewTableRow.BJCNumber = intBJCNumber;
                            NewTableRow.Description = TheVehiclesDataSet.vehicles[0].Model;
                            NewTableRow.HomeOffice = TheVehiclesDataSet.vehicles[0].HomeOffice;
                            NewTableRow.TransactionDate = TheVehiclesInYardDataSet.vehicleinyard[intCounter].Date;
                            NewTableRow.TransactionID = TheVehiclesInYardDataSet.vehicleinyard[intCounter].TransactionID;

                            TheYardReportDataSet.inyard.Rows.Add(NewTableRow);
                        }
                    }
                }


                dgrResults.DataSource = TheYardReportDataSet.inyard;
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Vehicles In Yard Report Find Button " + Ex.Message);

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
            int intNumberOfRecords;
            
            PrintX = 275;
            PrintY = 100;
            intStartingPageCounter = gintNewPrintCounter;


            //setting up the header
            e.Graphics.DrawString("Blue Jay Vehicles In Yard Report", PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            PrintY = PrintY + fltHeadingLineHeight + 5;
            
            PrintX = 50;
            e.Graphics.DrawString("BJC Number", PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            PrintX = 200;
            e.Graphics.DrawString("Model", PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            PrintX = 400;
            e.Graphics.DrawString("Home Office", PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            PrintX = 600;
            e.Graphics.DrawString("Date", PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            PrintY = PrintY + fltHeadingLineHeight + 10;

            intNumberOfRecords = TheYardReportDataSet.inyard.Rows.Count - 1;

            for (intCounter = intStartingPageCounter; intCounter <= intNumberOfRecords; intCounter++)
            {
                PrintX = 50;
                e.Graphics.DrawString(Convert.ToString(TheYardReportDataSet.inyard[intCounter].BJCNumber), PrintItemFont, Brushes.Black, PrintX, PrintY);
                PrintX = 200;
                e.Graphics.DrawString(TheYardReportDataSet.inyard[intCounter].Description, PrintItemFont, Brushes.Black, PrintX, PrintY);
                PrintX = 400;
                e.Graphics.DrawString(TheYardReportDataSet.inyard[intCounter].HomeOffice, PrintItemFont, Brushes.Black, PrintX, PrintY);
                PrintX = 600;
                e.Graphics.DrawString(Convert.ToString(TheYardReportDataSet.inyard[intCounter].TransactionDate), PrintItemFont, Brushes.Black, PrintX, PrintY);
                
                PrintY = PrintY + fltItemLineHeight + 5;

                if (PrintY >= 800)
                {
                    if (intStartingPageCounter == intNumberOfRecords)
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
                        intCounter = intNumberOfRecords;
                    }
                }

            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {

                printDocument1.PrinterSettings = printDialog1.PrinterSettings;

                gintNewPrintCounter = 0;
                
                printDocument1.Print();

            }
        }
    }
}
