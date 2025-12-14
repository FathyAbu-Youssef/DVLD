namespace DVLD__Version_02_.Licenses
{
    partial class ctrlDriverLicenses
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpLocalLicenses = new System.Windows.Forms.TabPage();
            this.lbLocaclLicensesCount = new System.Windows.Forms.Label();
            this.tpInternationalLicenses = new System.Windows.Forms.TabPage();
            this.dgvLocalLicenses = new System.Windows.Forms.DataGridView();
            this.dgvInternationalLicenses = new System.Windows.Forms.DataGridView();
            this.lbInternationalLicensesCount = new System.Windows.Forms.Label();
            this.cmInternationalLicense = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmLocalLicense = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tpLocalLicenses.SuspendLayout();
            this.tpInternationalLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenses)).BeginInit();
            this.cmInternationalLicense.SuspendLayout();
            this.cmLocalLicense.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.Beige;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1236, 281);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver Licenses";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpLocalLicenses);
            this.tabControl.Controls.Add(this.tpInternationalLicenses);
            this.tabControl.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tabControl.Location = new System.Drawing.Point(6, 34);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1224, 240);
            this.tabControl.TabIndex = 1;
            // 
            // tpLocalLicenses
            // 
            this.tpLocalLicenses.BackColor = System.Drawing.Color.White;
            this.tpLocalLicenses.Controls.Add(this.dgvLocalLicenses);
            this.tpLocalLicenses.Controls.Add(this.lbLocaclLicensesCount);
            this.tpLocalLicenses.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.tpLocalLicenses.ForeColor = System.Drawing.Color.Black;
            this.tpLocalLicenses.Location = new System.Drawing.Point(4, 33);
            this.tpLocalLicenses.Name = "tpLocalLicenses";
            this.tpLocalLicenses.Padding = new System.Windows.Forms.Padding(3);
            this.tpLocalLicenses.Size = new System.Drawing.Size(1216, 203);
            this.tpLocalLicenses.TabIndex = 0;
            this.tpLocalLicenses.Text = "Local Licenses";
            this.tpLocalLicenses.Click += new System.EventHandler(this.tpLocalLicenses_Click);
            // 
            // lbLocaclLicensesCount
            // 
            this.lbLocaclLicensesCount.AutoSize = true;
            this.lbLocaclLicensesCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbLocaclLicensesCount.ForeColor = System.Drawing.Color.Black;
            this.lbLocaclLicensesCount.Location = new System.Drawing.Point(15, 170);
            this.lbLocaclLicensesCount.Name = "lbLocaclLicensesCount";
            this.lbLocaclLicensesCount.Size = new System.Drawing.Size(91, 25);
            this.lbLocaclLicensesCount.TabIndex = 29;
            this.lbLocaclLicensesCount.Text = "#Records";
            // 
            // tpInternationalLicenses
            // 
            this.tpInternationalLicenses.BackColor = System.Drawing.Color.White;
            this.tpInternationalLicenses.Controls.Add(this.dgvInternationalLicenses);
            this.tpInternationalLicenses.Controls.Add(this.lbInternationalLicensesCount);
            this.tpInternationalLicenses.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.tpInternationalLicenses.ForeColor = System.Drawing.Color.Black;
            this.tpInternationalLicenses.Location = new System.Drawing.Point(4, 33);
            this.tpInternationalLicenses.Name = "tpInternationalLicenses";
            this.tpInternationalLicenses.Padding = new System.Windows.Forms.Padding(3);
            this.tpInternationalLicenses.Size = new System.Drawing.Size(1216, 203);
            this.tpInternationalLicenses.TabIndex = 1;
            this.tpInternationalLicenses.Text = "International Licenses";
            // 
            // dgvLocalLicenses
            // 
            this.dgvLocalLicenses.AllowUserToAddRows = false;
            this.dgvLocalLicenses.AllowUserToDeleteRows = false;
            this.dgvLocalLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLocalLicenses.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvLocalLicenses.BackgroundColor = System.Drawing.Color.White;
            this.dgvLocalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicenses.ContextMenuStrip = this.cmLocalLicense;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLocalLicenses.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLocalLicenses.GridColor = System.Drawing.SystemColors.WindowText;
            this.dgvLocalLicenses.Location = new System.Drawing.Point(6, 21);
            this.dgvLocalLicenses.Name = "dgvLocalLicenses";
            this.dgvLocalLicenses.ReadOnly = true;
            this.dgvLocalLicenses.RowHeadersWidth = 62;
            this.dgvLocalLicenses.RowTemplate.Height = 29;
            this.dgvLocalLicenses.Size = new System.Drawing.Size(1204, 149);
            this.dgvLocalLicenses.TabIndex = 30;
            // 
            // dgvInternationalLicenses
            // 
            this.dgvInternationalLicenses.AllowUserToAddRows = false;
            this.dgvInternationalLicenses.AllowUserToDeleteRows = false;
            this.dgvInternationalLicenses.AllowUserToResizeColumns = false;
            this.dgvInternationalLicenses.AllowUserToResizeRows = false;
            this.dgvInternationalLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInternationalLicenses.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvInternationalLicenses.BackgroundColor = System.Drawing.Color.White;
            this.dgvInternationalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicenses.ContextMenuStrip = this.cmInternationalLicense;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInternationalLicenses.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInternationalLicenses.GridColor = System.Drawing.SystemColors.WindowText;
            this.dgvInternationalLicenses.Location = new System.Drawing.Point(6, 13);
            this.dgvInternationalLicenses.Name = "dgvInternationalLicenses";
            this.dgvInternationalLicenses.ReadOnly = true;
            this.dgvInternationalLicenses.RowHeadersWidth = 62;
            this.dgvInternationalLicenses.RowTemplate.Height = 29;
            this.dgvInternationalLicenses.Size = new System.Drawing.Size(1204, 152);
            this.dgvInternationalLicenses.TabIndex = 32;
            // 
            // lbInternationalLicensesCount
            // 
            this.lbInternationalLicensesCount.AutoSize = true;
            this.lbInternationalLicensesCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbInternationalLicensesCount.ForeColor = System.Drawing.Color.Black;
            this.lbInternationalLicensesCount.Location = new System.Drawing.Point(15, 167);
            this.lbInternationalLicensesCount.Name = "lbInternationalLicensesCount";
            this.lbInternationalLicensesCount.Size = new System.Drawing.Size(91, 25);
            this.lbInternationalLicensesCount.TabIndex = 31;
            this.lbInternationalLicensesCount.Text = "#Records";
            // 
            // cmInternationalLicense
            // 
            this.cmInternationalLicense.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmInternationalLicense.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseDetailsToolStripMenuItem});
            this.cmInternationalLicense.Name = "cmInternationalLicense";
            this.cmInternationalLicense.Size = new System.Drawing.Size(250, 36);
            // 
            // cmLocalLicense
            // 
            this.cmLocalLicense.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmLocalLicense.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.cmLocalLicense.Name = "cmInternationalLicense";
            this.cmLocalLicense.Size = new System.Drawing.Size(250, 36);
            // 
            // showLicenseDetailsToolStripMenuItem
            // 
            this.showLicenseDetailsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.showLicenseDetailsToolStripMenuItem.Image = global::DVLD__Version_02_.Properties.Resources.international;
            this.showLicenseDetailsToolStripMenuItem.Name = "showLicenseDetailsToolStripMenuItem";
            this.showLicenseDetailsToolStripMenuItem.Size = new System.Drawing.Size(249, 32);
            this.showLicenseDetailsToolStripMenuItem.Text = "Show License Details";
            this.showLicenseDetailsToolStripMenuItem.Click += new System.EventHandler(this.showLicenseDetailsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItem1.Image = global::DVLD__Version_02_.Properties.Resources.location;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(249, 32);
            this.toolStripMenuItem1.Text = "Show License Details";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // ctrlDriverLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrlDriverLicenses";
            this.Size = new System.Drawing.Size(1244, 287);
            this.groupBox1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tpLocalLicenses.ResumeLayout(false);
            this.tpLocalLicenses.PerformLayout();
            this.tpInternationalLicenses.ResumeLayout(false);
            this.tpInternationalLicenses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenses)).EndInit();
            this.cmInternationalLicense.ResumeLayout(false);
            this.cmLocalLicense.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpLocalLicenses;
        private System.Windows.Forms.TabPage tpInternationalLicenses;
        private System.Windows.Forms.Label lbLocaclLicensesCount;
        private System.Windows.Forms.DataGridView dgvLocalLicenses;
        private System.Windows.Forms.DataGridView dgvInternationalLicenses;
        private System.Windows.Forms.Label lbInternationalLicensesCount;
        private System.Windows.Forms.ContextMenuStrip cmInternationalLicense;
        private System.Windows.Forms.ToolStripMenuItem showLicenseDetailsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmLocalLicense;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}
