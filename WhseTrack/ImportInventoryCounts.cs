/* Title:           Import Inventory Counts
 * Date:            12-7-16
 * Author:          Terry Holmes
 * 
 * Description:     This form is used to import the inventory count */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NewEventLogDLL;
using KeyWordDLL;
using InventoryDLL;
using CSVFileDLL;
using PartNumberDLL;

namespace WhseTrack
{
    public partial class ImportInventoryCounts : Form
    {
        //setting up the classes
        MessagesClass TheMessagesClass = new MessagesClass();
        EventLogClass TheEventLogClass = new EventLogClass();
        KeyWordClass TheKeyWordClass = new KeyWordClass();
        InventoryClass TheInventoryClass = new InventoryClass();
        PleaseWait PleaseWait = new PleaseWait();
        PartNumberClass ThePartNumberClass = new PartNumberClass();

        PartsWarehouseDataSet TheJHPartsWarehouse = new PartsWarehouseDataSet();
        CountsDataSet TheCountsDataSet = new CountsDataSet();
        PartNumbersDataSet TheSortedPartNumberDataSet = new PartNumbersDataSet();
        PartNumbersDataSet ThePartNumbersDataSet;
        PricingDataSet TheSortedPricingDataSet;

        public static ClevelandCountDataSet ThePublicCountDataSet = new ClevelandCountDataSet();
        public static SelectPartDataSet TheSelectPartDataSet = new SelectPartDataSet();

        WisconsinCountDataSet aWisconsinCountDataSet;
        WisconsinCountDataSet TheWisconsinCountDataSet;
        WisconsinCountDataSetTableAdapters.wisconsincountTableAdapter aWisconsinCountTableAdapter;

        ClevelandCountDataSet aClevelandCountDataSet;
        ClevelandCountDataSet TheClevelandCountDataSet;
        ClevelandCountDataSetTableAdapters.clevelandcountsTableAdapter aClevelandCountTableAdapter;

        KentuckyCountsDataSet aKentuckyCountsDataSet;
        KentuckyCountsDataSet TheKentuckyCountsDataSet;
        KentuckyCountsDataSetTableAdapters.kentuckycountsTableAdapter aKentuckyCountsTableAdapter;

        JamestownCountsDataSet aJamestownCountsDataSet;
        JamestownCountsDataSet TheJamesTownCountsDataSet;
        JamestownCountsDataSetTableAdapters.jamestowncountsTableAdapter aJamestownCountsTableAdapter;

