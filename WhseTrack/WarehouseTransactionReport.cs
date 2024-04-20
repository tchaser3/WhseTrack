/* Title:           Warehouse Transaction Report
 * Date:            11-7-17
 * Author:          Terry Holmes
 * 
 * Description:     This is the form that will show the transactions for a warehouse over a specific date range */

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
using DateSearchDLL;
using InventoryDLL;
using ReceivedMaterialDLL;
using IssuedPartsDLL;
using BOMPartsDLL;

namespace WhseTrack
{
    public partial class WarehouseTransactionReport : Form
    {
        //setting up the classes
        MessagesClass TheMessagesClass = new MessagesClass();
        EventLogClass TheEventLogClass = new EventLogClass();
        DateSearchClass TheDateSearchClass = new DateSearchClass();
        InventoryClass TheInventoryClass = new InventoryClass();
        ReceivedMaterialClass TheReceiveMaterialClass = new ReceivedMaterialClass();
        IssuedPartsClass TheIssuedPartsClass = new IssuedPartsClass();
        BOMPartsClass TheBomPartsClass = new BOMPartsClass();
        PleaseWait PleaseWait = new PleaseWait();

        //setting up the data
        InventoryDataSet TheInventoryDataSet;
        WarehouseInventoryDataSet TheWarehouseInventoryDataSet;
        ReceivedPartsDataSet TheReceivedPartsDataSet;
        IssuedPartsDataSet TheIssuedPartsDataSet;

        DatePartTransactionDataSet TheDatePartTransactionDataSet = new DatePartTransactionDataSet();

        //setting up the global variables
        DateTime gdatStartDate;
        DateTime gdatEndDate;
        string gstrErrorMessage;
        int gintWarehouseInventoryNumberOfRecords;
        int gintInventoryNumberOfRecords;

        public WarehouseTransactionReport()
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

        private void btnInventoryReports_Click(object sender, EventArgs e)
        {
            InventoryReports InventoryReports = new InventoryReports();
            InventoryReports.Show();
            this.Close();
        }

        private void WarehouseTransactionReport_Load(object sender, EventArgs e)
        {
            //this will load the form up
            bool blnFatalError = false;

            PleaseWait.Show();

            //work goes here
            gdatStartDate = TheDateSearchClass.RemoveTime(Logon.gdatStartDate);
            gdatEndDate = TheDateSearchClass.RemoveTime(Logon.gdatEndDate);

            blnFatalError = LoadInventoryDataSet();
            if (blnFatalError == false)
                blnFatalError = SortReceivedParts();

            PleaseWait.Hide();

            if(blnFatalError == true)
            {
                TheMessagesClass.ErrorMessage(gstrErrorMessage);
                btnPrint.Enabled = false;
                btnExportToCSV.Enabled = false;                
            }

            dgvSearchResults.DataSource = TheDatePartTransactionDataSet.parttransactions;
        }
        private bool SortReceivedParts()
        {
            bool blnFatalError = false;
            int intCounter;
            int intNumberOfRecords;
            DateTime datTransactionDate;

            try
            {
                //loading the data set
                TheReceivedPartsDataSet = TheReceiveMaterialClass.GetReceivedPartsInfo();

                //getting the number of records
                intNumberOfRecords = TheReceivedPartsDataSet.ReceivedParts.Rows.Count - 1;

                for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    datTransactionDate = TheDateSearchClass.RemoveTime(TheReceivedPartsDataSet.ReceivedParts[intCounter].Date);

                    if(gdatStartDate <= datTransactionDate)
                    {
                        if(gdatEndDate >= datTransactionDate)
                        {
                            DatePartTransactionDataSet.parttransactionsRow NewTableRow = TheDatePartTransactionDataSet.parttransactions.NewparttransactionsRow();

                            NewTableRow.Date = datTransactionDate;
                            NewTableRow.Description = "Need to put there";
                            NewTableRow.PartID = TheReceivedPartsDataSet.ReceivedParts[intCounter].PartID;
                            NewTableRow.PartNumber = TheReceivedPartsDataSet.ReceivedParts[intCounter].PartNumber;
                            NewTableRow.Project = TheReceivedPartsDataSet.ReceivedParts[intCounter].ProjectID;
                            NewTableRow.QuantityIssued = 0;
                            NewTableRow.QuantityReceived = TheReceivedPartsDataSet.ReceivedParts[intCounter].QTY;
                            NewTableRow.QuantityReported = 0;
                            NewTableRow.WarehouseID = TheReceivedPartsDataSet.ReceivedParts[intCounter].WarehouseID;

                            TheDatePartTransactionDataSet.parttransactions.Rows.Add(NewTableRow);

                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Warehouse Transaction Report Sort Received Parts " + Ex.Message);

                gstrErrorMessage = Ex.ToString();

                blnFatalError = true;
            }

            return blnFatalError;
        }
        private bool LoadInventoryDataSet()
        {
            bool blnFatalError = false;

            try
            {
                //loading the data bases
                TheInventoryDataSet = TheInventoryClass.GetInventoryInfo();

                TheWarehouseInventoryDataSet = TheInventoryClass.GetWarehouseInventoryInfo();

                //getting the number of records
                gintWarehouseInventoryNumberOfRecords = TheWarehouseInventoryDataSet.WarehouseInventory.Rows.Count - 1;
                gintInventoryNumberOfRecords = TheInventoryDataSet.Inventory.Rows.Count - 1;


            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Warehouse Transaction Report Load Inventory Data Set " + Ex.Message);

                gstrErrorMessage = Ex.ToString();

                blnFatalError = true;
            }

            return blnFatalError;
        }
    }
}
