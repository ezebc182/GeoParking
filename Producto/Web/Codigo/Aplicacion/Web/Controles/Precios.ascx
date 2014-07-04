<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Precios.ascx.cs" Inherits="Web.Controles.Precios" %>

<div>
    <asp:Label ID="lblPrecios" runat="server" Text="Precios"></asp:Label>
    <asp:Button ID="btnAgregarPrecio" runat="server" Text="Agregar" OnClick="btnAgregarPrecio_Click" />
    <div id="divSeccionFormulario" runat="server">
        <asp:UpdatePanel runat="server" ID="upFormulario">
            <ContentTemplate>
                <div class="form-horizontal" role="form">
                    <div class="form-group">
                        <label for="ddlTipoVehiculo" class="col-sm-2 control-label">Tipo de Vehiculo</label>
                        <div class="col-sm-7">
                            <asp:TextBox runat="server" CssClass="form-control required" ID="ddlTipoVehiculo" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="ddlTipoHorario" class="col-sm-2 control-label">Tipo de Horario</label>
                        <div class="col-sm-7">
                            <asp:TextBox runat="server" CssClass="form-control required" ID="ddlTipoHorario" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="ddlDias" class="col-sm-2 control-label">Dias</label>
                        <div class="col-sm-7">
                            <asp:TextBox runat="server" CssClass="form-control required" ID="ddlDias" />
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtPrecio" class="col-sm-2 control-label">Precio</label>
                    <div class="col-sm-10">
                        <asp:TextBox runat="server" CssClass="form-control col-sm-10 required" ID="txtPrecio" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Button runat="server" ID="btnAceptar" Text="Aceptar" OnClick="btnAceptar_Click"/>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div id="divSeccionPrecios" runat="server">
        <asp:UpdatePanel runat="server" ID="upGVResultados">
            <ContentTemplate>
                <asp:GridView runat="server" ID="gvPrecios" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField HeaderText="Tipo de Vehiculo" DataField="TipoVehiculo" />
                        <asp:BoundField HeaderText="Tipo de Horario" DataField="TipoHorario" />
                        <asp:BoundField HeaderText="Dias" DataField="Dias" />
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