        public ImportInventoryCounts()
        {
            InitializeComponent();
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

        private void btnUtilitiesMenu_Click(object sender, EventArgs e)
        {
            UtilitiesMenu UtilitiesMenu = new UtilitiesMenu();
            UtilitiesMenu.Show();
            this.Close();
        }

        private void ImportInventoryCounts_Load(object sender, EventArgs e)
        {
            //setting local variables
            int intCounter;
            int intNumberOfRecords;
            bool blnKeyWordNotFound;

            try
            {
                PleaseWait.Show();

                ThePartNumbersDataSet = ThePartNumberClass.GetPartNumbersInfo();

                //getting the number of records
                intNumberOfRecords = Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses.Rows.Count - 1;

                //adding items to the combo
                cboWarehouse.Items.Add("Select Warehouse");

                for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    blnKeyWordNotFound = TheKeyWordClass.FindKeyWord("JH", Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses[intCounter].FirstName);

                    if(blnKeyWordNotFound == false)
                    {
                        cboWarehouse.Items.Add(Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses[intCounter].FirstName);

                        PartsWarehouseDataSet.warehouseRow NewTableRow = TheJHPartsWarehouse.warehouse.NewwarehouseRow();

                        NewTableRow.WarehouseName = Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses[intCounter].FirstName;
                        NewTableRow.WarehouseID = Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses[intCounter].EmployeeID;

                        TheJHPartsWarehouse.warehouse.Rows.Add(NewTableRow);
                    }
                }

                cboWarehouse.SelectedIndex = 0;
                dgvInventoryCounts.DataSource = TheCountsDataSet.counts;

                PleaseWait.Hide();

                //TheKentuckyCountsDataSet = GetKentuckyCountsInfo();

                //dgvInventoryCounts.DataSource = TheKentuckyCountsDataSet.kentuckycounts;

                //UpdatePartNumberTable();

                cboWarehouse.Enabled = true;
            }
            catch (Exception Ex)
            {
                TheMessagesClass.ErrorMessage(Ex.ToString());

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Import Inventory Counts Form Load " + Ex.Message);
            }
            
        }
        private void UpdatePartNumberTable()
        {
            int intClevelandCounter;
            int intClevelandNumberOfRecords;
            int intRecordsReturned;
            bool blnItemFound = false;
            string strPartNumber;
            double douPrice = 0;
            string strDescription;
            int intPartCounter;
            int intPartNumberOfRecords;

            PleaseWait.Show();

            try
            {
                TheClevelandCountDataSet = GetClevelandCountInfo();

                intClevelandNumberOfRecords = TheClevelandCountDataSet.clevelandcounts.Rows.Count - 1;

                for (intClevelandCounter = 0; intClevelandCounter <= intClevelandNumberOfRecords; intClevelandCounter++)
                {
                    blnItemFound = false;

                    strPartNumber = TheClevelandCountDataSet.clevelandcounts[intClevelandCounter].PartNumber.ToUpper();

                    if(strPartNumber != "?")
                    {
                        //checking for the part number table
                        TheSortedPartNumberDataSet = ThePartNumberClass.GetPartByPartNumber(strPartNumber);

                        intRecordsReturned = TheSortedPartNumberDataSet.partnumbers.Rows.Count;

                        if (intRecordsReturned > 0)
                        {
                            blnItemFound = true;
                        }
                        else
                        {
                            TheSortedPricingDataSet = ThePartNumberClass.GetPricingByPartNumber(strPartNumber);
                            ThePublicCountDataSet.clevelandcounts.Rows.Clear();
                            TheSelectPartDataSet.selectpart.Rows.Clear();

                            intRecordsReturned = TheSortedPricingDataSet.pricing.Rows.Count;

                            if(intRecordsReturned > 0)
                            {
                                douPrice = TheSortedPricingDataSet.pricing[0].Cost;
                            }
                            else
                            {
                                ClevelandCountDataSet.clevelandcountsRow NewCountRow = ThePublicCountDataSet.clevelandcounts.NewclevelandcountsRow();

                                NewCountRow.Cost = TheClevelandCountDataSet.clevelandcounts[intClevelandCounter].Cost;
                                strDescription = TheClevelandCountDataSet.clevelandcounts[intClevelandCounter].Description.ToUpper();
                                NewCountRow.Description = strDescription;
                                NewCountRow.PartNumber = TheClevelandCountDataSet.clevelandcounts[intClevelandCounter].PartNumber;
                                NewCountRow.Quantity = TheClevelandCountDataSet.clevelandcounts[intClevelandCounter].Quantity;
                                NewCountRow.TransactionID = TheClevelandCountDataSet.clevelandcounts[intClevelandCounter].TransactionID;

                                ThePublicCountDataSet.clevelandcounts.Rows.Add(NewCountRow);

                                strDescription = strDescription.Substring(0, 7);

                                TheSortedPartNumberDataSet = ThePartNumberClass.GetPartNumberByDescriptionKey("%" + strDescription + "%");

                                intPartNumberOfRecords = TheSortedPartNumberDataSet.partnumbers.Rows.Count - 1;

                                if(intPartNumberOfRecords > -1)
                                {
                                    for(intPartCounter = 0; intPartCounter <= intPartNumberOfRecords; intPartCounter++)
                                    {
                                        SelectPartDataSet.selectpartRow NewSelectRow = TheSelectPartDataSet.selectpart.NewselectpartRow();

                                        NewSelectRow.Description = TheSortedPartNumberDataSet.partnumbers[intPartCounter].Description;
                                        NewSelectRow.PartID = TheSortedPartNumberDataSet.partnumbers[intPartCounter].PartID;
                                        NewSelectRow.PartNumber = TheSortedPartNumberDataSet.partnumbers[intPartCounter].PartNumber;
                                        NewSelectRow.Price = TheSortedPartNumberDataSet.partnumbers[intPartCounter].Price;
                                        NewSelectRow.Select = false;

                                        TheSelectPartDataSet.selectpart.Rows.Add(NewSelectRow);
                                    }

                                    CheckPartInfo CheckPartInfo = new CheckPartInfo();
                                    CheckPartInfo.ShowDialog();

                                    douPrice = ThePublicCountDataSet.clevelandcounts[0].Cost;

                                    for(intPartCounter = 0; intPartCounter <= intPartNumberOfRecords; intPartCounter++)
                                    {
                                        if(TheSelectPartDataSet.selectpart[intPartCounter].Select == true)
                                        {
                                            strPartNumber = TheSelectPartDataSet.selectpart[intPartCounter].PartNumber;
                                            douPrice = TheSelectPartDataSet.selectpart[intPartCounter].Price;
                                        }
                                    }
                                }
                            }

                            PartNumbersDataSet.partnumbersRow NewPartRow = ThePartNumbersDataSet.partnumbers.NewpartnumbersRow();

                            NewPartRow.Active = "YES";
                            NewPartRow.Description = TheClevelandCountDataSet.clevelandcounts[intClevelandCounter].Description.ToUpper(); ;
                            NewPartRow.JDEPartNumber = "NOT REQUIRED";
                            NewPartRow.PartID = ThePartNumberClass.CreatePartID();
                            NewPartRow.PartNumber = strPartNumber;
                            NewPartRow.PartType = "UNKNOWN";
                            NewPartRow.Price = douPrice;
                            NewPartRow.TimeWarnerPart = "NO";
                            NewPartRow.Type = "UNKNOWN";

                            ThePartNumbersDataSet.partnumbers.Rows.Add(NewPartRow);
                            ThePartNumberClass.UpdatePartNumbersDB(ThePartNumbersDataSet);
                        }
                    }
                }
            }
            catch(Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Import Inventory Counts Update Part Number Table " + Ex.Message);

                TheMessagesClass.ErrorMessage(Ex.ToString());
            }

            PleaseWait.Hide();
        }
        private void btnProcess_Click(object sender, EventArgs e)
        {
            //setting local variables
            int intCounter;
            int intNumberOfRecords;
            int intWarehouseID = 0;
            int intWarehouseCounter;
            string strWarehouse;
            int intWarehouseNumberOfRecords;
            string strPartNumber;
            string strDescription;
            double douPrice;
            int intPartID = 0;
            int intQuantity;
            int intRecordsReturned;
            int intPartCounter;
            int intPartNumberOfRecords;
            bool blnFatalError;
            bool blnItemFound = false;
            int intLength;

            PleaseWait.Show();

            try
            {
                //getting the warehouse id
                strWarehouse = cboWarehouse.Text;

                intWarehouseNumberOfRecords = Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses.Rows.Count - 1;

                for (intWarehouseCounter = 0; intWarehouseCounter <= intWarehouseNumberOfRecords; intWarehouseCounter++)
                {
                    if (strWarehouse == Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses[intWarehouseCounter].FirstName)
                    {
                        intWarehouseID = Logon.TheFindPartsWarehouseDataSet.FindPartsWarehouses[intWarehouseCounter].EmployeeID;
                        break;
                    }
                }

                intNumberOfRecords = TheCountsDataSet.counts.Rows.Count - 1;

                //loop
                for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    strDescription = TheCountsDataSet.counts[intCounter].Description;
                    strPartNumber = TheCountsDataSet.counts[intCounter].PartNumber;
                    douPrice = TheCountsDataSet.counts[intCounter].Price;
                    intQuantity = TheCountsDataSet.counts[intCounter].Quantity;

                    //checking for part in part db
                    TheSortedPartNumberDataSet = ThePartNumberClass.GetPartByPartNumber(strPartNumber);

                    intRecordsReturned = TheSortedPartNumberDataSet.partnumbers.Rows.Count;

                    if(intRecordsReturned == 0)
                    {
                        ThePublicCountDataSet.clevelandcounts.Rows.Clear();
                        TheSelectPartDataSet.selectpart.Rows.Clear();

                        ClevelandCountDataSet.clevelandcountsRow NewCountRow = ThePublicCountDataSet.clevelandcounts.NewclevelandcountsRow();

                        NewCountRow.Cost = douPrice;
                        NewCountRow.Description = strDescription;
                        NewCountRow.PartNumber = strPartNumber;
                        NewCountRow.Quantity = intQuantity;
                        NewCountRow.TransactionID = TheCountsDataSet.counts[intCounter].TransactionID;

                        ThePublicCountDataSet.clevelandcounts.Rows.Add(NewCountRow);

                        intLength = strDescription.Length - 1;

                        if (intLength < 7)
                            intLength = 7;

                        strDescription = "%" + strDescription.Substring(0, intLength) + "%";

                        TheSortedPartNumberDataSet = ThePartNumberClass.GetPartNumberByDescriptionKey(strDescription);

                        intPartNumberOfRecords = TheSortedPartNumberDataSet.partnumbers.Rows.Count - 1;

                        if(intPartNumberOfRecords > -1)
                        {
                            for(intPartCounter = 0; intPartCounter <= intPartNumberOfRecords; intPartCounter++)
                            {
                                SelectPartDataSet.selectpartRow NewSelectRow = TheSelectPartDataSet.selectpart.NewselectpartRow();

                                NewSelectRow.Description = TheSortedPartNumberDataSet.partnumbers[intPartCounter].Description;
                                NewSelectRow.PartID = TheSortedPartNumberDataSet.partnumbers[intPartCounter].PartID;
                                NewSelectRow.PartNumber = TheSortedPartNumberDataSet.partnumbers[intPartCounter].PartNumber;
                                NewSelectRow.Price = TheSortedPartNumberDataSet.partnumbers[intPartCounter].Price;
                                NewSelectRow.Select = false;

                                TheSelectPartDataSet.selectpart.Rows.Add(NewSelectRow);
                            }
                        }

                        CheckPartInfo CheckPartInfo = new CheckPartInfo();
                        CheckPartInfo.ShowDialog();

                        blnItemFound = false;

                        for (intPartCounter = 0; intPartCounter <= intPartNumberOfRecords; intPartCounter++)
                        {
                            if (TheSelectPartDataSet.selectpart[intPartCounter].Select == true)
                            {
                                strPartNumber = TheSelectPartDataSet.selectpart[intPartCounter].PartNumber;
                                intPartID = TheSelectPartDataSet.selectpart[intPartCounter].PartID;
                                blnItemFound = true;
                            }
                        }
                        if(blnItemFound == false)
                        {
                            intPartID = ThePartNumberClass.CreatePartID();

                            if (strPartNumber == "?")
                            {
                                strPartNumber = Convert.ToString(intPartID);
                            }

                            PartNumbersDataSet.partnumbersRow NewPartRow = ThePartNumbersDataSet.partnumbers.NewpartnumbersRow();

                            NewPartRow.Active = "YES";
                            NewPartRow.Description = ThePublicCountDataSet.clevelandcounts[0].Description;
                            NewPartRow.JDEPartNumber = "NOT REQUIRED";
                            NewPartRow.PartID = intPartID;
                            NewPartRow.PartNumber = strPartNumber;
                            NewPartRow.PartType = "UNKNOWN";
                            NewPartRow.Price = ThePublicCountDataSet.clevelandcounts[0].Cost;
                            NewPartRow.TimeWarnerPart = "NO";

                            ThePartNumbersDataSet.partnumbers.Rows.Add(NewPartRow);
                            ThePartNumberClass.UpdatePartNumbersDB(ThePartNumbersDataSet);
                        } 
                    }
                    else
                    {
                        intPartID = TheSortedPartNumberDataSet.partnumbers[0].PartID;
                    }

                    blnFatalError = TheInventoryClass.CreateNewWarehouseInventoryPartRecord(intPartID, strPartNumber, intWarehouseID, intQuantity);

                    if(blnFatalError == true)
                    {
                        TheMessagesClass.ErrorMessage("There is a problem");
                    }
                }

                btnProcess.Enabled = false;
                cboWarehouse.Enabled = true;
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Import Inventory Counts Process Button " + Ex.Message);

                TheMessagesClass.ErrorMessage(Ex.ToString());
            }

