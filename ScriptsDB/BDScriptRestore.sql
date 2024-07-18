USE [master]
GO
/****** Object:  Database [PTDoublePartners]    Script Date: 18/7/2024 15:00:52 ******/
CREATE DATABASE [PTDoublePartners]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PTDoublePartners', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\PTDoublePartners.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PTDoublePartners_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\PTDoublePartners_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PTDoublePartners] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PTDoublePartners].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PTDoublePartners] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PTDoublePartners] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PTDoublePartners] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PTDoublePartners] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PTDoublePartners] SET ARITHABORT OFF 
GO
ALTER DATABASE [PTDoublePartners] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PTDoublePartners] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PTDoublePartners] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PTDoublePartners] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PTDoublePartners] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PTDoublePartners] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PTDoublePartners] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PTDoublePartners] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PTDoublePartners] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PTDoublePartners] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PTDoublePartners] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PTDoublePartners] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PTDoublePartners] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PTDoublePartners] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PTDoublePartners] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PTDoublePartners] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PTDoublePartners] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PTDoublePartners] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PTDoublePartners] SET  MULTI_USER 
GO
ALTER DATABASE [PTDoublePartners] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PTDoublePartners] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PTDoublePartners] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PTDoublePartners] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PTDoublePartners] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PTDoublePartners] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PTDoublePartners] SET QUERY_STORE = OFF
GO
USE [PTDoublePartners]
GO
/****** Object:  User [AdminPartner]    Script Date: 18/7/2024 15:00:52 ******/
CREATE USER [AdminPartner] FOR LOGIN [AdminPartner] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [AdminPartner]
GO
/****** Object:  Table [dbo].[Personas]    Script Date: 18/7/2024 15:00:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personas](
	[Identificador] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [nvarchar](50) NULL,
	[Apellidos] [nvarchar](50) NULL,
	[NumeroIdentificacion] [nvarchar](20) NULL,
	[Email] [nvarchar](50) NULL,
	[TipoIdentificacion] [nvarchar](20) NULL,
	[FechaCreacion] [datetime] NULL,
	[NumeroIdentificacionConcatenado]  AS (([TipoIdentificacion]+' ')+[NumeroIdentificacion]) PERSISTED,
	[NombresApellidosConcatenados]  AS (([Nombres]+' ')+[Apellidos]) PERSISTED,
	[UsuarioId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Identificador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 18/7/2024 15:00:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Identificador] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [nvarchar](50) NULL,
	[Pass] [nvarchar](200) NULL,
	[FechaCreacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Identificador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Personas] ADD  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[Personas]  WITH CHECK ADD FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Identificador])
GO
/****** Object:  StoredProcedure [dbo].[sp_ConsultarPersonas]    Script Date: 18/7/2024 15:00:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Crear el procedimiento almacenado para consultar las personas
-- [dbo].[sp_ConsultarPersonas]
CREATE PROCEDURE [dbo].[sp_ConsultarPersonas]
AS
BEGIN
    SELECT 
        Identificador,
        Nombres,
        Apellidos,
        NumeroIdentificacion,
        Email,
        TipoIdentificacion,
        FechaCreacion,
        NumeroIdentificacionConcatenado,
        NombresApellidosConcatenados,
		UsuarioId
    FROM 
        Personas;
END;
GO
USE [master]
GO
ALTER DATABASE [PTDoublePartners] SET  READ_WRITE 
GO
