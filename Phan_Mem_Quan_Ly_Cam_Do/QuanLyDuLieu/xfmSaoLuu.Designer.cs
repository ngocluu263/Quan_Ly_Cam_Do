namespace Phan_Mem_Quan_Ly_Cam_Do.QuanLyDuLieu
{
    partial class xfmSaoLuu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xfmSaoLuu));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblMessage = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtTenFile = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.Bar = new DevExpress.XtraEditors.ProgressBarControl();
            this.btnThucHien = new DevExpress.XtraEditors.SimpleButton();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.txtDuongDan = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDuongDan.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Appearance.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblMessage.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblMessage.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblMessage.Location = new System.Drawing.Point(43, 15);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(337, 14);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Sao lưu dự phòng dữ liệu.";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 75);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Tên tập tin";
            // 
            // txtTenFile
            // 
            this.txtTenFile.Location = new System.Drawing.Point(88, 72);
            this.txtTenFile.Name = "txtTenFile";
            this.txtTenFile.Size = new System.Drawing.Size(337, 20);
            this.txtTenFile.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 108);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(54, 13);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Đường dẫn";
            // 
            // Bar
            // 
            this.Bar.Location = new System.Drawing.Point(87, 43);
            this.Bar.Name = "Bar";
            this.Bar.Properties.ShowTitle = true;
            this.Bar.Size = new System.Drawing.Size(337, 20);
            this.Bar.TabIndex = 6;
            // 
            // btnThucHien
            // 
            this.btnThucHien.Image = ((System.Drawing.Image)(resources.GetObject("btnThucHien.Image")));
            this.btnThucHien.Location = new System.Drawing.Point(268, 131);
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.Size = new System.Drawing.Size(75, 22);
            this.btnThucHien.TabIndex = 7;
            this.btnThucHien.Text = "Thực Hiện";
            this.btnThucHien.Click += new System.EventHandler(this.btnThucHien_Click);
            // 
            // btnDong
            // 
            this.btnDong.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.Image")));
            this.btnDong.Location = new System.Drawing.Point(349, 131);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 22);
            this.btnDong.TabIndex = 8;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.BtnCloseClick);
            // 
            // txtDuongDan
            // 
            this.txtDuongDan.Location = new System.Drawing.Point(88, 104);
            this.txtDuongDan.Name = "txtDuongDan";
            this.txtDuongDan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("txtDuongDan.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", "Browse", null, true)});
            this.txtDuongDan.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.TxtBackupFolderPropertiesButtonClick);
            this.txtDuongDan.Size = new System.Drawing.Size(337, 22);
            this.txtDuongDan.TabIndex = 4;
            this.txtDuongDan.TabStop = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 46);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 13);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Tiến trình";
            // 
            // xfmSaoLuu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 164);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnThucHien);
            this.Controls.Add(this.Bar);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtTenFile);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtDuongDan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "xfmSaoLuu";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sao lưu dữ liệu";
            ((System.ComponentModel.ISupportInitialize)(this.txtTenFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDuongDan.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblMessage;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtTenFile;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ProgressBarControl Bar;
        private DevExpress.XtraEditors.SimpleButton btnThucHien;
        private DevExpress.XtraEditors.SimpleButton btnDong;
        private DevExpress.XtraEditors.ButtonEdit txtDuongDan;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}