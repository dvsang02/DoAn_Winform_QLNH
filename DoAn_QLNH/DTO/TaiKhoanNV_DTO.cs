using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TaiKhoanNV_DTO
    {
        private int sMaTK;
        private string TenNhanVien;
        private string sTaiKhoan;
        private string sMatKhau;
        private string Email;
        private string FK_iMaQuyen;


        public TaiKhoanNV_DTO()
        {
        }

        public int SMaTK { get => sMaTK; set => sMaTK = value; }
        public string TenNhanVien1 { get => TenNhanVien; set => TenNhanVien = value; }
        public string STaiKhoan { get => sTaiKhoan; set => sTaiKhoan = value; }
        public string SMatKhau { get => sMatKhau; set => sMatKhau = value; }
        public string FK_iMaQuyen1 { get => FK_iMaQuyen; set => FK_iMaQuyen = value; }
        public string Email1 { get => Email; set => Email = value; }
    }
}
