/* Title:           Select Warehouse
 * Date:            11-6-16
 * Author:          Terry Holmes
 * 
 * Decription:      This will allow the user to select the warehouse */

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


namespace WhseTrack
{
    public partial class SelectWarehouse : Form
    {
        //setting up the classes
        MessagesClass TheMessagesClass = new MessagesClass();
        EventLogClass TheEventLogClass = new EventLogClass();

        public SelectWarehouse()
        {
            InitializeComponent();
        }

        private void SelectWarehouse_Load(object sender, EventArgs e)
        {
            //setting local variables
            int intCounter;
            int intNumberOfRecords;

            try
            {
                cboSelectWarehouse.Items.Add("SELECT WAREHOUSE");

                //setting up the loop
                intNumberOfRecords = Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses.Rows.Count - 1;

                for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    cboSelectWarehouse.Items.Add(Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses[intCounter].FirstName);
                }

                cboSelectWarehouse.SelectedIndex = 0;
            }
            catch (Exception Ex)
            {
                TheMessagesClass.ErrorMessage(Ex.ToString());

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Select Warehouse Form Load " + Ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //this will close the program
            TheMessagesClass.CloseTheProgram();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //this will display the main menu
            MainMenu MainMenu = new MainMenu();
            MainMenu.Show();
            this.Close();
        }

        private void cboSelectWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this will load the selected warehouse int the data set
            int intCounter;
            int intNumberOfRecords;

            if(cboSelectWarehouse.Text != "SELECT WAREHOUSE")
            {
                intNumberOfRecords = Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses.Rows.Count - 1;

                for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    if (cboSelectWarehouse.Text == Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses[intCounter].FirstName)
                    {
                        Logon.gintWarehouseID = Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses[intCounter].EmployeeID;
                        Logon.gstrWarehouseName = Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses[intCounter].FirstName;
                        break;
                    }
                }

                TheMessagesClass.InformationMessage("You Have Selected The " + Logon.gstrWarehouseName + " Warehouse");

                btnContinue.PerformClick();
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (cboSelectWarehouse.Text != "SELECT WAREHOUSE")
            {
                if(Logon.gstrMenuSelector != "DATAENTRY")
                {
                    InventoryMenu InventoryMenu = new WhseTrack.InventoryMenu();
                    InventoryMenu.Show();
                }

                this.Close();
            }
            else
            {
                TheMessagesClass.ErrorMessage("You Have Not Selected a Warehouse");
            }

        }
    }
}
