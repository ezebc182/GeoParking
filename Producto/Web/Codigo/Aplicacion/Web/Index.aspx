<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Web.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <!--seguro que este se bora jeje-->
    <link rel="stylesheet" href="Styles/index.css" type="text/css" />
    
    <!--Estilo para el autocomplete-->
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />

    <!--script de autocomplete-->
    <script src="Scripts/Autocomplete.js"></script>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <header class="intro">
        <div class="intro-body">
            <div class="container">
                <div class="row">
                    <div class="col-md-8 col-md-offset-2">

                        <h1 class="brand-heading"><span style="color: red;">Geo</span>Parking</h1>
                        <%--<img id="cel" src="./img/cel.png">--%>
                        <p class="intro-text">Estacioná de manera fácil, rápida y efectiva.</p>
                        <div class="input-group">                            
                            <asp:TextBox ID="txtBuscar" CssClass="form-control input-lg autosuggest" runat="server" ClientIDMode="Static" placeholder="Ingresá tu ciudad"></asp:TextBox>
                            <div class="input-group-btn">
                                <asp:Button ID="btnBuscar" CssClass="btn-primary btn btn-lg" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </header>

     <!--Scripts para autocomplete (no eliminar)-->
    <script src="Scripts/Autocomplete.js"></script>   
   <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script>
</asp:Content>
