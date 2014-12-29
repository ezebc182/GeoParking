﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeBehind="AdministracionPlayas.aspx.cs" Inherits="Web2.AdministracionPlayas" %>

<%@ Register Src="~/Mensajes/Confirmacion.ascx" TagName="confirmacion" TagPrefix="msjes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="bootstrap3-editable/css/bootstrap-editable.css" rel="stylesheet" />
    <link href="bootstrapformhelpers/css/bootstrap-formhelpers.min.css" rel="stylesheet" />
    <link href="js/GoogleMapsAdministracionPlaya.js" rel="stylesheet" />

<style>
    .pac-container {
        z-index:1040;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">

    <msjes:confirmacion runat="server" ID="msjeConfirmacion"></msjes:confirmacion>

    <%-- Id playa en edicion o viendo --%>
    <asp:HiddenField runat="server" ID="hfIdPlaya" />

    <%-- Modal Playa --%>

    <div class="modal fade" id="modificarPlaya">
        <div class="modal-dialog  modal-lg ">
            <div class=" modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h1 id="Titulo" class="modal-title">Registrar/Modificar playa</h1>
                </div>
                <div class="modal-body">
                    <div class="alert alert-danger hidden" id="divAlertError">
                        <p id="lblMensajeError">Error</p>
                    </div>
                    <div class="alert alert-success hidden" id="divAlertExito">
                        <p id="lblMensajeExito">Exito</p>
                    </div>




                    <div runat="server" id="divTabs">
                        <ul class="nav nav-tabs" id="myTab">
                            <li id="tabDatosGrales" class="active"><a href="#datosGrales" data-toggle="tab">Datos Generales</a></li>
                            <li id="tabDireccion"><a href="#direccion" data-toggle="tab">Direccion</a></li>
                        </ul>


                        <div class="tab-content" style="margin: 20px;">

                            <div class="tab-pane fade active in" id="datosGrales">
                                <div class="clearfix"></div>
                                <div class="formulario" data-bv-message="El valor es requerido" data-bv-feedbackicons-valid="glyphicon glyphicon-ok" data-bv-feedbackicons-invalid="glyphicon glyphicon-remove" data-bv-feedbackicons-validating="glyphicon glyphicon-refresh">

                                    <%-- Nombre --%>
                                    <div class="row">
                                        <div class="col-lg-6 col-md-6 col-sm-6 pull-left">
                                            <div class="col-lg-8 col-md-8 col-sm-8">
                                                <div class="form-group">
                                                    <label for="txtNombre" class="control-label">Nombre:</label>
                                                    <input class="form-control" id="txtNombre" data-bv-notempty="true" data-bv-notempty-message="El nombre es requerido." />
                                                </div>
                                            </div>
                                        </div>
                                        <%-- Tipo Playa --%>
                                        <div class="col-lg-6 col-md-6 col-sm-6 pull-left">
                                            <div class="col-lg-8 col-md-8 col-sm-8">
                                                <div class="form-group">
                                                    <label for="ddlTipoPlaya" class="control-label">Tipo de Playa:</label>
                                                    <asp:DropDownList runat="server" ID="ddlTipoPlaya" CssClass="form-control " data-bv-notempty="true" data-bv-notempty-message="Seleccione un tipo." />
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <%-- Telefono --%>
                                        <div class="col-lg-6 col-md-6 col-sm-6 pull-left">
                                            <div class="col-lg-8 col-md-8 col-sm-8">
                                                <div class="form-group">
                                                    <label for="txtTelefono" class="control-label">Telefono:</label>
                                                    <asp:TextBox runat="server" CssClass="form-control" type="tel" ID="txtTelefono" data-bv-notempty="true" data-bv-notempty-message="El teléfono es requerido" data-bv-regexp="true" data-bv-regexp-regexp="\b\d{3,5}[-.]?\d{3}[-.]?\d*\b" data-bv-regexp-message="Ingrese un número telefónico correcto." />
                                                </div>
                                            </div>
                                        </div>
                                        <%-- Mail --%>
                                        <div class="col-lg-6 col-md-6 col-sm-6 pull-right">
                                            <div class="col-lg-8 col-md-8 col-sm-8 ">
                                                <div class="form-group">
                                                    <label for="txtMail" class="control-label">Email:</label>
                                                    <asp:TextBox runat="server" type="email" CssClass="form-control" ID="txtMail" data-bv-notempty="true" data-bv-notempty-message="El email es requerido" data-bv-emailaddress-message="Ingrese un formato de email correcto." />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <%-- Horario --%>
                                    <h4>Horarios</h4>
                                    <div class="well">
                                        <div class="row">
                                            <div class="col-lg-4 col-md-4 col-sm-4 pull-left">
                                                <div class="form-group ">
                                                    <label for="ddlDias" class="control-label">Dias:</label>
                                                    <asp:DropDownList runat="server" ID="ddlDias" CssClass="form-control " data-bv-notempty="true" data-bv-notempty-message="Seleccione el dia" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4 col-md-4 col-sm-4">
                                                <div class="form-group ">
                                                    <label for="bfhDesde" class="control-label">Desde:</label>
                                                    <div id="txtDesde" class="bfh-timepicker" data-time="08:00" style="background-color: white;"></div>
                                                </div>
                                            </div>
                                            <div class="col-lg-4 col-md-4 col-sm-4 pull-right">
                                                <div class="form-group ">
                                                    <label for="txtHasta" class="control-label">Hasta:</label>
                                                    <div id="txtHasta" class="bfh-timepicker" data-time="22:00" style="background-color: white;"></div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%-- Servicios --%>
                                    <asp:HiddenField ID="hfTiempos" runat="server" />
                                    <h4>Servicios</h4>
                                    <div class="row">
                                        <div class="col-lg-6 col-md-6 col-sm-6 pull-left">
                                            <div class="col-lg-6 col-md-6 col-sm-6 pull-left">
                                                <div class="form-group ">
                                                    <label for="ddlTipoVehiculo" class="control-label">Tipo Vehiculo:</label>
                                                    <asp:DropDownList runat="server" ID="ddlTipoVehiculo" CssClass="form-control" />
                                                </div>
                                            </div>

                                            <div class="col-lg-6 col-md-6 col-sm-6 ">
                                                <div class="form-group ">
                                                    <label for="txtCapacidad" class="control-label">Capacidad:</label>
                                                    <div class="controls">
                                                        <div class="input-group">
                                                            <input class="form-control bfh-number" id="txtCapacidad" />
                                                            <div class="input-group-btn">
                                                                <button id="btnAgregarServicio" type="button" class="btn btn-success disabled">Agregar</button>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div>
                                        <table id="tbServicios" class="table table-hover table-responsive">
                                            <thead id="tbServiciosHead">
                                            </thead>
                                            <tbody id="tbServiciosBody">
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                                <%--<div class="form-group">
                                        <domicilios:domicilios runat="server" id="ucDomicilios" onerrorhandler="MostrarErrorDomicilio"></domicilios:domicilios>
                                        <div class="col-md-2 form-group pull-right">
                                            <button class="btn btn-primary pull-left disabled " id="btnPaso1_1"><span class='glyphicon glyphicon-chevron-left'></span></button>
                                            <button class="btn btn-primary pull-right" id="btnPaso1_2" data-toggle="tab" data-target="#horarios" onclick="javascript:abrirTab(this.id)"><span class='glyphicon glyphicon-chevron-right'></span></button>
                                        </div>

                                    </div>--%>
                            </div>

                            <div class="tab-pane fade" id="direccion">

                                <h4>Direcciones</h4>
                                <div class="row">
                                    <div class="col-lg-4 col-md-4 col-sm-4 pull-left">
                                        <div class="form-group ">
                                            <label for="txtBuscar" class="control-label ">Ciudad:</label>
                                            <input id="txtBuscar" type="text" class="form-control autocompleteCiudad" />
                                        </div>
                                    </div>

                                    <div class="col-lg-8 col-md-8 col-sm-8">
                                        <div class="col-lg-5 col-md-5 col-sm-5">
                                            <div class="form-group ">
                                                <label for="txtCalle" class="control-label">Calle:</label>
                                                <input id="txtCalle" class="form-control" type="text" />
                                            </div>
                                        </div>

                                        <div class="col-lg-6 col-md-6 col-sm-6 ">
                                            <div class="form-group ">
                                                <label for="txtNumero" class="control-label">Número:</label>
                                                <div class="controls">
                                                    <div class="input-group">
                                                        <input class="form-control" type="number" id="txtNumero" />

                                                        <div class="input-group-btn">
                                                            <button id="btnBuscarEnMapa" type="button" class="glyphicon glyphicon-map-marker btn btn-warning"
                                                                onclick="codeAddress()">
                                                            </button>
                                                            <button id="btnAgregarDireccion" type="button"
                                                                class="glyphicon glyphicon-plus btn btn-success">
                                                            </button>
                                                            <button id="btnAceptarEdicionDireccion" type="button"
                                                                class="glyphicon glyphicon-ok btn btn-success" style="visibility: hidden;">
                                                            </button>
                                                            <button id="btnCancelarEdicionDireccion" type="button"
                                                                class="glyphicon glyphicon-remove btn btn-danger" style="display: none;">
                                                            </button>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                </div>
                                <div id="divMapa">
                                    <input id="latitud" type="hidden" />
                                    <input id="longitud" type="hidden" />
                                    <div class="form-group">
                                        <div id="pnlMapa">
                                            <div id="map-canvas" style="height: 300px"></div>
                                        </div>

                                    </div>
                                </div>
                                <div>
                                    <table id="tbDirecciones" class="table table-hover table-responsive">
                                        <thead>
                                            <tr>
                                                <th>Calle</th>
                                                <th>Numero</th>
                                                <th>Ciudad</th>
                                                <th style="display: none;">Latitud</th>
                                                <th style="display: none;">Longitud</th>
                                            </tr>
                                        </thead>
                                        <tbody id="tbDireccionesBody">
                                        </tbody>
                                    </table>
                                </div>

                            </div>
                        </div>
                    </div>

                    <div class="modal-footer">
                        <button id="btnCancelar" type="button" class="btn btn-lg" data-dismiss="modal">Cancelar</button>
                        <button id="btnGuardar" type="button" class="btn btn-success btn-lg">Guardar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>



    <div class="container-fluid">
        <div class="jumbotron" style="margin-top: 5%;">
            <div class="page-header">
                <h1>Administración de playas</h1>
            </div>

            <div class="form-group" id="busquedaPlayas">
                <div class="col-md-4">
                    <input id="txtBuscarCiudades" class="form-control input-lg autocompleteCiudad" runat="server"
                        placeholder="Ciudad" autofocus />
                </div>
                <div class="col-md-4">
                    <input id="txtFiltroNombre" class="form-control input-lg" placeholder="Nombre de playa" />
                </div>
                <div class="col-md-4">
                    <button class="btn-primary btn btn-lg glyphicon glyphicon-search" id="btnBuscar" type="button"></button>
                    <button class="btn-success btn btn-lg glyphicon glyphicon-plus" id="btnNuevaPlaya" type="button"></button>
                </div>
            </div>

        </div>
    </div>

                    <div id="pnlResultados" class="container-fluid" style="display:none;">

                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                Resultados <span style="background-color: white; color: black;" class="badge" id="cantidadPlayas"></span>
                            </div>

                            <div class=" panel-body">
                                <div id="resultadosBusqueda">
                                    <table id="tbPlayas" class="table table-hover table-responsive">
                                        <thead>
                                            <tr>
                                                <th>Nombre</th>
                                                <th>Tipo</th>
                                                <th>Calle</th>
                                                <th>Número</th>
                                                <th>Ciudad</th>
                                                <th>Vehiculos</th>
                                                <th>Opciones(ver editar eliminar)</th>
                                            </tr>
                                        </thead>
                                        <tbody id="tbPlayasBody">

                                        </tbody>

                                    </table>

                                </div>
                            </div>
                        </div>
                    </div>

</asp:Content>

<asp:Content runat="server" ID="Script" ContentPlaceHolderID="ScriptContent">
    <%--<script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>--%>
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&libraries=places&sensor=false"></script>
    <script src="js/bootstrapValidator.min.js"></script>
    <script src="js/autocompleteCiudades.js"></script>
    <script src="bootstrap3-editable/js/bootstrap-editable.min.js"></script>
    <script src="bootstrapformhelpers/js/bootstrap-formhelpers.js"></script>
    <script src="js/GoogleMapsAdministracionPlaya.js"></script>
    <script src="js/administracionPlayas.js"></script>
    <script src="js/entidades.js"></script>
    <script type="text/javascript">

        
        $(document).ready(new function () {

            $('[id*=btnAgregarServicio]').on("click", function () {

                var servicioNuevo = new servicio(0, 0, $('[id*=ddlTipoVehiculo]').val(), $('[id*=txtCapacidad]').val(), {});

                servicios.agregar(servicioNuevo);
            });
            $('[id*=btnAgregarDireccion]').on("click", function () {
                var calle = $('[id*=txtCalle]').first().val();
                var numero = $('[id*=txtNumero]').first().val();
                var ciudad = $('[id*=txtBuscar]').first().val();
                var latitud = $('[id*=latitud]').first().val();
                var longitud = $('[id*=longitud]').first().val();
                var direccionNueva = new direccion(0, calle, numero, ciudad, latitud, longitud);

                direcciones.agregar(direccionNueva);
            });

            $('[id*=btnGuardar]').on("click", function () {
                playa.guardar();
            });

            $('[id*=btnNuevaPlaya]').on("click", function () {
                playa.iniciar();
                $('#modificarPlaya').modal({
                    backdrop: false,
                    keyboard: false,
                    show: true
                });
            });

            $('#tabDireccion').on("click", function () {
                direcciones.iniciar();
                setTimeout(function () { GoogleMaps.resize(); }, 200);
            });

            $('[id*=ddlTipoVehiculo]').on("change", function (e) {
                var valor = $('[id*=ddlTipoVehiculo]').find(':selected').val();
                if (valor > 0) {
                    $('[id*=btnAgregarServicio]').prop("disabled", false);
                }
                else $('[id*=btnAgregarServicio]').prop("disabled", true);
            });

        });

    </script>
</asp:Content>
