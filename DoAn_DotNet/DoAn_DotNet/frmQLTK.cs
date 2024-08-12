using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_DotNet
{
    public partial class frmQLTK : Form
    {
        ConnectDB_Vuong db = new ConnectDB_Vuong();
        DataTable dt;

        SqlDataAdapter da_TaiKhoan;
        DataSet ds_TaiKhoan;
        DataColumn[] key = new DataColumn[1];

        public frmQLTK()
        {
            InitializeComponent();
            string query = "SELECT TENTAIKHOAN, MATKHAU, LOAITAIKHOAN FROM TAIKHOAN";
            da_TaiKhoan = new SqlDataAdapter(query, db.ConStr);
            ds_TaiKhoan = new DataSet();
            da_TaiKhoan.Fill(ds_TaiKhoan, "TAIKHOAN");

            key[0] = ds_TaiKhoan.Tables["TAIKHOAN"].Columns["TENTAIKHOAN"];
            ds_TaiKhoan.Tables["TAIKHOAN"].PrimaryKey = key;

        }
        void HienThiTK()
        {
            string query = "SELECT * FROM TAIKHOAN";
            dt = db.getDataTable(query);
            dataGridView1.DataSource = dt;
        }

        private void frmQLTK_Load(object sender, EventArgs e)
        {
            string[] loaiTK = { "admin", "nhanvien" };
            cbo_LoaiTK.Items.AddRange(loaiTK);
            cbo_LoaiTK.SelectedIndex = 0;

            HienThiTK();
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_TenTK.Text) || string.IsNullOrWhiteSpace(txt_MatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản và mật khẩu để thêm.");
                return;
            }
            if (ds_TaiKhoan != null)
            {
                DataRow dr = ds_TaiKhoan.Tables["TAIKHOAN"].Rows.Find(txt_TenTK.Text);
                if (dr != null)
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string selectedLoaiTK = cbo_LoaiTK.SelectedItem.ToString();
                    int rowsAffected = db.ThemTaiKhoan(txt_TenTK.Text, txt_MatKhau.Text, selectedLoaiTK);

                    if(rowsAffected > 0)
                    {
                        HienThiTK();
                        MessageBox.Show("Thêm tài khoản mới thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Thêm tài khoản thất bại!");
                    } 
                        
                }
            }
            cbo_LoaiTK.SelectedIndex = 0;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_TenTK.Text) || string.IsNullOrWhiteSpace(txt_MatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản và mật khẩu để xóa.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này?", "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int rowsAffected = db.XoaTaiKhoan(txt_TenTK.Text);

                if (rowsAffected > 0)
                {
                    HienThiTK();
                    MessageBox.Show("Xóa tài khoản thành công!");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tài khoản để xóa!");
                }
            }

            cbo_LoaiTK.SelectedIndex = 0;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txt_TenTK.Text = row.Cells["TENTAIKHOAN"].Value.ToString();
                txt_MatKhau.Text = row.Cells["MATKHAU"].Value.ToString();
                cbo_LoaiTK.Text = row.Cells["LOAITAIKHOAN"].Value.ToString();
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            int rowsAffected = db.CapNhatTaiKhoan(txt_TenTK.Text, txt_MatKhau.Text, cbo_LoaiTK.SelectedItem.ToString());

            if (rowsAffected > 0)
            {
                HienThiTK();
                MessageBox.Show("Sửa thông tin tài khoản thành công!");
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin tài khoản để sửa!");
            }
        }
    }
}
