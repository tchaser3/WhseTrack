namespace WhseTrack
{
    partial class VehicleInspectionAuditReport
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.btnVehicleMenu = new System.Windows.Forms.Button();
            this.btnCSVFile = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.dgvSearchResults = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEnterBJCNumber = new System.Windows.Forms.TextBox();
            this.btnFindVehicle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchResults)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1055, 457);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(189, 66);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainMenu.Location = new System.Drawing.Point(1055, 387);
            this.btnMainMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(189, 66);
            this.btnMainMenu.TabIndex = 13;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // btnVehicleMenu
            // 
            this.btnVehicleMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVehicleMenu.Location = new System.Drawing.Point(1055, 317);
            this.btnVehicleMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVehicleMenu.Name = "btnVehicleMenu";
            this.btnVehicleMenu.Size = new System.Drawing.Size(189, 66);
            this.btnVehicleMenu.TabIndex = 14;
            this.btnVehicleMenu.Text = "Vehicle Menu";
            this.btnVehicleMenu.UseVisualStyleBackColor = true;
            this.btnVehicleMenu.Click += new System.EventHandler(this.btnVehicleMenu_Click);
            // 
            // btnCSVFile
            // 
            this.btnCSVFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCSVFile.Location = new System.Drawing.Point(1055, 247);
            this.btnCSVFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCSVFile.Name = "btnCSVFile";
            this.btnCSVFile.Size = new System.Drawing.Size(189, 66);
            this.btnCSVFile.TabIndex = 15;
            this.btnCSVFile.Text = "CSV File";
            this.btnCSVFile.UseVisualStyleBackColor = true;
            this.btnCSVFile.Click += new System.EventHandler(this.btnCSVFile_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WhseTrack.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(530, 19);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(197, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(12, 120);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(1232, 50);
            this.Label1.TabIndex = 27;
            this.Label1.Text = "Vehicle Inspection Audit Report";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvSearchResults
            // 
            this.dgvSearchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearchResults.Location = new System.Drawing.Point(38, 262);
            this.dgvSearchResults.Name = "dgvSearchResults";
            this.dgvSearchResults.RowTemplate.Height = 24;
            this.dgvSearchResults.Size = new System.Drawing.Size(983, 340);
            this.dgvSearchResults.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(321, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 25);
            this.label2.TabIndex = 36;
            this.label2.Text = "Enter BJC Number";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEnterBJCNumber
            // 
            this.txtEnterBJCNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnterBJCNumber.Location = new System.Drawing.Point(518, 194);
            this.txtEnterBJCNumber.Name = "txtEnterBJCNumber";
            this.txtEnterBJCNumber.Size = new System.Drawing.Size(129, 30);
            this.txtEnterBJCNumber.TabIndex = 35;
            // 
            // btnFindVehicle
            // 
            this.btnFindVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindVehicle.Location = new System.Drawing.Point(667, 188);
            this.btnFindVehicle.Name = "btnFindVehicle";
            this.btnFindVehicle.Size = new System.Drawing.Size(133, 47);
            this.btnFindVehicle.TabIndex = 34;
            this.btnFindVehicle.Text = "Find Vehicle";
            this.btnFindVehicle.UseVisualStyleBackColor = true;
            this.btnFindVehicle.Click += new System.EventHandler(this.btnFindVehicle_Click);
            // 
            // VehicleInspectionAuditReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 624);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEnterBJCNumber);
            this.Controls.Add(this.btnFindVehicle);
            this.Controls.Add(this.dgvSearchResults);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnCSVFile);
            this.Controls.Add(this.btnVehicleMenu);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnClose);
            this.Name = "VehicleInspectionAuditReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VehicleInspectionAuditReport";
            this.Load += new System.EventHandler(this.VehicleInspectionAuditReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Button btnVehicleMenu;
        private System.Windows.Forms.Button btnCSVFile;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.DataGridView dgvSearchResults;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEnterBJCNumber;
        private System.Windows.Forms.Button btnFindVehicle;
    }
}