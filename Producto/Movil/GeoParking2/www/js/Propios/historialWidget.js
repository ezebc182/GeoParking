$.widget("geoparking.historialWidget", {
    /**
     * Opciones del widget, se usan para tener un acceso
     * global a estas variables y son seteadas al iniciar el widget.
     */
    options: {
        contenedor: $("#listadoHistorial"),
        cantidadHistorial: 5,
        playaElegida: null,
        listadoPlayas: null,
        disponibilidadPlayas: null
    },
    /**
     * Metodo de creacion del widget, tiene que existir en todo widget.
     * Para crear el widget con las playas se lo debe invocar de la  siguiente manera:
     * $("#idDeAlgunElemento").historialWidget({ listadoPlayasplayas : unJsonDePlayas});
     */
    _create: function () {
        var widget = this;
    },
    /**
     * Este metodo se llama cada vez que se invoca el widget sin un metodo por parametro;
     */
    _init: function () {
        var widget = this;
        if ($("#listado-historial").length === 0) {
            widget._cargarListadoHistorial();
        } else {}
        quitarCargando();
    },
    /**
     * El metodo destroy tiene la responsabilidad de elimnar todos
     * los elementos creados por el widget.
     */
    destroy: function () {
        var widget = this;
        $("#listado-historial").remove();
        widget.options.contenedor.empty();
        $.Widget.prototype.destroy.call(this);
    },

    /*
    Carga el historial consultado por el usuario con un máximo configurable de playas a  mostrar
    */
    _cargarListadoHistorial: function () {
        var widget = this;
        if (db.getItem("playas") === null || JSON.parse(db.getItem("playas").length === 0)) {
            $("#listadoHistorial").html("");
            $("#listadoHistorial").append("<p class='historial' >El historial está vacío</p>");
        } else {
            widget.crearEstructuraHistorial();
        }
    },
    _crearEventoClickAPlayaSinGuardarConsulta: function (playa) {
        var widget = this;

        var posicionPlayaGoogle = new google.maps.LatLng(playa.Latitud, playa.Longitud);
        var eventoClick = function () {
            ir(posicionActual, posicionPlayaGoogle, "DRIVING", "METRIC");
            $("#pnlPrincipal").panel("close");
            widget.options.playaElegida = posicionPlayaGoogle;
            enviarConsultaAEstadisticas(playa);
        };
        return eventoClick;
    },
    _crearDescripcionParaPlaya: function (playa) {
        var widget = this;
        var description = "";
        description = playa.Calle;
        description += " ";
        description += playa.Numero;
        description += " - ";
        description += widget._calcularDistanciaPlaya(playa) + " Metros";
        return description;

    },
    /**
     * Dada una playa, calcula y retorna la distancia entre dicha playa y la posicion actual del movil.
     */
    _calcularDistanciaPlaya: function (playa) {
        var lat1 = parseFloat(playa.Latitud);
        var lon1 = parseFloat(playa.Longitud);
        var lat2 = parseFloat(posicionActual.k);
        var lon2 = parseFloat(posicionActual.D);
        var distancia = distanciaEntreDosPuntos(lat1, lon1, lat2, lon2) * 1000;
        distancia = distancia.toFixed(1);
        return distancia;
    },
    crearEstructuraHistorial: function () {
        var widget = this;
        var arrayPlayas = JSON.parse(db.getItem("playas"));
        widget.options.listadoPlayas = arrayPlayas;
        widget._obtenerPrecioPlayasSeleccionadas();
        widget._obtenerDisponibilidadParaPlayas();
        var listado = document.createElement("ul");
        listado.className = "ui-listview";
        listado.id = "listado-historial";
        $(".historial").remove();
        $.each(widget.options.listadoPlayas.reverse(), function (indX, playa) {

            var itemListado = document.createElement("li");
            itemListado.className = "historial";
            var itemA = document.createElement("a");
            itemA.className = "ui-btn";
            var posicionPlayaGoogle = new google.maps.LatLng(playa.Latitud, playa.Longitud);
            itemA.onclick = widget._crearEventoClickAPlayaSinGuardarConsulta(playa);
            itemA.setAttribute("data-rel", "close");
            var header = document.createElement("h2");
            header.innerHTML = playa.Nombre;
            var parrafoDireccion = document.createElement("p");
            parrafoDireccion.innerHTML = widget._crearDescripcionParaPlaya(playa);
            var parrafoPrecioa = document.createElement("p");
            parrafoPrecioa.className = "ui-li-aside";
            var strongPrecio = document.createElement("strong");
            var precio;
            if (playa.Precios && playa.Precios.length > 0) {
                precio = playa.Precios[0].Tiempo;
                precio += ": $";
                precio += playa.Precios[0].Monto;
            } else {
                precio = "Sin precio";
            }
            strongPrecio.innerHTML = precio;
            //Todos los append
            parrafoPrecioa.appendChild(strongPrecio);
            itemA.appendChild(header);
            itemA.appendChild(parrafoDireccion);
            itemA.appendChild(parrafoPrecioa);
            itemListado.appendChild(itemA);
            listado.appendChild(itemListado);
        });
        $("#listadoHistorial").append(listado);
    },
    retornarCantidadPlayasAGuardar: function () {
        var widget = this;
        return widget.options.cantidadHistorial;
    },
    /**
     * Toma el listado de playas seleccionado (deberia ya estar filtrado por distancia)
     * y pide para esas playas los precios en base al tipo de vehiculo seleccionado
     */
    _obtenerPrecioPlayasSeleccionadas: function () {
        var widget = this;
        var idPlayas = [];
        for (var i = 0; i < widget.options.listadoPlayas.length; i++) {
            var playa = widget.options.listadoPlayas[i];
            idPlayas.push(playa.Id);
        }
        var uri = obtenerURLServer() + 'api/Precios/GetObtenerPreciosPlayas?idPlayas=' + idPlayas.toString() + '&idTipoVehiculo=' + leerPropiedadTipoVehiculo();
        var precios;
        $.ajax({
            type: "GET",
            url: uri,
            async: false,
            success: function (data) {
                precios = (typeof data) == 'string' ?
                    eval('(' + data + ')') :
                    data;
                widget._agregarPreciosAPlayas(precios);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                abrirDialogoConDosBotones(null, "Error de conexion. Inténtelo de nuevo mas tarde", "Algo sucedió...");
            }
        });
    },
    /**
     *
     */
    _agregarPreciosAPlayas: function (precios) {
        var widget = this;
        for (var i = 0; i < widget.options.listadoPlayas.length; i++) {
            var playa = widget.options.listadoPlayas[i];
            playa['Precios'] = widget._obtenerPreciosDePlaya(playa.Id, precios);
        }
    },
    /**
     *
     */
    _obtenerPreciosDePlaya: function (playaId, precios) {
        var preciosDePlaya = [];
        for (var i = 0; i < precios.length; i++) {
            if (precios[i].IdPlaya === playaId) {
                preciosDePlaya.push(precios[i]);
            }
        }
        return preciosDePlaya;
    },
    /**
     *
     */
    _agregarDisponibilidadYNombreAListadoPlayas: function () {
        var widget = this;
        for (var i = 0; i < widget.options.listadoPlayas.length; i++) {
            var idPlaya = widget.options.listadoPlayas[i].Id;
            widget.options.listadoPlayas[i]['Nombre'] = widget._obtenerNombreDePlayaPorId(idPlaya);
        }
    },
    _obtenerNombreDePlayaPorId: function (idPlaya) {
        var widget = this;
        for (var i = 0; i < widget.options.disponibilidadPlayas.length; i++) {
            if (widget.options.disponibilidadPlayas[i].PlayaId === idPlaya) {
                return widget.options.disponibilidadPlayas[i].NombrePlaya;
            }
        }
        return "Sin Nombre";
    },
    /**
     * Toma el listado de playas seleccionado (deberia ya estar filtrado por distancia)
     * y pide para esas playas la disponibilidad en base al tipo de vehiculo seleccionado
     */
    _obtenerDisponibilidadParaPlayas: function () {
        var widget = this;
        var idPlayas = [];
        for (var i = 0; i < widget.options.listadoPlayas.length; i++) {
            var playa = widget.options.listadoPlayas[i];
            idPlayas.push(playa.Id);
        }
        var uri = obtenerURLServer() + 'api/disponibilidad/GetObtenerDisponibilidadesPlayasPorTipoVehiculo?idPlayas=' + idPlayas.toString() + '&idTipoVehiculo=' + leerPropiedadTipoVehiculo();
        var disponibilidades = widget.options.disponibilidadPlayas;
        $.ajax({
            type: "GET",
            url: uri,
            async: false,
            success: function (data) {
                disponibilidades = (typeof data) == 'string' ?
                    eval('(' + data + ')') :
                    data;
                widget.options.disponibilidadPlayas = disponibilidades;
                widget._agregarDisponibilidadYNombreAListadoPlayas();

            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert("No se pudo obtener las disponibilidades");
            }
        });
    }

});