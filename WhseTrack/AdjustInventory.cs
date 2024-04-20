/* Title:           Adjust Inventory
 * Date:            12-20-16
 * Author:          Terry Holmes
 * 
 * Description:     This form is used for Inventory Adjustment*/

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
using PartNumberDLL;
using NewEventLogDLL;
using DataValidationDLL;
using CreateIDDLL;

namespace WhseTrack
{
    public partial class AdjustInventory : Form
    {
        //setting up the classes
        MessagesClass TheMessagesClass = new MessagesClass();
        InventoryClass TheInventoryClass = new InventoryClass();
        PartNumberClass ThePartNumberClass = new PartNumberClass();
        EventLogClass TheEventLogClass = new EventLogClass();
        PleaseWait PleaseWait = new PleaseWait();
        DataValidationClass TheDataValidationClass = new DataValidationClass();
        CreateIDClass TheCreateIDClass = new CreateIDClass();

        AdjustInventoryDataSet TheAdjustInventoryDataSet;
        PartSearchDataSet ThePartSearchDataSet = new PartSearchDataSet();
        PartSearchDataSet TheSortedPartSearchDataSet = new PartSearchDataSet();
        PartNumbersDataSet TheSortedPartNumbersDataSet = new PartNumbersDataSet();
        WarehouseInventoryDataSet TheSortedWarehouseInventoryDataSet;
        WarehouseInventoryDataSet TheWarehouseInventoryDataSet;

        int gintWarehouseNumberOfRecords;
        int gintPartID;
        int gintWarehouseID;
        int gintTransactionID;

        //setting global variables
        int gintPartCounter;
        int gintPartUpperLimit;
        
        public AdjustInventory()
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

        private void txtPartNumber_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvParts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void AdjustInventory_Load(object sender, EventArgs e)
        {
            int intWarehouseCounter;
            int intRecordsReturned;

            PleaseWait.Show();

            try
            {
                TheWarehouseInventoryDataSet = TheInventoryClass.GetWarehouseInventoryInfo();

                TheSortedWarehouseInventoryDataSet = TheInventoryClass.GetWarehouseInventoryByWarehouseID(gintWarehouseID);

                gintWarehouseNumberOfRecords = TheSortedWarehouseInventoryDataSet.WarehouseInventory.Rows.Count - 1;

                TheAdjustInventoryDataSet = TheInventoryClass.GetAdjustInventoryInfo();

                for(intWarehouseCounter = 0; intWarehouseCounter <= gintWarehouseNumberOfRecords; intWarehouseCounter++)
                {
                    if(TheSortedWarehouseInventoryDataSet.WarehouseInventory[intWarehouseCounter].IsTablePartIDNull() == false)
                    {
                        TheSortedPartNumbersDataSet = ThePartNumberClass.GetPartNumberByPartID(TheSortedWarehouseInventoryDataSet.WarehouseInventory[intWarehouseCounter].TablePartID);

                        intRecordsReturned = TheSortedPartNumbersDataSet.partnumbers.Rows.Count;

                        if(intRecordsReturned > 0)
                        {
                            PartSearchDataSet.partsRow NewPartRow = ThePartSearchDataSet.parts.NewpartsRow();

                            NewPartRow.TransactionID = TheSortedWarehouseInventoryDataSet.WarehouseInventory[intWarehouseCounter].PartID;
                            NewPartRow.Description = TheSortedPartNumbersDataSet.partnumbers[0].Description;
                            NewPartRow.PartID = TheSortedPartNumbersDataSet.partnumbers[0].PartID;
                            NewPartRow.PartNumber = TheSortedPartNumbersDataSet.partnumbers[0].PartNumber;
                            NewPartRow.Quantity = TheSortedWarehouseInventoryDataSet.WarehouseInventory[intWarehouseCounter].QTYOnHand;
                            NewPartRow.TWCPart = TheSortedPartNumbersDataSet.partnumbers[0].JDEPartNumber;

                            ThePartSearchDataSet.parts.Rows.Add(NewPartRow);
                        }
                    }
                }

                dgvParts.DataSource = ThePartSearchDataSet.parts;
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Adjust Inventory Form Load " + Ex.Message);

                TheMessagesClass.ErrorMessage(Ex.ToString());
            }

            PleaseWait.Hide();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            //setting local variables
            int intPartCounter;
            int intPartNumberOfRecords;
            string strPartNumber;
            bool blnItemNotFound = true;

            try
            {
                //clearing the data set
                TheSortedPartSearchDataSet.parts.Rows.Clear();

                //getting ready for the loop
                intPartNumberOfRecords = ThePartSearchDataSet.parts.Rows.Count - 1;

                //getting the part number
                strPartNumber = txtPartNumber.Text;

                if (strPartNumber == "")
                {
                    TheMessagesClass.ErrorMessage("The Part Number Was Not Found");
                    return;
                }

                //loop
                for (intPartCounter = 0; intPartCounter <= intPartNumberOfRecords; intPartCounter++)
                {
                    if (strPartNumber == ThePartSearchDataSet.parts[intPartCounter].PartNumber)
                    {
                        txtQuantityOnHand.Text = Convert.ToString(ThePartSearchDataSet.parts[intPartCounter].Quantity);
                        gintPartID = ThePartSearchDataSet.parts[intPartCounter].PartID;
                        gintTransactionID = ThePartSearchDataSet.parts[intPartCounter].TransactionID;
                        blnItemNotFound = false;
                        break;
                    }
                }

                if(blnItemNotFound == true)
                {
                    TheMessagesClass.InformationMessage("The Part Number Was Not Found");
                }
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Adjust Inventory Part Number Text Change Event " + Ex.Message);

                TheMessagesClass.ErrorMessage(Ex.ToString());
            }
        }

