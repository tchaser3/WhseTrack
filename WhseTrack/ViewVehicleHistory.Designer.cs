namespace WhseTrack
{
    partial class ViewVehicleHistory
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
            this.btnMainMenuj = new System.Windows.Forms.Button();
            this.btnVehicleMenu = new System.Windows.Forms.Button();
            this.btnPrintReport = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.dgvSearchResults = new System.Windows.Forms.DataGridView();
            this.btnFindVehicle = new System.Windows.Forms.Button();
            this.txtEnterBJCNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchResults)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(915, 466);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(189, 66);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMainMenuj
            // 
            this.btnMainMenuj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainMenuj.Location = new System.Drawing.Point(915, 395);
            this.btnMainMenuj.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMainMenuj.Name = "btnMainMenuj";
            this.btnMainMenuj.Size = new System.Drawing.Size(189, 66);
            this.btnMainMenuj.TabIndex = 10;
            this.btnMainMenuj.Text = "Main Menu";
            this.btnMainMenuj.UseVisualStyleBackColor = true;
            this.btnMainMenuj.Click += new System.EventHandler(this.btnMainMenuj_Click);
            // 
            // btnVehicleMenu
            // 
            this.btnVehicleMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVehicleMenu.Location = new System.Drawing.Point(915, 324);
            this.btnVehicleMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVehicleMenu.Name = "btnVehicleMenu";
            this.btnVehicleMenu.Size = new System.Drawing.Size(189, 66);
            this.btnVehicleMenu.TabIndex = 11;
            this.btnVehicleMenu.Text = "Vehicle Menu";
            this.btnVehicleMenu.UseVisualStyleBackColor = true;
            this.btnVehicleMenu.Click += new System.EventHandler(this.btnVehicleMenu_Click);
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintReport.Location = new System.Drawing.Point(915, 252);
            this.btnPrintReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(189, 66);
            this.btnPrintReport.TabIndex = 12;
            this.btnPrintReport.Text = "Print Report";
            this.btnPrintReport.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WhseTrack.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(460, 15);
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
            this.Label1.Location = new System.Drawing.Point(15, 118);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(1089, 50);
            this.Label1.TabIndex = 29;
            this.Label1.Text = "View Vehicle History";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvSearchResults
            // 
            this.dgvSearchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearchResults.Location = new System.Drawing.Point(20, 252);
            this.dgvSearchResults.Name = "dgvSearchResults";
            this.dgvSearchResults.RowTemplate.Height = 24;
            this.dgvSearchResults.Size = new System.Drawing.Size(858, 321);
            this.dgvSearchResults.TabIndex = 30;
            // 
            // btnFindVehicle
            // 
            this.btnFindVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindVehicle.Location = new System.Drawing.Point(552, 189);
            this.btnFindVehicle.Name = "btnFindVehicle";
            this.btnFindVehicle.Size = new System.Drawing.Size(133, 47);
            this.btnFindVehicle.TabIndex = 31;
            this.btnFindVehicle.Text = "Find Vehicle";
            this.btnFindVehicle.UseVisualStyleBackColor = true;
            this.btnFindVehicle.Click += new System.EventHandler(this.btnFindVehicle_Click);
            // 
            // txtEnterBJCNumber
            // 
            this.txtEnterBJCNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnterBJCNumber.Location = new System.Drawing.Point(403, 195);
            this.txtEnterBJCNumber.Name = "txtEnterBJCNumber";
            this.txtEnterBJCNumber.Size = new System.Drawing.Size(129, 30);
            this.txtEnterBJCNumber.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(206, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 25);
            this.label2.TabIndex = 33;
            this.label2.Text = "Enter BJC Number";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ViewVehicleHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 598);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEnterBJCNumber);
            this.Controls.Add(this.btnFindVehicle);
            this.Controls.Add(this.dgvSearchResults);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnPrintReport);
            this.Controls.Add(this.btnVehicleMenu);
            this.Controls.Add(this.btnMainMenuj);
            this.Controls.Add(this.btnClose);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ViewVehicleHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViewVehicleHistory";
            this.Load += new System.EventHandler(this.ViewVehicleHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMainMenuj;
        private System.Windows.Forms.Button btnVehicleMenu;
        private System.Windows.Forms.Button btnPrintReport;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.DataGridView dgvSearchResults;
        private System.Windows.Forms.Button btnFindVehicle;
        private System.Windows.Forms.TextBox txtEnterBJCNumber;
        private System.Windows.Forms.Label label2;
    }
}