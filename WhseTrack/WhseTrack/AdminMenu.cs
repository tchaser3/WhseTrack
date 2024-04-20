/* Title:           Admin Menu
 * Date:            10-21-16
 * Author:          Terry Holmes
 * 
 * Descriptioin:    This form is used as the administrative menu */

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
    public partial class AdminMenu : Form
    {
        //setting up the classes
        MessagesClass TheMessagesClass = new MessagesClass();

        public AdminMenu()
        {
            InitializeComponent();
        }

        private void AdminMenu_Load(object sender, EventArgs e)
        {

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

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutBox AboutBox = new AboutBox();
            AboutBox.ShowDialog();
        }

        private void btnOnBoardNewEmployee_Click(object sender, EventArgs e)
        {
            TheMessagesClass.UnderDevelopment();
        }

        private void btnTerminateEmployee_Click(object sender, EventArgs e)
        {
            TheMessagesClass.UnderDevelopment();
        }

        private void btnVoidCableTransaction_Click(object sender, EventArgs e)
        {
            TheMessagesClass.UnderDevelopment();
        }
        private void btnCreateProjects_Click(object sender, EventArgs e)
        {
            TheMessagesClass.UnderDevelopment();
        }

        private void btnViewLastTransaction_Click(object sender, EventArgs e)
        {
            TheMessagesClass.UnderDevelopment();
        }

        private void btnViewEventLog_Click(object sender, EventArgs e)
        {
            ViewEventLog ViewEventLog = new ViewEventLog();
            ViewEventLog.Show();
            this.Close();
        }

        private void btnUtilitiesMenu_Click(object sender, EventArgs e)
        {
            UtilitiesMenu UtilitiesMenu = new UtilitiesMenu();
            UtilitiesMenu.Show();
            this.Close();
        }

        private void btnCreateNewPartNumbers_Click(object sender, EventArgs e)
        {
            CreateNewPart CreateNewPart = new CreateNewPart();
            CreateNewPart.Show();
            this.Close();
        }

        private void btnAddPartNumbers_Click(object sender, EventArgs e)
        {
            AddPartNumbers AddPartNumbers = new AddPartNumbers();
            AddPartNumbers.Show();
            this.Close();
        }
    }
}
