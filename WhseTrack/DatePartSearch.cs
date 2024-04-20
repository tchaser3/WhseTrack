/* Title:           Date Part Search
 * Date:            12-9-16
 * Author:          Terry Holmes
 * 
 * Description:     This will provide a report for Parts based on Dates */

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
using DataValidationDLL;
using NewEventLogDLL;
using InventoryDLL;
using PartNumberDLL;
using BOMPartsDLL;
using IssuedPartsDLL;
using ReceivedMaterialDLL;

namespace WhseTrack
{
    public partial class DatePartSearch : Form
    {
        //setting up the classes
        MessagesClass TheMessagesClass = new MessagesClass();
        DateSearchClass TheDateSearchClass = new DateSearchClass();
        DataValidationClass TheDataValidationClass = new DataValidationClass();
        EventLogClass TheEventLogClass = new EventLogClass();
        InventoryClass TheInventoryClass = new InventoryClass();
        PartNumberClass ThePartNumberClass = new PartNumberClass();
        BOMPartsClass TheBOMPartsClass = new BOMPartsClass();
        IssuedPartsClass TheIssuedPartsClass = new IssuedPartsClass();
        ReceivedMaterialClass TheReceivedMaterialClass = new ReceivedMaterialClass();
        PleaseWait PleaseWait = new PleaseWait();

        PartNumbersDataSet TheSortedPartNumbersDataSet = new PartNumbersDataSet();
        BOMPartsDataSet TheBOMPartsDataSet;
        ReceivedPartsDataSet TheReceivedPartsDataSet;
        IssuedPartsDataSet TheIssuedPartsDataSet;
        PartTransactionDataSet ThePartTransactionDataSet = new PartTransactionDataSet();

        //setting variables
        bool gblnPartNumberEntered;
        int gintPartID;
        string gstrPartNumber;
        string gstrDescription;
        int gintProjectCounter;
        int gintProjectUpperLimit;
        DateTime gdatStartDate;
        DateTime gdatEndDate;
        int gintNewPrintCounter;
        int gintUpperLimit;


        public DatePartSearch()
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

        private void btnInventoryReportMenu_Click(object sender, EventArgs e)
        {
            InventoryReports InventoryReports = new InventoryReports();
            InventoryReports.Show();
            this.Close();
        }

        private void DatePartSearch_Load(object sender, EventArgs e)
        {
            //setting local variables
            int intCounter;
            int intNumberOfRecords;

            //this will load the data
            try
            {
                intNumberOfRecords = Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses.Rows.Count - 1;
                cboWarehouse.Items.Add("Select Warehouse");
                    
                for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    cboWarehouse.Items.Add(Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses[intCounter].FirstName);
                }

                cboWarehouse.SelectedIndex = 0;
                cboWarehouse.Visible = false;
                txtEndDate.Visible = false;
                txtStartDate.Visible = false;
            }
            catch (Exception Ex)
            {
                TheMessagesClass.ErrorMessage(Ex.ToString());

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Date Part Search Form Load " + Ex.Message);
            }
        }

        private void txtEnterPartNumber_TextChanged(object sender, EventArgs e)
        {
            int intLength;
            string strPartNumber;

            strPartNumber = txtEnterPartNumber.Text;

            intLength = strPartNumber.Length;

            if(intLength >= 3)
            {
                strPartNumber = "%" + strPartNumber + "%";
                TheSortedPartNumbersDataSet = ThePartNumberClass.GetPartNumberByDescriptionKey(strPartNumber);
            }

            gblnPartNumberEntered = true;
            dgvInventory.DataSource = TheSortedPartNumbersDataSet.partnumbers;
        }

