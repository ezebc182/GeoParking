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

    <!--Script jquery -->
    <script src="Scripts/jquery.min.js"></script>


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
                            <%-- <label class="col-md-4 control-label" for="txtCalle">Dirección</label>--%>
                            <div class="input-group">
                                <span class="input-group-addon"><span class="glyphicon glyphicon-road"></span></span>
                                <div class="input-group">
                                    <input id="txtDireccion" name="txtCalle" type="text" placeholder="Dirección"
                                        class="form-control"
                                        required="">
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
                                <%--<label class="col-md-4 control-label" for="ddlTipoPlaya">Tipo
        de playa</label>--%>

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
                                <%-- <label class="col-md-4 control-label" for="ddlTipoVehiculo">Tipo
        de vehículo</label>--%>

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
                                <%--<label class="col-md-4 control-label" for="ddlDiasAtencion">Días
        atención</label>--%>

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
                                <%--<label class="col-md-4 control-label" for="txtMinPrecio">Precios</label>--%>
                                <input id="txtMinPrecio" name="txtMinPrecio" class="form-control" placeholder="Desde"
                                     data-bv-numeric-separator="," data-bv-numeric-message="Ingrese un precio válido."  min="0" data-bv-greaterThan-message="Ingrese un valor numérico">
                            </div>
                        </div>

                        <!-- Prepended text-->
                        <div class="col-md-6">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="glyphicon
    glyphicon-usd"></span></span>
                                <%--<label class="col-md-4 control-label" for="txtMaxPrecio">Precios</label>--%>
                                <input id="txtMaxPrecio" name="txtMaxPrecio" class="form-control" placeholder="Hasta"
                                     data-bv-numeric-separator="," data-bv-numeric-message="Ingrese un precio válido."  min="0" data-bv-greaterThan-message="Ingrese un valor numérico">
                            </div>
                        </div>
                    </div>
                    <!-- Select Basic -->

                    <div class="form-group">
                        <div class="col-md-6 col-sm-6 col-lg-6">
                            <div class="input-group">
                                <span class=" input-group-addon"><span class="glyphicon
        glyphicon-time"></span></span>
                                <%--<label class="col-md-4 control-label" for="ddlHoraDesde">Horarios</label>--%>
                                <asp:DropDownList ID="ddlHoraDesde" CssClass="form-control"
                                    runat="server" ClientIDMode="Static">
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

                            </div>
                        </div>

                        <!-- Select Basic -->

                        <div class="col-md-6 col-sm-6 col-lg-6">
                            <div class="input-group">
                                <span class=" input-group-addon"><span class="glyphicon
    glyphicon-time"></span></span>
                                <%--<label class="col-md-4 control-label" for="ddlHoraHasta">Horarios</label>--%>
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
                                    <asp:ListItem Value="23" Selected="True">24:00</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                </fieldset>
            </div>


            <!--Busqueda Avanzada-->
            <%--  <h4 class="legend">Búsqueda Avanzada</h4>
            <div class="form-group">
                <label for="direccion" class=" control-label pull-left">Dirección</label>
    <div class="col-md-10" id="direccion">
                    <div class="input-group">
                        <span class="input-group-addon"><span class="glyphicon glyphicon-road"></span></span>
    <asp:TextBox ID="txtCalle" CssClass="form-control" runat="server" ClientIDMode="Static"
    placeholder="Nombre calle"></asp:TextBox>
                    <asp:TextBox ID="txtNumero" CssClass="form-control" runat="server"
    ClientIDMode="Static"
                        placeholder="Número"></asp:TextBox>
                    </div> 
                </div>
               <button type="button" class="btn-warning btn pull-right" id="marcarPunto">
    <span class="glyphicon glyphicon-map-marker"></span>
                </button>
            </div>
            <div class="form-group">
                <!--Direccion-->
                <label for="ddlTipoPlaya" class=" control-label pull-left">Tipo de playa</label>
    <asp:DropDownList ID="ddlTipoPlaya" CssClass="form-control" runat="server" ClientIDMode="Static">
    </asp:DropDownList>

            </div>
            <div class="form-group">

                <!--Tipo de Vehiculo-->
                <label for="ddlTipoVehiculo" class="control-label col-sm-2">Tipo de
    vehiculo</label>
                <div class="input-group">
                    <span class="input-group-addon"><span class="glyphicon glyphicon-align-justify"></span></span>
    <asp:DropDownList ID="ddlTipoVehiculo" CssClass="form-control" runat="server" ClientIDMode="Static">
    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">

                <!--Rango de Precios-->
                <label for="precios" class="col-sm-2 control-label">Precios</label>
    <div class="col-md-10" id="precios">
                    <br />
                    <div class="input-group">
                    <span class="input-group-addon"><span class="glyphicon glyphicon-usd"></span></span>
    <asp:TextBox ID="txtMinPrecio" CssClass="form-control" runat="server" ClientIDMode="Static"
    type="number" min="0" max="999" placeholder="Precio desde"></asp:TextBox>
                    </div>
                    <div class="input-group">
                    <span class="input-group-addon"><span class="glyphicon glyphicon-usd"></span></span>
    <asp:TextBox ID="txtMaxPrecio" CssClass="form-control" runat="server" ClientIDMode="Static"
    type="number" min="0" max="999" placeholder="Precio hasta"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="form-group" id="diasAtencion">
                <!--Dias de Atencion-->
                <label for="ddlDiasAtencion" class="col-sm-2 control-label">Días</label>
    <div class="input-group">              
                
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
    <asp:DropDownList ID="ddlDiasAtencion" CssClass="form-control" runat="server" ClientIDMode="Static">
    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <!--Rango de Horario-->
                <label for="horarios" class="col-sm-2 control-label">Horarios</label>
    <br />
                <div id="horarios" class="col-md-10">
                    <%--<input type="time" id="ddlHoraDesde" class="form-control" />
    <input type="time" id="ddlHoraHasta" class="form-control" />
            <div class="input-group">
                <span class=" input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
    <asp:DropDownList ID="ddlHoraDesde" CssClass="form-control" runat="server" ClientIDMode="Static">
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
                </div>
                      <div class="input-group">
                <span class=" input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
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
                        <asp:ListItem Value="23" Selected="True">24:00</asp:ListItem>
    </asp:DropDownList>
                          </div>
                </div>
            </div>

            <!--Buscar-->--%>

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
