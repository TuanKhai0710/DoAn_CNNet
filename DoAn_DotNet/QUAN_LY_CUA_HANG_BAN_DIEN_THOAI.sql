﻿CREATE DATABASE QUAN_LY_CUA_HANG_BAN_DIEN_THOAI
go
USE QUAN_LY_CUA_HANG_BAN_DIEN_THOAI
go

-- Bảng Sản phẩm
CREATE TABLE TAIKHOAN(
	TENTAIKHOAN VARCHAR(MAX),
	MATKHAU VARCHAR(255),
	LOAITAIKHOAN VARCHAR(255),
);

CREATE TABLE NHACUNGCAP(
	MANCC VARCHAR(10) NOT NULL,
	TENNCC NVARCHAR(MAX),
	DIACHI NVARCHAR(MAX),
	SODIENTHOAI VARCHAR(15),
);

ALTER TABLE NHACUNGCAP
	ADD CONSTRAINT PK_NHACUNGCAP PRIMARY KEY(MANCC), 
		CONSTRAINT CK_SODIENTHOAI CHECK (SODIENTHOAI LIKE '[0-9]%' AND LEN(SODIENTHOAI) <= 15);
		
CREATE TABLE SANPHAM(
	MASANPHAM VARCHAR(10) NOT NULL,
	TenLoai NVARCHAR(MAX) NOT NULL,
);

ALTER TABLE SANPHAM
	ADD CONSTRAINT PK_MASANPHAM PRIMARY KEY(MASANPHAM);
	

CREATE TABLE KHO(
	MAKHO VARCHAR(10) NOT NULL,
	MASANPHAM VARCHAR(10),
	TENKHO NVARCHAR(MAX),
	DIACHIKHO NVARCHAR(MAX),
	SOLUONG INT,
	SODIENTHOAIKHO VARCHAR(15),
);

ALTER TABLE KHO
	ADD CONSTRAINT PK_KHO PRIMARY KEY(MAKHO),
		CONSTRAINT FK_SANPHAM_KHO FOREIGN KEY (MASANPHAM) REFERENCES SANPHAM(MASANPHAM),
		CONSTRAINT CK_SODIENTHOAIKHO CHECK (SODIENTHOAIKHO LIKE '[0-9]%' AND LEN(SODIENTHOAIKHO) <= 15);


CREATE TABLE NHAPKHO(
	MANHAPKHO VARCHAR(10) NOT NULL,
	MASANPHAM VARCHAR(10),
	MAKHO VARCHAR(10),
	SOLUONG INT,
	DONGIA FLOAT,
	NGAYNHAP DATETIME,
	MANCC VARCHAR(10),
);
ALTER TABLE NHAPKHO
	ADD CONSTRAINT PK_NHAPKHO PRIMARY KEY(MANHAPKHO),
		CONSTRAINT FK_SANPHAM_NHAPKHO FOREIGN KEY (MASANPHAM) REFERENCES SANPHAM(MASANPHAM),
		CONSTRAINT FK_NHACUNGCAP_NHAPKHO FOREIGN KEY (MANCC) REFERENCES NHACUNGCAP(MANCC),
		CONSTRAINT FK_KHO_NHAPKHO FOREIGN KEY (MAKHO) REFERENCES KHO(MAKHO),
		CONSTRAINT CK_SOLUONG CHECK(SOLUONG > 0),
		CONSTRAINT CK_DONGIA CHECK(DONGIA > 0);
	
CREATE TABLE XUATKHO(
	MAXUATKHO VARCHAR(10) NOT NULL,
	MAKHO VARCHAR(10),
	MASANPHAM VARCHAR(10),
	SOLUONG INT,
	DONGIA FLOAT,
	NGAYXUAT DATETIME,
);

ALTER TABLE XUATKHO
	ADD CONSTRAINT PK_XUATKHO PRIMARY KEY(MAXUATKHO),
		CONSTRAINT FK_KHO_XUATKHO FOREIGN KEY (MAKHO) REFERENCES KHO(MAKHO),
		CONSTRAINT FK_SANPHAM_XUATKHO FOREIGN KEY(MASANPHAM) REFERENCES SANPHAM(MASANPHAM);
	
	
