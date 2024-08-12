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
    public partial class frmThemTTCN : Form
    {
        ConnectDB_Vuong db = new ConnectDB_Vuong();
        DataTable dt;

        SqlDataAdapter da_Person;
        DataSet ds_Person;
        DataColumn[] key = new DataColumn[1];

        public frmThemTTCN()
        {
            InitializeComponent();
            txt_MaPerson.Focus();

            string query = "SELECT * FROM PERSON";
            da_Person = new SqlDataAdapter(query, db.ConStr);
            ds_Person = new DataSet();

            da_Person.Fill(ds_Person, "PERSON");

            if (ds_Person.Tables.Contains("PERSON"))
            {
                key[0] = ds_Person.Tables["PERSON"].Columns["MAPERSON"];
                ds_Person.Tables["PERSON"].PrimaryKey = key;
            }
            else
            {
                MessageBox.Show("Table 'PERSON' not found in the dataset.");
            }
        }

        void HienThiPerson()
        {
            string query = "SELECT MAPERSON, TEN, SODIENTHOAI, EMAIL, DIACHI, GIOITINH FROM PERSON";
            dt = db.getDataTable(query);
            dataGridView1.DataSource = dt;

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.BorderStyle = BorderStyle.FixedSingle;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] gioiTinh = { "Nam", "Nữ" };
            cbo_GioiTinh.Items.AddRange(gioiTinh);
            cbo_GioiTinh.SelectedIndex = 0;

            HienThiPerson();
        }

        private bool CheckInput()
        {
            if (txt_MaPerson.Text != null && txt_Ten.Text != null && txt_SDT.Text != null && txt_Email.Text != null && txt_DiaChi.Text != null)
                return true;
            return false;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (ds_Person != null)
            {
                DataRow dr = ds_Person.Tables["PERSON"].Rows.Find(txt_MaPerson.Text);
                if (dr != null)
                {
                    MessageBox.Show("Mã người dùng đã tồn tại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if(CheckInput())
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin để thêm!", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }   
                    else
                    {
                        int rowsAffected = db.ThemNguoiDung(txt_MaPerson.Text, txt_Ten.Text, txt_SDT.Text, txt_Email.Text, txt_DiaChi.Text, cbo_GioiTinh.SelectedItem.ToString());

                        if (rowsAffected > 0)
                        {
                            HienThiPerson();
                            dataGridView1.Refresh();
                            MessageBox.Show("Đã thêm thông tin cá nhân mới thành công.");
                        }
                        else
                        {
                            MessageBox.Show("Không thể thêm thông tin cá nhân mới!");
                        }
                    }    
                    
                }
            }
            cbo_GioiTinh.SelectedIndex = 0;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_MaPerson.Text))
            {
                MessageBox.Show("Vui lòng nhập mã người dùng để xóa.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin người này?", "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int rowsAffected = db.XoaNguoiDung(txt_MaPerson.Text);

                    if (rowsAffected > 0)
                    {
                        DataRow rowToDelete = ds_Person.Tables["PERSON"].Rows.Find(txt_MaPerson.Text);
                        if (rowToDelete != null)
                        {
                            ds_Person.Tables["PERSON"].Rows.Remove(rowToDelete);
                        }

                        dataGridView1.DataSource = ds_Person.Tables["PERSON"];

                        MessageBox.Show("Xóa thông tin người dùng thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin để xóa!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hãy xóa mã người dùng ở bên bảng nhân viên hoặc khách hàng trước!! \nHãy thử lại!! \nChi tiết lỗi: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btn_Sua_Click(object sender, EventArgs e)
        {
            int rowsAffected = db.SuaThongTinNguoiDung(txt_MaPerson.Text, txt_Ten.Text, txt_SDT.Text, txt_Email.Text, txt_DiaChi.Text, cbo_GioiTinh.SelectedItem.ToString());

            if (rowsAffected > 0)
            {
                HienThiPerson();
                MessageBox.Show("Sửa thông tin thành công!");
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin để sửa!");
            }
        }

        private string TaoMaTuDong()
        {
            string maPerson = "PER";
            int number = db.LayGiaTriSoCuoiCungNguoiDung() + 1;
            maPerson += number.ToString("0");
            return maPerson;
        }

        private void btn_TaoMaAuto_Click(object sender, EventArgs e)
        {
            txt_MaPerson.Text = TaoMaTuDong();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txt_MaPerson.Text = row.Cells["MAPERSON"].Value.ToString();
                txt_Ten.Text = row.Cells["TEN"].Value.ToString();
                txt_SDT.Text = row.Cells["SODIENTHOAI"].Value.ToString();
                txt_Email.Text = row.Cells["EMAIL"].Value.ToString();
                txt_DiaChi.Text = row.Cells["DIACHI"].Value.ToString();
                cbo_GioiTinh.Text = row.Cells["GIOITINH"].Value.ToString();
            }
        }
    }
}
