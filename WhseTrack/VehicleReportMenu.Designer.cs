namespace WhseTrack
{
    partial class VehicleReportMenu
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
            this.btnReportMenu = new System.Windows.Forms.Button();
            this.btnWeeklyVehicleInspections = new System.Windows.Forms.Button();
            this.btnVehicleHistory = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVehiclesSignedOut = new System.Windows.Forms.Button();
            this.btnVehiclesInYard = new System.Windows.Forms.Button();
            this.btnVehicleException = new System.Windows.Forms.Button();
            this.btnVehicleMaintenance = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(451, 380);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(189, 66);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainMenu.Location = new System.Drawing.Point(239, 380);
            this.btnMainMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(189, 66);
            this.btnMainMenu.TabIndex = 7;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // btnReportMenu
            // 
            this.btnReportMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportMenu.Location = new System.Drawing.Point(29, 380);
            this.btnReportMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReportMenu.Name = "btnReportMenu";
            this.btnReportMenu.Size = new System.Drawing.Size(189, 66);
            this.btnReportMenu.TabIndex = 6;
            this.btnReportMenu.Text = "Report Menu";
            this.btnReportMenu.UseVisualStyleBackColor = true;
            this.btnReportMenu.Click += new System.EventHandler(this.btnReportMenu_Click);
            // 
            // btnWeeklyVehicleInspections
            // 
            this.btnWeeklyVehicleInspections.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWeeklyVehicleInspections.Location = new System.Drawing.Point(29, 293);
            this.btnWeeklyVehicleInspections.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnWeeklyVehicleInspections.Name = "btnWeeklyVehicleInspections";
            this.btnWeeklyVehicleInspections.Size = new System.Drawing.Size(189, 66);
            this.btnWeeklyVehicleInspections.TabIndex = 3;
            this.btnWeeklyVehicleInspections.Text = "Weekly Vehicle Inspections";
            this.btnWeeklyVehicleInspections.UseVisualStyleBackColor = true;
            this.btnWeeklyVehicleInspections.Click += new System.EventHandler(this.btnWeeklyVehicleInspections_Click);
            // 
            // btnVehicleHistory
            // 
            this.btnVehicleHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVehicleHistory.Location = new System.Drawing.Point(29, 201);
            this.btnVehicleHistory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVehicleHistory.Name = "btnVehicleHistory";
            this.btnVehicleHistory.Size = new System.Drawing.Size(189, 66);
            this.btnVehicleHistory.TabIndex = 0;
            this.btnVehicleHistory.Text = "Vehicle History";
            this.btnVehicleHistory.UseVisualStyleBackColor = true;
            this.btnVehicleHistory.Click += new System.EventHandler(this.btnVehicleHistory_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WhseTrack.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(239, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(189, 101);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 119);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(635, 64);
            this.label1.TabIndex = 15;
            this.label1.Text = "Vehicle Report Menu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnVehiclesSignedOut
            // 
            this.btnVehiclesSignedOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVehiclesSignedOut.Location = new System.Drawing.Point(241, 201);
            this.btnVehiclesSignedOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVehiclesSignedOut.Name = "btnVehiclesSignedOut";
            this.btnVehiclesSignedOut.Size = new System.Drawing.Size(189, 66);
            this.btnVehiclesSignedOut.TabIndex = 1;
            this.btnVehiclesSignedOut.Text = "Vehicles Signed Out";
            this.btnVehiclesSignedOut.UseVisualStyleBackColor = true;
            this.btnVehiclesSignedOut.Click += new System.EventHandler(this.btnVehiclesSignedOut_Click);
            // 
            // btnVehiclesInYard
            // 
            this.btnVehiclesInYard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVehiclesInYard.Location = new System.Drawing.Point(451, 201);
            this.btnVehiclesInYard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVehiclesInYard.Name = "btnVehiclesInYard";
            this.btnVehiclesInYard.Size = new System.Drawing.Size(189, 66);
            this.btnVehiclesInYard.TabIndex = 2;
            this.btnVehiclesInYard.Text = "Vehicle In Yard";
            this.btnVehiclesInYard.UseVisualStyleBackColor = true;
            this.btnVehiclesInYard.Click += new System.EventHandler(this.btnVehiclesInYard_Click);
            // 
            // btnVehicleException
            // 
            this.btnVehicleException.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVehicleException.Location = new System.Drawing.Point(241, 293);
            this.btnVehicleException.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVehicleException.Name = "btnVehicleException";
            this.btnVehicleException.Size = new System.Drawing.Size(189, 66);
            this.btnVehicleException.TabIndex = 4;
            this.btnVehicleException.Text = "Vehicle Exception";
            this.btnVehicleException.UseVisualStyleBackColor = true;
            this.btnVehicleException.Click += new System.EventHandler(this.btnVehicleException_Click);
            // 
            // btnVehicleMaintenance
            // 
            this.btnVehicleMaintenance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVehicleMaintenance.Location = new System.Drawing.Point(451, 293);
            this.btnVehicleMaintenance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVehicleMaintenance.Name = "btnVehicleMaintenance";
            this.btnVehicleMaintenance.Size = new System.Drawing.Size(189, 66);
            this.btnVehicleMaintenance.TabIndex = 5;
            this.btnVehicleMaintenance.Text = "Vehicle Maintenance";
            this.btnVehicleMaintenance.UseVisualStyleBackColor = true;
            this.btnVehicleMaintenance.Click += new System.EventHandler(this.btnVehicleMaintenance_Click);
            // 
            // VehicleReportMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 481);
            this.ControlBox = false;
            this.Controls.Add(this.btnVehicleMaintenance);
            this.Controls.Add(this.btnVehicleException);
            this.Controls.Add(this.btnVehiclesInYard);
            this.Controls.Add(this.btnVehiclesSignedOut);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnVehicleHistory);
            this.Controls.Add(this.btnWeeklyVehicleInspections);
            this.Controls.Add(this.btnReportMenu);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnClose);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "VehicleReportMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VehicleReportMenu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Button btnReportMenu;
        private System.Windows.Forms.Button btnWeeklyVehicleInspections;
        private System.Windows.Forms.Button btnVehicleHistory;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVehiclesSignedOut;
        private System.Windows.Forms.Button btnVehiclesInYard;
        private System.Windows.Forms.Button btnVehicleException;
        private System.Windows.Forms.Button btnVehicleMaintenance;
    }
}