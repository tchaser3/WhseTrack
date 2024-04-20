namespace WhseTrack
{
    partial class AdjustInventory
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
            this.btnProcessAdjustment = new System.Windows.Forms.Button();
            this.btnInventoryMenu = new System.Windows.Forms.Button();
            this.dgvParts = new System.Windows.Forms.DataGridView();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtPartNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuantityOnHand = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewQuantity = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParts)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WhseTrack.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(520, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(171, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 89;
            this.pictureBox1.TabStop = false;
            // 
            // lblAddPartNumbers
            // 
            this.lblAddPartNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddPartNumbers.Location = new System.Drawing.Point(12, 107);
            this.lblAddPartNumbers.Name = "lblAddPartNumbers";
            this.lblAddPartNumbers.Size = new System.Drawing.Size(1181, 58);
            this.lblAddPartNumbers.TabIndex = 88;
            this.lblAddPartNumbers.Text = "Adjust Inventory";
            this.lblAddPartNumbers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainMenu.Location = new System.Drawing.Point(1004, 416);
            this.btnMainMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(189, 66);
            this.btnMainMenu.TabIndex = 5;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1004, 487);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(189, 66);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnProcessAdjustment
            // 
            this.btnProcessAdjustment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessAdjustment.Location = new System.Drawing.Point(1004, 275);
            this.btnProcessAdjustment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnProcessAdjustment.Name = "btnProcessAdjustment";
            this.btnProcessAdjustment.Size = new System.Drawing.Size(189, 66);
            this.btnProcessAdjustment.TabIndex = 3;
            this.btnProcessAdjustment.Text = "Process Adjustment";
            this.btnProcessAdjustment.UseVisualStyleBackColor = true;
            this.btnProcessAdjustment.Click += new System.EventHandler(this.btnProcessAdjustment_Click);
            // 
            // btnInventoryMenu
            // 
            this.btnInventoryMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventoryMenu.Location = new System.Drawing.Point(1004, 346);
            this.btnInventoryMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInventoryMenu.Name = "btnInventoryMenu";
            this.btnInventoryMenu.Size = new System.Drawing.Size(189, 66);
            this.btnInventoryMenu.TabIndex = 4;
            this.btnInventoryMenu.Text = "Inventory Menu";
            this.btnInventoryMenu.UseVisualStyleBackColor = true;
            this.btnInventoryMenu.Click += new System.EventHandler(this.btnInventoryMenu_Click);
            // 
            // dgvParts
            // 
            this.dgvParts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParts.Location = new System.Drawing.Point(12, 275);
            this.dgvParts.Name = "dgvParts";
            this.dgvParts.RowTemplate.Height = 24;
            this.dgvParts.Size = new System.Drawing.Size(970, 419);
            this.dgvParts.TabIndex = 94;
            this.dgvParts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParts_CellContentClick);
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(236, 179);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(245, 26);
            this.Label3.TabIndex = 96;
            this.Label3.Text = "Enter Part No\\Description";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPartNumber
            // 
            this.txtPartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPartNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPartNumber.Location = new System.Drawing.Point(489, 179);
            this.txtPartNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtPartNumber.Name = "txtPartNumber";
            this.txtPartNumber.Size = new System.Drawing.Size(160, 28);
            this.txtPartNumber.TabIndex = 0;
            this.txtPartNumber.TextChanged += new System.EventHandler(this.txtPartNumber_TextChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 230);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 26);
            this.label1.TabIndex = 98;
            this.label1.Text = "Current Quantity On Hand";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQuantityOnHand
            // 
            this.txtQuantityOnHand.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQuantityOnHand.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantityOnHand.Location = new System.Drawing.Point(317, 230);
            this.txtQuantityOnHand.Margin = new System.Windows.Forms.Padding(4);
            this.txtQuantityOnHand.Name = "txtQuantityOnHand";
            this.txtQuantityOnHand.ReadOnly = true;
            this.txtQuantityOnHand.Size = new System.Drawing.Size(160, 28);
            this.txtQuantityOnHand.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(485, 230);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 26);
            this.label2.TabIndex = 100;
            this.label2.Text = "New Quantity";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNewQuantity
            // 
            this.txtNewQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNewQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewQuantity.Location = new System.Drawing.Point(738, 230);
            this.txtNewQuantity.Margin = new System.Windows.Forms.Padding(4);
            this.txtNewQuantity.Name = "txtNewQuantity";
            this.txtNewQuantity.Size = new System.Drawing.Size(160, 28);
            this.txtNewQuantity.TabIndex = 2;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(665, 173);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(92, 44);
            this.btnFind.TabIndex = 101;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // AdjustInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 706);
            this.ControlBox = false;
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNewQuantity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtQuantityOnHand);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtPartNumber);
            this.Controls.Add(this.dgvParts);
            this.Controls.Add(this.btnProcessAdjustment);
            this.Controls.Add(this.btnInventoryMenu);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblAddPartNumbers);
            this.Name = "AdjustInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdjustInventory";
            this.Load += new System.EventHandler(this.AdjustInventory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Label lblAddPartNumbers;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnProcessAdjustment;
        private System.Windows.Forms.Button btnInventoryMenu;
        private System.Windows.Forms.DataGridView dgvParts;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtPartNumber;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtQuantityOnHand;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtNewQuantity;
        private System.Windows.Forms.Button btnFind;
    }
}