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
using Microsoft.SqlServer.Smo;
using Phan_Mem_Quan_Ly_Cam_Do.DoiTuong;

namespace Phan_Mem_Quan_Ly_Cam_Do.QuanLyDuLieu
{
    public partial class xfmRestoreDatabase : DevExpress.XtraEditors.XtraForm
    {
        private readonly string _connectionString;
        private readonly string _database;

        public xfmRestoreDatabase()
        {
            InitializeComponent();
            //var mySql = new SqlHelper();

            _connectionString = String.Format("data source={0};integrated security=SSPI;Initial Catalog=master;", SqlHelper.Server);
            if (!SqlHelper.IsWindowsAuthentication)
                _connectionString = String.Format("server={0};user id={1};password={2};", SqlHelper.Server, SqlHelper.User, SqlHelper.Password);
            _database = SqlHelper.Database;
            txtBackupFolder.Text=@"D:\Database\Perfect Software\Perfect Stock";
            txtBackupFolder.Text = _database;
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
                    txtBackupFolder.Text = _database;
                }
                txtBackupFile.Text = fileDialog.FileName;
                cnn.Close();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            
            btnStart.Enabled = false;
            //SYS_LOG.Insert("Cơ Sơ Dữ Liệu", "Phục Hồi", txtBackupFolder.Text + ", " + txtBackupFile.Text);
            DataController.ConnectString = SqlHelper.ConnectionString;
            var restore = new DataController();
            groupControl1.Text = @"Đang Phục Hồi...";
            restore.RestoreComplete += restore_RestoreComplete;
            restore.RestoreError += restore_RestoreError;
            restore.RestoreProcess += restore_RestoreProcess;
            var newThread = new Thread(() => restore.RestoreDatabase(txtBackupFile.Text, txtBackupFolder.Text));
            newThread.Start();
        }

        void restore_RestoreProcess(object sender, PercentCompleteEventArgs e)
        {
            if (this.Bar.InvokeRequired)
            {
                var myRestore =
                    new RestoreProcessEventHander(restore_RestoreProcess);
                Invoke(myRestore, new[] { sender, e });
            }
            else
            {

                Bar.EditValue = e.Percent;
            }
        }

        void restore_RestoreError(object sender, string Message)
        {
            if (Bar.InvokeRequired)
            {
                var myRestore = new RestoreErrorEventHander(restore_RestoreError);
                Invoke(myRestore, new[] { sender, Message });
            }
            else
            {
                XtraMessageBox.Show("Error:\n\t" + Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnStart.Enabled = true;
                Bar.EditValue = 0;
            }
        }

        void restore_RestoreComplete(object sender, ServerMessageEventArgs e)
        {
            if (Bar.InvokeRequired)
            {
                var myRestore = new RestoreCompleteEventHander(restore_RestoreComplete);
                Invoke(myRestore, new[] { sender, e });
            }
            else
            {
                Bar.EditValue = 0;
                btnStart.Enabled = true;
                groupControl1.Text = @"Phục Hồi Thành Công.";
                XtraMessageBox.Show("Phục Hồi Thành Công.\nĐể cập nhật mới dữ liệu, phần mềm sẽ khởi động lại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            return false;
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
                    txtBackupFolder.Text = _database;
                }
                txtBackupFile.Text = fileDialog.FileName;
                cnn.Close();
            }
        }
    }
}