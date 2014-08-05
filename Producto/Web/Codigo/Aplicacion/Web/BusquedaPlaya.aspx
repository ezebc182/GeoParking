<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BusquedaPlaya.aspx.cs" Inherits="Web.BusquedaPlaya" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="./Styles/BusquedaPlaya.css" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <br />
        <br />
        <br />
        <br />
        <!--Cabecera con formulario para buscar en otra ciudad y cambiar el mapa-->
        <div class="col-sm-12 col-md-12 col-lg-12">
            <div class="col-sm-4 col-md-4 col-lg-4">
                <asp:TextBox ID="txtBuscar" CssClass="form-control input-lg" placeholder="Buscar en otra ciudad..." runat="server"></asp:TextBox>
            </div>
            <div class="col-sm-2 col-md-2 col-lg-2">
                <asp:Button ID="btnBuscar" CssClass="btn-primary btn btn-lg" runat="server" Text="Buscar" />
            </div>
            <hr class="col-sm-12 col-md-12 col-lg-12" />
        </div>
        <hr />
        <br />
        <br />
        <br />
        <br />
        <!--Columna con los fitros de la busqueda-->
        <div class="col-sm-3 col-md-3 col-lg-3 control-label">
            <!--Busqueda Avanzada-->
            <h4 class="modal-title">Busqueda Avanzada</h4>
            <br />
            <!--Direccion-->
            <asp:Label ID="lblDireccion" class="col-sm-12 col-md-12 col-lg-12 control-label" runat="server" Text="Calle y altura"></asp:Label>
            <div class="col-sm-8 col-md-8 col-lg-8">
                <asp:TextBox ID="txtCalle" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <asp:Label ID="separadorDireccion" class="col-sm-1 col-md-1 col-lg-1 control-label" runat="server" Text="-"></asp:Label>
            <div class="col-sm-3 col-md-3 col-lg-3">
                <asp:TextBox ID="txtNumero" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <br />
            <!--Tipo de Playa-->
            <asp:Label ID="lblTipoPlaya" runat="server" Text="Tipo de Playa"></asp:Label>
            <div>
                <asp:DropDownList ID="ddlTipoPlaya" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <br />
            <!--Tipo de Vehiculo-->
            <asp:Label ID="lblTipoVehiculo" runat="server" Text="Tipo de Vehiculo"></asp:Label>
            <div>
                <asp:DropDownList ID="ddlTipoVehiculo" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <br />
            <!--Rango de Precios-->
            <asp:Label ID="lblPrecio" class="col-sm-12 col-md-12 col-lg-12" runat="server" Text="Precio"></asp:Label>
            <div class="col-sm-5 col-md-5 col-lg-5">
                <asp:TextBox ID="txtMinPrecio" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <asp:Label ID="separadorPrecios" class="col-sm-2 col-md-2 col-lg-2 control-label" runat="server" Text="-"></asp:Label>
            <div class="col-sm-5 col-md-5 col-lg-5">
                <asp:TextBox ID="txtMaxPrecio" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <br />
            <!--Dias de Atencion-->
            <asp:Label ID="lblDiasDeAtencion" runat="server" Text="Dias de Atencion"></asp:Label>
            <div>
                <asp:DropDownList ID="ddlDiasAtencion" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <br />
            <!--Rango de Horario-->
            <asp:Label ID="lblHorario" class="col-sm-12 col-md-12 col-lg-12" runat="server" Text="Horario"></asp:Label>
            <div class="col-sm-5 col-md-5 col-lg-5">
                <asp:DropDownList ID="ddlHoraDesde" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <asp:Label ID="separadorHoras" class="col-sm-2 col-md-2 col-lg-2" runat="server" Text="-"></asp:Label>
            <div class="col-sm-5 col-md-5 col-lg-5">
                <asp:DropDownList ID="ddlHoraHasta" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <br />
            <!--Buscar-->
            <div>
                <asp:Button ID="btnBuscarConFiltros" CssClass="btn-primary btn btn-md" runat="server" Text="Filtrar" />
            </div>
        </div>
        <div class="col-sm-9 col-md-9 col-lg-9">
            <!--Rectangulo del Mapa-->
            <div id="pnlMapa" class="col-sm-12 col-md-12 col-lg-12">
                <div id="map-canvas"></div>
                <asp:TextBox runat="server" CssClass="form-control col-sm-5 col-md-5 col-lg-5 required hidden" ID="txtLatitud" ClientIDMode="Static" />
                <asp:TextBox runat="server" CssClass="form-control col-sm-5 col-md-5 col-lg-5 required hidden" ID="txtLongitud" ClientIDMode="Static" />
            </div>
            <!--Rectangulo de la Grilla-->
            <div>
                <asp:GridView ID="gvPlayas"  runat="server"></asp:GridView>
            </div>
        </div>

    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="helpContent" runat="server">
</asp:Content>
