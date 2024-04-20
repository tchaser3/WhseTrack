/* Title:           Enter Inventory Form
 * Date:            11-6-16
 * Author:          Terry Holmes
 * 
 * Description:     This form is for entering inventory */

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
using ReceivedMaterialDLL;
using IssuedPartsDLL;
using BOMPartsDLL;
using KeyWordDLL;
using DataValidationDLL;
using CreateIDDLL;
using NewEmployeeDLL;
using ProjectsDLL;
using NewEventLogDLL;

namespace WhseTrack
{
    public partial class EnterInventoryForm : Form
    {
        //setting up the classes
        MessagesClass TheMessagesClass = new MessagesClass();
        InventoryClass TheInventoryClass = new InventoryClass();
        PartNumberClass ThePartNumberClass = new PartNumberClass();
        ReceivedMaterialClass TheReceivedMaterialClass = new ReceivedMaterialClass();
        IssuedPartsClass TheIssuedPartsClass = new IssuedPartsClass();
        BOMPartsClass TheBOMPartsClass = new BOMPartsClass();
        KeyWordClass TheKeyWordClass = new KeyWordClass();
        DataValidationClass TheDataValidationClass = new DataValidationClass();
        CreateIDClass TheCreateIDClass = new CreateIDClass();
        EmployeeClass TheEmployeeClass = new EmployeeClass();
        ProjectClass TheProjectClass = new ProjectClass();
        EventLogClass theEventLogClass = new EventLogClass();

        //setting up the data
        ComboEmployeeDataSet TheComboEmployeeDataSet = new ComboEmployeeDataSet();
        PartNumbersDataSet TheFilteredPartNumberDataSet = new PartNumbersDataSet();
        OrderEntryPartsDataSet TheOrderEntryPartsDataSet = new OrderEntryPartsDataSet();

        string gstrPartNumber;
        int gintPartID;

        int gintSelectedEmployeeID;
               
        //setting up global variables
        string gstrMenuSelection;

        public EnterInventoryForm()
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

