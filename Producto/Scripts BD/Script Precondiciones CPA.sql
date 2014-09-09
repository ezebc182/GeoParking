-- Se borran los datos que puedan quedar de otros CPA
	
	--Se borrran las relaciones
DELETE FROM Direccions WHERE PlayaDeEstacionamientoId in (SELECT Id FROM PlayaDeEstacionamientoes p WHERE p.Nombre LIKE 'CPA_%')
DELETE FROM Horarios WHERE PlayaDeEstacionamientoId in (SELECT Id FROM PlayaDeEstacionamientoes p WHERE p.Nombre LIKE 'CPA_%')
DELETE FROM Precios WHERE PlayaDeEstacionamientoId in (SELECT Id FROM PlayaDeEstacionamientoes p WHERE p.Nombre LIKE 'CPA_%')
DELETE FROM Servicios WHERE PlayaDeEstacionamientoId in (SELECT Id FROM PlayaDeEstacionamientoes p WHERE p.Nombre LIKE 'CPA_%')
	
	--Se borran los datos
DELETE FROM PlayaDeEstacionamientoes WHERE Nombre LIKE 'CPA_%';
DELETE FROM DiaAtencions WHERE Nombre LIKE 'CPA_%';
DELETE FROM Tiempoes WHERE Nombre LIKE 'CPA_%';
DELETE FROM TipoPlayas WHERE Nombre LIKE 'CPA_%';
DELETE FROM Ciudads WHERE Nombre LIKE 'CPA_%';
DELETE FROM Departamentoes WHERE Nombre LIKE 'CPA_%';
DELETE FROM Permisoes WHERE Nombre LIKE 'CPA_%';
DELETE FROM Provincias WHERE Nombre LIKE 'CPA_%';
DELETE FROM Rols WHERE Nombre LIKE 'CPA_%';
DELETE FROM TipoVehiculoes WHERE Nombre LIKE 'CPA_%';


-- Se agregan los datos necesarios para correr los test cases automaticos

INSERT INTO DiaAtencions (Nombre, FechaAlta) VALUES ('CPA_DiasDeAtencion1', '2014/08/08');
INSERT INTO Tiempoes  (Nombre, FechaAlta) VALUES ('CPA_TipoHorario1', '2014/08/08');
INSERT INTO TipoPlayas (Nombre, FechaAlta) VALUES ('CPA_TipoPlaya1', '2014/08/08');
INSERT INTO TipoVehiculoes (Nombre, FechaAlta) VALUES ('CPA_TipoVehiculo1', '2014/08/08');
INSERT INTO TipoVehiculoes (Nombre, FechaAlta) VALUES ('CPA_TipoVehiculo2', '2014/08/08');
INSERT INTO Permisoes (Nombre, Url, Acceso, FechaAlta) VALUES ('CPA_Permiso', 'CPA_Url', '1', '2014/08/08');
