var ubicacionAuto;
var cantClick = 0;
var modo = 1;


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
                obtenerPosicionActual();

                ventanaRecordar.close();
                var mdConfirmacion = new BootstrapDialog({
                    closable: false,
                    title: 'Ruta a vehículo',
                    message: 'Trazando ruta a vehículo!',
                    buttons: [{
                        label: 'Ok',
                        cssClass: 'btn-default',
                        action: function (ventanaExito) {
                            ir(posicionActual, ubicacionAuto, "WALKING", "METRIC");
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
        message: $('#panel_ruta').val(),
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