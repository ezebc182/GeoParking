<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Estadisticas.aspx.cs" Inherits="Web2.Estadisticas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="js/bootstrapformhelpers/css/bootstrap-formhelpers.min.css" rel="stylesheet" />
    <link href="js/select2-4.0.0-beta.3/css/select2.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <asp:HiddenField ID="hdPlayas" runat="server"/>
<asp:HiddenField ID="hdTiposVehiculos" runat="server"/>
<asp:HiddenField ID="hdZonas" runat="server"/>
    <asp:HiddenField ID="hdTiposPlayas" runat="server"/>

    <div class="panel panel-primary">
        <div class="panel-heading">
            <div class="row">
                <div class="col-lg-3">
                    <div class="panel-title">Estadisticas</div>
                </div>
                <div class="col-lg-3 pull-right">
                    <div class="dropdown pull-right">
                        <button class="btn btn-success dropdown-toggle" type="button" data-toggle="dropdown" aria-expanded="true">
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
                            <div class="pull-left">
                                <button class="btn btn-success" type="button"><span class="fa fa-search">Buscar</span></button>
                            </div>
                            <div class="pull-right"><i id="minMax" class="fa fa-square-o fa-lg"></i></div>
                        </div>
                    </div>
                </div>
                <div class="panel-body" style="display: none;">
                    <div id="divFiltros" class="col-lg-4">
                        <div class="form-group col-lg-12">
                            <div class="col-lg-3" style="padding-left: 0px;">
                                <label class="form-label">Zonas: </label>
                            </div>
                            <div class="col-lg-9">
                                <select id="ddlZonas" data-multiple="true"></select>
                            </div>
                        </div>
                        <div class="form-group col-lg-12">
                            <div class="col-lg-3" style="padding-left: 0px;">
                                <label class="form-label">Playas: </label>
                            </div>
                            <div class="col-lg-9">
                                <select id="ddlPlayas" data-multiple="true"></select>
                            </div>
                        </div>
                        <div class="form-group col-lg-12">
                            <div class="col-lg-3" style="padding-left: 0px;">
                                <label class="form-label">Tipo de playa:</label>
                            </div>
                            <div class="col-lg-9">
                                <select id="ddlTipoPlaya" data-multiple="true"></select>
                            </div>
                        </div>
                        <div class="form-group col-lg-12">
                            <div class="col-lg-3" style="padding-left: 0px;">
                                <label class="form-label">Tipo de vehiculo:</label>
                            </div>
                            <div class="col-lg-9">
                                <select id="ddlTipoVehiculo" data-multiple="true"></select>
                            </div>
                        </div>
                    </div>
                    <div id="divEstadistica" class="col-lg-8" data-value="">
                        <div class="pull-left">
                            <button class="glyphicon glyphicon-chevron-left" type="button" onclick="menuFiltros(this)"></button>
                        </div>
                        <div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="js/bootstrapformhelpers/js/bootstrap-formhelpers.js"></script>
    <script src="js/estadisticas.js" type="text/javascript"></script>
    <script src="js/select2-4.0.0-beta.3/js/select2.min.js" type="text/javascript"></script>
    <script>
        $(document).ready(function () {

        });


    </script>
</asp:Content>
