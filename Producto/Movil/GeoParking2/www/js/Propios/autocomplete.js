var input = (document.getElementById('txtBusqueda'));
var autocomplete = new google.maps.places.Autocomplete(input);
var lugarBuscado = null;
$("#btnMostrarBusquedaEnMapa").click(function(){
    var markerLugarBuscado = new google.maps.Marker({
        position: lugarBuscado.geometry.location,
        map: map,
        icon: lugarBuscado.icon
    });
    markerLugarBuscado.setMap(map);
    map.setCenter(lugarBuscado.geometry.location);
});
$("#btnVerListadoPuntoBuscado").click(function(){
    verListado()
});
$("#btnBorrarBusqueda").click(function(){
    lugarBuscado = null;
    markerLugarBuscado.setMap(null);
    markerLugarBuscado = null;
    ubicarMiPosicion();
});


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









//var inputs = ($('#txtBusqueda'));

//para lugares de interes robarle a miautobus.com controles/geosearcher.js metodo getplaces
/*var location = usuario.getLocation();*/
/*var options = {
    types: ['(cities)'],
    componentRestrictions: {
        country: 'ar'
    }

};

var autocompletes = new Array();
$.each(inputs, function (i, input) {
    var autocomplete = new google.maps.places.Autocomplete(input,
        options);
    autocompletes.push(autocomplete);
});*/

/* ESTE ES EL METODO ROBADO DE miautobus.com
function getPlaces(dire) {
    var dire = $('#txtBusqueda').val('');
    var request = {
        query: dire,
        bounds: strictBounds,
        types: ['accounting', 'airport', 'amusement_park', 'aquarium', 'art_gallery', 'atm', 'bakery', 'bank', 'bar', 'beauty_salon', 'bicycle_store', 'book_store', 'bowling_alley', 'bus_station', 'cafe', 'campground', 'car_dealer', 'car_rental', 'car_repair', 'car_wash', 'casino', 'cemetery', 'church', 'city_hall', 'clothing_store', 'convenience_store', 'courthouse', 'dentist', 'department_store', 'doctor', 'electrician', 'electronics_store', 'embassy', 'establishment', 'finance', 'fire_station', 'florist', 'food', 'funeral_home', 'furniture_store', 'gas_station', 'general_contractor', 'grocery_or_supermarket', 'gym', 'hair_care', 'hardware_store', 'health', 'hindu_temple', 'home_goods_store', 'hospital', 'insurance_agency', 'jewelry_store', 'laundry', 'lawyer', 'library', 'liquor_store', 'local_government_office', 'locksmith', 'lodging', 'meal_delivery', 'meal_takeaway', 'mosque', 'movie_rental', 'movie_theater', 'moving_company', 'museum', 'night_club', 'painter', 'park', 'parking', 'pet_store', 'pharmacy', 'physiotherapist', 'place_of_worship,', 'plumber,', 'police,', 'post_office', 'real_estate_agency', 'restaurant', 'roofing_contractor', 'rv_park', 'school', 'shoe_store', 'shopping_mall', 'spa', 'stadium', 'storage', 'store', 'subway_station', 'synagogue', 'taxi_stand', 'train_station', 'travel_agency', 'university', 'veterinary_care', 'zoo']
    };

    service = new google.maps.places.PlacesService(map);
    service.textSearch(request, function (results, status) {
            if (status == google.maps.places.PlacesServiceStatus.OK) {
                for (var i = 0; i < results.length; i++) {
                    var latlng = results[i].geometry.location;
                    var name = results[i].name;

                });
            alert("buscado");

        }*/