/* Title:           Create new Part
 * Date:            10-21-16
 * Author:          Terry Holmes
 * 
 * Description:     This form is used to create a new part */

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
using PartNumberDLL;
using CSVFileDLL;
using System.IO;

namespace WhseTrack
{
    public partial class CreateNewPart : Form
    {
        //settting up the classes
        MessagesClass TheMessagesClass = new MessagesClass();
        EventLogClass TheEventLogClass = new EventLogClass();
        PartNumberClass ThePartNumberClass = new PartNumberClass();
        PleaseWait PleaseWait = new PleaseWait();

        //setting up the data
        PartNumbersDataSet ThePartNumberDataSet;

        //setting global variables
        int gintPartNumberOfRecords;

        public CreateNewPart()
        {
            InitializeComponent();
        }

        private void CreateNewPart_Load(object sender, EventArgs e)
        {
            //try catch for exceptions
            try
            {
                PleaseWait.Show();

                //loading the data set
                ThePartNumberDataSet = ThePartNumberClass.GetPartNumbersInfo();

                //getting count
                gintPartNumberOfRecords = ThePartNumberDataSet.partnumbers.Rows.Count - 1;

                CheckForNull();

                SetControlsVisible(false);

                PleaseWait.Hide();
            }
            catch (Exception Ex)
            {
                //message to the user
                TheMessagesClass.ErrorMessage(Ex.ToString());

                //event log entry
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "WhseTrack Create New Part Form Load " + Ex.Message);
            }
        }
        private bool CheckForNull()
        {
            bool blnFatalError = false;
            int intCounter;
            bool blnFieldIsNull;
            bool blnUpdateRecord;

            try
            {
                for (intCounter = 0; intCounter <= gintPartNumberOfRecords; intCounter++)
                {
                    blnUpdateRecord = false;

                    //checking all fields for nulls
                    blnFieldIsNull = ThePartNumberDataSet.partnumbers[intCounter].IsActiveNull();
                    if (blnFieldIsNull == true)
                    {
                        ThePartNumberDataSet.partnumbers[intCounter].Active = "YES";
                        blnUpdateRecord = true;
                    }
                    blnFieldIsNull = ThePartNumberDataSet.partnumbers[intCounter].IsDescriptionNull();
                    if (blnFieldIsNull == true)
                    {
                        ThePartNumberDataSet.partnumbers[intCounter].Description = "NOT PROVIDED";
                        blnUpdateRecord = true;
                    }
                    blnFieldIsNull = ThePartNumberDataSet.partnumbers[intCounter].IsJDEPartNumberNull();
                    if (blnFieldIsNull == true)
                    {
                        ThePartNumberDataSet.partnumbers[intCounter].JDEPartNumber = "NOT PROVIDED";
                        blnUpdateRecord = true;
                    }
                    blnFieldIsNull = ThePartNumberDataSet.partnumbers[intCounter].IsPartNumberNull();
                    if (blnFieldIsNull == true)
                    {
                        ThePartNumberDataSet.partnumbers[intCounter].PartNumber = "NOT PROVIDED";
                        blnUpdateRecord = true;
                    }
                    blnFieldIsNull = ThePartNumberDataSet.partnumbers[intCounter].IsPartTypeNull();
                    if (blnFieldIsNull == true)
                    {
                        ThePartNumberDataSet.partnumbers[intCounter].PartType = "NOT PROVIDED";
                        blnUpdateRecord = true;
                    }
                    blnFieldIsNull = ThePartNumberDataSet.partnumbers[intCounter].IsPriceNull();
                    if (blnFieldIsNull == true)
                    {
                        ThePartNumberDataSet.partnumbers[intCounter].Price = 0;
                        blnUpdateRecord = true;
                    }
                    blnFieldIsNull = ThePartNumberDataSet.partnumbers[intCounter].IsTimeWarnerPartNull();
                    if (blnFieldIsNull == true)
                    {
                        ThePartNumberDataSet.partnumbers[intCounter].TimeWarnerPart = "NO";
                        blnUpdateRecord = true;
                    }
                    blnFieldIsNull = ThePartNumberDataSet.partnumbers[intCounter].IsTypeNull();
                    if (blnFieldIsNull == true)
                    {
                        ThePartNumberDataSet.partnumbers[intCounter].Type = "NOT PROVIDED";
                        blnUpdateRecord = true;
                    }
                    
                    if(blnUpdateRecord == true)
                    {
                        ThePartNumberClass.UpdatePartNumbersDB(ThePartNumberDataSet);
                    }
                }
            }
            catch (Exception Ex)
            {
                TheMessagesClass.ErrorMessage(Ex.ToString());

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "WhseTrack Create New Part Check for Null " + Ex.Message);
            }

