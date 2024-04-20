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
using EventLogDLL;

namespace WhseTrack
{
    public partial class AdjustInventory : Form
    {
        //setting up the classes
        MessagesClass TheMessagesClass = new MessagesClass();
        InventoryClass TheInventoryClass = new InventoryClass();
        PartNumberClass ThePartNumberClass = new PartNumberClass();
        EventLogClass TheEventLogClass = new EventLogClass();

        AdjustInventoryDataSet TheAdjustInventoryDataSet;
        PartSearchDataSet ThePartSearhDataSet = new PartSearchDataSet();
        PartNumbersDataSet TheSortedPartNumbersDataSet = new PartNumbersDataSet();

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
            //setting local variables
            int intRecordsReturned;
            string strPartDescription;
            string strPartNumber;
            int intCounter;
            int intPartIDForSearch = 0;
            bool blnItemFound = false;
            int intPartCounter;

            try
            {
                //clearing the data set
                TheSortedPartNumbersDataSet.partnumbers.Rows.Clear();

                strPartDescription = "%" + txtPartNumber.Text + "%";
                strPartNumber = txtPartNumber.Text;

                gintPartCounter = 0;
                gintPartUpperLimit = 0;

                TheSortedPartNumbersDataSet = ThePartNumberClass.GetPartByPartNumber(strPartNumber);

                intRecordsReturned = TheSortedPartNumbersDataSet.partnumbers.Rows.Count - 1;

                if(intRecordsReturned == -1)
                {
                    TheSortedPartNumbersDataSet = ThePartNumberClass.GetPartNumberByDescriptionKey(strPartDescription);
                }

                if(intRecordsReturned > -1)
                {
                    for (intCounter = 0; intCounter <= intRecordsReturned; intCounter++)
                    {
                        blnItemFound = false;
                        intPartIDForSearch = TheSortedPartNumbersDataSet.partnumbers[intCounter].PartID;

                        if(gintPartCounter > 0)
                        {
                            for(intPartCounter = 0; intPartCounter <= gintPartUpperLimit; intPartCounter++)
                            {
                                if(intPartIDForSearch == ThePartSearhDataSet.parts[intPartCounter].PartID)
                                {
                                    blnItemFound = true;
                                }
                            }
                        }

                        if(blnItemFound == false)
                        {
                            PartSearchDataSet.partsRow NewPartRow = ThePartSearhDataSet.parts.NewpartsRow();

                            NewPartRow.Description = TheSortedPartNumbersDataSet.partnumbers[intCounter].Description;
                            NewPartRow.PartID = TheSortedPartNumbersDataSet.partnumbers[intCounter].PartID;
                            NewPartRow.PartNumber = TheSortedPartNumbersDataSet.partnumbers[intCounter].PartNumber;
                            NewPartRow.TWCPart = TheSortedPartNumbersDataSet.partnumbers[intCounter].TimeWarnerPart;

                            ThePartSearhDataSet.parts.Rows.Add(NewPartRow);
                        }
                    }
                }


                dgvParts.DataSource = ThePartSearhDataSet.parts;
            }
            catch(Exception Ex)
            {
                TheEventLogClass.CreateEventLogEntry("Whse Track Adjust Inventory Part Number Text Change Event " + Ex.Message);
            }
        }

        private void dgvParts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
