using DoAn_Winform;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmInHoaDon : Form
    {
        public frmInHoaDon()
        {
            InitializeComponent();
        }

        private void frmInHoaDon_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsHoaDon.DataTable1' table. You can move, or remove it, as needed.
            CultureInfo cul = new CultureInfo("vi-VN");


            DateTime nowTime = DateTime.Now;

            // các thuộc tính sẽ truyền vào hóa đơn
            ReportParameter p1 = new ReportParameter("tenBan", frmQuanLiBanAn.tenBan);
            ReportParameter p2 = new ReportParameter("maHoaDon", frmQuanLiBanAn.maHoaDon);
            ReportParameter p3 = new ReportParameter("time", nowTime.ToString("dd/MM/yyyy"));
            ReportParameter p4 = new ReportParameter("tongTien", frmQuanLiBanAn.tongTien.ToString("c", cul));
            ReportParameter p5 = new ReportParameter("khuyenMai", frmQuanLiBanAn.khuyenMai.ToString("c", cul));
            ReportParameter p6 = new ReportParameter("thanhTien", frmQuanLiBanAn.thanhTien.ToString("c", cul));

            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5, p6 });

            // in hóa đơn dựa vào id bàn
            this.DataTable1TableAdapter.Fill(this.dsHoaDon.DataTable1, frmQuanLiBanAn.id);

            this.reportViewer1.RefreshReport();
        }
    }
}
