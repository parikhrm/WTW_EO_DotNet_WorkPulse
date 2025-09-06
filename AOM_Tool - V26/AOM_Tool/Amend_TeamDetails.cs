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
    public partial class Amend_TeamDetails : Form
    {
        //public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        //public string connectionstringtxt = "Data Source=10.137.16.47;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        //public string connectionstringtxt = ConfigurationManager.ConnectionStrings["KYC_RDC_Workflow.Properties.Settings.DRDConnectionString"].ConnectionString;
        //public string connectionstringtxt = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();


        public Amend_TeamDetails()
        {
            InitializeComponent();
        }

        private void Amend_TeamDetails_Load(object sender, EventArgs e)
        {
            empname_list();
            teamname_list();
            reportingmanger_list();
            reset_overall();
        }

        public void reset_overall()
        {
            empname.SelectedIndex = -1;
            teamname.SelectedIndex = -1;
            searchby_empname.Enabled = false;
            checkbox_iscore.Checked = false;
            datagridview_display_overall();
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
                obj_empdetails.emp_details_overall(dtaa);
                empname.DataSource = dtaa;
                empname.DisplayMember = "EmpName";
                conn.Close();

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void reportingmanger_list()
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
                searchby_reportingmanager.DataSource = dtaa;
                searchby_reportingmanager.DisplayMember = "EmpName";
                conn.Close();
                searchby_reportingmanager.SelectedIndex = -1;

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void empname_basedon_reportingmanager_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                searchby_empname.Enabled = true;
                Emp_Details obj_empdetails = new Emp_Details();
                DataTable dtaa = new DataTable();
                obj_empdetails.emp_details_basedonreportingmanager (dtaa,searchby_reportingmanager.Text);
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
                obj_teamdetails.teamname_list_amend_teamdetails_form(dtaa);
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
                if (string.IsNullOrEmpty(searchby_empname.Text) && string.IsNullOrEmpty(searchby_reportingmanager.Text))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select a.EmpID,a.EmpName,b.[Reporting Manager] as ReportingManager,TeamName,ActivityName from aom.vw_teamdetails_dotnet a  left join dbo.tbl_emp_details b with(nolock) on a.EmpID = b.[EmpId - New] order by a.TeamName, a.ActivityName, a.EmpName";
                }
                else
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "aom.usp_datagridview_teamdetails_dotnet";
                    if (string.IsNullOrEmpty(searchby_reportingmanager.Text))
                    {
                        cmd.Parameters.AddWithValue("@reportingmanager", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@reportingmanager", searchby_reportingmanager.Text);
                    }
                    if (string.IsNullOrEmpty(searchby_empname.Text))
                    {
                        cmd.Parameters.AddWithValue("@associatename", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@associatename", searchby_empname.Text);
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

        private void searchby_reportingmanager_SelectedIndexChanged(object sender, EventArgs e)
        {
            empname_basedon_reportingmanager_list();
            datagridview_display_overall();
        }

        private void searchby_empname_SelectedIndexChanged(object sender, EventArgs e)
        {
            datagridview_display_overall();
        }

        private void reset_Click(object sender, EventArgs e)
        {
            reset_overall();
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
                cmd.CommandText = "aom.usp_update_teamdetails_dotnet";
                cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@EmpName", empname.Text);
                cmd.Parameters.AddWithValue("@TeamNameID", teamname.SelectedValue);
                int iscore;
                if (checkbox_iscore.Checked == true)
                {
                    iscore = 1;
                }
                else
                {
                    iscore = 0;
                }
                cmd.Parameters.AddWithValue("@IsCore", iscore);

                //If conditions
                if (string.IsNullOrEmpty(empname.Text))
                {
                    MessageBox.Show("Please update Employee Name");
                }
                else if (string.IsNullOrEmpty(teamname.Text))
                {
                    MessageBox.Show("Please update Team Name");
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

        private void checkbox_iscore_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void homepage_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            HomePage obj_homepage = new HomePage();
            obj_homepage.Show();
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
                cmd.CommandText = "aom.usp_delete_teamdetails_dotnet";
                cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@EmpName", empname.Text);
                cmd.Parameters.AddWithValue("@TeamNameID", teamname.SelectedValue);
                
                //If conditions
                if (string.IsNullOrEmpty(empname.Text))
                {
                    MessageBox.Show("Please update Employee Name");
                }
                else if (string.IsNullOrEmpty(teamname.Text))
                {
                    MessageBox.Show("Please update Team Name");
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
    

    }
}
