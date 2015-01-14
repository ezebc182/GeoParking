function obtenerPlayasPorPosicion(posicion){
    var uri = obtenerURLServer() + 'api/Playas/GetUbicacionesPlayasPorDistancia?latitud=' + posicion.latitud + "&longitud=" + posicion.longitud +"&tipoVehiculoId=" + leerPropiedadTipoVehiculo();
    $.ajax({
        type: "GET",
        url: uri,
        success: function (data) {
            playas = (typeof data) == 'string' ?
                eval('(' + data + ')') :
                data;
            for(var i = 0; i<playas.length ; i++){
                playas[i].Latitud = playas[i].Latitud.replace(",",".");
                playas[i].Longitud = playas[i].Longitud.replace(",",".");
            }
            agregarPlayasAMapa(playas);
            showMarkers();

        },
        error: function (jqXHR, textStatus, errorThrown) {
            BootstrapDialog.show({
                title: "Error",
                message: "Error de conexión con el servidor, por favor reinténtelo más tarde." + "<br>" + errorThrown,
                type: BootstrapDialog.TYPE_DANGER,
                buttons: [{
                    label: 'Cerrar',
                    cssClass: 'btn-default',
                    action: function (ventanaError) {
                        ventanaError.close();
                    }
                }]

            }).open();

        }
    });
    
}