USE [SherlockStrategy]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 3.08.2016 17:04:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Subject] [nvarchar](50) NULL,
	[Message] [nvarchar](max) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EncounterArchive]    Script Date: 3.08.2016 17:04:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EncounterArchive](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GameId] [int] NULL,
	[StartDate] [datetime] NULL,
	[EncounterType] [int] NULL,
	[PlayerId] [int] NULL,
	[EncounterStatus] [int] NULL,
	[WinnerType] [int] NULL,
 CONSTRAINT [PK_GameArchive] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Game]    Script Date: 3.08.2016 17:04:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Game](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GameName] [nvarchar](255) NULL,
	[TempPath] [nvarchar](255) NULL,
 CONSTRAINT [PK_Game] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GeneralSetting]    Script Date: 3.08.2016 17:04:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralSetting](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContractText] [nvarchar](max) NULL,
 CONSTRAINT [PK_GeneralSetting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Message]    Script Date: 3.08.2016 17:04:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SendUser] [int] NULL,
	[ReceiverUser] [int] NULL,
	[Subject] [nvarchar](255) NULL,
	[MessageText] [nvarchar](max) NULL,
	[Date] [datetime] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MoveArchive]    Script Date: 3.08.2016 17:04:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MoveArchive](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EncounterId] [int] NULL,
	[MoveCellx] [int] NULL,
	[MoveCelly] [int] NULL,
	[CellValue] [nvarchar](1) NULL,
 CONSTRAINT [PK_MoveArchive] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 3.08.2016 17:04:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Rol] [int] NULL,
	[Status] [bit] NULL,
	[SingUpContractStatus] [bit] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Contact] ON 

INSERT [dbo].[Contact] ([Id], [Subject], [Message], [Status]) VALUES (5, N'Hata Bildirimi', N'hata bildirimi yapıyorum !', 0)
SET IDENTITY_INSERT [dbo].[Contact] OFF
SET IDENTITY_INSERT [dbo].[EncounterArchive] ON 

INSERT [dbo].[EncounterArchive] ([Id], [GameId], [StartDate], [EncounterType], [PlayerId], [EncounterStatus], [WinnerType]) VALUES (304, 1, CAST(0x0000A65701003EB9 AS DateTime), 1, 30, 2, 0)
INSERT [dbo].[EncounterArchive] ([Id], [GameId], [StartDate], [EncounterType], [PlayerId], [EncounterStatus], [WinnerType]) VALUES (305, 1, CAST(0x0000A6570100DCEC AS DateTime), 1, 30, 1, 3)
INSERT [dbo].[EncounterArchive] ([Id], [GameId], [StartDate], [EncounterType], [PlayerId], [EncounterStatus], [WinnerType]) VALUES (306, 1, CAST(0x0000A6570100EC89 AS DateTime), 1, 30, 2, 0)
INSERT [dbo].[EncounterArchive] ([Id], [GameId], [StartDate], [EncounterType], [PlayerId], [EncounterStatus], [WinnerType]) VALUES (307, 1, CAST(0x0000A65701163EA3 AS DateTime), 1, 30, 2, 0)
SET IDENTITY_INSERT [dbo].[EncounterArchive] OFF
SET IDENTITY_INSERT [dbo].[Game] ON 

INSERT [dbo].[Game] ([Id], [GameName], [TempPath]) VALUES (1, N'XOX', N'XoxTemplate.html')
INSERT [dbo].[Game] ([Id], [GameName], [TempPath]) VALUES (2, N'Amiral Battı', N'AmiralBattiTemplate.html')
SET IDENTITY_INSERT [dbo].[Game] OFF
SET IDENTITY_INSERT [dbo].[GeneralSetting] ON 

INSERT [dbo].[GeneralSetting] ([Id], [ContractText]) VALUES (1, N'Kayıt sözleşme metni update')
SET IDENTITY_INSERT [dbo].[GeneralSetting] OFF
SET IDENTITY_INSERT [dbo].[Message] ON 

