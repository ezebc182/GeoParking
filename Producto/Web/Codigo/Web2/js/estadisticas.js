var estadisticas = new Array();

$('#btnNuevaEstadisticaHistorica').off('click').on('click', function () {
    $('#divContenedorEstadisticas').append(divEstadisticaHistorica)
    $('.bfh-selectbox').bfhselectbox('toggle');
    $('.bfh-datepicker').bfhdatepicker('toggle');
    $('body').click();
    minMax();
});

function estadistica(div, datos, tipoEstadistica) {
    this.init = function () {

    };
    this.cambiarTipo = function () {

    };
    this.filtrar = function () {

    };
    this.div = div;
    this.datos = datos;
    this.me = this;
};

function minMax() {
    $('#minMax').on('click', function () {
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
    $('#divFiltros').slideToggle(150, function () {
        if ($('#divFiltros').is(":visible")) {
            $(btn).removeClass('glyphicon-chevron-right').addClass('glyphicon-chevron-left');
        }
        else {
            $(btn).removeClass('glyphicon-chevron-left').addClass('glyphicon-chevron-right');
        }
    });
}

var divEstadisticaHistorica = '<div class="panel panel-default"><div class="panel-heading"><div class="row"><div class="col-lg-1"><h3 class="panel-title">Historico</h3></div><div class="col-lg-3"><div class="col-lg-6"><label class="control-label pull-right">Buscar Por:</label></div><div class="col-lg-6"><div class="bfh-selectbox" data-name="ddlBuscarPor"><div data-value="1">Playa</div><div data-value="2">Zona</div></div></div></div><div class="col-lg-3"><div class="col-lg-3"><label class="control-label">Desde:</label></div><div class="col-lg-9 pul-left"><div class="bfh-datepicker" data-placeholder="Fecha Desde" data-min="01/15/2013" data-max="today"></div></div></div><div class="col-lg-3"><div class="col-lg-3"><label class="control-label">Hasta:</label></div><div class="col-lg-9 pull-left"><div class="bfh-datepicker" data-placeholder="Fecha Hasta" data-min="01/15/2013" data-max="today"></div></div></div><div class="col-lg-2"><div class="pull-right"><i id="minMax" class="fa fa-minus-square-o fa-lg"></i></div></div></div></div><div class="panel-body"><div id="divFiltros" class="col-lg-4" style="display: none;"><div class="bfh-selectbox" data-name="ddlZonas" style="display:none;"></div><div class="bfh-selectbox" data-name="ddlPlayas"></div><div class="bfh-selectbox" data-name="ddlTipoPlaya"></div><div class="bfh-selectbox" data-name="ddlTipoVehiculo"></div></div><div id="divEstadistica" data-value=""><div class="pull-left"><button class="glyphicon glyphicon-chevron-left" type="button" onclick="menuFiltros(this)"></button></div><div></div></div>';