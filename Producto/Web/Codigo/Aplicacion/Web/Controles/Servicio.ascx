<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Servicio.ascx.cs" Inherits="Web.Controles.ServicioControl" %>

<div id="divPanel">
    <asp:UpdatePanel runat="server" ID="UpdatePanel">
        <ContentTemplate>
            <asp:LinkButton ID="btnAgregarServicio" runat="server" CssClass="btn btn-md btn-success pull-right" Text="<span class='glyphicon glyphicon-plus'></span>" OnClick="btnAgregarServicio_Click" OnClientClick="mostrarPanel((this))" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Servicios</h3>
        </div>
        <div class="panel-body">
            <asp:UpdatePanel runat="server" ID="UpdatePanel2" >
                <ContentTemplate>
                    <div id="divSeccionFormulario" runat="server" class=" ">

                        <div class="form-horizontal " role="form" data-bv-message="This value is not valid" data-bv-feedbackicons-valid="glyphicon glyphicon-ok" data-bv-feedbackicons-invalid="glyphicon glyphicon-remove" data-bv-feedbackicons-validating="glyphicon glyphicon-refresh">
                            <div class="form-group">
                                <label for="ddlTipoVehiculo" class="col-sm-2 col-md-2 col-lg-2 control-label">Tipo de Vehiculo</label>
                                <div class="col-sm-6 col-md-6 col-lg-6">
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlTipoVehiculo" data-bv-notempty="true" data-bv-notempty-message="Seleccione un tipo de vehículo." />
                                </div>
                                <label for="txtCapacidad" class="col-sm-2 col-md-2 col-lg-2 control-label">Capacidad</label>
                                <div class="col-sm-2 col-md-2 col-lg-2">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtCapacidad" type="number" data-bv-integer-message="La capacidad debe ser un número entero." data-bv-notempty="true" data-bv-notempty-message="La capacidad es requerida." data-bv-regexp-regexp="^[0-9]" data-bv-regexp-message="Ingrese números." min="1" />
                                </div>

                            </div>
                            <div class="form-group pull-right">
                                <asp:LinkButton runat="server" ID="btnGuardar" CssClass="btn btn-lg" Text="<span class='glyphicon glyphicon-ok-circle'></span>" ForeColor="Green" BackColor="Transparent" OnClick="btnGuardar_Click" OnClientClick="ocultarPanel()" />
                                <asp:LinkButton runat="server" ID="btnCancelar" CssClass="btn btn-lg" Text="<span class='glyphicon glyphicon-remove-circle'></span>" ForeColor="Red" BackColor="Transparent" OnClick="btnCancelar_Click" OnClientClick="ocultarPanel()" />
                            </div>
                        </div>
                    </div>


                    <div id="divSeccionGrillaServicios" runat="server" class="">

                        <asp:GridView runat="server" ID="gvServicios" AutoGenerateColumns="false"
                            DataKeyNames="Id,TipoVehiculoId" OnRowCommand="OnRowCommandGvServicios" CssClass="table table-hover table-responsive" AllowPaging="True">
                            <Columns>
                                <asp:BoundField HeaderText="Tipo de Vehiculo" DataField="TipoVehiculoStr" />
                                <asp:BoundField HeaderText="Capacidad" DataField="Capacidad" />
                                <asp:TemplateField HeaderText="Acciones">
                                    <ItemTemplate>
                                        <asp:Button runat="server" ID="btnQuitar" CommandName="Quitar" CssClass="btn btn-danger" Text="&#9747;" CommandArgument="<%# Container.DataItemIndex %>" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>
</div>