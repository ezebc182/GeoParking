<%@ Page Title="Reportes y Estadisticas" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Estadisticas.aspx.cs" Inherits="Web2.Estadisticas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="js/bootstrapformhelpers/css/bootstrap-formhelpers.min.css" rel="stylesheet" />
    <link href="js/select2-4.0.0-beta.3/css/select2.min.css" rel="stylesheet" />
    <link href="css/morris.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <asp:HiddenField ID="hdUsuarioId" runat="server" />

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



        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&libraries=places,visualization&sensor=false"></script>
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
