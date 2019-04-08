/*==============================================================*/
/* Data base name:      Quan Ly Ho Khau (qlhk)                  */
/* Created on:          10/20/2018 12:11:22 PM                  */
/*==============================================================*/

/*==============================================================*/
/* Table: HOC SINH SINH VIEN                                    */
/*==============================================================*/

create database QLHK;
go
use QLHK;

create table HOCSINHSINHVIEN
(
    MAHSSV                              char(9)         not null,
    MADINHDANH                          char(12)        not null,
    TRUONG                              nvarchar(50)    not null,
    DIACHITHUONGTRU                     nvarchar(50)    not null,
    THOIGIANBATDAUTAMTRUTHUONGTRU       smalldatetime   not null,
    THOIGIANKETTHUCTAMTRUTHUONGTRU      smalldatetime   not null,
    VIPHAM                              nvarchar(100)                    ,

    primary key (MAHSSV)
);

/*==============================================================*/
/* Table: NHAN KHAU                                             */
/*==============================================================*/
create table NHANKHAU
(
    MADINHDANH          char(12)                        not null,
    HOTEN               nvarchar(50)                            not null,
    TENKHAC             nvarchar(50)                                    ,
    NGAYSINH            smalldatetime                            not null,
    GIOITINH            varchar(200)                     not null,
    NOISINH             nvarchar(100)                            not null,
    NGUYENQUAN          nvarchar(100)                            not null,
    DANTOC              varchar(20)                     not null,  
    TONGIAO             varchar(20)                     not null,
    QUOCTICH            varchar(20)                     not null,
    HOCHIEU             varchar(20)                             ,
    NOITHUONGTRU        nvarchar(100)                            not null,
    DIACHIHIENNAY       nvarchar(100)                            not null,
    SDT                 char(10)                                ,
    TRINHDOHOCVAN       nvarchar(100)                                    ,
    TRINHDOCHUYENMON    nvarchar(100)                                    ,
    BIETTIENGDANTOC     nvarchar(100)                                    ,
    TRINHDONGOAINGU     nvarchar(100)                                    ,
    NGHENGHIEP          nvarchar(100)                            not null,
  
    primary key (MADINHDANH)
);

/*==============================================================*/
/* Table: NHAN KHAU THUONG TRU                                  */
/*==============================================================*/
create table NHANKHAUTHUONGTRU
(
    MANHANKHAUTHUONGTRU     char(9)                     not null,
    MADINHDANH              char(12)                    not null,
    DIACHITHUONGTRU         nvarchar(100)                        not null,
    QUANHEVOICHUHO          nvarchar(100)                                ,
    SOSOHOKHAU              char(9)                     not null,

    primary key (MANHANKHAUTHUONGTRU)
);

/*==============================================================*/
/* Table:   NHAN KHAU TAM VANG                                  */
/*==============================================================*/
create table NHANKHAUTAMVANG
(
    MANHANKHAUTAMVANG       char(9)                     not null,         
    MADINHDANH              char(12)                     not null,
    NGAYBATDAUTAMVANG       smalldatetime                        not null,
    NGAYKETTHUCTAMVANG      smalldatetime                        not null,
    LYDO                    nvarchar(100)                        not null,
    NOIDEN                  nvarchar(100)                        not null,

    primary key (MANHANKHAUTAMVANG)
);

/*==============================================================*/
/* Table: NHAN KHAU TAM TRU                                     */
/*==============================================================*/
create table NHANKHAUTAMTRU
(
    MANHAKHAUTAMTRU         char(9)                     not null,
    MADINHDANH              char(12)                    not null,
    NOITAMTRU               nvarchar(100)                        not null,
    TUNGAY                  smalldatetime                        not null,
    DENNGAY                 smalldatetime                        not null,
    LYDO                    nvarchar(100)                        not null,
    SOSOTAMTRU              char(9)                     not null,

    primary key (MANHAKHAUTAMTRU)
);

/*==============================================================*/
/* Table: SO HO KHAU                                            */
/*==============================================================*/
create table SOHOKHAU
(
    SOSOHOKHAU              char(9)                     not null,
    MACHUHO                   char(9)                     not null,
    DIACHI                     nvarchar(100)                        not null,
    NGAYCAP                 smalldatetime                        not null,
    SODANGKY                char(7)                     not null,

    primary key (SOSOHOKHAU)
);

/*==============================================================*/
/* Table: SO TAM TRU                                            */
/*==============================================================*/
create table SOTAMTRU
(
    SOSOTAMTRU              char(9)                     not null,
    CHUHO                   char(9)                     not null,
    NOITAMTRU               nvarchar(100)                        not null,
    NGAYCAP                 smalldatetime                        not null,
    DENNGAY                 smalldatetime                        not null,

    primary key (SOSOTAMTRU)   
);

/*==============================================================*/
/* Table: TIEU SU                                               */
/*==============================================================*/
create table TIEUSU
(
    MATIEUSU                char(9)                     not null,
    MADINHDANH              char(12)                    not null,
    THOIGIANBATDAU          smalldatetime                        not null,
    THOIGIANKETTHUC         smalldatetime                        not null,
    CHOO                    nvarchar(100)                        not null,
    NGHENGHIEP              nvarchar(100)                        not null,
    NOILAMVIEC              nvarchar(100)                        not null,

    primary key (MATIEUSU)
);

/*==============================================================*/
/* Table: TIEN AN TIEN SU                                       */
/*==============================================================*/
create table TIENANTIENSU
(
    MATIENANTIENSU          char(9)                     not null,
    MADINHDANH              char(12)                    not null,
    TOIDANH                 nvarchar(100)                        not null,
    HINHPHAT                nvarchar(100)                        not null,
    BANAN                   nvarchar(100)                        not null,  
    NGAYPHAT                smalldatetime                        not null,

    primary key (MATIENANTIENSU)
);

/*==============================================================*/
/* Table: CAN BO                                                */
/*==============================================================*/
create table CANBO
(
    MACANBO                 char(9)                     not null,
    MANHANKHAUTHUONGTRU     char(9)                     not null,
    TENTAIKHOAN             nvarchar(100)                        not null,
    MATKHAU                 nvarchar(100)                        not null,
    LOAICANBO               nvarchar(100)                        not null,

    primary key (MACANBO)
);

/*
alter table NHANKHAUTAMTRU add constraint FK_NKTT_NK foreign key (MADINHDANH)
    references NHANKHAU (MADINHDANH);
alter table NHANKHAUTAMTRU add constraint FK_NKTT_STT foreign key (SOSOTAMTRU)
    references SOTAMTRU (SOSOTAMTRU);
alter table HOCSINHSINHVIEN add constraint FK_HSSV_NK foreign key (MADINHDANH)
    references NHANKHAU (MADINHDANH);
alter table NHANKHAUTAMVANG add constraint FK_NKTV_NK foreign key (MADINHDANH)
    references NHANKHAU (MADINHDANH);
alter table NHANKHAUTHUONGTRU add constraint FK_NKTTRU_NK foreign key (MADINHDANH)
    references NHANKHAU (MADINHDANH);
alter table NHANKHAUTHUONGTRU add constraint FK_NKTTRU_STTRU foreign key (SOSOHOKHAU)
    references SOHOKHAU (SOSOHOKHAU);
alter table SOHOKHAU add constraint FK_NSHK_NKTTRU foreign key (MACHUHO)
    references NHANKHAUTHUONGTRU (MANHANKHAUTHUONGTRU);
alter table SOTAMTRU add constraint FK_STT_NKTT foreign key (CHUHO)
    references NHANKHAUTAMTRU (MANHANKHAUTAMTRU);
	*/