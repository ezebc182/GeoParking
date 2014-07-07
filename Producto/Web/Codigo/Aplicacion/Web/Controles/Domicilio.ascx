﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Domicilio.ascx.cs" Inherits="Web.Controles.Domicilio" %>


<asp:UpdatePanel runat="server" ID="UpdatePanel1">
    <ContentTemplate>
        <asp:Label ID="lblDomicilios" runat="server" Text="Domicilio"></asp:Label>
        <asp:Button ID="btnAgregarDomicilio" runat="server" CssClass="btn btn-primary" Text="Agregar" OnClick="btnAgregarDomicilio_Click" OnClientClick="mostrarFormularioDomicilio()" />
    </ContentTemplate>
</asp:UpdatePanel>

<div id="divSeccionFormulario" runat="server" class="hidden">
    <asp:UpdatePanel runat="server" ID="upFormulario">
        <ContentTemplate>
            <div class="form-horizontal" role="form">
                <div class="form-group">
                    <label for="ddlProvincia" class="col-sm-2 control-label">Provincia</label>
                    <div class="col-sm-7">
                        <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control required" ID="ddlProvincia" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="ddlDepartamento" class="col-sm-2 control-label">Departamento</label>
                    <div class="col-sm-7">
                        <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control required" ID="ddlDepartamento" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="ddlCiudad" class="col-sm-2 control-label">Ciudad</label>
                    <div class="col-sm-7">
                        <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control required" ID="ddlCiudad" />
                    </div>
                </div>

                <div class="form-group">
                    <label for="txtCalle" class="col-sm-2 control-label">Calle</label>
                    <div class="col-sm-10">
                        <asp:TextBox runat="server" CssClass="form-control col-sm-10 required" ID="txtCalle" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtNumero" class="col-sm-2 control-label">Numero</label>
                    <div class="col-sm-10">
                        <asp:TextBox runat="server" CssClass="form-control col-sm-10 required" ID="txtNumero" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Button runat="server" ID="btnGuardar" Text="Guardar" CssClass="btn btn-success" OnClientClick="mostrarFormularioDomicilio()" OnClick="btnGuardar_Click" />
                    <asp:Button runat="server" ID="btnCancelar" Text="Cancelar " CssClass="btn btn-danger" OnClick="btnCancelar_Click" OnClientClick="mostrarFormularioDomicilio()" />
                </div>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
<div id="divSeccionDomicilios" runat="server">
    <asp:UpdatePanel ID="upseccionDomicilios" runat="server">
        <ContentTemplate>

            <asp:GridView runat="server" ID="gvDomicilios" AutoGenerateColumns="false" DataKeyNames="Id">
                <Columns>
                    <asp:BoundField HeaderText="Calle" DataField="Calle" />
                    <asp:BoundField HeaderText="Numero" DataField="Numero" />
                    <asp:BoundField HeaderText="CiudadId" DataField="CiudadId" Visible="false" />
                    <asp:BoundField HeaderText="Ciudad" DataField="CiudadStr" />
                    <asp:BoundField HeaderText="Departamento" DataField="DepartamentoStr" />
                    <asp:BoundField HeaderText="Provincia" DataField="ProvinciaStr" />
                    <asp:BoundField HeaderText="Latitud" DataField="Latitud" Visible="false" />
                    <asp:BoundField HeaderText="Longitud" DataField="Longitud" Visible="false" />
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
