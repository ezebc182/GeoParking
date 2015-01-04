$.widget( "geoparking.preferenciasWidget", {
	options : {
		tipoVehiculoId : null,
		radio : null,
		gpsOnOff : null,
		contenedor : $("#panelConfiguraciones")
	},
	_create : function(){
		var widget = this;
	},
	_init : function(){
		var widget = this;
		if(widget.options.contenedor.children().length === 0){
            $("#pnlMapa").hide();
			widget._crearHTMLInicial();
			widget._agregarTiposDeVehiculos();
			widget._cargarValoresAlmacenados();
		}
		else{
			widget.options.contenedor.empty();
            $("#pnlMapa").show();
		}
	},
	_crearHTMLInicial : function () {
		var widget = this;
		/*var container = document.createElement("div");
        container.className="ui-content";
        container.role="main";
        container.setAttribute("data-role","content");
        
        var form = document.createElement("form");
       
        var listado = document.createElement("ul");
        listado.className="ui-listview ui-listview-inset ui-corner-all ui-shadow";
        listado.setAttribute("data-role","listview");
        listado.setAttribute("data-inset","true");
        
        //Combo Tipo vehiculo
        var liTipoVehiculo = document.createElement("li");
        liTipoVehiculo.className = "ui-field-contain ui-li-static ui-body-inherit";
        liTipoVehiculo.setAttribute("data-role","fieldcontain");
        
        var labelTipoVehiculo = document.createElement("label");
        labelTipoVehiculo.className="select";
        labelTipoVehiculo.setAttribute("for","select-choice-1b");
        labelTipoVehiculo.innerHTML="Tipo de Vehiculo";
        
        var divTipovehiculo = document.createElement("div");
        divTipovehiculo.className="ui-select";
        
        var comboTipoVehiculo = document.createElement("select");
        comboTipoVehiculo.setAttribute("name","select-choice-1");
        comboTipoVehiculo.id = "tipoVehiculoSelect";
        comboTipoVehiculo.setAttribute("data-native-menu","true");
        
        var opcionSelecione = document.createElement("option");
        opcionSelecione.value=0;
        opcionSelecione.innerHTML="Seleccione";
        
        comboTipoVehiculo.appendChild(opcionSelecione);
        divTipovehiculo.appendChild(comboTipoVehiculo);
        liTipoVehiculo.appendChild(labelTipoVehiculo);
        liTipoVehiculo.appendChild(divTipovehiculo);
        listado.appendChild(liTipoVehiculo);
        
        //Slide radio distancia
        var liRadio = document.createElement("li");
        liRadio.className = "ui-field-contain ui-li-static ui-body-inherit";
        liRadio.setAttribute("data-role","fieldcontain");
        
        var labelRadio = document.createElement("label");
        labelRadio.className="select";
        labelRadio.setAttribute("for","slider2b");
        labelRadio.id=id="slider2b-label";*/
        
        widget.options.contenedor.append('<div data-role="content" class="ui-content" role="main"><form><ul data-role="listview" data-inset="true" class="ui-listview ui-listview-inset ui-corner-all ui-shadow" id="listadoConfiguraciones" ><li data-role="fieldcontain" class="ui-field-contain ui-li-static ui-body-inherit"><label for="select-choice-1b" class="select">Select</label><div class="ui-select"><select name="select-choice-1" id="tipoVehiculoSelect" data-native-menu="true"><option value="0">Seleccione</option></select></div></div></li><li data-role="fieldcontain" class="ui-field-contain ui-li-static ui-body-inherit"><label for="slider2b" id="slider2b-label">Radio:</label><input type="number" data-type="range" name="slider2" id="slider2b" value="100" min="100" max="1000" data-highlight="true" class="ui-shadow-inset ui-body-inherit ui-corner-all ui-slider-input"></li><li data-role="fieldcontain" class="ui-field-contain ui-li-static ui-body-inherit"><label for="checkbox-based-flipswitch">GPS:</label><input type="checkbox" id="checkbox-based-flipswitch" data-role="flipswitch"></li><li class="ui-li-static ui-body-inherit ui-last-child"><button type="submit" data-inline="true" class=" ui-btn ui-btn-inline ui-shadow ui-corner-all"><i class="lIcon fa fa-check"></i>Guardar</button><button type="reset" data-inline="true" class=" ui-btn ui-btn-inline ui-shadow ui-corner-all"><i class="lIcon fa fa-times"></i>Cancelar</button></li></ul></form></div>');
        $('select').selectmenu();
        $(" input[type=number]").slider();
        $(" input[type=checkbox]").flipswitch();
        $("#listadoConfiguraciones").append($(" input[type=number]").parent().parent());
        $("#listadoConfiguraciones").append($(" label[for=checkbox-based-flipswitch]").parent());
        $("#listadoConfiguraciones").append($(" button[type=submit]").parent());
        //$(" button[type=submit]").parent()
        //$(" label[for=flip2b]").parent()
        //$(" input[type=number]").parent().parent();
	},
	_cargarValoresAlmacenados : function () {
		var widget = this;
		widget.options.radio = leerPropiedadRadio();
		widget.options.tipoVehiculoId = leerPropiedadTipoVehiculo();
		$('#tipoVehiculoSelect').val(widget.options.tipoVehiculoId);
		
	},
	_guardarValoresSeleccionados : function () {
		var widget = this;
	},
	_obtenerTiposVehiculosDeServidor : function (){
		var uri = obtenerURLServer() + "api/playas/GetTiposVehiculo";
		var tiposVehiculos = null;
		$.ajax({
			type: "GET",
			async: false,
			url: uri,
			success: function (response) {
				tiposVehiculos = jQuery.parseJSON(response);
			}
		});
		return tiposVehiculos;
	},
	_agregarTiposDeVehiculos : function() {
		var widget = this;
		var tiposVehiculos = widget._obtenerTiposVehiculosDeServidor();
		for(var i = 0; i < tiposVehiculos.length; i++){
			var opcion = document.createElement("option");
			opcion.value = tiposVehiculos[i].Id;
			opcion.innerHTML = tiposVehiculos[i].Nombre;
			 $('#tipoVehiculoSelect').append(opcion);
		}
	}
});
