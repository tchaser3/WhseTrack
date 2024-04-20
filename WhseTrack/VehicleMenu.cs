/* Title:           Vehicle Menu
 * Date:            10-13-16
 * Author:          Terry Holmes
 * 
 * Description:     This is the vehicle menu */

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
    public partial class VehicleMenu : Form
    {
        //setting up the classes
        MessagesClass TheMessagesCless = new MessagesClass();

        public VehicleMenu()
        {
            InitializeComponent();
        }

        private void btnSignInOutVehicle_Click(object sender, EventArgs e)
        {
            SignOutVehicle SignOutVehicle = new SignOutVehicle();
            SignOutVehicle.Show();
            this.Close();
        }

        private void btnVehicleDashboard_Click(object sender, EventArgs e)
        {
            TheMessagesCless.UnderDevelopment();
        }

        private void btnDOTFormEntry_Click(object sender, EventArgs e)
        {
            TheMessagesCless.UnderDevelopment();
        }

        private void btnDailyInspections_Click(object sender, EventArgs e)
        {
            TheMessagesCless.UnderDevelopment();
        }


        private void btnWeeklyInspections_Click(object sender, EventArgs e)
        {
            TheMessagesCless.UnderDevelopment();
        }

        private void btnVehiclesInYard_Click(object sender, EventArgs e)
        {
            TheMessagesCless.UnderDevelopment();
        }

        private void btnVehicleMaintenance_Click(object sender, EventArgs e)
        {
            TheMessagesCless.UnderDevelopment();
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
            TheMessagesCless.CloseTheProgram();
        }

        private void btnViewVehicleHistory_Click(object sender, EventArgs e)
        {
            Logon.gstrMenuSelector = "VEHICLEHISTORY";
            DateParameters DateParameters = new DateParameters();
            DateParameters.Show();
            this.Close();
        }

        private void btnVehicleInspectionAudit_Click(object sender, EventArgs e)
        {
            //Calling the vehicle inspection audit form
            Logon.gstrMenuSelector = "VEHICLEINSPECTIONAUDIT";
            DateParameters DateParameters = new DateParameters();
            DateParameters.Show();
            this.Close();
        }
    }
}
