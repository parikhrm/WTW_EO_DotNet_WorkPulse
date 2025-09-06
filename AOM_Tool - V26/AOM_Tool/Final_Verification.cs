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
    public partial class Final_Verification : Form
    {
        //public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        //public string connectionstringtxt = ConfigurationManager.ConnectionStrings["KYC_RDC_Workflow.Properties.Settings.DRDConnectionString"].ConnectionString;
        //public string connectionstringtxt = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();

        public Final_Verification()
        {
            InitializeComponent();
        }

        private void Final_Verification_Load(object sender, EventArgs e)
        {
            
            reportingmanager_list();
            teamname_list();
            reset_overall();
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

                obj_coretime_target.coretime_roster_final_verification (dtaa, searchby_empname.Text, searchby_date.Value.Date);
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

        public void refresh_overall()
        {
            datagridview_coretime_display();
            datagridview_diverted_display();
            datagridview_downtime_display();
            datagridview_breaktime_display();
            datagridview_idletime_display();
            datagridview_display_overall();
            
            if (!string.IsNullOrEmpty(searchby_empname.Text))
            {
                utilization_calculate_filter();
                productivity_calculate_filter();
            }
            breaktime_calculate_filter();
            coretime_calculate_filter();
            downtime_calculate_filter();
            timeworked_calculate_filter();
            divertedtime_calculate_filter();
            coretime_target();
            
        }

        public void reset_overall()
        {
            searchby_date.CustomFormat = " ";
            searchby_empname.SelectedIndex = -1;
            //searchby_teamname.SelectedIndex = -1;
            searchby_reportingmanagername.SelectedIndex = -1;
            replicate_workflow_volumes.Visible = false;
            
        }

        

        private void homepage_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            HomePage obj_homepage = new HomePage();
            obj_homepage.Show();
        }

        public void breaktime_calculate_filter()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                breaktime_combobox.SelectedIndex = -1;
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select concat('BreakTime(Mins)','   ', sum(isnull(TotalTime_Minutes,0))) as BreakTimeinMinutes from aom.vw_verification_volumes_dotnet_final where TaskType = 'Break' and convert(date,AOM_Date) = convert(date,@date) and EmpName = @assciatename /* and TeamNameID = @teamnameid */";
                cmd.Parameters.AddWithValue("@date", searchby_date.Value.Date);
                cmd.Parameters.AddWithValue("@assciatename", searchby_empname.Text);
                //cmd.Parameters.AddWithValue("@teamnameid",searchby_teamname.SelectedValue);
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                breaktime_combobox.DataSource = dt;
                breaktime_combobox.DisplayMember = "BreakTimeinMinutes";
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
                downtime_combobox.SelectedIndex = -1;
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select concat('DownTime(Mins)','   ', sum(isnull(TotalTime_Minutes,0))) as DownTimeinMinutes from aom.vw_verification_volumes_dotnet_final where TaskType = 'DownTime' and convert(date,AOM_Date) = convert(date,@date) and EmpName = @assciatename /* and TeamNameID = @teamnameid */";
                cmd.Parameters.AddWithValue("@date", searchby_date.Value.Date);
                cmd.Parameters.AddWithValue("@assciatename", searchby_empname.Text);
                //cmd.Parameters.AddWithValue("@teamnameid", searchby_teamname.SelectedValue);
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                downtime_combobox.DataSource = dt;
                downtime_combobox.DisplayMember = "DownTimeinMinutes";
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
                divertedtime_combobox.SelectedIndex = -1;
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select concat('DivertedTime(Mins)','   ', sum(isnull(TotalTime_Minutes,0))) as DivertedTimeinMinutes from aom.vw_verification_volumes_dotnet_final where TaskType = 'Diverted' and convert(date,AOM_Date) = convert(date,@date) and EmpName = @assciatename /* and TeamNameID = @teamnameid */";
                cmd.Parameters.AddWithValue("@date", searchby_date.Value.Date);
                cmd.Parameters.AddWithValue("@assciatename", searchby_empname.Text);
                //cmd.Parameters.AddWithValue("@teamnameid", searchby_teamname.SelectedValue);
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                divertedtime_combobox.DataSource = dt;
                divertedtime_combobox.DisplayMember = "DivertedTimeinMinutes";
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
                coretime_combobox.SelectedIndex = -1;
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select concat('CoreTime(Mins)','   ', sum(isnull(TotalTime_Minutes,0))) as CoreTimeinMinutes from aom.vw_verification_volumes_dotnet_final where TaskType = 'Core' and convert(date,AOM_Date) = convert(date,@date) and EmpName = @assciatename /* and TeamNameID = @teamnameid */";
                cmd.Parameters.AddWithValue("@date", searchby_date.Value.Date);
                cmd.Parameters.AddWithValue("@assciatename", searchby_empname.Text);
                //cmd.Parameters.AddWithValue("@teamnameid", searchby_teamname.SelectedValue);
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                coretime_combobox.DataSource = dt;
                coretime_combobox.DisplayMember = "CoreTimeinMinutes";
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void timeworked_calculate_filter()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                timeworked_combobox.SelectedIndex = -1;
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select concat('TimeWorked(Mins)','   ', sum(isnull(TotalTime_Minutes,0))) as TimeWorkedinMinutes from aom.vw_verification_volumes_dotnet_final where TaskType in ('Core','Diverted') and convert(date,AOM_Date) = convert(date,@date) and EmpName = @assciatename /* and TeamNameID = @teamnameid */";
                cmd.Parameters.AddWithValue("@date", searchby_date.Value.Date);
                cmd.Parameters.AddWithValue("@assciatename", searchby_empname.Text);
                //cmd.Parameters.AddWithValue("@teamnameid", searchby_teamname.SelectedValue);
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                timeworked_combobox.DataSource = dt;
                timeworked_combobox.DisplayMember = "TimeWorkedinMinutes";
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        private void searchby_date_ValueChanged(object sender, EventArgs e)
        {
            searchby_date.CustomFormat = "dd-MMMM-yyyy";
            //datagridview_coretime_display();
            //datagridview_diverted_display();
            //datagridview_downtime_display();
            //datagridview_breaktime_display();
            //datagridview_idletime_display();
            //datagridview_display_overall();
            //if (!string.IsNullOrEmpty(searchby_empname.Text))
            //{
            //    utilization_calculate_filter();
            //    productivity_calculate_filter();
            //}
        }

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
                cmd.CommandText = "aom.usp_utilization_calculate_filter_dotnet_final_verification_new";
                cmd.Parameters.AddWithValue("@associatename", searchby_empname.Text);
                cmd.Parameters.AddWithValue("@date", searchby_date.Value.Date);
                cmd.Parameters.AddWithValue("@teamnameid",searchby_teamname.SelectedValue);
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
                cmd.CommandText = "aom.usp_productivity_calculate_filter_dotnet_final_verification_new";
                cmd.Parameters.AddWithValue("@associatename", searchby_empname.Text);
                cmd.Parameters.AddWithValue("@date", searchby_date.Value.Date);
                cmd.Parameters.AddWithValue("@teamnameid",searchby_teamname.SelectedValue);
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
                obj_empdetails.reportingmanager_details_overall (dtaa);
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

        public void teamname_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                TasksDetails obj_tasksdetails = new TasksDetails();
                DataTable dtaa = new DataTable();
                obj_tasksdetails.teamname_finalverification_list(dtaa);
                searchby_teamname.DataSource = dtaa;
                searchby_teamname.DisplayMember = "TeamName";
                searchby_teamname.ValueMember = "TeamNameID";
                conn.Close();
                //searchby_teamname.SelectedIndex = -1;
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
                Emp_Details obj_empdetails = new Emp_Details();
                DataTable dtaa = new DataTable();
                obj_empdetails.emp_details_basedonreportingmanager_and_teamname(dtaa, searchby_reportingmanagername.Text,searchby_teamname.Text);
                searchby_empname.DataSource = dtaa;
                searchby_empname.DisplayMember = "EmpName";
                conn.Close();
                searchby_empname.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        private void searchby_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                searchby_date.CustomFormat = " ";
            }
        }

        public void datagridview_coretime_display()
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
                if (string.IsNullOrEmpty(searchby_empname.Text) && searchby_date.Text.Trim() == string.Empty && string.IsNullOrEmpty(searchby_teamname.Text) && string.IsNullOrEmpty(searchby_reportingmanagername.Text))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select top 100 a.ID,a.TeamName,b.ActivityName,isnull(a.Volumes,0) as Volumes,isnull(Volumes_Workflow,0) as Volumes_Workflow,a.TotalTime_Minutes,a.TotalTime_Hours,a.AssociateName,a.AOM_Date,c.EmpName,a.Verified_By,a.IsVerified from aom.vw_verification_volumes_dotnet a inner join aom.tbl_tasks_details_dotnet b with(nolock) on a.ActivityNameID = b.ID inner join dbo.tbl_emp_details c with(nolock) on a.AssociateName = substring(c.INTID,5,len(c.INTID)) where /*a.AOM_Date = @date and c.EmpName = @empname and*/ b.tasktype = 'Core'";
                    //cmd.Parameters.AddWithValue("@date", searchby_date.Value.Date);
                    //cmd.Parameters.AddWithValue("@empname", searchby_empname.Text);

                }
                else
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "aom.usp_datagridview_final_verification_coretime_dotnet";
                    if (searchby_date.Text.Trim() == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@date", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@date", searchby_date.Value.Date);
                    }
                    if (string.IsNullOrEmpty(searchby_empname.Text))
                    {
                        cmd.Parameters.AddWithValue("@empname", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@empname",searchby_empname.Text);
                    }
                    if (string.IsNullOrEmpty(searchby_teamname.Text))
                    {
                        cmd.Parameters.AddWithValue("@teamname",DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@teamname",searchby_teamname.Text);
                    }
                }


                sda.SelectCommand = cmd;
                sda.Fill(dt);
                datagridview_coretime.DataSource = dt;
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
                if (!string.IsNullOrEmpty(searchby_empname.Text) && searchby_date.Text.Trim() != string.Empty)
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "aom.usp_totaltime_final_verification_dotnet_new";
                    cmd.Parameters.AddWithValue("@aomdate", searchby_date.Value.Date);
                    cmd.Parameters.AddWithValue("@empname", searchby_empname.Text);
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                    datagridview_overall.DataSource = dt;
                    conn.Close();
                }
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

       

        public void datagridview_diverted_display()
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
                if (string.IsNullOrEmpty(searchby_empname.Text) && searchby_date.Text.Trim() == string.Empty && string.IsNullOrEmpty(searchby_teamname.Text) && string.IsNullOrEmpty(searchby_reportingmanagername.Text))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select top 100 a.ID,a.TeamName,b.ActivityName,a.AssociateName,a.AOM_Date,c.EmpName,TotalTime_Hours,TotalTime_Minutes,a.Verified_By,a.IsVerified from aom.vw_verification_volumes_dotnet a inner join aom.vw_tasks_details_dotnet b on a.ActivityNameID = b.ID inner join dbo.tbl_emp_details c with(nolock) on a.AssociateName = substring(c.INTID,5,len(c.INTID)) where /*a.AOM_Date = @date and c.EmpName = @empname and*/ b.tasktype = 'Diverted'";
                    //cmd.Parameters.AddWithValue("@date", searchby_date.Value.Date);
                    //cmd.Parameters.AddWithValue("@empname", searchby_empname.Text);

                }
                else
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "aom.usp_datagridview_final_verification_diverted_dotnet";
                    if (searchby_date.Text.Trim() == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@date", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@date", searchby_date.Value.Date);
                    }
                    if (string.IsNullOrEmpty(searchby_empname.Text))
                    {
                        cmd.Parameters.AddWithValue("@empname", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@empname", searchby_empname.Text);
                    }
                    if (string.IsNullOrEmpty(searchby_teamname.Text))
                    {
                        cmd.Parameters.AddWithValue("@teamname", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@teamname", searchby_teamname.Text);
                    }
                }


                sda.SelectCommand = cmd;
                sda.Fill(dt);
                datagridview_diverted.DataSource = dt;
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void datagridview_downtime_display()
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
                if (string.IsNullOrEmpty(searchby_empname.Text) && searchby_date.Text.Trim() == string.Empty && string.IsNullOrEmpty(searchby_teamname.Text) && string.IsNullOrEmpty(searchby_reportingmanagername.Text))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select top 100 a.ID,a.TeamName,b.ActivityName,a.AssociateName,a.AOM_Date,c.EmpName,a.TotalTime_Hours,a.TotalTime_Minutes,a.Verified_By,a.IsVerified from aom.vw_verification_volumes_dotnet a inner join aom.vw_tasks_details_dotnet b on a.ActivityNameID = b.ID inner join dbo.tbl_emp_details c with(nolock) on a.AssociateName = substring(c.INTID,5,len(c.INTID)) where /*a.AOM_Date = @date and c.EmpName = @empname and*/ b.tasktype = 'DownTime'";
                    //cmd.Parameters.AddWithValue("@date", searchby_date.Value.Date);
                    //cmd.Parameters.AddWithValue("@empname", searchby_empname.Text);

                }
                else
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "aom.usp_datagridview_final_verification_downtime_dotnet";
                    if (searchby_date.Text.Trim() == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@date", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@date", searchby_date.Value.Date);
                    }
                    if (string.IsNullOrEmpty(searchby_empname.Text))
                    {
                        cmd.Parameters.AddWithValue("@empname", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@empname", searchby_empname.Text);
                    }
                    if (string.IsNullOrEmpty(searchby_teamname.Text))
                    {
                        cmd.Parameters.AddWithValue("@teamname", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@teamname", searchby_teamname.Text);
                    }
                }


                sda.SelectCommand = cmd;
                sda.Fill(dt);
                datagridview_downtime.DataSource = dt;
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void datagridview_breaktime_display()
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
                if (string.IsNullOrEmpty(searchby_empname.Text) && searchby_date.Text.Trim() == string.Empty && string.IsNullOrEmpty(searchby_teamname.Text) && string.IsNullOrEmpty(searchby_reportingmanagername.Text))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select top 100 a.ID,a.TeamName,b.ActivityName,a.AssociateName,a.AOM_Date,c.EmpName,TotalTime_Hours,TotalTime_Minutes,a.Verified_By,a.IsVerified from aom.vw_verification_volumes_dotnet a inner join aom.vw_tasks_details_dotnet b on a.ActivityNameID = b.ID inner join dbo.tbl_emp_details c with(nolock) on a.AssociateName = substring(c.INTID,5,len(c.INTID)) where /*a.AOM_Date = @date and c.EmpName = @empname and*/ b.tasktype = 'Break'";
                    //cmd.Parameters.AddWithValue("@date", searchby_date.Value.Date);
                    //cmd.Parameters.AddWithValue("@empname", searchby_empname.Text);

                }
                else
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "aom.usp_datagridview_final_verification_break_dotnet";
                    if (searchby_date.Text.Trim() == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@date", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@date", searchby_date.Value.Date);
                    }
                    if (string.IsNullOrEmpty(searchby_empname.Text))
                    {
                        cmd.Parameters.AddWithValue("@empname", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@empname", searchby_empname.Text);
                    }
                    if (string.IsNullOrEmpty(searchby_teamname.Text))
                    {
                        cmd.Parameters.AddWithValue("@teamname", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@teamname", searchby_teamname.Text);
                    }
                }


                sda.SelectCommand = cmd;
                sda.Fill(dt);
                datagridview_breaktime.DataSource = dt;
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void datagridview_idletime_display()
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
                if (string.IsNullOrEmpty(searchby_empname.Text) && searchby_date.Text.Trim() == string.Empty && string.IsNullOrEmpty(searchby_teamname.Text) && string.IsNullOrEmpty(searchby_reportingmanagername.Text))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select top 100 a.ID,a.TeamName,b.ActivityName,a.AssociateName,a.AOM_Date,c.EmpName,TotalTime_Hours,TotalTime_Minutes,a.Verified_By,a.IsVerified from aom.vw_verification_volumes_dotnet a inner join aom.tbl_tasks_details_dotnet b with(nolock) on a.ActivityNameID = b.ID inner join dbo.tbl_emp_details c with(nolock) on a.AssociateName = substring(c.INTID,5,len(c.INTID)) where /*a.AOM_Date = @date and c.EmpName = @empname and */  b.tasktype = 'Idle Time'";
                    //cmd.Parameters.AddWithValue("@date", searchby_date.Value.Date);
                    //cmd.Parameters.AddWithValue("@empname", searchby_empname.Text);

                }
                else
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "aom.usp_datagridview_final_verification_idletime_dotnet";
                    if (searchby_date.Text.Trim() == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@date", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@date", searchby_date.Value.Date);
                    }
                    if (string.IsNullOrEmpty(searchby_empname.Text))
                    {
                        cmd.Parameters.AddWithValue("@empname", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@empname", searchby_empname.Text);
                    }
                    if (string.IsNullOrEmpty(searchby_teamname.Text))
                    {
                        cmd.Parameters.AddWithValue("@teamname", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@teamname", searchby_teamname.Text);
                    }
                }


                sda.SelectCommand = cmd;
                sda.Fill(dt);
                datagridview_idletime.DataSource = dt;
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        private void datagridview_coretime_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            if (datagridview_coretime.CurrentRow != null)
            {
                try
                {
                    DataGridViewRow dgvrow = datagridview_coretime.CurrentRow;
                    conn.ConnectionString = connectionstringtxt;
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "aom.usp_verification_volumes_final_dotnet";
                    cmd.Parameters.AddWithValue("@id", dgvrow.Cells["txtID_CoreTime"].Value);
                    cmd.Parameters.AddWithValue("@volumes", dgvrow.Cells["txtVolumes_CoreTime"].Value);
                    cmd.Parameters.AddWithValue("@volumes_workflow", dgvrow.Cells["txtVolumes_Workflow"].Value);
                    cmd.Parameters.AddWithValue("@lastupdatedby", Environment.UserName.ToString());
                    cmd.Parameters.AddWithValue("@minutes", dgvrow.Cells["txtTotalTime_Minutes_CoreTime"].Value);
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
                    }
                    datagridview_coretime_display();
                    
                }

                catch (Exception ab)
                {
                    MessageBox.Show("Error Generated Details :" + ab.ToString());
                    datagridview_coretime_display();

                }
            }
        }

        private void datagridview_diverted_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            if (datagridview_diverted.CurrentRow != null)
            {
                try
                {
                    DataGridViewRow dgvrow = datagridview_diverted.CurrentRow;
                    conn.ConnectionString = connectionstringtxt;
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.CommandText = "aom.usp_verification_divertedtime_final_dotnet";
                    cmd.CommandText = "aom.usp_verification_time_final_dotnet";
                    cmd.Parameters.AddWithValue("@id", dgvrow.Cells["txtID_Diverted"].Value);
                    cmd.Parameters.AddWithValue("@minutes", dgvrow.Cells["txtTotalTime_Minutes_Diverted"].Value);
                    cmd.Parameters.AddWithValue("@lastupdatedby", Environment.UserName.ToString());
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
                    }
                    datagridview_diverted_display();

                }

                catch (Exception ab)
                {
                    MessageBox.Show("Error Generated Details :" + ab.ToString());
                    datagridview_diverted_display();

                }
            }
        }

        private void datagridview_downtime_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            if (datagridview_downtime.CurrentRow != null)
            {
                try
                {
                    DataGridViewRow dgvrow = datagridview_downtime.CurrentRow;
                    conn.ConnectionString = connectionstringtxt;
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.CommandText = "aom.usp_verification_downtime_final_dotnet";
                    cmd.CommandText = "aom.usp_verification_time_final_dotnet";
                    cmd.Parameters.AddWithValue("@id", dgvrow.Cells["txtID_DownTime"].Value);
                    cmd.Parameters.AddWithValue("@minutes", dgvrow.Cells["txtTotalTime_Minutes_DownTime"].Value);
                    cmd.Parameters.AddWithValue("@lastupdatedby", Environment.UserName.ToString());
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
                    }
                    datagridview_downtime_display();

                }

                catch (Exception ab)
                {
                    MessageBox.Show("Error Generated Details :" + ab.ToString());
                    datagridview_downtime_display();

                }
            }
        }

        private void searchby_empname_SelectedIndexChanged(object sender, EventArgs e)
        {
            //datagridview_coretime_display();
            //datagridview_diverted_display();
            //datagridview_downtime_display();
            //datagridview_breaktime_display();
            //datagridview_display_overall();
            //datagridview_idletime_display();
            //if (searchby_date.Text.Trim() != string.Empty)
            //{
            //    utilization_calculate_filter();
            //    productivity_calculate_filter();
            //}
        }

        private void searchby_reportingmanagername_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(searchby_teamname.Text) && !string.IsNullOrEmpty(searchby_reportingmanagername.Text))
            {
                empname_list();
            }
        }

        private void searchby_teamname_SelectedIndexChanged(object sender, EventArgs e)
        {
            //datagridview_coretime_display();
            //datagridview_diverted_display();
            //datagridview_downtime_display();
            //datagridview_breaktime_display();
            //datagridview_idletime_display();
            //datagridview_idletime_display();
            if (!string.IsNullOrEmpty(searchby_teamname.Text) && !string.IsNullOrEmpty(searchby_reportingmanagername.Text))
            {
                empname_list();
            }
        }

        private void datagridview_breaktime_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            if (datagridview_breaktime.CurrentRow != null)
            {
                try
                {
                    DataGridViewRow dgvrow = datagridview_breaktime.CurrentRow;
                    conn.ConnectionString = connectionstringtxt;
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.CommandText = "aom.usp_verification_breaktime_final_dotnet";
                    cmd.CommandText = "aom.usp_verification_time_final_dotnet";
                    cmd.Parameters.AddWithValue("@id", dgvrow.Cells["txtID_BreakTime"].Value);
                    cmd.Parameters.AddWithValue("@minutes", dgvrow.Cells["txtTotalTime_Minutes_BreakTime"].Value);
                    cmd.Parameters.AddWithValue("@lastupdatedby", Environment.UserName.ToString());
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
                    }
                    datagridview_breaktime_display();

                }

                catch (Exception ab)
                {
                    MessageBox.Show("Error Generated Details :" + ab.ToString());
                    datagridview_coretime_display();

                }
            }
        }

        private void datagridview_idletime_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            if (datagridview_idletime.CurrentRow != null)
            {
                try
                {
                    DataGridViewRow dgvrow = datagridview_idletime.CurrentRow;
                    conn.ConnectionString = connectionstringtxt;
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.CommandText = "aom.usp_verification_breaktime_final_dotnet";
                    cmd.CommandText = "aom.usp_verification_time_final_dotnet";
                    cmd.Parameters.AddWithValue("@id", dgvrow.Cells["txtID_IdleTime"].Value);
                    cmd.Parameters.AddWithValue("@minutes", dgvrow.Cells["txtTotalTime_Minutes_IdleTime"].Value);
                    cmd.Parameters.AddWithValue("@lastupdatedby", Environment.UserName.ToString());
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
                    }
                    datagridview_idletime_display();

                }

                catch (Exception ab)
                {
                    MessageBox.Show("Error Generated Details :" + ab.ToString());
                    datagridview_idletime_display();

                }
            }
        }

        private void rtm_verification_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible = false;
            RTM_Verification obj_verification = new RTM_Verification();
            obj_verification.Show();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            //datagridview_coretime_display();
            //datagridview_diverted_display();
            //datagridview_downtime_display();
            //datagridview_breaktime_display();
            //datagridview_idletime_display();
            //datagridview_display_overall();
            //if (!string.IsNullOrEmpty(searchby_empname.Text))
            //{
            //    utilization_calculate_filter();
            //    productivity_calculate_filter();
            //}
            refresh_overall();
        }

        private void data_verified_Click(object sender, EventArgs e)
        {
            string messsage = "Do you confirm the data is verified?";
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
                cmd.CommandText = "aom.usp_verification_verified_status_dotnet";
                cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@teamname", searchby_teamname.SelectedValue);
                cmd.Parameters.AddWithValue("@empname", searchby_empname.Text);
                cmd.Parameters.AddWithValue("@date", searchby_date.Value.Date);
                cmd.Parameters.AddWithValue("@verified_by", Environment.UserName.ToString());
            
                conn.Open();
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                string uploadmessage = cmd.Parameters["@Message"].Value.ToString();
                MessageBox.Show("" + uploadmessage.ToString());
                cmd.Parameters.Clear();
                //reset_overall();
                //refresh_scores_today();
                refresh_overall();

                conn.Close();
            }

            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details :" + ab.ToString());
            }
        }
        
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://app.powerbi.com/groups/81c3ab7d-0a2a-46f2-b54f-38eb239011a1/reports/d0b2b18a-ee36-4478-b015-ed785e7c1d2f/ReportSection31a41de679b2bcefa277?experience=power-bi");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
        }

        private void datagridview_diverted_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void datagridview_coretime_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow myrow in datagridview_coretime.Rows)
            {
                if (myrow.Cells["txtIsVerified_CoreTime"].Value.ToString() == "1")
                {
                    myrow.DefaultCellStyle.BackColor = Color.Green;
                    myrow.DefaultCellStyle.ForeColor = Color.White;
         
                }
                else 
                {
                    myrow.DefaultCellStyle.BackColor = Color.Orange;
                    myrow.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void datagridview_diverted_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow myrow in datagridview_diverted.Rows)
            {
                if (myrow.Cells["txtIsVerified_Diverted"].Value.ToString() == "1")
                {
                    myrow.DefaultCellStyle.BackColor = Color.Green;
                    myrow.DefaultCellStyle.ForeColor = Color.White;

                }
                else
                {
                    myrow.DefaultCellStyle.BackColor = Color.Orange;
                    myrow.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void datagridview_downtime_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow myrow in datagridview_downtime.Rows)
            {
                if (myrow.Cells["txtIsVerified_DownTime"].Value.ToString() == "1")
                {
                    myrow.DefaultCellStyle.BackColor = Color.Green;
                    myrow.DefaultCellStyle.ForeColor = Color.White;

                }
                else
                {
                    myrow.DefaultCellStyle.BackColor = Color.Orange;
                    myrow.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void datagridview_breaktime_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow myrow in datagridview_breaktime.Rows)
            {
                if (myrow.Cells["txtIsVerified_BreakTime"].Value.ToString() == "1")
                {
                    myrow.DefaultCellStyle.BackColor = Color.Green;
                    myrow.DefaultCellStyle.ForeColor = Color.White;

                }
                else
                {
                    myrow.DefaultCellStyle.BackColor = Color.Orange;
                    myrow.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void datagridview_idletime_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow myrow in datagridview_idletime.Rows)
            {
                if (myrow.Cells["txtIsVerified_IdleTime"].Value.ToString() == "1")
                {
                    myrow.DefaultCellStyle.BackColor = Color.Green;
                    myrow.DefaultCellStyle.ForeColor = Color.White;

                }
                else
                {
                    myrow.DefaultCellStyle.BackColor = Color.Orange;
                    myrow.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://A20-CB-DBSE01P/Reports/report/DRD%20MI%20Mumbai/DRD%20Reports/rpt_SSRS_WorkPulse_Verified_Status_Report_DotNet");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
        }

        private void datagridview_idletime_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void replicate_workflow_volumes_Click(object sender, EventArgs e)
        {
            string messsage = "Do you confirm the data is verified?";
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
                    cmd.CommandText = "aom.usp_verification_replicateworkflowvolumes_dotnet";
                    cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                    cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@teamname", searchby_teamname.SelectedValue);
                    cmd.Parameters.AddWithValue("@empname", searchby_empname.Text);
                    cmd.Parameters.AddWithValue("@date", searchby_date.Value.Date);
                    cmd.Parameters.AddWithValue("@lastupdatedby", Environment.UserName.ToString());

                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    string uploadmessage = cmd.Parameters["@Message"].Value.ToString();
                    MessageBox.Show("" + uploadmessage.ToString());
                    cmd.Parameters.Clear();
                    //reset_overall();
                    //refresh_scores_today();
                    refresh_overall();

                    conn.Close();
                }

                catch (Exception ab)
                {
                    MessageBox.Show("Error Generated Details :" + ab.ToString());
                }
            }

        }

        
        
    }
}
