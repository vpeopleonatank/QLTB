IF EXISTS(SELECT * FROM sys.databases WHERE name = 'QLTB')
begin
	 use master
	alter database QLTB set single_user with rollback immediate
	Drop Database QLTB
end

IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'QLTB')
BEGIN
CREATE DATABASE QLTB
END
GO
 USE QLTB
GO

Create table Donvi (
	Madv int IDENTITY(1,1) not null primary key,
	Tendv nvarchar(30),
);
GO

Create table Loaithietbi (
	Maloai int IDENTITY(1,1) not null primary key,
	Tenloai nvarchar(30),
	Danhmuc nvarchar(30),
	Ghichu nvarchar(30)
);
GO

create table Thietbi (
	Matb int IDENTITY(1,1)
	not null primary key,
	Madv int not null FOREIGN KEY REFERENCES Donvi(Madv),
	Maloai int not null FOREIGN KEY REFERENCES Loaithietbi(Maloai),
	Tentb nvarchar(30),
	Nuocsx nvarchar(15)
);
go

USE [QLTB]
GO
INSERT [dbo].[Donvi] ([Tendv]) VALUES (N'Đơn vị 1')
GO
INSERT [dbo].[Donvi] ([Tendv]) VALUES (N'Đơn vị 2')
GO
INSERT [dbo].[Donvi] ([Tendv]) VALUES ( N'Đơn vị 3')
GO
INSERT [dbo].[Loaithietbi] ([Tenloai], [Danhmuc], [Ghichu]) VALUES ( N'Máy tính bảng', N'Maytinh', NULL)
GO
INSERT [dbo].[Loaithietbi] ( [Tenloai], [Danhmuc], [Ghichu]) VALUES (N'Máy tính trạm', N'Maytinh', NULL)
GO
INSERT [dbo].[Loaithietbi] ([Tenloai], [Danhmuc], [Ghichu]) VALUES ( N'Switch', N'Thietbimang', NULL)
GO
INSERT [dbo].[Thietbi] ([Madv], [Maloai], [Tentb], [Nuocsx]) VALUES (1, 1, N'Ipad 2020', N'Mỹ')
GO
INSERT [dbo].[Thietbi] ([Madv], [Maloai], [Tentb], [Nuocsx]) VALUES (2, 2, N'Dell r730', N'Mỹ')
GO
INSERT [dbo].[Thietbi] ([Madv], [Maloai], [Tentb], [Nuocsx]) VALUES (3, 3, N'Switch Extreme 220', N'Mỹ')
GO
