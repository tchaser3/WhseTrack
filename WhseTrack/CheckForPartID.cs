/* Title:           Check For Part ID
 * Date:            10-31-16
 * Author:          Terry Holmes
 * 
 * Description:     This form will add IDs for the part ID in the inventory tables */

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
using PartNumberDLL;
using ReceivedMaterialDLL;
using IssuedPartsDLL;
using BOMPartsDLL;

namespace WhseTrack
{
    public partial class CheckForPartID : Form
    {
        //setting up the classes
        MessagesClass theMessagesClass = new MessagesClass();
        EventLogClass TheEventLogClass = new EventLogClass();
        InventoryClass TheInventoryClass = new InventoryClass();
        PartNumberClass ThePartNumberClass = new PartNumberClass();
        PleaseWait PleaseWait = new PleaseWait();
        ReceivedMaterialClass TheReceivedMaterialClass = new ReceivedMaterialClass();
        IssuedPartsClass TheIssuedPartsClass = new IssuedPartsClass();
        BOMPartsClass TheBOMPartsClass = new BOMPartsClass();

        //setting up the data
        WarehouseInventoryDataSet TheWarehouseInventoryDataSet;
        PartNumbersDataSet ThePartNumberDataSet;
        InventoryDataSet TheInventoryDataSet;
        ReceivedPartsDataSet TheReceivedPartsDataSet;
        IssuedPartsDataSet TheIssuedPartsDataSet;
        BOMPartsDataSet TheBOMPartsDataSet;

        //setting up global variables
        int gintPartUpperLimit;
        int gintWarehouseUpperLimit;
        int gintInventoryUpperLimit;
        int gintReceivedUpperLimit;
        int gintIssuedUpperLimit;
        int gintBOMUpperLimit;

        public CheckForPartID()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //this will close the program
            theMessagesClass.CloseTheProgram();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            MainMenu MainMenu = new MainMenu();
            MainMenu.Show();
            this.Close();
        }

        private void btnInventoryMenu_Click(object sender, EventArgs e)
        {
            InventoryMenu InventoryMenu = new InventoryMenu();
            InventoryMenu.Show();
            this.Close();
        }

        private void CheckForPartID_Load(object sender, EventArgs e)
        {
            try
            {
                //loading combo box
                cboSelectTable.Items.Add("Select Table");
                cboSelectTable.Items.Add("Warehouse Inventory");
                cboSelectTable.Items.Add("TWC Inventory");
                cboSelectTable.Items.Add("Receive Table");
                cboSelectTable.Items.Add("Issue Table");
                cboSelectTable.Items.Add("BOM Table");
                cboSelectTable.SelectedIndex = 0;

                //loading data
                ThePartNumberDataSet = ThePartNumberClass.GetPartNumbersInfo();
                TheWarehouseInventoryDataSet = TheInventoryClass.GetWarehouseInventoryInfo();
                TheInventoryDataSet = TheInventoryClass.GetInventoryInfo();
                TheReceivedPartsDataSet = TheReceivedMaterialClass.GetReceivedPartsInfo();
                TheIssuedPartsDataSet = TheIssuedPartsClass.GetIssuedPartsInfo();
                TheBOMPartsDataSet = TheBOMPartsClass.GetBOMPartsInfo();

                //loading counter variables
                gintPartUpperLimit = ThePartNumberDataSet.partnumbers.Rows.Count - 1;
                gintWarehouseUpperLimit = TheWarehouseInventoryDataSet.WarehouseInventory.Rows.Count - 1;
                gintInventoryUpperLimit = TheInventoryDataSet.Inventory.Rows.Count - 1;
                gintReceivedUpperLimit = TheReceivedPartsDataSet.ReceivedParts.Rows.Count - 1;
                gintIssuedUpperLimit = TheIssuedPartsDataSet.IssuedParts.Rows.Count - 1;
                gintBOMUpperLimit = TheBOMPartsDataSet.BOMParts.Rows.Count - 1;

            }
            catch (Exception Ex)
            {
                theMessagesClass.ErrorMessage(Ex.ToString());

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Check For Part ID Form Load " + Ex.Message);
            }
        }

