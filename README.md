# nmcnpm
# sql query 
```
create database NMCNPM
USE [master]
GO
/****** Object:  Database [NMCNPM]    Script Date: 08/06/2020 06:19:13 ******/
CREATE DATABASE [NMCNPM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NMCNPM', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\NMCNPM.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'NMCNPM_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\NMCNPM_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [NMCNPM] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NMCNPM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NMCNPM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NMCNPM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NMCNPM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NMCNPM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NMCNPM] SET ARITHABORT OFF 
GO
ALTER DATABASE [NMCNPM] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NMCNPM] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [NMCNPM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NMCNPM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NMCNPM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NMCNPM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NMCNPM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NMCNPM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NMCNPM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NMCNPM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NMCNPM] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NMCNPM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NMCNPM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NMCNPM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NMCNPM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NMCNPM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NMCNPM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NMCNPM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NMCNPM] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [NMCNPM] SET  MULTI_USER 
GO
ALTER DATABASE [NMCNPM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NMCNPM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NMCNPM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NMCNPM] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [NMCNPM]
GO
/****** Object:  StoredProcedure [dbo].[sp_getBP]    Script Date: 08/06/2020 06:19:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_getBP]
as
select *from BoPhan 

GO
/****** Object:  StoredProcedure [dbo].[sp_getEmployee]    Script Date: 08/06/2020 06:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_getEmployee]
AS
	SELECT MaNV,TenNV,Gioitinh,Diachi,SDT,Ngaysinh,MaBP  FROM dbo.NhanVien

GO
/****** Object:  StoredProcedure [dbo].[sp_getKH]    Script Date: 08/06/2020 06:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_getKH]
AS
	SELECT *  FROM dbo.KhachHang

GO
/****** Object:  StoredProcedure [dbo].[sp_getMA]    Script Date: 08/06/2020 06:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_getMA]
AS
	SELECT *  FROM dbo.MonAn

GO
/****** Object:  StoredProcedure [dbo].[sp_getNCC]    Script Date: 08/06/2020 06:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_getNCC]
AS
	SELECT *  FROM dbo.NhaCungCap

GO
/****** Object:  StoredProcedure [dbo].[sp_getNL]    Script Date: 08/06/2020 06:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_getNL]
AS
	SELECT *  FROM dbo.NguyenLieu

GO
/****** Object:  StoredProcedure [dbo].[sp_insertEmplyees]    Script Date: 08/06/2020 06:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_insertEmplyees]
@sTenNhanVien NVARCHAR(50),
@sSDT NVARCHAR(10),
@sDiaChi NVARCHAR(50), 
@bGioiTinh BIT,
@dNgaySinh DATETIME,
@MaBP int
AS
	INSERT INTO dbo.NhanVien
	        ( MaNV,
          TenNV ,
		  Diachi ,
          Ngaysinh ,
          SDT,
          MaBP,
          Quyen,
		  pass,
		  sUsername,
		  Gioitinh
	        )
	VALUES  ( dbo.fcgetEmployee() , -- sMaNhanVien - nvarchar(50)
	          @sTenNhanVien , -- sTenNhanVien - nvarchar(50)
			   @sDiaChi , -- sDiaChi - nvarchar(50)
	          
	          @dNgaySinh , -- dNgaySinh - datetime
	          @sSDT , -- sSDT - nvarchar(10)
	         
	          @MaBP , -- dNgayVaoLam - datetime
	          N'' , -- sUsername - nvarchar(50)
	          N'' , -- sPassword - nvarchar(50)
	          N'',  -- sQuyen - nvarchar(50)
			  @bGioiTinh  -- bGioiTinh - bit
	        )

GO
/****** Object:  StoredProcedure [dbo].[sp_insertKH]    Script Date: 08/06/2020 06:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_insertKH]
@sTenKH NVARCHAR(50),
@sSDT NVARCHAR(10),
@sDiaChi NVARCHAR(50) 

AS
	INSERT INTO dbo.KhachHang
	        ( MaKH,
          TenKH ,
		   SDT,
		  Diachi 
          
         
          
	        )
	VALUES  ( dbo.fcgetCustomer() , -- sMaNhanVien - nvarchar(50)
	          @sTenKH , -- sTenNhanVien - nvarchar(50)
			   @sDiaChi , -- sDiaChi - nvarchar(50)
	          @sSDT  -- sSDT - nvarchar(10)
	         
	          
	        )

GO
/****** Object:  StoredProcedure [dbo].[sp_insertMA]    Script Date: 08/06/2020 06:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_insertMA]
@sTenMA NVARCHAR(50),
@Dongia int 

AS
	INSERT INTO dbo.MonAn
	        ( 
			TenMon ,
			 Dongia
          
         
          
	        )
	VALUES  ( 
	          @sTenMA , -- sTenNhanVien - nvarchar(50)
			   @Dongia
	         
	          
	        )

GO
/****** Object:  StoredProcedure [dbo].[sp_insertNCC]    Script Date: 08/06/2020 06:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_insertNCC]
@sTenNCC NVARCHAR(50),
@sSDT NVARCHAR(10),
@sDiaChi NVARCHAR(50) 

AS
	INSERT INTO dbo.NhaCungCap
	        ( 
          TenNCC ,
		   SDT,
		  Diachi 
          
         
          
	        )
	VALUES  ( 
	          @sTenNCC , -- sTenNhanVien - nvarchar(50)
			   @sDiaChi , -- sDiaChi - nvarchar(50)
	          @sSDT  -- sSDT - nvarchar(10)
	         
	          
	        )

GO
/****** Object:  StoredProcedure [dbo].[sp_insertNL]    Script Date: 08/06/2020 06:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_insertNL]
@sTenNL NVARCHAR(50),
@Dongia int ,
@Soluong int,
@MaNCC int

AS
	INSERT INTO dbo.NguyenLieu
	        ( 
			TenNL ,
			 Dongia,
			 Soluong ,
			 MaNCC 
          
         
          
	        )
	VALUES  ( 
	          @sTenNL , -- sTenNhanVien - nvarchar(50)
			   @Dongia,
			   @Soluong,
			   @MaNCC
	         
	          
	        )

GO
/****** Object:  StoredProcedure [dbo].[sp_login]    Script Date: 08/06/2020 06:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_login]
@sUsername NVARCHAR(50),
@sPassword NVARCHAR(50)
AS
	SELECT * FROM dbo.NhanVien WHERE sUsername = @sUsername AND pass = @sPassword

GO
/****** Object:  StoredProcedure [dbo].[sp_updateEmployees]    Script Date: 08/06/2020 06:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_updateEmployees]
@sMaNhanVien NVARCHAR(50),
@sTenNhanVien NVARCHAR(50),
@sSDT NVARCHAR(10),
@sDiaChi NVARCHAR(50), 
@bGioiTinh BIT,
@dNgaySinh DATETIME,
@MaBP int
AS
	UPDATE dbo.NhanVien SET TenNV = @sTenNhanVien,SDT = @sSDT,Diachi = @sDiaChi,Gioitinh = @bGioiTinh,Ngaysinh = @dNgaySinh,MaBP = @MaBP
	WHERE MaNV= @sMaNhanVien

GO
/****** Object:  StoredProcedure [dbo].[sp_updateKH]    Script Date: 08/06/2020 06:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_updateKH]
@sMaKH NVARCHAR(50),
@sTenKH NVARCHAR(50),
@sSDT NVARCHAR(10),
@sDiaChi NVARCHAR(50) 

AS
	UPDATE dbo.KhachHang SET TenKH = @sTenKH,SDT = @sSDT,Diachi = @sDiaChi
	WHERE MaKH= @sMaKH

GO
/****** Object:  StoredProcedure [dbo].[sp_updateMA]    Script Date: 08/06/2020 06:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_updateMA]
@sMaMA int,
@sTenMA NVARCHAR(50),
@Dongia int

AS
	UPDATE dbo.MonAn SET TenMon = @sTenMA,Dongia=@Dongia
	WHERE MaMon= @sMaMA

GO
/****** Object:  StoredProcedure [dbo].[sp_updateMKNV]    Script Date: 08/06/2020 06:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_updateMKNV]
@sMaNhanVien NVARCHAR(50),
@MKcu NVARCHAR(50),
@MKmoi  NVARCHAR(50)
as
begin
declare @pass nvarchar(50)
set @pass = (select pass from NhanVien where @sMaNhanVien=MaNV)

if(@pass=@MKcu)
begin
update NhanVien
set pass=@MKmoi
where @sMaNhanVien=MaNV
return @@Rowcount;
end
else 
return -1;
end
GO
/****** Object:  StoredProcedure [dbo].[sp_updateNCC]    Script Date: 08/06/2020 06:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_updateNCC]
@sMaNCC int,
@sTenNCC NVARCHAR(50),
@sSDT NVARCHAR(10),
@sDiaChi NVARCHAR(50) 

AS
	UPDATE dbo.NhaCungCap SET TenNCC = @sTenNCC,SDT = @sSDT,Diachi = @sDiaChi
	WHERE MaNCC= @sMaNCC

GO
/****** Object:  StoredProcedure [dbo].[sp_updateNL]    Script Date: 08/06/2020 06:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_updateNL]
@sMaNL int,
@sTenNL NVARCHAR(50),
@Dongia int,
@Soluong int,
@MaNCC int
AS
	UPDATE dbo.NguyenLieu SET TenNl = @sTenNL,Dongia=@Dongia, Soluong=@Soluong,MaNCC=@MaNCC
	WHERE MaNL= @sMaNL

GO
/****** Object:  StoredProcedure [dbo].[sp_updateNV]    Script Date: 08/06/2020 06:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_updateNV]
@sMaNhanVien NVARCHAR(50),
@Quyen NVARCHAR(50)

AS
	UPDATE dbo.NhanVien SET Quyen=@Quyen
	WHERE MaNV= @sMaNhanVien

GO
/****** Object:  UserDefinedFunction [dbo].[fcgetCustomer]    Script Date: 08/06/2020 06:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[fcgetCustomer]()
returns varchar(50)
as
begin 
   declare @sMaKhachHang varchar(10)
   declare @MaxMaKhachHang varchar(10)
   declare @Max float

   select @MaxMaKhachHang=MAX(MaKH) from dbo.KhachHang

   if exists (select MaKH from dbo.KhachHang)
						set @Max = CONVERT(float, SUBSTRING(@MaxMaKhachHang,3,8)) + 1
			else
						set @Max=1	
			if (@Max < 10)
						set @sMaKhachHang='KH' + '0000000' + Convert(varchar(1),@Max)
			else
			if (@Max < 100)
						set @sMaKhachHang='KH' + '000000' + Convert(varchar(2),@Max)
			else
			if (@Max < 1000)
						set @sMaKhachHang='KH' + '00000' + Convert(varchar(3),@Max)
			else
			if (@Max < 10000)
						set @sMaKhachHang='KH' + '0000' + Convert(varchar(4),@Max)
			else
			if (@Max < 100000)
						set @sMaKhachHang ='KH' + '000' + Convert(varchar(5),@Max)
			else
			if (@Max < 1000000)
						set @sMaKhachHang  ='KH' + '00' + Convert(varchar(6),@Max)
			else	
			if (@Max < 10000000)
						set @sMaKhachHang ='KH' + '0' + Convert(varchar(7),@Max)
			else
						set @sMaKhachHang ='KH' +  Convert(varchar(8),@Max)
			Return @sMaKhachHang
END

GO
/****** Object:  UserDefinedFunction [dbo].[fcgetEmployee]    Script Date: 08/06/2020 06:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create  function [dbo].[fcgetEmployee]()
returns varchar(50)
as
begin 
   declare @sMaNV varchar(10)
   declare @MaxMaNV varchar(10)
   declare @Max float

   select @MaxMaNV=MAX(MaNV) from dbo.NhanVien

   if exists (select MaNV from dbo.NhanVien)
						set @Max = CONVERT(float, SUBSTRING(@MaxMaNV,3,8)) + 1
			else
						set @Max=1	
			if (@Max < 10)
						set @sMaNV='NV' + '0000000' + Convert(varchar(1),@Max)
			else
			if (@Max < 100)
						set @sMaNV='NV' + '000000' + Convert(varchar(2),@Max)
			else
			if (@Max < 1000)
						set @sMaNV='NV' + '00000' + Convert(varchar(3),@Max)
			else
			if (@Max < 10000)
						set @sMaNV='NV' + '0000' + Convert(varchar(4),@Max)
			else
			if (@Max < 100000)
						set @sMaNV ='NV' + '000' + Convert(varchar(5),@Max)
			else
			if (@Max < 1000000)
						set @sMaNV  ='NV' + '00' + Convert(varchar(6),@Max)
			else	
			if (@Max < 10000000)
						set @sMaNV ='NV' + '0' + Convert(varchar(7),@Max)
			else
						set @sMaNV ='NV' +  Convert(varchar(8),@Max)
			Return @sMaNV
end 
GO
/****** Object:  Table [dbo].[BoPhan]    Script Date: 08/06/2020 06:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoPhan](
	[MaBP] [int] IDENTITY(1,1) NOT NULL,
	[TenBP] [nvarchar](50) NULL,
 CONSTRAINT [PK_BoPhan] PRIMARY KEY CLUSTERED 
(
	[MaBP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CTHoaDonBan]    Script Date: 08/06/2020 06:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTHoaDonBan](
	[MaHD] [int] NOT NULL,
	[MaMon] [int] NOT NULL,
	[Soluong] [int] NULL,
 CONSTRAINT [PK_CTHoaDonBan] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC,
	[MaMon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CTHoaDonDatHang]    Script Date: 08/06/2020 06:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTHoaDonDatHang](
	[MaHDD] [int] NOT NULL,
	[MaNL] [int] NOT NULL,
	[Soluong] [int] NULL,
 CONSTRAINT [PK_CTHoaDonDatHang] PRIMARY KEY CLUSTERED 
(
	[MaHDD] ASC,
	[MaNL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CTHoaDonNhapHang]    Script Date: 08/06/2020 06:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTHoaDonNhapHang](
	[MaNH] [int] NOT NULL,
	[MaNL] [int] NOT NULL,
	[Soluong] [int] NULL,
 CONSTRAINT [PK_CTHoaDonNhapHang] PRIMARY KEY CLUSTERED 
(
	[MaNH] ASC,
	[MaNL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CTHoaDonTraHang]    Script Date: 08/06/2020 06:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTHoaDonTraHang](
	[MaHDT] [int] NOT NULL,
	[MaNL] [int] NOT NULL,
	[Soluong] [int] NULL,
	[Lido] [nvarchar](50) NULL,
 CONSTRAINT [PK_CTHoaDonTraHang] PRIMARY KEY CLUSTERED 
(
	[MaHDT] ASC,
	[MaNL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDonBanHang]    Script Date: 08/06/2020 06:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonBanHang](
	[MaHD] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [nvarchar](50) NULL,
	[MaKH] [nvarchar](50) NULL,
	[Soban] [nvarchar](50) NULL,
	[Thoigian] [datetime] NULL,
	[Giamgia] [float] NULL,
 CONSTRAINT [PK_HoaDonBanHang] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDonDatHang]    Script Date: 08/06/2020 06:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonDatHang](
	[MaHDD] [int] IDENTITY(1,1) NOT NULL,
	[Ngaydat] [datetime] NULL,
	[MaNV] [nvarchar](50) NULL,
 CONSTRAINT [PK_HoaDonDatHang] PRIMARY KEY CLUSTERED 
(
	[MaHDD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDonNhapHang]    Script Date: 08/06/2020 06:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonNhapHang](
	[MaNH] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [nvarchar](50) NULL,
	[NguoiGiao] [nvarchar](50) NULL,
	[Thoigian] [datetime] NULL,
 CONSTRAINT [PK_HoaDonNhapHang] PRIMARY KEY CLUSTERED 
(
	[MaNH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDonTraHang]    Script Date: 08/06/2020 06:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonTraHang](
	[MaHDT] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [nvarchar](50) NULL,
	[Thoigian] [datetime] NULL,
 CONSTRAINT [PK_HoaDonTraHang] PRIMARY KEY CLUSTERED 
(
	[MaHDT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 08/06/2020 06:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [nvarchar](50) NOT NULL,
	[TenKH] [nvarchar](50) NULL,
	[SDT] [nvarchar](50) NULL,
	[Diachi] [nvarchar](50) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MonAn]    Script Date: 08/06/2020 06:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonAn](
	[MaMon] [int] IDENTITY(1,1) NOT NULL,
	[TenMon] [nvarchar](50) NULL,
	[Dongia] [int] NULL,
 CONSTRAINT [PK_MonAn] PRIMARY KEY CLUSTERED 
(
	[MaMon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NguyenLieu]    Script Date: 08/06/2020 06:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguyenLieu](
	[MaNL] [int] IDENTITY(1,1) NOT NULL,
	[TenNL] [nvarchar](50) NULL,
	[Dongia] [float] NULL,
	[MaNCC] [int] NULL,
	[Soluong] [int] NULL,
 CONSTRAINT [PK_NguyenLieu] PRIMARY KEY CLUSTERED 
(
	[MaNL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 08/06/2020 06:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[MaNCC] [int] IDENTITY(1,1) NOT NULL,
	[TenNCC] [nvarchar](50) NULL,
	[SDT] [nvarchar](50) NULL,
	[Diachi] [nvarchar](50) NULL,
 CONSTRAINT [PK_NhaCungCap] PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 08/06/2020 06:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [nvarchar](50) NOT NULL,
	[TenNV] [nvarchar](50) NULL,
	[Diachi] [nvarchar](50) NULL,
	[Ngaysinh] [datetime] NULL,
	[SDT] [nvarchar](50) NULL,
	[MaBP] [int] NULL,
	[Quyen] [nvarchar](50) NOT NULL,
	[pass] [nvarchar](50) NULL,
	[sUsername] [nvarchar](50) NULL,
	[Gioitinh] [bit] NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[BoPhan] ON 

INSERT [dbo].[BoPhan] ([MaBP], [TenBP]) VALUES (1, N'Bán Hàng')
INSERT [dbo].[BoPhan] ([MaBP], [TenBP]) VALUES (2, N'Chế Biến')
SET IDENTITY_INSERT [dbo].[BoPhan] OFF
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [Diachi]) VALUES (N'KH00000001', N'Nguyễn Văn Tùng', N'0929559912', N'Hưng Yên')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [Diachi]) VALUES (N'KH00000002', N'Đinh Trang', N'Hà Nội', N'123698745')
SET IDENTITY_INSERT [dbo].[MonAn] ON 

INSERT [dbo].[MonAn] ([MaMon], [TenMon], [Dongia]) VALUES (1, N'Pizza Bò Nướng', 180000)
INSERT [dbo].[MonAn] ([MaMon], [TenMon], [Dongia]) VALUES (2, N'Pizza Hải Sản', 180000)
INSERT [dbo].[MonAn] ([MaMon], [TenMon], [Dongia]) VALUES (3, N'Pizza Thịt Heo', 170000)
SET IDENTITY_INSERT [dbo].[MonAn] OFF
SET IDENTITY_INSERT [dbo].[NguyenLieu] ON 

INSERT [dbo].[NguyenLieu] ([MaNL], [TenNL], [Dongia], [MaNCC], [Soluong]) VALUES (2, N'Bò', 250000, 1, 4)
SET IDENTITY_INSERT [dbo].[NguyenLieu] OFF
SET IDENTITY_INSERT [dbo].[NhaCungCap] ON 

INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [SDT], [Diachi]) VALUES (1, N'Mai Linh', N'0123698754', N'Phú Thọ')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [SDT], [Diachi]) VALUES (2, N'Hoa Mai', N'0698726112', N'Hà Nội')
SET IDENTITY_INSERT [dbo].[NhaCungCap] OFF
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [Diachi], [Ngaysinh], [SDT], [MaBP], [Quyen], [pass], [sUsername], [Gioitinh]) VALUES (N'NV00000001', N'Nguyễn Thị Ngân', N'Hưng Yên', CAST(0x00008C8C00000000 AS DateTime), N'0337981919', 1, N'thanhvien', N'123456', N'NV00000001', 0)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [Diachi], [Ngaysinh], [SDT], [MaBP], [Quyen], [pass], [sUsername], [Gioitinh]) VALUES (N'NV00000002', N'Nguyễn Minh Hà', N'Hà Nội', CAST(0x00008C9100000000 AS DateTime), N'0363987524', 1, N'nhanvien', N'123456', N'NV00000002', 0)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [Diachi], [Ngaysinh], [SDT], [MaBP], [Quyen], [pass], [sUsername], [Gioitinh]) VALUES (N'NV00000003', N'Đỗ Mạnh Dũng', N'Hà Nam', CAST(0x00008CAB002FDD20 AS DateTime), N'0321456789', 2, N'nhanvien', N'123456', N'NV00000003', 1)
ALTER TABLE [dbo].[CTHoaDonBan]  WITH CHECK ADD  CONSTRAINT [FK_CTHoaDonBan_HoaDonBanHang] FOREIGN KEY([MaHD])
REFERENCES [dbo].[HoaDonBanHang] ([MaHD])
GO
ALTER TABLE [dbo].[CTHoaDonBan] CHECK CONSTRAINT [FK_CTHoaDonBan_HoaDonBanHang]
GO
ALTER TABLE [dbo].[CTHoaDonBan]  WITH CHECK ADD  CONSTRAINT [FK_CTHoaDonBan_MonAn] FOREIGN KEY([MaMon])
REFERENCES [dbo].[MonAn] ([MaMon])
GO
ALTER TABLE [dbo].[CTHoaDonBan] CHECK CONSTRAINT [FK_CTHoaDonBan_MonAn]
GO
ALTER TABLE [dbo].[CTHoaDonDatHang]  WITH CHECK ADD  CONSTRAINT [FK_CTHoaDonDatHang_HoaDonDatHang] FOREIGN KEY([MaHDD])
REFERENCES [dbo].[HoaDonDatHang] ([MaHDD])
GO
ALTER TABLE [dbo].[CTHoaDonDatHang] CHECK CONSTRAINT [FK_CTHoaDonDatHang_HoaDonDatHang]
GO
ALTER TABLE [dbo].[CTHoaDonDatHang]  WITH CHECK ADD  CONSTRAINT [FK_CTHoaDonDatHang_NguyenLieu] FOREIGN KEY([MaNL])
REFERENCES [dbo].[NguyenLieu] ([MaNL])
GO
ALTER TABLE [dbo].[CTHoaDonDatHang] CHECK CONSTRAINT [FK_CTHoaDonDatHang_NguyenLieu]
GO
ALTER TABLE [dbo].[CTHoaDonNhapHang]  WITH CHECK ADD  CONSTRAINT [FK_CTHoaDonNhapHang_HoaDonNhapHang] FOREIGN KEY([MaNH])
REFERENCES [dbo].[HoaDonNhapHang] ([MaNH])
GO
ALTER TABLE [dbo].[CTHoaDonNhapHang] CHECK CONSTRAINT [FK_CTHoaDonNhapHang_HoaDonNhapHang]
GO
ALTER TABLE [dbo].[CTHoaDonNhapHang]  WITH CHECK ADD  CONSTRAINT [FK_CTHoaDonNhapHang_NguyenLieu] FOREIGN KEY([MaNL])
REFERENCES [dbo].[NguyenLieu] ([MaNL])
GO
ALTER TABLE [dbo].[CTHoaDonNhapHang] CHECK CONSTRAINT [FK_CTHoaDonNhapHang_NguyenLieu]
GO
ALTER TABLE [dbo].[CTHoaDonTraHang]  WITH CHECK ADD  CONSTRAINT [FK_CTHoaDonTraHang_HoaDonTraHang] FOREIGN KEY([MaHDT])
REFERENCES [dbo].[HoaDonTraHang] ([MaHDT])
GO
ALTER TABLE [dbo].[CTHoaDonTraHang] CHECK CONSTRAINT [FK_CTHoaDonTraHang_HoaDonTraHang]
GO
ALTER TABLE [dbo].[CTHoaDonTraHang]  WITH CHECK ADD  CONSTRAINT [FK_CTHoaDonTraHang_NguyenLieu] FOREIGN KEY([MaNL])
REFERENCES [dbo].[NguyenLieu] ([MaNL])
GO
ALTER TABLE [dbo].[CTHoaDonTraHang] CHECK CONSTRAINT [FK_CTHoaDonTraHang_NguyenLieu]
GO
ALTER TABLE [dbo].[HoaDonBanHang]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonBanHang_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[HoaDonBanHang] CHECK CONSTRAINT [FK_HoaDonBanHang_KhachHang]
GO
ALTER TABLE [dbo].[HoaDonBanHang]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonBanHang_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[HoaDonBanHang] CHECK CONSTRAINT [FK_HoaDonBanHang_NhanVien]
GO
ALTER TABLE [dbo].[HoaDonNhapHang]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonNhapHang_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[HoaDonNhapHang] CHECK CONSTRAINT [FK_HoaDonNhapHang_NhanVien]
GO
ALTER TABLE [dbo].[NguyenLieu]  WITH CHECK ADD  CONSTRAINT [FK_NguyenLieu_NhaCungCap] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NhaCungCap] ([MaNCC])
GO
ALTER TABLE [dbo].[NguyenLieu] CHECK CONSTRAINT [FK_NguyenLieu_NhaCungCap]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_BoPhan] FOREIGN KEY([MaBP])
REFERENCES [dbo].[BoPhan] ([MaBP])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_BoPhan]
GO
USE [master]
GO
ALTER DATABASE [NMCNPM] SET  READ_WRITE 
GO
use NMCNPM
go
create proc sp_getHDBH
as
select * from HoaDonBanHang inner join CTHoaDonBan on HoaDonBanHang.MaHD = CTHoaDonBan.MaHD
go
alter proc sp_insertHDBH
@MaHD int,
@MaNV nvarchar(50),
@MaKH nvarchar(50),
@Soban nvarchar(50),
@Thoigian datetime,
@Giamgia float,
@MaMon int,
@Soluong int
as 
insert into HoaDonBanHang
values(@MaHD,@MaNV,@MaKH,@Soban,@Thoigian,@Giamgia)
insert into CTHoaDonBan
values(@MaHD,@MaMon,@Soluong)
go
create proc sp_updateHDBH
@MaHD int,
@MaNV nvarchar(50),
@MaKH nvarchar(50),
@Soban nvarchar(50),
@Giamgia float,
@MaMon int,
@Soluong int
as
update HoaDonBanHang
set MaHD = @MaHD,
MaNV = @MaNV,
MaKH = @MaKH,
Soban = @Soban,
Giamgia = @Giamgia
where MaHD = @MaHD
update CTHoaDonBan
set MaHD = @MaHD,
MaMon = @MaMon,
Soluong = @Soluong
where MaHD = @MaHD
go
```



