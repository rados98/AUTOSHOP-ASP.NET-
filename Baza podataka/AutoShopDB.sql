USE [master]
GO
/****** Object:  Database [AutoShop]    Script Date: 15.5.2020. 15:59:19 ******/
CREATE DATABASE [AutoShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AutoShop', FILENAME = N'd:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\AutoShop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AutoShop_log', FILENAME = N'd:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\AutoShop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [AutoShop] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AutoShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AutoShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AutoShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AutoShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AutoShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AutoShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [AutoShop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AutoShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AutoShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AutoShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AutoShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AutoShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AutoShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AutoShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AutoShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AutoShop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AutoShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AutoShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AutoShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AutoShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AutoShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AutoShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AutoShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AutoShop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AutoShop] SET  MULTI_USER 
GO
ALTER DATABASE [AutoShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AutoShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AutoShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AutoShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AutoShop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AutoShop] SET QUERY_STORE = OFF
GO
USE [AutoShop]
GO
/****** Object:  Table [dbo].[AutoDeo]    Script Date: 15.5.2020. 15:59:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AutoDeo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](50) NOT NULL,
	[Proizvodjac] [nvarchar](50) NOT NULL,
	[GodProizvodnje] [nvarchar](50) NOT NULL,
	[JedCena] [float] NOT NULL,
	[Opis] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_AutoDeo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AutoDeo_Magacin]    Script Date: 15.5.2020. 15:59:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AutoDeo_Magacin](
	[IDMagacin] [int] NOT NULL,
	[IDAutoDeo] [int] NOT NULL,
	[Stanje] [int] NOT NULL,
 CONSTRAINT [PK_AutoDeo_Magacin] PRIMARY KEY CLUSTERED 
(
	[IDMagacin] ASC,
	[IDAutoDeo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Magacin]    Script Date: 15.5.2020. 15:59:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Magacin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Grad] [nvarchar](50) NOT NULL,
	[Adresa] [nvarchar](150) NOT NULL,
	[Velicina] [nvarchar](50) NULL,
 CONSTRAINT [PK_Magacin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Racun]    Script Date: 15.5.2020. 15:59:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Racun](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Datum] [date] NOT NULL,
	[Vreme] [time](7) NOT NULL,
	[UkupnaVrednost] [float] NOT NULL,
 CONSTRAINT [PK_Racun] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 15.5.2020. 15:59:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role_User]    Script Date: 15.5.2020. 15:59:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role_User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDRole] [int] NOT NULL,
	[IDUser] [int] NOT NULL,
 CONSTRAINT [PK_Role_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StavkaRacuna]    Script Date: 15.5.2020. 15:59:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StavkaRacuna](
	[IDRacuna] [int] NOT NULL,
	[IDStavkaRacuna] [int] IDENTITY(1,1) NOT NULL,
	[IDMagacin] [int] NOT NULL,
	[IDAutoDeo] [int] NOT NULL,
	[Kolicina] [int] NOT NULL,
	[JedCena] [float] NOT NULL,
	[Vrednost] [float] NOT NULL,
 CONSTRAINT [PK_StavkaRacuna] PRIMARY KEY CLUSTERED 
(
	[IDRacuna] ASC,
	[IDStavkaRacuna] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UnosMagacin]    Script Date: 15.5.2020. 15:59:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnosMagacin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDMagacin] [int] NOT NULL,
	[IDAutoDeo] [int] NOT NULL,
	[Kolicina] [int] NOT NULL,
	[Datum] [date] NULL,
	[Vreme] [time](7) NULL,
 CONSTRAINT [PK_UnosMagacin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 15.5.2020. 15:59:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AutoDeo] ON 

INSERT [dbo].[AutoDeo] ([ID], [Naziv], [Proizvodjac], [GodProizvodnje], [JedCena], [Opis]) VALUES (1, N'Zupcasti kais', N'audi', N'2019', 2500, N'Kvalitetan zupcasti kais')
INSERT [dbo].[AutoDeo] ([ID], [Naziv], [Proizvodjac], [GodProizvodnje], [JedCena], [Opis]) VALUES (2, N'Cilindar menjaca', N'Peugeot', N'2010', 5000, N'Ovo je cilindar menjaca za peugeot')
INSERT [dbo].[AutoDeo] ([ID], [Naziv], [Proizvodjac], [GodProizvodnje], [JedCena], [Opis]) VALUES (3, N' DPF Filter', N'VW', N'2012', 25124, N'DPF filter za VW automobile')
INSERT [dbo].[AutoDeo] ([ID], [Naziv], [Proizvodjac], [GodProizvodnje], [JedCena], [Opis]) VALUES (4, N'Volan', N'Audi', N'2018', 12000, N'Volan za audi')
INSERT [dbo].[AutoDeo] ([ID], [Naziv], [Proizvodjac], [GodProizvodnje], [JedCena], [Opis]) VALUES (5, N'Amortizeri', N'Peugeot', N'2012', 2600, N'Amortizeri u paru za peugeot')
INSERT [dbo].[AutoDeo] ([ID], [Naziv], [Proizvodjac], [GodProizvodnje], [JedCena], [Opis]) VALUES (6, N'Zadnja poluosovina', N'Skoda', N'2018', 9000, N'Zadnja poluovina za skodu')
INSERT [dbo].[AutoDeo] ([ID], [Naziv], [Proizvodjac], [GodProizvodnje], [JedCena], [Opis]) VALUES (7, N'Prednji trap i solje', N'Opel', N'2015', 6500, N'Prednji trap i solje za opel')
INSERT [dbo].[AutoDeo] ([ID], [Naziv], [Proizvodjac], [GodProizvodnje], [JedCena], [Opis]) VALUES (8, N'Rucica za menjac', N'Citroen', N'2019', 2000, N'Rucica za menjac modela Citroen')
INSERT [dbo].[AutoDeo] ([ID], [Naziv], [Proizvodjac], [GodProizvodnje], [JedCena], [Opis]) VALUES (9, N'Instrument tabla', N'Skoda', N'2018', 5122, N'Intrument tabla za skodu')
INSERT [dbo].[AutoDeo] ([ID], [Naziv], [Proizvodjac], [GodProizvodnje], [JedCena], [Opis]) VALUES (1003, N'Volan trokraki', N'Citroen', N'2019', 1999, N'Ovo je trokraki volan za citroen')
INSERT [dbo].[AutoDeo] ([ID], [Naziv], [Proizvodjac], [GodProizvodnje], [JedCena], [Opis]) VALUES (1004, N'Bosch pumpa', N'VW', N'2019', 15000, N'Boshc pumpa za VW automobile')
SET IDENTITY_INSERT [dbo].[AutoDeo] OFF
GO
INSERT [dbo].[AutoDeo_Magacin] ([IDMagacin], [IDAutoDeo], [Stanje]) VALUES (1, 1, 18)
INSERT [dbo].[AutoDeo_Magacin] ([IDMagacin], [IDAutoDeo], [Stanje]) VALUES (1, 2, 4)
INSERT [dbo].[AutoDeo_Magacin] ([IDMagacin], [IDAutoDeo], [Stanje]) VALUES (1, 3, 6)
INSERT [dbo].[AutoDeo_Magacin] ([IDMagacin], [IDAutoDeo], [Stanje]) VALUES (1, 4, 5)
INSERT [dbo].[AutoDeo_Magacin] ([IDMagacin], [IDAutoDeo], [Stanje]) VALUES (1, 5, 2)
INSERT [dbo].[AutoDeo_Magacin] ([IDMagacin], [IDAutoDeo], [Stanje]) VALUES (1, 6, 2)
INSERT [dbo].[AutoDeo_Magacin] ([IDMagacin], [IDAutoDeo], [Stanje]) VALUES (1, 7, 50)
INSERT [dbo].[AutoDeo_Magacin] ([IDMagacin], [IDAutoDeo], [Stanje]) VALUES (1, 8, 123)
INSERT [dbo].[AutoDeo_Magacin] ([IDMagacin], [IDAutoDeo], [Stanje]) VALUES (1, 9, 6)
INSERT [dbo].[AutoDeo_Magacin] ([IDMagacin], [IDAutoDeo], [Stanje]) VALUES (1, 1003, 1)
INSERT [dbo].[AutoDeo_Magacin] ([IDMagacin], [IDAutoDeo], [Stanje]) VALUES (1, 1004, 3)
GO
SET IDENTITY_INSERT [dbo].[Magacin] ON 

INSERT [dbo].[Magacin] ([ID], [Grad], [Adresa], [Velicina]) VALUES (1, N'Smederevo', N'Karadjordjeva 2', N'1500m2')
SET IDENTITY_INSERT [dbo].[Magacin] OFF
GO
SET IDENTITY_INSERT [dbo].[Racun] ON 

INSERT [dbo].[Racun] ([ID], [Datum], [Vreme], [UkupnaVrednost]) VALUES (2, CAST(N'2020-04-04' AS Date), CAST(N'20:12:56.1140080' AS Time), 39000)
INSERT [dbo].[Racun] ([ID], [Datum], [Vreme], [UkupnaVrednost]) VALUES (3, CAST(N'2020-04-04' AS Date), CAST(N'22:12:11.0793156' AS Time), 54498)
INSERT [dbo].[Racun] ([ID], [Datum], [Vreme], [UkupnaVrednost]) VALUES (1002, CAST(N'2020-04-05' AS Date), CAST(N'17:13:31.6762863' AS Time), 50000)
INSERT [dbo].[Racun] ([ID], [Datum], [Vreme], [UkupnaVrednost]) VALUES (1003, CAST(N'2020-04-05' AS Date), CAST(N'17:18:15.5656649' AS Time), 5000)
INSERT [dbo].[Racun] ([ID], [Datum], [Vreme], [UkupnaVrednost]) VALUES (1004, CAST(N'2020-04-07' AS Date), CAST(N'18:53:57.8085226' AS Time), 25124)
INSERT [dbo].[Racun] ([ID], [Datum], [Vreme], [UkupnaVrednost]) VALUES (1005, CAST(N'2020-04-07' AS Date), CAST(N'19:08:09.1149045' AS Time), 67748)
SET IDENTITY_INSERT [dbo].[Racun] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([ID], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([ID], [Name]) VALUES (2, N'Super admin')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Role_User] ON 

INSERT [dbo].[Role_User] ([ID], [IDRole], [IDUser]) VALUES (1, 1, 3)
INSERT [dbo].[Role_User] ([ID], [IDRole], [IDUser]) VALUES (2, 2, 1)
SET IDENTITY_INSERT [dbo].[Role_User] OFF
GO
SET IDENTITY_INSERT [dbo].[StavkaRacuna] ON 

INSERT [dbo].[StavkaRacuna] ([IDRacuna], [IDStavkaRacuna], [IDMagacin], [IDAutoDeo], [Kolicina], [JedCena], [Vrednost]) VALUES (2, 1, 1, 2, 3, 5000, 15000)
INSERT [dbo].[StavkaRacuna] ([IDRacuna], [IDStavkaRacuna], [IDMagacin], [IDAutoDeo], [Kolicina], [JedCena], [Vrednost]) VALUES (2, 2, 1, 4, 2, 12000, 24000)
INSERT [dbo].[StavkaRacuna] ([IDRacuna], [IDStavkaRacuna], [IDMagacin], [IDAutoDeo], [Kolicina], [JedCena], [Vrednost]) VALUES (3, 3, 1, 1, 7, 2500, 17500)
INSERT [dbo].[StavkaRacuna] ([IDRacuna], [IDStavkaRacuna], [IDMagacin], [IDAutoDeo], [Kolicina], [JedCena], [Vrednost]) VALUES (3, 4, 1, 1003, 2, 1999, 3998)
INSERT [dbo].[StavkaRacuna] ([IDRacuna], [IDStavkaRacuna], [IDMagacin], [IDAutoDeo], [Kolicina], [JedCena], [Vrednost]) VALUES (3, 5, 1, 4, 2, 12000, 24000)
INSERT [dbo].[StavkaRacuna] ([IDRacuna], [IDStavkaRacuna], [IDMagacin], [IDAutoDeo], [Kolicina], [JedCena], [Vrednost]) VALUES (3, 6, 1, 6, 1, 9000, 9000)
INSERT [dbo].[StavkaRacuna] ([IDRacuna], [IDStavkaRacuna], [IDMagacin], [IDAutoDeo], [Kolicina], [JedCena], [Vrednost]) VALUES (1002, 1002, 1, 1004, 3, 15000, 45000)
INSERT [dbo].[StavkaRacuna] ([IDRacuna], [IDStavkaRacuna], [IDMagacin], [IDAutoDeo], [Kolicina], [JedCena], [Vrednost]) VALUES (1002, 1003, 1, 1, 2, 2500, 5000)
INSERT [dbo].[StavkaRacuna] ([IDRacuna], [IDStavkaRacuna], [IDMagacin], [IDAutoDeo], [Kolicina], [JedCena], [Vrednost]) VALUES (1003, 1004, 1, 2, 1, 5000, 5000)
INSERT [dbo].[StavkaRacuna] ([IDRacuna], [IDStavkaRacuna], [IDMagacin], [IDAutoDeo], [Kolicina], [JedCena], [Vrednost]) VALUES (1004, 1005, 1, 3, 1, 25124, 25124)
INSERT [dbo].[StavkaRacuna] ([IDRacuna], [IDStavkaRacuna], [IDMagacin], [IDAutoDeo], [Kolicina], [JedCena], [Vrednost]) VALUES (1005, 1006, 1, 1, 3, 2500, 7500)
INSERT [dbo].[StavkaRacuna] ([IDRacuna], [IDStavkaRacuna], [IDMagacin], [IDAutoDeo], [Kolicina], [JedCena], [Vrednost]) VALUES (1005, 1007, 1, 2, 2, 5000, 10000)
INSERT [dbo].[StavkaRacuna] ([IDRacuna], [IDStavkaRacuna], [IDMagacin], [IDAutoDeo], [Kolicina], [JedCena], [Vrednost]) VALUES (1005, 1008, 1, 3, 2, 25124, 50248)
SET IDENTITY_INSERT [dbo].[StavkaRacuna] OFF
GO
SET IDENTITY_INSERT [dbo].[UnosMagacin] ON 

INSERT [dbo].[UnosMagacin] ([ID], [IDMagacin], [IDAutoDeo], [Kolicina], [Datum], [Vreme]) VALUES (1, 1, 1, 2, CAST(N'2020-03-31' AS Date), CAST(N'00:00:00' AS Time))
INSERT [dbo].[UnosMagacin] ([ID], [IDMagacin], [IDAutoDeo], [Kolicina], [Datum], [Vreme]) VALUES (3, 1, 2, 1, CAST(N'2020-04-01' AS Date), CAST(N'16:15:17.8841001' AS Time))
INSERT [dbo].[UnosMagacin] ([ID], [IDMagacin], [IDAutoDeo], [Kolicina], [Datum], [Vreme]) VALUES (4, 1, 2, 10, CAST(N'2020-04-01' AS Date), CAST(N'16:29:13.6714687' AS Time))
INSERT [dbo].[UnosMagacin] ([ID], [IDMagacin], [IDAutoDeo], [Kolicina], [Datum], [Vreme]) VALUES (5, 1, 2, 10, CAST(N'2020-04-01' AS Date), CAST(N'16:30:02.6597631' AS Time))
INSERT [dbo].[UnosMagacin] ([ID], [IDMagacin], [IDAutoDeo], [Kolicina], [Datum], [Vreme]) VALUES (6, 1, 2, 10, CAST(N'2020-04-01' AS Date), CAST(N'16:35:11.6604680' AS Time))
INSERT [dbo].[UnosMagacin] ([ID], [IDMagacin], [IDAutoDeo], [Kolicina], [Datum], [Vreme]) VALUES (7, 1, 3, 9, CAST(N'2020-04-01' AS Date), CAST(N'16:40:15.5435851' AS Time))
INSERT [dbo].[UnosMagacin] ([ID], [IDMagacin], [IDAutoDeo], [Kolicina], [Datum], [Vreme]) VALUES (8, 1, 3, 9, CAST(N'2020-04-01' AS Date), CAST(N'16:44:28.2552340' AS Time))
INSERT [dbo].[UnosMagacin] ([ID], [IDMagacin], [IDAutoDeo], [Kolicina], [Datum], [Vreme]) VALUES (9, 1, 1003, 3, CAST(N'2020-04-02' AS Date), CAST(N'16:07:44.7591592' AS Time))
INSERT [dbo].[UnosMagacin] ([ID], [IDMagacin], [IDAutoDeo], [Kolicina], [Datum], [Vreme]) VALUES (10, 1, 1004, 10, CAST(N'2020-04-05' AS Date), CAST(N'17:12:24.7579136' AS Time))
INSERT [dbo].[UnosMagacin] ([ID], [IDMagacin], [IDAutoDeo], [Kolicina], [Datum], [Vreme]) VALUES (11, 1, 1, 1, CAST(N'2020-04-07' AS Date), CAST(N'01:03:03.6446802' AS Time))
INSERT [dbo].[UnosMagacin] ([ID], [IDMagacin], [IDAutoDeo], [Kolicina], [Datum], [Vreme]) VALUES (12, 1, 1004, 2, CAST(N'2020-04-07' AS Date), CAST(N'01:44:25.9897201' AS Time))
INSERT [dbo].[UnosMagacin] ([ID], [IDMagacin], [IDAutoDeo], [Kolicina], [Datum], [Vreme]) VALUES (14, 1, 1004, 3, CAST(N'2020-04-07' AS Date), CAST(N'18:53:34.8293564' AS Time))
INSERT [dbo].[UnosMagacin] ([ID], [IDMagacin], [IDAutoDeo], [Kolicina], [Datum], [Vreme]) VALUES (15, 1, 1, 2, CAST(N'2020-04-07' AS Date), CAST(N'19:07:02.9544104' AS Time))
SET IDENTITY_INSERT [dbo].[UnosMagacin] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [Name], [Email], [Password]) VALUES (1, N'Rados', N'rados@gmail.com', N'123')
INSERT [dbo].[User] ([ID], [Name], [Email], [Password]) VALUES (3, N'Nemanja', N'nemanja@gmail.com', N'111')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[AutoDeo_Magacin]  WITH CHECK ADD  CONSTRAINT [FK_AutoDeo_Magacin_AutoDeo] FOREIGN KEY([IDAutoDeo])
REFERENCES [dbo].[AutoDeo] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AutoDeo_Magacin] CHECK CONSTRAINT [FK_AutoDeo_Magacin_AutoDeo]
GO
ALTER TABLE [dbo].[AutoDeo_Magacin]  WITH CHECK ADD  CONSTRAINT [FK_AutoDeo_Magacin_AutoDeo_Magacin] FOREIGN KEY([IDMagacin])
REFERENCES [dbo].[Magacin] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AutoDeo_Magacin] CHECK CONSTRAINT [FK_AutoDeo_Magacin_AutoDeo_Magacin]
GO
ALTER TABLE [dbo].[Role_User]  WITH CHECK ADD  CONSTRAINT [FK_Role_User_Role] FOREIGN KEY([IDRole])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[Role_User] CHECK CONSTRAINT [FK_Role_User_Role]
GO
ALTER TABLE [dbo].[Role_User]  WITH CHECK ADD  CONSTRAINT [FK_Role_User_User] FOREIGN KEY([IDUser])
REFERENCES [dbo].[User] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Role_User] CHECK CONSTRAINT [FK_Role_User_User]
GO
ALTER TABLE [dbo].[StavkaRacuna]  WITH CHECK ADD  CONSTRAINT [FK_StavkaRacuna_AutoDeo_Magacin] FOREIGN KEY([IDMagacin], [IDAutoDeo])
REFERENCES [dbo].[AutoDeo_Magacin] ([IDMagacin], [IDAutoDeo])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StavkaRacuna] CHECK CONSTRAINT [FK_StavkaRacuna_AutoDeo_Magacin]
GO
ALTER TABLE [dbo].[StavkaRacuna]  WITH CHECK ADD  CONSTRAINT [FK_StavkaRacuna_Racun] FOREIGN KEY([IDRacuna])
REFERENCES [dbo].[Racun] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StavkaRacuna] CHECK CONSTRAINT [FK_StavkaRacuna_Racun]
GO
ALTER TABLE [dbo].[UnosMagacin]  WITH CHECK ADD  CONSTRAINT [FK_UnosMagacin_AutoDeo_Magacin] FOREIGN KEY([IDMagacin], [IDAutoDeo])
REFERENCES [dbo].[AutoDeo_Magacin] ([IDMagacin], [IDAutoDeo])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UnosMagacin] CHECK CONSTRAINT [FK_UnosMagacin_AutoDeo_Magacin]
GO
USE [master]
GO
ALTER DATABASE [AutoShop] SET  READ_WRITE 
GO