        private void EnterInventoryForm_Load(object sender, EventArgs e)
        {
            //setting the test of the lable
            if (Logon.gstrMenuSelector == "RECEIVE")
                lblEnterInventory.Text = "Enter Items Received";
            else if (Logon.gstrMenuSelector == "ISSUE")
                lblEnterInventory.Text = "Enter Items Issued";
            else if (Logon.gstrMenuSelector == "BOM")
                lblEnterInventory.Text = "Enter Items on the BOM";

            //loading form global variables
            gstrMenuSelection = Logon.gstrMenuSelector;

            dgvLastTransactions.DataSource = TheOrderEntryPartsDataSet.parts;

            btnAdd.PerformClick();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //setting local variables
            string strValueForValidation;
            string strPartNumber = "";
            bool blnFatalError = false;
            bool blnThereIsAProblem = false;
            string strErrorMessage = "";            
            int intPartID = 0;
            string strJDEPartNumber = "";
            string strDescription = "";
            string strMSRNumber;
            string strProjectID;
            int intQuantity = 0;
            bool blnProjectFound;
            int intProjectID = 0;
            int intWarehouseID;
            bool blnItemUpdated = false;

            if(btnAdd.Text == "Add")
            {
                //loading controls
                txtDataEntryComplete.Text = "NO";
                txtDate.Text = Convert.ToString(DateTime.Now);
                txtWarehouseID.Text = Convert.ToString(Logon.gintWarehouseID);
                txtTransactionID.Text = Convert.ToString(TheCreateIDClass.CreateInventoryID());

                if(gstrMenuSelection == "ISSUE")
                {
                    SetIssueControlsVisible(true);
                }

                btnAdd.Text = "Save";
            }
            else
            {
                
                strPartNumber = gstrPartNumber;
                intPartID = gintPartID;
                if(gstrMenuSelection == "RECEIVE")
                {
                    strMSRNumber = txtMSRNumber.Text;
                    if(strMSRNumber == "")
                    {
                        blnThereIsAProblem = true;
                        strErrorMessage += "The MSR Number Was Not Entered\n";

                    }
                    else if(strMSRNumber == "NO MSR NUMBER")
                    {
                        blnThereIsAProblem = true;
                        strErrorMessage += "You Cannot Enter NO MSR NUMBER\n";
                    }
                }

                if (strPartNumber == null)
                {
                    blnThereIsAProblem = true;
                    strErrorMessage = strErrorMessage + "The Part Was Not Selected\n";
                }
                if (strPartNumber == "")
                {
                    blnThereIsAProblem = true;
                    strErrorMessage = strErrorMessage + "The Part Was Not Selected\n";
                }

                strProjectID = txtProjectID.Text;
                blnFatalError = TheDataValidationClass.VerifyTextData(strProjectID);
                if (blnFatalError == true)
                {
                    blnThereIsAProblem = true;
                    strErrorMessage = strErrorMessage + "The Project ID Was Not Entered\n";
                }
                else
                {
                    blnProjectFound = TheProjectClass.VerifyTWCProjectID(strProjectID);

                    if (blnProjectFound == false)
                    {
                        Logon.gstrTWCProjectID = strProjectID;
                        Logon.gstrMSRNumber = txtMSRNumber.Text;

                        AddNewProjectFromParts AddNewProjectFromParts = new AddNewProjectFromParts();
                        AddNewProjectFromParts.ShowDialog();
                    }

                    Logon.gstrTWCProjectID = strProjectID;

                    intProjectID = TheProjectClass.FindProjectID(Logon.gstrTWCProjectID);
                }


                //validating the quantity
                strValueForValidation = txtQuantity.Text;
                blnFatalError = TheDataValidationClass.VerifyIntegerData(strValueForValidation);
                if(blnThereIsAProblem == true)
                {
                    blnThereIsAProblem = true;
                    strErrorMessage = strErrorMessage + "The Quantity is not an Integer\n";
                }
                else
                {
                    intQuantity = Convert.ToInt32(strValueForValidation);
                }

                //message to the user
                if (blnThereIsAProblem == true)
                {
                    TheMessagesClass.ErrorMessage(strErrorMessage);
                    return;
                }

                intWarehouseID = Logon.gintWarehouseID;

                //try catch
                try
                {
                    if(gstrMenuSelection == "RECEIVE")
                    {
                        blnFatalError = TheReceivedMaterialClass.LoadNewReceivedPartsRow(intWarehouseID, intQuantity, Logon.gstrTWCProjectID, strPartNumber, intPartID, Logon.gstrMSRNumber, intProjectID, Logon.TheVerifyLogonDataSet.VerifyLogon[0].EmployeeID, DateTime.Now);
                                              
                        blnItemUpdated = TheInventoryClass.UpdateInventoryCount(intPartID, intWarehouseID, intQuantity);
                        if (blnItemUpdated == false)
                            blnFatalError = TheInventoryClass.CreateNewInventoryPartRecord(intPartID, strPartNumber, intWarehouseID, intQuantity);
                        if (blnFatalError == false)
                            blnItemUpdated = TheInventoryClass.UpdateWarehouseInventoryCount(intPartID, intWarehouseID, intQuantity);
                        if (blnItemUpdated == false)
                            blnFatalError = TheInventoryClass.CreateNewWarehouseInventoryPartRecord(intPartID, strPartNumber, intWarehouseID, intQuantity);   
                    }
                    if(gstrMenuSelection == "ISSUE")
                    {
                        blnFatalError = TheIssuedPartsClass.InsertNewIssuedPartsRow(DateTime.Now, Logon.gstrTWCProjectID, strPartNumber, intQuantity, intProjectID, gintSelectedEmployeeID, intWarehouseID, intPartID);

                        intQuantity = intQuantity * -1;
                        blnItemUpdated = TheInventoryClass.UpdateWarehouseInventoryCount(intPartID, intWarehouseID, intQuantity);
                        if(blnItemUpdated == false)
                             blnFatalError = TheInventoryClass.CreateNewWarehouseInventoryPartRecord(intPartID, strPartNumber, intWarehouseID, intQuantity);

                    }
                    if(gstrMenuSelection == "BOM")
                    {
                        blnFatalError = TheBOMPartsClass.InsertNewTableRow(strPartNumber, intPartID, intProjectID, DateTime.Now, Logon.gstrTWCProjectID, intWarehouseID, Convert.ToString(intQuantity));

                        intQuantity = intQuantity * -1;
                        blnItemUpdated = TheInventoryClass.UpdateInventoryCount(intPartID, intWarehouseID, intQuantity);
                        if(blnItemUpdated == false)
                            blnFatalError = TheInventoryClass.CreateNewInventoryPartRecord(intPartID, strPartNumber, intWarehouseID, intQuantity);
                    }

                    //adding a new row
                    InventoryEnteredDataSet.inventoryenteredRow NewTableRow = Logon.TheInventoryEnteredDataSet.inventoryentered.NewinventoryenteredRow();

                    NewTableRow.Date = DateTime.Now;
                    NewTableRow.Description = strDescription;
                    NewTableRow.PartID = intPartID;
                    NewTableRow.PartNumber = strPartNumber;
                    NewTableRow.ProjectID = Logon.gstrTWCProjectID;
                    NewTableRow.WarehouseID = intWarehouseID;
                    NewTableRow.JDEPartNumber = strJDEPartNumber;
                    NewTableRow.Quantity = intQuantity;

                    if(gstrMenuSelection == "ISSUE")
                    {
                        NewTableRow.EmployeeID = gintSelectedEmployeeID;
                    }
                    else
                    {
                        NewTableRow.EmployeeID = Logon.TheVerifyLogonDataSet.VerifyLogon[0].EmployeeID;
                    }
                    Logon.TheInventoryEnteredDataSet.inventoryentered.Rows.Add(NewTableRow);

                    btnAdd.Text = "Add";
                    txtPartNumber.Text = "";
                    txtQuantity.Text = "";

                    if (txtDataEntryComplete.Text == "NO")
                    {
                        btnAdd.PerformClick();
                        TheFilteredPartNumberDataSet.partnumbers.Rows.Clear();
                        gstrPartNumber = "";
                        gintPartID = 0;
                    }
                }
                catch (Exception Ex)
                {
                    TheMessagesClass.ErrorMessage(Ex.ToString());

                    theEventLogClass.InsertEventLogEntry(DateTime.Now, "Enter Inventory Informatioin Add Button " + Ex.Message);
                }
            }

            
        }

