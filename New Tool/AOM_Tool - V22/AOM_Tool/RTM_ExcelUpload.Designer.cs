namespace AOM_Tool
{
    partial class RTM_ExcelUpload
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
            this.homepage = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.excelsheetname = new System.Windows.Forms.TextBox();
            this.excelfilepath = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtTaskType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtActivityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtVolumes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtEmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtLoginDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtStartDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtEndDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtComments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // homepage
            // 
            this.homepage.Location = new System.Drawing.Point(22, 12);
            this.homepage.Name = "homepage";
            this.homepage.Size = new System.Drawing.Size(128, 33);
            this.homepage.TabIndex = 15;
            this.homepage.Text = "Home Page";
            this.homepage.UseVisualStyleBackColor = true;
            this.homepage.Click += new System.EventHandler(this.homepage_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.reset);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Location = new System.Drawing.Point(372, 78);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(608, 113);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(7, 25);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(172, 58);
            this.button2.TabIndex = 0;
            this.button2.Text = "Load the records below";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // reset
            // 
            this.reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset.Location = new System.Drawing.Point(431, 25);
            this.reset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(142, 58);
            this.reset.TabIndex = 2;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(208, 25);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(192, 58);
            this.button3.TabIndex = 1;
            this.button3.Text = "Upload Final";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(234, 13);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(123, 32);
            this.button4.TabIndex = 26;
            this.button4.Text = "Select File";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(896, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 20);
            this.label2.TabIndex = 28;
            this.label2.Text = "Excel Sheet Name";
            // 
            // excelsheetname
            // 
            this.excelsheetname.Location = new System.Drawing.Point(1069, 13);
            this.excelsheetname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.excelsheetname.Name = "excelsheetname";
            this.excelsheetname.Size = new System.Drawing.Size(224, 26);
            this.excelsheetname.TabIndex = 29;
            // 
            // excelfilepath
            // 
            this.excelfilepath.Location = new System.Drawing.Point(414, 13);
            this.excelfilepath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.excelfilepath.Name = "excelfilepath";
            this.excelfilepath.Size = new System.Drawing.Size(414, 26);
            this.excelfilepath.TabIndex = 27;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtTaskType,
            this.txtTeamName,
            this.txtActivityName,
            this.txtVolumes,
            this.txtEmpName,
            this.txtLoginDate,
            this.txtStartDateTime,
            this.txtEndDateTime,
            this.txtComments});
            this.dataGridView1.Location = new System.Drawing.Point(22, 215);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1579, 667);
            this.dataGridView1.TabIndex = 31;
            // 
            // txtTaskType
            // 
            this.txtTaskType.DataPropertyName = "TaskType";
            this.txtTaskType.HeaderText = "TaskType";
            this.txtTaskType.Name = "txtTaskType";
            this.txtTaskType.ReadOnly = true;
            // 
            // txtTeamName
            // 
            this.txtTeamName.DataPropertyName = "TeamName";
            this.txtTeamName.HeaderText = "TeamName";
            this.txtTeamName.Name = "txtTeamName";
            this.txtTeamName.ReadOnly = true;
            this.txtTeamName.Width = 190;
            // 
            // txtActivityName
            // 
            this.txtActivityName.DataPropertyName = "ActivityName";
            this.txtActivityName.HeaderText = "ActivityName";
            this.txtActivityName.Name = "txtActivityName";
            this.txtActivityName.ReadOnly = true;
            this.txtActivityName.Width = 190;
            // 
            // txtVolumes
            // 
            this.txtVolumes.DataPropertyName = "Volumes";
            this.txtVolumes.HeaderText = "Volumes";
            this.txtVolumes.Name = "txtVolumes";
            this.txtVolumes.ReadOnly = true;
            this.txtVolumes.Width = 75;
            // 
            // txtEmpName
            // 
            this.txtEmpName.DataPropertyName = "EmpName";
            this.txtEmpName.HeaderText = "EmpName";
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.ReadOnly = true;
            this.txtEmpName.Width = 150;
            // 
            // txtLoginDate
            // 
            this.txtLoginDate.DataPropertyName = "LoginDate";
            this.txtLoginDate.HeaderText = "LoginDate";
            this.txtLoginDate.Name = "txtLoginDate";
            this.txtLoginDate.ReadOnly = true;
            // 
            // txtStartDateTime
            // 
            this.txtStartDateTime.DataPropertyName = "StartDateTime";
            this.txtStartDateTime.HeaderText = "StartDateTime";
            this.txtStartDateTime.Name = "txtStartDateTime";
            this.txtStartDateTime.ReadOnly = true;
            // 
            // txtEndDateTime
            // 
            this.txtEndDateTime.DataPropertyName = "EndDateTime";
            this.txtEndDateTime.HeaderText = "EndDateTime";
            this.txtEndDateTime.Name = "txtEndDateTime";
            this.txtEndDateTime.ReadOnly = true;
            // 
            // txtComments
            // 
            this.txtComments.DataPropertyName = "Comments";
            this.txtComments.HeaderText = "Comments";
            this.txtComments.Name = "txtComments";
            this.txtComments.ReadOnly = true;
            // 
            // RTM_ExcelUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1713, 956);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.excelsheetname);
            this.Controls.Add(this.excelfilepath);
            this.Controls.Add(this.homepage);
            this.Name = "RTM_ExcelUpload";
            this.Text = "RTM_ExcelUpload";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RTM_ExcelUpload_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button homepage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox excelsheetname;
        private System.Windows.Forms.TextBox excelfilepath;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTaskType;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTeamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtActivityName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtVolumes;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtEmpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtLoginDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtStartDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtEndDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtComments;
    }
}