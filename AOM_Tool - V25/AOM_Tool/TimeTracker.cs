using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;

namespace AOM_Tool
{
    public partial class TimeTracker : Form
    {
        //public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        //public string connectionstringtxt = "Data Source=10.137.16.47;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        //public string connectionstringtxt = ConfigurationManager.ConnectionStrings["KYC_RDC_Workflow.Properties.Settings.DRDConnectionString"].ConnectionString;
        //public string connectionstringtxt = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();

        public TimeTracker()
        {
            InitializeComponent();
        }

        private void TimeTracker_Load(object sender, EventArgs e)
        {
            searchby_date.CustomFormat = "dd-MMMM-yyyy";
            adminlevel_check_list();
            logintime();
            coretime_target();
            //if (string.IsNullOrEmpty(logintime_combobox.Text) && adminlevel_check.Text != "Admin")
            //{
            //    aom_login();
            //}
            refresh_scores_today();
            tasktype_list();
            reset_overall();
            comments.Text = string.Empty;
            radio_minutes.Checked = true;
            radio_hours.Checked = false;
            coreteam_associatewise_list();
            id.Enabled = false;
            id.Visible = false;

            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //Rectangle formrect = Screen.GetBounds(this);
            //this.Location = formrect.Location;
            //this.Size = formrect.Size;
            
        }

        

        //private void GoFullscreen(bool fullscreen)
        //{
        //    if (fullscreen)
        //    {
        //        this.WindowState = FormWindowState.Normal;
        //        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        //        this.Bounds = Screen.PrimaryScreen.Bounds;
        //    }
        //    else
        //    {
        //        this.WindowState = FormWindowState.Maximized;
        //        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
        //    }
        //}

        public void reset_button()
        {
            reset.Visible = false;
            tasktype.Enabled = true;
            teamname.Enabled = true;
            coreteam.Enabled = true;
            start.Visible = true;
            update.Visible = false;
        }

