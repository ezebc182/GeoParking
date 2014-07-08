<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Precios.ascx.cs" Inherits="Web.Controles.PrecioControl" %>

<div>
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <asp:LinkButton ID="btnAgregarPrecio" runat="server" CssClass="btn btn-md btn-success pull-right" Text="<span class='glyphicon glyphicon-plus'></span>" OnClientClick="mostrarFormularioPrecio()" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Precios</h3>
        </div>
        <div class="panel-body">
            <div id="divSeccionFormulario" runat="server" class="hidden">
                <asp:UpdatePanel runat="server" ID="upFormulario">
                    <ContentTemplate>
                        <%--<div class="form-horizontal" role="form">--%>
                        <div class="form-group">
                            <label for="ddlTipoVehiculo" class="col-sm-2 col-md-2 col-lg-2 control-label">Tipo de Vehiculo</label>

                            <div class="col-sm-10 col-md-10 col-lg-10">
                                <asp:DropDownList runat="server" CssClass="form-control required" ID="ddlTipoVehiculo" />

                            </div>
                        </div>
                        <div class="form-group">
                            <label for="ddlTipoHorario" class="col-sm-2 col-md-2 col-lg-2 control-label">Tipo de Horario</label>

                            <div class="col-sm-10 col-md-10 col-lg-10">
                                <asp:DropDownList runat="server" CssClass="form-control required" ID="ddlTipoHorario" />

                            </div>
                        </div>
                        <div class="form-group">
                            <label for="ddlDias" class="col-sm-2 col-md-2 col-lg-2 control-label">Dias</label>

                            <div class="col-sm-10 col-md-10 col-lg-10">
                                <asp:DropDownList runat="server" CssClass="form-control required" ID="ddlDias" />

                            </div>
                        </div>
                        <%--</div>--%>
                        <div class="form-group">
                            <label for="txtPrecio" class="col-sm-2 col-md-2 col-lg-2 control-label">Precio</label>
                            <div class="col-sm-10 col-md-10 col-lg-10">
                                <asp:TextBox runat="server" CssClass="form-control required" ID="txtPrecio" />
                            </div>
                        </div>
                        <div class="form-group pull-right">
                            <asp:LinkButton runat="server" ID="btnGuardar" Text="<span class='glyphicon glyphicon-ok-circle'></span>" CssClass="btn btn-lg" ForeColor="Green" BackColor="Transparent" OnClientClick="mostrarFormularioPrecio()" OnClick="btnGuardar_Click" />
                            <asp:LinkButton runat="server" ID="btnCancelar" Text="<span class='glyphicon glyphicon-remove-circle'></span>" CssClass="btn btn-lg" ForeColor="Red" BackColor="Transparent" OnClientClick="mostrarFormularioPrecio()" />
                        </div>
                    </ContentTemplate>

                </asp:UpdatePanel>
            </div>

            <div id="divSeccionPrecios" runat="server">
                <asp:UpdatePanel runat="server" ID="upGVResultados">
                    <ContentTemplate>
                        <asp:GridView runat="server" ID="gvPrecios" AutoGenerateColumns="false" DataKeyNames="Id, TipoVehiculoId, TiempoId, DiaAtencionId"
                            OnRowCommand="OnRowCommandGvPrecios">
                            <Columns>
                                <asp:BoundField HeaderText="Tipo de Vehiculo" DataField="TipoVehiculoStr" />
                                <asp:BoundField HeaderText="Tiempo" DataField="TiempoStr" />
                                <asp:BoundField HeaderText="Dias" DataField="DiaAtencionStr" />
                                <asp:BoundField HeaderText="Precio" DataField="Monto" />
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
