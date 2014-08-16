<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Playa.aspx.cs" Inherits="Web.Playa" %>

<%@ Register Src="~/Controles/Domicilio.ascx" TagName="domicilios" TagPrefix="domicilios" %>
<%@ Register Src="~/Controles/Precios.ascx" TagName="precios" TagPrefix="precios" %>
<%@ Register Src="~/Controles/Horarios.ascx" TagName="horarios" TagPrefix="horarios" %>
<%@ Register Src="~/Controles/Servicio.ascx" TagName="servicios" TagPrefix="servicios" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" href="./Styles/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <!--Script de google mas-->
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="helpContent" runat="server">
    <!-- Modal Ayuda-->
    <div class="modal fade" id="ayudaABMC" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title" id="myModalLabel">Ayuda</h4>
                </div>
                <div class="modal-body">
                    <div class="panel-group" id="accordion">
                        <div class="panel panel-success">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <span class="indicator glyphicon glyphicon-ok pull-left"></span><a style="text-decoration: none;" class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#ayudaRegistrarPlaya">&nbsp;&nbsp; Registrar
                                    </a><i class="indicator glyphicon glyphicon-chevron-down  pull-right"></i>
                                    <small>Pasos para agregar una playa de estacionamiento</small>
                                </h4>
                            </div>
                            <div id="ayudaRegistrarPlaya" class="panel-collapse collapse in">
                                <div class="panel-body">
                                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
                                    tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,
                                    quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo
                                    consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse
                                    cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non
                                    proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-warning">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <span class="indicator glyphicon glyphicon-pencil pull-left"></span><a style="text-decoration: none;" class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#ayudaModificarPlaya">&nbsp;&nbsp; Modificar
                                    </a><i class="indicator glyphicon glyphicon-chevron-up  pull-right"></i>
                                    <small>Pasos para modificar una playa de estacionamiento</small>
                                </h4>
                            </div>
                            <div id="ayudaModificarPlaya" class="panel-collapse collapse">
                                <div class="panel-body">
                                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
                                    tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,
                                    quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo
                                    consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse
                                    cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non
                                    proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-info">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <span class="indicator glyphicon glyphicon-search pull-left"></span><a style="text-decoration: none;" class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#ayudaConsultarPlaya">&nbsp;&nbsp; Consultar
                                    </a><i class="indicator glyphicon glyphicon-chevron-up pull-right"></i>
                                    <small>Pasos para consultar una playa de estacionamiento</small>
                                </h4>
                            </div>
                            <div id="ayudaConsultarPlaya" class="panel-collapse collapse">
                                <div class="panel-body">
                                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
                                    tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,
                                    quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo
                                    consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse
                                    cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non
                                    proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-danger">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <span class="indicator glyphicon glyphicon-remove pull-left"></span>
                                    <a style="text-decoration: none;" class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#ayudaEliminarPlaya">&nbsp;&nbsp; Eliminar
                                    </a><i class="indicator glyphicon glyphicon-chevron-up pull-right"></i>
                                    <small>Pasos para eliminar una playa de estacionamiento</small>
                                </h4>
                            </div>
                            <div id="ayudaEliminarPlaya" class="panel-collapse collapse">
                                <div class="panel-body">
                                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
                                    tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,
                                    quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo
                                    consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse
                                    cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non
                                    proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="reset" id="btnCancelar" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Acerca De-->
    <div class="modal fade" id="acercaDe" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" onclick="javascript:this.resetForm()"><span aria-hidden="true">&times;</span><span class="sr-only">Cerrar</span></button>
                    <h4 class="modal-title" id="H1">Acerca de GeoParking</h4>
                </div>
                <div class="modal-body">
                    LALALA
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
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
                            <li runat="server" id="tabDatosGrales" class="active"><a href="#datosGrales" data-toggle="tab">1. Datos Generales</a></li>
                            <li runat="server" id="tabHorarios"><a href="#horarios" data-toggle="tab">2. Horarios</a></li>
                            <li runat="server" id="tabPrecios"><a href="#precios" data-toggle="tab">3. Precios</a></li>
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
                                <div class="form-group ">
                                    <precios:precios runat="server" ID="ucPrecios" OnErrorHandler="MostrarErrorPrecio"></precios:precios>
                                    <div class="col-md-2 form-group pull-right">
                                        <a href="#" class="btn btn-primary pull-left" id="btnPaso3_2" data-toggle="tab" data-target="#horarios" onclick="javascript:abrirTab(this.id)"><span class='glyphicon glyphicon-chevron-left'></span></a>
                                        <a href="#" class="btn btn-primary pull-right disabled" id="btnPaso3_3"><span class='glyphicon glyphicon-chevron-right'></span></a>
                                    </div>

                                </div>
                            </div>

                        </div>
                    </div>
                    <button id="btnAceptar" runat="server" class="btn hidden" data-dismiss="modal">Aceptar</button>
                </div>
                <div class="modal-footer">
                    <asp:UpdatePanel runat="server" ID="upBotones">
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
        <asp:UpdatePanel ID="upBusqueda" runat="server">
            <ContentTemplate>
                <div class="container-fluid">
                    <div class="jumbotron" style="margin-top: 5%;">
                        <div class="page-header">
                            <h1>Administración de playas <small>Consulta</small></h1>
                        </div>
                        <div class="form-horizontal" role="form">
                            <div class="form-group" id="busquedaPlayas">
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtFiltroNombre" CssClass="form-control input-lg" runat="server" placeholder="Nombre de playa">
                                    </asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:LinkButton runat="server" CssClass="btn-primary btn btn-lg" ID="btnBuscar" Text="Buscar" OnClick="btnBuscar_Click"></asp:LinkButton>
                                    <asp:LinkButton runat="server" CssClass="btn-success btn btn-lg" ID="btnNuevo" Text="Nueva" OnClick="btnNuevo_Click" OnClientClick="$('#modificarPlaya').modal({keyboard: false, show: true, backdrop: 'static'});"></asp:LinkButton>
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
                                            <asp:BoundField DataField="Extras" HeaderText="Extras" />
                                            <asp:TemplateField HeaderText="Acciones">
                                                <ItemStyle CssClass="grilla-columna-accion" />
                                                <ItemTemplate>

                                                    <asp:Button ToolTip="Ver" ID="btnVer" runat="server" CssClass="btn btn-default" CommandArgument="<%# Container.DataItemIndex %>"
                                                        CommandName="Ver" data-toggle="modal" data-target="#modificarPlaya" Text="&#9733;" />

                                                    <asp:Button ToolTip="Modificar" ID="btnEditar" runat="server" CssClass="btn btn-default" CommandArgument="<%# Container.DataItemIndex %>"
                                                        CommandName="Editar" data-toggle="modal" data-target="#modificarPlaya" Text="&#9839;" />

                                                    <asp:Button ToolTip="Eliminar" ID="btnEliminar" runat="server" CssClass="btn btn-default eliminacion" CommandArgument="<%# Container.DataItemIndex %>"
                                                        CommandName="Eliminar" Text="&#9747;" />


                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    
    <script src="./Scripts/GoogleMaps.js" type="text/javascript"></script>
    <script src="./Scripts/paneles.js"></script>
    <script src="./Scripts/contarFilas.js"></script>
    <script src="./Scripts/DesplazarTabs.js"></script>
    <script src="./Scripts/moment.js"></script>
    <script src="./Scripts/datetimepicker.min.js"></script>

    <script>
        $(document).ready(function () {

            $('.formulario').bootstrapValidator({

            });
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

        pageManager = Sys.WebForms.PageRequestManager.getInstance();
        pageManager.add_endRequest(function () {


            if ($("[id *= ucDomicilio] [id *= btnAgregar]").attr("class").search("hidden") > 0) {
                GoogleMaps.initialize();
            }
            contarFilas();
            $("#MainContent_btnBuscar").click(function () {
                customSlideToggle($("#pnlResultados"));

            });
        });

    </script>

</asp:Content>
