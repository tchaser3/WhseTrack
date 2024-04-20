namespace WhseTrack
{
    partial class ProjectPartReport
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
            this.btnExportToCSV = new System.Windows.Forms.Button();
            this.btnPrintReport = new System.Windows.Forms.Button();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.btnInventoryReportMenu = new System.Windows.Forms.Button();
            this.btnReportMenu = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblAddPartNumbers = new System.Windows.Forms.Label();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.txtProject = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExportToCSV
            // 
            this.btnExportToCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportToCSV.Location = new System.Drawing.Point(808, 212);
            this.btnExportToCSV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExportToCSV.Name = "btnExportToCSV";
            this.btnExportToCSV.Size = new System.Drawing.Size(142, 54);
            this.btnExportToCSV.TabIndex = 96;
            this.btnExportToCSV.Text = "Export To CSV";
            this.btnExportToCSV.UseVisualStyleBackColor = true;
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintReport.Location = new System.Drawing.Point(808, 269);
            this.btnPrintReport.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(142, 54);
            this.btnPrintReport.TabIndex = 95;
            this.btnPrintReport.Text = "Print Report";
            this.btnPrintReport.UseVisualStyleBackColor = true;
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // dgvInventory
            // 
            this.dgvInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Location = new System.Drawing.Point(32, 212);
            this.dgvInventory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.RowTemplate.Height = 24;
            this.dgvInventory.Size = new System.Drawing.Size(771, 361);
            this.dgvInventory.TabIndex = 94;
            this.dgvInventory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventory_CellContentClick);
            // 
            // btnInventoryReportMenu
            // 
            this.btnInventoryReportMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventoryReportMenu.Location = new System.Drawing.Point(808, 326);
            this.btnInventoryReportMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnInventoryReportMenu.Name = "btnInventoryReportMenu";
            this.btnInventoryReportMenu.Size = new System.Drawing.Size(142, 54);
            this.btnInventoryReportMenu.TabIndex = 90;
            this.btnInventoryReportMenu.Text = "Inventory Reports";
            this.btnInventoryReportMenu.UseVisualStyleBackColor = true;
            this.btnInventoryReportMenu.Click += new System.EventHandler(this.btnInventoryReportMenu_Click);
            // 
            // btnReportMenu
            // 
            this.btnReportMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportMenu.Location = new System.Drawing.Point(808, 384);
            this.btnReportMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReportMenu.Name = "btnReportMenu";
            this.btnReportMenu.Size = new System.Drawing.Size(142, 54);
            this.btnReportMenu.TabIndex = 91;
            this.btnReportMenu.Text = "Report Menu";
            this.btnReportMenu.UseVisualStyleBackColor = true;
            this.btnReportMenu.Click += new System.EventHandler(this.btnReportMenu_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainMenu.Location = new System.Drawing.Point(808, 441);
            this.btnMainMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(142, 54);
            this.btnMainMenu.TabIndex = 88;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(808, 499);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(142, 54);
            this.btnClose.TabIndex = 89;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WhseTrack.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(428, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 87;
            this.pictureBox1.TabStop = false;
            // 
            // lblAddPartNumbers
            // 
            this.lblAddPartNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddPartNumbers.Location = new System.Drawing.Point(9, 84);
            this.lblAddPartNumbers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddPartNumbers.Name = "lblAddPartNumbers";
            this.lblAddPartNumbers.Size = new System.Drawing.Size(960, 47);
            this.lblAddPartNumbers.TabIndex = 86;
            this.lblAddPartNumbers.Text = "Project Part Report";
            this.lblAddPartNumbers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // txtProject
            // 
            this.txtProject.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProject.Location = new System.Drawing.Point(440, 168);
            this.txtProject.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtProject.Name = "txtProject";
            this.txtProject.Size = new System.Drawing.Size(133, 26);
            this.txtProject.TabIndex = 97;
            this.txtProject.TextChanged += new System.EventHandler(this.txtProject_TextChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(286, 162);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 37);
            this.label1.TabIndex = 98;
            this.label1.Text = "Enter Project Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ProjectPartReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(978, 581);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtProject);
            this.Controls.Add(this.btnExportToCSV);
            this.Controls.Add(this.btnPrintReport);
            this.Controls.Add(this.dgvInventory);
            this.Controls.Add(this.btnInventoryReportMenu);
            this.Controls.Add(this.btnReportMenu);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblAddPartNumbers);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ProjectPartReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProjectPartReport";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExportToCSV;
        private System.Windows.Forms.Button btnPrintReport;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.Button btnInventoryReportMenu;
        private System.Windows.Forms.Button btnReportMenu;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Label lblAddPartNumbers;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.TextBox txtProject;
        private System.Windows.Forms.Label label1;
    }
}