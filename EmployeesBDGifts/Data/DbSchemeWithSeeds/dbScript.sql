USE [master]
GO
/****** Object:  Database [EmployeeBDGifts]    Script Date: 18/04/2020 14:58:05 ******/
CREATE DATABASE [EmployeeBDGifts]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EmployeeBDGifts', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\EmployeeBDGifts.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EmployeeBDGifts_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\EmployeeBDGifts_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [EmployeeBDGifts] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmployeeBDGifts].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EmployeeBDGifts] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmployeeBDGifts] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmployeeBDGifts] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmployeeBDGifts] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmployeeBDGifts] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmployeeBDGifts] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EmployeeBDGifts] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmployeeBDGifts] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmployeeBDGifts] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmployeeBDGifts] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmployeeBDGifts] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmployeeBDGifts] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmployeeBDGifts] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmployeeBDGifts] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmployeeBDGifts] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EmployeeBDGifts] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmployeeBDGifts] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmployeeBDGifts] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EmployeeBDGifts] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EmployeeBDGifts] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmployeeBDGifts] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EmployeeBDGifts] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EmployeeBDGifts] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EmployeeBDGifts] SET  MULTI_USER 
GO
ALTER DATABASE [EmployeeBDGifts] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EmployeeBDGifts] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EmployeeBDGifts] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EmployeeBDGifts] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EmployeeBDGifts] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EmployeeBDGifts] SET QUERY_STORE = OFF
GO
USE [EmployeeBDGifts]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 18/04/2020 14:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gifts]    Script Date: 18/04/2020 14:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gifts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Gifts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 18/04/2020 14:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Bday] [datetime2](7) NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserVotes]    Script Date: 18/04/2020 14:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserVotes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[VoteId] [int] NOT NULL,
 CONSTRAINT [PK_UserVotes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Votes]    Script Date: 18/04/2020 14:58:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Votes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[GiftId] [int] NOT NULL,
	[Year] [int] NOT NULL,
	[OwnerId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[VoteEnded] [bit] NOT NULL,
 CONSTRAINT [PK_Votes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200417081946_AddUser', N'2.1.8-servicing-32085')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200417094736_AddGiftsAndPropsTOUser', N'2.1.8-servicing-32085')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200417103244_AddGifts', N'2.1.8-servicing-32085')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200417113741_addVoteTable', N'2.1.8-servicing-32085')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200417115717_addQuantityToVotesAndUserVoteTable', N'2.1.8-servicing-32085')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200418113723_addVoteEndedToVotes', N'2.1.8-servicing-32085')
SET IDENTITY_INSERT [dbo].[Gifts] ON 

