/* Title:           Check Part Number
 * Date:            12-14-16
 * Author:          Terry Holmes
 * 
 * Description:     This form will allow the user to check the part number */

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
    public partial class CheckPartInfo : Form
    {
        public CheckPartInfo()
        {
            InitializeComponent();
        }

        private void CheckPartInfo_Load(object sender, EventArgs e)
        {
            dgvCount.DataSource = ImportInventoryCounts.ThePublicCountDataSet.clevelandcounts;

            dgvPart.DataSource = ImportInventoryCounts.TheSelectPartDataSet.selectpart;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
