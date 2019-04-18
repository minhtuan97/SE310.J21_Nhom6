/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     4/13/2019 10:50:59 AM                        */
/*==============================================================*/
create database QLHK;
go
use QLHK;
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CANBO') and o.name = 'FK_CANBO_NKTT_CB_NHANKHAU')
alter table CANBO
   drop constraint FK_CANBO_NKTT_CB_NHANKHAU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('HOCSINHSINHVIEN') and o.name = 'FK_HOCSINHS_LAHSSV_NHANKHAU')
alter table HOCSINHSINHVIEN
   drop constraint FK_HOCSINHS_LAHSSV_NHANKHAU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('NHANKHAUTAMTRU') and o.name = 'FK_NHANKHAU_NK_NKTAMT_NHANKHAU')
alter table NHANKHAUTAMTRU
   drop constraint FK_NHANKHAU_NK_NKTAMT_NHANKHAU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('NHANKHAUTAMTRU') and o.name = 'FK_NHANKHAU_STT_NKTT_SOTAMTRU')
alter table NHANKHAUTAMTRU
   drop constraint FK_NHANKHAU_STT_NKTT_SOTAMTRU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('NHANKHAUTAMVANG') and o.name = 'FK_NHANKHAU_NK_NKTAMV_NHANKHAU')
alter table NHANKHAUTAMVANG
   drop constraint FK_NHANKHAU_NK_NKTAMV_NHANKHAU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('NHANKHAUTHUONGTRU') and o.name = 'FK_NHANKHAU_NKTT_SHK_SOHOKHAU')
alter table NHANKHAUTHUONGTRU
   drop constraint FK_NHANKHAU_NKTT_SHK_SOHOKHAU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('NHANKHAUTHUONGTRU') and o.name = 'FK_NHANKHAU_NK_NKTHUO_NHANKHAU')
alter table NHANKHAUTHUONGTRU
   drop constraint FK_NHANKHAU_NK_NKTHUO_NHANKHAU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('QUANHUYEN') and o.name = 'FK_QUANHUYE_QH_TTP_TINHTHAN')
alter table QUANHUYEN
   drop constraint FK_QUANHUYE_QH_TTP_TINHTHAN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SOHOKHAU') and o.name = 'FK_SOHOKHAU_LACHUHO_NHANKHAU')
alter table SOHOKHAU
   drop constraint FK_SOHOKHAU_LACHUHO_NHANKHAU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SOTAMTRU') and o.name = 'FK_SOTAMTRU_CHOHO_NHANKHAU')
alter table SOTAMTRU
   drop constraint FK_SOTAMTRU_CHOHO_NHANKHAU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TIENANTIENSU') and o.name = 'FK_TIENANTI_NK_TIENAN_NHANKHAU')
alter table TIENANTIENSU
   drop constraint FK_TIENANTI_NK_TIENAN_NHANKHAU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TIEUSU') and o.name = 'FK_TIEUSU_NK_TIEUSU_NHANKHAU')
alter table TIEUSU
   drop constraint FK_TIEUSU_NK_TIEUSU_NHANKHAU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('XAPHUONGTHITRAN') and o.name = 'FK_XAPHUONG_QH_XP_QUANHUYE')
alter table XAPHUONGTHITRAN
   drop constraint FK_XAPHUONG_QH_XP_QUANHUYE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CANBO')
            and   name  = 'NKTT_CB_FK'
            and   indid > 0
            and   indid < 255)
   drop index CANBO.NKTT_CB_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CANBO')
            and   type = 'U')
   drop table CANBO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('HOCSINHSINHVIEN')
            and   name  = 'LAHSSV_FK'
            and   indid > 0
            and   indid < 255)
   drop index HOCSINHSINHVIEN.LAHSSV_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('HOCSINHSINHVIEN')
            and   type = 'U')
   drop table HOCSINHSINHVIEN
go

