namespace WhseTrack
{
    partial class WarehouseInventoryReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblAddPartNumbers = new System.Windows.Forms.Label();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnInventoryReportMenu = new System.Windows.Forms.Button();
            this.btnReportMenu = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboWarehouse = new System.Windows.Forms.ComboBox();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.btnPrintReport = new System.Windows.Forms.Button();
            this.btnExportToCSV = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WhseTrack.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(541, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(171, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 76;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblAddPartNumbers
            // 
            this.lblAddPartNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddPartNumbers.Location = new System.Drawing.Point(15, 108);
            this.lblAddPartNumbers.Name = "lblAddPartNumbers";
            this.lblAddPartNumbers.Size = new System.Drawing.Size(1228, 58);
            this.lblAddPartNumbers.TabIndex = 75;
            this.lblAddPartNumbers.Text = "Warehouse Inventory Report";
            this.lblAddPartNumbers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAddPartNumbers.Click += new System.EventHandler(this.lblAddPartNumbers_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainMenu.Location = new System.Drawing.Point(1054, 547);
            this.btnMainMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(189, 66);
            this.btnMainMenu.TabIndex = 77;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1054, 618);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(189, 66);
            this.btnClose.TabIndex = 78;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnInventoryReportMenu
            // 
            this.btnInventoryReportMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventoryReportMenu.Location = new System.Drawing.Point(1054, 405);
            this.btnInventoryReportMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInventoryReportMenu.Name = "btnInventoryReportMenu";
            this.btnInventoryReportMenu.Size = new System.Drawing.Size(189, 66);
            this.btnInventoryReportMenu.TabIndex = 79;
            this.btnInventoryReportMenu.Text = "Inventory Reports";
            this.btnInventoryReportMenu.UseVisualStyleBackColor = true;
            this.btnInventoryReportMenu.Click += new System.EventHandler(this.btnInventoryMenu_Click);
            // 
            // btnReportMenu
            // 
            this.btnReportMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportMenu.Location = new System.Drawing.Point(1054, 476);
            this.btnReportMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReportMenu.Name = "btnReportMenu";
            this.btnReportMenu.Size = new System.Drawing.Size(189, 66);
            this.btnReportMenu.TabIndex = 80;
            this.btnReportMenu.Text = "Report Menu";
            this.btnReportMenu.UseVisualStyleBackColor = true;
            this.btnReportMenu.Click += new System.EventHandler(this.btnReportMenu_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(309, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 37);
            this.label2.TabIndex = 82;
            this.label2.Text = "Select Warehouse";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cboWarehouse
            // 
            this.cboWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboWarehouse.FormattingEnabled = true;
            this.cboWarehouse.Location = new System.Drawing.Point(541, 182);
            this.cboWarehouse.Name = "cboWarehouse";
            this.cboWarehouse.Size = new System.Drawing.Size(230, 37);
            this.cboWarehouse.TabIndex = 81;
            this.cboWarehouse.SelectedIndexChanged += new System.EventHandler(this.cboWarehouse_SelectedIndexChanged);
            // 
            // dgvInventory
            // 
            this.dgvInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Location = new System.Drawing.Point(20, 233);
            this.dgvInventory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.RowTemplate.Height = 24;
            this.dgvInventory.Size = new System.Drawing.Size(1028, 476);
            this.dgvInventory.TabIndex = 83;
            this.dgvInventory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventory_CellContentClick);
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintReport.Location = new System.Drawing.Point(1054, 335);
            this.btnPrintReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(189, 66);
            this.btnPrintReport.TabIndex = 84;
            this.btnPrintReport.Text = "Print Report";
            this.btnPrintReport.UseVisualStyleBackColor = true;
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // btnExportToCSV
            // 
            this.btnExportToCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportToCSV.Location = new System.Drawing.Point(1054, 265);
            this.btnExportToCSV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExportToCSV.Name = "btnExportToCSV";
            this.btnExportToCSV.Size = new System.Drawing.Size(189, 66);
            this.btnExportToCSV.TabIndex = 85;
            this.btnExportToCSV.Text = "Export To CSV";
            this.btnExportToCSV.UseVisualStyleBackColor = true;
            this.btnExportToCSV.Click += new System.EventHandler(this.btnExportToCSV_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // WarehouseInventoryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 720);
            this.ControlBox = false;
            this.Controls.Add(this.btnExportToCSV);
            this.Controls.Add(this.btnPrintReport);
            this.Controls.Add(this.dgvInventory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboWarehouse);
            this.Controls.Add(this.btnInventoryReportMenu);
            this.Controls.Add(this.btnReportMenu);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblAddPartNumbers);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WarehouseInventoryReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Warehouse Inventory Report";
            this.Load += new System.EventHandler(this.WarehouseInventoryReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Label lblAddPartNumbers;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnInventoryReportMenu;
        private System.Windows.Forms.Button btnReportMenu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboWarehouse;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.Button btnPrintReport;
        private System.Windows.Forms.Button btnExportToCSV;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}