$.widget( "geoparking.listadoPlayasWidget", {
	/**
	* Opciones del widget, se usan para tener un acceso
	* global a estas variables y son seteadas al iniciar el widget.
	*/
	options : {
		contenedor : $("#panelListado"),
		listadoPlayas : null,
		playaElegida : null,
        disponibilidadPlayas : null
	},
	/**
	* Metodo de creacion del widget, tiene que existir en todo widget.
	* Para crear el widget con las playas se lo debe invocar de la  siguiente manera:
	* $("#idDeAlgunElemento").listadoPlayasWidget({ listadoPlayasplayas : unJsonDePlayas});
	*/
	_create : function(){
		var widget = this;
	},
    /**
	* Este metodo se llama cada vez que se invoca el widget sin un metodo por parametro;
	*/
    _init: function() {
        var widget = this;
		if($("#acordion").length === 0){
			widget._crearListado();
		}
		else{
			widget.destroy();
		}
    },
	/**
	* El metodo destroy tiene la responsabilidad de elimnar todos 
	* los elementos creados por el widget.
	*/
	destroy : function() {
		var widget = this;
        $("#listadoPlayasId").remove();
        $("#pnlMapa").show();
		widget.options.contenedor.empty();
		$.Widget.prototype.destroy.call(this);
	},
	/**
	* Este metodo verifica que se hayan encontrado playas 
	* cercanas a la posicion del vehiculo.
	*/
	_crearListado : function(){
		var widget = this;
        //widget._filtrarPlayasPorDistancia();
        if( widget.options.listadoPlayas.length === 0){
            mensajeErrorConexion("No se encontraron playas cercanas");
        }
        else{
            var ul = widget._cargarListado();
			ul.id = "listadoPlayasId";
			$("#pnlMapa").hide();
			$("#panelListado").append(ul);
			$("#listadoPlayasId").attr("data-role","listview");
			$("#listadoPlayasId").attr("data-insert","false");
			$("#listadoPlayasId").attr("data-divider-them","b");
        }
	},
	/**
	* Se encarga  de el acordion donde se mostraran 
	* las playas encontradas cercanas.
	*/
	_cargarListado : function(){
		var widget = this;
		var listado = document.createElement("ul");		
		widget._obtenerDisponibilidadParaPlayas();
        widget._ordenarPlayasPorDisponiblidad();
		for(var i = 0; i < widget.options.listadoPlayas.length; i++){
			var playa = widget.options.listadoPlayas[i];
			widget._crearEntradaParaPlaya(playa, listado);
		}
		return listado;
	},
	_crearEntradaParaPlaya : function(playa, listado){
        var widget = this;
		
		var itemListado= document.createElement("li");
		var itemA = document.createElement("a");
		itemA.onclick= widget._crearEventoClickAPlaya(playa);
		
        var header = document.createElement("h3");
        header.innerHTML = widget._crearHeaderParaPlaya(playa);
		
		var parrafoDireccion = document.createElement("p");
		var	direccion = playa.Direcciones[0].Calle;
		direccion += " ";
		direccion += playa.Direcciones[0].Numero;
		parrafoDireccion.innerHTML=direccion;
		
		var parrafoDistancia = document.createElement("p");
		parrafoDistancia.className="ui-li-aside";
		var strongDistnacia = document.createElement("strong");
		var distancia = widget._calcularDistanciaPlaya(playa);
		strongDistnacia.innerHTML=distancia;
		
		//Todos los append
		parrafoDistancia.appendChild(strongDistnacia);
		itemA.appendChild(header);
		itemA.appendChild(parrafoDireccion);
		itemA.appendChild(parrafoDistancia);
		itemListado.appendChild(itemA);
		listado.appendChild(itemListado);
	},
	_crearHeaderParaPlaya : function(playa){
		var header = "";
		header += playa.Nombre;
		header += " - ";
		header += playa.Precios[0].Monto;
		return header;
	},
	_crearEventoClickAPlaya : function (playa){
		var widget = this;
		var posicionPlayaGoogle = new google.maps.LatLng(playa.Latitud, playa.Longitud);
		var eventoClick = function(){
            widget.destroy();			
			ir(posicionActual, posicionPlayaGoogle, "DRIVING","METRIC");
			widget.options.playaElegida = posicionPlayaGoogle;
		};
		return eventoClick;
	},
	/**
	* Dada una playa, calcula y retorna la distancia entre dicha playa y la posicion actual del movil.
	*/
	_calcularDistanciaPlaya : function (playa){
        var lat1 = parseFloat(playa.Latitud);
        var lon1 = parseFloat(playa.Longitud);
        var lat2 = parseFloat(posicionActual.k);
        var lon2 = parseFloat(posicionActual.D);
        var distancia = distanciaEntreDosPuntos(lat1, lon1, lat2, lon2) * 1000;
        distancia = distancia.toFixed(2);
        return distancia;
	},
	/**
	* Lee en el localStorage la distancia guardada por el usuario en el panel configuraciones, 
	* si no existe ninguna almacenada, devuelve 500 (valor por defecto).
	*/
	_obtenerDistanciaPredeterminada : function (){
		var configuraciones = localStorage.getItem("Configuraciones");
		if(configuraciones !== null){
			configuraciones = jQuery.parseJSON(configuraciones);
			return parseInt(configuraciones.radio);
		}
		return 500;
	},
	/**
	* Obtiene el tipo de vehiculo almacenado en el localStorage
	* que fue guardado en el panel configuraciones.
	*/
	_obtenerTipoVehiculoPredeterminado : function (){
		var configuraciones = localStorage.getItem("Configuraciones");
		if(configuraciones !== null){
			configuraciones = jQuery.parseJSON(configuraciones);
			return configuraciones.tipoVehiculo;
		}
		return "0";
	},
	/**
	* Obtiene la playa elegida (este metodo es publico)
	*/
	obtenerPlayaElegida : function() {
		var widget = this;
		return widget.options.playaElegida;
	},
	/**
	* Filtra el listado de playas recibido por parametro en el widget
	* dejando solo aquellas que se encuentran a una distancia en linea 
	* recta menor al radio seleccionado en el panel de condifuraciones
	*/
	_filtrarPlayasPorDistancia : function(){
        var widget = this;
		var playasFiltradas = [];
		var distanciaAFiltrar = widget._obtenerDistanciaPredeterminada();
		for(var i = 0; i < widget.options.listadoPlayas.length; i++){
			var playa = widget.options.listadoPlayas[i];
			var distanciaPlaya = widget._calcularDistanciaPlaya(playa);
			if(distanciaPlaya <= distanciaAFiltrar){
				playasFiltradas.push(playa);
			}
		}
		widget.options.listadoPlayas = playasFiltradas;
        
	},
	/**
	* Toma el listado de playas seleccionado (deberia ya estar filtrado por distancia)
	* y pide para esas playas la disponibilidad en base al tipo de vehiculo seleccionado
	*/
	_obtenerDisponibilidadParaPlayas : function(){
		var widget = this;
		var idPlayas = [];
		for(var i = 0; i < widget.options.listadoPlayas.length; i++){
			var playa = widget.options.listadoPlayas[i];
			idPlayas.push(playa.Id);
		}
		var tipoVehiculo = widget._obtenerTipoVehiculoPredeterminado();
		var uri = obtenerURLServer() + 'api/disponibilidad/GetDisponibilidadesPlayasPorTipoVehiculo?idPlayas=' + idPlayas.toString() + '&idTipoVehiculo=' +tipoVehiculo;
        var disponibilidades = widget.options.disponibilidadPlayas;
        $.ajax({
            type: "GET",
            url: uri,
            async : false,
            success: function (data) {
                disponibilidades = (typeof data) == 'string' ?
                    eval('(' + data + ')') :
                    data;
                widget.options.disponibilidadPlayas = disponibilidades;
                widget._agregarDisponibilidadAListadoPlayas();

            },
            error: function (jqXHR, textStatus, errorThrown) {
                
            }
        });
	},
	/**
	* Se encarga de ordenar el listado de playas por disponibilidad.
	*/
	_ordenarPlayasPorDisponiblidad : function(){
		var widget = this;
		var funcionDeOrden = function(a, b){
			return (parseInt(b.Disponibilidad) - parseInt(a.Disponibilidad));
		}
		widget.options.listadoPlayas = widget.options.listadoPlayas.sort(funcionDeOrden);
	},
    /**
    * 
    */
    _agregarDisponibilidadAListadoPlayas : function(){
        var widget = this;
        for(var i = 0; i < widget.options.listadoPlayas.length; i++){
            widget.options.listadoPlayas[i]['Disponibilidad'] = widget._obtenerDisponibilidadDePlayaPorId(widget.options.listadoPlayas[i].Id);
		}
    },
    /**
    * 
    */
    _obtenerDisponibilidadDePlayaPorId : function(idPlaya) {
        var widget = this;
        for(var i = 0; i < widget.options.disponibilidadPlayas.length; i++){
            if(widget.options.disponibilidadPlayas[i].PlayaDeEstacionamientoId === idPlaya){
                return widget.options.disponibilidadPlayas[i].Disponibilidad;
            }
        }
        return 0;
    }
});