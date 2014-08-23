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


    //INICIALIZA EL MAPA AL CARGAR LA PAGINA
    function initialize() {

        //variable para la busqueda con una direccion
        geocoder = new google.maps.Geocoder();

        //centrar el mapa en la plaza San Martin
        var puntoPlaza = new google.maps.LatLng(-31.416756, -64.183501);

        //opciones basicas del mapa
        var mapOptions = {
            zoom: 15,
            center: puntoPlaza,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };

        //crea el mapa en el div "map-canvas" y le setea las opciones
        map = new google.maps.Map(document.getElementById('map-canvas'),
            mapOptions);

        //agregamos un evento de click que es el de crear circulo con el radio de cobertura
        google.maps.event.addListener(map, 'click', function (event) {

            dibujarPunto(event);

        });

        //recuperamos las playas de la ciudad
        getPlayas();
    }

//AGREGA UN PUNTO DE INTERES A PARTIR DE UN CLICK EN EL MAPA
function dibujarPunto(event) {

    //borra aquellos circulos que puede haber en el mapa
    deleteCirculos();

    //opciones del circulo
    var populationOptions = {
        strokeColor: '#FF0000',
        strokeOpacity: 0.9,
        strokeWeight: 2,
        fillColor: '#FF0000',
        fillOpacity: 0.1,
        map: map,
        center: event.latLng,
        editable: false,
        radius: 500
    };

    //centro el mapa donde se realizo el click (centro del circulo)
    map.setCenter(event.latLng);

    //agrega el circulo al mapa y a la variable punto de interes
    puntoInteres = new google.maps.Circle(populationOptions);

    //agrega el nuevo circulo a un array de circulos
    circulos.push(puntoInteres);
}

//AGREGA UN PUNTO DE INTERES A PARTIR DE UNA DIRECCION (calle y numero + la ciudad)
function marcarPunto() {

    //borra aquellos circulos que puede haber en el mapa
    deleteCirculos();

    //toma, arma y la direccion y la busca
    var address = document.getElementById('txtCalle').value + " " + document.getElementById('txtNumero').value + "," + document.getElementById('txtBuscar').value ;
    geocoder.geocode({ 'address': address }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            map.setCenter(results[0].geometry.location);

            //opciones del ciurculo
            var populationOptions = {
                strokeColor: '#FF0000',
                strokeOpacity: 0.9,
                strokeWeight: 2,
                fillColor: '#FF0000',
                fillOpacity: 0.1,
                map: map,
                center: results[0].geometry.location,
                editable: false,
                radius: 500
            };

            //agrega el circulo al mapa y a la variable punto de interes
            puntoInteres = new google.maps.Circle(populationOptions);

            //agrega el nuevo circulo a un array de circulos
            circulos.push(puntoInteres);

        } else {
            alert('La direccion establecida no ha podido encontrarse');
        }
    });


}

//AGREGA UN MARCADOR AL MAPA
function addMarker(location) {
    var marker = new google.maps.Marker({
        position: location,
        map: map
    });

    //agrega informacion al marcador
    google.maps.event.addListener(marker, 'click', function () {
        infowindow.setContent(contenido);//seteamos el contenido
        infowindow.open(map, marker);//seteamos el evento para el infowindows
    });

    //agrego el marcador al array de marcadores
    markers.push(marker);


}

//SETEO TODOS LOS MARCADORES EN EL MAPA
function setAllMap(map) {
    for (var i = 0; i < markers.length; i++) {
        markers[i].setMap(map);
    }
}

//SETEO TODOS LOS CIRCULOS EN EL MAPA
function setAllMapCirculos(map) {
    for (var i = 0; i < circulos.length; i++) {
        circulos[i].setMap(map);
    }
}

//REMUEVE TODOS LOS MARCADORES DEL MAPA
function clearMarkers() {
    setAllMap(null);
}

//REMUEVE TODOS LOS CIRCULOS DEL MAPA
function clearCirculos() {
    setAllMapCirculos(null);
}

//MUESTRA TODOS LOS MARCADORES EN EL MAPA
function showMarkers() {
    setAllMap(map);
}

//BORRA TODOS LOS MARCADORES DEL MAPA Y DEL ARRAY
function deleteMarkers() {
    clearMarkers();
    markers = [];
}

//BORRA TODOS LOS CIRCULOS DEL MAPA Y DEL ARRAY
function deleteCirculos() {
    clearCirculos();
    circulos = [];
}

