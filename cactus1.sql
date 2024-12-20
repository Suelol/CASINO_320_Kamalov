USE [CASINO]
GO
/****** Object:  Table [dbo].[Bonuses]    Script Date: 17.11.2024 20:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bonuses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BonusType] [nvarchar](50) NOT NULL,
	[Amount] [decimal](10, 2) NOT NULL,
	[MinDeposit] [decimal](10, 2) NOT NULL,
	[MaxBonus] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FinancialOperations]    Script Date: 17.11.2024 20:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FinancialOperations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[OperationType] [nvarchar](50) NOT NULL,
	[Amount] [decimal](10, 2) NOT NULL,
	[DateTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GameHistory]    Script Date: 17.11.2024 20:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GameHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[GameId] [int] NOT NULL,
	[SessionId] [int] NOT NULL,
	[Bet] [decimal](10, 2) NOT NULL,
	[Result] [decimal](10, 2) NOT NULL,
	[DateTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Games]    Script Date: 17.11.2024 20:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Games](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GameSessions]    Script Date: 17.11.2024 20:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GameSessions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[GameId] [int] NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NULL,
	[Bet] [decimal](10, 2) NOT NULL,
	[Result] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reports]    Script Date: 17.11.2024 20:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reports](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportType] [nvarchar](50) NOT NULL,
	[UserId] [int] NULL,
	[ReportData] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rewards]    Script Date: 17.11.2024 20:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rewards](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RewardType] [nvarchar](50) NOT NULL,
	[Amount] [decimal](10, 2) NOT NULL,
	[DateTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 17.11.2024 20:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Balance] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FinancialOperations] ON 

INSERT [dbo].[FinancialOperations] ([Id], [UserId], [OperationType], [Amount], [DateTime]) VALUES (1, 1, N'Пополнение средств', CAST(20.00 AS Decimal(10, 2)), CAST(N'2024-09-22T18:08:41.107' AS DateTime))
INSERT [dbo].[FinancialOperations] ([Id], [UserId], [OperationType], [Amount], [DateTime]) VALUES (2, 1, N'Вывод средств', CAST(200.00 AS Decimal(10, 2)), CAST(N'2024-09-22T18:11:50.727' AS DateTime))
INSERT [dbo].[FinancialOperations] ([Id], [UserId], [OperationType], [Amount], [DateTime]) VALUES (3, 1, N'Пополнение средств', CAST(1222.00 AS Decimal(10, 2)), CAST(N'2024-09-23T12:50:35.020' AS DateTime))
INSERT [dbo].[FinancialOperations] ([Id], [UserId], [OperationType], [Amount], [DateTime]) VALUES (4, 1, N'Вывод средств', CAST(1200000.00 AS Decimal(10, 2)), CAST(N'2024-09-23T13:24:29.697' AS DateTime))
INSERT [dbo].[FinancialOperations] ([Id], [UserId], [OperationType], [Amount], [DateTime]) VALUES (5, 2, N'Пополнение средств', CAST(1200000.00 AS Decimal(10, 2)), CAST(N'2024-09-23T13:58:42.767' AS DateTime))
INSERT [dbo].[FinancialOperations] ([Id], [UserId], [OperationType], [Amount], [DateTime]) VALUES (6, 1, N'Пополнение средств', CAST(234234.00 AS Decimal(10, 2)), CAST(N'2024-09-23T17:09:00.120' AS DateTime))
INSERT [dbo].[FinancialOperations] ([Id], [UserId], [OperationType], [Amount], [DateTime]) VALUES (7, 1, N'Пополнение средств', CAST(100.00 AS Decimal(10, 2)), CAST(N'2024-09-24T11:56:25.987' AS DateTime))
INSERT [dbo].[FinancialOperations] ([Id], [UserId], [OperationType], [Amount], [DateTime]) VALUES (8, 1, N'Вывод средств', CAST(234.00 AS Decimal(10, 2)), CAST(N'2024-09-24T11:56:33.517' AS DateTime))
SET IDENTITY_INSERT [dbo].[FinancialOperations] OFF
GO
SET IDENTITY_INSERT [dbo].[GameHistory] ON 

INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (3, 1, 1, 4, CAST(1000.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2024-09-22T16:23:07.303' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (4, 1, 1, 4, CAST(1000.00 AS Decimal(10, 2)), CAST(1.00 AS Decimal(10, 2)), CAST(N'2024-09-23T12:48:22.160' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (5, 1, 1, 4, CAST(1000.00 AS Decimal(10, 2)), CAST(1.00 AS Decimal(10, 2)), CAST(N'2024-09-23T12:48:30.297' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (6, 1, 1, 4, CAST(1000.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2024-09-23T12:48:33.537' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (7, 1, 1, 4, CAST(1000.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2024-09-23T12:48:37.203' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (8, 1, 1, 4, CAST(1000.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2024-09-23T12:48:41.347' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (9, 1, 1, 4, CAST(1000.00 AS Decimal(10, 2)), CAST(1.00 AS Decimal(10, 2)), CAST(N'2024-09-23T12:48:44.047' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (10, 1, 1, 4, CAST(10.00 AS Decimal(10, 2)), CAST(1.00 AS Decimal(10, 2)), CAST(N'2024-09-23T12:49:39.903' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (11, 1, 1, 4, CAST(10.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2024-09-23T12:49:44.367' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (12, 1, 1, 4, CAST(10.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2024-09-23T12:49:48.047' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (13, 1, 1, 4, CAST(10.00 AS Decimal(10, 2)), CAST(2.00 AS Decimal(10, 2)), CAST(N'2024-09-23T12:49:51.713' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (14, 1, 1, 4, CAST(10.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2024-09-23T12:49:54.530' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (15, 1, 1, 4, CAST(10.00 AS Decimal(10, 2)), CAST(1.00 AS Decimal(10, 2)), CAST(N'2024-09-23T12:49:57.690' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (16, 1, 1, 4, CAST(10.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2024-09-23T12:50:01.707' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (17, 2, 1, 4, CAST(1000.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2024-09-23T13:25:23.973' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (18, 2, 1, 4, CAST(1000.00 AS Decimal(10, 2)), CAST(1.00 AS Decimal(10, 2)), CAST(N'2024-09-23T13:25:28.833' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (19, 2, 1, 4, CAST(1000.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2024-09-23T13:25:32.280' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (20, 2, 1, 4, CAST(1000.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2024-09-23T13:25:35.347' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (21, 2, 1, 4, CAST(1000.00 AS Decimal(10, 2)), CAST(1.00 AS Decimal(10, 2)), CAST(N'2024-09-23T13:25:40.660' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (22, 2, 1, 4, CAST(5000.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2024-09-23T13:25:52.097' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (23, 2, 1, 4, CAST(2000.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2024-09-23T13:26:06.690' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (24, 2, 1, 4, CAST(2000.00 AS Decimal(10, 2)), CAST(1.00 AS Decimal(10, 2)), CAST(N'2024-09-23T13:26:09.497' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (25, 2, 1, 4, CAST(2000.00 AS Decimal(10, 2)), CAST(2.00 AS Decimal(10, 2)), CAST(N'2024-09-23T13:26:14.033' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (26, 2, 1, 4, CAST(1000.00 AS Decimal(10, 2)), CAST(1.00 AS Decimal(10, 2)), CAST(N'2024-09-23T13:58:23.023' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (27, 2, 1, 4, CAST(1000.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2024-09-23T17:08:16.127' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (28, 2, 1, 4, CAST(1000.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2024-09-23T17:08:23.527' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (29, 2, 1, 4, CAST(1000.00 AS Decimal(10, 2)), CAST(1.00 AS Decimal(10, 2)), CAST(N'2024-09-23T17:08:27.237' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (30, 1, 1, 4, CAST(1000.00 AS Decimal(10, 2)), CAST(1.00 AS Decimal(10, 2)), CAST(N'2024-09-23T17:16:38.990' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (31, 1, 1, 4, CAST(1000.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2024-09-23T17:16:47.077' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (32, 1, 1, 4, CAST(1000.00 AS Decimal(10, 2)), CAST(2.00 AS Decimal(10, 2)), CAST(N'2024-09-23T17:16:49.863' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (33, 1, 1, 4, CAST(1000.00 AS Decimal(10, 2)), CAST(1.00 AS Decimal(10, 2)), CAST(N'2024-09-23T17:16:53.413' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (34, 1, 1, 4, CAST(1000.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2024-09-23T17:16:59.593' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (35, 1, 1, 4, CAST(1000.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2024-09-23T17:17:06.687' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (36, 1, 1, 4, CAST(1000.00 AS Decimal(10, 2)), CAST(1.00 AS Decimal(10, 2)), CAST(N'2024-09-23T17:17:09.397' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (37, 1, 1, 4, CAST(1000.00 AS Decimal(10, 2)), CAST(1.00 AS Decimal(10, 2)), CAST(N'2024-09-23T18:40:05.593' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (38, 1, 1, 4, CAST(1000.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2024-09-24T10:44:17.937' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (39, 1, 1, 4, CAST(1000.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2024-09-24T10:44:21.573' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (40, 1, 1, 4, CAST(1000.00 AS Decimal(10, 2)), CAST(1.00 AS Decimal(10, 2)), CAST(N'2024-09-24T10:44:24.863' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (41, 1, 1, 4, CAST(1000.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2024-09-24T10:44:28.950' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (42, 1, 1, 4, CAST(1000.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2024-09-24T11:56:01.320' AS DateTime))
INSERT [dbo].[GameHistory] ([Id], [UserId], [GameId], [SessionId], [Bet], [Result], [DateTime]) VALUES (43, 1, 1, 4, CAST(1000.00 AS Decimal(10, 2)), CAST(1.00 AS Decimal(10, 2)), CAST(N'2024-09-24T11:56:06.373' AS DateTime))
SET IDENTITY_INSERT [dbo].[GameHistory] OFF
GO
SET IDENTITY_INSERT [dbo].[Games] ON 

INSERT [dbo].[Games] ([Id], [Name], [Description]) VALUES (1, N'21', N'21')
SET IDENTITY_INSERT [dbo].[Games] OFF
GO
SET IDENTITY_INSERT [dbo].[GameSessions] ON 

INSERT [dbo].[GameSessions] ([Id], [UserId], [GameId], [StartTime], [EndTime], [Bet], [Result]) VALUES (4, 1, 1, CAST(N'2024-01-01T00:00:00.000' AS DateTime), NULL, CAST(1.00 AS Decimal(10, 2)), NULL)
SET IDENTITY_INSERT [dbo].[GameSessions] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Login], [Password], [Email], [Balance]) VALUES (1, N'1', N'1', N'sdas@mail.ru', CAST(234245.00 AS Decimal(10, 2)))
INSERT [dbo].[Users] ([Id], [Login], [Password], [Email], [Balance]) VALUES (2, N'Suelol', N'Ramil2005r', N'kamalovramil432@gmail.com', CAST(1204000.00 AS Decimal(10, 2)))
INSERT [dbo].[Users] ([Id], [Login], [Password], [Email], [Balance]) VALUES (7, N'Kamal', N'Kamal', N'kamal@gmail.com', CAST(0.00 AS Decimal(10, 2)))
INSERT [dbo].[Users] ([Id], [Login], [Password], [Email], [Balance]) VALUES (8, N'Ramil', N'123', N'123@gmail.com', CAST(0.00 AS Decimal(10, 2)))
INSERT [dbo].[Users] ([Id], [Login], [Password], [Email], [Balance]) VALUES (9, N'Ramil1', N'1234', N'dsfdsf@gmail.com', CAST(0.00 AS Decimal(10, 2)))
INSERT [dbo].[Users] ([Id], [Login], [Password], [Email], [Balance]) VALUES (10, N'123231', N'123', N'kamalovramil432@gmail.com', CAST(0.00 AS Decimal(10, 2)))
INSERT [dbo].[Users] ([Id], [Login], [Password], [Email], [Balance]) VALUES (11, N'Ramil123', N'123', N'123@gmail.com', CAST(0.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0.00)) FOR [Balance]
GO
ALTER TABLE [dbo].[FinancialOperations]  WITH CHECK ADD  CONSTRAINT [FK_FinancialOperations_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[FinancialOperations] CHECK CONSTRAINT [FK_FinancialOperations_Users]
GO
ALTER TABLE [dbo].[GameHistory]  WITH CHECK ADD  CONSTRAINT [FK_GameHistory_Games] FOREIGN KEY([GameId])
REFERENCES [dbo].[Games] ([Id])
GO
ALTER TABLE [dbo].[GameHistory] CHECK CONSTRAINT [FK_GameHistory_Games]
GO
ALTER TABLE [dbo].[GameHistory]  WITH CHECK ADD  CONSTRAINT [FK_GameHistory_GameSessions] FOREIGN KEY([SessionId])
REFERENCES [dbo].[GameSessions] ([Id])
GO
ALTER TABLE [dbo].[GameHistory] CHECK CONSTRAINT [FK_GameHistory_GameSessions]
GO
ALTER TABLE [dbo].[GameHistory]  WITH CHECK ADD  CONSTRAINT [FK_GameHistory_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[GameHistory] CHECK CONSTRAINT [FK_GameHistory_Users]
GO
ALTER TABLE [dbo].[GameSessions]  WITH CHECK ADD  CONSTRAINT [FK_GameSessions_Games] FOREIGN KEY([GameId])
REFERENCES [dbo].[Games] ([Id])
GO
ALTER TABLE [dbo].[GameSessions] CHECK CONSTRAINT [FK_GameSessions_Games]
GO
ALTER TABLE [dbo].[GameSessions]  WITH CHECK ADD  CONSTRAINT [FK_GameSessions_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[GameSessions] CHECK CONSTRAINT [FK_GameSessions_Users]
GO
ALTER TABLE [dbo].[Reports]  WITH CHECK ADD  CONSTRAINT [FK_Reports_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Reports] CHECK CONSTRAINT [FK_Reports_Users]
GO
ALTER TABLE [dbo].[Rewards]  WITH CHECK ADD  CONSTRAINT [FK_Rewards_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Rewards] CHECK CONSTRAINT [FK_Rewards_Users]
GO
