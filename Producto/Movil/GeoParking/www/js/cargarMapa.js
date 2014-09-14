//mapa de la pagina
var map;
//array de marcadores
var markers = [];
//array de circulos
var circulos = [];
//contenido del marcador
var contenido = "";
//variable infoWindows que se seteara al marcador 
var infowindow = new google.maps.InfoWindow({
    content: ''
});

function initialize(){
    
    //variable para la busqueda con una direccion
    geocoder = new google.maps.Geocoder();
    //opciones basicas del mapa
    var mapOptions = {
        zoom: 17,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    
   
    //crea el mapa en el div "map-canvas" y le setea las opciones
    map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);
   
    //centro el mapa en la posicion actual del movil.
    obtenerPosicionActual();
    
    /*var address = "cordoba, Argentina";
    geocoder.geocode({ 'address': address }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            map.setCenter(results[0].geometry.location);
            map.setZoom(15);
        } else {
            mensajeErrorConexion();
        }
    });*/
}

function mensajeErrorConexion(){
    alert("Error!");
}
function addMarker(location) {
    
    var marker = new google.maps.Marker({
        position: location,
        map: map/*,
        icon: './img/maracdorParking.png'*/
    });
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
        //var lblMensaje = document.getElementById("lblMensaje");
        //lblMensaje.innerHTML = "Latitud = " + p.coords.latitude + ", Longitud = " + p.coords.longitude;
        
        if(p.coords.latitude !== undefined && p.coords.longitude !== undefined){
            var posicionGoogle = new google.maps.LatLng(p.coords.latitude, p.coords.longitude);
            map.setCenter(posicionGoogle);
            var posicionInterna = {
                latitud : p.coords.latitude,
                longitud : p.coords.longitude
            };
            obtenerCiudadDePosicion(posicionInterna);
            
        }

    };
    var errorFunction = function(){
        mensajeErrorConexion();
    };
    intel.xdk.geolocation.getCurrentPosition(successFunction,errorFunction);
}
function obtenerCiudadDePosicion(posicion){
    var lblMensaje = document.getElementById("lblMensaje");
    lblMensaje.innerHTML = "por generar la uri";
    var uri = "http://maps.googleapis.com/maps/api/geocode/json?latlng="+posicion.latitud+","+posicion.longitud+"&sensor=true";
    lblMensaje.innerHTML = uri;
    var funcionCiudad = function(direcciones){
        if(direcciones.status === "OK" && direcciones.results.length > 3){
            //en esta posicion siempre se muestra el formato ciudad, provincia, pais
            var i = direcciones.results.length - 3; 
             //aca tengo la ciudad para llamar al servicio de geoparking que devuelve playas en base a la ciudad
            var ciudad = (direcciones.results[i].formatted_address).split(",")[0];
            
            
            lblMensaje.innerHTML = "Ciudad: " + ciudad;
            
            var playasDeCiudad = obtenerPlayasDeCiudad(ciudad);
            agregarPlayasAMapa(playasDeCiudad);
            showMarkers();
            
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