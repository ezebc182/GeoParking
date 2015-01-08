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
    this.Longitude = longitud;
    this.Latitude = latitud;
}
function direccion(id, calle, numero, ciudad, posicion) {
    this.Id = id;
    this.Calle = calle;
    this.Numero = numero;
    this.Ciudad = ciudad;
    this.Posicion = posicion;
};