CREATE TABLE CHITIETSANPHAM(
	MACHITIETSANPHAM VARCHAR(10) NOT NULL,
	MASANPHAM VARCHAR(10),
	TENSANPHAM NVARCHAR(MAX),
	GIA FLOAT,
	MAUSAC NVARCHAR(MAX),
	MOTASANPHAM NVARCHAR(MAX),
	HINHANH VARCHAR(MAX),
);

ALTER TABLE CHITIETSANPHAM
	ADD CONSTRAINT PK_CHITIETSANPHAM PRIMARY KEY(MACHITIETSANPHAM),
		CONSTRAINT FK_SANPHAM_CHITIETSANPHAM FOREIGN KEY (MASANPHAM) REFERENCES SANPHAM(MASANPHAM);


CREATE TABLE PERSON(
	MAPERSON VARCHAR(10) NOT NULL,
	TEN NVARCHAR(MAX),
	SODIENTHOAI VARCHAR(15),
	EMAIL VARCHAR(MAX),
	DIACHI NVARCHAR(MAX),
	GIOITINH NVARCHAR(10),
);

ALTER TABLE PERSON
	ADD CONSTRAINT PK_PERSON PRIMARY KEY(MAPERSON),
		CONSTRAINT CK_SODIENTHOAIPERSON CHECK (SODIENTHOAI LIKE '[0-9]%' AND LEN(SODIENTHOAI) <= 15);


CREATE TABLE DONHANG(
	MADONHANG VARCHAR(10) NOT NULL,
	MAKHACHHANG VARCHAR(10),
	NGAYDATHANG DATETIME,
	TRANGTHAI NVARCHAR(20),
	TONGTIEN FLOAT,
);

CREATE TABLE KHACHHANG(
	MAKHACHHANG VARCHAR(10) NOT NULL,
	MAPERSON VARCHAR(10),
);

ALTER TABLE KHACHHANG
	ADD CONSTRAINT PK_KHACHHANG PRIMARY KEY(MAKHACHHANG),
		CONSTRAINT FK_PEROSON_KHACHHANG FOREIGN KEY (MAPERSON) REFERENCES PERSON(MAPERSON);

ALTER TABLE DONHANG
	ADD CONSTRAINT PK_DONHANG PRIMARY KEY(MADONHANG),
		CONSTRAINT FK_KHACHHANG_DONHANG FOREIGN KEY (MAKHACHHANG) REFERENCES KHACHHANG(MAKHACHHANG);

CREATE TABLE NHANVIEN(
	MANHANVIEN VARCHAR(10) NOT NULL,
	MAPERSON VARCHAR(10),
	CHUCVU NVARCHAR(25),
);

ALTER TABLE NHANVIEN
	ADD CONSTRAINT PK_NHANVIEN PRIMARY KEY(MANHANVIEN),
		CONSTRAINT FK_PEROSON_NHANVIEN FOREIGN KEY (MAPERSON) REFERENCES PERSON(MAPERSON);



CREATE TABLE CHITIETDONHANG(
	MACHITIETDONHANG VARCHAR(255) NOT NULL,
	MADONHANG VARCHAR(10) NOT NULL,
	MACHITIETSANPHAM VARCHAR(10) NOT NULL,
	SOLUONG INT,
	KIEMTRATHANHTOAN BIT,
);

ALTER TABLE CHITIETDONHANG
	ADD CONSTRAINT PK_CHITIETDONHANG PRIMARY KEY(MACHITIETDONHANG, MADONHANG, MACHITIETSANPHAM),
		CONSTRAINT FK_CHITIETSANPHAM_CHITIETDONHANG FOREIGN KEY (MACHITIETSANPHAM) REFERENCES CHITIETSANPHAM(MACHITIETSANPHAM),
		CONSTRAINT FK_DONHANG_CHITIETDONHANG FOREIGN KEY (MADONHANG) REFERENCES DONHANG(MADONHANG),
		CONSTRAINT CK_SOLUONG_CTDH CHECK (SOLUONG > 0)

