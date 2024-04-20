/* Title:           Inventory Evaluation
 * Date:            12-9-16
 * Author:          Terry Holmes
 * 
 * Description:     This form is used for inventory valuation */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryDLL;
using KeyWordDLL;
using NewEventLogDLL;
using PartNumberDLL;

namespace WhseTrack
{
    public partial class InventoryEvaluation : Form
    {
        //setting up the classes
        MessagesClass TheMessagesClass = new MessagesClass();
        InventoryClass TheInventoryClass = new InventoryClass();
        KeyWordClass TheKeyWordClass = new KeyWordClass();
        EventLogClass TheEventLogClass = new EventLogClass();
        PartNumberClass ThePartNumberClass = new PartNumberClass();
        PleaseWait PleaseWait = new PleaseWait();

        WarehouseInventoryDataSet TheSortedInventoryDataSet;
        PartNumbersDataSet TheSortedPartNumberDataSet;

        InventoryEvaluationDataSet TheInventoryEvaluationDataSet = new InventoryEvaluationDataSet();

        public InventoryEvaluation()
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
            InventoryMenu InventoryMenu = new InventoryMenu();
            InventoryMenu.Show();
            this.Close();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            //setting local variables
            int intWarehouseCounter;
            int intWarehouseNumberOfRecords;
            int intWarehouseID;
            int intInventoryCounter;
            int intInventoryNumberOfRecords;
            bool blnKeyWordNotFound;
            double douValue;

            try
            {
                PleaseWait.Show();
                 
                intWarehouseNumberOfRecords = Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses.Rows.Count - 1;

                for(intWarehouseCounter = 0; intWarehouseCounter <= intWarehouseNumberOfRecords; intWarehouseCounter++)
                {
                    douValue = 0;

                    blnKeyWordNotFound = TheKeyWordClass.FindKeyWord("JH", Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses[intWarehouseCounter].FirstName);

                    if(blnKeyWordNotFound == false)
                    {
                        intWarehouseID = Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses[intWarehouseCounter].EmployeeID;

                        TheSortedInventoryDataSet = TheInventoryClass.GetWarehouseInventoryByWarehouseID(intWarehouseID);

                        intInventoryNumberOfRecords = TheSortedInventoryDataSet.WarehouseInventory.Rows.Count - 1;

                        if(intInventoryNumberOfRecords > -1)
                        {
                            for (intInventoryCounter = 0; intInventoryCounter <= intInventoryNumberOfRecords; intInventoryCounter++)
                            {
                                TheSortedPartNumberDataSet = ThePartNumberClass.GetPartNumberByPartID(TheSortedInventoryDataSet.WarehouseInventory[intInventoryCounter].TablePartID);

                                douValue = douValue + (TheSortedPartNumberDataSet.partnumbers[0].Price * TheSortedInventoryDataSet.WarehouseInventory[intInventoryCounter].QTYOnHand);
                            }
                        }
                        
                        InventoryEvaluationDataSet.inventoryevaluationRow NewTableRow = TheInventoryEvaluationDataSet.inventoryevaluation.NewinventoryevaluationRow();

                        NewTableRow.Value = douValue;
                        NewTableRow.Warehouse = Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses[intWarehouseCounter].FirstName;
                        NewTableRow.WarehouseID = intWarehouseID;

                        TheInventoryEvaluationDataSet.inventoryevaluation.Rows.Add(NewTableRow);
                    }
                }

                dgvInventory.DataSource = TheInventoryEvaluationDataSet.inventoryevaluation;
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Inventory Evaluation Process Button " + Ex.Message);
            }

            PleaseWait.Hide();
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.PrinterSettings = printDialog1.PrinterSettings;
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
            int intNumberOfRecords;
            Font PrintHeaderFont = new Font("Arial", 14, FontStyle.Bold);
            Font PrintItemFont = new Font("Arial", 10, FontStyle.Regular);
            float PrintX = e.MarginBounds.Left;
            float PrintY = e.MarginBounds.Top;
            float HeadingLineHeight = PrintHeaderFont.GetHeight() + 18;
            int intStartingPageCounter;
            bool blnNewPage = false;
            float fltHeadingLineHeight = PrintHeaderFont.GetHeight() + 10;
            float fltItemLineHeight = PrintItemFont.GetHeight() + 5;
            double douTotalAmount = 0;
            

            PrintX = 250;
            PrintY = 100;

            intNumberOfRecords = TheInventoryEvaluationDataSet.inventoryevaluation.Rows.Count - 1;

            //setting up the header
            e.Graphics.DrawString("Blue Jay Inventory Evaluation Report", PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            PrintY = PrintY + fltHeadingLineHeight + 10;
           

            PrintX = 100;
            e.Graphics.DrawString("Warehouse ID", PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            PrintX = 400;
            e.Graphics.DrawString("Warehouse", PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            PrintX = 700;
            e.Graphics.DrawString("Value", PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            

            PrintY = PrintY + fltHeadingLineHeight + 10;

            for (intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
            {
                PrintX = 100;
                e.Graphics.DrawString(Convert.ToString(TheInventoryEvaluationDataSet.inventoryevaluation[intCounter].WarehouseID), PrintItemFont, Brushes.Black, PrintX, PrintY);

                PrintX = 400;
                e.Graphics.DrawString(TheInventoryEvaluationDataSet.inventoryevaluation[intCounter].Warehouse, PrintItemFont, Brushes.Black, PrintX, PrintY);
                PrintX = 700;
                douTotalAmount = douTotalAmount + TheInventoryEvaluationDataSet.inventoryevaluation[intCounter].Value;
                e.Graphics.DrawString(Convert.ToString(TheInventoryEvaluationDataSet.inventoryevaluation[intCounter].Value), PrintItemFont, Brushes.Black, PrintX, PrintY);
                PrintY = PrintY + fltItemLineHeight + 5;
            }

            PrintX = 400;
            e.Graphics.DrawString("Total Value = " + Convert.ToString(douTotalAmount), PrintHeaderFont, Brushes.Black, PrintX, PrintY);
        }
    }
}
