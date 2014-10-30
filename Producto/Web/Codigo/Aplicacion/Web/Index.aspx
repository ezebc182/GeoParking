<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Index.aspx.cs" Inherits="Web.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <!--seguro que este se bora jeje-->
    <link rel="stylesheet" href="Styles/index.css" type="text/css" />

    <!--Estilo para el autocomplete-->
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css"
        rel="stylesheet" type="text/css" />

    <!--script de autocomplete-->
    <script src="Scripts/Autocomplete.js"></script>
    <!--Scripts para autocomplete (no eliminar)-->
    <script src="Scripts/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
   <asp:Panel runat="server" ID="panel1" DefaultButton="btnBuscar">
     <div class="intro">
        <div class="intro-body">
            <div class="container">
                <div class="row">
                    <h1 class="brand-heading" style="text-shadow: 4px 4px 13px rgb(30, 28, 28);"><span style="color: red;">Geo</span>Parking</h1>
                    <p style="text-shadow: 4px 4px 13px rgba(30, 28, 28 ,1);" class="intro-text">Estacioná de manera fácil, rápida y efectiva.</p>
                    <div class="input-group col-lg-4 col-lg-offset-4">
                        <asp:TextBox ID="txtBuscar" CssClass="form-control input-lg autosuggest" runat="server"
                            ClientIDMode="Static" placeholder="Ingresá tu ciudad" autofocus></asp:TextBox>
                        <div class="input-group-btn">
                            <asp:Button ID="btnBuscar" CssClass="btn-primary btn btn-lg" runat="server" Text="Buscar"
                                OnClick="btnBuscar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
       </asp:Panel>
</asp:Content>
<asp:Content ContentPlaceHolderID="footer" runat="server">
    <div class="container-fluid">

        <footer class="" style="padding: 1% 1% 0% 1%; background-color: #000;">
            <div class="row">
                <div class="col-md-4">
                    <blockquote class="blockquote">
                        <span class="glyphicon glyphicon-map-marker"></span>&nbsp;La empresa                    
                        <small><a href="Contacto.aspx">Contacto</a></small>
                        <small><a href="Ayuda.aspx">FAQ's</a></small>
                    </blockquote>
                </div>
                <div class="col-md-4">
                    <blockquote class="blockquote">

                        <span class="glyphicon glyphicon-edit"></span>&nbsp;Dejanos tu opinión en:<br />
                        <div class="btn-group-sm">
                            <button class="btn btn-default">
                                <img class="apps" src="/img/whatsapp.png" /></button>
                            <button class="btn btn-default">
                                <img class="apps" src="/img/twitter.png" /></button>
                            <button class="btn btn-default">
                                <img class="apps" src="/img/facebook.png" /></button>
                        </div>


                    </blockquote>

                </div>
                <div class="col-md-4">
                    <blockquote class="blockquote">
                        <span class="glyphicon glyphicon-phone"></span>&nbsp;GeoParking en:<br />
                        <div class="btn-group-sm">
                            <button class="btn btn-default btn-sm">
                                <img class="apps" src="/img/android.png" /></button>
                            <button class="btn btn-sm btn-default">
                                <img class="apps" src="/img/apple.png" /></button>
                            <button class="btn btn-default btn-sm">
                                <img class="apps" src="/img/windows.png" /></button>

                        </div>
                    </blockquote>
                </div>

            </div>
        </footer>
    </div>

</asp:Content>
