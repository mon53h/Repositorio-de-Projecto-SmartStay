USE [master]
GO
/****** Object:  Database [PV_ProyectoFinal]    Script Date: 4/2/2025 14:31:41 ******/
CREATE DATABASE [PV_ProyectoFinal]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PV_ProyectoFinal', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS01\MSSQL\DATA\PV_ProyectoFinal.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PV_ProyectoFinal_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS01\MSSQL\DATA\PV_ProyectoFinal_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PV_ProyectoFinal] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PV_ProyectoFinal].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PV_ProyectoFinal] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PV_ProyectoFinal] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PV_ProyectoFinal] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PV_ProyectoFinal] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PV_ProyectoFinal] SET ARITHABORT OFF 
GO
ALTER DATABASE [PV_ProyectoFinal] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PV_ProyectoFinal] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PV_ProyectoFinal] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PV_ProyectoFinal] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PV_ProyectoFinal] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PV_ProyectoFinal] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PV_ProyectoFinal] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PV_ProyectoFinal] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PV_ProyectoFinal] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PV_ProyectoFinal] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PV_ProyectoFinal] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PV_ProyectoFinal] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PV_ProyectoFinal] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PV_ProyectoFinal] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PV_ProyectoFinal] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PV_ProyectoFinal] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PV_ProyectoFinal] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PV_ProyectoFinal] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PV_ProyectoFinal] SET  MULTI_USER 
GO
ALTER DATABASE [PV_ProyectoFinal] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PV_ProyectoFinal] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PV_ProyectoFinal] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PV_ProyectoFinal] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PV_ProyectoFinal] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PV_ProyectoFinal] SET QUERY_STORE = OFF
GO
USE [PV_ProyectoFinal]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 4/2/2025 14:31:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[idBitacora] [int] IDENTITY(1,1) NOT NULL,
	[idReservacion] [int] NOT NULL,
	[idPersona] [int] NOT NULL,
	[accionRealizada] [varchar](25) NOT NULL,
	[fechaDeLaAccion] [datetime] NOT NULL,
 CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED 
