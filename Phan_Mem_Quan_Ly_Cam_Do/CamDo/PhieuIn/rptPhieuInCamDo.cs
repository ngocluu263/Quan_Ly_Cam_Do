using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Phan_Mem_Quan_Ly_Cam_Do.DoiTuong;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Phan_Mem_Quan_Ly_Cam_Do.CamDo.PhieuIn
{
    public partial class rptPhieuInCamDo : DevExpress.XtraReports.UI.XtraReport
    {
        string thong_tin_rut_gon_khach_hang = "";
        string thong_tin_rut_gon_tai_san = "";
        public rptPhieuInCamDo()
        {
            InitializeComponent();
        }

        public rptPhieuInCamDo(string maphieu, bool inthongtinrutgon)
        {
            InitializeComponent();

            Ten_Tiem.Value = SqlHelper.TenTiem;
            BenB.Value = string.IsNullOrEmpty(SqlHelper.BienNhanCamDoBenB) ? "....................................................................." : SqlHelper.BienNhanCamDoBenB;
            Dia_Chi_Tiem.Value = SqlHelper.DiaChi;
            Dien_Thoai_Tiem.Value = SqlHelper.DienThoai;

            DataSet ds = new DataSet();
            ds = dsCamDo1.Copy();
            ds.Tables[dsCamDo1.CHUNG_TU_CHI_TIET.TableName].Rows.Clear();

            var database = new DB_Quan_Ly_Cam_DoDataContext(SqlHelper.ConnectionString);

            var chungtu = (from ct in database.CHUNG_TUs
                          where ct.Ma_Chung_Tu == maphieu
                           select ct).FirstOrDefault();

            if (chungtu != null)
            {
                Ma_Chung_Tu.Value = chungtu.Ma_Chung_Tu;
                So.Value = chungtu.So;
                Lien.Value = chungtu.Lien;
                Ngay.Value = chungtu.Ngay;
                Ten_Khach_Hang.Value = chungtu.Ten_Khach_Hang;
                So_CMND.Value = string.IsNullOrEmpty(chungtu.So_CMND) ? "......................................" : chungtu.So_CMND;
                Ngay_Cap_CMND.Value = string.IsNullOrEmpty(chungtu.Ngay_Cap_CMND) ? "......................................" : chungtu.Ngay_Cap_CMND;
                Noi_Cap_CMND.Value = string.IsNullOrEmpty(chungtu.Noi_Cap) ? "..................................." : chungtu.Noi_Cap;
                Dia_Chi.Value = string.IsNullOrEmpty(chungtu.Dia_Chi) ? "......................................" : chungtu.Dia_Chi;
                So_Dien_Thoai.Value = string.IsNullOrEmpty(chungtu.So_Dien_Thoai) ? "......................................" : chungtu.So_Dien_Thoai;
                So_Tien_Cam.Value = chungtu.So_Tien_Cam;
                So_Tien_Cam_Bang_Chu.Value = TinhToan.DocChu(String.Format("{0:##,##0}",chungtu.So_Tien_Cam));
                Tu_Ngay.Value = string.IsNullOrEmpty(chungtu.Tu_Ngay) ? ".........................." : chungtu.Tu_Ngay;
                Den_Ngay.Value = string.IsNullOrEmpty(chungtu.Den_Ngay) ? ".........................." : chungtu.Den_Ngay;
                Lai_Suat_Ngay.Value = chungtu.Lai_Suat_Ngay;
                Lai_Suat_Thang.Value = chungtu.Lai_Suat_Thang;
                thong_tin_rut_gon_khach_hang = "";
                thong_tin_rut_gon_khach_hang += "Mã: " + chungtu.Ma_Chung_Tu + " - Số: " + chungtu.So + " - Ngày: " + String.Format("{0:dd/MM/yyyy}", chungtu.Ngay) + "\n";
                thong_tin_rut_gon_khach_hang += "Tên: " + chungtu.Ten_Khach_Hang + "\n";
                thong_tin_rut_gon_khach_hang += "Số Tiền: " + String.Format("{0:##,##0.###}", chungtu.So_Tien_Cam) + "\n";
                
            }

            string[] myPara = { "@Ma_Chung_Tu" };
            object[] myValue = { maphieu };

            string sql =
            @"
                SELECT *
                FROM   CHUNG_TU_CHI_TIET ctct
                WHERE  ctct.Ma_Chung_Tu = @Ma_Chung_Tu
            ";

            var mySql = new SqlHelper();
            ds.Tables[dsCamDo1.CHUNG_TU_CHI_TIET.TableName].Merge(mySql.ExecuteDataTable(sql, myPara, myValue));
            dsCamDo1.Merge(ds);

            if (inthongtinrutgon)
            {
                if (ds != null)
                {       
                    for (int i = 0; i < ds.Tables[dsCamDo1.CHUNG_TU_CHI_TIET.TableName].Rows.Count; i++)
                    {
                        thong_tin_rut_gon_tai_san += "- " + ds.Tables[dsCamDo1.CHUNG_TU_CHI_TIET.TableName].Rows[i]["Ten_Tai_San"].ToString() + " - " + ds.Tables[dsCamDo1.CHUNG_TU_CHI_TIET.TableName].Rows[i]["Loai_Vang"].ToString() + " - " + ds.Tables[dsCamDo1.CHUNG_TU_CHI_TIET.TableName].Rows[i]["Trong_Luong"].ToString();
                        if (i < ds.Tables[dsCamDo1.CHUNG_TU_CHI_TIET.TableName].Rows.Count - 1)
                        {
                            thong_tin_rut_gon_tai_san += "\n";
                        }
                    }
                }
                Thong_Tin_Rut_Gon_Khach_Hang.Value = thong_tin_rut_gon_khach_hang;
                Thong_Tin_Rut_Gon_Tai_San.Value = thong_tin_rut_gon_tai_san;
                xrtbThongTinRutGon.Visible = true;
            }
            RequestParameters = false;
        }

    }
}
