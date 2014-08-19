<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Web.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<%--    <!--seguro que este se bora jeje-->
    <link rel="stylesheet" href="./Styles/index.css" type="text/css" />

    <!--Estilo para el autocomplete-->
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    --%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <!--Scripts jquery del auto complete-->
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script>
   
    <!--Script de la funcion autocomplete-->
    <script type="text/javascript">
        $(document).ready(function () {
            SearchText();
        });
        function SearchText() {
            $(".autosuggest").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "Index.aspx/GetNombreCiudades",
                        data: "{'pre':'" + document.getElementById('txtBuscar').value + "'}",
                        dataType: "json",
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (result) {
                            alert("Error");
                        }
                    });
                }
            });
        }
    </script>

    <!--Eliminar los BR-->
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <div id="imagenPricipal">
        <asp:Image ID="imagen" class="img-thumbnail" runat="server" ImageUrl="~/img/Banner.png" ImageAlign="Middle" />
    </div>
    <div class="buscadrPrincipal">
        <div class="col-sm-4 col-md-4 col-lg-4 text-center"></div>
        <!--Eliminar esta columna-->
        <div class="col-sm-4 col-md-4 col-lg-4">
            <asp:TextBox ID="txtBuscar" CssClass="form-control input-lg autosuggest" runat="server" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div class="col-sm-2 col-md-2 col-lg-2">
            <asp:Button ID="btnBuscar" CssClass="btn-primary btn btn-lg" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
        </div>
        <div class="col-sm-4 col-md-4 col-lg-4"></div>
        <!--Eliminar esta columna-->
    </div>  
    

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="helpContent" runat="server">
</asp:Content>