(
	[idBitacora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Habitacion]    Script Date: 4/2/2025 14:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Habitacion](
	[idHabitacion] [int] IDENTITY(1,1) NOT NULL,
	[idHotel] [int] NOT NULL,
	[numeroHabitacion] [varchar](10) NOT NULL,
	[capacidadMaxima] [int] NOT NULL,
	[descripcion] [varchar](500) NOT NULL,
	[estado] [varchar](1) NOT NULL,
 CONSTRAINT [PK_Habitacion] PRIMARY KEY CLUSTERED 
(
	[idHabitacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotel]    Script Date: 4/2/2025 14:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotel](
	[idHotel] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](150) NOT NULL,
	[direccion] [varchar](500) NULL,
	[costoPorCadaAdulto] [numeric](10, 2) NOT NULL,
	[costoPorCadaNinho] [numeric](10, 2) NOT NULL,
 CONSTRAINT [PK_Hotel] PRIMARY KEY CLUSTERED 
(
	[idHotel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 4/2/2025 14:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[idPersona] [int] IDENTITY(1,1) NOT NULL,
	[nombreCompleto] [varchar](250) NOT NULL,
	[email] [varchar](150) NOT NULL,
	[clave] [varchar](15) NOT NULL,
	[esEmpleado] [bit] NOT NULL,
	[estado] [varchar](1) NOT NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[idPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservacion]    Script Date: 4/2/2025 14:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservacion](
	[idReservacion] [int] IDENTITY(1,1) NOT NULL,
	[idPersona] [int] NOT NULL,
	[idHabitacion] [int] NOT NULL,
	[fechaEntrada] [datetime] NOT NULL,
	[fechaSalida] [datetime] NOT NULL,
	[numeroAdultos] [int] NOT NULL,
	[numeroNinhos] [int] NOT NULL,
	[totalDiasReservacion] [int] NOT NULL,
	[costoPorCadaAdulto] [numeric](10, 2) NOT NULL,
	[costoPorCadaNinho] [numeric](10, 2) NOT NULL,
	[costoTotal] [numeric](14, 2) NOT NULL,
	[fechaCreacion] [datetime] NOT NULL,
	[fechaModificacion] [datetime] NULL,
	[estado] [varchar](1) NOT NULL,
 CONSTRAINT [PK_Reservacion] PRIMARY KEY CLUSTERED 
(
	[idReservacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Habitacion_hotel_numeroHabitacion]    Script Date: 4/2/2025 14:31:42 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Habitacion_hotel_numeroHabitacion] ON [dbo].[Habitacion]
(
	[idHotel] ASC,
	[numeroHabitacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Persona_email]    Script Date: 4/2/2025 14:31:42 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Persona_email] ON [dbo].[Persona]
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Persona] ADD  CONSTRAINT [DF_Persona_clave]  DEFAULT ((12345)) FOR [clave]
GO
ALTER TABLE [dbo].[Persona] ADD  CONSTRAINT [DF_Persona_esEmpleado]  DEFAULT ((0)) FOR [esEmpleado]
GO
ALTER TABLE [dbo].[Persona] ADD  CONSTRAINT [DF_Persona_estado]  DEFAULT ('A') FOR [estado]
GO
ALTER TABLE [dbo].[Bitacora]  WITH CHECK ADD  CONSTRAINT [FK_Bitacora_Persona] FOREIGN KEY([idPersona])
REFERENCES [dbo].[Persona] ([idPersona])
GO
ALTER TABLE [dbo].[Bitacora] CHECK CONSTRAINT [FK_Bitacora_Persona]
GO
ALTER TABLE [dbo].[Bitacora]  WITH CHECK ADD  CONSTRAINT [FK_Bitacora_Reservacion] FOREIGN KEY([idReservacion])
REFERENCES [dbo].[Reservacion] ([idReservacion])
GO
ALTER TABLE [dbo].[Bitacora] CHECK CONSTRAINT [FK_Bitacora_Reservacion]
GO
ALTER TABLE [dbo].[Habitacion]  WITH CHECK ADD  CONSTRAINT [FK_Habitacion_Hotel] FOREIGN KEY([idHotel])
REFERENCES [dbo].[Hotel] ([idHotel])
GO
ALTER TABLE [dbo].[Habitacion] CHECK CONSTRAINT [FK_Habitacion_Hotel]
GO
ALTER TABLE [dbo].[Reservacion]  WITH CHECK ADD  CONSTRAINT [FK_Reservacion_Habitacion] FOREIGN KEY([idHabitacion])
REFERENCES [dbo].[Habitacion] ([idHabitacion])
GO
ALTER TABLE [dbo].[Reservacion] CHECK CONSTRAINT [FK_Reservacion_Habitacion]
GO
ALTER TABLE [dbo].[Reservacion]  WITH CHECK ADD  CONSTRAINT [FK_Reservacion_Persona] FOREIGN KEY([idPersona])
REFERENCES [dbo].[Persona] ([idPersona])
GO
ALTER TABLE [dbo].[Reservacion] CHECK CONSTRAINT [FK_Reservacion_Persona]
GO
/****** Object:  StoredProcedure [dbo].[spConsultarBitacora]    Script Date: 4/2/2025 14:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[spConsultarBitacora]
AS	
BEGIN
	SELECT
		b.idBitacora,
		b.idReservacion,
		b.idPersona,
		b.accionRealizada,
		b.fechaDeLaAccion
	FROM dbo.Bitacora b
	LEFT JOIN dbo.Reservacion r ON b.idReservacion = r.idReservacion
	LEFT JOIN dbo.Persona p ON b.idPersona = p.idPersona
	ORDER BY b.accionRealizada asc, r.fechaEntrada asc, p.nombreCompleto asc
end
GO
/****** Object:  StoredProcedure [dbo].[spConsultarBitacoraPorId]    Script Date: 4/2/2025 14:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[spConsultarBitacoraPorId]
	@idBitacora int
AS	
BEGIN
	SELECT
		b.idBitacora,
		b.idReservacion,
		b.idPersona,
		b.accionRealizada,
		b.fechaDeLaAccion
	FROM dbo.Bitacora b
	LEFT JOIN dbo.Reservacion r ON b.idReservacion = r.idReservacion
	LEFT JOIN dbo.Persona p ON b.idPersona = p.idPersona
	where b.idBitacora = @idBitacora 
end
GO
/****** Object:  StoredProcedure [dbo].[spConsultarHabitacion]    Script Date: 4/2/2025 14:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[spConsultarHabitacion]
AS	
BEGIN
	SELECT
		h.idHabitacion,
		h.idHotel,
		h.numeroHabitacion,
		h.capacidadMaxima,
		h.descripcion,
		h.estado
	FROM dbo.Habitacion h
	LEFT JOIN dbo.Hotel ho ON h.numeroHabitacion = ho.nombre
	ORDER BY h.numeroHabitacion asc, ho.nombre asc
end

GO
/****** Object:  StoredProcedure [dbo].[spConsultarHabitacionPorId]    Script Date: 4/2/2025 14:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[spConsultarHabitacionPorId]
	@idHabitacion int
AS	
BEGIN
	SELECT
		h.idHabitacion,
		h.idHotel,
		h.numeroHabitacion,
		h.capacidadMaxima,
		h.descripcion,
		h.estado
	FROM dbo.Habitacion h
	LEFT JOIN dbo.Hotel ho ON h.numeroHabitacion = ho.nombre
	where h.idHabitacion = @idHabitacion
end

GO
/****** Object:  StoredProcedure [dbo].[spConsultarHotel]    Script Date: 4/2/2025 14:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[spConsultarHotel]
AS	
BEGIN
	SELECT
		ho.idHotel,
		ho.nombre,
		ho.direccion,
		ho.costoPorCadaAdulto,
		ho.costoPorCadaNinho
	FROM dbo.Hotel ho
	ORDER BY ho.nombre asc
end
GO
/****** Object:  StoredProcedure [dbo].[spConsultarHotelPorId]    Script Date: 4/2/2025 14:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[spConsultarHotelPorId]
	@idHotel int
AS	
BEGIN
	SELECT
		ho.idHotel,
		ho.nombre,
		ho.direccion,
		ho.costoPorCadaAdulto,
		ho.costoPorCadaNinho
	FROM dbo.Hotel ho
	where ho.idHotel = @idHotel
end
GO
/****** Object:  StoredProcedure [dbo].[spConsultarPersona]    Script Date: 4/2/2025 14:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[spConsultarPersona]
AS	
BEGIN
	SELECT
		p.idPersona,
		p.nombreCompleto,
		p.email,
		p.clave,
		p.esEmpleado,
		p.estado
	FROM dbo.Persona p
	ORDER BY p.nombreCompleto asc
end

GO
/****** Object:  StoredProcedure [dbo].[spConsultarPersonaPorId]    Script Date: 4/2/2025 14:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[spConsultarPersonaPorId]
	@idPersona int
AS	
BEGIN
	SELECT
		p.idPersona,
		p.nombreCompleto,
		p.email,
		p.clave,
		p.esEmpleado,
		p.estado
	FROM dbo.Persona p
	where p.idPersona = @idPersona
end

GO
/****** Object:  StoredProcedure [dbo].[spConsultarReservacion]    Script Date: 4/2/2025 14:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[spConsultarReservacion]
AS	
BEGIN
	SELECT
		r.idReservacion,
		r.idPersona,
		r.idHabitacion,
		r.fechaEntrada,
		r.fechaSalida,
		r.numeroAdultos,
		r.numeroNinhos,
		r.costoTotal,
		r.fechaCreacion,
		r.fechaModificacion,
		r.estado
	FROM dbo.Reservacion r
	LEFT JOIN dbo.Persona p ON r.idPersona = p.idPersona
	left join dbo.Habitacion h on r.idHabitacion = h.idHabitacion
	ORDER BY r.fechaEntrada asc, p.nombreCompleto asc, h.numeroHabitacion asc
end

GO
/****** Object:  StoredProcedure [dbo].[spConsultarReservacionPorId]    Script Date: 4/2/2025 14:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[spConsultarReservacionPorId]
	@idReservacion int
AS	
BEGIN
	SELECT
		r.idReservacion,
		r.idPersona,
		r.idHabitacion,
		r.fechaEntrada,
		r.fechaSalida,
		r.numeroAdultos,
		r.numeroNinhos,
		r.costoTotal,
		r.fechaCreacion,
		r.fechaModificacion,
		r.estado
	FROM dbo.Reservacion r
	LEFT JOIN dbo.Persona p ON r.idPersona = p.idPersona
	left join dbo.Habitacion h on r.idHabitacion = h.idHabitacion
	where r.idReservacion = @idReservacion
end

GO
/****** Object:  StoredProcedure [dbo].[spConsultarReservacionPorIdPersona]    Script Date: 4/2/2025 14:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[spConsultarReservacionPorIdPersona]
	@idPersona int
AS	
BEGIN
	SELECT
		r.idReservacion,
		r.idPersona,
		r.idHabitacion,
		r.fechaEntrada,
		r.fechaSalida,
		r.numeroAdultos,
		r.numeroNinhos,
		r.costoTotal,
		r.fechaCreacion,
		r.fechaModificacion,
		r.estado
	FROM dbo.Reservacion r
	LEFT JOIN dbo.Persona p ON r.idPersona = p.idPersona
	left join dbo.Habitacion h on r.idHabitacion = h.idHabitacion
	where r.idPersona = @idPersona
end

GO
/****** Object:  StoredProcedure [dbo].[spCrearBitacora]    Script Date: 4/2/2025 14:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spCrearBitacora]
	@idReservacion INT,
	@idPersona int,
	@accionRealizada VARCHAR(25),
	@fechaDeLaAccion DATETIME
AS	
BEGIN
	INSERT INTO dbo.Bitacora (idReservacion,idPersona, accionRealizada, fechaDeLaAccion)
	VALUES (@idReservacion, @idPersona, @accionRealizada, @fechaDeLaAccion)
END
GO
/****** Object:  StoredProcedure [dbo].[spCrearHabitacion]    Script Date: 4/2/2025 14:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spCrearHabitacion]
	@idHotel INT,
	@numeroHabitacion varchar(10),
	@capacidadMaxima int,
	@descripcion varchar(500)
AS	
BEGIN
	INSERT INTO dbo.Habitacion(idHotel,numeroHabitacion, capacidadMaxima, descripcion, estado)
	VALUES (@idHotel, @numeroHabitacion, @capacidadMaxima, @descripcion, 'A')
END
GO
/****** Object:  StoredProcedure [dbo].[spCrearHotel]    Script Date: 4/2/2025 14:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spCrearHotel]
	@nombre varchar(150),
	@direccion varchar(500),
	@costoPorCadaAdulto numeric(10,2),
	@costoPorCadaNinho numeric(10,2)
AS	
BEGIN
	INSERT INTO dbo.Hotel(nombre,direccion, costoPorCadaAdulto, costoPorCadaNinho)
	VALUES (@nombre, @direccion, @costoPorCadaAdulto, @costoPorCadaNinho)
END
GO
/****** Object:  StoredProcedure [dbo].[spCrearPersona]    Script Date: 4/2/2025 14:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spCrearPersona]
	@nombreCompleto varchar(250),
	@email varchar(150),
	@clave varchar(15),
	@esEmpleado bit
AS	
BEGIN
	INSERT INTO dbo.Persona(nombreCompleto,email, clave, esEmpleado,estado)
	VALUES (@nombreCompleto, @email, @clave, @esEmpleado, 'A')
END
GO
/****** Object:  StoredProcedure [dbo].[spCrearReservacion]    Script Date: 4/2/2025 14:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spCrearReservacion]
	@idPersona int,
	@idHabitacion int,
	@fechaEntrada datetime,
	@fechaSalida datetime,
	@numeroAdultos int,
	@numeroNinhos int,
	@totalDiasReservacion int,
	@costoPorCadaAdulto numeric(10,2),
	@costoPorCadaNinho numeric(10,2),
	@costoTotal numeric(14,2),
	@fechaCreacion datetime,
	@fechaModificacion datetime
AS	
BEGIN
	INSERT INTO dbo.Reservacion(idPersona,idHabitacion, fechaEntrada, fechaSalida,numeroAdultos, numeroNinhos, totalDiasReservacion, costoPorCadaAdulto, costoPorCadaNinho,costoTotal,fechaCreacion,fechaModificacion, estado)
	VALUES (@idPersona, @idHabitacion, @fechaEntrada, @fechaSalida, @numeroAdultos, @numeroNinhos, @totalDiasReservacion, @costoPorCadaAdulto, @costoPorCadaNinho,@costoTotal,@fechaCreacion, @fechaModificacion, 'A')
END
GO
/****** Object:  StoredProcedure [dbo].[spEditarBitacora]    Script Date: 4/2/2025 14:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spEditarBitacora]
	@idBitacora INT,
	@idReservacion INT,
	@idPersona INT,
	@accionRealizada VARCHAR(25),
	@fechaDeLaAccion Datetime
AS	
BEGIN
	UPDATE dbo.Bitacora
	SET idReservacion = @idReservacion, idPersona = @idPersona, accionRealizada = @accionRealizada, fechaDeLaAccion = @fechaDeLaAccion
	WHERE idBitacora = @idBitacora
END
GO
/****** Object:  StoredProcedure [dbo].[spEditarHabitacion]    Script Date: 4/2/2025 14:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spEditarHabitacion]
	@idHabitacion INT,
	@idHotel INT,
	@numeroHabitacion varchar(10),
	@capacidadMaxima int,
	@descripcion varchar(500),
	@estado varchar(3)
AS	
BEGIN
	UPDATE dbo.Habitacion
	SET  idHotel = @idHotel, numeroHabitacion = @numeroHabitacion, capacidadMaxima = @capacidadMaxima, descripcion = @descripcion, estado = @estado
	WHERE idHabitacion = @idHabitacion
END
GO
/****** Object:  StoredProcedure [dbo].[spEditarHotel]    Script Date: 4/2/2025 14:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spEditarHotel]
	@idHotel INT,
	@nombre varchar(150),
	@direccion varchar(500),
	@costoPorCadaAdulto numeric(10,2),
	@costoPorCadaNinho numeric(10,2)
AS	
BEGIN
	UPDATE dbo.Hotel
	SET   nombre = @nombre, direccion = @direccion, costoPorCadaAdulto = @costoPorCadaAdulto, costoPorCadaNinho = @costoPorCadaNinho
	WHERE idHotel = @idHotel
END
GO
/****** Object:  StoredProcedure [dbo].[spEditarPersona]    Script Date: 4/2/2025 14:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spEditarPersona]
	@idPersona INT,
	@nombreCompleto varchar(250),
	@email varchar(150),
	@clave varchar(15),
	@esEmpleado bit,
	@estado varchar(1)
AS	
BEGIN
	UPDATE dbo.Persona
	SET   nombreCompleto = @nombreCompleto, email = @email, clave = @clave, esEmpleado = @esEmpleado, estado = @estado
	WHERE idPersona = @idPersona
END
GO
/****** Object:  StoredProcedure [dbo].[spEditarReservacion]    Script Date: 4/2/2025 14:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spEditarReservacion]
	@idReservacion int,
	@idPersona INT,
	@idHabitacion int,
	@fechaEntrada datetime,
	@fechaSalida datetime,
	@numeroAdultos int,
	@numeroNinhos int,
	@totalDiasReservacion int,
	@costoPorCadaAdulto numeric(10,2),
	@costoPorCadaNinho numeric(10,2),
	@costoTotal numeric(10,2),
	@fechaCreacion datetime,
	@fechaModificacion datetime,
	@estado varchar(1)
AS	
BEGIN
	UPDATE dbo.Reservacion
	SET   idPersona = @idPersona, idHabitacion = @idHabitacion, fechaEntrada = @fechaEntrada, fechaSalida = @fechaSalida, numeroAdultos = @numeroAdultos, numeroNinhos = @numeroNinhos, totalDiasReservacion = @totalDiasReservacion, costoPorCadaAdulto = @costoPorCadaAdulto, costoPorCadaNinho = @costoPorCadaNinho, costoTotal = @costoTotal, fechaCreacion = @fechaCreacion, fechaModificacion = @fechaModificacion, estado = @estado
	WHERE idReservacion = @idReservacion
END
GO
/****** Object:  StoredProcedure [dbo].[spEliminarBitacora]    Script Date: 4/2/2025 14:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spEliminarBitacora]
	@idBitacora INT
AS	
BEGIN
	DELETE dbo.Bitacora 
	WHERE idBitacora = @idBitacora
END
GO
/****** Object:  StoredProcedure [dbo].[spEliminarHabitacion]    Script Date: 4/2/2025 14:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spEliminarHabitacion]
	@idHabitacion INT
AS	
BEGIN
	DELETE dbo.Habitacion 
	WHERE idHabitacion = @idHabitacion
END
GO
/****** Object:  StoredProcedure [dbo].[spEliminarHotel]    Script Date: 4/2/2025 14:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spEliminarHotel]
	@idHotel INT
AS	
BEGIN
	DELETE dbo.Hotel 
	WHERE idHotel = @idHotel
END
GO
/****** Object:  StoredProcedure [dbo].[spEliminarPersona]    Script Date: 4/2/2025 14:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spEliminarPersona]
	@idPersona INT
AS	
BEGIN
	DELETE dbo.Persona 
	WHERE idPersona = @idPersona
END
GO
/****** Object:  StoredProcedure [dbo].[spEliminarReservacion]    Script Date: 4/2/2025 14:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spEliminarReservacion]
	@idReservacion INT
AS	
BEGIN
	DELETE dbo.Reservacion 
	WHERE idReservacion = @idReservacion
END
GO
USE [master]
GO
ALTER DATABASE [PV_ProyectoFinal] SET  READ_WRITE 
GO
