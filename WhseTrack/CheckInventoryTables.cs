/* Title:       Check Inventory Tables
 * Date:        11-21-16
 * Author:      Terry Holmes
 * 
 * Description: This form is used to check the inventory tables */

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
using BOMPartsDLL;
using ReceivedMaterialDLL;
using IssuedPartsDLL;
using NewEventLogDLL;
using PartNumberDLL;

namespace WhseTrack
{
    public partial class CheckInventoryTables : Form
    {
        //setting up the classes
        MessagesClass TheMessagesClass = new MessagesClass();
        InventoryClass TheInventoryClass = new InventoryClass();
        BOMPartsClass TheBOMPartsClass = new BOMPartsClass();
        ReceivedMaterialClass TheReceivedMaterialClass = new ReceivedMaterialClass();
        IssuedPartsClass TheIssuedPartsClass = new IssuedPartsClass();
        EventLogClass TheEventLogClass = new EventLogClass();
        PartNumberClass ThePartNumberClass = new PartNumberClass();

        //setting up the data
        PartNumbersDataSet ThePartNumberDataSet;
        WarehouseInventoryDataSet TheWarehouseInventoryDataSet;
        WarehouseInventoryDataSet TheSortedWarehouseInventoryDataSet = new WarehouseInventoryDataSet();
        InventoryDataSet TheInventoryDataSet;
        InventoryDataSet TheSortedInventoryDataSet = new InventoryDataSet();
        IssuedPartsDataSet TheIssuedPartsDataSet;
        IssuedPartsDataSet TheSortedIssuedPartsDataSet = new IssuedPartsDataSet();
        ReceivedPartsDataSet TheReceivedPartsDataSet;
        ReceivedPartsDataSet TheSortedReceivedPartsDataSet = new ReceivedPartsDataSet();
        BOMPartsDataSet TheBOMPartsDataSet;
        BOMPartsDataSet TheSortedBOMPartsDataSet = new BOMPartsDataSet();
        PleaseWait PleaseWait = new PleaseWait();

        //setting global variables
        int gintPartUpperLimit;
        int gintWarehouseInventoryUpperLimit;
        int gintInventoryUpperLimit;
        int gintIssuedUpperLimit;
        int gintReceivedUpperLimit;
        int gintBOMUpperLimit;

        public CheckInventoryTables()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //this will close the program'
            TheMessagesClass.CloseTheProgram();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            MainMenu MainMenu = new MainMenu();
            MainMenu.Show();
            this.Close();
        }

        private void btnAdminMenu_Click(object sender, EventArgs e)
        {
            AdminMenu AdminMenu = new AdminMenu();
            AdminMenu.Show();
            this.Close();
        }

        private void btnUtilityMenu_Click(object sender, EventArgs e)
        {
            UtilitiesMenu UtilitiesMenu = new UtilitiesMenu();
            UtilitiesMenu.Show();
            this.Close();
        }

