namespace AOM_Tool
{
    partial class Amend_TeamDetails
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
            this.label1 = new System.Windows.Forms.Label();
            this.empname = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.teamname = new System.Windows.Forms.ComboBox();
            this.checkbox_iscore = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtEmpID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtEmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtReportingManager = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtActivityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtIsCore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.searchby_empname = new System.Windows.Forms.ComboBox();
            this.searchby_reportingmanager = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.update = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.homepage = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Emp Name";
            // 
            // empname
            // 
            this.empname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.empname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.empname.FormattingEnabled = true;
            this.empname.Location = new System.Drawing.Point(188, 58);
            this.empname.Name = "empname";
            this.empname.Size = new System.Drawing.Size(276, 28);
            this.empname.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Team Name";
            // 
            // teamname
            // 
            this.teamname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.teamname.FormattingEnabled = true;
            this.teamname.Location = new System.Drawing.Point(188, 105);
            this.teamname.Name = "teamname";
            this.teamname.Size = new System.Drawing.Size(362, 28);
            this.teamname.TabIndex = 3;
            // 
            // checkbox_iscore
            // 
            this.checkbox_iscore.AutoSize = true;
            this.checkbox_iscore.Location = new System.Drawing.Point(586, 105);
            this.checkbox_iscore.Name = "checkbox_iscore";
            this.checkbox_iscore.Size = new System.Drawing.Size(82, 24);
            this.checkbox_iscore.TabIndex = 4;
            this.checkbox_iscore.Text = "IsCore";
            this.checkbox_iscore.UseVisualStyleBackColor = true;
            this.checkbox_iscore.CheckedChanged += new System.EventHandler(this.checkbox_iscore_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtEmpID,
            this.txtEmpName,
            this.txtReportingManager,
            this.txtTeamName,
            this.txtActivityName,
            this.txtIsCore});
            this.dataGridView1.Location = new System.Drawing.Point(34, 109);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1632, 693);
            this.dataGridView1.TabIndex = 5;
            // 
            // txtEmpID
            // 
            this.txtEmpID.DataPropertyName = "EmpID";
            this.txtEmpID.HeaderText = "EmpID";
            this.txtEmpID.Name = "txtEmpID";
            this.txtEmpID.ReadOnly = true;
            // 
            // txtEmpName
            // 
            this.txtEmpName.DataPropertyName = "EmpName";
            this.txtEmpName.HeaderText = "EmpName";
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.ReadOnly = true;
            // 
            // txtReportingManager
            // 
            this.txtReportingManager.DataPropertyName = "ReportingManager";
            this.txtReportingManager.HeaderText = "ReportingManager";
            this.txtReportingManager.Name = "txtReportingManager";
            this.txtReportingManager.ReadOnly = true;
            // 
            // txtTeamName
            // 
            this.txtTeamName.DataPropertyName = "TeamName";
            this.txtTeamName.HeaderText = "TeamName";
            this.txtTeamName.Name = "txtTeamName";
            this.txtTeamName.ReadOnly = true;
            this.txtTeamName.Width = 200;
            // 
            // txtActivityName
            // 
            this.txtActivityName.DataPropertyName = "ActivityName";
            this.txtActivityName.HeaderText = "ActivityName";
            this.txtActivityName.Name = "txtActivityName";
            this.txtActivityName.ReadOnly = true;
            this.txtActivityName.Width = 200;
            // 
            // txtIsCore
            // 
            this.txtIsCore.DataPropertyName = "IsCore";
            this.txtIsCore.HeaderText = "IsCore";
            this.txtIsCore.Name = "txtIsCore";
            this.txtIsCore.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.searchby_empname);
            this.groupBox1.Controls.Add(this.searchby_reportingmanager);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(17, 195);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1688, 807);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // searchby_empname
            // 
            this.searchby_empname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchby_empname.FormattingEnabled = true;
            this.searchby_empname.Location = new System.Drawing.Point(417, 24);
            this.searchby_empname.Name = "searchby_empname";
            this.searchby_empname.Size = new System.Drawing.Size(277, 28);
            this.searchby_empname.TabIndex = 9;
            this.searchby_empname.SelectedIndexChanged += new System.EventHandler(this.searchby_empname_SelectedIndexChanged);
            // 
            // searchby_reportingmanager
            // 
            this.searchby_reportingmanager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchby_reportingmanager.FormattingEnabled = true;
            this.searchby_reportingmanager.Location = new System.Drawing.Point(88, 24);
            this.searchby_reportingmanager.Name = "searchby_reportingmanager";
            this.searchby_reportingmanager.Size = new System.Drawing.Size(304, 28);
            this.searchby_reportingmanager.TabIndex = 8;
            this.searchby_reportingmanager.SelectedIndexChanged += new System.EventHandler(this.searchby_reportingmanager_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(451, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Search by Associate Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(130, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Search by Reporting Manager";
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(151, 151);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(121, 40);
            this.update.TabIndex = 5;
            this.update.Text = "Update";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(429, 151);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(121, 40);
            this.reset.TabIndex = 6;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // homepage
            // 
            this.homepage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homepage.Location = new System.Drawing.Point(17, 12);
            this.homepage.Name = "homepage";
            this.homepage.Size = new System.Drawing.Size(128, 33);
            this.homepage.TabIndex = 14;
            this.homepage.Text = "Home Page";
            this.homepage.UseVisualStyleBackColor = true;
            this.homepage.Click += new System.EventHandler(this.homepage_Click);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(288, 151);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(121, 40);
            this.delete.TabIndex = 15;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // Amend_TeamDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1729, 1050);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.homepage);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.update);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkbox_iscore);
            this.Controls.Add(this.teamname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.empname);
            this.Controls.Add(this.label1);
            this.Name = "Amend_TeamDetails";
            this.Text = "Amend_TeamDetails";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Amend_TeamDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox empname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox teamname;
        private System.Windows.Forms.CheckBox checkbox_iscore;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox searchby_empname;
        private System.Windows.Forms.ComboBox searchby_reportingmanager;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtEmpID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtEmpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtReportingManager;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTeamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtActivityName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtIsCore;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Button homepage;
        private System.Windows.Forms.Button delete;
    }
}