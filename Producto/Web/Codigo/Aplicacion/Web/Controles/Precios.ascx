<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Precios.ascx.cs" Inherits="Web.Controles.Precio" %>

<div>
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <asp:Label ID="lblPrecios" runat="server" Text="Precios"></asp:Label>
            <asp:Button ID="btnAgregarPrecio" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClientClick="mostrarFormularioPrecio()" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <div id="divSeccionFormulario" runat="server" class="hidden">
        <asp:UpdatePanel runat="server" ID="upFormulario">
            <ContentTemplate>
                <%--<div class="form-horizontal" role="form">--%>
                    <div class="form-group">
                        <label for="ddlTipoVehiculo" class="col-sm-2 control-label">Tipo de Vehiculo</label>

                        <div class="col-sm-7">
                            <asp:DropDownList runat="server" CssClass="form-control required" ID="ddlTipoVehiculo" />

                        </div>
                    </div>
                    <div class="form-group">
                        <label for="ddlTipoHorario" class="col-sm-2 control-label">Tipo de Horario</label>

                        <div class="col-sm-7">
                            <asp:DropDownList runat="server" CssClass="form-control required" ID="ddlTipoHorario" />

                        </div>
                    </div>
                    <div class="form-group">
                        <label for="ddlDias" class="col-sm-2 control-label">Dias</label>

                        <div class="col-sm-7">
                            <asp:DropDownList runat="server" CssClass="form-control required" ID="ddlDias" />

                        </div>
                    </div>
                <%--</div>--%>
                <div class="form-group">
                    <label for="txtPrecio" class="col-sm-2 control-label">Precio</label>
                    <div class="col-sm-10">
                        <asp:TextBox runat="server" CssClass="form-control required" ID="txtPrecio" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Button runat="server" ID="btnGuardar" Text="Guardar" CssClass="btn btn-success" OnClientClick="mostrarFormularioPrecio()" OnClick="btnGuardar_Click" />
                    <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" CssClass="btn btn-danger" OnClientClick="mostrarFormularioPrecio()" />
                </div>
            </ContentTemplate>

        </asp:UpdatePanel>
    </div>
    <div id="divSeccionPrecios" runat="server">
        <asp:UpdatePanel runat="server" ID="upGVResultados">
            <ContentTemplate>
                <asp:GridView runat="server" ID="gvPrecios" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="TipoVehiculoId" Visible="false" />
                        <asp:BoundField HeaderText="Tipo de Vehiculo" DataField="TipoVehiculoStr" />
                        <asp:BoundField DataField="TiempoId" Visible="false" />
                        <asp:BoundField HeaderText="Tiempo" DataField="TiempoStr" />
                        <asp:BoundField DataField="DiaAtencionId" Visible="false" />
                        <asp:BoundField HeaderText="Dias" DataField="DiaAtencionStr" />
                        <asp:BoundField HeaderText="Precio" DataField="Precio" />
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

    function mostrarFormularioPrecio() {
        var mostrar = $('#TopContent_ucPrecios_divSeccionFormulario').hasClass("hidden");
        if (mostrar) {
            $('#TopContent_ucPrecios_divSeccionFormulario').removeClass("hidden");
            $('#TopContent_ucPrecios_btnAgregarPrecio').addClass("hidden");
        }
        else {
            $('#TopContent_ucPrecios_divSeccionFormulario').addClass("hidden");
            $('#TopContent_ucPrecios_btnAgregarPrecio').removeClass("hidden");
        }

    }

</script>
