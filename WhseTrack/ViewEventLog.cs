/* Title:           View Event Log
 * Date:            12-22-16
 * Author:          Terry Holmes
 * 
 * Description:     This form will view the event log*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewEventLogDLL;

namespace WhseTrack
{
    public partial class ViewEventLog : Form
    {
        //setting up the class
        EventLogClass TheEventLogClass = new EventLogClass();
        MessagesClass TheMessagesClass = new MessagesClass();

        //setting up the data
        EventLogDataSet TheEventLogDatgSet;

        public ViewEventLog()
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

        private void btnAdminMenu_Click(object sender, EventArgs e)
        {
            AdminMenu AdminMenu = new AdminMenu();
            AdminMenu.Show();
            this.Close();
        }

        private void ViewEventLog_Load(object sender, EventArgs e)
        {
            //this will load the grid
            try
            {
                TheEventLogDatgSet = TheEventLogClass.GetEventLogInfo();

                dgvEventLog.DataSource = TheEventLogDatgSet.eventlog;
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track View Event Log Form Load " + Ex.Message);

                TheMessagesClass.ErrorMessage(Ex.ToString());
            }
        }
    }
}
