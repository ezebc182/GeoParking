//mapas de la pagina
var maps = new Array;
//array de marcadores
var markers = new Array();
//array de datos
var pointArray = new Array();
//array de heatmaps
var heatmap = new Array();
//array de cantidad tipo de playas
var cantTipoPlaya = new Array();
//array de cantidad tipo de vehiculos
var cantTipoVehiculo = new Array();
//array de los valores de los range
var min = new Array();
var max = new Array();
//año seleccionado en el txt range
var ano;
var IdHM = 0;
var IdHMAnt = 0;

function initialize(IdMapa) {

    //Se agrega un array de marcadores para usar con el mapa actual, un array de puntos, y uno de heatmaps
    if (markers.length !== IdMapa - 1) {
        markers.push(new Array());
        pointArray.push(new Array());
        heatmap.push(new Array());
        cantTipoPlaya.push(new Array());
        cantTipoVehiculo.push(new Array());
    }
    calcularIdHM(IdMapa);

    cargarConsultasPorTipoPlaya(IdMapa);
    cargarConsultasPorTipoVehiculo(IdMapa);
    cargarConsultas(IdMapa);
};
function cargarConsultasPorTipoPlaya(IdMapa) {

    var fechaDesde = $('[id=fechaDesde]').val();
    var fechaHasta = $('[id=fechaHasta]').val();

    //peticionAjax
    $.ajax({
        type: "POST",
        url: "Estadisticas.aspx/ObtenerCantidadConsultasDeCiudadPorTipoPlaya",
        data: "{'ciudadNombre': 'Cordoba', 'desde': '" + fechaDesde + "','hasta': '" + fechaHasta + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var consultasArray = (typeof response.d) == 'string' ?
                           eval('(' + response.d + ')') :
                           response.d;



            //Cargar por año
            for (i = 0; i <= max[IdMapa] - min[IdMapa]; i++) {
                var consultas = new Array();
                var consultasArrayAno = new Array();
                //Consultas por año
                for (var j = 0; j < consultasArray.length; j++) {

                    if (consultasArray[j].Fecha == parseInt(min[IdMapa], 10) + i) {
                        consultasArrayAno.push(consultasArray[j]);
                    }
                }

                for (j = 0; j < consultasArrayAno.length; j++) {
                    if (consultasArrayAno[j] !== undefined) {
                        consultas.push({ label: consultasArrayAno[j].Nombre, value: consultasArrayAno[j].Cantidad });
                    }
                }
                cantTipoPlaya[IdMapa][i] = consultas;
            }
            cargarGraficoCantidadTipoPlayas(IdMapa);
        },
        error: function (result) {
            Alerta_openModalError('ERROR ' + result.status + ' ' + result.statusText, 'Error');
        }

    });
}
function cargarConsultasPorTipoVehiculo(IdMapa) {

    var fechaDesde = $('[id=fechaDesde]').val();
    var fechaHasta = $('[id=fechaHasta]').val();

    //peticionAjax
    $.ajax({
        type: "POST",
        url: "Estadisticas.aspx/ObtenerCantidadConsultasDeCiudadPorTipoVehiculo",
        data: "{'ciudadNombre': 'Cordoba', 'desde': '" + fechaDesde + "','hasta': '" + fechaHasta + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var consultasArray = (typeof response.d) == 'string' ?
                           eval('(' + response.d + ')') :
                           response.d;



            //Cargar por año
            for (i = 0; i <= max[IdMapa] - min[IdMapa]; i++) {
                var consultas = new Array();
                var consultasArrayAno = new Array();
                //Consultas por año
                for (var j = 0; j < consultasArray.length; j++) {

                    if (consultasArray[j].Fecha == parseInt(min[IdMapa], 10) + i) {
                        consultasArrayAno.push(consultasArray[j]);
                    }
                }

                for (j = 0; j < consultasArrayAno.length; j++) {
                    if (consultasArrayAno[j] !== undefined) {
                        consultas.push({ label: consultasArrayAno[j].Nombre, value: consultasArrayAno[j].Cantidad });
                    }
                }
                cantTipoVehiculo[IdMapa][i] = consultas;
                
            }
            cargarGraficoCantidadTipoVehiculos(IdMapa);
        },
        error: function (result) {
            Alerta_openModalError('ERROR ' + result.status + ' ' + result.statusText, 'Error');
        }

    });
}

