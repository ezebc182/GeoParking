<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Playa.aspx.cs" Inherits="appWeb1.app.Formulario_web1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" Visible =" false">
    <div class="row-fluid" id="divFiltrosBusqueda" runat="server">
            <h1>Consultar Playa</h1>
        <div class="span6">
            <div class="control-group">
                <label class="control-label">
                    Nombre:
                </label>
                <div class="controls">
                    <asp:TextBox ID="txtFiltroNombre" runat="server"></asp:TextBox>
                    <asp:Button ID="btnConsultar" runat="server" CssClass="btn btn-success" OnClick="btnConsultar_Click" Text="Consultar" ValidationGroup="AbmcValidation" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="gvResultados" runat="server" CssClass="table table-condensed table-bordered table-striped table-hover"
        AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" EmptyDataText="No se encontraron Playas para los filtros utilizados">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" Visible="true" />
            <asp:BoundField DataField="Direccion" HeaderText="Direccion" Visible="true" />
            <asp:BoundField DataField="TipoPlaya" HeaderText="Tipo" Visible="true" />
            <asp:BoundField DataField="Latitud" HeaderText="Latitud" Visible="true" />
            <asp:BoundField DataField="Longitud" HeaderText="Longitud" Visible="true" />
            <asp:TemplateField HeaderText="Editar">
                <ItemStyle CssClass="grilla-columna-accion" />
                <ItemTemplate>
                    <asp:Button ID="btnEditar" runat="server" CommandArgument="<%# Container.DataItemIndex %>"
                        CommandName="Editar" CssClass="icon icon-grilla icon-edit" />
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Eliminar">
                <ItemStyle CssClass="grilla-columna-accion" />
                <ItemTemplate>
                    <asp:Button ID="btnEliminar" runat="server" CommandArgument="<%# Container.DataItemIndex %>"
                        CommandName="Eliminar" CssClass="icon icon-grilla icon-delete" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h1>
        <asp:Label id="Titulo" runat="server" ></asp:Label>
    </h1>
    <asp:HiddenField runat="server" ID="hfId" />
    <div class="row-fluid">
        <div class="span6">
            <div class="control-group">
                <label class="control-label">
                    Nombre(*):</label>
                <div class="controls">
                    <asp:TextBox ID="txtNombre" runat="server" MaxLength="100"></asp:TextBox>
                </div>
                <label class="control-label">
                    Direccion(*):
                </label>
                <div class="controls">
                    <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
                </div>
                <label class="control-label">
                    Tipo(*):
                </label>
                <div class="controls">
                    <asp:DropDownList ID="ddlTipoPlaya" runat="server">
                    </asp:DropDownList>
                </div>
                <label class="control-label">
                    Capacidad(*):
                </label>
                <div class="controls">
                    <asp:TextBox ID="txtCapacidad" runat="server"></asp:TextBox>
                </div>

                <div>
                    <div id="map-canvas"></div>
                    <asp:TextBox ID="txtLatitud" runat="server" ClientIDMode="Static"></asp:TextBox>
                    <asp:TextBox ID="txtLongitud" runat="server" ClientIDMode="Static"></asp:TextBox>
                </div>

                <label class="control-label">
                    Horario(*):
                </label>
                <div class="controls">
                    <asp:RadioButton ID="rbTodo" Text="24 hs" runat="server" GroupName="horario"></asp:RadioButton>
                </div>
                <div class="controls">
                    <asp:RadioButton ID="rbOtro" runat="server" GroupName="horario"></asp:RadioButton>
                    <label class="control-label">
                        Desde(*):
                    </label>
                    <div class="controls">
                        <asp:TextBox ID="txtDesde" runat="server"></asp:TextBox>
                    </div>
                    <label class="control-label">
                        Hasta(*):
                    </label>
                    <div class="controls">
                        <asp:TextBox ID="txtHasta" runat="server"></asp:TextBox>
                    </div>
                    <div class="controls">
                        <label class="control-label">
                            Motos(*):
                        </label>
                        <asp:CheckBox ID="chkMotos" runat="server"></asp:CheckBox>
                        <label class="control-label">
                            Bicis(*):
                        </label>
                        <asp:CheckBox ID="chkBicis" runat="server"></asp:CheckBox>
                        <label class="control-label">
                            Utilitarios(*):
                        </label>
                        <asp:CheckBox ID="chkUtilitarios" runat="server"></asp:CheckBox>
                    </div>
                </div>
            </div>
            <div class="form-actions">
                <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnGuardar_Click" />
                <asp:Button ID="btnCancelar" runat="server" CausesValidation="False" CssClass="btn" Text="Cancelar" OnClick="btnCancelar_Click" />
            </div>
        </div>
    </div>
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>
    <script>
        // In the following example, markers appear when the user clicks on the map.
        // The markers are stored in an array.
        // The user can then click an option to hide, show or delete the markers.
        var map;
        var markers = [];

        function initialize() {

            if (document.getElementById('txtLatitud').value == "") {
                var haightAshbury = new google.maps.LatLng(-31.416756, -64.183501);
            }
            else {
                var latitud = document.getElementById('txtLatitud').value;
                var longitud = document.getElementById('txtLongitud').value
                var haightAshbury = new google.maps.LatLng(latitud, longitud);
            }
            
            var mapOptions = {
                zoom: 17,
                center: haightAshbury,
                mapTypeId: google.maps.MapTypeId.SATELLITE
            };
            map = new google.maps.Map(document.getElementById('map-canvas'),
                mapOptions);

            // This event listener will call addMarker() when the map is clicked.
            google.maps.event.addListener(map, 'click', function (event) {
                deleteMarkers();
                addMarker(event.latLng);
                document.getElementById('txtLatitud').value = event.latLng.lat();
                document.getElementById('txtLongitud').value = event.latLng.lng();               
               
            });

            // Adds a marker at the center of the map.
            addMarker(haightAshbury);
        }

        //Agregar el marcador en la posicion establecida
        function addMarker(location) {

            map.setOptions({
                center: location,
            });

            var marker = new google.maps.Marker({
                position: location,
                map: map
            });
            markers.push(marker);
        }

        // seteo seteo el marcador en el mapa
        function setAllMap(map) {
            markers[0].setMap(map);
        }

        // Borro los marcadores del array y del mapa
        function deleteMarkers() {
            setAllMap(null);
            markers = [];
        }

        function loadScript() {
            var script = document.createElement("script");
            script.type = "text/javascript";
            script.src = "https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false&callback=initialize";
            document.body.appendChild(script);
        }

        window.onload = loadScript;

        //google.maps.event.addDomListener(window, 'onload', initialize);

    </script>
</asp:Content>
