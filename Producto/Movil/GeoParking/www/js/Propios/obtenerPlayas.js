function obtenerPlayasDeCiudad(ciudad){
    if(ciudad === "Capital"){
        ciudad = "Cordoba";
    }
    var uri = 'http://ifrigerio-001-site1.smarterasp.net/api/playas/getPlayas?ciudad=' + ciudad;
    //var uri = 'http://localhost:5027/api/playas/getPlayas?ciudad=' + ciudad;
    //var uri = 'http://localhost:33357/api/playas/getPlayas?ciudad=' + ciudad;
    $.ajax({
        type: "GET",
        url: uri,
        success: function (data) {
            playas = (typeof data) == 'string' ?
                eval('(' + data + ')') :
                data;
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