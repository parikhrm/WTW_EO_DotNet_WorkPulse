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
    public partial class RTM_ExcelUpload : Form
    {
        //public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        //public string connectionstringtxt = ConfigurationManager.ConnectionStrings["KYC_RDC_Workflow.Properties.Settings.DRDConnectionString"].ConnectionString;
        //public string connectionstringtxt = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();

        public RTM_ExcelUpload()
        {
            InitializeComponent();
        }

        private void RTM_ExcelUpload_Load(object sender, EventArgs e)
        {
            datagridview_display_overall();
        }

        private void homepage_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            HomePage obj_homepage = new HomePage();
            obj_homepage.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(excelsheetname.Text))
            {
                MessageBox.Show("Please enter excel sheet name");
            }
            else
            {
                string messsage = "Do you want to upload these records?";
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
                        button3.Enabled = true;
                        //string pathconn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelfilepath.Text + ";Extended Properties=\"Excel 8.0;HDR=Yes;\";";
                        //OleDbConnection conne = new OleDbConnection(pathconn);
                        //OleDbDataAdapter da = new OleDbDataAdapter("select * from [" + excelsheetname.Text + "$]", conne);
                        //DataTable dt = new DataTable();
                        //da.Fill(dt);
                        //dataGridView1.DataSource = dt;

                        //String name = "Items";
                        String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                        excelfilepath.Text +
                                        ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

                        OleDbConnection con = new OleDbConnection(constr);
                        OleDbCommand oconn = new OleDbCommand("Select * From [" + excelsheetname.Text + "$]", con);
                        con.Open();

                        OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                        DataTable data = new DataTable();
                        sda.Fill(data);
                        dataGridView1.DataSource = data;
                    }
                    catch (Exception ab)
                    {
                        MessageBox.Show("Rows Uploaded Unsuccessfully");
                        MessageBox.Show("Error Generated Details :" + ab.ToString());
                    }
                }
                else
                {
                    excelfilepath.Focus();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.excelfilepath.Text = openFileDialog1.FileName;
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
                cmd.CommandText = "select  TaskType,TeamName,ActivityName,Volumes,EmpName,LoginDate,StartDateTime,EndDateTime,Comments from aom.tbl_excelupload_daily_dotnet with(nolock)";
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



        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                string messsage = "Do you want to upload these records in the final table?";
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
                        conn.ConnectionString = connectionstringtxt;
                        cmd.Connection = conn;
                        conn.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "truncate table aom.tbl_excelupload_daily_dotnet";
                        cmd.ExecuteNonQuery();
                        

                        //new code
                        string pathconn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                        excelfilepath.Text +
                                        ";Extended Properties='Excel 12.0 XML;HDR=YES;';";
                        OleDbConnection conne = new OleDbConnection(pathconn);
                        OleDbDataAdapter da = new OleDbDataAdapter("select * from [" + excelsheetname.Text + "$]", conne);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                      
                        //using (SqlBulkCopy sqlbulkcopy = new SqlBulkCopy(conn))
                        //{
                        //    sqlbulkcopy.DestinationTableName = "aom.tbl_excelupload_daily_dotnet";
                        //    sqlbulkcopy.ColumnMappings.Add("TaskType", "TaskType");
                        //    sqlbulkcopy.ColumnMappings.Add("TeamName", "TeamName");
                        //    sqlbulkcopy.ColumnMappings.Add("ActivityName", "ActivityName");
                        //    sqlbulkcopy.ColumnMappings.Add("Volumes", "Volumes");
                        //    sqlbulkcopy.ColumnMappings.Add("EmpName", "EmpName");
                        //    sqlbulkcopy.ColumnMappings.Add("LoginDate", "LoginDate");
                        //    sqlbulkcopy.ColumnMappings.Add("StartDateTime", "StartDateTime");
                        //    sqlbulkcopy.ColumnMappings.Add("EndDateTime", "EndDateTime");
                        //    sqlbulkcopy.ColumnMappings.Add("Comments", "Comments");
                        //    conn.Open();
                        //    sqlbulkcopy.WriteToServer(dt);
                        //    conn.Close();
                        //}

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            cmd.CommandText = "insert into aom.tbl_excelupload_daily_dotnet (TaskType,TeamName,ActivityName,Volumes,EmpName,LoginDate,StartDateTime,EndDateTime,Comments,UploadDateTime,UploadedBy,MachineName) values('" + row.Cells["txtTaskType"].Value + "','" + row.Cells["txtTeamName"].Value + "','" + row.Cells["txtActivityName"].Value + "','" + row.Cells["txtVolumes"].Value + "','" + row.Cells["txtEmpName"].Value + "','" + Convert.ToDateTime(row.Cells["txtLoginDate"].Value) + "','" + Convert.ToDateTime(row.Cells["txtStartDateTime"].Value) + "','" + Convert.ToDateTime(row.Cells["txtEndDateTime"].Value) + "','" + row.Cells["txtComments"].Value + "','" + DateTime.Now.ToLocalTime() + "', '" + Environment.UserName.ToString() + "','" + Environment.MachineName.ToString() + "')";
                            cmd.ExecuteNonQuery();
                        }
                        //conn.Close();

                        

                        //conn.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Clear();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "aom.usp_excelupload_daily_dotnet";
                        cmd.Parameters.AddWithValue("@uploadedby", Environment.UserName.ToString());
                        //cmd.Parameters.AddWithValue("@uploaddatetime", DateTime.Now.ToLocalTime());
                        //cmd.Parameters.AddWithValue("@machinename", Environment.MachineName.ToString());
                        cmd.Parameters.Add("@message", SqlDbType.NVarChar, 2000);
                        cmd.Parameters["@message"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        string uploadmessage = cmd.Parameters["@message"].Value.ToString();
                        MessageBox.Show("" + uploadmessage.ToString());
                        cmd.Parameters.Clear();
                        datagridview_display_overall();
                        conn.Close();

                        
                    }

                    catch (Exception ab)
                    {
                        MessageBox.Show("Rows uploaded unsuccessfully into final table");
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                        datagridview_display_overall();
                        MessageBox.Show("Error Generated Details :" + ab.ToString());
                    }
                }
                else
                {
                    excelfilepath.Focus();
                }
            }
            else
            {
                MessageBox.Show("There are no records to be uploaded");
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            datagridview_display_overall();
        }
    }
}
