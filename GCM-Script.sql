USE [master]
GO
/****** Object:  Database [GamesCollectionManagment]    Script Date: 12/5/2024 6:40:42 PM ******/
CREATE DATABASE [GamesCollectionManagment]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GamesCollectionManagment', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\GamesCollectionManagment.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GamesCollectionManagment_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\GamesCollectionManagment_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [GamesCollectionManagment] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GamesCollectionManagment].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GamesCollectionManagment] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GamesCollectionManagment] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GamesCollectionManagment] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GamesCollectionManagment] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GamesCollectionManagment] SET ARITHABORT OFF 
GO
ALTER DATABASE [GamesCollectionManagment] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GamesCollectionManagment] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GamesCollectionManagment] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GamesCollectionManagment] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GamesCollectionManagment] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GamesCollectionManagment] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GamesCollectionManagment] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GamesCollectionManagment] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GamesCollectionManagment] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GamesCollectionManagment] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GamesCollectionManagment] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GamesCollectionManagment] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GamesCollectionManagment] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GamesCollectionManagment] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GamesCollectionManagment] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GamesCollectionManagment] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GamesCollectionManagment] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GamesCollectionManagment] SET RECOVERY FULL 
GO
ALTER DATABASE [GamesCollectionManagment] SET  MULTI_USER 
GO
ALTER DATABASE [GamesCollectionManagment] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GamesCollectionManagment] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GamesCollectionManagment] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GamesCollectionManagment] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GamesCollectionManagment] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GamesCollectionManagment] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'GamesCollectionManagment', N'ON'
GO
ALTER DATABASE [GamesCollectionManagment] SET QUERY_STORE = OFF
GO
USE [GamesCollectionManagment]
GO
/****** Object:  Table [dbo].[GameManagment]    Script Date: 12/5/2024 6:40:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GameManagment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GameTitle] [nvarchar](100) NOT NULL,
	[GamePublisher] [nvarchar](100) NULL,
	[GameReleaseDate] [date] NULL,
	[GameGenres] [nvarchar](200) NULL,
	[GamePlatforms] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserOwnedGame]    Script Date: 12/5/2024 6:40:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserOwnedGame](
	[UserID] [int] NOT NULL,
	[Id] [int] NOT NULL,
	[GameOwned] [bit] NOT NULL,
 CONSTRAINT [UC_UserOwned] UNIQUE NONCLUSTERED 
(
	[UserID] ASC,
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/5/2024 6:40:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](256) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserWishlist]    Script Date: 12/5/2024 6:40:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserWishlist](
	[UserID] [int] NOT NULL,
	[Id] [int] NOT NULL,
 CONSTRAINT [UC_UserWishlist] UNIQUE NONCLUSTERED 
(
	[UserID] ASC,
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UserOwnedGame] ADD  DEFAULT ((1)) FOR [GameOwned]
GO
ALTER TABLE [dbo].[UserOwnedGame]  WITH CHECK ADD  CONSTRAINT [FK_UserOwned_GameId] FOREIGN KEY([Id])
REFERENCES [dbo].[GameManagment] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserOwnedGame] CHECK CONSTRAINT [FK_UserOwned_GameId]
GO
ALTER TABLE [dbo].[UserOwnedGame]  WITH CHECK ADD  CONSTRAINT [FK_UserOwned_UserId] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserOwnedGame] CHECK CONSTRAINT [FK_UserOwned_UserId]
GO
ALTER TABLE [dbo].[UserOwnedGame]  WITH CHECK ADD  CONSTRAINT [FK_UserOwnedGame_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[UserOwnedGame] CHECK CONSTRAINT [FK_UserOwnedGame_User]
GO
ALTER TABLE [dbo].[UserWishlist]  WITH CHECK ADD  CONSTRAINT [FK_UserWishlist_GameId] FOREIGN KEY([Id])
REFERENCES [dbo].[GameManagment] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserWishlist] CHECK CONSTRAINT [FK_UserWishlist_GameId]
GO
ALTER TABLE [dbo].[UserWishlist]  WITH CHECK ADD  CONSTRAINT [FK_UserWishlist_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[UserWishlist] CHECK CONSTRAINT [FK_UserWishlist_User]
GO
ALTER TABLE [dbo].[UserWishlist]  WITH CHECK ADD  CONSTRAINT [FK_UserWishlist_UserId] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserWishlist] CHECK CONSTRAINT [FK_UserWishlist_UserId]
GO
USE [master]
GO
ALTER DATABASE [GamesCollectionManagment] SET  READ_WRITE 
GO
