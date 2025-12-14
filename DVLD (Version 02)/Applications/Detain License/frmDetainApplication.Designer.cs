namespace DVLD__Version_02_.Applications.Detain_License
{
    partial class frmDetainApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetainApplication));
            this.llshowlicenseinfo = new System.Windows.Forms.LinkLabel();
            this.llshowlicensehistory = new System.Windows.Forms.LinkLabel();
            this.btndetain = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFineFees = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.lbCreatedBy = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbLicenseid = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbDetainDate = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.LbDetainID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbHeader = new System.Windows.Forms.Label();
            this.ctrlDriverLicenseInfoWithFilter1 = new DVLD__Version_02_.Licenses.Local_Licenses.Controls.ctrlDriverLicenseInfoWithFilter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.SuspendLayout();
            // 
            // llshowlicenseinfo
            // 
            this.llshowlicenseinfo.AutoSize = true;
            this.llshowlicenseinfo.Enabled = false;
            this.llshowlicenseinfo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.llshowlicenseinfo.LinkColor = System.Drawing.Color.Beige;
            this.llshowlicenseinfo.Location = new System.Drawing.Point(271, 937);
            this.llshowlicenseinfo.Name = "llshowlicenseinfo";
            this.llshowlicenseinfo.Size = new System.Drawing.Size(196, 24);
            this.llshowlicenseinfo.TabIndex = 185;
            this.llshowlicenseinfo.TabStop = true;
            this.llshowlicenseinfo.Text = "Show License Info";
            this.llshowlicenseinfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llshowlicenseinfo_LinkClicked);
            // 
            // llshowlicensehistory
            // 
            this.llshowlicensehistory.AutoSize = true;
            this.llshowlicensehistory.Enabled = false;
            this.llshowlicensehistory.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.llshowlicensehistory.LinkColor = System.Drawing.Color.Beige;
            this.llshowlicensehistory.Location = new System.Drawing.Point(34, 935);
            this.llshowlicensehistory.Name = "llshowlicensehistory";
            this.llshowlicensehistory.Size = new System.Drawing.Size(225, 24);
            this.llshowlicensehistory.TabIndex = 184;
            this.llshowlicensehistory.TabStop = true;
            this.llshowlicensehistory.Text = "Show License History";
            this.llshowlicensehistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llshowlicensehistory_LinkClicked);
            // 
            // btndetain
            // 
            this.btndetain.Enabled = false;
            this.btndetain.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndetain.ForeColor = System.Drawing.Color.Black;
            this.btndetain.Location = new System.Drawing.Point(1170, 934);
            this.btndetain.Name = "btndetain";
            this.btndetain.Size = new System.Drawing.Size(92, 38);
            this.btndetain.TabIndex = 182;
            this.btndetain.Text = "Detain";
            this.btndetain.UseVisualStyleBackColor = true;
            this.btndetain.Click += new System.EventHandler(this.btndetain_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFineFees);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.pictureBox11);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.pictureBox9);
            this.groupBox1.Controls.Add(this.lbCreatedBy);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lbLicenseid);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lbDetainDate);
            this.groupBox1.Controls.Add(this.pictureBox6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.pictureBox8);
            this.groupBox1.Controls.Add(this.LbDetainID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Beige;
            this.groupBox1.Location = new System.Drawing.Point(32, 679);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1259, 245);
            this.groupBox1.TabIndex = 181;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "Close";
            this.groupBox1.Text = "Detain Info";
            // 
            // txtFineFees
            // 
            this.txtFineFees.Location = new System.Drawing.Point(236, 179);
            this.txtFineFees.Name = "txtFineFees";
            this.txtFineFees.Size = new System.Drawing.Size(100, 32);
            this.txtFineFees.TabIndex = 166;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::DVLD__Version_02_.Properties.Resources.id1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(835, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 35);
            this.pictureBox1.TabIndex = 165;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox11
            // 
            this.pictureBox11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox11.BackgroundImage")));
            this.pictureBox11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox11.Location = new System.Drawing.Point(174, 173);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(48, 42);
            this.pictureBox11.TabIndex = 164;
            this.pictureBox11.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(17, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 24);
            this.label5.TabIndex = 162;
            this.label5.Text = "Fine Fees:";
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox9.BackgroundImage")));
            this.pictureBox9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox9.Location = new System.Drawing.Point(832, 119);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(51, 29);
            this.pictureBox9.TabIndex = 158;
            this.pictureBox9.TabStop = false;
            // 
            // lbCreatedBy
            // 
            this.lbCreatedBy.AutoSize = true;
            this.lbCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lbCreatedBy.ForeColor = System.Drawing.Color.White;
            this.lbCreatedBy.Location = new System.Drawing.Point(889, 121);
            this.lbCreatedBy.Name = "lbCreatedBy";
            this.lbCreatedBy.Size = new System.Drawing.Size(36, 25);
            this.lbCreatedBy.TabIndex = 157;
            this.lbCreatedBy.Text = "??";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(643, 114);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(128, 24);
            this.label11.TabIndex = 155;
            this.label11.Text = "Created By:";
            // 
            // lbLicenseid
            // 
            this.lbLicenseid.AutoSize = true;
            this.lbLicenseid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lbLicenseid.ForeColor = System.Drawing.Color.White;
            this.lbLicenseid.Location = new System.Drawing.Point(889, 59);
            this.lbLicenseid.Name = "lbLicenseid";
            this.lbLicenseid.Size = new System.Drawing.Size(36, 25);
            this.lbLicenseid.TabIndex = 147;
            this.lbLicenseid.Text = "??";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(643, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 24);
            this.label7.TabIndex = 146;
            this.label7.Text = "License ID:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lbDetainDate
            // 
            this.lbDetainDate.AutoSize = true;
            this.lbDetainDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lbDetainDate.ForeColor = System.Drawing.Color.White;
            this.lbDetainDate.Location = new System.Drawing.Point(237, 115);
            this.lbDetainDate.Name = "lbDetainDate";
            this.lbDetainDate.Size = new System.Drawing.Size(36, 25);
            this.lbDetainDate.TabIndex = 87;
            this.lbDetainDate.Text = "??";
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackgroundImage = global::DVLD__Version_02_.Properties.Resources.calendar__2_;
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox6.Location = new System.Drawing.Point(174, 110);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(51, 33);
            this.pictureBox6.TabIndex = 86;
            this.pictureBox6.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(17, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 24);
            this.label3.TabIndex = 76;
            this.label3.Text = "Detain Date:";
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackgroundImage = global::DVLD__Version_02_.Properties.Resources.id1;
            this.pictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox8.Location = new System.Drawing.Point(174, 52);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(48, 35);
            this.pictureBox8.TabIndex = 75;
            this.pictureBox8.TabStop = false;
            // 
            // LbDetainID
            // 
            this.LbDetainID.AutoSize = true;
            this.LbDetainID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.LbDetainID.ForeColor = System.Drawing.Color.White;
            this.LbDetainID.Location = new System.Drawing.Point(231, 58);
            this.LbDetainID.Name = "LbDetainID";
            this.LbDetainID.Size = new System.Drawing.Size(42, 25);
            this.LbDetainID.TabIndex = 3;
            this.LbDetainID.Text = " ??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(17, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Detain ID:";
            // 
            // lbHeader
            // 
            this.lbHeader.AutoSize = true;
            this.lbHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lbHeader.ForeColor = System.Drawing.Color.Beige;
            this.lbHeader.Location = new System.Drawing.Point(536, 26);
            this.lbHeader.Name = "lbHeader";
            this.lbHeader.Size = new System.Drawing.Size(243, 45);
            this.lbHeader.TabIndex = 186;
            this.lbHeader.Text = "Detain  License";
            // 
            // ctrlDriverLicenseInfoWithFilter1
            // 
            this.ctrlDriverLicenseInfoWithFilter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(48)))));
            this.ctrlDriverLicenseInfoWithFilter1.FilterEnabled = true;
            this.ctrlDriverLicenseInfoWithFilter1.Location = new System.Drawing.Point(23, 77);
            this.ctrlDriverLicenseInfoWithFilter1.Name = "ctrlDriverLicenseInfoWithFilter1";
            this.ctrlDriverLicenseInfoWithFilter1.Size = new System.Drawing.Size(1276, 603);
            this.ctrlDriverLicenseInfoWithFilter1.TabIndex = 53;
            this.ctrlDriverLicenseInfoWithFilter1.OnPersonSelected += new System.Action<int>(this.ctrlDriverLicenseInfoWithFilter1_OnPersonSelected);
            // 
            // frmDetainApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1331, 981);
            this.Controls.Add(this.lbHeader);
            this.Controls.Add(this.llshowlicenseinfo);
            this.Controls.Add(this.llshowlicensehistory);
            this.Controls.Add(this.btndetain);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrlDriverLicenseInfoWithFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmDetainApplication";
            this.Text = "Detain Application";
            this.Load += new System.EventHandler(this.frmDetainApplication_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Licenses.Local_Licenses.Controls.ctrlDriverLicenseInfoWithFilter ctrlDriverLicenseInfoWithFilter1;
        private System.Windows.Forms.LinkLabel llshowlicenseinfo;
        private System.Windows.Forms.LinkLabel llshowlicensehistory;
        private System.Windows.Forms.Button btndetain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label lbCreatedBy;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbLicenseid;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbDetainDate;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label LbDetainID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtFineFees;
        private System.Windows.Forms.Label lbHeader;
    }
}