/*==============================================================*/
/* Data base name:      Quan Ly Ho Khau (qlhk)                  */
/* Created on:          10/20/2018 12:11:22 PM                  */
/*==============================================================*/

/*==============================================================*/
/* Table: HOC SINH SINH VIEN                                    */
/*==============================================================*/

create database QLHK;
use QLHK;

create table HOCSINHSINHVIEN
(
    MAHSSV                              char(9)         not null,
    MADINHDANH                          char(12)        not null,
    TRUONG                              text            not null,
    DIACHITHUONGTRU                     text            not null,
    THOIGIANBATDAUTAMTRUTHUONGTRU       date            not null,
    THOIGIANKETTHUCTAMTRUTHUONGTRU      date            not null,
    VIPHAM                              text                    ,

    primary key (MAHSSV)
);

/*==============================================================*/
/* Table: NHAN KHAU                                             */
/*==============================================================*/
create table NHANKHAU
(
    MADINHDANH          char(12)                        not null,
    HOTEN               text                            not null,
    TENKHAC             text                                    ,
    NGAYSINH            date                            not null,
    GIOITINH            varchar(10)                     not null,
    NOISINH             text                            not null,
    NGUYENQUAN          text                            not null,
    DANTOC              varchar(20)                     not null,  
    TONGIAO             varchar(20)                     not null,
    QUOCTICH            varchar(20)                     not null,
    HOCHIEU             varchar(20)                             ,
    NOITHUONGTRU        text                            not null,
    DIACHIHIENNAY       text                            not null,
    SDT                 char(10)                                ,
    TRINHDOHOCVAN       text                                    ,
    TRINHDOCHUYENMON    text                                    ,
    BIETTIENGDANTOC     text                                    ,
    TRINHDONGOAINGU     text                                    ,
    NGHENGHIEP          text                            not null,
  
    primary key (MADINHDANH)
);

/*==============================================================*/
/* Table: NHAN KHAU THUONG TRU                                  */
/*==============================================================*/
create table NHANKHAUTHUONGTRU
(
    MANHANKHAUTHUONGTRU     char(9)                     not null,
    MADINHDANH              char(12)                    not null,
    DIACHITHUONGTRU         text                        not null,
    QUANHEVOICHUHO          text                                ,
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
    NGAYBATDAUTAMVANG       date                        not null,
    NGAYKETTHUCTAMVANG      date                        not null,
    LYDO                    text                        not null,
    NOIDEN                  text                        not null,

    primary key (MANHANKHAUTAMVANG)
);

/*==============================================================*/
/* Table: NHAN KHAU TAM TRU                                     */
/*==============================================================*/
create table NHANKHAUTAMTRU
(
    MANHAKHAUTAMTRU         char(9)                     not null,
    MADINHDANH              char(12)                    not null,
    NOITAMTRU               text                        not null,
    TUNGAY                  date                        not null,
    DENNGAY                 date                        not null,
    LYDO                    text                        not null,
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
    DIACHI                     text                        not null,
    NGAYCAP                 date                        not null,
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
    NOITAMTRU               text                        not null,
    NGAYCAP                 date                        not null,
    DENNGAY                 date                        not null,

    primary key (SOSOTAMTRU)   
);

/*==============================================================*/
/* Table: TIEU SU                                               */
/*==============================================================*/
create table TIEUSU
(
    MATIEUSU                char(9)                     not null,
    MADINHDANH              char(12)                    not null,
    THOIGIANBATDAU          date                        not null,
    THOIGIANKETTHUC         date                        not null,
    CHOO                    text                        not null,
    NGHENGHIEP              text                        not null,
    NOILAMVIEC              text                        not null,

    primary key (MATIEUSU)
);

/*==============================================================*/
/* Table: TIEN AN TIEN SU                                       */
/*==============================================================*/
create table TIENANTIENSU
(
    MATIENANTIENSU          char(9)                     not null,
    MADINHDANH              char(12)                    not null,
    TOIDANH                 text                        not null,
    HINHPHAT                text                        not null,
    BANAN                   text                        not null,  
    NGAYPHAT                date                        not null,

    primary key (MATIENANTIENSU)
);

/*==============================================================*/
/* Table: CAN BO                                                */
/*==============================================================*/
create table CANBO
(
    MACANBO                 char(9)                     not null,
    MANHANKHAUTHUONGTRU     char(9)                     not null,
    TENTAIKHOAN             text                        not null,
    MATKHAU                 text                        not null,
    LOAICANBO               text                        not null,

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