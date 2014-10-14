function mostrarMetros(valor) {
    $('#radioInput').val(valor + " metros");
}


function redirect() {
    window.location.replace("index.html");
}

function cambiarEstado() {
    estadoCheck($('#myonoffswitch').prop("checked"));
    //    if (cantClickCheck % 2 == 0) {
    //        $('#myonoffswitch').prop("checked", true);
    //    } else {
    //        $('#myonoffswitch').prop("checked", false);
    //    }
    //    cantClickCheck++;



}

function estadoCheck(estado) {
    //    var rta;
    //    rta = $('#myonoffswitch').prop("checked");
    if (estado == true) {

        return "Encencido";
    } else if (estado == false) {

        return "Apagado";
    }
}




function guardarConfiguracion() {
    config = {
        "tipoVehiculo": $('#tipoVehiculo').val(),
        "radio": $('#radio').val(),
        "gps": estadoCheck()
    }
    BootstrapDialog.show({
        title: "Configuración guardada!",
        message: "<h4>Datos de configuración:</h4>" +
            "<ul class='well'>" +
            "<li>Tipo vehiculo: " + config["tipoVehiculo"] + "</li>" +
            "<li>Alcance: " + config["radio"] + " metros</li>" +
            "<li>GPS: " + config["gps"] + "</li>" +
            "</ul>" + "<br>" +
            "<strong> La aplicación se reiniciará para reflejar los cambios</strong>",
        buttons: [{

                label: 'Cancelar',
                action: function (ventanaConfiguracion) {
                    ventanaConfiguracion.close();
                }

        },
            {
                label: 'Aceptar',
                cssClass: 'btn-success',
                action: function () {

                    window.setTimeout(redirect, 1000)


                }
            }]
    });

}