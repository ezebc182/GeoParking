﻿var GoogleMaps = {};
var map;
var markers = [];
var geocoder;

GoogleMaps.initialize = function () {
    deleteMarkers();
    geocoder = new google.maps.Geocoder();
    if ($('[id *= latitud]').first().val() == "") {
        var haightAshbury = new google.maps.LatLng(-31.416756, -64.183501);
    }
    else {
        var latitud = $('[id *= latitud]').first().val();
        var longitud = $('[id *= longitud]').first().val();
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
        $('[id *= latitud]').first().val(event.latLng.lat().toString());
        $('[id *= longitud]').first().val(event.latLng.lng().toString());
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
        draggable:true,
        map: map,
        icon: './img/marcadorParking2.png'
        
    });

    //evento al soltar le marcador para que tome la nueva posicion
    google.maps.event.addListener(marker, 'dragend', function () {
        $('[id *= latitud]').first().val(marker.getPosition().lat());
        $('[id *= longitud]').first().val(marker.getPosition().lng());        
    });

    markers.push(marker);
}

// seteo seteo el marcador en el mapa
function setAllMap(map) {
    if (markers.length > 0) {
        for (var i in markers) {
            markers[i].setMap(map);
        }
    }
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
    var calle = $('[id*=txtCalle]').first().val();
    var numero = $('[id*=txtNumero]').first().val();
    var ciudad = $("[id*=txtCiudad]").first().val();
    var address = (calle === "" ? "" : calle + " " + numero + ", ") + (ciudad !== "" ? ciudad + ", " : ciudad) + ", Argentina";

    geocoder.geocode({ 'address': address }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            map.setCenter(results[0].geometry.location);
            var marker = new google.maps.Marker({
                map: map,
                position: results[0].geometry.location,
                icon: './img/marcadorParking2.png'
            });

            $('[id *= latitud]').first().val(results[0].geometry.location.lat().toString());
            $('[id *= longitud]').first().val(results[0].geometry.location.lng().toString());

            //evento al soltar le marcador para que tome la nueva posicion
            google.maps.event.addListener(marker, 'dragend', function () {
                $('[id *= latitud]').first().val(marker.getPosition().lat());
                $('[id *= longitud]').first().val(marker.getPosition().lng());
            });

            markers.push(marker);
        } else {
            address = ciudad + ", " + provincia + ", Argentina";
            geocoder.geocode({ 'address': address }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    map.setCenter(results[0].geometry.location);
                    var marker = new google.maps.Marker({
                        map: map,
                        position: results[0].geometry.location
                    });

                    $('[id *= latitud]').first().val(results[0].geometry.location.lat().toString());
                    $('[id *= longitud]').first().val(results[0].geometry.location.lng().toString());

                    //evento al soltar le marcador para que tome la nueva posicion
                    google.maps.event.addListener(marker, 'dragend', function () {                        
                        $('[id *= latitud]').first().val(marker.getPosition().lat());
                        $('[id *= longitud]').first().val(marker.getPosition().lng());
                    });

                    markers.push(marker);
                } else {
                    alert('La direccion establecida no ha podido encontrarse');
                }
            });
        }
    });

    window.onload = loadScript;

    google.maps.event.addDomListener(window, 'onload', GoogleMaps.initialize);
}