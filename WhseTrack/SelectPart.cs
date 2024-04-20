/* Title:           Select Part
 * Date:            11-7-16
 * Author:          Terry Holmes
 * 
 * Description:     This form will allow the user to select a part number from an array of parts */

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
    public partial class SelectPart : Form
    {
        MessagesClass TheMessgesClass = new MessagesClass();
        EventLogClass TheEventLogClass = new EventLogClass();

        public SelectPart()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SelectPart_Load(object sender, EventArgs e)
        {
            try
            {
                dgvParts.DataSource = Logon.ThePartSelectionDataSet.partsselected;
            }
            catch (Exception Ex)
            {
                TheMessgesClass.ErrorMessage(Ex.ToString());

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Whse Track Select Parts Form Load " + Ex.Message);
            }
        }
    }
}
