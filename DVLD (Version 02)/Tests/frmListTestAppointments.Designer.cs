namespace DVLD__Version_02_.Tests
{
    partial class frmListTestAppointments
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbHeader = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbCountOfAppointments = new System.Windows.Forms.Label();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.cmOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.editTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddNewTestAppointment = new System.Windows.Forms.Button();
            this.PBHeaderImage = new System.Windows.Forms.PictureBox();
            this.ctrlLocalDrivingLicenseInfo1 = new DVLD__Version_02_.Applications.LocalDrivingLicense.ctrlLocalDrivingLicenseInfo();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.cmOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBHeaderImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lbHeader
            // 
            this.lbHeader.AutoSize = true;
            this.lbHeader.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.lbHeader.ForeColor = System.Drawing.Color.Beige;
            this.lbHeader.Location = new System.Drawing.Point(473, 84);
            this.lbHeader.Name = "lbHeader";
            this.lbHeader.Size = new System.Drawing.Size(192, 39);
            this.lbHeader.TabIndex = 2;
            this.lbHeader.Text = "Vision Test";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Beige;
            this.label1.Location = new System.Drawing.Point(14, 639);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 24);
            this.label1.TabIndex = 136;
            this.label1.Text = "Appointments:";
            // 
            // lbCountOfAppointments
            // 
            this.lbCountOfAppointments.AutoSize = true;
            this.lbCountOfAppointments.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lbCountOfAppointments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(229)))));
            this.lbCountOfAppointments.Location = new System.Drawing.Point(13, 852);
            this.lbCountOfAppointments.Name = "lbCountOfAppointments";
            this.lbCountOfAppointments.Size = new System.Drawing.Size(99, 28);
            this.lbCountOfAppointments.TabIndex = 137;
            this.lbCountOfAppointments.Text = "#Records";
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.AllowUserToAddRows = false;
            this.dgvAppointments.AllowUserToDeleteRows = false;
            this.dgvAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAppointments.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAppointments.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAppointments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.ContextMenuStrip = this.cmOptions;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAppointments.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAppointments.GridColor = System.Drawing.SystemColors.WindowText;
            this.dgvAppointments.Location = new System.Drawing.Point(4, 670);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.ReadOnly = true;
            this.dgvAppointments.RowHeadersWidth = 62;
            this.dgvAppointments.RowTemplate.Height = 29;
            this.dgvAppointments.Size = new System.Drawing.Size(1104, 181);
            this.dgvAppointments.TabIndex = 138;
            // 
            // cmOptions
            // 
            this.cmOptions.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.takeTestToolStripMenuItem,
            this.toolStripSeparator1,
            this.editTestToolStripMenuItem});
            this.cmOptions.Name = "contextMenuStrip1";
            this.cmOptions.Size = new System.Drawing.Size(162, 74);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Image = global::DVLD__Version_02_.Properties.Resources.TakeTest;
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(161, 32);
            this.takeTestToolStripMenuItem.Text = "Take Test";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(158, 6);
            // 
            // editTestToolStripMenuItem
            // 
            this.editTestToolStripMenuItem.Image = global::DVLD__Version_02_.Properties.Resources.edit;
            this.editTestToolStripMenuItem.Name = "editTestToolStripMenuItem";
            this.editTestToolStripMenuItem.Size = new System.Drawing.Size(161, 32);
            this.editTestToolStripMenuItem.Text = "Edit Test";
            this.editTestToolStripMenuItem.Click += new System.EventHandler(this.editTestToolStripMenuItem_Click);
            // 
            // btnAddNewTestAppointment
            // 
            this.btnAddNewTestAppointment.BackgroundImage = global::DVLD__Version_02_.Properties.Resources.add__1_;
            this.btnAddNewTestAppointment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddNewTestAppointment.Location = new System.Drawing.Point(1047, 618);
            this.btnAddNewTestAppointment.Name = "btnAddNewTestAppointment";
            this.btnAddNewTestAppointment.Size = new System.Drawing.Size(57, 45);
            this.btnAddNewTestAppointment.TabIndex = 139;
            this.btnAddNewTestAppointment.UseVisualStyleBackColor = true;
            this.btnAddNewTestAppointment.Click += new System.EventHandler(this.btnAddNewTestAppointment_Click);
            // 
            // PBHeaderImage
            // 
            this.PBHeaderImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PBHeaderImage.Image = global::DVLD__Version_02_.Properties.Resources.eye;
            this.PBHeaderImage.Location = new System.Drawing.Point(486, -1);
            this.PBHeaderImage.Name = "PBHeaderImage";
            this.PBHeaderImage.Size = new System.Drawing.Size(158, 102);
            this.PBHeaderImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBHeaderImage.TabIndex = 134;
            this.PBHeaderImage.TabStop = false;
            // 
            // ctrlLocalDrivingLicenseInfo1
            // 
            this.ctrlLocalDrivingLicenseInfo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(48)))));
            this.ctrlLocalDrivingLicenseInfo1.Location = new System.Drawing.Point(-5, 126);
            this.ctrlLocalDrivingLicenseInfo1.Name = "ctrlLocalDrivingLicenseInfo1";
            this.ctrlLocalDrivingLicenseInfo1.Size = new System.Drawing.Size(1113, 486);
            this.ctrlLocalDrivingLicenseInfo1.TabIndex = 140;
            // 
            // frmListTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1116, 885);
            this.Controls.Add(this.ctrlLocalDrivingLicenseInfo1);
            this.Controls.Add(this.btnAddNewTestAppointment);
            this.Controls.Add(this.dgvAppointments);
            this.Controls.Add(this.lbHeader);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PBHeaderImage);
            this.Controls.Add(this.lbCountOfAppointments);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmListTestAppointments";
            this.Text = "List Test Appointments";
            this.Load += new System.EventHandler(this.frmListTestAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.cmOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PBHeaderImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbHeader;
        private System.Windows.Forms.PictureBox PBHeaderImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbCountOfAppointments;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.Button btnAddNewTestAppointment;
        private System.Windows.Forms.ContextMenuStrip cmOptions;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem editTestToolStripMenuItem;
        private Applications.LocalDrivingLicense.ctrlLocalDrivingLicenseInfo ctrlLocalDrivingLicenseInfo1;
    }
}