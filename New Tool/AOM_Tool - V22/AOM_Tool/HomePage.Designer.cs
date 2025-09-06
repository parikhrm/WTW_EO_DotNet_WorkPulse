namespace AOM_Tool
{
    partial class HomePage
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
            this.rtm = new System.Windows.Forms.Button();
            this.finalverification = new System.Windows.Forms.Button();
            this.accesscheck = new System.Windows.Forms.ComboBox();
            this.reports = new System.Windows.Forms.Button();
            this.amend_teamdetails = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtm
            // 
            this.rtm.BackColor = System.Drawing.Color.Purple;
            this.rtm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtm.ForeColor = System.Drawing.Color.White;
            this.rtm.Location = new System.Drawing.Point(525, 156);
            this.rtm.Name = "rtm";
            this.rtm.Size = new System.Drawing.Size(201, 87);
            this.rtm.TabIndex = 0;
            this.rtm.Text = "RTM";
            this.rtm.UseVisualStyleBackColor = false;
            this.rtm.Click += new System.EventHandler(this.rtm_Click);
            // 
            // finalverification
            // 
            this.finalverification.BackColor = System.Drawing.Color.Purple;
            this.finalverification.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finalverification.ForeColor = System.Drawing.Color.White;
            this.finalverification.Location = new System.Drawing.Point(768, 156);
            this.finalverification.Name = "finalverification";
            this.finalverification.Size = new System.Drawing.Size(201, 87);
            this.finalverification.TabIndex = 1;
            this.finalverification.Text = "Final Verification";
            this.finalverification.UseVisualStyleBackColor = false;
            this.finalverification.Click += new System.EventHandler(this.verification_Click);
            // 
            // accesscheck
            // 
            this.accesscheck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.accesscheck.FormattingEnabled = true;
            this.accesscheck.Location = new System.Drawing.Point(1400, 27);
            this.accesscheck.Name = "accesscheck";
            this.accesscheck.Size = new System.Drawing.Size(121, 28);
            this.accesscheck.TabIndex = 2;
            // 
            // reports
            // 
            this.reports.BackColor = System.Drawing.Color.Purple;
            this.reports.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reports.ForeColor = System.Drawing.Color.White;
            this.reports.Location = new System.Drawing.Point(525, 282);
            this.reports.Name = "reports";
            this.reports.Size = new System.Drawing.Size(201, 83);
            this.reports.TabIndex = 3;
            this.reports.Text = "Reports";
            this.reports.UseVisualStyleBackColor = false;
            this.reports.Click += new System.EventHandler(this.reports_Click);
            // 
            // amend_teamdetails
            // 
            this.amend_teamdetails.BackColor = System.Drawing.Color.Purple;
            this.amend_teamdetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amend_teamdetails.ForeColor = System.Drawing.Color.White;
            this.amend_teamdetails.Location = new System.Drawing.Point(768, 282);
            this.amend_teamdetails.Name = "amend_teamdetails";
            this.amend_teamdetails.Size = new System.Drawing.Size(201, 83);
            this.amend_teamdetails.TabIndex = 4;
            this.amend_teamdetails.Text = "Amend Team Details";
            this.amend_teamdetails.UseVisualStyleBackColor = false;
            this.amend_teamdetails.Click += new System.EventHandler(this.amend_teamdetails_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(525, 394);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(663, 228);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Formuals";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(332, 62);
            this.label2.TabIndex = 1;
            this.label2.Text = "Utilization% =\r\n(Total Core Time + Diverted Core Time) /\r\n(Total Core Time + Tota" +
    "l Diverted Time)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 62);
            this.label1.TabIndex = 0;
            this.label1.Text = "Productivity% =\r\nWorkOutput(Volumes * AHT) / \r\n((Contract Hours - Break Time)*90%" +
    ")";
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1638, 677);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.amend_teamdetails);
            this.Controls.Add(this.reports);
            this.Controls.Add(this.accesscheck);
            this.Controls.Add(this.finalverification);
            this.Controls.Add(this.rtm);
            this.Name = "HomePage";
            this.Text = "WorkPulse";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button rtm;
        private System.Windows.Forms.Button finalverification;
        private System.Windows.Forms.ComboBox accesscheck;
        private System.Windows.Forms.Button reports;
        private System.Windows.Forms.Button amend_teamdetails;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;

    }
}