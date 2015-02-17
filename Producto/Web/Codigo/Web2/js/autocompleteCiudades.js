function initialize() {

    var inputs = ($('.autocompleteCiudad'));
    //para lugares de interes robarle a miautobus.com controles/geosearcher.js metodo getplaces
    var options = {
        types: ['(cities)'],
        componentRestrictions: { country: 'ar' }
    };
    var autocompletes = new Array();

    var autocomplete;

    $.each(inputs, function (i, input) {
        autocomplete = new google.maps.places.Autocomplete(input,
    options);

        google.maps.event.addListener(autocomplete, 'place_changed', function () {
            
            var place = autocomplete.getPlace();

            try {
                $('#txtIdPlace').val(place.id);
               
            }
            catch (err) {

            }

        });
        autocompletes.push(autocomplete);


    });


}

google.maps.event.addDomListener(window, 'load', initialize);