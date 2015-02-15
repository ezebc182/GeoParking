var autocomplete;

function crearAutocomplete(){
    obtenerLimitesDePais();
}

function limpiarBusqueda() {
    var place = autocomplete.getPlace();
    if (place) {
        $('#txtBusqueda').val(place.name);
    }
    else {
        $('#txtBusqueda').val('');
    }
}
var lugarBuscado = null;
var markerLugarBuscado;
var puntoInteres;
function cerrarPanelBusqueda(){
    $("#pnlBusqueda").panel('close');
}
function agregarPuntoInteres(lugarBuscado){
    
    markerLugarBuscado = new google.maps.Marker({
        position: lugarBuscado.geometry.location,
        map: map,
        icon: lugarBuscado.icon
    });
    markerLugarBuscado.setIcon({
      url: lugarBuscado.icon,
      size: new google.maps.Size(60, 60)
    });
    markerLugarBuscado.setMap(map);
    map.setCenter(lugarBuscado.geometry.location);
    //crear ciurculo
    var populationOptions = {
        strokeColor: '#FF0000',
        strokeOpacity: 0.9,
        strokeWeight: 2,
        fillColor: '#FF0000',
        fillOpacity: 0.1,
        map: map,
        center: lugarBuscado.geometry.location,
        editable: false,
        radius: leerPropiedadRadio()
    };
    if(puntoInteres){
        puntoInteres.setMap(null);
    }
    puntoInteres = new google.maps.Circle(populationOptions);
}
$("#btnMostrarBusquedaEnMapa").click(function(){
    //obtenerLimitesDeCiudad();
    if(markerLugarBuscado){
        markerLugarBuscado.setMap(null);
    }
    agregarPuntoInteres(lugarBuscado);
    cerrarPanelBusqueda();
});
$("#btnVerListadoPuntoBuscado").click(function(){
    agregarPuntoInteres(lugarBuscado);
    verListado();
    cerrarPanelBusqueda();
});
$("#btnBorrarBusqueda").click(function(){
    lugarBuscado = null;
    markerLugarBuscado.setMap(null);
    markerLugarBuscado = null;
    puntoInteres.setMap(null);
    $("#parrafoDireccionBuscada").html("");
    ubicarMiPosicion();
    cerrarPanelBusqueda();
});
function obtenerLimitesDePais() {
    var successFunction = function(p) {
        if (p.coords.latitude !== undefined && p.coords.longitude !== undefined){
            var uri = "http://maps.googleapis.com/maps/api/geocode/json?latlng=" + p.coords.latitude + "," + p.coords.longitude + "&sensor=true";
            var limites;
            var restriccion;
            $.ajax({
                type: "GET",
                async: false,
                url: uri,
                success: function (response) {
                    if (response.status === "OK" && response.results.length > 0){
                        limites = response.results[1].geometry.bounds;
                        restriccion = obtenerRestriccionAaplicar(response.results);
                    }
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert("Error de Conexion");
                }
            });
            var input = (document.getElementById('txtBusqueda'));
            autocomplete = new google.maps.places.Autocomplete(input, restriccion);
            google.maps.event.addListener(autocomplete, 'place_changed', function() {
                var place = autocomplete.getPlace();
                if (!place.geometry) {
                    //hacer algo cuando lo que se encuentra no es un lugar
                    return;
                }
                var lat1 = parseFloat(place.geometry.location.k);
                var lon1 = parseFloat(place.geometry.location.D);
                var lat2 = parseFloat(posicionActual.k);
                var lon2 = parseFloat(posicionActual.D);
                var distancia = distanciaEntreDosPuntos(lat1, lon1, lat2, lon2) * 1000;
                if(distancia > 15000){
                    //alert("El lugar buscado se encuentra demasiado lejos.");
                    //return;
                }
                $("#parrafoDireccionBuscada").html("Encontrado en: " + place.formatted_address);
                lugarBuscado = place;

            });
        }
    };
    var errorFunction = function(){
        alert("Error");
    };
    navigator.geolocation.getCurrentPosition(successFunction, errorFunction);
}
function obtenerRestriccionAaplicar(results){
    var options = {};
    for(var i = 0; i < results.length; i++){
        var tipos = results[i].types;
        for(var j = 0; j < tipos.length; j++){
            if(tipos[j] === "locality"){
                var limites = results[i].geometry.bounds;
                var hyderabadBounds = new google.maps.LatLngBounds(
                    new google.maps.LatLng(limites.northeast.lat, limites.northeast.lng),
                    new google.maps.LatLng(limites.southwest.lat, limites.southwest.lng)
                );
                options['bounds'] = hyderabadBounds;
                options = ObtenerPuntoMedioYRadio(limites, options)
            }
            if(tipos[j] === "country"){
                var paisShortName = results[i].address_components[0].short_name;
                var restriccionComponente = {
                    'country' : paisShortName
                };
                options['componentRestrictions'] = { 'country' : paisShortName } ;
            }
        }	
    }
    return options;
}
function ObtenerPuntoMedioYRadio(limites, options){
    var latitudMedia = ((limites.northeast.lat - limites.southwest.lat) > 0) ? (limites.northeast.lat - limites.southwest.lat)/2 : (limites.southwest.lat - limites.northeast.lat)/2;
    var longitudMedia = ((limites.northeast.lng - limites.southwest.lng) > 0) ? (limites.northeast.lng - limites.southwest.lng)/2 : (limites.southwest.lng - limites.northeast.lng)/2;
    var puntoMedio = new google.maps.LatLng (latitudMedia, longitudMedia);
    options['location'] = puntoMedio;
    var lat1 = parseFloat(limites.southwest.lat);
    var lon1 = parseFloat(limites.southwest.lng);
    var lat2 = parseFloat(limites.northeast.lat);
    var lon2 = parseFloat(limites.northeast.lng);
    var distancia = (distanciaEntreDosPuntos(lat1, lon1, lat2, lon2) * 1000)/2;
    options['radius'] = distancia;
    return options;
}