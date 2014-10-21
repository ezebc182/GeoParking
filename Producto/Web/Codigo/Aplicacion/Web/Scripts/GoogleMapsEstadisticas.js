//mapas de la pagina
var maps = new Array;
//array de marcadores
var markers = new Array();
//array de datos
var pointArray = new Array();
//array de heatmaps
var heatmap = new Array();
//array de los valores de los range
var min = new Array();

function initialize(IdMapa) {

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

    //Se agrega un array de marcadores para usar con el mapa actual, un array de puntos, y uno de heatmaps
    if (markers.length !== IdMapa - 1) {
        markers.push(new Array());
        pointArray.push(new Array());
        heatmap.push(new Array());
    }

    calcularIdHM(IdMapa);
    //recuperamos las playas de la ciudad
    getPlayas(IdMapa, IdHM);
}

//AGREGAR MARCADORES DE LAS PLAYAS DE LA CIUDAD BUSCADA EN EL INDEX
function getPlayas(IdMapa, IdHM) {

    //peticionAjax
    $.ajax({
        type: "POST",
        url: "DensidadConsultasPorFechas.aspx/ObtenerPlayasDeCiudad",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var playasArray = (typeof response.d) == 'string' ?
                           eval('(' + response.d + ')') :
                           response.d;

            var playas = new Array();

            for (i = 0; i < playasArray.length; i++) {

                playas.push(new google.maps.LatLng(playasArray[i].Latitud, playasArray[i].Longitud));
            }
            markers[IdMapa][IdHM] = playas;
            cargarHeatMap(IdMapa, IdHM);
        },
        error: function (result) {
            Alerta_openModalError('ERROR ' + result.status + ' ' + result.statusText, 'Error');
        }
    });
}
function cargarHeatMap(IdMapa, IdHM) {

    pointArray[IdMapa][IdHM] = new google.maps.MVCArray(markers[IdMapa][IdHM]);

    heatmap[IdMapa][IdHM] = new google.maps.visualization.HeatmapLayer({
        data: pointArray[IdMapa][IdHM],
        map: maps[IdMapa]
    });
}
function calcularIdHM(IdMapa) {
    //Se setea el mes elegido del mapa
    ano = $('[id*=txtMes-' + IdMapa + ']').val();
    min[IdMapa] = $('[id*=txtMes-' + IdMapa + ']').attr('min');
    IdHM = ano - min
}

function toggleHeatmap(IdMapa) {
    calcularIdHM(IdMapa);
    heatmap[IdMapa][IdHM].setMap(heatmap[Id][IdHM].getMap() ? null : maps[IdMapa]);
}