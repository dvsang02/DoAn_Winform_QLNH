using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace GUI
{
    public partial class frmQuenMatKhau : Form
    {
        public frmQuenMatKhau()
        {
            InitializeComponent();
            lblKetQua.Text = "";
        }

        private void btnQuenPass_Click(object sender, EventArgs e)
        {
            string email = txtEmailDK.Text;
            if(email.Trim() == "") { MessageBox.Show("Vui lòng nhập email!"); }
            else
            {
                if(TaiKhoan_BUS.checkEmailQuenPass(email).Count != 0)
                {
                    lblKetQua.ForeColor = Color.Blue;
                    lblKetQua.Text = "Mật khẩu: " + TaiKhoan_BUS.layMatKhau(email);
                }
                else
                {
                    lblKetQua.ForeColor = Color.Red;
                    lblKetQua.Text = "Email này chưa được đăng ký!";
                }
            }

        }
    }
}
