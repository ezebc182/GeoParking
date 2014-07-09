<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Domicilio.ascx.cs" Inherits="Web.Controles.DomicilioControl" %>

<asp:UpdatePanel runat="server" ID="UpdatePanel1">
    <ContentTemplate>
        <asp:LinkButton ID="btnAgregarDomicilio" runat="server" CssClass="btn btn-md btn-success pull-right" OnClick="btnAgregarDomicilio_Click" Text="<span class='glyphicon glyphicon-plus'></span>" OnClientClick="mostrarFormularioDomicilio()" />
    </ContentTemplate>
</asp:UpdatePanel>
<div class="panel panel-default">
    <div class="panel-heading">
        <h3 class="panel-title">Domicilios</h3>
    </div>
    <div class="panel-body">
        <asp:UpdatePanel runat="server" ID="upFormulario">
            <ContentTemplate>
                <div id="divSeccionFormulario" runat="server" class="">
                    <div class="form-horizontal" role="form">
                        <div class="form-group">
                            <label for="ddlProvincia" class="col-sm-2 col-md-2 col-lg-2 control-label">Provincia</label>
                            <div class="col-sm-10 col-md-10 col-lg-10">
                                <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control required" ID="ddlProvincia" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="ddlDepartamento" class="col-sm-2 col-md-2 col-lg-2 control-label">Departamento</label>
                            <div class="col-sm-10 col-md-10 col-lg-10">
                                <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control required" ID="ddlDepartamento" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="ddlCiudad" class="col-sm-2 col-md-2 col-lg-2 control-label">Ciudad</label>
                            <div class="col-sm-10 col-md-10 col-lg-10">
                                <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control required" ID="ddlCiudad" />
                            </div>
                        </div>
                        <div class="form-group">

                            <label for="txtCalle" class="col-sm-2 col-md-2 col-lg-2 control-label">Calle</label>
                            <div class="col-sm-6 col-md-6 col-lg-6">
                                <asp:TextBox runat="server" CssClass="form-control required" ID="txtCalle" />
                            </div>

                            <label for="txtNumero" class="col-sm-1 col-md-1 col-lg-1 control-label">Número</label>
                            <div class="col-sm-2 col-md-2 col-lg-2">
                                <asp:TextBox runat="server" CssClass="form-control required" ID="txtNumero" />
                            </div>
                            <div class="col-sm-1 col-md-1 col-lg-1">
                                <asp:LinkButton runat="server" ID="btnBuscarEnMapa" Text="<span class='glyphicon glyphicon-map-marker'></span>"
                                     ToolTip="Buscar en mapa" CssClass="btn btn-warning pull-right" OnClick="btnBuscarEnMapa_Click" OnClientClick="codeAddress()" />
                                <asp:TextBox runat="server" ClientIDMode="Static" ID="txtDireccion" CssClass="hidden"/>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-2 col-md-2 col-lg-2"></div>
                            <div id="pnlMapa" class="col-sm-10 col-md-10 col-lg-10">
                                <div id="map-canvas"></div>
                                <asp:TextBox runat="server" CssClass="form-control col-sm-5 col-md-5 col-lg-5 required hidden" ID="txtLatitud" ClientIDMode="Static" />
                                <asp:TextBox runat="server" CssClass="form-control col-sm-5 col-md-5 col-lg-5 required hidden" ID="txtLongitud" ClientIDMode="Static" />
                            </div>
                        </div>

                        <div class="form-group pull-right">
                            <asp:LinkButton runat="server" ID="btnGuardar" CssClass="btn btn-lg" Text="<span class='glyphicon glyphicon-ok-circle'></span>" ForeColor="Green" BackColor="Transparent" OnClientClick="mostrarFormularioDomicilio()" OnClick="btnGuardar_Click" />
                            <asp:LinkButton runat="server" ID="btnCancelar" Text="<span class='glyphicon glyphicon-remove-circle'></span>" CssClass="btn btn-lg" ForeColor="Red" BackColor="Transparent" OnClick="btnCancelar_Click" OnClientClick="mostrarFormularioDomicilio()" />
                        </div>

                    </div>
                </div>
                <div id="divSeccionDomicilios" runat="server">
                    <asp:GridView runat="server" ID="gvDomicilios" AutoGenerateColumns="false"
                        DataKeyNames="Id, CiudadId" CssClass="table table-hover table-responsive"
                        OnRowCommand="OnRowCommandGvDomicilios">
                        <Columns>
                            <asp:BoundField HeaderText="Calle" DataField="Calle" />
                            <asp:BoundField HeaderText="Numero" DataField="Numero" />
                            <asp:BoundField HeaderText="Ciudad" DataField="CiudadStr" />
                            <asp:BoundField HeaderText="Departamento" DataField="DepartamentoStr" />
                            <asp:BoundField HeaderText="Provincia" DataField="ProvinciaStr" />
                            <asp:BoundField HeaderText="Latitud" DataField="Latitud" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                            <asp:BoundField HeaderText="Longitud" DataField="Longitud" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                            <asp:TemplateField HeaderText="Quitar">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="btnQuitar" CssClass="btn btn-danger btn-xs" Text="<span class='glyphicon glyphicon-remove'></span>"
                                        CommandArgument="<%# Container.DataItemIndex %>" CommandName="Quitar" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</div>

<script type="text/javascript">

    function mostrarFormularioDomicilio() {
        //var mostrar = $('#TopContent_ucDomicilios_divSeccionFormulario').hasClass("hidden");
        //if (mostrar) {
        //    $('#TopContent_ucDomicilios_divSeccionDomicilios').addClass("hidden");
        //    $('#TopContent_ucDomicilios_divSeccionFormulario').removeClass("hidden");
        //    $('#TopContent_ucDomicilios_btnAgregarDomicilio').addClass("hidden");
        //}
        //else {
        //    $('#TopContent_ucDomicilios_divSeccionFormulario').addClass("hidden");
        //    $('#TopContent_ucDomicilios_divSeccionDomicilios').removeClass("hidden");

        //    $('#TopContent_ucDomicilios_btnAgregarDomicilio').removeClass("hidden");
        //}

    }

</script>
