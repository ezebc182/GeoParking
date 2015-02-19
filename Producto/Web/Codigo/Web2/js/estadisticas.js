var publicado = 1;// Cambiar a 1 para publicado, 0 para local!!

var tiposVehiculos = new Array();
var tiposPlayas = new Array();
var zonas = new Array();
var playas = new Array();

function configurarCamposPorGrafico($div, valor) {
    if (valor == 1) {
        $div.prev().find('#ddlEscala').parent().parent().hide();
    }
    else {
        $div.prev().find('#ddlEscala').parent().parent().show();
    }
}
function cargarFiltros(div, datos) {
    var tiposVehiculosAux = new Object();
    var tiposPlayasAux = new Object();
    var zonasAux = new Object();
    var playasAux = new Object();

    $.each(datos, function (i, item) {
        if (zonasAux[item.ZonaId] == undefined) { zonasAux[item.ZonaId] = item.ZonaNombre }
        if (playasAux[item.PlayaId] == undefined) { playasAux[item.PlayaId] = item.PlayaNombre }
        if (tiposPlayasAux[item.TipoPlayaId] == undefined) { tiposPlayasAux[item.TipoPlayaId] = item.TipoPlayaNombre }
        if (tiposVehiculosAux[item.TipoVehiculoId] == undefined) { tiposVehiculosAux[item.TipoVehiculoId] = item.TipoVehiculoNombre }
    });


    $.each(tiposVehiculosAux, function (i, item) {
        tiposVehiculos.push({ id: i, text: item });
    })
    $.each(tiposPlayasAux, function (i, item) {
        tiposPlayas.push({ id: i, text: item });
    })
    $.each(zonasAux, function (i, item) {
        zonas.push({ id: i, text: item });
    })
    $.each(playasAux, function (i, item) {
        playas.push({ id: i, text: item });
    })

    $(div).find('#ddlTipoVehiculo').select2({
        placeholder: "Todos",
        data: tiposVehiculos
    });

    $(div).find('#ddlTipoPlaya').select2({
        placeholder: "Todos",
        data: tiposPlayas
    });

    $(div).find('#ddlZonas').select2({
        placeholder: "Todas",
        data: zonas
    });
    $(div).find('#ddlPlayas').select2({
        placeholder: "Todas",
        data: playas
    });

};

var estadisticas = new Array();
$('#btnNuevaEstadisticaTiempoReal').off('click').on('click', function () {
    nuevaEstadistica(2);
});

$('#btnNuevaEstadisticaHistorica').off('click').on('click', function () {
    nuevaEstadistica(1);



});

