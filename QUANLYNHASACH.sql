create database QuanlyNhasach;
use QuanLyNhasach;


create table TAIKHOANADMIN( 
	Username nvarchar(20) primary key not null,
	Password nvarchar(50) not null
);

select * from TAIKHOANADMIN

create table TACGIA(
	MaTG char(7) primary key not null,
	TenTG nvarchar(40),
	NamSinh date
);

select * from TACGIA

create table THELOAISACH(
	MaTL nvarchar(20) primary key not null,
	TenTL nvarchar(50) not null,

);



create table NHAXUATBAN(
	MaNXB nvarchar(20) primary key not null,
	TenNXB nvarchar(50) not null
);


create table SACH(
	MaSach nvarchar(20) primary key not null,
	TenSach nvarchar(50) not null,
	MaTG char(7) not null,
	MaTL nvarchar(20) not null,
	GiaMua int null,
	GiaBia int null,
	LanTaiBan int null,
	MaNXB nvarchar(20) not null,
	NamXuatBan int not null,
	constraint fk_MaTG foreign key (MaTG) references TACGIA(MaTG),
	constraint fk_MaTl foreign key (MaTL) references THELOAISACH(MaTL),
	constraint fk_MaNXB foreign key (MaNXB) references NHAXUATBAN(MaNXB)
);


select * from SACH

create table KHOSACH(
	MaSach nvarchar(20) not null,
	SoLuong int null
	constraint fk_MaSach foreign key (MaSach) references SACH(MaSach)
);


create table HOADON(
	MaHoaDon nvarchar(20) primary key not null,
	TenKhachHang nvarchar(50) not null,
	NgayLap date null,
	TongTien int null
);


create table CHITIETHOADON(
	MaHoaDon nvarchar(20) not null,
	MaSach nvarchar(20) not null,
	SoLuong int null,
	GiaTien int null,
	ThanhTien int null
	constraint fk_MaSachHoaDon foreign key (MaSach) references SACH(MaSach),
	constraint fk_MaHoaDon foreign key (MaHoaDon) references HOADON(MaHoaDon)
);