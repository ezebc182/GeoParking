//aplicacion angular con modulo de ng-grid
var app = angular.module('myApp', ['ngGrid']);

//controlador de la aplicacion (busqueda playa)
app.controller('MyCtrl', function ($scope, $http) {

    $scope.map;//mapa
    $scope.markers = [];//marcadores   
    $scope.circulos = [];//circulos    
    $scope.marcadorCirculo = [];//marcadores de circulos    
    var contenido = "";//contenido infowindow de marcador   
    var infowindow = new google.maps.InfoWindow({ content: '' });//infowindow vacio

    //playas de la BD de la ciudad buscada
    $scope.playasBD = [];

    $scope.mostrarGrilla = false;

    //opciones de la grilla
    $scope.filterOptions = {
        filterText: ''
        // useExternalFilter: true
    };
    $scope.totalServerItems = 0;
    $scope.pagingOptions = {
        pageSizes: [5, 10, 20],
        pageSize: 5,
        currentPage: 1
    };

    /*seteo de la paginacion por cambio de pagina*/
    $scope.setPagingData = function (data, page, pageSize) {
        var pagedData = data.slice((page - 1) * pageSize, page * pageSize);
        $scope.myData = pagedData;
        $scope.totalServerItems = data.length;
        if (!$scope.$$phase) {
            $scope.$apply();
        }
    };

    /*sincronizacion con los datos*/
    $scope.getPagedDataAsync = function (pageSize, page, searchText) {
        setTimeout(function () {
            var data;
            if (searchText) {
                var ft = searchText.toLowerCase();
                $http({
                    url: "reclamos.php",//mi pagina de begin
                    method: "POST",
                    headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                    data: $.param({
                        ciudad: $scope.ciudad //ciudad guardada en el modelo (textbox)
                    })
                }).success(function (largeLoad, status, headers, config) {
                    datos = eval(JSON.stringify(largeLoad));

                    data = datos.filter(function (item) {
                        return JSON.stringify(item).toLowerCase().indexOf(ft) != -1;
                    });
                    $scope.setPagingData(data, page, pageSize);
                }).error(function (data, status, headers, config) {
                    alert(status);
                });

            }
            else {

                datos = [{ 'id': "1", 'nombre': "Playa Patio Olmos", 'tipoPlaya': "techada", 'direccion': "Bv San Juan 298", 'vehiculos': "Autos y motos", 'precios': "$9" },
                            { 'id': "2", 'nombre': "Playa Verde", 'tipoPlaya': "descubierta", 'direccion': "Bv San Juan 298", 'vehiculos': "Autos, motos y bicis", 'precios': "$12" },
                            { 'id': "3", 'nombre': "Playa Dean Funes", 'tipoPlaya': "techada", 'direccion': "Bv San Juan 298", 'vehiculos': "Autos y motos", 'precios': "$19" },
                            { 'id': "4", 'nombre': "Estrada Panking", 'tipoPlaya': "descubierta", 'direccion': "Bv San Juan 298", 'vehiculos': "Autos", 'precios': "$14" },
                            { 'id': "5", 'nombre': "Playa Bolivar", 'tipoPlaya': "techada", 'direccion': "Bv San Juan 298", 'vehiculos': "Autos", 'precios': "$16" },
                            { 'id': "6", 'nombre': "Playa Mitre", 'tipoPlaya': "subterranea", 'direccion': "Bv San Juan 298", 'vehiculos': "Autos y motos", 'precios': "$14" },
                            { 'id': "7", 'nombre': "Playa Azul", 'tipoPlaya': "techada", 'direccion': "Bv San Juan 298", 'vehiculos': "Autos, motos y bicis", 'precios': "$23" }];
                $scope.setPagingData(datos, page, pageSize);

                $http({
                    url: "reclamos.php",//mi pagina de begin
                    method: "POST",
                    headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                    data: $.param({
                        ciudad: $scope.ciudad //ciudad guardada en el modelo (textbox)
                    })
                }).success(function (largeLoad, status, headers, config) {

                    datos = eval(JSON.stringify(largeLoad));
                    $scope.setPagingData(datos, page, pageSize);

                }).error(function (data, status, headers, config) {
                    alert(status);
                });
            }
        }, 100);
    };

    //sincronizacion al inicio de la aplicacion
    //$scope.getPagedDataAsync($scope.pagingOptions.pageSize, $scope.pagingOptions.currentPage);

    //escucha de los cambios de paginacion
    $scope.$watch('pagingOptions', function (newVal, oldVal) {
        if (newVal !== oldVal && newVal.currentPage !== oldVal.currentPage) {
            $scope.getPagedDataAsync($scope.pagingOptions.pageSize, $scope.pagingOptions.currentPage, $scope.filterOptions.filterText);
        }
    }, true);

    //escucha de los cambios en los filtros
    $scope.$watch('filterOptions', function (newVal, oldVal) {
        if (newVal !== oldVal) {
            $scope.getPagedDataAsync($scope.pagingOptions.pageSize, $scope.pagingOptions.currentPage, $scope.filterOptions.filterText);
        }
    }, true);

    //boton para ir a la playa en el mapa
    $scope.btnOption = '<div style="text-align:center;"><button id="editBtn" type="button" ng-click="ir(row)"><span class="glyphicon glyphicon-search"></span></span></button></div>';

    //opciones de la grilla
    $scope.gridOptions = {
        data: 'myData',
        enablePaging: true,
        showFooter: true,
        totalServerItems: 'totalServerItems',
        pagingOptions: $scope.pagingOptions,
        filterOptions: $scope.filterOptions,
        showGroupPanel: true,
        enableFiltering: true,
        multiSelect: false,
        columnDefs://definir las columnas a tener en la grilla
        [
        { field: 'Id', displayName: 'Id', width: "30px"},
        { field: 'Nombre', displayName: 'Nombre', width: "200px" },
        { field: 'TipoPlaya', displayName: 'Tipo Playa', width:"100px" },
        { field: 'Direccion', displayName: 'Direccion' },
        { field: 'Vehiculos', displayName: 'Vehiculos', width: "200px" },
        { field: 'Precios', displayName: 'Precios' },
        { displayName: "Ver", cellTemplate: $scope.btnOption, width: "50px" }

        ]

    };

    /*permite mostrar la playa seleccionada en el mapa*/
    $scope.ir = function (row) {

        //entidad seleccionada
        var playa = row.entity;

        alert("voy a playa de estacionamiento")
    };


    /*Muestra la grilla o la esconde si esta activa*/
    $scope.listar = function () {
        if ($scope.mostrarGrilla == false) {
            $scope.mostrarGrilla = true;
            $("#btnListado").html("Ver Mapa")
        }
        else {
            $scope.mostrarGrilla = false;
            $("#btnListado").html("Ver Listado")
        }
    }

    /*BUSCO LAS PLAYAS DE LA NUEVA CIUDAD*/
    $scope.buscarPlayasCiudad = function () {        

        //borramos marcadores y circulos
        $scope.deleteMarkers();
        $scope.deleteCirculos();

        //tomo el valor de la nueva ciudad
        var ciudadNueva = $scope.ciudad;

        $http({
            url: "BusquedaPlaya.aspx/ObtenerPlayasDeCiudadNueva",//mi pagina de begin
            method: "POST",
            headers: { 'Content-Type': 'application/json' },  // agregar a para webmethod con parametros
            data: { ciudad: ciudadNueva }            
        }).success(function (response) {        

            //toma la direccion y la busca
            var address = ciudadNueva + ", Argentina";
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

    /*FILTRO LAS PLAYAS*/
    $scope.filtrar = function () {
        alert("aca realizo el filtrado de las playas")

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
            data: {tipoPlaya: tipoplaya,
                tipoVehiculo: tipovehiculo,
                diaAtencion: diaatencion,
                precioDesde: preciodesde, 
                precioHasta: preciohasta, 
                horaDesde: horadesde, 
                horaHasta: horahasta }
        }).success(function (response) {

            $scope.cargarPlayas(response);//cargar playas resultantes de los filtros en el mapa
            $scope.cargarPlayasGrila(response);//cargar playas resultantes en la grilla

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

            $scope.ciudad = response.d;//ciudad en la session

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
        var playas = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;

        if (playas.length > 0) {
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
                contenido += "<table>";
                var direcciones = eval(playas[i].Direcciones);
                for (var j = 0; j < direcciones.length; j++) {
                    contenido += "<tr><td> <strong>Calle:</strong>  </td> <td>" + direcciones[j].Calle + ":  </td> <td> <strong> N° </strong>: </td> <td>" + direcciones[j].Numero + " </td> </tr>";
                }
                contenido += "</table>";

                //agregamos los servicios
                contenido += "<div><h6>SERVICIOS<h6></div>";
                contenido += "<table>";
                var servicios = eval(playas[i].Servicios);
                for (var K = 0; K < servicios.length; K++) {
                    contenido += "<tr><td> <strong>Tipo Vehiculo:</strong> </td> <td>" + servicios[K].TipoVehiculo + ":  </td> <td> <strong> Capacidad: </strong> </td> <td>" + servicios[K].Capacidad + " </td> </tr>";
                }
                contenido += "</table>";
                contenido += "</p></div>";

                //SEGUNDO TAB
                contenido += "<div class='tab-pane' id='panel-2'>" +
                "<p>";

                //agregamos los horarios
                contenido += "<div><h6>HORARIOS<h6></div>";
                contenido += "<table>";
                var horarios = eval(playas[i].Horarios);
                for (var l = 0; l < horarios.length; l++) {
                    contenido += "<tr><td>" + horarios[l].Dia + "</td> <td> - <strong>Desde:</strong></td> <td> " + horarios[l].HoraDesde + "</td> <td> - <strong>Hasta:</strong> </td> <td>" + horarios[l].HoraHasta + "</td> </tr>";
                }
                contenido += "</table>";
                contenido += "</p></div>";

                //TERCER TAB
                contenido += "<div class='tab-pane' id='panel-3'>" +
                "<p>";

                //agregamos los precios
                contenido += "<div><h6>PRECIOS<h6></div>";
                contenido += "<table>";
                var precios = eval(playas[i].Precios);
                for (var m = 0; m < precios.length; m++) {
                    //contenido += "<div>" + precios[m].TipoVehiculo + " - " + precios[m].Dia + " - " + precios[m].Tiempo + " $" + precios[m].Monto + "</div>";
                    contenido += "<tr><td>" + precios[m].TipoVehiculo + "</td> <td> - " + precios[m].Tiempo + ":</td> <td> $" + precios[m].Monto + "</td> </tr>";
                }
                contenido += "</table>"
                contenido += "</p></div>";

                contenido += "</div></div>";

                //creamos el marcador                      
                var marker = new google.maps.Marker({
                    position: new google.maps.LatLng(playas[i].Latitud, playas[i].Longitud),
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
        else Alerta_openModalInfo('No se han encontrado playas con los filtros seleccionados.', 'Resultado de la Busqueda')
    }

    /*CARGA LAS PLAYAS EN LA GRILLA*/
    $scope.cargarPlayasGrilla = function (response) {

        //vacio la variable
        $scope.playasBD = [];

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
                var precios = eval(playas[i].Precios);
                for (var m = 0; m < precios.length; m++) {
                    Precios += precios[m].TipoVehiculo + " - " + precios[m].Tiempo + ": $" + precios[m].Monto + "\n";
                }

                $scope.playasBD.push({ Id: Id, Nombre: Nombre, TipoPlaya: TipoPlaya, Direccion: Direccion, Vehiculos: Vehiculos, Precios: Precios });


            }
        }        
        
        $scope.setPagingData($scope.playasBD, $scope.pagingOptions.currentPage, $scope.pagingOptions.pageSize);
    }

    /*AGREGAR MARCADORES DE LAS PLAYAS DE LA CIUDAD BUSCADA EN EL INDEX [mantenida en session]*/
    $scope.getPlayas = function () {

        $http({
            url: "BusquedaPlaya.aspx/ObtenerPlayasDeCiudad",//mi pagina de begin
            method: "POST",
            data: $.param({})
        }).success(function (response) {

            $scope.cargarPlayas(response);//carga las playas en el mapa

            $scope.cargarPlayasGrilla(response);//carga las playas en la grilla               

        }).error(function (data, status, headers, config) {
            alert('ERROR ' + result.status + ' ' + result.statusText, 'Error');
        });
    }

    /*LIMPIAR MAPA*/
    $scope.limpiarMapa = function() {
        $scope.clearCirculos();
        $scope.clearMarcadorCirculo();
    }

    /*INICIALIZA EL MAPA AL CARGAR LA PAGINA*/
    $scope.inicializarMapa = function () {
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
    //inicializacion de la pagina (en duda por si no funciona la linea anterior)
    //$scope.inicializarMapa();




});