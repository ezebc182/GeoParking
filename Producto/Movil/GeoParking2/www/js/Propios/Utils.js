var db = getLocalStorage() || alert("Local Storage Not supported in this browser");
/*variable global de historial de playas consultadas*/
/*
var cantidadAlmacenadas = 0;*/

function getLocalStorage() {
    try {
        if (window.localStorage) return window.localStorage;
    } catch (e) {
        return undefined;
    }
}

function setlocal() {

    db.setItem("mi_posicion", posicionActual);
    getlocal();
}

function ClearAll() {

    db.clear();
    getlocal();
}

function getlocal() {
    var i = 0;
    for (i = 0; i <= db.length - 1; i++) {
        key = db.key(i);
        alert(db.getItem(key));
    }
}

function getopenDb() {
    try {
        if (window.openDatabase) {
            return window.openDatabase;
        } else {
            alert('No HTML5 support');
            return undefined;
        }
    } catch (e) {
        alert(e);
        return undefined;
    }
}

function distanciaEntreDosPuntos(lat1, lon1, lat2, lon2) {
    var R = 6371; // km
    var phi1 = toRad(lat1);
    var phi2 = toRad(lat2);
    var deltaPhi = toRad(lat2 - lat1);
    var deltaLambda = toRad(lon2 - lon1);
    var a = Math.sin(deltaPhi / 2) * Math.sin(deltaPhi / 2) +
        Math.cos(phi1) * Math.cos(phi2) *
        Math.sin(deltaLambda / 2) * Math.sin(deltaLambda / 2);
    var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
    var d = R * c;

    return d;
}

function toRad(value) {
    return value * Math.PI / 180;
}

function obtenerURLServer() {
    return 'http://ifrigerio-001-site1.smarterasp.net/';
    //return 'http://localhost:21305/';
}

function leerPropiedadTipoVehiculo() {
    var configuraciones = localStorage.getItem("Configuraciones");
    if (configuraciones !== null) {
        configuraciones = jQuery.parseJSON(configuraciones);
        return configuraciones.tipoVehiculo;
    }
    return "0";
}

function leerPropiedadGPS() {
    var configuraciones = localStorage.getItem("Configuraciones");
    if (configuraciones !== null) {
        configuraciones = jQuery.parseJSON(configuraciones);
        return configuraciones.gps;
    }
    return false;
}

function leerPropiedadRadio() {
    var configuraciones = localStorage.getItem("Configuraciones");
    if (configuraciones !== null) {
        configuraciones = jQuery.parseJSON(configuraciones);
        return parseInt(configuraciones.radio);
    }
    return 500;
}

function cargandoConMensaje(mensaje) {
    $.mobile.loading('show', {
        text: mensaje,
        textVisible: true,
        theme: 'a'
    });
}

function cargandoSinMensaje() {
    $.mobile.loading('show', {
        theme: 'a'
    });
}

function quitarCargando() {
    $.mobile.loading('hide');
}

function leerNumeroMovil() {
    var telephoneNumber = cordova.require("cordova/plugin/telephonenumber");
    telephoneNumber.get(function (result) {
        return result;
    }, function () {
        return "error";
    });
}

function validarNumberoTelefono(inputtxt) {
    var phoneo = /^\d{10}$/;
    if (inputtxt.value.match(phoneo)) {
        return true;
    } else {
        return false;
    }
}

function validarEmail(inputtxt) {
    var email = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    if (inputtxt.value.match(email)) {
        return true;
    } else {
        return false;
    }
}

function abrirPopup(mensaje) {
    $("#parrafoPopupSimple").html(mensaje);
    $("#linkAbrePopupBasico").click();
    var cerrarPopup = function () {
        $("#popupBasic").popup("close");
    }
    setTimeout(cerrarPopup, 1500);

}

/*function mensajeErrorConexion(mensaje) {
    abrirPopup(mensaje);
}*/

function abrirDialogoConDosBotones(funcionOk, mensaje, encabezado) {
    $("#dialogoDosBotonesHeader").html(encabezado);
    $("#dialogoDosBotonesDescripcion").html(mensaje);
    document.getElementById("dialogoDosBotonesAcpetar").onclick = funcionOk;
    var funcionCancelar = function () {
        $("#popupDialog").dialog('close');
    };
    document.getElementById("dialogoConDosBotonesCancelar").onclick = funcionCancelar;
    $("#linkAbreDialogoDosBotones").click();
}

function cerrarDialogoConDosBotones() {
    $("#popupDialog").remove();
}






/* Guarda un historial de las últimas playas consultadas actualizando en el panel principal el listado en forma última consultada primera en la pila, descartando repetidos */
function verificarQueExistePlayaEnArray(playa, array) {
    for (var j = 0; j < array.length; j++) {
        if (playa.Id === array[j].Id) {
            return true;
        }
    }
    return false;
}

