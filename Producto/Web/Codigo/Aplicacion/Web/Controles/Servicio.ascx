<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Servicio.ascx.cs" Inherits="Web.Controles.ServicioControl" %>

<div>
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <asp:LinkButton ID="btnAgregarServicio" runat="server" OnClick="btnAgregarServicio_Click" CssClass="btn btn-md btn-success pull-right" Text="<span class='glyphicon glyphicon-plus'></span>" OnClientClick="mostrarFormularioServicio()" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Servicios</h3>
        </div>
        <div class="panel-body">
            <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                <ContentTemplate>
                    <div id="divSeccionFormulario" runat="server" class="">

                        <div class="form-horizontal" role="form">
                            <div class="form-group">
                                <label for="ddlTipoVehiculo" class="col-sm-2 col-md-2 col-lg-2 control-label">Tipo de Vehiculo</label>
                                <div class="col-sm-6 col-md-6 col-lg-6">
                                    <asp:DropDownList runat="server" CssClass="form-control required" ID="ddlTipoVehiculo" />
                                </div>
                                <label for="txtCapacidad" class="col-sm-2 col-md-2 col-lg-2 control-label">Capacidad</label>
                                <div class="col-sm-2 col-md-2 col-lg-2">
                                    <asp:TextBox runat="server" CssClass="form-control required" ID="txtCapacidad" />
                                </div>

                            </div>
                            <div class="form-group pull-right">
                                <asp:LinkButton runat="server" ID="btnGuardar" CssClass="btn btn-lg" Text="<span class='glyphicon glyphicon-ok-circle'></span>" ForeColor="Green" BackColor="Transparent" OnClientClick="mostrarFormularioServicio()" OnClick="btnGuardar_Click" />
                                <asp:LinkButton runat="server" ID="btnCancelar" Text="<span class='glyphicon glyphicon-remove-circle'></span>" CssClass="btn btn-lg" ForeColor="Red" BackColor="Transparent" OnClientClick="mostrarFormularioServicio()" OnClick="btnCancelar_Click" />
                            </div>
                        </div>
                    </div>
                    <div id="divSeccionServicios" runat="server" class="">

                        <asp:GridView runat="server" ID="gvServicios" AutoGenerateColumns="false"
                            DataKeyNames="Id,TipoVehiculoId" OnRowCommand="OnRowCommandGvServicios" CssClass="table table-hover table-responsive">
                            <Columns>
                                <asp:BoundField HeaderText="Tipo de Vehiculo" DataField="TipoVehiculoStr" />
                                <asp:BoundField HeaderText="Capacidad" DataField="Capacidad" />
                                <asp:TemplateField HeaderText="Quitar">
                                    <ItemTemplate>
                                        <asp:Button runat="server" ID="btnQuitar" CommandName="Quitar" CommandArgument="<%# Container.DataItemIndex %>" />
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

<script type="text/javascript">

    function mostrarFormularioServicio() {
        //var mostrar = $('#TopContent_ucServicios_divSeccionFormulario').hasClass("hidden");
        //if (mostrar) {
        //    $('#TopContent_ucServicios_divSeccionFormulario').removeClass("hidden");
        //    //$('#TopContent_ucServicios_divSeccionServicios').addClass("hidden");
        //    $('#TopContent_ucServicios_btnAgregarServicio').addClass("hidden");
        //}
        //else {
        //    $('#TopContent_ucServicios_divSeccionFormulario').addClass("hidden");
        //    //$('#TopContent_ucServicios_divSeccionServicios').removeClass("hidden");
        //    $('#TopContent_ucServicios_btnAgregarServicio').removeClass("hidden");
        //}

    }

</script>
