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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        public static string tenDangNhap = "";
        public static string chucVu = "";
        ConnectDB_Vuong db = new ConnectDB_Vuong();
        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            string tentaikhoan = txt_taikhoan.Text;
            string matkhau = txt_matkhau.Text;
            if (tentaikhoan.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản");
                txt_taikhoan.Focus();
            }
            else if (matkhau.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu");
                txt_matkhau.Focus();
            }
            else
            {
                string chuoitruyvan = "Select * from TAIKHOAN where TENTAIKHOAN = '" + tentaikhoan + "' and MATKHAU  = '" + matkhau + "'";
                DataTable dt = db.getDataTable(chuoitruyvan);
                if (dt.Rows.Count != 0)
                {
                    if (dt.Rows[0]["LOAITAIKHOAN"].ToString() == "admin")
                    {
                        tenDangNhap = dt.Rows[0]["TENTAIKHOAN"].ToString();
                        chucVu = dt.Rows[0]["LOAITAIKHOAN"].ToString();
                        HomeForm f = new HomeForm();
                        f.Show();
                        this.Hide();
                    }
                    else
                    {
                        tenDangNhap = dt.Rows[0]["TENTAIKHOAN"].ToString();
                        chucVu = dt.Rows[0]["LOAITAIKHOAN"].ToString();
                        Frm_NhanVien f = new Frm_NhanVien(); //Có thể sửa để mở sang form khác dành cho admin (nếu có) - tui để mặc định nv với admin mở chung homeform
                        f.Show();
                        this.Hide();
                    }
                   
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại, vui lòng kiểm tra lại tài khoản và mật khẩu");
                    txt_taikhoan.Clear();
                    txt_matkhau.Clear();
                    txt_taikhoan.Focus();
                }
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DangNhap_Shown(object sender, EventArgs e)
        {
            txt_taikhoan.Focus();
        }

        private void txt_taikhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txt_matkhau.Focus();
            }    
        }

        private void txt_matkhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btn_dangnhap_Click(sender, e);
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txt_taikhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txt_matkhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
