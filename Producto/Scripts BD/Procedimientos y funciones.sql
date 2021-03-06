USE [DB_9B3453_Geoparking]
GO
/****** Object:  StoredProcedure [dbo].[spGetCantidadConsultasPorTipoPlaya]    Script Date: 13/01/2015 17:14:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetCantidadConsultasPorTipoPlaya]
@ciudad int = 0,
@tipoPlaya int = 0,
	@fechaDesde datetime = null,
	@fechaHasta datetime = null
	AS
BEGIN
	
	select YEAR(e.Hora) as 'Fecha', t.Nombre, COUNT(e.Id) as 'Cantidad'
	
	from EstadisticaConsultas e inner join TipoPlayas t on e.IdTipoPlaya = t.Id
	
	WHERE
	(@fechaDesde is null OR Hora >=  @fechaDesde) AND
	(@fechaHasta IS NULL OR  Hora <=  @fechaHasta) AND	
	(@ciudad = 0 OR Ciudad = @ciudad) AND
	(@tipoPlaya = 0 OR IdTipoPlaya = @tipoPlaya)

	group by Year(e.Hora), t.Nombre
	order by 1
END
GO
/****** Object:  StoredProcedure [dbo].[spGetCantidadConsultasPorTipoVehiculo]    Script Date: 13/01/2015 17:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetCantidadConsultasPorTipoVehiculo]
@ciudad int = 0,

	@fechaDesde datetime = null,
	@fechaHasta datetime = null
	AS
BEGIN
	
	select YEAR(e.Hora) as 'Fecha', t.Nombre, COUNT(e.Id) as 'Cantidad'
	
	from EstadisticaConsultas e inner join TipoVehiculoes t on e.IdTipoVehiculo = t.Id
	
	WHERE
	(@fechaDesde is null OR Hora >=  @fechaDesde) AND
	(@fechaHasta IS NULL OR  Hora <=  @fechaHasta) AND	
	(@ciudad = 0 OR Ciudad = @ciudad)

	group by Year(e.Hora), t.Nombre
	order by 1
END
GO
/****** Object:  StoredProcedure [dbo].[spGetEstadisticasByFilters]    Script Date: 13/01/2015 17:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetEstadisticasByFilters]
	@ciudad int = 0,
	@fechaDesde datetime = null,
	@fechaHasta datetime = null
AS
BEGIN
	
	SELECT
			latitud as latitud, 
			longitud as longitud,
			Hora as Hora

	FROM	EstadisticaConsultas

	WHERE
	(@fechaDesde is null OR Hora >=  @fechaDesde) AND
	(@fechaHasta IS NULL OR  Hora <=  @fechaHasta) AND	
	(@ciudad = 0 OR Ciudad = @ciudad)
END
GO
/****** Object:  StoredProcedure [dbo].[spGetPreciosDePlayasPorTipoVehiculoEIdPlayas]    Script Date: 13/01/2015 17:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetPreciosDePlayasPorTipoVehiculoEIdPlayas]
	-- Add the parameters for the stored procedure here
	@ListaIds nvarchar(MAX),
	@TipoVehiculoId int
AS
BEGIN
    -- Insert statements for procedure here
	SELECT pr.*
	FROM [dbo].[Precios] pr, [dbo].[Servicios] s, [dbo].[PlayaDeEstacionamientoes] p
	WHERE pr.[ServicioId] = s.[Id]
		AND s.[PlayaDeEstacionamientoId] = p.[Id]
		AND s.[FechaBaja] IS NULL
		AND pr.[FechaBaja] IS NULL
		AND p.[FechaBaja] IS NULL
		AND s.TipoVehiculoId = @TipoVehiculoId
		AND s.[PlayaDeEstacionamientoId] IN (SELECT * FROM [dbo].[iter$simple_intlist_to_tbl](@ListaIds));
END
GO
/****** Object:  StoredProcedure [dbo].[spObtenerDisponibilidadPlayasPorTipoVehiculo]    Script Date: 13/01/2015 17:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spObtenerDisponibilidadPlayasPorTipoVehiculo]
	-- Add the parameters for the stored procedure here
	@ListaIds nvarchar(MAX),
	@TipoVehiculoId int
AS
BEGIN

    -- Insert statements for procedure here
	SELECT s.[PlayaDeEstacionamientoID] as PlayaId, s.[TipoVehiculoId], d.[Disponibilidad], p.[Nombre] as NombrePlaya
	FROM [dbo].[DisponibilidadPlayas] d, [dbo].[PlayaDeEstacionamientoes] p, [dbo].[Servicios]  s
	WHERE d.[ServicioId] = s.[Id]
		AND s.[PlayaDeEstacionamientoID] = p.[Id]
		AND d.[FechaBaja] IS NULL
		AND s.[FechaBaja] IS NULL
		AND p.[FechaBaja] IS NULL
		AND s.[TipoVehiculoId] = @TipoVehiculoId
		AND s.[PlayaDeEstacionamientoID]  IN (SELECT * FROM [dbo].[iter$simple_intlist_to_tbl](@ListaIds));
END
GO
/****** Object:  StoredProcedure [dbo].[spObtenerUbicacionesDePlayasPorCiudadYTipoVehiculo]    Script Date: 13/01/2015 17:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spObtenerUbicacionesDePlayasPorCiudadYTipoVehiculo] 
	-- Add the parameters for the stored procedure here
	@Ciudad nvarchar(MAX),
	@TipoVehiculoId int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SELECT d.*
	FROM [dbo].[Direccions] d, [dbo].[PlayaDeEstacionamientoes] p, [dbo].[Servicios] s
	WHERE d.[PlayaDeEstacionamientoId] = p.[Id]
		AND p.[Id] = s.[PlayaDeEstacionamientoId]
		AND p.[FechaBaja] IS NULL
		AND s.[FechaBaja] IS NULL
		AND d.[FechaBaja] IS NULL
		AND d.[Ciudad] = @Ciudad
		AND (s.[TipoVehiculoId] = @TipoVehiculoId OR @TipoVehiculoId = 0);
END
GO
/****** Object:  StoredProcedure [dbo].[spObtenerUbicacionPorUbicacion]    Script Date: 13/01/2015 17:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spObtenerUbicacionPorUbicacion] 
	-- Add the parameters for the stored procedure here
	@latitud float,
	@longitud float,
	@TipoVehiculoId int
AS
BEGIN
declare @posicionGeography geography
set @posicionGeography = geography::Point(@latitud, @longitud, 4326)
	SELECT d.*
	FROM [dbo].[Direccions] d, [dbo].[PlayaDeEstacionamientoes] p, [dbo].[Servicios] s
	WHERE d.[PlayaDeEstacionamientoId] = p.[Id]
		AND p.[Id] = s.[PlayaDeEstacionamientoId]
		AND p.[FechaBaja] IS NULL
		AND s.[FechaBaja] IS NULL
		AND d.[FechaBaja] IS NULL
		AND d.[Posicion].STDistance(@posicionGeography) < 10000
		AND (s.[TipoVehiculoId] = @TipoVehiculoId OR @TipoVehiculoId = 0);
END

GO
/****** Object:  UserDefinedFunction [dbo].[iter$simple_intlist_to_tbl]    Script Date: 13/01/2015 17:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[iter$simple_intlist_to_tbl] (@list nvarchar(MAX))
   RETURNS @tbl TABLE (number int NOT NULL) AS
BEGIN
   DECLARE @pos        int,
           @nextpos    int,
           @valuelen   int

   SELECT @pos = 0, @nextpos = 1

   WHILE @nextpos > 0
   BEGIN
      SELECT @nextpos = charindex(',', @list, @pos + 1)
      SELECT @valuelen = CASE WHEN @nextpos > 0
                              THEN @nextpos
                              ELSE len(@list) + 1
                         END - @pos - 1
      INSERT @tbl (number)
         VALUES (convert(int, substring(@list, @pos + 1, @valuelen)))
      SELECT @pos = @nextpos
   END
   RETURN
END
GO
