var playaElegida;

function crearListado(playas) {
    if ($("#acordion").length === 0) {
        var acordion = crearAcordion(playas);
        if ($(acordion).children().length >= 2) {
            $("#pnlMapa").hide();
            $("#panelListado").append(acordion);
            /*$(acordion).accordion();*/
        } else {
            mensajeErrorConexion("No se encontraron playas cercanas");
        }
    } else {
        $("#acordion").remove();
        $("#pnlMapa").show();
    }
}

function agregarClickAPlaya(playa) {
    var posicionPlayaGoogle = new google.maps.LatLng(playa.Latitud, playa.Longitud);
    var eventoClick = function () {
        $("#acordion").remove();
        $("#btnVerListado").show();
        $("#pnlMapa").show();

        ir(posicionActual, posicionPlayaGoogle, "DRIVING", "METRIC");
        playaElegida = posicionPlayaGoogle;
    };
    return eventoClick;
}

function calcularDistanciaPlaya(playa) {
    var lat1 = parseFloat(playa.Latitud);
    var lon1 = parseFloat(playa.Longitud);
    var lat2 = parseFloat(posicionActual.k);
    var lon2 = parseFloat(posicionActual.B);
    var distancia = distanciaEntreDosPuntos(lat1, lon1, lat2, lon2) * 1000;
    distancia = distancia.toFixed(2);
    return distancia;
}

function crearAcordion(playas) {
    //    var acordion = document.createElement("div");
    //    acordion.id = "acordion";


    var acordion = "<div data-role='content' class='fullscreen'>";
    acordion.id = "acordion";

    acordion += "<ul data-role='listview' data-inset='false' data-icon='false' data-divider-theme='b'>";
    /*acordion += "<li data-role='list-divider'>Playas encontradas:<span class='ui-li-count'>" + +"</span></li>";*/

    for (var i = 0; i < playas.length; i++) {
        var playa = playas[i];
        var distancia = calcularDistanciaPlaya(playa);
        if (distancia <= obtenerDistanciaPredeterminada()) {
            acordion += "<li>";
            contenido += "<a href='#'>";
            contenido += "<img src='http://www.placehold.it/150x150'>";
            contenido += crearHeaderParaPlaya(playa);
            contenido += crearDescripcionParaPlaya(playa);
            contenido += "<div class='ui-li-aside'><button onclick='agregarClickAPlaya(playa)'>Ir</button>";
            acordion += "</li>";

            //            var header = document.createElement("h3");
            //            header.innerHTML = crearHeaderParaPlaya(playa);
            //            var contenedor = document.createElement("div");
            //            var label = document.createElement("label");
            //            label.innerHTML = crearDescripcionParaPlaya(playa);
            //            contenedor.appendChild(label);
            //            acordion.appendChild(header);
            //            acordion.appendChild(contenedor);
            //            var botonIr = document.createElement("input");
            //            botonIr.className = "btn btn-default pull-right"
            //            botonIr.type = "button";
            //            botonIr.value = "Ir";
            //            botonIr.onclick = agregarClickAPlaya(playa);
            //            contenedor.appendChild(botonIr);
        }
    }
    acordion += "</ul>";
    acordion += "</div>";
    return acordion;
}

function obtenerDistanciaPredeterminada() {
    var configuraciones = localStorage.getItem("Configuraciones");
    if (configuraciones !== null) {
        configuraciones = jQuery.parseJSON(configuraciones);
        return parseInt(configuraciones.radio);
    }
    return 500;
}

function crearDescripcionParaPlaya(playa) {
    /*var descripcion = "Direccion: ";*/
    var descripcion = "<p>";
    descripcion += playa.Direcciones[0].Calle;
    descripcion += " ";
    descripcion += playa.Direcciones[0].Numero;
    descripcion += " | ";
    /*descripcion += "Tipo de playa: ";*/
    descripcion += playa.TipoPlaya;
    //    descripcion += "<br>";
    //    descripcion += "Precios: ";
    descripcion += " | ";
    for (var i = 0; i < playa.Precios.length; i++) {
        //        descripcion += "<br>";
        //        descripcion += "&emsp;&emsp;";
        descripcion += playa.Precios[i].TipoVehiculo;
        descripcion += ": $";
        descripcion += parseFloat(playa.Precios[i].Monto).toFixed(2);
    }
    descripcion += " | ";
    descripcion += "Capacidad: ";
    for (var i = 0; i < playa.Servicios.length; i++) {
        //        descripcion += " | ";
        //        descripcion += "&emsp;&emsp;";
        descripcion += playa.Servicios[i].TipoVehiculo;
        descripcion += ": ";
        descripcion += playa.Servicios[i].Capacidad;
        descripcion += "</p>";
    }
    return descripcion;
}

function crearHeaderParaPlaya(playa) {
    var header = "<h2>" + playa.Nombre + "</h2>";

    return header;

}