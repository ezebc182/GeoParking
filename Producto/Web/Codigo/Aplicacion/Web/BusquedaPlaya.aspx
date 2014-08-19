<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="BusquedaPlaya.aspx.cs" Inherits="Web.BusquedaPlaya" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <!--Estilos del mapa y su panel-->
    <link href="Styles/BusquedaPlaya.css" rel="stylesheet" />

    <!--Script de google mas-->
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>

    <!--Script jquery -->
    <script src="Scripts/jquery.min.js"></script>

    <!--Script para el mapa de toda la pagina-->
    <script src="Scripts/GoogleMapsBusquedaPlaya.js"></script>

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
                <asp:TextBox ID="txtBuscar" CssClass="form-control input-lg" placeholder="Buscar en otra ciudad..."
                    runat="server" ClientIDMode="Static"></asp:TextBox>
            </div>
            <div class="col-sm-2 col-md-2 col-lg-2">
                <input type="button" class="btn-primary btn btn-lg" value="Buscar" id="btnBuscarPorCiudad" />
            </div>
            <div class="col-sm-2 col-md-2 col-lg-2">
                <button type="button" class="btn-warning btn btn-lg" id="btnBusquedaAvanzada" data-toggle="collapse"
                    data-target="#busquedaAvanzada">
                    <span class="glyphicon glyphicon-cog"></span>&nbsp;Búsqueda
                    avanzada</button>

            </div>

            <hr class="col-sm-12 col-md-12 col-lg-12" />
        </div>
        <hr />

        <!--Columna con los fitros de la busqueda-->
        <div class="col-sm-3 col-md-3 col-lg-3  collapse" id="busquedaAvanzada" style="background-color: lightgray;">

            <!--Busqueda Avanzada-->
            <h4 class="page-title">Búsqueda Avanzada</h4>
            <div class="form-group">
                <label for="direccion" class=" control-label pull-left">Dirección</label>
                <div class="col-md-10" id="direccion">
                    <asp:TextBox ID="txtCalle" CssClass="form-control" runat="server" ClientIDMode="Static"
                        placeholder="Nombre calle"></asp:TextBox>
                    <asp:TextBox ID="txtNumero" CssClass="form-control" runat="server" ClientIDMode="Static"
                        placeholder="Número"></asp:TextBox>
                     
                </div>
               <button type="button" class="btn-info btn pull-right" id="marcarPunto">
                    <span class="glyphicon glyphicon-screenshot"></span>&nbsp;Localizar
                </button>
            </div>
            <div class="form-group">
                <!--Direccion-->
                <label for="ddlTipoPlaya" class=" control-label pull-left">Tipo de playa</label>
                <asp:DropDownList ID="ddlTipoPlaya" CssClass="form-control" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                    <asp:ListItem Value="1">techada</asp:ListItem>
                    <asp:ListItem Value="3">Descubierta</asp:ListItem>
                </asp:DropDownList>

            </div>
            <div class="form-group">

                <!--Tipo de Vehiculo-->
                <label for="ddlTipoVehiculo" class="control-label pull-left">Tipo de vehiculo</label>
                <div>
                    <asp:DropDownList ID="ddlTipoVehiculo" CssClass="form-control" runat="server" ClientIDMode="Static">
                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                        <asp:ListItem Value="1">Auto</asp:ListItem>
                        <asp:ListItem Value="2">Moto</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">

                <!--Rango de Precios-->
                <label for="precios" class="col-sm-2 control-label">Precios</label>
                <div class="col-md-10" id="precios">
                    <br />

                    <asp:TextBox ID="txtMinPrecio" CssClass="form-control" runat="server" ClientIDMode="Static"
                        type="number" min="0" max="999" placeholder="Desde $"></asp:TextBox>

                    <asp:TextBox ID="txtMaxPrecio" CssClass="form-control" runat="server" ClientIDMode="Static"
                        type="number" min="0" max="999" placeholder="Hasta $"></asp:TextBox>

                </div>
            </div>
            <div class="form-group">
                <!--Dias de Atencion-->
                <label for="ddlDiasAtencion" class="col-sm-2 control-label">Días</label>
                <div>
                    <asp:DropDownList ID="ddlDiasAtencion" CssClass="form-control" runat="server" ClientIDMode="Static">
                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                        <asp:ListItem Value="1">Lunes-Viernes</asp:ListItem>
                        <asp:ListItem Value="2">Sabado</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <!--Rango de Horario-->
                <label for="horarios" class="col-sm-2 control-label">Horarios</label>
                <br />
                <div id="horarios" class="col-md-10">
                    <input type="time" id="horaDesde" class="form-control" />
                    <input type="time" id="horaHasta" class="form-control" />
                    <%--                    <asp:DropDownList ID="ddlHoraDesde" CssClass="form-control" runat="server" ClientIDMode="Static">
                        <asp:ListItem Value="0">00:00</asp:ListItem>
                        <asp:ListItem Value="2">02:00</asp:ListItem>
                        <asp:ListItem Value="4">04:00</asp:ListItem>
                        <asp:ListItem Value="6">06:00</asp:ListItem>
                        <asp:ListItem Value="8">08:00</asp:ListItem>
                        <asp:ListItem Value="10">10:00</asp:ListItem>
                        <asp:ListItem Value="12">12:00</asp:ListItem>
                        <asp:ListItem Value="14">14:00</asp:ListItem>
                        <asp:ListItem Value="16">16:00</asp:ListItem>
                        <asp:ListItem Value="18">18:00</asp:ListItem>
                        <asp:ListItem Value="20">20:00</asp:ListItem>
                        <asp:ListItem Value="22">22:00</asp:ListItem>
                        <asp:ListItem Value="23">24:00</asp:ListItem>
                    </asp:DropDownList>

                    <asp:DropDownList ID="ddlHoraHasta" CssClass="form-control" runat="server" ClientIDMode="Static">
                        <asp:ListItem Value="0">00:00</asp:ListItem>
                        <asp:ListItem Value="2">02:00</asp:ListItem>
                        <asp:ListItem Value="4">04:00</asp:ListItem>
                        <asp:ListItem Value="6">06:00</asp:ListItem>
                        <asp:ListItem Value="8">08:00</asp:ListItem>
                        <asp:ListItem Value="10">10:00</asp:ListItem>
                        <asp:ListItem Value="12">12:00</asp:ListItem>
                        <asp:ListItem Value="14">14:00</asp:ListItem>
                        <asp:ListItem Value="16">16:00</asp:ListItem>
                        <asp:ListItem Value="18">18:00</asp:ListItem>
                        <asp:ListItem Value="20">20:00</asp:ListItem>
                        <asp:ListItem Value="22">22:00</asp:ListItem>
                        <asp:ListItem Value="23">24:00</asp:ListItem>
                    </asp:DropDownList>--%>
                </div>
            </div>

            <!--Buscar-->

            <input type="button" class="btn-primary btn pull-right" value="Filtrar" id="btnBuscar" />

        </div>
    </div>
    <br />


    <div class="col-sm-9 col-md-9 col-lg-9">
        <!--Rectangulo del Mapa-->
        <div id="pnlMapa" class="col-sm-12 col-md-12 col-lg-12">
            <div id="map-canvas"></div>
            <asp:TextBox runat="server" CssClass="form-control col-sm-5 col-md-5 col-lg-5 required hidden"
                ID="txtLatitud" ClientIDMode="Static" />
            <asp:TextBox runat="server" CssClass="form-control col-sm-5 col-md-5 col-lg-5 required hidden"
                ID="txtLongitud" ClientIDMode="Static" />
        </div>
        <!--Rectangulo de la Grilla-->
        <div>
            <asp:GridView ID="gvPlayas" runat="server"></asp:GridView>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="helpContent" runat="server">
</asp:Content>
