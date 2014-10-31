<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Estadisticas.aspx.cs" Inherits="Web.Estadisticas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&libraries=visualization"></script>
    <script type="text/javascript" src="Scripts/GoogleMapsEstadisticas.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="panel-group" id="accordion">
  <div class="panel panel-default">
    <div class="panel-heading">
      <h4 class="panel-title">
        <a data-toggle="collapse" data-parent="#accordion" href="#densidad">
          Densidad
        </a>
          <a id="btnAgregarComparacion" class="pull-right" onclick="agregarComparacion()">+</a>
      </h4>
    </div>
    <div id="densidad" class="panel-collapse collapse in">
      <div class="panel-body">

                <div id="divEstadisticas">
                </div>
      </div>
    </div>
  </div>
  <div class="panel panel-default">
    <div class="panel-heading">
      <h4 class="panel-title">
        <a data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">
         Otra estadistica  
        </a>
      </h4>
    </div>
    <div id="collapseTwo" class="panel-collapse collapse">
      <div class="panel-body">
       </div>
    </div>
  </div>
  <div class="panel panel-default">
    <div class="panel-heading">
      <h4 class="panel-title">
        <a data-toggle="collapse" data-parent="#accordion" href="#collapseThree">
         Otra estadistica
             </a>
      </h4>
    </div>
    <div id="collapseThree" class="panel-collapse collapse">
      <div class="panel-body">
        </div>
    </div>
  </div>
</div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="helpContent" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ScriptContent" runat="server">
    <!--Script de google mas-->

    <script>
        var cont = -1;
        
        $(document).ready(function () {
            agregarComparacion();
        });

        function agregarComparacion() {
            cont++

            var div = '<div class="col-sm-12 col-md-12 col-lg-12">\
<div id="map-'+cont+'" style="height: 250px; width:100%;"></div>\
<input id="txtMes-'+cont+'" type="range" value="2014" min="2000" max="2020" step="1" \
            onchange= toggleHeatmap('+cont+')\
            oninput= toggleHeatmap('+cont+')\
            /></div>'
            $('[id*=divEstadisticas]').first().append(div);
            initialize(cont);
        };
    </script>

</asp:Content>
