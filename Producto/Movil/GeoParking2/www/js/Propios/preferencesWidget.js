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
    /**
    * Verifica si ya existe o el panel de configuraciones y lo crea o elimina 
    * segun corresponda, se ejecuta cada vez que se hace la llamadad $("algun selector").preferenciasWidget();
    */
	_init : function(){
		var widget = this;
		if(widget.options.contenedor.children().length === 0){
            $("#pnlMapa").hide();
			widget._crearHTMLInicial();
			widget._agregarTiposDeVehiculos();
			widget._cargarValoresAlmacenados();
            $("a[href=#mypanel]").click();
		}
		else{
			widget.destroy();
		}
	},
    destroy : function(){
        var widget = this;
        widget.options.contenedor.empty();
        $("#pnlMapa").show();
        //window.location.replace("index.html");
        $.Widget.prototype.destroy.call(this);
    },
    /**
    * Crea la estructura inicial de la pantalla de configuraciones
    */
	_crearHTMLInicial : function () {
		var widget = this;
        widget.options.contenedor.append('<div data-role="content" class="ui-content" role="main"><form data-ajax="false"><ul data-role="listview" data-inset="true" class="ui-listview ui-listview-inset ui-corner-all ui-shadow" id="listadoConfiguraciones" ><li data-role="fieldcontain" class="ui-field-contain ui-li-static ui-body-inherit"><label for="select-choice-1b" class="select">Select</label><div class="ui-select"><select name="select-choice-1" id="tipoVehiculoSelect" data-native-menu="true"><option value="0">Seleccione</option></select></div></li><li data-role="fieldcontain" class="ui-field-contain ui-li-static ui-body-inherit"><label for="slider2b" id="slider2b-label">Radio:</label><input type="number" data-type="range" name="slider2" id="slider2b" value="100" min="100" max="1000" data-highlight="true" class="ui-shadow-inset ui-body-inherit ui-corner-all ui-slider-input"></li><li data-role="fieldcontain" class="ui-field-contain ui-li-static ui-body-inherit"><label for="checkbox-based-flipswitch">GPS:</label><input type="checkbox" id="checkbox-based-flipswitch" data-role="flipswitch"></li><li class="ui-li-static ui-body-inherit ui-last-child"><div class="ui-btn ui-input-btn ui-corner-all ui-shadow">Guardar<input id="btnGuardarConfig" type="submit" value="Guardar"></div><div class="ui-btn ui-input-btn ui-corner-all ui-shadow">Cancelar<input id="btnCancelarConfig" type="submit" value="Cancelar"></div></li></ul></form></div>');
        widget._incializarWindgetDeControles();
	},
    /**
    * incializa los winget de los controles y los reubica dentro del listado de controles
    */
    _incializarWindgetDeControles : function(){
        $('select').selectmenu();
        $(" input[type=number]").slider();
        $(" input[type=checkbox]").flipswitch();
        
        $("#btnGuardarConfig").parent().click(function(){
            $("#panelConfiguraciones").preferenciasWidget("guardarValoresSeleccionados");
        });
        $("#btnCancelarConfig").parent().click(function(){
            $("#panelConfiguraciones").preferenciasWidget("destroy");
        });
        
        $("#listadoConfiguraciones").append($(" input[type=number]").parent().parent());
        $("#listadoConfiguraciones").append($(" label[for=checkbox-based-flipswitch]").parent());
        $("#listadoConfiguraciones").append($(" button[type=submit]").parent());
        $("#listadoConfiguraciones").append($("#btnGuardarConfig").parent().parent());
    },
    /**
    * Toma los valores del local storage y setea los valores de los controles
    */
	_cargarValoresAlmacenados : function () {
		var widget = this;
		widget.options.radio = leerPropiedadRadio();
		widget.options.tipoVehiculoId = leerPropiedadTipoVehiculo();
        widget.options.gpsOnOff = leerPropiedadGPS();
		$('#tipoVehiculoSelect').val(widget.options.tipoVehiculoId);
        $("#tipoVehiculoSelect-button > span").html($('select option:selected').html());
        $(" input[type=number]").val(widget.options.radio);
        var porcentajeBarra = ((widget.options.radio - 100) / 900) * 100;
        $($(" input[type=number]").parent().children()[1]).children()[0].style.width = porcentajeBarra +"%";
        $($(" input[type=number]").parent().children()[1]).children()[1].style.left = porcentajeBarra +"%";
        $($($(" input[type=number]").parent().children()[1]).children()[1]).attr("aria-valuetext",widget.options.radio);
        $($($(" input[type=number]").parent().children()[1]).children()[1]).attr("aria-valuenow",widget.options.radio);
        $($($(" input[type=number]").parent().children()[1]).children()[1]).attr("title",widget.options.radio);
        if(!($(" input[type=checkbox]").parent().hasClass("ui-flipswitch-active")) && widget.options.gpsOnOff){
            $(" input[type=checkbox]").parent().addClass("ui-flipswitch-active");
        }
        else if($(" input[type=checkbox]").parent().hasClass("ui-flipswitch-active") && !widget.options.gpsOnOff){
            $(" input[type=checkbox]").parent().removeClass("ui-flipswitch-active");
        }
	},
	guardarValoresSeleccionados : function () {
        var widget = this;
        widget.options.tipoVehiculoId = $('select option:selected').val()
        widget.options.radio = $(" input[type=number]").val();
        widget.options.gpsOnOff = $(" input[type=checkbox]").parent().hasClass("ui-flipswitch-active");
        var configuraciones = {
            tipoVehiculo : widget.options.tipoVehiculoId,
            radio : widget.options.radio,
            gps : widget.options.gpsOnOff
        };
        localStorage.setItem("Configuraciones", JSON.stringify(configuraciones));
        
        widget.destroy();
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
