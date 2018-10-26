USE [master]
GO

/****** Object:  Database [GearTracking]    Script Date: 8/29/2018 4:54:32 PM ******/
CREATE DATABASE [GearTracking]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GearTracking', FILENAME = N'D:\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\GearTracking.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GearTracking_log', FILENAME = N'D:\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\GearTracking_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

ALTER DATABASE [GearTracking] SET COMPATIBILITY_LEVEL = 140
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GearTracking].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [GearTracking] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [GearTracking] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [GearTracking] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [GearTracking] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [GearTracking] SET ARITHABORT OFF 
GO

ALTER DATABASE [GearTracking] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [GearTracking] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [GearTracking] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [GearTracking] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [GearTracking] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [GearTracking] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [GearTracking] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [GearTracking] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [GearTracking] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [GearTracking] SET  DISABLE_BROKER 
GO

ALTER DATABASE [GearTracking] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [GearTracking] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [GearTracking] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [GearTracking] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [GearTracking] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [GearTracking] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [GearTracking] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [GearTracking] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [GearTracking] SET  MULTI_USER 
GO

ALTER DATABASE [GearTracking] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [GearTracking] SET DB_CHAINING OFF 
GO

ALTER DATABASE [GearTracking] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [GearTracking] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [GearTracking] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [GearTracking] SET QUERY_STORE = OFF
GO

USE [GearTracking]
GO

ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO

ALTER DATABASE [GearTracking] SET  READ_WRITE 
GO


USE GearTracking
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Item
	(
	Id int NOT NULL IDENTITY (1, 1),
	Name varchar(50) NULL,
	Rfid varchar(MAX) NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Item ADD CONSTRAINT
	PK_Item PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Item SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.TrackingHistory
	(
	Id int NOT NULL IDENTITY (1, 1),
	ItemId int NOT NULL,
	CheckInDate datetime NOT NULL,
	CheckOutDate datetime NOT NULL,
	LocationID int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.TrackingHistory ADD CONSTRAINT
	PK_TrackingHistory PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.TrackingHistory SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Location
	(
	Id int NOT NULL IDENTITY (1, 1),
	Name varchar(50) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Location ADD CONSTRAINT
	PK_Location PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Location SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
GO