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
    localStorage.setItem("Configuraciones",JSON.stringify(config));
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

function leerConfiguracionGuardada(){
    var configuraciones = localStorage.getItem("Configuraciones");
    if(configuraciones !== null){
        configuraciones = jQuery.parseJSON(configuraciones);
    }
    return configuraciones;
}
function setearValoresDeConfiguraciones(){
    var config = leerConfiguracionGuardada();
    if(config !== null){
        $('#tipoVehiculo').val(config.tipoVehiculo);
        $('#radio').val(config.radio);
    }
}
function cargarTiposDeVehiculo(){
    var tiposVehiculos = obtenerTiposDeVehiculos();
    for(var i = 0; i < tiposVehiculos.length; i++){
        var option = document.createElement("option");
        option.value = tiposVehiculos[i].Id;
        option.innerHTML = tiposVehiculos[i].Nombre;
        $('#tipoVehiculo').append(option);
    }
}
function obtenerTiposDeVehiculos(){
    var uri = "http://ifrigerio-001-site1.smarterasp.net/api/playas/GetTiposVehiculo";
    var tiposVehiculos = null;
    $.ajax({
        type : "GET",
        async : false,
        url : uri,
        success : function(response){
            tiposVehiculos = jQuery.parseJSON(response);
        }
    });
    return tiposVehiculos;
}