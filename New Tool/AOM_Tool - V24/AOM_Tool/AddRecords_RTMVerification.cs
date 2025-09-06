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
    public partial class AddRecords_RTMVerification : Form
    {
        //public string connectionstringtxt = "Data Source=MUM1-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        //public string connectionstringtxt = ConfigurationManager.ConnectionStrings["KYC_RDC_Workflow.Properties.Settings.DRDConnectionString"].ConnectionString;
        //public string connectionstringtxt = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();

        public AddRecords_RTMVerification()
        {
            InitializeComponent();
        }

        private void AddRecords_RTMVerification_Load(object sender, EventArgs e)
        {
            empname_list();
            tasktype_list();
            reset_overall();
        }

        public void reset_overall()
        {
            empname.SelectedIndex = -1;
            teamname.SelectedIndex = -1;
            tasktype.SelectedIndex = -1;
            activityname.SelectedIndex = -1;
            starttime.CustomFormat = " ";
            endtime.CustomFormat = " ";
            volumes.Text = string.Empty;
            date.CustomFormat = " ";
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
                obj_empdetails.emp_details_overall (dtaa);
                empname.DataSource = dtaa;
                empname.DisplayMember = "EmpName";
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
                TeamDetails obj_teamdetails = new TeamDetails();
                DataTable dtaa = new DataTable();
                obj_teamdetails.teamname_associatewise_rtm_verification_list(dtaa, empname.Text);
                teamname.DataSource = dtaa;
                teamname.DisplayMember = "TeamName";
                teamname.ValueMember = "TeamNameID";
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
                obj_taskdetails.tasktype_rtm_verification_addtask_list(dtaa);
                tasktype.DataSource = dtaa;
                tasktype.DisplayMember = "TaskType";
                conn.Close();
                tasktype.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void activityname_list()
        {
            //if (!string.IsNullOrEmpty(teamname.Text) && !string.IsNullOrEmpty(tasktype.Text) && tasktype.Text == "Core")
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
                    activityname.SelectedIndex = -1;
                }
                catch (Exception ab)
                {
                    MessageBox.Show("Error Generated Details : " + ab.ToString());
                }
            }
        }

        public void activityname_noncore_list()
        {
            //if (!string.IsNullOrEmpty(teamname.Text) && !string.IsNullOrEmpty(tasktype.Text) && tasktype.Text == "Core")
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                try
                {
                    TasksDetails obj_taskdetails = new TasksDetails();
                    DataTable dtaa = new DataTable();
                    obj_taskdetails.activityname_noncore_list(dtaa, tasktype.Text);
                    activityname.DataSource = dtaa;
                    activityname.DisplayMember = "ActivityName";
                    activityname.ValueMember = "ID";
                    conn.Close();
                    activityname.SelectedIndex = -1;
                }
                catch (Exception ab)
                {
                    MessageBox.Show("Error Generated Details : " + ab.ToString());
                }
            }
        }

        private void empname_SelectedIndexChanged(object sender, EventArgs e)
        {
            teamname_list();
        }

        private void tasktype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(teamname.Text) && !string.IsNullOrEmpty(tasktype.Text) && tasktype.Text == "Core")
            {
                activityname_list();
            }
            else
            {
                activityname_noncore_list();
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            reset_overall();
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
        }

        private void teamname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(teamname.Text) && !string.IsNullOrEmpty(tasktype.Text) && tasktype.Text == "Core")
            {
                activityname_list();
            }
            else
            {
                activityname_noncore_list();
            }
        }

        private void date_ValueChanged(object sender, EventArgs e)
        {
            date.CustomFormat = "dd-MMMM-yyyy";
        }

        private void date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                date.CustomFormat = " ";
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            string messsage = "Do you want to add this record?";
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
                    cmd.CommandText = "aom.usp_rtm_verification_addtask_dotnet";
                    cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                    cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@EmpName", empname.Text);
                    cmd.Parameters.AddWithValue("@TeamNameID",teamname.SelectedValue);
                    cmd.Parameters.AddWithValue("@TaskType",tasktype.Text);
                    cmd.Parameters.AddWithValue("@ActivityNameID",activityname.SelectedValue);
                    cmd.Parameters.AddWithValue("@StartTime",starttime.Value.ToLongTimeString());
                    cmd.Parameters.AddWithValue("@EndTime",endtime.Value.ToLongTimeString());
                    cmd.Parameters.AddWithValue("@Volumes",volumes.Text);
                    cmd.Parameters.AddWithValue("@Date",date.Value.Date);
                    cmd.Parameters.AddWithValue("@MachineName",Environment.MachineName.ToString());
                    cmd.Parameters.AddWithValue("@LastUpdatedBy_Manager",Environment.UserName.ToString());

                    //if conditions
                    if (string.IsNullOrEmpty(empname.Text))
                    {
                        MessageBox.Show("Please update Emp Name");
                    }
                    else if (string.IsNullOrEmpty(teamname.Text))
                    {
                        MessageBox.Show("please update Team Name");
                    }
                    else if (string.IsNullOrEmpty(tasktype.Text))
                    {
                        MessageBox.Show("Please update Task Type");
                    }
                    else if (string.IsNullOrEmpty(activityname.Text))
                    {
                        MessageBox.Show("Please update Activity Name");
                    }
                    else if (starttime.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please update Start Time");
                    }
                    else if (endtime.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please update end time");
                    }
                    else if (date.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please update Date");
                    }
                    else if (volumes.Text == string.Empty)
                    {
                        MessageBox.Show("Please update Volumes");
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
                empname.Focus();
            }
        }
    }
}
