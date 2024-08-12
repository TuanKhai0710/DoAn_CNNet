namespace DoAn_DotNet
{
    partial class DonHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_TongTien = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_MaDonHang = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cbo_KhachHang = new System.Windows.Forms.ComboBox();
            this.cbo_SanPham = new System.Windows.Forms.ComboBox();
            this.lbl_DonGia = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv_ListCTDH = new System.Windows.Forms.DataGridView();
            this.MACHITIETDONHANG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MADONHANG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MACHITIETSANPHAM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOLUONG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KIEMTRATHANHTOAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.numUD_SoLuong = new System.Windows.Forms.NumericUpDown();
            this.btn_Them = new System.Windows.Forms.Button();
            this.lbl_TenSanPham = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl_GioiTinh = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_TaoHoaDon = new System.Windows.Forms.Button();
            this.lbl_TongTienThucTra = new System.Windows.Forms.Label();
            this.lbl_DienThoai = new System.Windows.Forms.Label();
            this.lbl_DiaChi = new System.Windows.Forms.Label();
            this.lbl_TenKhachHang = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lbl_NgayLap = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListCTDH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_SoLuong)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_TongTien);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txt_MaDonHang);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.cbo_KhachHang);
            this.groupBox1.Controls.Add(this.cbo_SanPham);
            this.groupBox1.Controls.Add(this.lbl_DonGia);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numUD_SoLuong);
            this.groupBox1.Controls.Add(this.btn_Them);
            this.groupBox1.Controls.Add(this.lbl_TenSanPham);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(15, 24);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(779, 575);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin mua hàng";
            // 
            // lbl_TongTien
            // 
            this.lbl_TongTien.AutoSize = true;
            this.lbl_TongTien.Location = new System.Drawing.Point(356, 533);
            this.lbl_TongTien.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_TongTien.Name = "lbl_TongTien";
            this.lbl_TongTien.Size = new System.Drawing.Size(0, 22);
            this.lbl_TongTien.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(422, 44);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 22);
            this.label9.TabIndex = 15;
            this.label9.Text = "Mã Đơn Hàng";
            // 
            // txt_MaDonHang
            // 
            this.txt_MaDonHang.Location = new System.Drawing.Point(528, 41);
            this.txt_MaDonHang.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txt_MaDonHang.Name = "txt_MaDonHang";
            this.txt_MaDonHang.Size = new System.Drawing.Size(228, 30);
            this.txt_MaDonHang.TabIndex = 14;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(272, 533);
            this.label16.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(95, 22);
            this.label16.TabIndex = 18;
            this.label16.Text = "Tổng tiền :";
            // 
            // cbo_KhachHang
            // 
            this.cbo_KhachHang.FormattingEnabled = true;
            this.cbo_KhachHang.Location = new System.Drawing.Point(144, 41);
            this.cbo_KhachHang.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbo_KhachHang.Name = "cbo_KhachHang";
            this.cbo_KhachHang.Size = new System.Drawing.Size(214, 30);
            this.cbo_KhachHang.TabIndex = 13;
            this.cbo_KhachHang.SelectedIndexChanged += new System.EventHandler(this.cbo_KhachHang_SelectedIndexChanged);
            // 
            // cbo_SanPham
            // 
            this.cbo_SanPham.FormattingEnabled = true;
            this.cbo_SanPham.Location = new System.Drawing.Point(144, 80);
            this.cbo_SanPham.Margin = new System.Windows.Forms.Padding(6);
            this.cbo_SanPham.Name = "cbo_SanPham";
            this.cbo_SanPham.Size = new System.Drawing.Size(214, 30);
            this.cbo_SanPham.TabIndex = 12;
            this.cbo_SanPham.SelectedIndexChanged += new System.EventHandler(this.cbo_SanPham_SelectedIndexChanged);
            // 
            // lbl_DonGia
            // 
            this.lbl_DonGia.AutoSize = true;
            this.lbl_DonGia.Location = new System.Drawing.Point(144, 165);
            this.lbl_DonGia.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_DonGia.Name = "lbl_DonGia";
            this.lbl_DonGia.Size = new System.Drawing.Size(0, 22);
            this.lbl_DonGia.TabIndex = 11;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgv_ListCTDH);
            this.groupBox3.Location = new System.Drawing.Point(28, 238);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox3.Size = new System.Drawing.Size(728, 289);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách sản phẩm chọn";
            // 
            // dgv_ListCTDH
            // 
            this.dgv_ListCTDH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ListCTDH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MACHITIETDONHANG,
            this.MADONHANG,
            this.MACHITIETSANPHAM,
            this.SOLUONG,
            this.KIEMTRATHANHTOAN});
            this.dgv_ListCTDH.Location = new System.Drawing.Point(12, 31);
            this.dgv_ListCTDH.Margin = new System.Windows.Forms.Padding(6);
            this.dgv_ListCTDH.Name = "dgv_ListCTDH";
            this.dgv_ListCTDH.RowHeadersWidth = 51;
            this.dgv_ListCTDH.Size = new System.Drawing.Size(693, 235);
            this.dgv_ListCTDH.TabIndex = 0;
            this.dgv_ListCTDH.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ListSanPham_CellContentClick);
            // 
            // MACHITIETDONHANG
            // 
            this.MACHITIETDONHANG.DataPropertyName = "MACHITIETDONHANG";
            this.MACHITIETDONHANG.HeaderText = "Mã CT đơn hàng";
            this.MACHITIETDONHANG.MinimumWidth = 6;
            this.MACHITIETDONHANG.Name = "MACHITIETDONHANG";
            this.MACHITIETDONHANG.Width = 150;
            // 
            // MADONHANG
            // 
            this.MADONHANG.DataPropertyName = "MADONHANG";
            this.MADONHANG.HeaderText = "Mã đơn hàng";
            this.MADONHANG.MinimumWidth = 6;
            this.MADONHANG.Name = "MADONHANG";
            this.MADONHANG.Width = 150;
            // 
            // MACHITIETSANPHAM
            // 
            this.MACHITIETSANPHAM.DataPropertyName = "MACHITIETSANPHAM";
            this.MACHITIETSANPHAM.HeaderText = "Mã chi tiết sản phẩm";
            this.MACHITIETSANPHAM.MinimumWidth = 6;
            this.MACHITIETSANPHAM.Name = "MACHITIETSANPHAM";
            this.MACHITIETSANPHAM.Width = 150;
            // 
            // SOLUONG
            // 
            this.SOLUONG.DataPropertyName = "SOLUONG";
            this.SOLUONG.HeaderText = "Số lượng";
            this.SOLUONG.MinimumWidth = 6;
            this.SOLUONG.Name = "SOLUONG";
            this.SOLUONG.Width = 125;
            // 
            // KIEMTRATHANHTOAN
            // 
            this.KIEMTRATHANHTOAN.DataPropertyName = "KIEMTRATHANHTOAN";
            this.KIEMTRATHANHTOAN.HeaderText = "Kiểm tra thanh toán";
            this.KIEMTRATHANHTOAN.MinimumWidth = 6;
            this.KIEMTRATHANHTOAN.Name = "KIEMTRATHANHTOAN";
            this.KIEMTRATHANHTOAN.Width = 125;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(422, 83);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 22);
            this.label4.TabIndex = 9;
            this.label4.Text = "Số Lượng";
            // 
            // numUD_SoLuong
            // 
            this.numUD_SoLuong.Location = new System.Drawing.Point(528, 81);
            this.numUD_SoLuong.Margin = new System.Windows.Forms.Padding(6);
            this.numUD_SoLuong.Name = "numUD_SoLuong";
            this.numUD_SoLuong.Size = new System.Drawing.Size(228, 30);
            this.numUD_SoLuong.TabIndex = 8;
            // 
            // btn_Them
            // 
            this.btn_Them.Location = new System.Drawing.Point(290, 188);
            this.btn_Them.Margin = new System.Windows.Forms.Padding(6);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(101, 38);
            this.btn_Them.TabIndex = 7;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // lbl_TenSanPham
            // 
            this.lbl_TenSanPham.Location = new System.Drawing.Point(144, 113);
            this.lbl_TenSanPham.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_TenSanPham.Name = "lbl_TenSanPham";
            this.lbl_TenSanPham.Size = new System.Drawing.Size(214, 38);
            this.lbl_TenSanPham.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 165);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Đơn giá";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 124);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên sản phẩm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 83);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn sản phẩm";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 44);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 22);
            this.label7.TabIndex = 2;
            this.label7.Text = "Mã khách hàng :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbl_GioiTinh);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.lbl_Email);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.btn_TaoHoaDon);
            this.groupBox2.Controls.Add(this.lbl_TongTienThucTra);
            this.groupBox2.Controls.Add(this.lbl_DienThoai);
            this.groupBox2.Controls.Add(this.lbl_DiaChi);
            this.groupBox2.Controls.Add(this.lbl_TenKhachHang);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(843, 159);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox2.Size = new System.Drawing.Size(355, 440);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin hóa đơn";
            // 
            // lbl_GioiTinh
            // 
            this.lbl_GioiTinh.AutoSize = true;
            this.lbl_GioiTinh.Location = new System.Drawing.Point(159, 167);
            this.lbl_GioiTinh.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_GioiTinh.Name = "lbl_GioiTinh";
            this.lbl_GioiTinh.Size = new System.Drawing.Size(113, 22);
            this.lbl_GioiTinh.TabIndex = 24;
            this.lbl_GioiTinh.Text = "lbl_GioiTinh";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(26, 167);
            this.label13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 22);
            this.label13.TabIndex = 23;
            this.label13.Text = "Giới Tính :";
            // 
            // lbl_Email
            // 
            this.lbl_Email.AutoSize = true;
            this.lbl_Email.Location = new System.Drawing.Point(159, 135);
            this.lbl_Email.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(89, 22);
            this.lbl_Email.TabIndex = 22;
            this.lbl_Email.Text = "lbl_Email";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(26, 135);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 22);
            this.label11.TabIndex = 21;
            this.label11.Text = "Email :";
            // 
            // btn_TaoHoaDon
            // 
            this.btn_TaoHoaDon.Location = new System.Drawing.Point(92, 323);
            this.btn_TaoHoaDon.Margin = new System.Windows.Forms.Padding(6);
            this.btn_TaoHoaDon.Name = "btn_TaoHoaDon";
            this.btn_TaoHoaDon.Size = new System.Drawing.Size(160, 38);
            this.btn_TaoHoaDon.TabIndex = 18;
            this.btn_TaoHoaDon.Text = "Tạo Hóa Đơn";
            this.btn_TaoHoaDon.UseVisualStyleBackColor = true;
            this.btn_TaoHoaDon.Click += new System.EventHandler(this.btn_TaoHoaDon_Click);
            // 
            // lbl_TongTienThucTra
            // 
            this.lbl_TongTienThucTra.AutoSize = true;
            this.lbl_TongTienThucTra.Location = new System.Drawing.Point(165, 217);
            this.lbl_TongTienThucTra.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_TongTienThucTra.Name = "lbl_TongTienThucTra";
            this.lbl_TongTienThucTra.Size = new System.Drawing.Size(182, 22);
            this.lbl_TongTienThucTra.TabIndex = 16;
            this.lbl_TongTienThucTra.Text = "lbl_TongTienThucTra";
            // 
            // lbl_DienThoai
            // 
            this.lbl_DienThoai.AutoSize = true;
            this.lbl_DienThoai.Location = new System.Drawing.Point(159, 103);
            this.lbl_DienThoai.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_DienThoai.Name = "lbl_DienThoai";
            this.lbl_DienThoai.Size = new System.Drawing.Size(126, 22);
            this.lbl_DienThoai.TabIndex = 12;
            this.lbl_DienThoai.Text = "lbl_DienThoai";
            // 
            // lbl_DiaChi
            // 
            this.lbl_DiaChi.AutoSize = true;
            this.lbl_DiaChi.Location = new System.Drawing.Point(159, 72);
            this.lbl_DiaChi.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_DiaChi.Name = "lbl_DiaChi";
            this.lbl_DiaChi.Size = new System.Drawing.Size(99, 22);
            this.lbl_DiaChi.TabIndex = 11;
            this.lbl_DiaChi.Text = "lbl_DiaChi";
            // 
            // lbl_TenKhachHang
            // 
            this.lbl_TenKhachHang.AutoSize = true;
            this.lbl_TenKhachHang.Location = new System.Drawing.Point(159, 41);
            this.lbl_TenKhachHang.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_TenKhachHang.Name = "lbl_TenKhachHang";
            this.lbl_TenKhachHang.Size = new System.Drawing.Size(162, 22);
            this.lbl_TenKhachHang.TabIndex = 10;
            this.lbl_TenKhachHang.Text = "lbl_TenKhachHang";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(26, 217);
            this.label15.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(165, 22);
            this.label15.TabIndex = 6;
            this.label15.Text = "Tổng tiền thực trả : ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 103);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 22);
            this.label10.TabIndex = 5;
            this.label10.Text = "Điện thoại :";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(26, 72);
            this.label.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(79, 22);
            this.label.TabIndex = 4;
            this.label.Text = "Địa chỉ :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 41);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(141, 22);
            this.label8.TabIndex = 3;
            this.label8.Text = "Tên Khách Hàng";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(839, 34);
            this.label14.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 22);
            this.label14.TabIndex = 6;
            this.label14.Text = "Ngày :";
            // 
            // lbl_NgayLap
            // 
            this.lbl_NgayLap.AutoSize = true;
            this.lbl_NgayLap.Location = new System.Drawing.Point(913, 34);
            this.lbl_NgayLap.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_NgayLap.Name = "lbl_NgayLap";
            this.lbl_NgayLap.Size = new System.Drawing.Size(0, 22);
            this.lbl_NgayLap.TabIndex = 7;
            // 
            // DonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1305, 761);
            this.Controls.Add(this.lbl_NgayLap);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "DonHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.DonHang_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListCTDH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_SoLuong)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numUD_SoLuong;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Label lbl_TenSanPham;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv_ListCTDH;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbl_TongTienThucTra;
        private System.Windows.Forms.Label lbl_DienThoai;
        private System.Windows.Forms.Label lbl_DiaChi;
        private System.Windows.Forms.Label lbl_TenKhachHang;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_DonGia;
        private System.Windows.Forms.ComboBox cbo_SanPham;
        private System.Windows.Forms.Label lbl_TongTien;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btn_TaoHoaDon;
        private System.Windows.Forms.Label lbl_GioiTinh;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbo_KhachHang;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_MaDonHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn MACHITIETDONHANG;
        private System.Windows.Forms.DataGridViewTextBoxColumn MADONHANG;
        private System.Windows.Forms.DataGridViewTextBoxColumn MACHITIETSANPHAM;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOLUONG;
        private System.Windows.Forms.DataGridViewTextBoxColumn KIEMTRATHANHTOAN;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbl_NgayLap;
    }
}

