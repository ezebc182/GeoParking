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

    //var ciudad = <%=ciudadBuscada%>;
    //document.getElementById('txtBuscar').value =ciudad;

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
    var address = document.getElementById('txtDireccion').value + "," + document.getElementById('txtBuscar').value;
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
        map: map,
        icon: './img/maracdorParking.png'
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

//METODO DE BUSQUEDA EN CIUDAD NUEVA
$(function () {
    $('#Button1').click(function () {

        //borramos los marcadores de busquedas anteriores
        deleteMarkers();

        //tomo el valor de la nueva ciudad
        var ciudadNueva = document.getElementById('txtBuscar').value;

        //consulta Ajax con la ciudad nueva como parametro
        $.ajax({
            type: "POST",
            url: "BusquedaPlaya.aspx/ObtenerPlayasDeCiudadNueva",
            data: '{ciudad:"'+ciudadNueva+'"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                cargarPlayas(response);
            },
            error: function (response) {
                alert('ERROR ' + response.status + ' ' + response.statusText);
            }
        });

    });
});
 
//METODO DE BUSQUEDA POR FILTROS
$(function () {
            $('#btnBuscar').click(function () {

                //borramos los marcadores de busquedas anteriores
                deleteMarkers();                  

                //tomo los valores de los filtros
                var tipoplaya = document.getElementById('ddlTipoPlaya').value;
                var tipovehiculo = document.getElementById('ddlTipoVehiculo').value;
                var diaatencion = document.getElementById('ddlDiasAtencion').value;

                var minPrecio = document.getElementById('txtMinPrecio').value;
                if (Number.isInteger(parseInt(minPrecio))) {
                    var preciodesde = minPrecio;
                }
                else {
                    var preciodesde = "0";
                }

                var maxPrecio = document.getElementById('txtMaxPrecio').value;
                if (Number.isInteger(parseInt(maxPrecio))) {
                    var preciohasta = maxPrecio;
                }
                else {
                    var preciohasta = "0";
                }
                
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

//METODO DE LAS TABS DE INFORMACION DE LAS PLAYAS
$(function () {
                $("#tabs").tabs();
          });

//carga las playas de estacionamiento en el mapa
function cargarPlayas(response) {

        //leo las playas de estacionamiento
        var playas = (typeof response.d) == 'string' ?
                           eval('(' + response.d + ')') :
                           response.d;

        if (playas.length == 0)
            alert("No se encontraron resultados con los filtros seleccionados");

        //analizo la cada una y armo el contenio del marcador
        for (var i = 0; i < playas.length; i++) {

            contenido = "";

            contenido += "<div class='tabbable' id='tabs-23'>" +
                            "<ul class='nav nav-tabs'>" +
                              "<li class='active'>" +
                                "<a href='#panel-1' data-toggle='tab'>Datos Generales</a>" +
                              "</li>" +
                              "<li>" +
                                "<a href='#panel-2' data-toggle='tab'>Horarios</a>" +
                              "</li>" +
                               "<li>" +
                                "<a href='#panel-3' data-toggle='tab'>Precios</a>" +
                              "</li>" +
                            "</ul>" +
                            "<div class='tab-content'>";  
 

            //PRIMER TAB
            contenido += "<div class='tab-pane active' id='panel-1'>"+
            "<p>";
              
            "<div>Nombre: " + playas[i].Nombre + "</div>" +
           "<div>Mail: " + playas[i].Mail + "</div>" +
           "<div>Telefono: " + playas[i].Telefono + "</div>" +
           "<div>Tipo Playa: " + playas[i].TipoPlaya + "</div>"


            //agregamos las direcciones
            contenido += "<div><h6>DIRECCION<h6></div>";
            var direcciones = eval(playas[i].Direcciones);
            for (var j = 0; j < direcciones.length; j++) {
                contenido += "<div>Calle: " + direcciones[j].Calle + " - N°: " + direcciones[j].Numero + "</div>";
            }

            //agregamos los servicios
            contenido += "<div><h6>SERVICIOS<h6></div>";
            var servicios = eval(playas[i].Servicios);
            for (var K = 0; K < servicios.length; K++) {
                contenido += "<div>Tipo Vehiculo: " + servicios[K].TipoVehiculo + " - Capacidad: " + servicios[K].Capacidad + "</div>";
            }

            contenido += "</p></div>";   

            //SEGUNDO TAB
            contenido += "<div class='tab-pane' id='panel-2'>" +
            "<p>";

            //agregamos los horarios
            contenido += "<div><h6>HORARIOS<h6></div>";
            var horarios = eval(playas[i].Horarios);
            for (var l = 0; l < horarios.length; l++) {
                contenido += "<div>" + horarios[l].Dia + " - Desde: " + horarios[l].HoraDesde + " - Hasta: " + horarios[l].HoraHasta + "</div>";
            }

            contenido += "</p></div>";                
   
            //TERCER TAB
            contenido += "<div class='tab-pane' id='panel-3'>" +
            "<p>";
    
            //agregamos los precios
            contenido += "<div><h6>PRECIOS<h6></div>";
            var precios = eval(playas[i].Precios);
            for (var m = 0; m < precios.length; m++) {
                contenido += "<div>" + precios[m].TipoVehiculo + " - " + precios[m].Dia + " - " + precios[m].Tiempo + " $" + precios[m].Monto + "</div>";
            }

            contenido += "</p></div>";
     
            contenido += "</div></div>";

            //creamos el marcador                      
            var marker = new google.maps.Marker({
                position: new google.maps.LatLng(playas[i].Latitud, playas[i].Longitud),
                map: map,
                icon: './img/maracdorParking.png'
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

//marcar punto por una direccion
$(function () {
        $('#marcarPunto').click(function () {
            marcarPunto();
        });
    });

