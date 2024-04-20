namespace WhseTrack
{
    partial class EnterInventoryForm
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
            this.btnClearGrid = new System.Windows.Forms.Button();
            this.dgvLastTransactions = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtWarehouseID = new System.Windows.Forms.TextBox();
            this.txtTransactionID = new System.Windows.Forms.TextBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.txtMSRNumber = new System.Windows.Forms.TextBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtDataEntryComplete = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtPartNumber = new System.Windows.Forms.TextBox();
            this.txtProjectID = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnInventoryMenu = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblEnterInventory = new System.Windows.Forms.Label();
            this.lblEnterLastName = new System.Windows.Forms.Label();
            this.txtEnterLastName = new System.Windows.Forms.TextBox();
            this.cboSelectEmployee = new System.Windows.Forms.ComboBox();
            this.lblSelectEmployee = new System.Windows.Forms.Label();
            this.btnChangeWarehouse = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLastTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClearGrid
            // 
            this.btnClearGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearGrid.Location = new System.Drawing.Point(376, 251);
            this.btnClearGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClearGrid.Name = "btnClearGrid";
            this.btnClearGrid.Size = new System.Drawing.Size(163, 60);
            this.btnClearGrid.TabIndex = 11;
            this.btnClearGrid.Text = "Clear Grid";
            this.btnClearGrid.UseVisualStyleBackColor = true;
            this.btnClearGrid.Click += new System.EventHandler(this.btnClearGrid_Click);
            // 
            // dgvLastTransactions
            // 
            this.dgvLastTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvLastTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLastTransactions.Location = new System.Drawing.Point(571, 178);
            this.dgvLastTransactions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvLastTransactions.Name = "dgvLastTransactions";
            this.dgvLastTransactions.Size = new System.Drawing.Size(843, 436);
            this.dgvLastTransactions.TabIndex = 87;
            this.dgvLastTransactions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLastTransactions_CellContentClick);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(45, 270);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 26);
            this.label7.TabIndex = 86;
            this.label7.Text = "Transaction ID";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(45, 462);
            this.Label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(133, 26);
            this.Label6.TabIndex = 85;
            this.Label6.Text = "Warehouse ID";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtWarehouseID
            // 
            this.txtWarehouseID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtWarehouseID.Location = new System.Drawing.Point(187, 462);
            this.txtWarehouseID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtWarehouseID.Name = "txtWarehouseID";
            this.txtWarehouseID.ReadOnly = true;
            this.txtWarehouseID.Size = new System.Drawing.Size(160, 22);
            this.txtWarehouseID.TabIndex = 8;
            // 
            // txtTransactionID
            // 
            this.txtTransactionID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTransactionID.Location = new System.Drawing.Point(187, 273);
            this.txtTransactionID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTransactionID.Name = "txtTransactionID";
            this.txtTransactionID.ReadOnly = true;
            this.txtTransactionID.Size = new System.Drawing.Size(160, 22);
            this.txtTransactionID.TabIndex = 2;
            // 
            // Label12
            // 
            this.Label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.Location = new System.Drawing.Point(17, 363);
            this.Label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(163, 26);
            this.Label12.TabIndex = 82;
            this.Label12.Text = "MSR\\PO Number";
            this.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMSRNumber
            // 
            this.txtMSRNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMSRNumber.Location = new System.Drawing.Point(187, 363);
            this.txtMSRNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMSRNumber.Name = "txtMSRNumber";
            this.txtMSRNumber.Size = new System.Drawing.Size(160, 22);
            this.txtMSRNumber.TabIndex = 5;
            // 
            // Label11
            // 
            this.Label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label11.Location = new System.Drawing.Point(45, 302);
            this.Label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(133, 26);
            this.Label11.TabIndex = 81;
            this.Label11.Text = "Date";
            this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDate
            // 
            this.txtDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDate.Location = new System.Drawing.Point(187, 302);
            this.txtDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(160, 22);
            this.txtDate.TabIndex = 3;
            // 
            // Label5
            // 
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(19, 486);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(160, 44);
            this.Label5.TabIndex = 80;
            this.Label5.Text = "Data Entry Complete";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataEntryComplete
            // 
            this.txtDataEntryComplete.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDataEntryComplete.Location = new System.Drawing.Point(187, 497);
            this.txtDataEntryComplete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDataEntryComplete.Name = "txtDataEntryComplete";
            this.txtDataEntryComplete.Size = new System.Drawing.Size(160, 22);
            this.txtDataEntryComplete.TabIndex = 9;
            // 
            // Label4
            // 
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(45, 428);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(133, 26);
            this.Label4.TabIndex = 79;
            this.Label4.Text = "Qty";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(13, 395);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(165, 26);
            this.Label3.TabIndex = 78;
            this.Label3.Text = "Part No\\Description";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(45, 334);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(133, 26);
            this.Label2.TabIndex = 77;
            this.Label2.Text = "Project ID";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQuantity
            // 
            this.txtQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQuantity.Location = new System.Drawing.Point(187, 428);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(160, 22);
            this.txtQuantity.TabIndex = 7;
            // 
            // txtPartNumber
            // 
            this.txtPartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPartNumber.Location = new System.Drawing.Point(187, 395);
            this.txtPartNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPartNumber.Name = "txtPartNumber";
            this.txtPartNumber.Size = new System.Drawing.Size(160, 22);
            this.txtPartNumber.TabIndex = 6;
            this.txtPartNumber.TextChanged += new System.EventHandler(this.txtPartNumber_TextChanged);
            // 
            // txtProjectID
            // 
            this.txtProjectID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProjectID.Location = new System.Drawing.Point(187, 334);
            this.txtProjectID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProjectID.Name = "txtProjectID";
            this.txtProjectID.Size = new System.Drawing.Size(160, 22);
            this.txtProjectID.TabIndex = 4;
            this.txtProjectID.TextChanged += new System.EventHandler(this.txtProjectID_TextChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(376, 322);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(163, 60);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnInventoryMenu
            // 
            this.btnInventoryMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventoryMenu.Location = new System.Drawing.Point(376, 391);
            this.btnInventoryMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInventoryMenu.Name = "btnInventoryMenu";
            this.btnInventoryMenu.Size = new System.Drawing.Size(163, 60);
            this.btnInventoryMenu.TabIndex = 13;
            this.btnInventoryMenu.Text = "Inventory Menu";
            this.btnInventoryMenu.UseVisualStyleBackColor = true;
            this.btnInventoryMenu.Click += new System.EventHandler(this.btnInventoryMenu_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainMenu.Location = new System.Drawing.Point(376, 465);
            this.btnMainMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(163, 60);
            this.btnMainMenu.TabIndex = 14;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(376, 539);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(163, 60);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WhseTrack.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(616, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(171, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 66;
            this.pictureBox1.TabStop = false;
            // 
            // lblEnterInventory
            // 
            this.lblEnterInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnterInventory.Location = new System.Drawing.Point(19, 103);
            this.lblEnterInventory.Name = "lblEnterInventory";
            this.lblEnterInventory.Size = new System.Drawing.Size(1385, 58);
            this.lblEnterInventory.TabIndex = 65;
            this.lblEnterInventory.Text = "Update Inventory";
            this.lblEnterInventory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEnterLastName
            // 
            this.lblEnterLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnterLastName.Location = new System.Drawing.Point(24, 181);
            this.lblEnterLastName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEnterLastName.Name = "lblEnterLastName";
            this.lblEnterLastName.Size = new System.Drawing.Size(155, 26);
            this.lblEnterLastName.TabIndex = 89;
            this.lblEnterLastName.Text = "Enter Last Name";
            this.lblEnterLastName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblEnterLastName.Visible = false;
            // 
            // txtEnterLastName
            // 
            this.txtEnterLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEnterLastName.Location = new System.Drawing.Point(187, 185);
            this.txtEnterLastName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEnterLastName.Name = "txtEnterLastName";
            this.txtEnterLastName.Size = new System.Drawing.Size(160, 22);
            this.txtEnterLastName.TabIndex = 0;
            this.txtEnterLastName.Visible = false;
            this.txtEnterLastName.TextChanged += new System.EventHandler(this.txtEnterLastName_TextChanged);
            this.txtEnterLastName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEnterLastName_KeyDown);
            // 
            // cboSelectEmployee
            // 
            this.cboSelectEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelectEmployee.FormattingEnabled = true;
            this.cboSelectEmployee.Location = new System.Drawing.Point(187, 226);
            this.cboSelectEmployee.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboSelectEmployee.Name = "cboSelectEmployee";
            this.cboSelectEmployee.Size = new System.Drawing.Size(160, 24);
            this.cboSelectEmployee.TabIndex = 1;
            this.cboSelectEmployee.Visible = false;
            this.cboSelectEmployee.SelectedIndexChanged += new System.EventHandler(this.cboSelectEmployee_SelectedIndexChanged);
            // 
            // lblSelectEmployee
            // 
            this.lblSelectEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectEmployee.Location = new System.Drawing.Point(24, 224);
            this.lblSelectEmployee.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelectEmployee.Name = "lblSelectEmployee";
            this.lblSelectEmployee.Size = new System.Drawing.Size(155, 26);
            this.lblSelectEmployee.TabIndex = 92;
            this.lblSelectEmployee.Text = "Select Employee";
            this.lblSelectEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSelectEmployee.Visible = false;
            // 
            // btnChangeWarehouse
            // 
            this.btnChangeWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeWarehouse.Location = new System.Drawing.Point(376, 178);
            this.btnChangeWarehouse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnChangeWarehouse.Name = "btnChangeWarehouse";
            this.btnChangeWarehouse.Size = new System.Drawing.Size(163, 60);
            this.btnChangeWarehouse.TabIndex = 10;
            this.btnChangeWarehouse.Text = "Change Warehouse";
            this.btnChangeWarehouse.UseVisualStyleBackColor = true;
            this.btnChangeWarehouse.Click += new System.EventHandler(this.btnChangeWarehouse_Click);
            // 
            // EnterInventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1440, 628);
            this.ControlBox = false;
            this.Controls.Add(this.btnChangeWarehouse);
            this.Controls.Add(this.lblSelectEmployee);
            this.Controls.Add(this.cboSelectEmployee);
            this.Controls.Add(this.txtEnterLastName);
            this.Controls.Add(this.lblEnterLastName);
            this.Controls.Add(this.btnClearGrid);
            this.Controls.Add(this.dgvLastTransactions);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.txtWarehouseID);
            this.Controls.Add(this.txtTransactionID);
            this.Controls.Add(this.Label12);
            this.Controls.Add(this.txtMSRNumber);
            this.Controls.Add(this.Label11);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.txtDataEntryComplete);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtPartNumber);
            this.Controls.Add(this.txtProjectID);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnInventoryMenu);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblEnterInventory);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "EnterInventoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EnterInventoryForm";
            this.Load += new System.EventHandler(this.EnterInventoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLastTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnClearGrid;
        internal System.Windows.Forms.DataGridView dgvLastTransactions;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox txtWarehouseID;
        internal System.Windows.Forms.TextBox txtTransactionID;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.TextBox txtMSRNumber;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.TextBox txtDate;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txtDataEntryComplete;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtQuantity;
        internal System.Windows.Forms.TextBox txtPartNumber;
        internal System.Windows.Forms.TextBox txtProjectID;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.Button btnInventoryMenu;
        internal System.Windows.Forms.Button btnMainMenu;
        internal System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Label lblEnterInventory;
        internal System.Windows.Forms.Label lblEnterLastName;
        internal System.Windows.Forms.TextBox txtEnterLastName;
        private System.Windows.Forms.ComboBox cboSelectEmployee;
        internal System.Windows.Forms.Label lblSelectEmployee;
        internal System.Windows.Forms.Button btnChangeWarehouse;
    }
}