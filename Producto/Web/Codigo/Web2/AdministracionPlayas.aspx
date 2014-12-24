<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeBehind="AdministracionPlayas.aspx.cs" Inherits="Web2.AdministracionPlayas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
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
                                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" data-bv-notempty="true" data-bv-notempty-message="El nombre es requerido." />
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
                                                    <label for="ddlDesde" class="control-label">Desde:</label>
                                                    <asp:DropDownList runat="server" ID="ddlDesde" CssClass="form-control " data-bv-notempty="true" data-bv-notempty-message="Seleccione el dia" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4 col-md-4 col-sm-4 pull-right">
                                                <div class="form-group ">

                                                    <label for="ddlHasta" class="control-label">Hasta:</label>
                                                    <asp:DropDownList runat="server" ID="ddlHasta" CssClass="form-control " data-bv-notempty="true" data-bv-notempty-message="Seleccione el dia" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%-- Servicios --%>

                                    <h4>Servicios</h4>
                                    <div class="row">
                                        <div class="col-lg-6 col-md-6 col-sm-6 pull-left">
                                            <div class="col-lg-6 col-md-6 col-sm-6 pull-left">
                                                <div class="form-group ">
                                                    <label for="ddlTipoVehiculo" class="control-label">Tipo Vehiculo:</label>
                                                    <asp:DropDownList runat="server" ID="ddlTipoVehiculo" CssClass="form-control " data-bv-notempty="true" data-bv-notempty-message="Seleccione el dia" />
                                                </div>
                                            </div>

                                            <div class="col-lg-6 col-md-6 col-sm-6 ">
                                                <div class="form-group ">
                                                    <label for="txtCapacidad" class="control-label">Capacidad:</label>
                                                    <div class="controls">
                                                        <div class="input-group">
                                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtCapacidad" data-bv-notempty="true" data-bv-notempty-message="El email es requerido" data-bv-emailaddress-message="Ingrese un formato de email correcto." />
                                                            <div class="input-group-btn">
                                                                <button id="btnAgregar" class="btn btn-success">Agregar</button>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div>
                                        <table id="tbServicios" class="table table-hover table-responsive">
                                            <thead>
                                                <tr>
                                                    <th>Tipo Vehiculo</th>
                                                    <th>Capacidad</th>
                                                    <th>$ x Hora</th>
                                                    <th>$ x 4hs</th>
                                                    <th>$ x 6hs</th>
                                                    <th>$ x 12hs</th>
                                                    <th>$ x 24hs</th>
                                                    <th>$ x abono</th>
                                                </tr>
                                            </thead>
                                            <tbody id="tbServiciosBody">
                                                <%--agregar dinamicamente con jquery--%>
                                                <tr>
                                                    <td idtipovehiculo="0">Tipo Vehiculo</td>
                                                    <td>Capacidad</td>
                                                    <td idtiempo="0">$ x Hora</td>
                                                    <td idtiempo="1">$ x 4hs</td>
                                                    <td idtiempo="2">$ x 6hs</td>
                                                    <td idtiempo="3">$ x 12hs</td>
                                                    <td idtiempo="4">$ x 24hs</td>
                                                    <td idtiempo="5">$ x abono</td>
                                                    <td><span>X</span></td>
                                                </tr>
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
                        </div>

                        <div class="tab-pane" id="direccion">
                            <%-- <div class="form-group ">
                                    <horarios:horarios runat="server" id="ucHorarios" onerrorhandler="MostrarErrorHorario"></horarios:horarios>
                                    <div class="col-md-2 form-group pull-right">
                                        <a href="#" class="btn btn-primary pull-left" id="btnPaso2_1" data-toggle="tab" data-target="#datosGrales" onclick="javascript:abrirTab(this.id)"><span class='glyphicon glyphicon-chevron-left'></span></a>
                                        <a href="#" class="btn btn-primary pull-right" id="btnPaso2_3" data-toggle="tab" data-target="#precios" onclick="javascript:abrirTab(this.id)"><span class='glyphicon glyphicon-chevron-right'></span></a>

                                    </div>--%>
                        </div>
                    </div>

                </div>

                <div class="modal-footer">

                    <%--<asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-lg" OnClick="btnCancelar_Click" data-dismiss="modal" Text="Cancelar"></asp:Button>
                    <asp:Button ID="btnGuardar" runat="server" CssClass="btn disabled btn-success btn-lg" OnClick="btnGuardar_Click" Text="Guardar"></asp:Button>--%>
                </div>
            </div>
        </div>
    </div>



    <%--<div class="container-fluid">
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
        </div>--%>
</asp:Content>

<asp:Content runat="server" ID="Script" ContentPlaceHolderID="ScriptContent">

    <script type="text/javascript">
        //pasar a un archivo aparte "administracionPlayas.js"
        //var precios = hfPrecios convertir a objeto {id,nombre}
        var playaCargada = "";
        
        var tbServiciosHead = function () {
            var $tr = $('<tr> </tr>');

            $.each(precios, function (i, precio) {
                $tr.append('<th idPrecio="' + precio.id + '"> $ x ' + precio.nombre + '</th>');
            });

            return $tr; //funciona OK!
        };

        var servicios = {
            agregar: function (tipoVehiculoId, Capacidad) {
                //agregar a la tabla el servicio
                var table = $('[id*=tbServicios]');
                var $tr = $('<tr> </tr>');

                $tr.append('<td tipoVehiculoId=' + '"' + tipoVehiculoId + '"' + '> </td>');
                $tr.append('<td>' + capacidad + ' </td>');
                $.each(precios, function (i, precio) {
                    var precioId = $tr.find('th[idPrecio]').eq(i).attr(idPrecio);
                    $tr.append('<td idPrecio= ' + '"' + precioId + '"' + '> - </td>');
                });

                table.append($tr);
            },
            iniciar: function () {
                //llenar la tabla con el head de hfPrecios y los servicios en el hfServicios
                var $table = $('[id*=tbServicios]');
                var $tableHead = $('[id*=tbServiciosHead]');

                $tableHead.append(tbServiciosHead);
                if (this.lista !== "") {
                    //se esta editando una playa, cargar los servicios en la tabla
                    playaCargada.Servicios
                }
            },
            grabar: function () {
                //pasar la lista al hfServicios 
            },
            lista: ""//lista de servicios en la tabla JSON
        };
        direcciones: {
            //parecido a servicios
        };

    </script>
</asp:Content>
