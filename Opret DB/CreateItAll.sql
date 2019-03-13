USE master
GO

CREATE DATABASE Eksamensopgave2DB
GO

USE Eksamensopgave2DB
GO

CREATE TABLE [dbo].[GroceryTable] (
    [Id]        INT           IDENTITY (0, 1) NOT NULL,
    [name]      NVARCHAR (50) NOT NULL,
    [checkmark] BIT           DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[Counter] [int] NOT NULL,
	[LastLogin] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[GroceryTable] ON
INSERT INTO [dbo].[GroceryTable] ([Id], [name], [checkmark]) VALUES (0, N'Mælk', 0)
INSERT INTO [dbo].[GroceryTable] ([Id], [name], [checkmark]) VALUES (1, N'Ost', 0)
INSERT INTO [dbo].[GroceryTable] ([Id], [name], [checkmark]) VALUES (2, N'Havregryn', 0)
INSERT INTO [dbo].[GroceryTable] ([Id], [name], [checkmark]) VALUES (3, N'Kaffe', 0)
INSERT INTO [dbo].[GroceryTable] ([Id], [name], [checkmark]) VALUES (4, N'Mel', 0)
INSERT INTO [dbo].[GroceryTable] ([Id], [name], [checkmark]) VALUES (5, N'Jordbær', 0)
INSERT INTO [dbo].[GroceryTable] ([Id], [name], [checkmark]) VALUES (6, N'Sukker', 0)
SET IDENTITY_INSERT [dbo].[GroceryTable] OFF
GO

SET IDENTITY_INSERT [dbo].[Users] ON
INSERT INTO [dbo].[Users] ([Id], [Name], [Password], [Counter]) VALUES (1, N'Kristoffer', N'1234', 0)
INSERT INTO [dbo].[Users] ([Id], [Name], [Password], [Counter]) VALUES (2, N'Gæst', N'1234', 0)
INSERT INTO [dbo].[Users] ([Id], [Name], [Password], [Counter]) VALUES (3, N'Uden', N'1234', 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO