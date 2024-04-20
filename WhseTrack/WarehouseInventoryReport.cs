/* Title:           Warehouse Inventory Report
 * Date:            11-29-16
 * Author:          Terry Holmes
 * 
 * Description:     This form is used for the Warehouse Inventory Report */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PartNumberDLL;
using InventoryDLL;
using NewEventLogDLL;

namespace WhseTrack
{
    public partial class WarehouseInventoryReport : Form
    {
        //setting up the classes
        MessagesClass TheMessagesClass = new MessagesClass();
        PartNumberClass ThePartNumberClass = new PartNumberClass();
        InventoryClass TheInventoryClass = new InventoryClass();
        EventLogClass TheEventLogClass = new EventLogClass();
        PleaseWait PleaseWait = new PleaseWait();

        WarehouseInventoryDataSet TheSortedWarehouseInventory = new WarehouseInventoryDataSet();
        
        //setting global variables
        int gintNewPrintCounter;
        int gintUpperLimit;
        
        public WarehouseInventoryReport()
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

        private void btnInventoryMenu_Click(object sender, EventArgs e)
        {
            InventoryReports InventoryReports = new InventoryReports();
            InventoryReports.Show();
            this.Close();
        }

        private void cboWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            //setting local variables
            int intCounter;
            int intNumberOfRecords;
            int intWarehouseID;

            if (cboWarehouse.Text != "Select Warehouse")
            {
                if(cboWarehouse.Text == "All Warehouses")
                {

                }
                else
                {
                    intNumberOfRecords = Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses.Rows.Count - 1;

                    for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                    {
                        if(Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses[intCounter].FirstName == cboWarehouse.Text)
                        {
                            intWarehouseID = Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses[intCounter].EmployeeID;

                            TheSortedWarehouseInventory = TheInventoryClass.GetWarehouseInventoryByWarehouseID(intWarehouseID);
                            break;
                        }
                    }
                }

                dgvInventory.DataSource = TheSortedWarehouseInventory.WarehouseInventory;
            }
        }

        private void WarehouseInventoryReport_Load(object sender, EventArgs e)
        {
            //setting local variables
            int intCounter;
            int intNumberOfRecords;

            try
            {
                //getting the number of records
                intNumberOfRecords = Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses.Rows.Count - 1;

                cboWarehouse.Items.Add("Select Warehouse");
                cboWarehouse.Items.Add("All Warehouses");

                //loop
                for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    cboWarehouse.Items.Add(Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses[intCounter].FirstName);
                }

                cboWarehouse.SelectedIndex = 0;
                dgvInventory.DataSource = TheSortedWarehouseInventory.WarehouseInventory;
            }
            catch (Exception ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Warehouse Inventory Report Form Load Event " + ex.Message);

                TheMessagesClass.ErrorMessage(ex.ToString());
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
                    gintUpperLimit = TheSortedWarehouseInventory.WarehouseInventory.Rows.Count - 1;

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
            

            PrintX = 150;
            PrintY = 100;
            intStartingPageCounter = gintNewPrintCounter;
            

            //setting up the header
            e.Graphics.DrawString("Blue Jay Inventory Report For " + cboWarehouse.Text, PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            PrintY = PrintY + fltHeadingLineHeight + 10;

            PrintX = 50;
            e.Graphics.DrawString("Part Number", PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            PrintX = 200;
            e.Graphics.DrawString("Description", PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            PrintX = 700;
            e.Graphics.DrawString("Quantity", PrintHeaderFont, Brushes.Black, PrintX, PrintY);
                     
            PrintY = PrintY + fltHeadingLineHeight + 10;

            for (intCounter = intStartingPageCounter; intCounter <= gintUpperLimit; intCounter++)
            {
                PrintX = 50;
                e.Graphics.DrawString(TheSortedWarehouseInventory.WarehouseInventory[intCounter].PartNumber, PrintItemFont, Brushes.Black, PrintX, PrintY);
                strDescription = ThePartNumberClass.FindPartDescription(TheSortedWarehouseInventory.WarehouseInventory[intCounter].PartNumber);
                intStringLength = strDescription.Length;
                if(intStringLength > 50)
                {
                    strDescription = strDescription.Substring(0, 50);
                }
                PrintX = 200;
                e.Graphics.DrawString(strDescription, PrintItemFont, Brushes.Black, PrintX, PrintY);
                PrintX = 700;
                e.Graphics.DrawString(Convert.ToString(TheSortedWarehouseInventory.WarehouseInventory[intCounter].QTYOnHand), PrintItemFont, Brushes.Black, PrintX, PrintY);
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

        private void lblAddPartNumbers_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dgvInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExportToCSV_Click(object sender, EventArgs e)
        {

        }
    }
}
