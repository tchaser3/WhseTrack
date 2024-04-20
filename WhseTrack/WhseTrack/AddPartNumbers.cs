/* Title:           Add Part Numbers
 * Date:            11-19-16
 * Author:          Terry Holmes
 * 
 * Description:     This form is where part numbers will be added */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EventLogDLL;
using PartNumberDLL;

namespace WhseTrack
{
    public partial class AddPartNumbers : Form
    {
        //adding the class
        MessagesClass TheMessagesClass = new MessagesClass();
        EventLogClass TheEventLogClass = new EventLogClass();
        PartNumberClass ThePartNumberClass = new PartNumberClass();
        PleaseWait PleaseWait = new PleaseWait();

        //setting up the data set
        PartNumbersDataSet ThePartNumberDataSet;
        PartNumbersDataSet TheSortedPartNumbersDataSet = new PartNumbersDataSet();

        public AddPartNumbers()
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

        private void btnAdminMenu_Click(object sender, EventArgs e)
        {
            AdminMenu AdminMenu = new AdminMenu();
            AdminMenu.Show();
            this.Close();
        }

        private void AddPartNumbers_Load(object sender, EventArgs e)
        {
            int intCounter;
            int intNumberOfRecords;
            bool blnNotTimeWarner;

            try
            {
                PleaseWait.Show();

                ThePartNumberDataSet = ThePartNumberClass.GetPartNumbersInfo();
 
            }
            catch (Exception Ex)
            {
                TheMessagesClass.ErrorMessage(Ex.ToString());

                TheEventLogClass.CreateEventLogEntry("Whse Track Add Part Numbers Form Load " + Ex.Message);
            }

            PleaseWait.Hide();
        }

        private void txtPartNumber_TextChanged(object sender, EventArgs e)
        {
            //setting local variables
            int intRecordsReturned;
            string strPartDescription;

            try
            {
                //clearing the data set
                TheSortedPartNumbersDataSet.partnumbers.Rows.Clear();

                strPartDescription = "%" + txtPartNumber.Text + "%";

                TheSortedPartNumbersDataSet = ThePartNumberClass.GetPartNumberByDescriptionKey(strPartDescription);

                dgvParts.DataSource = TheSortedPartNumbersDataSet.partnumbers;
            }
            catch (Exception Ex)
            {
                TheEventLogClass.CreateEventLogEntry("Whse Track Adjust Inventory Part Number Text Change Event " + Ex.Message);
            }
        }

        private void btnUpdateParts_Click(object sender, EventArgs e)
        {
            int intCounter;
            int intNumberOfRecords;
            int intPartCounter;
            int intPartNumberOfRecords;
            int intPartIDForSearch;

            try
            {
                PleaseWait.Show();

                intNumberOfRecords = TheSortedPartNumbersDataSet.partnumbers.Rows.Count - 1;
                intPartNumberOfRecords = ThePartNumberDataSet.partnumbers.Rows.Count - 1;

                for (intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    if (TheSortedPartNumbersDataSet.partnumbers[intCounter].RowState == DataRowState.Modified)
                    {
                        intPartIDForSearch = TheSortedPartNumbersDataSet.partnumbers[intCounter].PartID;

                        //beginning the second loop
                        for(intPartCounter = 0; intPartCounter <= intPartNumberOfRecords; intPartCounter++)
                        {
                            if(intPartIDForSearch == ThePartNumberDataSet.partnumbers[intPartCounter].PartID)
                            {
                                //loading the fields
                                ThePartNumberDataSet.partnumbers[intPartCounter].Active = TheSortedPartNumbersDataSet.partnumbers[intCounter].Active.ToUpper();
                                ThePartNumberDataSet.partnumbers[intPartCounter].Description = TheSortedPartNumbersDataSet.partnumbers[intCounter].Description.ToUpper();
                                ThePartNumberDataSet.partnumbers[intPartCounter].JDEPartNumber = TheSortedPartNumbersDataSet.partnumbers[intCounter].JDEPartNumber.ToUpper();
                                ThePartNumberDataSet.partnumbers[intPartCounter].PartNumber = TheSortedPartNumbersDataSet.partnumbers[intCounter].PartNumber.ToUpper();
                                ThePartNumberDataSet.partnumbers[intPartCounter].PartType = TheSortedPartNumbersDataSet.partnumbers[intCounter].PartType.ToUpper();
                                ThePartNumberDataSet.partnumbers[intPartCounter].Price = TheSortedPartNumbersDataSet.partnumbers[intCounter].Price;
                                ThePartNumberDataSet.partnumbers[intPartCounter].TimeWarnerPart = TheSortedPartNumbersDataSet.partnumbers[intCounter].TimeWarnerPart.ToUpper();

                                //updating the tables
                                ThePartNumberClass.UpdatePartNumbersDB(ThePartNumberDataSet);
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                TheEventLogClass.CreateEventLogEntry("Whse Track Add Part Numbers Update Part Button " + Ex.Message);

                TheMessagesClass.ErrorMessage(Ex.ToString());
            }

            PleaseWait.Hide();
            
        }
    }
}
