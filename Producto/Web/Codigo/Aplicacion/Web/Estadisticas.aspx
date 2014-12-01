<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Estadisticas.aspx.cs" Inherits="Web2.Estadisticas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&libraries=visualization"></script>
    <!--Estilo para el autocomplete-->
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <link href="Styles/morris.css" rel="stylesheet" />
    <!--script de autocomplete-->
    <script src="Scripts/Autocomplete.js"></script>
    <!--Scripts para autocomplete (no eliminar)-->
    <script src="Scripts/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script>
    <script src="http://cdnjs.cloudflare.com/ajax/libs/raphael/2.1.0/raphael-min.js"></script>
    <script src="Scripts/morris.min.js"></script>
    <script type="text/javascript" src="Scripts/Estadisticas.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-lg-12">
        <div class="panel-group" id="accordion">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#anuales-0">Estadisticas Anuales
                        </a>
                        <a id="btnAgregarComparacion" class="pull-right hidden" onclick="agregarComparacion()">+</a>
                    </h4>
                </div>
                <div id="estadisticasAnuales">
                    <div id="anuales-0" class="panel-collapse collapse in col-lg-12" numero="0">
                        <div class="panel-body">
                            <div id="Configuracion">
                                <div class="row">
                                    <div class="form-inline">
                                        <div class="formulario" data-bv-message="El valor es requerido" data-bv-feedbackicons-valid="glyphicon glyphicon-ok" data-bv-feedbackicons-invalid="glyphicon glyphicon-remove" data-bv-feedbackicons-validating="glyphicon glyphicon-refresh">
                                            <div class="form-group">
                                                <div class="col-lg-6">
                                                    <div class="col-lg-6">
                                                        <div class="input-group input-group-sm">
                                                            <input placeholder="Año Desde" class="form-control input-sm" id="fechaDesde"
                                                                data-bv-notempty="true" data-bv-notempty-message="Ingrese el año desde el cual se quieren ver las estadisticas." />
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <div class="input-group input-group-sm">
                                                            <input placeholder="Año Hasta" class="form-control input-sm" id="fechaHasta"
                                                                data-bv-notempty="true" data-bv-notempty-message="Ingrese el año desde el cual se quieren ver las estadisticas." />
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="input-group col-lg-6">
                                                    <input id="txtBuscar" class="form-control input-sm autosuggest"
                                                        placeholder="Ingresá tu ciudad"
                                                        data-bv-notempty="true" data-bv-notempty-message="Ingrese la ciudad." />
                                                    <div class="input-group-btn">
                                                        <input type="button" id="btnBuscar" class="btn-primary btn btn-sm"
                                                            onclick="btnBuscar_Click(this)" value="Buscar" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <div id="PanelesEstadisticas" class="hidden">
                                <div id="datosGrales" class="col-sm-12 col-md-12 col-lg-12">

                                    <div class="form-horizontal">
                                        <div class="form-group">

                                            <div class="input-group input-group-lg col-sm-3 col-md-3 col-lg-3">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-map-marker"></i></span>
                                                <input value="Ciudad" class="form-control input-lg" readonly="true" id="txtCiudad" />
                                            </div>

                                            <div class="input-group input-group-lg col-sm-3 col-md-3 col-lg-3">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                                <input value="Año" class="form-control input-lg" readonly="true" id="txtAno" />
                                            </div>

                                            <div class="input-group input-group-lg col-sm-3 col-md-3 col-lg-3">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-search"></i></span>
                                                <input class="form-control input-lg" readonly="true" id="txtConsultas" />
                                            </div>
                                        </div>
                                    </div>
                                    <input id="txtMes" type="range" step="1"
                                        oninput="cambiarRange($(this).parents('[id*=anuales]').first().attr('numero'))" min="2010" max="2014" value="2014" />
                                </div>
                                <div class="panel panel-default col-sm-12 col-md-12 col-lg-12">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a data-toggle="collapse" href="#densidad">Densidad de consultas</a>
                                        </h4>
                                    </div>
                                    <div id="densidad" class="panel-collapse collapse in">
                                        <div class="panel-body">

                                            <div class="col-sm-12 col-md-12 col-lg-12">
                                                <div id="map-0" style="height: 200px; width: 100%;"></div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="panel panel-default col-sm-6 col-md-6 col-lg-6">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a data-toggle="collapse" href="#tipoPlaya">Por Tipo de Playa</a>
                                        </h4>
                                    </div>
                                    <div id="tipoPlaya" class="panel-collapse collapse in">
                                        <div class="panel-body">
                                            <div id="consultasTipoPlaya-0" style="height: 200px;"></div>
                                        </div>
                                    </div>
                                </div>

                                <div class="panel panel-default  col-sm-6 col-md-6 col-lg-6">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a data-toggle="collapse" href="#tipoVehiculo">Por Tipo de Vehiculo</a>
                                        </h4>
                                    </div>
                                    <div id="tipoVehiculo" class="panel-collapse collapse in">
                                        <div class="panel-body">
                                            <div id="consultasTipoVehiculo-0" style="height: 200px;"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>


                     <div id="anuales-1" class="panel-collapse collapse in col-lg-6 hidden" numero="1">
                        <div class="panel-body">
                            <div id="Configuracion">
                                <div class="row">
                                    <div class="form-inline">
                                        <div class="formulario" data-bv-message="El valor es requerido" data-bv-feedbackicons-valid="glyphicon glyphicon-ok" data-bv-feedbackicons-invalid="glyphicon glyphicon-remove" data-bv-feedbackicons-validating="glyphicon glyphicon-refresh">
                                            <div class="form-group">
                                                <div class="col-lg-6">
                                                    <div class="col-lg-6">
                                                        <div class="input-group input-group-sm">
                                                            <input placeholder="Año Desde" class="form-control input-sm" id="fechaDesde"
                                                                data-bv-notempty="true" data-bv-notempty-message="Ingrese el año desde el cual se quieren ver las estadisticas." />
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <div class="input-group input-group-sm">
                                                            <input placeholder="Año Hasta" class="form-control input-sm" id="fechaHasta"
                                                                data-bv-notempty="true" data-bv-notempty-message="Ingrese el año desde el cual se quieren ver las estadisticas." />
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="input-group col-lg-6">
                                                    <input id="txtBuscar2" class="form-control input-sm autosuggest"
                                                        placeholder="Ingresá tu ciudad"
                                                        data-bv-notempty="true" data-bv-notempty-message="Ingrese la ciudad." />
                                                    <div class="input-group-btn">
                                                        <input type="button" id="btnBuscar" class="btn-primary btn btn-sm"
                                                            onclick="btnBuscar_Click(this)" value="Buscar" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <div id="PanelesEstadisticas" class="hidden">
                                <div id="datosGrales" class="col-sm-12 col-md-12 col-lg-12">

                                    <div class="form-horizontal">
                                        <div class="form-group">

                                            <div class="input-group input-group-lg col-sm-4 col-md-4 col-lg-4">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-map-marker"></i></span>
                                                <input value="Ciudad" class="form-control input-lg" readonly="true" id="txtCiudad" />
                                            </div>

                                            <div class="input-group input-group-lg col-sm-4 col-md-4 col-lg-4">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                                <input value="Año" class="form-control input-lg" readonly="true" id="txtAno" />
                                            </div>

                                            <div class="input-group input-group-lg col-sm-4 col-md-4 col-lg-4">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-search"></i></span>
                                                <input class="form-control input-lg" readonly="true" id="txtConsultas" />
                                            </div>
                                        </div>
                                    </div>
                                    <input id="txtMes" type="range" step="1"
                                        oninput="cambiarRange($(this).parents('[id*=anuales]').first().attr('numero'))" min="2010" max="2014" value="2014" />
                                </div>
                                <div class="panel panel-default col-sm-12 col-md-12 col-lg-12">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a data-toggle="collapse" href="#densidad">Densidad de consultas</a>
                                        </h4>
                                    </div>
                                    <div id="densidad" class="panel-collapse collapse in">
                                        <div class="panel-body">

                                            <div class="col-sm-12 col-md-12 col-lg-12">
                                                <div id="map-1" style="height: 200px; width: 100%;"></div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="panel panel-default col-sm-6 col-md-6 col-lg-6">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a data-toggle="collapse" href="#tipoPlaya">Por Tipo de Playa</a>
                                        </h4>
                                    </div>
                                    <div id="tipoPlaya" class="panel-collapse collapse in">
                                        <div class="panel-body">
                                            <div id="consultasTipoPlaya-1" style="height: 200px;"></div>
                                        </div>
                                    </div>
                                </div>

                                <div class="panel panel-default  col-sm-6 col-md-6 col-lg-6">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a data-toggle="collapse" href="#tipoVehiculo">Por Tipo de Vehiculo</a>
                                        </h4>
                                    </div>
                                    <div id="tipoVehiculo" class="panel-collapse collapse in">
                                        <div class="panel-body">
                                            <div id="consultasTipoVehiculo-1" style="height: 200px;"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="helpContent" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ScriptContent" runat="server">
    <!--Script de google mas-->

    <script>
        var cont = 0;

        $(document).ready(function () {
            $('.formulario').bootstrapValidator();
        });

        function btnBuscar_Click(e) {
            var id = $(e).parents('[id*=anuales]').first().attr('numero');
            if (cont == 0) { $('#btnAgregarComparacion').removeClass('hidden');}

            
            $('#anuales-' + id + ' [id=txtMes]').attr('min', ($('#anuales-' + id + ' [id=fechaDesde]').val()));
            $('#anuales-' + id + ' [id=txtMes]').attr('max', ($('#anuales-' + id + ' [id=fechaHasta]').val()));
            $('#anuales-' + id + ' [id=txtMes]').attr('value', ($('#anuales-' + id + ' [id=fechaHasta]').val()));
            $('#anuales-' + id + ' [id=txtCiudad]').val($('#anuales-' + id + ' [id=txtBuscar]').val());
            $('#anuales-' + id + ' [id=txtAno]').val($('#anuales-' + id + ' [id=txtMes]').val());
            initialize(cont);
            $('#anuales-' + id + ' [id=PanelesEstadisticas]').removeClass('hidden');
            $('#anuales-' + id + ' [id=Configuracion]').addClass('hidden');
            google.maps.event.trigger(maps[1], 'resize')
            centrarMapa(id);
        };

        function agregarComparacion() {
            cont++;
            $('#anuales-0').removeClass('col-lg-12');
            $('#anuales-0').addClass('col-lg-6');
            $('#anuales-1').removeClass('hidden');
            $('#btnAgregarComparacion').addClass('hidden');
            $('#txtBuscar').attr('id', 'txtBuscar1');
            $('#txtBuscar2').attr('id', 'txtBuscar');
            cargarGraficoCantidadTipoPlayas(0);
            cargarGraficoCantidadTipoVehiculos(0);
            google.maps.event.trigger(maps[0], 'resize')
            centrarMapa(0);

        };
    </script>
     <script>
         $("#admPlayas").removeClass("active");
         $("#admUsuarios").removeClass("active");
         $("#admEstadisticas").addClass("active");
    </script>

</asp:Content>