//SETEA COMO METODO DE INICIO AL CARGAR LA PAGINA
google.maps.event.addDomListener(window, 'load', initialize);

        
    //AGREGAR MARCADORES DE LAS PLAYAS DE LA CIUDAD BUSCADA EN EL INDEX
    function getPlayas() {

        //peticionAjax
        $.ajax({
            type: "POST",
            url: "BusquedaPlaya.aspx/ObtenerPlayasDeCiudad",
            data: "{}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                cargarPlayas(response);                   
            },
            error: function (result) {
                alert('ERROR ' + result.status + ' ' + result.statusText);
            }
        });
    }

            
        //METODO DE BUSQUEDA POR FILTROS
        $(function () {
            $('#btnBuscar').click(function () {

                //borramos los marcadores de busquedas anteriores
                deleteMarkers();                  

                //tomo los valores de los filtros
                var tipoplaya = document.getElementById('ddlTipoPlaya').value;
                var tipovehiculo = document.getElementById('ddlTipoVehiculo').value;
                var diaatencion = document.getElementById('ddlDiasAtencion').value;

                if (Number.isInteger(document.getElementById('txtMinPrecio').value)) {
                    var preciodesde = document.getElementById('txtMinPrecio').value;
                }
                else {
                    var preciodesde = "0";
                }

                if (Number.isInteger(document.getElementById('txtMaxPrecio').value)) {
                    var preciohasta = document.getElementById('txtMaxPrecio').value;
                }
                else {
                    var preciohasta = "0";
                }


                //var preciodesde = document.getElementById('txtMinPrecio').value;
                //var preciohasta = document.getElementById('txtMaxPrecio').value;
                var horadesde = document.getElementById('ddlHoraDesde').value;
                var horahasta = document.getElementById('ddlHoraHasta').value;   
                        
                //consulta Ajax con los filtros como parametros
                $.ajax({
                    type: "POST",
                    url: "BusquedaPlaya.aspx/ObtenerPlayasDeCiudadPorFiltro",
                    data: '{tipoPlaya:' + tipoplaya + ' , tipoVehiculo:' + tipovehiculo +
                          ' , diaAtencion: ' + diaatencion + ', precioDesde:' + preciodesde +
                          ', precioHasta:' + preciohasta + ', horaDesde:' + horadesde +
                          ', horaHasta:' + horahasta + ' }',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        cargarPlayas(response);
                    },
                    error: function (result) {
                        alert('ERROR ' + result.status + ' ' + result.statusText);
                    }
                });

            });
        });


    //carga las playas de estacionamiento en el mapa
    function cargarPlayas(response) {

        //leo las playas de estacionamiento
        var playas = (typeof response.d) == 'string' ?
                           eval('(' + response.d + ')') :
                           response.d;
        alert(response);

        if (playas.length == 0)
            alert("No se encontraron resultados con los filtros seleccionados");

        //analizo la cada una y armo el contenio del marcador
        for (var i = 0; i < playas.length; i++) {

            contenido = "<div>Nombre: " + playas[i].Nombre + "</div>" +
                        "<div>Mail: " + playas[i].Mail + "</div>" +
                        "<div>Telefono: " + playas[i].Telefono + "</div>" +
                        "<div>Tipo Playa: " + playas[i].TipoPlaya + "</div>";

            //agregamos las direcciones
            contenido += "<div><h6>DIRECCIONES<h6></div>";
            var direcciones = eval(playas[i].Direcciones);
            for (var j = 0; j < direcciones.length; j++) {
                contenido += "<div>Calle: " + direcciones[j].Calle + " - Numero: " + direcciones[j].Numero + "</div>";
            }

            //agregamos los servicios
            contenido += "<div><h6>SERVICIOS<h6></div>";
            var servicios = eval(playas[i].Servicios);
            for (var K = 0; K < servicios.length; K++) {
                contenido += "<div>Tipo Vehiculo: " + servicios[K].TipoVehiculo + " - Capacidad: " + servicios[K].Capacidad + "</div>";
            }

            //agregamos los horarios
            contenido += "<div><h6>HORARIOS<h6></div>";
            var horarios = eval(playas[i].Horarios);
            for (var l = 0; l < horarios.length; l++) {
                contenido += "<div>Dia: " + horarios[l].Dia + " - Desde: " + horarios[l].HoraDesde + " - Hasta: " + horarios[l].HoraHasta + "</div>";
            }

            //agregamos los precios
            contenido += "<div><h6>PRECIOS<h6></div>";
            var precios = eval(playas[i].Precios);
            for (var m = 0; m < precios.length; m++) {
                contenido += "<div>Tipo Vehiculo: " + precios[m].TipoVehiculo + " - Dia: " + precios[m].Dia + " - Tiempo: " + precios[m].Tiempo + " - Monto: " + precios[m].Monto + "</div>";
            }

            //creamos el marcador                      
            var marker = new google.maps.Marker({
                position: new google.maps.LatLng(playas[i].Latitud, playas[i].Longitud),
                map: map
            });

            //seteamos al contenido
            (function (marker, contenido) {
                google.maps.event.addListener(marker, 'click', function () {
                    infowindow.setContent(contenido);
                    infowindow.open(map, marker);
                });
            })(marker, contenido);

            //agregamos el marcador al array
            markers.push(marker);

        }
    }

    $(function () {
        $('#marcarPunto').click(function () {
            marcarPunto();
        });
    });

