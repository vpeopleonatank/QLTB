IF EXISTS(SELECT * FROM sys.databases WHERE name = 'QLKARAOKE')
begin
	 use master
	alter database QLKARAOKE set single_user with rollback immediate
	Drop Database QLKARAOKE
end

IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'QLKARAOKE')
BEGIN
CREATE DATABASE QLKARAOKE
END
GO
 USE QLKARAOKE
GO

Create table PHONG (
	MaPhong varchar(10) not null primary key,
	LoaiPhong nvarchar(30),
	SoKhachToiDa int,
	GiaPhong float,
	MoTa nvarchar(50)
);
GO

Create table KHACH_HANG (
	MaKH varchar(10) not null primary key,
	TenKH nvarchar(50),
	DiaChi nvarchar(50),
	SoDT varchar(20)
);
GO

Create table DICH_VU_DI_KEM (
	MaDV varchar(10) not null primary key,
	TenDV nvarchar(50),
	DonViTinh nvarchar(20),
	DonGia float
);
GO

Create table DAT_PHONG (
	MaDatPhong varchar(10) not null,
	MaPhong varchar(10) not null FOREIGN KEY REFERENCES Phong(MaPhong),
	MaKH varchar(10) not null FOREIGN KEY REFERENCES KHACH_HANG(MaKH),
	NgayDat date,
	GioBatDau time,
	GioKetThuc time,
	TienDatCoc decimal,
	GhiChu nvarchar(50),
	TrangThaiDat nvarchar(10)
);
GO

Create table CHI_TIET_SU_DUNG_DICH_VU (
	MaDatPhong varchar(10) not null,
	MaDV varchar(10) not null FOREIGN KEY REFERENCES DICH_VU_DI_KEM(MaDV),
	SoLuong int,
	primary key(MaDatPhong, MaDV)
);
GO

