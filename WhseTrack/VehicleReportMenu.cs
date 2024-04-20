/* Title:           Vehicle Report Menu
 * Date:            2-9-17
 * Author:          Terry Holmes
 * 
 * Description:     This is the menu for vehicle reports */

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
    public partial class VehicleReportMenu : Form
    {
        MessagesClass TheMessagesClass = new MessagesClass();

        public VehicleReportMenu()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
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

        private void btnVehicleMaintenance_Click(object sender, EventArgs e)
        {
            TheMessagesClass.UnderDevelopment();
        }

        private void btnVehicleHistory_Click(object sender, EventArgs e)
        {
            TheMessagesClass.UnderDevelopment();
        }

        

        private void btnWeeklyVehicleInspections_Click(object sender, EventArgs e)
        {
            TheMessagesClass.UnderDevelopment();
        }

        private void btnVehicleException_Click(object sender, EventArgs e)
        {
            VehicleExceptionReport VehicleExceptionReport = new VehicleExceptionReport();
            VehicleExceptionReport.Show();
            this.Close();
        }

        private void btnVehiclesSignedOut_Click(object sender, EventArgs e)
        {
            VehiclesSignedOut VehiclesSignedOut = new VehiclesSignedOut();
            VehiclesSignedOut.Show();
            this.Close();
        }

        private void btnVehiclesInYard_Click(object sender, EventArgs e)
        {
            VehiclesInYardReport VehiclesInYardReport = new VehiclesInYardReport();
            VehiclesInYardReport.Show();
            Close();
        }
    }
}
