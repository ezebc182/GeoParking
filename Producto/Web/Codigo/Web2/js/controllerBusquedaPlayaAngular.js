
//aplicacion angular con modulo de ng-grid
var app = angular.module('myApp', []);

//controlador de la aplicacion (busqueda playa)
app.controller('MyCtrl', function ($scope, $http) {   

    $scope.map;//mapa
    $scope.markers = [];//marcadores   
    $scope.circulos = [];//circulos    
    $scope.marcadorCirculo = [];//marcadores de circulos    
    var contenido = "";//contenido infowindow de marcador   
    var infowindow = new google.maps.InfoWindow({ content: '' , maxWidth: 600  });//infowindow vacio
    var playas = [];//playas que recupera de la BD
    var mostrarBusquedaAvanzada = false;
    $scope.playasGrilla = [];//playas de la grilla de la ciudad buscada       
    $scope.mostrarGrilla = false;//true: se muestra grilla , false: se muestra mapa   
    $scope.resultado = [];

    $scope.currentPage = 0;
    $scope.pageSize = 8;
    
    $scope.$watch('a', function () {
        $scope.currentPage = 0;
        $scope.numberOfPages();
    });

    $scope.$watch('pageSize', function () {
        $scope.currentPage = 0;
        $scope.numberOfPages();
    });

    $scope.numberOfPages = function () {
        return Math.ceil($scope.resultado.length / $scope.pageSize);
    }

    /*OMITE LOS ACENTOS DE UNA CADENA, PARA QUE EL NOMBRE DE LA CIUDAD
    SEA COMPATIBLE CON LA BD*/
    $scope.omitirAcentos = function(text) {
        var acentos = "ÃÀÁÄÂÈÉËÊÌÍÏÎÒÓÖÔÙÚÜÛãàáäâèéëêìíïîòóöôùúüûÑñÇç";
        var original = "AAAAAEEEEIIIIOOOOUUUUaaaaaeeeeiiiioooouuuunncc";
        for (var i = 0; i < acentos.length; i++) {
            text = text.replace(acentos.charAt(i), original.charAt(i));
        }
        return text;
    }

    /*CREA EL INFOWINDOWS PARA UNA PLAYA*/
    $scope.crearInfoWindows = function (playa) {

        infoWindow = new google.maps.InfoWindow();

        contenido = "";

        contenido += "<div class='tabbable' id='tabs-23'>" +
                        "<ul class='nav nav-tabs'>" +
                          "<li class='active'>" +
                            "<a href='#panel-1' data-toggle='tab'>Datos Generales</a>" +
                          "</li>" +
                          "<li>" +
                            "<a href='#panel-2' data-toggle='tab'>Servicios</a>" +
                          "</li>" +                           
                        "</ul>" +
                        "<div class='tab-content'>";


        //PRIMER TAB
        contenido += "<div class='tab-pane active' id='panel-1'>" +
        "<p>";

        contenido += "<table class='table table-responsive'>";

        contenido += "<tr><td> <strong>Nombre:</strong> </td> <td>" + playa.Nombre + " </td> </tr>" +
       "<tr><td> <strong>Mail:</strong> </td> <td>" + playa.Mail + " </td> </tr>" +
       "<tr><td> <strong>Telefono:</strong> </td> <td>" + playa.Telefono + " </td> </tr>" +
       "<tr><td> <strong>Tipo Playa:</strong> </td> <td>" + playa.TipoPlaya + " </td> </tr>";

        contenido += "</table>";

        //agregamos las direcciones
        contenido += "<div><h6>DIRECCION<h6></div>";
        contenido += "<table>";
        var direcciones = eval(playa.Direcciones);
        for (var j = 0; j < direcciones.length; j++) {
            contenido += "<tr><td>" + direcciones[j].Calle + ":  </td> <td>" + direcciones[j].Numero + " </td> </tr>";
        }
        contenido += "</table>";

        //agregamos los horarios
        contenido += "<div><h6>HORARIO<h6></div>";
        contenido += "<table>";
        contenido += "<tr><td>" + playa.Horario.Dia + "</td> <td> <strong>Desde:</strong></td> <td> " + playa.Horario.HoraDesde + "</td> <td> - <strong>Hasta:</strong> </td> <td>" + playa.Horario.HoraHasta + "</td> </tr>";
        contenido += "</table>";             

        
        contenido += "</p></div>";

        //SEGUNDO TAB
        contenido += "<div class='tab-pane' id='panel-2'>" +
        "<p>";

        //agregamos los servicios
        contenido += "<div><h6>SERVICIOS<h6></div>";
        contenido += "<table class='table table-responsive'>";
        var servicios = eval(playa.Servicios);
        for (var K = 0; K < servicios.length; K++) {
            contenido += "<tr><td>" + servicios[K].TipoVehiculo + ":  </td> <td> <strong> Capacidad: </strong>" + servicios[K].Capacidad + " </td> </tr>";
        }
        contenido += "</table>";

        //agregamos los precios
        contenido += "<div><h6>PRECIOS<h6></div>";
        contenido += "<table class='table table-responsive'>";

        for (var l = 0; l < servicios.length; l++) {
            var precios = eval(servicios[l].Precios);
            if (precios != null) {
                for (var m = 0; m < precios.length; m++) {
                    if (precios[m].Monto > 0)
                        contenido += "<tr><td>" + servicios[l].TipoVehiculo + "</td> <td>  <strong> " + precios[m].Tiempo + ": </strong>$" + precios[m].Monto + "</td> </tr>";
                }
            }
        }       
        contenido += "</table>"
        contenido += "</p></div>";
        contenido += "</div></div>";

        infoWindow.setContent(
            '' + contenido + ''
        );

        infoWindow.setPosition(new google.maps.LatLng(playa.Latitud.replace(",", "."), playa.Longitud.replace(",", ".")));
        infoWindow.open($scope.map);
    }

    /*PERMITE MOSTRAR LAPLAYA SELECCIONADA EN EL MAPA*/
    $scope.ir = function (row) {

        for (var i = 0; i < playas.length; i++) {
            if (playas[i].Id == row.Id) {
                var playa = playas[i];
            }
        }

        if (mostrarBusquedaAvanzada == true) {
            $scope.ajustarMapa();
        }

        $scope.listar();//$scope.mostrarGrilla = false;//oculto la grilla        
        $scope.map.setZoom(20);//zoom mapa      
        $scope.crearInfoWindows(playa);//crea el info para esa playa y lo muestra
        $scope.map.setCenter(new google.maps.LatLng(playa.Latitud.replace(",", "."), playa.Longitud.replace(",", ".")));//centro el mapa en la playa              
    }

    /*AGRANDA EL MAPA PARA MOSTRARLO COMPLETO (CUANDO NO ESTA LA BUQUEDA AVANZADA)*/
    $scope.agrandarMapa = function () {
        $("#btnBusquedaAvanzada").html("<span class='glyphicon glyphicon-cog'></span>&nbsp;Búsqueda Avanzada");
        $("#busquedaAvanzada").hide();
        $("#map-canvas").css("width", "1260px");
        $("#map-canvas").css("height", "500px");
        $("#map-canvas").css("border-color", "gray");
        $("#map-canvas").css("margin-left", "-30px");
    }

    /*MUESTRA LA GRILLA O LA ESCONDE SI ESTA ACTIVA*/
    $scope.listar = function () {
        if ($scope.mostrarGrilla == false) {
            if (mostrarBusquedaAvanzada == false) {
                $("#contenedorGrilla").removeClass("table-responsive");
            }
            $scope.mostrarGrilla = true;
            $("#btnListado").html("<span class='glyphicon glyphicon-globe'></span>&nbsp;Ver Mapa");
        }
        else {
            $scope.mostrarGrilla = false;
            $("#btnListado").html("<span class='glyphicon glyphicon-list-alt'></span>&nbsp;Ver Listado")
        }

    }

    /*AJUSTA EL TAMAÑO DEL MAPA AL ABRIR LA BUSQUEDA AVANZADA*/
    $scope.ajustarMapa = function () {
        if (mostrarBusquedaAvanzada == false) {
            $("#btnBusquedaAvanzada").html("<span class='glyphicon glyphicon-cog'></span>&nbsp;Ocultar Avanzada");//            
            $("#map-canvas").fadeIn(3000, function () {
                $("#map-canvas").css("width", "931px");
                $("#map-canvas").css("height", "500");
                $("#map-canvas").css("border-color", "gray");
                $("#map-canvas").css("margin-left", "-10px");
            });
            $("#contenedorGrilla").addClass("table-responsive");
            $(".gridStyle").css("margin-left","0px");
            $("#busquedaAvanzada").show();
            mostrarBusquedaAvanzada = true;
        }
        else {
            $scope.agrandarMapa();
            $(".gridStyle").css("margin-left", "-15px");
            $("#contenedorGrilla").removeClass("table-responsive");
            mostrarBusquedaAvanzada = false;
        }

    }

    /*BUSCO LAS PLAYAS DE LA NUEVA CIUDAD*/
    $scope.buscarPlayasCiudad = function () {

        $scope.playasGrilla = [];//vacio las playas a mostrar en la grila        

        if ($scope.mostrarGrilla == true) {
            $scope.listar();//$scope.mostrarGrilla = false;//oculto la grilla y muestro el mapa
        }

        //borramos marcadores y circulos
        $scope.deleteMarkers();
        $scope.deleteCirculos();

        $scope.ciudad = document.getElementById('txtBuscar').value;        

        //tomo el valor de la nueva ciudad
        var direccionCiudad = $scope.ciudad.split(',');
        var ciudad = direccionCiudad[0];

        var ciudadNueva = ciudad;
        //var ciudadNueva = $scope.omitirAcentos(ciudad);

        $http({
            url: "BusquedaPlaya.aspx/ObtenerPlayasDeCiudadNueva",//mi pagina de begin
            method: "POST",
            headers: { 'Content-Type': 'application/json' },  // agregar a para webmethod con parametros
            data: { ciudad: ciudadNueva }
        }).success(function (response) {

            //toma la direccion y la busca
            var address = $scope.ciudad;
           
            $scope.geocoder.geocode({ 'address': address }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    $scope.map.setCenter(results[0].geometry.location);
                    $scope.map.setZoom(12);

                    $scope.cargarPlayas(response)//carga las playas en el mapa     

                    $scope.cargarPlayasGrilla(response);//carga las playas en la grilla

                    //reseteo filtros
                    document.getElementById('ddlTipoPlaya').value = 0;
                    document.getElementById('ddlTipoVehiculo').value = 0;
                    document.getElementById('ddlDiasAtencion').value = 0;
                    document.getElementById('txtMinPrecio').value = 0;
                    document.getElementById('txtMaxPrecio').value = 0;
                    document.getElementById('ddlHoraDesde').value = 0;
                    document.getElementById('ddlHoraHasta').value = 0;
                }
            });

        }).error(function (data, status, headers, config) {
            alert('ERROR ' + data.status + ' ' + data.statusText, 'Error');
        });
    }   

    /*BUSCA LA CIUDAD EN LA SESSION Y LA LOCALIZA EN EL MAPA*/
    $scope.buscarCiudadSesion = function () {
        $http({
            url: "BusquedaPlaya.aspx/ObtenerCiudadSession",//mi pagina de begin
            method: "POST",
            data: $.param({})
        }).success(function (response) {

            //$scope.ciudad = $scope.omitirAcentos(response.d);//ciudad en la session
            $scope.ciudad = response.d;

            //toma la ciudad, arma la direccion (solo argentina) y la busca
            var address = $scope.ciudad + ", Argentina";
            $scope.geocoder.geocode({ 'address': address }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    $scope.map.setCenter(results[0].geometry.location);
                    $scope.map.setZoom(12);
                } else {
                    alert("La ciudad no ha podido encontrarse")
                }
            });

        }).error(function (data, status, headers, config) {
            alert(status);
        });
    }

    /*COLOCA UN MARCADOR+CIRCULO=(PUNTODE INTERES) EN EL LUGAR DEL CLICK*/
    $scope.dibujarPunto = function (event) {
        $scope.deleteCirculos();//borrar circulos

        //opciones del circulo
        var populationOptions = {
            strokeColor: '#FF0000',
            strokeOpacity: 0.9,
            strokeWeight: 2,
            fillColor: '#FF0000',
            fillOpacity: 0.1,
            map: $scope.map,
            center: event.latLng,
            editable: false,
            radius: 500
        };

        $scope.map.setCenter(event.latLng);//centro el mapa
        puntoInteres = new google.maps.Circle(populationOptions);//creo punto de interes(circulo)        
        $scope.circulos.push(puntoInteres);//agrego punto de interes "circulos"

        //creamos el marcador                      
        var marker = new google.maps.Marker({
            position: event.latLng,
            map: $scope.map
        });

        marker.setAnimation(google.maps.Animation.BOUNCE);

        //seteamos al contenido
        (function (marker, contenido) {
            google.maps.event.addListener(marker, 'mouseover', function () {
                infowindow.setContent("Usted esta aquí");
                infowindow.open($scope.map, marker);
            });
        })(marker, contenido);

        $scope.marcadorCirculo.push(marker);//agregamos el marcador
        $scope.map.setZoom(15);//zoom mapa
    }

    /*COLOCA UN MARCADOR+CIRCULO=(PUNTODE INTERES) A PARTIR DE UNA DIRECCION (calle y numero + la ciudad)*/
    $scope.marcarPunto = function () {

        alert("borro los circulos")
        $scope.deleteCirculos();//borra circulos

        alert("direccion: " + $scope.direccion);

        //toma la direccion, la completa y la busca en el mapa
        var address = $scope.direccion + "," + $scope.ciudad + ", Argentina";
        $scope.geocoder.geocode({ 'address': address }, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                $scope.map.setCenter(results[0].geometry.location);//centro el mapa

                //opciones del ciurculo
                var populationOptions = {
                    strokeColor: '#FF0000',
                    strokeOpacity: 0.9,
                    strokeWeight: 2,
                    fillColor: '#FF0000',
                    fillOpacity: 0.1,
                    map: $scope.map,
                    center: results[0].geometry.location,
                    editable: false,
                    radius: 500
                };

                puntoInteres = new google.maps.Circle(populationOptions);//creo punto de interes(circulo)

                $scope.circulos.push(puntoInteres);//agrego punto de interes

                //creamos el marcador                      
                var marker = new google.maps.Marker({
                    position: results[0].geometry.location,
                    map: $scope.map
                });

                marker.setAnimation(google.maps.Animation.BOUNCE);

                //seteamos al contenido
                (function (marker, contenido) {
                    google.maps.event.addListener(marker, 'mouseover', function () {
                        infowindow.setContent("Usted esta aquí");
                        infowindow.open($scope.map, marker);
                    });
                })(marker, contenido);

                //agregamos el marcador al array
                $scope.marcadorCirculo.push(marker);

                $scope.map.setZoom(15);

            } else {
                alert('La direccion establecida no ha podido encontrarse', 'Resultado de la Busqueda');
            }
        });


    }

    /*AGREGA UN MARCADOR AL MAPA*/
    $scope.addMarker = function (location) {

        //creamos el marcador
        var marker = new google.maps.Marker({
            position: location,
            map: $scope.map,
            icon: './img/marcadorParking2.png'
        });

        //agrega informacion al marcador
        google.maps.event.addListener(marker, 'click', function () {
            infowindow.setContent(contenido);//seteamos el contenido
            infowindow.open($scope.map, marker);//seteamos el evento para el infowindows
        });

        $scope.markers.push(marker);//agrego el marcador
    }

    /*SETEO TODOS LOS MARCADORES EN EL MAPA*/
    $scope.setAllMap = function (map) {
        for (var i = 0; i < $scope.markers.length; i++) {
            $scope.markers[i].setMap(map);
        }
    }

    /*SETEO TODOS LOS CIRCULOS EN EL MAPA*/
    $scope.setAllMapCirculos = function (map) {
        for (var i = 0; i < $scope.circulos.length; i++) {
            $scope.circulos[i].setMap(map);
        }
    }

    /*SETEO TODOS LOS MARCADORES DE CIRULO EN EL MAPA*/
    $scope.setAllMapMarcadorCirculo = function (map) {
        for (var i = 0; i < $scope.marcadorCirculo.length; i++) {
            $scope.marcadorCirculo[i].setMap(map);
        }
    }

    /*REMUEVE TODOS LOS MARCADORES DEL MAPA*/
    $scope.clearMarkers = function () {
        $scope.setAllMap(null);
    }

    /*REMUEVE TODOS LOS CIRCULOS DEL MAPA*/
    $scope.clearCirculos = function () {
        $scope.setAllMapCirculos(null);
    }

    /*REMUEVE TODOS LOS MARCADORES DE CIRCULOS DEL MAPA*/
    $scope.clearMarcadorCirculo = function () {
        $scope.setAllMapMarcadorCirculo(null);
    }

    /*MUESTRA TODOS LOS MARCADORES EN EL MAPA*/
    $scope.showMarkers = function () {
        $scope.setAllMap($scope.map);
    }

    /*BORRA TODOS LOS MARCADORES DEL MAPA Y DEL ARRAY*/
    $scope.deleteMarkers = function () {
        $scope.clearMarkers();
        $scope.markers = [];
    }

    /*BORRA TODOS LOS CIRCULOS DEL MAPA Y DEL ARRAY*/
    $scope.deleteCirculos = function () {
        $scope.clearCirculos();
        $scope.circulos = [];
        $scope.clearMarcadorCirculo();
        $scope.marcadorCirculo = [];
    }

    /*CARGA LAS PLAYAS DE ESTACIONAMIENTO EN EL MAPA [REVEER HTML]*/
    $scope.cargarPlayas = function (response) {

        //leo las playas de estacionamiento
        playas = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;

        if (playas.length > 0) {
            //analizo la cada una y armo el contenio del marcador
            for (var i = 0; i < playas.length; i++) {

                contenido = "<div id=info>";

                contenido += "<div class='tabbable' id='tabs-23'>" +
                                "<ul class='nav nav-tabs'>" +
                                  "<li class='active'>" +
                                    "<a href='#panel-1' data-toggle='tab'>Datos Generales</a>" +
                                  "</li>" +
                                  "<li>" +
                                    "<a href='#panel-2' data-toggle='tab'>Servicios</a>" +
                                  "</li>" +                                  
                                "</ul>" +
                                "<div class='tab-content'>";


                //PRIMER TAB
                contenido += "<div class='tab-pane active' id='panel-1'>" +
                "<p>";

                contenido += "<table class='table table-responsive'>";

                contenido += "<tr><td> <strong>Nombre:</strong> </td> <td>" + playas[i].Nombre + " </td> </tr>" +
               "<tr><td> <strong>Mail:</strong> </td> <td>" + playas[i].Mail + " </td> </tr>" +
               "<tr><td> <strong>Telefono:</strong> </td> <td>" + playas[i].Telefono + " </td> </tr>" +
               "<tr><td> <strong>Tipo Playa:</strong> </td> <td>" + playas[i].TipoPlaya + " </td> </tr>";

                contenido += "</table>";

                //agregamos las direcciones
                contenido += "<div><h6>DIRECCION<h6></div>";
                contenido += "<table class='table table-responsive'>";
                var direcciones = eval(playas[i].Direcciones);
                for (var j = 0; j < direcciones.length; j++) {
                    contenido += "<tr><td>" + direcciones[j].Calle + "  </td><td style='text-aline:left'> " + direcciones[j].Numero + " </td> </tr>";
                }
                contenido += "</table>";

                //agregamos los horarios
                contenido += "<div><h6>HORARIO<h6></div>";
                contenido += "<table>";
                contenido += "<tr><td>" + playas[i].Horario.Dia + "</td> <td> <strong>Desde:</strong></td> <td> " + playas[i].Horario.HoraDesde + "</td> <td> - <strong>Hasta:</strong> </td> <td>" + playas[i].Horario.HoraHasta + "</td> </tr>";
                contenido += "</table>";
                contenido += "</p></div>";

                

                //SEGUNDO TAB
                contenido += "<div class='tab-pane' id='panel-2'>" +
                "<p>";

                //agregamos los servicios
                contenido += "<div><h6>SERVICIOS<h6></div>";
                contenido += "<table class='table table-responsive'>";
                var servicios = eval(playas[i].Servicios);
                for (var K = 0; K < servicios.length; K++) {
                    contenido += "<tr><td>" + servicios[K].TipoVehiculo + ":  </td> <td> <strong> Capacidad: </strong>" + servicios[K].Capacidad + " </td> </tr>";
                }
                contenido += "</table>";
               

                //agregamos los precios
                contenido += "<div><h6>PRECIOS<h6></div>";
                contenido += "<table class='table table-responsive'>";

                for (var l = 0; l < servicios.length; l++) {
                    var precios = eval(servicios[l].Precios);
                    if (precios != null) {
                        for (var m = 0; m < precios.length; m++) {
                            if(precios[m].Monto>0)
                                contenido += "<tr><td>" + servicios[l].TipoVehiculo + "</td> <td>  <strong> " + precios[m].Tiempo + ": </strong>$" + precios[m].Monto + "</td> </tr>";
                        }
                    }
                }
                contenido += "</table>"
                
                contenido += "</p></div>";

                
                contenido += "</div></div>";

                contenido += "</div>";

                //creamos el marcador                      
                var marker = new google.maps.Marker({
                    position: new google.maps.LatLng(playas[i].Latitud.replace(",", "."), playas[i].Longitud.replace(",", ".")),
                    map: $scope.map,
                    icon: './img/marcadorParking2.png'
                });

                
                //seteamos al contenido
                (function (marker, contenido) {
                    google.maps.event.addListener(marker, 'click', function () {
                        infowindow.setContent(contenido);
                        infowindow.open($scope.map, marker);
                    });
                })(marker, contenido);

                //agregamos el marcador al array
                $scope.markers.push(marker);

            }
        }
        else alert('No se han encontrado playas con los filtros seleccionados')
    }

    /*CARGA LAS PLAYAS EN LA GRILLA*/
    $scope.cargarPlayasGrilla = function (response) {

        //vacio la variable
        $scope.playasGrilla = [];

        //leo las playas de estacionamiento
        var playas = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;

        if (playas.length > 0) {

            //analizo la cada una y armo el contenio del marcador
            for (var i = 0; i < playas.length; i++) {

                var Id = playas[i].Id;
                var Nombre = playas[i].Nombre;
                var TipoPlaya = playas[i].TipoPlaya;
                var Direccion = "";
                var direcciones = eval(playas[i].Direcciones);
                Direccion += direcciones[0].Calle + " " + direcciones[0].Numero;

                var Vehiculos = "";
                var servicios = eval(playas[i].Servicios);
                for (var K = 0; K < servicios.length; K++) {
                    Vehiculos += servicios[K].TipoVehiculo + ",";
                }

                //var Horarios=""               
                //var horarios = eval(playas[i].Horarios);
                //for (var l = 0; l < horarios.length; l++) {
                //    contenido += "<tr><td>" + horarios[l].Dia + "</td> <td> - <strong>Desde:</strong></td> <td> " + horarios[l].HoraDesde + "</td> <td> - <strong>Hasta:</strong> </td> <td>" + horarios[l].HoraHasta + "</td> </tr>";
                //}

                var Precios = "";

                for (var l = 0; l < servicios.length; l++) {
                    var precios = eval(servicios[l].Precios);
                    if (precios != null) {
                        for (var m = 0; m < precios.length; m++) {
                            if (precios[m].Monto > 0 && precios[m].Tiempo=="Hora")
                                //Precios += servicios[l].TipoVehiculo + " - " + precios[m].Tiempo + ": $" + precios[m].Monto + "\n";
                                Precios += " " + servicios[l].TipoVehiculo + ": $" + precios[m].Monto + "\n";
                        }
                    }
                }
              
                var latitud = playas[i].Latitud;
                var longitud = playas[i].Longitud;

                $scope.playasGrilla.push({ Id: Id, Nombre: Nombre, TipoPlaya: TipoPlaya, Direccion: Direccion, Vehiculos: Vehiculos, Precios: Precios, Latitud: latitud, Longitud: longitud });
                
            }            
        }               
    }

    /*FILTRO LAS PLAYAS*/
    $scope.filtrar = function () {
        alert("aca realizo el filtrado de las playas")

        $scope.playasGrilla = [];//vacio las playas a mostrar en la grila

        //borramos los marcadores de busquedas anteriores
        $scope.deleteMarkers();

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

        $http({
            url: "BusquedaPlaya.aspx/ObtenerPlayasDeCiudadPorFiltro",//mi pagina de begin
            method: "POST",
            headers: { 'Content-Type': 'application/json' },  // agregar a para webmethod con parametros
            data: {
                tipoPlaya: tipoplaya,
                tipoVehiculo: tipovehiculo,
                diaAtencion: diaatencion,
                precioDesde: preciodesde,
                precioHasta: preciohasta,
                horaDesde: horadesde,
                horaHasta: horahasta
            }
        }).success(function (response) {

            $scope.cargarPlayas(response);//cargar playas resultantes de los filtros en el mapa
            $scope.cargarPlayasGrilla(response);//cargar playas resultantes en la grilla            

        }).error(function (data, status, headers, config) {
            alert('ERROR ' + data.status + ' ' + data.statusText, 'Error');
        });
    }

    /*AGREGAR MARCADORES DE LAS PLAYAS DE LA CIUDAD BUSCADA EN EL INDEX [mantenida en session]*/
    $scope.getPlayas = function () {

        $http({
            url: "BusquedaPlaya.aspx/ObtenerPlayasDeCiudad",//mi pagina de begin
            method: "POST",
            data: $.param({})
        }).success(function (response) {

            $scope.playasGrilla = [];//vacio las playas a mostrar en la grila            

            $scope.cargarPlayas(response);//carga las playas en el mapa

            $scope.cargarPlayasGrilla(response);//carga las playas en la grilla               

        }).error(function (data, status, headers, config) {
            alert('ERROR ' + result.status + ' ' + result.statusText, 'Error');
        });
    }

    /*LIMPIAR MAPA*/
    $scope.limpiarMapa = function () {
        $scope.clearCirculos();
        $scope.clearMarcadorCirculo();

        //ubica el mapa en la ciudad
        var address = $scope.ciudad + ", Argentina";
        $scope.geocoder.geocode({ 'address': address }, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                $scope.map.setCenter(results[0].geometry.location);
                $scope.map.setZoom(12);
            } else {
                alert("La ciudad no ha podido encontrarse")
            }
        });
    }

    /*INICIALIZA EL MAPA AL CARGAR LA PAGINA*/
    $scope.inicializarMapa = function () {

        var input = (document.getElementById('txtBuscar'));
        var options = {
            types: ['(cities)'],
            componentRestrictions: { country: 'ar' }
        };
        var autocomplete = new google.maps.places.Autocomplete(input,
        options);        

        $scope.buscarCiudadSesion();//ciudad en session
        $scope.geocoder = new google.maps.Geocoder();//busqueda de direccion

        //opciones basicas del mapa
        $scope.mapOptions = {
            zoom: 12,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };

        $scope.map = new google.maps.Map(document.getElementById('map-canvas'), $scope.mapOptions);//instancia el mapa
        google.maps.event.addListener($scope.map, 'click', function (event) { $scope.dibujarPunto(event); });//evento de dibujar punto (Click)
        $scope.getPlayas();//playas de la ciudad en session
    }

    /*SETEA COMO METODO DE INICIO AL CARGAR LA PAGINA*/
    google.maps.event.addDomListener(window, 'load', $scope.inicializarMapa);

});

app.filter('startFrom', function () {
    return function (input, start) {
        start = +start; //parse to int
        return input.slice(start);
    }
});