/* Title:           Report Menu
 * Date:            11-28-16
 * Author:          Terry Holmes
 * 
 * Description:     This form is the report menu */

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
    public partial class ReportMenu : Form
    {
        //setting up the classes
        MessagesClass TheMessagesClass = new MessagesClass();

        public ReportMenu()
        {
            InitializeComponent();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutBox AboutBox = new AboutBox();
            AboutBox.ShowDialog();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            MainMenu MainMenu = new MainMenu();
            MainMenu.Show();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //this will close the program
            TheMessagesClass.CloseTheProgram();
        }

        private void btnInventoryReports_Click(object sender, EventArgs e)
        {
            InventoryReports InventoryReports = new InventoryReports();
            InventoryReports.Show();
            this.Close();
        }

        private void btnToolReports_Click(object sender, EventArgs e)
        {
            TheMessagesClass.UnderDevelopment();
        }

        private void btnVehicleReports_Click(object sender, EventArgs e)
        {
            VehicleReportMenu VehicleReportMenu = new VehicleReportMenu();
            VehicleReportMenu.Show();
            this.Close();
        }

        private void btnTrailerReports_Click(object sender, EventArgs e)
        {
            TheMessagesClass.UnderDevelopment();
        }

        private void btnAssetReports_Click(object sender, EventArgs e)
        {
            TheMessagesClass.UnderDevelopment();
        }

        private void btnInspectionReports_Click(object sender, EventArgs e)
        {
            TheMessagesClass.UnderDevelopment();
        }
    }
}
