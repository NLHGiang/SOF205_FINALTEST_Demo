create database SOF205_FINAL_TEST
go
use SOF205_FINAL_TEST 
go
create table SINHVIEN
(	id int identity(1,1) primary key,
	ten nvarchar(50) not null,
	email varchar(50) not null unique,
	sdt varchar(10),
	diachi nvarchar(100),
	idPH int
)
go
create table PHUHUYNH
(	id int identity(1,1) primary key,
	ten nvarchar(50) not null,
	nghenghiep nvarchar(50)
)
alter table SINHVIEN add constraint FK_SV_PH FOREIGN KEY (idPH)  references PHUHUYNH(id)

go
create table SANPHAM
(	id int identity(1,1) primary key,
	ten nvarchar(50) not null,
	mota varchar(150) not null,
	soluongtonkho int,
	giatien int,
	idNCC int
)
go
create table NHACUNGCAP
(	id int identity(1,1) primary key,
	ten nvarchar(50) not null,
	diachi nvarchar(50)
)
go
alter table SANPHAM add constraint FK_SP_NCC FOREIGN KEY (idNCC)  references NHACUNGCAP(id)

go

create table THUCUNG
(	id int identity(1,1) primary key,
	ten nvarchar(50) not null,
	loai varchar(150) not null,
	maulong varchar(10),
	tuoi int,
	idCN int
)
go
create table CHUNHAN
(	id int identity(1,1) primary key,
	ten nvarchar(50) not null,
	diachi nvarchar(50)
)
go
alter table THUCUNG add constraint FK_TC_CN FOREIGN KEY (idCN)  references CHUNHAN(id)

create table CUAHANG
(	id int identity(1,1) primary key,
	ten nvarchar(50) not null,
	mota varchar(150) not null,
	loaihang varchar(10),
	ngaydangky date,
	idCN int
)
go
create table TRUNGTAM
(	id int identity(1,1) primary key,
	ten nvarchar(50) not null,
	diachi nvarchar(50)
)
go
alter table CUAHANG add constraint FKCH_TT FOREIGN KEY (idCN)  references TRUNGTAM(id)