INSERT [dbo].[Message] ([Id], [SendUser], [ReceiverUser], [Subject], [MessageText], [Date], [Status]) VALUES (7, 30, 31, N'kullanıcı mesaj', N'yöneticisinden kullanıcıya mesaj', CAST(0x0000A650008DE2B0 AS DateTime), 1)
INSERT [dbo].[Message] ([Id], [SendUser], [ReceiverUser], [Subject], [MessageText], [Date], [Status]) VALUES (8, 31, 30, N'kullanıcı mesaj', N'test Cevap', CAST(0x0000A650009E57B1 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Message] OFF
SET IDENTITY_INSERT [dbo].[MoveArchive] ON 

INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellx], [MoveCelly], [CellValue]) VALUES (494, 304, 0, 0, N'X')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellx], [MoveCelly], [CellValue]) VALUES (495, 304, 1, 1, N'O')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellx], [MoveCelly], [CellValue]) VALUES (496, 304, 0, 2, N'X')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellx], [MoveCelly], [CellValue]) VALUES (497, 304, 0, 1, N'O')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellx], [MoveCelly], [CellValue]) VALUES (498, 304, 2, 0, N'X')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellx], [MoveCelly], [CellValue]) VALUES (499, 304, 1, 0, N'O')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellx], [MoveCelly], [CellValue]) VALUES (500, 304, 1, 2, N'X')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellx], [MoveCelly], [CellValue]) VALUES (501, 304, 2, 1, N'O')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellx], [MoveCelly], [CellValue]) VALUES (502, 304, 2, 2, N'X')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellx], [MoveCelly], [CellValue]) VALUES (503, 305, 0, 0, N'X')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellx], [MoveCelly], [CellValue]) VALUES (504, 305, 1, 1, N'O')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellx], [MoveCelly], [CellValue]) VALUES (505, 305, 0, 2, N'X')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellx], [MoveCelly], [CellValue]) VALUES (506, 305, 0, 1, N'O')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellx], [MoveCelly], [CellValue]) VALUES (507, 305, 2, 1, N'X')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellx], [MoveCelly], [CellValue]) VALUES (508, 305, 1, 0, N'O')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellx], [MoveCelly], [CellValue]) VALUES (509, 305, 1, 2, N'X')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellx], [MoveCelly], [CellValue]) VALUES (510, 305, 2, 2, N'O')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellx], [MoveCelly], [CellValue]) VALUES (511, 305, 2, 0, N'X')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellx], [MoveCelly], [CellValue]) VALUES (512, 306, 0, 0, N'X')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellx], [MoveCelly], [CellValue]) VALUES (513, 306, 1, 1, N'O')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellx], [MoveCelly], [CellValue]) VALUES (514, 306, 0, 1, N'X')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellx], [MoveCelly], [CellValue]) VALUES (515, 306, 0, 2, N'O')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellx], [MoveCelly], [CellValue]) VALUES (516, 306, 1, 0, N'X')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellx], [MoveCelly], [CellValue]) VALUES (517, 306, 2, 0, N'O')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellx], [MoveCelly], [CellValue]) VALUES (518, 307, 0, 0, N'X')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellx], [MoveCelly], [CellValue]) VALUES (519, 307, 0, 1, N'O')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellx], [MoveCelly], [CellValue]) VALUES (520, 307, 2, 2, N'X')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellx], [MoveCelly], [CellValue]) VALUES (521, 307, 1, 1, N'O')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellx], [MoveCelly], [CellValue]) VALUES (522, 307, 2, 0, N'X')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellx], [MoveCelly], [CellValue]) VALUES (523, 307, 1, 0, N'O')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellx], [MoveCelly], [CellValue]) VALUES (524, 307, 2, 1, N'X')
SET IDENTITY_INSERT [dbo].[MoveArchive] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [UserName], [Password], [Email], [Rol], [Status], [SingUpContractStatus]) VALUES (30, N'yunus', N'123', N'asd', 1, 1, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [Email], [Rol], [Status], [SingUpContractStatus]) VALUES (31, N'emre', N'321', N'emre@akbulut.com', 2, 1, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [Email], [Rol], [Status], [SingUpContractStatus]) VALUES (100, N'admin', N'1122', N'admin@akbulut.net', 2, 0, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [Email], [Rol], [Status], [SingUpContractStatus]) VALUES (101, N'asd', N'asdqwe', N'asd@yunus.com', 2, 0, 1)
SET IDENTITY_INSERT [dbo].[User] OFF
