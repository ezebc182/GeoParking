var ubicacionAuto;
var cantClick = 0;
var modo = 1;
var regresoAVehiculo = false;


function guardarUbicacion() {
    var confirmarGuardado = function(){
        obtenerPosicionActual();
        ubicacionAuto = posicionActual;
        localStorage.setItem("UbicacionVehiculo", JSON.stringify(ubicacionAuto));
    };
    abrirDialogoConDosBotones(confirmarGuardado, '&iquest;Desea guardar la posici&oacute;n de su veh&iacute;culo?', 'Recordar posici&oacute;n veh&iacute;culo');
}


function trazarRegreso() {
    var confirmarRutaRegreso = function(){
        var ubicacionAVolver = localStorage.getItem("UbicacionVehiculo");
        ubicacionAVolver = jQuery.parseJSON(ubicacionAVolver);
        ubicacionAVolver = new google.maps.LatLng(ubicacionAVolver.k, ubicacionAVolver.D);
        destino = ubicacionAVolver;
        agregarMarkadorPosicionAuto(ubicacionAVolver);
        tipoDestino = "ubicacion";
        ir(posicionActual, ubicacionAVolver, "WALKING", "METRIC");
    };
    abrirDialogoConDosBotones(confirmarRutaRegreso, '&iquest;Desea visualizar el camino hacia su veh&iacute;culo?', 'Desplazarse hacia veh&iacute;culo');
}

function mostrarIndicaciones() {

    /*$('#panel_ruta').removeClass('hidden');


    BootstrapDialog.show({

        title: "Ruta de navegación",
        message: $('#panel_ruta'),
        type: BootstrapDialog.TYPE_INFO,
        buttons: [{
            label: 'Cerrar',
            cssClass: 'btn-default',
            action: function (ventanaNavegacion) {
                ventanaNavegacion.close();
            }
            }]
    });*/

}

function agregarMarkadorPosicionAuto(posicion) {
    marker = new google.maps.Marker({
        position: posicion,
        map: map,
        icon: './img/posicionGuardada.png'
    });
    markers.push(marker);
    marker.setMap(map);
}