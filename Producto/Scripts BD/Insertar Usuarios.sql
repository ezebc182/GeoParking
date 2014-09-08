/************************************
Script Usuarios
@ezebc182
070914
*************************************/

USE [BD_Geoparking]
GO

INSERT INTO [dbo].[Usuarios]
           ([NombreUsuario]
           ,[Contraseña]
           ,[Apellido]
           ,[Mail]
           ,[Nombre]
           ,[RolId]
           ,[FechaAlta]
           ,[FechaBaja])
     VALUES
	 --ADMINISTRADOR--
           ('geo_admin'
           ,123
           ,'geo_admin'
           ,'geo_admin@geoparking.com'
           ,'geo_admin'
           ,2
           ,CURRENT_TIMESTAMP
           ,NULL),
	-- SUPER ADMINISTRADOR --
		   ('geo_superadmin'
           ,123
           ,'geo_superadmin'
           ,'geo_superadmin@geoparking.com'
           ,'geo_superadmin'
           ,3
           ,CURRENT_TIMESTAMP
           ,NULL),
	-- REGISTRADO --
		   ('geo_user'
           ,123
           ,'geo_user'
           ,'geo_user@geoparking.com'
           ,'geo_user'
           ,1
           ,CURRENT_TIMESTAMP
           ,NULL)



