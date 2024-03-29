USE [hair_salon]
GO
/****** Object:  Table [dbo].[clients]    Script Date: 7/15/2016 9:55:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[clients](
	[name] [varchar](255) NULL,
	[stylist_id] [int] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[stylists]    Script Date: 7/15/2016 9:55:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[stylists](
	[name] [varchar](255) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[clients] ON 

INSERT [dbo].[clients] ([name], [stylist_id], [id]) VALUES (N'Jane', 5, 1)
INSERT [dbo].[clients] ([name], [stylist_id], [id]) VALUES (N'Fredrick', 8, 9)
INSERT [dbo].[clients] ([name], [stylist_id], [id]) VALUES (N'Abby', 8, 10)
INSERT [dbo].[clients] ([name], [stylist_id], [id]) VALUES (N'William II', 6, 11)
INSERT [dbo].[clients] ([name], [stylist_id], [id]) VALUES (N'Adam', 5, 14)
INSERT [dbo].[clients] ([name], [stylist_id], [id]) VALUES (N'Charles', 5, 15)
INSERT [dbo].[clients] ([name], [stylist_id], [id]) VALUES (N'George', 6, 16)
SET IDENTITY_INSERT [dbo].[clients] OFF
SET IDENTITY_INSERT [dbo].[stylists] ON 

INSERT [dbo].[stylists] ([name], [id]) VALUES (N'Simone', 6)
INSERT [dbo].[stylists] ([name], [id]) VALUES (N'Pierre', 8)
SET IDENTITY_INSERT [dbo].[stylists] OFF
