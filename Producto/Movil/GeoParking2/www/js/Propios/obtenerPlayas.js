function obtenerPlayasPorPosicion(posicion) {
    var uri = obtenerURLServer() + 'api/Playas/GetUbicacionesPlayasPorDistancia?latitud=' + posicion.latitud + "&longitud=" + posicion.longitud + "&tipoVehiculoId=" + leerPropiedadTipoVehiculo();
    $.ajax({
        type: "GET",
        url: uri,
        success: function (data) {
            playas = (typeof data) == 'string' ?
                eval('(' + data + ')') :
                data;
            for (var i = 0; i < playas.length; i++) {
                playas[i].Latitud = playas[i].Latitud.replace(",", ".");
                playas[i].Longitud = playas[i].Longitud.replace(",", ".");
            }
            agregarPlayasAMapa(playas);
            showMarkers();

        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Error de conexión con el servidor. Inténtelo de nuevo más tarde.");

        }
    });

}