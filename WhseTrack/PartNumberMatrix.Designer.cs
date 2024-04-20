namespace WhseTrack
{
    partial class PartNumberMatrix
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
            this.btnInventoryMenu = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvPartNumbers = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblEnterInventory = new System.Windows.Forms.Label();
            this.txtEnteredInformation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartNumbers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInventoryMenu
            // 
            this.btnInventoryMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventoryMenu.Location = new System.Drawing.Point(913, 315);
            this.btnInventoryMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInventoryMenu.Name = "btnInventoryMenu";
            this.btnInventoryMenu.Size = new System.Drawing.Size(189, 66);
            this.btnInventoryMenu.TabIndex = 15;
            this.btnInventoryMenu.Text = "Inventory Menu";
            this.btnInventoryMenu.UseVisualStyleBackColor = true;
            this.btnInventoryMenu.Click += new System.EventHandler(this.btnInventoryMenu_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainMenu.Location = new System.Drawing.Point(913, 386);
            this.btnMainMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(189, 66);
            this.btnMainMenu.TabIndex = 16;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(913, 457);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(189, 66);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvPartNumbers
            // 
            this.dgvPartNumbers.AllowUserToAddRows = false;
            this.dgvPartNumbers.AllowUserToDeleteRows = false;
            this.dgvPartNumbers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPartNumbers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPartNumbers.Location = new System.Drawing.Point(17, 250);
            this.dgvPartNumbers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvPartNumbers.Name = "dgvPartNumbers";
            this.dgvPartNumbers.Size = new System.Drawing.Size(873, 326);
            this.dgvPartNumbers.TabIndex = 18;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WhseTrack.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(473, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(171, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 68;
            this.pictureBox1.TabStop = false;
            // 
            // lblEnterInventory
            // 
            this.lblEnterInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnterInventory.Location = new System.Drawing.Point(12, 107);
            this.lblEnterInventory.Name = "lblEnterInventory";
            this.lblEnterInventory.Size = new System.Drawing.Size(1090, 58);
            this.lblEnterInventory.TabIndex = 67;
            this.lblEnterInventory.Text = "Part Number Matrix";
            this.lblEnterInventory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtEnteredInformation
            // 
            this.txtEnteredInformation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEnteredInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnteredInformation.Location = new System.Drawing.Point(405, 193);
            this.txtEnteredInformation.Name = "txtEnteredInformation";
            this.txtEnteredInformation.Size = new System.Drawing.Size(177, 30);
            this.txtEnteredInformation.TabIndex = 69;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(148, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 23);
            this.label1.TabIndex = 70;
            this.label1.Text = "Enter Search Information";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Location = new System.Drawing.Point(588, 185);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(130, 53);
            this.btnFind.TabIndex = 71;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // PartNumberMatrix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 601);
            this.ControlBox = false;
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEnteredInformation);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblEnterInventory);
            this.Controls.Add(this.dgvPartNumbers);
            this.Controls.Add(this.btnInventoryMenu);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnClose);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PartNumberMatrix";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PartNumberMatrix";
            this.Load += new System.EventHandler(this.PartNumberMatrix_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartNumbers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInventoryMenu;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvPartNumbers;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Label lblEnterInventory;
        private System.Windows.Forms.TextBox txtEnteredInformation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFind;
    }
}