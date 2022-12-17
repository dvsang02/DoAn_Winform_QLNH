using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using DTO;

namespace DAO
{
    public class TaiKhoan_DAO
    {
        static SqlConnection conn;
        public TaiKhoan_DAO()
        {
        }

        public static List<TaiKhoan_DTO> taiKhoans(string query)
        {
            
            SqlDataReader dataReader;
            List<TaiKhoan_DTO> taiKhoans = new List<TaiKhoan_DTO>();
            using(SqlConnection sqlConnection = DataProvider.MoKetNoi())
            {
                dataReader = DataProvider.ThucThiTruyVanReader(query, sqlConnection);
                while(dataReader.Read())
                {
                    taiKhoans.Add(new TaiKhoan_DTO(dataReader.GetString(1), dataReader.GetString(2)));
                }
                DataProvider.DongKetNoi(sqlConnection);
            }
            return taiKhoans;
        }

        public static List<TaiKhoan_DTO> checkDangNhap(string tentk, string matkhau)
        {
            List<TaiKhoan_DTO> taiKhoans = new List<TaiKhoan_DTO>();
            string query = "select * from TaiKhoan where sTaiKhoan = '" + tentk + "' and sMatKhau = '" + matkhau + "'";

            taiKhoans = TaiKhoan_DAO.taiKhoans(query);

            return taiKhoans;
        }

        public static List<TaiKhoan_DTO> checkTaiKhoanTrung(string tenTaiKhoan)
        {
            List<TaiKhoan_DTO> taiKhoans = new List<TaiKhoan_DTO>();
            string query = "select * from TaiKhoan where sTaiKhoan = '" + tenTaiKhoan + "'";

            taiKhoans = TaiKhoan_DAO.taiKhoans(query);

            return taiKhoans;
        }

        public static List<TaiKhoan_DTO> checkEmailTrung(string email)
        {
            List<TaiKhoan_DTO> taiKhoans = new List<TaiKhoan_DTO>();
            string query = "select * from TaiKhoan where Email = '" + email + "'";

            taiKhoans = TaiKhoan_DAO.taiKhoans(query);

            return taiKhoans;
        }

        public static bool checkAccount(string ac)
        {
            return Regex.IsMatch(ac, "^[a-zA-Z0-9]{3,24}$");
        }

        public static bool checkEmail(string em)
        {
            return Regex.IsMatch(em, "^\\S+@\\S+\\.\\S+$");
        }

        public static bool DangKy(TaiKhoan_DTO taiKhoan, string email)
        {
            string chuoiTruyVan = string.Format("insert into TaiKhoan(sTaiKhoan, sMatKhau, Email, FK_iMaQuyen) values ('" + taiKhoan.STaiKhoan+"', '"+taiKhoan.SMatKhau+"', '"+email+"', 2)");
            conn = DataProvider.MoKetNoi();
            try
            {
                DataProvider.ThucThiTruyVanNonQuery(chuoiTruyVan, conn);
                DataProvider.DongKetNoi(conn);
                return true;
            }
            catch (Exception)
            {
                DataProvider.DongKetNoi(conn);
                return false;
            }
        }

        public static List<TaiKhoan_DTO> checkEmailQuenPass(string email)
        {
            List<TaiKhoan_DTO> taiKhoans = new List<TaiKhoan_DTO>();
            string query = "select * from TaiKhoan where Email = '"+email+"'";

            taiKhoans = TaiKhoan_DAO.taiKhoans(query);

            return taiKhoans;
        }

        public static string layMatKhau(string email)
        {
            string query = "select * from TaiKhoan where Email = '" + email + "'";
            return TaiKhoan_DAO.taiKhoans(query)[0].SMatKhau;
        }

