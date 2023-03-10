USE [master]
GO
/****** Object:  Database [CondominiosDB]    Script Date: 2/21/2023 10:52:14 PM ******/
CREATE DATABASE [CondominiosDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CondiminiosDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CondiminiosDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CondiminiosDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CondiminiosDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CondominiosDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CondominiosDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CondominiosDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CondominiosDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CondominiosDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CondominiosDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CondominiosDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CondominiosDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CondominiosDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CondominiosDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CondominiosDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CondominiosDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CondominiosDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CondominiosDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CondominiosDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CondominiosDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CondominiosDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CondominiosDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CondominiosDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CondominiosDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CondominiosDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CondominiosDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CondominiosDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CondominiosDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CondominiosDB] SET RECOVERY FULL 
GO
ALTER DATABASE [CondominiosDB] SET  MULTI_USER 
GO
ALTER DATABASE [CondominiosDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CondominiosDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CondominiosDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CondominiosDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CondominiosDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CondominiosDB', N'ON'
GO
ALTER DATABASE [CondominiosDB] SET QUERY_STORE = OFF
GO
USE [CondominiosDB]
GO
/****** Object:  Table [dbo].[AreaComun]    Script Date: 2/21/2023 10:52:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AreaComun](
	[Id] [int] NOT NULL,
	[Descripcion] [nvarchar](100) NULL,
	[HoraAbierto] [time](7) NOT NULL,
	[HoraCierre] [time](7) NOT NULL,
	[Borrado] [bit] NOT NULL,
 CONSTRAINT [PK_AreaComun] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CondicionResidencia]    Script Date: 2/21/2023 10:52:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CondicionResidencia](
	[Id] [int] NOT NULL,
	[Descripcion] [nvarchar](20) NOT NULL,
	[Borrado] [bit] NOT NULL,
 CONSTRAINT [PK_CondicionResidencia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Deuda]    Script Date: 2/21/2023 10:52:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deuda](
	[IdResidencia] [int] NOT NULL,
	[IdPlanCobro] [int] NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[PendientePago] [bit] NOT NULL,
	[MontoPagado] [money] NOT NULL,
	[Borrado] [bit] NOT NULL,
	[Id] [int] NOT NULL,
 CONSTRAINT [PK_Deuda] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadoIncidente]    Script Date: 2/21/2023 10:52:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoIncidente](
	[Id] [int] NOT NULL,
	[Descripcion] [nvarchar](20) NOT NULL,
	[Borrado] [bit] NOT NULL,
 CONSTRAINT [PK_EstadoIncidente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Incidente]    Script Date: 2/21/2023 10:52:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Incidente](
	[Id] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Titulo] [nvarchar](20) NOT NULL,
	[Descripcion] [nvarchar](200) NOT NULL,
	[Estado] [int] NOT NULL,
	[Borrado] [bit] NOT NULL,
 CONSTRAINT [PK_Incidente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Informacion]    Script Date: 2/21/2023 10:52:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Informacion](
	[Id] [int] NOT NULL,
	[Texto] [nvarchar](max) NOT NULL,
	[Doc1] [varbinary](max) NULL,
	[Doc2] [varbinary](max) NULL,
	[Doc3] [varbinary](max) NULL,
	[TipoInformacion] [int] NOT NULL,
	[Borrado] [bit] NOT NULL,
 CONSTRAINT [PK_Informacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlanCobro]    Script Date: 2/21/2023 10:52:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlanCobro](
	[Id] [int] NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
	[MontoTotal] [money] NOT NULL,
	[Borrado] [bit] NOT NULL,
 CONSTRAINT [PK_PlanCobro] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlanCobro_RubroCobro]    Script Date: 2/21/2023 10:52:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlanCobro_RubroCobro](
	[IdPlanCobro] [int] NOT NULL,
	[IdRubroCobro] [int] NOT NULL,
 CONSTRAINT [PK_PlanCobro_RubroCobro] PRIMARY KEY CLUSTERED 
(
	[IdPlanCobro] ASC,
	[IdRubroCobro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservacion]    Script Date: 2/21/2023 10:52:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservacion](
	[Id] [int] NOT NULL,
	[IdAreaComun] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[HoraInicio] [time](7) NOT NULL,
	[HoraFinal] [time](7) NOT NULL,
	[Borrado] [bit] NOT NULL,
 CONSTRAINT [PK_Reservacion_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[IdAreaComun] ASC,
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Residencia]    Script Date: 2/21/2023 10:52:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Residencia](
	[Id] [int] NOT NULL,
	[Propietario] [int] NOT NULL,
	[Habitantes] [tinyint] NOT NULL,
	[AnioConstrucion] [date] NULL,
	[Condicion] [int] NOT NULL,
	[Vehiculos] [tinyint] NOT NULL,
	[Borrado] [bit] NULL,
 CONSTRAINT [PK_Residencia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RubroCobro]    Script Date: 2/21/2023 10:52:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RubroCobro](
	[Id] [int] NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
	[Costo] [money] NOT NULL,
	[Borrado] [bit] NOT NULL,
 CONSTRAINT [PK_RubroCobro] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoInformacion]    Script Date: 2/21/2023 10:52:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoInformacion](
	[Id] [int] NOT NULL,
	[Descripcion] [nvarchar](20) NOT NULL,
	[Borrado] [bit] NOT NULL,
 CONSTRAINT [PK_TipoInformacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoUsuario]    Script Date: 2/21/2023 10:52:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoUsuario](
	[Id] [int] NOT NULL,
	[Descripcion] [nvarchar](20) NOT NULL,
	[Borrado] [bit] NOT NULL,
 CONSTRAINT [PK_TipoUsuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 2/21/2023 10:52:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] NOT NULL,
	[IdTipoUsuario] [int] NOT NULL,
	[Nombre] [nvarchar](20) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Cedula] [int] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Contrasenna] [nvarchar](10) NOT NULL,
	[Borrado] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CondicionResidencia] ([Id], [Descripcion], [Borrado]) VALUES (1, N'Habitada', 0)
INSERT [dbo].[CondicionResidencia] ([Id], [Descripcion], [Borrado]) VALUES (2, N'En construcción', 0)
GO
INSERT [dbo].[Deuda] ([IdResidencia], [IdPlanCobro], [Fecha], [PendientePago], [MontoPagado], [Borrado], [Id]) VALUES (1101, 1, CAST(N'2021-06-05T12:02:00' AS SmallDateTime), 0, 850.0000, 0, 1)
INSERT [dbo].[Deuda] ([IdResidencia], [IdPlanCobro], [Fecha], [PendientePago], [MontoPagado], [Borrado], [Id]) VALUES (1102, 2, CAST(N'2021-06-05T01:07:00' AS SmallDateTime), 0, 1300.0000, 0, 2)
INSERT [dbo].[Deuda] ([IdResidencia], [IdPlanCobro], [Fecha], [PendientePago], [MontoPagado], [Borrado], [Id]) VALUES (1103, 4, CAST(N'2021-06-05T10:10:00' AS SmallDateTime), 1, 800.0000, 0, 3)
INSERT [dbo].[Deuda] ([IdResidencia], [IdPlanCobro], [Fecha], [PendientePago], [MontoPagado], [Borrado], [Id]) VALUES (1104, 3, CAST(N'2021-06-05T02:30:00' AS SmallDateTime), 0, 1300.0000, 0, 4)
INSERT [dbo].[Deuda] ([IdResidencia], [IdPlanCobro], [Fecha], [PendientePago], [MontoPagado], [Borrado], [Id]) VALUES (1105, 4, CAST(N'2021-09-12T03:45:00' AS SmallDateTime), 1, 0.0000, 0, 5)
INSERT [dbo].[Deuda] ([IdResidencia], [IdPlanCobro], [Fecha], [PendientePago], [MontoPagado], [Borrado], [Id]) VALUES (1106, 2, CAST(N'2021-06-06T06:16:00' AS SmallDateTime), 1, 0.0000, 0, 6)
GO
INSERT [dbo].[PlanCobro] ([Id], [Descripcion], [MontoTotal], [Borrado]) VALUES (1, N'Mantenimiento de zonas verdes', 850.0000, 0)
INSERT [dbo].[PlanCobro] ([Id], [Descripcion], [MontoTotal], [Borrado]) VALUES (2, N'Limpieza de zonas comunes', 1300.0000, 0)
INSERT [dbo].[PlanCobro] ([Id], [Descripcion], [MontoTotal], [Borrado]) VALUES (3, N'Mantenimiento de infraestructura', 1300.0000, 0)
INSERT [dbo].[PlanCobro] ([Id], [Descripcion], [MontoTotal], [Borrado]) VALUES (4, N'Servicios de seguridad', 1600.0000, 0)
GO
INSERT [dbo].[PlanCobro_RubroCobro] ([IdPlanCobro], [IdRubroCobro]) VALUES (1, 1)
INSERT [dbo].[PlanCobro_RubroCobro] ([IdPlanCobro], [IdRubroCobro]) VALUES (1, 2)
INSERT [dbo].[PlanCobro_RubroCobro] ([IdPlanCobro], [IdRubroCobro]) VALUES (2, 3)
INSERT [dbo].[PlanCobro_RubroCobro] ([IdPlanCobro], [IdRubroCobro]) VALUES (2, 4)
INSERT [dbo].[PlanCobro_RubroCobro] ([IdPlanCobro], [IdRubroCobro]) VALUES (2, 5)
INSERT [dbo].[PlanCobro_RubroCobro] ([IdPlanCobro], [IdRubroCobro]) VALUES (2, 6)
INSERT [dbo].[PlanCobro_RubroCobro] ([IdPlanCobro], [IdRubroCobro]) VALUES (3, 7)
INSERT [dbo].[PlanCobro_RubroCobro] ([IdPlanCobro], [IdRubroCobro]) VALUES (3, 8)
INSERT [dbo].[PlanCobro_RubroCobro] ([IdPlanCobro], [IdRubroCobro]) VALUES (3, 9)
INSERT [dbo].[PlanCobro_RubroCobro] ([IdPlanCobro], [IdRubroCobro]) VALUES (3, 10)
INSERT [dbo].[PlanCobro_RubroCobro] ([IdPlanCobro], [IdRubroCobro]) VALUES (4, 11)
INSERT [dbo].[PlanCobro_RubroCobro] ([IdPlanCobro], [IdRubroCobro]) VALUES (4, 12)
INSERT [dbo].[PlanCobro_RubroCobro] ([IdPlanCobro], [IdRubroCobro]) VALUES (4, 13)
GO
INSERT [dbo].[Residencia] ([Id], [Propietario], [Habitantes], [AnioConstrucion], [Condicion], [Vehiculos], [Borrado]) VALUES (1101, 1, 4, CAST(N'2021-03-02' AS Date), 1, 2, 0)
INSERT [dbo].[Residencia] ([Id], [Propietario], [Habitantes], [AnioConstrucion], [Condicion], [Vehiculos], [Borrado]) VALUES (1102, 2, 2, CAST(N'2021-08-06' AS Date), 1, 2, 0)
INSERT [dbo].[Residencia] ([Id], [Propietario], [Habitantes], [AnioConstrucion], [Condicion], [Vehiculos], [Borrado]) VALUES (1103, 3, 6, CAST(N'2019-08-08' AS Date), 1, 3, 0)
INSERT [dbo].[Residencia] ([Id], [Propietario], [Habitantes], [AnioConstrucion], [Condicion], [Vehiculos], [Borrado]) VALUES (1104, 4, 1, CAST(N'2018-01-01' AS Date), 1, 1, 0)
INSERT [dbo].[Residencia] ([Id], [Propietario], [Habitantes], [AnioConstrucion], [Condicion], [Vehiculos], [Borrado]) VALUES (1105, 5, 0, CAST(N'2022-03-09' AS Date), 2, 0, 0)
INSERT [dbo].[Residencia] ([Id], [Propietario], [Habitantes], [AnioConstrucion], [Condicion], [Vehiculos], [Borrado]) VALUES (1106, 6, 0, CAST(N'2023-01-01' AS Date), 2, 0, 0)
GO
INSERT [dbo].[RubroCobro] ([Id], [Descripcion], [Costo], [Borrado]) VALUES (1, N'Corta de césped', 250.0000, 0)
INSERT [dbo].[RubroCobro] ([Id], [Descripcion], [Costo], [Borrado]) VALUES (2, N'Riego de zonas verdes', 600.0000, 0)
INSERT [dbo].[RubroCobro] ([Id], [Descripcion], [Costo], [Borrado]) VALUES (3, N'Limpieza de jardines', 300.0000, 0)
INSERT [dbo].[RubroCobro] ([Id], [Descripcion], [Costo], [Borrado]) VALUES (4, N'Limpieza de calles', 300.0000, 0)
INSERT [dbo].[RubroCobro] ([Id], [Descripcion], [Costo], [Borrado]) VALUES (5, N'Limpieza de área de juegos', 300.0000, 0)
INSERT [dbo].[RubroCobro] ([Id], [Descripcion], [Costo], [Borrado]) VALUES (6, N'Recolección de basura', 400.0000, 0)
INSERT [dbo].[RubroCobro] ([Id], [Descripcion], [Costo], [Borrado]) VALUES (7, N'Mantenimiento de  Gimnasio', 300.0000, 0)
INSERT [dbo].[RubroCobro] ([Id], [Descripcion], [Costo], [Borrado]) VALUES (8, N'Mantenimiento de Piscina', 300.0000, 0)
INSERT [dbo].[RubroCobro] ([Id], [Descripcion], [Costo], [Borrado]) VALUES (9, N'Mantenimiento de salón eventos', 300.0000, 0)
INSERT [dbo].[RubroCobro] ([Id], [Descripcion], [Costo], [Borrado]) VALUES (10, N'Mantenimiento de portones', 400.0000, 0)
INSERT [dbo].[RubroCobro] ([Id], [Descripcion], [Costo], [Borrado]) VALUES (11, N'Mantenimiento de sistema vigilancia', 400.0000, 0)
INSERT [dbo].[RubroCobro] ([Id], [Descripcion], [Costo], [Borrado]) VALUES (12, N'Mantenimiento de alumbrado', 500.0000, 0)
INSERT [dbo].[RubroCobro] ([Id], [Descripcion], [Costo], [Borrado]) VALUES (13, N'Pago de servicios de personal de seguridad', 700.0000, 0)
GO
INSERT [dbo].[TipoUsuario] ([Id], [Descripcion], [Borrado]) VALUES (1, N'Administrador', 0)
INSERT [dbo].[TipoUsuario] ([Id], [Descripcion], [Borrado]) VALUES (2, N'Regular', 0)
GO
INSERT [dbo].[Usuario] ([Id], [IdTipoUsuario], [Nombre], [Apellido], [Cedula], [Email], [Contrasenna], [Borrado]) VALUES (1, 1, N'Melanny', N'Vargas', 208080192, N'mvargas@gmail.com', N'm123456', 0)
INSERT [dbo].[Usuario] ([Id], [IdTipoUsuario], [Nombre], [Apellido], [Cedula], [Email], [Contrasenna], [Borrado]) VALUES (2, 1, N'Gabriel', N'Ulate', 208460544, N'gulate@gmail.com', N'g123456', 0)
INSERT [dbo].[Usuario] ([Id], [IdTipoUsuario], [Nombre], [Apellido], [Cedula], [Email], [Contrasenna], [Borrado]) VALUES (3, 2, N'María', N'Stefano', 204045632, N'mstefano@gmail.com', N'ms123456', 0)
INSERT [dbo].[Usuario] ([Id], [IdTipoUsuario], [Nombre], [Apellido], [Cedula], [Email], [Contrasenna], [Borrado]) VALUES (4, 2, N'Felipe', N'Faraj', 211136568, N'ffaraj@gmail.com', N'ff123456', 0)
INSERT [dbo].[Usuario] ([Id], [IdTipoUsuario], [Nombre], [Apellido], [Cedula], [Email], [Contrasenna], [Borrado]) VALUES (5, 2, N'Ronald', N'Castro', 506942532, N'rcastro@gmail.com', N'rc123456', 0)
INSERT [dbo].[Usuario] ([Id], [IdTipoUsuario], [Nombre], [Apellido], [Cedula], [Email], [Contrasenna], [Borrado]) VALUES (6, 2, N'Isabel', N'Celeste', 603285632, N'iceleste@gmail.com', N'ic123456', 0)
GO
ALTER TABLE [dbo].[Deuda]  WITH CHECK ADD  CONSTRAINT [FK_Deuda_PlanCobro] FOREIGN KEY([IdPlanCobro])
REFERENCES [dbo].[PlanCobro] ([Id])
GO
ALTER TABLE [dbo].[Deuda] CHECK CONSTRAINT [FK_Deuda_PlanCobro]
GO
ALTER TABLE [dbo].[Deuda]  WITH CHECK ADD  CONSTRAINT [FK_Deuda_Residencia] FOREIGN KEY([IdResidencia])
REFERENCES [dbo].[Residencia] ([Id])
GO
ALTER TABLE [dbo].[Deuda] CHECK CONSTRAINT [FK_Deuda_Residencia]
GO
ALTER TABLE [dbo].[Incidente]  WITH CHECK ADD  CONSTRAINT [FK_Incidente_EstadoIncidente] FOREIGN KEY([Estado])
REFERENCES [dbo].[EstadoIncidente] ([Id])
GO
ALTER TABLE [dbo].[Incidente] CHECK CONSTRAINT [FK_Incidente_EstadoIncidente]
GO
ALTER TABLE [dbo].[Incidente]  WITH CHECK ADD  CONSTRAINT [FK_Incidente_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Incidente] CHECK CONSTRAINT [FK_Incidente_Usuario]
GO
ALTER TABLE [dbo].[Informacion]  WITH CHECK ADD  CONSTRAINT [FK_Informacion_TipoInformacion] FOREIGN KEY([TipoInformacion])
REFERENCES [dbo].[TipoInformacion] ([Id])
GO
ALTER TABLE [dbo].[Informacion] CHECK CONSTRAINT [FK_Informacion_TipoInformacion]
GO
ALTER TABLE [dbo].[PlanCobro_RubroCobro]  WITH CHECK ADD  CONSTRAINT [FK_PlanCobro_RubroCobro_PlanCobro] FOREIGN KEY([IdPlanCobro])
REFERENCES [dbo].[PlanCobro] ([Id])
GO
ALTER TABLE [dbo].[PlanCobro_RubroCobro] CHECK CONSTRAINT [FK_PlanCobro_RubroCobro_PlanCobro]
GO
ALTER TABLE [dbo].[PlanCobro_RubroCobro]  WITH CHECK ADD  CONSTRAINT [FK_PlanCobro_RubroCobro_RubroCobro] FOREIGN KEY([IdRubroCobro])
REFERENCES [dbo].[RubroCobro] ([Id])
GO
ALTER TABLE [dbo].[PlanCobro_RubroCobro] CHECK CONSTRAINT [FK_PlanCobro_RubroCobro_RubroCobro]
GO
ALTER TABLE [dbo].[Reservacion]  WITH CHECK ADD  CONSTRAINT [FK_Reservacion_AreaComun] FOREIGN KEY([IdAreaComun])
REFERENCES [dbo].[AreaComun] ([Id])
GO
ALTER TABLE [dbo].[Reservacion] CHECK CONSTRAINT [FK_Reservacion_AreaComun]
GO
ALTER TABLE [dbo].[Reservacion]  WITH CHECK ADD  CONSTRAINT [FK_Reservacion_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Reservacion] CHECK CONSTRAINT [FK_Reservacion_Usuario]
GO
ALTER TABLE [dbo].[Residencia]  WITH CHECK ADD  CONSTRAINT [FK_Residencia_CondicionResidencia] FOREIGN KEY([Condicion])
REFERENCES [dbo].[CondicionResidencia] ([Id])
GO
ALTER TABLE [dbo].[Residencia] CHECK CONSTRAINT [FK_Residencia_CondicionResidencia]
GO
ALTER TABLE [dbo].[Residencia]  WITH CHECK ADD  CONSTRAINT [FK_Residencia_Usuario] FOREIGN KEY([Propietario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Residencia] CHECK CONSTRAINT [FK_Residencia_Usuario]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_TipoUsuario] FOREIGN KEY([IdTipoUsuario])
REFERENCES [dbo].[TipoUsuario] ([Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_TipoUsuario]
GO
USE [master]
GO
ALTER DATABASE [CondominiosDB] SET  READ_WRITE 
GO
