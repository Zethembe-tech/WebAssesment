USE [WebAssessmentDB]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 2025/03/17 13:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[code] [int] IDENTITY(1,1) NOT NULL,
	[person_code] [int] NOT NULL,
	[account_number] [varchar](50) NOT NULL,
	[outstanding_balance] [money] NOT NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persons]    Script Date: 2025/03/17 13:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[code] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[surname] [varchar](50) NULL,
	[id_number] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 2025/03/17 13:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StatusTypes] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 2025/03/17 13:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[code] [int] IDENTITY(1,1) NOT NULL,
	[account_code] [int] NOT NULL,
	[transaction_date] [datetime] NOT NULL,
	[capture_date] [datetime] NOT NULL,
	[amount] [money] NOT NULL,
	[description] [varchar](100) NOT NULL,
	[UserCode] [int] NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2025/03/17 13:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonCode] [int] NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[PasswordHash] [varchar](255) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (1, 1, N'10000577', 234.9900, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (3, 3, N'1000373', 0.0000, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (4, 4, N'10007792', 0.0000, N'Closed')
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (5, 5, N'10011773', 641.7000, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (7, 7, N'100137', 936.4100, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (8, 8, N'10014357', 440.8700, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (9, 9, N'10015256', 170.6800, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (10, 10, N'10016473', 663.7700, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (11, 11, N'10017712', 1471.2700, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (12, 12, N'10019324', 269.8200, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (13, 13, N'10019766', 485.7800, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (14, 14, N'10020241', 715.8300, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (15, 15, N'10020918', 81.3500, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (16, 16, N'10021663', 627.1300, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (17, 17, N'10021698', 426.4300, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (18, 18, N'10022821', 557.3000, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (19, 19, N'10022996', 299.2000, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (20, 20, N'10024492', 767.2500, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (22, 22, N'10027602', 724.2600, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (23, 23, N'10028579', 1008.9900, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (24, 24, N'1002864', 1059.4300, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (25, 25, N'10032223', 719.6500, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (26, 26, N'10032274', 0.0000, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (27, 27, N'1003267', 843.5900, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (28, 28, N'10036466', 1186.8500, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (29, 29, N'10036474', 0.0000, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (30, 30, N'10036679', 226.7900, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (31, 31, N'10037489', 117.5200, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (32, 32, N'10039015', 542.0800, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (34, 34, N'10040919', 612.1000, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (35, 35, N'10041745', 191.7000, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (36, 36, N'10044361', 807.6000, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (37, 37, N'10045473', 806.4500, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (38, 38, N'10045856', 310.0300, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (39, 39, N'100460892', 0.0000, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (40, 40, N'10048022', 0.0000, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (41, 41, N'10048812', 648.3500, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (42, 42, N'1005022', 260.8500, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (43, 43, N'10050523', 532.6300, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (44, 44, N'10052623', 302.8500, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (45, 45, N'10052712', 633.4300, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (46, 46, N'10053581', 281.7700, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (47, 47, N'10053794', 268.4600, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (48, 48, N'10054855', 1803.2800, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (49, 49, N'10056262', 789.7400, NULL)
INSERT [dbo].[Accounts] ([code], [person_code], [account_number], [outstanding_balance], [Status]) VALUES (50, 50, N'10057269', 359.6000, NULL)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[Persons] ON 

INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (1, N'REJOCE', N'MAJOLA', N'63XX2907910XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (2, N'Friday1', N'MOKOMELE', N'70XX2403660XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (3, N'NTOMBIKHONA', N'MLAMBO', N'42XX1002420XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (4, N'KLAAS', N'OCKHUIS', N'39XX1400850XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (5, N'FERDI', N'LUUS', N'59XX0110380XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (7, N'', N'MOSOOANE', N'74XX2301550XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (8, N'', N'MOTENO', N'59XX1901940XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (9, N'', N'ZWANE', N'66XX0354900XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (10, N'JOSEPH', N'MOSWEU', N'72XX1806150XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (11, N'', N'ZULU', N'78XX0650010XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (12, N'', N'SKINI', N'72XX2205500XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (13, N'', N'MASOPA', N'60XX0707320XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (14, N'', N'COETZEE', N'56XX2351400XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (15, N'', N'BEN', N'65XX1003960XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (16, N'SOPHIE', N'SIHLANGU', N'68XX1612540XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (17, N'BUYISELWA', N'KEPATA', N'71XX2451300XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (18, N'ZANELE', N'NDLOVU', N'72XX2702550XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (19, N'', N'BARNABAS', N'62XX2207640XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (20, N'', N'ABRAHAMS', N'75XX2302470XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (21, N'', N'GOVENDER', N'73XX1104570XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (22, N'', N'ABDUL', N'65XX0106100XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (23, N'', N'MBIXANE', N'47XX2706770XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (24, N'MAVIS', N'MBOMBO', N'59XX1002010XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (25, N'', N'RAMALEPE', N'44XX0801450XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (26, N'', N'MRSHALOI', N'70XX3105540XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (27, N'', N'DE MEYER', N'69XX2604250XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (28, N'MICHAELINE', N'SITUMA', N'73XX0311610XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (29, N'', N'NDWANE', N'66XX2705830XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (30, N'', N'WEAVER', N'76XX2904740XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (31, N'REBECCA', N'JOOSTE', N'70XX2251240XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (32, N'', N'MOKETSI', N'67XX2750210XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (34, N'MICHEAL', N'TRUTER', N'67XX1256390XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (35, N'GLORY', N'SITHOLE', N'70XX0355620XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (36, N'ANNA', N'KOBE', N'57XX1907550XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (37, N'', N'PARTAB', N'69XX2459930XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (38, N'STORY', N'MAIPATO', N'70XX1507650XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (39, N'', N'SOTYATO', N'69XX2005003XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (40, N'FRANS', N'TOSKEY', N'73XX1306320XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (41, N'LILLIAN', N'DANIELS', N'58XX3100790XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (42, N'THEMBILE', N'MLUMBI', N'72XX0401610XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (43, N'BERENICE', N'MEINTJIES', N'67XX1105810XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (44, N'', N'NOMAVUKA', N'73XX1807580XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (45, N'NONHLANHLA', N'NGWENYA', N'68XX1211490XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (46, N'ELIZABETH', N'MOSES', N'77XX2304150XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (47, N'', N'JACOBS', N'76XX2902020XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (48, N'', N'GERTENBACH', N'58XX1802150XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (49, N'', N'MAMORARE', N'78XX1701830XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (50, N'', N'KHUMALO', N'45XX2605080XX')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (51, N'Zethembe', N'Myeni', N'980754xxx542')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (54, N'Zethembeaa', N'Myeni', N'9807540054214')
INSERT [dbo].[Persons] ([code], [name], [surname], [id_number]) VALUES (55, N'Bob', N'Marley', N'980754yyyy542')
SET IDENTITY_INSERT [dbo].[Persons] OFF
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([Id], [StatusTypes]) VALUES (1, N'Closed')
INSERT [dbo].[Status] ([Id], [StatusTypes]) VALUES (2, N'Open')
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[Transactions] ON 

INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (1, 1, CAST(N'2025-03-12T08:33:55.120' AS DateTime), CAST(N'2025-03-12T08:33:55.120' AS DateTime), 234.9900, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (3, 3, CAST(N'2025-03-12T08:33:55.120' AS DateTime), CAST(N'2025-03-12T08:33:55.120' AS DateTime), 520.6700, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (4, 4, CAST(N'2025-03-12T08:33:55.120' AS DateTime), CAST(N'2025-03-12T08:33:55.120' AS DateTime), 328.7000, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (5, 5, CAST(N'2025-03-12T08:33:55.120' AS DateTime), CAST(N'2025-03-12T08:33:55.120' AS DateTime), 641.7000, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (7, 7, CAST(N'2025-03-12T08:33:55.120' AS DateTime), CAST(N'2025-03-12T08:33:55.120' AS DateTime), 936.4100, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (8, 8, CAST(N'2025-03-12T08:33:55.120' AS DateTime), CAST(N'2025-03-12T08:33:55.120' AS DateTime), 440.8700, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (9, 9, CAST(N'2025-03-12T08:33:55.120' AS DateTime), CAST(N'2025-03-12T08:33:55.120' AS DateTime), 170.6800, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (10, 10, CAST(N'2025-03-12T08:33:55.120' AS DateTime), CAST(N'2025-03-12T08:33:55.120' AS DateTime), 663.7700, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (11, 11, CAST(N'2025-03-12T08:33:55.120' AS DateTime), CAST(N'2025-03-12T08:33:55.120' AS DateTime), 1471.2700, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (12, 12, CAST(N'2025-03-12T08:33:55.123' AS DateTime), CAST(N'2025-03-12T08:33:55.123' AS DateTime), 269.8200, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (13, 13, CAST(N'2025-03-12T08:33:55.123' AS DateTime), CAST(N'2025-03-12T08:33:55.123' AS DateTime), 485.7800, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (14, 14, CAST(N'2025-03-12T08:33:55.123' AS DateTime), CAST(N'2025-03-12T08:33:55.123' AS DateTime), 715.8300, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (15, 15, CAST(N'2025-03-12T08:33:55.123' AS DateTime), CAST(N'2025-03-12T08:33:55.123' AS DateTime), 81.3500, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (16, 16, CAST(N'2025-03-12T08:33:55.123' AS DateTime), CAST(N'2025-03-12T08:33:55.123' AS DateTime), 627.1300, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (17, 17, CAST(N'2025-03-12T08:33:55.123' AS DateTime), CAST(N'2025-03-12T08:33:55.123' AS DateTime), 426.4300, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (18, 18, CAST(N'2025-03-12T08:33:55.123' AS DateTime), CAST(N'2025-03-12T08:33:55.123' AS DateTime), 557.3000, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (19, 19, CAST(N'2025-03-12T08:33:55.123' AS DateTime), CAST(N'2025-03-12T08:33:55.123' AS DateTime), 299.2000, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (20, 20, CAST(N'2025-03-12T08:33:55.123' AS DateTime), CAST(N'2025-03-12T08:33:55.123' AS DateTime), 767.2500, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (22, 22, CAST(N'2025-03-12T08:33:55.123' AS DateTime), CAST(N'2025-03-12T08:33:55.123' AS DateTime), 724.2600, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (23, 23, CAST(N'2025-03-12T08:33:55.123' AS DateTime), CAST(N'2025-03-12T08:33:55.123' AS DateTime), 1008.9900, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (24, 24, CAST(N'2025-03-12T08:33:55.123' AS DateTime), CAST(N'2025-03-12T08:33:55.123' AS DateTime), 1059.4300, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (25, 25, CAST(N'2025-03-12T08:33:55.127' AS DateTime), CAST(N'2025-03-12T08:33:55.127' AS DateTime), 719.6500, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (26, 27, CAST(N'2025-03-12T08:33:55.127' AS DateTime), CAST(N'2025-03-12T08:33:55.127' AS DateTime), 843.5900, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (27, 28, CAST(N'2025-03-12T08:33:55.127' AS DateTime), CAST(N'2025-03-12T08:33:55.127' AS DateTime), 1186.8500, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (28, 30, CAST(N'2025-03-12T08:33:55.127' AS DateTime), CAST(N'2025-03-12T08:33:55.127' AS DateTime), 226.7900, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (29, 31, CAST(N'2025-03-12T08:33:55.127' AS DateTime), CAST(N'2025-03-12T08:33:55.127' AS DateTime), 117.5200, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (30, 32, CAST(N'2025-03-12T08:33:55.127' AS DateTime), CAST(N'2025-03-12T08:33:55.127' AS DateTime), 542.0800, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (31, 34, CAST(N'2025-03-12T08:33:55.127' AS DateTime), CAST(N'2025-03-12T08:33:55.127' AS DateTime), 612.1000, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (32, 35, CAST(N'2025-03-12T08:33:55.127' AS DateTime), CAST(N'2025-03-12T08:33:55.127' AS DateTime), 191.7000, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (34, 37, CAST(N'2025-03-12T08:33:55.127' AS DateTime), CAST(N'2025-03-12T08:33:55.127' AS DateTime), 806.4500, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (35, 38, CAST(N'2025-03-12T08:33:55.127' AS DateTime), CAST(N'2025-03-12T08:33:55.127' AS DateTime), 310.0300, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (36, 41, CAST(N'2025-03-12T08:33:55.127' AS DateTime), CAST(N'2025-03-12T08:33:55.127' AS DateTime), 648.3500, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (37, 42, CAST(N'2025-03-12T08:33:55.127' AS DateTime), CAST(N'2025-03-12T08:33:55.127' AS DateTime), 260.8500, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (38, 43, CAST(N'2025-03-12T08:33:55.127' AS DateTime), CAST(N'2025-03-12T08:33:55.127' AS DateTime), 532.6300, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (39, 44, CAST(N'2025-03-12T08:33:55.130' AS DateTime), CAST(N'2025-03-12T08:33:55.130' AS DateTime), 302.8500, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (40, 45, CAST(N'2025-03-12T08:33:55.130' AS DateTime), CAST(N'2025-03-12T08:33:55.130' AS DateTime), 633.4300, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (41, 46, CAST(N'2025-03-12T08:33:55.130' AS DateTime), CAST(N'2025-03-12T08:33:55.130' AS DateTime), 281.7700, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (42, 47, CAST(N'2025-03-12T08:33:55.130' AS DateTime), CAST(N'2025-03-12T08:33:55.130' AS DateTime), 268.4600, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (43, 48, CAST(N'2025-03-12T08:33:55.130' AS DateTime), CAST(N'2025-03-12T08:33:55.130' AS DateTime), 1803.2800, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (44, 49, CAST(N'2025-03-12T08:33:55.130' AS DateTime), CAST(N'2025-03-12T08:33:55.130' AS DateTime), 789.7400, N'Charge Off Amount', NULL)
INSERT [dbo].[Transactions] ([code], [account_code], [transaction_date], [capture_date], [amount], [description], [UserCode]) VALUES (45, 50, CAST(N'2025-03-12T08:33:55.130' AS DateTime), CAST(N'2025-03-12T08:33:55.130' AS DateTime), 359.6000, N'Charge Off Amount', NULL)
SET IDENTITY_INSERT [dbo].[Transactions] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [PersonCode], [Username], [PasswordHash], [CreatedAt], [IsActive]) VALUES (1, 1, N'Zethembe', N't7OBsBCFY4g=', CAST(N'2025-03-12T09:21:03.423' AS DateTime), 1)
INSERT [dbo].[Users] ([Id], [PersonCode], [Username], [PasswordHash], [CreatedAt], [IsActive]) VALUES (2, 2, N'testuser2', N'hashedpassword2', CAST(N'2025-03-12T09:21:03.423' AS DateTime), 1)
INSERT [dbo].[Users] ([Id], [PersonCode], [Username], [PasswordHash], [CreatedAt], [IsActive]) VALUES (3, 3, N'testuser3', N'hashedpassword3', CAST(N'2025-03-12T09:21:03.423' AS DateTime), 1)
INSERT [dbo].[Users] ([Id], [PersonCode], [Username], [PasswordHash], [CreatedAt], [IsActive]) VALUES (4, 4, N'testuser4', N'hashedpassword4', CAST(N'2025-03-12T09:21:03.423' AS DateTime), 1)
INSERT [dbo].[Users] ([Id], [PersonCode], [Username], [PasswordHash], [CreatedAt], [IsActive]) VALUES (5, 5, N'testuser5', N'hashedpassword5', CAST(N'2025-03-12T09:21:03.423' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__536C85E454AE2885]    Script Date: 2025/03/17 13:19:43 ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ_Person_User]    Script Date: 2025/03/17 13:19:43 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UQ_Person_User] UNIQUE NONCLUSTERED 
(
	[PersonCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Account_Person] FOREIGN KEY([person_code])
REFERENCES [dbo].[Persons] ([code])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Account_Person]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_Account] FOREIGN KEY([account_code])
REFERENCES [dbo].[Accounts] ([code])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transaction_Account]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_User] FOREIGN KEY([UserCode])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transaction_User]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_User_Person] FOREIGN KEY([PersonCode])
REFERENCES [dbo].[Persons] ([code])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_User_Person]
GO
/****** Object:  StoredProcedure [dbo].[stp_Accounts_Add]    Script Date: 2025/03/17 13:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stp_Accounts_Add]
   @PersonCode int = 0,
   @AccountNumber nvarchar(100) = '',
   @OutstandingBalance decimal(18,2) = 0

AS
BEGIN	
		if  exists(select 1 from Accounts where account_number = @AccountNumber)
		begin
		 Select 'Account number Already Exists.'
		end
		else 
		begin
			INSERT INTO [dbo].[Accounts] (person_code,account_number,outstanding_balance) 
	        values(@PersonCode,@AccountNumber,@OutstandingBalance)
		end


END
GO
/****** Object:  StoredProcedure [dbo].[stp_Accounts_Delete]    Script Date: 2025/03/17 13:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stp_Accounts_Delete]

    @Code int = 0


AS
BEGIN
    DELETE FROM [dbo].[Accounts] WHERE code = @Code


END
GO
/****** Object:  StoredProcedure [dbo].[stp_Accounts_GetDetailsById]    Script Date: 2025/03/17 13:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stp_Accounts_GetDetailsById]

    @Code int = 0


AS
BEGIN
    SELECT 
	a.code as Code,
	a.person_code as PersonCode,
	a.account_number as AccountNumber,
	cast(a.outstanding_balance as decimal(18,2)) as OutstandingBalance,
	p.[name] as [PersonName]
	FROM [dbo].[Accounts] a
	inner join Persons p on a.code = p.code
	where a.code =@Code
    ORDER BY 
    code

END
GO
/****** Object:  StoredProcedure [dbo].[stp_Accounts_ListAll]    Script Date: 2025/03/17 13:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stp_Accounts_ListAll]

	--@account_number varchar(50) = '',
	--@idnumber int = 0,
	--@name varchar(50) = ''

AS
BEGIN
    SELECT 
	a.code as Code,
	a.person_code as PersonCode,
	a.account_number as AccountNumber,
	cast(a.outstanding_balance as decimal(18,2)) as OutstandingBalance,
	p.[name] as [PersonName]
	FROM [dbo].[Accounts] a
	inner join Persons p on a.code = p.code
	--where a.account_number = @account_number 
	--or p.id_number = @idnumber 
	--or p.name = @name
    ORDER BY 
    code

END
GO
/****** Object:  StoredProcedure [dbo].[stp_Accounts_StatusCheck]    Script Date: 2025/03/17 13:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stp_Accounts_StatusCheck]
   @Code int = 0

AS
BEGIN		
    declare @Status nvarchar(50) = (SELECT [Status] FROM Accounts WHERE code = @Code)
	select @Status;
END
GO
/****** Object:  StoredProcedure [dbo].[stp_Accounts_StatusUpdate]    Script Date: 2025/03/17 13:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stp_Accounts_StatusUpdate]
   @Code int = 0,
   @Status varchar(250) = ''

AS
BEGIN		
       declare @outstanding_balance decimal(18,2) = (SELECT outstanding_balance FROM Accounts WHERE code = @Code);

	   if(@outstanding_balance = 0)
	    begin
			UPDATE Accounts
			SET [Status] =  @Status
			WHERE code = @Code 
		  select 'Account Closed succesfully'

		End
	else
	begin 
     select 'outstanding balance is 0'
	end
END
GO
/****** Object:  StoredProcedure [dbo].[stp_Accounts_Update]    Script Date: 2025/03/17 13:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stp_Accounts_Update]
   @Code int = 0,
   @PersonCode int = 0,
   @AccountNumber nvarchar(100) = '',
   @OutstandingBalance decimal(18,2) = 0

AS
BEGIN	
	UPDATE [dbo].[Accounts] 
	SET person_code = @PersonCode,
	    account_number = @AccountNumber,
	    outstanding_balance = @OutstandingBalance 
		where code = @Code
END
GO
/****** Object:  StoredProcedure [dbo].[stp_Persons_Add]    Script Date: 2025/03/17 13:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stp_Persons_Add]
   @name nvarchar(100) = '',
   @surname nvarchar(100) = '',
   @idNumber nvarchar(13) = ''

AS
BEGIN	
		if  exists(select 1 from Persons where id_number = @idNumber)
		begin
		 Select 'Identity number Already Exists.'
		end
		else
		begin 
			INSERT INTO [dbo].[Persons] ([name],surname,id_number) 
			values(@name,@surname,@idNumber)
		end


END
GO
/****** Object:  StoredProcedure [dbo].[stp_Persons_Delete]    Script Date: 2025/03/17 13:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stp_Persons_Delete]

    @Code int = 0


AS
BEGIN
    DELETE FROM [dbo].[Persons] WHERE code = @Code
	select 'DELETED';


END
GO
/****** Object:  StoredProcedure [dbo].[stp_Persons_GetDetails]    Script Date: 2025/03/17 13:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stp_Persons_GetDetails]

 @Code int = 0
AS
BEGIN
SELECT 
    p.Code,
    p.[name],
	a.account_number,
	a.outstanding_balance
FROM 
    [dbo].[Persons] p
	inner join Accounts a on p.code =a.code
WHERE 
    [name] IS NOT NULL
    AND TRIM([name]) <> ''
	AND P.code = @Code
ORDER BY 
    [name]

END
GO
/****** Object:  StoredProcedure [dbo].[stp_Persons_GetDetailsById]    Script Date: 2025/03/17 13:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stp_Persons_GetDetailsById]

    @Code int = 0


AS
BEGIN
    SELECT 
     Code,
	 name ,
	 surname,
	 id_number as IdNumber
	FROM [dbo].[Persons] 
	where code =@Code
    ORDER BY 
    code

END
GO
/****** Object:  StoredProcedure [dbo].[stp_Persons_GetNameList]    Script Date: 2025/03/17 13:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stp_Persons_GetNameList]


AS
BEGIN
SELECT 
    p.Code,
    p.[name] 
FROM 
    [dbo].[Persons] p
	inner join Accounts a on p.code =a.code
WHERE 
    [name] IS NOT NULL
    AND TRIM([name]) <> ''
ORDER BY 
    [name]

END
GO
/****** Object:  StoredProcedure [dbo].[stp_Persons_ListAll]    Script Date: 2025/03/17 13:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stp_Persons_ListAll]


AS
BEGIN
      SELECT 
     Code,
	 name ,
	 surname,
	 id_number as IdNumber
	FROM [dbo].[Persons] 
    ORDER BY 
    code

END
GO
/****** Object:  StoredProcedure [dbo].[stp_Persons_Update]    Script Date: 2025/03/17 13:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stp_Persons_Update]
   @code int = 0,
   @name  nvarchar(100) = '',
   @surname nvarchar(100) = '',
   @IdNumber  nvarchar(13)= ''

AS
BEGIN	
	UPDATE [dbo].[Persons] 
	SET [name] = @name,
	    surname = @surname,
	    id_number = @IdNumber 
		where code = @code
END
GO
/****** Object:  StoredProcedure [dbo].[stp_Transaction_Update]    Script Date: 2025/03/17 13:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stp_Transaction_Update]
   @Code int = 0,
   @AccountCode int = 0,
   @TransactionDate datetime = '',
   @CaptureDate datetime = '',
   @Amount decimal(18,2)=0,
   @Description varchar(250) = ''

AS
BEGIN	
	UPDATE [dbo].[TransactionS] 
	SET account_code = @AccountCode,
	    transaction_date = @TransactionDate,
	    capture_date = getdate(),
		amount = @Amount,
		[description] = @Description
		where code = @Code
END
GO
/****** Object:  StoredProcedure [dbo].[stp_Transactions_Add]    Script Date: 2025/03/17 13:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stp_Transactions_Add]
   @AccountCode int = 0,
   @TransactionDate datetime = '',
   @CaptureDate datetime = '',
   @Amount decimal(18,2)=0,
   @Description varchar(250) = ''


AS
BEGIN	
	INSERT INTO [dbo].[Transactions] ([account_code],transaction_date,capture_date,amount,[description]) 
	values(@AccountCode,@TransactionDate,@CaptureDate, @Amount, @Description)

END
GO
/****** Object:  StoredProcedure [dbo].[stp_Transactions_Delete]    Script Date: 2025/03/17 13:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stp_Transactions_Delete]

    @Code int = 0


AS
BEGIN
    DELETE FROM [dbo].[Transactions] WHERE code = @Code

END
GO
/****** Object:  StoredProcedure [dbo].[stp_Transactions_GetDetailsById]    Script Date: 2025/03/17 13:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stp_Transactions_GetDetailsById]
  @Code int 

AS
BEGIN
      SELECT 
		 t.code,
		 a.account_number,
		 t.transaction_date as TransactionDate,
		 t.capture_date as CaptureDate,
		 t.amount,
		 t.[description]
	FROM [dbo].[Transactions] t
	inner join Accounts a on t.account_code = a.code
	where a.code = @Code
    ORDER BY 
    code

END
GO
/****** Object:  StoredProcedure [dbo].[stp_Transactions_ListAll]    Script Date: 2025/03/17 13:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stp_Transactions_ListAll]


AS
BEGIN
      SELECT 
		 t.code as Code,
		 t.account_code as AccountCode ,
		 t.transaction_date as TransactionDate,
		 t.capture_date as CaptureDate,
		 t.amount as Amount,
		 t.[description],
		 a.account_number,
		 CONCAT( p.name , ' ' , p.surname) as [Name]
	FROM [dbo].[Transactions] t
	inner join Accounts a on t.account_code = a.code
	inner join Persons p on a.code = p.code
    ORDER BY 
    code

END
GO
/****** Object:  StoredProcedure [dbo].[stp_Transactions_ListAllByCode]    Script Date: 2025/03/17 13:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stp_Transactions_ListAllByCode]

@code int 
AS
BEGIN
      SELECT 
		 t.code as Code,
		 t.account_code as AccountCode ,
		 t.transaction_date as TransactionDate,
		 t.capture_date as CaptureDate,
		 t.amount as Amount,
		 t.[description],
		 a.account_number,
		 CONCAT( p.name , ' ' , p.surname) as [Name]
	FROM [dbo].[Transactions] t
	inner join Accounts a on t.account_code = a.code
	inner join Persons p on a.code = p.code
	where t.code = @code
    ORDER BY 
    code

END
GO
/****** Object:  StoredProcedure [dbo].[stp_TransactionsAccount_Delete]    Script Date: 2025/03/17 13:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stp_TransactionsAccount_Delete]

    @Code int = 0


AS
BEGIN
DELETE FROM [dbo].[Transactions] WHERE account_code = @Code;

END
GO
/****** Object:  StoredProcedure [dbo].[stp_User_GetDetailsByUsername]    Script Date: 2025/03/17 13:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stp_User_GetDetailsByUsername]
  @username nvarchar(max) 

AS
BEGIN
      SELECT *from Users where Username = @username

END
GO
