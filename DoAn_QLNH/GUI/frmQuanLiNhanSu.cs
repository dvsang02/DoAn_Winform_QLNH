using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using System.Text.RegularExpressions;
using DTO;
using BUS;

namespace DoAn_Winform
{
    public partial class frmQuanLiNhanSu : Form
    {
        public frmQuanLiNhanSu()
        {
            InitializeComponent();
        }

        private void frmQuanLiNhanSu_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
            LoadTaiKhoan();
            LoadCbbTenNV();
            LoadCbbQuyen();
        }

        List<NhanVien_DTO> danhSachNhanVien;
        private void LoadNhanVien()
        {
            danhSachNhanVien = NhanVien_BUS.LoadNhanVien();
            dgvDanhSachNhanVien.DataSource = danhSachNhanVien;

            if (danhSachNhanVien == null)
                return;

            dgvDanhSachNhanVien.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
            dgvDanhSachNhanVien.Columns["TenNhanVien"].HeaderText = "Tên Nhân Viên";
            dgvDanhSachNhanVien.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
            dgvDanhSachNhanVien.Columns["GioiTinh"].HeaderText = "Giới Tính";
            dgvDanhSachNhanVien.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
            dgvDanhSachNhanVien.Columns["ChucVu"].HeaderText = "Chức Vụ";
            dgvDanhSachNhanVien.Columns["Luong"].HeaderText = "Lương";
            dgvDanhSachNhanVien.Columns["DiaChi"].HeaderText = "Địa Chỉ";

            dgvDanhSachNhanVien.Columns["ID"].Width = 50;
            dgvDanhSachNhanVien.Columns["MaNhanVien"].Width = 100;
            dgvDanhSachNhanVien.Columns["TenNhanVien"].Width = 200;
            dgvDanhSachNhanVien.Columns["NgaySinh"].Width = 120;
            dgvDanhSachNhanVien.Columns["GioiTinh"].Width = 70;
            dgvDanhSachNhanVien.Columns["SoDienThoai"].Width = 150;
            dgvDanhSachNhanVien.Columns["ChucVu"].Width = 150;
            dgvDanhSachNhanVien.Columns["Luong"].Width = 150;
            dgvDanhSachNhanVien.Columns["DiaChi"].Width = 285;
        }

