/* Title:           Remove Part Numbers
 * Date:            11-20-16
 * Author:          Terry Holmes
 * 
 * Description:     This form will remove the selected part numbers */

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
using NewEventLogDLL;

namespace WhseTrack
{
    public partial class RemovePartNumbers : Form
    {
        //setting up the classes
        PartNumberClass ThePartNumberClass = new PartNumberClass();
        EventLogClass TheEventLogClass = new EventLogClass();
        MessagesClass TheMessagesClass = new MessagesClass();
        PleaseWait PleaseWait = new PleaseWait();

        PartNumbersDataSet ThePartNumberDataSet;
        RemovePartNumbersDataSet TheRemovePartNumbersDataSet = new RemovePartNumbersDataSet();

        int gintPartUpperLimit;

        public RemovePartNumbers()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //closing the program
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

        private void btnUtilitiesMenu_Click(object sender, EventArgs e)
        {
            UtilitiesMenu UtilitiesMenu = new UtilitiesMenu();
            UtilitiesMenu.Show();
            this.Close();
        }

        private void RemovePartNumbers_Load(object sender, EventArgs e)
        {
            FillRemovePartsDataSet();
        }
        private void FillRemovePartsDataSet()
        {
            //setting local variables
            int intCounter;
            bool blnNotTWCPart;

            try
            {
                TheRemovePartNumbersDataSet.removeparts.Rows.Clear();

                //loading the part number set
                ThePartNumberDataSet = ThePartNumberClass.GetPartNumbersInfo();

                //getting the upper limit
                gintPartUpperLimit = ThePartNumberDataSet.partnumbers.Rows.Count - 1;

                //beginning the loop
                for (intCounter = 0; intCounter <= gintPartUpperLimit; intCounter++)
                {
                    blnNotTWCPart = ThePartNumberClass.CheckTimeWarnerPart(ThePartNumberDataSet.partnumbers[intCounter].PartNumber);

                    if (blnNotTWCPart == true)
                    {
                        RemovePartNumbersDataSet.removepartsRow NewTableRow = TheRemovePartNumbersDataSet.removeparts.NewremovepartsRow();

                        NewTableRow.Description = ThePartNumberDataSet.partnumbers[intCounter].Description;
                        NewTableRow.JDEPartNumber = ThePartNumberDataSet.partnumbers[intCounter].JDEPartNumber;
                        NewTableRow.PartID = ThePartNumberDataSet.partnumbers[intCounter].PartID;
                        NewTableRow.PartNumber = ThePartNumberDataSet.partnumbers[intCounter].PartNumber;
                        NewTableRow.Select = false;

                        TheRemovePartNumbersDataSet.removeparts.Rows.Add(NewTableRow);
                    }
                }

                dgvParts.DataSource = TheRemovePartNumbersDataSet.removeparts;
            }
            catch (Exception Ex)
            {
                TheMessagesClass.ErrorMessage(Ex.ToString());

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Remove Part Numbers Form Load " + Ex.Message);
            }
        }
        private void btnProcess_Click(object sender, EventArgs e)
        {
            int intCounter;
            int intNumberOfRecords;
            int intPartCounter;
            int intPartIDForSearch;

            PleaseWait.Show();

            gintPartUpperLimit = ThePartNumberDataSet.partnumbers.Rows.Count - 1;

            //getting ready for the loop
            intNumberOfRecords = TheRemovePartNumbersDataSet.removeparts.Rows.Count - 1;

            for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
            {
                if(TheRemovePartNumbersDataSet.removeparts[intCounter].Select == true)
                {
                    intPartIDForSearch = TheRemovePartNumbersDataSet.removeparts[intCounter].PartID;

                    //second counter
                    for(intPartCounter = 0; intPartCounter <= gintPartUpperLimit; intPartCounter++)
                    {
                        if(intPartIDForSearch == ThePartNumberDataSet.partnumbers[intPartCounter].PartID)
                        {
                            ThePartNumberDataSet.partnumbers.Rows[intPartCounter].Delete();
                            ThePartNumberClass.UpdatePartNumbersDB(ThePartNumberDataSet);
                            gintPartUpperLimit--;
                            break;
                        }
                    }
                }
            }

            FillRemovePartsDataSet();

            PleaseWait.Hide();
        }
    }
}
