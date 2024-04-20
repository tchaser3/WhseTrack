namespace WhseTrack
{
    partial class ImportPartNumbers
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
            this.btnAdminMenu = new System.Windows.Forms.Button();
            this.btnUtilitiesMenu = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvParts = new System.Windows.Forms.DataGridView();
            this.btnCheckPartNumbers = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1297, 539);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(189, 66);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainMenu.Location = new System.Drawing.Point(1297, 469);
            this.btnMainMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(189, 66);
            this.btnMainMenu.TabIndex = 16;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // btnAdminMenu
            // 
            this.btnAdminMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminMenu.Location = new System.Drawing.Point(1297, 399);
            this.btnAdminMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdminMenu.Name = "btnAdminMenu";
            this.btnAdminMenu.Size = new System.Drawing.Size(189, 66);
            this.btnAdminMenu.TabIndex = 17;
            this.btnAdminMenu.Text = "Admin Menu";
            this.btnAdminMenu.UseVisualStyleBackColor = true;
            this.btnAdminMenu.Click += new System.EventHandler(this.btnAdminMenu_Click);
            // 
            // btnUtilitiesMenu
            // 
            this.btnUtilitiesMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUtilitiesMenu.Location = new System.Drawing.Point(1297, 328);
            this.btnUtilitiesMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUtilitiesMenu.Name = "btnUtilitiesMenu";
            this.btnUtilitiesMenu.Size = new System.Drawing.Size(189, 66);
            this.btnUtilitiesMenu.TabIndex = 18;
            this.btnUtilitiesMenu.Text = "Utilities Menu";
            this.btnUtilitiesMenu.UseVisualStyleBackColor = true;
            this.btnUtilitiesMenu.Click += new System.EventHandler(this.btnUtilitiesMenu_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.Location = new System.Drawing.Point(1297, 189);
            this.btnProcess.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(189, 66);
            this.btnProcess.TabIndex = 20;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(12, 114);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(1456, 50);
            this.Label1.TabIndex = 38;
            this.Label1.Text = "Import CSV Part File";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WhseTrack.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(641, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(197, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // dgvParts
            // 
            this.dgvParts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            this.dgvParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParts.Location = new System.Drawing.Point(17, 190);
            this.dgvParts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvParts.Name = "dgvParts";
            this.dgvParts.RowTemplate.Height = 24;
            this.dgvParts.Size = new System.Drawing.Size(1247, 415);
            this.dgvParts.TabIndex = 40;
            // 
            // btnCheckPartNumbers
            // 
            this.btnCheckPartNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckPartNumbers.Location = new System.Drawing.Point(1297, 259);
            this.btnCheckPartNumbers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCheckPartNumbers.Name = "btnCheckPartNumbers";
            this.btnCheckPartNumbers.Size = new System.Drawing.Size(189, 66);
            this.btnCheckPartNumbers.TabIndex = 41;
            this.btnCheckPartNumbers.Text = "Check Part Numbers";
            this.btnCheckPartNumbers.UseVisualStyleBackColor = true;
            this.btnCheckPartNumbers.Click += new System.EventHandler(this.btnCheckPartNumbers_Click);
            // 
            // ImportPartNumbers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1502, 615);
            this.ControlBox = false;
            this.Controls.Add(this.btnCheckPartNumbers);
            this.Controls.Add(this.dgvParts);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.btnUtilitiesMenu);
            this.Controls.Add(this.btnAdminMenu);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnClose);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ImportPartNumbers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImportPartNumbers";
            this.Load += new System.EventHandler(this.ImportPartNumbers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Button btnAdminMenu;
        private System.Windows.Forms.Button btnUtilitiesMenu;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.DataGridView dgvParts;
        private System.Windows.Forms.Button btnCheckPartNumbers;
    }
}