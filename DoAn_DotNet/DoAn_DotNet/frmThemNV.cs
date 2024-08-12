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
    public partial class frmThemNV : Form
    {
        ConnectDB_Vuong db = new ConnectDB_Vuong();
        DataTable dt;

        SqlDataAdapter da_nhanvien;
        DataSet ds_nhanvien;
        public frmThemNV()
        {
            InitializeComponent();

            string query = "Select * from NHANVIEN";
            da_nhanvien = new SqlDataAdapter(query, db.ConStr);
            ds_nhanvien = new DataSet();
            da_nhanvien.Fill(ds_nhanvien, "NHANVIEN");

        }

        private void frmThemNV_Load(object sender, EventArgs e)
        {
            LoadCboChonMaPerson();
            HienThiDanhSachNhanVien();
        }

        private void LoadCboChonMaPerson()
        {
            List<string> danhSachMaPerson = db.LayDanhSachMaPerson();

            if (danhSachMaPerson != null && danhSachMaPerson.Count > 0)
            {
                cbo_ChonMaPerson.Items.Clear();
                cbo_ChonMaPerson.Items.AddRange(danhSachMaPerson.ToArray());
                cbo_ChonMaPerson.SelectedIndex = 0;
            }
        }

        private void HienThiDanhSachNhanVien()
        {
            DataTable dt = db.LayDanhSachNhanVien();

            if (dt != null && dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                HienThiThongTinNhanVien(0);
            }
        }

        private void HienThiThongTinNhanVien(int rowIndex)
        {
            if (dt != null && dt.Rows.Count > 0 && rowIndex >= 0 && rowIndex < dataGridView1.Rows.Count)
            {
                DataRow row = dt.Rows[rowIndex];
                txt_MaNV.Text = row["MANHANVIEN"].ToString();
                cbo_ChonMaPerson.Text = row["MAPERSON"].ToString();
                txt_ChucVu.Text = row["CHUCVU"].ToString();
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_MaNV.Text) || cbo_ChonMaPerson.SelectedItem == null || string.IsNullOrWhiteSpace(txt_ChucVu.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ds_nhanvien != null)
            {
                int check = db.CheckMaNV(txt_MaNV.Text);
                if (check != 0)
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    

                    string selectedMaPerson = cbo_ChonMaPerson.SelectedItem.ToString();
                    int rowsAffected = db.ThemNhanVien(txt_MaNV.Text, selectedMaPerson, txt_ChucVu.Text);

                    if (rowsAffected > 0)
                    {
                        HienThiDanhSachNhanVien();
                        MessageBox.Show("Thêm nhân viên mới thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm nhân viên mới!");
                    }
                }
            }

            cbo_ChonMaPerson.SelectedIndex = 0;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_MaNV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên để xóa.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int rowsAffected = db.XoaNhanVien(txt_MaNV.Text);
                if (rowsAffected > 0)
                {
                    HienThiDanhSachNhanVien();
                    MessageBox.Show("Xóa nhân viên thành công!");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên để xóa!");
                }
            }

            cbo_ChonMaPerson.SelectedIndex = 0;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txt_MaNV.Text = row.Cells["MANHANVIEN"].Value.ToString();
                cbo_ChonMaPerson.Text = row.Cells["MAPERSON"].Value.ToString();
                txt_ChucVu.Text = row.Cells["CHUCVU"].Value.ToString();
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            int rowsAffected = db.CapNhatNhanVien(txt_MaNV.Text, cbo_ChonMaPerson.SelectedItem.ToString(), txt_ChucVu.Text);

            if (rowsAffected > 0)
            {
                HienThiDanhSachNhanVien();
                MessageBox.Show("Sửa thông tin thành công!");
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin để sửa!");
            }
        }

        private string TaoMaTuDong()
        {
            string maNV = "MANV";
            int number = db.LayGiaTriSoCuoiCungNhanVien() + 1;
            maNV += number.ToString("0");
            return maNV;
        }
        private void btn_TaoMaNV_Click(object sender, EventArgs e)
        {
            txt_MaNV.Text = TaoMaTuDong();
        }
    }
}
