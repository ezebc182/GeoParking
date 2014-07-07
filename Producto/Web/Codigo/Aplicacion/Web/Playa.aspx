<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Playa.aspx.cs" Inherits="Web.Playa" %>

<%@ Register Src="~/Controles/Domicilio.ascx" TagName="domicilios" TagPrefix="domicilios" %>
<%@ Register Src="~/Controles/Precios.ascx" TagName="precios" TagPrefix="precios" %>
<%@ Register Src="~/Controles/Horarios.ascx" TagName="horarios" TagPrefix="horarios" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TopContent" runat="server">
    <div class="modal fade" id="modificarPlaya">
        <div class="modal-dialog">
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


                    <div class="alert alert-danger" id="divAlertError" runat="server" visible="false">
                        <asp:Label ID="lblMensajeError" runat="server"></asp:Label>
                    </div>
                    <div class="form-horizontal" role="form">
                        <ul class="nav nav-tabs" id="myTab">
                            <li runat="server" id="tabDestino" class="active"><a href="#datosGrales" data-toggle="tab">Datos Generales</a></li>
                            <li runat="server" id="tabBuscarDestino"><a href="#horarios" data-toggle="tab">Horarios</a></li>
                            <li runat="server" id="Li1"><a href="#precios" data-toggle="tab">Precios</a></li>
                        </ul>
                        <div class="tab-content">

                            <div class="tab-pane fade in active" id="datosGrales">
                                <div class="control-group">

                                    <div class="form-group">
                                        <asp:HiddenField runat="server" ID="hfIdPlaya" />
                                        <label for="txtNombre" class="col-sm-2 control-label">Nombre</label>
                                        <div class="col-sm-10 col-md-10 col-lg-10">
                                            <asp:TextBox runat="server" CssClass="form-control required" ID="txtNombre" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtTelefono" class="col-sm-2 control-label">Telefono</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox runat="server" CssClass="form-control  required" ID="txtTelefono" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtMail" class="col-sm-2 control-label">Mail</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox runat="server" CssClass="form-control required" ID="txtMail" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="ddlTipoPlaya" class="col-sm-2 control-label">Tipo de Playa</label>
                                        <div class="col-sm-10">
                                            <asp:DropDownList runat="server" ID="ddlTipoPlaya" CssClass="btn btn-default required" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <domicilios:domicilios runat="server" ID="ucDomicilios"></domicilios:domicilios>
                                    </div>
                                </div>
                                <asp:Button ID="btnPaso1" Text="Siguiente" runat="server" CssClass="btn btn-primary pull-right" data-toggle="tab" data-target="#horarios" OnClientClick="abrirTab()" />
                            </div>

                            <div class="tab-pane" id="horarios">
                                <div class="control-group">

                                    <horarios:horarios runat="server" ID="ucHorarios"></horarios:horarios>
                                    <asp:Button ID="btnPaso2" Text="Siguiente" runat="server" CssClass="btn btn-primary pull-right" data-toggle="tab" data-target="#precios" OnClientClick="abrirTab()" />
                                </div>
                            </div>

                            <div class="tab-pane " id="precios">
                                <div class="control-group">

                                    <precios:precios runat="server" ID="ucPrecios"></precios:precios>
                                    <div class="modal-footer">
                                        <asp:Button ID="btnCancelar" runat="server" CssClass="btn" OnClick="btnCancelar_Click" data-dismiss="modal" Text="Cancelar"></asp:Button>
                                        <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success" OnClick="btnGuardar_Click" Text="Guardar"></asp:Button>

                                    </div>

                                </div>
                            </div>

                        </div>
                    </div>
                    <!-- Fin form -->

                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="upResultados" runat="server" ChildrenAsTriggers="true">
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
        </ContentTemplate>
    </asp:UpdatePanel>

    <!-- Resultados de búsqueda -->
    <asp:HiddenField ID="hfFilasGrilla" runat="server" />
    <div id="pnlResultados" class="container-fluid hidden">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true">
            <ContentTemplate>
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        Resultados <span style="background-color: white; color: black;" class="badge" id="cantidadPlayas"></span>
                    </div>

                    <div class="panel-body">
                        <div id="resultadosBusqueda">
                            <asp:GridView ID="gvResultados" runat="server" DataKeyNames="Id" CssClass="table table-hover table-responsive"
                                AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" EmptyDataText="No se encontraron Playas para los filtros utilizados"
                                OnRowCommand="gvResultados_RowCommand" OnRowDataBound="gvResultados_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" Visible="true" />
                                    <asp:BoundField DataField="Direccion" HeaderText="Direccion" Visible="true" />
                                    <asp:BoundField DataField="TipoPlayaNombre" HeaderText="Tipo" Visible="true" />
                                    <asp:BoundField DataField="Extras" HeaderText="Extras" Visible="true" />
                                    <asp:TemplateField HeaderText="Acciones">
                                        <ItemStyle CssClass="grilla-columna-accion" />
                                        <ItemTemplate>
                                            <asp:Button ID="btnEditar" runat="server" CommandArgument="<%# Container.DataItemIndex %>"
                                                CommandName="Editar" data-toggle="modal" data-target="#modificarPlaya" CssClass="icon icon-grilla icon-edit" />

                                            <asp:Button ID="btnEliminar" runat="server" CommandArgument="<%# Container.DataItemIndex %>"
                                                CommandName="Eliminar" CssClass="icon icon-grilla icon-delete" />

                                            <asp:Button ID="btnVer" runat="server" CommandArgument="<%# Container.DataItemIndex %>"
                                                CommandName="Ver" data-toggle="modal" data-target="#modificarPlaya" CssClass="icon icon-grilla icon-edit" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>




            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <script>

        function openModal() {
            $('#modificarPlaya').modal('show');


        }

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

            contarFilas();

        });


        /*Cuenta la cantidad de filas de la tabla*/
        function contarFilas() {
            $("#cantidadPlayas").text($("#MainContent_hfFilasGrilla").val());
        }

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
            // GoogleMaps.initialize();
            contarFilas();
            $("#MainContent_btnBuscar").click(function () {
                customSlideToggle($("#pnlResultados"));

            });
        });

    </script>
    <script src="~/Scripts/tabs.js"></script>
    <script src="~/Scripts/DesplazarTabs.js"></script>
</asp:Content>
