using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Phan_Mem_Quan_Ly_Cam_Do.DoiTuong;

namespace Phan_Mem_Quan_Ly_Cam_Do.QuanLyDuLieu
{
    public partial class xfmPhucHoi : DevExpress.XtraEditors.XtraForm
    {
        private readonly string _connectionString;
        private readonly string _database;

        public xfmPhucHoi()
        {
            InitializeComponent();
            //var mySql = new SqlHelper();

            _connectionString = String.Format("data source={0};integrated security=SSPI;Initial Catalog=master;", SqlHelper.Server);
            if (!SqlHelper.IsWindowsAuthentication)
                _connectionString = String.Format("server={0};user id={1};password={2};", SqlHelper.Server, SqlHelper.User, SqlHelper.Password);
            _database = SqlHelper.Database;
            txtCoSoDuLieu.Text=@"D:\Database\Perfect Software\Perfect Stock";
            txtCoSoDuLieu.Text = _database;
        }

        private void btnBackupFile_Click(object sender, EventArgs e)
        {
            var fileDialog=new OpenFileDialog
                        {
                           Filter = @"Backup File(*.bak)|*.bak|All File(*.*)|*.*",
                           FilterIndex = 0
                        };

            if (fileDialog.ShowDialog()== DialogResult.OK)
            {
               
                var cnn = new SqlConnection(_connectionString);
                cnn.Open();
                var conn = new ServerConnection(cnn);
                var myServer = new Server(conn);

                var currentDb = myServer.Databases[_database];
                if (currentDb != null)
                {
                    txtCoSoDuLieu.Text = _database;
                }
                txtTenTapTin.Text = fileDialog.FileName;
                cnn.Close();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var newThread = new Thread(() => PhucHoiDuLieu());
            newThread.Start();
            
        }

        private void PhucHoiDuLieu()
        {
            GetDatabaseInformation();

            var cnn = new SqlConnection(_connectionString);
            cnn.Open();
            var conn = new ServerConnection(cnn);
            var server = new Server(conn);
            cnn.Close();

            Restore restore = new Restore();

            //string fileName = string.Format("{0}\\{1}.bak", testFolder, databaseName);
            string fileName = txtTenTapTin.Text;

            restore.Devices.Add(new BackupDeviceItem(fileName, DeviceType.File));
            // Just give it a new name 

            //string destinationDatabaseName = string.Format("{0}_newly_restored", databaseName);
            string destinationDatabaseName = txtCoSoDuLieu.Text;

            // Go grab the current database’s logical names for the data 
            // and log files. For this example, we assume there are 1 for each. 

            //Database currentDatabase = server.Databases[databaseName]; 
            //string currentLogicalData_ = currentDatabase.FileGroups[0].Files[0].Name; 
            //string currentLogicalLog_ = currentDatabase.LogFiles[0].Name;



            // Now relocate the data and log files

            //RelocateFile reloData = new RelocateFile(currentLogicalData, string.Format(@"{0}\{1}.mdf", testFolder, destinationDatabaseName)); 
            //RelocateFile reloLog = new RelocateFile(currentLogicalLog, string.Format(@"{0}\{1}_Log.ldf", testFolder, destinationDatabaseName));

            RelocateFile reloData = new RelocateFile(currentLogicalData, physicalFileName);
            RelocateFile reloLog = new RelocateFile(currentLogicalLog, physicalFileLogName);

            //MessageBox.Show(fileName);
            //MessageBox.Show(destinationDatabaseName);

            //MessageBox.Show(currentLogicalData);
            //MessageBox.Show(currentLogicalLog);

            //MessageBox.Show(currentLogicalData_);
            //MessageBox.Show(currentLogicalLog_);

            //MessageBox.Show(string.Format(@"{0}\{1}.mdf", testFolder, destinationDatabaseName));
            //MessageBox.Show(string.Format(@"{0}\{1}_Log.ldf", testFolder, destinationDatabaseName));

            //MessageBox.Show(physicalFileName);
            //MessageBox.Show(physicalFileLogName);

            restore.RelocateFiles.Add(reloData);
            restore.RelocateFiles.Add(reloLog);
            restore.Database = destinationDatabaseName;
            restore.ReplaceDatabase = true;
            restore.PercentCompleteNotification = 10;
            restore.PercentComplete += restore_PercentComplete;
            //restore.Complete += restore_Complete; 

            restore.ReplaceDatabase = true;
            server.KillAllProcesses(txtCoSoDuLieu.Text);
            restore.SqlRestore(server);
            server.Refresh();
            MessageBox.Show("Quá trình hoàn tất");

            Bar.EditValue = 0;
            Bar.Refresh();

            //progressBar1.Value = 0;
            //progressBar1.Refresh();
        }

        public void restore_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            Bar.EditValue = e.Percent;
            Bar.Refresh();

            //progressBar1.Value = e.Percent;
            //progressBar1.Refresh();
        }

        private string physicalFileName = "";
        private string physicalFileLogName = "";
        private string currentLogicalData = "";
        private string currentLogicalLog = "";

        private void GetDatabaseInformation()
        {
            string strconn = SqlHelper.ConnectionString;
            SqlConnection con = new SqlConnection(strconn);
            con.Open();
            string sql =
            @"
                SELECT *
                FROM sysfiles s
            ";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            con.Close();

            if (dt.Rows.Count > 0)
            {
                physicalFileName = dt.Rows[0]["filename"].ToString();
                physicalFileLogName = dt.Rows[1]["filename"].ToString();

                currentLogicalData = dt.Rows[0]["name"].ToString();
                currentLogicalLog = dt.Rows[1]["name"].ToString();
            }
        }

        private void txtBackupFile_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fileDialog = new OpenFileDialog
            {
                Filter = @"Backup File(*.bak)|*.bak|All File(*.*)|*.*",
                FilterIndex = 0
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {

                var cnn = new SqlConnection(_connectionString);
                cnn.Open();
                var conn = new ServerConnection(cnn);
                var myServer = new Server(conn);

                var currentDb = myServer.Databases[_database];
                if (currentDb != null)
                {
                    txtCoSoDuLieu.Text = _database;
                }
                txtTenTapTin.Text = fileDialog.FileName;
                cnn.Close();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string duongdan_mdf = "";
        private string duongdan_ldf = "";

        private string ten_mdf = "";
        private string ten_ldf = "";

        private void GetFilePath()
        { 
            string sql =
            @"
                SELECT physical_name,
                       [name]
                FROM   sys.database_files
            ";

            var mySql = new SqlHelper();
            DataTable dt = new DataTable();
            dt = mySql.ExecuteDataTable(sql, null, null);

            if(dt.Rows.Count > 0)
            {
                duongdan_mdf = dt.Rows[0][0].ToString();
                duongdan_ldf = dt.Rows[1][0].ToString();

                ten_mdf = dt.Rows[0][1].ToString();
                ten_ldf = dt.Rows[1][1].ToString();
            }   
        }
    }
}