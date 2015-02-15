<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="AdministracionSolicitudesYConexiones.aspx.cs" Inherits="Web2.AdministracionSolicitudesYConexiones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3 class="panel-title">
                <span class="fa  fa-list"></span><span runat="server" id="t_solicitudes"> Solicitudes</span>
            </h3>
        </div>
        <div class="panel-body">
                    <asp:GridView ID="gvSolicitudes" runat="server" CssClass="table table-condensed table-bordered table-striped"
            AutoGenerateColumns="False" ClientIDMode="Static"
            EmptyDataText="No hay solicitudes pendientes"
            DataKeyNames="Id">
            <Columns>
                <asp:BoundField DataField="Id" Visible="False" />
                <asp:BoundField DataField="Asunto" HeaderText="Asunto" />
                <asp:BoundField DataField="Tema" HeaderText="Tema" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemStyle CssClass="btn-group-table" />
                    <ItemTemplate>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </div>
    </div>
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3 class="panel-title">
                <span class="fa  fa-list"></span><span runat="server" id="t_conexiones"> Conexiones</span>
            </h3>
        </div>
        <div class="panel-body">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript">
        $(document).ready(new function () {
            $('[id=li_Solicitudes]').attr("class", "active");
        });
    </script>
</asp:Content>
