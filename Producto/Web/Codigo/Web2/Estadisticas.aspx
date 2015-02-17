<%@ Page Title="Reportes y Estadisticas" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Estadisticas.aspx.cs" Inherits="Web2.Estadisticas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="js/bootstrapformhelpers/css/bootstrap-formhelpers.min.css" rel="stylesheet" />
    <link href="js/select2-4.0.0-beta.3/css/select2.min.css" rel="stylesheet" />
    <link href="css/morris.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <asp:HiddenField ID="hdPlayas" runat="server" />
    <asp:HiddenField ID="hdTiposVehiculos" runat="server" />
    <asp:HiddenField ID="hdZonas" runat="server" />
    <asp:HiddenField ID="hdTiposPlayas" runat="server" />
    <asp:HiddenField ID="txtIdPlace" ClientIDMode="Static" runat="server" />
    
    <div class="panel panel-primary">
        <div class="panel-heading">
            <div class="row">
                <div class="col-lg-3">
                    <div class="col-lg-4">
                        <div class="panel-title">Estadisticas</div>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="col-lg-3">
                        <label class="control-label">Ciudad: </label>
                    </div>
                    <div class="col-lg-7">
                        <asp:TextBox ID="txtBuscarCiudad" CssClass="form-control autocompleteCiudad" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 pull-right">
                    <div class="dropdown pull-right">
                        <button class="btn btn-success dropdown-toggle" id="btnNueva" type="button" data-toggle="dropdown" aria-expanded="true" disabled>
                            <span class="glyphicon glyphicon-plus">Nueva</span>
                        </button>
                        <ul class="dropdown-menu" role="menu" aria-labelledby="dropdownMenu1">
                            <li role="presentation"><a id="btnNuevaEstadisticaTiempoReal" role="menuitem" tabindex="-1" href="#">Tiempo Real</a></li>
                            <li role="presentation"><a id="btnNuevaEstadisticaHistorica" role="menuitem" tabindex="-1" href="#">Historica</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body" id="divContenedorEstadisticas">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-lg-2">
                            <div class="col-lg-6">
                                <label class="control-label pull-right">Estadistica:</label>
                            </div>
                            <div class="col-lg-6">
                                <select id="ddlEstadistica">
                                    <option value="1">Disponibilidad</option>
                                    <option value="2">Consultas</option>
                                </select>
                            </div>
                        </div>
                        <div class="col-lg-2">
                            <div class="col-lg-6">
                                <label class="control-label pull-right">Buscar Por:</label>
                            </div>
                            <div class="col-lg-6">
                                <select id="ddlBuscarPor">
                                    <option value="1">Playa</option>
                                    <option value="2">Zona</option>
                                </select>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="col-lg-3">
                                <label class="control-label">Desde:</label>
                            </div>
                            <div class="col-lg-9 pul-left">
                                <div id="fechaDesde" class="bfh-datepicker" data-placeholder="Fecha Desde" data-min="01/15/2013" data-format="d-m-y" data-max="today"></div>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="col-lg-3">
                                <label class="control-label">Hasta:</label>
                            </div>
                            <div class="col-lg-9 pull-left">
                                <div id="fechaHasta" class="bfh-datepicker" data-placeholder="Fecha Hasta" data-min="01/15/2013" data-format="d-m-y" data-max="today"></div>
                            </div>
                        </div>
                        <div class="col-lg-2">
                            <div class="pull-left">
                                <button id="btnBuscarEstadisticas" class="btn btn-success" type="button"><span class="fa fa-search">Buscar</span></button>
                            </div>
                            <div class="pull-right"><i id="minMax" class="fa fa-square-o fa-lg"></i></div>
                        </div>
                    </div>
                </div>
                <div class="panel-body" style="display: none;">
                    <div id="divFiltros" class="col-lg-4">
                        <div class="form-group col-lg-12">
                            <input id="chkZonas" type="checkbox" />
                            <label class="form-label" for="ddlZonas">Zonas: </label>
                            <select id="ddlZonas" style="width: 100%;" multiple></select>
                        </div>
                        <div class="form-group col-lg-12">
                            <input id="chkPlayas" type="checkbox" />
                            <label class="form-label" for="ddlPlayas">Playas: </label>
                            <select id="ddlPlayas" style="width: 100%;" multiple></select>
                        </div>
                        <div class="form-group col-lg-12">
                            <input id="chkTipoPlaya" type="checkbox" />
                            <label class="form-label" for="ddlTipoPlaya">Tipo de playa:</label>
                            <select id="ddlTipoPlaya" style="width: 100%;" multiple></select>
                        </div>
                        <div class="form-group col-lg-12">
                            <input id="chkTipoVehiculo" type="checkbox" />
                            <label class="form-label" for="ddlTipoVehiculo">Tipo de vehiculo:</label>
                            <select id="ddlTipoVehiculo" class="form-control" style="width: 100%;" multiple></select>
                        </div>
                    </div>
                    <div class="col-lg-8">
                        <div class="row">
                            <div class="pull-left">
                                <button class="glyphicon glyphicon-chevron-left" type="button" onclick="menuFiltros(this)"></button>
                            </div>
                            <div class="col-lg-4">
                                <div class="col-lg-8">
                                    <label class="form-label">Agrupar Por: </label>
                                </div>
                                <div class="col-lg-4">
                                    <select id="ddlAgruparPor" style="width: 100%;">
                                        <option></option>
                                        <option value="1" selected>Zonas</option>
                                        <option value="2">Playas</option>
                                        <option value="3">Tipos de Playa</option>
                                        <option value="4">Tipos de Vehiculo</option>
                                    </select>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="col-lg-8">
                                    <label class="form-label">Eje X: </label>
                                </div>
                                <div class="col-lg-4">
                                    <select id="ddlEscala" style="width: 100%;">
                                        <option></option>
                                        <option value="1" selected>Años</option>
                                        <option value="2">Meses</option>
                                    </select>
                                </div>
                            </div>
                           <div class="dropdown pull-right">
                        <button class="btn btn-success dropdown-toggle" type="button" data-toggle="dropdown" aria-expanded="true">
                            <span class="glyphicon glyphicon-stats"></span>
                        </button>
                        <ul class="dropdown-menu" role="menu" aria-labelledby="dropdownMenu1" id="ddlCambiarGrafico">
                            <li role="presentation"><a id="btnCambiarATorta" role="menuitem" data-value="1" tabindex="-1" href="#">Gráfico de Torta</a></li>
                            <li role="presentation"><a id="btnCambiarABarras" role="menuitem" data-value="2" tabindex="-1" href="#">Gráfico de Barras</a></li>
                        <li role="presentation"><a id="btnCambiarALineas" role="menuitem" data-value="3" tabindex="-1" href="#">Gráfico de Lineas</a></li>
                        <li role="presentation"><a id="btnCambiarAAreas" role="menuitem" data-value="4" tabindex="-1" href="#">Gráfico de Áreas</a></li>
                        </ul>
                    </div>
                        </div>
                        <div id="divEstadistica-'+estadisticas.length+'" class="col-lg-8" style="height: 300px" data-value="'+estadisticas.length+'"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&libraries=places&sensor=false"></script>
    <script src="js/autocompleteCiudades.js"></script>
    <script src="js/bootstrapformhelpers/js/bootstrap-formhelpers.js"></script>
    <script src="http://cdnjs.cloudflare.com/ajax/libs/raphael/2.1.0/raphael-min.js"></script>
    <script src="js/morris.min.js"></script>
    <script src="js/estadisticas.js" type="text/javascript"></script>
    <script src="js/select2-4.0.0-beta.3/js/select2.min.js" type="text/javascript"></script>
    <script>
        $(document).ready(function () {
            minMax();

            $('#ddlTipoVehiculo').select2({
                data: tiposVehiculos
            });
            $('#ddlTipoPlaya').select2({
                data: tiposPlayas
            });
            $('#ddlZonas').select2({
                data: zonas
            });
            $('#ddlPlayas').select2();

            $('input[type=checkbox]').off('change').on('change', function () {
                var select = $(this).next().next();
                if ($(this).is(':checked')) {
                    select.prop('disabled', !$(this).is(':checked'));
                    select.off('change').on('change', function () {
                        //estadisticas[i].filtrar
                    });
                }
                else {
                    select.prop('disabled', !$(this).is(':checked'));
                    select.off('change');
                }
            })
        });

        $('[id*=txtBuscarCiudad]').focusout(function () {
            if ($('[id*=txtBuscarCiudad]').val() != "") {
                $('#btnNueva').removeAttr('disabled');
                buscarPlayas();
            }
            else {
                $('#btnNueva').attr('disabled', true);
            }
        });

        function buscarPlayas() {
            var ciudad = $('[id*=txtBuscarCiudad]').val();
            $.ajax({
                type: "POST",
                url: "Estadisticas.aspx/BuscarPlayas",
                data: "{'ciudad': '" + ciudad + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    $('[id*=hdPlayas]').val(response.d);
                }
            });
        };
    </script>
</asp:Content>
