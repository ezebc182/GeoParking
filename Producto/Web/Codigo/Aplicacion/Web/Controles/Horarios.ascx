<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Horarios.ascx.cs" Inherits="Web.Controles.Horarios" %>

<div>
    <asp:Label ID="lblHorarios" runat="server" Text="Horarios"></asp:Label>
    <asp:Button ID="btnAgregarHorario" runat="server" Text="Agregar" OnClick="btnAgregarHorario_Click" CssClass="btn btn-success" />
    <div id="divSeccionFormulario" runat="server">
        <asp:UpdatePanel runat="server" ID="upFormulario">
            <ContentTemplate>
                <%--<div class="form-horizontal" role="form">--%>
                    <div class="form-group">
                        <label for="ddlDias" class="col-sm-2 control-label">Provincia</label>
                        <div class="col-sm-10">
                            <asp:DropDownList runat="server" CssClass="form-control required" ID="ddlDias" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtDesde" class="col-sm-2 control-label">Departamento</label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" CssClass="form-control required" ID="txtDesde" />
                        </div>

                        <label for="txtHasta" class="col-sm-2 control-label">Ciudad</label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" CssClass="form-control required" ID="txtHasta" />
                        </div>
                        <asp:CheckBox runat="server" ID="chk24Horas" Text="24 Horas" />
                    </div>
                    <div class="form-group">
                        <asp:Button runat="server" ID="btnAceptar" Text="Aceptar" OnClick="btnAceptar_Click" />
                    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div id="divSeccionHorarios" runat="server">
        <asp:UpdatePanel runat="server" ID="upGVResultados">
            <ContentTemplate>
                <asp:GridView runat="server" ID="gvHorarios" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField HeaderText="Dias" DataField="Dias" />
                        <asp:BoundField HeaderText="Desde" DataField="Desde" />
                        <asp:BoundField HeaderText="Hasta" DataField="Hasta" />
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