        private void txtEnterLastName_KeyDown(object sender, KeyEventArgs e)
        {
            //setting local variables
            int intCounter;
            int intNumberOfRecords;
            string strLastName;

            if(e.KeyCode == Keys.Enter)
            {
                //getting the last name
                strLastName = txtEnterLastName.Text;

                cboSelectEmployee.Items.Clear();

                TheComboEmployeeDataSet.employees.Rows.Clear();

                if(strLastName == "")
                {
                    TheMessagesClass.ErrorMessage("Employee Name Was Not Found");
                    return;
                }

                //loading the combo box
                cboSelectEmployee.Items.Add("Select Employee");

                //getting the data set
                TheComboEmployeeDataSet = TheEmployeeClass.FillEmployeeComboBox(strLastName);

                //getting the records count
                intNumberOfRecords = TheComboEmployeeDataSet.employees.Rows.Count - 1;

                if(intNumberOfRecords == -1)
                {
                    TheMessagesClass.InformationMessage("Employee Not Found");
                    return;
                }

                //loop
                for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    cboSelectEmployee.Items.Add(TheComboEmployeeDataSet.employees[intCounter].FullName);
                }

                cboSelectEmployee.SelectedIndex = 0;
            }
        }
        private void SetIssueControlsVisible(bool valueBoolean)
        {
            //routine to set controls visible
            txtEnterLastName.Visible = valueBoolean;
            lblEnterLastName.Visible = valueBoolean;
            lblSelectEmployee.Visible = valueBoolean;
            cboSelectEmployee.Visible = valueBoolean;
        }

        private void cboSelectEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            //setting local variables
            int intCounter;
            int intNumberOfRecords;

