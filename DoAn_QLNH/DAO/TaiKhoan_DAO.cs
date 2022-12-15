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
    }
}
