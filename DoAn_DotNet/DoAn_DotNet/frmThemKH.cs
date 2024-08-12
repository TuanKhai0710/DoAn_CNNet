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
    public partial class frmThemKH : Form
    {
        ConnectDB_Vuong db = new ConnectDB_Vuong();
        DataTable dt;

        SqlDataAdapter da_khachhang;
        DataSet ds_khachhang;
        DataColumn[] key = new DataColumn[1];
        public frmThemKH()
        {
            InitializeComponent();

            string query = "SELECT * FROM KHACHHANG";
            da_khachhang = new SqlDataAdapter(query, db.ConStr);
            ds_khachhang = new DataSet();
            da_khachhang.Fill(ds_khachhang, "KHACHHANG");

            if (ds_khachhang.Tables.Contains("KHACHHANG"))
            {
                key[0] = ds_khachhang.Tables["KHACHHANG"].Columns["KHACHHANG"];
                ds_khachhang.Tables["KHACHHANG"].PrimaryKey = key;
            }
            else
            {
                MessageBox.Show("Table 'PERSON' not found in the dataset.");
            }
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

        private void HienThiDanhSachKhachHang()
        {
            DataTable dt = db.LayDanhSachKhachHang();

            if (dt != null && dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                HienThiThongTinKhachHang(0);
            }
        }

        private void HienThiThongTinKhachHang(int rowIndex)
        {

            if (rowIndex >= 0 && rowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[rowIndex];
                txt_MaKH.Text = row.Cells[0].Value.ToString();
                cbo_ChonMaPerson.Text = row.Cells[1].Value.ToString();
            }
        }

        private void frmThemKH_Load(object sender, EventArgs e)
        {
            LoadCboChonMaPerson();
            HienThiDanhSachKhachHang();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_MaKH.Text) || cbo_ChonMaPerson.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            if (ds_khachhang != null)
            {
                if(txt_MaKH.Text != null)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }   
                else
                {
                    int check = db.CheckMaKH(txt_MaKH.Text);
                    if (check != 0)
                    {
                        MessageBox.Show("Mã khách hàng đã tồn tại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string selectedMaPerson = cbo_ChonMaPerson.SelectedItem.ToString();
                        int rowsAffected = db.ThemKhachHang(txt_MaKH.Text, selectedMaPerson);

                        if (rowsAffected > 0)
                        {
                            HienThiDanhSachKhachHang();
                            MessageBox.Show("Thêm khách hàng mới thành công!");
                        }
                        else
                        {
                            MessageBox.Show("Không thể thêm khách hàng mới!");
                        }
                    }
                }    
            }    

            cbo_ChonMaPerson.SelectedIndex = 0;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_MaKH.Text))
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng để xóa.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int rowsAffected = db.XoaKhachHang(txt_MaKH.Text);

                if (rowsAffected > 0)
                {
                    HienThiDanhSachKhachHang();
                    MessageBox.Show("Xóa khách hàng thành công!");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng để xóa!");
                }
            }

            cbo_ChonMaPerson.SelectedIndex = 0;
        }
        private void btn_Sua_Click(object sender, EventArgs e)
        {
            int rowsAffected = db.CapNhatKhachHang(txt_MaKH.Text, cbo_ChonMaPerson.SelectedItem.ToString());

            if (rowsAffected > 0)
            {
                HienThiDanhSachKhachHang();
                MessageBox.Show("Sửa thông tin thành công!");
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin để sửa!");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txt_MaKH.Text = row.Cells["MAKHACHHANG"].Value.ToString();
                cbo_ChonMaPerson.Text = row.Cells["MAPERSON"].Value.ToString();
            }
        }

        private string TaoMaTuDong()
        {
            string maPerson = "MAKH";
            int number = db.LayGiaTriSoCuoiCungKhachHang() + 1;
            maPerson += number.ToString("0");
            return maPerson;
        }

        private void btn_TaoMaKH_Click(object sender, EventArgs e)
        {
            txt_MaKH.Text = TaoMaTuDong();
        }
    }
}
