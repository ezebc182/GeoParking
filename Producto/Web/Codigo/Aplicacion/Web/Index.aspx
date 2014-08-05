<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Web.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="./Styles/index.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <!--Eliminar los BR-->
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <div id="imagenPricipal" >
        <asp:Image ID="imagen" class="img-thumbnail" runat="server" ImageUrl="~/img/Banner.png" ImageAlign="Middle" />
    </div>
    <div class="buscadrPrincipal">
        <div class="col-sm-4 col-md-4 col-lg-4 text-center"></div><!--Eliminar esta columna-->
        <div class="col-sm-4 col-md-4 col-lg-4">
            <asp:TextBox ID="txtBuscar" CssClass="form-control input-lg" runat="server" ></asp:TextBox>
        </div>
        <div class="col-sm-2 col-md-2 col-lg-2">
            <asp:Button ID="btnBuscar" CssClass="btn-primary btn btn-lg" runat="server" Text="Buscar" />
        </div>
        <div class="col-sm-4 col-md-4 col-lg-4"></div><!--Eliminar esta columna-->
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="helpContent" runat="server">
</asp:Content>
