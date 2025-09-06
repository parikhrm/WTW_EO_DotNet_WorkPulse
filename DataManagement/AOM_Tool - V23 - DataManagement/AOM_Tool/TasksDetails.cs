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
    class TasksDetails
    {
        public void tasks_details_overall(DataTable dta)
        {
            //string connectionstringtxt = "Data Source=MUM1-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
            string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
            //string connectionstringtxt = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();

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
                cmd.CommandText = "select * from aom.tbl_tasks_details_dotnet with(nolock) where isdeleted = 0 order by ActivityName";
                sda.SelectCommand = cmd;
                dt = dta;
                sda.Fill(dta);
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void tasktype_list(DataTable dta)
        {
            //string connectionstringtxt = "Data Source=MUM1-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
            string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
            //string connectionstringtxt = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();

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
                cmd.CommandText = "select distinct TaskType from aom.tbl_tasks_details_dotnet with(nolock) where isdeleted = 0 and TaskType is not null and tasktype not in ('Log Off','Log In') order by TaskType";
                sda.SelectCommand = cmd;
                dt = dta;
                sda.Fill(dta);
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void tasktype_rtm_verification_list(DataTable dta)
        {
            //string connectionstringtxt = "Data Source=MUM1-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
            string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
            //string connectionstringtxt = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();

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
                cmd.CommandText = "select distinct TaskType from aom.tbl_tasks_details_dotnet with(nolock) where isdeleted = 0 and TaskType is not null order by TaskType";
                sda.SelectCommand = cmd;
                dt = dta;
                sda.Fill(dta);
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void teamname_list(DataTable dta, string tasktypeparam)
        {
            //string connectionstringtxt = "Data Source=MUM1-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
            string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
            //string connectionstringtxt = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();

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
                cmd.CommandText = "select distinct TeamName from aom.tbl_tasks_details_dotnet with(nolock) where isdeleted = 0 and TeamName is not null and TaskType = @tasktype order by TeamName";
                cmd.Parameters.AddWithValue("@tasktype", tasktypeparam);
                sda.SelectCommand = cmd;
                dt = dta;
                sda.Fill(dta);
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void activityname_list(DataTable dta, string tasktypeparam, string teamnameparam)
        {
            //string connectionstringtxt = "Data Source=MUM1-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
            string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
            //string connectionstringtxt = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();

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
                cmd.CommandText = "select distinct ActivityName,ID from aom.tbl_tasks_details_dotnet with(nolock) where isdeleted = 0 and ActivityName is not null and TaskType = @tasktype and TeamName = @teamname order by ActivityName";
                cmd.Parameters.AddWithValue("@tasktype", tasktypeparam);
                cmd.Parameters.AddWithValue("@teamname",teamnameparam);
                sda.SelectCommand = cmd;
                dt = dta;
                sda.Fill(dta);
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void activityname_list_associate(DataTable dta, string tasktypeparam, string teamnameparam)
        {
            //string connectionstringtxt = "Data Source=MUM1-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
            string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
            //string connectionstringtxt = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();

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
                cmd.CommandText = "select distinct ActivityName,ID from aom.tbl_tasks_details_dotnet with(nolock) where isdeleted = 0 and ActivityName is not null /*and id <> 109*/ and TaskType = @tasktype and TeamName = @teamname order by ActivityName";
                cmd.Parameters.AddWithValue("@tasktype", tasktypeparam);
                cmd.Parameters.AddWithValue("@teamname", teamnameparam);
                sda.SelectCommand = cmd;
                dt = dta;
                sda.Fill(dta);
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }
        

        public void activityname_noncore_list(DataTable dta, string tasktypeparam)
        {
            //string connectionstringtxt = "Data Source=MUM1-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
            string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
            //string connectionstringtxt = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();

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
                cmd.CommandText = "select distinct ActivityName,ID from aom.tbl_tasks_details_dotnet with(nolock) where isdeleted = 0 and ActivityName is not null and TaskType = @tasktype and tasktype <> 'Core' order by ActivityName";
                cmd.Parameters.AddWithValue("@tasktype", tasktypeparam);
                sda.SelectCommand = cmd;
                dt = dta;
                sda.Fill(dta);
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void activityname_datagridview_list(DataTable dta/*, string tasktypeparam, string teamnameparam*/)
        {
            //string connectionstringtxt = "Data Source=MUM1-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
            string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
            //string connectionstringtxt = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();

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
                //cmd.CommandText = "select distinct ActivityName,ID from aom.tbl_tasks_details_dotnet with(nolock) where isdeleted = 0 and ActivityName is not null and TaskType = @tasktype and TeamName = @teamname  order by ActivityName";
                //cmd.Parameters.AddWithValue("@tasktype", tasktypeparam);
                //cmd.Parameters.AddWithValue("@teamname", teamnameparam);

                cmd.CommandText = "select distinct ActivityName,ID from aom.tbl_tasks_details_dotnet with(nolock) where isdeleted = 0 and ActivityName is not null order by ActivityName";

                sda.SelectCommand = cmd;
                dt = dta;
                sda.Fill(dta);
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void teamname_finalverification_list(DataTable dta)
        {
            //string connectionstringtxt = "Data Source=MUM1-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
            string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
            //string connectionstringtxt = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();

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
                cmd.CommandText = "select distinct TeamName,TeamNameID from aom.tbl_tasks_details_dotnet with(nolock) where isdeleted = 0 and TeamName is not null and TeamName not in ('Break','Diverted','Downtime','Log In','Log Off') order by TeamName";
                sda.SelectCommand = cmd;
                dt = dta;
                sda.Fill(dta);
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void tasktype_rtm_verification_addtask_list(DataTable dta)
        {
            //string connectionstringtxt = "Data Source=MUM1-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
            string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
            //string connectionstringtxt = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();

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
                cmd.CommandText = "select distinct TaskType from aom.tbl_tasks_details_dotnet with(nolock) where isdeleted = 0 and TaskType is not null  and tasktype not in ('Log Off') order by TaskType";
                sda.SelectCommand = cmd;
                dt = dta;
                sda.Fill(dta);
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }



    }
}
