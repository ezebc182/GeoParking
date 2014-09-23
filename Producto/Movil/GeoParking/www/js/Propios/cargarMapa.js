//mapa de la pagina
var map;
//array de marcadores
var markers = [];
//contenido del marcador
var contenido = "";
//variable infoWindows que se seteara al marcador 
var infowindow = new google.maps.InfoWindow({
    content: ''
});

var directionsDisplay = new google.maps.DirectionsRenderer({
    suppressMarkers: true
});
var directionsService = new google.maps.DirectionsService();

var posicionActual;
function mensajeErrorConexion(mensaje) {
    $("#pnlMapa").prepend("<label id='msjError' style='font-size: 12px; font-family: sans-serif; font-style: normal; color: red;'>"+mensaje+"</label>");
}
function ir(origen, destino, modoViaje, sistema) {
    directionsDisplay.setMap(null);
    var request = {
        origin: origen,
        destination: destino,
        travelMode: google.maps.DirectionsTravelMode[modoViaje],
        unitSystem: google.maps.DirectionsUnitSystem[sistema],
        provideRouteAlternatives: true
    };
    directionsService.route(request, function(response, status) {
        if (status == google.maps.DirectionsStatus.OK) {
            directionsDisplay.setMap(map);
            //directionsDisplay.setPanel($("#panel_ruta").get(0));
            directionsDisplay.setDirections(response);
        } else {
            mensajeErrorConexion("Error al Calcular la ruta");
        }
    });
}
function addCarMarker(location) {
    var marker = new google.maps.Marker({
        position: location,
        map: map,
        icon: './img/marcadorAuto.png'
    });
    markers.push(marker);
}
function addMarker(location) {
    
    var marker = new google.maps.Marker({
        position: location,
        map: map,
        icon: './img/maracdorParking.png'
    });
    (function(marker,origen){
        google.maps.event.addListener(marker, 'click', function() {
            ir(posicionActual, marker.getPosition(), "DRIVING","METRIC");
        });
    })(marker,posicionActual);
    
    markers.push(marker);
}
function setAllMap(map) {
  for (var i = 0; i < markers.length; i++) {
    markers[i].setMap(map);
  }
}
function showMarkers() {
  setAllMap(map);
}
function obtenerPosicionActual(){
    var successFunction = function(p){
        if(p.coords.latitude !== undefined && p.coords.longitude !== undefined){
            var posicionGoogle = new google.maps.LatLng(p.coords.latitude, p.coords.longitude);
            posicionActual = posicionGoogle;
            map.setCenter(posicionGoogle);
            addCarMarker(posicionGoogle);
            var posicionInterna = {
                latitud : p.coords.latitude,
                longitud : p.coords.longitude
            };
            obtenerCiudadDePosicion(posicionInterna);
            loading($("#map-canvas"), false);
        }
    };
    var errorFunction = function(){
        mensajeErrorConexion("Error de conexion, Por favor habilite la localizacion para continuar");
    };
    navigator.geolocation.getCurrentPosition(successFunction, errorFunction);
}
function obtenerCiudadDePosicion(posicion){
    var uri = "http://maps.googleapis.com/maps/api/geocode/json?latlng="+posicion.latitud+","+posicion.longitud+"&sensor=true";
    var funcionCiudad = function(direcciones){
        if(direcciones.status === "OK" && direcciones.results.length > 3){
            //en esta posicion siempre se muestra el formato ciudad, provincia, pais
            var i = direcciones.results.length - 3;
             //aca tengo la ciudad para llamar al servicio de geoparking que devuelve playas en base a la ciudad
            var ciudad = (direcciones.results[i].formatted_address).split(",")[0];
            obtenerPlayasDeCiudad(ciudad);
            //var playasDeCiudad = obtenerPlayasDeCiudad(ciudad);
            /*agregarPlayasAMapa(playasDeCiudad);
            showMarkers();*/
        }
        else{
            mensajeErrorConexion("Error de conexion, Por favor habilite la localizacion para continuar");
        }
            
    };
    $.getJSON(uri).done(funcionCiudad);
}
function agregarPlayasAMapa(playas){
    for(var i = 0;i < playas.length; i++){
        agregarPlayaAMapa(playas[i]);
    }
}
function agregarPlayaAMapa(playa){
    var posicionDePlaya = new google.maps.LatLng(playa.Latitud, playa.Longitud);
    addMarker(posicionDePlaya);
}

function loading(componente, on){
    if(on){
        componente.addClass("loadingOn");
    }
    else{
        componente.removeClass("loadingOn");
    }
}
function initialize() {
    loading($("#map-canvas"), true);
    //variable para la busqueda con una direccion
    geocoder = new google.maps.Geocoder();
    //opciones basicas del mapa
    var mapOptions = {
        zoom: 15,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    //crea el mapa en el div "map-canvas" y le setea las opciones
    map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);
    //centro el mapa en la posicion actual del movil.
    setTimeout(function () {
        obtenerPosicionActual();
    }, 100);
}