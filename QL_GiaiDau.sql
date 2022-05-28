/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     07/12/2021 7:40:00 PM                        */
/*==============================================================*/
USE master
GO
IF DB_ID('QL_GIAIDAU') IS NOT NULL
	DROP DATABASE QL_GIAIDAU
GO
CREATE DATABASE QL_GIAIDAU
GO
USE QL_GIAIDAU
GO

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BANTHANG') and o.name = 'FK_BANTHANG_BANTHANGC_CAUTHU')
alter table BANTHANG
   drop constraint FK_BANTHANG_BANTHANGC_CAUTHU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BANTHANG') and o.name = 'FK_BANTHANG_COBANTHAN_TRANDAU')
alter table BANTHANG
   drop constraint FK_BANTHANG_COBANTHAN_TRANDAU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CAUTHU') and o.name = 'FK_CAUTHU_COCAUTHU_DOIBONG')
alter table CAUTHU
   drop constraint FK_CAUTHU_COCAUTHU_DOIBONG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DOIBONG') and o.name = 'FK_DOIBONG_TAODOIBON_NGUOIDUN')
alter table DOIBONG
   drop constraint FK_DOIBONG_TAODOIBON_NGUOIDUN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('GIAIDAU') and o.name = 'FK_GIAIDAU_TAOGIAIDA_NGUOIDUN')
alter table GIAIDAU
   drop constraint FK_GIAIDAU_TAOGIAIDA_NGUOIDUN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('GIAIDAU') and o.name = 'FK_GIAIDAU_TOCHUCTAI_SANVANDO')
alter table GIAIDAU
   drop constraint FK_GIAIDAU_TOCHUCTAI_SANVANDO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('KETQUA') and o.name = 'FK_KETQUA_RELATIONS_GIAIDAU')
alter table KETQUA
   drop constraint FK_KETQUA_RELATIONS_GIAIDAU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('KETQUA') and o.name = 'FK_KETQUA_RELATIONS_DOIBONG')
alter table KETQUA
   drop constraint FK_KETQUA_RELATIONS_DOIBONG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('THAMGIAGIAIDAU') and o.name = 'FK_THAMGIAG_THAMGIAGI_DOIBONG')
alter table THAMGIAGIAIDAU
   drop constraint FK_THAMGIAG_THAMGIAGI_DOIBONG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('THAMGIAGIAIDAU') and o.name = 'FK_THAMGIAG_THAMGIAGI_GIAIDAU')
alter table THAMGIAGIAIDAU
   drop constraint FK_THAMGIAG_THAMGIAGI_GIAIDAU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('THEPHAT') and o.name = 'FK_THEPHAT_BITHEPHAT_CAUTHU')
alter table THEPHAT
   drop constraint FK_THEPHAT_BITHEPHAT_CAUTHU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('THEPHAT') and o.name = 'FK_THEPHAT_COTHEPHAT_TRANDAU')
alter table THEPHAT
   drop constraint FK_THEPHAT_COTHEPHAT_TRANDAU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TRANDAU') and o.name = 'FK_TRANDAU_RELATIONS_GIAIDAU')
alter table TRANDAU
   drop constraint FK_TRANDAU_RELATIONS_GIAIDAU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TRANDAU') and o.name = 'FK_TRANDAU_RELATIONS_DOIBONG')
alter table TRANDAU
   drop constraint FK_TRANDAU_RELATIONS_DOIBONG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TRANDAU') and o.name = 'FK_TRANDAU_RELATIONS_DOIBONG')
alter table TRANDAU
   drop constraint FK_TRANDAU_RELATIONS_DOIBONG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TRANDAU') and o.name = 'FK_TRANDAU_RELATIONS_VONGDAU')
