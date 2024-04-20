namespace WhseTrack
{
    partial class ViewMaterialInventory
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
            this.lblEnterInventory = new System.Windows.Forms.Label();
            this.btnInventoryMenu = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.cboSelectWarehouse = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WhseTrack.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(501, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 70;
            this.pictureBox1.TabStop = false;
            // 
            // lblEnterInventory
            // 
            this.lblEnterInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnterInventory.Location = new System.Drawing.Point(9, 87);
            this.lblEnterInventory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEnterInventory.Name = "lblEnterInventory";
            this.lblEnterInventory.Size = new System.Drawing.Size(1111, 47);
            this.lblEnterInventory.TabIndex = 69;
            this.lblEnterInventory.Text = "Complete Warehouse Inventory";
            this.lblEnterInventory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnInventoryMenu
            // 
            this.btnInventoryMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventoryMenu.Location = new System.Drawing.Point(978, 274);
            this.btnInventoryMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnInventoryMenu.Name = "btnInventoryMenu";
            this.btnInventoryMenu.Size = new System.Drawing.Size(142, 54);
            this.btnInventoryMenu.TabIndex = 71;
            this.btnInventoryMenu.Text = "Inventory Menu";
            this.btnInventoryMenu.UseVisualStyleBackColor = true;
            this.btnInventoryMenu.Click += new System.EventHandler(this.btnInventoryMenu_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainMenu.Location = new System.Drawing.Point(978, 332);
            this.btnMainMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(142, 54);
            this.btnMainMenu.TabIndex = 72;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(978, 390);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(142, 54);
            this.btnClose.TabIndex = 73;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvInventory
            // 
            this.dgvInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Location = new System.Drawing.Point(13, 186);
            this.dgvInventory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.RowTemplate.Height = 24;
            this.dgvInventory.Size = new System.Drawing.Size(950, 362);
            this.dgvInventory.TabIndex = 74;
            // 
            // cboSelectWarehouse
            // 
            this.cboSelectWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelectWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSelectWarehouse.FormattingEnabled = true;
            this.cboSelectWarehouse.Location = new System.Drawing.Point(547, 143);
            this.cboSelectWarehouse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboSelectWarehouse.Name = "cboSelectWarehouse";
            this.cboSelectWarehouse.Size = new System.Drawing.Size(228, 28);
            this.cboSelectWarehouse.TabIndex = 76;
            this.cboSelectWarehouse.SelectedIndexChanged += new System.EventHandler(this.cboSelectWarehouse_SelectedIndexChanged);
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(375, 134);
            this.Label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(167, 41);
            this.Label1.TabIndex = 75;
            this.Label1.Text = "Select Warehouse";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ViewMaterialInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1028, 557);
            this.ControlBox = false;
            this.Controls.Add(this.cboSelectWarehouse);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.dgvInventory);
            this.Controls.Add(this.btnInventoryMenu);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblEnterInventory);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ViewMaterialInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViewMaterialInventory";
            this.Load += new System.EventHandler(this.ViewMaterialInventory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Label lblEnterInventory;
        private System.Windows.Forms.Button btnInventoryMenu;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.ComboBox cboSelectWarehouse;
        internal System.Windows.Forms.Label Label1;
    }
}