function guardarPlayaConsultada(playa) {

    var cantidad = $("#listadoHistorial").historialWidget('retornarCantidadPlayasAGuardar');
    var widget = this;
    arrayActual = JSON.parse(db.getItem("playas"));
    if (db.getItem("playas") !== null) {
        cantidadAlmacenadas = JSON.parse(db.getItem("playas")).length;
    } else {
        cantidadAlmacenadas = 0;
    }

    if (arrayActual === null) {
        var arrayActual = new Array();
        arrayActual.push(playa);
        db.setItem("playas", JSON.stringify(arrayActual));
        arrayActual = JSON.parse(db.getItem("playas"));


    } else {
        if (cantidadAlmacenadas < cantidad) {
            var estaRepetido = verificarQueExistePlayaEnArray(playa, arrayActual);
            if (estaRepetido === false) {
                arrayActual.push(playa);
                db.setItem("playas", JSON.stringify(arrayActual));
                /*Inicializar el widget*/

            } else {
                var posRepetido;
                for (var i = 0; i < arrayActual.length; i++) {

                    if (arrayActual[i].Id === playa.Id) {

                        posRepetido = i;
                    }

                }
                arrayActual.splice(posRepetido, 1);
                arrayActual.push(playa);
                db.setItem("playas", JSON.stringify(arrayActual));

            }

        } else {
            arrayActual.splice(0, 1);
            arrayActual.push(playa);
            db.setItem("playas", JSON.stringify(arrayActual));


        }

    }
    $("#listadoHistorial").historialWidget("crearEstructuraHistorial");



}
$.fn.isBound = function (type) {
    var data = jQuery._data(this[0], 'events')[type];

    return !(data === undefined || data.length === 0);
};


/*Si está abierto el popupOpciones lo cierra, sino se abre*/
$('#popupOpciones').popup();
if ($(".ui-popup-active").length > 0) {
    $('#popupOpciones').popup('close');
} else {
    $('#popupOpciones').popup('open');
}

function obtenerTiposVehiculosDeServidor() {
    var uri = obtenerURLServer() + "api/playas/GetTiposVehiculo";
    var tiposVehiculos = null;
    $.ajax({
        type: "GET",
        async: false,
        url: uri,
        success: function (response) {
            tiposVehiculos = jQuery.parseJSON(response);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Error de Conexion");
        }
    });
    return tiposVehiculos;
}

function agregarTiposDeVehiculos() {

    var tiposVehiculos = obtenerTiposVehiculosDeServidor();
    for (var i = 0; i < tiposVehiculos.length; i++) {
        var opcion = document.createElement("option");
        opcion.value = tiposVehiculos[i].Id;
        opcion.innerHTML = tiposVehiculos[i].Nombre;
        $('#selectTipoVehiculosWelcome').append(opcion);
    }
}

/* Función de la pantalla inicial cuando se utiliza por primera vez la app*/



function goToStep2() {
    var select = document.getElementById("selectTipoVehiculosWelcome");
    var tipoVehiculo = select.options[select.selectedIndex].value;
    var boton = document.getElementById("btnSiguiente");

    if (tipoVehiculo !== "0") {

        boton.className = "ui-btn";

    } else {
        boton.className = "ui-btn ui-state-disabled";
    }
}

function guardarDatosIniciales() {
    var select = document.getElementById("selectTipoVehiculosWelcome");
    var tipoVehiculo = select.options[select.selectedIndex].value;
    var radioBusqueda = document.getElementById("radioWelcome").value;
    var opcionGPS = $("#checGPSkWelcome").parent().hasClass("ui-flipswitch-active");

    var configuraciones = {
        tipoVehiculo: tipoVehiculo,
        radio: radioBusqueda,
        gps: opcionGPS
    };
    localStorage.setItem("Configuraciones", JSON.stringify(configuraciones));
}

/*Comprueba si ya están seteados los datos de ajustes, sino muestra la pantalla de bienvenida para que los setee el usuario */


function welcome() {
    if (db.getItem("Configuraciones") == null) {
        document.location.href = "#welcomePage";
        agregarTiposDeVehiculos();
    } else {
        document.getElementById("welcomePage").setAttribute("hidden", true);
        document.location.href = "#mainPage";
    }
}
/*
function cargarAplicacion() {
        var width = $(".content").width();
    var height = $(".content").height();
    $("img").css({
        "max-width": width,
        "max-height": height
    });
    var progressbar = $("#progressbar"),
        progressLabel = $(".progress-label");

    progressbar.progressbar({
        value: false,
        change: function () {
             //progressLabel.text(progressbar.progressbar("value") + "%");
        },
        complete: function () {
             //progressLabel.text("100%");
        }
    });

    function progress() {
        var val = progressbar.progressbar("value") || 0;

        progressbar.progressbar("value", val + 2);

        if (val < 99) {
            setTimeout(progress, 80);
        }
    }

    setTimeout(progress, 2000);
}*/


/*function comprobarConexion() { if (navigator.onLine) { abrirPopup("Estás conectado."); } else { abrirPopup("Sin conexión."); } }

*/