        private void btnProcessAdjustment_Click(object sender, EventArgs e)
        {
            //setting local variables
            int intCounter;
            int intNumberOfRecords;
            int intQuantity;
            string strValueForValidation;
            bool blnFatalError;
            int intQuantityOnHand;

            PleaseWait.Show();

            try
            {
                //data validation
                strValueForValidation = txtNewQuantity.Text;
                blnFatalError = TheDataValidationClass.VerifyIntegerData(strValueForValidation);
                if(blnFatalError == true)
                {
                    TheMessagesClass.ErrorMessage("The Quantity Entered is not an Integer");
                    return;
                }
                else
                {
                    intQuantity = Convert.ToInt32(strValueForValidation);
                }

                //getting ready for the loop
                intNumberOfRecords = TheWarehouseInventoryDataSet.WarehouseInventory.Rows.Count - 1;

                for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    if(gintTransactionID == TheWarehouseInventoryDataSet.WarehouseInventory[intCounter].PartID)
                    {
                        intQuantityOnHand = TheWarehouseInventoryDataSet.WarehouseInventory[intCounter].QTYOnHand;
                        TheWarehouseInventoryDataSet.WarehouseInventory[intCounter].QTYOnHand = intQuantity;
                        TheInventoryClass.UpdateWarehouseInventoryDB(TheWarehouseInventoryDataSet);

                        AdjustInventoryDataSet.adjustinventoryRow NewTableRow = TheAdjustInventoryDataSet.adjustinventory.NewadjustinventoryRow();

                        NewTableRow.Date = DateTime.Now;
                        NewTableRow.EmployeeID = Logon.TheVerifyLogonDataSet.VerifyLogon[0].EmployeeID;
                        NewTableRow.PartID = gintPartID;
                        NewTableRow.PartNumber = TheWarehouseInventoryDataSet.WarehouseInventory[intCounter].PartNumber;
                        NewTableRow.Quantity = intQuantityOnHand;
                        NewTableRow.Reason = "CYCLE COUNT";
                        NewTableRow.TransactionID = TheCreateIDClass.CreateInventoryID();
                        NewTableRow.WarehouseID = gintWarehouseID;

                        TheAdjustInventoryDataSet.adjustinventory.Rows.Add(NewTableRow);
                        TheInventoryClass.UpdateAdjustInventoryDB(TheAdjustInventoryDataSet);
                    }
                }

                TheMessagesClass.InformationMessage("Part Is Updated");
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Adjust Inventory Process Button " + Ex.Message);

                TheMessagesClass.ErrorMessage(Ex.ToString());
            }

            PleaseWait.Hide();
        }
    }
}
