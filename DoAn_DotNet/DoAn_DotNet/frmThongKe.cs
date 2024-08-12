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
    public partial class frmThongKe : Form
    {
        ConnectDB_Vuong db = new ConnectDB_Vuong();
        public frmThongKe()
        {
            InitializeComponent();
            loadCboThang();
            ThongKeTrangThaiDonHang();
            ThongKeSoLuongDoanhThuSanPham();
        }

        private void loadCboThang()
        {
            for (int i = 1; i <= 12; i++)
            {
                cbo_Thang.Items.Add(i);
            }

            int currentYear = DateTime.Now.Year;
            for (int i = 2020; i <= currentYear; i++)
            {
                cbo_Nam.Items.Add(i);
            }

            cbo_Thang.SelectedIndex = DateTime.Now.Month - 1;
            cbo_Nam.SelectedItem = currentYear;
        }

        private void ThongKe()
        {
            if (cbo_Thang.SelectedItem != null && cbo_Nam.SelectedItem != null)
            {
                int selectedMonth = int.Parse(cbo_Thang.SelectedItem.ToString());

                if (cbo_Nam.SelectedItem != null)
                {
                    int selectedYear = int.Parse(cbo_Nam.SelectedItem.ToString());

                    string query = "EXEC usp_ThongKeDoanhThu @Thang = " + selectedMonth + ", @Nam = " + selectedYear;
                    DataTable dataTable = db.getDataTable(query);

                    dataGridView1.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Please select a year."); 
                }
            }
        }

        private void ThongKeTrangThaiDonHang()
        {
            string query = "EXEC usp_ThongKeDonHang";
            DataTable dt = db.getDataTable(query);
            dataGridView2.DataSource = dt;
        }

        private void ThongKeSoLuongDoanhThuSanPham()
        {
            string query = "EXEC usp_ThongKeSanPham";
            DataTable dt = db.getDataTable(query);
            dataGridView3.DataSource = dt;
        }

        private void cbo_Thang_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThongKe();
        }

    }
}