CREATE TABLE THANHTOANDONHANG(
	MATHANHTOANDONHANG VARCHAR(10) NOT NULL,
	MADONHANG VARCHAR(10),
	NGAYTHANHTOAN DATETIME,
	TONGTIEN FLOAT,
);

ALTER TABLE THANHTOANDONHANG
	ADD CONSTRAINT PK_THANHTOANDONHANG PRIMARY KEY(MATHANHTOANDONHANG),
		CONSTRAINT FK_DONHANG_THANHTOANDONHANG FOREIGN KEY (MADONHANG) REFERENCES DONHANG(MADONHANG);
		

CREATE TABLE QUANGCAO(
	MAQUANGCAO VARCHAR(10) NOT NULL,
	TENQUANGCAO NVARCHAR(MAX),
	HINHANH VARCHAR(MAX),
);

ALTER TABLE QUANGCAO
	ADD CONSTRAINT PK_QUANGCAO PRIMARY KEY(MAQUANGCAO);

CREATE TABLE VITRICUAHANG(
	MAVITRICUAHANG VARCHAR(10) NOT NULL,
	TENVITRICUAHANG NVARCHAR(MAX),
	DIACHICUAHANG NVARCHAR(MAX),
);

ALTER TABLE VITRICUAHANG
	ADD CONSTRAINT PK_VITRICUAHANG PRIMARY KEY(MAVITRICUAHANG);

SET DATEFORMAT DMY

GO
INSERT INTO TAIKHOAN (TENTAIKHOAN, MATKHAU, LOAITAIKHOAN)
VALUES
('Admin', '123', 'admin'),
('hao', '123', 'nhanvien'),
('vuong', '123', 'nhanvien'),
('khai', '123', 'nhanvien'),
('quang', '123', 'nhanvien');



-- Dữ liệu cho bảng NHACUNGCAP
INSERT INTO NHACUNGCAP (MANCC, TENNCC, DIACHI, SODIENTHOAI)
VALUES
('NCC1', N'Apple', N'Hoa Kỳ', '0123456789'),
('NCC2', N'SamSung', N'Hàn Quốc', '0987654321'),
('NCC3', N'Xiaomi', N'Trung Quốc', '0369871245'),
('NCC4', N'Redmi', N'Trung Quốc', '0312457896'),
('NCC5', N'Nokia', N'Phần Lan', '0758213694');

-- Dữ liệu cho bảng KHO
INSERT INTO KHO (MAKHO, TENKHO, DIACHIKHO, SODIENTHOAIKHO)
VALUES
('KHO1', 'Kho 1' ,N'140 Lê Trọng Tấn', '0123456789'),
('KHO2', 'Kho 2' ,N'Bình Dương', '0987654321'),
('KHO3', 'Kho 3',N'Bình Phước', '0369871245'),
('KHO4', 'Kho 4', N'Long An', '0312457896'),
('KHO5', 'Kho 5', N'Cần Thơ', '0758213694');

-- Dữ liệu cho bảng SANPHAM
INSERT INTO SANPHAM (MASANPHAM, TENLOAI)
VALUES
('SP1',N'SamSung'),
('SP2',N'Iphone'),
('SP3',N'Xiaomi'),
('SP4',N'Redmi'),
('SP5',N'Nokia');

-- Dữ liệu cho bảng NHAPKHO
INSERT INTO NHAPKHO (MANHAPKHO, MASANPHAM, MAKHO, SOLUONG, DONGIA, NGAYNHAP, MANCC)
VALUES
('NHAP1', 'SP1', 'KHO1', 100, 5000000, '10-12-2023', 'NCC1'),
('NHAP2', 'SP2', 'KHO2', 150, 6000000, '10-12-2023', 'NCC2'),
('NHAP3', 'SP3', 'KHO3', 200, 4500000, '10-12-2023', 'NCC3'),
('NHAP4', 'SP4', 'KHO4', 120, 5500000, '10-12-2023', 'NCC4'),
('NHAP5', 'SP5', 'KHO5', 180, 7000000, '10-12-2023', 'NCC5');

