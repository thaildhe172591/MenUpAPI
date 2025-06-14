USE [master]
GO
/****** Object:  Database [SkincareShopForMen]    Script Date: 05/27/2025 02:04:10 ******/
CREATE DATABASE [SkincareShopForMen]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SkincareShopForMen', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SkincareShopForMen.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SkincareShopForMen_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SkincareShopForMen_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [SkincareShopForMen] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SkincareShopForMen].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SkincareShopForMen] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SkincareShopForMen] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SkincareShopForMen] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SkincareShopForMen] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SkincareShopForMen] SET ARITHABORT OFF 
GO
ALTER DATABASE [SkincareShopForMen] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SkincareShopForMen] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SkincareShopForMen] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SkincareShopForMen] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SkincareShopForMen] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SkincareShopForMen] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SkincareShopForMen] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SkincareShopForMen] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SkincareShopForMen] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SkincareShopForMen] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SkincareShopForMen] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SkincareShopForMen] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SkincareShopForMen] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SkincareShopForMen] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SkincareShopForMen] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SkincareShopForMen] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SkincareShopForMen] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SkincareShopForMen] SET RECOVERY FULL 
GO
ALTER DATABASE [SkincareShopForMen] SET  MULTI_USER 
GO
ALTER DATABASE [SkincareShopForMen] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SkincareShopForMen] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SkincareShopForMen] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SkincareShopForMen] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SkincareShopForMen] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SkincareShopForMen] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SkincareShopForMen', N'ON'
GO
ALTER DATABASE [SkincareShopForMen] SET QUERY_STORE = ON
GO
ALTER DATABASE [SkincareShopForMen] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [SkincareShopForMen]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 05/27/2025 02:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[BrandId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Country] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[BrandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CartItems]    Script Date: 05/27/2025 02:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartItems](
	[CartItemId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[ProductId] [int] NULL,
	[Quantity] [int] NULL,
	[AddedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CartItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 05/27/2025 02:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmailVerifications]    Script Date: 05/27/2025 02:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailVerifications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Username] [nvarchar](100) NULL,
	[PasswordHash] [nvarchar](500) NOT NULL,
	[FullName] [nvarchar](200) NULL,
	[OtpCode] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ExpiredAt] [datetime] NULL,
	[Gender] [nvarchar](10) NULL,
	[DateOfBirth] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 05/27/2025 02:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderDetailId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
	[ProductId] [int] NULL,
	[Quantity] [int] NULL,
	[UnitPrice] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 05/27/2025 02:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[OrderDate] [datetime] NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[Status] [nvarchar](50) NULL,
	[ShippingAddress] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 05/27/2025 02:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[PaymentId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
	[PaymentDate] [datetime] NULL,
	[Amount] [decimal](18, 2) NULL,
	[PaymentMethod] [nvarchar](50) NULL,
	[PaymentStatus] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductReviews]    Script Date: 05/27/2025 02:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductReviews](
	[ReviewId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[UserId] [int] NULL,
	[Rating] [int] NULL,
	[Comment] [nvarchar](max) NULL,
	[ReviewDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ReviewId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 05/27/2025 02:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Quantity] [int] NOT NULL,
	[CategoryId] [int] NULL,
	[BrandId] [int] NULL,
	[ImageUrl] [nvarchar](500) NULL,
	[CreatedAt] [datetime] NULL,
	[GenderTarget] [nvarchar](20) NULL,
	[AffiliateLink] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 05/27/2025 02:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SkinAnalyses]    Script Date: 05/27/2025 02:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SkinAnalyses](
	[AnalysisId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[AnalysisDate] [datetime] NULL,
	[SkinType] [nvarchar](50) NULL,
	[BrightnessLevel] [int] NULL,
	[AcneLevel] [int] NULL,
	[TextureScore] [int] NULL,
	[PoresVisibility] [int] NULL,
	[DarkSpotsLevel] [int] NULL,
	[AnalysisResult] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[AnalysisId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 05/27/2025 02:04:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[PasswordHash] [nvarchar](255) NOT NULL,
	[FullName] [nvarchar](255) NULL,
	[Gender] [nvarchar](10) NULL,
	[DateOfBirth] [date] NULL,
	[CreatedAt] [datetime] NULL,
	[IsVerified] [bit] NULL,
	[RoleId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Brands] ON 

INSERT [dbo].[Brands] ([BrandId], [Name], [Country]) VALUES (1, N'Hada Labo', N'Nhật Bản')
INSERT [dbo].[Brands] ([BrandId], [Name], [Country]) VALUES (2, N'Nivea Men', N'Đức')
INSERT [dbo].[Brands] ([BrandId], [Name], [Country]) VALUES (3, N'L’Oreal Men Expert', N'Pháp')
SET IDENTITY_INSERT [dbo].[Brands] OFF
GO
SET IDENTITY_INSERT [dbo].[CartItems] ON 

INSERT [dbo].[CartItems] ([CartItemId], [UserId], [ProductId], [Quantity], [AddedAt]) VALUES (8, 1, 1, 9, CAST(N'2025-05-26T18:26:49.340' AS DateTime))
INSERT [dbo].[CartItems] ([CartItemId], [UserId], [ProductId], [Quantity], [AddedAt]) VALUES (9, 1, 6, 3, CAST(N'2025-05-26T18:26:55.387' AS DateTime))
INSERT [dbo].[CartItems] ([CartItemId], [UserId], [ProductId], [Quantity], [AddedAt]) VALUES (10, 1, 7, 1, CAST(N'2025-05-26T18:27:18.443' AS DateTime))
INSERT [dbo].[CartItems] ([CartItemId], [UserId], [ProductId], [Quantity], [AddedAt]) VALUES (11, 1, 8, 1, CAST(N'2025-05-26T18:39:19.080' AS DateTime))
INSERT [dbo].[CartItems] ([CartItemId], [UserId], [ProductId], [Quantity], [AddedAt]) VALUES (12, 1, 5, 2, CAST(N'2025-05-26T18:40:03.537' AS DateTime))
INSERT [dbo].[CartItems] ([CartItemId], [UserId], [ProductId], [Quantity], [AddedAt]) VALUES (13, 1, 2, 1, CAST(N'2025-05-26T19:02:59.580' AS DateTime))
INSERT [dbo].[CartItems] ([CartItemId], [UserId], [ProductId], [Quantity], [AddedAt]) VALUES (14, 1, 3, 5, CAST(N'2025-05-26T19:03:01.260' AS DateTime))
SET IDENTITY_INSERT [dbo].[CartItems] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [Name], [Description]) VALUES (1, N'Sữa rửa mặt', N'Giúp làm sạch bụi bẩn, dầu thừa và tế bào chết')
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description]) VALUES (2, N'Toner', N'Cân bằng độ pH và cấp ẩm sau khi rửa mặt')
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description]) VALUES (3, N'Kem dưỡng', N'Khóa ẩm và nuôi dưỡng da mềm mịn')
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description]) VALUES (4, N'Sữa rửa mặt', N'Các loại sữa rửa mặt phù hợp cho da nam giới')
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description]) VALUES (5, N'Kem dưỡng da', N'Kem dưỡng da chống lão hóa và làm mềm da cho nam giới')
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description]) VALUES (6, N'Toner', N'Nước cân bằng da giúp se khít lỗ chân lông')
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description]) VALUES (7, N'Serum', N'Tinh chất dưỡng da đặc trị cho nam giới')
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description]) VALUES (8, N'Mặt nạ', N'Mặt nạ chăm sóc da giúp da sáng khỏe')
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description]) VALUES (9, N'Tẩy tế bào chết', N'Sản phẩm tẩy tế bào chết nhẹ nhàng, làm sạch sâu')
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description]) VALUES (10, N'Chống nắng', N'Sản phẩm chống nắng bảo vệ da khỏi tia UV')
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description]) VALUES (11, N'Sản phẩm trị mụn', N'Sản phẩm đặc trị mụn cho da nam')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[EmailVerifications] ON 