if exists (select 1
            from  sysobjects
           where  id = object_id('NHANKHAU')
            and   type = 'U')
   drop table NHANKHAU
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('NHANKHAUTAMTRU')
            and   name  = 'STT_NKTT_FK'
            and   indid > 0
            and   indid < 255)
   drop index NHANKHAUTAMTRU.STT_NKTT_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('NHANKHAUTAMTRU')
            and   name  = 'NK_NKTAMTRU_FK'
            and   indid > 0
            and   indid < 255)
   drop index NHANKHAUTAMTRU.NK_NKTAMTRU_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('NHANKHAUTAMTRU')
            and   type = 'U')
   drop table NHANKHAUTAMTRU
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('NHANKHAUTAMVANG')
            and   name  = 'NK_NKTAMVANG_FK'
            and   indid > 0
            and   indid < 255)
   drop index NHANKHAUTAMVANG.NK_NKTAMVANG_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('NHANKHAUTAMVANG')
            and   type = 'U')
   drop table NHANKHAUTAMVANG
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('NHANKHAUTHUONGTRU')
            and   name  = 'NKTT_SHK_FK'
            and   indid > 0
            and   indid < 255)
   drop index NHANKHAUTHUONGTRU.NKTT_SHK_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('NHANKHAUTHUONGTRU')
            and   name  = 'NK_NKTHUONGTRU_FK'
            and   indid > 0
            and   indid < 255)
   drop index NHANKHAUTHUONGTRU.NK_NKTHUONGTRU_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('NHANKHAUTHUONGTRU')
            and   type = 'U')
   drop table NHANKHAUTHUONGTRU
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('QUANHUYEN')
            and   name  = 'QH_TTP_FK'
            and   indid > 0
            and   indid < 255)
   drop index QUANHUYEN.QH_TTP_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('QUANHUYEN')
            and   type = 'U')
   drop table QUANHUYEN
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SOHOKHAU')
            and   name  = 'LACHUHO_FK'
            and   indid > 0
            and   indid < 255)
   drop index SOHOKHAU.LACHUHO_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SOHOKHAU')
            and   type = 'U')
   drop table SOHOKHAU
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SOTAMTRU')
            and   name  = 'CHOHO_FK'
            and   indid > 0
            and   indid < 255)
   drop index SOTAMTRU.CHOHO_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SOTAMTRU')
            and   type = 'U')
   drop table SOTAMTRU
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TIENANTIENSU')
            and   name  = 'NK_TIENANTIENSU_FK'
            and   indid > 0
            and   indid < 255)
   drop index TIENANTIENSU.NK_TIENANTIENSU_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TIENANTIENSU')
            and   type = 'U')
   drop table TIENANTIENSU
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TIEUSU')
            and   name  = 'NK_TIEUSU_FK'
            and   indid > 0
            and   indid < 255)
   drop index TIEUSU.NK_TIEUSU_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TIEUSU')
            and   type = 'U')
   drop table TIEUSU
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TINHTHANHPHO')
            and   type = 'U')
   drop table TINHTHANHPHO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('XAPHUONGTHITRAN')
            and   name  = 'QH_XP_FK'
            and   indid > 0
            and   indid < 255)
   drop index XAPHUONGTHITRAN.QH_XP_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('XAPHUONGTHITRAN')
            and   type = 'U')
   drop table XAPHUONGTHITRAN
go

/*==============================================================*/
/* Table: CANBO                                                 */
/*==============================================================*/
create table CANBO (
   MACANBO              char(9)              not null,
   MANHANKHAUTHUONGTRU  char(9)              null,
   TENTAIKHOAN          nvarchar(100)        not null,
   MATKHAU              nvarchar(100)        not null,
   LOAICANBO            nvarchar(100)        not null,
   constraint PK_CANBO primary key (MACANBO)
)
go

/*==============================================================*/
/* Index: NKTT_CB_FK                                            */
/*==============================================================*/
create index NKTT_CB_FK on CANBO (
MANHANKHAUTHUONGTRU ASC
)
go

/*==============================================================*/
/* Table: HOCSINHSINHVIEN                                       */
/*==============================================================*/
create table HOCSINHSINHVIEN (
   MAHSSV               char(9)              not null,
   MADINHDANH           char(12)             not null,
   TRUONG               nvarchar(50)         not null,
   DIACHITHUONGTRU      nvarchar(100)        not null,
   THOIGIANBATDAUTAMTRUTHUONGTRU smalldatetime        not null,
   THOIGIANKETTHUCTAMTRUTHUONGTRU smalldatetime        not null,
   VIPHAM               nvarchar(100)        null,
   constraint PK_HOCSINHSINHVIEN primary key (MAHSSV)
)
go

/*==============================================================*/
/* Index: LAHSSV_FK                                             */
/*==============================================================*/
create index LAHSSV_FK on HOCSINHSINHVIEN (
MADINHDANH ASC
)
go

/*==============================================================*/
/* Table: NHANKHAU                                              */
/*==============================================================*/
create table NHANKHAU (
   MADINHDANH           char(12)             not null,
   HOTEN                nvarchar(50)         not null,
   TENKHAC              nvarchar(50)         null,
   NGAYSINH             smalldatetime        not null,
   GIOITINH             nvarchar(200)        not null,
   NOISINH              nvarchar(100)        not null,
   NGUYENQUAN           nvarchar(100)        not null,
   DANTOC               nvarchar(20)         not null,
   TONGIAO              nvarchar(20)         not null,
   QUOCTICH             nvarchar(20)         not null,
   HOCHIEU              nvarchar(20)         null,
   NOITHUONGTRU         nvarchar(100)        not null,
   DIACHIHIENNAY        nvarchar(100)        not null,
   SDT                  char(10)             null,
   TRINHDOHOCVAN        nvarchar(100)        null,
   TRINHDOCHUYENMON     nvarchar(100)        null,
   BIETTIENGDANTOC      nvarchar(100)        null,
   TRINHDONGOAINGU      nvarchar(100)        null,
   NGHENGHIEP           nvarchar(100)        not null,
   constraint PK_NHANKHAU primary key (MADINHDANH)
)
go