-- Dữ liệu cho bảng XUATKHO
INSERT INTO XUATKHO (MAXUATKHO, MAKHO, MASANPHAM, SOLUONG, DONGIA, NGAYXUAT)
VALUES
('XUAT1', 'KHO1', 'SP1' ,50, 6000000, '10-12-2023'),
('XUAT2', 'KHO2', 'SP2' ,70, 7000000, '10-12-2023'),
('XUAT3', 'KHO3', 'SP3' ,90, 7500000, '10-12-2023'),
('XUAT4', 'KHO4', 'SP4' ,60, 6500000, '10-12-2023'),
('XUAT5', 'KHO5', 'SP5' ,80, 8000000, '10-12-2023');

-- Dữ liệu cho bảng CHITIETSANPHAM
INSERT INTO CHITIETSANPHAM (MACHITIETSANPHAM, MASANPHAM, TENSANPHAM, GIA, MAUSAC, MOTASANPHAM, HINHANH)
VALUES
('CTSP1', 'SP1', N'SamSung Galaxy Note 20', 5000000, N'Đen', N'Mô tả sản phẩm 1', 'image1.jpg'),
('CTSP2', 'SP2', N'Iphone 14 Promax', 6000000, N'Trắng', N'Mô tả sản phẩm 2', 'image2.jpg'),
('CTSP3', 'SP3', N'Xiaomi Redmi Note 11', 4500000, N'Xanh', N'Mô tả sản phẩm 3', 'image3.jpg'),
('CTSP4', 'SP4', N'Redmi 7', 5500000, N'Đỏ', N'Mô tả sản phẩm 4', 'image4.jpg'),
('CTSP5', 'SP5', N'Nokia 1280', 7000000, N'Vàng', N'Mô tả sản phẩm 5', 'image5.jpg');


-- Dữ liệu cho bảng PERSON
INSERT INTO PERSON (MAPERSON, TEN, SODIENTHOAI, EMAIL, DIACHI, GIOITINH)
VALUES
('PER1', N'Võ Nhựt Hào', '0388533247Hao', 'vonhuthao11235@email.com', N'TP.HCM', N'Nam'),
('PER2', N'Lê Viết Tuấn Khải', '0987654321', 'user2@email.com', N'TP.HCM', N'Nam'),
('PER3', N'Trần Trọng Vương', '0369871245', 'user3@email.com', N'TP.HCM', N'Nam'),
('PER4', N'Hồ Minh Quang', '0312457896', 'user4@email.com', N'TP.HCM', N'Nam'),
('PER5', N'Lê Thị Bé Ba', '0758213694', 'user5@email.com', N'TP.HCM', N'Nữ'),
('PER6', N'Võ Nhựt Hào', '0388533247Hao', 'vonhuthao11235@email.com', N'TP.HCM', N'Nam'),
('PER7', N'Lê Viết Tuấn Khải', '0987654321', 'user2@email.com', N'TP.HCM', N'Nam'),
('PER8', N'Trần Trọng Vương', '0369871245', 'user3@email.com', N'TP.HCM', N'Nam'),
('PER9', N'Hồ Minh Quang', '0312457896', 'user4@email.com', N'TP.HCM', N'Nam'),
('PER10', N'Lê Thị Bé Ba', '0758213694', 'user5@email.com', N'TP.HCM', N'Nữ');
-- Dữ liệu cho bảng KHACHHANG
INSERT INTO KHACHHANG (MAKHACHHANG, MAPERSON)
VALUES
('MAKH1', 'PER1'),
('MAKH2', 'PER2'),
('MAKH3', 'PER3'),
('MAKH4', 'PER4'),
('MAKH5', 'PER5');
-- Dữ liệu cho bảng DONHANG
SET DATEFORMAT DMY
INSERT INTO DONHANG (MADONHANG, MAKHACHHANG, NGAYDATHANG, TRANGTHAI)
VALUES
('DH1', 'MAKH1', '16-10-2023', N'Chờ xử lý'),
('DH2', 'MAKH2', '16-10-2023 ', N'Đã giao hàng'),
('DH3', 'MAKH3', '17-10-2023 ', N'Đã thanh toán'),
('DH4', 'MAKH4', '15-10-2023 ', N'Đã giao hàng'),
('DH5', 'MAKH5', '20-10-2023 ', N'Chờ xử lý');

