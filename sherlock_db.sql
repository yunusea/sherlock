USE [SherlockStrategy]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 1.08.2016 17:01:59 ******/
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
/****** Object:  Table [dbo].[EncounterArchive]    Script Date: 1.08.2016 17:01:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EncounterArchive](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GameId] [int] NULL,
	[StartDate] [datetime] NULL,
	[MoveCount] [int] NULL,
	[EncounterType] [int] NULL,
	[PlayerId] [int] NULL,
 CONSTRAINT [PK_GameArchive] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Game]    Script Date: 1.08.2016 17:01:59 ******/
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
/****** Object:  Table [dbo].[GeneralSetting]    Script Date: 1.08.2016 17:01:59 ******/
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
/****** Object:  Table [dbo].[Message]    Script Date: 1.08.2016 17:01:59 ******/
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
/****** Object:  Table [dbo].[MoveArchive]    Script Date: 1.08.2016 17:01:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MoveArchive](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EncounterId] [int] NULL,
	[MoveCellId] [nvarchar](6) NULL,
 CONSTRAINT [PK_MoveArchive] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 1.08.2016 17:01:59 ******/
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

INSERT [dbo].[EncounterArchive] ([Id], [GameId], [StartDate], [MoveCount], [EncounterType], [PlayerId]) VALUES (59, 1, CAST(0x0000A65500FB6AF4 AS DateTime), 0, 1, 30)
INSERT [dbo].[EncounterArchive] ([Id], [GameId], [StartDate], [MoveCount], [EncounterType], [PlayerId]) VALUES (60, 1, CAST(0x0000A65500FB7E41 AS DateTime), 0, 1, 30)
INSERT [dbo].[EncounterArchive] ([Id], [GameId], [StartDate], [MoveCount], [EncounterType], [PlayerId]) VALUES (61, 1, CAST(0x0000A65500FB9140 AS DateTime), 0, 1, 30)
INSERT [dbo].[EncounterArchive] ([Id], [GameId], [StartDate], [MoveCount], [EncounterType], [PlayerId]) VALUES (62, 1, CAST(0x0000A65500FBA841 AS DateTime), 0, 1, 30)
INSERT [dbo].[EncounterArchive] ([Id], [GameId], [StartDate], [MoveCount], [EncounterType], [PlayerId]) VALUES (63, 1, CAST(0x0000A6550101F84F AS DateTime), 0, 1, 30)
INSERT [dbo].[EncounterArchive] ([Id], [GameId], [StartDate], [MoveCount], [EncounterType], [PlayerId]) VALUES (64, 1, CAST(0x0000A65501068979 AS DateTime), 0, 1, 30)
INSERT [dbo].[EncounterArchive] ([Id], [GameId], [StartDate], [MoveCount], [EncounterType], [PlayerId]) VALUES (65, 1, CAST(0x0000A65501069254 AS DateTime), 0, 1, 30)
INSERT [dbo].[EncounterArchive] ([Id], [GameId], [StartDate], [MoveCount], [EncounterType], [PlayerId]) VALUES (66, 1, CAST(0x0000A6550106BBB1 AS DateTime), 0, 1, 30)
INSERT [dbo].[EncounterArchive] ([Id], [GameId], [StartDate], [MoveCount], [EncounterType], [PlayerId]) VALUES (67, 1, CAST(0x0000A6550106D9AE AS DateTime), 0, 1, 30)
INSERT [dbo].[EncounterArchive] ([Id], [GameId], [StartDate], [MoveCount], [EncounterType], [PlayerId]) VALUES (68, 1, CAST(0x0000A6550106E959 AS DateTime), 0, 1, 30)
INSERT [dbo].[EncounterArchive] ([Id], [GameId], [StartDate], [MoveCount], [EncounterType], [PlayerId]) VALUES (69, 1, CAST(0x0000A6550106FFCA AS DateTime), 0, 1, 30)
INSERT [dbo].[EncounterArchive] ([Id], [GameId], [StartDate], [MoveCount], [EncounterType], [PlayerId]) VALUES (70, 1, CAST(0x0000A65501074A80 AS DateTime), 0, 1, 30)
INSERT [dbo].[EncounterArchive] ([Id], [GameId], [StartDate], [MoveCount], [EncounterType], [PlayerId]) VALUES (71, 1, CAST(0x0000A65501076ED1 AS DateTime), 0, 1, 30)
INSERT [dbo].[EncounterArchive] ([Id], [GameId], [StartDate], [MoveCount], [EncounterType], [PlayerId]) VALUES (72, 1, CAST(0x0000A65501077B1E AS DateTime), 0, 1, 30)
INSERT [dbo].[EncounterArchive] ([Id], [GameId], [StartDate], [MoveCount], [EncounterType], [PlayerId]) VALUES (73, 1, CAST(0x0000A65501078A2C AS DateTime), 0, 1, 30)
INSERT [dbo].[EncounterArchive] ([Id], [GameId], [StartDate], [MoveCount], [EncounterType], [PlayerId]) VALUES (74, 1, CAST(0x0000A65501079F68 AS DateTime), 0, 1, 30)
INSERT [dbo].[EncounterArchive] ([Id], [GameId], [StartDate], [MoveCount], [EncounterType], [PlayerId]) VALUES (75, 1, CAST(0x0000A6550107DC84 AS DateTime), 0, 1, 30)
INSERT [dbo].[EncounterArchive] ([Id], [GameId], [StartDate], [MoveCount], [EncounterType], [PlayerId]) VALUES (76, 1, CAST(0x0000A6550108962F AS DateTime), 0, 1, 30)
INSERT [dbo].[EncounterArchive] ([Id], [GameId], [StartDate], [MoveCount], [EncounterType], [PlayerId]) VALUES (77, 1, CAST(0x0000A6550108A324 AS DateTime), 0, 1, 30)
INSERT [dbo].[EncounterArchive] ([Id], [GameId], [StartDate], [MoveCount], [EncounterType], [PlayerId]) VALUES (78, 1, CAST(0x0000A65501099B58 AS DateTime), 0, 1, 30)
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

INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (91, 59, N'cell00')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (92, 59, N'cell01')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (93, 59, N'cell20')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (94, 59, N'cell11')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (95, 59, N'cell12')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (96, 59, N'cell10')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (97, 59, N'cell11')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (98, 59, N'cell00')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (99, 59, N'cell22')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (100, 59, N'cell00')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (101, 59, N'cell01')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (102, 59, N'cell10')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (103, 59, N'cell11')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (104, 59, N'cell22')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (105, 59, N'cell00')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (106, 59, N'cell22')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (107, 59, N'cell10')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (108, 59, N'cell01')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (109, 59, N'cell00')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (110, 59, N'cell01')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (111, 59, N'cell10')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (112, 59, N'cell00')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (113, 59, N'cell11')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (114, 59, N'cell22')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (115, 59, N'cell00')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (116, 59, N'cell01')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (117, 59, N'cell02')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (118, 59, N'cell00')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (119, 59, N'cell00')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (120, 59, N'cell11')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (121, 59, N'cell10')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (122, 59, N'cell22')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (123, 59, N'cell10')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (124, 59, N'cell00')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (125, 59, N'cell11')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (126, 59, N'cell12')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (127, 59, N'cell10')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (128, 59, N'cell00')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (129, 59, N'cell11')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (130, 59, N'cell20')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (131, 59, N'cell21')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (132, 59, N'cell02')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (133, 59, N'cell00')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (134, 59, N'cell10')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (135, 59, N'cell11')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (136, 59, N'cell21')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (137, 59, N'cell00')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (138, 59, N'cell01')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (139, 59, N'cell12')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (140, 59, N'cell10')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (141, 59, N'cell11')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (142, 59, N'cell21')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (143, 59, N'cell01')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (144, 59, N'cell11')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (145, 59, N'cell20')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (146, 59, N'cell21')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (147, 59, N'cell11')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (148, 59, N'cell01')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (149, 59, N'cell21')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (150, 59, N'cell00')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (151, 59, N'cell10')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (152, 59, N'cell11')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (153, 59, N'cell22')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (154, 59, N'cell11')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (155, 59, N'cell21')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (156, 59, N'cell01')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (157, 59, N'cell12')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (158, 59, N'cell22')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (159, 59, N'cell00')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (160, 59, N'cell10')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (161, 59, N'cell01')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (162, 59, N'cell12')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (163, 59, N'cell21')
INSERT [dbo].[MoveArchive] ([Id], [EncounterId], [MoveCellId]) VALUES (164, 59, N'cell22')
SET IDENTITY_INSERT [dbo].[MoveArchive] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [UserName], [Password], [Email], [Rol], [Status], [SingUpContractStatus]) VALUES (30, N'yunus', N'123', N'asd', 1, 1, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [Email], [Rol], [Status], [SingUpContractStatus]) VALUES (31, N'emre', N'321', N'emre@akbulut.com', 2, 1, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [Email], [Rol], [Status], [SingUpContractStatus]) VALUES (100, N'admin', N'1122', N'admin@akbulut.net', 2, 0, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [Email], [Rol], [Status], [SingUpContractStatus]) VALUES (101, N'asd', N'asdqwe', N'asd@yunus.com', 2, 0, 1)
SET IDENTITY_INSERT [dbo].[User] OFF
