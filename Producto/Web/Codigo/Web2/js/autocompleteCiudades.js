function initialize() {
    var input = (document.getElementById('txtBuscar'));

    var options = {
        types: ['(cities)'],
        componentRestrictions: { country: 'ar' }
    };
    var autocomplete = new google.maps.places.Autocomplete(input,
    options);   
}

google.maps.event.addDomListener(window, 'load', initialize);