alter table TRANDAU
   drop constraint FK_TRANDAU_RELATIONS_VONGDAU
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('BANTHANG')
            and   name  = 'BANTHANGCUA_FK'
            and   indid > 0
            and   indid < 255)
   drop index BANTHANG.BANTHANGCUA_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('BANTHANG')
            and   name  = 'COBANTHANG_FK'
            and   indid > 0
            and   indid < 255)
   drop index BANTHANG.COBANTHANG_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BANTHANG')
            and   type = 'U')
   drop table BANTHANG
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CAUTHU')
            and   name  = 'COCAUTHU_FK'
            and   indid > 0
            and   indid < 255)
   drop index CAUTHU.COCAUTHU_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CAUTHU')
            and   type = 'U')
   drop table CAUTHU
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DOIBONG')
            and   name  = 'TAODOIBONG_FK'
            and   indid > 0
            and   indid < 255)
   drop index DOIBONG.TAODOIBONG_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DOIBONG')
            and   type = 'U')
   drop table DOIBONG
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('GIAIDAU')
            and   name  = 'TOCHUCTAI_FK'
            and   indid > 0
            and   indid < 255)
   drop index GIAIDAU.TOCHUCTAI_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('GIAIDAU')
            and   name  = 'TAOGIAIDAU_FK'
            and   indid > 0
            and   indid < 255)
   drop index GIAIDAU.TAOGIAIDAU_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('GIAIDAU')
            and   type = 'U')
   drop table GIAIDAU
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('KETQUA')
            and   name  = 'RELATIONSHIP_15_FK'
            and   indid > 0
            and   indid < 255)
   drop index KETQUA.RELATIONSHIP_15_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('KETQUA')
            and   name  = 'RELATIONSHIP_14_FK'
            and   indid > 0
            and   indid < 255)
   drop index KETQUA.RELATIONSHIP_14_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('KETQUA')
            and   type = 'U')
   drop table KETQUA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('NGUOIDUNG')
            and   type = 'U')
   drop table NGUOIDUNG
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SANVANDONG')
            and   type = 'U')
   drop table SANVANDONG
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('THAMGIAGIAIDAU')
            and   name  = 'THAMGIAGIAIDAU2_FK'
            and   indid > 0
            and   indid < 255)
   drop index THAMGIAGIAIDAU.THAMGIAGIAIDAU2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('THAMGIAGIAIDAU')
            and   name  = 'THAMGIAGIAIDAU_FK'
            and   indid > 0
            and   indid < 255)
   drop index THAMGIAGIAIDAU.THAMGIAGIAIDAU_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('THAMGIAGIAIDAU')
            and   type = 'U')
   drop table THAMGIAGIAIDAU
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('THEPHAT')
            and   name  = 'BITHEPHAT_FK'
            and   indid > 0
            and   indid < 255)
   drop index THEPHAT.BITHEPHAT_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('THEPHAT')
            and   name  = 'COTHEPHAT_FK'
            and   indid > 0
            and   indid < 255)
   drop index THEPHAT.COTHEPHAT_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('THEPHAT')
            and   type = 'U')
   drop table THEPHAT
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TRANDAU')
            and   name  = 'RELATIONSHIP_13_FK'
            and   indid > 0
            and   indid < 255)
   drop index TRANDAU.RELATIONSHIP_13_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TRANDAU')
            and   name  = 'RELATIONSHIP_7_FK'
            and   indid > 0
            and   indid < 255)
   drop index TRANDAU.RELATIONSHIP_7_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TRANDAU')
            and   name  = 'RELATIONSHIP_5_FK'
            and   indid > 0
            and   indid < 255)
   drop index TRANDAU.RELATIONSHIP_5_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TRANDAU')
            and   name  = 'RELATIONSHIP_4_FK'
            and   indid > 0
            and   indid < 255)
   drop index TRANDAU.RELATIONSHIP_4_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TRANDAU')
            and   type = 'U')
   drop table TRANDAU
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VONGDAU')
            and   type = 'U')
   drop table VONGDAU
go

/*==============================================================*/
/* Table: BANTHANG                                              */
/*==============================================================*/
create table BANTHANG (
   MABT                 char(6)              not null,
   MATV                 char(6)              not null,
   MAGD                 char(6)              not null,
   MATD                 char(6)              not null,
   PHUTGHI              int                  null,
   constraint PK_BANTHANG primary key nonclustered (MABT)
)
go

/*==============================================================*/
/* Index: COBANTHANG_FK                                         */
/*==============================================================*/
create index COBANTHANG_FK on BANTHANG (
MAGD ASC,
MATD ASC
)
go

/*==============================================================*/
/* Index: BANTHANGCUA_FK                                        */
/*==============================================================*/
create index BANTHANGCUA_FK on BANTHANG (
MATV ASC
)
go

/*==============================================================*/
/* Table: CAUTHU                                                */
/*==============================================================*/
create table CAUTHU (
   MATV                 char(6)              not null,
   MADB                 char(6)              not null,
   TENTV                nvarchar(20)          null,
   NGAYSINH             datetime             null,
   GIOITINH             nvarchar(3)           null,
   ANHTHE               char(50)                null,
   VITRI                varchar(20)          null,
   SOAO                 int                  null,
   constraint PK_CAUTHU primary key nonclustered (MATV)
)
go

/*==============================================================*/
/* Index: COCAUTHU_FK                                           */
/*==============================================================*/
create index COCAUTHU_FK on CAUTHU (
MADB ASC
)
go

