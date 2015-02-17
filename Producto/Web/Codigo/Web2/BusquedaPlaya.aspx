<%@ Page Title="Busqueda Playas" Language="C#" MasterPageFile="~/MasterUsuario.master" AutoEventWireup="true" CodeBehind="BusquedaPlaya.aspx.cs" Inherits="Web2.BusquedaPlaya" %>
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

    <link href="js/bootstrapformhelpers/css/bootstrap-formhelpers.min.css" rel="stylesheet" />
    <script src="js/bootstrapformhelpers/js/bootstrap-formhelpers.js"></script>

    <script src="js/busquedaPlaya.js"></script>
       
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
                        <%--id del place de la ciudad--%>
                        <asp:TextBox runat="server" ID="txtIdPlace" ClientIDMode="Static" class="hide" ng-model="idPlaceCiudad"/>
                        <div class="input-group-btn">
                            <button type="button" class="btn-primary btn btn-md" id="txtBuscar" title="Buscar Ciudad" ng-click="buscarPlayasCiudad()">
                                <span class="glyphicon glyphicon-search"></span>&nbsp;Buscar</button>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <button type="button" class="btn-warning btn btn-md hidden" id="btnBusquedaAvanzada" data-toggle="collapse"
                        data-target="#busquedaAvanzada"  ng-click="ajustarMapa()" title="Busqueda Avanzada">
                        <span class="glyphicon glyphicon-resize-full"></span>&nbsp;Expandir Mapa</button>
                    <button type="button" class="btn-warning btn btn-md" id="btnListado" ng-click="listar();" title="Ver listado/mapa"><span class='glyphicon glyphicon-list-alt'></span>&nbsp;Ver Listado</button>
                </div>
                <div class="form-group">
                    <button type="button" class="btn-default btn btn-md" id="limpiarBusqueda" ng-click="buscarPlayasCiudad();" title="Restaurar Mapa"><!--limpiarMapa()-->
                        <span class="glyphicon glyphicon-repeat"></span>&nbsp;Restaurar Mapa
                    </button>
                </div>  
                <div class="form-group" style=" margin-left: 31%; position: fixed;" onClick="abrirAyuda()">
                    <button type="button" class="btn-default btn btn-md" id="btnAyuda" title="Ayuda" >
                        <span class="glyphicon glyphicon-question-sign"></span>
                    </button>
                    
                </div>          
            </div>        

            <!--Columna con los fitros de la busqueda-->
            <div class="col-md-3 col-sm-3 col-lg-3" id="busquedaAvanzada" >
                <div class="formulario form-horizontal" data-bv-message="El valor es requerido" data-bv-feedbackicons-valid="glyphicon glyphicon-ok"
                    data-bv-feedbackicons-invalid="glyphicon glyphicon-remove" data-bv-feedbackicons-validating="glyphicon glyphicon-refresh">
                    <fieldset>
                        <!-- Form Name -->
                        <legend>Búsqueda avanzada</legend>
                        <!-- Text input-->
                        <div id="tags" class="col-md-12 col-sm-12 col-lg-12"></div>
                        <br />
                        <br />
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
                                        runat="server" ClientIDMode="Static" onChange="agregarTags(1)">
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
                                        runat="server" ClientIDMode="Static" onChange="agregarTags(2)">
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
                                        runat="server" ClientIDMode="Static" onChange="agregarTags(3)">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <!-- Prepended text-->
                        <div class="form-group">
                                                   
                            <!-- Prepended text-->
                            <div class="col-md-12 col-sm-12 col-lg-12">                                
                                <div class="input-group">
                                     <span class="input-group-addon"><span class="glyphicon
        glyphicon-usd"></span></span>

                                    <input type="number" id="txtMaxPrecio"  maxlength="3" class="form-control" placeholder="Precio Maximo" title="Precio Maximo">
                                </div>
                            </div>
                        </div>
                        <!-- Select Basic -->
                        <div class="form-group">
                        <div class="col-md-12 col-sm-12 col-lg-12">
                           
                            <div class="col-lg-6 col-md-6 col-sm-6">
                                                    <div class="form-group ">                                                        
                                                        <div id="horaDesde"  class="bfh-timepicker"  data-time="00:00" style="background-color: white;"></div>
                                                    </div>
                                                </div>                                           

                             <div class="col-lg-6 col-md-6 col-sm-6">
                                                    <div class="form-group ">                                                        
                                                        <div id="horaHasta" class="bfh-timepicker"  data-time="00:00" style="background-color: white;"></div>
                                                    </div>
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
                <div id="contenedorGrilla" class="container" ng-show="mostrarGrilla">
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

    <div id="tiposPlaya" hidden="hidden"></div>
    <div id="tiposVehiculo" hidden="hidden"></div>
    <div id="diasAtencion" hidden="hidden"></div>
    <div id="resultados" hidden="hidden" onclick="mostrarMensaje()"></div>

    <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" >
    <div class="modal-dialog" style="z-index:3 !important;"  >
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
          <h4 class="modal-title" id="myModalLabel">
            <span class="glyphicon glyphicon-bookmark"></span> <strong>AYUDA</strong>
          </h4>
        </div>
        <div class="modal-body">                   

          <div class="panel-group" id="accordion">
            <div class="panel panel-default">
              <div class="panel-heading">
                <h4 class="panel-title">
                  <a data-toggle="collapse" data-parent="#accordion" href="#collapse1">
                    <span class="glyphicon glyphicon-home"></span> Buscar en otra Ciudad
                  </a>
                </h4>
              </div>
              <div id="collapse1" class="panel-collapse collapse">
                <div class="panel-body">
                    <p style="text-align:justify;">
                Para realizar un busqueda en otra ciudad, debe escibir el nombre de la nueva ciudad y presionar BUSCAR. <br /> Automaticamente
                    el mapa se caragar en la ciudad seleccionada y con las playas pertenecientes a la misma.
                   <div class="form-group" style="width:40%;">
                    <div class="input-group" style="width: 150%;">
                        <input type="text" class="form-control input-md ng-valid ng-dirty" value="" id="Text2" placeholder="Buscar en otra ciudad..." autocomplete="off" >
                        <div class="input-group-btn">
                            <button type="button" class="btn-primary btn btn-md" id="Button1" title="Buscar Ciudad">
                                <span class="glyphicon glyphicon-search"></span>&nbsp;Buscar</button>
                        </div>
                    </div>
                </div>      
                 </p>                                               
                </div>
              </div>
              </div>
              <div class="panel panel-default">
                <div class="panel-heading">
                  <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapse2">
                      <span class="glyphicon glyphicon-list-alt"></span> Ver listado de Playas
                    </a>
                  </h4>
                </div>
                <div id="collapse2" class="panel-collapse collapse ">
                  <div class="panel-body">
                   <p style="text-align:justify;">  
                       Otra manera de visualizar las playas encontradas pertenecientes a la ciudad, es en forma de 
                       tabla, donde el usuario podra visualizar directamente la informacion de las mismas. Para ello se 
                       debe presionar el boton VER LISTADO.
                    </p> 
                      <button type="button" class="btn-warning btn btn-md" id="Button2" title="Ver listado/mapa">
                          <span class="glyphicon glyphicon-list-alt"></span>&nbsp;Ver Listado

                      </button>       
                                                   
                </div>
              </div>
            </div>
            <div class="panel panel-default">
              <div class="panel-heading">
                <h4 class="panel-title">
                  <a data-toggle="collapse" data-parent="#accordion" href="#collapse3">
                    <span class="glyphicon glyphicon-chevron-right"></span> Grilla de Playas
                  </a>
                </h4>
              </div>
              <div id="collapse3" class="panel-collapse collapse ">
                <div class="panel-body">
                  <p style="text-align:justify;">  
                      En la tabla se puede filtrar por el contenido de cualquier columna con solo ingresar el valor a buscar.
                    </p> 
                    <img src="img/Busquedas/tablaBusqueda.PNG" class="img-responsive" />
                </div>
              </div>
            </div>
            <div class="panel panel-default">
              <div class="panel-heading">
                <h4 class="panel-title">
                  <a data-toggle="collapse" data-parent="#accordion" href="#collapse4">
                    <span class="glyphicon glyphicon-search"></span> Busqueda Avanzada (Filtros)
                  </a>
                </h4>
              </div>
              <div id="collapse4" class="panel-collapse collapse ">
                <div class="panel-body">

                    <div class="col-lg-6 col-md-6 col-sm-6">
                        <p style="text-align:justify;">  
                       Esta seccion le permitira al usuario aplicar filtros especificos en su busqueda de playas.<br />
                      Los friltros posibles a aplicar son por tipo de playa, por tipo de vehículo, precios, horarios, etc.<br />
                            Tambien le permitira enfocar la busqueda en una direccion particular, donde se resaltaran las playas
                            cercanas a ese punto.
                    </p> 
                    </div>
                    
                    <div class="col-lg-6 col-md-6 col-sm-6">
                        <img src="img/Busquedas/panelAvanzadaPNG.PNG" class="img-responsive" style="height: 300px;"/>
                    </div>

                  </div>
                </div>                            
              </div>
            </div>
          </div>               
        <div class="modal-footer">
          <strong>GeoParking</strong>     
        </div>
      </div>
    </div>
    </div>
 

    
   
</asp:Content>
