USE [master]
GO
/****** Object:  Database [ScienceJourney]    Script Date: 10.07.2016 22:02:52 ******/
CREATE DATABASE [ScienceJourney]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ScienceJourney', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\ScienceJourney.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ScienceJourney_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\ScienceJourney_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ScienceJourney] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ScienceJourney].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ScienceJourney] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ScienceJourney] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ScienceJourney] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ScienceJourney] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ScienceJourney] SET ARITHABORT OFF 
GO
ALTER DATABASE [ScienceJourney] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ScienceJourney] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ScienceJourney] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ScienceJourney] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ScienceJourney] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ScienceJourney] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ScienceJourney] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ScienceJourney] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ScienceJourney] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ScienceJourney] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ScienceJourney] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ScienceJourney] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ScienceJourney] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ScienceJourney] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ScienceJourney] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ScienceJourney] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ScienceJourney] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ScienceJourney] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ScienceJourney] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ScienceJourney] SET  MULTI_USER 
GO
ALTER DATABASE [ScienceJourney] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ScienceJourney] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ScienceJourney] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ScienceJourney] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [ScienceJourney]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 10.07.2016 22:02:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[AddressID] [int] IDENTITY(1,1) NOT NULL,
	[City] [nvarchar](50) NULL,
	[PostCode] [nvarchar](50) NULL,
	[Country_Province_State] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[OtherDetails] [nvarchar](255) NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Artefacts]    Script Date: 10.07.2016 22:02:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artefacts](
	[ArtefactID] [int] IDENTITY(1,1) NOT NULL,
	[MuseumID] [int] NULL,
	[ArtefactName] [nvarchar](50) NULL,
	[ArtefactDescription] [nvarchar](255) NULL,
 CONSTRAINT [PK_Artefacts] PRIMARY KEY CLUSTERED 
(
	[ArtefactID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Articles]    Script Date: 10.07.2016 22:02:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articles](
	[ArticleID] [int] IDENTITY(1,1) NOT NULL,
	[MuseumID] [int] NULL,
	[ScientistID] [int] NULL,
	[ArtefactID] [int] NULL,
	[Article] [text] NULL,
	[createTime] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cities]    Script Date: 10.07.2016 22:02:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cities](
	[id] [int] NULL,
	[name] [varchar](50) NOT NULL,
	[country_id] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[countries]    Script Date: 10.07.2016 22:02:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[countries](
	[id] [int] NOT NULL,
	[sortname] [varchar](3) NOT NULL,
	[name] [varchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Member]    Script Date: 10.07.2016 22:02:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Member](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](25) NOT NULL,
	[last_name] [varchar](25) NOT NULL,
	[email] [varchar](80) NOT NULL,
	[password] [char](41) NOT NULL,
	[country] [int] NULL,
	[city] [int] NULL,
	[interests] [text] NULL,
	[Gender] [varchar](10) NULL,
	[createTime] [datetime] NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Museums]    Script Date: 10.07.2016 22:02:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Museums](
	[MuseumID] [int] IDENTITY(1,1) NOT NULL,
	[AddressID] [int] NULL,
	[Shop] [bit] NULL,
	[Smoking] [bit] NULL,
	[AnnualVisitorCount] [int] NULL,
	[DateBuilt] [datetime] NULL,
	[OpeningHours] [time](7) NULL,
	[MuseumName] [nvarchar](50) NULL,
	[MuseumDescription] [nvarchar](255) NULL,
 CONSTRAINT [PK_Museums] PRIMARY KEY CLUSTERED 
(
	[MuseumID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Scientist]    Script Date: 10.07.2016 22:02:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Scientist](
	[ScientistID] [int] NOT NULL,
	[LastName] [varchar](50) NULL,
	[FirstName] [varchar](50) NULL,
	[AddressID] [int] NULL,
	[Title] [varchar](50) NULL,
	[MiddleName] [varchar](50) NULL,
	[createTime] [datetime] NULL,
 CONSTRAINT [PK_Scientist] PRIMARY KEY CLUSTERED 
(
	[ScientistID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Artefacts]  WITH CHECK ADD  CONSTRAINT [FK_Artefacts_Museums] FOREIGN KEY([MuseumID])
REFERENCES [dbo].[Museums] ([MuseumID])
GO
ALTER TABLE [dbo].[Artefacts] CHECK CONSTRAINT [FK_Artefacts_Museums]
GO
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD  CONSTRAINT [FK_Articles_Artefacts] FOREIGN KEY([ArtefactID])
REFERENCES [dbo].[Artefacts] ([ArtefactID])
GO
ALTER TABLE [dbo].[Articles] CHECK CONSTRAINT [FK_Articles_Artefacts]
GO
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD  CONSTRAINT [FK_Articles_Museums] FOREIGN KEY([MuseumID])
REFERENCES [dbo].[Museums] ([MuseumID])
GO
ALTER TABLE [dbo].[Articles] CHECK CONSTRAINT [FK_Articles_Museums]
GO
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD  CONSTRAINT [FK_Articles_Scientist] FOREIGN KEY([ScientistID])
REFERENCES [dbo].[Scientist] ([ScientistID])
GO
ALTER TABLE [dbo].[Articles] CHECK CONSTRAINT [FK_Articles_Scientist]
GO
ALTER TABLE [dbo].[Museums]  WITH CHECK ADD  CONSTRAINT [FK_Museums_Addresses] FOREIGN KEY([AddressID])
REFERENCES [dbo].[Addresses] ([AddressID])
GO
ALTER TABLE [dbo].[Museums] CHECK CONSTRAINT [FK_Museums_Addresses]
GO
USE [master]
GO
ALTER DATABASE [ScienceJourney] SET  READ_WRITE 
GO
