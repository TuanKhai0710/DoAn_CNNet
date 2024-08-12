using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_DotNet
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
            this.Size = new Size(1460, 800);
        }
        Form currentFormChild;
        void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_Body.Controls.Add(childForm);
            panel_Body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btn_SanPham_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SanPham());
            lbl_TenForm.Text = "Quản lý sản phẩm";
        }

        private void btn_KhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThemKH());
            lbl_TenForm.Text = "Quản lý khách hàng";
        }

        private void btn_TTCN_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThemTTCN());
            lbl_TenForm.Text = "Quản lý thông tin cá nhân";
        }
        private void btn_NhaCungCap_Click(object sender, EventArgs e)
        {
            OpenChildForm(new NhaCungCap());
            lbl_TenForm.Text = "Quản lý nhà cung cấp";
        }

        private void btn_NhapKho_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ChiTietSanPham());
            lbl_TenForm.Text = "Quản lý chi tiết sản phẩm";
        }

        private void btn_XuatKho_Click(object sender, EventArgs e)
        {
            OpenChildForm(new XuatKho());
            lbl_TenForm.Text = "Quản lý xuất kho";
        }

        private void btn_QuangCao_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QuangCao());
            lbl_TenForm.Text = "Quản lý quảng cáo";
        }
        private void btn_NhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThemNV());
            lbl_TenForm.Text = "Quản lý nhân viên";
        }

        private void btn_QLTK_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQLTK());
            lbl_TenForm.Text = "Quản lý tài khoản";
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThongKe());
            lbl_TenForm.Text = "Quản lý thống kê";
        }
        private void btn_logo_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThongKe());
            lbl_TenForm.Text = "Quản lý thống kê";
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            btn_SanPham.FlatAppearance.BorderSize = 0;
            btn_KhachHang.FlatAppearance.BorderSize = 0;
            btn_NhaCungCap.FlatAppearance.BorderSize = 0;
            btn_QuangCao.FlatAppearance.BorderSize = 0;
            btn_XuatKho.FlatAppearance.BorderSize = 0;
            btn_CTSP.FlatAppearance.BorderSize = 0;
            btn_TTCN.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.BorderSize = 0;
            btn_QLTK.FlatAppearance.BorderSize = 0;
            btn_NhanVien.FlatAppearance.BorderSize = 0;
            btn_ThongKe.FlatAppearance.BorderSize = 0;
            btn_logo.FlatAppearance.BorderSize = 0;
            lbl_TenDangNhap.Text = DangNhap.tenDangNhap;
            lbl_ChucVu.Text = DangNhap.chucVu;
            lbl_TenForm.Text = "Home Form";

            btn_ThongKe_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DangNhap f = new DangNhap();
            f.Show();
            this.Hide();
        }

        
    }
}