INSERT [dbo].[Gifts] ([Id], [Name]) VALUES (1, N'Gift0')
INSERT [dbo].[Gifts] ([Id], [Name]) VALUES (2, N'Gift17')
INSERT [dbo].[Gifts] ([Id], [Name]) VALUES (3, N'Gift16')
INSERT [dbo].[Gifts] ([Id], [Name]) VALUES (4, N'Gift15')
INSERT [dbo].[Gifts] ([Id], [Name]) VALUES (5, N'Gift14')
INSERT [dbo].[Gifts] ([Id], [Name]) VALUES (6, N'Gift13')
INSERT [dbo].[Gifts] ([Id], [Name]) VALUES (7, N'Gift12')
INSERT [dbo].[Gifts] ([Id], [Name]) VALUES (8, N'Gift11')
INSERT [dbo].[Gifts] ([Id], [Name]) VALUES (9, N'Gift10')
INSERT [dbo].[Gifts] ([Id], [Name]) VALUES (10, N'Gift9')
INSERT [dbo].[Gifts] ([Id], [Name]) VALUES (11, N'Gift8')
INSERT [dbo].[Gifts] ([Id], [Name]) VALUES (12, N'Gift7')
INSERT [dbo].[Gifts] ([Id], [Name]) VALUES (13, N'Gift6')
INSERT [dbo].[Gifts] ([Id], [Name]) VALUES (14, N'Gift5')
INSERT [dbo].[Gifts] ([Id], [Name]) VALUES (15, N'Gift4')
INSERT [dbo].[Gifts] ([Id], [Name]) VALUES (16, N'Gift3')
INSERT [dbo].[Gifts] ([Id], [Name]) VALUES (17, N'Gift2')
INSERT [dbo].[Gifts] ([Id], [Name]) VALUES (18, N'Gift1')
INSERT [dbo].[Gifts] ([Id], [Name]) VALUES (19, N'Gift18')
INSERT [dbo].[Gifts] ([Id], [Name]) VALUES (20, N'Gift19')
SET IDENTITY_INSERT [dbo].[Gifts] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Name], [Password], [Bday], [UserName]) VALUES (22, N'Employee0', N'password0', CAST(N'2000-04-17T13:33:57.5606989' AS DateTime2), N'UserName0')
INSERT [dbo].[Users] ([Id], [Name], [Password], [Bday], [UserName]) VALUES (23, N'Employee17', N'password17', CAST(N'2001-09-17T13:33:57.5641370' AS DateTime2), N'UserName17')
INSERT [dbo].[Users] ([Id], [Name], [Password], [Bday], [UserName]) VALUES (24, N'Employee16', N'password16', CAST(N'2001-08-17T13:33:57.5641363' AS DateTime2), N'UserName16')
INSERT [dbo].[Users] ([Id], [Name], [Password], [Bday], [UserName]) VALUES (25, N'Employee15', N'password15', CAST(N'2001-07-17T13:33:57.5641357' AS DateTime2), N'UserName15')
INSERT [dbo].[Users] ([Id], [Name], [Password], [Bday], [UserName]) VALUES (26, N'Employee14', N'password14', CAST(N'2001-06-17T13:33:57.5641352' AS DateTime2), N'UserName14')
INSERT [dbo].[Users] ([Id], [Name], [Password], [Bday], [UserName]) VALUES (27, N'Employee13', N'password13', CAST(N'2001-05-17T13:33:57.5641346' AS DateTime2), N'UserName13')
INSERT [dbo].[Users] ([Id], [Name], [Password], [Bday], [UserName]) VALUES (28, N'Employee12', N'password12', CAST(N'2001-04-17T13:33:57.5641340' AS DateTime2), N'UserName12')
INSERT [dbo].[Users] ([Id], [Name], [Password], [Bday], [UserName]) VALUES (29, N'Employee11', N'password11', CAST(N'2001-03-17T13:33:57.5641335' AS DateTime2), N'UserName11')
INSERT [dbo].[Users] ([Id], [Name], [Password], [Bday], [UserName]) VALUES (30, N'Employee10', N'password10', CAST(N'2001-02-17T13:33:57.5641329' AS DateTime2), N'UserName10')
INSERT [dbo].[Users] ([Id], [Name], [Password], [Bday], [UserName]) VALUES (31, N'Employee9', N'password9', CAST(N'2001-01-17T13:33:57.5641322' AS DateTime2), N'UserName9')
INSERT [dbo].[Users] ([Id], [Name], [Password], [Bday], [UserName]) VALUES (32, N'Employee8', N'password8', CAST(N'2000-12-17T13:33:57.5641314' AS DateTime2), N'UserName8')
INSERT [dbo].[Users] ([Id], [Name], [Password], [Bday], [UserName]) VALUES (33, N'Employee7', N'password7', CAST(N'2000-11-17T13:33:57.5641261' AS DateTime2), N'UserName7')
INSERT [dbo].[Users] ([Id], [Name], [Password], [Bday], [UserName]) VALUES (34, N'Employee6', N'password6', CAST(N'2000-10-17T13:33:57.5641255' AS DateTime2), N'UserName6')
INSERT [dbo].[Users] ([Id], [Name], [Password], [Bday], [UserName]) VALUES (35, N'Employee5', N'password5', CAST(N'2000-09-17T13:33:57.5641250' AS DateTime2), N'UserName5')
INSERT [dbo].[Users] ([Id], [Name], [Password], [Bday], [UserName]) VALUES (36, N'Employee4', N'password4', CAST(N'2000-08-17T13:33:57.5641237' AS DateTime2), N'UserName4')
INSERT [dbo].[Users] ([Id], [Name], [Password], [Bday], [UserName]) VALUES (37, N'Employee3', N'password3', CAST(N'2000-07-17T13:33:57.5641232' AS DateTime2), N'UserName3')
INSERT [dbo].[Users] ([Id], [Name], [Password], [Bday], [UserName]) VALUES (38, N'Employee2', N'password2', CAST(N'2000-06-17T13:33:57.5641226' AS DateTime2), N'UserName2')
INSERT [dbo].[Users] ([Id], [Name], [Password], [Bday], [UserName]) VALUES (39, N'Employee1', N'password1', CAST(N'2000-05-17T13:33:57.5641208' AS DateTime2), N'UserName1')
INSERT [dbo].[Users] ([Id], [Name], [Password], [Bday], [UserName]) VALUES (40, N'Employee18', N'password18', CAST(N'2001-10-17T13:33:57.5641376' AS DateTime2), N'UserName18')
INSERT [dbo].[Users] ([Id], [Name], [Password], [Bday], [UserName]) VALUES (41, N'Employee19', N'password19', CAST(N'2001-11-17T13:33:57.5641381' AS DateTime2), N'UserName19')
INSERT [dbo].[Users] ([Id], [Name], [Password], [Bday], [UserName]) VALUES (44, N'aleh', N'123456', CAST(N'1993-04-09T22:22:00.0000000' AS DateTime2), N'donchev93')
SET IDENTITY_INSERT [dbo].[Users] OFF
SET IDENTITY_INSERT [dbo].[UserVotes] ON 