function nuevaEstadistica(tipoEstadistica) {
    
    var divEstadisticaHistorica = ' <div class="panel panel-default">                <div class="panel-heading">                    <div class="row">                        <div class="col-lg-3"style="margin-left:-30px;">                            <div class="col-lg-6">                                <label class="control-label pull-right">Estadistica:</label>                            </div>                            <div class="col-lg-6">                                <select id="ddlEstadistica">                                    <option value="1">Disponibilidad</option>                                    <option value="2">Consultas</option>                                </select>                            </div>                        </div>                        <div class="col-lg-2">                            <div class="col-lg-4">                                <label class="control-label pull-right">Por: </label>                            </div>                            <div class="col-lg-8">                                <select id="ddlBuscarPor">                                    <option value="1">Playa</option>                                    <option value="2">Zona</option>                                </select>                            </div>                        </div>                        <div class="col-lg-3">                            <div class="col-lg-3">                                <label class="control-label">Desde:</label>                            </div>                            <div class="col-lg-9 pul-left">                                <div id="fechaDesde" class="bfh-datepicker" data-placeholder="Fecha Desde" data-min="01/15/2013" data-format="d-m-y" data-max="today"></div>                            </div>                        </div>                        <div class="col-lg-3">                            <div class="col-lg-3">                                <label class="control-label">Hasta:</label>                            </div>                            <div class="col-lg-9 pull-left">                                <div id="fechaHasta" class="bfh-datepicker" data-placeholder="Fecha Hasta" data-min="01/15/2013" data-format="d-m-y" data-max="today"></div>                            </div>                        </div>                        <div class="">                            <div class="pull-left">                                <button id="btnBuscarEstadisticas" class="btn btn-success" type="button"><span class="fa fa-search">Buscar</span></button>                            </div>                            <div class="pull-right"><i id="minMax" class="fa fa-square-o fa-lg" style="margin-right:10px;"></i></div>                        </div>                    </div>                </div>                <div class="panel-body" style="display: none;">                    <div id="divFiltros" class="col-lg-4">                        <div class="form-group col-lg-12">                            <input id="chkZonas" type="checkbox" />                            <label class="form-label" for="ddlZonas">Zonas: </label>                            <select id="ddlZonas" style="width: 100%;" multiple></select>                        </div>                        <div class="form-group col-lg-12">                            <input id="chkPlayas" type="checkbox" />                            <label class="form-label" for="ddlPlayas">Playas: </label>                            <select id="ddlPlayas" style="width: 100%;" multiple></select>                        </div>                        <div class="form-group col-lg-12">                            <input id="chkTipoPlaya" type="checkbox" />                            <label class="form-label" for="ddlTipoPlaya">Tipo de playa:</label>                            <select id="ddlTipoPlaya" style="width: 100%;" multiple></select>                        </div>                        <div class="form-group col-lg-12">                            <input id="chkTipoVehiculo" type="checkbox" />                            <label class="form-label" for="ddlTipoVehiculo">Tipo de vehiculo:</label>                            <select id="ddlTipoVehiculo" class="form-control" style="width: 100%;" multiple></select>                        </div>                    </div>                    <div class="col-lg-8">                        <div class="row">                            <div class="pull-left" style="margin-left:-30px">                                <button class="glyphicon glyphicon-chevron-left" type="button" onclick="menuFiltros(this)"></button>                            </div>                            <div class="col-lg-6">                                <div class="col-lg-5">                                    <label class="form-label pull-right">Agrupar Por: </label>                                </div>                                <div class="col-lg-7">                                    <select id="ddlAgruparPor" style="width: 100%;">                                        <option></option>                                        <option value="1" selected>Zonas</option>                                        <option value="2">Playas</option>                                        <option value="3">Tipos de Playa</option>                                        <option value="4">Tipos de Vehiculo</option>                                    </select>                                </div>                            </div>                            <div class="col-lg-5">                                <div class="col-lg-5">                                    <label class="form-label pull-right">Eje X: </label>                                </div>                                <div class="col-lg-7">                                    <select id="ddlEscala" style="width: 100%;">                                        <option></option>                                        <option value="1" selected>Años</option>                                        <option value="2">Meses</option>                                    </select>                                </div>                            </div>                           <div class="dropdown pull-right">                        <button class="btn btn-success dropdown-toggle" type="button" data-toggle="dropdown" aria-expanded="true">                            <span class="glyphicon glyphicon-stats"></span>                        </button>                        <ul class="dropdown-menu" role="menu" aria-labelledby="dropdownMenu1">                            <li role="presentation"><a id="btnCambiarATorta" role="menuitem" data-value="1" tabindex="-1" href="#">Gráfico de Torta</a></li>                            <li role="presentation"><a id="btnCambiarABarras" role="menuitem" data-value="2" tabindex="-1" href="#">Gráfico de Barras</a></li>                        <li role="presentation"><a id="btnCambiarALineas" role="menuitem" data-value="3" tabindex="-1" href="#">Gráfico de Lineas</a></li>                        <li role="presentation"><a id="btnCambiarAAreas" role="menuitem" data-value="4" tabindex="-1" href="#">Gráfico de Áreas</a></li>                        </ul>                    </div>                        </div>                        <div id="divEstadistica-' + estadisticas.length + '" style="height: 300px" data-value="' + estadisticas.length + '"></div>                    </div>                </div>            </div>';

    var divEstadisticaTiempoReal = '<div class="panel panel-default">                <div class="panel-heading">                    <div class="row">                        <div class="col-lg-4">                            <div class="col-lg-4">                                <label class="control-label pull-right">Estadistica:</label>                            </div>                            <div class="col-lg-8">                                <select id="ddlEstadistica" style="width: 100%;"  disabled>                                    <option value="1">Disponibilidad</option>                                    <option value="2">Consultas</option>                                </select>                            </div>                        </div>                        <div class="col-lg-4">                            <div class="col-lg-4">                                <label class="control-label pull-right">Por: </label>                            </div>                            <div class="col-lg-8">                                <select id="ddlBuscarPor" style="width: 100%;" disabled>                                    <option value="3">Playa</option>                               </select>                            </div>                        </div>                        <div class="col-lg-3" hidden>                            <div class="col-lg-3">                                <label class="control-label">Desde:</label>                            </div>                            <div class="col-lg-9 pul-left">                                <div id="fechaDesde" class="bfh-datepicker" data-placeholder="Fecha Desde" data-min="01/15/2013" data-format="d-m-y" data-max="today"></div>                            </div>                        </div>                        <div class="col-lg-3" hidden>                            <div class="col-lg-3">                                <label class="control-label">Hasta:</label>                            </div>                            <div class="col-lg-9 pull-left">                                <div id="fechaHasta" class="bfh-datepicker" data-placeholder="Fecha Hasta" data-min="01/15/2013" data-format="d-m-y" data-max="today"></div>                            </div>                        </div>                        <div class="">                            <div class="pull-left">                                <button id="btnBuscarEstadisticas" class="btn btn-success" type="button"><span class="fa fa-search">Buscar</span></button>                            </div>                            <div class="pull-right"><i id="minMax" class="fa fa-square-o fa-lg" style="margin-right: 10px;"></i></div>                        </div>                    </div>                </div>                <div class="panel-body" style="display: none;">                    <div id="divFiltros" class="col-lg-4">                        <div class="form-group col-lg-12">                            <input id="chkPlayas" type="checkbox" />                            <label class="form-label" for="ddlPlayas">Playas: </label>                            <select id="ddlPlayas" style="width: 100%;" multiple></select>                        </div>                        <div class="form-group col-lg-12">                            <input id="chkTipoPlaya" type="checkbox" />                            <label class="form-label" for="ddlTipoPlaya">Tipo de playa:</label>                            <select id="ddlTipoPlaya" style="width: 100%;" multiple></select>                        </div>                        <div class="form-group col-lg-12">                            <input id="chkTipoVehiculo" type="checkbox" />                            <label class="form-label" for="ddlTipoVehiculo">Tipo de vehiculo:</label>                            <select id="ddlTipoVehiculo" class="form-control" style="width: 100%;" multiple></select>                        </div>                    </div>                    <div class="col-lg-8">                        <div class="row">                            <div class="pull-left" style="margin-left: -30px">                                <button class="glyphicon glyphicon-chevron-left" type="button" onclick="menuFiltros(this)"></button>                            </div>                            <div class="col-lg-6">                                <div class="col-lg-5">                                    <label class="form-label pull-right">Agrupar Por: </label>                                </div>                                <div class="col-lg-7">                                    <select id="ddlAgruparPor" style="width: 100%;">                           <option value="2" selected>Playas</option>                                        <option value="3">Tipos de Playa</option>                                        <option value="4">Tipos de Vehiculo</option>                                    </select>                                </div>                            </div>                            <div class="col-lg-5">                                <div class="col-lg-5">                                    <label class="form-label pull-right">Eje X: </label>                                </div>                                <div class="col-lg-7">                                    <select id="ddlEscala" style="width: 100%;" disabled>                                        <option value="3" selected>Tiempo Real</option>                                    </select>                                </div>                            </div>                            <div class="dropdown pull-right">                                <button class="btn btn-success dropdown-toggle" type="button" data-toggle="dropdown" aria-expanded="true"><span class="glyphicon glyphicon-stats"></span></button>                                <ul class="dropdown-menu" role="menu" aria-labelledby="dropdownMenu1">                                    <li role="presentation"><a id="btnCambiarALineas" role="menuitem" data-value="3" tabindex="-1" href="#">Gráfico de Lineas</a></li>                                    <li role="presentation"><a id="btnCambiarADensidad" role="menuitem" data-value="5" tabindex="-1" href="#">Gráfico de Densidad</a></li>                                </ul>                            </div>                        </div>                        <div id="divEstadistica-' + estadisticas.length + '" style="height: 300px" data-value="' + estadisticas.length + '"></div>                    </div>                </div>            </div>';

    if (tipoEstadistica == 1) { $('#divContenedorEstadisticas').append(divEstadisticaHistorica); }
    else { $('#divContenedorEstadisticas').append(divEstadisticaTiempoReal); }


    //inicio los controles de filtros    
    var $divEstadisticaNueva = $('#divEstadistica-' + estadisticas.length);
    var index = $divEstadisticaNueva.attr('data-value');

    estadisticas.push(new estadistica($divEstadisticaNueva.attr('id'), null));

    $divEstadisticaNueva.parents('.panel-body').first().prev().find('[id*=ddl]').select2();
    $divEstadisticaNueva.parents('.panel-body').first().find('[id*=ddl]').select2();


    $divEstadisticaNueva.parents('.panel-body').first().find('[id*=btnCambiarA]').off('click').on('click', function () {
        estadisticas[index].cambiarTipo($(this).attr('data-value'));
        configurarCamposPorGrafico($divEstadisticaNueva, $(this).attr('data-value'));
    });

    $divEstadisticaNueva.parents('.panel-body').first().find('[id*=ddl]').on('change', function () {
        estadisticas[index].init();
    });

    $divEstadisticaNueva.parents('.panel-body').first().find('#divFiltros').find('[id*=ddl]').on('change', function () {
        estadisticas[index].filtrar()
        estadisticas[index].init();
    });

    $divEstadisticaNueva.parents('.panel-body').first().find('input[type=checkbox]').prop('checked', true);

    $('input[type=checkbox]').off('change').on('change', function () {
        var select = $(this).next().next();
        if ($(this).is(':checked')) {
            select.prop('disabled', !$(this).is(':checked'));
        }
        else {
            select.prop('disabled', !$(this).is(':checked'));
            select.val(null).trigger("change");
        }
    })

    $('.bfh-datepicker').bfhdatepicker({ format: "d/m/y" });

 //se agrega la funcion de abrir cerrar el panel con el boton minMax.
    minMax();

    //lo uso para mantener la referencia del boton en la respuesta del ajax
    var btnBuscarEstadisticas;

    //click en buscar
    $divEstadisticaNueva.parents('.panel-body').prev().find('#btnBuscarEstadisticas').off('click').on('click', function () {
        var tipoEstadistica = $(this).parents('.panel-heading').find('#ddlEstadistica').val();
        var buscarPor = $(this).parents('.panel-heading').find('#ddlBuscarPor').val();
        var desdeAUX = $(this).parents('.panel-heading').find('#fechaDesde').val().split('/');
        var hastaAUX = $(this).parents('.panel-heading').find('#fechaHasta').val().split('/');
        var desde = publicado == 1 ? desdeAUX[1] + '/' + desdeAUX[0] + '/' + desdeAUX[2] : desdeAUX[0] + '/' + desdeAUX[1] + '/' + desdeAUX[2];
        var hasta = publicado == 1 ? hastaAUX[1] + '/' + hastaAUX[0] + '/' + hastaAUX[2] : hastaAUX[0] + '/' + hastaAUX[1] + '/' + hastaAUX[2];
        var ciudad = $('[id*=txtIdPlace]').val();
        var usuarioId = $('[id*=hdUsuarioId]').val();
        var $filtros = $(this).parents('.panel-heading').next().find('#divFiltros');
        var $divEstadistica = $(this).parents('.panel-heading').next().find('[id*=divEstadistica-]');

        //borro las opciones playa y zonas, porque se configuran despues
        $divEstadistica.prev().find('#ddlAgruparPor option[value=1]').remove();
        $divEstadistica.prev().find('#ddlAgruparPor option[value=2]').remove();

        if (buscarPor == "1") {
            $filtros.find('#ddlZonas').parent().hide()
            $filtros.find('#ddlPlayas').parent().show()
            $divEstadistica.prev().find('#ddlAgruparPor').select2("destroy");
            $divEstadistica.prev().find('#ddlAgruparPor option[value=1]').remove();
            $divEstadistica.prev().find('#ddlAgruparPor').prepend('<option value="2">Playas</option>');
            $divEstadistica.prev().find('#ddlAgruparPor').val("2");
            $divEstadistica.prev().find('#ddlAgruparPor').select2();
        }

        if (buscarPor == "2") {
            $filtros.find('#ddlZonas').parent().show();
            $filtros.find('#ddlPlayas').parent().hide();
            $divEstadistica.prev().find('#ddlAgruparPor').select2("destroy");
            $divEstadistica.prev().find('#ddlAgruparPor option[value=2]').remove();
            $divEstadistica.prev().find('#ddlAgruparPor').prepend('<option value="1">Zonas</option>');
            $divEstadistica.prev().find('#ddlAgruparPor').val("1");
            $divEstadistica.prev().find('#ddlAgruparPor').select2();
        }

        if (buscarPor == "3") {
            $filtros.find('#ddlZonas').parent().hide()
            $filtros.find('#ddlPlayas').parent().show()
            $divEstadistica.prev().find('#ddlAgruparPor').select2("destroy");
            $divEstadistica.prev().find('#ddlAgruparPor option[value=1]').remove();
            $divEstadistica.prev().find('#ddlAgruparPor').prepend('<option value="2">Playas</option>');
            $divEstadistica.prev().find('#ddlAgruparPor').val("2");
            $divEstadistica.prev().find('#ddlAgruparPor').select2();
            $(btnBuscarEstadisticas).prop('disabled', true);
        }
        
        btnBuscarEstadisticas = this;
        if (buscarPor == 3) {
            busquedaEstadisticasAjax();

            setInterval(function () {
                busquedaEstadisticasAjax();
            }, 10000)
            function busquedaEstadisticasAjax() {
                $.ajax({
                    type: "POST",
                    url: "Estadisticas.aspx/BuscarEstadisticas",
                    data: "{'ciudad': '" + ciudad + "', 'usuarioId': '" + usuarioId + "', 'tipoEstadistica': '" + tipoEstadistica + "', 'buscarPor': '" + buscarPor + "', 'desde': '" + desde + "', 'hasta': '" + hasta + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var resultado = $.parseJSON(response.d);
                        cargarFiltros($(btnBuscarEstadisticas).parents('.panel-heading').next().find('#divFiltros'), resultado);
                        var index = $(btnBuscarEstadisticas).parents('.panel-heading').next().find('[id*=divEstadistica-]').attr('data-value');
                        if (estadisticas[index].datos == null) {
                            estadisticas[index].datos = resultado;
                        }
                        else { Array.prototype.push.apply(estadisticas[index].datos, resultado); }

                        if (estadisticas[index].tipo == 1) { estadisticas[index].tipo = 3 }
                        estadisticas[index].init();
                        configurarCamposPorGrafico($divEstadistica, estadisticas[$divEstadistica.attr('data-value')].tipo);
                        $(btnBuscarEstadisticas).parents('.panel-heading').next().show();
                    },
                    error: function (result) {
                    }
                });
            }
        }

        else {
            $.ajax({
                type: "POST",
                url: "Estadisticas.aspx/BuscarEstadisticas",
                data: "{'ciudad': '" + ciudad + "', 'usuarioId': '" + usuarioId + "', 'tipoEstadistica': '" + tipoEstadistica + "', 'buscarPor': '" + buscarPor + "', 'desde': '" + desde + "', 'hasta': '" + hasta + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var resultado = $.parseJSON(response.d);
                    cargarFiltros($(btnBuscarEstadisticas).parents('.panel-heading').next().find('#divFiltros'), resultado);

                    configurarCamposPorGrafico($divEstadistica, estadisticas[$divEstadistica.attr('data-value')].tipo);
                    $(btnBuscarEstadisticas).parents('.panel-heading').next().show();

                    estadisticas[$(btnBuscarEstadisticas).parents('.panel-heading').next().find('[id*=divEstadistica-]').attr('data-value')].datos = resultado;
                    estadisticas[$(btnBuscarEstadisticas).parents('.panel-heading').next().find('[id*=divEstadistica-]').attr('data-value')].init();

                },
                error: function (result) {
                }
            });
        }
    });

}

function estadistica(divId, datos) {
    this.init = function () {
        this.filtrar();
        switch (parseInt(this.tipo)) {
            case 1:
                this.initEstadisticaTorta();
                break;
            case 2:
                this.initEstadisticaBarra();
                break;
            case 3:
                this.initEstadisticaLinea();
                break;
            case 4:
                this.initEstadisticaArea();
                break;
            case 5:
                this.initEstadisticaDensidad();
                break;
            default:
        }
    };
    this.initEstadisticaTorta = function () {
        var me = this;
        var datosFormateados = new Array();

        configurarDatos();

        $('#' + this.div).empty();
        this.grafico = new Morris.Donut({
            element: this.div,
            data: datosFormateados
        });

        function configurarDatos() {

            var etiquetas = new Object();
            var valores = new Object();

            var agruparPor = $('#' + me.div).parent().find('#ddlAgruparPor').val();
            switch (agruparPor) {
                case "1":
                    agruparPorZona();
                    break;
                case "2":
                    agruparPorPlaya();
                    break;
                case "3":
                    agruparPorTipoPlaya();
                    break;
                case "4":
                    agruparPorTipoVehiculo();
                    break;
                default:

            }

            var dataJSON = '[';
            $.each(valores, function (i, item) {
                dataJSON += '{"label":"' + i + '", ';
                dataJSON += '"value": "' + item + '"}, ';
            })
            if (dataJSON.length > 2) {
                dataJSON = dataJSON.slice(0, -2);
            }
            dataJSON += ']';
            datosFormateados = JSON.parse(dataJSON);


            function agruparPorZona() {
                datosFormateados = new Array();
                $.each(me.datosFiltrados, function (i, item) {
                    if (valores[item.ZonaNombre] == undefined) { valores[item.ZonaNombre] = item.Cantidad; }
                    else { valores[item.ZonaNombre] += item.Cantidad; }
                });
            }
            function agruparPorPlaya() {
                datosFormateados = new Array();
                $.each(me.datosFiltrados, function (i, item) {
                    if (valores[item.PlayaNombre] == undefined) { valores[item.PlayaNombre] = item.Cantidad; }
                    else { valores[item.PlayaNombre] += item.Cantidad; }
                });
            }

            function agruparPorTipoPlaya() {
                datosFormateados = new Array();
                $.each(me.datosFiltrados, function (i, item) {
                    if (valores[item.TipoPlayaNombre] == undefined) { valores[item.TipoPlayaNombre] = item.Cantidad; }
                    else { valores[item.TipoPlayaNombre] += item.Cantidad; }
                });
            }
            function agruparPorTipoVehiculo() {
                datosFormateados = new Array();
                $.each(me.datosFiltrados, function (i, item) {
                    if (valores[item.TipoVehiculoNombre] == undefined) { valores[item.TipoVehiculoNombre] = item.Cantidad; }
                    else { valores[item.TipoVehiculoNombre] += item.Cantidad; }
                });
            }

        }

    },
    this.initEstadisticaBarra = function () {
        var me = this;
        var datosFormateados = new Object();
        var xkey = 'l';
        var ykeys;
        var labels;
        configurarDatos()

        $('#' + this.div).empty();
        this.grafico = new Morris.Bar({
            element: this.div,
            data: datosFormateados,
            xkey: xkey,
            ykeys: ykeys,
            labels: labels
        });

        function configurarDatos() {

            var etiquetas = new Object();
            var valores = new Object();

            var agruparPor = $('#' + me.div).parent().find('#ddlAgruparPor').val();
            var escala = $('#' + me.div).parent().find('#ddlEscala').val();
            if (escala == 2) {
                switch (agruparPor) {
                    case "1":
                        agruparPorZonaMes();
                        break;
                    case "2":
                        agruparPorPlayaMes();
                        break;
                    case "3":
                        agruparPorTipoPlayaMes();
                        break;
                    case "4":
                        agruparPorTipoVehiculoMes();
                        break;
                    default:

                }
            }
            if (escala == 1) {
                switch (agruparPor) {
                    case "1":
                        agruparPorZonaAno();
                        break;
                    case "2":
                        agruparPorPlayaAno();
                        break;
                    case "3":
                        agruparPorTipoPlayaAno();
                        break;
                    case "4":
                        agruparPorTipoVehiculoAno();
                        break;
                    default:

                }
            }

            var ykeysJSON = '[';
            var labelsJSON = '[';
            var dataJSON = '[{';
            $.each(valores, function (i, fecha) {
                dataJSON += '"l":"' + i + '", ';
                $.each(fecha, function (j, item) {
                    dataJSON += '"' + j + '": "' + item + '", ';
                })
            })

            $.each(etiquetas, function (i, item) {
                ykeysJSON += '"' + i + '", ';
                labelsJSON += '"' + item + '", ';
            });
            if (labelsJSON.length > 2) {
                labelsJSON = labelsJSON.slice(0, -2);
            }
            labelsJSON += ']';
            if (ykeysJSON.length > 2) {
                ykeysJSON = ykeysJSON.slice(0, -2);
            }
            ykeysJSON += ']';
            if (dataJSON.length > 2) {
                dataJSON = dataJSON.slice(0, -2);
            }
            dataJSON += '}]';
            ykeys = JSON.parse(ykeysJSON);
            labels = JSON.parse(labelsJSON);
            datosFormateados = JSON.parse(dataJSON);

            function agruparPorPlayaMes() {
                $.each(me.datosFiltrados, function (i, item) {
                    if (etiquetas[item.PlayaId] == undefined) { etiquetas[item.PlayaId] = item.PlayaNombre; }
                    if (valores[item.Mes + '/' + item.Ano] == undefined) { valores[item.Mes + '/' + item.Ano] = new Object(); }
                    if (valores[item.Mes + '/' + item.Ano][item.PlayaId] == undefined) { valores[item.Mes + '/' + item.Ano][item.PlayaId] = item.Cantidad; }
                    else { valores[item.Mes + '/' + item.Ano][item.PlayaId] += item.Cantidad; }
                })

            };

            function agruparPorPlayaAno() {
                $.each(me.datosFiltrados, function (i, item) {
                    if (etiquetas[item.PlayaId] == undefined) { etiquetas[item.PlayaId] = item.PlayaNombre; }
                    if (valores[item.Ano.toString()] == undefined) { valores[item.Ano.toString()] = new Object(); }
                    if (valores[item.Ano.toString()][item.PlayaId] == undefined) { valores[item.Ano.toString()][item.PlayaId] = item.Cantidad; }
                    else { valores[item.Ano.toString()][item.PlayaId] += item.Cantidad; }
                })
            };

            function agruparPorTipoPlayaMes() {

                $.each(me.datosFiltrados, function (i, item) {
                    if (etiquetas[item.TipoPlayaId] == undefined) { etiquetas[item.TipoPlayaId] = item.TipoPlayaNombre; }
                    if (valores[item.Mes + '/' + item.Ano] == undefined) { valores[item.Mes + '/' + item.Ano] = new Object(); }
                    if (valores[item.Mes + '/' + item.Ano][item.TipoPlayaId] == undefined) { valores[item.Mes + '/' + item.Ano][item.TipoPlayaId] = item.Cantidad; }
                    else { valores[item.Mes + '/' + item.Ano][item.TipoPlayaId] += item.Cantidad; }
                })

            };

            function agruparPorTipoPlayaAno() {
                $.each(me.datosFiltrados, function (i, item) {
                    if (etiquetas[item.TipoPlayaId] == undefined) { etiquetas[item.TipoPlayaId] = item.TipoPlayaNombre; }
                    if (valores[item.Ano.toString()] == undefined) { valores[item.Ano.toString()] = new Object(); }
                    if (valores[item.Ano.toString()][item.TipoPlayaId] == undefined) { valores[item.Ano.toString()][item.TipoPlayaId] = item.Cantidad; }
                    else { valores[item.Ano.toString()][item.TipoPlayaId] += item.Cantidad; }
                })
            };

            function agruparPorTipoVehiculoMes() {
                $.each(me.datosFiltrados, function (i, item) {
                    if (etiquetas[item.TipoVehiculoId] == undefined) { etiquetas[item.TipoVehiculoId] = item.TipoVehiculoNombre; }
                    if (valores[item.Mes + '/' + item.Ano] == undefined) { valores[item.Mes + '/' + item.Ano] = new Object(); }
                    if (valores[item.Mes + '/' + item.Ano][item.TipoVehiculoId] == undefined) { valores[item.Mes + '/' + item.Ano][item.TipoVehiculoId] = item.Cantidad; }
                    else { valores[item.Mes + '/' + item.Ano][item.TipoVehiculoId] += item.Cantidad; }
                })
            };

            function agruparPorTipoVehiculoAno() {
                $.each(me.datosFiltrados, function (i, item) {
                    if (etiquetas[item.TipoVehiculoId] == undefined) { etiquetas[item.TipoVehiculoId] = item.TipoVehiculoNombre; }
                    if (valores[item.Ano.toString()] == undefined) { valores[item.Ano.toString()] = new Object(); }
                    if (valores[item.Ano.toString()][item.TipoVehiculoId] == undefined) { valores[item.Ano.toString()][item.TipoVehiculoId] = item.Cantidad; }
                    else { valores[item.Ano.toString()][item.TipoVehiculoId] += item.Cantidad; }
                })
            };

            function agruparPorZonaMes() {
                $.each(me.datosFiltrados, function (i, item) {
                    if (etiquetas[item.ZonaId] == undefined) { etiquetas[item.ZonaId] = item.ZonaNombre; }
                    if (valores[item.Mes + '/' + item.Ano] == undefined) { valores[item.Mes + '/' + item.Ano] = new Object(); }
                    if (valores[item.Mes + '/' + item.Ano][item.ZonaId] == undefined) { valores[item.Mes + '/' + item.Ano][item.ZonaId] = item.Cantidad; }
                    else { valores[item.Mes + '/' + item.Ano][item.ZonaId] += item.Cantidad; }
                })
            };

            function agruparPorZonaAno() {
                $.each(me.datosFiltrados, function (i, item) {
                    if (etiquetas[item.ZonaId] == undefined) { etiquetas[item.ZonaId] = item.ZonaNombre; }
                    if (valores[item.Ano.toString()] == undefined) { valores[item.Ano.toString()] = new Object(); }
                    if (valores[item.Ano.toString()][item.ZonaId] == undefined) { valores[item.Ano.toString()][item.ZonaId] = item.Cantidad; }
                    else { valores[item.Ano.toString()][item.ZonaId] += item.Cantidad; }
                })
            };

        };



    };
    this.initEstadisticaLinea = function () {
        var me = this;
        var datosFormateados = new Object();
        var xkey = 'l';
        var ykeys;
        var labels;
        configurarDatos()

        $('#' + this.div).empty();
        this.grafico = new Morris.Line({
            element: this.div,
            data: datosFormateados,
            xkey: xkey,
            ykeys: ykeys,
            labels: labels,
            xLabels: "10sec",
            hideHover: "true"
        });

        function configurarDatos() {

            var etiquetas = new Object();
            var valores = new Object();

            var agruparPor = $('#' + me.div).parent().find('#ddlAgruparPor').val();
            var escala = $('#' + me.div).parent().find('#ddlEscala').val();
            if (escala == 2) {
                switch (agruparPor) {
                    case "1":
                        agruparPorZonaMes();
                        break;
                    case "2":
                        agruparPorPlayaMes();
                        break;
                    case "3":
                        agruparPorTipoPlayaMes();
                        break;
                    case "4":
                        agruparPorTipoVehiculoMes();
                        break;
                    default:

                }
            }
            if (escala == 1) {
                switch (agruparPor) {
                    case "1":
                        agruparPorZonaAno();
                        break;
                    case "2":
                        agruparPorPlayaAno();
                        break;
                    case "3":
                        agruparPorTipoPlayaAno();
                        break;
                    case "4":
                        agruparPorTipoVehiculoAno();
                        break;
                    default:

                }
            }

            if (escala == 3) {
                switch (agruparPor) {
                    //case "1":
                    //    agruparPorZonaTiempo();
                    //    break;
                    case "2":
                        agruparPorPlayaTiempo();
                        break;
                    case "3":
                        agruparPorTipoPlayaTiempo();
                        break;
                    case "4":
                        agruparPorTipoVehiculoTiempo();
                        break;
                    default:

                }
            }
            var ykeysJSON = '[';
            var labelsJSON = '[';
            var dataJSON = '[';
            $.each(valores, function (i, fecha) {
                dataJSON += '{"l":"' + i + '", ';
                $.each(fecha, function (j, item) {
                    dataJSON += '"' + j + '": "' + item + '", ';
                })
                dataJSON = dataJSON.slice(0, -2);
                dataJSON += '}, ';

            })

            $.each(etiquetas, function (i, item) {
                ykeysJSON += '"' + i + '", ';
                labelsJSON += '"' + item + '", ';
            });
            if (labelsJSON.length > 2) {
                labelsJSON = labelsJSON.slice(0, -2);
            }
            labelsJSON += ']';
            if (ykeysJSON.length > 2) {
                ykeysJSON = ykeysJSON.slice(0, -2);
            }
            ykeysJSON += ']';
            if (dataJSON.length > 2) {
                dataJSON = dataJSON.slice(0, -2);
            }
            dataJSON += ']';
            ykeys = JSON.parse(ykeysJSON);
            labels = JSON.parse(labelsJSON);
            datosFormateados = escala != 3 ? JSON.parse(dataJSON) : JSON.parse(dataJSON).slice(-6);

            function agruparPorPlayaMes() {
                $.each(me.datosFiltrados, function (i, item) {
                    if (etiquetas[item.PlayaId] == undefined) { etiquetas[item.PlayaId] = item.PlayaNombre; }
                    if (valores[item.Mes + '/' + item.Ano] == undefined) { valores[item.Mes + '/' + item.Ano] = new Object(); }
                    if (valores[item.Mes + '/' + item.Ano][item.PlayaId] == undefined) { valores[item.Mes + '/' + item.Ano][item.PlayaId] = item.Cantidad; }
                    else { valores[item.Mes + '/' + item.Ano][item.PlayaId] += item.Cantidad; }
                })

            };

            function agruparPorPlayaAno() {
                $.each(me.datosFiltrados, function (i, item) {
                    if (etiquetas[item.PlayaId] == undefined) { etiquetas[item.PlayaId] = item.PlayaNombre; }
                    if (valores[item.Ano.toString()] == undefined) { valores[item.Ano.toString()] = new Object(); }
                    if (valores[item.Ano.toString()][item.PlayaId] == undefined) { valores[item.Ano.toString()][item.PlayaId] = item.Cantidad; }
                    else { valores[item.Ano.toString()][item.PlayaId] += item.Cantidad; }
                })
            };

            function agruparPorPlayaTiempo() {
                $.each(me.datosFiltrados, function (i, item) {
                    if (etiquetas[item.PlayaId] == undefined) { etiquetas[item.PlayaId] = item.PlayaNombre; }
                    if (valores[item.Tiempo] == undefined) { valores[item.Tiempo] = new Object(); }
                    if (valores[item.Tiempo][item.PlayaId] == undefined) {
                        valores[item.Tiempo][item.PlayaId] = item.Cantidad;
                    }
                    else { valores[item.Tiempo][item.PlayaId] += item.Cantidad; }
                })

            };


            function agruparPorTipoPlayaTiempo() {
                $.each(me.datosFiltrados, function (i, item) {
                    if (etiquetas[item.TipoPlayaId] == undefined) { etiquetas[item.TipoPlayaId] = item.TipoPlayaNombre; }
                    if (valores[item.Tiempo] == undefined) { valores[item.Tiempo] = new Object(); }
                    if (valores[item.Tiempo][item.TipoPlayaId] == undefined) { valores[item.Tiempo][item.TipoPlayaId] = item.Cantidad; }
                    else { valores[item.Tiempo][item.TipoPlayaId] += item.Cantidad; }
                })
            };


            function agruparPorTipoPlayaMes() {

                $.each(me.datosFiltrados, function (i, item) {
                    if (etiquetas[item.TipoPlayaId] == undefined) { etiquetas[item.TipoPlayaId] = item.TipoPlayaNombre; }
                    if (valores[item.Mes + '/' + item.Ano] == undefined) { valores[item.Mes + '/' + item.Ano] = new Object(); }
                    if (valores[item.Mes + '/' + item.Ano][item.TipoPlayaId] == undefined) { valores[item.Mes + '/' + item.Ano][item.TipoPlayaId] = item.Cantidad; }
                    else { valores[item.Mes + '/' + item.Ano][item.TipoPlayaId] += item.Cantidad; }
                })

            };

            function agruparPorTipoPlayaAno() {
                $.each(me.datosFiltrados, function (i, item) {
                    if (etiquetas[item.TipoPlayaId] == undefined) { etiquetas[item.TipoPlayaId] = item.TipoPlayaNombre; }
                    if (valores[item.Ano.toString()] == undefined) { valores[item.Ano.toString()] = new Object(); }
                    if (valores[item.Ano.toString()][item.TipoPlayaId] == undefined) { valores[item.Ano.toString()][item.TipoPlayaId] = item.Cantidad; }
                    else { valores[item.Ano.toString()][item.TipoPlayaId] += item.Cantidad; }
                })
            };

            function agruparPorTipoVehiculoTiempo() {
                $.each(me.datosFiltrados, function (i, item) {
                    if (etiquetas[item.TipoVehiculoId] == undefined) { etiquetas[item.TipoVehiculoId] = item.TipoVehiculoNombre; }
                    if (valores[item.Tiempo] == undefined) { valores[item.Tiempo] = new Object(); }
                    if (valores[item.Tiempo][item.TipoVehiculoId] == undefined) { valores[item.Tiempo][item.TipoVehiculoId] = item.Cantidad; }
                    else { valores[item.Tiempo][item.TipoVehiculoId] += item.Cantidad; }
                })
            };

            function agruparPorTipoVehiculoMes() {
                $.each(me.datosFiltrados, function (i, item) {
                    if (etiquetas[item.TipoVehiculoId] == undefined) { etiquetas[item.TipoVehiculoId] = item.TipoVehiculoNombre; }
                    if (valores[item.Mes + '/' + item.Ano] == undefined) { valores[item.Mes + '/' + item.Ano] = new Object(); }
                    if (valores[item.Mes + '/' + item.Ano][item.TipoVehiculoId] == undefined) { valores[item.Mes + '/' + item.Ano][item.TipoVehiculoId] = item.Cantidad; }
                    else { valores[item.Mes + '/' + item.Ano][item.TipoVehiculoId] += item.Cantidad; }
                })
            };

            function agruparPorTipoVehiculoAno() {
                $.each(me.datosFiltrados, function (i, item) {
                    if (etiquetas[item.TipoVehiculoId] == undefined) { etiquetas[item.TipoVehiculoId] = item.TipoVehiculoNombre; }
                    if (valores[item.Ano.toString()] == undefined) { valores[item.Ano.toString()] = new Object(); }
                    if (valores[item.Ano.toString()][item.TipoVehiculoId] == undefined) { valores[item.Ano.toString()][item.TipoVehiculoId] = item.Cantidad; }
                    else { valores[item.Ano.toString()][item.TipoVehiculoId] += item.Cantidad; }
                })
            };

            function agruparPorZonaMes() {
                $.each(me.datosFiltrados, function (i, item) {
                    if (etiquetas[item.ZonaId] == undefined) { etiquetas[item.ZonaId] = item.ZonaNombre; }
                    if (valores[item.Mes + '/' + item.Ano] == undefined) { valores[item.Mes + '/' + item.Ano] = new Object(); }
                    if (valores[item.Mes + '/' + item.Ano][item.ZonaId] == undefined) { valores[item.Mes + '/' + item.Ano][item.ZonaId] = item.Cantidad; }
                    else { valores[item.Mes + '/' + item.Ano][item.ZonaId] += item.Cantidad; }
                })
            };

            function agruparPorZonaAno() {
                $.each(me.datosFiltrados, function (i, item) {
                    if (etiquetas[item.ZonaId] == undefined) { etiquetas[item.ZonaId] = item.ZonaNombre; }
                    if (valores[item.Ano.toString()] == undefined) { valores[item.Ano.toString()] = new Object(); }
                    if (valores[item.Ano.toString()][item.ZonaId] == undefined) { valores[item.Ano.toString()][item.ZonaId] = item.Cantidad; }
                    else { valores[item.Ano.toString()][item.ZonaId] += item.Cantidad; }
                })
            };

        };

    };
    this.initEstadisticaArea = function () {
        var me = this;
        var datosFormateados = new Object();
        var xkey = 'l';
        var ykeys;
        var labels;
        configurarDatos()

        $('#' + this.div).empty();
        this.grafico = new Morris.Area({
            element: this.div,
            data: datosFormateados,
            xkey: xkey,
            ykeys: ykeys,
            labels: labels
        });

        function configurarDatos() {

            var etiquetas = new Object();
            var valores = new Object();

            var agruparPor = $('#' + me.div).parent().find('#ddlAgruparPor').val();
            var escala = $('#' + me.div).parent().find('#ddlEscala').val();
            if (escala == 2) {
                switch (agruparPor) {
                    case "1":
                        agruparPorZonaMes();
                        break;
                    case "2":
                        agruparPorPlayaMes();
                        break;
                    case "3":
                        agruparPorTipoPlayaMes();
                        break;
                    case "4":
                        agruparPorTipoVehiculoMes();
                        break;
                    default:

                }
            }
            if (escala == 1) {
                switch (agruparPor) {
                    case "1":
                        agruparPorZonaAno();
                        break;
                    case "2":
                        agruparPorPlayaAno();
                        break;
                    case "3":
                        agruparPorTipoPlayaAno();
                        break;
                    case "4":
                        agruparPorTipoVehiculoAno();
                        break;
                    default:

                }
            }

            var ykeysJSON = '[';
            var labelsJSON = '[';
            var dataJSON = '[';
            $.each(valores, function (i, fecha) {
                dataJSON += '"l":"' + i + '", ';
                $.each(fecha, function (j, item) {
                    dataJSON += '"' + j + '": "' + item + '", ';
                })
                dataJSON = dataJSON.slice(0, -2);
                dataJSON += '}, ';
            })

            $.each(etiquetas, function (i, item) {
                ykeysJSON += '"' + i + '", ';
                labelsJSON += '"' + item + '", ';
            });
            if (labelsJSON.length > 2) {
                labelsJSON = labelsJSON.slice(0, -2);
            }
            labelsJSON += ']';
            if (ykeysJSON.length > 2) {
                ykeysJSON = ykeysJSON.slice(0, -2);
            }
            ykeysJSON += ']';
            if (dataJSON.length > 2) {
                dataJSON = dataJSON.slice(0, -2);
            }
            dataJSON += ']';
            ykeys = JSON.parse(ykeysJSON);
            labels = JSON.parse(labelsJSON);
            datosFormateados = JSON.parse(dataJSON);

            function agruparPorPlayaMes() {
                $.each(me.datosFiltrados, function (i, item) {
                    if (etiquetas[item.PlayaId] == undefined) { etiquetas[item.PlayaId] = item.PlayaNombre; }
                    if (valores[item.Mes + '/' + item.Ano] == undefined) { valores[item.Mes + '/' + item.Ano] = new Object(); }
                    if (valores[item.Mes + '/' + item.Ano][item.PlayaId] == undefined) { valores[item.Mes + '/' + item.Ano][item.PlayaId] = item.Cantidad; }
                    else { valores[item.Mes + '/' + item.Ano][item.PlayaId] += item.Cantidad; }
                })

            };

            function agruparPorPlayaAno() {
                $.each(me.datosFiltrados, function (i, item) {
                    if (etiquetas[item.PlayaId] == undefined) { etiquetas[item.PlayaId] = item.PlayaNombre; }
                    if (valores[item.Ano.toString()] == undefined) { valores[item.Ano.toString()] = new Object(); }
                    if (valores[item.Ano.toString()][item.PlayaId] == undefined) { valores[item.Ano.toString()][item.PlayaId] = item.Cantidad; }
                    else { valores[item.Ano.toString()][item.PlayaId] += item.Cantidad; }
                })
            };

            function agruparPorTipoPlayaMes() {

                $.each(me.datosFiltrados, function (i, item) {
                    if (etiquetas[item.TipoPlayaId] == undefined) { etiquetas[item.TipoPlayaId] = item.TipoPlayaNombre; }
                    if (valores[item.Mes + '/' + item.Ano] == undefined) { valores[item.Mes + '/' + item.Ano] = new Object(); }
                    if (valores[item.Mes + '/' + item.Ano][item.TipoPlayaId] == undefined) { valores[item.Mes + '/' + item.Ano][item.TipoPlayaId] = item.Cantidad; }
                    else { valores[item.Mes + '/' + item.Ano][item.TipoPlayaId] += item.Cantidad; }
                })

            };

            function agruparPorTipoPlayaAno() {
                $.each(me.datosFiltrados, function (i, item) {
                    if (etiquetas[item.TipoPlayaId] == undefined) { etiquetas[item.TipoPlayaId] = item.TipoPlayaNombre; }
                    if (valores[item.Ano.toString()] == undefined) { valores[item.Ano.toString()] = new Object(); }
                    if (valores[item.Ano.toString()][item.TipoPlayaId] == undefined) { valores[item.Ano.toString()][item.TipoPlayaId] = item.Cantidad; }
                    else { valores[item.Ano.toString()][item.TipoPlayaId] += item.Cantidad; }
                })
            };

            function agruparPorTipoVehiculoMes() {
                $.each(me.datosFiltrados, function (i, item) {
                    if (etiquetas[item.TipoVehiculoId] == undefined) { etiquetas[item.TipoVehiculoId] = item.TipoVehiculoNombre; }
                    if (valores[item.Mes + '/' + item.Ano] == undefined) { valores[item.Mes + '/' + item.Ano] = new Object(); }
                    if (valores[item.Mes + '/' + item.Ano][item.TipoVehiculoId] == undefined) { valores[item.Mes + '/' + item.Ano][item.TipoVehiculoId] = item.Cantidad; }
                    else { valores[item.Mes + '/' + item.Ano][item.TipoVehiculoId] += item.Cantidad; }
                })
            };

            function agruparPorTipoVehiculoAno() {
                $.each(me.datosFiltrados, function (i, item) {
                    if (etiquetas[item.TipoVehiculoId] == undefined) { etiquetas[item.TipoVehiculoId] = item.TipoVehiculoNombre; }
                    if (valores[item.Ano.toString()] == undefined) { valores[item.Ano.toString()] = new Object(); }
                    if (valores[item.Ano.toString()][item.TipoVehiculoId] == undefined) { valores[item.Ano.toString()][item.TipoVehiculoId] = item.Cantidad; }
                    else { valores[item.Ano.toString()][item.TipoVehiculoId] += item.Cantidad; }
                })
            };

            function agruparPorZonaMes() {
                $.each(me.datosFiltrados, function (i, item) {
                    if (etiquetas[item.ZonaId] == undefined) { etiquetas[item.ZonaId] = item.ZonaNombre; }
                    if (valores[item.Mes + '/' + item.Ano] == undefined) { valores[item.Mes + '/' + item.Ano] = new Object(); }
                    if (valores[item.Mes + '/' + item.Ano][item.ZonaId] == undefined) { valores[item.Mes + '/' + item.Ano][item.ZonaId] = item.Cantidad; }
                    else { valores[item.Mes + '/' + item.Ano][item.ZonaId] += item.Cantidad; }
                })
            };

            function agruparPorZonaAno() {
                $.each(me.datosFiltrados, function (i, item) {
                    if (etiquetas[item.ZonaId] == undefined) { etiquetas[item.ZonaId] = item.ZonaNombre; }
                    if (valores[item.Ano.toString()] == undefined) { valores[item.Ano.toString()] = new Object(); }
                    if (valores[item.Ano.toString()][item.ZonaId] == undefined) { valores[item.Ano.toString()][item.ZonaId] = item.Cantidad; }
                    else { valores[item.Ano.toString()][item.ZonaId] += item.Cantidad; }
                })
            };

        };

    };
    this.initEstadisticaDensidad = function () {
        var me = this;
        var datosFormateados = me.datosFiltrados;
        var xkey = 'l';
        var ykeys;
        var labels;

        var heatMapData = [];

        configurarDatos();

        $.each(datosFormateados, function (i, item) {
            heatMapData.push({ location: new google.maps.LatLng(item.lat, item.long), weight: 100 / item.cantidad });
        });

        $('#' + me.div).empty();

        var center = new google.maps.LatLng(-31.416756, -64.183501);

        var mapOptions = {
            zoom: 13,
            center: center,
            mapTypeId: google.maps.MapTypeId.SATELLITE
        };
        map = new google.maps.Map(document.getElementById(me.div),
            mapOptions);

        var heatmap = new google.maps.visualization.HeatmapLayer({
            data: heatMapData
        });
        heatmap.setMap(map);


        function configurarDatos() {

            var etiquetas = [];
            var valores = new Object();

            agruparPorPlaya();


            var dataJSON = '[';

            $.each(valores[etiquetas[etiquetas.length - 1]], function (i, item) {
                dataJSON += '{"lat":"' + item.Latitud + '", "long": "' + item.Longitud + '", "cantidad": "' + item.Cantidad + '"}, ';
            })
            if (dataJSON.length > 2) {
                dataJSON = dataJSON.slice(0, -2);
            }
            dataJSON += ']';
            datosFormateados = JSON.parse(dataJSON);

            function agruparPorPlaya() {
                var cont = 0;
                $.each(me.datosFiltrados, function (i, item) {
                    if (etiquetas[cont] == undefined) { etiquetas[cont] = item.Tiempo; cont++; }
                    if (valores[item.Tiempo] == undefined) { valores[item.Tiempo] = new Object(); }
                    if (valores[item.Tiempo][item.PlayaId] == undefined) {
                        valores[item.Tiempo][item.PlayaId] = new Object();
                        valores[item.Tiempo][item.PlayaId].Cantidad = item.Cantidad;
                        var LongLat = item.Posicion.Geography.WellKnownText.substr(item.Posicion.Geography.WellKnownText.indexOf('(') + 1, item.Posicion.Geography.WellKnownText.length).replace(')', '').split(' ');
                        valores[item.Tiempo][item.PlayaId].Latitud = LongLat[1];
                        valores[item.Tiempo][item.PlayaId].Longitud = LongLat[0];
                    }
                    else { valores[item.Tiempo][item.PlayaId].Cantidad += item.Cantidad; }
                })

            };
        };
    };
    this.cambiarTipo = function (tipoNuevo) {
        this.tipo = tipoNuevo;
        this.init();
    };
    this.filtrar = function () {
        this.datosFiltrados = JSON.parse(JSON.stringify(this.datos));
        var $filtros = $('#' + this.div).parents('.panel-body').first().find('#divFiltros');
        if ($filtros.find('#chkZonas').prop('checked')) {
            var valoresAceptados = $filtros.find('#ddlZonas').val();
            var me = this;
            if (valoresAceptados != null) {

                me.datosFiltrados = $.grep(me.datosFiltrados, function (item, i) {
                    if ($.inArray(item.ZonaId.toString(), valoresAceptados) != -1) {
                        return true;
                    }
                });
            }
        }

        if ($filtros.find('#chkPlayas').prop('checked')) {
            var valoresAceptados = $filtros.find('#ddlPlayas').val();
            var me = this;
            if (valoresAceptados != null) {
                me.datosFiltrados = $.grep(me.datosFiltrados, function (item, i) {
                    if ($.inArray(item.PlayaId.toString(), valoresAceptados) != -1) {
                        return true
                    }
                });
            }
        };



        if ($filtros.find('#chkTipoPlaya').prop('checked')) {
            var valoresAceptados = $filtros.find('#ddlTipoPlaya').val();
            var me = this;
            if (valoresAceptados != null) {
                me.datosFiltrados = $.grep(me.datosFiltrados, function (item, i) {
                    if ($.inArray(item.TipoPlayaId.toString(), valoresAceptados) != -1) {
                        return true
                    }
                });
            }
        }

        if ($filtros.find('#chkTipoVehiculo').prop('checked')) {
            var valoresAceptados = $filtros.find('#ddlTipoVehiculo').val();
            var me = this;
            if (valoresAceptados != null) {
                me.datosFiltrados = $.grep(me.datosFiltrados, function (item, i) {
                    if ($.inArray(item.TipoVehiculoId.toString(), valoresAceptados) != -1) {
                        return true
                    }
                });
            }
        };

    };
    this.grafico = null;
    this.div = divId;
    this.datos = datos;
    this.datosFiltrados = datos;
    this.tipo = 1;

};

