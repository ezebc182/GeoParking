-- Se borran los datos que puedan quedar de otros CPA
	
	--Se borrran las relaciones
DELETE FROM Direccions;
DELETE FROM Horarios;
DELETE FROM Precios;
DELETE FROM Servicios;
	
	--Se borran los datos
DELETE FROM PlayaDeEstacionamientoes;
DELETE FROM DiaAtencions;
DELETE FROM Tiempoes;
DELETE FROM TipoPlayas;
DELETE FROM Ciudads WHERE Nombre LIKE 'CPA_%';
DELETE FROM Departamentoes WHERE Nombre LIKE 'CPA_%';
DELETE FROM Permisoes WHERE Nombre LIKE 'CPA_%';
DELETE FROM Provincias WHERE Nombre LIKE 'CPA_%';
DELETE FROM Rols  WHERE Nombre LIKE 'CPA_%';
DELETE FROM TipoVehiculoes;


-- Se agregan los datos necesarios para correr los test cases automaticos

INSERT INTO DiaAtencions (Nombre, FechaAlta) VALUES ('CPA_DiasDeAtencion1', '2014/08/08');
INSERT INTO Tiempoes  (Nombre, FechaAlta) VALUES ('CPA_TipoHorario1', '2014/08/08');
INSERT INTO TipoPlayas (Nombre, FechaAlta) VALUES ('CPA_TipoPlaya1', '2014/08/08');
INSERT INTO TipoVehiculoes (Nombre, FechaAlta) VALUES ('CPA_TipoVehiculo1', '2014/08/08');
INSERT INTO TipoVehiculoes (Nombre, FechaAlta) VALUES ('CPA_TipoVehiculo2', '2014/08/08');
INSERT INTO Permisoes (Nombre, Url, Acceso, FechaAlta) VALUES ('CPA_Permiso', 'CPA_Url', '1', '2014/08/08');
