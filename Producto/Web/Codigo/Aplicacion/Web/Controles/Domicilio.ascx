﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Domicilio.ascx.cs" Inherits="Web.Controles.DomicilioControl" %>


<asp:UpdatePanel runat="server" ID="UpdatePanel1">
    <ContentTemplate>
        <asp:LinkButton ID="btnAgregarDomicilio" runat="server" CssClass="btn btn-md btn-success pull-right" Text="<span class='glyphicon glyphicon-plus'></span>" OnClick="btnAgregarDomicilio_Click" OnClientClick="mostrarFormularioDomicilio()" />
    </ContentTemplate>
</asp:UpdatePanel>
<div class="panel panel-default">
    <div class="panel-heading">
        <h3 class="panel-title">Domicilios</h3>
    </div>
    <div class="panel-body">
        <div id="divSeccionFormulario" runat="server" class="hidden panel-body">
            <asp:UpdatePanel runat="server" ID="upFormulario">
                <ContentTemplate>
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
                            <div class="col-sm-10">
                                <asp:TextBox runat="server" CssClass="form-control col-sm-10 required" ID="txtCalle" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="txtNumero" class="col-sm-2 col-md-2 col-lg-2 control-label">Numero</label>
                            <div class="col-sm-10">
                                <asp:TextBox runat="server" CssClass="form-control col-sm-10 required" ID="txtNumero" />
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
                        <div class="form-group pull-right">
                            <asp:LinkButton runat="server" ID="btnGuardar" CssClass="btn btn-lg" Text="<span class='glyphicon glyphicon-ok-circle'></span>" ForeColor="Green" BackColor="Transparent" OnClientClick="mostrarFormularioDomicilio()" OnClick="btnGuardar_Click" />
                            <asp:LinkButton runat="server" ID="btnCancelar" Text="<span class='glyphicon glyphicon-remove-circle'></span>" CssClass="btn btn-lg" ForeColor="Red" BackColor="Transparent" OnClick="btnCancelar_Click" OnClientClick="mostrarFormularioDomicilio()" />
                        </div>

                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div id="divSeccionDomicilios" runat="server">
            <asp:UpdatePanel ID="upseccionDomicilios" runat="server">
                <ContentTemplate>

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
                                        CommandArgument="<%# Container.DataItemIndex %>" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</div>

<script type="text/javascript">

    function mostrarFormularioDomicilio() {
        var mostrar = $('#TopContent_ucDomicilios_divSeccionFormulario').hasClass("hidden");
        if (mostrar) {
            $('#TopContent_ucDomicilios_divSeccionFormulario').removeClass("hidden");
            $('#TopContent_ucDomicilios_btnAgregarDomicilio').addClass("hidden");
        }
        else {
            $('#TopContent_ucDomicilios_divSeccionFormulario').addClass("hidden");
            $('#TopContent_ucDomicilios_btnAgregarDomicilio').removeClass("hidden");
        }

    }

</script>
