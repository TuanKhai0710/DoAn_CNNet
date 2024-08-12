using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_DotNet
{
    class ConnectDB_Vuong
    {
        public readonly string ConStr = @"Data Source=VUONG-TRAN\MSSQLSERVER01;Initial Catalog=QUAN_LY_CUA_HANG_BAN_DIEN_THOAI;Persist Security Info=True;User ID=sa;Password=123";

        SqlConnection con;

        public ConnectDB_Vuong()
        {
            con = new SqlConnection(ConStr);
        }
        public void OpenDB()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
        }
        public void CloseDB()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }
        public int getExecuteNonQuery(string query)
        {
            OpenDB();
            SqlCommand cmd = new SqlCommand(query, con);

            int kq = cmd.ExecuteNonQuery();

            return kq;
        }
        public object getExecuteScalar(string query)
        {
            OpenDB();
            SqlCommand cmd = new SqlCommand(query, con);

            object kq = cmd.ExecuteScalar();

            return kq;
        }

        public DataTable getDataTable(string query)
        {
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public int updateDataTable(DataTable dt, string query)
        {
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            int kq = da.Update(dt);
            return kq;
        }

        #region Quản lý tài khoản
        public int ThemTaiKhoan(string tenTK, string matkhau, string loaiTK)
        {
            string query = "INSERT INTO TAIKHOAN (TENTAIKHOAN, MATKHAU, LOAITAIKHOAN) VALUES (@TenTK, @MatKhau, @LoaiTK)";
            SqlCommand insertCommand = new SqlCommand(query, con);
            insertCommand.Parameters.AddWithValue("@TenTK", tenTK);
            insertCommand.Parameters.AddWithValue("@MatKhau", matkhau);
            insertCommand.Parameters.AddWithValue("@LoaiTK", loaiTK);

            OpenDB();
            int rowsAffected = insertCommand.ExecuteNonQuery();
            CloseDB();

            return rowsAffected;
        }

        public int XoaTaiKhoan(string tenTK)
        {
            string query = "DELETE FROM TAIKHOAN WHERE TENTAIKHOAN = @TenTK";
            SqlCommand deleteCommand = new SqlCommand(query, con);
            deleteCommand.Parameters.AddWithValue("@TenTK", tenTK);

            OpenDB();
            int rowsAffected = deleteCommand.ExecuteNonQuery();
            CloseDB();

            return rowsAffected;
        }

        public int CapNhatTaiKhoan(string tenTk, string matKhau, string loaiTK)
        {
            string query = "UPDATE TAIKHOAN SET MATKHAU = @MatKhau, LOAITAIKHOAN = @LoaiTK WHERE TENTAIKHOAN = @TenTK";
            SqlCommand updateCommand = new SqlCommand(query, con);
            updateCommand.Parameters.AddWithValue("@TenTK", tenTk);
            updateCommand.Parameters.AddWithValue("@MatKhau", matKhau);
            updateCommand.Parameters.AddWithValue("@LoaiTK", loaiTK);

            OpenDB();
            int rowsAffected = updateCommand.ExecuteNonQuery();
            CloseDB();

            return rowsAffected;
        }

        #endregion

        #region Quản lý thông tin cá nhân

        public int ThemNguoiDung(string maPerson, string ten, string soDienThoai, string email, string diaChi, string gioiTinh)
        {
            string insertCommandText = "INSERT INTO PERSON (MAPERSON, TEN, SODIENTHOAI, EMAIL, DIACHI, GIOITINH) VALUES (@MaPerson, @Ten, @SoDienThoai, @Email, @DiaChi, @GioiTinh)";
            SqlCommand insertCommand = new SqlCommand(insertCommandText, con);
            insertCommand.Parameters.AddWithValue("@MaPerson", maPerson);
            insertCommand.Parameters.AddWithValue("@Ten", ten);
            insertCommand.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
            insertCommand.Parameters.AddWithValue("@Email", email);
            insertCommand.Parameters.AddWithValue("@DiaChi", diaChi);
            insertCommand.Parameters.AddWithValue("@GioiTinh", gioiTinh);

            OpenDB();
            int rowsAffected = insertCommand.ExecuteNonQuery();
            CloseDB();

            return rowsAffected;
        }


        public int XoaNguoiDung(string maPerson)
        {
            string deleteCommandText = "DELETE FROM PERSON WHERE MAPERSON = @MaPerson";
            SqlCommand deleteCommand = new SqlCommand(deleteCommandText, con);
            deleteCommand.Parameters.AddWithValue("@MaPerson", maPerson);

            OpenDB();
            int rowsAffected = deleteCommand.ExecuteNonQuery();
            CloseDB();

            return rowsAffected;
        }

        public int SuaThongTinNguoiDung(string maPerson, string ten, string soDienThoai, string email, string diaChi, string gioiTinh)
        {
            string updateCommandText = "UPDATE PERSON SET TEN = @Ten, SODIENTHOAI = @SDT, EMAIL = @Email, DIACHI = @DiaChi, GIOITINH = @GioiTinh WHERE MAPERSON = @MaPerson";
            SqlCommand updateCommand = new SqlCommand(updateCommandText, con);
            updateCommand.Parameters.AddWithValue("@MaPerson", maPerson);
            updateCommand.Parameters.AddWithValue("@Ten", ten);
            updateCommand.Parameters.AddWithValue("@SDT", soDienThoai);
            updateCommand.Parameters.AddWithValue("@Email", email);
            updateCommand.Parameters.AddWithValue("@DiaChi", diaChi);
            updateCommand.Parameters.AddWithValue("@GioiTinh", gioiTinh);

            OpenDB();
            int rowsAffected = updateCommand.ExecuteNonQuery();
            CloseDB();

            return rowsAffected;
        }

        public int LayGiaTriSoCuoiCungNguoiDung()
        {
            string query = "SELECT MAX(CAST(SUBSTRING(MAPERSON, 4, LEN(MAPERSON)) AS INT)) FROM PERSON WHERE MAPERSON LIKE 'PER%'";

            object result = getExecuteScalar(query);

            if (result != null && result != DBNull.Value)
            {
                return Convert.ToInt32(result);
            }

            return 0;
        }


        #endregion

        #region Quản lý khách hàng

        public int ThemKhachHang(string maKhachHang, string maPerson)
        {
            string query = "INSERT INTO KHACHHANG (MAKHACHHANG, MAPERSON) VALUES (@MaKH, @MaPerson)";
            SqlCommand insertCommand = new SqlCommand(query, con);
            insertCommand.Parameters.AddWithValue("@MaKH", maKhachHang);
            insertCommand.Parameters.AddWithValue("@MaPerson", maPerson);

            OpenDB();
            int rowsAffected = insertCommand.ExecuteNonQuery();
            CloseDB();

            return rowsAffected;
        }

        public int XoaKhachHang(string maKhachHang)
        {
            string query = "DELETE FROM KHACHHANG WHERE MAKHACHHANG = @MaKH";
            SqlCommand deleteCommand = new SqlCommand(query, con);
            deleteCommand.Parameters.AddWithValue("@MaKH", maKhachHang);

            OpenDB();
            int rowsAffected = deleteCommand.ExecuteNonQuery();
            CloseDB();

            return rowsAffected;
        }

        public int CheckMaKH(string maKH)
        {
            string query = "SELECT COUNT(*) FROM KHACHHANG WHERE MAKHACHHANG = @MaKH";
            SqlCommand checkCommant = new SqlCommand(query, con);
            checkCommant.Parameters.AddWithValue("@MaKH", maKH);

            OpenDB();
            int rowsAffected = checkCommant.ExecuteNonQuery();
            CloseDB();

            return rowsAffected;
        }

        public int CapNhatKhachHang(string maKhachHang, string maPerson)
        {
            string query = "UPDATE KHACHHANG SET MAPERSON = @MaPerson WHERE MAKHACHHANG = @MaKH";
            SqlCommand updateCommand = new SqlCommand(query, con);
            updateCommand.Parameters.AddWithValue("@MaKH", maKhachHang);
            updateCommand.Parameters.AddWithValue("@MaPerson", maPerson);

            OpenDB();
            int rowsAffected = updateCommand.ExecuteNonQuery();
            CloseDB();

            return rowsAffected;
        }

        public DataTable LayDanhSachKhachHang()
        {
            string query = "SELECT KHACHHANG.MAKHACHHANG, PERSON.MAPERSON, PERSON.TEN, PERSON.GIOITINH, PERSON.SODIENTHOAI, PERSON.DIACHI, PERSON.EMAIL " +
                "FROM KHACHHANG " +
                "INNER JOIN PERSON ON KHACHHANG.MAPERSON = PERSON.MAPERSON";

            return getDataTable(query);
        }

        public List<string> LayDanhSachMaPerson()
        {
            List<string> danhSachMaPerson = new List<string>();
            string query = "SELECT MAPERSON FROM PERSON";

            using (DataTable dt = getDataTable(query))
            {
                foreach (DataRow row in dt.Rows)
                {
                    danhSachMaPerson.Add(row["MAPERSON"].ToString());
                }
            }

            return danhSachMaPerson;
        }

        public int LayGiaTriSoCuoiCungKhachHang()
        {
            string query = "SELECT MAX(CAST(SUBSTRING(MAKHACHHANG, 5, LEN(MAKHACHHANG)) AS INT)) FROM KHACHHANG WHERE MAKHACHHANG LIKE 'MAKH%'";

            object result = getExecuteScalar(query);

            if (result != null && result != DBNull.Value)
            {
                return Convert.ToInt32(result);
            }

            return 0;
        }


        #endregion

        #region Quản lý nhân viên

        public int ThemNhanVien(string maNhanVien, string maPerson, string chucVu)
        {
            string query = "NSERT INTO NHANVIEN (MANHANVIEN, MAPERSON, CHUCVU) VALUES (@MaNV, @MaPerson, @ChucVu);";
            SqlCommand insertCommand = new SqlCommand(query, con);
            insertCommand.Parameters.AddWithValue("@MaKH", maNhanVien);
            insertCommand.Parameters.AddWithValue("@MaPerson", maPerson);
            insertCommand.Parameters.AddWithValue("@ChucVu", chucVu);

            OpenDB();
            int rowsAffected = insertCommand.ExecuteNonQuery();
            CloseDB();

            return rowsAffected;
        }

        public int XoaNhanVien(string maNhanVien)
        {
            string query = "DELETE FROM NHANVIEN WHERE MANHANVIEN = @MaNV";
            SqlCommand deleteCommand = new SqlCommand(query, con);
            deleteCommand.Parameters.AddWithValue("@MaKH", maNhanVien);

            OpenDB();
            int rowsAffected = deleteCommand.ExecuteNonQuery();
            CloseDB();

            return rowsAffected;
        }

        public int CapNhatNhanVien(string maNhanVien, string maPerson, string chucVu)
        {
            string query = "UPDATE NHANVIEN SET MAPERSON = @MaPerson, CHUCVU = @ChucVu WHERE MANHANVIEN = @MaNV";
            SqlCommand updateCommand = new SqlCommand(query, con);
            updateCommand.Parameters.AddWithValue("@MaNV", maNhanVien);
            updateCommand.Parameters.AddWithValue("@MaPerson", maPerson);
            updateCommand.Parameters.AddWithValue("@ChucVu", chucVu);

            OpenDB();
            int rowsAffected = updateCommand.ExecuteNonQuery();
            CloseDB();

            return rowsAffected;
        }

        public int LayGiaTriSoCuoiCungNhanVien()
        {
            string query = "SELECT MAX(CAST(SUBSTRING(MANHANVIEN, 3, LEN(MANHANVIEN)) AS INT)) FROM NHANVIEN WHERE MANHANVIEN LIKE 'NV%'";

            object result = getExecuteScalar(query);

            if (result != null && result != DBNull.Value)
            {
                return Convert.ToInt32(result);
            }

            return 0;
        }

        public DataTable LayDanhSachNhanVien()
        {
            string query = "SELECT NHANVIEN.MANHANVIEN, PERSON.MAPERSON, PERSON.TEN, NHANVIEN.CHUCVU, PERSON.GIOITINH, PERSON.SODIENTHOAI, PERSON.DIACHI, PERSON.EMAIL " +
            "FROM NHANVIEN " +
            "INNER JOIN PERSON ON NHANVIEN.MAPERSON = PERSON.MAPERSON";

            return getDataTable(query);
        }

        public int CheckMaNV(string maNV)
        {
            string query = "SELECT COUNT(*) FROM NHANVIEN WHERE MANHANVIEN = @MaNV";
            SqlCommand checkCommant = new SqlCommand(query, con);
            checkCommant.Parameters.AddWithValue("@MaNV", maNV);

            OpenDB();
            int rowsAffected = checkCommant.ExecuteNonQuery();
            CloseDB();

            return rowsAffected;
        }

        #endregion
    }
}
