<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Playa.aspx.cs" Inherits="Web.Playa" %>

<%@ Register Src="~/Controles/Domicilio.ascx" TagName="domicilios" TagPrefix="domicilios" %>
<%@ Register Src="~/Controles/Precios.ascx" TagName="precios" TagPrefix="precios" %>
<%@ Register Src="~/Controles/Horarios.ascx" TagName="horarios" TagPrefix="horarios" %>
<%@ Register Src="~/Controles/Servicio.ascx" TagName="servicios" TagPrefix="servicios" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TopContent" runat="server">
    <div class="modal fade" id="modificarPlaya">
        <div class="modal-dialog  modal-lg ">
            <div class="modal-content">
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
                            <li runat="server" id="tabDatosGrales" class="active"><a href="#datosGrales" data-toggle="tab">Datos Generales</a></li>
                            <li runat="server" id="tabHorarios"><a href="#horarios" data-toggle="tab">Horarios</a></li>
                            <li runat="server" id="tabPrecios"><a href="#precios" data-toggle="tab">Precios</a></li>
                        </ul>


                        <div class="tab-content" style="margin: 20px;">

                            <div class="tab-pane fade active in" id="datosGrales">
                                <div class="clearfix"></div>
                                <asp:UpdatePanel runat="server" ID="upDatosGrales">
                                    <ContentTemplate>
                                        <div class="form-group">
                                            <asp:HiddenField runat="server" ID="hfIdPlaya" />
                                            <label for="txtNombre" class="col-sm-2 col-md-2 col-lg-2 control-label">Nombre</label>
                                            <div class="col-sm-10 col-md-10 col-lg-10 col-md-10 col-lg-10">
                                                <asp:TextBox runat="server" CssClass="form-control required" ID="txtNombre" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtTelefono" class="col-sm-2 col-md-2 col-lg-2 col-md-2 col-lg-2 control-label">Telefono</label>
                                            <div class="col-sm-10 col-md-10 col-lg-10">
                                                <asp:TextBox runat="server" CssClass="form-control  required" ID="txtTelefono" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtMail" class="col-sm-2 col-md-2 col-lg-2 control-label">Mail</label>
                                            <div class="col-sm-10 col-md-10 col-lg-10">
                                                <asp:TextBox runat="server" CssClass="form-control required" ID="txtMail" />
                                            </div>

                                        </div>
                                        <div class="form-group">
                                            <label for="ddlTipoPlaya" class="col-sm-2 col-md-2 col-lg-2 control-label">Tipo de Playa</label>
                                            <div class="col-sm-10 col-md-10 col-lg-10">
                                                <asp:DropDownList runat="server" ID="ddlTipoPlaya" CssClass="form-control required" />
                                            </div>
                                        </div>

                                    </ContentTemplate>
                                </asp:UpdatePanel>


                                <div class="form-group">
                                    <servicios:servicios runat="server" ID="ucServicios" OnErrorHandler="MostrarErrorServicio"></servicios:servicios>
                                </div>

                                <div class="form-group">
                                    <domicilios:domicilios runat="server" ID="ucDomicilios" OnErrorHandler="MostrarErrorDomicilio"></domicilios:domicilios>
                                    <asp:Button ID="btnPaso1" Text="Siguiente" runat="server" CssClass="btn btn-primary pull-right" OnClientClick="abrirTab($(this))" />
                                </div>


                            </div>
                            <div class="tab-pane" id="horarios">
                                <div class="form-group">
                                    <horarios:horarios runat="server" ID="ucHorarios" OnErrorHandler="MostrarErrorHorario"></horarios:horarios>
                                    <asp:Button ID="btnPaso2" Text="Siguiente" runat="server" CssClass="btn btn-primary pull-right" data-toggle="tab" data-target="#precios" OnClientClick="abrirTab()" />
                                </div>
                            </div>

                            <div class="tab-pane" id="precios">
                                <div class="control-group">

                                    <precios:precios runat="server" ID="ucPrecios" OnErrorHandler="MostrarErrorPrecio"></precios:precios>
                                    <div class="modal-footer">
                                        <asp:UpdatePanel runat="server" ID="upBotones">
                                            <ContentTemplate>
                                                <asp:Button ID="btnCancelar" runat="server" CssClass="btn" OnClick="btnCancelar_Click" data-dismiss="modal" Text="Cancelar"></asp:Button>
                                                <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success" OnClick="btnGuardar_Click" Text="Guardar"></asp:Button>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>

                                    </div>

                                </div>
                            </div>

                        </div>
                    </div>
                    <button id="btnAceptar" runat="server" class="btn hidden" data-dismiss="modal" >Aceptar</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:UpdatePanel ID="upBusqueda" runat="server" ChildrenAsTriggers="true">
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
                                    <asp:Button runat="server" CssClass="btn-primary btn btn-lg" ID="btnBuscar" Text="Buscar" OnClick="btnBuscar_Click"></asp:Button>
                                    <asp:Button runat="server" CssClass="btn-success btn btn-lg" ID="btnNuevo" Text="Nueva" OnClick="btnNuevo_Click" OnClientClick="openModal()"></asp:Button>
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
                                                    <asp:Button ID="btnEditar" runat="server" CommandArgument="<%# Container.DataItemIndex %>"
                                                        CommandName="Editar" data-toggle="modal" data-target="#modificarPlaya" CssClass="icon icon-grilla icon-edit" />

                                                    <asp:Button ID="btnEliminar" runat="server" CommandArgument="<%# Container.DataItemIndex %>"
                                                        CommandName="Eliminar" CssClass="icon icon-grilla icon-delete" />

                                                    <asp:Button ID="btnVer" runat="server" CommandArgument="<%# Container.DataItemIndex %>"
                                                        CommandName="Ver" data-toggle="modal" data-target="#modificarPlaya" CssClass="icon icon-grilla " />
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
    <script src="./Scripts/openModal.js"></script>
    <script src="./Scripts/contarFilas.js"></script>
    <script src="./Scripts/DesplazarTabs.js"></script>
    <script>



        $(document).ready(function () {

            $('#eliminar').tooltip();
            $('#editar').tooltip();
            $('#buscar').tooltip();


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
        var contador = 0;
        pageManager = Sys.WebForms.PageRequestManager.getInstance();
        pageManager.add_endRequest(function () {

          
            if (document.getElementById('TopContent_ucDomicilios_divSeccionFormulario') != null && contador == 0) {
                contador = 1;
                GoogleMaps.initialize();
            }
            contarFilas();
            $("#MainContent_btnBuscar").click(function () {
                customSlideToggle($("#pnlResultados"));

            });
        });

    </script>

</asp:Content>