        private void dgvInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(gblnPartNumberEntered == true)
            {
                try
                {
                    if (e.RowIndex >= 0)
                    {
                        DataGridViewRow row = dgvInventory.Rows[e.RowIndex];

                        gintPartID = Convert.ToInt32(row.Cells["PartID"].Value.ToString());
                        gstrPartNumber = row.Cells["PartNumber"].Value.ToString();
                        gstrDescription = row.Cells["Description"].Value.ToString();

                        cboWarehouse.Visible = true;
                    }
                }
                catch (Exception Ex)
                {
                    TheMessagesClass.ErrorMessage(Ex.ToString());
                }
            }
        }

        private void cboWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            //setting local variables
            int intCounter;
            int intNumberOfRecords;
            int intWarehouseID = 0;

            if(cboWarehouse.Text != "Select Warehouse")
            {
                PleaseWait.Show();

                intNumberOfRecords = Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses.Rows.Count - 1;

                for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    if(cboWarehouse.Text == Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses[intCounter].FirstName)
                    {
                        intWarehouseID = Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses[intCounter].EmployeeID;
                        break;
                    }
                }

                TheBOMPartsDataSet = TheBOMPartsClass.GetBOMPartsByPartID(gintPartID, intWarehouseID);
                TheIssuedPartsDataSet = TheIssuedPartsClass.GetIssuedPartsByPartID(gintPartID, intWarehouseID);
                TheReceivedPartsDataSet = TheReceivedMaterialClass.GetReceivedPartsByPartID(gintPartID, intWarehouseID);

                txtEndDate.Visible = true;
                txtStartDate.Visible = true;

                PleaseWait.Hide();
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            //this will process the order
            //setting local variables
            string strValueForValidation;
            bool blnFatalError = false;
            bool blnThereIsAProblem = false;
            string strErrorMessage = "";

            ThePartTransactionDataSet.parttransactions.Rows.Clear();

            //performing Data validation
            strValueForValidation = txtStartDate.Text;
            blnFatalError = TheDataValidationClass.VerifyDateData(strValueForValidation);
            if(blnFatalError == true)
            {
                blnThereIsAProblem = true;
                strErrorMessage = "The Start Date is not a Date\n";
            }
            else
            {
                gdatStartDate = Convert.ToDateTime(strValueForValidation);
                gdatStartDate = TheDateSearchClass.RemoveTime(gdatStartDate);
            }
            strValueForValidation = txtEndDate.Text;
            blnFatalError = TheDataValidationClass.VerifyDateData(strValueForValidation);
            if (blnFatalError == true)
            {
                blnThereIsAProblem = true;
                strErrorMessage = "The End Date is not a Date\n";
            }
            else
            {
                gdatEndDate = Convert.ToDateTime(strValueForValidation);
                gdatEndDate = TheDateSearchClass.RemoveTime(gdatEndDate);
            }
            blnFatalError = TheDataValidationClass.verifyDateRange(gdatStartDate, gdatEndDate);
            if (blnFatalError == true)
            {
                blnThereIsAProblem = true;
                strErrorMessage = "The Start Date is Greater Than The End Date\n";
            }
            if(blnThereIsAProblem == true)
            {
                TheMessagesClass.ErrorMessage(strErrorMessage);
                return;
            }
            LoadReceivedParts();
            LoadIssueParts();
            LoadBOMParts();

            dgvInventory.DataSource = ThePartTransactionDataSet.parttransactions;
        }
        private void LoadBOMParts()
        {
            int intCounter;
            int intNumberOfRecords;

            try
            {
                intNumberOfRecords = TheBOMPartsDataSet.BOMParts.Rows.Count - 1;

                for (intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    if (TheBOMPartsDataSet.BOMParts[intCounter].IsDateNull() == false)
                    {
                        if (TheBOMPartsDataSet.BOMParts[intCounter].Date >= gdatStartDate)
                        {
                            if (TheBOMPartsDataSet.BOMParts[intCounter].Date <= gdatEndDate)
                            {
                                PartTransactionDataSet.parttransactionsRow NewTableRow = ThePartTransactionDataSet.parttransactions.NewparttransactionsRow();

                                NewTableRow.Date = TheDateSearchClass.RemoveTime(TheBOMPartsDataSet.BOMParts[intCounter].Date);
                                NewTableRow.ProjectID = TheBOMPartsDataSet.BOMParts[intCounter].ProjectID;
                                NewTableRow.QuantityIssued = 0;
                                NewTableRow.QuantityReceived = 0;
                                NewTableRow.QuantityReported = Convert.ToInt32(TheBOMPartsDataSet.BOMParts[intCounter].QTY);

                                ThePartTransactionDataSet.parttransactions.Rows.Add(NewTableRow);

                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Date Part Search Load Received Parts " + Ex.Message);

                TheMessagesClass.ErrorMessage(Ex.Message);
            }
        }
        private void LoadIssueParts()
        {
            int intCounter;
            int intNumberOfRecords;

            try
            {
                intNumberOfRecords = TheIssuedPartsDataSet.IssuedParts.Rows.Count - 1;

                for (intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    if (TheIssuedPartsDataSet.IssuedParts[intCounter].IsDateNull() == false)
                    {
                        if (TheIssuedPartsDataSet.IssuedParts[intCounter].Date >= gdatStartDate)
                        {
                            if (TheIssuedPartsDataSet.IssuedParts[intCounter].Date <= gdatEndDate)
                            {
                                PartTransactionDataSet.parttransactionsRow NewTableRow = ThePartTransactionDataSet.parttransactions.NewparttransactionsRow();

                                NewTableRow.Date = TheDateSearchClass.RemoveTime(TheIssuedPartsDataSet.IssuedParts[intCounter].Date);
                                NewTableRow.ProjectID = TheIssuedPartsDataSet.IssuedParts[intCounter].ProjectID;
                                NewTableRow.QuantityIssued = TheIssuedPartsDataSet.IssuedParts[intCounter].QTY;
                                NewTableRow.QuantityReceived = 0;
                                NewTableRow.QuantityReported = 0;

                                ThePartTransactionDataSet.parttransactions.Rows.Add(NewTableRow);

                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Date Part Search Load Received Parts " + Ex.Message);

                TheMessagesClass.ErrorMessage(Ex.Message);
            }
        }
        private void LoadReceivedParts()
        {
            int intCounter;
            int intNumberOfRecords;

            try
            {
                intNumberOfRecords = TheReceivedPartsDataSet.ReceivedParts.Rows.Count - 1;

                for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    if(TheReceivedPartsDataSet.ReceivedParts[intCounter].IsDateNull() == false)
                    {
                        if(TheReceivedPartsDataSet.ReceivedParts[intCounter].Date >= gdatStartDate)
                        {
                            if (TheReceivedPartsDataSet.ReceivedParts[intCounter].Date <= gdatEndDate)
                            {
                                PartTransactionDataSet.parttransactionsRow NewTableRow = ThePartTransactionDataSet.parttransactions.NewparttransactionsRow();

                                NewTableRow.Date = TheDateSearchClass.RemoveTime(TheReceivedPartsDataSet.ReceivedParts[intCounter].Date);
                                NewTableRow.ProjectID = TheReceivedPartsDataSet.ReceivedParts[intCounter].ProjectID;
                                NewTableRow.QuantityIssued = 0;
                                NewTableRow.QuantityReceived = TheReceivedPartsDataSet.ReceivedParts[intCounter].QTY;
                                NewTableRow.QuantityReported = 0;

                                ThePartTransactionDataSet.parttransactions.Rows.Add(NewTableRow);

                            }
                        }
                    }
                }
            }
            catch(Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Date Part Search Load Received Parts " + Ex.Message);

                TheMessagesClass.ErrorMessage(Ex.Message);
            }
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.PrinterSettings = printDialog1.PrinterSettings;
                    gintNewPrintCounter = 0;
                    gintUpperLimit = ThePartTransactionDataSet.parttransactions.Rows.Count - 1;

                    printDocument1.DefaultPageSettings.Landscape = true;

                    printDocument1.Print();
                }
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Warehouse Inventory Report Print Report " + Ex.Message);

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


            PrintX = 250;
            PrintY = 100;
            intStartingPageCounter = gintNewPrintCounter;


            //setting up the header
            e.Graphics.DrawString("Blue Jay Project Inventory for Part Number " + gstrPartNumber, PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            PrintY = PrintY + fltHeadingLineHeight + 10;
            PrintX = 270;
            e.Graphics.DrawString(gstrDescription, PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            PrintY = PrintY + fltHeadingLineHeight + 10;

            PrintX = 50;
            e.Graphics.DrawString("Project ID", PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            PrintX = 300;
            e.Graphics.DrawString("Date", PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            PrintX = 500;
            e.Graphics.DrawString("Qty Received", PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            PrintX = 650;
            e.Graphics.DrawString("Qty Issued", PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            PrintX = 800;
            e.Graphics.DrawString("Qty Reported", PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            
            PrintY = PrintY + fltHeadingLineHeight + 10;

            for (intCounter = intStartingPageCounter; intCounter <= gintUpperLimit; intCounter++)
            {
                PrintX = 50;
                e.Graphics.DrawString(ThePartTransactionDataSet.parttransactions[intCounter].ProjectID, PrintItemFont, Brushes.Black, PrintX, PrintY);
                
                PrintX = 300;
                e.Graphics.DrawString(Convert.ToString(ThePartTransactionDataSet.parttransactions[intCounter].Date), PrintItemFont, Brushes.Black, PrintX, PrintY);
                PrintX = 500;
                e.Graphics.DrawString(Convert.ToString(ThePartTransactionDataSet.parttransactions[intCounter].QuantityReceived), PrintItemFont, Brushes.Black, PrintX, PrintY);
                PrintX = 650;
                e.Graphics.DrawString(Convert.ToString(ThePartTransactionDataSet.parttransactions[intCounter].QuantityIssued), PrintItemFont, Brushes.Black, PrintX, PrintY);
                PrintX = 800;
                e.Graphics.DrawString(Convert.ToString(ThePartTransactionDataSet.parttransactions[intCounter].QuantityReported), PrintItemFont, Brushes.Black, PrintX, PrintY);
                PrintY = PrintY + fltItemLineHeight + 5;

                if (PrintY >= 800)
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
