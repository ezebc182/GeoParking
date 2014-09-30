function crearListado(playas) {
    var acordion = crearAcordion(playas);
    $("#panelListado").append(acordion);
    $(acordion).accordion();
}
function agregarClickAPlaya(playa){
    var posicionPlayaGoogle = new google.maps.LatLng(playa.Latitud, playa.Longitud);
    var eventoClick = function(){
        $("#acordion").remove();
        $("#btnVerListado").show();
        $("#pnlMapa").show();
        ir(posicionActual, posicionPlayaGoogle, "DRIVING","METRIC");
    };
    return eventoClick;
}

function calcularDistanciaPlaya(playa){
    var lat1 = parseFloat(playa.Latitud);
    var lon1 = parseFloat(playa.Longitud);
    var lat2 = parseFloat(posicionActual.k);
    var lon2 = parseFloat(posicionActual.B);
    var distancia = distanciaEntreDosPuntos(lat1, lon1, lat2, lon2) * 100;
    distancia = distancia.toFixed(2);
    return distancia + " metros";
}
function crearAcordion(playas){
    var acordion = document.createElement("div");
    acordion.id = "acordion";
    acordion.className = "fullscreen";
    for(var i = 0; i < playas.length; i++){
        var playa = playas[i];
        var header = document.createElement("h3");
        header.innerHTML = crearHeaderParaPlaya(playa);
        var contenedor = document.createElement("div");
        var botonIr = document.createElement("input");
        botonIr.type = "button";
        botonIr.style = "position: relative; float: right; height: 100%; width: 20%;";
        botonIr.value = "Ir a esta Playa";
        botonIr.onclick = agregarClickAPlaya(playa);
        contenedor.appendChild(botonIr);
        var label = document.createElement("label");
        label.innerHTML = crearDescripcionParaPlaya(playa);
        contenedor.appendChild(label);
        acordion.appendChild(header);
        acordion.appendChild(contenedor);
    }
    return acordion;
}
function crearDescripcionParaPlaya(playa){
    var descripcion = "Direccion: ";
    descripcion += playa.Direcciones[0].Calle;
    descripcion += " ";
    descripcion += playa.Direcciones[0].Numero;
    descripcion += "<br>";
    descripcion += "Tipo de playa: ";
    descripcion += playa.TipoPlaya;
    descripcion += "<br>";
    descripcion += "Precios: ";
    for(var i = 0; i < playa.Precios.lengh; i++){
        descripcion += "<br>";
        descripcion += "    ";
        descripcion += playa.Precios[i].TipoVehiculo;
        descripcion += " ";
        descripcion += parseFloat(playa.Precios[i].Monto).toFixed(2);
    }
    return descripcion;
}
function crearHeaderParaPlaya(playa){
    var header = "";
    header += playa.Nombre;
    header += " - ";
    header += calcularDistanciaPlaya(playa);
    return header;

}