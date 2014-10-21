var ubicacionAuto;
var cantClick = 0;
var modo = 1;
var regresoAVehiculo = false;


function guardarUbicacion() {

    BootstrapDialog.show({

        title: "Recordar posición vehículo",
        message: "¿Desea guardar la posición de su vehículo?",
        buttons: [{
            label: 'Si',
            cssClass: 'btn-success',
            action: function (ventanaRecordar) {
                obtenerPosicionActual();
                ubicacionAuto = posicionActual;
                localStorage.setItem("UbicacionVehiculo", JSON.stringify(ubicacionAuto));
                ventanaRecordar.close();
                var mdConfirmacion = new BootstrapDialog({
                    closable: false,
                    title: 'Éxito',
                    message: ('Posición guardada!'),
                    buttons: [{
                        label: 'Ok',
                        cssClass: 'btn-default',
                        action: function (ventanaExito) {
                            ventanaExito.close();
                        }
                    }],
                    type: BootstrapDialog.TYPE_INFO
                }).open();

            }
            }, {
            label: 'No',
            cssClass: 'btn-default',
            action: function (ventanaRecordar) {
                ventanaRecordar.close();
            }
            }]
    });



}


function trazarRegreso() {

    BootstrapDialog.show({

        title: "Desplazarse hacia vehículo",
        message: "¿Desea visualizar el camino hacia su vehículo?",
        buttons: [{
            label: 'Si',
            cssClass: 'btn-success',
            action: function (ventanaRecordar) {
                //obtenerPosicionActual();
                var ubicacionAVolver = localStorage.getItem("UbicacionVehiculo");
                ubicacionAVolver = jQuery.parseJSON(ubicacionAVolver);
                ubicacionAVolver = new google.maps.LatLng(ubicacionAVolver.k, ubicacionAVolver.B);
                destino = ubicacionAVolver;
                agregarMarkadorPosicionAuto(ubicacionAVolver);
                ventanaRecordar.close();
                var mdConfirmacion = new BootstrapDialog({
                    closable: false,
                    title: 'Ruta a vehículo',
                    message: 'Trazando ruta a vehículo!',
                    buttons: [{
                        label: 'Ok',
                        cssClass: 'btn-default',
                        action: function (ventanaExito) {
                            regresoAVehiculo = true;
                            enRecorrido = false;
                            ir(posicionActual, ubicacionAVolver, "WALKING", "METRIC");
                            ventanaExito.close();
                        }
                    }],
                    type: BootstrapDialog.TYPE_INFO
                }).open();

            }
            }, {
            label: 'No',
            cssClass: 'btn-default',
            action: function (ventanaRecordar) {
                ventanaRecordar.close();
            }
            }]
    });


}

function mostrarIndicaciones() {

    $('#panel_ruta').removeClass('hidden');


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
    });

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