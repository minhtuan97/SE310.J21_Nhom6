USE [QLHS]
GO
/****** Object:  Table [dbo].[HocSinh]    Script Date: 2/28/2019 2:01:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocSinh](
	[MaSo] [nvarchar](10) NOT NULL,
	[Ten] [nvarchar](50) NULL,
	[NamSinh] [int] NULL,
	[MaLop] [nvarchar](10) NULL,
 CONSTRAINT [PK_HocSinh] PRIMARY KEY CLUSTERED 
(
	[MaSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[HocSinh] ([MaSo], [Ten], [NamSinh], [MaLop]) VALUES (N'123', N'Nguyễn Văn A', 1995, N'A111')
INSERT [dbo].[HocSinh] ([MaSo], [Ten], [NamSinh], [MaLop]) VALUES (N'124', N'Trần Thị B', 1993, N'A113')
INSERT [dbo].[HocSinh] ([MaSo], [Ten], [NamSinh], [MaLop]) VALUES (N'125', N'Huỳnh Thu C', 1995, N'A111')
INSERT [dbo].[HocSinh] ([MaSo], [Ten], [NamSinh], [MaLop]) VALUES (N'126', N'Hoàng Nam', 1997, N'A114')
