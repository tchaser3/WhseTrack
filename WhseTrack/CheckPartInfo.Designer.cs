namespace WhseTrack
{
    partial class CheckPartInfo
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
            this.dgvCount = new System.Windows.Forms.DataGridView();
            this.dgvPart = new System.Windows.Forms.DataGridView();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPart)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCount
            // 
            this.dgvCount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCount.Location = new System.Drawing.Point(28, 49);
            this.dgvCount.Name = "dgvCount";
            this.dgvCount.RowTemplate.Height = 24;
            this.dgvCount.Size = new System.Drawing.Size(1221, 90);
            this.dgvCount.TabIndex = 0;
            // 
            // dgvPart
            // 
            this.dgvPart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPart.Location = new System.Drawing.Point(28, 223);
            this.dgvPart.Name = "dgvPart";
            this.dgvPart.RowTemplate.Height = 24;
            this.dgvPart.Size = new System.Drawing.Size(1221, 291);
            this.dgvPart.TabIndex = 1;
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(23, 155);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(1226, 50);
            this.Label1.TabIndex = 48;
            this.Label1.Text = "Select The Part";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.Location = new System.Drawing.Point(557, 532);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(234, 65);
            this.btnSelect.TabIndex = 49;
            this.btnSelect.Text = "Select Part";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // CheckPartInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 624);
            this.ControlBox = false;
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.dgvPart);
            this.Controls.Add(this.dgvCount);
            this.Name = "CheckPartInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CheckPartInfo";
            this.Load += new System.EventHandler(this.CheckPartInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCount;
        private System.Windows.Forms.DataGridView dgvPart;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button btnSelect;
    }
}