        private void cboSelectTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboSelectTable.Text == "Warehouse Inventory")
            {
                ProcessWarehouseInventoryTable();
            }
            if(cboSelectTable.Text == "TWC Inventory")
            {
                ProcessInventoryTable();
            }
            if(cboSelectTable.Text == "Receive Table")
            {
                ProcessReceivedTable();
            }
            if(cboSelectTable.Text == "Issue Table")
            {
                ProcessIssuedTable();
            }
            if(cboSelectTable.Text == "BOM Table")
            {
                ProcessBOMTable();
            }
        }
        private void ProcessBOMTable()
        {
            int intPartCounter;
            int intBOMCounter;
            string strPartNumberForSearch;
            string strPartNumberFromTable;

            try
            {
                PleaseWait.Show();

                //first loop
                for (intBOMCounter = 0; intBOMCounter <= gintBOMUpperLimit; intBOMCounter++)
                {
                    //getting the part number
                    strPartNumberForSearch = TheBOMPartsDataSet.BOMParts[intBOMCounter].PartNumber;

                    //part loop
                    for (intPartCounter = 0; intPartCounter <= gintPartUpperLimit; intPartCounter++)
                    {
                        strPartNumberFromTable = ThePartNumberDataSet.partnumbers[intPartCounter].PartNumber;

                        //editing the row
                        if (strPartNumberFromTable == strPartNumberForSearch)
                        {
                            TheBOMPartsDataSet.BOMParts[intBOMCounter].PartID = ThePartNumberDataSet.partnumbers[intPartCounter].PartID;
                            TheBOMPartsDataSet.BOMParts[intBOMCounter].InternalProjectID = 0;
                            break;
                        }
                    }
                }

                TheBOMPartsClass.UpdateBOMPartsDB(TheBOMPartsDataSet);
            }
            catch (Exception Ex)
            {
                theMessagesClass.ErrorMessage(Ex.ToString());

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Check For Part ID Process BOM Table " + Ex.Message);
            }

            PleaseWait.Hide();
            theMessagesClass.InformationMessage("Process Complete");
        }
        private void ProcessIssuedTable()
        {
            int intPartCounter;
            int intIssueCounter;
            string strPartNumberForSearch;
            string strPartNumberFromTable;

            try
            {
                PleaseWait.Show();

                //first loop
                for (intIssueCounter = 0; intIssueCounter <= gintIssuedUpperLimit; intIssueCounter++)
                {
                    //getting the part number
                    strPartNumberForSearch = TheIssuedPartsDataSet.IssuedParts[intIssueCounter].PartNumber;

                    //part loop
                    for (intPartCounter = 0; intPartCounter <= gintPartUpperLimit; intPartCounter++)
                    {
                        strPartNumberFromTable = ThePartNumberDataSet.partnumbers[intPartCounter].PartNumber;

                        //editing the row
                        if (strPartNumberFromTable == strPartNumberForSearch)
                        {
                            TheIssuedPartsDataSet.IssuedParts[intIssueCounter].PartID = ThePartNumberDataSet.partnumbers[intPartCounter].PartID;
                            TheIssuedPartsDataSet.IssuedParts[intIssueCounter].EmployeeID = 0;
                            TheIssuedPartsDataSet.IssuedParts[intIssueCounter].InternalProjectID = 0;
                            break;
                        }
                    }
                }

                TheIssuedPartsClass.UpdateIssuedPartsDB(TheIssuedPartsDataSet);
            }
            catch (Exception Ex)
            {
                theMessagesClass.ErrorMessage(Ex.ToString());

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Check For Part ID Process Issued Table " + Ex.Message);
            }

            PleaseWait.Hide();
            theMessagesClass.InformationMessage("Process Complete");
        }
        private void ProcessReceivedTable()
        {
            int intPartCounter;
            int intReceivedCounter;
            string strPartNumberForSearch;
            string strPartNumberFromTable;

            try
            {
                PleaseWait.Show();

                //first loop
                for (intReceivedCounter = 0; intReceivedCounter <= gintReceivedUpperLimit; intReceivedCounter++)
                {
                    //getting the part number
                    strPartNumberForSearch = TheReceivedPartsDataSet.ReceivedParts[intReceivedCounter].PartNumber;

                    //part loop
                    for (intPartCounter = 0; intPartCounter <= gintPartUpperLimit; intPartCounter++)
                    {
                        strPartNumberFromTable = ThePartNumberDataSet.partnumbers[intPartCounter].PartNumber;

                        //editing the row
                        if (strPartNumberFromTable == strPartNumberForSearch)
                        {
                            TheReceivedPartsDataSet.ReceivedParts[intReceivedCounter].PartID = ThePartNumberDataSet.partnumbers[intPartCounter].PartID;
                            TheReceivedPartsDataSet.ReceivedParts[intReceivedCounter].InternalProjectID = 0;
                            TheReceivedPartsDataSet.ReceivedParts[intReceivedCounter].EmployeeID = 0;
                            break;
                        }
                    }
                }

                TheReceivedMaterialClass.UpdateReceivedPartsDB(TheReceivedPartsDataSet);
            }
            catch (Exception Ex)
            {
                theMessagesClass.ErrorMessage(Ex.ToString());

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Check For Part ID Process Recieved Table " + Ex.Message);
            }

            PleaseWait.Hide();
            theMessagesClass.InformationMessage("Process Complete");
        }
        private void ProcessInventoryTable()
        {
            int intPartCounter;
            int intInventoryCounter;
            string strPartNumberForSearch;
            string strPartNumberFromTable;

            try
            {
                PleaseWait.Show();

                //first loop
                for (intInventoryCounter = 0; intInventoryCounter <= gintInventoryUpperLimit; intInventoryCounter++)
                {
                    //getting the part number
                    strPartNumberForSearch = TheInventoryDataSet.Inventory[intInventoryCounter].PartNumber;

                    //part loop
                    for (intPartCounter = 0; intPartCounter <= gintPartUpperLimit; intPartCounter++)
                    {
                        strPartNumberFromTable = ThePartNumberDataSet.partnumbers[intPartCounter].PartNumber;

                        //editing the row
                        if (strPartNumberFromTable == strPartNumberForSearch)
                        {
                            TheInventoryDataSet.Inventory[intInventoryCounter].TablePartID = ThePartNumberDataSet.partnumbers[intPartCounter].PartID;
                            TheInventoryDataSet.Inventory[intInventoryCounter].PartDescription = ThePartNumberDataSet.partnumbers[intPartCounter].Description;
                            break;
                        }
                    }
                }

                TheInventoryClass.UpdateInventoryDB(TheInventoryDataSet);
            }
            catch (Exception Ex)
            {
                theMessagesClass.ErrorMessage(Ex.ToString());

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Check For Part ID Process Inventory Table " + Ex.Message);
            }

            PleaseWait.Hide();
            theMessagesClass.InformationMessage("Process Complete");
        }
        private void ProcessWarehouseInventoryTable()
        {
            int intPartCounter;
            int intInventoryCounter;
            string strPartNumberForSearch;
            string strPartNumberFromTable;
            
            try
            {
                PleaseWait.Show();
                 
                //first loop
                for (intInventoryCounter = 0; intInventoryCounter <= gintWarehouseUpperLimit; intInventoryCounter++)
                {
                    //getting the part number
                    strPartNumberForSearch = TheWarehouseInventoryDataSet.WarehouseInventory[intInventoryCounter].PartNumber;

                    //part loop
                    for(intPartCounter = 0; intPartCounter <= gintPartUpperLimit; intPartCounter++)
                    {
                        strPartNumberFromTable = ThePartNumberDataSet.partnumbers[intPartCounter].PartNumber;

                        //editing the row
                        if(strPartNumberFromTable == strPartNumberForSearch)
                        {
                            TheWarehouseInventoryDataSet.WarehouseInventory[intInventoryCounter].TablePartID = ThePartNumberDataSet.partnumbers[intPartCounter].PartID;
                            TheWarehouseInventoryDataSet.WarehouseInventory[intInventoryCounter].PartDescription = ThePartNumberDataSet.partnumbers[intPartCounter].Description;
                            TheWarehouseInventoryDataSet.WarehouseInventory[intInventoryCounter].Max = 0;
                            TheWarehouseInventoryDataSet.WarehouseInventory[intInventoryCounter].Min = 0;
                            break;
                        }
                    }
                }

                TheInventoryClass.UpdateWarehouseInventoryDB(TheWarehouseInventoryDataSet);
            }
            catch (Exception Ex)
            {
                theMessagesClass.ErrorMessage(Ex.ToString());

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Check For Part ID Process Warehouse Inventory Table " + Ex.Message);
            }

            PleaseWait.Hide();
            theMessagesClass.InformationMessage("Process Complete");
        }
    }
}