            //returning value
            return blnFatalError;
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

        private void btmAdminMenu_Click(object sender, EventArgs e)
        {
            AdminMenu AdminMenu = new AdminMenu();
            AdminMenu.Show();
            this.Close();
        }
        private void SetControlsVisible(bool valueBoolean)
        {
            txtActive.Visible = valueBoolean;
            txtDescription.Visible = valueBoolean;
            txtJDEPartNumber.Visible = valueBoolean;
            txtPartID.Visible = valueBoolean;
            txtPartNumber.Visible = valueBoolean;
            txtPartType.Visible = valueBoolean;
            txtPrice.Visible = valueBoolean;
            txtTWCPart.Visible = valueBoolean;
            txtType.Visible = valueBoolean;
        }
        
        private bool UpdatePartTable(string strJDEPartNumber, string strPartNumber, string strDescription)
        {
            //setting local variables
            int intPartCounter;
            bool blnIsFieldNull;
            bool blnItemProcessed = false;

            try
            {
                blnItemProcessed = false;
                
                for (intPartCounter = 0; intPartCounter <= gintPartNumberOfRecords; intPartCounter++)
                {
                    //checking to see if the 
                    blnIsFieldNull = ThePartNumberDataSet.partnumbers[intPartCounter].IsPartNumberNull();

                    if(strPartNumber == ThePartNumberDataSet.partnumbers[intPartCounter].PartNumber)
                    {
                        ThePartNumberDataSet.partnumbers[intPartCounter].JDEPartNumber = strJDEPartNumber;
                        ThePartNumberDataSet.partnumbers[intPartCounter].Description = strDescription;
                        blnItemProcessed = true;
                    }
                }

                if (blnItemProcessed == false)
                {
                    //creating the row
                    PartNumbersDataSet.partnumbersRow NewPartRow = ThePartNumberDataSet.partnumbers.NewpartnumbersRow();

                    NewPartRow.Description = strDescription;
                    NewPartRow.JDEPartNumber = strJDEPartNumber;
                    NewPartRow.PartID = ThePartNumberClass.CreatePartID();
                    NewPartRow.PartNumber = strPartNumber;
                    NewPartRow.PartType = "UNKNOWN";
                    NewPartRow.Price = 0.00;
                    NewPartRow.TimeWarnerPart = "YES";
                    NewPartRow.Type = "UNKNOWN";
                    NewPartRow.Active = "YES";

                    //updating the table
                    ThePartNumberDataSet.partnumbers.Rows.Add(NewPartRow);
                }

                ThePartNumberClass.UpdatePartNumbersDB(ThePartNumberDataSet);

            }
            catch (Exception Ex)
            {
                TheMessagesClass.ErrorMessage(Ex.ToString());

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "WhseTrack Update Part Table " + Ex.Message);
            }

            return blnItemProcessed;
        }
        private void FillPartTable(string strJDEPartNumber, string strPartNumber, string strDescription)
        {
            //setting local variables
            int intPartCounter;
            bool blnItemNotFound;;

            try
            {
                //for loop               
                blnItemNotFound = true;

                //part counter
                for(intPartCounter = 0; intPartCounter <= gintPartNumberOfRecords; intPartCounter++)
                {
                    if(strPartNumber == ThePartNumberDataSet.partnumbers[intPartCounter].PartNumber)
                    {
                        blnItemNotFound = false;
                    }
                }

                if(blnItemNotFound == true)
                {
                    
                }
               

                ThePartNumberDataSet = ThePartNumberClass.GetPartNumbersInfo();

                gintPartNumberOfRecords = ThePartNumberDataSet.partnumbers.Rows.Count - 1;
            }
            catch (Exception Ex)
            {
                TheMessagesClass.ErrorMessage(Ex.ToString());

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "WhseTrack Fill Part Table " + Ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        { 
        }
    }
}
