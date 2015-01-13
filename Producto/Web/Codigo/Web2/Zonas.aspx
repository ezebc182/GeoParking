<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeBehind="Zonas.aspx.cs"
     Inherits="Web2.Zonas"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">

    <div class="col-lg-4 col-md-4 col-sm-4">
        <input id="txtNombreZona" />
        <button type="button" class="btn btn-success" id="btnGuardarZona"></button>
        <button type="button" class="btn btn-danger" id="btnCancelar"></button>
    </div>
    <div class="col-lg-8 col-md-8 col-sm-8">
        <div id="map-canvas" style="height: 300px;"></div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false&libraries=drawing"></script>
    <script src="js/entidades.js" type="text/javascript"></script>
    <script src="js/zonas.js" type="text/javascript"></script>

    <script>
        $(document).ready(function () {
            $('#btnGuardarZona').click( function () { guardarZona() });
        });
    </script>
</asp:Content>
