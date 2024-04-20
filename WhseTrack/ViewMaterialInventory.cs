/* Title:           View Material Inventory
 * Date:            11-12-16
 * Name:            Terry Holmes
 * 
 * Description:     This form is used to view material inventory */

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
using PartNumberDLL;
using NewEventLogDLL;

namespace WhseTrack
{
    public partial class ViewMaterialInventory : Form
    {
        //setting up the class
        MessagesClass TheMessagesClass = new MessagesClass();
        InventoryClass TheInventoryClass = new InventoryClass();
        KeyWordClass TheKeyWordClass = new KeyWordClass();
        PartNumberClass ThePartNumberClass = new PartNumberClass();
        PleaseWait PleaseWait = new PleaseWait();
        EventLogClass TheEventLogClass = new EventLogClass();

        //adding data
        WarehouseInventoryDataSet TheWarehouseInventoryDataSet;
        CompleteInventoryDataSet TheCompleteInventoryDataSet = new CompleteInventoryDataSet();
        PartNumbersDataSet ThePartNumbersDataSet = new PartNumbersDataSet();

        //setting global variables
        int gintPartUpperLimit;
        string gstrErrorMessage;
        int gintInventoryUpperLimit;
        int gintWarehouseUpperLimit;
        int gintWarehouseID;

        public ViewMaterialInventory()
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

        private void btnInventoryMenu_Click(object sender, EventArgs e)
        {
            InventoryMenu InventoryMenu = new InventoryMenu();
            InventoryMenu.Show();
            this.Close();
        }

        private void ViewMaterialInventory_Load(object sender, EventArgs e)
        {
            //setting local variable
            bool blnFatalError = false;
            int intCounter;
            int intNumberOfRecords;

            PleaseWait.Show();

            //filling data sets
            blnFatalError = LoadPartNumberDataSet();
            if (blnFatalError == false)
                blnFatalError = LoadInventoryDataSet();

            dgvInventory.DataSource = TheCompleteInventoryDataSet.completeinventory;

            cboSelectWarehouse.Items.Add("Select Warehouse");

            intNumberOfRecords = Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses.Rows.Count - 1;

            for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
            {
                cboSelectWarehouse.Items.Add(Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses[intCounter].FirstName);
            }

            cboSelectWarehouse.SelectedIndex = 0;

            PleaseWait.Hide();

            if(blnFatalError == true)
            {
                TheMessagesClass.ErrorMessage(gstrErrorMessage);
            }
        }
        private bool LoadInventoryDataSet()
        {
            //setting local variables
            bool blnFatalError = false;
            int intCounter;
            int intNumberOfRecords;
            int intPartID;
            int intQuantityOnHand = 0;
            string strPartNumber = "";
            int intRecordsReturned;

            try
            {
                //loading the data set
                TheWarehouseInventoryDataSet = TheInventoryClass.GetWarehouseInventoryInfo();
                TheWarehouseInventoryDataSet = TheInventoryClass.GetWarehouseInventoryByWarehouseID(gintWarehouseID);

                //getting the record count
                intNumberOfRecords = TheWarehouseInventoryDataSet.WarehouseInventory.Rows.Count - 1;

                //for loop
                for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    intQuantityOnHand = 0;

                    if(TheWarehouseInventoryDataSet.WarehouseInventory[intCounter].IsTablePartIDNull() == false)
                    {
                        intPartID = TheWarehouseInventoryDataSet.WarehouseInventory[intCounter].TablePartID;
                        intQuantityOnHand = TheWarehouseInventoryDataSet.WarehouseInventory[intCounter].QTYOnHand;

                        ThePartNumbersDataSet = ThePartNumberClass.GetPartNumberByPartID(intPartID);

                        intRecordsReturned = ThePartNumbersDataSet.partnumbers.Rows.Count;

                        if(intRecordsReturned == 1)
                        {
                            strPartNumber = ThePartNumbersDataSet.partnumbers[0].PartNumber;

                            CompleteInventoryDataSet.completeinventoryRow NewTableRow = TheCompleteInventoryDataSet.completeinventory.NewcompleteinventoryRow();

                            NewTableRow.Description = ThePartNumbersDataSet.partnumbers[0].Description;
                            NewTableRow.JDEPartNumber = ThePartNumbersDataSet.partnumbers[0].JDEPartNumber;
                            NewTableRow.PartID = intPartID;
                            NewTableRow.PartNumber = strPartNumber;
                            NewTableRow.QTYOnHand = intQuantityOnHand;

                            TheCompleteInventoryDataSet.completeinventory.Rows.Add(NewTableRow);
                        }
                    }
                }

                dgvInventory.DataSource = TheCompleteInventoryDataSet.completeinventory;
                
            }
            catch (Exception Ex)
            {
                //event log entry
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track View Material Inventory Load Inventory Data Set " + Ex.Message);

                //message for the user
                gstrErrorMessage = Ex.ToString();

                //setting flag
                blnFatalError = true;
            }

            return blnFatalError;
        }
        private bool LoadPartNumberDataSet()
        {
            //setting local variables
            bool blnFatalError = false;

            try
            {
                //filling the data set
                ThePartNumbersDataSet = ThePartNumberClass.GetPartNumbersInfo();

                //getting the warehouse id
                gintWarehouseID = Logon.gintWarehouseID;

                //setting the count
                gintPartUpperLimit = ThePartNumbersDataSet.partnumbers.Rows.Count - 1;
            }
            catch (Exception Ex)
            {
                //event log entry
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track View Material Inventory Load Part Number Data Set " + Ex.Message);

                //message for the user
                gstrErrorMessage = Ex.ToString();

                //setting flag
                blnFatalError = true;
            }

            //returning value
            return blnFatalError;
        }

        private void cboSelectWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this will load the selected warehouse int the data set
            int intCounter;
            int intNumberOfRecords;

            if (cboSelectWarehouse.Text != "SELECT WAREHOUSE")
            {
                PleaseWait.Show();

                TheCompleteInventoryDataSet.completeinventory.Rows.Clear();

                intNumberOfRecords = Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses.Rows.Count - 1;

                for (intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    if (cboSelectWarehouse.Text == Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses[intCounter].FirstName)
                    {
                        gintWarehouseID = Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses[intCounter].EmployeeID;
                        LoadInventoryDataSet();
                        break;
                    }
                }

                PleaseWait.Hide();
            }
        }
    }
}
