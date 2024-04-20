/* Title:           Date Parameters
 * Date:            10-13-16
 * Author:          Terry Holmes
 * 
 * Description:     This is the box that allows the date to be searched */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DateSearchDLL;
using DataValidationDLL;
using EventLogDLL;

namespace WhseTrack
{
    public partial class DateParameters : Form
    {
        //setting up the classes
        MessagesClass TheMessagesClass = new MessagesClass();
        DataValidationClass TheDataValidationClass = new DataValidationClass();
        DateSearchClass TheDateSearchClass = new DateSearchClass();
        EventLogClass TheEventLogClass = new EventLogClass();

        public DateParameters()
        {
            InitializeComponent();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            //calling the main menu
            MainMenu MainMenu = new MainMenu();
            MainMenu.Show();
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //setting up the variables
            string strValueForValidation;
            bool blnFatalError = false;
            bool blnThereIsAProblem = false;
            string strErrorMessage = "";

            //performing data validation
            strValueForValidation = txtStartDate.Text;
            blnFatalError = TheDataValidationClass.VerifyDateData(strValueForValidation);
            if(blnFatalError == true)
            {
                blnThereIsAProblem = true;
                strErrorMessage = strErrorMessage + "The Start Date is not a Date\n";
            }
            else
            {
                Logon.gdatStartDate = Convert.ToDateTime(strValueForValidation);
                Logon.gdatStartDate = TheDateSearchClass.RemoveTime(Logon.gdatStartDate);
            }
            strValueForValidation = txtEndDate.Text;
            blnFatalError = TheDataValidationClass.VerifyDateData(strValueForValidation);
            if (blnFatalError == true)
            {
                blnThereIsAProblem = true;
                strErrorMessage = strErrorMessage + "The End Date is not a Date\n";
            }
            else
            {
                Logon.gdatEndDate = Convert.ToDateTime(strValueForValidation);
                Logon.gdatEndDate = TheDateSearchClass.RemoveTime(Logon.gdatEndDate);
            }
            if(blnThereIsAProblem == false)
            {
                blnFatalError = TheDataValidationClass.verifyDateRange(Logon.gdatStartDate, Logon.gdatEndDate);
                if(blnFatalError == true)
                {
                    blnThereIsAProblem = true;
                    strErrorMessage = "The End Date is Before the Start Date";
                }
            }
            if(blnThereIsAProblem == true)
            {
                TheMessagesClass.ErrorMessage(strErrorMessage);
                return;
            }

            //beginning decision
            if(Logon.gstrMenuSelector == "VEHICLEHISTORY")
            {
                ViewVehicleHistory ViewVehicleHistory = new ViewVehicleHistory();
                ViewVehicleHistory.Show();
            }
            else if(Logon.gstrMenuSelector == "VEHICLEINSPECTIONAUDIT")
            {
                VehicleInspectionAuditReport VehicleInspectionAuditReport = new VehicleInspectionAuditReport();
                VehicleInspectionAuditReport.Show();
            }
            else if(Logon.gstrMenuSelector == "WAREHOUSETRANSACTIONREPORT")
            {
                WarehouseTransactionReport WarehouseTransactionReport = new WarehouseTransactionReport();
                WarehouseTransactionReport.Show();
            }
            else
            {
                btnMainMenu.PerformClick();
            }

            this.Close();
        }
    }
}
