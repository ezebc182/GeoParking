<%@ Page Title="" Language="C#" MasterPageFile="~/MasterUsuario.master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Web2.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/jquery.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.0.2/angular.min.js"></script>   
    <script src="js/controllerBusquedaPlayaAngular.js"></script>
     <link rel="stylesheet" href="http://cdn.datatables.net/1.10.4/css/jquery.dataTables.css"/>
    <script type="text/javascript" charset = "UTF-8" src="http://cdn.datatables.net/1.10.4/js/jquery.dataTables.min.js"></script>

<script type="text/javascript">
    $(document).ready(function () {
        $('#myTable').DataTable({
            "bStateSave": true,
            "oLanguage": {
                "sProcessing": "Procesando...",
                "sLengthMenu": "Mostrar _MENU_ Remito/Parte",
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "Ningún dato disponible en esta tabla",
                "sInfo": "Mostrando del _START_ al _END_ de un total de _TOTAL_ Playas de Estacionamiento",
                "sInfoEmpty": "",
                // "sInfoEmpty": "Mostrando Playas del 0 al 0 de un total de 0 Playas",
                "sInfoFiltered": "(filtrado de un total de _MAX_ Playas de Estacionamiento)",
                "sInfoPostFix": "",
                "sSearch": "Buscar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                }
            }
        });
    });</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body ng-controller="MyCtrl">

        <!-- header -->
        <div class="row clearfix">          
            <div class="col-md-12 column fixed" id="titulo">
                <h3>Sistema de Sugerencias y Reclamos</h3>                
                <hr>
            </div>
        </div>        
       <div  width="400px">
        <table id="myTable" class="display center" cellspacing="0" >          
          <thead>
            <tr>
              <th>Id</th>
              <th>Nombre</th>
              <th>Tipo Playa</th>
              <th></th>
            </tr>            
          </thead>        
         
          <tbody>
            <tr ng-repeat="p in playasGrilla ">
              <th>{{p.ID }}</th>
              <th>{{p.Nombre}}</th>
              <th>{{p.TipoPlaya}}</th>
              <th><button id="editBtn" type="button" ng-click="ir(row)"><span class="glyphicon glyphicon-search"></span></span></button></th>
            </tr>            
          </tbody>
        </table>  
       </div>
        


    </body>
</asp:Content>
