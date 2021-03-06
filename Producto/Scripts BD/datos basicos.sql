USE [DB_9B3453_Geoparking]
GO
SET IDENTITY_INSERT [dbo].[Rols] ON 

INSERT [dbo].[Rols] ([Id], [Nombre], [Descripcion], [FechaAlta], [FechaBaja]) VALUES (1, N'Registrado', N'rol a asignar a un usuario cuando se registra por primera vez', CAST(0x0000A39C01519F43 AS DateTime), NULL)
INSERT [dbo].[Rols] ([Id], [Nombre], [Descripcion], [FechaAlta], [FechaBaja]) VALUES (2, N'Administrador', N'Rol para los usuarios encargados de administrar las playas de estacionamiento', CAST(0x0000A38800C9AE52 AS DateTime), NULL)
INSERT [dbo].[Rols] ([Id], [Nombre], [Descripcion], [FechaAlta], [FechaBaja]) VALUES (3, N'Superadministrador', N'Rol para el usuario encargado de asignar roles a los demas usuarios, crear roles y asignar permisos a cada rol', CAST(0x0000A38800C9F39D AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Rols] OFF
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([Id], [NombreUsuario], [Contraseña], [Apellido], [Mail], [Nombre], [RolId], [FechaAlta], [FechaBaja]) VALUES (6, N'geo_admin', N'Jk6gYVl8BTI=', N'admin', N'admin@geoparking.com', N'admin', 2, CAST(0x0000A39E01525A5E AS DateTime), NULL)
INSERT [dbo].[Usuarios] ([Id], [NombreUsuario], [Contraseña], [Apellido], [Mail], [Nombre], [RolId], [FechaAlta], [FechaBaja]) VALUES (1009, N'superadmin', N'Jk6gYVl8BTI=', N'superadmin', N'superadmin@geoparking.com', N'superadmin', 3, CAST(0x0000A3A601550717 AS DateTime), NULL)
INSERT [dbo].[Usuarios] ([Id], [NombreUsuario], [Contraseña], [Apellido], [Mail], [Nombre], [RolId], [FechaAlta], [FechaBaja]) VALUES (2007, N'ezebc182', N'Jk6gYVl8BTI=', N'Bär Coch', N'eebarcoch@gmail.com', N'Eze', 3, CAST(0x0000A3AF011EFBED AS DateTime), NULL)
INSERT [dbo].[Usuarios] ([Id], [NombreUsuario], [Contraseña], [Apellido], [Mail], [Nombre], [RolId], [FechaAlta], [FechaBaja]) VALUES (2008, N'picante', N'ClZ4fiRaU1Y=', N'pereyra', N'pica@gmail.com', N'picante', 1, CAST(0x0000A3BD0102FC87 AS DateTime), NULL)
INSERT [dbo].[Usuarios] ([Id], [NombreUsuario], [Contraseña], [Apellido], [Mail], [Nombre], [RolId], [FechaAlta], [FechaBaja]) VALUES (2011, N'lucastoneatto', N'uf5aILdP3j8=', N'Toneatto', N'lucastoneatto@gmail.com', N'Lucas', 1, CAST(0x0000A3C60117C55B AS DateTime), NULL)
INSERT [dbo].[Usuarios] ([Id], [NombreUsuario], [Contraseña], [Apellido], [Mail], [Nombre], [RolId], [FechaAlta], [FechaBaja]) VALUES (2021, N'cuquimarquez', N'oUU/KAMBh64=', N'Marquez', N'fer@cuqui.com', N'Fernando', 3, CAST(0x0000A3D9007F5D2E AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
INSERT [dbo].[Permisoes] ([Id], [Nombre], [Url], [Acceso], [FechaAlta], [FechaBaja]) VALUES (1, N'BusquedaPlaya', N'BusquedaPlaya.aspx', 1, CAST(0x0000A38000000000 AS DateTime), NULL)
INSERT [dbo].[Permisoes] ([Id], [Nombre], [Url], [Acceso], [FechaAlta], [FechaBaja]) VALUES (2, N'Index', N'Index.aspx', 1, CAST(0x0000A38000000000 AS DateTime), NULL)
INSERT [dbo].[Permisoes] ([Id], [Nombre], [Url], [Acceso], [FechaAlta], [FechaBaja]) VALUES (3, N'Playa', N'Playa.aspx', 1, CAST(0x0000A38000000000 AS DateTime), NULL)
INSERT [dbo].[Permisoes] ([Id], [Nombre], [Url], [Acceso], [FechaAlta], [FechaBaja]) VALUES (4, N'AdministracionUsuarios', N'AdministracionUsuarios.aspx', 1, CAST(0x0000A39E00000000 AS DateTime), NULL)
INSERT [dbo].[Permisoes] ([Id], [Nombre], [Url], [Acceso], [FechaAlta], [FechaBaja]) VALUES (5, N'Contacto', N'Contacto.aspx', 1, CAST(0x0000A39E00000000 AS DateTime), NULL)
INSERT [dbo].[Permisoes] ([Id], [Nombre], [Url], [Acceso], [FechaAlta], [FechaBaja]) VALUES (6, N'Ayuda', N'Ayuda.aspx', 1, CAST(0x0000A39E00000000 AS DateTime), NULL)
INSERT [dbo].[Permisoes] ([Id], [Nombre], [Url], [Acceso], [FechaAlta], [FechaBaja]) VALUES (7, N'Estadisticas', N'Estadisticas.aspx', 1, CAST(0x0000A39E00000000 AS DateTime), NULL)
INSERT [dbo].[RolPermisoes] ([Rol_Id], [Permiso_Id]) VALUES (1, 1)
INSERT [dbo].[RolPermisoes] ([Rol_Id], [Permiso_Id]) VALUES (2, 1)
INSERT [dbo].[RolPermisoes] ([Rol_Id], [Permiso_Id]) VALUES (3, 1)
INSERT [dbo].[RolPermisoes] ([Rol_Id], [Permiso_Id]) VALUES (1, 2)
INSERT [dbo].[RolPermisoes] ([Rol_Id], [Permiso_Id]) VALUES (2, 2)
INSERT [dbo].[RolPermisoes] ([Rol_Id], [Permiso_Id]) VALUES (3, 2)
INSERT [dbo].[RolPermisoes] ([Rol_Id], [Permiso_Id]) VALUES (2, 3)
INSERT [dbo].[RolPermisoes] ([Rol_Id], [Permiso_Id]) VALUES (3, 3)
INSERT [dbo].[RolPermisoes] ([Rol_Id], [Permiso_Id]) VALUES (3, 4)
INSERT [dbo].[RolPermisoes] ([Rol_Id], [Permiso_Id]) VALUES (1, 5)
INSERT [dbo].[RolPermisoes] ([Rol_Id], [Permiso_Id]) VALUES (2, 5)
INSERT [dbo].[RolPermisoes] ([Rol_Id], [Permiso_Id]) VALUES (3, 5)
INSERT [dbo].[RolPermisoes] ([Rol_Id], [Permiso_Id]) VALUES (1, 6)
INSERT [dbo].[RolPermisoes] ([Rol_Id], [Permiso_Id]) VALUES (2, 6)
INSERT [dbo].[RolPermisoes] ([Rol_Id], [Permiso_Id]) VALUES (3, 6)
INSERT [dbo].[RolPermisoes] ([Rol_Id], [Permiso_Id]) VALUES (2, 7)
INSERT [dbo].[RolPermisoes] ([Rol_Id], [Permiso_Id]) VALUES (3, 7)
SET IDENTITY_INSERT [dbo].[DiaAtencions] ON 

INSERT [dbo].[DiaAtencions] ([Id], [Nombre], [FechaAlta], [FechaBaja]) VALUES (1, N'Lunes - Viernes', CAST(0x0000A38A00000000 AS DateTime), NULL)
INSERT [dbo].[DiaAtencions] ([Id], [Nombre], [FechaAlta], [FechaBaja]) VALUES (2, N'Lunes - Sabado', CAST(0x0000A38800000000 AS DateTime), NULL)
INSERT [dbo].[DiaAtencions] ([Id], [Nombre], [FechaAlta], [FechaBaja]) VALUES (3, N'Lunes - Domingo', CAST(0x0000A38800000000 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[DiaAtencions] OFF
INSERT [dbo].[Tiempoes] ([Nombre], [FechaAlta], [FechaBaja]) VALUES (N'Hora', CAST(0x0000A38500000000 AS DateTime), NULL)
INSERT [dbo].[Tiempoes] ([Nombre], [FechaAlta], [FechaBaja]) VALUES (N'6 Horas', CAST(0x0000A41000000000 AS DateTime), NULL)
INSERT [dbo].[Tiempoes] ([Nombre], [FechaAlta], [FechaBaja]) VALUES (N'12 Horas', CAST(0x0000A38500000000 AS DateTime), NULL)
INSERT [dbo].[Tiempoes] ([Nombre], [FechaAlta], [FechaBaja]) VALUES (N'24 Horas', CAST(0x0000A38500000000 AS DateTime), NULL)
INSERT [dbo].[Tiempoes] ([Nombre], [FechaAlta], [FechaBaja]) VALUES (N'Mes', CAST(0x0000A38500000000 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[TipoPlayas] ON 

INSERT [dbo].[TipoPlayas] ([Id], [Nombre], [Descripcion], [FechaAlta], [FechaBaja]) VALUES (1, N'Techada', N'con techo', CAST(0x0000A37D00000000 AS DateTime), NULL)
INSERT [dbo].[TipoPlayas] ([Id], [Nombre], [Descripcion], [FechaAlta], [FechaBaja]) VALUES (2, N'Descubierta', N'sin techo', CAST(0x0000A38000000000 AS DateTime), NULL)
INSERT [dbo].[TipoPlayas] ([Id], [Nombre], [Descripcion], [FechaAlta], [FechaBaja]) VALUES (3, N'Subterranea', N'Subsuelo de otro edificio', CAST(0x0000A37D00000000 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[TipoPlayas] OFF
SET IDENTITY_INSERT [dbo].[TipoVehiculoes] ON 

INSERT [dbo].[TipoVehiculoes] ([Id], [Nombre], [Descripcion], [FechaAlta], [FechaBaja]) VALUES (1, N'Auto', N'Automoviles hasta 1,9mts de altura ', CAST(0x0000A37D00000000 AS DateTime), NULL)
INSERT [dbo].[TipoVehiculoes] ([Id], [Nombre], [Descripcion], [FechaAlta], [FechaBaja]) VALUES (2, N'Utilitario', N'Automoviles de mas de 1,9mts de altura', CAST(0x0000A38000000000 AS DateTime), NULL)
INSERT [dbo].[TipoVehiculoes] ([Id], [Nombre], [Descripcion], [FechaAlta], [FechaBaja]) VALUES (3, N'Moto', N'Motocicletas de todo tipo', CAST(0x0000A37D00000000 AS DateTime), NULL)
INSERT [dbo].[TipoVehiculoes] ([Id], [Nombre], [Descripcion], [FechaAlta], [FechaBaja]) VALUES (4, N'Bicicleta', N'Bicicletas de todo tipo de rodado', CAST(0x0000A3A100000000 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[TipoVehiculoes] OFF
