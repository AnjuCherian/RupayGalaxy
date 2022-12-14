USE [Banking]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 02/23/2019 12:58:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Login](
	[LoginID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NULL,
	[Username] [varchar](100) NULL,
	[Password] [varchar](100) NULL,
	[Isdeleted] [bit] NULL,
	[CreatedOn] [date] NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[LoginID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Login] ON
INSERT [dbo].[Login] ([LoginID], [RoleID], [Username], [Password], [Isdeleted], [CreatedOn]) VALUES (1, 2, N'rahul', N'00000', 0, CAST(0x583F0B00 AS Date))
INSERT [dbo].[Login] ([LoginID], [RoleID], [Username], [Password], [Isdeleted], [CreatedOn]) VALUES (2, 1, N'Admin', N'admin', 0, CAST(0x583F0B00 AS Date))
SET IDENTITY_INSERT [dbo].[Login] OFF
/****** Object:  Table [dbo].[District]    Script Date: 02/23/2019 12:58:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[District](
	[DistrictID] [int] IDENTITY(1,1) NOT NULL,
	[DistrictName] [varchar](100) NULL,
 CONSTRAINT [PK_District] PRIMARY KEY CLUSTERED 
(
	[DistrictID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[District] ON
INSERT [dbo].[District] ([DistrictID], [DistrictName]) VALUES (1, N'Kottayam')
INSERT [dbo].[District] ([DistrictID], [DistrictName]) VALUES (2, N'Alappuza')
INSERT [dbo].[District] ([DistrictID], [DistrictName]) VALUES (3, N'Idukki')
SET IDENTITY_INSERT [dbo].[District] OFF
/****** Object:  Table [dbo].[Bank]    Script Date: 02/23/2019 12:58:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bank](
	[BankID] [int] IDENTITY(1,1) NOT NULL,
	[BankName] [varchar](100) NULL,
	[BankLocation] [varchar](100) NULL,
	[Mobile] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[Website] [varchar](100) NULL,
 CONSTRAINT [PK_Bank] PRIMARY KEY CLUSTERED 
(
	[BankID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Bank] ON
INSERT [dbo].[Bank] ([BankID], [BankName], [BankLocation], [Mobile], [Email], [Website]) VALUES (1, N'Bank1', N'location1', N'7896547821', N'bank1@gmail.com', N'www.bank1.com')
SET IDENTITY_INSERT [dbo].[Bank] OFF
/****** Object:  Table [dbo].[Registration]    Script Date: 02/23/2019 12:58:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Registration](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[LoginID] [int] NULL,
	[Name] [varchar](100) NULL,
	[Gender] [varchar](100) NULL,
	[Address] [varchar](100) NULL,
	[Mobile] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[AaadharNo] [varchar](100) NULL,
	[PAN] [varchar](100) NULL,
	[DistrictID] [int] NULL,
	[Salary] [varchar](100) NULL,
	[UserImg] [varchar](8000) NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Registration] ON
INSERT [dbo].[Registration] ([UserID], [LoginID], [Name], [Gender], [Address], [Mobile], [Email], [AaadharNo], [PAN], [DistrictID], [Salary], [UserImg]) VALUES (1, 1, N'Rahul', N'Male', N'abcdefgh', N'7489654789', N'rahul@gmail.com', N'789654782514', N'418529637418', 1, N'25000', N'/Content/Photo/7489654789.jpg')
SET IDENTITY_INSERT [dbo].[Registration] OFF
/****** Object:  ForeignKey [FK_Registration_District]    Script Date: 02/23/2019 12:58:33 ******/
ALTER TABLE [dbo].[Registration]  WITH CHECK ADD  CONSTRAINT [FK_Registration_District] FOREIGN KEY([DistrictID])
REFERENCES [dbo].[District] ([DistrictID])
GO
ALTER TABLE [dbo].[Registration] CHECK CONSTRAINT [FK_Registration_District]
GO
/****** Object:  ForeignKey [FK_Registration_Login]    Script Date: 02/23/2019 12:58:33 ******/
ALTER TABLE [dbo].[Registration]  WITH CHECK ADD  CONSTRAINT [FK_Registration_Login] FOREIGN KEY([LoginID])
REFERENCES [dbo].[Login] ([LoginID])
GO
ALTER TABLE [dbo].[Registration] CHECK CONSTRAINT [FK_Registration_Login]
GO