INSERT INTO DONHANG (MADONHANG, MAKHACHHANG, NGAYDATHANG, TRANGTHAI)
VALUES
('DH6', 'MAKH1', '16-04-2023', N'Chờ xử lý'),
('DH7', 'MAKH2', '16-05-2023 ', N'Đã giao hàng'),
('DH8', 'MAKH3', '17-06-2023 ', N'Đã thanh toán'),
('DH9', 'MAKH4', '15-11-2023 ', N'Đã giao hàng'),
('DH10', 'MAKH5', '20-12-2023 ', N'Chờ xử lý');

-- Dữ liệu cho bảng NHANVIEN
INSERT INTO NHANVIEN (MANHANVIEN, MAPERSON, CHUCVU)
VALUES
('NV1', 'PER6', N'Nhân viên bán hàng'),
('NV2', 'PER7', N'Nhân viên kho'),
('NV3', 'PER8', N'Quản lý cửa hàng'),
('NV4', 'PER9', N'Nhân viên kỹ thuật'),
('NV5', 'PER10', N'Quản lý bán hàng');

-- Dữ liệu cho bảng CHITIETDONHANG
INSERT INTO CHITIETDONHANG (MACHITIETDONHANG, MADONHANG, MACHITIETSANPHAM, SOLUONG, KIEMTRATHANHTOAN)
VALUES
('CTDH1', 'DH1', 'CTSP1', 2, 0),
('CTDH2', 'DH1', 'CTSP2', 3, 0),
('CTDH3', 'DH2', 'CTSP3', 4, 1),
('CTDH4', 'DH3', 'CTSP4', 1, 1),
('CTDH5', 'DH4', 'CTSP5', 5, 0),
('CTDH1', 'DH1', 'CTSP2', 2, 1)

INSERT INTO CHITIETDONHANG (MACHITIETDONHANG, MADONHANG, MACHITIETSANPHAM, SOLUONG, KIEMTRATHANHTOAN)
VALUES
('CTDH6', 'DH6', 'CTSP1', 2, 0),
('CTDH7', 'DH7', 'CTSP2', 3, 0),
('CTDH8', 'DH8', 'CTSP3', 4, 1),
('CTDH9', 'DH9', 'CTSP4', 1, 1),
('CTDH10', 'DH10', 'CTSP5', 5, 0),
('CTDH11', 'DH1', 'CTSP2', 2, 1)

-- Dữ liệu cho bảng THANHTOANDONHANG
INSERT INTO THANHTOANDONHANG (MATHANHTOANDONHANG, MADONHANG, NGAYTHANHTOAN, TONGTIEN)
VALUES
('TT1', 'DH1', '10-12-2023', 15000000),
('TT2', 'DH2', '10-12-2023', 18000000),
('TT3', 'DH3', '10-12-2023', 20000000),
('TT4', 'DH4', '10-12-2023', 5500000),
('TT5', 'DH5', '10-12-2023', 3500000);

INSERT INTO THANHTOANDONHANG (MATHANHTOANDONHANG, MADONHANG, NGAYTHANHTOAN, TONGTIEN)
VALUES
('TT6', 'DH6', '10-4-2023', 15000000),
('TT7', 'DH7', '10-5-2023', 18000000),
('TT8', 'DH8', '10-6-2023', 20000000),
('TT9', 'DH9', '10-11-2023', 5500000),
('TT10', 'DH10', '10-12-2023', 3500000);