/*==============================================================*/
/* Table: NHANKHAUTAMTRU                                        */
/*==============================================================*/
create table NHANKHAUTAMTRU (
   MANHANKHAUTAMTRU     char(9)              not null,
   MADINHDANH           char(12)             not null,
   SOSOTAMTRU           char(9)              null,
   NOITAMTRU            nvarchar(100)        not null,
   TUNGAY               smalldatetime        not null,
   DENNGAY              smalldatetime        not null,
   LYDO                 nvarchar(100)        not null,
   constraint PK_NHANKHAUTAMTRU primary key (MANHAKHAUTAMTRU)
)
go

/*==============================================================*/
/* Index: NK_NKTAMTRU_FK                                        */
/*==============================================================*/
create index NK_NKTAMTRU_FK on NHANKHAUTAMTRU (
MADINHDANH ASC
)
go

/*==============================================================*/
/* Index: STT_NKTT_FK                                           */
/*==============================================================*/
create index STT_NKTT_FK on NHANKHAUTAMTRU (
SOSOTAMTRU ASC
)
go

/*==============================================================*/
/* Table: NHANKHAUTAMVANG                                       */
/*==============================================================*/
create table NHANKHAUTAMVANG (
   MANHANKHAUTAMVANG    char(9)              not null,
   MADINHDANH           char(12)             null,
   NGAYBATDAUTAMVANG    smalldatetime        not null,
   NGAYKETTHUCTAMVANG   smalldatetime        not null,
   LYDO                 nvarchar(100)        not null,
   NOIDEN               nvarchar(100)        not null,
   constraint PK_NHANKHAUTAMVANG primary key (MANHANKHAUTAMVANG)
)
go

/*==============================================================*/
/* Index: NK_NKTAMVANG_FK                                       */
/*==============================================================*/
create index NK_NKTAMVANG_FK on NHANKHAUTAMVANG (
MADINHDANH ASC
)
go

/*==============================================================*/
/* Table: NHANKHAUTHUONGTRU                                     */
/*==============================================================*/
create table NHANKHAUTHUONGTRU (
   MANHANKHAUTHUONGTRU  char(9)              not null,
   MADINHDANH           char(12)             not null,
   SOSOHOKHAU           char(9)              not null,
   DIACHITHUONGTRU      nvarchar(100)        not null,
   QUANHEVOICHUHO       nvarchar(100)        null,
   constraint PK_NHANKHAUTHUONGTRU primary key (MANHANKHAUTHUONGTRU)
)
go

/*==============================================================*/
/* Index: NK_NKTHUONGTRU_FK                                     */
/*==============================================================*/
create index NK_NKTHUONGTRU_FK on NHANKHAUTHUONGTRU (
MADINHDANH ASC
)
go

/*==============================================================*/
/* Index: NKTT_SHK_FK                                           */
/*==============================================================*/
create index NKTT_SHK_FK on NHANKHAUTHUONGTRU (
SOSOHOKHAU ASC
)
go

/*==============================================================*/
/* Table: QUANHUYEN                                             */
/*==============================================================*/
create table QUANHUYEN (
   maqh                 nvarchar(5)          not null,  
   ten                  nvarchar(100)        not null,
   kieu                 nvarchar(30)         not null,
   matp                 nvarchar(5)          null,
   constraint PK_QUANHUYEN primary key (maqh)
)
go

/*==============================================================*/
/* Index: QH_TTP_FK                                             */
/*==============================================================*/
create index QH_TTP_FK on QUANHUYEN (
matp ASC
)
go

/*==============================================================*/
/* Table: SOHOKHAU                                              */
/*==============================================================*/
create table SOHOKHAU (
   SOSOHOKHAU           char(9)              not null,
   MACHUHO                char(9)              null,
   DIACHI               nvarchar(100)        not null,
   NGAYCAP              smalldatetime        not null,
   SODANGKY             char(7)              not null,
   constraint PK_SOHOKHAU primary key (SOSOHOKHAU)
)
go


/*==============================================================*/
/* Table: SOTAMTRU                                              */
/*==============================================================*/
create table SOTAMTRU (
   SOSOTAMTRU           char(9)              not null,
   MACHUHO                char(9)              null,
   NOITAMTRU            nvarchar(100)        not null,
   NGAYCAP              smalldatetime        not null,
   DENNGAY              smalldatetime        not null,
   constraint PK_SOTAMTRU primary key (SOSOTAMTRU)
)
go