/*==============================================================*/
/* Table: DOIBONG                                               */
/*==============================================================*/
create table DOIBONG (
   MADB                 char(6)              not null,
   MAND                 char(6)              not null,
   TENDB                nvarchar(20)          null,
   SOLUONGTV            int                  null,
   DOTUOI				int						null,
   KHUVUC_HD			char(50)				null,
   GIOITINH				char(50)				null,
   GIOITHIEU			char(50)				null,
   ANHDAIDIEN           char(50)                null,
   ANHDP1               char(50)                null,
   ANHDP2               char(50)                null,
   constraint PK_DOIBONG primary key nonclustered (MADB)
)
go

/*==============================================================*/
/* Index: TAODOIBONG_FK                                         */
/*==============================================================*/
create index TAODOIBONG_FK on DOIBONG (
MAND ASC
)
go

/*==============================================================*/
/* Table: GIAIDAU                                               */
/*==============================================================*/
create table GIAIDAU (
   MAGD                 char(6)              not null,
   MASVD                char(6)              not null,
   MAND                 char(6)              not null,
   TENGD                nvarchar(20)          null,
   SOLUONGDOITG         int                  null,
   SLTV_HT				int					null,
   TUOITOITHIEU         int                  null,
   TUOITOIDA            int                  null,
   SLTVTOIDA            int                  null,
   GIAITHUONG           varchar(20)          null,
   TGBATDAU             datetime             null,
   TRANGTHAI            int                  null,
   ANHDAIDIEN			char(50)			null,
   constraint PK_GIAIDAU primary key nonclustered (MAGD)
)
go

/*==============================================================*/
/* Index: TAOGIAIDAU_FK                                         */
/*==============================================================*/
create index TAOGIAIDAU_FK on GIAIDAU (
MAND ASC
)
go

/*==============================================================*/
/* Index: TOCHUCTAI_FK                                          */
/*==============================================================*/
create index TOCHUCTAI_FK on GIAIDAU (
MASVD ASC
)
go

