<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="BusquedaPlaya.aspx.cs" Inherits="Web.BusquedaPlaya" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <!--Estilos del mapa y su panel-->
    <link href="Styles/BusquedaPlaya.css" rel="stylesheet" />

    <!--Estilo para el autocomplete-->
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css"
        rel="stylesheet" type="text/css" />

    <!--Script de google mas-->
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>
    
    <!--Script para el mapa de toda la pagina-->
    <script src="Scripts/GoogleMapsBusquedaPlaya.js"></script>

    <!--script de autocomplete-->
    <script src="Scripts/Autocomplete.js"></script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <!--Scripts para autocomplete (no eliminar)-->
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script>


       <div class="formulario" data-bv-message="El valor es requerido" data-bv-feedbackicons-valid="glyphicon glyphicon-ok" data-bv-feedbackicons-invalid="glyphicon glyphicon-remove" data-bv-feedbackicons-validating="glyphicon glyphicon-refresh">
        <!--Cabecera con formulario para buscar en otra ciudad y cambiar el mapa-->
        <div class="col-sm-12 col-md-12 col-lg-12">
            <div class="col-sm-4 col-md-4 col-lg-4">
                <input type="text" class="form-control input-lg autosuggest" value="" id="txtBuscar"
                    placeholder="Buscar en otra ciudad..." />

            </div>

            <div class="col-sm-2 col-md-2 col-lg-2">
                <button type="button" class="btn-primary btn btn-lg" id="Button1"><span class="glyphicon glyphicon-filter">
                    </span>&nbsp;Filtrar</button>
            </div>
            <div class="col-sm-2 col-md-2 col-lg-2">
                <button type="button" class="btn-warning btn btn-lg" id="btnBusquedaAvanzada" data-toggle="collapse"
                    data-target="#busquedaAvanzada" onclick="ajustarMapa()">
                    <span class="glyphicon glyphicon-cog"></span>&nbsp;Búsqueda
                    avanzada</button>

            </div>

            <hr class="col-sm-12 col-md-12 col-lg-12" />
        </div>
        <hr />

        <!--Columna con los fitros de la busqueda-->




        <div class="col-md-3 col-sm-3 col-lg-3 collapse well" id="busquedaAvanzada">
            <div class="formulario form-horizontal" data-bv-message="El valor es requerido" data-bv-feedbackicons-valid="glyphicon glyphicon-ok" data-bv-feedbackicons-invalid="glyphicon glyphicon-remove" data-bv-feedbackicons-validating="glyphicon glyphicon-refresh">
                <fieldset>

                    <!-- Form Name -->
                    <legend>Búsqueda avanzada</legend>

                    <!-- Text input-->
                    <div class="form-group">
                        <div class="col-md-12 col-sm-12 col-lg-12">
                            
                            <div class="input-group">
                                <span class="input-group-addon"><span class="glyphicon glyphicon-road"></span></span>
                                <div class="input-group">

                                    <input id="txtDireccion" name="txtCalle" type="text" placeholder="Dirección"
                                        class="form-control">

                                    <span class="input-group-btn">
                                        <button type="button" class="btn-warning btn pull-right"
                                            id="marcarPunto">
                                            <span class="glyphicon glyphicon-map-marker"></span>
                                        </button>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>


                    <!-- Select Basic -->
                    <div class="form-group">
                        <div class="col-sm-12 col-md-12 col-lg-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="glyphicon glyphicon-star"></span>
                                </span>
                              

                                <asp:DropDownList ID="ddlTipoPlaya" CssClass="form-control"
                                    runat="server" ClientIDMode="Static">
                                </asp:DropDownList>

                            </div>
                        </div>
                    </div>
                    <!-- Select Basic -->
                    <div class="form-group">
                        <div class="col-sm-12 col-md-12 col-lg-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="glyphicon
    glyphicon-align-justify"></span>
                                </span>
                              
                                <asp:DropDownList ID="ddlTipoVehiculo" CssClass="form-control"
                                    runat="server" ClientIDMode="Static">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <!-- Select Basic -->
                    <div class="form-group">
                        <div class="col-sm-12 col-md-12 col-lg-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="glyphicon
    glyphicon-calendar"></span>
                                </span>
                              

                                <asp:DropDownList ID="ddlDiasAtencion" CssClass="form-control"
                                    runat="server" ClientIDMode="Static">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <!-- Prepended text-->
                    <div class="form-group">
                        <div class="col-md-6">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="glyphicon
    glyphicon-usd"></span></span>
                              
                                <input id="txtMinPrecio" name="txtMinPrecio" class="form-control" placeholder="0"
                                    data-bv-regexp-message="Ingrese un valor válido" pattern="[+-]?(?=\.\d|\d)(?:\d+)?(?:\.?\d*)(?:[eE][+-]?\d+)?"  data-bv-lessThan-inclusive="true" data-bv-lessThan-message="Precio desde debe ser menor que precio hasta" data-bv-lessThan-value="txtMaxPrecio ">
                            </div>
                        </div>

                        <!-- Prepended text-->
                        <div class="col-md-6">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="glyphicon
    glyphicon-usd"></span></span>
                              
                                <input id="txtMaxPrecio" name="txtMaxPrecio" class="form-control" placeholder="10"
                                       data-bv-regexp-message="Ingrese un valor válido" pattern="[+-]?(?=\.\d|\d)(?:\d+)?(?:\.?\d*)(?:[eE][+-]?\d+)?"  data-bv-greaterThan-inclusive="true" data-bv-greaterThan-message="Precio hasta debe ser mayor que precio desde" data-bv-greaterThan-value="txtMinPrecio">
                            </div>
                        </div>
                    </div>
                    <!-- Select Basic -->

                    <div class="form-group">
                        <div class="col-md-6 col-sm-6 col-lg-6">
                            <div class="input-group">
                                <span class=" input-group-addon"><span class="glyphicon
        glyphicon-time"></span></span>
                              
                                <asp:DropDownList ID="ddlHoraDesde" CssClass="form-control"
                                    runat="server" ClientIDMode="Static">
                                    <asp:ListItem Value="0">00</asp:ListItem>
                                    <asp:ListItem Value="2">02</asp:ListItem>
                                    <asp:ListItem Value="4">04</asp:ListItem>
                                    <asp:ListItem Value="6">06</asp:ListItem>
                                    <asp:ListItem Value="8">08</asp:ListItem>
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                    <asp:ListItem Value="12">12</asp:ListItem>
                                    <asp:ListItem Value="14">14</asp:ListItem>
                                    <asp:ListItem Value="16">16</asp:ListItem>
                                    <asp:ListItem Value="18">18</asp:ListItem>
                                    <asp:ListItem Value="20">20</asp:ListItem>
                                    <asp:ListItem Value="22">22</asp:ListItem>
                                    <asp:ListItem Value="23">24</asp:ListItem>
                                </asp:DropDownList>

                            </div>
                        </div>

                        <!-- Select Basic -->

                        <div class="col-md-6 col-sm-6 col-lg-6">
                            <div class="input-group">
                                <span class=" input-group-addon"><span class="glyphicon
    glyphicon-time"></span></span>
                             
                                <asp:DropDownList ID="ddlHoraHasta" CssClass="form-control" runat="server" ClientIDMode="Static">
                                    <asp:ListItem Value="0">00</asp:ListItem>
                                    <asp:ListItem Value="2">02</asp:ListItem>
                                    <asp:ListItem Value="4">04</asp:ListItem>
                                    <asp:ListItem Value="6">06</asp:ListItem>
                                    <asp:ListItem Value="8">08</asp:ListItem>
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                    <asp:ListItem Value="12">12</asp:ListItem>
                                    <asp:ListItem Value="14">14</asp:ListItem>
                                    <asp:ListItem Value="16">16</asp:ListItem>
                                    <asp:ListItem Value="18">18</asp:ListItem>
                                    <asp:ListItem Value="20">20</asp:ListItem>
                                    <asp:ListItem Value="22">22</asp:ListItem>
                                    <asp:ListItem Value="23" Selected="True">24</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                </fieldset>
            </div>


            <!--Buscar-->

            <input type="button" class="btn-primary btn btn-block" value="Filtrar"
                id="btnBuscar" />


        </div>



        <div class="col-sm-9 col-md-9 col-lg-9">
            <!--Rectangulo del Mapa-->
            <div id="pnlMapa" class="col-sm-12 col-md-12 col-lg-12">
                <div id="map-canvas"></div>
                <asp:TextBox runat="server" CssClass="form-control col-sm-5 col-md-5
    col-lg-5 required hidden"
                    ID="txtLatitud" ClientIDMode="Static" />
                <asp:TextBox runat="server" CssClass="form-control col-sm-5 col-md-5
    col-lg-5 required hidden"
                    ID="txtLongitud" ClientIDMode="Static" />
            </div>
            <!--Rectangulo de la Grilla-->
            <div>
                <asp:GridView ID="gvPlayas" runat="server"></asp:GridView>
            </div>
        </div>
    </div>

    <script>
        var cantClick = 0;
        $(document).ready(function () {
            $("#admUsuarios").addClass("hidden");
            $("#admPlayas").addClass("hidden");
            $("#admPOI").addClass("hidden");
            agrandarMapa();
            


        });

        $(".formulario").bootstrapValidator();
        function agrandarMapa() {
            $("#map-canvas").css("width", "1070px");
            $("#map-canvas").css("height", "427px");            
            $("#btnBusquedaAvanzada").html("<span class='glyphicon glyphicon-cog'></span>&nbsp;Búsqueda Avanzada");
            
        }

        function ajustarMapa() {
            if (cantClick % 2 == 0) {
                
                $("#btnBusquedaAvanzada").html("<span class='glyphicon glyphicon-cog'></span>&nbsp;Ocultar Avanzada");
                $("#map-canvas").fadeIn(3000, function () {
                    $("#map-canvas").css("width", "800px");
                    $("#map-canvas").css("height", "427px");
                });
                
            }
            else {
                agrandarMapa();
            }
            cantClick++;

        }
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="helpContent" runat="server">
</asp:Content>
