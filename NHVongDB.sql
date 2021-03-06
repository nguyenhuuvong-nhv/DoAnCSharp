USE [master]
GO
/****** Object:  Database [NHVongDB]    Script Date: 20/06/2021 7:58:29 CH ******/
CREATE DATABASE [NHVongDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NHVongDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\NHVongDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NHVongDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\NHVongDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [NHVongDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NHVongDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NHVongDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NHVongDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NHVongDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NHVongDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NHVongDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [NHVongDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NHVongDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NHVongDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NHVongDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NHVongDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NHVongDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NHVongDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NHVongDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NHVongDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NHVongDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NHVongDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NHVongDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NHVongDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NHVongDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NHVongDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NHVongDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NHVongDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NHVongDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [NHVongDB] SET  MULTI_USER 
GO
ALTER DATABASE [NHVongDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NHVongDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NHVongDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NHVongDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NHVongDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NHVongDB] SET QUERY_STORE = OFF
GO
USE [NHVongDB]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 20/06/2021 7:58:30 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [varchar](6) NOT NULL,
	[CategoryName] [nvarchar](30) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 20/06/2021 7:58:30 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [varchar](6) NOT NULL,
	[ProductName] [nvarchar](30) NOT NULL,
	[UnitCost] [money] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Image] [varchar](100) NULL,
	[Description] [nvarchar](500) NULL,
	[CategoryID] [varchar](6) NOT NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAccount]    Script Date: 20/06/2021 7:58:30 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAccount](
	[UserID] [varchar](6) NOT NULL,
	[UserName] [nvarchar](30) NOT NULL,
	[Password] [varchar](300) NOT NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Description]) VALUES (N'1', N'Sữa rửa mặt & Toner', N'1qe')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Description]) VALUES (N'2', N'Tái Tạo', N'vqqv')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Description]) VALUES (N'3', N'Serum', N'faa')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Description]) VALUES (N'4', N'Kem dưỡng ẩm / Bảo vệ', N'ad')
GO
INSERT [dbo].[Product] ([ProductID], [ProductName], [UnitCost], [Quantity], [Image], [Description], [CategoryID], [Status]) VALUES (N'1', N'Clarifying Toner', 455.0000, 23, N'Data/Sites/1/Product/565/duoc-my-pham-murad-clarifying-toner-compressor.jpg', N'Nét da căng mượt - Xua tan lão hóa', N'2', 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [UnitCost], [Quantity], [Image], [Description], [CategoryID], [Status]) VALUES (N'2', N'Clarifying Mask', 123.0000, 45, N'Data/Sites/1/Product/1095/clarifying-mask.jpg', N'Kem dưỡng siêu cung cấp độ ẩm cho mắt', N'1', 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [UnitCost], [Quantity], [Image], [Description], [CategoryID], [Status]) VALUES (N'3', N'Acne Body Wash', 100.0000, 45, N'/Data/Sites/1/Product/642/duoc-my-pham-murad-acne-body-wash.jpg', N'Gel tắm kiểm soát mụn cơ thể & Tẩy tế bào chết dịu nhẹ', N'4', 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [UnitCost], [Quantity], [Image], [Description], [CategoryID], [Status]) VALUES (N'4', N'Dew Gooder', 560.0000, 45, N'/Data/Sites/1/Product/1186/dew-gooder_alt_1__99580.16001252.jpg', N'Phục hồi chuyên sâu - ẩm mượt từng tế bào', N'4', 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [UnitCost], [Quantity], [Image], [Description], [CategoryID], [Status]) VALUES (N'5', N'CHỐNG NẮNG BÊN TRONG', 142.0000, 14, N'/Data/Sites/1/Product/1313/km-12.png', N'Đẹp từ trong giấc ngủ', N'3', 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [UnitCost], [Quantity], [Image], [Description], [CategoryID], [Status]) VALUES (N'6', N'Keep Skin Smooth and Young', 130.0000, 55, N'/Data/Sites/1/Product/1252/km-03.png', N'Nét da căng mượt - Xua tan lão hóa', N'2', 1)
GO
INSERT [dbo].[UserAccount] ([UserID], [UserName], [Password], [Status]) VALUES (N'1', N'admin', N'21232f297a57a5a743894a0e4a801fc3', 1)
INSERT [dbo].[UserAccount] ([UserID], [UserName], [Password], [Status]) VALUES (N'2', N'hv', N'0585c777d1ef4367398ab5136d1e50d4', 0)
INSERT [dbo].[UserAccount] ([UserID], [UserName], [Password], [Status]) VALUES (N'3', N'Tom', N'54064b3ae8950c01c573f95fd99e3358', 1)
INSERT [dbo].[UserAccount] ([UserID], [UserName], [Password], [Status]) VALUES (N'4', N'Jerry', N'f6c2ab00e0f2b607be34fb11bcc159a4', 0)
INSERT [dbo].[UserAccount] ([UserID], [UserName], [Password], [Status]) VALUES (N'5', N'Tiger', N'454c9843110686bf6f67ce5115b66617', 0)
INSERT [dbo].[UserAccount] ([UserID], [UserName], [Password], [Status]) VALUES (N'6', N'Dog', N'47e5872dedc9ac45434480385d670bf7', 1)
INSERT [dbo].[UserAccount] ([UserID], [UserName], [Password], [Status]) VALUES (N'7', N'1811505310353', N'36b08b5a853ab6da7dd0b2951f45fa4b', 0)
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
USE [master]
GO
ALTER DATABASE [NHVongDB] SET  READ_WRITE 
GO