        //----------------------------- thêm nhân viên --------------------------------------
        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtMaNhanVien.Text == "")
            {
                MessageBox.Show("Nhập mã nhân viên");
                return;
            }
            if (txtHoTen.Text == "")
            {
                MessageBox.Show("Nhập tên nhân viên");
                return;
            }
            if (txtSoDienThoai.Text == "")
            {
                MessageBox.Show("Nhập số điện thoại");
                return;
            }
            if (txtChucVu.Text == "")
            {
                MessageBox.Show("Nhập chức vụ");
                return;
            }
            if (txtBacLuong.Text == "")
            {
                MessageBox.Show("Nhập lương");
                return;
            }
            if (rtxtDiaChi.Text == "")
            {
                MessageBox.Show("Nhập địa chỉ");
                return;
            }
            NhanVien_DTO nhanVien = new NhanVien_DTO();
            nhanVien.MaNhanVien = txtMaNhanVien.Text;
            nhanVien.TenNhanVien = txtHoTen.Text;
            nhanVien.NgaySinh = DateTime.Parse(dtpNgaySinh.Text);
            if (rdNam.Checked)
                nhanVien.GioiTinh = "Nam";
            else
                nhanVien.GioiTinh = "Nữ";
            nhanVien.SoDienThoai = txtSoDienThoai.Text;
            nhanVien.ChucVu = txtChucVu.Text;
            nhanVien.Luong = txtBacLuong.Text;
            nhanVien.DiaChi = rtxtDiaChi.Text;
            if(danhSachNhanVien != null)
            {
                foreach (NhanVien_DTO nv in danhSachNhanVien)
                {
                    if (nhanVien.MaNhanVien == nv.MaNhanVien)
                    {
                        MessageBox.Show("Mã nhân viên đã có rồi");
                        return;
                    }
                }
            }
            if(NhanVien_BUS.ThemNhanVien(nhanVien))
            {
                LoadNhanVien();
                MessageBox.Show("Thêm thành công");
                return;
            }
            MessageBox.Show("Thêm thất bại");
        }

        //-------------- không cho phép nhập chữ ----------------------------
        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBacLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        // -------- sự kiện click vào 1 dòng
        DataGridViewRow drNhanVien;
        private void dgvDanhSachNhanVien_Click(object sender, EventArgs e)
        {
            try
            {
                drNhanVien = dgvDanhSachNhanVien.SelectedRows[0];
            }
            catch(Exception)
            {
                return;
            }

            txtMaNhanVien.Text = drNhanVien.Cells["MaNhanVien"].Value.ToString();
            txtHoTen.Text = drNhanVien.Cells["TenNhanVien"].Value.ToString();
            dtpNgaySinh.Text = drNhanVien.Cells["NgaySinh"].Value.ToString();
            if (drNhanVien.Cells["GioiTinh"].Value.ToString() == "Nam")
                rdNam.Checked = true;
            else
                rdNu.Checked = true;
            txtSoDienThoai.Text = drNhanVien.Cells["SoDienThoai"].Value.ToString();
            txtChucVu.Text = drNhanVien.Cells["ChucVu"].Value.ToString();
            txtBacLuong.Text = drNhanVien.Cells["Luong"].Value.ToString();
            rtxtDiaChi.Text = drNhanVien.Cells["DiaChi"].Value.ToString();
        }

        //---------------- sửa nhân viên ------------------------------
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if(drNhanVien == null)
            {
                MessageBox.Show("Chọn nhân viên muốn cập nhật");
                return;
            }

            NhanVien_DTO nhanVien = new NhanVien_DTO();

            nhanVien.MaNhanVien = drNhanVien.Cells["MaNhanVien"].Value.ToString();
            nhanVien.TenNhanVien = txtHoTen.Text;
            nhanVien.NgaySinh = DateTime.Parse(dtpNgaySinh.Text);
            if (rdNam.Checked)
                nhanVien.GioiTinh = "Nam";
            else
                nhanVien.GioiTinh = "Nữ";
            nhanVien.SoDienThoai = txtSoDienThoai.Text;
            nhanVien.ChucVu = txtChucVu.Text;
            nhanVien.Luong = txtBacLuong.Text;
            nhanVien.DiaChi = rtxtDiaChi.Text;

            if(NhanVien_BUS.SuaNhanVien(nhanVien))
            {
                
                drNhanVien = null;
                txtMaNhanVien.Text = "";
                txtHoTen.Text = "";
                txtSoDienThoai.Text = "";
                txtChucVu.Text = "";
                txtBacLuong.Text = "";
                rtxtDiaChi.Text = "";
                
                LoadNhanVien();
                MessageBox.Show("Sửa thành công");
                return;
            }
            MessageBox.Show("Sửa thất bại");
        }


        //------------------ xóa nhân viên ----------------------------
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(drNhanVien ==  null)
            {
                MessageBox.Show("Chọn nhân viên muốn xóa");
                return;
            }

            NhanVien_DTO nhanVien = new NhanVien_DTO();
            nhanVien.MaNhanVien = txtMaNhanVien.Text;

            if (MessageBox.Show("Xác nhận xóa","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (danhSachNhanVien == null)
                    dgvDanhSachNhanVien.DataSource = null;
                if (NhanVien_BUS.XoaNhanVien(nhanVien))
                {
                    drNhanVien = null;
                    txtMaNhanVien.Text = "";
                    txtHoTen.Text = "";
                    txtSoDienThoai.Text = "";
                    txtChucVu.Text = "";
                    txtBacLuong.Text = "";
                    rtxtDiaChi.Text = "";
                    MessageBox.Show("Xóa thành công");
                    LoadNhanVien();
                    return;
                } 
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void txtTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
            txtTimKiem.ForeColor = Color.Black;
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            txtTimKiem.Text = "Nhập tên nhân viên ...";
            txtTimKiem.ForeColor = Color.Gray;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            List<NhanVien_DTO> ketQua = NhanVien_BUS.TimNhanVien(txtTimKiem.Text);
            if (ketQua == null)
                return;
            dgvDanhSachNhanVien.DataSource = ketQua;
        }


        //========================QUAN LY TAI KHOAN============================

        List<TaiKhoanNV_DTO> taiKhoans;
        private void LoadTaiKhoan()
        {
            taiKhoans = TaiKhoan_BUS.LoadTaiKhoan();
            dgvTaiKhoan.DataSource = taiKhoans;

            if (taiKhoans == null)
                return;

            dgvTaiKhoan.Columns["SMaTK"].HeaderText = "ID";
            dgvTaiKhoan.Columns["TenNhanVien1"].HeaderText = "Tên Nhân Viên";
            dgvTaiKhoan.Columns["STaiKhoan"].HeaderText = "Tên Tài Khoản";
            dgvTaiKhoan.Columns["SMatKhau"].HeaderText = "Mật Khẩu";
            dgvTaiKhoan.Columns["FK_iMaQuyen1"].HeaderText = "Quyền";


            dgvTaiKhoan.Columns["SMaTK"].Width = 50;
            dgvTaiKhoan.Columns["TenNhanVien1"].Width = 200;
            dgvTaiKhoan.Columns["STaiKhoan"].Width = 200;
            dgvTaiKhoan.Columns["SMatKhau"].Width = 100;
            dgvTaiKhoan.Columns["FK_iMaQuyen1"].Width = 90;
        }

        private void LoadCbbTenNV()
        {
            cbbTenNV.DataSource = TaiKhoan_BUS.CbbTenNV();
            cbbTenNV.ValueMember = "ID"; //Trường giá trị
            cbbTenNV.DisplayMember = "TenNhanVien"; //Trường hiển thị
        }

        private void LoadCbbQuyen()
        {
            cbbQuyen.DataSource = TaiKhoan_BUS.CbbQuyen();
            cbbQuyen.ValueMember = "iMaQuyen"; //Trường giá trị
            cbbQuyen.DisplayMember = "sTenQuyen"; //Trường hiển thị
        }
        
        DataGridViewRow drTaiKhoan;
        private void dgvTaiKhoan_Click(object sender, EventArgs e)
        {
            try
            {
                drTaiKhoan = dgvTaiKhoan.SelectedRows[0];
            }
            catch (Exception)
            {
                return;
            }

            cbbTenNV.Text = drTaiKhoan.Cells["TenNhanVien1"].Value.ToString();
            txtTenTK.Text = drTaiKhoan.Cells["STaiKhoan"].Value.ToString();
            txtMatKhau.Text = drTaiKhoan.Cells["SMatKhau"].Value.ToString();
            txtEmail.Text = drTaiKhoan.Cells["Email1"].Value.ToString();
            cbbQuyen.Text = drTaiKhoan.Cells["FK_iMaQuyen1"].Value.ToString();

        }

        private void btnThemTK_Click(object sender, EventArgs e)
        {
            TaiKhoanNV_DTO taiKhoan = new TaiKhoanNV_DTO();
            taiKhoan.STaiKhoan = txtTenTK.Text;
            taiKhoan.SMatKhau = txtMatKhau.Text;
            taiKhoan.Email1 = txtEmail.Text;
            taiKhoan.FK_iMaQuyen1 = cbbQuyen.SelectedValue.ToString();
            taiKhoan.TenNhanVien1 = cbbTenNV.SelectedValue.ToString();

            if (txtTenTK.Text == "")
            {
                MessageBox.Show("Nhập tên tài khoản");
                return;
            }
            if (txtMatKhau.Text == "")
            {
                MessageBox.Show("Nhập mật khẩu");
                return;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Nhập email");
                return;
            }
            if (TaiKhoan_BUS.CheckTaiKhoanTrung(txtTenTK.Text).Count != 0) { MessageBox.Show("Tên tài khoản này đã được đăng ký, vui lòng đăng ký tên tài khoản khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (!TaiKhoan_BUS.checkEmail(txtEmail.Text)) { MessageBox.Show("Vui lòng nhập đúng định dạng email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (TaiKhoan_BUS.CheckEmailTrung(txtEmail.Text).Count != 0) { MessageBox.Show("Email này đã được đăng ký, vui lòng đăng ký email khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            if (TaiKhoan_BUS.ThemTaiKhoan(taiKhoan))
            {
                LoadTaiKhoan();
                MessageBox.Show("Thêm thành công");
                return;
            }
            MessageBox.Show("Thêm thất bại");

        }

        private void btnCapNhatTK_Click(object sender, EventArgs e)
        {
            if (drTaiKhoan == null)
            {
                MessageBox.Show("Chọn nhân viên muốn cập nhật");
                return;
            }
            if (TaiKhoan_BUS.CheckTaiKhoanTrung(txtTenTK.Text).Count != 0) { MessageBox.Show("Tên tài khoản này đã được đăng ký, vui lòng đăng ký tên tài khoản khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (!TaiKhoan_BUS.checkEmail(txtEmail.Text)) { MessageBox.Show("Vui lòng nhập đúng định dạng email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (TaiKhoan_BUS.CheckEmailTrung(txtEmail.Text).Count != 0) { MessageBox.Show("Email này đã được đăng ký, vui lòng đăng ký email khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }


            TaiKhoanNV_DTO taiKhoan = new TaiKhoanNV_DTO();
            taiKhoan.SMaTK = int.Parse(drTaiKhoan.Cells["sMaTK"].Value.ToString());
            taiKhoan.STaiKhoan = txtTenTK.Text;
            taiKhoan.SMatKhau = txtMatKhau.Text;
            taiKhoan.Email1 = txtEmail.Text;
            taiKhoan.FK_iMaQuyen1 = cbbQuyen.SelectedValue.ToString();
            taiKhoan.TenNhanVien1 = cbbTenNV.SelectedValue.ToString();

            if (TaiKhoan_BUS.SuaTaiKhoan(taiKhoan))
            {

                drTaiKhoan = null;
                cbbTenNV.Text = "";
                txtTenTK.Text = "";
                txtMatKhau.Text = "";
                txtEmail.Text = "";
                cbbQuyen.Text = "";

                LoadTaiKhoan();
                MessageBox.Show("Sửa thành công");
                return;
            }
            MessageBox.Show("Sửa thất bại");
        }

        private void btnXoaTK_Click(object sender, EventArgs e)
        {
            if (drTaiKhoan == null)
            {
                MessageBox.Show("Chọn nhân viên muốn cập nhật");
                return;
            }
            TaiKhoanNV_DTO taiKhoan = new TaiKhoanNV_DTO();
            taiKhoan.SMaTK = int.Parse(drTaiKhoan.Cells["sMaTK"].Value.ToString());

            if (MessageBox.Show("Xác nhận xóa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (taiKhoan == null)
                    dgvTaiKhoan.DataSource = null;
                if (TaiKhoan_BUS.XoaTaiKhoan(taiKhoan))
                {
                    drTaiKhoan = null;
                    cbbTenNV.Text = "";
                    txtTenTK.Text = "";
                    txtMatKhau.Text = "";
                    txtEmail.Text = "";
                    cbbQuyen.Text = "";
                    MessageBox.Show("Xóa thành công");
                    LoadTaiKhoan();
                    return;
                }
                MessageBox.Show("Xóa thất bại");
            }
        }
    }
}
