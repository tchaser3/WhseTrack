/* Title:           Utitilies Menu
 * Date:            11-19-16
 * Author:          Terry Holmes
 * 
 * Description:     This will be the untilities menu */

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
    public partial class UtilitiesMenu : Form
    {
        //setting up classes
        MessagesClass TheMessagesClass = new MessagesClass();

        public UtilitiesMenu()
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

        private void btnImportPartNumbers_Click(object sender, EventArgs e)
        {
            ImportPartNumbers ImportPartNumbers = new ImportPartNumbers();
            ImportPartNumbers.Show();
            this.Close();
        }

        private void btnRemovePartNumbers_Click(object sender, EventArgs e)
        {
            RemovePartNumbers RemovePartNumbers = new RemovePartNumbers();
            RemovePartNumbers.Show();
            this.Close();
        }

        private void btnCheckInventoryTables_Click(object sender, EventArgs e)
        {
            CheckInventoryTables CheckInventoryTables = new CheckInventoryTables();
            CheckInventoryTables.Show();
            this.Close();
        }

        private void btnImportInventoryCounts_Click(object sender, EventArgs e)
        {
            ImportInventoryCounts ImportInventoryCounts = new ImportInventoryCounts();
            ImportInventoryCounts.Show();
            this.Close();
        }
    }
}
