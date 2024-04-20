/* Title:           Inventory Reports
 * Date:            11-29-16
 * Author:          Terry Holmes
 * 
 * Description:     This is the inventory reports menu */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhseTrack
{
    public partial class InventoryReports : Form
    {
        //setting up the classes
        MessagesClass TheMessagesClass = new MessagesClass();

        public InventoryReports()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //this will close the application
            TheMessagesClass.CloseTheProgram();
        }

        private void btnReportMenu_Click(object sender, EventArgs e)
        {
            ReportMenu ReportMenu = new ReportMenu();
            ReportMenu.Show();
            this.Close();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            MainMenu MainMenu = new MainMenu();
            MainMenu.Show();
            this.Close();
        }
        
        private void btnWarehouseInventoryReport_Click(object sender, EventArgs e)
        {
            WarehouseInventoryReport WarehouseInventoryReport = new WarehouseInventoryReport();
            WarehouseInventoryReport.Show();
            this.Close();
        }

        private void btnProjectPartReport_Click(object sender, EventArgs e)
        {
            ProjectPartReport ProjectPartReport = new ProjectPartReport();
            ProjectPartReport.Show();
            this.Close();
        }

        private void btnDatePartSearch_Click(object sender, EventArgs e)
        {
            DatePartSearch DatePartSearch = new DatePartSearch();
            DatePartSearch.Show();
            this.Close();
        }

        private void btnInventoryEvaluation_Click(object sender, EventArgs e)
        {
            InventoryEvaluation InventoryEvaluation = new InventoryEvaluation();
            InventoryEvaluation.Show();
            this.Close();
        }

        private void btnWarehouseTransactionReport_Click(object sender, EventArgs e)
        {
            Logon.gstrMenuSelector = "WAREHOUSETRANSACTIONREPORT";

            DateParameters DateParameters = new DateParameters();
            DateParameters.Show();
            this.Close();
        }
    }
}
