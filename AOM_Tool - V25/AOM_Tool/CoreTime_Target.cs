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
    class CoreTime_Target
    {
        public void coretime_roster(DataTable dta,string intid,DateTime dateroster)
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
                cmd.CommandText = "select distinct convert(decimal(18,2),b.Contract_Hours) * (convert(decimal(18,2),[CoreTime%])/100) as CoreTime_Target from dbo.vw_roster_dotnet a inner join dbo.tbl_emp_details b on a.EmpID = b.[EmpId - New] where a.DateRoster = convert(date,@dateroster) and substring(a.intid,5,len(a.intid)) = @intid";
                cmd.Parameters.AddWithValue("@dateroster",dateroster);
                cmd.Parameters.AddWithValue("@intid",intid);
                sda.SelectCommand = cmd;
                dt = dta;
                sda.Fill(dta);
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void coretime_roster_final_verification(DataTable dta, string associatename, DateTime dateroster)
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
                cmd.CommandText = "select distinct convert(decimal(18,2),b.Contract_Hours) * (convert(decimal(18,2),[CoreTime%])/100) as CoreTime_Target from dbo.vw_roster_dotnet a inner join dbo.tbl_emp_details b on a.EmpID = b.[EmpId - New] where a.DateRoster = convert(date,@dateroster) and a.EmpName = @associatename";
                cmd.Parameters.AddWithValue("@dateroster", dateroster);
                cmd.Parameters.AddWithValue("@associatename", associatename);
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