USE QLKARAOKE
GO
INSERT [dbo].[PHONG] ([MaPhong], [LoaiPhong], [SoKhachToiDa], [GiaPhong], [MoTa]) VALUES (N'P0001', N'Loai 1', 20, 60000, NULL)
GO
INSERT [dbo].[PHONG] ([MaPhong], [LoaiPhong], [SoKhachToiDa], [GiaPhong], [MoTa]) VALUES (N'P0002', N'Loai 1', 25, 80000, NULL)
GO
INSERT [dbo].[PHONG] ([MaPhong], [LoaiPhong], [SoKhachToiDa], [GiaPhong], [MoTa]) VALUES (N'P0003', N'Loai 2', 15, 50000, NULL)
GO
INSERT [dbo].[PHONG] ([MaPhong], [LoaiPhong], [SoKhachToiDa], [GiaPhong], [MoTa]) VALUES (N'P0004', N'Loai 3', 20, 50000, NULL)
GO
INSERT [dbo].[KHACH_HANG] ([MaKH], [TenKH], [DiaChi], [SoDT]) VALUES (N'KH0001', N'Nguyen Van A', N'Hoa xuan', N'1111111111')
GO
INSERT [dbo].[KHACH_HANG] ([MaKH], [TenKH], [DiaChi], [SoDT]) VALUES (N'KH0002', N'Nguyen Van B', N'Hoa hai', N'1111111112')
GO
INSERT [dbo].[KHACH_HANG] ([MaKH], [TenKH], [DiaChi], [SoDT]) VALUES (N'KH0003', N'Phan Van A', N'Cam le', N'1111111113')
GO
INSERT [dbo].[KHACH_HANG] ([MaKH], [TenKH], [DiaChi], [SoDT]) VALUES (N'KH0004', N'Phan Van B', N'Hoa xuan', N'1111111114')
GO
INSERT [dbo].[DAT_PHONG] ([MaDatPhong], [MaPhong], [MaKH], [NgayDat], [GioBatDau], [GioKetThuc], [TienDatCoc], [GhiChu], [TrangThaiDat]) VALUES (N'DP0001', N'P0001', N'KH0002', CAST(N'2018-03-26' AS Date), CAST(N'11:00:00' AS Time), CAST(N'13:30:00' AS Time), CAST(100000 AS Decimal(18, 0)), NULL, N'Da dat')
GO
INSERT [dbo].[DAT_PHONG] ([MaDatPhong], [MaPhong], [MaKH], [NgayDat], [GioBatDau], [GioKetThuc], [TienDatCoc], [GhiChu], [TrangThaiDat]) VALUES (N'DP0002', N'P0001', N'KH0003', CAST(N'2018-03-27' AS Date), CAST(N'17:15:00' AS Time), CAST(N'19:15:00' AS Time), CAST(50000 AS Decimal(18, 0)), NULL, N'Da huy')
GO
INSERT [dbo].[DAT_PHONG] ([MaDatPhong], [MaPhong], [MaKH], [NgayDat], [GioBatDau], [GioKetThuc], [TienDatCoc], [GhiChu], [TrangThaiDat]) VALUES (N'DP0003', N'P0002', N'KH0002', CAST(N'2018-03-26' AS Date), CAST(N'20:30:00' AS Time), CAST(N'22:15:00' AS Time), CAST(100000 AS Decimal(18, 0)), NULL, N'Da dat')
GO
INSERT [dbo].[DAT_PHONG] ([MaDatPhong], [MaPhong], [MaKH], [NgayDat], [GioBatDau], [GioKetThuc], [TienDatCoc], [GhiChu], [TrangThaiDat]) VALUES (N'DP0004', N'P0003', N'KH0001', CAST(N'2018-04-01' AS Date), CAST(N'19:30:00' AS Time), CAST(N'21:15:00' AS Time), CAST(200000 AS Decimal(18, 0)), NULL, N'Da dat')
GO
INSERT [dbo].[DICH_VU_DI_KEM] ([MaDV], [TenDV], [DonViTinh], [DonGia]) VALUES (N'DV001', N'Beer', N'lon', 10000)
GO
INSERT [dbo].[DICH_VU_DI_KEM] ([MaDV], [TenDV], [DonViTinh], [DonGia]) VALUES (N'DV002', N'Nuoc ngot', N'lon', 8000)
GO
INSERT [dbo].[DICH_VU_DI_KEM] ([MaDV], [TenDV], [DonViTinh], [DonGia]) VALUES (N'DV003', N'Trai cay', N'dia', 35000)
GO
INSERT [dbo].[DICH_VU_DI_KEM] ([MaDV], [TenDV], [DonViTinh], [DonGia]) VALUES (N'DV004', N'Khan uot', N'cai', 2000)
GO
INSERT [dbo].[CHI_TIET_SU_DUNG_DICH_VU] ([MaDatPhong], [MaDV], [SoLuong]) VALUES (N'DP0001', N'DV001', 20)
GO
INSERT [dbo].[CHI_TIET_SU_DUNG_DICH_VU] ([MaDatPhong], [MaDV], [SoLuong]) VALUES (N'DP0001', N'DV002', 10)
GO
INSERT [dbo].[CHI_TIET_SU_DUNG_DICH_VU] ([MaDatPhong], [MaDV], [SoLuong]) VALUES (N'DP0001', N'DV003', 3)
GO
INSERT [dbo].[CHI_TIET_SU_DUNG_DICH_VU] ([MaDatPhong], [MaDV], [SoLuong]) VALUES (N'DP0002', N'DV002', 10)
GO
INSERT [dbo].[CHI_TIET_SU_DUNG_DICH_VU] ([MaDatPhong], [MaDV], [SoLuong]) VALUES (N'DP0002', N'DV003', 1)
GO
INSERT [dbo].[CHI_TIET_SU_DUNG_DICH_VU] ([MaDatPhong], [MaDV], [SoLuong]) VALUES (N'DP0003', N'DV003', 2)
GO
INSERT [dbo].[CHI_TIET_SU_DUNG_DICH_VU] ([MaDatPhong], [MaDV], [SoLuong]) VALUES (N'DP0003', N'DV004', 10)
GO

-- Cau 1
