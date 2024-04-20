/* Title:           Project  Part Report
 * Date:            12-9-16
 * Author:          Terry Holmes
 * 
 * Description:     This report will show all the parts associated with a project */

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
using InventoryDLL;
using ProjectsDLL;
using IssuedPartsDLL;
using ReceivedMaterialDLL;
using BOMPartsDLL;
using KeyWordDLL;
using DataValidationDLL;
using PartNumberDLL;

namespace WhseTrack
{
    public partial class ProjectPartReport : Form
    {
        //Setting up the classes
        MessagesClass TheMessagesClass = new MessagesClass();
        EventLogClass TheEventLogClass = new EventLogClass();
        InventoryClass TheInventoryClass = new InventoryClass();
        ProjectClass TheProjectClass = new ProjectClass();
        IssuedPartsClass TheIssuePartsClass = new IssuedPartsClass();
        ReceivedMaterialClass TheReceiveMaterialClass = new ReceivedMaterialClass();
        BOMPartsClass TheBOMPartsClass = new BOMPartsClass();
        KeyWordClass TheKeyWordClass = new KeyWordClass();
        DataValidationClass TheDataValidationClass = new DataValidationClass();
        PartNumberClass ThePartNumberClass = new PartNumberClass();
        PleaseWait PleaseWait = new PleaseWait();

        //setting up the data sets
        InternalProjectDataSet TheSortedProjectsDataSet;
        BOMPartsDataSet TheBOMPartsDataSet;
        ReceivedPartsDataSet TheReceievePartsDataSet;
        IssuedPartsDataSet TheIssuedPartsDataSet;
        ProjectTransactionDataSet TheProjectTransactionDataSet = new ProjectTransactionDataSet();
        PartNumbersDataSet TheSortedPartNumberDataSet = new PartNumbersDataSet();

        string gstrProjectID;
        int gintPartCounter;
        int gintPartUpperLimit;
        int gintNewPrintCounter;
                
        public ProjectPartReport()
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

        private void txtProject_TextChanged(object sender, EventArgs e)
        {
            int intLength;
            string strProjectID;

            intLength = txtProject.Text.Length;

            if(intLength >= 3)
            {
                strProjectID = txtProject.Text;

                strProjectID = "%" + strProjectID + "%";

                TheSortedProjectsDataSet = TheProjectClass.GetInternalProjectByProjectID(strProjectID);

                dgvInventory.DataSource = TheSortedProjectsDataSet.internalprojects;
            }
        }

        private void dgvInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    PleaseWait.Show();

                    TheProjectTransactionDataSet.projectttransactions.Rows.Clear();

                    DataGridViewRow row = dgvInventory.Rows[e.RowIndex];

                    gstrProjectID = row.Cells["TWCControlNumber"].Value.ToString();

                    TheReceievePartsDataSet = TheReceiveMaterialClass.GetReceivedPartsByProjectID(gstrProjectID);
                    TheIssuedPartsDataSet = TheIssuePartsClass.GetIssuedPartsByProjectID(gstrProjectID);
                    TheBOMPartsDataSet = TheBOMPartsClass.GetBOMPartsByProjectID(gstrProjectID);

                    gintPartCounter = 0;
                    gintPartUpperLimit = 0;
                    LoadReceivedParts();
                    LoadIssueParts();
                    LoadBOMParts();
                    dgvInventory.DataSource = TheProjectTransactionDataSet.projectttransactions;