/*==============================================================*/
/* Table: TIENANTIENSU                                          */
/*==============================================================*/
create table TIENANTIENSU (
   MATIENANTIENSU       char(9)              not null,
   MADINHDANH           char(12)             null,
   TOIDANH              nvarchar(100)        not null,
   HINHPHAT             nvarchar(100)        not null,
   BANAN                nvarchar(100)        not null,
   NGAYPHAT             smalldatetime        not null,
   constraint PK_TIENANTIENSU primary key (MATIENANTIENSU)
)
go

/*==============================================================*/
/* Index: NK_TIENANTIENSU_FK                                    */
/*==============================================================*/
create index NK_TIENANTIENSU_FK on TIENANTIENSU (
MADINHDANH ASC
)
go

/*==============================================================*/
/* Table: TIEUSU                                                */
/*==============================================================*/
create table TIEUSU (
   MATIEUSU             char(9)              not null,
   MADINHDANH           char(12)             null,
   THOIGIANBATDAU       smalldatetime        not null,
   THOIGIANKETTHUC      smalldatetime        not null,
   CHOO                 nvarchar(100)        not null,
   NGHENGHIEP           nvarchar(100)        not null,
   NOILAMVIEC           nvarchar(100)        not null,
   constraint PK_TIEUSU primary key (MATIEUSU)
)
go

/*==============================================================*/
/* Index: NK_TIEUSU_FK                                          */
/*==============================================================*/
create index NK_TIEUSU_FK on TIEUSU (
MADINHDANH ASC
)
go

/*==============================================================*/
/* Table: TINHTHANHPHO                                          */
/*==============================================================*/
create table TINHTHANHPHO (
   matp                 nvarchar(5)          not null,
   ten                  nvarchar(100)        not null,
   kieu                 nvarchar(30)         not null,
   constraint PK_TINHTHANHPHO primary key (matp)
)
go

/*==============================================================*/
/* Table: XAPHUONGTHITRAN                                       */
/*==============================================================*/
create table XAPHUONGTHITRAN (
   maxp                 nvarchar(5)          not null,  
   ten                  nvarchar(100)        not null,
   kieu                 nvarchar(30)         not null,
   maqh                 nvarchar(5)          null,
   constraint PK_XAPHUONGTHITRAN primary key (maxp)
)
go

/*==============================================================*/
/* Index: QH_XP_FK                                              */
/*==============================================================*/
create index QH_XP_FK on XAPHUONGTHITRAN (
maqh ASC
)
go

alter table CANBO
   add constraint FK_CANBO_NKTT_CB_NHANKHAU foreign key (MANHANKHAUTHUONGTRU)
      references NHANKHAUTHUONGTRU (MANHANKHAUTHUONGTRU)
go

alter table HOCSINHSINHVIEN
   add constraint FK_HOCSINHS_LAHSSV_NHANKHAU foreign key (MADINHDANH)
      references NHANKHAU (MADINHDANH)
go

alter table NHANKHAUTAMTRU
   add constraint FK_NHANKHAU_NK_NKTAMT_NHANKHAU foreign key (MADINHDANH)
      references NHANKHAU (MADINHDANH)
go

alter table NHANKHAUTAMTRU
   add constraint FK_NHANKHAU_STT_NKTT_SOTAMTRU foreign key (SOSOTAMTRU)
      references SOTAMTRU (SOSOTAMTRU)
go

alter table NHANKHAUTAMVANG
   add constraint FK_NHANKHAU_NK_NKTAMV_NHANKHAU foreign key (MADINHDANH)
      references NHANKHAU (MADINHDANH)
go

alter table NHANKHAUTHUONGTRU
   add constraint FK_NHANKHAU_NKTT_SHK_SOHOKHAU foreign key (SOSOHOKHAU)
      references SOHOKHAU (SOSOHOKHAU)
go

alter table NHANKHAUTHUONGTRU
   add constraint FK_NHANKHAU_NK_NKTHUO_NHANKHAU foreign key (MADINHDANH)
      references NHANKHAU (MADINHDANH)
go

alter table QUANHUYEN
   add constraint FK_QUANHUYE_QH_TTP_TINHTHAN foreign key (matp)
      references TINHTHANHPHO (matp)
go

alter table TIENANTIENSU
   add constraint FK_TIENANTI_NK_TIENAN_NHANKHAU foreign key (MADINHDANH)
      references NHANKHAU (MADINHDANH)
go

alter table TIEUSU
   add constraint FK_TIEUSU_NK_TIEUSU_NHANKHAU foreign key (MADINHDANH)
      references NHANKHAU (MADINHDANH)
go

alter table XAPHUONGTHITRAN
   add constraint FK_XAPHUONG_QH_XP_QUANHUYE foreign key (maqh)
      references QUANHUYEN (maqh)
go