INSERT [dbo].[UserVotes] ([Id], [UserId], [VoteId]) VALUES (39, 44, 42)
INSERT [dbo].[UserVotes] ([Id], [UserId], [VoteId]) VALUES (40, 44, 43)
INSERT [dbo].[UserVotes] ([Id], [UserId], [VoteId]) VALUES (41, 39, 44)
INSERT [dbo].[UserVotes] ([Id], [UserId], [VoteId]) VALUES (42, 38, 45)
INSERT [dbo].[UserVotes] ([Id], [UserId], [VoteId]) VALUES (46, 37, 46)
INSERT [dbo].[UserVotes] ([Id], [UserId], [VoteId]) VALUES (47, 36, 45)
INSERT [dbo].[UserVotes] ([Id], [UserId], [VoteId]) VALUES (48, 35, 45)
INSERT [dbo].[UserVotes] ([Id], [UserId], [VoteId]) VALUES (49, 34, 45)
INSERT [dbo].[UserVotes] ([Id], [UserId], [VoteId]) VALUES (50, 33, 46)
INSERT [dbo].[UserVotes] ([Id], [UserId], [VoteId]) VALUES (51, 32, 47)
INSERT [dbo].[UserVotes] ([Id], [UserId], [VoteId]) VALUES (52, 31, 45)
INSERT [dbo].[UserVotes] ([Id], [UserId], [VoteId]) VALUES (54, 30, 48)
INSERT [dbo].[UserVotes] ([Id], [UserId], [VoteId]) VALUES (55, 30, 49)
INSERT [dbo].[UserVotes] ([Id], [UserId], [VoteId]) VALUES (59, 30, 53)
SET IDENTITY_INSERT [dbo].[UserVotes] OFF
SET IDENTITY_INSERT [dbo].[Votes] ON 

INSERT [dbo].[Votes] ([Id], [UserId], [GiftId], [Year], [OwnerId], [Quantity], [VoteEnded]) VALUES (42, 2, 2, 2021, 44, 1, 0)
INSERT [dbo].[Votes] ([Id], [UserId], [GiftId], [Year], [OwnerId], [Quantity], [VoteEnded]) VALUES (43, 2, 2, 2020, 44, 1, 0)
INSERT [dbo].[Votes] ([Id], [UserId], [GiftId], [Year], [OwnerId], [Quantity], [VoteEnded]) VALUES (44, 22, 1, 2020, 30, 1, 1)
INSERT [dbo].[Votes] ([Id], [UserId], [GiftId], [Year], [OwnerId], [Quantity], [VoteEnded]) VALUES (45, 22, 2, 2020, 30, 5, 1)
INSERT [dbo].[Votes] ([Id], [UserId], [GiftId], [Year], [OwnerId], [Quantity], [VoteEnded]) VALUES (46, 22, 3, 2020, 30, 2, 1)
INSERT [dbo].[Votes] ([Id], [UserId], [GiftId], [Year], [OwnerId], [Quantity], [VoteEnded]) VALUES (47, 22, 4, 2020, 30, 1, 1)
INSERT [dbo].[Votes] ([Id], [UserId], [GiftId], [Year], [OwnerId], [Quantity], [VoteEnded]) VALUES (48, 22, 5, 2020, 39, 1, 1)
INSERT [dbo].[Votes] ([Id], [UserId], [GiftId], [Year], [OwnerId], [Quantity], [VoteEnded]) VALUES (49, 23, 1, 2020, 30, 1, 1)
INSERT [dbo].[Votes] ([Id], [UserId], [GiftId], [Year], [OwnerId], [Quantity], [VoteEnded]) VALUES (53, 24, 4, 2029, 30, 1, 0)
SET IDENTITY_INSERT [dbo].[Votes] OFF
ALTER TABLE [dbo].[Users] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [Bday]
GO
ALTER TABLE [dbo].[Votes] ADD  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[Votes] ADD  DEFAULT ((0)) FOR [VoteEnded]
GO
USE [master]
GO
ALTER DATABASE [EmployeeBDGifts] SET  READ_WRITE 
GO
