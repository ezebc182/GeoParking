﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterUsuario.master" AutoEventWireup="true" CodeBehind="BusquedaPlaya.aspx.cs" Inherits="Web2.BusquedaPlaya" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--Estilos del mapa y su panel-->
    <link href="css/BusquedaPlaya.css" rel="stylesheet" />   
       
    <%-- validadores js --%>
    <%--script src="js/bootstrapValidator.min.js"></script> NO ANDAN--%>

    <!--Script de google mas-->
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false&libraries=places"></script>  

    <%--jquery para angular--%>
    <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>

    <%--js para angular--%>
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.0.2/angular.min.js"></script>      

    <%--js angular de la aplicacion--%>
    <script src="js/controllerBusquedaPlayaAngular.js"></script>        
       
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div id="contenidoBusquedaPlaya" ng-app="myApp" ng-controller="MyCtrl">        
        <div class="formulario" data-bv-message="El valor es requerido" data-bv-feedbackicons-valid="glyphicon glyphicon-ok"
            data-bv-feedbackicons-invalid="glyphicon glyphicon-remove" data-bv-feedbackicons-validating="glyphicon glyphicon-refresh">
        
            <!--Cabecera con formulario para buscar en otra ciudad y cambiar el mapa-->
            <div class="form-inline" style="margin-bottom:1%;">
                <div class="form-group" style="width:40%;">
                    <div class="input-group" style="width: 85%;">
                        <input type="text" class="form-control input-md autosuggest" value="" id="txtBuscar" ng-model="ciudad"
                            placeholder="Buscar en otra ciudad..." />
                        <div class="input-group-btn">
                            <button type="button" class="btn-primary btn btn-md" id="txtBuscar" title="Buscar Ciudad" ng-click="buscarPlayasCiudad()">
                                <span class="glyphicon glyphicon-search"></span>&nbsp;Buscar</button>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <button type="button" class="btn-warning btn btn-md" id="btnBusquedaAvanzada" data-toggle="collapse"
                        data-target="#busquedaAvanzada"  ng-click="ajustarMapa()" title="Busqueda Avanzada">
                        <span class="glyphicon glyphicon-cog"></span>&nbsp;Búsqueda
                        avanzada</button>
                    <button type="button" class="btn-warning btn btn-md" id="btnListado" ng-click="listar();" title="Busqueda Avanzada"><span class='glyphicon glyphicon-list-alt'></span>&nbsp;Ver Listado</button>
                </div>
                <div class="form-group">
                    <button type="button" class="btn-default btn btn-md" id="limpiarBusqueda" ng-click="limpiarMapa();" title="Limpiar Mapa">
                        <span class="glyphicon glyphicon-trash"></span>
                    </button>
                </div>            
            </div>        

            <!--Columna con los fitros de la busqueda-->
            <div class="col-md-3 col-sm-3 col-lg-3 collapse well" id="busquedaAvanzada" >
                <div class="formulario form-horizontal" data-bv-message="El valor es requerido" data-bv-feedbackicons-valid="glyphicon glyphicon-ok"
                    data-bv-feedbackicons-invalid="glyphicon glyphicon-remove" data-bv-feedbackicons-validating="glyphicon glyphicon-refresh">
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
                                            class="form-control" ng-model="direccion">
                                        <span class="input-group-btn">
                                            <button type="button" class="btn-warning btn pull-right"
                                                id="marcarPunto" ng-click="marcarPunto()">
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
                            <div class="col-md-6 col-sm-6 col-lg-6"">   
                                <div class="input-group">
                                    <span class="input-group-addon"><span class="glyphicon
        glyphicon-usd"></span></span>

                                    <input id="txtMinPrecio" name="txtMinPrecio" maxlength="3" class="form-control" placeholder="0"
                                        data-bv-regexp-message="Ingrese un valor válido" pattern="[+-]?(?=\.\d|\d)(?:\d+)?(?:\.?\d*)(?:[eE][+-]?\d+)?"
                                        data-bv-lessthan-inclusive="true" data-bv-lessthan-message="Precio desde debe ser menor que precio hasta"
                                        data-bv-lessthan-value="txtMaxPrecio" title="Precio Minimo">
                                </div>
                            </div>
                        
                            <!-- Prepended text-->
                            <div class="col-md-6 col-sm-6 col-lg-6"">
                            
                                <div class="input-group">
                                     <span class="input-group-addon"><span class="glyphicon
        glyphicon-usd"></span></span>

                                    <input id="txtMaxPrecio" name="txtMaxPrecio" maxlength="3" class="form-control" placeholder="10"
                                        data-bv-regexp-message="Ingrese un valor válido" pattern="[+-]?(?=\.\d|\d)(?:\d+)?(?:\.?\d*)(?:[eE][+-]?\d+)?"
                                        data-bv-greaterthan-inclusive="true" data-bv-greaterthan-message="Precio hasta debe ser mayor que precio desde"
                                        data-bv-greaterthan-value="txtMinPrecio" title="Precio Maximo">
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
                                        <asp:ListItem Value="0" Selected="True">00</asp:ListItem>
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
                                        <asp:ListItem Value="24">24</asp:ListItem>

                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </fieldset>
                </div>
                <!--Buscar-->
                <input type="button" class="btn-primary btn btn-block" value="Filtrar"
                    id="btnBuscar" ng-click="filtrar()"/>
            </div>

            <div class="col-sm-9 col-md-9 col-lg-9">
                <!--Rectangulo del Mapa-->
                <div id="pnlMapa" class="col-sm-12 col-md-12 col-lg-12" ng-hide="mostrarGrilla">
                    <div id="map-canvas"></div>
                    <asp:TextBox runat="server" CssClass="form-control col-sm-5 col-md-5
        col-lg-5 required hidden"
                        ID="txtLatitud" ClientIDMode="Static" />
                    <asp:TextBox runat="server" CssClass="form-control col-sm-5 col-md-5
        col-lg-5 required hidden"
                        ID="txtLongitud" ClientIDMode="Static" />
                </div>
                <!--Rectangulo de la Grilla-->                   
                <div id="contenedorGrilla" class="table-responsive" ng-show="mostrarGrilla">
                    <br />
                    <div class="col-md-4"></div>
                    <div class="col-md-8" style="text-align: right;">
                        <div class="input-group" style="width: 100%; text-align: right;">
                            <input type="text" class="form-control input-md autosuggest ng-pristine ng-valid" value="" id="Text1" ng-model="a" placeholder="Filtrar por cualquiera de los campos" autocomplete="off">
                            <span class="input-group-addon"><span class="badge label-primary">{{resultado.length}} resultados</span> </span>                    
                        </div> 
                    </div>              
                    <br />
                    <br />
                     <table id="myTable" class="table table-striped gridStyle" >                   
                          <thead>
                            <tr>
                              <th>Id</th>
                              <th>Nombre</th>
                              <th>Tipo Playa</th>
                              <th>Direccion</th>
                              <th>Tipo de Vehiculos</th>
                              <th>Precios x hora</th>
                              <th></th>  
                            </tr>            
                          </thead>                 
                          <tbody>
                            <tr ng-repeat="p in resultado  =(playasGrilla| filter  : a) | startFrom:currentPage*pageSize | limitTo:pageSize ">
                              <th>{{p.Id }}</th>
                              <th>{{p.Nombre}}</th>
                              <th>{{p.TipoPlaya}}</th>
                              <th>{{p.Direccion}}</th>
                              <th>{{p.Vehiculos}}</th>
                              <th>{{p.Precios}}</th>
                              <th><button id="editBtn" type="button" ng-click="ir(p)"><span class="glyphicon glyphicon-search"></span></button></th>
                            </tr> 
                          </tbody>                           
                    </table>                  
           
                    <button ng-disabled="currentPage == 0" ng-click="currentPage=currentPage-1" class="btn btn-default ">Anterior</button>
                    {{currentPage+1}}/{{numberOfPages()}}
                    <button ng-disabled="currentPage >= resultado.length/pageSize - 1" ng-click="currentPage=currentPage+1"  class="btn btn-default ">Siguiente</button>
                </div>
            </div>
        </div>
    </div>     
</asp:Content>