function minMax() {
    $('[id*=minMax]').off('click').on('click', function () {
        var $heading = $(this).parents('.panel-heading');
        var $content = $heading.next();

        $content.slideToggle(500, function () {
            if ($content.is(":visible")) {
                $heading.find('#minMax').removeClass('fa-square-o').addClass('fa-minus-square-o');
            }
            else {
                $heading.find('#minMax').removeClass('fa-minus-square-o').addClass('fa-square-o');
            }
        });
    });
}

function menuFiltros(btn) {
    var $filtros = $(btn).parents('.panel-body').first().find('#divFiltros');
    $filtros.slideToggle(150, function () {
        if ($filtros.is(":visible")) {
            $(btn).removeClass('glyphicon-chevron-right').addClass('glyphicon-chevron-left');
            $(btn).parent().css('margin-left', '-30px');
            $(btn).parents('.panel-body').first().find('[id*=divEstadistica-]').parent().removeClass('col-lg-12').addClass('col-lg-8');
        }
        else {
            $(btn).removeClass('glyphicon-chevron-left').addClass('glyphicon-chevron-right');
            $(btn).parent().css('margin-left', '0px');
            $(btn).parents('.panel-body').first().find('[id*=divEstadistica-]').parent().removeClass('col-lg-8').addClass('col-lg-12');
        }
    });
}

