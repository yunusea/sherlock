USE [SherlockStrategy]
GO
/****** Object:  Table [dbo].[GeneralSetting]    Script Date: 22.07.2016 17:01:56 ******/
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
/****** Object:  Table [dbo].[Message]    Script Date: 22.07.2016 17:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[SendUser] [int] NULL,
	[ReceiverUser] [int] NULL,
	[Date] [datetime] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 22.07.2016 17:01:56 ******/
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
SET IDENTITY_INSERT [dbo].[GeneralSetting] ON 

INSERT [dbo].[GeneralSetting] ([Id], [ContractText]) VALUES (1, N'Kayıt sözleşme metni update')
SET IDENTITY_INSERT [dbo].[GeneralSetting] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [UserName], [Password], [Email], [Rol], [Status], [SingUpContractStatus]) VALUES (30, N'yunus', N'123', N'asd', 1, 1, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [Email], [Rol], [Status], [SingUpContractStatus]) VALUES (31, N'emre', N'321', N'emre@akbulut.com', 2, 1, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [Email], [Rol], [Status], [SingUpContractStatus]) VALUES (100, N'admin', N'1122', N'admin@akbulut.net', 2, 0, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [Email], [Rol], [Status], [SingUpContractStatus]) VALUES (101, N'asd', N'asdqwe', N'asd@yunus.com', 2, 0, 1)
SET IDENTITY_INSERT [dbo].[User] OFF
