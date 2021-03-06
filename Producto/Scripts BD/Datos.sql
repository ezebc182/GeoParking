USE [DB_9B3453_Geoparking]
GO
SET IDENTITY_INSERT [dbo].[TipoPlayas] ON 

INSERT [dbo].[TipoPlayas] ([Id], [Nombre], [Descripcion], [FechaAlta], [FechaBaja]) VALUES (1, N'Techada', N'con techo', CAST(0x0000A37D00000000 AS DateTime), NULL)
INSERT [dbo].[TipoPlayas] ([Id], [Nombre], [Descripcion], [FechaAlta], [FechaBaja]) VALUES (2, N'Descubierta', N'sin techo', CAST(0x0000A38000000000 AS DateTime), NULL)
INSERT [dbo].[TipoPlayas] ([Id], [Nombre], [Descripcion], [FechaAlta], [FechaBaja]) VALUES (3, N'Subterranea', N'Subsuelo de otro edificio', CAST(0x0000A37D00000000 AS DateTime), NULL)
INSERT [dbo].[TipoPlayas] ([Id], [Nombre], [Descripcion], [FechaAlta], [FechaBaja]) VALUES (1010, N'CPA_TipoPlaya1', NULL, CAST(0x0000A38100000000 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[TipoPlayas] OFF
SET IDENTITY_INSERT [dbo].[PlayaDeEstacionamientoes] ON 

INSERT [dbo].[PlayaDeEstacionamientoes] ([Id], [Nombre], [TipoPlayaId], [FechaAlta], [FechaBaja], [Mail], [Telefono]) VALUES (25, N'24 hs', 1, CAST(0x0000A3A100E3276B AS DateTime), NULL, N'24hs@gmail.com', N'4225555')
INSERT [dbo].[PlayaDeEstacionamientoes] ([Id], [Nombre], [TipoPlayaId], [FechaAlta], [FechaBaja], [Mail], [Telefono]) VALUES (26, N'Playa Dean Funes', 1, CAST(0x0000A3A100E32ABB AS DateTime), NULL, N'deanfunes-playa@gmail.com', N'4235489')
INSERT [dbo].[PlayaDeEstacionamientoes] ([Id], [Nombre], [TipoPlayaId], [FechaAlta], [FechaBaja], [Mail], [Telefono]) VALUES (27, N'Playa Duarte Quirós I', 3, CAST(0x0000A3A100E32D34 AS DateTime), NULL, N'duartequiros-playa@gmail.com', N'155220032')
INSERT [dbo].[PlayaDeEstacionamientoes] ([Id], [Nombre], [TipoPlayaId], [FechaAlta], [FechaBaja], [Mail], [Telefono]) VALUES (28, N'Estacionamiento Caseros', 1, CAST(0x0000A3A100E32F89 AS DateTime), NULL, N'estacionamiento-caseros@hotmail.com', N'4243300')
INSERT [dbo].[PlayaDeEstacionamientoes] ([Id], [Nombre], [TipoPlayaId], [FechaAlta], [FechaBaja], [Mail], [Telefono]) VALUES (29, N'Buenos Aires Park', 1, CAST(0x0000A3A100E332D7 AS DateTime), NULL, N'bsaspark@hotmail.com', N'4662288')
INSERT [dbo].[PlayaDeEstacionamientoes] ([Id], [Nombre], [TipoPlayaId], [FechaAlta], [FechaBaja], [Mail], [Telefono]) VALUES (30, N'Playas Velez', 1, CAST(0x0000A3A100E33566 AS DateTime), NULL, N'velezparking@hotmail.com', N'155220033')
INSERT [dbo].[PlayaDeEstacionamientoes] ([Id], [Nombre], [TipoPlayaId], [FechaAlta], [FechaBaja], [Mail], [Telefono]) VALUES (31, N'Playas Illia', 1, CAST(0x0000A3A100E33A05 AS DateTime), NULL, N'playaillia@hotmail.com', N'4231212')
INSERT [dbo].[PlayaDeEstacionamientoes] ([Id], [Nombre], [TipoPlayaId], [FechaAlta], [FechaBaja], [Mail], [Telefono]) VALUES (32, N'Playas Illia', 1, CAST(0x0000A3A100E33C88 AS DateTime), NULL, N'playasillia@hotmail.com', N'4200333')
INSERT [dbo].[PlayaDeEstacionamientoes] ([Id], [Nombre], [TipoPlayaId], [FechaAlta], [FechaBaja], [Mail], [Telefono]) VALUES (33, N'Aparcamiento Sarmiento', 1, CAST(0x0000A3A100E34127 AS DateTime), NULL, N'playa-sarmiento@gmail.com', N'4779922')
INSERT [dbo].[PlayaDeEstacionamientoes] ([Id], [Nombre], [TipoPlayaId], [FechaAlta], [FechaBaja], [Mail], [Telefono]) VALUES (34, N'Estrada Parking', 1, CAST(0x0000A3A100E34426 AS DateTime), NULL, N'playa-estrada@gmail.com', N'4334400')
INSERT [dbo].[PlayaDeEstacionamientoes] ([Id], [Nombre], [TipoPlayaId], [FechaAlta], [FechaBaja], [Mail], [Telefono]) VALUES (35, N'Unquillo Parking', 1, CAST(0x0000A3A100E346BF AS DateTime), NULL, N'playa-unquillo@gmail.com', N'4334400')
INSERT [dbo].[PlayaDeEstacionamientoes] ([Id], [Nombre], [TipoPlayaId], [FechaAlta], [FechaBaja], [Mail], [Telefono]) VALUES (36, N'Rio IV Parking', 1, CAST(0x0000A3A100E34950 AS DateTime), NULL, N'playa-rioiv@gmail.com', N'4554302')
SET IDENTITY_INSERT [dbo].[PlayaDeEstacionamientoes] OFF
SET IDENTITY_INSERT [dbo].[Direccions] ON 

INSERT [dbo].[Direccions] ([Id], [Calle], [Numero], [CiudadId], [PlayaDeEstacionamientoId], [Latitud], [Longitud], [FechaAlta], [FechaBaja]) VALUES (25, N'27 de Abril', 650, 1560, 25, N'-31.414432', N'-64.193366', CAST(0x0000A3A100E32835 AS DateTime), NULL)
INSERT [dbo].[Direccions] ([Id], [Calle], [Numero], [CiudadId], [PlayaDeEstacionamientoId], [Latitud], [Longitud], [FechaAlta], [FechaBaja]) VALUES (26, N'Dean Funes', 942, 1560, 26, N'-31.412051', N'-64.197003', CAST(0x0000A3A100E32B4D AS DateTime), NULL)
INSERT [dbo].[Direccions] ([Id], [Calle], [Numero], [CiudadId], [PlayaDeEstacionamientoId], [Latitud], [Longitud], [FechaAlta], [FechaBaja]) VALUES (27, N'Av Duarte Quirós', 1022, 1560, 27, N'-31.415192', N'-64.199502', CAST(0x0000A3A100E32D9F AS DateTime), NULL)
INSERT [dbo].[Direccions] ([Id], [Calle], [Numero], [CiudadId], [PlayaDeEstacionamientoId], [Latitud], [Longitud], [FechaAlta], [FechaBaja]) VALUES (28, N'Caseros', 502, 1560, 28, N'-31.416126', N'-64.192421', CAST(0x0000A3A100E33167 AS DateTime), NULL)
INSERT [dbo].[Direccions] ([Id], [Calle], [Numero], [CiudadId], [PlayaDeEstacionamientoId], [Latitud], [Longitud], [FechaAlta], [FechaBaja]) VALUES (29, N'Buenos Aires', 220, 1560, 29, N'-31.419376', N'-64.184192', CAST(0x0000A3A100E3336B AS DateTime), NULL)
INSERT [dbo].[Direccions] ([Id], [Calle], [Numero], [CiudadId], [PlayaDeEstacionamientoId], [Latitud], [Longitud], [FechaAlta], [FechaBaja]) VALUES (30, N'Av Vélez Sarsfield', 699, 1560, 30, N'-31.423907', N'-64.190613', CAST(0x0000A3A100E336F9 AS DateTime), NULL)
INSERT [dbo].[Direccions] ([Id], [Calle], [Numero], [CiudadId], [PlayaDeEstacionamientoId], [Latitud], [Longitud], [FechaAlta], [FechaBaja]) VALUES (31, N'Bv. San Juan', 400, 1560, 31, N'-31.419196', N'-64.192354', CAST(0x0000A3A100E33AAF AS DateTime), NULL)
INSERT [dbo].[Direccions] ([Id], [Calle], [Numero], [CiudadId], [PlayaDeEstacionamientoId], [Latitud], [Longitud], [FechaAlta], [FechaBaja]) VALUES (32, N'Bv. Arturo Illia', 202, 1560, 32, N'-31.421503', N'-64.182949', CAST(0x0000A3A100E33D3A AS DateTime), NULL)
INSERT [dbo].[Direccions] ([Id], [Calle], [Numero], [CiudadId], [PlayaDeEstacionamientoId], [Latitud], [Longitud], [FechaAlta], [FechaBaja]) VALUES (33, N'Sarmiento', 100, 1560, 33, N'-31.410652', N'-64.179460', CAST(0x0000A3A100E341E5 AS DateTime), NULL)
INSERT [dbo].[Direccions] ([Id], [Calle], [Numero], [CiudadId], [PlayaDeEstacionamientoId], [Latitud], [Longitud], [FechaAlta], [FechaBaja]) VALUES (34, N'José Manuel Estrada', 100, 1560, 34, N'-31.427371', N'-64.188308', CAST(0x0000A3A100E344CE AS DateTime), NULL)
INSERT [dbo].[Direccions] ([Id], [Calle], [Numero], [CiudadId], [PlayaDeEstacionamientoId], [Latitud], [Longitud], [FechaAlta], [FechaBaja]) VALUES (35, N'Av San Martin ', 2072, 2107, 35, N'-31.234030', N'-64.315794', CAST(0x0000A3A100E3477E AS DateTime), NULL)
INSERT [dbo].[Direccions] ([Id], [Calle], [Numero], [CiudadId], [PlayaDeEstacionamientoId], [Latitud], [Longitud], [FechaAlta], [FechaBaja]) VALUES (36, N'Mendoza', 699, 1982, 36, N'-33.123056', N'-64.353331', CAST(0x0000A3A100E349E0 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Direccions] OFF
SET IDENTITY_INSERT [dbo].[DiaAtencions] ON 

INSERT [dbo].[DiaAtencions] ([Id], [Nombre], [FechaAlta], [FechaBaja]) VALUES (1, N'Lunes-Viernes', CAST(0x0000A38A00000000 AS DateTime), NULL)
INSERT [dbo].[DiaAtencions] ([Id], [Nombre], [FechaAlta], [FechaBaja]) VALUES (2, N'Sabado', CAST(0x0000A38800000000 AS DateTime), NULL)
INSERT [dbo].[DiaAtencions] ([Id], [Nombre], [FechaAlta], [FechaBaja]) VALUES (3, N'Domingo-Feriado', CAST(0x0000A38800000000 AS DateTime), NULL)
INSERT [dbo].[DiaAtencions] ([Id], [Nombre], [FechaAlta], [FechaBaja]) VALUES (1010, N'CPA_DiasDeAtencion1', CAST(0x0000A38100000000 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[DiaAtencions] OFF
SET IDENTITY_INSERT [dbo].[Horarios] ON 

INSERT [dbo].[Horarios] ([Id], [HoraDesde], [HoraHasta], [DiaAtencionId], [PlayaDeEstacionamientoId], [FechaAlta], [FechaBaja]) VALUES (25, N'09:00', N'22:30', 1, 25, CAST(0x0000A3A100E32942 AS DateTime), NULL)
INSERT [dbo].[Horarios] ([Id], [HoraDesde], [HoraHasta], [DiaAtencionId], [PlayaDeEstacionamientoId], [FechaAlta], [FechaBaja]) VALUES (26, N'07:00', N'20:30', 1, 26, CAST(0x0000A3A100E32C80 AS DateTime), NULL)
INSERT [dbo].[Horarios] ([Id], [HoraDesde], [HoraHasta], [DiaAtencionId], [PlayaDeEstacionamientoId], [FechaAlta], [FechaBaja]) VALUES (27, N'09:00', N'21:30', 1, 27, CAST(0x0000A3A100E32EA6 AS DateTime), NULL)
INSERT [dbo].[Horarios] ([Id], [HoraDesde], [HoraHasta], [DiaAtencionId], [PlayaDeEstacionamientoId], [FechaAlta], [FechaBaja]) VALUES (28, N'09:00', N'21:30', 1, 28, CAST(0x0000A3A100E3325E AS DateTime), NULL)
INSERT [dbo].[Horarios] ([Id], [HoraDesde], [HoraHasta], [DiaAtencionId], [PlayaDeEstacionamientoId], [FechaAlta], [FechaBaja]) VALUES (29, N'08:00', N'23:30', 1, 29, CAST(0x0000A3A100E334BA AS DateTime), NULL)
INSERT [dbo].[Horarios] ([Id], [HoraDesde], [HoraHasta], [DiaAtencionId], [PlayaDeEstacionamientoId], [FechaAlta], [FechaBaja]) VALUES (30, N'08:00', N'23:30', 1, 30, CAST(0x0000A3A100E33949 AS DateTime), NULL)
INSERT [dbo].[Horarios] ([Id], [HoraDesde], [HoraHasta], [DiaAtencionId], [PlayaDeEstacionamientoId], [FechaAlta], [FechaBaja]) VALUES (31, N'08:00', N'23:30', 1, 31, CAST(0x0000A3A100E33BC5 AS DateTime), NULL)
INSERT [dbo].[Horarios] ([Id], [HoraDesde], [HoraHasta], [DiaAtencionId], [PlayaDeEstacionamientoId], [FechaAlta], [FechaBaja]) VALUES (32, N'08:00', N'23:30', 1, 32, CAST(0x0000A3A100E33EA7 AS DateTime), NULL)
INSERT [dbo].[Horarios] ([Id], [HoraDesde], [HoraHasta], [DiaAtencionId], [PlayaDeEstacionamientoId], [FechaAlta], [FechaBaja]) VALUES (33, N'08:00', N'23:30', 1, 33, CAST(0x0000A3A100E34333 AS DateTime), NULL)
INSERT [dbo].[Horarios] ([Id], [HoraDesde], [HoraHasta], [DiaAtencionId], [PlayaDeEstacionamientoId], [FechaAlta], [FechaBaja]) VALUES (34, N'08:00', N'23:30', 1, 34, CAST(0x0000A3A100E34628 AS DateTime), NULL)
INSERT [dbo].[Horarios] ([Id], [HoraDesde], [HoraHasta], [DiaAtencionId], [PlayaDeEstacionamientoId], [FechaAlta], [FechaBaja]) VALUES (35, N'08:00', N'23:30', 1, 35, CAST(0x0000A3A100E348D3 AS DateTime), NULL)
INSERT [dbo].[Horarios] ([Id], [HoraDesde], [HoraHasta], [DiaAtencionId], [PlayaDeEstacionamientoId], [FechaAlta], [FechaBaja]) VALUES (36, N'08:00', N'23:30', 1, 36, CAST(0x0000A3A100E34B0C AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Horarios] OFF
SET IDENTITY_INSERT [dbo].[Tiempoes] ON 

INSERT [dbo].[Tiempoes] ([Id], [Nombre], [FechaAlta], [FechaBaja]) VALUES (1, N'Hora', CAST(0x0000A38500000000 AS DateTime), NULL)
INSERT [dbo].[Tiempoes] ([Id], [Nombre], [FechaAlta], [FechaBaja]) VALUES (2, N'12 horas', CAST(0x0000A38500000000 AS DateTime), NULL)
INSERT [dbo].[Tiempoes] ([Id], [Nombre], [FechaAlta], [FechaBaja]) VALUES (3, N'24 horas', CAST(0x0000A38500000000 AS DateTime), NULL)
INSERT [dbo].[Tiempoes] ([Id], [Nombre], [FechaAlta], [FechaBaja]) VALUES (4, N'Mes', CAST(0x0000A38500000000 AS DateTime), NULL)
INSERT [dbo].[Tiempoes] ([Id], [Nombre], [FechaAlta], [FechaBaja]) VALUES (1011, N'CPA_TipoHorario1', CAST(0x0000A38100000000 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Tiempoes] OFF
SET IDENTITY_INSERT [dbo].[TipoVehiculoes] ON 

INSERT [dbo].[TipoVehiculoes] ([Id], [Nombre], [Descripcion], [FechaAlta], [FechaBaja]) VALUES (1, N'Auto', N'Automoviles hasta 1,9mts de altura ', CAST(0x0000A37D00000000 AS DateTime), NULL)
INSERT [dbo].[TipoVehiculoes] ([Id], [Nombre], [Descripcion], [FechaAlta], [FechaBaja]) VALUES (2, N'Utilitario', N'Automoviles de mas de 1,9mts de altura', CAST(0x0000A38000000000 AS DateTime), NULL)
INSERT [dbo].[TipoVehiculoes] ([Id], [Nombre], [Descripcion], [FechaAlta], [FechaBaja]) VALUES (3, N'Moto', N'Motocicletas de todo tipo', CAST(0x0000A37D00000000 AS DateTime), NULL)
INSERT [dbo].[TipoVehiculoes] ([Id], [Nombre], [Descripcion], [FechaAlta], [FechaBaja]) VALUES (4, N'Bicicleta', N'Bicicletas de todo tipo de rodado', CAST(0x0000A3A100000000 AS DateTime), NULL)
INSERT [dbo].[TipoVehiculoes] ([Id], [Nombre], [Descripcion], [FechaAlta], [FechaBaja]) VALUES (17, N'CPA_TipoVehiculo1', NULL, CAST(0x0000A38100000000 AS DateTime), NULL)
INSERT [dbo].[TipoVehiculoes] ([Id], [Nombre], [Descripcion], [FechaAlta], [FechaBaja]) VALUES (18, N'CPA_TipoVehiculo2', NULL, CAST(0x0000A38100000000 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[TipoVehiculoes] OFF
SET IDENTITY_INSERT [dbo].[Precios] ON 

INSERT [dbo].[Precios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [DiaAtencionId], [TiempoId], [Monto], [FechaAlta], [FechaBaja]) VALUES (42, 1, 25, 1, 1, 22.0000, CAST(0x0000A3A100E32896 AS DateTime), NULL)
INSERT [dbo].[Precios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [DiaAtencionId], [TiempoId], [Monto], [FechaAlta], [FechaBaja]) VALUES (43, 1, 26, 1, 1, 18.0000, CAST(0x0000A3A100E32BD9 AS DateTime), NULL)
INSERT [dbo].[Precios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [DiaAtencionId], [TiempoId], [Monto], [FechaAlta], [FechaBaja]) VALUES (44, 3, 27, 1, 1, 9.0000, CAST(0x0000A3A100E32E11 AS DateTime), NULL)
INSERT [dbo].[Precios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [DiaAtencionId], [TiempoId], [Monto], [FechaAlta], [FechaBaja]) VALUES (45, 4, 28, 1, 1, 9.0000, CAST(0x0000A3A100E331ED AS DateTime), NULL)
INSERT [dbo].[Precios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [DiaAtencionId], [TiempoId], [Monto], [FechaAlta], [FechaBaja]) VALUES (46, 4, 29, 1, 1, 12.0000, CAST(0x0000A3A100E3340F AS DateTime), NULL)
INSERT [dbo].[Precios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [DiaAtencionId], [TiempoId], [Monto], [FechaAlta], [FechaBaja]) VALUES (47, 1, 30, 1, 1, 23.0000, CAST(0x0000A3A100E337A2 AS DateTime), NULL)
INSERT [dbo].[Precios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [DiaAtencionId], [TiempoId], [Monto], [FechaAlta], [FechaBaja]) VALUES (48, 4, 30, 1, 1, 12.0000, CAST(0x0000A3A100E337A2 AS DateTime), NULL)
INSERT [dbo].[Precios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [DiaAtencionId], [TiempoId], [Monto], [FechaAlta], [FechaBaja]) VALUES (49, 1, 31, 1, 1, 23.0000, CAST(0x0000A3A100E33B1A AS DateTime), NULL)
INSERT [dbo].[Precios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [DiaAtencionId], [TiempoId], [Monto], [FechaAlta], [FechaBaja]) VALUES (50, 3, 31, 1, 1, 30.0000, CAST(0x0000A3A100E33B1A AS DateTime), NULL)
INSERT [dbo].[Precios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [DiaAtencionId], [TiempoId], [Monto], [FechaAlta], [FechaBaja]) VALUES (51, 1, 32, 1, 1, 26.0000, CAST(0x0000A3A100E33DF3 AS DateTime), NULL)
INSERT [dbo].[Precios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [DiaAtencionId], [TiempoId], [Monto], [FechaAlta], [FechaBaja]) VALUES (52, 3, 32, 1, 1, 40.0000, CAST(0x0000A3A100E33DF3 AS DateTime), NULL)
INSERT [dbo].[Precios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [DiaAtencionId], [TiempoId], [Monto], [FechaAlta], [FechaBaja]) VALUES (53, 1, 33, 1, 1, 16.0000, CAST(0x0000A3A100E3427E AS DateTime), NULL)
INSERT [dbo].[Precios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [DiaAtencionId], [TiempoId], [Monto], [FechaAlta], [FechaBaja]) VALUES (54, 4, 33, 1, 1, 10.0000, CAST(0x0000A3A100E3427E AS DateTime), NULL)
INSERT [dbo].[Precios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [DiaAtencionId], [TiempoId], [Monto], [FechaAlta], [FechaBaja]) VALUES (55, 1, 34, 1, 1, 20.0000, CAST(0x0000A3A100E3457B AS DateTime), NULL)
INSERT [dbo].[Precios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [DiaAtencionId], [TiempoId], [Monto], [FechaAlta], [FechaBaja]) VALUES (56, 4, 34, 1, 1, 10.0000, CAST(0x0000A3A100E3457B AS DateTime), NULL)
INSERT [dbo].[Precios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [DiaAtencionId], [TiempoId], [Monto], [FechaAlta], [FechaBaja]) VALUES (57, 3, 34, 1, 1, 15.0000, CAST(0x0000A3A100E3457B AS DateTime), NULL)
INSERT [dbo].[Precios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [DiaAtencionId], [TiempoId], [Monto], [FechaAlta], [FechaBaja]) VALUES (58, 1, 35, 1, 1, 20.0000, CAST(0x0000A3A100E3482B AS DateTime), NULL)
INSERT [dbo].[Precios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [DiaAtencionId], [TiempoId], [Monto], [FechaAlta], [FechaBaja]) VALUES (59, 4, 35, 1, 1, 10.0000, CAST(0x0000A3A100E3482B AS DateTime), NULL)
INSERT [dbo].[Precios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [DiaAtencionId], [TiempoId], [Monto], [FechaAlta], [FechaBaja]) VALUES (60, 3, 35, 1, 1, 15.0000, CAST(0x0000A3A100E3482B AS DateTime), NULL)
INSERT [dbo].[Precios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [DiaAtencionId], [TiempoId], [Monto], [FechaAlta], [FechaBaja]) VALUES (61, 1, 36, 1, 1, 20.0000, CAST(0x0000A3A100E34A69 AS DateTime), NULL)
INSERT [dbo].[Precios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [DiaAtencionId], [TiempoId], [Monto], [FechaAlta], [FechaBaja]) VALUES (62, 4, 36, 1, 1, 10.0000, CAST(0x0000A3A100E34A69 AS DateTime), NULL)
INSERT [dbo].[Precios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [DiaAtencionId], [TiempoId], [Monto], [FechaAlta], [FechaBaja]) VALUES (63, 3, 36, 1, 1, 15.0000, CAST(0x0000A3A100E34A69 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Precios] OFF
SET IDENTITY_INSERT [dbo].[Servicios] ON 

INSERT [dbo].[Servicios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [Capacidad], [FechaAlta], [FechaBaja]) VALUES (42, 1, 25, 40, CAST(0x0000A3A100E32A32 AS DateTime), NULL)
INSERT [dbo].[Servicios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [Capacidad], [FechaAlta], [FechaBaja]) VALUES (43, 1, 26, 60, CAST(0x0000A3A100E32D34 AS DateTime), NULL)
INSERT [dbo].[Servicios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [Capacidad], [FechaAlta], [FechaBaja]) VALUES (44, 3, 27, 25, CAST(0x0000A3A100E32F89 AS DateTime), NULL)
INSERT [dbo].[Servicios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [Capacidad], [FechaAlta], [FechaBaja]) VALUES (45, 4, 28, 25, CAST(0x0000A3A100E332D7 AS DateTime), NULL)
INSERT [dbo].[Servicios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [Capacidad], [FechaAlta], [FechaBaja]) VALUES (46, 4, 29, 30, CAST(0x0000A3A100E33565 AS DateTime), NULL)
INSERT [dbo].[Servicios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [Capacidad], [FechaAlta], [FechaBaja]) VALUES (47, 1, 30, 30, CAST(0x0000A3A100E33A05 AS DateTime), NULL)
INSERT [dbo].[Servicios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [Capacidad], [FechaAlta], [FechaBaja]) VALUES (48, 4, 30, 10, CAST(0x0000A3A100E33A05 AS DateTime), NULL)
INSERT [dbo].[Servicios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [Capacidad], [FechaAlta], [FechaBaja]) VALUES (49, 1, 31, 30, CAST(0x0000A3A100E33C88 AS DateTime), NULL)
INSERT [dbo].[Servicios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [Capacidad], [FechaAlta], [FechaBaja]) VALUES (50, 3, 31, 20, CAST(0x0000A3A100E33C88 AS DateTime), NULL)
INSERT [dbo].[Servicios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [Capacidad], [FechaAlta], [FechaBaja]) VALUES (51, 1, 32, 22, CAST(0x0000A3A100E34127 AS DateTime), NULL)
INSERT [dbo].[Servicios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [Capacidad], [FechaAlta], [FechaBaja]) VALUES (52, 3, 32, 12, CAST(0x0000A3A100E34127 AS DateTime), NULL)
INSERT [dbo].[Servicios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [Capacidad], [FechaAlta], [FechaBaja]) VALUES (53, 1, 33, 30, CAST(0x0000A3A100E34425 AS DateTime), NULL)
INSERT [dbo].[Servicios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [Capacidad], [FechaAlta], [FechaBaja]) VALUES (54, 4, 33, 40, CAST(0x0000A3A100E34425 AS DateTime), NULL)
INSERT [dbo].[Servicios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [Capacidad], [FechaAlta], [FechaBaja]) VALUES (55, 1, 34, 30, CAST(0x0000A3A100E346BE AS DateTime), NULL)
INSERT [dbo].[Servicios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [Capacidad], [FechaAlta], [FechaBaja]) VALUES (56, 4, 34, 40, CAST(0x0000A3A100E346BE AS DateTime), NULL)
INSERT [dbo].[Servicios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [Capacidad], [FechaAlta], [FechaBaja]) VALUES (57, 3, 34, 30, CAST(0x0000A3A100E346BE AS DateTime), NULL)
INSERT [dbo].[Servicios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [Capacidad], [FechaAlta], [FechaBaja]) VALUES (58, 1, 35, 30, CAST(0x0000A3A100E3494B AS DateTime), NULL)
INSERT [dbo].[Servicios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [Capacidad], [FechaAlta], [FechaBaja]) VALUES (59, 4, 35, 40, CAST(0x0000A3A100E3494B AS DateTime), NULL)
INSERT [dbo].[Servicios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [Capacidad], [FechaAlta], [FechaBaja]) VALUES (60, 3, 35, 30, CAST(0x0000A3A100E3494B AS DateTime), NULL)
INSERT [dbo].[Servicios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [Capacidad], [FechaAlta], [FechaBaja]) VALUES (61, 1, 36, 30, CAST(0x0000A3A100E34BA0 AS DateTime), NULL)
INSERT [dbo].[Servicios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [Capacidad], [FechaAlta], [FechaBaja]) VALUES (62, 4, 36, 40, CAST(0x0000A3A100E34BA0 AS DateTime), NULL)
INSERT [dbo].[Servicios] ([Id], [TipoVehiculoId], [PlayaDeEstacionamientoId], [Capacidad], [FechaAlta], [FechaBaja]) VALUES (63, 3, 36, 30, CAST(0x0000A3A100E34BA0 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Servicios] OFF
SET IDENTITY_INSERT [dbo].[Rols] ON 

INSERT [dbo].[Rols] ([Id], [Nombre], [Descripcion], [FechaAlta], [FechaBaja]) VALUES (1, N'Registrado', N'rol a asignar a un usuario cuando se registra por primera vez', CAST(0x0000A39C01519F43 AS DateTime), NULL)
INSERT [dbo].[Rols] ([Id], [Nombre], [Descripcion], [FechaAlta], [FechaBaja]) VALUES (2, N'Administrador', N'Rol para los usuarios encargados de administrar las playas de estacionamiento', CAST(0x0000A38800C9AE52 AS DateTime), NULL)
INSERT [dbo].[Rols] ([Id], [Nombre], [Descripcion], [FechaAlta], [FechaBaja]) VALUES (3, N'Superadministrador', N'Rol para el usuario encargado de asignar roles a los demas usuarios, crear roles y asignar permisos a cada rol', CAST(0x0000A38800C9F39D AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Rols] OFF
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([Id], [NombreUsuario], [Contraseña], [Apellido], [Mail], [Nombre], [RolId], [FechaAlta], [FechaBaja]) VALUES (6, N'geo_admin', N'Jk6gYVl8BTI=', N'admin', N'admin@geoparking.com', N'admin', 1, CAST(0x0000A39E01525A5E AS DateTime), NULL)
INSERT [dbo].[Usuarios] ([Id], [NombreUsuario], [Contraseña], [Apellido], [Mail], [Nombre], [RolId], [FechaAlta], [FechaBaja]) VALUES (1009, N'superadmin', N'Jk6gYVl8BTI=', N'superadmin', N'superadmin@geoparking.com', N'superadmin', 3, CAST(0x0000A3A601550717 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
SET IDENTITY_INSERT [dbo].[Permisoes] ON 

INSERT [dbo].[Permisoes] ([Id], [Nombre], [Url], [Acceso], [FechaAlta], [FechaBaja]) VALUES (4, N'BusquedaPlaya', N'BusquedaPlaya.aspx', 1, CAST(0x0000A38000000000 AS DateTime), NULL)
INSERT [dbo].[Permisoes] ([Id], [Nombre], [Url], [Acceso], [FechaAlta], [FechaBaja]) VALUES (5, N'Index', N'Index.aspx', 1, CAST(0x0000A38000000000 AS DateTime), NULL)
INSERT [dbo].[Permisoes] ([Id], [Nombre], [Url], [Acceso], [FechaAlta], [FechaBaja]) VALUES (6, N'Playa', N'Playa.aspx', 1, CAST(0x0000A38000000000 AS DateTime), NULL)
INSERT [dbo].[Permisoes] ([Id], [Nombre], [Url], [Acceso], [FechaAlta], [FechaBaja]) VALUES (7, N'AdministracionUsuarios', N'AdministracionUsuarios.aspx', 1, CAST(0x0000A39E00000000 AS DateTime), NULL)
INSERT [dbo].[Permisoes] ([Id], [Nombre], [Url], [Acceso], [FechaAlta], [FechaBaja]) VALUES (13, N'CPA_Permiso', N'CPA_Url', 1, CAST(0x0000A38100000000 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Permisoes] OFF
INSERT [dbo].[RolPermisoes] ([Rol_Id], [Permiso_Id]) VALUES (1, 4)
INSERT [dbo].[RolPermisoes] ([Rol_Id], [Permiso_Id]) VALUES (2, 4)
INSERT [dbo].[RolPermisoes] ([Rol_Id], [Permiso_Id]) VALUES (3, 4)
INSERT [dbo].[RolPermisoes] ([Rol_Id], [Permiso_Id]) VALUES (1, 5)
INSERT [dbo].[RolPermisoes] ([Rol_Id], [Permiso_Id]) VALUES (2, 5)
INSERT [dbo].[RolPermisoes] ([Rol_Id], [Permiso_Id]) VALUES (3, 5)
INSERT [dbo].[RolPermisoes] ([Rol_Id], [Permiso_Id]) VALUES (2, 6)
INSERT [dbo].[RolPermisoes] ([Rol_Id], [Permiso_Id]) VALUES (3, 6)
INSERT [dbo].[RolPermisoes] ([Rol_Id], [Permiso_Id]) VALUES (3, 7)
