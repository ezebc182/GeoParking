var db = getLocalStorage() || alert("Local Storage Not supported in this browser");
/*variable global de historial de playas consultadas*/
var cantidadAlmacenadas = 0;

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
$.fn.isBound = function (type) {
    var data = jQuery._data(this[0], 'events')[type];

    return !(data === undefined || data.length === 0);
};