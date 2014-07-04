<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Domicilio.ascx.cs" Inherits="Web.Controles.Domicilio" %>

<div>
    <asp:Label ID="lblDomicilios" runat="server" Text="Domicilio"></asp:Label>
    <asp:Button ID="btnAgregarDomicilio" runat="server" Text="Agregar" OnClick="btnAgregarDomicilio_Click" />
    <div id="divSeccionFormulario" runat="server">
        <asp:UpdatePanel runat="server" ID="upFormulario">
            <ContentTemplate>
                <div class="form-horizontal" role="form">
                    <div class="form-group">
                        <label for="txtProvincia" class="col-sm-2 control-label">Provincia</label>
                        <div class="col-sm-7">
                            <asp:TextBox runat="server" CssClass="form-control required" ID="txtProvincia" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtDepartamento" class="col-sm-2 control-label">Departamento</label>
                        <div class="col-sm-7">
                            <asp:TextBox runat="server" CssClass="form-control required" ID="txtDepartamento" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtCiudad" class="col-sm-2 control-label">Ciudad</label>
                        <div class="col-sm-7">
                            <asp:TextBox runat="server" CssClass="form-control required" ID="txtCiudad" />
                        </div>
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
                    <asp:Button runat="server" ID="btnAceptar" Text="Aceptar" OnClick="btnAceptar_Click"/>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div id="divSeccionDomicilios" runat="server">
        <asp:UpdatePanel runat="server" ID="upGVResultados">
            <ContentTemplate>
                <asp:GridView runat="server" ID="gvDomicilios" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField HeaderText="Calle" DataField="Calle" />
                        <asp:BoundField HeaderText="Numero" DataField="Numero" />
                        <asp:BoundField HeaderText="Ciudad" DataField="Ciudad" />
                        <asp:BoundField HeaderText="Provincia" DataField="Provincia" />
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