            if(cboSelectEmployee.Text != "Select Employee")
            {
                //getting the number of cords
                intNumberOfRecords = TheComboEmployeeDataSet.employees.Rows.Count - 1;

                for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    if(cboSelectEmployee.Text == TheComboEmployeeDataSet.employees[intCounter].FullName)
                    {
                        gintSelectedEmployeeID = TheComboEmployeeDataSet.employees[intCounter].EmployeeID;
                    }
                }
            }
        }

        private void btnClearGrid_Click(object sender, EventArgs e)
        {
            //this will clear the grid
            Logon.TheInventoryEnteredDataSet.inventoryentered.Rows.Clear();
        }

        private void txtPartNumber_TextChanged(object sender, EventArgs e)
        {
            string strPartDescription;
            int intCounter;
            int intNumberOfRecords;
            int intDescriptionLength;
            bool blnItemIsNotInteger;
            int intPartID;

            TheFilteredPartNumberDataSet.partnumbers.Rows.Clear();
            TheOrderEntryPartsDataSet.parts.Rows.Clear();

            strPartDescription = txtPartNumber.Text;

            intDescriptionLength = strPartDescription.Length;

            //checking part number
            if(intDescriptionLength >= 4)
            {
                blnItemIsNotInteger = TheDataValidationClass.VerifyIntegerData(strPartDescription);

                if(blnItemIsNotInteger == false)
                {
                    intPartID = Convert.ToInt32(strPartDescription);

                    TheFilteredPartNumberDataSet = ThePartNumberClass.GetPartNumberByPartID(intPartID);

                    intNumberOfRecords = TheFilteredPartNumberDataSet.partnumbers.Rows.Count;

                    if(intNumberOfRecords > 0)
                    {
                        gstrPartNumber = TheFilteredPartNumberDataSet.partnumbers[0].PartNumber;
                        gintPartID = intPartID;
                        //txtPartNumber.Text = gstrPartNumber;
                    }
                }
            }

            if(intDescriptionLength >= 5)
            {
                TheFilteredPartNumberDataSet = ThePartNumberClass.GetPartByPartNumber(strPartDescription);

                intNumberOfRecords = TheFilteredPartNumberDataSet.partnumbers.Rows.Count - 1;

                if (intNumberOfRecords == -1)
                {
                    TheFilteredPartNumberDataSet = ThePartNumberClass.FindPartByJDEPartNumber(strPartDescription);

                    intNumberOfRecords = TheFilteredPartNumberDataSet.partnumbers.Rows.Count - 1;

                    if (intNumberOfRecords == -1)
                    {
                        strPartDescription = "%" + txtPartNumber.Text + "%";

                        TheFilteredPartNumberDataSet = ThePartNumberClass.GetPartNumberByDescriptionKey(strPartDescription);

                        intNumberOfRecords = TheFilteredPartNumberDataSet.partnumbers.Rows.Count - 1;
                    }
                    else
                    {
                        gstrPartNumber = TheFilteredPartNumberDataSet.partnumbers[0].PartNumber;
                        gintPartID = TheFilteredPartNumberDataSet.partnumbers[0].PartID;
                    }
                }
                else
                {
                    gstrPartNumber = TheFilteredPartNumberDataSet.partnumbers[0].PartNumber;
                    gintPartID = TheFilteredPartNumberDataSet.partnumbers[0].PartID;
                }
            }
            else if (intDescriptionLength > 3)
            {
                strPartDescription = "%" + txtPartNumber.Text + "%";

                TheFilteredPartNumberDataSet = ThePartNumberClass.GetPartNumberByDescriptionKey(strPartDescription);

                intNumberOfRecords = TheFilteredPartNumberDataSet.partnumbers.Rows.Count - 1;
            }
            else
            {
                intNumberOfRecords = -1;
            }
            
            if (intNumberOfRecords > -1)
            {
                for (intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    OrderEntryPartsDataSet.partsRow NewPartRow = TheOrderEntryPartsDataSet.parts.NewpartsRow();

                    NewPartRow.Description = TheFilteredPartNumberDataSet.partnumbers[intCounter].Description;
                    NewPartRow.JDEPartNumber = TheFilteredPartNumberDataSet.partnumbers[intCounter].JDEPartNumber;
                    NewPartRow.PartID = TheFilteredPartNumberDataSet.partnumbers[intCounter].PartID;
                    NewPartRow.PartNumber = TheFilteredPartNumberDataSet.partnumbers[intCounter].PartNumber;

                    TheOrderEntryPartsDataSet.parts.Rows.Add(NewPartRow);
                }
            }

            dgvLastTransactions.DataSource = TheOrderEntryPartsDataSet.parts;
        }

        private void dgvLastTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLastTransactions.Rows[e.RowIndex];

                gstrPartNumber = row.Cells["PartNumber"].Value.ToString();

                gintPartID = Convert.ToInt32(row.Cells["PartID"].Value.ToString());

                TheMessagesClass.InformationMessage(gstrPartNumber + " " + Convert.ToString(gintPartID));
            }
        }

        private void txtEnterLastName_TextChanged(object sender, EventArgs e)
        {
            string strLastName;
            int intNumberOfRecords;
            int intCounter;

            //getting the last name
            strLastName = txtEnterLastName.Text;

            cboSelectEmployee.Items.Clear();

            TheComboEmployeeDataSet.employees.Rows.Clear();

            if (strLastName == "")
            {
                TheMessagesClass.ErrorMessage("Employee Name Was Not Found");
                return;
            }

            //loading the combo box
            cboSelectEmployee.Items.Add("Select Employee");

            //getting the data set
            TheComboEmployeeDataSet = TheEmployeeClass.FillEmployeeComboBox(strLastName);

            //getting the records count
            intNumberOfRecords = TheComboEmployeeDataSet.employees.Rows.Count - 1;

            if (intNumberOfRecords == -1)
            {
                TheMessagesClass.InformationMessage("Employee Not Found");
                return;
            }

            //loop
            for (intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
            {
                cboSelectEmployee.Items.Add(TheComboEmployeeDataSet.employees[intCounter].FullName);
            }

            cboSelectEmployee.SelectedIndex = 0;
        }

        private void btnChangeWarehouse_Click(object sender, EventArgs e)
        {
            Logon.gstrMenuSelector = "DATAENTRY";

            SelectWarehouse SelectWarehouse = new SelectWarehouse();
            SelectWarehouse.ShowDialog();

            txtWarehouseID.Text = Convert.ToString(Logon.gintWarehouseID);
        }

        private void txtProjectID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
