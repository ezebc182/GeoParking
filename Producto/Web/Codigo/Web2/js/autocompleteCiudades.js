function initialize() {
    var inputs = ($('.autocompleteCiudad'));
    //para lugares de interes robarle a miautobus.com controles/geosearcher.js metodo getplaces
    var options = {
        types: ['(cities)'],
        componentRestrictions: { country: 'ar' }
    };
    var autocompletes = new Array();
    $.each(inputs, function (i, input) {
        var autocomplete = new google.maps.places.Autocomplete(input,
    options);
        autocompletes.push(autocomplete);
    });
       
}

google.maps.event.addDomListener(window, 'load', initialize);