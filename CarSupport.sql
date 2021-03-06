USE [CuuHoXeV3]
GO
/****** Object:  Table [dbo].[ChiTietSuDungDV]    Script Date: 5/18/2022 2:20:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietSuDungDV](
	[IdSDDV] [int] NOT NULL,
	[IdDV] [int] NOT NULL,
	[GiaDV] [decimal](18, 0) NULL,
	[SoLuongDV] [int] NULL,
 CONSTRAINT [PK__ChiTietS__F489A63850FBBE98] PRIMARY KEY CLUSTERED 
(
	[IdSDDV] ASC,
	[IdDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CoSoDichVu]    Script Date: 5/18/2022 2:20:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoSoDichVu](
	[IdNCC] [int] IDENTITY(1,1) NOT NULL,
	[TenNCC] [nvarchar](50) NOT NULL,
	[TenTK] [varchar](20) NOT NULL,
	[DiaChi] [nvarchar](250) NULL,
	[NgayDangKi] [smalldatetime] NULL,
	[ImageNCC] [nchar](100) NULL,
 CONSTRAINT [PK__CoSoDich__0DD24973ABFFCD64] PRIMARY KEY CLUSTERED 
(
	[IdNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DichVu]    Script Date: 5/18/2022 2:20:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DichVu](
	[IdDV] [int] IDENTITY(1,1) NOT NULL,
	[TenDichVu] [nvarchar](255) NOT NULL,
	[GiaDV] [decimal](18, 0) NOT NULL,
	[MoTa] [nvarchar](255) NULL,
	[IdNCC] [int] NULL,
	[ImageDV] [nchar](50) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiayPhepCSDV]    Script Date: 5/18/2022 2:20:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiayPhepCSDV](
	[IdAnh] [int] IDENTITY(1,1) NOT NULL,
	[HinhAnh] [nvarchar](50) NULL,
	[IdNCC] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAnh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HinhAnhDV]    Script Date: 5/18/2022 2:20:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HinhAnhDV](
	[IdAnh] [int] IDENTITY(1,1) NOT NULL,
	[HinhAnh] [nvarchar](50) NULL,
	[IdDV] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAnh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LePhi]    Script Date: 5/18/2022 2:20:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LePhi](
	[IdLP] [int] IDENTITY(1,1) NOT NULL,
	[IdNCC] [int] NULL,
	[ThoiGianNop] [date] NULL,
	[TrangThai] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdLP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SuDungDichVu]    Script Date: 5/18/2022 2:20:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SuDungDichVu](
	[IdSDDV] [int] IDENTITY(1,1) NOT NULL,
	[TenTK] [varchar](20) NOT NULL,
	[ThoiGianDat] [date] NULL,
	[IdNCC] [int] NULL,
	[DiaChiDat] [varchar](20) NULL,
	[MoTa] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdSDDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 5/18/2022 2:20:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenTK] [varchar](20) NOT NULL,
	[MatKhau] [varchar](20) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[SoDienThoai] [varchar](12) NULL,
	[Email] [varchar](50) NULL,
	[XacNhanMK] [varchar](20) NOT NULL,
	[DiaChi] [varchar](20) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK__TaiKhoan__4CF9E776DBD91C7E] PRIMARY KEY CLUSTERED 
(
	[TenTK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChiTietSuDungDV] ([IdSDDV], [IdDV], [GiaDV], [SoLuongDV]) VALUES (12, 2, CAST(100000 AS Decimal(18, 0)), 1)
INSERT [dbo].[ChiTietSuDungDV] ([IdSDDV], [IdDV], [GiaDV], [SoLuongDV]) VALUES (13, 2, CAST(100000 AS Decimal(18, 0)), 5)
INSERT [dbo].[ChiTietSuDungDV] ([IdSDDV], [IdDV], [GiaDV], [SoLuongDV]) VALUES (13, 4, CAST(1000000 AS Decimal(18, 0)), 1)
INSERT [dbo].[ChiTietSuDungDV] ([IdSDDV], [IdDV], [GiaDV], [SoLuongDV]) VALUES (14, 1, CAST(241000 AS Decimal(18, 0)), 1)
INSERT [dbo].[ChiTietSuDungDV] ([IdSDDV], [IdDV], [GiaDV], [SoLuongDV]) VALUES (14, 2, CAST(100000 AS Decimal(18, 0)), 3)
INSERT [dbo].[ChiTietSuDungDV] ([IdSDDV], [IdDV], [GiaDV], [SoLuongDV]) VALUES (14, 6, CAST(20000 AS Decimal(18, 0)), 1)
GO
SET IDENTITY_INSERT [dbo].[CoSoDichVu] ON 

INSERT [dbo].[CoSoDichVu] ([IdNCC], [TenNCC], [TenTK], [DiaChi], [NgayDangKi], [ImageNCC]) VALUES (1, N'Gara oto Thành Đạt', N'admin', N'48 Cao Thắng', CAST(N'2021-04-23T12:00:00' AS SmallDateTime), N'gara1.jpg                                                                                           ')
INSERT [dbo].[CoSoDichVu] ([IdNCC], [TenNCC], [TenTK], [DiaChi], [NgayDangKi], [ImageNCC]) VALUES (2, N'Gara oto Võ Thắng', N'ctv1', N'82 Lê Duẩn', CAST(N'2020-12-15T12:00:00' AS SmallDateTime), N'gara1.jpg                                                                                           ')
INSERT [dbo].[CoSoDichVu] ([IdNCC], [TenNCC], [TenTK], [DiaChi], [NgayDangKi], [ImageNCC]) VALUES (3, N'Gara oto Văn Thắng', N'ctv2', N'24 Nguyễn Lương Bằng', CAST(N'2021-05-24T12:00:00' AS SmallDateTime), N'gara1.jpg                                                                                           ')
SET IDENTITY_INSERT [dbo].[CoSoDichVu] OFF
GO
SET IDENTITY_INSERT [dbo].[DichVu] ON 

INSERT [dbo].[DichVu] ([IdDV], [TenDichVu], [GiaDV], [MoTa], [IdNCC], [ImageDV], [Status]) VALUES (1, N'Vá lốp xe trước', CAST(241000 AS Decimal(18, 0)), N'Vá lốp xe trước', 1, N'pro1.jpg                                          ', 1)
INSERT [dbo].[DichVu] ([IdDV], [TenDichVu], [GiaDV], [MoTa], [IdNCC], [ImageDV], [Status]) VALUES (2, N'Vá lốp xe sau', CAST(100000 AS Decimal(18, 0)), N'Vá lốp xe sau', 3, N'pro2.jpg                                          ', 1)
INSERT [dbo].[DichVu] ([IdDV], [TenDichVu], [GiaDV], [MoTa], [IdNCC], [ImageDV], [Status]) VALUES (4, N'Thay acquy', CAST(1000000 AS Decimal(18, 0)), N'Thay acquy xe', 3, N'gara1.jpg                                         ', 1)
INSERT [dbo].[DichVu] ([IdDV], [TenDichVu], [GiaDV], [MoTa], [IdNCC], [ImageDV], [Status]) VALUES (6, N'Vá lốp xe sau', CAST(20000 AS Decimal(18, 0)), N'Vá lốp xe sau', 2, N'pro2.jpg                                          ', 1)
INSERT [dbo].[DichVu] ([IdDV], [TenDichVu], [GiaDV], [MoTa], [IdNCC], [ImageDV], [Status]) VALUES (12, N'Cafe', CAST(123123 AS Decimal(18, 0)), N'Lốp xe9', 3, N'pro12.jpg                                         ', 1)
INSERT [dbo].[DichVu] ([IdDV], [TenDichVu], [GiaDV], [MoTa], [IdNCC], [ImageDV], [Status]) VALUES (14, N'Revive', CAST(1233 AS Decimal(18, 0)), N'12313', 1, N'pro14.jpg                                         ', 1)
INSERT [dbo].[DichVu] ([IdDV], [TenDichVu], [GiaDV], [MoTa], [IdNCC], [ImageDV], [Status]) VALUES (15, N'number1', CAST(200000 AS Decimal(18, 0)), N'abc', 3, N'pro15.jpg                                         ', NULL)
INSERT [dbo].[DichVu] ([IdDV], [TenDichVu], [GiaDV], [MoTa], [IdNCC], [ImageDV], [Status]) VALUES (16, N'tttttt', CAST(11111111 AS Decimal(18, 0)), N'1111111', 1, N'pro16.jpg                                         ', NULL)
SET IDENTITY_INSERT [dbo].[DichVu] OFF
GO
SET IDENTITY_INSERT [dbo].[GiayPhepCSDV] ON 

INSERT [dbo].[GiayPhepCSDV] ([IdAnh], [HinhAnh], [IdNCC]) VALUES (1, N'Giấy đăng kí kinh doanh', 1)
INSERT [dbo].[GiayPhepCSDV] ([IdAnh], [HinhAnh], [IdNCC]) VALUES (2, N'Giấy đăng kí kinh doanh', 2)
INSERT [dbo].[GiayPhepCSDV] ([IdAnh], [HinhAnh], [IdNCC]) VALUES (3, N'Giấy đăng kí kinh doanh', 3)
SET IDENTITY_INSERT [dbo].[GiayPhepCSDV] OFF
GO
SET IDENTITY_INSERT [dbo].[LePhi] ON 

INSERT [dbo].[LePhi] ([IdLP], [IdNCC], [ThoiGianNop], [TrangThai]) VALUES (1, 1, NULL, 1)
INSERT [dbo].[LePhi] ([IdLP], [IdNCC], [ThoiGianNop], [TrangThai]) VALUES (2, 2, NULL, 0)
INSERT [dbo].[LePhi] ([IdLP], [IdNCC], [ThoiGianNop], [TrangThai]) VALUES (3, 3, NULL, 1)
SET IDENTITY_INSERT [dbo].[LePhi] OFF
GO
SET IDENTITY_INSERT [dbo].[SuDungDichVu] ON 

INSERT [dbo].[SuDungDichVu] ([IdSDDV], [TenTK], [ThoiGianDat], [IdNCC], [DiaChiDat], [MoTa]) VALUES (12, N'gr3', CAST(N'2022-05-13' AS Date), NULL, NULL, N'12222231')
INSERT [dbo].[SuDungDichVu] ([IdSDDV], [TenTK], [ThoiGianDat], [IdNCC], [DiaChiDat], [MoTa]) VALUES (13, N'gr3', CAST(N'2022-05-13' AS Date), NULL, N'DA NANG', N'DA NANG')
INSERT [dbo].[SuDungDichVu] ([IdSDDV], [TenTK], [ThoiGianDat], [IdNCC], [DiaChiDat], [MoTa]) VALUES (14, N'gr3', CAST(N'2022-05-13' AS Date), NULL, N'DA NANG', N'abc')
SET IDENTITY_INSERT [dbo].[SuDungDichVu] OFF
GO
SET IDENTITY_INSERT [dbo].[TaiKhoan] ON 

INSERT [dbo].[TaiKhoan] ([Id], [TenTK], [MatKhau], [HoTen], [NgaySinh], [SoDienThoai], [Email], [XacNhanMK], [DiaChi], [Status]) VALUES (2, N'admin', N'123456', N'Quản trị viên', CAST(N'2000-04-02' AS Date), N'0344976831', N'admin@gmail.com', N'123456', N'DN', 0)
INSERT [dbo].[TaiKhoan] ([Id], [TenTK], [MatKhau], [HoTen], [NgaySinh], [SoDienThoai], [Email], [XacNhanMK], [DiaChi], [Status]) VALUES (3, N'ctv1', N'123456', N'Cộng tác viên 1', CAST(N'2000-12-15' AS Date), N'0329134582', N'ctv1@gmail.com', N'123456', N'DN', 0)
INSERT [dbo].[TaiKhoan] ([Id], [TenTK], [MatKhau], [HoTen], [NgaySinh], [SoDienThoai], [Email], [XacNhanMK], [DiaChi], [Status]) VALUES (4, N'ctv2', N'1234567', N'Nguyễn Văn Thắng', CAST(N'2001-12-13' AS Date), N'0344787811', N'tthang@gmail.com', N'1234567', N'48 Cao Thang', 0)
INSERT [dbo].[TaiKhoan] ([Id], [TenTK], [MatKhau], [HoTen], [NgaySinh], [SoDienThoai], [Email], [XacNhanMK], [DiaChi], [Status]) VALUES (5, N'gr1', N'123456', N'Cộng tác viên 2', CAST(N'1978-04-22' AS Date), N'0346982527', N'ctv2@gmail.com', N'123456', N'DN', 0)
INSERT [dbo].[TaiKhoan] ([Id], [TenTK], [MatKhau], [HoTen], [NgaySinh], [SoDienThoai], [Email], [XacNhanMK], [DiaChi], [Status]) VALUES (6, N'gr2', N'123456', N'Nguyễn Văn Thắng', CAST(N'1978-08-14' AS Date), N'0982172577', N'thanhdat@gmail.com', N'123456', N'DN', 0)
INSERT [dbo].[TaiKhoan] ([Id], [TenTK], [MatKhau], [HoTen], [NgaySinh], [SoDienThoai], [Email], [XacNhanMK], [DiaChi], [Status]) VALUES (7, N'gr3', N'1234567', N'Nguyễn Văn Thắng', CAST(N'2001-02-14' AS Date), N'0344787811', N'vthang@gmail.com', N'1234567', N'DN', 0)
INSERT [dbo].[TaiKhoan] ([Id], [TenTK], [MatKhau], [HoTen], [NgaySinh], [SoDienThoai], [Email], [XacNhanMK], [DiaChi], [Status]) VALUES (32, N'ttt', N'123456', N'thang123', CAST(N'2022-06-06' AS Date), N'11123555', N'admi3n@gmail.com', N'123456', N'Quang Binh', NULL)
SET IDENTITY_INSERT [dbo].[TaiKhoan] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__TaiKhoan__A9D10534619590C4]    Script Date: 5/18/2022 2:20:20 PM ******/
ALTER TABLE [dbo].[TaiKhoan] ADD  CONSTRAINT [UQ__TaiKhoan__A9D10534619590C4] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CoSoDichVu] ADD  CONSTRAINT [DF__CoSoDichV__NgayD__29572725]  DEFAULT (getdate()) FOR [NgayDangKi]
GO
ALTER TABLE [dbo].[ChiTietSuDungDV]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietSu__IdSDD__32E0915F] FOREIGN KEY([IdSDDV])
REFERENCES [dbo].[SuDungDichVu] ([IdSDDV])
GO
ALTER TABLE [dbo].[ChiTietSuDungDV] CHECK CONSTRAINT [FK__ChiTietSu__IdSDD__32E0915F]
GO
ALTER TABLE [dbo].[ChiTietSuDungDV]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietSuD__IdDV__33D4B598] FOREIGN KEY([IdDV])
REFERENCES [dbo].[DichVu] ([IdDV])
GO
ALTER TABLE [dbo].[ChiTietSuDungDV] CHECK CONSTRAINT [FK__ChiTietSuD__IdDV__33D4B598]
GO
ALTER TABLE [dbo].[CoSoDichVu]  WITH CHECK ADD  CONSTRAINT [FK__CoSoDichV__TenTK__286302EC] FOREIGN KEY([TenTK])
REFERENCES [dbo].[TaiKhoan] ([TenTK])
GO
ALTER TABLE [dbo].[CoSoDichVu] CHECK CONSTRAINT [FK__CoSoDichV__TenTK__286302EC]
GO
ALTER TABLE [dbo].[DichVu]  WITH CHECK ADD  CONSTRAINT [FK__DichVu__IdNCC__2C3393D0] FOREIGN KEY([IdNCC])
REFERENCES [dbo].[CoSoDichVu] ([IdNCC])
GO
ALTER TABLE [dbo].[DichVu] CHECK CONSTRAINT [FK__DichVu__IdNCC__2C3393D0]
GO
ALTER TABLE [dbo].[GiayPhepCSDV]  WITH CHECK ADD  CONSTRAINT [FK__GiayPhepC__IdNCC__398D8EEE] FOREIGN KEY([IdNCC])
REFERENCES [dbo].[CoSoDichVu] ([IdNCC])
GO
ALTER TABLE [dbo].[GiayPhepCSDV] CHECK CONSTRAINT [FK__GiayPhepC__IdNCC__398D8EEE]
GO
ALTER TABLE [dbo].[HinhAnhDV]  WITH CHECK ADD FOREIGN KEY([IdDV])
REFERENCES [dbo].[DichVu] ([IdDV])
GO
ALTER TABLE [dbo].[LePhi]  WITH CHECK ADD  CONSTRAINT [FK__LePhi__IdNCC__36B12243] FOREIGN KEY([IdNCC])
REFERENCES [dbo].[CoSoDichVu] ([IdNCC])
GO
ALTER TABLE [dbo].[LePhi] CHECK CONSTRAINT [FK__LePhi__IdNCC__36B12243]
GO
ALTER TABLE [dbo].[SuDungDichVu]  WITH CHECK ADD  CONSTRAINT [FK__SuDungDic__IdNCC__300424B4] FOREIGN KEY([IdNCC])
REFERENCES [dbo].[CoSoDichVu] ([IdNCC])
GO
ALTER TABLE [dbo].[SuDungDichVu] CHECK CONSTRAINT [FK__SuDungDic__IdNCC__300424B4]
GO
ALTER TABLE [dbo].[SuDungDichVu]  WITH CHECK ADD  CONSTRAINT [FK__SuDungDic__TenTK__2F10007B] FOREIGN KEY([TenTK])
REFERENCES [dbo].[TaiKhoan] ([TenTK])
GO
ALTER TABLE [dbo].[SuDungDichVu] CHECK CONSTRAINT [FK__SuDungDic__TenTK__2F10007B]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [CK__TaiKhoan__Email__25869641] CHECK  (([Email] like '[A-Za-z]%@gmail.com'))
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [CK__TaiKhoan__Email__25869641]
GO
