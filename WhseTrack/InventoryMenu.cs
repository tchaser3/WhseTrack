/* Title:           Inventory Menu
 * Date:            10-29-16
 * Author:          Terry Holmes
 * 
 * Description:     This form is the menu for inventory */

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
    public partial class InventoryMenu : Form
    {
        //setting up the classes
        MessagesClass TheMessagesClass = new MessagesClass();

        public InventoryMenu()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //This will close the program
            TheMessagesClass.CloseTheProgram();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            MainMenu MainMenu = new MainMenu();
            MainMenu.Show();
            this.Close();
        }

        private void btnRecieveMaterial_Click(object sender, EventArgs e)
        {
            Logon.gstrMenuSelector = "RECEIVE";
            EnterInventoryForm EnterInventoryForm = new EnterInventoryForm();
            EnterInventoryForm.Show();
            this.Close();
        }

        private void btnIssueMaterial_Click(object sender, EventArgs e)
        {
            Logon.gstrMenuSelector = "ISSUE";
            EnterInventoryForm EnterInventoryForm = new EnterInventoryForm();
            EnterInventoryForm.Show();
            this.Close();
        }

        private void btnEnterBOM_Click(object sender, EventArgs e)
        {
            Logon.gstrMenuSelector = "BOM";
            EnterInventoryForm EnterInventoryForm = new EnterInventoryForm();
            EnterInventoryForm.Show();
            this.Close();
        }

        private void btnViewMaterialInventory_Click(object sender, EventArgs e)
        {
            TheMessagesClass.UnderDevelopment();
        }

        private void btnReceiveCable_Click(object sender, EventArgs e)
        {
            TheMessagesClass.UnderDevelopment();
        }

        private void btnIssueCable_Click(object sender, EventArgs e)
        {
            TheMessagesClass.UnderDevelopment();
        }

        private void btnEnterBOMCable_Click(object sender, EventArgs e)
        {
            TheMessagesClass.UnderDevelopment();
        }

        private void btnViewCableInventory_Click(object sender, EventArgs e)
        {
            TheMessagesClass.UnderDevelopment();
        }

        private void btnAdjustInventory_Click(object sender, EventArgs e)
        {
            AdjustInventory AdjustInventory = new AdjustInventory();
            AdjustInventory.Show();
            this.Close();
        }

        private void btnTWCPartMatrix_Click(object sender, EventArgs e)
        {
            PartNumberMatrix PartNumberMatrix = new PartNumberMatrix();
            PartNumberMatrix.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TheMessagesClass.UnderDevelopment();
        }

        private void btnMaterialMaxMin_Click(object sender, EventArgs e)
        {
            TheMessagesClass.UnderDevelopment();
        }

        private void btnCheckPartID_Click(object sender, EventArgs e)
        {
            CheckForPartID CheckForPartID = new CheckForPartID();
            CheckForPartID.Show();
            this.Close();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutBox AboutBox = new AboutBox();
            AboutBox.ShowDialog();
        }
    }
}
