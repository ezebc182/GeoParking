<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Servicio.ascx.cs" Inherits="Web.Controles.ServicioControl" %>

<div>
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <asp:Label ID="lblServicios" runat="server" Text="Servicios"></asp:Label>
            <asp:Button ID="btnAgregarServicio" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClientClick="mostrarFormularioServicio()" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <div id="divSeccionFormulario" runat="server" class="hidden">
        <asp:UpdatePanel runat="server" ID="upFormulario">
            <ContentTemplate>
                <div class="form-horizontal" role="form">
                    <div class="form-group">
                        <label for="ddlTipoVehiculo" class="col-sm-2 control-label">Tipo de Vehiculo</label>
                        <div class="col-sm-7">
                            <asp:DropDownList runat="server" CssClass="form-control required" ID="ddlTipoVehiculo" />
                        </div>
                    </div>
                    <div class="form-group">

                        <label for="txtCapacidad" class="col-sm-2 control-label">Capacidad</label>
                        <div class="col-sm-7">
                            <asp:TextBox runat="server" CssClass="form-control required" ID="txtCapacidad" />
                        </div>

                    </div>
                    <div class="form-group">
                        <asp:Button runat="server" ID="btnGuardar" CssClass="btn btn-success" Text="Guardar" OnClientClick="mostrarFormularioServicio()" OnClick="btnGuardar_Click" />
                        <asp:Button runat="server" ID="btnCancelar" CssClass="btn btn-danger" Text="Cancelar" OnClientClick="mostrarFormularioServicio()" />
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div id="divSeccionServicios" runat="server">
        <asp:UpdatePanel runat="server" ID="upGVResultados">
            <ContentTemplate>
                <asp:GridView runat="server" ID="gvServicios" AutoGenerateColumns="false"
                    DataKeyNames="Id,TipoVehiculoId">
                    <Columns>
                        <asp:BoundField HeaderText="Tipo de Vehiculo" DataField="TipoVehiculoStr" />
                        <asp:BoundField HeaderText="Capacidad" DataField="Capacidad" />
                        <asp:TemplateField HeaderText="Quitar">
                            <ItemTemplate>
                                <asp:Button runat="server" ID="btnQuitar" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>

<script type="text/javascript">

    function mostrarFormularioServicio() {
        var mostrar = $('#TopContent_ucServicios_divSeccionFormulario').hasClass("hidden");
        if (mostrar) {
            $('#TopContent_ucServicios_divSeccionFormulario').removeClass("hidden");
            $('#TopContent_ucServicios_btnAgregarServicio').addClass("hidden");
        }
        else {
            $('#TopContent_ucServicios_divSeccionFormulario').addClass("hidden");
            $('#TopContent_ucServicios_btnAgregarServicio').removeClass("hidden");
        }

    }

</script>