        public void save_record()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {

                cmd.Parameters.Clear();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "aom.usp_aom_insert_daily_dotnet";
                cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@ActivityNameID", activityname.SelectedValue);
                cmd.Parameters.AddWithValue("@Volumes", volumes.Value);
                cmd.Parameters.AddWithValue("@LastUpdatedBy_Associate", Environment.UserName.ToString());
                cmd.Parameters.AddWithValue("@MachineName", Environment.MachineName.ToString());
                cmd.Parameters.AddWithValue("@teamnameid", coreteam.SelectedValue);
                if (string.IsNullOrEmpty(comments.Text))
                {
                    cmd.Parameters.AddWithValue("@Comments", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Comments", comments.Text);
                }

                //If conditions
                if (string.IsNullOrEmpty(tasktype.Text))
                {
                    MessageBox.Show("Please update Task Type");
                }
                else if (string.IsNullOrEmpty(teamname.Text))
                {
                    MessageBox.Show("Please update Team Name");
                }
                else if (string.IsNullOrEmpty(activityname.Text))
                {
                    MessageBox.Show("Please update Activity Name");
                }
                else if (volumes.Value < 0)
                {
                    MessageBox.Show("Volumes cannot be negative");
                }
                else if (tasktype.Text == "Diverted" && string.IsNullOrEmpty(comments.Text))
                {
                    MessageBox.Show("Please update Comments");
                }
                else if (tasktype.Text == "DownTime" && string.IsNullOrEmpty(comments.Text))
                {
                    MessageBox.Show("Please update Comments");
                }
                else
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    string uploadmessage = cmd.Parameters["@Message"].Value.ToString();
                    MessageBox.Show("" + uploadmessage.ToString());
                    cmd.Parameters.Clear();
                    reset_overall();
                    //refresh_scores_today();
                    conn.Close();
                }
            }

            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details :" + ab.ToString());
            }
        }
       
        public void reset_overall()
        {
            searchby_date.CustomFormat = "dd-MMMM-yyyy";
            //tasktype.SelectedIndex = -1;
            tasktype.Text = "Core";
            //teamname.SelectedIndex = -1;
            activityname.SelectedIndex = -1;
            //teamname.Enabled = false;
            volumes.Value = 0;
            //if (searchby_date.Text.Trim() == string.Empty)
            //{
            //    datagridview_display_overall();
            //}
            //else
            //{
            //    datagridview_searchby_date();
            //}
            datagridview_display_overall();
            dataGridView1.Enabled = true;
            volumes.Enabled = true;
            //if (searchby_date.Text.Trim() == string.Empty)
            //{
            //    refresh_scores_today();
            //}
            //else
            //{
            //    refresh_scores_filter();
            //}
            comments.Text = string.Empty;
            button_check();
            coreteam_associatewise_list();
            label_coreteam.Visible = false;
            coreteam.Visible = false;
            teamname.Visible = true;
            label2.Visible = true;
            tasktype.Enabled = true;
            teamname.Enabled = true;
            coreteam.Enabled = true;
            reset.Visible = false;
            start.Visible = true;
            update.Visible = false;
            id.Text = string.Empty;
            datagridview_volumes_summary.Visible = false;
        }

        public void button_check()
        {
            if (string.IsNullOrEmpty(logintime_combobox.Text) && string.IsNullOrEmpty(logofftime_combobox.Text) && adminlevel_check.Text != "Admin")
            {
                start.Enabled = false;
                login.Enabled = true;
                logoff.Enabled = false;
            }
            else if (!string.IsNullOrEmpty(logintime_combobox.Text) && string.IsNullOrEmpty(logofftime_combobox.Text) && adminlevel_check.Text != "Admin")
            {
                login.Enabled = false;
                start.Enabled = true;
                logoff.Enabled = true;
            }
            else if (!string.IsNullOrEmpty(logintime_combobox.Text) && !string.IsNullOrEmpty(logofftime_combobox.Text) && adminlevel_check.Text != "Admin")
            {
                login.Enabled = false;
                start.Enabled = false;
                logoff.Enabled = false;
            }
            else if (adminlevel_check.Text == "Admin")
            {
                login.Enabled = false;
                start.Enabled = false;
                logoff.Enabled = false;
            }
        }

        public void refresh_scores_today()
        {
            //coretime_calculate_today();
            coretime_calculate_filter();
            //divertedtime_calculate_today();
            divertedtime_calculate_filter();
            //downtime_calculate_today();
            downtime_calculate_filter();
            //breaktime_calculate_today();
            breaktime_calculate_filter();
            //timeworked_calculate_today();
            timeworked_calculate_filter();
            logintime();
            logofftime_check();
            //productivity_calculate_today();
            productivity_calculate_filter();
            productivity_calculate_filter_monthly();
            //utilization_calculate_today();
            utilization_calculate_filter();
            utilization_calculate_filter_monthly();
            datagridview_display_overall();
            workoutput_calculate_filter();
            coretime_target();
        }

        public void refresh_scores_filter()
        {
            coretime_calculate_filter();
            divertedtime_calculate_filter();
            downtime_calculate_filter();
            breaktime_calculate_filter();
            timeworked_calculate_filter();
            logintime_check_searchby_date();
            logofftime_check_searchby_date();
            productivity_calculate_filter();
            productivity_calculate_filter_monthly();
            utilization_calculate_filter();
            utilization_calculate_filter_monthly();
            datagridview_display_overall();
            workoutput_calculate_filter();
            coretime_target();
        }

        //public void productivity_calculate_today()
        //{
        //    if (conn.State == ConnectionState.Open)
        //    {
        //        conn.Close();
        //    }

        //    try
        //    {
        //        //productivity_combobox.SelectedIndex = -1;
        //        SqlDataAdapter sda = new SqlDataAdapter();
        //        DataTable dt = new DataTable();
        //        conn.ConnectionString = connectionstringtxt;
        //        cmd.Connection = conn;
        //        conn.Open();
        //        cmd.Parameters.Clear();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        //cmd.CommandText = "select concat('Productivity','   ',convert(decimal(18,2),(sum(WorkOut)/(sum(Contract_Hours)-sum(Diverted)))*100),'%') as Productivity from aom.vw_productivity_dotnet  where convert(date,DateTime) = convert(date,getdate()) and AssociateName = @assciatename";
        //        cmd.CommandText = "aom.usp_productivity_calculate_today_dotnet";
        //        cmd.Parameters.AddWithValue("@associatename", Environment.UserName.ToString());
        //        sda.SelectCommand = cmd;
        //        sda.Fill(dt);
        //        productivity_combobox.DataSource = dt;
        //        productivity_combobox.DataSource = dt;
        //        productivity_combobox.DisplayMember = "Productivity";
        //        productivity_combobox.DisplayMember = "Productivity";
        //        conn.Close();
        //    }
        //    catch (Exception ab)
        //    {
        //        MessageBox.Show("Error Generated Details : " + ab.ToString());
        //    }
        //}

        public void productivity_calculate_filter()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                //productivity_combobox.SelectedIndex = -1;
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "select concat('Productivity','   ',convert(decimal(18,2),(sum(WorkOut)/(sum(Contract_Hours)-sum(Diverted)))*100),'%') as Productivity from aom.vw_productivity_dotnet where convert(date,DateTime) = convert(date,@date) and AssociateName = @assciatename";
                //cmd.CommandText = "aom.usp_productivity_calculate_filter_dotnet_test";
                cmd.CommandText = "aom.usp_productivity_calculate_filter_dotnet";
                cmd.Parameters.AddWithValue("@associatename", Environment.UserName.ToString());
                cmd.Parameters.AddWithValue("@date", searchby_date.Value.Date);
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                productivity_combobox.DataSource = dt;
                productivity_combobox.DataSource = dt;
                productivity_combobox.DisplayMember = "Productivity";
                productivity_combobox.DisplayMember = "Productivity";
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void productivity_calculate_filter_monthly()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                //productivity_combobox.SelectedIndex = -1;
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "select concat('Productivity','   ',convert(decimal(18,2),(sum(WorkOut)/(sum(Contract_Hours)-sum(Diverted)))*100),'%') as Productivity from aom.vw_productivity_dotnet where convert(date,DateTime) = convert(date,@date) and AssociateName = @assciatename";
                cmd.CommandText = "aom.usp_productivity_calculate_dotnet_rtm_monthly";
                cmd.Parameters.AddWithValue("@associatename", Environment.UserName.ToString());
                cmd.Parameters.AddWithValue("@month", searchby_date.Value.Date);
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                productivity_combobox_monthly.DataSource = dt;
                productivity_combobox_monthly.DataSource = dt;
                productivity_combobox_monthly.DisplayMember = "Productivity";
                productivity_combobox_monthly.DisplayMember = "Productivity";
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void volumes_summary_filter()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                groupBox4.Visible = false;
                //productivity_combobox.SelectedIndex = -1;
                datagridview_volumes_summary.Size = new Size(375, 300);
                datagridview_volumes_summary.Visible = true;
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                //cmd.CommandText = "select concat('Productivity','   ',convert(decimal(18,2),(sum(WorkOut)/(sum(Contract_Hours)-sum(Diverted)))*100),'%') as Productivity from aom.vw_productivity_dotnet where convert(date,DateTime) = convert(date,@date) and AssociateName = @assciatename";
                cmd.CommandText = "select ActivityName,sum(Volumes) as Volumes from aom.vw_datagridview_dotnet where AssociateName = @associatename and convert(date,LoginDate) = convert(date,@date) and TaskType = 'Core' group by ActivityName";
                cmd.Parameters.AddWithValue("@associatename", Environment.UserName.ToString());
                cmd.Parameters.AddWithValue("@date", searchby_date.Value.Date);
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                datagridview_volumes_summary.DataSource = dt;
                conn.Close();

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        //public void utilization_calculate_today()
        //{
        //    if (conn.State == ConnectionState.Open)
        //    {
        //        conn.Close();
        //    }
        //    try
        //    {
        //        //utilization_combobox.SelectedIndex = -1;
        //        SqlDataAdapter sda = new SqlDataAdapter();
        //        DataTable dt = new DataTable();
        //        conn.ConnectionString = connectionstringtxt;
        //        cmd.Connection = conn;
        //        conn.Open();
        //        cmd.Parameters.Clear();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        //cmd.CommandText = "select concat('Utilization','   ',convert(decimal(18,2),((sum(CoreTime)+sum(Diverted))/sum(Contract_Hours))*100),'%') as Utilization from aom.vw_utilization_dotnet where convert(date,DateTime) = convert(date,getdate()) and AssociateName = @assciatename";
        //        cmd.CommandText = "aom.usp_utilization_calculate_today_dotnet";
        //        cmd.Parameters.AddWithValue("@associatename", Environment.UserName.ToString());
        //        sda.SelectCommand = cmd;
        //        sda.Fill(dt);
        //        utilization_combobox.DataSource = dt;
        //        utilization_combobox.DisplayMember = "Utilization";
        //        conn.Close();
        //    }
        //    catch (Exception ab)
        //    {
        //        MessageBox.Show("Error Generated Details : " + ab.ToString());
        //    }
        //}

        public void utilization_calculate_filter()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                //utilization_combobox.SelectedIndex = -1;
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "select concat('Utilization','   ',convert(decimal(18,2),((sum(CoreTime)+sum(Diverted))/sum(Contract_Hours))*100),'%') as Utilization from aom.vw_utilization_dotnet where convert(date,DateTime) = convert(date,@date) and AssociateName = @assciatename";
                cmd.CommandText = "aom.usp_utilization_calculate_filter_dotnet";
                cmd.Parameters.AddWithValue("@associatename", Environment.UserName.ToString());
                cmd.Parameters.AddWithValue("@date", searchby_date.Value.Date);
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                utilization_combobox.DataSource = dt;
                utilization_combobox.DisplayMember = "Utilization";
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void utilization_calculate_filter_monthly()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                //utilization_combobox.SelectedIndex = -1;
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "select concat('Utilization','   ',convert(decimal(18,2),((sum(CoreTime)+sum(Diverted))/sum(Contract_Hours))*100),'%') as Utilization from aom.vw_utilization_dotnet where convert(date,DateTime) = convert(date,@date) and AssociateName = @assciatename";
                cmd.CommandText = "aom.usp_utilization_calculate_dotnet_rtm_monthly";
                cmd.Parameters.AddWithValue("@associatename", Environment.UserName.ToString());
                cmd.Parameters.AddWithValue("@month", searchby_date.Value.Date);
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                utilization_combobox_monthly.DataSource = dt;
                utilization_combobox_monthly.DisplayMember = "Utilization";
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        

        //public void breaktime_calculate_today()
        //{
        //    if (conn.State == ConnectionState.Open)
        //    {
        //        conn.Close();
        //    }
        //    try
        //    {
        //        breaktime_minutes.SelectedIndex = -1;
        //        breaktime_hours.SelectedIndex = -1;
        //        SqlDataAdapter sda = new SqlDataAdapter();
        //        DataTable dt = new DataTable();
        //        conn.ConnectionString = connectionstringtxt;
        //        cmd.Connection = conn;
        //        conn.Open();
        //        cmd.Parameters.Clear();
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = "select concat('BreakTime','   ', sum(TimeTakeninMinutes)) as BreakTimeinMinutes, concat('BreakTime','   ',sum(TimeTakeninHours)) as BreakTimeinHours from aom.vw_datagridview_dotnet where ActivityNameID = 130 and convert(date,LoginDate) = convert(date,@date) and AssociateName = @assciatename";
        //        cmd.Parameters.AddWithValue("@assciatename", Environment.UserName.ToString());
        //        cmd.Parameters.AddWithValue("@date", searchby_date.Value.Date);
        //        sda.SelectCommand = cmd;
        //        sda.Fill(dt);
        //        breaktime_minutes.DataSource = dt;
        //        breaktime_hours.DataSource = dt;
        //        breaktime_minutes.DisplayMember = "BreakTimeinMinutes";
        //        breaktime_hours.DisplayMember = "BreakTimeinHours";
        //        conn.Close();
        //    }
        //    catch (Exception ab)
        //    {
        //        MessageBox.Show("Error Generated Details : " + ab.ToString());
        //    }
        //}

        public void breaktime_calculate_filter()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                breaktime_minutes.SelectedIndex = -1;
                breaktime_hours.SelectedIndex = -1;
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select concat('BreakTime','   ', sum(TimeTakeninMinutes)) as BreakTimeinMinutes, concat('BreakTime','   ',sum(TimeTakeninHours)) as BreakTimeinHours,concat('BreakTime','   ',sum(Volumes)) as BreakTimeVolumes from aom.vw_datagridview_dotnet where ActivityNameID = 130 and convert(date,LoginDate) = convert(date,@date) and AssociateName = @assciatename";
                cmd.Parameters.AddWithValue("@date", searchby_date.Value.Date);
                cmd.Parameters.AddWithValue("@assciatename", Environment.UserName.ToString());
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                breaktime_minutes.DataSource = dt;
                breaktime_hours.DataSource = dt;
                breaktime_volumes.DataSource = dt;
                breaktime_minutes.DisplayMember = "BreakTimeinMinutes";
                breaktime_hours.DisplayMember = "BreakTimeinHours";
                breaktime_volumes.DisplayMember = "BreakTimeVolumes";
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        //public void coretime_calculate_today()
        //{
        //    if (conn.State == ConnectionState.Open)
        //    {
        //        conn.Close();
        //    }
        //    try
        //    {
        //        coretime_minutes.SelectedIndex = -1;
        //        coretime_hours.SelectedIndex = -1;
        //        SqlDataAdapter sda = new SqlDataAdapter();
        //        DataTable dt = new DataTable();
        //        conn.ConnectionString = connectionstringtxt;
        //        cmd.Connection = conn;
        //        conn.Open();
        //        cmd.Parameters.Clear();
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = "select concat('CoreTime','   ',sum(TimeTakeninMinutes)) as CoreTimeinMinutes, concat('CoreTime','   ',sum(TimeTakeninHours)) as CoreTimeinHours from aom.vw_datagridview_dotnet where TaskType = 'Core' and convert(date,LoginDate) = convert(date,@date) and AssociateName = @assciatename ";
        //        cmd.Parameters.AddWithValue("@assciatename", Environment.UserName.ToString());
        //        cmd.Parameters.AddWithValue("@date",searchby_date.Value.Date);
        //        sda.SelectCommand = cmd;
        //        sda.Fill(dt);
        //        coretime_minutes.DataSource = dt;
        //        coretime_hours.DataSource = dt;
        //        coretime_minutes.DisplayMember = "CoreTimeinMinutes";
        //        coretime_hours.DisplayMember = "CoreTimeinHours";
        //        conn.Close();

        //    }
        //    catch (Exception ab)
        //    {
        //        MessageBox.Show("Error Generated Details : " + ab.ToString());
        //    }
        //}

        public void coretime_calculate_filter()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                coretime_hours.SelectedIndex = -1;
                coretime_minutes.SelectedIndex = -1;
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select concat('CoreTime','   ',sum(TimeTakeninMinutes)) as CoreTimeinMinutes, concat('CoreTime','   ',sum(TimeTakeninHours)) as CoreTimeinHours,concat('CoreTime','   ',sum(Volumes)) as CoreTimeVolumes from aom.vw_datagridview_dotnet where TaskType = 'Core' and convert(date,LoginDate) = convert(date,@date) and AssociateName = @assciatename ";
                cmd.Parameters.AddWithValue("@date",searchby_date.Value.Date);
                cmd.Parameters.AddWithValue("@assciatename", Environment.UserName.ToString());
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                coretime_minutes.DataSource = dt;
                coretime_hours.DataSource = dt;
                coretime_volumes.DataSource = dt;
                coretime_minutes.DisplayMember = "CoreTimeinMinutes";
                coretime_hours.DisplayMember = "CoreTimeinHours";
                coretime_volumes.DisplayMember = "CoreTimeVolumes";
                conn.Close();

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void workoutput_calculate_filter()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                workoutput_combobox.SelectedIndex = -1;
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "aom.usp_workoutput_calculate_filter_dotnet";
                cmd.Parameters.AddWithValue("@associatename", Environment.UserName.ToString());
                cmd.Parameters.AddWithValue("@date",searchby_date.Value.Date);
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                workoutput_combobox.DataSource = dt;
                workoutput_combobox.DisplayMember = "WorkOutput";
                conn.Close();

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        //public void divertedtime_calculate_today()
        //{
        //    if (conn.State == ConnectionState.Open)
        //    {
        //        conn.Close();
        //    }
        //    try
        //    {
        //        divertedtime_minutes.SelectedIndex = -1;
        //        divertedtime_hours.SelectedIndex = -1;
        //        SqlDataAdapter sda = new SqlDataAdapter();
        //        DataTable dt = new DataTable();
        //        conn.ConnectionString = connectionstringtxt;
        //        cmd.Connection = conn;
        //        conn.Open();
        //        cmd.Parameters.Clear();
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = "select concat('DivertedTime','   ',sum(TimeTakeninMinutes)) as DivertedTimeinMinutes, concat('DivertedTime','   ',sum(TimeTakeninHours)) as DivertedTimeinHours from aom.vw_datagridview_dotnet where TaskType = 'Diverted' and convert(date,LoginDate) = convert(date,@date) and AssociateName = @assciatename ";
        //        cmd.Parameters.AddWithValue("@assciatename", Environment.UserName.ToString());
        //        cmd.Parameters.AddWithValue("@date",searchby_date.Value.Date);
        //        sda.SelectCommand = cmd;
        //        sda.Fill(dt);
        //        divertedtime_minutes.DataSource = dt;
        //        divertedtime_hours.DataSource = dt;
        //        divertedtime_minutes.DisplayMember = "DivertedTimeinMinutes";
        //        divertedtime_hours.DisplayMember = "DivertedTimeinHours";
        //        conn.Close();

        //    }
        //    catch (Exception ab)
        //    {
        //        MessageBox.Show("Error Generated Details : " + ab.ToString());
        //    }
        //}

        public void divertedtime_calculate_filter()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                divertedtime_minutes.SelectedIndex = -1;
                divertedtime_hours.SelectedIndex = -1;
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select concat('DivertedTime','   ',sum(TimeTakeninMinutes)) as DivertedTimeinMinutes, concat('DivertedTime','   ',sum(TimeTakeninHours)) as DivertedTimeinHours,concat('DivertedTime','   ',sum(Volumes)) as DivertedTimeVolumes from aom.vw_datagridview_dotnet where TaskType = 'Diverted' and convert(date,LoginDate) = convert(date,@date) and AssociateName = @assciatename ";
                cmd.Parameters.AddWithValue("@date",searchby_date.Value.Date);
                cmd.Parameters.AddWithValue("@assciatename", Environment.UserName.ToString());
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                divertedtime_minutes.DataSource = dt;
                divertedtime_hours.DataSource = dt;
                divertedtime_volumes.DataSource = dt;
                divertedtime_minutes.DisplayMember = "DivertedTimeinMinutes";
                divertedtime_hours.DisplayMember = "DivertedTimeinHours";
                divertedtime_volumes.DisplayMember = "DivertedTimeVolumes";
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        //public void downtime_calculate_today()
        //{
        //    if (conn.State == ConnectionState.Open)
        //    {
        //        conn.Close();
        //    }
        //    try
        //    {
        //        downtime_minutes.SelectedIndex = -1;
        //        downtime_hours.SelectedIndex = -1;
        //        SqlDataAdapter sda = new SqlDataAdapter();
        //        DataTable dt = new DataTable();
        //        conn.ConnectionString = connectionstringtxt;
        //        cmd.Connection = conn;
        //        conn.Open();
        //        cmd.Parameters.Clear();
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = "select concat('DownTime','   ',sum(TimeTakeninMinutes)) as DownTimeinMinutes, concat('DownTime','   ',sum(TimeTakeninHours)) as DownTimeinHours from aom.vw_datagridview_dotnet where TaskType = 'Downtime' and convert(date,LoginDate) = convert(date,@date) and AssociateName = @assciatename ";
        //        cmd.Parameters.AddWithValue("@assciatename", Environment.UserName.ToString());
        //        cmd.Parameters.AddWithValue("@date",searchby_date.Value.Date);
        //        sda.SelectCommand = cmd;
        //        sda.Fill(dt);
        //        downtime_minutes.DataSource = dt;
        //        downtime_hours.DataSource = dt;
        //        downtime_minutes.DisplayMember = "DownTimeinMinutes";
        //        downtime_hours.DisplayMember = "DownTimeinHours";
        //        conn.Close();
        //    }
        //    catch (Exception ab)
        //    {
        //        MessageBox.Show("Error Generated Details : " + ab.ToString());
        //    }
        //}

        public void downtime_calculate_filter()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                downtime_minutes.SelectedIndex = -1;
                downtime_hours.SelectedIndex = -1;
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select concat('DownTime','   ',sum(TimeTakeninMinutes)) as DownTimeinMinutes, concat('DownTime','   ',sum(TimeTakeninHours)) as DownTimeinHours, concat('DownTime','   ',sum(Volumes)) as DownTimeVolumes from aom.vw_datagridview_dotnet where TaskType = 'Downtime' and convert(date,LoginDate) = convert(date,@date) and AssociateName = @assciatename ";
                cmd.Parameters.AddWithValue("@date",searchby_date.Value.Date);
                cmd.Parameters.AddWithValue("@assciatename", Environment.UserName.ToString());
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                downtime_minutes.DataSource = dt;
                downtime_hours.DataSource = dt;
                downtime_volumes.DataSource = dt;
                downtime_minutes.DisplayMember = "DownTimeinMinutes";
                downtime_hours.DisplayMember = "DownTimeinHours";
                downtime_volumes.DisplayMember = "DownTimeVolumes";
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        //public void timeworked_calculate_today()
        //{
        //    if (conn.State == ConnectionState.Open)
        //    {
        //        conn.Close();
        //    }
        //    try
        //    {
        //        SqlDataAdapter sda = new SqlDataAdapter();
        //        DataTable dt = new DataTable();
        //        conn.ConnectionString = connectionstringtxt;
        //        cmd.Connection = conn;
        //        conn.Open();
        //        cmd.Parameters.Clear();
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = "select concat('TimeWorked','   ',sum(TimeTakeninMinutes)) as TimeWorkedinMinutes, concat('TimeWorked','   ',sum(TimeTakeninHours)) as TimeWorkedinHours from aom.vw_datagridview_dotnet where TaskType in ('Core','Diverted') and convert(date,LoginDate) = convert(date,@date) and AssociateName = @assciatename ";
        //        cmd.Parameters.AddWithValue("@assciatename", Environment.UserName.ToString());
        //        cmd.Parameters.AddWithValue("date",searchby_date.Value.Date);
        //        sda.SelectCommand = cmd;
        //        sda.Fill(dt);
        //        timeworked_minutes.DataSource = dt;
        //        timeworked_hours.DataSource = dt;
        //        timeworked_minutes.DisplayMember = "TimeWorkedinMinutes";
        //        timeworked_hours.DisplayMember = "TimeWorkedinHours";
        //        conn.Close();
        //    }
        //    catch (Exception ab)
        //    {
        //        MessageBox.Show("Error Generated Details : " + ab.ToString());
        //    }
        //}

        public void timeworked_calculate_filter()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select concat('TimeWorked','   ',sum(TimeTakeninMinutes)) as TimeWorkedinMinutes, concat('TimeWorked','   ',sum(TimeTakeninHours)) as TimeWorkedinHours,concat('TimeWorked','   ',sum(Volumes)) as TimeWorkedVolumes from aom.vw_datagridview_dotnet where TaskType in ('Core','Diverted') and convert(date,LoginDate) = convert(date,@date) and AssociateName = @assciatename ";
                cmd.Parameters.AddWithValue("@date",searchby_date.Value.Date);
                cmd.Parameters.AddWithValue("@assciatename", Environment.UserName.ToString());
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                timeworked_minutes.DataSource = dt;
                timeworked_hours.DataSource = dt;
                timeworked_volumes.DataSource = dt;
                timeworked_minutes.DisplayMember = "TimeWorkedinMinutes";
                timeworked_hours.DisplayMember = "TimeWorkedinHours";
                timeworked_volumes.DisplayMember = "TimeWorkedVolumes";
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }



        public void adminlevel_check_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                Emp_Details obj_empdetails = new Emp_Details();
                DataTable dtaa = new DataTable();
                obj_empdetails.emp_details_adminlevel_check(dtaa,Environment.UserName.ToString());
                adminlevel_check.DataSource = dtaa;
                adminlevel_check.DisplayMember = "AOMTool_Access";
                conn.Close();
                adminlevel_check.Visible = false;

                if (adminlevel_check.Text == "Admin")
                {
                    //rtm_verification.Enabled = true;
                    //login.Enabled = false;
                    //logoff.Enabled = false;
                    //start.Enabled = false;
                }
                else
                {
                    //rtm_verification.Enabled = false;
                    //login.Enabled = true;
                    //logoff.Enabled = true;
                    //start.Enabled = true;
                }

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void coreteam_associatewise_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                TeamDetails obj_teamdetails = new TeamDetails();
                DataTable dtaa = new DataTable();
                obj_teamdetails.coreteamname_associatewise_list (dtaa, Environment.UserName.ToString());
                coreteam.DataSource = dtaa;
                coreteam.DisplayMember = "CoreTeamName";
                coreteam.ValueMember = "TeamNameID";
                conn.Close();
                
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void tasktype_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                TasksDetails obj_taskdetails = new TasksDetails();
                DataTable dtaa = new DataTable();
                obj_taskdetails.tasktype_list (dtaa);
                tasktype.DataSource = dtaa;
                tasktype.DisplayMember = "TaskType";
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void teamname_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                TasksDetails obj_taskdetails = new TasksDetails();
                DataTable dtaa = new DataTable();
                obj_taskdetails.teamname_list (dtaa,tasktype.Text);
                teamname.DataSource = dtaa;
                teamname.DisplayMember = "TeamName";
                conn.Close();
                if (tasktype.Text == "Core")
                {
                    teamname.SelectedIndex = -1;
                    teamname.Enabled = true;
                }
                else
                {
                    teamname.Enabled = false;
                }
               
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void teamname_associatewise_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                TeamDetails obj_teamdetails = new TeamDetails();
                DataTable dtaa = new DataTable();
                obj_teamdetails.teamname_associatewise_list(dtaa, Environment.UserName.ToString());
                teamname.DataSource = dtaa;
                teamname.DisplayMember = "TeamName";
                conn.Close();
                if (tasktype.Text == "Core")
                {
                    //teamname.SelectedIndex = -1;
                    teamname.Enabled = true;
                }
                else
                {
                    teamname.Enabled = false;
                }

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void activityname_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                TasksDetails obj_taskdetails = new TasksDetails();
                DataTable dtaa = new DataTable();
                DataTable dtaa1 = new DataTable();

                obj_taskdetails.activityname_list_associate(dtaa,tasktype.Text,teamname.Text);
                activityname.DataSource = dtaa;
                activityname.DisplayMember = "ActivityName";
                activityname.ValueMember = "ID";
                conn.Close();
                if (tasktype.Text != "Break")
                {
                    activityname.SelectedIndex = -1;
                }

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void activityname_associatewise_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                TeamDetails obj_teamdetails = new TeamDetails();
                DataTable dtaa = new DataTable();
                obj_teamdetails.activityname_associatewise_timetracker_list(dtaa, Environment.UserName.ToString(), teamname.Text);
                activityname.DataSource = dtaa;
                activityname.DisplayMember = "ActivityName";
                activityname.ValueMember = "ActivityNameID";
                conn.Close();
                activityname.SelectedIndex = -1;

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        private void tasktype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (adminlevel_check.Text == "Admin")
            {
                teamname_list();
            }
            else if (adminlevel_check.Text != "Admin" && tasktype.Text == "Core")
            {
                teamname_associatewise_list();
                label_coreteam.Visible = false;
                coreteam.Visible = false;
                label2.Visible = true;
                teamname.Visible = true;
            }
            else
            {
                teamname_list();
                label_coreteam.Visible = true;
                coreteam.Visible = true;
                label2.Visible = false;
                teamname.Visible = false;

            }

            if (tasktype.Text == "Core")
            {
                volumes.Enabled = true;
            }
            else
            {
                volumes.Enabled = false;
            }
            coreteam_associatewise_list();

            
           
        }

        private void teamname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (adminlevel_check.Text == "Admin")
            {
                activityname_list();
            }
            else if (adminlevel_check.Text != "Admin" && tasktype.Text == "Core")
            {
                activityname_associatewise_list();
                coreteam.Text = teamname.Text;
            }
            else
            {
                activityname_list();
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            save_record();
        }

        public void datagridview_searchby_date()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select ID,ActivityNameID,TaskType, TeamName, ActivityName, Volumes, AssociateName, DateTime, DateTime_Final,TimeTakeninMinutes,Comments,CoreTeamName from aom.vw_datagridview_dotnet where AssociateName = @intid and convert(date,LoginDate) = @date order by 8 desc, 9 desc";
                cmd.Parameters.AddWithValue("@intid", Environment.UserName.ToString());
                cmd.Parameters.AddWithValue("@date", searchby_date.Value.Date);

                sda.SelectCommand = cmd;
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }

        }

        public void datagridview_display_overall()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.Text;
                //cmd.CommandText = "select ID,TaskType, TeamName, ActivityName, Volumes, AssociateName, DateTime, DateTime_Final,TimeTakeninMinutes,Comments from aom.vw_datagridview_dotnet where AssociateName = @intid and convert(date,LoginDate) = @date order by DateTime asc";
                //cmd.CommandText = "select ID,TaskType, TeamName, ActivityName, Volumes, AssociateName, DateTime, DateTime_Final,TimeTakeninMinutes,Comments from aom.vw_datagridview_dotnet where AssociateName = @intid and convert(date,LoginDate) = (select convert(date,max(LoginDate)) as LoginDate from aom.vw_daily_dotnet where LastUpdatedBy_Associate = @intid) order by DateTime asc";
                cmd.CommandText = "select ID,ActivityNameID,TaskType, TeamName, ActivityName, Volumes, AssociateName, DateTime, DateTime_Final,TimeTakeninMinutes,Comments,CoreTeamName from aom.vw_datagridview_dotnet where AssociateName = @intid and convert(date,LoginDate) = convert(date,@date) order by 8 desc, 9 desc";
                cmd.Parameters.AddWithValue("@intid",Environment.UserName.ToString());
                cmd.Parameters.AddWithValue("@date",searchby_date.Value.Date);
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }

        }

        public void logintime()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select convert(time,min(DateTime)) as DateTime from aom.vw_datagridview_dotnet where AssociateName = @intid and convert(date,LoginDate) = convert(date,@date) /*and IsLogin = 1*/ and ActivityNameID = 132";
                cmd.Parameters.AddWithValue("@intid", Environment.UserName.ToString());
                cmd.Parameters.AddWithValue("@date", searchby_date.Value.Date);

                sda.SelectCommand = cmd;
                sda.Fill(dt);
                logintime_combobox.DataSource = dt;
                logintime_combobox.DisplayMember = "DateTime";
                //logintime_textbox = Convert.ToChar(logintime_combobox.Text);
                conn.Close();
                logintime_combobox.Enabled = false;
                button_check();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }

        }

        public void coretime_target()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                CoreTime_Target obj_coretime_target = new CoreTime_Target();
                DataTable dtaa = new DataTable();

                obj_coretime_target.coretime_roster(dtaa, Environment.UserName.ToString(), searchby_date.Value.Date);
                coretime_target_combobox.DataSource = dtaa;
                coretime_target_combobox.DisplayMember = "CoreTime_Target";
                conn.Close();
                coretime_target_combobox.Enabled = false;
                
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }

        }

        public void logintime_check_searchby_date()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                logintime_combobox.SelectedIndex = -1;
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select convert(time,min(DateTime)) as DateTime from aom.vw_datagridview_dotnet where AssociateName = @intid and convert(date,DateTime) = @date and ActivityNameID = 132";
                cmd.Parameters.AddWithValue("@intid", Environment.UserName.ToString());
                cmd.Parameters.AddWithValue("@date", searchby_date.Value.Date);

                sda.SelectCommand = cmd;
                sda.Fill(dt);
                logintime_combobox.DataSource = dt;
                logintime_combobox.DisplayMember = "DateTime";
                //logintime_textbox = Convert.ToChar(logintime_combobox.Text);
                conn.Close();
                logintime_combobox.Enabled = false;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }

        }

        public void logofftime_check()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                logofftime_combobox.SelectedIndex = -1;
                logofftime_combobox.Enabled = false;
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.Text;
                //cmd.CommandText = "select convert(time,DateTime) as DateTime from aom.vw_datagridview_dotnet where AssociateName = @intid and convert(date,LoginDate) = convert(date,getdate()) and ActivityNameID = 131";
                cmd.CommandText = "select convert(time,DateTime) as DateTime from aom.vw_datagridview_dotnet where AssociateName = @intid and convert(date,LoginDate) = convert(date,@date) and ActivityNameID = 131";
                cmd.Parameters.AddWithValue("@date",searchby_date.Value.Date);
                cmd.Parameters.AddWithValue("@intid", Environment.UserName.ToString());
                
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                logofftime_combobox.DataSource = dt;
                logofftime_combobox.DisplayMember = "DateTime";
                conn.Close();

                if (!string.IsNullOrEmpty(logofftime_combobox.Text))
                {
                    logoff.Enabled = false;
                    //start.Enabled = false;
                }
                else
                {
                    logoff.Enabled = true;
                    //start.Enabled = true;
                }
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }

        }

        public void logofftime_check_searchby_date()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                logofftime_combobox.SelectedIndex = -1;
                logofftime_combobox.Enabled = false;
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select convert(time,DateTime) as DateTime from aom.vw_datagridview_dotnet where AssociateName = @intid and convert(date,LoginDate) = @date and ActivityNameID = 131";
                cmd.Parameters.AddWithValue("@intid", Environment.UserName.ToString());
                cmd.Parameters.AddWithValue("@date", searchby_date.Value.Date);

                sda.SelectCommand = cmd;
                sda.Fill(dt);
                logofftime_combobox.DataSource = dt;
                logofftime_combobox.DisplayMember = "DateTime";
                conn.Close();
               
                if (string.IsNullOrEmpty(logofftime_combobox.Text))
                {
                    logoff.Enabled = true;
                    start.Enabled = true;
                }
                else
                {
                    logoff.Enabled = false;
                    start.Enabled = false;
                }
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }

        }

        

        private void logoff_Click(object sender, EventArgs e)
        {
            string messsage = "Do you want to Log Off?";
            string title = "Message Box";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(messsage, title, buttons);
            if (result == DialogResult.Yes)
            {

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                try
                {
                    cmd.Parameters.Clear();
                    conn.ConnectionString = connectionstringtxt;
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "aom.usp_aom_logoff_dotnet";
                    cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                    cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@LastUpdatedBy_Associate", Environment.UserName.ToString());
                    cmd.Parameters.AddWithValue("@MachineName", Environment.MachineName.ToString());
                    cmd.Parameters.AddWithValue("@teamnameid",coreteam.SelectedValue);
                    if (string.IsNullOrEmpty(comments.Text))
                    {
                        cmd.Parameters.AddWithValue("@Comments", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Comments", comments.Text);
                    }

                    //if conditions
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    string uploadmessage = cmd.Parameters["@Message"].Value.ToString();
                    MessageBox.Show("" + uploadmessage.ToString());
                    cmd.Parameters.Clear();
                    logofftime_check();
                    reset_overall();
                    refresh_scores_today();
                    conn.Close();
                    //if (string.IsNullOrEmpty(logintime_combobox.Text))
                    //{
                    //    logoff.Enabled = true;
                    //    login.Enabled = false;
                    //    start.Enabled = false;
                    //}
                    //else
                    //{
                    //    logoff.Enabled = false;
                    //    login.Enabled = false;
                    //    start.Enabled = false;
                    //}

                }
                catch (Exception ab)
                {
                    MessageBox.Show("Error Generated Details :" + ab.ToString());
                }
            }
            else
            {
                tasktype.Focus();
            }
        }

        private void searchby_date_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            //{
            //    searchby_date.CustomFormat = " ";
            //    refresh_scores_today();
            //    datagridview_display_overall();
            //    dataGridView1.Enabled = true;
            //}
        }

        private void searchby_date_ValueChanged(object sender, EventArgs e)
        {
           
            searchby_date.CustomFormat = "dd-MMMM-yyyy";
            if (searchby_date.Text.Trim() != string.Empty)
            {
                datagridview_searchby_date();
                if (searchby_date.Value.Date != DateTime.Now.Date)
                {
                    dataGridView1.Enabled = false;
                }
                else
                {
                    dataGridView1.Enabled = true;
                }
                refresh_scores_filter();
            }
            else
            {
                datagridview_display_overall();
            }
            button_check();
        }

        public void aom_login()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                cmd.Parameters.Clear();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "aom.usp_aom_login_dotnet";
                cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@LastUpdatedBy_Associate", Environment.UserName.ToString());
                cmd.Parameters.AddWithValue("@MachineName", Environment.MachineName.ToString());
                cmd.Parameters.AddWithValue("@teamnameid",coreteam.SelectedValue);

                conn.Open();
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                string uploadmessage = cmd.Parameters["@Message"].Value.ToString();
                MessageBox.Show("" + uploadmessage.ToString());
                cmd.Parameters.Clear();
                reset_overall();
                conn.Close();

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details :" + ab.ToString());
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            if (dataGridView1.CurrentRow != null)
            {
                try
                {
                    DataGridViewRow dgvrow = dataGridView1.CurrentRow;
                    conn.ConnectionString = connectionstringtxt;
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "aom.usp_aom_update_volumes_daily_dotnet";
                    cmd.Parameters.AddWithValue("@ID", dgvrow.Cells["txtID"].Value);
                    cmd.Parameters.AddWithValue("@Volumes", dgvrow.Cells["txtVolumes"].Value);
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtComments"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@Comments", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Comments", dgvrow.Cells["txtComments"].Value.ToString());
                    }
                    cmd.Parameters.AddWithValue("@LastUpdatedBy",Environment.UserName.ToString());
                    cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 500);
                    cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    string leavemessage2 = cmd.Parameters["@Message"].Value.ToString();
                    if (!string.IsNullOrEmpty(leavemessage2))
                    {
                        MessageBox.Show("" + leavemessage2.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Records Updated Successfully");
                        //AutoClosingMessageBox.Show("Records Updated Successfully", "", 1000);
                    }
                    datagridview_display_overall();
                    //refresh_scores_today();
                }

                catch (Exception ab)
                {
                    MessageBox.Show("Error Generated Details :" + ab.ToString());
                    datagridview_display_overall();
                   
                }
            }
        }

        private void radio_minutes_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_minutes.Checked == true)
            {
                coretime_minutes.Visible = true;
                coretime_hours.Visible = false;
                coretime_volumes.Visible = false;
                divertedtime_minutes.Visible = true;
                divertedtime_hours.Visible = false;
                divertedtime_volumes.Visible = false;
                downtime_minutes.Visible = true;
                downtime_hours.Visible = false;
                downtime_volumes.Visible = false;
                breaktime_minutes.Visible = true;
                breaktime_hours.Visible = false;
                breaktime_volumes.Visible = false;
                timeworked_minutes.Visible = true;
                timeworked_hours.Visible = false;
                timeworked_volumes.Visible = false;
                coretime_calculate_filter();
                divertedtime_calculate_filter();
                downtime_calculate_filter();
                breaktime_calculate_filter();
                timeworked_calculate_filter();
                //if (searchby_date.Text.Trim() == string.Empty)
                //{
                //    coretime_calculate_today();
                //    divertedtime_calculate_today();
                //    downtime_calculate_today();
                //    breaktime_calculate_today();
                //    timeworked_calculate_today();
                //}
                //else
                //{
                //    coretime_calculate_filter();
                //    divertedtime_calculate_filter();
                //    downtime_calculate_filter();
                //    breaktime_calculate_filter();
                //    timeworked_calculate_filter();
                //}
            }
        }

        private void radio_seconds_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_hours.Checked == true)
            {
                coretime_minutes.Visible = false;
                coretime_hours.Visible = true;
                coretime_volumes.Visible = false;
                divertedtime_minutes.Visible = false;
                divertedtime_hours.Visible = true;
                divertedtime_volumes.Visible = false;
                downtime_minutes.Visible = false;
                downtime_hours.Visible = true;
                downtime_volumes.Visible = false;
                breaktime_minutes.Visible = false;
                breaktime_hours.Visible = true;
                breaktime_volumes.Visible = false;
                timeworked_minutes.Visible = false;
                timeworked_hours.Visible = true;
                timeworked_volumes.Visible = false;
                coretime_calculate_filter();
                divertedtime_calculate_filter();
                downtime_calculate_filter();
                breaktime_calculate_filter();
                timeworked_calculate_filter();
                //if (searchby_date.Text.Trim() == string.Empty)
                //{
                //    coretime_calculate_today();
                //    divertedtime_calculate_today();
                //    downtime_calculate_today();
                //    breaktime_calculate_today();
                //    timeworked_calculate_today();
                //}
                //else
                //{
                //    coretime_calculate_filter();
                //    divertedtime_calculate_filter();
                //    downtime_calculate_filter();
                //    breaktime_calculate_filter();
                //    timeworked_calculate_filter();
                //}
            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            if (searchby_date.Text.Trim() == string.Empty)
            {
                refresh_scores_today();
            }
            else
            {
                refresh_scores_filter();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                string messsage = "Do you want to update the record?";
                string title = "Message Box";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(messsage, title, buttons);
                if (result == DialogResult.Yes)
                {
                    if (e.RowIndex >= 0)
                    {
                        
                        DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                        id.Text = row.Cells["txtID"].Value.ToString();
                        tasktype.Text = row.Cells["txtTaskType"].Value.ToString();
                        teamname.Text = row.Cells["txtCoreTeamName"].Value.ToString();
                        coreteam.Text = row.Cells["txtCoreTeamName"].Value.ToString();
                        activityname.Text = row.Cells["txtActivityName"].Value.ToString();
                        if (tasktype.Text == "Core")
                        {
                            tasktype.Enabled = false;
                            teamname.Enabled = false;
                            coreteam.Enabled = false;
                            reset.Visible = true;
                            start.Visible = false;
                            update.Visible = true;
                        }
                        else if(tasktype.Text == "Diverted")
                        {
                            tasktype.Enabled = false;
                            teamname.Enabled = false;
                            coreteam.Enabled = false;
                            reset.Visible = true;
                            start.Visible = false;
                            update.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show("You can edit only core activities");
                            reset_button();
                        }
                    }
                }
                else
                {
                    tasktype.Enabled = true;
                    teamname.Enabled = true;
                    coreteam.Enabled = true;
                    reset.Visible = false;
                    update.Visible = false;
                    start.Visible = true;
                }
            }
        }

        private void homepage_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            HomePage obj_homepage = new HomePage();
            obj_homepage.Show();
        }

        private void activityname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void login_Click(object sender, EventArgs e)
        {
            string messsage = "Do you want to Log In?";
            string title = "Message Box";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(messsage, title, buttons);
            if (result == DialogResult.Yes)
            {
                aom_login();
                logintime();
            }
            //if (string.IsNullOrEmpty(logofftime_combobox.Text))
            //{
            //    login.Enabled = true;
            //    start.Enabled = false;
            //}
            //else
            //{
            //    login.Enabled = false;
            //    start.Enabled = true;
            //}
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radio_volumes_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_volumes.Checked == true)
            {
                coretime_minutes.Visible = false;
                coretime_hours.Visible = false;
                coretime_volumes.Visible = true;
                divertedtime_minutes.Visible = false;
                divertedtime_hours.Visible = false;
                divertedtime_volumes.Visible = true;
                downtime_minutes.Visible = false;
                downtime_hours.Visible = false;
                downtime_volumes.Visible = true;
                breaktime_minutes.Visible = false;
                breaktime_hours.Visible = false;
                breaktime_volumes.Visible = true;
                timeworked_minutes.Visible = false;
                timeworked_hours.Visible = false;
                timeworked_volumes.Visible = true;
                coretime_calculate_filter();
                divertedtime_calculate_filter();
                downtime_calculate_filter();
                breaktime_calculate_filter();
                timeworked_calculate_filter();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow myrow in dataGridView1.Rows)
            {
                if (myrow.Cells["txtTaskType"].Value.ToString() == "Break")
                {
                    myrow.DefaultCellStyle.BackColor = Color.IndianRed;
                    myrow.DefaultCellStyle.ForeColor = Color.Black;
                }
                else if (myrow.Cells["txtTaskType"].Value.ToString() == "Core")
                {
                    myrow.DefaultCellStyle.BackColor = Color.LimeGreen;
                    myrow.DefaultCellStyle.ForeColor = Color.Black;
                }
                else if (myrow.Cells["txtTaskType"].Value.ToString() == "Diverted")
                {
                    myrow.DefaultCellStyle.BackColor = Color.Orange;
                    myrow.DefaultCellStyle.ForeColor = Color.Black;
                }
                else if (myrow.Cells["txtTaskType"].Value.ToString() == "Downtime")
                {
                    myrow.DefaultCellStyle.BackColor = Color.MediumPurple;
                    myrow.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void coreteam_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void reset_Click(object sender, EventArgs e)
        {
            reset_button();
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {

                cmd.Parameters.Clear();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "aom.usp_aom_update_coreactivity_dotnet";
                cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@ActivityNameID", activityname.SelectedValue);
                cmd.Parameters.AddWithValue("@LastUpdatedBy_Associate", Environment.UserName.ToString());
                cmd.Parameters.AddWithValue("@MachineName", Environment.MachineName.ToString());
                cmd.Parameters.AddWithValue("@id", id.Text);
                
                
                conn.Open();
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                string uploadmessage = cmd.Parameters["@Message"].Value.ToString();
                MessageBox.Show("" + uploadmessage.ToString());
                cmd.Parameters.Clear();
                reset_overall();
                //refresh_scores_today();
                conn.Close();
            }

            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details :" + ab.ToString());
            }
        }

        private void volumes_summary_MouseHover(object sender, EventArgs e)
        {
            volumes_summary_filter();
        }

        private void volumes_summary_MouseLeave(object sender, EventArgs e)
        {
            datagridview_volumes_summary.Visible = false;
            groupBox4.Visible = true;
        }

        private void volumes_summary_Click(object sender, EventArgs e)
        {
            volumes_summary_filter();
        }

        private void TimeTracker_Enter(object sender, EventArgs e)
        {

            //if (!string.IsNullOrEmpty(logintime_combobox.Text) && string.IsNullOrEmpty(logofftime_combobox.Text) && adminlevel_check.Text != "Admin")
            //{
            //    save_record();
            //}
            
        }

        private void TimeTracker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(logintime_combobox.Text) && string.IsNullOrEmpty(logofftime_combobox.Text) && adminlevel_check.Text != "Admin" && update.Visible == false)
                {
                    save_record();
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://A20-CB-DBSE01P/Reports/report/DRD%20MI%20Mumbai/DRD%20Reports/rpt_SSRS_AOM_AHT_Details_DotNet");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
        }

       
    }
}