function cargarGraficoCantidadTipoPlayas(IdMapa) {
    Morris.Donut({
        element: 'consultasTipoPlaya-' + IdMapa,
        data: cantTipoPlaya[IdMapa][IdHM]
    });
};
function cargarGraficoCantidadTipoVehiculos(IdMapa) {
    Morris.Bar({
        element: 'consultasTipoVehiculo-' + IdMapa,
        data: cantTipoVehiculo[IdMapa][IdHM],
        xkey: 'label',
        ykeys: ['value'],
        labels: ['Consultas']
    });
};

function cargarConsultas(IdMapa) {

    //variable para la busqueda con una direccion
    geocoder = new google.maps.Geocoder();

    //centrar el mapa en la plaza San Martin
    var puntoPlaza = new google.maps.LatLng(-31.416756, -64.183501);

    //opciones basicas del mapa
    var mapOptions = {
        zoom: 12,
        center: puntoPlaza,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };

    //crea el mapa en el div "map-canvas" y le setea las opciones
    maps.push(new google.maps.Map(document.getElementById('map-' + IdMapa),
        mapOptions));


    //recuperamos las consultas de la ciudad
    getConsultas(IdMapa, IdHM);
}

//AGREGAR MARCADORES DE LAS consultas DE LA CIUDAD BUSCADA EN EL INDEX
function getConsultas(IdMapa, IdHM) {

    var fechaDesde = $('[id=fechaDesde]').val();
    var fechaHasta = $('[id=fechaHasta]').val();

    //peticionAjax
    $.ajax({
        type: "POST",
        url: "Estadisticas.aspx/ObtenerConsultasDeCiudad",
        data: "{'ciudadNombre': 'Cordoba', 'desde': '" + fechaDesde + "','hasta': '" + fechaHasta + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var consultasArray = (typeof response.d) == 'string' ?
                           eval('(' + response.d + ')') :
                           response.d;



            //Cargar por año
            for (i = 0; i <= max[IdMapa] - min[IdMapa]; i++) {
                var consultas = new Array();
                var consultasArrayAno = new Array();
                //Consultas por año
                for (var j = 0; j < consultasArray.length; j++) {

                    var date = new Date(consultasArray[j].Hora);
                    if (date.getUTCFullYear() == parseInt(min[IdMapa], 10) + i) {
                        consultasArrayAno.push(consultasArray[j]);
                    }

                }

                for (j = 0; j < consultasArrayAno.length; j++) {
                    if (consultasArrayAno[j] !== undefined) {
                        consultas.push(new google.maps.LatLng(consultasArrayAno[j].Latitud, consultasArrayAno[j].Longitud));
                    }
                }
                markers[IdMapa][i] = consultas;
                cargarHeatMap(IdMapa, i);
            }
            heatmap[IdMapa][IdHM].setMap(heatmap[IdMapa][IdHM].getMap() ? null : maps[IdMapa]);
            cambiarCantidadConsultas(IdMapa);
        },
        error: function (result) {
            Alerta_openModalError('ERROR ' + result.status + ' ' + result.statusText, 'Error');
        }
    });
}
function cargarHeatMap(IdMapa, i) {

    pointArray[IdMapa][i] = new google.maps.MVCArray(markers[IdMapa][i]);

    heatmap[IdMapa][i] = new google.maps.visualization.HeatmapLayer({
        data: pointArray[IdMapa][i]
    });
}
function calcularIdHM(IdMapa) {
    //se guarda el indice anterior
    IdHMAnt = IdHM;
    //Se setea el mes elegido del mapa
    ano = $('[id*=txtMes-' + IdMapa + ']').val();
    min[IdMapa] = $('[id*=txtMes-' + IdMapa + ']').attr('min');
    max[IdMapa] = $('[id*=txtMes-' + IdMapa + ']').attr('max');
    IdHM = ano - min[IdMapa]
};

function toggleHeatmap(IdMapa) {
    heatmap[IdMapa][IdHM].setMap(heatmap[IdMapa][IdHM].getMap() ? null : maps[IdMapa]);
    heatmap[IdMapa][IdHMAnt].setMap(null);
};

function cambiarRange(IdMapa) {
    calcularIdHM(IdMapa);
    cambiarAno(IdMapa);
    cambiarCantidadConsultas(IdMapa);
    toggleHeatmap(IdMapa);
    cargarGraficoCantidadTipoPlayas(IdMapa, IdHM);
    cargarGraficoCantidadTipoVehiculos(IdMapa, IdHM);
};

function cambiarAno(IdMapa) {
    $('#anuales-'+IdMapa + ' [id=txtAno]').val(ano);
};
function cambiarCantidadConsultas(IdMapa){
    $('#anuales-'+IdMapa + ' [id=txtConsultas]').val(markers[IdMapa][IdHM].length)
};