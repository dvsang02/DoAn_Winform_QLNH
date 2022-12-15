using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TaiKhoan_DTO
    {
        private string sTaiKhoan;
        private string sMatKhau;

        public TaiKhoan_DTO()
        {
        }

        public TaiKhoan_DTO(string sTaiKhoan, string sMatKhau)
        {
            this.sTaiKhoan = sTaiKhoan;
            this.sMatKhau = sMatKhau;
        }

        public string STaiKhoan { get => sTaiKhoan; set => sTaiKhoan = value; }
        public string SMatKhau { get => sMatKhau; set => sMatKhau = value; }
    }
}
