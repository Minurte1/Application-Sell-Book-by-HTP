
create table KHACHHANG(
	MaKH nvarchar(20) primary key not null,
	TenKH nvarchar(50) not null,
	SDTKhachHang nvarchar(10) null,
	DiachiKhachHang nvarchar(100) null,
	GioiTinhKH nvarchar(5) null
);


create table NHANVIEN(
	MaNV nvarchar(20) primary key not null,
	TenNV nvarchar(50) not null,
	SDTNhanVien nvarchar(10) null,
	DiachiNhanVien nvarchar(100) null,
	GioiTinhNV nvarchar(5) null
);


alter table HOADON add MaNV nvarchar(20) not null;

alter table HOADON add constraint fk_MaNV foreign key (MaNV) references NHANVIEN(MaNV);

alter table HOADON add MaKH nvarchar(20) not null;
alter table HOADON add constraint fk_MaKH foreign key (MaKH) references KHACHHANG(MaKH);

