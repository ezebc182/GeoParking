<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Playa.aspx.cs" Inherits="Web.Playa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" Visible=" false">
    <div class="row-fluid" id="divFiltrosBusqueda" runat="server">
        <h1>Consultar Playa</h1>
        <div class="span6">
            <div class="control-group">
                <label class="control-label">
                    Nombre:
                </label>
                <div class="controls">
                    <asp:TextBox ID="txtFiltroNombre" runat="server"></asp:TextBox>
                    <asp:Button ID="btnConsultar" runat="server" CssClass="btn btn-success" OnClick="btnConsultar_Click" Text="Consultar" ValidationGroup="AbmcValidation" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="gvResultados" runat="server" CssClass="table table-condensed table-bordered table-striped table-hover"
        AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" EmptyDataText="No se encontraron Playas para los filtros utilizados">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" Visible="true" />
            <asp:BoundField DataField="Direccion" HeaderText="Direccion" Visible="true" />
            <asp:BoundField DataField="TipoPlaya" HeaderText="Tipo" Visible="true" />
            <asp:BoundField DataField="Latitud" HeaderText="Latitud" Visible="true" />
            <asp:BoundField DataField="Longitud" HeaderText="Longitud" Visible="true" />
            <asp:TemplateField HeaderText="Editar">
                <ItemStyle CssClass="grilla-columna-accion" />
                <ItemTemplate>
                    <asp:Button ID="btnEditar" runat="server" CommandArgument="<%# Container.DataItemIndex %>"
                        CommandName="Editar" CssClass="icon icon-grilla icon-edit" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Eliminar">
                <ItemStyle CssClass="grilla-columna-accion" />
                <ItemTemplate>
                    <asp:Button ID="btnEliminar" runat="server" CommandArgument="<%# Container.DataItemIndex %>"
                        CommandName="Eliminar" CssClass="icon icon-grilla icon-delete" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h1>
        <asp:Label ID="Titulo" runat="server"></asp:Label>
    </h1>
    <asp:HiddenField runat="server" ID="hfId" />
    <div class="row-fluid">
        <div class="span6">
            <div class="control-group">
                <label class="control-label">
                    Nombre(*):</label>
                <div class="controls">
                    <asp:TextBox ID="txtNombre" runat="server" MaxLength="100"></asp:TextBox>
                </div>
                <label class="control-label">
                    Direccion(*):
                </label>
                <div class="controls">
                    <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
                </div>
                <label class="control-label">
                    Tipo(*):
                </label>
                <div class="controls">
                    <asp:DropDownList ID="ddlTipoPlaya" runat="server">
                    </asp:DropDownList>
                </div>
                <label class="control-label">
                    Capacidad(*):
                </label>
                <div class="controls">
                    <asp:TextBox ID="txtCapacidad" runat="server"></asp:TextBox>
                </div>

                <div>
                    <div id="map-canvas"></div>
                    <asp:TextBox ID="txtLatitud" runat="server" ClientIDMode="Static"></asp:TextBox>
                    <asp:TextBox ID="txtLongitud" runat="server" ClientIDMode="Static"></asp:TextBox>
                </div>

                <label class="control-label">
                    Horario(*):
                </label>
                <div class="controls">
                    <asp:RadioButton ID="rbTodo" Text="24 hs" runat="server" GroupName="horario"></asp:RadioButton>
                </div>
                <div class="controls">
                    <asp:RadioButton ID="rbOtro" runat="server" GroupName="horario"></asp:RadioButton>
                    <label class="control-label">
                        Desde(*):
                    </label>
                    <div class="controls">
                        <asp:TextBox ID="txtDesde" runat="server"></asp:TextBox>
                    </div>
                    <label class="control-label">
                        Hasta(*):
                    </label>
                    <div class="controls">
                        <asp:TextBox ID="txtHasta" runat="server"></asp:TextBox>
                    </div>
                    <div class="controls">
                        <label class="control-label">
                            Motos(*):
                        </label>
                        <asp:CheckBox ID="chkMotos" runat="server"></asp:CheckBox>
                        <label class="control-label">
                            Bicis(*):
                        </label>
                        <asp:CheckBox ID="chkBicis" runat="server"></asp:CheckBox>
                        <label class="control-label">
                            Utilitarios(*):
                        </label>
                        <asp:CheckBox ID="chkUtilitarios" runat="server"></asp:CheckBox>
                    </div>
                </div>
            </div>
            <div class="form-actions">
                <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnGuardar_Click" />
                <asp:Button ID="btnCancelar" runat="server" CausesValidation="False" CssClass="btn" Text="Cancelar" OnClick="btnCancelar_Click" />
            </div>
        </div>
    </div>

    <script src="Scripts/GoogleMaps.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(GoogleMaps.Initialize());
        pageManager = Sys.WebForms.PageRequestManager.getInstance();

    </script>
</asp:Content>
