<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.master" AutoEventWireup="true" CodeBehind="DensidadConsultasPorFechas.aspx.cs" Inherits="Web.DensidadConsultasPorFechas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&libraries=visualization"></script>
    <script type="text/javascript" src="http://www.heatmapapi.com/Javascript/HeatmapAPIGoogle3.js"></script>
    <script type="text/javascript" src="http://www.heatmapapi.com/Javascript/HeatMapAPI3.aspx?k=7262dd16-d535-4679-a4f4-7a8c62b41b98"></script>
    <script type="text/javascript" src="Scripts/GoogleMapsEstadisticas.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-xs-12 col-sm-12">
            <div class="box">
                <div class="box-header">
                    <div class="box-name">
                        <i class="fa fa-map-marker"></i>
                        <span>Estadisticas</span>
                    </div>
                    <div class="box-icons">
                        <a class="collapse-link">
                            <i class="fa fa-chevron-up"></i>
                        </a>
                        <a class="expand-link">
                            <i class="fa fa-expand"></i>
                        </a>
                        <a id="btnAgregarComparacion" onclick="agregarComparacion()"></a>
                    </div>
                    <div class="no-move"></div>
                </div>
                <div id="divEstadisticas">
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
<input id="txtAno1" type="number" maxlength="4" placeholder="Año Desde" />\
<input id="txtAno2" type="number" maxlength="4" placeholder="Año Hasta" />\
<div id="map-'+cont+'" style="height: 250px; width:100%;"></div>\
<input id="txtMes-'+cont+'" type="range" min="2014" max="2020" step="1"/>\
</div>'
            $('[id*=divEstadisticas]').first().append(div);
            initialize(cont);
        };
    </script>

</asp:Content>