            PleaseWait.Hide();
        }
        private void cboWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            //setting local variables
            int intCounter;
            int intNumberOfRecords;
            string strPartNumber;
            string strDescription;
            int intRecordReturned;
            double douPrice = 0;
            double douTotalPrice;

            try
            {
                TheCountsDataSet.counts.Rows.Clear();

                PleaseWait.Show();

                if (cboWarehouse.Text == "MILWAUKEE - JH")
                {
                    TheWisconsinCountDataSet = GetWisconsinCountInfo();

                    intNumberOfRecords = TheWisconsinCountDataSet.wisconsincount.Rows.Count - 1;

                    for (intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                    {
                        strPartNumber = TheWisconsinCountDataSet.wisconsincount[intCounter].PartNumber;
                        strDescription = TheWisconsinCountDataSet.wisconsincount[intCounter].Description;

                        //getting the part number search
                        TheSortedPartNumberDataSet = ThePartNumberClass.GetPartByPartNumber(strPartNumber);

                        intRecordReturned = TheSortedPartNumberDataSet.partnumbers.Rows.Count;

                        if(intRecordReturned == 0)
                        {
                            TheSortedPartNumberDataSet = ThePartNumberClass.GetPartNumberByDescriptionKey("%" + strDescription + "%");

                            intRecordReturned = TheSortedPartNumberDataSet.partnumbers.Rows.Count;

                            if (intRecordReturned == 0)
                            {
                                douPrice = 0;
                            }
                        }
                        
                        if(intRecordReturned > 0)
                        {
                            douPrice = TheSortedPartNumberDataSet.partnumbers[0].Price;

                            if(strPartNumber == "?")
                            {
                                strPartNumber = TheSortedPartNumberDataSet.partnumbers[0].PartNumber;
                            }
                        }

                        douTotalPrice = douPrice * Convert.ToInt32(TheWisconsinCountDataSet.wisconsincount[intCounter].Quantity);

                        CountsDataSet.countsRow newTableRow = TheCountsDataSet.counts.NewcountsRow();

                        newTableRow.Description = TheWisconsinCountDataSet.wisconsincount[intCounter].Description;
                        newTableRow.PartNumber = strPartNumber;
                        newTableRow.Price = douTotalPrice;
                        newTableRow.Quantity = Convert.ToInt32(TheWisconsinCountDataSet.wisconsincount[intCounter].Quantity);

                        TheCountsDataSet.counts.Rows.Add(newTableRow);
                    }
                }
                if(cboWarehouse.Text == "CLEVELAND-JH")
                {
                    TheClevelandCountDataSet = GetClevelandCountInfo();

                    intNumberOfRecords = TheClevelandCountDataSet.clevelandcounts.Rows.Count - 1;

                    for (intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                    {
                        strPartNumber = TheClevelandCountDataSet.clevelandcounts[intCounter].PartNumber.ToUpper();
                        strDescription = TheClevelandCountDataSet.clevelandcounts[intCounter].Description.ToUpper();

                        TheSortedPartNumberDataSet = ThePartNumberClass.GetPartByPartNumber(strPartNumber);

                        intRecordReturned = TheSortedPartNumberDataSet.partnumbers.Rows.Count;

                        if (intRecordReturned == 0)
                        {
                            TheSortedPartNumberDataSet = ThePartNumberClass.GetPartNumberByDescriptionKey("%" + strDescription + "%");

                            intRecordReturned = TheSortedPartNumberDataSet.partnumbers.Rows.Count;

                            if (intRecordReturned == 0)
                            {
                                douPrice = 0;
                            }
                        }

                        if (intRecordReturned > 0)
                        {
                            douPrice = TheSortedPartNumberDataSet.partnumbers[0].Price;
                        }

                        douTotalPrice = douPrice * TheClevelandCountDataSet.clevelandcounts[intCounter].Quantity;

                        CountsDataSet.countsRow newTableRow = TheCountsDataSet.counts.NewcountsRow();

                        newTableRow.Description = TheClevelandCountDataSet.clevelandcounts[intCounter].Description.ToUpper();
                        newTableRow.PartNumber = strPartNumber;
                        newTableRow.Price = douTotalPrice;
                        newTableRow.Quantity = Convert.ToInt32(TheClevelandCountDataSet.clevelandcounts[intCounter].Quantity);

                        TheCountsDataSet.counts.Rows.Add(newTableRow);
                    }
                }
                if (cboWarehouse.Text == "KENTUCKY-JH")
                {
                    TheKentuckyCountsDataSet = GetKentuckyCountsInfo();

                    intNumberOfRecords = TheKentuckyCountsDataSet.kentuckycounts.Rows.Count - 1;

                    for (intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                    {
                        if(TheKentuckyCountsDataSet.kentuckycounts[intCounter].IsPartNumberNull() == false)
                        {
                            strPartNumber = TheKentuckyCountsDataSet.kentuckycounts[intCounter].PartNumber.ToUpper();
                            strDescription = TheKentuckyCountsDataSet.kentuckycounts[intCounter].Description.ToUpper();

                            TheSortedPartNumberDataSet = ThePartNumberClass.GetPartByPartNumber(strPartNumber);

                            intRecordReturned = TheSortedPartNumberDataSet.partnumbers.Rows.Count;

                            if (intRecordReturned == 0)
                            {
                                TheSortedPartNumberDataSet = ThePartNumberClass.GetPartNumberByDescriptionKey("%" + strDescription + "%");

                                intRecordReturned = TheSortedPartNumberDataSet.partnumbers.Rows.Count;

                                if (intRecordReturned == 0)
                                {
                                    douPrice = 0;
                                }
                            }

                            if (intRecordReturned > 0)
                            {
                                douPrice = TheSortedPartNumberDataSet.partnumbers[0].Price;
                            }

                            douTotalPrice = douPrice * TheKentuckyCountsDataSet.kentuckycounts[intCounter].Quantity;

                            CountsDataSet.countsRow newTableRow = TheCountsDataSet.counts.NewcountsRow();

                            newTableRow.Description = TheKentuckyCountsDataSet.kentuckycounts[intCounter].Description.ToUpper();
                            newTableRow.PartNumber = strPartNumber;
                            newTableRow.Price = douTotalPrice;
                            newTableRow.Quantity = Convert.ToInt32(TheKentuckyCountsDataSet.kentuckycounts[intCounter].Quantity);

                            TheCountsDataSet.counts.Rows.Add(newTableRow);
                        }
                        
                    }
                }
                if (cboWarehouse.Text == "JAMESTOWN-JH")
                {
                    TheJamesTownCountsDataSet = GetJamestownCountsInfo();

                    intNumberOfRecords = TheJamesTownCountsDataSet.jamestowncounts.Rows.Count - 1;

                    for (intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                    {
                        if (TheJamesTownCountsDataSet.jamestowncounts[intCounter].IsPartNumberNull() == false)
                        {
                            strPartNumber = TheJamesTownCountsDataSet.jamestowncounts[intCounter].PartNumber.ToUpper();
                            strDescription = TheJamesTownCountsDataSet.jamestowncounts[intCounter].Description.ToUpper();

                            TheSortedPartNumberDataSet = ThePartNumberClass.GetPartByPartNumber(strPartNumber);

                            intRecordReturned = TheSortedPartNumberDataSet.partnumbers.Rows.Count;

                            if (intRecordReturned == 0)
                            {
                                TheSortedPartNumberDataSet = ThePartNumberClass.GetPartNumberByDescriptionKey("%" + strDescription + "%");

                                intRecordReturned = TheSortedPartNumberDataSet.partnumbers.Rows.Count;

                                if (intRecordReturned == 0)
                                {
                                    douPrice = 0;
                                }
                            }

                            if (intRecordReturned > 0)
                            {
                                douPrice = TheSortedPartNumberDataSet.partnumbers[0].Price;
                            }

                            douTotalPrice = douPrice * TheJamesTownCountsDataSet.jamestowncounts[intCounter].Quantity;

                            CountsDataSet.countsRow newTableRow = TheCountsDataSet.counts.NewcountsRow();

                            newTableRow.Description = TheJamesTownCountsDataSet.jamestowncounts[intCounter].Description.ToUpper();
                            newTableRow.PartNumber = strPartNumber;
                            newTableRow.Price = douTotalPrice;
                            newTableRow.Quantity = Convert.ToInt32(TheJamesTownCountsDataSet.jamestowncounts[intCounter].Quantity);

                            TheCountsDataSet.counts.Rows.Add(newTableRow);
                        }

                    }
                }

                dgvInventoryCounts.DataSource = TheCountsDataSet.counts;
                cboWarehouse.Enabled = false;
                btnProcess.Enabled = true;

                PleaseWait.Hide();
            }
            catch (Exception Ex)
            {
                TheMessagesClass.ErrorMessage(Ex.ToString());
            }
           
        }
        private WisconsinCountDataSet GetWisconsinCountInfo()
        {
            try
            {
                aWisconsinCountDataSet = new WisconsinCountDataSet();
                aWisconsinCountTableAdapter = new WisconsinCountDataSetTableAdapters.wisconsincountTableAdapter();
                aWisconsinCountTableAdapter.Fill(aWisconsinCountDataSet.wisconsincount);
            }
            catch (Exception Ex)
            {
                TheMessagesClass.ErrorMessage(Ex.ToString());

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Import Inventory Counts Get Wisconsin Count Info " + Ex.Message);
            }

            //returning value
            return aWisconsinCountDataSet;
        }
        private void UpdateWisconsinCountsDB(WisconsinCountDataSet aWisconsinCountDataSet)
        {
            try
            {
                aWisconsinCountTableAdapter = new WisconsinCountDataSetTableAdapters.wisconsincountTableAdapter();
                aWisconsinCountTableAdapter.Update(aWisconsinCountDataSet.wisconsincount);
            }
            catch (Exception Ex)
            {
                TheMessagesClass.ErrorMessage(Ex.ToString());

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Import Inventory Counts UPdate Wisconsin Count DB " + Ex.Message);
            }
        }
        private ClevelandCountDataSet GetClevelandCountInfo()
        {
            try
            {
                aClevelandCountDataSet = new ClevelandCountDataSet();
                aClevelandCountTableAdapter = new ClevelandCountDataSetTableAdapters.clevelandcountsTableAdapter();
                aClevelandCountTableAdapter.Fill(aClevelandCountDataSet.clevelandcounts);
            }
            catch(Exception Ex)
            {
                TheMessagesClass.ErrorMessage(Ex.ToString());

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Import Inventory Counts Get Cleveland Count Info " + Ex.Message);
            }

            return aClevelandCountDataSet;
        }
        private void UpdateClevelandCountDB(ClevelandCountDataSet aClevelandCountDataSet)
        {
            try
            {
                aClevelandCountTableAdapter = new ClevelandCountDataSetTableAdapters.clevelandcountsTableAdapter();
                aClevelandCountTableAdapter.Update(aClevelandCountDataSet.clevelandcounts);
            }
            catch (Exception Ex)
            {
                TheMessagesClass.ErrorMessage(Ex.ToString());

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Import Inventory Counts Update Cleveland Count DB " + Ex.Message);
            }
        }
        private KentuckyCountsDataSet GetKentuckyCountsInfo()
        {
            try
            {
                aKentuckyCountsDataSet = new KentuckyCountsDataSet();
                aKentuckyCountsTableAdapter = new KentuckyCountsDataSetTableAdapters.kentuckycountsTableAdapter();
                aKentuckyCountsTableAdapter.Fill(aKentuckyCountsDataSet.kentuckycounts);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Inport Inventory Counts Get Kentucky Counts Info " + Ex.Message);

                TheMessagesClass.ErrorMessage(Ex.ToString());
            }

            //returning value
            return aKentuckyCountsDataSet;
        }
        private void UpdateKentuckyCountsDB(KentuckyCountsDataSet aKentuckyCountsDataSet)
        {
            try
            {
                aKentuckyCountsTableAdapter = new KentuckyCountsDataSetTableAdapters.kentuckycountsTableAdapter();
                aKentuckyCountsTableAdapter.Update(aKentuckyCountsDataSet.kentuckycounts);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Inport Inventory Counts Get Kentucky Counts Info " + Ex.Message);

                TheMessagesClass.ErrorMessage(Ex.ToString());
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            UpdateKentuckyCountsDB(TheKentuckyCountsDataSet);
        }
        private JamestownCountsDataSet GetJamestownCountsInfo()
        {
            try
            {
                aJamestownCountsDataSet = new JamestownCountsDataSet();
                aJamestownCountsTableAdapter = new JamestownCountsDataSetTableAdapters.jamestowncountsTableAdapter();
                aJamestownCountsTableAdapter.Fill(aJamestownCountsDataSet.jamestowncounts);
            }
            catch (Exception Ex)
            {
                TheMessagesClass.ErrorMessage(Ex.ToString());

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Import Inventory Counts Get Jamestowns Counts Info " + Ex.Message);
            }

            return aJamestownCountsDataSet;
        }
    }
}