                    PleaseWait.Hide();
                }
            }
            catch (Exception Ex)
            {
                TheMessagesClass.ErrorMessage(Ex.ToString());
            }

            PleaseWait.Hide();
            
        }
        private void LoadBOMParts()
        {
            int intBOMCounter;
            int intPartCounter;
            int intBOMUpperLimit;
            int intWarehouseCounter;
            int intWarehouseUpperLimit;
            bool blnItemFound = false;
            int intTotalQuantity;
            int intTransactionQuantity;

            try
            {
                intBOMUpperLimit = TheBOMPartsDataSet.BOMParts.Rows.Count - 1;
                intWarehouseUpperLimit = Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses.Rows.Count - 1;

                if (intBOMUpperLimit > -1)
                {
                    for (intBOMCounter = 0; intBOMCounter <= intBOMUpperLimit; intBOMCounter++)
                    {
                        if (TheBOMPartsDataSet.BOMParts[intBOMCounter].IsPartIDNull() == false)
                        {
                            blnItemFound = false;

                            if (gintPartCounter > 0)
                            {
                                for (intPartCounter = 0; intPartCounter <= gintPartUpperLimit; intPartCounter++)
                                {
                                    if (TheProjectTransactionDataSet.projectttransactions[intPartCounter].PartID == TheBOMPartsDataSet.BOMParts[intBOMCounter].PartID)
                                    {
                                        if(TheProjectTransactionDataSet.projectttransactions[intPartCounter].WarehouseID == TheBOMPartsDataSet.BOMParts[intBOMCounter].WarehouseID)
                                        {
                                            intTransactionQuantity = Convert.ToInt32(TheBOMPartsDataSet.BOMParts[intBOMCounter].QTY);
                                            intTotalQuantity = TheProjectTransactionDataSet.projectttransactions[intPartCounter].QuantityReported;
                                            intTotalQuantity = intTotalQuantity + intTransactionQuantity;
                                            TheProjectTransactionDataSet.projectttransactions[intPartCounter].QuantityReported = intTotalQuantity;
                                            blnItemFound = true;
                                        }
                                    }
                                }
                            }

                            if (blnItemFound == false)
                            {
                                ProjectTransactionDataSet.projectttransactionsRow NewTableRow = TheProjectTransactionDataSet.projectttransactions.NewprojectttransactionsRow();

                                TheSortedPartNumberDataSet = ThePartNumberClass.GetPartNumberByPartID(TheBOMPartsDataSet.BOMParts[intBOMCounter].PartID);

                                NewTableRow.Description = TheSortedPartNumberDataSet.partnumbers[0].Description;
                                NewTableRow.PartID = TheSortedPartNumberDataSet.partnumbers[0].PartID;
                                NewTableRow.PartNumber = TheSortedPartNumberDataSet.partnumbers[0].PartNumber;
                                NewTableRow.QuantityIssued = 0;
                                NewTableRow.QuantityReceived = 0;
                                NewTableRow.QuantityReported = Convert.ToInt32(TheBOMPartsDataSet.BOMParts[intBOMCounter].QTY);
                                NewTableRow.WarehouseID = TheBOMPartsDataSet.BOMParts[intBOMCounter].WarehouseID;

                                for (intWarehouseCounter = 0; intWarehouseCounter <= intWarehouseUpperLimit; intWarehouseCounter++)
                                {
                                    if (Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses[intWarehouseCounter].EmployeeID == TheBOMPartsDataSet.BOMParts[intBOMCounter].WarehouseID)
                                    {
                                        NewTableRow.Warehouse = Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses[intWarehouseCounter].FirstName;
                                        break;
                                    }
                                }

                                TheProjectTransactionDataSet.projectttransactions.Rows.Add(NewTableRow);
                                gintPartUpperLimit = gintPartCounter;
                                gintPartCounter++;
                            }
                        }
                    }

                }


            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Project Part Report Load BOM Parts " + Ex.Message);

                TheMessagesClass.ErrorMessage(Ex.ToString());
            }
        }
        private void LoadIssueParts()
        {
            int intIssueCounter;
            int intPartCounter;
            int intIssueUpperLimit;
            int intWarehouseCounter;
            int intWarehouseUpperLimit;
            bool blnItemFound = false;
            int intTotalQuantity;
            int intTransactionQuantity;

            try
            {
                intIssueUpperLimit = TheIssuedPartsDataSet.IssuedParts.Rows.Count - 1;
                intWarehouseUpperLimit = Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses.Rows.Count - 1;

                if (intIssueUpperLimit > -1)
                {
                    for (intIssueCounter = 0; intIssueCounter <= intIssueUpperLimit; intIssueCounter++)
                    {
                        if (TheIssuedPartsDataSet.IssuedParts[intIssueCounter].IsPartIDNull() == false)
                        {
                            blnItemFound = false;

                            if (gintPartCounter > 0)
                            {
                                for (intPartCounter = 0; intPartCounter <= gintPartUpperLimit; intPartCounter++)
                                {
                                    if (TheProjectTransactionDataSet.projectttransactions[intPartCounter].PartID == TheIssuedPartsDataSet.IssuedParts[intIssueCounter].PartID)
                                    {
                                        if(TheProjectTransactionDataSet.projectttransactions[intPartCounter].WarehouseID == TheIssuedPartsDataSet.IssuedParts[intIssueCounter].WarehouseID)
                                        {
                                            intTransactionQuantity = TheIssuedPartsDataSet.IssuedParts[intIssueCounter].QTY;
                                            intTotalQuantity = TheProjectTransactionDataSet.projectttransactions[intPartCounter].QuantityIssued;
                                            intTotalQuantity = intTotalQuantity + intTransactionQuantity;
                                            TheProjectTransactionDataSet.projectttransactions[intPartCounter].QuantityIssued = intTotalQuantity;
                                            blnItemFound = true;
                                        }
                                    }
                                }
                            }

                            if (blnItemFound == false)
                            {
                                ProjectTransactionDataSet.projectttransactionsRow NewTableRow = TheProjectTransactionDataSet.projectttransactions.NewprojectttransactionsRow();

                                TheSortedPartNumberDataSet = ThePartNumberClass.GetPartNumberByPartID(TheIssuedPartsDataSet.IssuedParts[intIssueCounter].PartID);

                                NewTableRow.Description = TheSortedPartNumberDataSet.partnumbers[0].Description;
                                NewTableRow.PartID = TheSortedPartNumberDataSet.partnumbers[0].PartID;
                                NewTableRow.PartNumber = TheSortedPartNumberDataSet.partnumbers[0].PartNumber;
                                NewTableRow.QuantityIssued = TheIssuedPartsDataSet.IssuedParts[intIssueCounter].QTY;
                                NewTableRow.QuantityReceived = 0;
                                NewTableRow.QuantityReported = 0;
                                NewTableRow.WarehouseID = TheIssuedPartsDataSet.IssuedParts[intIssueCounter].WarehouseID;

                                for (intWarehouseCounter = 0; intWarehouseCounter <= intWarehouseUpperLimit; intWarehouseCounter++)
                                {
                                    if (Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses[intWarehouseCounter].EmployeeID == TheIssuedPartsDataSet.IssuedParts[intIssueCounter].WarehouseID)
                                    {
                                        NewTableRow.Warehouse = Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses[intWarehouseCounter].FirstName;
                                        break;
                                    }
                                }

                                TheProjectTransactionDataSet.projectttransactions.Rows.Add(NewTableRow);
                                gintPartUpperLimit = gintPartCounter;
                                gintPartCounter++;
                            }
                        }
                    }

                }


            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Project Part Report Load Issue Parts " + Ex.Message);

                TheMessagesClass.ErrorMessage(Ex.ToString());
            }
        }
        private void LoadReceivedParts()
        {
            int intReceiveCounter;
            int intPartCounter;
            int intReceiveUpperLimit;
            int intWarehouseCounter;
            int intWarehouseUpperLimit;
            bool blnItemFound = false;
            int intTotalQuantity;
            int intTransactionQuantity;

            try
            {
                intReceiveUpperLimit = TheReceievePartsDataSet.ReceivedParts.Rows.Count - 1;
                intWarehouseUpperLimit = Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses.Rows.Count - 1;

                if(intReceiveUpperLimit > - 1)
                {
                    for(intReceiveCounter = 0; intReceiveCounter <= intReceiveUpperLimit; intReceiveCounter++)
                    {
                        if(TheReceievePartsDataSet.ReceivedParts[intReceiveCounter].IsPartIDNull() == false)
                        {
                            blnItemFound = false;

                            if (gintPartCounter > 0)
                            {
                                for (intPartCounter = 0; intPartCounter <= gintPartUpperLimit; intPartCounter++)
                                {
                                    if (TheProjectTransactionDataSet.projectttransactions[intPartCounter].PartID == TheReceievePartsDataSet.ReceivedParts[intReceiveCounter].PartID)
                                    {
                                        if(TheProjectTransactionDataSet.projectttransactions[intPartCounter].WarehouseID == TheReceievePartsDataSet.ReceivedParts[intReceiveCounter].WarehouseID)
                                        {
                                            intTransactionQuantity = TheReceievePartsDataSet.ReceivedParts[intReceiveCounter].QTY;
                                            intTotalQuantity = TheProjectTransactionDataSet.projectttransactions[intPartCounter].QuantityReceived;
                                            intTotalQuantity = intTotalQuantity + intTransactionQuantity;
                                            TheProjectTransactionDataSet.projectttransactions[intPartCounter].QuantityReceived = intTotalQuantity;
                                            blnItemFound = true;
                                        }                                        
                                    }
                                }
                            }

                            if (blnItemFound == false)
                            {
                                ProjectTransactionDataSet.projectttransactionsRow NewTableRow = TheProjectTransactionDataSet.projectttransactions.NewprojectttransactionsRow();

                                TheSortedPartNumberDataSet = ThePartNumberClass.GetPartNumberByPartID(TheReceievePartsDataSet.ReceivedParts[intReceiveCounter].PartID);

                                NewTableRow.Description = TheSortedPartNumberDataSet.partnumbers[0].Description;
                                NewTableRow.PartID = TheSortedPartNumberDataSet.partnumbers[0].PartID;
                                NewTableRow.PartNumber = TheSortedPartNumberDataSet.partnumbers[0].PartNumber;
                                NewTableRow.QuantityIssued = 0;
                                NewTableRow.QuantityReceived = TheReceievePartsDataSet.ReceivedParts[intReceiveCounter].QTY;
                                NewTableRow.QuantityReported = 0;
                                NewTableRow.WarehouseID = TheReceievePartsDataSet.ReceivedParts[intReceiveCounter].WarehouseID;

                                for (intWarehouseCounter = 0; intWarehouseCounter <= intWarehouseUpperLimit; intWarehouseCounter++)
                                {
                                    if (Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses[intWarehouseCounter].EmployeeID == TheReceievePartsDataSet.ReceivedParts[intReceiveCounter].WarehouseID)
                                    {
                                        NewTableRow.Warehouse = Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses[intWarehouseCounter].FirstName;
                                        break;
                                    }
                                }

                                TheProjectTransactionDataSet.projectttransactions.Rows.Add(NewTableRow);
                                gintPartUpperLimit = gintPartCounter;
                                gintPartCounter++;
                            }
                        }
                    }
                        
                }


            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Project Part Report Load Receive Parts " + Ex.Message);

                TheMessagesClass.ErrorMessage(Ex.ToString());
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


            PrintX = 350;
            PrintY = 100;
            intStartingPageCounter = gintNewPrintCounter;


            //setting up the header
            e.Graphics.DrawString("Blue Jay Project Inventory for Project " + gstrProjectID, PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            PrintY = PrintY + fltHeadingLineHeight + 10;

            PrintX = 50;
            e.Graphics.DrawString("Part Number", PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            PrintX = 200;
            e.Graphics.DrawString("Description", PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            PrintX = 450;
            e.Graphics.DrawString("Qty Received", PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            PrintX = 600;
            e.Graphics.DrawString("Qty Issued", PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            PrintX = 750;
            e.Graphics.DrawString("Qty Reported", PrintHeaderFont, Brushes.Black, PrintX, PrintY);
            PrintX = 900;
            e.Graphics.DrawString("Warehouse", PrintHeaderFont, Brushes.Black, PrintX, PrintY);

            PrintY = PrintY + fltHeadingLineHeight + 10;

            for (intCounter = intStartingPageCounter; intCounter <= gintPartUpperLimit; intCounter++)
            {
                PrintX = 50;
                e.Graphics.DrawString(TheProjectTransactionDataSet.projectttransactions[intCounter].PartNumber, PrintItemFont, Brushes.Black, PrintX, PrintY);
                strDescription = TheProjectTransactionDataSet.projectttransactions[intCounter].Description;
                intStringLength = strDescription.Length;
                if (intStringLength > 25)
                {
                    strDescription = strDescription.Substring(0, 25);
                }
                PrintX = 200;
                e.Graphics.DrawString(strDescription, PrintItemFont, Brushes.Black, PrintX, PrintY);
                PrintX = 450;
                e.Graphics.DrawString(Convert.ToString(TheProjectTransactionDataSet.projectttransactions[intCounter].QuantityReceived), PrintItemFont, Brushes.Black, PrintX, PrintY);
                PrintX = 600;
                e.Graphics.DrawString(Convert.ToString(TheProjectTransactionDataSet.projectttransactions[intCounter].QuantityIssued), PrintItemFont, Brushes.Black, PrintX, PrintY);
                PrintX = 750;
                e.Graphics.DrawString(Convert.ToString(TheProjectTransactionDataSet.projectttransactions[intCounter].QuantityReported), PrintItemFont, Brushes.Black, PrintX, PrintY);
                PrintX = 900;
                e.Graphics.DrawString(TheProjectTransactionDataSet.projectttransactions[intCounter].Warehouse, PrintItemFont, Brushes.Black, PrintX, PrintY);
                PrintY = PrintY + fltItemLineHeight + 5;

                if (PrintY >= 800)
                {
                    if (intStartingPageCounter == gintPartUpperLimit)
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
                        intCounter = gintPartUpperLimit;
                    }
                }

            }
        }
        
    }
}
