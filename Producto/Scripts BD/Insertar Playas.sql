/*****************************************
Script Alta de playas de estacionamiento
@ezebc182
fecha:07/09/2014
******************************************/
USE [DB_9B3453_Geoparking]
-------------------------------------------- Playa 1

/*Datos Generales*/
INSERT INTO [dbo].[PlayaDeEstacionamientoes]
           ([Nombre]
           ,[TipoPlayaId]
           ,[FechaAlta]
           ,[FechaBaja]
           ,[Mail]
           ,[Telefono])
     VALUES
           ('24 hs'
           ,1
           ,CURRENT_TIMESTAMP
           ,null
           ,'24hs@gmail.com'
           ,4225555)
GO

/* Ubicacion */
INSERT INTO [dbo].[Direccions]
           ([Calle]
           ,[Numero]
           ,[CiudadId]
           ,[PlayaDeEstacionamientoId]
           ,[Latitud]
           ,[Longitud]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           ('27 de Abril'
           ,650
           ,1560
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,-31.414432
           ,-64.193366 
           ,CURRENT_TIMESTAMP
           ,null)
GO
/* Precios */

INSERT INTO [dbo].[Precios]
           ([TipoVehiculoId]
           ,[PlayaDeEstacionamientoId]
           ,[DiaAtencionId]
           ,[TiempoId]
           ,[Monto]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           (1
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,1
           ,1
           ,22
           ,CURRENT_TIMESTAMP
           ,null)
GO
/*Horarios*/

INSERT INTO [dbo].[Horarios]
           ([HoraDesde]
           ,[HoraHasta]
           ,[DiaAtencionId]
           ,[PlayaDeEstacionamientoId]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           ('09:00'
           ,'22:30'
           ,1
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,CURRENT_TIMESTAMP
           ,null)
GO
/* Servicios*/
INSERT INTO [dbo].[Servicios]
           ([TipoVehiculoId]
           ,[PlayaDeEstacionamientoId]
           ,[Capacidad]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           (1
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,40
           ,CURRENT_TIMESTAMP
           ,null)
GO
-------------------------------------------- Playa 2

/*Datos Generales*/
INSERT INTO [dbo].[PlayaDeEstacionamientoes]
           ([Nombre]
           ,[TipoPlayaId]
           ,[FechaAlta]
           ,[FechaBaja]
           ,[Mail]
           ,[Telefono])
     VALUES
           ('Playa Dean Funes'
           ,1
           ,CURRENT_TIMESTAMP
           ,null
           ,'deanfunes-playa@gmail.com'
           ,4235489)
GO

/* Ubicacion */
INSERT INTO [dbo].[Direccions]
           ([Calle]
           ,[Numero]
           ,[CiudadId]
           ,[PlayaDeEstacionamientoId]
           ,[Latitud]
           ,[Longitud]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           ('Dean Funes'
           ,942
           ,1560
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,-31.412051
           ,-64.197003 
           ,CURRENT_TIMESTAMP
           ,null)
GO
/* Precios */

INSERT INTO [dbo].[Precios]
           ([TipoVehiculoId]
           ,[PlayaDeEstacionamientoId]
           ,[DiaAtencionId]
           ,[TiempoId]
           ,[Monto]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           (1
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,1
           ,1
           ,18
           ,CURRENT_TIMESTAMP
           ,null)
GO
/*Horarios*/

INSERT INTO [dbo].[Horarios]
           ([HoraDesde]
           ,[HoraHasta]
           ,[DiaAtencionId]
           ,[PlayaDeEstacionamientoId]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           ('07:00'
           ,'20:30'
           ,1
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,CURRENT_TIMESTAMP
           ,null)
GO
/* Servicios*/
INSERT INTO [dbo].[Servicios]
           ([TipoVehiculoId]
           ,[PlayaDeEstacionamientoId]
           ,[Capacidad]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           (1
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,60
           ,CURRENT_TIMESTAMP
           ,null)
-------------------------------------------- Playa 3

/*Datos Generales*/
INSERT INTO [dbo].[PlayaDeEstacionamientoes]
           ([Nombre]
           ,[TipoPlayaId]
           ,[FechaAlta]
           ,[FechaBaja]
           ,[Mail]
           ,[Telefono])
     VALUES
           ('Playa Duarte Quirós I'
           ,3
           ,CURRENT_TIMESTAMP
           ,null
           ,'duartequiros-playa@gmail.com'
           ,155220032)
GO

/* Ubicacion */
INSERT INTO [dbo].[Direccions]
           ([Calle]
           ,[Numero]
           ,[CiudadId]
           ,[PlayaDeEstacionamientoId]
           ,[Latitud]
           ,[Longitud]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           ('Av Duarte Quirós'
           ,1022
           ,1560
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,-31.415192 
           ,-64.199502
           ,CURRENT_TIMESTAMP
           ,null)
GO
/* Precios */

INSERT INTO [dbo].[Precios]
           ([TipoVehiculoId]
           ,[PlayaDeEstacionamientoId]
           ,[DiaAtencionId]
           ,[TiempoId]
           ,[Monto]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           (3
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,1
           ,1
           ,9
           ,CURRENT_TIMESTAMP
           ,null)
GO
/*Horarios*/

INSERT INTO [dbo].[Horarios]
           ([HoraDesde]
           ,[HoraHasta]
           ,[DiaAtencionId]
           ,[PlayaDeEstacionamientoId]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           ('09:00'
           ,'21:30'
           ,1
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,CURRENT_TIMESTAMP
           ,null)
GO
/* Servicios*/
INSERT INTO [dbo].[Servicios]
           ([TipoVehiculoId]
           ,[PlayaDeEstacionamientoId]
           ,[Capacidad]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           (3
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,25
           ,CURRENT_TIMESTAMP
           ,null)
--

-------------------------------------------- Playa 4

/*Datos Generales*/
INSERT INTO [dbo].[PlayaDeEstacionamientoes]
           ([Nombre]
           ,[TipoPlayaId]
           ,[FechaAlta]
           ,[FechaBaja]
           ,[Mail]
           ,[Telefono])
     VALUES
           ('Estacionamiento Caseros'
           ,1
           ,CURRENT_TIMESTAMP
           ,null
           ,'estacionamiento-caseros@hotmail.com'
           ,4243300)
GO

/* Ubicacion */
INSERT INTO [dbo].[Direccions]
           ([Calle]
           ,[Numero]
           ,[CiudadId]
           ,[PlayaDeEstacionamientoId]
           ,[Latitud]
           ,[Longitud]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           ('Caseros'
           ,502
           ,1560
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,-31.416126
           ,-64.192421
           ,CURRENT_TIMESTAMP
           ,null)
GO
/* Precios */

INSERT INTO [dbo].[Precios]
           ([TipoVehiculoId]
           ,[PlayaDeEstacionamientoId]
           ,[DiaAtencionId]
           ,[TiempoId]
           ,[Monto]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           (4
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,1
           ,1
           ,9
           ,CURRENT_TIMESTAMP
           ,null)
GO
/*Horarios*/

INSERT INTO [dbo].[Horarios]
           ([HoraDesde]
           ,[HoraHasta]
           ,[DiaAtencionId]
           ,[PlayaDeEstacionamientoId]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           ('09:00'
           ,'21:30'
           ,1
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,CURRENT_TIMESTAMP
           ,null)
GO
/* Servicios*/
INSERT INTO [dbo].[Servicios]
           ([TipoVehiculoId]
           ,[PlayaDeEstacionamientoId]
           ,[Capacidad]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           (4
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,25
           ,CURRENT_TIMESTAMP
           ,null)

-------------------------------------------- Playa 5

/*Datos Generales*/
INSERT INTO [dbo].[PlayaDeEstacionamientoes]
           ([Nombre]
           ,[TipoPlayaId]
           ,[FechaAlta]
           ,[FechaBaja]
           ,[Mail]
           ,[Telefono])
     VALUES
           ('Buenos Aires Park'
           ,1
           ,CURRENT_TIMESTAMP
           ,null
           ,'bsaspark@hotmail.com'
           ,4662288)
GO

/* Ubicacion */
INSERT INTO [dbo].[Direccions]
           ([Calle]
           ,[Numero]
           ,[CiudadId]
           ,[PlayaDeEstacionamientoId]
           ,[Latitud]
           ,[Longitud]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           ('Buenos Aires'
           ,220
           ,1560
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,-31.419376 
           ,-64.184192
           ,CURRENT_TIMESTAMP
           ,null)
GO
/* Precios */

INSERT INTO [dbo].[Precios]
           ([TipoVehiculoId]
           ,[PlayaDeEstacionamientoId]
           ,[DiaAtencionId]
           ,[TiempoId]
           ,[Monto]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           (4
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,1
           ,1
           ,12
           ,CURRENT_TIMESTAMP
           ,null)
GO
/*Horarios*/

INSERT INTO [dbo].[Horarios]
           ([HoraDesde]
           ,[HoraHasta]
           ,[DiaAtencionId]
           ,[PlayaDeEstacionamientoId]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           ('08:00'
           ,'23:30'
           ,1
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,CURRENT_TIMESTAMP
           ,null)
GO
/* Servicios*/
INSERT INTO [dbo].[Servicios]
           ([TipoVehiculoId]
           ,[PlayaDeEstacionamientoId]
           ,[Capacidad]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           (4
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,30
           ,CURRENT_TIMESTAMP
           ,null)
--

-------------------------------------------- Playa 6

/*Datos Generales*/
INSERT INTO [dbo].[PlayaDeEstacionamientoes]
           ([Nombre]
           ,[TipoPlayaId]
           ,[FechaAlta]
           ,[FechaBaja]
           ,[Mail]
           ,[Telefono])
     VALUES
           ('Playas Velez'
           ,1
           ,CURRENT_TIMESTAMP
           ,null
           ,'velezparking@hotmail.com'
           ,155220033)
GO

/* Ubicacion */
INSERT INTO [dbo].[Direccions]
           ([Calle]
           ,[Numero]
           ,[CiudadId]
           ,[PlayaDeEstacionamientoId]
           ,[Latitud]
           ,[Longitud]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           ('Av Vélez Sarsfield'
           ,699
           ,1560
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,-31.423907 
           ,-64.190613
           ,CURRENT_TIMESTAMP
           ,null)
GO
/* Precios */

INSERT INTO [dbo].[Precios]
           ([TipoVehiculoId]
           ,[PlayaDeEstacionamientoId]
           ,[DiaAtencionId]
           ,[TiempoId]
           ,[Monto]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           (1
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,1
           ,1
           ,23
           ,CURRENT_TIMESTAMP
           ,null),
		   (4
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,1
           ,1
           ,12
           ,CURRENT_TIMESTAMP
           ,null)
GO
/*Horarios*/

INSERT INTO [dbo].[Horarios]
           ([HoraDesde]
           ,[HoraHasta]
           ,[DiaAtencionId]
           ,[PlayaDeEstacionamientoId]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           ('08:00'
           ,'23:30'
           ,1
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,CURRENT_TIMESTAMP
           ,null)
GO
/* Servicios*/
INSERT INTO [dbo].[Servicios]
           ([TipoVehiculoId]
           ,[PlayaDeEstacionamientoId]
           ,[Capacidad]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           (1
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,30
           ,CURRENT_TIMESTAMP
           ,null),
		   (4
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,10
           ,CURRENT_TIMESTAMP
           ,null)

--

-------------------------------------------- Playa 7

/*Datos Generales*/
INSERT INTO [dbo].[PlayaDeEstacionamientoes]
           ([Nombre]
           ,[TipoPlayaId]
           ,[FechaAlta]
           ,[FechaBaja]
           ,[Mail]
           ,[Telefono])
     VALUES
           ('Playas Illia'
           ,1
           ,CURRENT_TIMESTAMP
           ,null
           ,'playaillia@hotmail.com'
           ,4231212)
GO

/* Ubicacion */
INSERT INTO [dbo].[Direccions]
           ([Calle]
           ,[Numero]
           ,[CiudadId]
           ,[PlayaDeEstacionamientoId]
           ,[Latitud]
           ,[Longitud]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           ('Bv. San Juan'
           ,400
           ,1560
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,-31.419196
           , -64.192354
           ,CURRENT_TIMESTAMP
           ,null)
GO
/* Precios */

INSERT INTO [dbo].[Precios]
           ([TipoVehiculoId]
           ,[PlayaDeEstacionamientoId]
           ,[DiaAtencionId]
           ,[TiempoId]
           ,[Monto]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           (1
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,1
           ,1
           ,23
           ,CURRENT_TIMESTAMP
           ,null),
		   (3
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,1
           ,1
           ,30
           ,CURRENT_TIMESTAMP
           ,null)
GO
/*Horarios*/

INSERT INTO [dbo].[Horarios]
           ([HoraDesde]
           ,[HoraHasta]
           ,[DiaAtencionId]
           ,[PlayaDeEstacionamientoId]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           ('08:00'
           ,'23:30'
           ,1
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,CURRENT_TIMESTAMP
           ,null)
GO
/* Servicios*/
INSERT INTO [dbo].[Servicios]
           ([TipoVehiculoId]
           ,[PlayaDeEstacionamientoId]
           ,[Capacidad]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           (1
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,30
           ,CURRENT_TIMESTAMP
           ,null),
		   (3
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,20
           ,CURRENT_TIMESTAMP
           ,null)

--


-------------------------------------------- Playa 8

/*Datos Generales*/
INSERT INTO [dbo].[PlayaDeEstacionamientoes]
           ([Nombre]
           ,[TipoPlayaId]
           ,[FechaAlta]
           ,[FechaBaja]
           ,[Mail]
           ,[Telefono])
     VALUES
           ('Playas Illia'
           ,1
           ,CURRENT_TIMESTAMP
           ,null
           ,'playasillia@hotmail.com'
           ,4200333)
GO

/* Ubicacion */
INSERT INTO [dbo].[Direccions]
           ([Calle]
           ,[Numero]
           ,[CiudadId]
           ,[PlayaDeEstacionamientoId]
           ,[Latitud]
           ,[Longitud]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           ('Bv. Arturo Illia'
           ,202
           ,1560
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,-31.421503
		   , -64.182949
           ,CURRENT_TIMESTAMP
           ,null)
GO
/* Precios */

INSERT INTO [dbo].[Precios]
           ([TipoVehiculoId]
           ,[PlayaDeEstacionamientoId]
           ,[DiaAtencionId]
           ,[TiempoId]
           ,[Monto]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           (1
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,1
           ,1
           ,26
           ,CURRENT_TIMESTAMP
           ,null),
		   (3
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,1
           ,1
           ,40
           ,CURRENT_TIMESTAMP
           ,null)
GO
/*Horarios*/

INSERT INTO [dbo].[Horarios]
           ([HoraDesde]
           ,[HoraHasta]
           ,[DiaAtencionId]
           ,[PlayaDeEstacionamientoId]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           ('08:00'
           ,'23:30'
           ,1
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,CURRENT_TIMESTAMP
           ,null)
GO
/* Servicios*/
INSERT INTO [dbo].[Servicios]
           ([TipoVehiculoId]
           ,[PlayaDeEstacionamientoId]
           ,[Capacidad]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           (1
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,22
           ,CURRENT_TIMESTAMP
           ,null),
		   (3
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,12
           ,CURRENT_TIMESTAMP
           ,null)

--

-------------------------------------------- Playa 9

/*Datos Generales*/
INSERT INTO [dbo].[PlayaDeEstacionamientoes]
           ([Nombre]
           ,[TipoPlayaId]
           ,[FechaAlta]
           ,[FechaBaja]
           ,[Mail]
           ,[Telefono])
     VALUES
           ('Aparcamiento Sarmiento'
           ,1
           ,CURRENT_TIMESTAMP
           ,null
           ,'playa-sarmiento@gmail.com'
           ,4779922)
GO

/* Ubicacion */
INSERT INTO [dbo].[Direccions]
           ([Calle]
           ,[Numero]
           ,[CiudadId]
           ,[PlayaDeEstacionamientoId]
           ,[Latitud]
           ,[Longitud]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           ('Sarmiento'
           ,100
           ,1560
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,-31.410652
		   , -64.179460
           ,CURRENT_TIMESTAMP
           ,null)
GO
/* Precios */

INSERT INTO [dbo].[Precios]
           ([TipoVehiculoId]
           ,[PlayaDeEstacionamientoId]
           ,[DiaAtencionId]
           ,[TiempoId]
           ,[Monto]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           (1
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,1
           ,1
           ,16
           ,CURRENT_TIMESTAMP
           ,null),
		   (4
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,1
           ,1
           ,10
           ,CURRENT_TIMESTAMP
           ,null)
GO
/*Horarios*/

INSERT INTO [dbo].[Horarios]
           ([HoraDesde]
           ,[HoraHasta]
           ,[DiaAtencionId]
           ,[PlayaDeEstacionamientoId]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           ('08:00'
           ,'23:30'
           ,1
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,CURRENT_TIMESTAMP
           ,null)
GO
/* Servicios*/
INSERT INTO [dbo].[Servicios]
           ([TipoVehiculoId]
           ,[PlayaDeEstacionamientoId]
           ,[Capacidad]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           (1
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,30
           ,CURRENT_TIMESTAMP
           ,null),
		   (4
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,40
           ,CURRENT_TIMESTAMP
           ,null)

--



-------------------------------------------- Playa 10

/*Datos Generales*/
INSERT INTO [dbo].[PlayaDeEstacionamientoes]
           ([Nombre]
           ,[TipoPlayaId]
           ,[FechaAlta]
           ,[FechaBaja]
           ,[Mail]
           ,[Telefono])
     VALUES
           ('Estrada Parking'
           ,1
           ,CURRENT_TIMESTAMP
           ,null
           ,'playa-estrada@gmail.com'
           ,4334400)
GO

/* Ubicacion */
INSERT INTO [dbo].[Direccions]
           ([Calle]
           ,[Numero]
           ,[CiudadId]
           ,[PlayaDeEstacionamientoId]
           ,[Latitud]
           ,[Longitud]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           ('José Manuel Estrada'
           ,100
           ,1560
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,-31.427371
		   , -64.188308
           ,CURRENT_TIMESTAMP
           ,null)
GO
/* Precios */

INSERT INTO [dbo].[Precios]
           ([TipoVehiculoId]
           ,[PlayaDeEstacionamientoId]
           ,[DiaAtencionId]
           ,[TiempoId]
           ,[Monto]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           (1
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,1
           ,1
           ,20
           ,CURRENT_TIMESTAMP
           ,null),
		   (4
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,1
           ,1
           ,10
           ,CURRENT_TIMESTAMP
           ,null),		   
		   (3
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,1
           ,1
           ,15
           ,CURRENT_TIMESTAMP
           ,null)
GO
/*Horarios*/

INSERT INTO [dbo].[Horarios]
           ([HoraDesde]
           ,[HoraHasta]
           ,[DiaAtencionId]
           ,[PlayaDeEstacionamientoId]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           ('08:00'
           ,'23:30'
           ,1
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,CURRENT_TIMESTAMP
           ,null)
GO
/* Servicios*/
INSERT INTO [dbo].[Servicios]
           ([TipoVehiculoId]
           ,[PlayaDeEstacionamientoId]
           ,[Capacidad]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           (1
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,30
           ,CURRENT_TIMESTAMP
           ,null),
		   (4
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,40
           ,CURRENT_TIMESTAMP
           ,null),
		   (3
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,30
           ,CURRENT_TIMESTAMP
           ,null)

--
/*Otras ciudades*/


--Unquillo


/*Datos Generales*/
INSERT INTO [dbo].[PlayaDeEstacionamientoes]
           ([Nombre]
           ,[TipoPlayaId]
           ,[FechaAlta]
           ,[FechaBaja]
           ,[Mail]
           ,[Telefono])
     VALUES
           ('Unquillo Parking'
           ,1
           ,CURRENT_TIMESTAMP
           ,null
           ,'playa-unquillo@gmail.com'
           ,4334400)
GO

/* Ubicacion */
INSERT INTO [dbo].[Direccions]
           ([Calle]
           ,[Numero]
           ,[CiudadId]
           ,[PlayaDeEstacionamientoId]
           ,[Latitud]
           ,[Longitud]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           ('Av San Martin '
           ,2072
           ,2107
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,-31.234030,
		    -64.315794
           ,CURRENT_TIMESTAMP
           ,null)
GO
/* Precios */

INSERT INTO [dbo].[Precios]
           ([TipoVehiculoId]
           ,[PlayaDeEstacionamientoId]
           ,[DiaAtencionId]
           ,[TiempoId]
           ,[Monto]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           (1
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,1
           ,1
           ,20
           ,CURRENT_TIMESTAMP
           ,null),
		   (4
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,1
           ,1
           ,10
           ,CURRENT_TIMESTAMP
           ,null),		   
		   (3
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,1
           ,1
           ,15
           ,CURRENT_TIMESTAMP
           ,null)
GO
/*Horarios*/

INSERT INTO [dbo].[Horarios]
           ([HoraDesde]
           ,[HoraHasta]
           ,[DiaAtencionId]
           ,[PlayaDeEstacionamientoId]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           ('08:00'
           ,'23:30'
           ,1
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,CURRENT_TIMESTAMP
           ,null)
GO
/* Servicios*/
INSERT INTO [dbo].[Servicios]
           ([TipoVehiculoId]
           ,[PlayaDeEstacionamientoId]
           ,[Capacidad]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           (1
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,30
           ,CURRENT_TIMESTAMP
           ,null),
		   (4
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,40
           ,CURRENT_TIMESTAMP
           ,null),
		   (3
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,30
           ,CURRENT_TIMESTAMP
           ,null)

--Rio Cuarto


/*Datos Generales*/
INSERT INTO [dbo].[PlayaDeEstacionamientoes]
           ([Nombre]
           ,[TipoPlayaId]
           ,[FechaAlta]
           ,[FechaBaja]
           ,[Mail]
           ,[Telefono])
     VALUES
           ('Rio IV Parking'
           ,1
           ,CURRENT_TIMESTAMP
           ,null
           ,'playa-rioiv@gmail.com'
           ,4554302)
GO

/* Ubicacion */
INSERT INTO [dbo].[Direccions]
           ([Calle]
           ,[Numero]
           ,[CiudadId]
           ,[PlayaDeEstacionamientoId]
           ,[Latitud]
           ,[Longitud]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           ('Mendoza'
           ,699
           ,1982
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,-33.123056
		   , -64.353331
           ,CURRENT_TIMESTAMP
           ,null)
GO
/* Precios */

INSERT INTO [dbo].[Precios]
           ([TipoVehiculoId]
           ,[PlayaDeEstacionamientoId]
           ,[DiaAtencionId]
           ,[TiempoId]
           ,[Monto]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           (1
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,1
           ,1
           ,20
           ,CURRENT_TIMESTAMP
           ,null),
		   (4
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,1
           ,1
           ,10
           ,CURRENT_TIMESTAMP
           ,null),		   
		   (3
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,1
           ,1
           ,15
           ,CURRENT_TIMESTAMP
           ,null)
GO
/*Horarios*/

INSERT INTO [dbo].[Horarios]
           ([HoraDesde]
           ,[HoraHasta]
           ,[DiaAtencionId]
           ,[PlayaDeEstacionamientoId]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           ('08:00'
           ,'23:30'
           ,1
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,CURRENT_TIMESTAMP
           ,null)
GO
/* Servicios*/
INSERT INTO [dbo].[Servicios]
           ([TipoVehiculoId]
           ,[PlayaDeEstacionamientoId]
           ,[Capacidad]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
           (1
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,30
           ,CURRENT_TIMESTAMP
           ,null),
		   (4
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,40
           ,CURRENT_TIMESTAMP
           ,null),
		   (3
           ,(SELECT MAX(id) FROM [dbo].[PlayaDeEstacionamientoes])
           ,30
           ,CURRENT_TIMESTAMP
           ,null)
