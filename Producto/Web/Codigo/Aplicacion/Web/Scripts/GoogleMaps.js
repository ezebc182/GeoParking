var GoogleMaps = {};
var map;
var markers = [];
var geocoder;

GoogleMaps.initialize = function () {
    geocoder = new google.maps.Geocoder();
    if (document.getElementById('txtLatitud').value == "") {
        var haightAshbury = new google.maps.LatLng(-31.416756, -64.183501);
    }
    else {
        var latitud = document.getElementById('txtLatitud').value;
        var longitud = document.getElementById('txtLongitud').value
        var haightAshbury = new google.maps.LatLng(latitud, longitud);
    }

    var mapOptions = {
        zoom: 17,
        center: haightAshbury,
        mapTypeId: google.maps.MapTypeId.SATELLITE
    };
    map = new google.maps.Map(document.getElementById('map-canvas'),
        mapOptions);

    // This event listener will call addMarker() when the map is clicked.
    google.maps.event.addListener(map, 'click', function (event) {
        deleteMarkers();
        addMarker(event.latLng);
        document.getElementById('txtLatitud').value = event.latLng.lat();
        document.getElementById('txtLongitud').value = event.latLng.lng();

    });

    // Adds a marker at the center of the map.
    addMarker(haightAshbury);
}

//Agregar el marcador en la posicion establecida
function addMarker(location) {

    map.setOptions({
        center: location,
    });

    var marker = new google.maps.Marker({
        position: location,
        map: map
    });
    markers.push(marker);
}

// seteo seteo el marcador en el mapa
function setAllMap(map) {
    markers[0].setMap(map);
}

// Borro los marcadores del array y del mapa
function deleteMarkers() {
    setAllMap(null);
    markers = [];
}

function loadScript() {
    var script = document.createElement("script");
    script.type = "text/javascript";
    script.src = "https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false&callback=initialize";
    document.body.appendChild(script);
}

function codeAddress() {

    deleteMarkers();

    var address = document.getElementById('txtDireccion').value;
    geocoder.geocode({ 'txtDireccion': address }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            map.setCenter(results[0].geometry.location);
            var marker = new google.maps.Marker({
                map: map,
                position: results[0].geometry.location
            });

            markers.push(marker);
        } else {
            alert('La direccion establecida no ha podido encontrarse');
        }
    });

    window.onload = loadScript;

    google.maps.event.addDomListener(window, 'onload', initialize);
}