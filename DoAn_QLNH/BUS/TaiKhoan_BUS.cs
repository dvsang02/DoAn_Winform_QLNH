using DTO;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TaiKhoan_BUS
    {
        public static List<TaiKhoan_DTO> GetTaiKhoan(string taikhoan, string matkhau)
        {
            return TaiKhoan_DAO.checkDangNhap(taikhoan, matkhau);
        }

        public static List<TaiKhoan_DTO> CheckEmailTrung(string email)
        {
            return TaiKhoan_DAO.checkEmailTrung(email);
        }

        public static List<TaiKhoan_DTO> CheckTaiKhoanTrung(string tenTK)
        {
            return TaiKhoan_DAO.checkTaiKhoanTrung(tenTK);
        }

        public static bool checkAccount(string ac)
        {
            return TaiKhoan_DAO.checkAccount(ac);
        }

        public static bool checkEmail(string email)
        {
            return TaiKhoan_DAO.checkEmail(email);
        }

        public static bool DangKy(TaiKhoan_DTO tk, string email)
        {
            return TaiKhoan_DAO.DangKy(tk, email);
        }

        public static List<TaiKhoan_DTO> checkEmailQuenPass(string email)
        {
            return TaiKhoan_DAO.checkEmailQuenPass(email);
        }

        public static string layMatKhau(string email)
        {
            return TaiKhoan_DAO.layMatKhau(email);
        }
    }
}
