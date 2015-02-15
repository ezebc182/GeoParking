<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="AdministracionSolicitudesYConexiones.aspx.cs" Inherits="Web2.AdministracionSolicitudesYConexiones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3 class="panel-title">
                <i class="fa  fa-list"></i> Administración de Solicitudes</h3>
        </div>
        <div class="panel-body">
        </div>
    </div>
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3 class="panel-title">
                <i class="fa  fa-list"></i> Administración de Conexiones</h3>
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