        private void CheckInventoryTables_Load(object sender, EventArgs e)
        {
            //this will load the data sets
            try
            {
                PleaseWait.Show();

                btnProcess.Enabled = false;

                cboSelectTable.Items.Add("Select Table");

                ThePartNumberDataSet = ThePartNumberClass.GetPartNumbersInfo();

                gintPartUpperLimit = ThePartNumberDataSet.partnumbers.Rows.Count - 1;

                TheWarehouseInventoryDataSet = TheInventoryClass.GetWarehouseInventoryInfo();

                gintWarehouseInventoryUpperLimit = TheWarehouseInventoryDataSet.WarehouseInventory.Rows.Count - 1;

                cboSelectTable.Items.Add("Warehouse Inventory");

                TheInventoryDataSet = TheInventoryClass.GetInventoryInfo();

                gintInventoryUpperLimit = TheInventoryDataSet.Inventory.Rows.Count - 1;

                cboSelectTable.Items.Add("Inventory");

                TheReceivedPartsDataSet = TheReceivedMaterialClass.GetReceivedPartsInfo();

                gintReceivedUpperLimit = TheReceivedPartsDataSet.ReceivedParts.Rows.Count - 1;

                cboSelectTable.Items.Add("Received Parts");

                TheIssuedPartsDataSet = TheIssuedPartsClass.GetIssuedPartsInfo();

                gintIssuedUpperLimit = TheIssuedPartsDataSet.IssuedParts.Rows.Count - 1;

                cboSelectTable.Items.Add("Issued Parts");

                TheBOMPartsDataSet = TheBOMPartsClass.GetBOMPartsInfo();

                gintBOMUpperLimit = TheBOMPartsDataSet.BOMParts.Rows.Count - 1;

                cboSelectTable.Items.Add("BOM Parts");

                cboSelectTable.SelectedIndex = 0;

                PleaseWait.Hide();
            }
            catch (Exception Ex)
            {
                TheMessagesClass.ErrorMessage(Ex.ToString());

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Check Inventory Tables Form Load " + Ex.Message);
            }
        }

        private void cboSelectTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            //setitng local variables
            int intCounter;
            string strPartDescription;
            int intPartID;
            int intRecordCount = 0;

            try
            {
                if (cboSelectTable.Text != "Select Table")
                {
                    if (cboSelectTable.Text == "Warehouse Inventory")
                    {
                        //clearing the data set
                        TheSortedWarehouseInventoryDataSet.WarehouseInventory.Rows.Clear();
                        
                        //beginning loop
                        for (intCounter = 0; intCounter <= gintWarehouseInventoryUpperLimit; intCounter++)
                        {
                            if (TheWarehouseInventoryDataSet.WarehouseInventory[intCounter].IsTablePartIDNull())
                            {
                                intPartID = -1;

                                if(TheWarehouseInventoryDataSet.WarehouseInventory[intCounter].IsPartDescriptionNull())
                                {
                                    strPartDescription = "NOT ENTERED";
                                }
                                else
                                {
                                    strPartDescription = TheWarehouseInventoryDataSet.WarehouseInventory[intCounter].PartDescription;
                                }

                                WarehouseInventoryDataSet.WarehouseInventoryRow NewTableRow = TheSortedWarehouseInventoryDataSet.WarehouseInventory.NewWarehouseInventoryRow();

                                NewTableRow.Max = TheWarehouseInventoryDataSet.WarehouseInventory[intCounter].Max;
                                NewTableRow.Min = TheWarehouseInventoryDataSet.WarehouseInventory[intCounter].Min;
                                NewTableRow.PartDescription = strPartDescription;
                                NewTableRow.PartID = TheWarehouseInventoryDataSet.WarehouseInventory[intCounter].PartID;
                                NewTableRow.PartNumber = TheWarehouseInventoryDataSet.WarehouseInventory[intCounter].PartNumber;
                                NewTableRow.QTYOnHand = TheWarehouseInventoryDataSet.WarehouseInventory[intCounter].QTYOnHand;
                                NewTableRow.TablePartID = intPartID;
                                NewTableRow.WarehouseID = TheWarehouseInventoryDataSet.WarehouseInventory[intCounter].WarehouseID;

                                TheSortedWarehouseInventoryDataSet.WarehouseInventory.Rows.Add(NewTableRow);
                            }
                        }

                        intRecordCount = TheSortedWarehouseInventoryDataSet.WarehouseInventory.Rows.Count;

                        

                        dgvResults.DataSource = TheSortedWarehouseInventoryDataSet.WarehouseInventory;
                    }


                }

                if (intRecordCount > 0)
                {
                    btnProcess.Enabled = true;
                }
            }
            catch (Exception Ex)
            {
                TheMessagesClass.ErrorMessage(Ex.ToString());

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Check Inventory Table Selected Table Combo box " + Ex.Message);
            }

            
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            
        }
    }
}