INSERT [dbo].[EmailVerifications] ([Id], [Email], [Username], [PasswordHash], [FullName], [OtpCode], [CreatedAt], [ExpiredAt], [Gender], [DateOfBirth]) VALUES (3, N'manhlche176152@fpt.edu.vn', N'manh2', N'$2a$11$ovLc8nhin8EJihCoHZamGOTa.Ut4KmlJvp95f6WWEhPfHcRBoq36m', N'Lê Chí Mạnh', N'139775', CAST(N'2025-05-25T20:05:51.707' AS DateTime), CAST(N'2025-05-25T20:15:51.707' AS DateTime), N'MMale', CAST(N'2003-06-26' AS Date))
INSERT [dbo].[EmailVerifications] ([Id], [Email], [Username], [PasswordHash], [FullName], [OtpCode], [CreatedAt], [ExpiredAt], [Gender], [DateOfBirth]) VALUES (4, N'manhlche176152@fpt.edu.vn', N'manh2', N'$2a$11$DOVprH/8BCyKjUersc16gOsC9ktZoozDtaUsWmzmCamdszqEzHWMK', N'Lê Chí Mạnh', N'937807', CAST(N'2025-05-25T20:05:54.287' AS DateTime), CAST(N'2025-05-25T20:15:54.287' AS DateTime), N'MMale', CAST(N'2003-06-26' AS Date))
INSERT [dbo].[EmailVerifications] ([Id], [Email], [Username], [PasswordHash], [FullName], [OtpCode], [CreatedAt], [ExpiredAt], [Gender], [DateOfBirth]) VALUES (5, N'manhlche176152@fpt.edu.vn', N'manh2', N'$2a$11$XiyVBjS9okAHoZK53Y51Y.16irsObjkmk3V1Ff7ifl9KrrEl7Pqgi', N'Lê Chí Mạnh', N'916756', CAST(N'2025-05-25T20:05:54.837' AS DateTime), CAST(N'2025-05-25T20:15:54.837' AS DateTime), N'MMale', CAST(N'2003-06-26' AS Date))
SET IDENTITY_INSERT [dbo].[EmailVerifications] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 

INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (1, 1, 1, 2, CAST(125000.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (2, 1, 2, 1, CAST(95000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderId], [UserId], [OrderDate], [TotalAmount], [Status], [ShippingAddress]) VALUES (1, 1, CAST(N'2025-05-24T22:39:34.620' AS DateTime), CAST(345000.00 AS Decimal(18, 2)), N'Pending', N'123 Đường Lê Lợi, Quận 1, TP.HCM')
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Payments] ON 

INSERT [dbo].[Payments] ([PaymentId], [OrderId], [PaymentDate], [Amount], [PaymentMethod], [PaymentStatus]) VALUES (1, 1, CAST(N'2025-05-24T22:39:34.623' AS DateTime), CAST(345000.00 AS Decimal(18, 2)), N'Momo', N'Đã thanh toán')
SET IDENTITY_INSERT [dbo].[Payments] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductReviews] ON 

INSERT [dbo].[ProductReviews] ([ReviewId], [ProductId], [UserId], [Rating], [Comment], [ReviewDate]) VALUES (1, 1, 1, 5, N'Sữa rửa mặt rất mát, dùng xong da sạch mà không khô!', CAST(N'2025-05-24T22:39:34.623' AS DateTime))
SET IDENTITY_INSERT [dbo].[ProductReviews] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Quantity], [CategoryId], [BrandId], [ImageUrl], [CreatedAt], [GenderTarget], [AffiliateLink]) VALUES (1, N'Sữa rửa mặt Hada Labo cho nam', N'Làm sạch sâu nhưng vẫn dịu nhẹ với da nam giới.', CAST(125000.00 AS Decimal(18, 2)), 100, 1, 1, N'https://img.tripi.vn/cdn-cgi/image/width=700,height=700/https://gcs.tripi.vn/public-tripi/tripi-feed/img/473633OAR/combo-trang-da-cho-nam-nerman-perfect-whitening-1032892.jpg', CAST(N'2025-05-24T22:39:34.620' AS DateTime), N'Male', NULL)
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Quantity], [CategoryId], [BrandId], [ImageUrl], [CreatedAt], [GenderTarget], [AffiliateLink]) VALUES (2, N'Toner Nivea Men', N'Cân bằng da, giảm dầu nhờn hiệu quả.', CAST(95000.00 AS Decimal(18, 2)), 50, 2, 2, N'https://img.tripi.vn/cdn-cgi/image/width=700,height=700/https://gcs.tripi.vn/public-tripi/tripi-feed/img/473633OAR/combo-trang-da-cho-nam-nerman-perfect-whitening-1032892.jpg', CAST(N'2025-05-24T22:39:34.620' AS DateTime), N'Male', NULL)
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Quantity], [CategoryId], [BrandId], [ImageUrl], [CreatedAt], [GenderTarget], [AffiliateLink]) VALUES (3, N'Kem dưỡng L’Oreal Expert', N'Dưỡng ẩm và phục hồi da sau cạo râu.', CAST(185000.00 AS Decimal(18, 2)), 70, 3, 3, N'https://img.tripi.vn/cdn-cgi/image/width=700,height=700/https://gcs.tripi.vn/public-tripi/tripi-feed/img/473633OAR/combo-trang-da-cho-nam-nerman-perfect-whitening-1032892.jpg', CAST(N'2025-05-24T22:39:34.620' AS DateTime), N'Male', NULL)
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Quantity], [CategoryId], [BrandId], [ImageUrl], [CreatedAt], [GenderTarget], [AffiliateLink]) VALUES (4, N'Sữa rửa mặt', N'Sữa rửa mặt dịu nhẹ', CAST(150000.00 AS Decimal(18, 2)), 100, 1, 1, N'https://img.tripi.vn/cdn-cgi/image/width=700,height=700/https://gcs.tripi.vn/public-tripi/tripi-feed/img/473633OAR/combo-trang-da-cho-nam-nerman-perfect-whitening-1032892.jpg', CAST(N'2025-05-26T09:43:42.820' AS DateTime), N'Female', NULL)
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Quantity], [CategoryId], [BrandId], [ImageUrl], [CreatedAt], [GenderTarget], [AffiliateLink]) VALUES (5, N'Kem dưỡng da', N'Kem dưỡng da ban ngày', CAST(250000.00 AS Decimal(18, 2)), 50, 2, 2, N'https://img.tripi.vn/cdn-cgi/image/width=700,height=700/https://gcs.tripi.vn/public-tripi/tripi-feed/img/473633OAR/combo-trang-da-cho-nam-nerman-perfect-whitening-1032892.jpg', CAST(N'2025-05-26T09:43:42.820' AS DateTime), N'Male', NULL)
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Quantity], [CategoryId], [BrandId], [ImageUrl], [CreatedAt], [GenderTarget], [AffiliateLink]) VALUES (6, N'Serum chống lão hóa', N'Serum đặc trị lão hóa', CAST(300000.00 AS Decimal(18, 2)), 30, 2, 3, N'https://img.tripi.vn/cdn-cgi/image/width=700,height=700/https://gcs.tripi.vn/public-tripi/tripi-feed/img/473633OAR/combo-trang-da-cho-nam-nerman-perfect-whitening-1032892.jpg', CAST(N'2025-05-26T09:43:42.820' AS DateTime), N'Unisex', NULL)
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Quantity], [CategoryId], [BrandId], [ImageUrl], [CreatedAt], [GenderTarget], [AffiliateLink]) VALUES (7, N'Sữa rửa mặt', N'Sữa rửa mặt dịu nhẹ', CAST(150000.00 AS Decimal(18, 2)), 100, 1, 1, N'https://img.tripi.vn/cdn-cgi/image/width=700,height=700/https://gcs.tripi.vn/public-tripi/tripi-feed/img/473633OAR/combo-trang-da-cho-nam-nerman-perfect-whitening-1032892.jpg', CAST(N'2025-05-26T09:44:10.313' AS DateTime), N'Female', NULL)
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Quantity], [CategoryId], [BrandId], [ImageUrl], [CreatedAt], [GenderTarget], [AffiliateLink]) VALUES (8, N'Kem dưỡng da', N'Kem dưỡng da ban ngày', CAST(250000.00 AS Decimal(18, 2)), 50, 2, 2, N'https://img.tripi.vn/cdn-cgi/image/width=700,height=700/https://gcs.tripi.vn/public-tripi/tripi-feed/img/473633OAR/combo-trang-da-cho-nam-nerman-perfect-whitening-1032892.jpg', CAST(N'2025-05-26T09:44:10.313' AS DateTime), N'Male', NULL)
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Quantity], [CategoryId], [BrandId], [ImageUrl], [CreatedAt], [GenderTarget], [AffiliateLink]) VALUES (9, N'Serum chống lão hóa', N'Serum đặc trị lão hóa', CAST(300000.00 AS Decimal(18, 2)), 30, 2, 3, N'https://img.tripi.vn/cdn-cgi/image/width=700,height=700/https://gcs.tripi.vn/public-tripi/tripi-feed/img/473633OAR/combo-trang-da-cho-nam-nerman-perfect-whitening-1032892.jpg', CAST(N'2025-05-26T09:44:10.313' AS DateTime), N'Unisex', NULL)
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Quantity], [CategoryId], [BrandId], [ImageUrl], [CreatedAt], [GenderTarget], [AffiliateLink]) VALUES (10, N'Sữa rửa mặt', N'Sữa rửa mặt dịu nhẹ', CAST(150000.00 AS Decimal(18, 2)), 100, 1, 1, N'https://img.tripi.vn/cdn-cgi/image/width=700,height=700/https://gcs.tripi.vn/public-tripi/tripi-feed/img/473633OAR/combo-trang-da-cho-nam-nerman-perfect-whitening-1032892.jpg', CAST(N'2025-05-26T09:53:55.220' AS DateTime), N'Female', NULL)
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Quantity], [CategoryId], [BrandId], [ImageUrl], [CreatedAt], [GenderTarget], [AffiliateLink]) VALUES (11, N'Kem dưỡng da', N'Kem dưỡng da ban ngày', CAST(250000.00 AS Decimal(18, 2)), 50, 2, 2, N'https://img.tripi.vn/cdn-cgi/image/width=700,height=700/https://gcs.tripi.vn/public-tripi/tripi-feed/img/473633OAR/combo-trang-da-cho-nam-nerman-perfect-whitening-1032892.jpg', CAST(N'2025-05-26T09:53:55.220' AS DateTime), N'Male', NULL)
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Quantity], [CategoryId], [BrandId], [ImageUrl], [CreatedAt], [GenderTarget], [AffiliateLink]) VALUES (12, N'Serum chống lão hóa', N'Serum đặc trị lão hóa', CAST(300000.00 AS Decimal(18, 2)), 30, 2, 3, N'https://img.tripi.vn/cdn-cgi/image/width=700,height=700/https://gcs.tripi.vn/public-tripi/tripi-feed/img/473633OAR/combo-trang-da-cho-nam-nerman-perfect-whitening-1032892.jpg', CAST(N'2025-05-26T09:53:55.220' AS DateTime), N'Unisex', NULL)
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Quantity], [CategoryId], [BrandId], [ImageUrl], [CreatedAt], [GenderTarget], [AffiliateLink]) VALUES (42, N'Serum chống lão hóa', N'Serum đặc trị lão hóa', CAST(300000.00 AS Decimal(18, 2)), 30, 2, 3, N'https://product.hstatic.net/1000296046/product/bo_men_1200x1200_c6954c62743141d19b4572d3b4751958_master.png', CAST(N'2025-05-26T12:30:46.310' AS DateTime), N'Unisex', NULL)
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Quantity], [CategoryId], [BrandId], [ImageUrl], [CreatedAt], [GenderTarget], [AffiliateLink]) VALUES (43, N'Sữa rửa mặt', N'Sữa rửa mặt dịu nhẹ', CAST(150000.00 AS Decimal(18, 2)), 100, 1, 1, N'https://product.hstatic.net/1000296046/product/bo_men_1200x1200_c6954c62743141d19b4572d3b4751958_master.png', CAST(N'2025-05-26T13:26:09.300' AS DateTime), N'Female', N'https://product.hstatic.net/1000296046/product/bo_men_1200x1200_c6954c62743141d19b4572d3b4751958_master.png')
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Quantity], [CategoryId], [BrandId], [ImageUrl], [CreatedAt], [GenderTarget], [AffiliateLink]) VALUES (46, N'Sữa rửa mặt', N'Sữa rửa mặt dịu nhẹ', CAST(150000.00 AS Decimal(18, 2)), 100, 1, 1, N'https://product.hstatic.net/1000296046/product/bo_men_1200x1200_c6954c62743141d19b4572d3b4751958_master.png', CAST(N'2025-05-26T14:49:53.820' AS DateTime), N'Female', N'https://product.hstatic.net/1000296046/product/bo_men_1200x1200_c6954c62743141d19b4572d3b4751958_master.png')
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Quantity], [CategoryId], [BrandId], [ImageUrl], [CreatedAt], [GenderTarget], [AffiliateLink]) VALUES (47, N'Kem dưỡng da', N'Kem dưỡng da ban ngày', CAST(250000.00 AS Decimal(18, 2)), 50, 2, 2, N'https://product.hstatic.net/1000296046/product/bo_men_1200x1200_c6954c62743141d19b4572d3b4751958_master.png', CAST(N'2025-05-26T14:49:53.820' AS DateTime), N'Unisex', N'https://product.hstatic.net/1000296046/product/bo_men_1200x1200_c6954c62743141d19b4572d3b4751958_master.png')
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Quantity], [CategoryId], [BrandId], [ImageUrl], [CreatedAt], [GenderTarget], [AffiliateLink]) VALUES (48, N'Serum chống lão hóa', N'Serum đặc trị lão hóa', CAST(300000.00 AS Decimal(18, 2)), 30, 2, 3, N'https://product.hstatic.net/1000296046/product/bo_men_1200x1200_c6954c62743141d19b4572d3b4751958_master.png', CAST(N'2025-05-26T14:49:53.820' AS DateTime), N'Male', N'https://product.hstatic.net/1000296046/product/bo_men_1200x1200_c6954c62743141d19b4572d3b4751958_master.png')
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Quantity], [CategoryId], [BrandId], [ImageUrl], [CreatedAt], [GenderTarget], [AffiliateLink]) VALUES (49, N'Kem dưỡng da', N'Kem dưỡng da ban ngày', CAST(250000.00 AS Decimal(18, 2)), 500, 2, 2, N'https://product.hstatic.net/1000296046/product/bo_men_1200x1200_c6954c62743141d19b4572d3b4751958_master.png', CAST(N'2025-05-26T22:47:17.243' AS DateTime), N'Female', N'https://product.hstatic.net/1000296046/product/bo_men_1200x1200_c6954c62743141d19b4572d3b4751958_master.png')
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (3, N'Customer')
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (4, N'Guest')
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (2, N'Staff')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[SkinAnalyses] ON 

