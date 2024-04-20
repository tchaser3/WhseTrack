/* Title:           Main Menu
 * Author:          Terry Holmes
 * Date:            10-7-16
 * 
 * Description:     This is the main menu */

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
    public partial class MainMenu : Form
    {
        //setting up the classes
        MessagesClass TheMessagesClass = new MessagesClass();

        public MainMenu()
        {
            InitializeComponent();
        }
        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //this will close the program
            TheMessagesClass.CloseTheProgram();
        }

        private void btnToolMenu_Click(object sender, EventArgs e)
        {
            TheMessagesClass.UnderDevelopment();
        }

        private void btnInventoryMenu_Click(object sender, EventArgs e)
        {
            SelectWarehouse SelectWarehouse = new SelectWarehouse();
            SelectWarehouse.Show();
            this.Close();
        }

        private void btnAssetMenu_Click(object sender, EventArgs e)
        {
            TheMessagesClass.UnderDevelopment();
        }

        private void btnTrailerMenu_Click(object sender, EventArgs e)
        {
            TheMessagesClass.UnderDevelopment();
        }

        private void btnAdministrativeMenu_Click(object sender, EventArgs e)
        {
            //this will open the administrative menu
            AdminMenu AdminMenu = new AdminMenu();
            AdminMenu.Show();
            this.Close();
        }
        private void btnReports_Click(object sender, EventArgs e)
        {
            ReportMenu ReportMenu = new ReportMenu();
            ReportMenu.Show();
            this.Close();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            //this will display the about box
            AboutBox AboutBox = new AboutBox();
            AboutBox.ShowDialog();
        }

        private void btnVehicleMenu_Click(object sender, EventArgs e)
        {
            VehicleMenu VehicleMenu = new VehicleMenu();
            VehicleMenu.Show();
            this.Close();
        }
    }
}
