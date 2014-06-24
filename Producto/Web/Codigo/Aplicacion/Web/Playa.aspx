<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Playa.aspx.cs" Inherits="Web.Playa" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server" Visible="false"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TopContent" runat="server" Visible="false">

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
                    <asp:UpdatePanel ID="upModalDatosPlaya" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <div class="alert alert-danger" id="divAlertError" runat="server" Visible="false">
                                <asp:Label ID="lblMensajeError" runat="server" ></asp:Label>
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
                                    <label for="ddlTipoPlaya" class="col-sm-2 control-label">Tipo</label>
                                    <div class="col-sm-10">
                                        <asp:DropDownList runat="server" ID="ddlTipoPlaya" CssClass="btn btn-default required" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="txtDireccion" class="col-sm-2 control-label">Dirección</label>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" CssClass="form-control required" ID="txtDireccion" ClientIDMode="Static" />
                                    </div>
                                    <div class="col-sm-3">
                                        <input type="button" value="Buscar" class="btn btn-primary" onclick="codeAddress()">
                                    </div>
                                </div>


                                <div class="form-group">
                                    <label class="col-sm-2 control-label" for="txtLatitud">Ubicación</label>
                                    <div id="pnlMapa" class="col-sm-10">
                                        <div class="panel panel-primary">
                                            <div class="panel-heading">Visualizador de playas</div>
                                            <div class="panel-body">
                                                <div id="map-canvas"></div>
                                            </div>
                                        </div>

                                        <div class="col-sm-5">
                                            <asp:TextBox runat="server" CssClass="form-control required" ID="txtLatitud" ClientIDMode="Static" />
                                        </div>
                                        <div class="col-sm-5">
                                            <asp:TextBox runat="server" CssClass="form-control required" ID="txtLongitud" ClientIDMode="Static" />
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-2 control-label" for="gvTiposVehiculo">Tipos de Vehiculo</label>
                                    <div class="col-sm-10">
                                        <asp:GridView ID="gvTiposVehiculo" runat="server" CssClass="table table-hover"
                                            AutoGenerateColumns="False" OnRowDataBound="gvTiposVehiculo_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="checkBox" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Capacidad">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtCapacidad" CssClass="numeric" runat="server"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Precio">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtPrecio" CssClass="numeric" runat="server"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="txtHoraDesde" class="col-sm-2 control-label">Horarios</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox runat="server" TextMode="Time" CssClass="form-control" ID="txtHoraDesde" />
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:TextBox runat="server" TextMode="Time" CssClass="form-control" ID="txtHoraHasta" />
                                    </div>
                                    <div class="col-sm-2">
                                        <label class="checkbox inline" for="cbAllDay">
                                            <asp:CheckBox runat="server" ID="cbAllDay" value="1" Text="24 hs" />
                                        </label>
                                    </div>
                                </div>
                            </div>

                        </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnGuardar" EventName="Click" />
                    </Triggers>
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


</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" Visible=" false">
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
                            Resultados <span style="background-color: white; color: black;" class="badge" id="cantidadPlayas" ></span>
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
