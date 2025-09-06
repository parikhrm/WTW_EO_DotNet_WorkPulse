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
    public partial class RTM_Verification : Form
    {
        //public string connectionstringtxt = "Data Source=MUM1-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        //public string connectionstringtxt = ConfigurationManager.ConnectionStrings["KYC_RDC_Workflow.Properties.Settings.DRDConnectionString"].ConnectionString;
        //public string connectionstringtxt = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();

        public RTM_Verification()
        {
            InitializeComponent();
        }

        private void Verification_Load(object sender, EventArgs e)
        {
            reportingmanager_list();
            radio_minutes.Checked = true;
            radio_volumes.Checked = false;
            //searchby_date.Text = DateTime.Now.Date;
            searchby_date.CustomFormat = "dd-MMMM-yyyy";
            reset_overall();
            datagridview_check.Visible = false;
            searchby_associatename.Enabled = false;
            teamname.Visible = false;
            coreteamname.Enabled = false;
        }

        public void reset_overall()
        {
            startdate.CustomFormat = " ";
            starttime.CustomFormat = " ";
            enddate.CustomFormat = " ";
            endtime.CustomFormat = " ";
            id.Enabled = false;
            id.Text = string.Empty;
            datagridview_display_overall();
            refresh_scores_filter();
            empname.Enabled = false;
            tasktype.SelectedIndex = -1;
            activityname.SelectedIndex = -1;
            empname.Text = string.Empty;
            coreteamname.SelectedIndex = -1;
            teamname.SelectedIndex = -1;
        }

        public void refresh_scores_filter()
        {
           coretime_calculate_filter();
           divertedtime_calculate_filter();
           downtime_calculate_filter();
           breaktime_calculate_filter();
           productivity_calculate_filter();
           utilization_calculate_filter();
        }

        private void homepage_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            HomePage obj_homepage = new HomePage();
            obj_homepage.Show();
        }

        private void searchby_date_ValueChanged(object sender, EventArgs e)
        {
            searchby_date.CustomFormat = "dd-MMMM-yyyy";
            datagridview_display_overall();
            refresh_scores_filter();
            if (searchby_date.Text.Trim() != string.Empty && !string.IsNullOrEmpty(searchby_associatename.Text))
            {
                utilization_calculate_filter();
                productivity_calculate_filter();
                
            }
        }

        private void searchby_date_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            //{
            //    searchby_date.CustomFormat = "dd-MMMM-yyyy";
            //}
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
                if (string.IsNullOrEmpty(searchby_associatename.Text) && searchby_date.Text.Trim() != string.Empty)
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select top 100 a.ActivityNameID,a.ID,a.TaskType,a.TeamName,a.ActivityName,a.Volumes,a.EmpName,a.AssociateName,convert(date,a.DateTime) as StartDate,convert(time,a.DateTime) as StartTime,convert(date,a.DateTime_Final) as EndDate,convert(time,a.DateTime_Final) as EndTime,TimeTakeninMinutes,TimeTakeninSeconds,CoreTeamName,TeamNameID from aom.vw_datagridview_dotnet a /*left join dbo.tbl_emp_details b with(nolock) on a.AssociateName = substring(b.INTID,5,len(b.INTID))*/ where convert(date,a.LoginDate) = convert(date,@date) order by 9 desc, 10 desc";
                    cmd.Parameters.AddWithValue("@date", searchby_date.Value.Date);
                }
                else
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "aom.usp_datagridview_verification_dotnet";
                    if (searchby_date.Text.Trim() == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@date", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@date", searchby_date.Value.Date);
                    }
                    if (string.IsNullOrEmpty(searchby_associatename.Text))
                    {
                        cmd.Parameters.AddWithValue("@associatename", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@associatename", searchby_associatename.Text);
                    }
                }

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

        public void productivity_calculate_filter()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                productivity_combobox.SelectedIndex = -1;
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "select concat('Productivity','   ',convert(decimal(18,2),(sum(WorkOut)/(sum(Contract_Hours)-sum(Diverted)))*100),'%') as Productivity from aom.vw_productivity_dotnet where convert(date,DateTime) = convert(date,@date) and AssociateName = @assciatename";
                cmd.CommandText = "aom.usp_productivity_rtm_calculate_filter_dotnet_V1";
                cmd.Parameters.AddWithValue("@associatename", searchby_associatename.Text);
                cmd.Parameters.AddWithValue("@date", searchby_date.Value.Date);
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                productivity_combobox.DataSource = dt;
                productivity_combobox.DisplayMember = "Productivity";
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void utilization_calculate_filter()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                utilization_combobox.SelectedIndex = -1;
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "select concat('Utilization','   ',convert(decimal(18,2),((sum(CoreTime)+sum(Diverted))/sum(Contract_Hours))*100),'%') as Utilization from aom.vw_utilization_dotnet where convert(date,DateTime) = convert(date,@date) and AssociateName = @assciatename";
                cmd.CommandText = "aom.usp_utilization_rtm_calculate_filter_dotnet";
                cmd.Parameters.AddWithValue("@associatename", searchby_associatename.Text);
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

        private void searchby_associatename_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (searchby_associatename.Enabled == true && !string.IsNullOrEmpty(searchby_associatename.Text))
            {
                datagridview_display_overall();
                refresh_scores_filter();
                //if (searchby_date.Text.Trim() != string.Empty && !string.IsNullOrEmpty(searchby_associatename.Text))
                //{
                //    utilization_calculate_filter();
                //    productivity_calculate_filter();

                //}
            }
        }

        private void startdate_ValueChanged(object sender, EventArgs e)
        {
            startdate.CustomFormat = "dd-MMMM-yyyy";
        }

        private void startdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                startdate.CustomFormat = " ";
            }
        }

        private void starttime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                starttime.CustomFormat = " ";
            }
        }

        private void starttime_MouseDown(object sender, MouseEventArgs e)
        {
            starttime.CustomFormat = "HH:mm:ss";
            //starttime.Text = DateTime.Now.ToLongTimeString();
        }

        private void enddate_ValueChanged(object sender, EventArgs e)
        {
            enddate.CustomFormat = "dd-MMMM-yyyy";
        }

        private void enddate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                enddate.CustomFormat = " ";
            }
        }

        private void endtime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                endtime.CustomFormat = " ";
            }
        }

        private void endtime_MouseDown(object sender, MouseEventArgs e)
        {
            endtime.CustomFormat = "HH:mm:ss";
            //endtime.Text = DateTime.Now.ToLongTimeString();
        }

        public void reportingmanager_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                Emp_Details obj_empdetails = new Emp_Details();
                DataTable dtaa = new DataTable();
                obj_empdetails.reportingmanager_details_overall(dtaa);
                searchby_reportingmanagername.DataSource = dtaa;
                searchby_reportingmanagername.DisplayMember = "EmpName";
                conn.Close();
                searchby_reportingmanagername.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void empname_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                
                searchby_associatename.Enabled = true;
                Emp_Details obj_empdetails = new Emp_Details();
                DataTable dtaa = new DataTable();
                obj_empdetails.emp_details_basedonreportingmanager(dtaa,searchby_reportingmanagername.Text);
                searchby_associatename.DataSource = dtaa;
                searchby_associatename.DisplayMember = "EmpName";
                conn.Close();
                searchby_associatename.SelectedIndex = -1;
                
                
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string messsage = "Do you want to update the record?";
            string title = "Message Box";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(messsage, title, buttons);
            if (result == DialogResult.Yes)
            {
                if (e.RowIndex >= 0)
                {
                    tasktype_list();
                    
                    datagridview_check.Enabled = true;
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    id.Text = row.Cells["txtID"].Value.ToString();
                    empname.Text = row.Cells["txtEmpName"].Value.ToString();
                    coreteamname_associatewise_list();
                    startdate.Text = row.Cells["txtStartDate"].Value.ToString();
                    startdate.CustomFormat = "dd-MMMM-yyyy";
                    starttime.Text = row.Cells["txtStartTime"].Value.ToString();
                    starttime.CustomFormat = "HH:mm:ss";
                    if (string.IsNullOrEmpty(row.Cells["txtEndDate"].Value.ToString()))
                    {
                        enddate.CustomFormat = " ";
                        endtime.CustomFormat = " ";
                    }
                    else
                    {
                        enddate.Text = row.Cells["txtEndDate"].Value.ToString();
                        enddate.CustomFormat = "dd-MMMM-yyyy";
                        endtime.Text = row.Cells["txtEndTime"].Value.ToString();
                        endtime.CustomFormat = "HH:mm:ss";
                    }
                    tasktype.Text = row.Cells["txtTaskType"].Value.ToString();
                    if (tasktype.Text == "Core")
                    {
                        teamname_associatewise_list();
                    }
                    else
                    {
                        teamname_list();
                    }
                    teamname.Text = row.Cells["txtTeamName"].Value.ToString();
                    coreteamname.Text = row.Cells["txtCoreTeamName"].Value.ToString();
                    teamnameid.Text = row.Cells["txtTeamNameID"].Value.ToString();

                    if (tasktype.Text == "Core")
                    {
                        activityname_associatewise_list();
                    }
                    else
                    {
                        activityname_list();
                    }
                    activityname.Text = row.Cells["txtActivityName"].Value.ToString();
                    volumes.Value = Convert.ToInt32(row.Cells["txtVolumes"].Value);
                }
            }
            else
            {
                id.Focus();
            }
        }

        

        
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
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
                cmd.CommandText = "aom.usp_verification_rtm_update_dotnet";
                cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@searchbydate",searchby_date.Value.Date);
                cmd.Parameters.AddWithValue("@id", id.Text);
                cmd.Parameters.AddWithValue("@startdate",startdate.Value.Date);
                cmd.Parameters.AddWithValue("@starttime", starttime.Value.ToLongTimeString());
                cmd.Parameters.AddWithValue("@enddate",enddate.Value.Date);
                cmd.Parameters.AddWithValue("@endtime",endtime.Value.ToLongTimeString());
                cmd.Parameters.AddWithValue("@lastupdatedby", Environment.UserName.ToString());
                cmd.Parameters.AddWithValue("@activitynameid",activityname.SelectedValue);
                cmd.Parameters.AddWithValue("@volumes",volumes.Value);
                cmd.Parameters.AddWithValue("@empname", empname.Text);

                if (string.IsNullOrEmpty(id.Text))
                {
                    MessageBox.Show("Please select a record");
                }
                else if (startdate.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update StartDate");
                }
                else if (starttime.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update StartTime");
                }
                else if (enddate.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update EndDate");
                }
                else if (endtime.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update EndTime");
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
                    conn.Close();
                }
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details :" + ab.ToString());
            }
        }

        public void breaktime_calculate_filter()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {

                breaktime_minutes.SelectedIndex = -1;
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select concat('BreakTime','   ',isnull(sum(Volumes),0)) as BreakTimeinVolumes, concat('BreakTime','   ', sum(TimeTakeninMinutes)) as BreakTimeinMinutes, concat('BreakTime','   ',sum(TimeTakeninSeconds)) as BreakTimeinSeconds from aom.vw_datagridview_dotnet where ActivityNameID = 130 and convert(date,LoginDate) = convert(date,@date) and EmpName = @assciatename";
                cmd.Parameters.AddWithValue("@date", searchby_date.Value.Date);
                cmd.Parameters.AddWithValue("@assciatename", searchby_associatename.Text);
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                breaktime_minutes.DataSource = dt;
                breaktime_minutes.DisplayMember = "BreakTimeinMinutes";
                breaktime_seconds.DataSource = dt;
                breaktime_seconds.DisplayMember = "BreakTimeinVolumes";
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void coretime_calculate_filter()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {

                coretime_minutes.SelectedIndex = -1;
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select concat('CoreTime','   ',isnull(sum(Volumes),0)) as CoreTimeinVolumes,concat('CoreTime','   ',sum(TimeTakeninMinutes)) as CoreTimeinMinutes, concat('CoreTime','   ',sum(TimeTakeninSeconds)) as CoreTimeinSeconds from aom.vw_datagridview_dotnet where TaskType = 'Core' and convert(date,LoginDate) = convert(date,@date) and EmpName = @assciatename ";
                cmd.Parameters.AddWithValue("@date", searchby_date.Value.Date);
                cmd.Parameters.AddWithValue("@assciatename", searchby_associatename.Text);
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                coretime_minutes.DataSource = dt;
                coretime_minutes.DisplayMember = "CoreTimeinMinutes";
                coretime_seconds.DataSource = dt;
                coretime_seconds.DisplayMember = "CoreTimeinVolumes";
                conn.Close();

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void divertedtime_calculate_filter()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {

                divertedtime_minutes.SelectedIndex = -1;
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select concat('DivertedTime','   ',isnull(sum(Volumes),0)) as DivertedTimeinVolumes, concat('DivertedTime','   ',sum(TimeTakeninMinutes)) as DivertedTimeinMinutes, concat('DivertedTime','   ',sum(TimeTakeninSeconds)) as DivertedTimeinSeconds from aom.vw_datagridview_dotnet where TaskType = 'Diverted' and convert(date,LoginDate) = convert(date,@date) and EmpName = @assciatename ";
                cmd.Parameters.AddWithValue("@date", searchby_date.Value.Date);
                cmd.Parameters.AddWithValue("@assciatename", searchby_associatename.Text);
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                divertedtime_minutes.DataSource = dt;
                divertedtime_minutes.DisplayMember = "DivertedTimeinMinutes";
                divertedtime_seconds.DataSource = dt;
                divertedtime_seconds.DisplayMember = "DivertedTimeinVolumes";
                conn.Close();

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void downtime_calculate_filter()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {

                downtime_minutes.SelectedIndex = -1;
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select concat('DownTime','   ',isnull(sum(Volumes),0)) as DownTimeinSeconds, concat('DownTime','   ',sum(TimeTakeninMinutes)) as DownTimeinMinutes, concat('DownTime','   ',sum(TimeTakeninSeconds)) as DownTimeinSeconds from aom.vw_datagridview_dotnet where TaskType = 'Downtime' and convert(date,LoginDate) = convert(date,@date) and EmpName = @assciatename ";
                cmd.Parameters.AddWithValue("@date", searchby_date.Value.Date);
                cmd.Parameters.AddWithValue("@assciatename", searchby_associatename.Text);
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                downtime_minutes.DataSource = dt;
                downtime_minutes.DisplayMember = "DownTimeinMinutes";
                downtime_seconds.DataSource = dt;
                downtime_seconds.DisplayMember = "DownTimeinSeconds";
                conn.Close();

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        private void radio_minutes_CheckedChanged(object sender, EventArgs e)
        {
            breaktime_minutes.Visible = true;
            coretime_minutes.Visible = true;
            downtime_minutes.Visible = true;
            divertedtime_minutes.Visible = true;
            breaktime_seconds.Visible = false;
            coretime_seconds.Visible = false;
            downtime_seconds.Visible = false;
            divertedtime_seconds.Visible = false;
            refresh_scores_filter();
        }

        private void radio_volumes_CheckedChanged(object sender, EventArgs e)
        {
            breaktime_minutes.Visible = false;
            coretime_minutes.Visible = false;
            downtime_minutes.Visible = false;
            divertedtime_minutes.Visible = false;
            breaktime_seconds.Visible = true;
            coretime_seconds.Visible = true;
            downtime_seconds.Visible = true;
            divertedtime_seconds.Visible = true;
            refresh_scores_filter();
        }

        private void logoff_Click(object sender, EventArgs e)
        {
            string messsage = "Do you want to log off?";
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
                    cmd.CommandText = "aom.usp_aom_verification_rtm_logoff_dotnet";
                    cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                    cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@LastUpdatedBy_Manager", Environment.UserName.ToString());
                    cmd.Parameters.AddWithValue("@LastUpdatedBy_Associate",searchby_associatename.Text);
                    cmd.Parameters.AddWithValue("@Date",searchby_date.Value.Date);
                    
                    //if conditions
                    if(searchby_date.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please select the date");
                    }
                    else if (string.IsNullOrEmpty(searchby_associatename.Text))
                    {
                        MessageBox.Show("Please select Associate Name");
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
                    conn.Close();
                    }

                }
                catch (Exception ab)
                {
                    MessageBox.Show("Error Generated Details :" + ab.ToString());
                }
            }
            else
            {
                homepage.Focus();
            }
            datagridview_display_overall();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(searchby_associatename.Text) && !string.IsNullOrEmpty(searchby_reportingmanagername.Text) && searchby_date.Text.Trim() != string.Empty)
            reset_overall();
        }

        private void endtime_ValueChanged(object sender, EventArgs e)
        {

        }

        private void delete_Click(object sender, EventArgs e)
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
                cmd.CommandText = "aom.usp_verification_rtm_delete_dotnet";
                cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@id", id.Text);
                cmd.Parameters.AddWithValue("@lastupdatedby", Environment.UserName.ToString());

                if (string.IsNullOrEmpty(id.Text))
                {
                    MessageBox.Show("Please select a record");
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
                    conn.Close();
                }
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details :" + ab.ToString());
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
                obj_taskdetails.tasktype_rtm_verification_list(dtaa);
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
                obj_taskdetails.teamname_list (dtaa, tasktype.Text);
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
                obj_teamdetails.teamname_associatewise_rtm_verification_list(dtaa, empname.Text.ToString());
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

        public void coreteamname_associatewise_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                TeamDetails obj_teamdetails = new TeamDetails();
                DataTable dtaa = new DataTable();
                obj_teamdetails.teamname_associatewise_rtm_verification_list(dtaa, empname.Text.ToString());
                coreteamname.DataSource = dtaa;
                coreteamname.DisplayMember = "TeamName";
                coreteamname.ValueMember = "TeamNameID";
                conn.Close();
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
                obj_taskdetails.activityname_list(dtaa, tasktype.Text, teamname.Text);
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
                obj_teamdetails.activityname_associatewise_rtm_verification_list(dtaa, empname.Text, teamname.Text);
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

        public void core_activityname_associatewise_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                TeamDetails obj_teamdetails = new TeamDetails();
                DataTable dtaa = new DataTable();
                obj_teamdetails.activityname_associatewise_rtm_verification_list(dtaa, empname.Text, coreteamname.Text);
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
            if (tasktype.Text == "Core")
            {
                teamname_associatewise_list();
            }
            else
            {
                teamname_list();
            }
        }

        private void teamname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tasktype.Text == "Core")
            {
                activityname_associatewise_list();
            }
            else
            {
                activityname_list();
            }
        }

        private void activityname_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void empname_TextChanged(object sender, EventArgs e)
        {

        }

        private void starttime_ValueChanged(object sender, EventArgs e)
        {

        }

        private void searchby_reportingmanagername_SelectedIndexChanged(object sender, EventArgs e)
        {
            empname_list();
        }

        private void updatefinal_Click(object sender, EventArgs e)
        {
            string messsage = "Do you want to update?";
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
                    cmd.CommandText = "aom.usp_aom_verification_rtm_dotnet_update";
                    cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                    cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@LastUpdatedBy_Manager", Environment.UserName.ToString());
                    cmd.Parameters.AddWithValue("@LastUpdatedBy_Associate",searchby_associatename.Text);
                    cmd.Parameters.AddWithValue("@Date",searchby_date.Value.Date);
                    
                    //if conditions
                    if(searchby_date.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please select the date");
                    }
                    else if (string.IsNullOrEmpty(searchby_associatename.Text))
                    {
                        MessageBox.Show("Please select Associate Name");
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
                    conn.Close();
                    }

                }
                catch (Exception ab)
                {
                    MessageBox.Show("Error Generated Details :" + ab.ToString());
                }
            }
            else
            {
                homepage.Focus();
            }
            datagridview_display_overall();
        }

        private void coreteamname_SelectedIndexChanged(object sender, EventArgs e)
        {
            //coreteamname_associatewise_list();
            core_activityname_associatewise_list();
        }

        private void addtask_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddRecords_RTMVerification obj1 = new AddRecords_RTMVerification();
            obj1.Show();
        }
        


        

    }
}
