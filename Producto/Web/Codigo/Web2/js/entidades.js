function capacidad(id, cantidad) {
    this.ServicioId = id;
    this.Cantidad = cantidad;
}
function precio(id, idTiempo, precio) {
    this.ServicioId = id;
    this.TiempoId = idTiempo;
    this.Monto = precio;
}

function horario(id, horaDesde, horaHasta, diaAtencionId) {
    this.PlayaDeEstacionamientoId = id;
    this.HoraDesde = horaDesde;
    this.HoraHasta = horaHasta;
    this.DiaAtencionId = diaAtencionId;
};

function servicio(id, playaId, tipoVehiculoId, capacidad, precios) {
    this.Id = id;
    this.PlayaDeEstacionamientoId = playaId;
    this.TipoVehiculoId = tipoVehiculoId;
    this.Capacidad = capacidad;
    this.Precios = precios;
};

function usuario(id, nombreUsuario, contraseña, apellido, mail, nombre, rolId) {
    this.Id = id;
    this.NombreUsuario = nombreUsuario;
    this.Contraseña = contraseña;
    this.Apellido = apellido;
    this.Mail = mail;
    this.Nombre = nombre;
    this.RolId = rolId;
};

function playaDeEstacionamiento(id, nombre, mail, telefono, tipoPlayaId, horario, direcciones, servicios) {
    this.Id = id;
    this.Nombre = nombre;
    this.Mail = mail;
    this.Telefono = telefono;
    this.TipoPlayaId = tipoPlayaId;
    this.Horario = horario;
    this.Direcciones = direcciones;
    this.Servicios = servicios;
};
function posicion(longitud, latitud) {
    this.Geography = {
        CoordinateSystemId: 4326,
        WellKnownText: "POINT (" + longitud + " " + latitud + ")"
    };
};

function zona(id, nombre, wkt) {
    this.Id = id,
    this.Nombre = nombre,
    this.UsuarioId = 0,
    this.Poligono = {
        Geography: {
            CoordinateSystemId: 4326,
            WellKnownText: wkt
        }
    };
};
function direccion(id, calle, numero, ciudad, idPlaceCiudad, latitud, longitud) {
    this.Id = id;
    this.Calle = calle;
    this.Numero = numero;
    this.Ciudad = ciudad;
    this.IdPlaceCiudad = idPlaceCiudad,
    this.Posicion = new posicion(longitud, latitud);
    this.Latitud = latitud;
    this.Longitud = longitud;
};
