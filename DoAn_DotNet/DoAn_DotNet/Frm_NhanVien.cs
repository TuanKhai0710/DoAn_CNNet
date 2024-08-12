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
    public partial class Frm_NhanVien : Form
    {
        public Frm_NhanVien()
        {
            InitializeComponent();
            this.Size = new Size(1460, 750);
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
        private void btn_KhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThemKH());
            lbl_TenForm.Text = "Quản lý khách hàng";
        }

        private void btn_NhapKho_Click(object sender, EventArgs e)
        {
            OpenChildForm(new NhapKho());
            lbl_TenForm.Text = "Quản lý nhập kho";
        }

        private void btn_DonHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DonHang());
            lbl_TenForm.Text = "Quản lý đơn hàng";
        }

        private void Frm_NhanVien_Load(object sender, EventArgs e)
        {
            btn_KhachHang.FlatAppearance.BorderSize = 0;
            btn_NhapKho.FlatAppearance.BorderSize = 0;
            btn_TTCN.FlatAppearance.BorderSize = 0;
            btn_DonHang.FlatAppearance.BorderSize = 0;
            btn_logo.FlatAppearance.BorderSize = 0;
            lbl_TenDangNhap.Text = DangNhap.tenDangNhap;
            lbl_ChucVu.Text = DangNhap.chucVu;
            lbl_TenForm.Text = "Nhân Viên Form";

            btn_TTCN_Click(sender, e);
        }

        private void btn_TTCN_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThemTTCN());
            lbl_TenForm.Text = "Quản lý thông tin cá nhân";
        }

        private void btn_logo_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThemTTCN());
            lbl_TenForm.Text = "Quản lý thông tin cá nhân";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DangNhap f = new DangNhap();
            f.Show();
            this.Hide();
        }

        
    }
}