-- Dữ liệu cho bảng QUANGCAO
INSERT INTO QUANGCAO (MAQUANGCAO, TENQUANGCAO, HINHANH)
VALUES
('QC1', N'Quảng cáo 1', 'image_qc1.jpg'),
('QC2', N'Quảng cáo 2', 'image_qc2.jpg'),
('QC3', N'Quảng cáo 3', 'image_qc3.jpg'),
('QC4', N'Quảng cáo 4', 'image_qc4.jpg'),
('QC5', N'Quảng cáo 5', 'image_qc5.jpg');

-- Dữ liệu cho bảng VITRICUAHANG
INSERT INTO VITRICUAHANG (MAVITRICUAHANG, TENVITRICUAHANG, DIACHICUAHANG)
VALUES
('VCH1', N'Cửa hàng 1', N'Địa chỉ cửa hàng 1'),
('VCH2', N'Cửa hàng 2', N'Địa chỉ cửa hàng 2'),
('VCH3', N'Cửa hàng 3', N'Địa chỉ cửa hàng 3'),
('VCH4', N'Cửa hàng 4', N'Địa chỉ cửa hàng 4'),
('VCH5', N'Cửa hàng 5', N'Địa chỉ cửa hàng 5');

UPDATE DONHANG
SET TONGTIEN = 
	(SELECT SUM(SOLUONG * GIA) FROM CHITIETDONHANG
			INNER JOIN CHITIETSANPHAM ON CHITIETDONHANG.MACHITIETSANPHAM = CHITIETSANPHAM.MACHITIETSANPHAM
			WHERE CHITIETDONHANG.MADONHANG = DONHANG.MADONHANG)

UPDATE DONHANG SET TONGTIEN = (SELECT SUM(SOLUONG * GIA) FROM CHITIETDONHANG 
INNER JOIN CHITIETSANPHAM ON CHITIETDONHANG.MACHITIETSANPHAM = CHITIETSANPHAM.MACHITIETSANPHAM WHERE CHITIETDONHANG.MADONHANG = DONHANG.MADONHANG)

GO
CREATE PROCEDURE usp_ThongKeDoanhThu
    @Thang INT,
    @Nam INT
AS
BEGIN
    SELECT MONTH(NGAYDATHANG) AS Thang, YEAR(NGAYDATHANG) AS Nam, SUM(TONGTIEN) AS TongDoanhThu
    FROM DONHANG
    WHERE MONTH(NGAYDATHANG) = @Thang AND YEAR(NGAYDATHANG) = @Nam
    GROUP BY MONTH(NGAYDATHANG), YEAR(NGAYDATHANG)
    ORDER BY Nam, Thang;
END;

GO
CREATE PROCEDURE usp_ThongKeDonHang
AS
BEGIN
    SELECT TRANGTHAI, COUNT(MADONHANG) AS SoLuongDonHang, STRING_AGG(MADONHANG, ', ') AS DanhSachMaDonHang
    FROM DONHANG
    GROUP BY TRANGTHAI
    ORDER BY SoLuongDonHang DESC;
END;

GO

CREATE PROCEDURE usp_ThongKeSanPham
AS
BEGIN
    SELECT 
        SANPHAM.MASANPHAM, 
        CHITIETSANPHAM.TENSANPHAM, 
        SUM(CHITIETDONHANG.SOLUONG) AS SoLuong, 
        SUM(CHITIETDONHANG.SOLUONG * CHITIETSANPHAM.GIA) AS DoanhThu
    FROM 
        CHITIETDONHANG
    INNER JOIN 
        CHITIETSANPHAM ON CHITIETDONHANG.MACHITIETSANPHAM = CHITIETSANPHAM.MACHITIETSANPHAM
    INNER JOIN 
        SANPHAM ON SANPHAM.MASANPHAM = CHITIETSANPHAM.MASANPHAM
    GROUP BY 
        SANPHAM.MASANPHAM, 
        CHITIETSANPHAM.TENSANPHAM
    ORDER BY 
        DoanhThu DESC;
END;