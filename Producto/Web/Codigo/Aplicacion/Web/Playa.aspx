<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Playa.aspx.cs" Inherits="Web.Playa" %>

<%@ Register Src="~/Controles/Domicilio.ascx" TagName="domicilios" TagPrefix="domicilios" %>
<%@ Register Src="~/Controles/Precios.ascx" TagName="precios" TagPrefix="precios" %>
<%@ Register Src="~/Controles/Horarios.ascx" TagName="horarios" TagPrefix="horarios" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TopContent" runat="server">

    <!-- Form para datos de playa-->
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
                    <asp:UpdatePanel runat="server" ID="upFormularioPlaya">
                        <ContentTemplate>
                            <ul class="nav nav-tabs" id="myTab">
                                <li class="active" runat="server" id="tabDestino"><a href="#datosGrales" data-toggle="tab">
                                    <br />
                                    Datos Generales</a></li>
                                <li class="" runat="server" id="tabBuscarDestino"><a href="#horarios" data-toggle="tab">
                                    <br />
                                    Horarios</a></li>
                                <li class="" runat="server" id="Li1"><a href="#precios" data-toggle="tab">
                                    <br />
                                    Precios</a></li>
                            </ul>
                            <div class="tab-content">
                                <div class="tab-pane active" id="datosGrales">
                                    <div class="control-group span10">

                                        <div class="alert alert-danger" id="divAlertError" runat="server" visible="false">
                                            <asp:Label ID="lblMensajeError" runat="server"></asp:Label>
                                        </div>
                                        <div class="form-horizontal" role="form">
                                            <div class="form-group">
                                                <asp:HiddenField runat="server" ID="hfIdPlaya" />
                                                <label for="txtNombre" class="col-sm-2 control-label">Nombre</label>
                                                <div class="col-sm-10">
                                                    <asp:TextBox runat="server" CssClass="form-control col-sm-10 required" ID="txtNombre" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="txtTelefono" class="col-sm-2 control-label">Telefono</label>
                                                <div class="col-sm-10">
                                                    <asp:TextBox runat="server" CssClass="form-control col-sm-10 required" ID="txtTelefono" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="txtMail" class="col-sm-2 control-label">Mail</label>
                                                <div class="col-sm-10">
                                                    <asp:TextBox runat="server" CssClass="form-control col-sm-10 required" ID="txtMail" />
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


                                    </div>
                                </div>

                                <div class="tab-content">
                                    <div class="tab-pane" id="horarios">
                                        <div class="control-group span10">

                                            <horarios:horarios runat="server" ID="ucHorarios"></horarios:horarios>

                                        </div>
                                    </div>
                                </div>

                                <div class="tab-content">
                                    <div class="tab-pane " id="precios">
                                        <div class="control-group span10">

                                            <precios:precios runat="server" ID="ucPrecios"></precios:precios>

                                        </div>
                                    </div>
                                </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" OnClick="btnCancelar_Click" data-dismiss="modal" Text="Cancelar"></asp:Button>
                    <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success" OnClick="btnGuardar_Click" Text="Guardar"></asp:Button>

                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->

    </div>  
    </div>            
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="upResultados" runat="server" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="jumbotron">
                    <div class="page-header">
                        <h1>Administración de playas <small>Consulta</small></h1>
                    </div>
                    <div class="form-horizontal" role="form">
                        <div class="form-group" id="busquedaPlayas">
                            <div class="col-md-8">
                                <asp:TextBox ID="txtFiltroNombre" CssClass="form-control input-lg" runat="server">
                                </asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <asp:Button runat="server" CssClass="btn-primary btn btn-lg" ID="btnBuscar" Text="Buscar" OnClick="btnBuscar_Click"></asp:Button>
                                <asp:Button runat="server" CssClass="btn-success btn btn-lg" ID="btnNuevo" Text="Nueva" OnClick="btnNuevo_Click" data-toggle="modal" data-target="#modificarPlaya"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Resultados de búsqueda -->
                <asp:HiddenField ID="hfFilasGrilla" runat="server" />
                <div id="pnlResultados" class="container-fluid">
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
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>


    <script>

        $(document).ready(function () {

            //activa los tooltips de bootstrap
            $('#eliminar').tooltip();
            $('#editar').tooltip();
            $('#buscar').tooltip();

            $("#pnlResultados").addClass('hidden');

            /*Al iniciar cuenta las filas que tiene cargada la tabla. Client-side */
            contarFilas();

            /*Muestra los resultados de la búsqueda*/
            $("#MainContent_btnBuscar").click(function () {
                customSlideToggle($("#pnlResultados"));
            });

            /*$('#listadoPlayas').dataTable();*/

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
            GoogleMaps.initialize();
            contarFilas();
            $("#MainContent_btnBuscar").click(function () {
                customSlideToggle($("#pnlResultados"));

            });

        });

        //Guarda el estado de los update panels, para que no se pierdan los atributos cambiados en el postback
        var resultadosOcultos;
        function SaveState(sender, args) {
            // code to save state of update panel controls
            if ($("#pnlResultados").hasClass('hidden')) {
                resultadosOcultos = true;
            }
            else {
                resultadosOcultos = false;
            }
        }
        //Aplica el estado guardado anteriormente
        function ReapplyState(sender, args) {

            // code to reapply state of update panel controls
            if (resultadosOcultos) {
                $("#pnlResultados").addClass('hidden');
            }
        }

        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(SaveState);
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(ReapplyState);

    </script>
</asp:Content>
