<%@ Page Title="" Language="C#" MasterPageFile="~/MasterUsuario.master" AutoEventWireup="true" CodeBehind="web.aspx.cs" Inherits="Web2.web" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title>GeoParking-Inicio</title>

    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&libraries=places"></script>
    <script src="js/autocompleteCiudades.js"></script>

    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="js/index/jquery.min.js"></script>

    <!-- estilo de la LandPage -->
    <link href="css/index/style.css" rel='stylesheet' type='text/css' />


    <%--estilo propio de la index--%>
    <link href="css/index.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">

    <div class="intro">
        <div class="intro-body">
            <div class="container">
                <div class="row">
                    <h1 class="brand-heading" style="text-shadow: 4px 4px 13px rgb(30, 28, 28);"><span style="color: red;">Geo</span>Parking</h1>
                    <p style="text-shadow: 4px 4px 13px rgba(30, 28, 28 ,1);" class="intro-text">Estacioná de manera fácil, rápida y efectiva.</p>
                    <div class="input-group col-lg-4 col-lg-offset-4">
                        <asp:TextBox ID="txtBuscar" CssClass="form-control input-lg autocompleteCiudad" runat="server"
                            ClientIDMode="Static" placeholder="Ingresá tu ciudad"></asp:TextBox>
                        <div class="input-group-btn">
                            <asp:Button ID="btnBuscar" CssClass="btn-primary btn btn-lg" runat="server" Text="Buscar"
                                OnClick="btnBuscar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%--id del place de la ciudad--%>
        <asp:TextBox runat="server" ID="txtIdPlace" ClientIDMode="Static" class="hide"/>
    </div>

    <script src="js/redireccionador.js"></script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript">

        $(document).ready(new function () {
            $('[id=iconGeoParking]').attr("href", "/index.aspx");
        });

    </script>
</asp:Content>
