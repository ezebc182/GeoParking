-- Script bucle para actualizar tabla mensual, datos de Enero a Julio.
-- Los datos de tablas, campos, etc�tera son ficticios.
 
DECLARE @anyo as int
DECLARE @mes  as int
DECLARE @fecIniMes as datetime
DECLARE @playa as int
DECLARE @tipoPlaya as int
DECLARE @tipoVehiculo as int
DECLARE @latitud as decimal(9,7)
DECLARE @longitud as decimal(9,7) 

SET @anyo = 2013
SET @mes  = 0
SET @playa = 0
SET @tipoPlaya = 0
SET @tipoVehiculo = 0
SET @latitud = 00.0000000
SET @longitud = 00.0000000

WHILE @anyo < 2015 -- Desde 2001 - 2014
BEGIN
SET @anyo  = @anyo + 1
SET @mes = 0
WHILE @mes < 13
BEGIN

SET @mes = @mes + 1
  SET @fecIniMes =  cast( '01/' + cast(@mes as varchar) + '/'
                    + cast(@anyo as varchar)  as datetime)

DECLARE @i as int
DECLARE @randomCorte as int
SET @i = 0
SET @randomCorte = ROUND( 8 + rand()*6, 0)
WHILE @i < @randomCorte
BEGIN
  SET @i = @i + 1
  
 SET @playa = 24 + ROUND(rand() * 37 + 1, 0)
 SET @tipoPlaya = (SELECT p.TipoPlayaId
					FROM PlayaDeEstacionamientoes as p
					WHERE p.Id = 25)
  SET @tipoVehiculo = ROUND(rand() * 3 + 1, 0)
  
  DECLARE @random as decimal(7,5)
  SET @random = rand()
  
  DECLARE @rLat as int
  DECLARE @rlong as int
  IF rand() > 0.5
	SET @rLat = 1
  ELSE 
	SET @rLat = -1
  
  IF rand() > 0.5
	SET @rlong = 1
  ELSE 
	SET @rlong = -1
  

  IF @anyo < 2002 
  BEGIN	 
	 IF (@random < 0.3) 
		BEGIN
			SET @latitud = -31.419706 + (rand()/120);
			SET @longitud = -64.190120 + (rand()/120);
		END
		ELSE 
		BEGIN
			IF (@random < 0.7)
			BEGIN
				SET @latitud = -31.419706 + (rand()/50);
				SET @longitud = -64.190120 + (rand()/50);
			END
			ELSE
				BEGIN
					SET @latitud = -31.419706 + (rand()/15);
					SET @longitud = -64.190120 + (rand()/15);
				END
		END
	END
	ELSE
	IF @anyo < 2015 
  BEGIN	 
	 IF (@random < 0.5) 
		BEGIN
			SET @latitud = -31.396557 + (@rLat * rand()/120);
			SET @longitud = -64.207458 + (@rLong * rand()/120);
		END
		ELSE 
		BEGIN
			IF (@random < 0.8)
			BEGIN
				SET @latitud = -31.419706 + (@rLat * rand()/50);
				SET @longitud = -64.207458 + (@rLong * rand()/50);
			END
			ELSE
				BEGIN
					SET @latitud = -31.419706 + (@rLat * rand()/17);
					SET @longitud = -64.207458 + (@rLong * rand()/17);
				END
		END
	END
	ELSE
	IF @anyo < 2016 
  BEGIN	 
	 IF (@random < 0.5) 
		BEGIN
			SET @latitud = -31.394213 + (@rLat * rand()/120);
			SET @longitud = -64.172439 + (@rLong * rand()/120);
		END
		ELSE 
		BEGIN
			IF (@random < 0.8)
			BEGIN
				SET @latitud = -31.394213 + (@rLat * rand()/50);
				SET @longitud = -64.172439 + (@rLong * rand()/50);
			END
			ELSE
				BEGIN
					SET @latitud = -31.394213 + (@rLat * rand()/17);
					SET @longitud = -64.172439 + (@rLong * rand()/17);
				END
		END
	END
	ELSE
	IF @anyo < 2018 
  BEGIN	 
	 IF (@random < 0.3) 
		BEGIN
			SET @latitud = -31.419706 + (rand()/100);
			SET @longitud = -64.190120 + (rand()/100);
		END
		ELSE 
		BEGIN
			IF (@random < 0.7)
			BEGIN
				SET @latitud = -31.419706 + (rand()/10);
				SET @longitud = -64.190120 + (rand()/10);
			END
			ELSE
				BEGIN
					SET @latitud = -31.419706 + (rand()/5);
					SET @longitud = -64.190120 + (rand()/5);
				END
		END
	END
	ELSE
	IF @anyo < 2021 
  BEGIN	 
	 IF (@random < 0.3) 
		BEGIN
			SET @latitud = -31.404469 + (rand()/100);
			SET @longitud = -64.167976 + (rand()/100);
		END
		ELSE 
		BEGIN
			IF (@random < 0.7)
			BEGIN
				SET @latitud = -31.404469 + (rand()/10);
				SET @longitud = -64.167976 + (rand()/10);
			END
			ELSE
				BEGIN
					SET @latitud = -31.404469 + (rand()/5);
					SET @longitud = -64.167976 + (rand()/5);
				END
		END
	END
	
	-- insert
  INSERT INTO EstadisticaConsultas
  VALUES (@fecIniMes, 1560, @playa, @tipoPlaya, @tipoVehiculo, @latitud, @longitud, @fecIniMes, null)
 
END
END
END