INSERT [dbo].[SkinAnalyses] ([AnalysisId], [UserId], [AnalysisDate], [SkinType], [BrightnessLevel], [AcneLevel], [TextureScore], [PoresVisibility], [DarkSpotsLevel], [AnalysisResult]) VALUES (1, 1, CAST(N'2025-05-24T22:39:34.623' AS DateTime), N'Dầu', 4, 6, 5, 7, 3, N'Da có nhiều dầu vùng chữ T, lỗ chân lông to và có mụn ẩn nhẹ.')
SET IDENTITY_INSERT [dbo].[SkinAnalyses] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [UserName], [Email], [PasswordHash], [FullName], [Gender], [DateOfBirth], [CreatedAt], [IsVerified], [RoleId]) VALUES (1, N'manh2606', N'lechimanhmanh@gmail.com', N'$2a$11$V/N3N.HHsdqAL9wjhk0XIubhxFIlQW4L/LJQjrqhrLboGrcH/rLTm', N'Lê Mạnh', N'Male', CAST(N'2003-06-26' AS Date), CAST(N'2025-05-24T15:27:11.920' AS DateTime), 0, 1)
INSERT [dbo].[Users] ([UserId], [UserName], [Email], [PasswordHash], [FullName], [Gender], [DateOfBirth], [CreatedAt], [IsVerified], [RoleId]) VALUES (2, N'manh260603', N'lemanh26062003@gmail.com', N'$2a$11$b2GVczCeYhJZC6/dO6ySpO121LisD1o7KfnTVdi6GfPcW25KTeLkm', N'Lê Mạnh', N'Male', CAST(N'2003-06-26' AS Date), CAST(N'2025-05-24T16:03:20.223' AS DateTime), 0, 2)
INSERT [dbo].[Users] ([UserId], [UserName], [Email], [PasswordHash], [FullName], [Gender], [DateOfBirth], [CreatedAt], [IsVerified], [RoleId]) VALUES (9, N'manh3', N'chimanh2606@gmail.com', N'$2a$11$oZLGll40VMQ5j8eKc7kwI..loIWQJUQkA0iwNq50LmrAXqoEI5YkG', N'Lê Chí Mạnh', N'MMale', CAST(N'2003-06-26' AS Date), CAST(N'2025-05-25T20:20:30.067' AS DateTime), 1, 3)
INSERT [dbo].[Users] ([UserId], [UserName], [Email], [PasswordHash], [FullName], [Gender], [DateOfBirth], [CreatedAt], [IsVerified], [RoleId]) VALUES (12, N'manh@', N'chimanh26062003@gmail.com', N'$2a$11$FCN6ZpzXaIBXM0t1eE56MeeHHUs5wkgbJJy0T8zsOWlXStU632R/2', N'Lê Mạnh', N'Male', CAST(N'2003-06-26' AS Date), CAST(N'2025-05-26T08:46:15.260' AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Roles__8A2B61603CB577CB]    Script Date: 05/27/2025 02:04:10 ******/
ALTER TABLE [dbo].[Roles] ADD UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__A9D105340789A9D1]    Script Date: 05/27/2025 02:04:10 ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__C9F28456B956277B]    Script Date: 05/27/2025 02:04:10 ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CartItems] ADD  DEFAULT (getdate()) FOR [AddedAt]
GO
ALTER TABLE [dbo].[EmailVerifications] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (getdate()) FOR [OrderDate]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ('Pending') FOR [Status]
GO
ALTER TABLE [dbo].[Payments] ADD  DEFAULT (getdate()) FOR [PaymentDate]
GO
ALTER TABLE [dbo].[ProductReviews] ADD  DEFAULT (getdate()) FOR [ReviewDate]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ('Male') FOR [GenderTarget]
GO
ALTER TABLE [dbo].[SkinAnalyses] ADD  DEFAULT (getdate()) FOR [AnalysisDate]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0)) FOR [IsVerified]
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[ProductReviews]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[ProductReviews]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brands] ([BrandId])
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[SkinAnalyses]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD CHECK  (([Quantity]>(0)))
GO
ALTER TABLE [dbo].[ProductReviews]  WITH CHECK ADD CHECK  (([Rating]>=(1) AND [Rating]<=(5)))
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD CHECK  (([Quantity]>=(0)))
GO
ALTER TABLE [dbo].[SkinAnalyses]  WITH CHECK ADD CHECK  (([AcneLevel]>=(0) AND [AcneLevel]<=(10)))
GO
ALTER TABLE [dbo].[SkinAnalyses]  WITH CHECK ADD CHECK  (([BrightnessLevel]>=(1) AND [BrightnessLevel]<=(10)))
GO
ALTER TABLE [dbo].[SkinAnalyses]  WITH CHECK ADD CHECK  (([DarkSpotsLevel]>=(0) AND [DarkSpotsLevel]<=(10)))
GO
ALTER TABLE [dbo].[SkinAnalyses]  WITH CHECK ADD CHECK  (([PoresVisibility]>=(1) AND [PoresVisibility]<=(10)))
GO
ALTER TABLE [dbo].[SkinAnalyses]  WITH CHECK ADD CHECK  (([TextureScore]>=(1) AND [TextureScore]<=(10)))
GO
USE [master]
GO
ALTER DATABASE [SkincareShopForMen] SET  READ_WRITE 
GO
