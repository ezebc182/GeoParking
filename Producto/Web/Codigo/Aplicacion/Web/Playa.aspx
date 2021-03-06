﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Playa.aspx.cs" Inherits="Web2.Playa" %>

<%@ Register Src="~/Controles/Domicilio.ascx" TagName="domicilios" TagPrefix="domicilios" %>
<%@ Register Src="~/Controles/Precios.ascx" TagName="precios" TagPrefix="precios" %>
<%@ Register Src="~/Controles/Horarios.ascx" TagName="horarios" TagPrefix="horarios" %>
<%@ Register Src="~/Controles/Servicio.ascx" TagName="servicios" TagPrefix="servicios" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" href="./Styles/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="./Styles/MapaAbmPlaya.css" type="text/css">
    <!--Script de google mas-->
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>


    <!--Estilo para el autocomplete-->
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css"
        rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="TopContent" runat="server">
    
    <div class="modal fade" id="modificarPlaya">
        <div class="modal-dialog  modal-lg ">
            <div class=" modal-content">
                <div class="modal-header">
                    <asp:UpdatePanel ID="upTituloModal" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <asp:Label ID="Titulo" runat="server" CssClass="modal-title" Text="Registrar/Modificar playa"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="upModalBody" runat="server">
                        <ContentTemplate>
                            <div class="alert alert-danger hidden" id="divAlertError" runat="server">
                                <asp:Label ID="lblMensajeError" runat="server"></asp:Label>
                            </div>
                            <div runat="server" class="hidden" id="divAlertExito">
                                <asp:Label ID="lblMensajeExito" runat="server"></asp:Label>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div runat="server" id="divModal" class="form-horizontal" role="form">
                        <ul class="nav nav-tabs" id="myTab">
                            <li runat="server" id="tabDatosGrales" class="active"><a href="#datosGrales" data-toggle="tab" onclick="habilitarBotonGuardar(false)">1. Datos Generales</a></li>
                            <li runat="server" id="tabHorarios"><a href="#horarios" data-toggle="tab" onclick="habilitarBotonGuardar(false)">2. Horarios</a></li>
                            <li runat="server" id="tabPrecios"><a href="#precios" data-toggle="tab" onclick="habilitarBotonGuardar(true)">3. Precios</a></li>
                        </ul>


                        <div class="tab-content" style="margin: 20px;">

                            <div class="tab-pane fade active in" id="datosGrales">
                                <div class="clearfix"></div>
                                <asp:UpdatePanel runat="server" ID="upDatosGrales">
                                    <ContentTemplate>
                                        <div class="formulario" data-bv-message="El valor es requerido" data-bv-feedbackicons-valid="glyphicon glyphicon-ok" data-bv-feedbackicons-invalid="glyphicon glyphicon-remove" data-bv-feedbackicons-validating="glyphicon glyphicon-refresh">
                                            <div class="form-group " id="nombrePlaya">
                                                <asp:HiddenField runat="server" ID="hfIdPlaya" />
                                                <label for="txtNombre" class="col-sm-2 col-md-2 col-lg-2 control-label">Nombre</label>
                                                <div class="col-sm-10 col-md-10 col-lg-10 col-md-10 col-lg-10">
                                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" data-bv-notempty="true" data-bv-notempty-message="El nombre es requerido." />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="txtTelefono" class="col-sm-2 col-md-2 col-lg-2 col-md-2 col-lg-2 control-label">Telefono</label>
                                                <div class="col-sm-3 col-md-3 col-lg-3">
                                                    <asp:TextBox runat="server" CssClass="form-control" type="tel" ID="txtTelefono" data-bv-notempty="true" data-bv-notempty-message="El teléfono es requerido" data-bv-regexp="true" data-bv-regexp-regexp="\b\d{3,5}[-.]?\d{3}[-.]?\d*\b" data-bv-regexp-message="Ingrese un número telefónico correcto." />
                                                </div>
                                                <label for="txtMail" class="col-sm-2 col-md-2 col-lg-2 control-label">Email</label>
                                                <div class="col-sm-5 col-md-5 col-lg-5">
                                                    <asp:TextBox runat="server" type="email" CssClass="form-control" ID="txtMail" data-bv-notempty="true" data-bv-notempty-message="El email es requerido" data-bv-emailaddress-message="Ingrese un formato de email correcto." />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="ddlTipoPlaya" class="col-sm-2 col-md-2 col-lg-2 control-label">Tipo de Playa</label>
                                                <div class="col-sm-10 col-md-10 col-lg-10">
                                                    <asp:DropDownList runat="server" ID="ddlTipoPlaya" CssClass="form-control " data-bv-notempty="true" data-bv-notempty-message="Seleccione un tipo." />
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>


                                <div class="form-group ">
                                    <servicios:servicios runat="server" ID="ucServicios" OnErrorHandler="MostrarErrorServicio"></servicios:servicios>
                                </div>

                                <div class="form-group">
                                    <domicilios:domicilios runat="server" ID="ucDomicilios" OnErrorHandler="MostrarErrorDomicilio"></domicilios:domicilios>
                                    <div class="col-md-2 form-group pull-right">
                                        <button class="btn btn-primary pull-left disabled " id="btnPaso1_1"><span class='glyphicon glyphicon-chevron-left'></span></button>
                                        <button class="btn btn-primary pull-right" id="btnPaso1_2" data-toggle="tab" data-target="#horarios" onclick="javascript:abrirTab(this.id)"><span class='glyphicon glyphicon-chevron-right'></span></button>
                                    </div>

                                </div>


                            </div>

                            <div class="tab-pane" id="horarios">
                                <div class="form-group ">
                                    <horarios:horarios runat="server" ID="ucHorarios" OnErrorHandler="MostrarErrorHorario"></horarios:horarios>
                                    <div class="col-md-2 form-group pull-right">
                                        <a href="#" class="btn btn-primary pull-left" id="btnPaso2_1" data-toggle="tab" data-target="#datosGrales" onclick="javascript:abrirTab(this.id)"><span class='glyphicon glyphicon-chevron-left'></span></a>
                                        <a href="#" class="btn btn-primary pull-right" id="btnPaso2_3" data-toggle="tab" data-target="#precios" onclick="javascript:abrirTab(this.id)"><span class='glyphicon glyphicon-chevron-right'></span></a>

                                    </div>
                                </div>
                            </div>

                            <div class="tab-pane" id="precios">
                                    <precios:precios runat="server" ID="ucPrecios" OnErrorHandler="MostrarErrorPrecio"></precios:precios>
                                    <div class="col-md-2 form-group pull-right">
                                        <a href="#" class="btn btn-primary pull-left" id="btnPaso3_2" data-toggle="tab" data-target="#horarios" onclick="javascript:abrirTab(this.id)"><span class='glyphicon glyphicon-chevron-left'></span></a>
                                        <a href="#" class="btn btn-primary pull-right disabled" id="btnPaso3_3"><span class='glyphicon glyphicon-chevron-right'></span></a>
                                    </div>

                                </div>

                        </div>
                    </div>
                    <button id="btnAceptar" runat="server" class="btn hidden" data-dismiss="modal">Aceptar</button>
                </div>
                <div class="modal-footer">
                    <asp:UpdatePanel runat="server" ID="upBotones" UpdateMode="Always" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-lg" OnClick="btnCancelar_Click" data-dismiss="modal" Text="Cancelar"></asp:Button>
                            <asp:Button ID="btnGuardar" runat="server" CssClass="btn disabled btn-success btn-lg" OnClick="btnGuardar_Click" Text="Guardar"></asp:Button>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:UpdatePanel ID="upBusqueda" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="container-fluid">
                    <div class="jumbotron" style="margin-top: 5%;">
                        <div class="page-header">
                            <h1>Administración de playas</h1>
                        </div>
                        <div class="form-horizontal" role="form">
                            <div class="form-group" id="busquedaPlayas">
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtBuscar" CssClass="form-control input-lg autosuggest" runat="server"
                                        ClientIDMode="Static" placeholder="Ciudad" autofocus></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtFiltroNombre" CssClass="form-control input-lg" runat="server" placeholder="Nombre de playa">
                                    </asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:LinkButton runat="server" CssClass="btn-primary btn btn-lg" ID="btnBuscar" Text="Buscar" OnClick="btnBuscar_Click"></asp:LinkButton>
                                    <asp:LinkButton runat="server" CssClass="btn-success btn btn-lg" ID="btnNuevo" Text="Nueva" OnClick="btnNuevo_Click" OnClientClick="abrirModalPlaya()"></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>


                    <!-- Resultados de búsqueda -->


                    <asp:HiddenField ID="hfFilasGrilla" runat="server" />
                    <div id="pnlResultados" runat="server" class="container-fluid" visible="false">

                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                Resultados <span style="background-color: white; color: black;" class="badge" id="cantidadPlayas"></span>
                            </div>

                            <div class=" panel-body">
                                <div id="resultadosBusqueda">
                                    <asp:GridView ID="gvResultados" runat="server" DataKeyNames="Id" CssClass="table table-hover table-responsive"
                                        AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" EmptyDataText="No se encontraron Playas para los filtros utilizados"
                                        OnRowCommand="gvResultados_RowCommand" OnRowDataBound="gvResultados_RowDataBound">
                                        <Columns>
                                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                            <asp:BoundField DataField="TipoPlayaStr" HeaderText="Tipo" />
                                            <asp:BoundField DataField="Calle" HeaderText="Calle" />
                                            <asp:BoundField DataField="Numero" HeaderText="Numero" />
                                            <asp:BoundField DataField="Ciudad" HeaderText="Ciudad" />
                                            <asp:BoundField DataField="Provincia" HeaderText="Provincia" />
                                            <asp:BoundField DataField="Extras" HeaderText="Vehiculos" />

                                            <asp:ButtonField CommandName="Ver" ButtonType="Link" HeaderText="Ver"
                                                Text="<i aria-hidden='true' class='glyphicon glyphicon-search'></i>" ControlStyle-CssClass="btn btn-default"></asp:ButtonField>
                                            <asp:ButtonField CommandName="Editar" ButtonType="Link" HeaderText="Editar"
                                                Text="<i aria-hidden='true' class='glyphicon glyphicon-pencil'></i>" ControlStyle-CssClass="btn btn-default"></asp:ButtonField>
                                            <asp:ButtonField CommandName="Eliminar" ButtonType="Link" HeaderText="Eliminar"
                                                Text="<i aria-hidden='true' class='glyphicon glyphicon-trash'></i>" ControlStyle-CssClass="btn btn-default"></asp:ButtonField>

                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <script src="Scripts/jquery.min.js"></script>
       <!--Scripts para autocomplete (no eliminar)-->
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script>
    <script src="./Scripts/GoogleMaps.js" type="text/javascript"></script>
    <script src="./Scripts/paneles.js"></script>
    <script src="./Scripts/contarFilas.js"></script>
    <script src="./Scripts/DesplazarTabs.js"></script>
    <script src="./Scripts/moment.js"></script>
    <script src="./Scripts/datetimepicker.min.js"></script>
        <!--script de autocomplete-->
    <script src="Scripts/Autocomplete.js"></script>

    <script>
        $(document).ready(function () {

            $('.formulario').bootstrapValidator();
            /*Al iniciar cuenta las filas que tiene cargada la tabla. Client-side */
            contarFilas();

            /*Muestra los resultados de la búsqueda*/
            $("#MainContent_btnBuscar").click(function () {
                customSlideToggle($("#pnlResultados"));
            });

        });

        function customSlideToggle(e) {
            if (e.hasClass('hidden')) {
                e.show();
                e.removeClass('hidden')
                e.slideDown('slow');
            }
            else {
                e.slideUp('slow', function () {
                    e.addclass('hidden');
                    e.hide();
                });
            }
        }
        function habilitarBotonGuardar(habilitar) {
            if (habilitar == true) {
                $('[id*=upBotones] [id*=btnGuardar]').first().removeClass('disabled');
            }
            else {
                $('[id*=upBotones] [id*=btnGuardar]').first().addClass('disabled');
            }
        }

        function abrirModalPlaya() {
            $('[id*=modificarPlaya]').modal({ keyboard: false, show: true, backdrop: 'static' });
            $('[id*=myTab] a:first').tab('show')
        }

        pageManager = Sys.WebForms.PageRequestManager.getInstance();
        pageManager.add_endRequest(function () {
            SearchText();
            $('.formulario').bootstrapValidator();

            $('#txtLatitud').val($('latitud').val())
            $('#txtLongitud').val($('longitud').val())

            $('#txtLatitud').text($('latitud').val())
            $('#txtLongitud').text($('longitud').val())

            if ($('[id*=precios][class*=active]').first().length > 0) {
                habilitarBotonGuardar(true);
            }
            else {
                habilitarBotonGuardar(false);
            }

            if ($("[id *= ucDomicilio][id *= btnAgregar]").attr("class").search("hidden") > 0) {
                GoogleMaps.initialize();
                $('[id*= ucDomicilio] [id*=divSeccionFormulario1] [id*=ddl]').change(function () {
                    codeAddress();
                });
            }
            contarFilas();
            $("#MainContent_btnBuscar").click(function () {
                customSlideToggle($("#pnlResultados"));

            });
        });

    </script>
    <script>
        $("#admPlayas").removeClass("hidden");
        $("#admPOI").removeClass("hidden");
        $("#admUsuarios").removeClass("hidden");
        $("#admPlayas").addClass("active");
    </script>

</asp:Content>
