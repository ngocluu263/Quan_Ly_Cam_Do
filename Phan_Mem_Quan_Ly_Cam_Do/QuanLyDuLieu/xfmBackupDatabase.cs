using System;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using Phan_Mem_Quan_Ly_Cam_Do.DoiTuong;
using System.IO;


namespace Phan_Mem_Quan_Ly_Cam_Do.QuanLyDuLieu
{
    public partial class xfmBackupDatabase : XtraForm
    {
        public xfmBackupDatabase()
        {
            InitializeComponent();
            
            txtBackupFolder.Text = Phan_Mem_Quan_Ly_Cam_Do.QuanLyDuLieu.DataController.DataMaker.GetLastDrive() + @"Backup";
            //var mySql = new SqlHelper(SqlHelper.ConnectString);
            //mySql.Extract();
            txtBackupFile.Text = SqlHelper.Database + @"." + Strings.Format(DateTime.Now, "dd.MM.yy hh.mm.bak");
        }

        private void BtnCloseClick(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnPathClick(object sender, EventArgs e)
        {
            var folderBrowserDialog=new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtBackupFolder.Text = folderBrowserDialog.SelectedPath;
            }

        }

        private void BtnStartClick(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtBackupFolder.Text))
            {
                Directory.CreateDirectory(txtBackupFolder.Text);
            }
            btnStart.Enabled = false;
            
            DataController.ConnectString = SqlHelper.ConnectionString;
            var backup = new DataController();
            lblMessage.Text = @"Đang Sao Lưu...";
            backup.BackupProcess += BackupBackupProcess;
            backup.BackupComplete += BackupBackupComplete;
            backup.BackupError += BackupBackupError;
            
            var newThread = new Thread(
                () => backup.BackupDataBase(SqlHelper.Database, txtBackupFolder.Text + "\\" + txtBackupFile.Text));
            newThread.Start();
        }

        void BackupBackupError(object sender, string message)
        {
            if (Bar.InvokeRequired)
            {
                var myRestore = new BackupErrorEventHander(BackupBackupError);
                Invoke(myRestore, new[] { sender, message });
            }
            else
            {
                XtraMessageBox.Show("Error:\n\t" + message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnStart.Enabled = true;
            }
        }

        void BackupBackupComplete(object sender, Microsoft.SqlServer.Management.Common.ServerMessageEventArgs e)
        {
            if (Bar.InvokeRequired)
            {
                var myRestore = new BackupCompleteEventHander(BackupBackupComplete);
                Invoke(myRestore, new[] { sender, e });
            }
            else
            {
                Bar.EditValue = 0;
                btnStart.Enabled = true;
                lblMessage.Text = @"Sao Lưu Thành Công";
            }
        }

        void BackupBackupProcess(object sender, Microsoft.SqlServer.Management.Smo.PercentCompleteEventArgs e)
        {
            if (Bar.InvokeRequired)
            {
                var myRestore = new BackupProcessEventHander(this.BackupBackupProcess);
                Invoke(myRestore, new[] { sender, e });
            }
            else
            {

                Bar.EditValue = e.Percent;
            }
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

        private void TxtBackupFolderPropertiesButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtBackupFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
}