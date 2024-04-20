/* Title:           Part Number Matrix
 * Date:            10-29-16
 * Author:          Terry Holmes
 * 
 * Description:     This will show the part number table and be search able by part number */

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
using DataValidationDLL;
using KeyWordDLL;

namespace WhseTrack
{
    public partial class PartNumberMatrix : Form
    {
        MessagesClass TheMessageClass = new MessagesClass();
        PartNumberClass ThePartNumberClass = new PartNumberClass();
        EventLogClass TheEventLogClass = new EventLogClass();
        PleaseWait PleaseWait = new PleaseWait();
        DataValidationClass TheDataValidationClass = new DataValidationClass();
        KeyWordClass TheKeyWordClass = new KeyWordClass();

        //creating the data set
        PartNumbersDataSet ThePartNumberDataSet;

        PartMatrixDataSet ThePartMatrixDataSet = new PartMatrixDataSet();
        PartMatrixDataSet TheSortedPartMatrixDataSet = new PartMatrixDataSet();

        public PartNumberMatrix()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //this will close the program
            TheMessageClass.CloseTheProgram();
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

        private void PartNumberMatrix_Load(object sender, EventArgs e)
        {
            //setting local variables
            int intCounter;
            int intNumberOfRecords;
            string strPartNumber;
            bool blnNotTWCPartNumber;

            try
            {
                PleaseWait.Show();

                //filling the data set
                ThePartNumberDataSet = ThePartNumberClass.GetPartNumbersInfo();

                //getting the record count
                intNumberOfRecords = ThePartNumberDataSet.partnumbers.Rows.Count - 1;

                //loop
                for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    strPartNumber = ThePartNumberDataSet.partnumbers[intCounter].PartNumber;

                    blnNotTWCPartNumber = ThePartNumberClass.CheckTimeWarnerPart(strPartNumber);

                    if(blnNotTWCPartNumber == false)
                    {
                        PartMatrixDataSet.partmatrixRow NewTableRow = ThePartMatrixDataSet.partmatrix.NewpartmatrixRow();

                        NewTableRow.PartNumber = ThePartNumberDataSet.partnumbers[intCounter].PartNumber;
                        NewTableRow.PartID = ThePartNumberDataSet.partnumbers[intCounter].PartID;
                        NewTableRow.JDEPartNumber = ThePartNumberDataSet.partnumbers[intCounter].JDEPartNumber;
                        NewTableRow.Description = ThePartNumberDataSet.partnumbers[intCounter].Description;

                        ThePartMatrixDataSet.partmatrix.Rows.Add(NewTableRow);
                    }
                }

                dgvPartNumbers.DataSource = ThePartMatrixDataSet.partmatrix;
            }
            catch (Exception Ex)
            {
                TheMessageClass.ErrorMessage(Ex.ToString());

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "WhseTrack Part Number Matrix Form Load " + Ex.Message);
            }

            PleaseWait.Hide();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            //this will find the part number via either part number, jde part number, description
            //setting local variables
            int intCounter;
            int intNumberOfRecords;
            string strPartNumber;
            bool blnItemNotFound = true;
            bool blnKeyWordNotFound;
            bool blnRecordFound = false;

            try
            {
                PleaseWait.Show();

                //data validation
                strPartNumber = txtEnteredInformation.Text;
                if (strPartNumber == "")
                {
                    TheMessageClass.ErrorMessage("No Search Information Was Entered");
                    return;
                }

                //getting ready for the loop
                intNumberOfRecords = ThePartMatrixDataSet.partmatrix.Rows.Count - 1;

                //clearing the data set
                TheSortedPartMatrixDataSet.partmatrix.Rows.Clear();

                //loop
                for (intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    blnRecordFound = false;

                    //checking to see if the part should be entered
                    if (strPartNumber == ThePartMatrixDataSet.partmatrix[intCounter].PartNumber)
                        blnRecordFound = true;
                    else if (strPartNumber == ThePartMatrixDataSet.partmatrix[intCounter].JDEPartNumber)
                        blnRecordFound = true;
                    else
                    {
                        blnKeyWordNotFound = TheKeyWordClass.FindKeyWord(strPartNumber, ThePartMatrixDataSet.partmatrix[intCounter].Description);

                        if (blnKeyWordNotFound == false)
                        {
                            blnRecordFound = true;
                        }
                    }

                    //new table entry
                    if (blnRecordFound == true)
                    {
                        //creating the row
                        PartMatrixDataSet.partmatrixRow NewTableRow = TheSortedPartMatrixDataSet.partmatrix.NewpartmatrixRow();

                        //filling the fields
                        NewTableRow.Description = ThePartMatrixDataSet.partmatrix[intCounter].Description;
                        NewTableRow.JDEPartNumber = ThePartMatrixDataSet.partmatrix[intCounter].JDEPartNumber;
                        NewTableRow.PartID = ThePartMatrixDataSet.partmatrix[intCounter].PartID;
                        NewTableRow.PartNumber = ThePartMatrixDataSet.partmatrix[intCounter].PartNumber;

                        //adding the row
                        TheSortedPartMatrixDataSet.partmatrix.Rows.Add(NewTableRow);
                        blnItemNotFound = false;
                    }
                }

                if (blnItemNotFound == true)
                {
                    TheMessageClass.InformationMessage("Part Information Not Found");

                    dgvPartNumbers.DataSource = ThePartMatrixDataSet.partmatrix;
                }
                else
                {
                    dgvPartNumbers.DataSource = TheSortedPartMatrixDataSet.partmatrix;
                }
            }
            catch (Exception Ex)
            {
                TheMessageClass.ErrorMessage(Ex.ToString());

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Part Number Matrix Find Button " + Ex.Message);
            }

            PleaseWait.Hide();
        }
    }
}