/*==============================================================*/
/* Table: KETQUA                                                */
/*==============================================================*/
create table KETQUA (
   MAGD                 char(6)              not null,
   MADB                 char(6)              not null,
   TENBANGDAU           char(1)              not null,
   DIEM                 int                  null,
   constraint PK_KETQUA primary key nonclustered (MAGD, MADB, TENBANGDAU)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_14_FK                                    */
/*==============================================================*/
create index RELATIONSHIP_14_FK on KETQUA (
MAGD ASC
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_15_FK                                    */
/*==============================================================*/
create index RELATIONSHIP_15_FK on KETQUA (
MADB ASC
)
go

/*==============================================================*/
/* Table: NGUOIDUNG                                             */
/*==============================================================*/
create table NGUOIDUNG (
   MAND                 char(6)              not null,
   USERNAME             char(20)             null,
   PASSWORD             char(10)             null,
   TENND                nvarchar(20)          null,
   SDT                  char(10)             null,
   EMAIL                char(50)             null,
   NGAYSINH             datetime             null,
   ANHDAIDIEN			char(50)			 null,
   constraint PK_NGUOIDUNG primary key nonclustered (MAND)
)
go

/*==============================================================*/
/* Table: SANVANDONG                                            */
/*==============================================================*/
create table SANVANDONG (
   MASVD                char(6)              not null,
   TENSVD               nvarchar(20)          null,
   DIACHI               nvarchar(50)          null,
   constraint PK_SANVANDONG primary key nonclustered (MASVD)
)
go

/*==============================================================*/
/* Table: THAMGIAGIAIDAU                                        */
/*==============================================================*/
create table THAMGIAGIAIDAU (
   MADB                 char(6)              not null,
   MAGD                 char(6)              not null,
   constraint PK_THAMGIAGIAIDAU primary key (MADB, MAGD)
)
go

/*==============================================================*/
/* Index: THAMGIAGIAIDAU_FK                                     */
/*==============================================================*/
create index THAMGIAGIAIDAU_FK on THAMGIAGIAIDAU (
MADB ASC
)
go

/*==============================================================*/
/* Index: THAMGIAGIAIDAU2_FK                                    */
/*==============================================================*/
create index THAMGIAGIAIDAU2_FK on THAMGIAGIAIDAU (
MAGD ASC
)
go

/*==============================================================*/
/* Table: THEPHAT                                               */
/*==============================================================*/
create table THEPHAT (
   MATP                 char(6)              not null,
   MAGD                 char(6)              not null,
   MATD                 char(6)              not null,
   MATV                 char(6)              not null,
   LOAITHE              char(1)              null,
   PHUTNHAN             int                  null,
   constraint PK_THEPHAT primary key nonclustered (MATP)
)
go

/*==============================================================*/
/* Index: COTHEPHAT_FK                                          */
/*==============================================================*/
create index COTHEPHAT_FK on THEPHAT (
MAGD ASC,
MATD ASC
)
go

/*==============================================================*/
/* Index: BITHEPHAT_FK                                          */
/*==============================================================*/
create index BITHEPHAT_FK on THEPHAT (
MATV ASC
)
go

/*==============================================================*/
/* Table: TRANDAU                                               */
/*==============================================================*/
create table TRANDAU (
   MAGD                 char(6)              not null,
   MATD                 char(6)              not null,
   MADB                 char(6)              not null,
   DOI_MADB             char(6)              not null,
   MAVD                 char(6)              not null,
   SOBAND1              int                  null,
   SOBAND2              int                  null,
   SOTHEPHAT            int                  null,
   THOIGIAN             datetime             null,
   constraint PK_TRANDAU primary key nonclustered (MAGD, MATD)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_4_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_4_FK on TRANDAU (
DOI_MADB ASC
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_5_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_5_FK on TRANDAU (
MADB ASC
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_7_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_7_FK on TRANDAU (
MAVD ASC
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_13_FK                                    */
/*==============================================================*/
create index RELATIONSHIP_13_FK on TRANDAU (
MAGD ASC
)
go

/*==============================================================*/
/* Table: VONGDAU                                               */
/*==============================================================*/
create table VONGDAU (
   MAVD                 char(6)              not null,
   VONGDAU              char(2)              null,
   constraint PK_VONGDAU primary key nonclustered (MAVD)
)
go

alter table BANTHANG
   add constraint FK_BANTHANG_BANTHANGC_CAUTHU foreign key (MATV)
      references CAUTHU (MATV)
go

alter table BANTHANG
   add constraint FK_BANTHANG_COBANTHAN_TRANDAU foreign key (MAGD, MATD)
      references TRANDAU (MAGD, MATD)
go

alter table CAUTHU
   add constraint FK_CAUTHU_COCAUTHU_DOIBONG foreign key (MADB)
      references DOIBONG (MADB)
go

alter table DOIBONG
   add constraint FK_DOIBONG_TAODOIBON_NGUOIDUN foreign key (MAND)
      references NGUOIDUNG (MAND)
go

alter table GIAIDAU
   add constraint FK_GIAIDAU_TAOGIAIDA_NGUOIDUN foreign key (MAND)
      references NGUOIDUNG (MAND)
go

alter table GIAIDAU
   add constraint FK_GIAIDAU_TOCHUCTAI_SANVANDO foreign key (MASVD)
      references SANVANDONG (MASVD)
go

alter table KETQUA
   add constraint FK_KETQUA_RELATIONS_GIAIDAU foreign key (MAGD)
      references GIAIDAU (MAGD)
go

alter table KETQUA
   add constraint FK_KETQUA_RELATIONS_DOIBONG foreign key (MADB)
      references DOIBONG (MADB)
go

alter table THAMGIAGIAIDAU
   add constraint FK_THAMGIAG_THAMGIAGI_DOIBONG foreign key (MADB)
      references DOIBONG (MADB)
go

alter table THAMGIAGIAIDAU
   add constraint FK_THAMGIAG_THAMGIAGI_GIAIDAU foreign key (MAGD)
      references GIAIDAU (MAGD)
go

alter table THEPHAT
   add constraint FK_THEPHAT_BITHEPHAT_CAUTHU foreign key (MATV)
      references CAUTHU (MATV)
go

alter table THEPHAT
   add constraint FK_THEPHAT_COTHEPHAT_TRANDAU foreign key (MAGD, MATD)
      references TRANDAU (MAGD, MATD)
go

alter table TRANDAU
   add constraint FK_TRANDAU_RELATIONS_GIAIDAU foreign key (MAGD)
      references GIAIDAU (MAGD)
go

alter table TRANDAU
   add constraint FK_TRANDAU_RELATIONS_DOIBONG foreign key (DOI_MADB)
      references DOIBONG (MADB)
go

alter table TRANDAU
   add constraint FK_TRANDAU_RELATIONS_DOIBONG1 foreign key (MADB)
      references DOIBONG (MADB)
go

alter table TRANDAU
   add constraint FK_TRANDAU_RELATIONS_VONGDAU foreign key (MAVD)
      references VONGDAU (MAVD)
go

insert into SANVANDONG values('SVD001','SAN 1','DCHI 1'),
								('SVD002','SAN 2','DCHI 2'),
								('SVD003','SAN 3','DCHI 3'),
								('SVD004','SAN 4','DCHI 4'),
								('SVD005','SAN 5','DCHI 5')
