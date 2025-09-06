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
    public partial class HomePage : Form
    {
        public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        //public string connectionstringtxt = ConfigurationManager.ConnectionStrings["KYC_RDC_Workflow.Properties.Settings.DRDConnectionString"].ConnectionString;
        //public string connectionstringtxt = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();

        public HomePage()
        {
            InitializeComponent();
        }

        private void rtm_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            TimeTracker obj_timetracker = new TimeTracker();
            obj_timetracker.Show();
        }

        private void verification_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Final_Verification obj_final = new Final_Verification();
            obj_final.Show();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            adminlevel_check_list();
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
                obj_empdetails.emp_details_adminlevel_check(dtaa, Environment.UserName.ToString());
                accesscheck.DataSource = dtaa;
                accesscheck.DisplayMember = "AOMTool_Access";
                conn.Close();
                accesscheck.Visible = false;

                if (accesscheck.Text == "Admin")
                {
                    finalverification.Enabled = true;
                    //reports.Enabled = true;
                    amend_teamdetails.Enabled = true;
                }
                else if (accesscheck.Text == "Admin_Associate")
                {
                    finalverification.Enabled = true;
                    //reports.Enabled = true;
                    amend_teamdetails.Enabled = true;
                }
                else
                {
                    finalverification.Enabled = false;
                    //reports.Enabled = false;
                    amend_teamdetails.Enabled = false;
                }

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        private void reports_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://app.powerbi.com/groups/81c3ab7d-0a2a-46f2-b54f-38eb239011a1/reports/fdab6a4d-e182-49c6-8f02-eb20502017bb/ReportSection31a41de679b2bcefa277?experience=power-bi");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
        }

        private void amend_teamdetails_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Amend_TeamDetails obj_teamdetails = new Amend_TeamDetails();
            obj_teamdetails.Show();
        }
    }
}
