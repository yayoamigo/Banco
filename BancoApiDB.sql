USE [master]
GO
/****** Object:  Database [BancoDB]    Script Date: 8/9/2023 1:25:39 PM ******/
CREATE DATABASE [BancoDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BancoDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BancoDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BancoDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BancoDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BancoDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BancoDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BancoDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BancoDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BancoDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BancoDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BancoDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BancoDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BancoDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BancoDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BancoDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BancoDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BancoDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BancoDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BancoDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BancoDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BancoDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BancoDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BancoDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BancoDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BancoDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BancoDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BancoDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BancoDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BancoDB] SET RECOVERY FULL 
GO
ALTER DATABASE [BancoDB] SET  MULTI_USER 
GO
ALTER DATABASE [BancoDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BancoDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BancoDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BancoDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BancoDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BancoDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BancoDB', N'ON'
GO
ALTER DATABASE [BancoDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [BancoDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BancoDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 8/9/2023 1:25:39 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 8/9/2023 1:25:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[ClienteId] [int] NOT NULL,
	[Identificacion] [int] NOT NULL,
	[Contrasena] [nvarchar](255) NOT NULL,
	[Estado] [char](1) NULL,
	[Nombre] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuenta]    Script Date: 8/9/2023 1:25:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuenta](
	[NumeroCuenta] [int] NOT NULL,
	[ClienteId] [int] NOT NULL,
	[TipoCuenta] [char](10) NOT NULL,
	[SaldoInicial] [decimal](18, 2) NOT NULL,
	[Estado] [char](1) NULL,
	[Nombre] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[NumeroCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimientos]    Script Date: 8/9/2023 1:25:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimientos](
	[MovimientoId] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[TipoMovimiento] [char](10) NOT NULL,
	[Valor] [decimal](18, 2) NOT NULL,
	[Saldo] [decimal](18, 2) NULL,
	[NumeroCuenta] [int] NOT NULL,
	[saldo_inicial] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[MovimientoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 8/9/2023 1:25:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[Identificacion] [int] NOT NULL,
	[Nombre] [nvarchar](255) NOT NULL,
	[Genero] [char](1) NULL,
	[Edad] [int] NULL,
	[Direccion] [nvarchar](255) NULL,
	[Telefono] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Identificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD FOREIGN KEY([Identificacion])
REFERENCES [dbo].[Persona] ([Identificacion])
GO
ALTER TABLE [dbo].[Cuenta]  WITH CHECK ADD FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([ClienteId])
GO
ALTER TABLE [dbo].[Movimientos]  WITH CHECK ADD FOREIGN KEY([NumeroCuenta])
REFERENCES [dbo].[Cuenta] ([NumeroCuenta])
GO
/****** Object:  StoredProcedure [dbo].[RealizarMovimiento]    Script Date: 8/9/2023 1:25:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RealizarMovimiento]
    @NumeroCuenta INT,
    @Valor DECIMAL(18, 2),
    @TipoMovimiento CHAR(10)
AS
BEGIN
    --Buscar el saldo actual de la cuenta para ingresarlo como param
	DECLARE @SaldoInicialReal DECIMAL(18, 2);
    SELECT @SaldoInicialReal = SaldoInicial FROM Cuenta WHERE NumeroCuenta = @NumeroCuenta;
	
	-- Buscar el saldo actual de la cuenta
    DECLARE @SaldoActual DECIMAL(18, 2);
    SELECT @SaldoActual = SaldoInicial FROM Cuenta WHERE NumeroCuenta = @NumeroCuenta;

    -- Aplicar el movimiento al saldo actual (asumiendo crédito como positivo, débito como negativo)
    SET @SaldoActual = @SaldoActual + @Valor;

    -- Actualizar la tabla Cuenta con el nuevo saldo
    UPDATE Cuenta SET SaldoInicial = @SaldoActual WHERE NumeroCuenta = @NumeroCuenta;

    -- Insertar un registro en la tabla de Movimientos con los detalles del movimiento
    INSERT INTO Movimientos (Fecha, TipoMovimiento, Valor, Saldo, NumeroCuenta, saldo_inicial)
    VALUES (GETDATE(), @TipoMovimiento, @Valor, @SaldoActual, @NumeroCuenta, @SaldoInicialReal);
END;
GO
USE [master]
GO
ALTER DATABASE [BancoDB] SET  READ_WRITE 
GO
