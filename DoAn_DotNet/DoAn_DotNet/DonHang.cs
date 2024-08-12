using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace DoAn_DotNet
{
    public partial class DonHang : Form
    {
        public DonHang()
        {
            InitializeComponent();
        }
        bool xong = false;
        void hienThiSanPham()
        {
            string query = "SELECT * FROM CHITIETSANPHAM";
            ConnectDB_Hao db = new ConnectDB_Hao();
            DataTable dt = db.getDataTable(query);

            cbo_SanPham.DataSource = dt;
            cbo_SanPham.DisplayMember = "TENSANPHAM";
            cbo_SanPham.ValueMember = "MACHITIETSANPHAM";
        }
        void loadKhachHang()
        {
            string query = "SELECT * FROM KHACHHANG INNER JOIN PERSON ON KHACHHANG.MAPERSON = PERSON.MAPERSON";
            ConnectDB_Hao db = new ConnectDB_Hao();
            DataTable dt = db.getDataTable(query);

            cbo_KhachHang.DataSource = dt;
            cbo_KhachHang.DisplayMember = "TEN";
            cbo_KhachHang.ValueMember = "MAKHACHHANG";
            lbl_TenKhachHang.Text = dt.Rows[0]["TEN"].ToString();
            lbl_DiaChi.Text = dt.Rows[0]["DIACHI"].ToString();
            lbl_DienThoai.Text = dt.Rows[0]["SODIENTHOAI"].ToString();
            lbl_GioiTinh.Text = dt.Rows[0]["GIOITINH"].ToString();
            lbl_Email.Text = dt.Rows[0]["EMAIL"].ToString();
            xong = true;
        }
        void loadDGV_CTHD()
        {
            ConnectDB_Hao connect = new ConnectDB_Hao();
            bool kiemTra = false; ;
            if (cbo_KhachHang.SelectedValue == null)
            {
                kiemTra = false;
            }
            else
            {
                kiemTra = true;
            }
            if (kiemTra == true)
            {
                string query = "SELECT MACHITIETDONHANG, DONHANG.MADONHANG, MACHITIETSANPHAM, SOLUONG, KIEMTRATHANHTOAN FROM CHITIETDONHANG INNER JOIN DONHANG ON DONHANG.MADONHANG = CHITIETDONHANG.MADONHANG INNER JOIN KHACHHANG ON KHACHHANG.MAKHACHHANG = DONHANG.MAKHACHHANG WHERE DONHANG.MAKHACHHANG = '" + cbo_KhachHang.SelectedValue + "'";
                DataTable dt = connect.getDataTable(query);
                dgv_ListCTDH.DataSource = dt;
            }
           
        }
        
        private void dgv_ListSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DonHang_Load(object sender, EventArgs e)
        {
            hienThiSanPham();
            loadKhachHang();
            lbl_NgayLap.Text = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
        }

        private void cbo_SanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (xong == true)
            {
                ConnectDB_Hao db = new ConnectDB_Hao();

                string query = "SELECT * FROM CHITIETSANPHAM WHERE MACHITIETSANPHAM = '" + cbo_SanPham.SelectedValue + "'";
                DataTable dt = db.getDataTable(query);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Vui Lòng Nhập Dữ Liệu Đầy Đủ");
                }
                else
                {
                    lbl_TenSanPham.Text = dt.Rows[0]["TENSANPHAM"].ToString();
                    lbl_DonGia.Text = dt.Rows[0]["GIA"].ToString();
                }
            }
        }

        private void cbo_KhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDGV_CTHD();
        }
        public static string donHang = "";
        private void btn_Them_Click(object sender, EventArgs e)
        {

            ConnectDB_Hao db = new ConnectDB_Hao();
            DataTable dt = (DataTable)dgv_ListCTDH.DataSource;
            DataRow dr = dt.NewRow();
            if (dt.Rows.Count == 0 && !string.IsNullOrEmpty(txt_MaDonHang.Text))
            {
                if (!db.kiemTraMaDH(txt_MaDonHang.Text))
                {
                    dr["MACHITIETDONHANG"] = "CTDH" + DateTime.Now;
                    dr["MADONHANG"] = txt_MaDonHang.Text;
                    dr["MACHITIETSANPHAM"] = cbo_SanPham.SelectedValue;
                    dr["SOLUONG"] = numUD_SoLuong.Value;
                    dr["KIEMTRATHANHTOAN"] = 0;
                    db.insertDonHang(dr["MADONHANG"].ToString(), cbo_KhachHang.SelectedValue.ToString(), DateTime.Now.ToString(), "Chờ Xử Lý");
                    dt.Rows.Add(dr);
                    db.tongTien();
                    //lbl_TongTien.Text = Convert.ToString(db.tongTienDH(txt_MaDonHang.Text.ToString()));
                }
                else
                {
                    MessageBox.Show("Mã đơn hàng đã tồn tại", "Thông Báo");
                }
            }
            else
            {
                dr["MACHITIETDONHANG"] = "CTDH" + (dt.Rows.Count + 1);
                dr["MADONHANG"] = dt.Rows[0]["MADONHANG"];
                dr["MACHITIETSANPHAM"] = cbo_SanPham.SelectedValue;
                dr["SOLUONG"] = numUD_SoLuong.Value;
                dr["KIEMTRATHANHTOAN"] = 0;
                dt.Rows.Add(dr);
                db.tongTien();
                lbl_TongTien.Text = Convert.ToString(db.tongTienDH(dt.Rows[0]["MADONHANG"].ToString()));
            }
            string query = "SELECT * FROM CHITIETDONHANG";
            lbl_TongTienThucTra.Text = lbl_TongTien.Text;
            db.updateDataTable(dt, query);
            
        }
        
        private void btn_TaoHoaDon_Click(object sender, EventArgs e)
        {
            donHang = dgv_ListCTDH.Rows[0].Cells["MADONHANG"].Value.ToString();
            FormRP f = new FormRP();
            f.Show();
            this.Hide();
        }

        
    }
}
