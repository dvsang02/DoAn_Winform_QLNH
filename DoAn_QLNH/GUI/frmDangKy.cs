using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS;
using DTO;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmDangKy : Form
    {
        TaiKhoan_DTO tk = new TaiKhoan_DTO();
        public frmDangKy()
        {
            InitializeComponent();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            tk.STaiKhoan = txtTenTaiKhoan.Text;
            tk.SMatKhau = txtMatKhau.Text;
            string xnmatkhau = txtXNMatKhau.Text;
            string email = txtEmail.Text;

            if(!TaiKhoan_BUS.checkAccount(tk.STaiKhoan)) { MessageBox.Show("Vui lòng nhập tên tài khoản dài 3 - 24 ký tự, với các ký tự chữ và số, chữ hoa và chữ thường!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if(!TaiKhoan_BUS.checkAccount(tk.SMatKhau)) { MessageBox.Show("Vui lòng nhập mật khẩu dài 3 - 24 ký tự, với các ký tự chữ và số, chữ hoa và chữ thường!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if(tk.SMatKhau != xnmatkhau) { MessageBox.Show("Xác nhận mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (!TaiKhoan_BUS.checkEmail(email)) { MessageBox.Show("Vui lòng nhập đúng định dạng email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (TaiKhoan_BUS.CheckTaiKhoanTrung(tk.STaiKhoan).Count != 0) { MessageBox.Show("Tên tài khoản này đã được đăng ký, vui lòng đăng ký tên tài khoản khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (TaiKhoan_BUS.CheckEmailTrung(email).Count != 0) { MessageBox.Show("Email này đã được đăng ký, vui lòng đăng ký email khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            bool check = TaiKhoan_BUS.DangKy(tk, email);

            if(check == true)
            {
                MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


        }
    }
}
