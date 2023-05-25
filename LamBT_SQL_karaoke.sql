Use QLKARAOKE
go

-- Cau 1
select MaDatPhong, MaDV, SoLuong from CHI_TIET_SU_DUNG_DICH_VU where SoLuong > 3 and SoLuong < 10
go

-- Cau 2
update PHONG set GiaPhong = GiaPhong + 10000 where SoKhachToiDa > 10
go

-- Cau 3
delete from DAT_PHONG where TrangThaiDat = 'Da huy'
go

-- Cau 4
select TenKH from KHACH_HANG where TenKH like '[HNM]%' and len(TenKH) <= 20
go

-- Cau 5
	-- cach 1
select TenKH from KHACH_HANG group by TenKH
	-- cach 2
select distinct TenKH from KHACH_HANG 

-- Cau 6
select MaDV, TenDV, DonViTinh, DonGia from DICH_VU_DI_KEM 
where (DonViTinh = 'lon' and DonGia > 10000) or (DonViTinh = 'cai' and DonGia < 5000)
go
select ngaydat from DAT_PHONG where year(NgayDat)  in (2017, 2019)
-- Cau 7
select dp.MaDatPhong, dp.MaPhong, LoaiPhong, SoKhachToiDa, GiaPhong, dp.MaKH, TenKH, SoDT, 
NgayDat, GioBatDau, GioKetThuc, MaDV, SoLuong from DAT_PHONG dp
join CHI_TIET_SU_DUNG_DICH_VU on dp.MaDatPhong = CHI_TIET_SU_DUNG_DICH_VU.MaDatPhong
join PHONG on dp.MaPhong = PHONG.MaPhong
join KHACH_HANG on KHACH_HANG.MaKH = dp.MaKH
where year(NgayDat)  in (2016, 2017) and GiaPhong > 50000
go

-- Cau 8
select DAT_PHONG_VA_GIA.MaDatPhong, DAT_PHONG_VA_GIA.MaPhong, LoaiPhong, GiaPhong, TenKH, NgayDat, 
TongTienHat,
ISNULL(TongTienSuDungDichVu, 0), TongTienHat + ISNULL(TongTienSuDungDichVu, 0) as TongTienThanhToan from 
( select MaDatPhong, MaKH,
GiaPhong * cast(datediff(minute, GioBatDau, GioKetThuc) as float) / 60. as TongTienHat,
DAT_PHONG.MaPhong, NgayDat
from DAT_PHONG join PHONG on DAT_PHONG.MaPhong = PHONG.MaPhong) as DAT_PHONG_VA_GIA
join PHONG on PHONG.MaPhong = DAT_PHONG_VA_GIA.MaPhong
join KHACH_HANG on KHACH_HANG.MaKH = DAT_PHONG_VA_GIA.MaKH
left join (select MaDatPhong, sum(DonGia * SoLuong) as TongTienSuDungDichVu from CHI_TIET_SU_DUNG_DICH_VU
join DICH_VU_DI_KEM on DICH_VU_DI_KEM.MaDV = CHI_TIET_SU_DUNG_DICH_VU.MaDV
group by MaDatPhong) TIEN_SU_DUNG_DICH_VU on TIEN_SU_DUNG_DICH_VU.MaDatPhong = DAT_PHONG_VA_GIA.MaDatPhong
go

-- Cau 9
select KHACH_HANG.MaKH, TenKH, DiaChi, SoDT from KHACH_HANG
join DAT_PHONG on DAT_PHONG.MaKH = KHACH_HANG.MaKH where DiaChi = 'Hoa xuan' and TrangThaiDat = 'Da dat'
go

-- Cau 10
select PHONG.MaPhong, LoaiPhong, SoKhachToiDa, GiaPhong, SoLanDat from PHONG
join (
select PHONG.MaPhong, count(PHONG.MaPhong) as SoLanDat from (select MaPhong from DAT_PHONG where TrangThaiDat = 'Da dat') as  DAT_PHONG_DA_DAT
join PHONG on PHONG.MaPhong = DAT_PHONG_DA_DAT.MaPhong group by PHONG.MaPhong 
) as TongHopLanDatPhong on TongHopLanDatPhong.MaPhong = PHONG.MaPhong
where SoLanDat > 2

-- Cau 11
create table CHITIETKHACHHANG (
	Id varchar(10) not null primary key,
	MaKH varchar(10) not null FOREIGN KEY REFERENCES KHACH_HANG(MaKH),
	Note nvarchar(30),
);
go

-- Hiển thị những khách hàng nào có số lần đặt phòng lớn hơn hoặc bằng 2 trong năm nay (2018)

select KHACH_HANG.MaKH, TenKH, DiaChi, SoDT, SoLanDat, 'VIP' as Note from KHACH_HANG
join (select DAT_PHONG_DA_DAT.MaKH, count(DAT_PHONG_DA_DAT.MaKH) as SoLanDat from 
(select MaKH, MaPhong from DAT_PHONG where TrangThaiDat = 'Da dat' and year(NgayDat) = 2018) as  DAT_PHONG_DA_DAT 
join KHACH_HANG on DAT_PHONG_DA_DAT.MaKH = KHACH_HANG.MaKH
group by DAT_PHONG_DA_DAT.MaKH) as KHACH_HANG_DA_DAT
on KHACH_HANG_DA_DAT.MaKH = KHACH_HANG.MaKH  where SoLanDat >= 2
go

