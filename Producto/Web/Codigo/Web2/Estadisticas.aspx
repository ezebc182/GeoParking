<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Estadisticas.aspx.cs" Inherits="Web2.Estadisticas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="js/bootstrapformhelpers/css/bootstrap-formhelpers.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <div class="row">
                <div class="col-lg-3">
                    <div class="panel-title">Estadisticas</div>
                </div>
                <div class="col-lg-3 pull-right">
                    <div class="dropdown pull-right">
                        <button class="btn btn-success dropdown-toggle" type="button" data-toggle="dropdown" aria-expanded="true">
                            Nueva <span class="gltphicon glyphicon-plus"></span>
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
           <%-- <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-lg-1">
                            <h3 class="panel-title">Historico</h3>
                        </div>
                        <div class="col-lg-3">
                            <div class="col-lg-6">
                                <label class="control-label pull-right">Buscar Por:</label>
                            </div>
                            <div class="col-lg-6">
                                <div class="bfh-selectbox" data-name="ddlBuscarPor">
                                    <div data-value="1">Playa</div>
                                    <div data-value="2">Zona</div>
                                    <div data-value="3">Ciudad</div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="col-lg-3">
                                <label class="control-label">Desde:</label>
                            </div>
                            <div class="col-lg-9 pul-left">
                                <div class="bfh-datepicker" data-placeholder="Fecha Desde" data-min="01/15/2013" data-max="today"></div>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="col-lg-3">
                                <label class="control-label">Hasta:</label>
                            </div>
                            <div class="col-lg-9 pull-left">
                                <div class="bfh-datepicker" data-placeholder="Fecha Hasta" data-min="01/15/2013" data-max="today"></div>
                            </div>
                        </div>
                        <div class="col-lg-2">
                            <div class="pull-right"><i id="minMax" class="fa fa-minus-square-o fa-lg"></i></div>
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <div id="divFiltros" class="col-lg-4" style="display: none;">
                        <div class="bfh-selectbox" data-name="ddlZonas" style="display: none;">
                        </div>
                        <div class="bfh-selectbox" data-name="ddlPlayas" style="display: none;">
                        </div>
                        <div class="bfh-selectbox" data-name="ddlTipoPlaya">
                        </div>
                        <div class="bfh-selectbox" data-name="ddlTipoVehiculo">
                        </div>
                    </div>
                    <div id="divEstadistica" data-value="">
                        <div class="pull-left">
                            <button class="glyphicon glyphicon-option-vertical" type="button" onclick="$('#divFiltros').toggle(150);"></button>
                        </div>
                    </div>
                </div>
            </div>--%>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="js/bootstrapformhelpers/js/bootstrap-formhelpers.js"></script>
    <script src="js/estadisticas.js" type="text/javascript"></script>
    <script>
        $(document).ready(function () {
            
        });

        
    </script>
</asp:Content>
