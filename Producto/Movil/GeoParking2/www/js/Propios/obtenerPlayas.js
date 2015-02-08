function obtenerPlayasPorPosicion(posicion) {
    var uri = obtenerURLServer() + 'api/Playas/PostUbicacionesPlayasPorDistancia';
    var datos = {
        latitud : posicion.latitud,
        longitud : posicion.longitud,
        tipoVehiculoId : parseInt(leerPropiedadTipoVehiculo())
    };
    $.ajax({
        type: "POST",
        url: uri,
        dataType: "json",
        content: "application/json; charset=utf-8",
        data : datos,
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