        public static List<TaiKhoanNV_DTO> LoadTaiKhoan()
        {
            string chuoiTruyVan = "select sMaTK, TenNhanVien, sTaiKhoan, sMatKhau, Email, sTenQuyen from TaiKhoan, NhanVien, Quyen where TaiKhoan.IDNhanVien = NhanVien.ID and TaiKhoan.FK_iMaQuyen = Quyen.iMaQuyen";
            conn = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.LayDataTable(chuoiTruyVan, conn);
            if (dt.Rows.Count == 0)
                return null;

            List<TaiKhoanNV_DTO> taiKhoanNhanViens = new List<TaiKhoanNV_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TaiKhoanNV_DTO taiKhoan = new TaiKhoanNV_DTO();

                taiKhoan.SMaTK = int.Parse(dt.Rows[i]["sMaTK"].ToString());
                taiKhoan.TenNhanVien1 = dt.Rows[i]["TenNhanVien"].ToString();
                taiKhoan.STaiKhoan = dt.Rows[i]["sTaiKhoan"].ToString();
                taiKhoan.SMatKhau = dt.Rows[i]["sMatKhau"].ToString();
                taiKhoan.Email1 = dt.Rows[i]["Email"].ToString();
                taiKhoan.FK_iMaQuyen1 = dt.Rows[i]["sTenQuyen"].ToString();

                taiKhoanNhanViens.Add(taiKhoan);
            }
            DataProvider.DongKetNoi(conn);
            return taiKhoanNhanViens;
        }

        public static DataTable CbbTenNV()
        {
            DataTable table = new DataTable();
            conn = DataProvider.MoKetNoi();
            string chuoiTruyVan = "Select * from NhanVien";
            table = DataProvider.LayDataTable(chuoiTruyVan, conn);
            DataProvider.DongKetNoi(conn);
            return table;
        }

        public static DataTable CbbQuyen()
        {
            DataTable table = new DataTable();
            conn = DataProvider.MoKetNoi();
            string chuoiTruyVan = "Select * from Quyen";
            table = DataProvider.LayDataTable(chuoiTruyVan, conn);
            DataProvider.DongKetNoi(conn);
            return table;
        }

        public static bool ThemTaiKhoan(TaiKhoanNV_DTO taiKhoan)
        {
            string chuoiTruyVan = string.Format("insert into TaiKhoan(sTaiKhoan, sMatKhau, Email, FK_iMaQuyen, IDNhanVien) Values ('{0}', '{1}', '{2}', {3}, {4})", taiKhoan.STaiKhoan, taiKhoan.SMatKhau, taiKhoan.Email1, taiKhoan.FK_iMaQuyen1, taiKhoan.TenNhanVien1);
            conn = DataProvider.MoKetNoi();
            try
            {
                DataProvider.ThucThiTruyVanNonQuery(chuoiTruyVan, conn);
                DataProvider.DongKetNoi(conn);
                return true;
            }
            catch (Exception)
            {
                DataProvider.DongKetNoi(conn);
                return false;
            }
        }

        public static bool CapNhatTK(TaiKhoanNV_DTO taiKhoan)
        {
            string chuoiTruyVan = string.Format("update TaiKhoan set sTaiKhoan = '{0}', sMatKhau = '{1}', Email = '{2}', FK_iMaQuyen = {3}, IDNhanVien = {4} where sMaTK = {5}", taiKhoan.STaiKhoan, taiKhoan.SMatKhau, taiKhoan.Email1, taiKhoan.FK_iMaQuyen1, taiKhoan.TenNhanVien1, taiKhoan.SMaTK);
            conn = DataProvider.MoKetNoi();
            try
            {
                DataProvider.ThucThiTruyVanNonQuery(chuoiTruyVan, conn);
                DataProvider.DongKetNoi(conn);
                return true;
            }
            catch (Exception)
            {
                DataProvider.DongKetNoi(conn);
                return false;
            }
        }

        public static bool XoaTaiKhoan(TaiKhoanNV_DTO taiKhoan)
        {
            // chuỗi truy vấn xóa món ăn
            string chuoiTruyVan = string.Format("Delete from TaiKhoan Where sMaTK = {0}", taiKhoan.SMaTK);
            conn = DataProvider.MoKetNoi();
            try
            {
                DataProvider.ThucThiTruyVanNonQuery(chuoiTruyVan, conn);
                DataProvider.DongKetNoi(conn);
                return true;
            }
            catch (Exception)
            {
                DataProvider.DongKetNoi(conn);
                return false;
            }
        }

        public static bool CheckQuyen(string tenTaiKhoan)
        {
            string chuoiTruyVan = string.Format("select sTenQuyen from TaiKhoan, Quyen where TaiKhoan.FK_iMaQuyen = Quyen.iMaQuyen and sTaiKhoan = '{0}'", tenTaiKhoan);
            conn = DataProvider.MoKetNoi();
            string quyen = DataProvider.ThucThiTruyVanScalar(chuoiTruyVan, conn);
            if (quyen == "Quản Lý")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
