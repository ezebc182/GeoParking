$.widget( "geoparking.contactoWidget", {
	options : {
		nombre : null,
		apellido : null,
		telefono : null,
		email : null,
		mensaje : null,
		contenedor : $("#panelContacto")
	},
	_create : function(){
		var widget = this;
	},
    /**
    * Verifica si ya existe o el panel de contactos y lo crea o elimina 
    * segun corresponda, se ejecuta cada vez que se hace la llamadad $("algun selector").contactoWidget();
    */
	_init : function(){
		var widget = this;
		if(widget.options.contenedor.children().length === 0){
            $("#pnlMapa").hide();
			widget._crearHTMLInicial();
            $("a[href=#mypanel]").click();
		}
		else{
			widget.destroy();
		}
	},
    /**
    * Se destruye el widget limpiando todos los componentes que creo
    */
    destroy : function(){
        var widget = this;
        widget.options.contenedor.empty();
        $("#pnlMapa").show();
        $.Widget.prototype.destroy.call(this);
    },
    /**
    * Crea la estructura inicial del panel de contacto
    */
	_crearHTMLInicial : function () {
		var widget = this;
        widget.options.contenedor.append('<div data-role="content" class="ui-content" role="main"><form data-ajax="false"><ul data-role="listview" data-inset="true" class="ui-listview ui-listview-inset ui-corner-all ui-shadow" id="listadoConfiguraciones" ><li data-role="fieldcontain" class="ui-field-contain ui-li-static ui-body-inherit"><label for="nombre">Nombre:</label><div class="ui-input-text ui-body-inherit ui-corner-all ui-shadow-inset ui-input-has-clear"><input type="text" name="nombre" id="nombre" value="" data-clear-btn="true" placeholder="Ingrese su nombre aqui"><a href="#" class="ui-input-clear ui-btn ui-icon-delete ui-btn-icon-notext ui-corner-all ui-input-clear-hidden" title="Clear text">Borrar nombre</a></div></li><li data-role="fieldcontain" class="ui-field-contain ui-li-static ui-body-inherit"><label for="apellido">Apellido:</label><div class="ui-input-text ui-body-inherit ui-corner-all ui-shadow-inset ui-input-has-clear"><input type="text" name="apellido" id="apellido" value="" data-clear-btn="true" placeholder="Ingrese su apellido aqui"><a href="#" class="ui-input-clear ui-btn ui-icon-delete ui-btn-icon-notext ui-corner-all ui-input-clear-hidden" title="Clear text">Borrar apellido</a></div></li><li data-role="fieldcontain" class="ui-field-contain ui-li-static ui-body-inherit"><label for="telefono">Teléfono:</label><div class="ui-input-text ui-body-inherit ui-corner-all ui-shadow-inset ui-input-has-clear"><input type="text" name="telefono" id="telefono" value="" data-clear-btn="true" placeholder="Ingrese su telefono aqui"><a href="#" class="ui-input-clear ui-btn ui-icon-delete ui-btn-icon-notext ui-corner-all ui-input-clear-hidden" title="Clear text">Borrar teléfono</a></div></li><li data-role="fieldcontain" class="ui-field-contain ui-li-static ui-body-inherit"><label for="inputEmail">Ingrese su email:</label><div class="ui-input-text ui-body-inherit ui-corner-all ui-shadow-inset ui-input-has-clear"><input type="email" name="inputEmail" id="inputEmail" value="" data-clear-btn="true" placeholder=""><a href="#" class="ui-input-clear ui-btn ui-icon-delete ui-btn-icon-notext ui-corner-all ui-input-clear-hidden" title="Clear text">Borrar email</a></div></li><li data-role="fieldcontain" class="ui-field-contain ui-li-static ui-body-inherit"><label for="mensaje">Textarea:</label><textarea cols="40" rows="8" name="mensaje" id="mensaje" placeholder="Mensaje, duda o consulta" class="ui-input-text ui-shadow-inset ui-body-inherit ui-corner-all ui-textinput-autogrow" style="height: 53px;"></textarea></li><li class="ui-li-static ui-body-inherit ui-last-child"><div class="ui-btn ui-input-btn ui-corner-all ui-shadow">Enviar<input id="btnEnviarContacto" type="submit" value="Guardar"></div><div class="ui-btn ui-input-btn ui-corner-all ui-shadow">Cancelar<input id="btnCancelarContacto" type="submit" value="Cancelar"></div></li></ul></form></div>');
        $("#btnEnviarContacto").click(function(){
			$("#panelContacto").contactoWidget("tomarDatosFormulario");
		});
        /*$("#btnCancelarContacto").click(function(){
			$("#panelContacto").contactoWidget("destroy");
		});*/
        var loaderOff = function(){
            $.mobile.loading( "hide" );
        }
        setTimeout(loaderOff,300);
	},
    /**
    * Toma los datos del formulario para enviarlos por mail
    */
	tomarDatosFormulario : function(){
		var widget = this;
		var datos = {
			Nombre : $("#nombre").val(),
			Apellido : $("#apellido").val(),
			Telefono : $("#telefono").val(),
			Email : $("#inputEmail").val(),
			Mensaje : $("#mensaje").val()
		};
		widget._enviarFormulario(datos);
	},
    /**
    * Envia los datos recibidos por mail (a traves del servidor)
    */
	_enviarFormulario : function(datos){
		var widget = this;
		var uri = obtenerURLServer() + "api/Contacto/PostEnviarEmailDeContacto";
		$.ajax({
			type: "POST",
			url: uri,
			data: datos,
			dataType: "json",
			content: "application/json; charset=utf-8",
			success: function(){
				alert("se envio la consulta");
                widget.destroy();
			},
		});
	}
});