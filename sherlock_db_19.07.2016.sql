USE [SherlockStrategy]
GO
/****** Object:  Table [dbo].[GeneralSetting]    Script Date: 19.07.2016 16:54:23 ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 19.07.2016 16:54:23 ******/
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
INSERT [dbo].[User] ([Id], [UserName], [Password], [Email], [Rol], [Status], [SingUpContractStatus]) VALUES (31, N'emre', N'321', N'emre@akbulut.com', 2, 1, 0)
INSERT [dbo].[User] ([Id], [UserName], [Password], [Email], [Rol], [Status], [SingUpContractStatus]) VALUES (63, N'admin', N'132', N'admin@akbulut.net', 1, 0, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [Email], [Rol], [Status], [SingUpContractStatus]) VALUES (99, N'asd', N'123', N'asd@asd.com', 2, 1, 0)
SET IDENTITY_INSERT [dbo].[User] OFF
