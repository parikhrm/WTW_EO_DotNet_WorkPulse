namespace AOM_Tool
{
    partial class RTM_Verification
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.homepage = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtActivityNameID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCoreTeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTaskType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtActivityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtVolumes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtEmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAssociateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTimeTakeninMinutes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTimeTakeninSeconds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTeamNameID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchby_date = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.searchby_associatename = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.coreteamname = new System.Windows.Forms.ComboBox();
            this.volumes = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.empname = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.activityname = new System.Windows.Forms.ComboBox();
            this.teamname = new System.Windows.Forms.ComboBox();
            this.tasktype = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.delete = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.endtime = new System.Windows.Forms.DateTimePicker();
            this.enddate = new System.Windows.Forms.DateTimePicker();
            this.starttime = new System.Windows.Forms.DateTimePicker();
            this.startdate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.utilization_combobox = new System.Windows.Forms.ComboBox();
            this.productivity_combobox = new System.Windows.Forms.ComboBox();
            this.downtime_seconds = new System.Windows.Forms.ComboBox();
            this.divertedtime_seconds = new System.Windows.Forms.ComboBox();
            this.coretime_seconds = new System.Windows.Forms.ComboBox();
            this.breaktime_seconds = new System.Windows.Forms.ComboBox();
            this.divertedtime_minutes = new System.Windows.Forms.ComboBox();
            this.radio_minutes = new System.Windows.Forms.RadioButton();
            this.refresh = new System.Windows.Forms.Button();
            this.downtime_minutes = new System.Windows.Forms.ComboBox();
            this.breaktime_minutes = new System.Windows.Forms.ComboBox();
            this.radio_volumes = new System.Windows.Forms.RadioButton();
            this.coretime_minutes = new System.Windows.Forms.ComboBox();
            this.logoff = new System.Windows.Forms.Button();
            this.datagridview_check = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.searchby_reportingmanagername = new System.Windows.Forms.ComboBox();
            this.updatefinal = new System.Windows.Forms.Button();
            this.teamnameid = new System.Windows.Forms.TextBox();
            this.addtask = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumes)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // homepage
            // 
            this.homepage.Location = new System.Drawing.Point(12, 6);
            this.homepage.Name = "homepage";
            this.homepage.Size = new System.Drawing.Size(128, 33);
            this.homepage.TabIndex = 14;
            this.homepage.Text = "Home Page";
            this.homepage.UseVisualStyleBackColor = true;
            this.homepage.Click += new System.EventHandler(this.homepage_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtID,
            this.txtActivityNameID,
            this.txtCoreTeamName,
            this.txtTaskType,
            this.txtTeamName,
            this.txtActivityName,
            this.txtVolumes,
            this.txtEmpName,
            this.txtAssociateName,
            this.txtStartDate,
            this.txtStartTime,
            this.txtEndDate,
            this.txtEndTime,
            this.txtTimeTakeninMinutes,
            this.txtTimeTakeninSeconds,
            this.txtTeamNameID});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(12, 377);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1896, 661);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // txtID
            // 
            this.txtID.DataPropertyName = "ID";
            this.txtID.HeaderText = "ID";
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Width = 50;
            // 
            // txtActivityNameID
            // 
            this.txtActivityNameID.DataPropertyName = "ActivityNameID";
            this.txtActivityNameID.HeaderText = "ActivityNameID";
            this.txtActivityNameID.Name = "txtActivityNameID";
            this.txtActivityNameID.ReadOnly = true;
            this.txtActivityNameID.Visible = false;
            // 
            // txtCoreTeamName
            // 
            this.txtCoreTeamName.DataPropertyName = "CoreTeamName";
            this.txtCoreTeamName.HeaderText = "TeamName";
            this.txtCoreTeamName.Name = "txtCoreTeamName";
            this.txtCoreTeamName.ReadOnly = true;
            this.txtCoreTeamName.Width = 250;
            // 
            // txtTaskType
            // 
            this.txtTaskType.DataPropertyName = "TaskType";
            this.txtTaskType.HeaderText = "TaskType";
            this.txtTaskType.Name = "txtTaskType";
            this.txtTaskType.ReadOnly = true;
            this.txtTaskType.Width = 65;
            // 
            // txtTeamName
            // 
            this.txtTeamName.DataPropertyName = "TeamName";
            this.txtTeamName.HeaderText = "TeamName";
            this.txtTeamName.Name = "txtTeamName";
            this.txtTeamName.ReadOnly = true;
            this.txtTeamName.Visible = false;
            this.txtTeamName.Width = 250;
            // 
            // txtActivityName
            // 
            this.txtActivityName.DataPropertyName = "ActivityName";
            this.txtActivityName.HeaderText = "ActivityName";
            this.txtActivityName.Name = "txtActivityName";
            this.txtActivityName.ReadOnly = true;
            this.txtActivityName.Width = 250;
            // 
            // txtVolumes
            // 
            this.txtVolumes.DataPropertyName = "Volumes";
            this.txtVolumes.HeaderText = "Volumes";
            this.txtVolumes.Name = "txtVolumes";
            this.txtVolumes.ReadOnly = true;
            this.txtVolumes.Width = 50;
            // 
            // txtEmpName
            // 
            this.txtEmpName.DataPropertyName = "EmpName";
            this.txtEmpName.HeaderText = "EmpName";
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.ReadOnly = true;
            // 
            // txtAssociateName
            // 
            this.txtAssociateName.DataPropertyName = "AssociateName";
            this.txtAssociateName.HeaderText = "AssociateName";
            this.txtAssociateName.Name = "txtAssociateName";
            this.txtAssociateName.ReadOnly = true;
            this.txtAssociateName.Visible = false;
            // 
            // txtStartDate
            // 
            this.txtStartDate.DataPropertyName = "StartDate";
            this.txtStartDate.HeaderText = "StartDate (Editable)";
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.ReadOnly = true;
            // 
            // txtStartTime
            // 
            this.txtStartTime.DataPropertyName = "StartTime";
            this.txtStartTime.HeaderText = "StartTime (Editable)";
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.ReadOnly = true;
            // 
            // txtEndDate
            // 
            this.txtEndDate.DataPropertyName = "EndDate";
            this.txtEndDate.HeaderText = "EndDate (Editable)";
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.ReadOnly = true;
            // 
            // txtEndTime
            // 
            this.txtEndTime.DataPropertyName = "EndTime";
            this.txtEndTime.HeaderText = "EndTime (Editable)";
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.ReadOnly = true;
            // 
            // txtTimeTakeninMinutes
            // 
            this.txtTimeTakeninMinutes.DataPropertyName = "TimeTakeninMinutes";
            this.txtTimeTakeninMinutes.HeaderText = "TimeTakeninMinutes";
            this.txtTimeTakeninMinutes.Name = "txtTimeTakeninMinutes";
            this.txtTimeTakeninMinutes.ReadOnly = true;
            this.txtTimeTakeninMinutes.Width = 120;
            // 
            // txtTimeTakeninSeconds
            // 
            this.txtTimeTakeninSeconds.DataPropertyName = "TimeTakeninSeconds";
            this.txtTimeTakeninSeconds.HeaderText = "TimeTakeninSeconds";
            this.txtTimeTakeninSeconds.Name = "txtTimeTakeninSeconds";
            this.txtTimeTakeninSeconds.ReadOnly = true;
            this.txtTimeTakeninSeconds.Visible = false;
            this.txtTimeTakeninSeconds.Width = 120;
            // 
            // txtTeamNameID
            // 
            this.txtTeamNameID.DataPropertyName = "TeamNameID";
            this.txtTeamNameID.HeaderText = "TeamNameID";
            this.txtTeamNameID.Name = "txtTeamNameID";
            this.txtTeamNameID.ReadOnly = true;
            this.txtTeamNameID.Visible = false;
            // 
            // searchby_date
            // 
            this.searchby_date.CustomFormat = " ";
            this.searchby_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.searchby_date.Location = new System.Drawing.Point(13, 306);
            this.searchby_date.Name = "searchby_date";
            this.searchby_date.Size = new System.Drawing.Size(257, 26);
            this.searchby_date.TabIndex = 16;
            this.searchby_date.ValueChanged += new System.EventHandler(this.searchby_date_ValueChanged);
            this.searchby_date.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchby_date_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 339);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Search by Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(565, 339);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Search by Associate Name";
            // 
            // searchby_associatename
            // 
            this.searchby_associatename.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchby_associatename.FormattingEnabled = true;
            this.searchby_associatename.Location = new System.Drawing.Point(546, 306);
            this.searchby_associatename.Name = "searchby_associatename";
            this.searchby_associatename.Size = new System.Drawing.Size(247, 28);
            this.searchby_associatename.TabIndex = 19;
            this.searchby_associatename.SelectedIndexChanged += new System.EventHandler(this.searchby_associatename_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.coreteamname);
            this.groupBox1.Controls.Add(this.volumes);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.empname);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.activityname);
            this.groupBox1.Controls.Add(this.teamname);
            this.groupBox1.Controls.Add(this.tasktype);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.delete);
            this.groupBox1.Controls.Add(this.update);
            this.groupBox1.Controls.Add(this.id);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.endtime);
            this.groupBox1.Controls.Add(this.enddate);
            this.groupBox1.Controls.Add(this.starttime);
            this.groupBox1.Controls.Add(this.startdate);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(13, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1868, 122);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // coreteamname
            // 
            this.coreteamname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.coreteamname.FormattingEnabled = true;
            this.coreteamname.Location = new System.Drawing.Point(400, 73);
            this.coreteamname.Name = "coreteamname";
            this.coreteamname.Size = new System.Drawing.Size(326, 28);
            this.coreteamname.TabIndex = 30;
            this.coreteamname.SelectedIndexChanged += new System.EventHandler(this.coreteamname_SelectedIndexChanged);
            // 
            // volumes
            // 
            this.volumes.Location = new System.Drawing.Point(1509, 31);
            this.volumes.Name = "volumes";
            this.volumes.Size = new System.Drawing.Size(88, 26);
            this.volumes.TabIndex = 29;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1423, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 20);
            this.label12.TabIndex = 28;
            this.label12.Text = "Volumes";
            // 
            // empname
            // 
            this.empname.Location = new System.Drawing.Point(1278, 72);
            this.empname.Name = "empname";
            this.empname.Size = new System.Drawing.Size(216, 26);
            this.empname.TabIndex = 27;
            this.empname.TextChanged += new System.EventHandler(this.empname_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1185, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 20);
            this.label11.TabIndex = 26;
            this.label11.Text = "Emp Name";
            // 
            // activityname
            // 
            this.activityname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.activityname.FormattingEnabled = true;
            this.activityname.Location = new System.Drawing.Point(846, 72);
            this.activityname.Name = "activityname";
            this.activityname.Size = new System.Drawing.Size(329, 28);
            this.activityname.TabIndex = 25;
            this.activityname.SelectedIndexChanged += new System.EventHandler(this.activityname_SelectedIndexChanged);
            // 
            // teamname
            // 
            this.teamname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.teamname.FormattingEnabled = true;
            this.teamname.Location = new System.Drawing.Point(400, 72);
            this.teamname.Name = "teamname";
            this.teamname.Size = new System.Drawing.Size(326, 28);
            this.teamname.TabIndex = 24;
            this.teamname.SelectedIndexChanged += new System.EventHandler(this.teamname_SelectedIndexChanged);
            // 
            // tasktype
            // 
            this.tasktype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tasktype.FormattingEnabled = true;
            this.tasktype.Location = new System.Drawing.Point(103, 72);
            this.tasktype.Name = "tasktype";
            this.tasktype.Size = new System.Drawing.Size(185, 28);
            this.tasktype.TabIndex = 23;
            this.tasktype.SelectedIndexChanged += new System.EventHandler(this.tasktype_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(737, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 20);
            this.label6.TabIndex = 22;
            this.label6.Text = "Activity Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(298, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "Team Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Task Type";
            // 
            // delete
            // 
            this.delete.BackColor = System.Drawing.Color.SlateGray;
            this.delete.Location = new System.Drawing.Point(1603, 71);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(95, 38);
            this.delete.TabIndex = 19;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // update
            // 
            this.update.BackColor = System.Drawing.Color.DodgerBlue;
            this.update.Location = new System.Drawing.Point(1502, 71);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(95, 38);
            this.update.TabIndex = 18;
            this.update.Text = "Update";
            this.update.UseVisualStyleBackColor = false;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(40, 26);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(87, 26);
            this.id.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "ID";
            // 
            // endtime
            // 
            this.endtime.CustomFormat = " ";
            this.endtime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endtime.Location = new System.Drawing.Point(1204, 26);
            this.endtime.Name = "endtime";
            this.endtime.ShowUpDown = true;
            this.endtime.Size = new System.Drawing.Size(200, 26);
            this.endtime.TabIndex = 15;
            this.endtime.ValueChanged += new System.EventHandler(this.endtime_ValueChanged);
            this.endtime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.endtime_KeyDown);
            this.endtime.MouseDown += new System.Windows.Forms.MouseEventHandler(this.endtime_MouseDown);
            // 
            // enddate
            // 
            this.enddate.CustomFormat = " ";
            this.enddate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.enddate.Location = new System.Drawing.Point(867, 26);
            this.enddate.Name = "enddate";
            this.enddate.Size = new System.Drawing.Size(241, 26);
            this.enddate.TabIndex = 14;
            this.enddate.ValueChanged += new System.EventHandler(this.enddate_ValueChanged);
            this.enddate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enddate_KeyDown);
            // 
            // starttime
            // 
            this.starttime.CustomFormat = " ";
            this.starttime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.starttime.Location = new System.Drawing.Point(572, 25);
            this.starttime.Name = "starttime";
            this.starttime.ShowUpDown = true;
            this.starttime.Size = new System.Drawing.Size(200, 26);
            this.starttime.TabIndex = 13;
            this.starttime.ValueChanged += new System.EventHandler(this.starttime_ValueChanged);
            this.starttime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.starttime_KeyDown);
            this.starttime.MouseDown += new System.Windows.Forms.MouseEventHandler(this.starttime_MouseDown);
            // 
            // startdate
            // 
            this.startdate.CustomFormat = " ";
            this.startdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startdate.Location = new System.Drawing.Point(234, 26);
            this.startdate.Name = "startdate";
            this.startdate.Size = new System.Drawing.Size(248, 26);
            this.startdate.TabIndex = 12;
            this.startdate.ValueChanged += new System.EventHandler(this.startdate_ValueChanged);
            this.startdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.startdate_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1120, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 20);
            this.label10.TabIndex = 7;
            this.label10.Text = "EndTime";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(786, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 20);
            this.label9.TabIndex = 6;
            this.label9.Text = "EndDate";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(488, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 20);
            this.label8.TabIndex = 5;
            this.label8.Text = "StartTime";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(139, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "StartDate";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.utilization_combobox);
            this.groupBox2.Controls.Add(this.productivity_combobox);
            this.groupBox2.Controls.Add(this.downtime_seconds);
            this.groupBox2.Controls.Add(this.divertedtime_seconds);
            this.groupBox2.Controls.Add(this.coretime_seconds);
            this.groupBox2.Controls.Add(this.breaktime_seconds);
            this.groupBox2.Controls.Add(this.divertedtime_minutes);
            this.groupBox2.Controls.Add(this.radio_minutes);
            this.groupBox2.Controls.Add(this.refresh);
            this.groupBox2.Controls.Add(this.downtime_minutes);
            this.groupBox2.Controls.Add(this.breaktime_minutes);
            this.groupBox2.Controls.Add(this.radio_volumes);
            this.groupBox2.Controls.Add(this.coretime_minutes);
            this.groupBox2.Location = new System.Drawing.Point(13, 183);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1227, 110);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            // 
            // utilization_combobox
            // 
            this.utilization_combobox.BackColor = System.Drawing.Color.DodgerBlue;
            this.utilization_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.utilization_combobox.ForeColor = System.Drawing.Color.Black;
            this.utilization_combobox.FormattingEnabled = true;
            this.utilization_combobox.Location = new System.Drawing.Point(875, 21);
            this.utilization_combobox.Name = "utilization_combobox";
            this.utilization_combobox.Size = new System.Drawing.Size(229, 28);
            this.utilization_combobox.TabIndex = 26;
            // 
            // productivity_combobox
            // 
            this.productivity_combobox.BackColor = System.Drawing.Color.GreenYellow;
            this.productivity_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.productivity_combobox.ForeColor = System.Drawing.Color.Black;
            this.productivity_combobox.FormattingEnabled = true;
            this.productivity_combobox.Location = new System.Drawing.Point(875, 55);
            this.productivity_combobox.Name = "productivity_combobox";
            this.productivity_combobox.Size = new System.Drawing.Size(229, 28);
            this.productivity_combobox.TabIndex = 25;
            // 
            // downtime_seconds
            // 
            this.downtime_seconds.BackColor = System.Drawing.Color.MediumPurple;
            this.downtime_seconds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.downtime_seconds.FormattingEnabled = true;
            this.downtime_seconds.Location = new System.Drawing.Point(621, 57);
            this.downtime_seconds.Name = "downtime_seconds";
            this.downtime_seconds.Size = new System.Drawing.Size(200, 28);
            this.downtime_seconds.TabIndex = 24;
            // 
            // divertedtime_seconds
            // 
            this.divertedtime_seconds.BackColor = System.Drawing.Color.Orange;
            this.divertedtime_seconds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.divertedtime_seconds.FormattingEnabled = true;
            this.divertedtime_seconds.Location = new System.Drawing.Point(420, 57);
            this.divertedtime_seconds.Name = "divertedtime_seconds";
            this.divertedtime_seconds.Size = new System.Drawing.Size(200, 28);
            this.divertedtime_seconds.TabIndex = 23;
            // 
            // coretime_seconds
            // 
            this.coretime_seconds.BackColor = System.Drawing.Color.LimeGreen;
            this.coretime_seconds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.coretime_seconds.FormattingEnabled = true;
            this.coretime_seconds.Location = new System.Drawing.Point(218, 57);
            this.coretime_seconds.Name = "coretime_seconds";
            this.coretime_seconds.Size = new System.Drawing.Size(200, 28);
            this.coretime_seconds.TabIndex = 22;
            // 
            // breaktime_seconds
            // 
            this.breaktime_seconds.BackColor = System.Drawing.Color.IndianRed;
            this.breaktime_seconds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.breaktime_seconds.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.breaktime_seconds.FormattingEnabled = true;
            this.breaktime_seconds.Location = new System.Drawing.Point(18, 57);
            this.breaktime_seconds.Name = "breaktime_seconds";
            this.breaktime_seconds.Size = new System.Drawing.Size(200, 28);
            this.breaktime_seconds.TabIndex = 22;
            // 
            // divertedtime_minutes
            // 
            this.divertedtime_minutes.BackColor = System.Drawing.Color.Orange;
            this.divertedtime_minutes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.divertedtime_minutes.FormattingEnabled = true;
            this.divertedtime_minutes.Location = new System.Drawing.Point(420, 57);
            this.divertedtime_minutes.Name = "divertedtime_minutes";
            this.divertedtime_minutes.Size = new System.Drawing.Size(200, 28);
            this.divertedtime_minutes.TabIndex = 22;
            // 
            // radio_minutes
            // 
            this.radio_minutes.AutoSize = true;
            this.radio_minutes.Location = new System.Drawing.Point(17, 25);
            this.radio_minutes.Name = "radio_minutes";
            this.radio_minutes.Size = new System.Drawing.Size(90, 24);
            this.radio_minutes.TabIndex = 25;
            this.radio_minutes.TabStop = true;
            this.radio_minutes.Text = "Minutes";
            this.radio_minutes.UseVisualStyleBackColor = true;
            this.radio_minutes.CheckedChanged += new System.EventHandler(this.radio_minutes_CheckedChanged);
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(242, 23);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(101, 30);
            this.refresh.TabIndex = 27;
            this.refresh.Text = "Refresh";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // downtime_minutes
            // 
            this.downtime_minutes.BackColor = System.Drawing.Color.MediumPurple;
            this.downtime_minutes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.downtime_minutes.FormattingEnabled = true;
            this.downtime_minutes.Location = new System.Drawing.Point(621, 57);
            this.downtime_minutes.Name = "downtime_minutes";
            this.downtime_minutes.Size = new System.Drawing.Size(200, 28);
            this.downtime_minutes.TabIndex = 23;
            // 
            // breaktime_minutes
            // 
            this.breaktime_minutes.BackColor = System.Drawing.Color.IndianRed;
            this.breaktime_minutes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.breaktime_minutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.breaktime_minutes.FormattingEnabled = true;
            this.breaktime_minutes.Location = new System.Drawing.Point(17, 58);
            this.breaktime_minutes.Name = "breaktime_minutes";
            this.breaktime_minutes.Size = new System.Drawing.Size(200, 28);
            this.breaktime_minutes.TabIndex = 17;
            // 
            // radio_volumes
            // 
            this.radio_volumes.AutoSize = true;
            this.radio_volumes.Location = new System.Drawing.Point(128, 25);
            this.radio_volumes.Name = "radio_volumes";
            this.radio_volumes.Size = new System.Drawing.Size(96, 24);
            this.radio_volumes.TabIndex = 26;
            this.radio_volumes.TabStop = true;
            this.radio_volumes.Text = "Volumes";
            this.radio_volumes.UseVisualStyleBackColor = true;
            this.radio_volumes.CheckedChanged += new System.EventHandler(this.radio_volumes_CheckedChanged);
            // 
            // coretime_minutes
            // 
            this.coretime_minutes.BackColor = System.Drawing.Color.LimeGreen;
            this.coretime_minutes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.coretime_minutes.FormattingEnabled = true;
            this.coretime_minutes.Location = new System.Drawing.Point(218, 57);
            this.coretime_minutes.Name = "coretime_minutes";
            this.coretime_minutes.Size = new System.Drawing.Size(200, 28);
            this.coretime_minutes.TabIndex = 19;
            // 
            // logoff
            // 
            this.logoff.BackColor = System.Drawing.Color.DarkViolet;
            this.logoff.ForeColor = System.Drawing.Color.White;
            this.logoff.Location = new System.Drawing.Point(1093, 307);
            this.logoff.Name = "logoff";
            this.logoff.Size = new System.Drawing.Size(106, 40);
            this.logoff.TabIndex = 22;
            this.logoff.Text = "Log Off";
            this.logoff.UseVisualStyleBackColor = false;
            this.logoff.Click += new System.EventHandler(this.logoff_Click);
            // 
            // datagridview_check
            // 
            this.datagridview_check.Location = new System.Drawing.Point(1316, 323);
            this.datagridview_check.Name = "datagridview_check";
            this.datagridview_check.Size = new System.Drawing.Size(131, 23);
            this.datagridview_check.TabIndex = 23;
            this.datagridview_check.Text = "DataGridView_Check";
            this.datagridview_check.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(305, 339);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(200, 20);
            this.label13.TabIndex = 24;
            this.label13.Text = "Search by Reporting Name";
            // 
            // searchby_reportingmanagername
            // 
            this.searchby_reportingmanagername.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchby_reportingmanagername.FormattingEnabled = true;
            this.searchby_reportingmanagername.Location = new System.Drawing.Point(280, 307);
            this.searchby_reportingmanagername.Name = "searchby_reportingmanagername";
            this.searchby_reportingmanagername.Size = new System.Drawing.Size(260, 28);
            this.searchby_reportingmanagername.TabIndex = 25;
            this.searchby_reportingmanagername.SelectedIndexChanged += new System.EventHandler(this.searchby_reportingmanagername_SelectedIndexChanged);
            // 
            // updatefinal
            // 
            this.updatefinal.BackColor = System.Drawing.Color.RoyalBlue;
            this.updatefinal.ForeColor = System.Drawing.Color.White;
            this.updatefinal.Location = new System.Drawing.Point(936, 307);
            this.updatefinal.Name = "updatefinal";
            this.updatefinal.Size = new System.Drawing.Size(151, 40);
            this.updatefinal.TabIndex = 26;
            this.updatefinal.Text = "Update Final";
            this.updatefinal.UseVisualStyleBackColor = false;
            this.updatefinal.Click += new System.EventHandler(this.updatefinal_Click);
            // 
            // teamnameid
            // 
            this.teamnameid.Location = new System.Drawing.Point(433, 13);
            this.teamnameid.Name = "teamnameid";
            this.teamnameid.Size = new System.Drawing.Size(165, 26);
            this.teamnameid.TabIndex = 27;
            // 
            // addtask
            // 
            this.addtask.AutoSize = true;
            this.addtask.Location = new System.Drawing.Point(812, 312);
            this.addtask.Name = "addtask";
            this.addtask.Size = new System.Drawing.Size(111, 20);
            this.addtask.TabIndex = 28;
            this.addtask.TabStop = true;
            this.addtask.Text = "Add New Task";
            this.addtask.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.addtask_LinkClicked);
            // 
            // RTM_Verification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1920, 1050);
            this.Controls.Add(this.addtask);
            this.Controls.Add(this.teamnameid);
            this.Controls.Add(this.updatefinal);
            this.Controls.Add(this.searchby_reportingmanagername);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.datagridview_check);
            this.Controls.Add(this.logoff);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.searchby_associatename);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchby_date);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.homepage);
            this.Name = "RTM_Verification";
            this.Text = "Verification";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Verification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumes)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button homepage;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker searchby_date;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox searchby_associatename;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker endtime;
        private System.Windows.Forms.DateTimePicker enddate;
        private System.Windows.Forms.DateTimePicker starttime;
        private System.Windows.Forms.DateTimePicker startdate;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox divertedtime_minutes;
        private System.Windows.Forms.RadioButton radio_minutes;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.ComboBox downtime_minutes;
        private System.Windows.Forms.ComboBox breaktime_minutes;
        private System.Windows.Forms.RadioButton radio_volumes;
        private System.Windows.Forms.ComboBox coretime_minutes;
        private System.Windows.Forms.ComboBox coretime_seconds;
        private System.Windows.Forms.ComboBox breaktime_seconds;
        private System.Windows.Forms.ComboBox downtime_seconds;
        private System.Windows.Forms.ComboBox divertedtime_seconds;
        private System.Windows.Forms.Button logoff;
        private System.Windows.Forms.ComboBox productivity_combobox;
        private System.Windows.Forms.ComboBox utilization_combobox;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.ComboBox activityname;
        private System.Windows.Forms.ComboBox teamname;
        private System.Windows.Forms.ComboBox tasktype;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button datagridview_check;
        private System.Windows.Forms.TextBox empname;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown volumes;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox searchby_reportingmanagername;
        private System.Windows.Forms.Button updatefinal;
        private System.Windows.Forms.ComboBox coreteamname;
        private System.Windows.Forms.TextBox teamnameid;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtActivityNameID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCoreTeamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTaskType;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTeamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtActivityName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtVolumes;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtEmpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtAssociateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTimeTakeninMinutes;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTimeTakeninSeconds;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTeamNameID;
        private System.Windows.Forms.LinkLabel addtask;
    }
}