/* Title:           Import Part Numbers
 * Date:            11-19-16
 * Author:          Terry Holmes
 * 
 * Description:     This form is used to import part numbers */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSVFileDLL;
using NewEventLogDLL;
using PartNumberDLL;
using System.IO;

namespace WhseTrack
{
    public partial class ImportPartNumbers : Form
    {
        //setting up the classes
        EventLogClass TheEventLogClass = new EventLogClass();
        MessagesClass TheMessagesClass = new MessagesClass();
        ReadWirteCSV TheCSVFileClass = new ReadWirteCSV();
        PartNumberClass ThePartNumberClass = new PartNumberClass();
        PleaseWait PleaseWait = new PleaseWait();

        //Setting up the parts
        PartNumbersDataSet ThePartNumberDataSet;
        CSVDataSet TheCSVDataSet = new CSVDataSet();
        PartNumbersDataSet TheSortedPartNumberDataSet = new PartNumbersDataSet();

        JohnsPartsDataSet aJohnPartsDataSet;
        JohnsPartsDataSet TheJohnsPartsDataSet;
        JohnsPartsDataSetTableAdapters.johnpartsTableAdapter aJohnsPartsTableAdpater;

        public ImportPartNumbers()
        {
            InitializeComponent();
        }

        private JohnsPartsDataSet GetJohnsPartsInfo()
        {
            try
            {
                aJohnPartsDataSet = new JohnsPartsDataSet();
                aJohnsPartsTableAdpater = new JohnsPartsDataSetTableAdapters.johnpartsTableAdapter();
                aJohnsPartsTableAdpater.Fill(aJohnPartsDataSet.johnparts);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inport Part Numbers Get Johns Parts Info " + Ex.Message);

                TheMessagesClass.ErrorMessage(Ex.ToString());
            }

            return aJohnPartsDataSet;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
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

        private void ImportPartNumbers_Load(object sender, EventArgs e)
        {
            //this will load up the data set
            try
            {
                ThePartNumberDataSet = ThePartNumberClass.GetPartNumbersInfo();

                TheJohnsPartsDataSet = GetJohnsPartsInfo();

                dgvParts.DataSource = TheJohnsPartsDataSet.johnparts;

                btnProcess.Enabled = false;
            }
            catch(Exception Ex)
            {
                TheMessagesClass.ErrorMessage(Ex.ToString());

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Import Part Numbers " + Ex.Message);
            }
        }

        

        private void btnUtilitiesMenu_Click(object sender, EventArgs e)
        {
            UtilitiesMenu UtilitiesMenu = new UtilitiesMenu();
            UtilitiesMenu.Show();
            this.Close();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            //setting local variables
            int intCounter;
            int intNumberOfRecords;
            string strPartNumber;
            int intPartID;
            string strDescription;
            int intRecordsFound = 0;

            PleaseWait.Show();

            try
            {
                intNumberOfRecords = TheCSVDataSet.parts.Rows.Count - 1;

                for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    strPartNumber = TheCSVDataSet.parts[intCounter].PartNumber;
                    strDescription = TheCSVDataSet.parts[intCounter].Description;

                    TheSortedPartNumberDataSet = ThePartNumberClass.GetPartByPartNumber(strPartNumber);

                    intRecordsFound = TheSortedPartNumberDataSet.partnumbers.Rows.Count;

                    if(intRecordsFound == 0)
                    {
                        intPartID = ThePartNumberClass.CreatePartID();

                        if(strPartNumber == "?")
                        {
                            strPartNumber = Convert.ToString(intPartID);
                        }

                        PartNumbersDataSet.partnumbersRow NewTableRow = ThePartNumberDataSet.partnumbers.NewpartnumbersRow();

                        NewTableRow.Active = "YES";
                        NewTableRow.Description = TheCSVDataSet.parts[intCounter].Description;
                        NewTableRow.JDEPartNumber = "NOT PROVIDED";
                        NewTableRow.PartID = intPartID;
                        NewTableRow.PartNumber = strPartNumber;
                        NewTableRow.PartType = "NOT PROVIDED";
                        NewTableRow.Price = TheCSVDataSet.parts[intCounter].Cost;
                        NewTableRow.TimeWarnerPart = "NO";
                        NewTableRow.Type = "NOT PROVIDED";

                        //updating the row
                        ThePartNumberDataSet.partnumbers.Rows.Add(NewTableRow);
                        ThePartNumberClass.UpdatePartNumbersDB(ThePartNumberDataSet);
                    }                             
                }
            }
            catch (Exception Ex)
            {
                TheMessagesClass.ErrorMessage(Ex.ToString());

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Import Part Numbers Process button " + Ex.Message);
            }

            PleaseWait.Hide();
        }

        private void btnCheckPartNumbers_Click(object sender, EventArgs e)
        {
            //setting local variables
            int intJohnCounter;
            int intJohnUpperLimit;
            int intPartUpperLimit;
            string strPartNumberForSearch;
            string strDescription;

            PleaseWait.Show();

            try
            {
                //getting ready for the count
                intPartUpperLimit = ThePartNumberDataSet.partnumbers.Rows.Count - 1;
                intJohnUpperLimit = TheJohnsPartsDataSet.johnparts.Rows.Count - 1;

                for(intJohnCounter = 0; intJohnCounter <= intJohnUpperLimit; intJohnCounter++)
                {
                    strPartNumberForSearch = TheJohnsPartsDataSet.johnparts[intJohnCounter].PartNumber.ToUpper();
                    strDescription = TheJohnsPartsDataSet.johnparts[intJohnCounter].Description.ToUpper();

                    TheSortedPartNumberDataSet = ThePartNumberClass.GetPartByPartNumber(strPartNumberForSearch);

                    intPartUpperLimit = TheSortedPartNumberDataSet.partnumbers.Rows.Count;

                    if(intPartUpperLimit == 0)
                    {
                        TheSortedPartNumberDataSet = ThePartNumberClass.GetPartNumberByDescriptionKey("%" + strDescription + "%");

                        intPartUpperLimit = TheSortedPartNumberDataSet.partnumbers.Rows.Count;

                        if(intPartUpperLimit != 0)
                        {
                            strPartNumberForSearch = TheSortedPartNumberDataSet.partnumbers[0].PartNumber;
                        }
                    }

                    if(intPartUpperLimit != 0)
                    {
                        CSVDataSet.partsRow NewTableRow = TheCSVDataSet.parts.NewpartsRow();

                        NewTableRow.Cost = TheJohnsPartsDataSet.johnparts[intJohnCounter].Price;
                        NewTableRow.Description = strDescription;
                        NewTableRow.PartNumber = strPartNumberForSearch;

                        TheCSVDataSet.parts.Rows.Add(NewTableRow);
                    }
                    else
                    {
                        CSVDataSet.partsRow NewTableRow = TheCSVDataSet.parts.NewpartsRow();

                        NewTableRow.Cost = TheJohnsPartsDataSet.johnparts[intJohnCounter].Price;
                        NewTableRow.Description = strDescription;
                        NewTableRow.PartNumber = strPartNumberForSearch;

                        TheCSVDataSet.parts.Rows.Add(NewTableRow);
                    }
                }

                dgvParts.DataSource = TheCSVDataSet.parts;

                btnProcess.Enabled = true;
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Import Part Numbers Check Part Numbers Button " + Ex.Message);

                TheMessagesClass.ErrorMessage(Ex.ToString());
            }

            PleaseWait.Hide();

        }
    }
}
