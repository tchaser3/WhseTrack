namespace WhseTrack
{
    partial class CheckForPartID
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
            this.Label1 = new System.Windows.Forms.Label();
            this.btnInventoryMenu = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cboSelectTable = new System.Windows.Forms.ComboBox();
            this.lblSelectTable = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WhseTrack.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(340, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(197, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(12, 116);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(858, 50);
            this.Label1.TabIndex = 38;
            this.Label1.Text = "Update Part ID";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnInventoryMenu
            // 
            this.btnInventoryMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventoryMenu.Location = new System.Drawing.Point(775, 289);
            this.btnInventoryMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInventoryMenu.Name = "btnInventoryMenu";
            this.btnInventoryMenu.Size = new System.Drawing.Size(189, 66);
            this.btnInventoryMenu.TabIndex = 40;
            this.btnInventoryMenu.Text = "Inventory Menu";
            this.btnInventoryMenu.UseVisualStyleBackColor = true;
            this.btnInventoryMenu.Click += new System.EventHandler(this.btnInventoryMenu_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainMenu.Location = new System.Drawing.Point(775, 361);
            this.btnMainMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(189, 66);
            this.btnMainMenu.TabIndex = 41;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(775, 432);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(189, 66);
            this.btnClose.TabIndex = 42;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cboSelectTable
            // 
            this.cboSelectTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelectTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSelectTable.FormattingEnabled = true;
            this.cboSelectTable.Location = new System.Drawing.Point(422, 189);
            this.cboSelectTable.Name = "cboSelectTable";
            this.cboSelectTable.Size = new System.Drawing.Size(146, 28);
            this.cboSelectTable.TabIndex = 43;
            this.cboSelectTable.SelectedIndexChanged += new System.EventHandler(this.cboSelectTable_SelectedIndexChanged);
            // 
            // lblSelectTable
            // 
            this.lblSelectTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectTable.Location = new System.Drawing.Point(260, 189);
            this.lblSelectTable.Name = "lblSelectTable";
            this.lblSelectTable.Size = new System.Drawing.Size(156, 23);
            this.lblSelectTable.TabIndex = 44;
            this.lblSelectTable.Text = "Select Table";
            this.lblSelectTable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CheckForPartID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 539);
            this.ControlBox = false;
            this.Controls.Add(this.lblSelectTable);
            this.Controls.Add(this.cboSelectTable);
            this.Controls.Add(this.btnInventoryMenu);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Label1);
            this.Name = "CheckForPartID";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CheckForPartID";
            this.Load += new System.EventHandler(this.CheckForPartID_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button btnInventoryMenu;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cboSelectTable;
        private System.Windows.Forms.Label lblSelectTable;
    }
}