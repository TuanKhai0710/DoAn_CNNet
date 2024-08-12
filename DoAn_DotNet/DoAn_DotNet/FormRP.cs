using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace DoAn_DotNet
{
    public partial class FormRP : Form
    {
        public FormRP()
        {
            InitializeComponent();
        }

        private void FormRP_Load(object sender, EventArgs e)
        {
            
            DataTable dt = new DataTable();
            ConnectDB_Hao db = new ConnectDB_Hao();
            string query = "SELECT MACHITIETDONHANG, MADONHANG, MACHITIETSANPHAM, SOLUONG, KIEMTRATHANHTOAN FROM CHITIETDONHANG WHERE CHITIETDONHANG.MADONHANG = '"+DonHang.donHang+"'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "CHITIETDONHANG");

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DoAn_DotNet.DonHang.rdlc";
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = ds.Tables["CHITIETDONHANG"];

            this.reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.RefreshReport();

        }
    }
}
