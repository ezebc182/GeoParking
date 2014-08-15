<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BusquedaPlaya.aspx.cs" Inherits="Web.BusquedaPlaya" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="./Styles/BusquedaPlaya.css" type="text/css">

    <!--Estilos del Mapa-->
    <style>



      body{        
        text-align: center;
        margin: 0px;
        padding: 0px;
        
      }

      .todo
      {
        text-align: center;
      }

      #map-canvas {
        width: 900px;
        height: 500px;
        text-align: center;
        border:5px;
        border-radius: 5px;
        border-color: blue;
        border-style: groove;
      }


      #panel {
        position: absolute;
        top: 5px;
        left: 50%;
        margin-left: -180px;
        z-index: 5;
        background-color: #fff;
        padding: 5px;
        border: 1px solid #999;
      }
    </style>

    <!--Script de google mas-->
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>

    <!--Scripts de ajax-->
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.microsoft.com/ajax/jquery/jquery-1.3.2.min.js" type="text/javascript"></script>

    <script src="//code.jquery.com/jquery-1.11.0.min.js"></script>
    <script src="//code.jquery.com/jquery-migrate-1.2.1.min.js"></script>

    <!--variables globales-->
    <script>

        var map;
        var markers = [];
        var circulos = [];

        //contenido del windows
        var contenido = "";
        //variable infoWindows
        var infowindow = new google.maps.InfoWindow({
            content: ''
        });


    </script>

    <!--Scrpit fr google maps-->
    <script>

        markers = [];
        circulos = [];

        function initialize() {

            geocoder = new google.maps.Geocoder();//AGREGAR ESTA VARIABLE

            var haightAshbury = new google.maps.LatLng(-31.416756, -64.183501);
            var mapOptions = {
                zoom: 15,
                center: haightAshbury,
                mapTypeId: google.maps.MapTypeId.SATELLITE
            };
            map = new google.maps.Map(document.getElementById('map-canvas'),
                mapOptions);

            google.maps.event.addListener(map, 'click', function (event) {

                deleteCirculos();

                var populationOptions = {
                    strokeColor: '#FF0000',
                    strokeOpacity: 0.9,
                    strokeWeight: 2,
                    fillColor: '#FF0000',
                    fillOpacity: 0.1,
                    map: map,
                    center: event.latLng,
                    editable: true,
                    radius: 1000
                };

                map.setCenter(event.latLng);

                // Add the circle for this city to the map.
                puntoInteres = new google.maps.Circle(populationOptions);

                circulos.push(puntoInteres);
            });

            getPlayas();
        }

        //AGREGAR TODO ESTE METODO
        function marcarPunto() {


            deleteCirculos();

            var address = document.getElementById('txtCalle').value + " " + document.getElementById('txtNumero').value + "," + document.getElementById('txtBuscar').value ;
            geocoder.geocode({ 'address': address }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    map.setCenter(results[0].geometry.location);


                    var populationOptions = {
                        strokeColor: '#FF0000',
                        strokeOpacity: 0.9,
                        strokeWeight: 2,
                        fillColor: '#FF0000',
                        fillOpacity: 0.1,
                        map: map,
                        center: results[0].geometry.location,
                        editable: true,
                        radius: 1000
                    };

                    // Add the circle for this city to the map.
                    puntoInteres = new google.maps.Circle(populationOptions);

                    circulos.push(puntoInteres);

                } else {
                    alert('La direccion establecida no ha podido encontrarse');
                }
            });


        }

        // Add a marker to the map and push to the array.
        function addMarker(location) {
            var marker = new google.maps.Marker({
                position: location,
                map: map
            });

            //ACA AGREGAMOS LA INFORMACION DEL CONTENIDO DEL WINDOWS
            google.maps.event.addListener(marker, 'click', function () {
                infowindow.setContent(contenido);//seteamos el contenido
                infowindow.open(map, marker);//seteamos el evento para el infowindows
            });

            markers.push(marker);


        }

        // Sets the map on all markers in the array.
        function setAllMap(map) {
            for (var i = 0; i < markers.length; i++) {
                markers[i].setMap(map);
            }
        }

        function setAllMapCirculos(map) {
            for (var i = 0; i < circulos.length; i++) {
                circulos[i].setMap(map);
            }
        }

        // Removes the markers from the map, but keeps them in the array.
        function clearMarkers() {
            setAllMap(null);
        }

        function clearCirculos() {
            setAllMapCirculos(null);
        }

        // Shows any markers currently in the array.
        function showMarkers() {
            setAllMap(map);
        }

        // Deletes all markers in the array by removing references to them.
        function deleteMarkers() {
            clearMarkers();
            markers = [];
        }

        function deleteCirculos() {
            clearCirculos();
            circulos = [];
        }

        google.maps.event.addDomListener(window, 'load', initialize);

    </script>

    <!--Agregar marcadores de playas-->
    <script type = "text/javascript">    
        function getPlayas() {
            $.ajax({
                type: "POST",
                url: "BusquedaPlaya.aspx/ObtenerPlayasDeCiudad",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                                       
                    var playas = (typeof response.d) == 'string' ?
                                       eval('(' + response.d + ')') :
                                       response.d;
                                        
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
                            contenido += "<div>Tipo Vehiculo: " + precios[m].Vehiculo + " - Dia: " + precios[m].Dia + " - Tiempo: " + precios[m].Tiempo + " - Monto: " + precios[m].Monto + "</div>";
                        }
                        

                        //addMarker(new google.maps.LatLng(playas[i].x, playas[i].y));
                        var contenid = contenido;
                        var marker = new google.maps.Marker({
                            position: new google.maps.LatLng(playas[i].Latitud, playas[i].Longitud),
                            map: map
                        });

                        (function (marker, contenid) {
                            google.maps.event.addListener(marker, 'click', function () {
                                infowindow.setContent(contenid);
                                infowindow.open(map, marker);
                            });
                        })(marker, contenido);

                        markers.push(marker);

                    }
                },
                error: function (result) {
                    alert('ERROR ' + result.status + ' ' + result.statusText);
                }
            });
        }
    </script> 

    <!--Agregar Marcadores de playas segun filtros-->
    <script>            
            
            $(function () {
                $('#btnBuscar').click(function () {

                    deleteMarkers();                  

                    alert('comenzando funcion ajax de filtrado');

                    //tomo los valores de los filtros
                    var tipoplaya = document.getElementById('ddlTipoPlaya').value;
                    var tipovehiculo = document.getElementById('ddlTipoVehiculo').value;
                    var diaatencion = document.getElementById('ddlDiasAtencion').value;
                    var preciodesde = document.getElementById('txtMinPrecio').value;
                    var preciohasta = document.getElementById('txtMaxPrecio').value;
                    var horadesde = document.getElementById('ddlHoraDesde').value;
                    var horahasta = document.getElementById('ddlHoraHasta').value;

                    //verifico los valores
                    alert(tipoplaya + " - " + tipovehiculo + " - " + diaatencion + " - " + preciodesde + " - " + preciohasta + " - " + horadesde + " - " + horahasta);
                        
                    $.ajax({
                        type: "POST",
                        url: "BusquedaPlaya.aspx/ObtenerPlayasDeCiudadPorFiltro",
                        data: '{tipoPlaya:' + tipoplaya + ' , tipoVehiculo:' + tipovehiculo + ' , diaAtencion: ' + diaatencion + ', precioDesde:' + preciodesde + ', precioHasta:' + preciohasta + ', horaDesde:' + horadesde + ', horaHasta:' + horahasta +' }',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: resultado,
                        error: errores
                    });

                });
            });

            function resultado(response) {
                //msg.d tiene el resultado devuelto por el método
                alert(response.d);

                
                var playas = (typeof response.d) == 'string' ?
                                       eval('(' + response.d + ')') :
                                       response.d;

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
                        contenido += "<div>Tipo Vehiculo: " + precios[m].Vehiculo + " - Dia: " + precios[m].Dia + " - Tiempo: " + precios[m].Tiempo + " - Monto: " + precios[m].Monto + "</div>";
                    }


                    //addMarker(new google.maps.LatLng(playas[i].x, playas[i].y));
                    var contenid = contenido;
                    var marker = new google.maps.Marker({
                        position: new google.maps.LatLng(playas[i].Latitud, playas[i].Longitud),
                        map: map
                    });

                    (function (marker, contenid) {
                        google.maps.event.addListener(marker, 'click', function () {
                            infowindow.setContent(contenid);
                            infowindow.open(map, marker);
                        });
                    })(marker, contenido);

                    markers.push(marker);

                }
            }
            function errores(response) {
                //msg.responseText tiene el mensaje de error enviado por el servidor
                alert('Error: ' + response.responseText);
            }

        
    </script>

    <!--Marcar el centro de radio con calle y numero-->
    <script>
        $(function () {
            $('#marcarPunto').click(function () {

                marcarPunto();
            });
        });
    </script>

    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <br />
        <br />
        <br />
        <br />
        <!--Cabecera con formulario para buscar en otra ciudad y cambiar el mapa-->
        <div class="col-sm-12 col-md-12 col-lg-12">
            <div class="col-sm-4 col-md-4 col-lg-4">
                <asp:TextBox ID="txtBuscar" CssClass="form-control input-lg" placeholder="Buscar en otra ciudad..." runat="server" ClientIDMode="Static"></asp:TextBox>
            </div>
            <div class="col-sm-2 col-md-2 col-lg-2">
                <input type="button" Class="btn-primary btn btn-lg" value="Buscar" id="btnBuscarPorCiudad" />   
            </div>
            <hr class="col-sm-12 col-md-12 col-lg-12" />
        </div>
        <hr />
        <br />
        <br />
        <br />
        <br />
        <!--Columna con los fitros de la busqueda-->
        <div class="col-sm-3 col-md-3 col-lg-3 control-label">
            <!--Busqueda Avanzada-->
            <h4 class="modal-title">Busqueda Avanzada</h4>
            <br />
            <!--Direccion-->
            <asp:Label ID="lblDireccion" class="col-sm-12 col-md-12 col-lg-12 control-label" runat="server" Text="Calle y altura"></asp:Label>
            <div class="col-sm-8 col-md-8 col-lg-8">
                <asp:TextBox ID="txtCalle" CssClass="form-control" runat="server" ClientIDMode="Static"></asp:TextBox>
            </div>
            <asp:Label ID="separadorDireccion" class="col-sm-1 col-md-1 col-lg-1 control-label" runat="server" Text="-"></asp:Label>
            <div class="col-sm-3 col-md-3 col-lg-3">
                <asp:TextBox ID="txtNumero" CssClass="form-control" runat="server" ClientIDMode="Static"></asp:TextBox>
                <input type="button" Class="btn-primary btn btn-lg" value="IR" id="marcarPunto" />   
            </div>
            <br />
            <!--Tipo de Playa-->
            <asp:Label ID="lblTipoPlaya" runat="server" Text="Tipo de Playa"></asp:Label>
            <div>
                <asp:DropDownList ID="ddlTipoPlaya" CssClass="form-control" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                    <asp:ListItem Value="1">techada</asp:ListItem>
                    <asp:ListItem Value="3">Descubierta</asp:ListItem>
                </asp:DropDownList>
            </div>
            <br />
            <!--Tipo de Vehiculo-->
            <asp:Label ID="lblTipoVehiculo" runat="server" Text="Tipo de Vehiculo"></asp:Label>
            <div>
                <asp:DropDownList ID="ddlTipoVehiculo" CssClass="form-control" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                    <asp:ListItem Value="1">Auto</asp:ListItem>
                    <asp:ListItem Value="2">Moto</asp:ListItem>
                </asp:DropDownList>
            </div>
            <br />
            <!--Rango de Precios-->
            <asp:Label ID="lblPrecio" class="col-sm-12 col-md-12 col-lg-12" runat="server" Text="Precio"></asp:Label>
            <div class="col-sm-5 col-md-5 col-lg-5">
                <asp:TextBox ID="txtMinPrecio" CssClass="form-control" runat="server" ClientIDMode="Static">0</asp:TextBox>
            </div>
            <asp:Label ID="separadorPrecios" class="col-sm-2 col-md-2 col-lg-2 control-label" runat="server" Text="-"></asp:Label>
            <div class="col-sm-5 col-md-5 col-lg-5">
                <asp:TextBox ID="txtMaxPrecio" CssClass="form-control" runat="server" ClientIDMode="Static">0</asp:TextBox>
            </div>
            <br />
            <!--Dias de Atencion-->
            <asp:Label ID="lblDiasDeAtencion" runat="server" Text="Dias de Atencion"></asp:Label>
            <div>
                <asp:DropDownList ID="ddlDiasAtencion" CssClass="form-control" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                    <asp:ListItem Value="1">Lunes-Viernes</asp:ListItem>
                    <asp:ListItem Value="2">Sabado</asp:ListItem>
                </asp:DropDownList>
            </div>
            <br />
            <!--Rango de Horario-->
            <asp:Label ID="lblHorario" class="col-sm-12 col-md-12 col-lg-12" runat="server" Text="Horario"></asp:Label>
            <div class="col-sm-5 col-md-5 col-lg-5">
                <asp:DropDownList ID="ddlHoraDesde" CssClass="form-control" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="0">00:00</asp:ListItem>
                    <asp:ListItem Value="8">08:00</asp:ListItem>
                    <asp:ListItem Value="24">24:00</asp:ListItem>
                </asp:DropDownList>
            </div>
            <asp:Label ID="separadorHoras" class="col-sm-2 col-md-2 col-lg-2" runat="server" Text="-"></asp:Label>
            <div class="col-sm-5 col-md-5 col-lg-5">
                <asp:DropDownList ID="ddlHoraHasta" CssClass="form-control" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="0">0:00</asp:ListItem>
                    <asp:ListItem Value="8">08:00</asp:ListItem>
                    <asp:ListItem Value="23">23:59</asp:ListItem>
                </asp:DropDownList>
            </div>
            <br />
            <!--Buscar-->
            <div>
                <input type="button" Class="btn-primary btn btn-lg" value="Filtrar" id="btnBuscar" />                
            </div>
        </div>
        <div class="col-sm-9 col-md-9 col-lg-9">
            <!--Rectangulo del Mapa-->
            <div id="pnlMapa" class="col-sm-12 col-md-12 col-lg-12">
                <div id="map-canvas"></div>
                <asp:TextBox runat="server" CssClass="form-control col-sm-5 col-md-5 col-lg-5 required hidden" ID="txtLatitud" ClientIDMode="Static" />
                <asp:TextBox runat="server" CssClass="form-control col-sm-5 col-md-5 col-lg-5 required hidden" ID="txtLongitud" ClientIDMode="Static" />
            </div>
            <!--Rectangulo de la Grilla-->
            <div>
                <asp:GridView ID="gvPlayas" runat="server"></asp:GridView>
            </div>
        </div>

    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="helpContent" runat="server">
</asp:Content>
