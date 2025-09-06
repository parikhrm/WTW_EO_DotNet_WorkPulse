namespace AOM_Tool
{
    partial class AddRecords_RTMVerification
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.empname = new System.Windows.Forms.ComboBox();
            this.teamname = new System.Windows.Forms.ComboBox();
            this.tasktype = new System.Windows.Forms.ComboBox();
            this.activityname = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.starttime = new System.Windows.Forms.DateTimePicker();
            this.endtime = new System.Windows.Forms.DateTimePicker();
            this.volumes = new System.Windows.Forms.TextBox();
            this.add = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Emp Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Team Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Task Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 254);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Activity Name";
            // 
            // empname
            // 
            this.empname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.empname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.empname.FormattingEnabled = true;
            this.empname.Location = new System.Drawing.Point(145, 71);
            this.empname.Name = "empname";
            this.empname.Size = new System.Drawing.Size(271, 28);
            this.empname.TabIndex = 1;
            this.empname.SelectedIndexChanged += new System.EventHandler(this.empname_SelectedIndexChanged);
            // 
            // teamname
            // 
            this.teamname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.teamname.FormattingEnabled = true;
            this.teamname.Location = new System.Drawing.Point(145, 122);
            this.teamname.Name = "teamname";
            this.teamname.Size = new System.Drawing.Size(362, 28);
            this.teamname.TabIndex = 3;
            this.teamname.SelectedIndexChanged += new System.EventHandler(this.teamname_SelectedIndexChanged);
            // 
            // tasktype
            // 
            this.tasktype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tasktype.FormattingEnabled = true;
            this.tasktype.Location = new System.Drawing.Point(145, 181);
            this.tasktype.Name = "tasktype";
            this.tasktype.Size = new System.Drawing.Size(197, 28);
            this.tasktype.TabIndex = 5;
            this.tasktype.SelectedIndexChanged += new System.EventHandler(this.tasktype_SelectedIndexChanged);
            // 
            // activityname
            // 
            this.activityname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.activityname.FormattingEnabled = true;
            this.activityname.Location = new System.Drawing.Point(145, 254);
            this.activityname.Name = "activityname";
            this.activityname.Size = new System.Drawing.Size(362, 28);
            this.activityname.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(553, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Start Time";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(553, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "End Time";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(553, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Volumes";
            // 
            // starttime
            // 
            this.starttime.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.starttime.CustomFormat = " ";
            this.starttime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.starttime.Location = new System.Drawing.Point(706, 71);
            this.starttime.Name = "starttime";
            this.starttime.ShowUpDown = true;
            this.starttime.Size = new System.Drawing.Size(200, 26);
            this.starttime.TabIndex = 9;
            this.starttime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.starttime_KeyDown);
            this.starttime.MouseDown += new System.Windows.Forms.MouseEventHandler(this.starttime_MouseDown);
            // 
            // endtime
            // 
            this.endtime.CustomFormat = " ";
            this.endtime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endtime.Location = new System.Drawing.Point(706, 122);
            this.endtime.Name = "endtime";
            this.endtime.ShowUpDown = true;
            this.endtime.Size = new System.Drawing.Size(200, 26);
            this.endtime.TabIndex = 11;
            this.endtime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.endtime_KeyDown);
            this.endtime.MouseDown += new System.Windows.Forms.MouseEventHandler(this.endtime_MouseDown);
            // 
            // volumes
            // 
            this.volumes.Location = new System.Drawing.Point(706, 187);
            this.volumes.Name = "volumes";
            this.volumes.Size = new System.Drawing.Size(118, 26);
            this.volumes.TabIndex = 13;
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(266, 332);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(88, 40);
            this.add.TabIndex = 16;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(380, 332);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(88, 40);
            this.reset.TabIndex = 17;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(553, 252);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Login Date";
            // 
            // date
            // 
            this.date.CustomFormat = " ";
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date.Location = new System.Drawing.Point(706, 252);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(200, 26);
            this.date.TabIndex = 15;
            this.date.ValueChanged += new System.EventHandler(this.date_ValueChanged);
            this.date.KeyDown += new System.Windows.Forms.KeyEventHandler(this.date_KeyDown);
            // 
            // AddRecords_RTMVerification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1612, 402);
            this.Controls.Add(this.date);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.add);
            this.Controls.Add(this.volumes);
            this.Controls.Add(this.endtime);
            this.Controls.Add(this.starttime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.activityname);
            this.Controls.Add(this.tasktype);
            this.Controls.Add(this.teamname);
            this.Controls.Add(this.empname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddRecords_RTMVerification";
            this.Text = "AddRecords_RTMVerification";
            this.Load += new System.EventHandler(this.AddRecords_RTMVerification_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox empname;
        private System.Windows.Forms.ComboBox teamname;
        private System.Windows.Forms.ComboBox tasktype;
        private System.Windows.Forms.ComboBox activityname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker starttime;
        private System.Windows.Forms.DateTimePicker endtime;
        private System.Windows.Forms.TextBox volumes;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker date;
    }
}