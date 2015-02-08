$.widget("geoparking.listadoPlayasWidget", {
    /**
     * Opciones del widget, se usan para tener un acceso
     * global a estas variables y son seteadas al iniciar el widget.
     */
    options: {
        contenedor: $("#panelListado"),
        listadoPlayas: null,
        playaElegida: null,
        disponibilidadPlayas: null,
        cantidadHistorial: 5
    },
    /**
     * Metodo de creacion del widget, tiene que existir en todo widget.
     * Para crear el widget con las playas se lo debe invocar de la  siguiente manera:
     * $("#idDeAlgunElemento").listadoPlayasWidget({ listadoPlayasplayas : unJsonDePlayas});
     */
    _create: function () {
        var widget = this;
    },
    /**
     * Este metodo se llama cada vez que se invoca el widget sin un metodo por parametro;
     */
    _init: function () {
        var widget = this;
        //widget._empezarLoading();
        if ($("#listadoPlayasId").length === 0) {
            widget._crearListado();
        } else {
            widget.destroy();
        }
        quitarCargando();
        setTimeout(function () {
            $("#panelListado").listadoPlayasWidget("actualizarDisponibilidades");
        }, 2000);
    },
    /**
     * El metodo destroy tiene la responsabilidad de elimnar todos
     * los elementos creados por el widget.
     */
    destroy: function () {
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
    _crearListado: function () {
        var widget = this;
        widget._filtrarPlayasPorDistancia();
        if (widget.options.listadoPlayas.length === 0) {
            abrirDialogoConDosBotones(null, "No se encontraron playas cercanas", "Mensaje");
        } else {
            var ul = widget._cargarListado();
            ul.id = "listadoPlayasId";
            $(ul).prepend('<li data-role="list-divider" role="heading" class="ui-li-divider ui-bar-b ui-li-has-count">Playas ordenadas por disponibildad<span id="spanCatidadPlayas" class="ui-li-count ui-body-inherit"></span></li>');
            $("#spanCatidadPlayas").html(widget.options.listadoPlayas.length);
            $("#pnlMapa").hide();
            $("#panelListado").append(ul);
            $("#listadoPlayasId").attr("data-role", "listview");
            $("#listadoPlayasId").attr("data-inset", "false");
            $("#listadoPlayasId").attr("data-icon", "false");
            $("#listadoPlayasId").attr("data-divider-them", "b");
        }
    },
    /**
     * Se encarga  de el acordion donde se mostraran
     * las playas encontradas cercanas.
     */
    _cargarListado: function () {
        var widget = this;
        var listado = document.createElement("ul");
        listado.className = "ui-listview";
        widget._filtrarUnaPlayaPorUbicacion();
        widget._obtenerDisponibilidadParaPlayas();
        widget._obtenerPrecioPlayasSeleccionadas();
        widget._ordenarPlayasPorDisponiblidad();
        for (var i = 0; i < widget.options.listadoPlayas.length; i++) {
            var playa = widget.options.listadoPlayas[i];
            widget._crearEntradaParaPlaya(playa, listado);
        }
        return listado;
    },
    _crearEntradaParaPlaya: function (playa, listado) {
        var widget = this;

        var itemListado = document.createElement("li");
        itemListado.className = "ui-li-has-thumb";

        var itemA = document.createElement("a");
        itemA.className = "ui-btn";
        itemA.onclick = widget._crearEventoClickAPlaya(playa);

        var imagen = document.createElement("img");
        imagen.id = "diponibilidadPlaya" + playa.Id;
        if (playa.Disponibilidad <= 30) {
            imagen.src = "./img/Disponibilidades/" + playa.Disponibilidad + ".png";
        } else {
            imagen.src = "./img/Disponibilidades/masDe30.png";
        }

        var header = document.createElement("h2");
        header.innerHTML = playa.Nombre;

        var parrafoDireccion = document.createElement("p");
        parrafoDireccion.innerHTML = widget._crearDescripcionParaPlaya(playa);

        var parrafoPrecios = document.createElement("p");
        parrafoPrecios.className = "ui-li-aside";
        var strongPrecio = document.createElement("strong");
        var precio = playa.Precios[0].Tiempo;
        precio += ": $";
        precio += playa.Precios[0].Monto;
        strongPrecio.innerHTML = precio;

        //Todos los append
        parrafoPrecios.appendChild(strongPrecio);
        itemA.appendChild(imagen);
        itemA.appendChild(header);
        itemA.appendChild(parrafoDireccion);
        itemA.appendChild(parrafoPrecios);
        itemListado.appendChild(itemA);
        listado.appendChild(itemListado);
    },
    /**
     * Una vez creado el listado de playas, se mantendra actualizada
     * la disponibilidad de las mismas
     */
    actualizarDisponibilidades: function () {
        var widget = this;
        if ($("#panelListado").children().length !== 0) {
            widget._obtenerDisponibilidadParaPlayas();
            widget._actualizarImagenesDisponibilidades();
            setTimeout(function () {
                $("#panelListado").listadoPlayasWidget("actualizarDisponibilidades");
            }, 2000);
        }
    },
    _actualizarImagenesDisponibilidades: function () {
        var widget = this;
        for (var i = 0; i < widget.options.listadoPlayas.length; i++) {
            var playa = widget.options.listadoPlayas[i];
            var imagen = document.getElementById("diponibilidadPlaya" + playa.Id);
            if (playa.Disponibilidad <= 30) {
                imagen.src = "./img/Disponibilidades/" + playa.Disponibilidad + ".png";
            } else {
                imagen.src = "./img/Disponibilidades/masDe30.png";
            }
        }
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
    _crearEventoClickAPlaya: function (playa) {
        var widget = this;
        var posicionPlayaGoogle = new google.maps.LatLng(playa.Latitud, playa.Longitud);
        var eventoClick = function () {
            widget.destroy();
            ir(posicionActual, posicionPlayaGoogle, "DRIVING", "METRIC");
            enviarConsultaAEstadisticas(playa);
            guardarPlayaConsultada(playa);
            widget.options.playaElegida = posicionPlayaGoogle;
        };
        return eventoClick;
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
    /**
     * Lee en el localStorage la distancia guardada por el usuario en el panel configuraciones,
     * si no existe ninguna almacenada, devuelve 500 (valor por defecto).
     */
    _obtenerDistanciaPredeterminada: function () {
        return leerPropiedadRadio();
    },
    /**
     * Obtiene el tipo de vehiculo almacenado en el localStorage
     * que fue guardado en el panel configuraciones.
     */
    _obtenerTipoVehiculoPredeterminado: function () {
        return leerPropiedadTipoVehiculo();
    },
    /**
     * Filtra el listado de playas recibido por parametro en el widget
     * dejando solo aquellas que se encuentran a una distancia en linea
     * recta menor al radio seleccionado en el panel de condifuraciones
     */
    _filtrarPlayasPorDistancia: function () {
        var widget = this;
        var playasFiltradas = [];
        var distanciaAFiltrar = widget._obtenerDistanciaPredeterminada();
        for (var i = 0; i < widget.options.listadoPlayas.length; i++) {
            var playa = widget.options.listadoPlayas[i];
            var distanciaPlaya = widget._calcularDistanciaPlaya(playa);
            if (distanciaPlaya <= distanciaAFiltrar) {
                playasFiltradas.push(playa);
            }
        }
        widget.options.listadoPlayas = playasFiltradas;

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
        var tipoVehiculo = widget._obtenerTipoVehiculoPredeterminado();
        var uri = obtenerURLServer() + 'api/disponibilidad/PostObtenerDisponibilidadesPlayasPorTipoVehiculo';
        var datos = {
            idPlayas : idPlayas.toString(),
            idTipoVehiculo : tipoVehiculo
        };
        var disponibilidades = widget.options.disponibilidadPlayas;
        $.ajax({
            type: "POST",
            url: uri,
            dataType: "json",
            content: "application/json; charset=utf-8",
            data : datos,
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
    },
    /**
     * Se encarga de ordenar el listado de playas por disponibilidad.
     */
    _ordenarPlayasPorDisponiblidad: function () {
        var widget = this;
        var funcionDeOrden = function (a, b) {
            if ((parseInt(b.Disponibilidad) - parseInt(a.Disponibilidad)) === 0) {
                return widget._calcularDistanciaPlaya(a) - widget._calcularDistanciaPlaya(b);
            }
            return (parseInt(b.Disponibilidad) - parseInt(a.Disponibilidad));
        };
        widget.options.listadoPlayas = widget.options.listadoPlayas.sort(funcionDeOrden);
    },
    /**
     *
     */
    _agregarDisponibilidadYNombreAListadoPlayas: function () {
        var widget = this;
        for (var i = 0; i < widget.options.listadoPlayas.length; i++) {
            var idPlaya = widget.options.listadoPlayas[i].Id;
            widget.options.listadoPlayas[i]['Disponibilidad'] = widget._obtenerDisponibilidadDePlayaPorId(idPlaya);
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
     *
     */
    _obtenerDisponibilidadDePlayaPorId: function (idPlaya) {
        var widget = this;
        for (var i = 0; i < widget.options.disponibilidadPlayas.length; i++) {
            if (widget.options.disponibilidadPlayas[i].PlayaId === idPlaya) {
                return widget.options.disponibilidadPlayas[i].Disponibilidad;
            }
        }
        return 0;
    },
    _filtrarUnaPlayaPorUbicacion: function () {
        var widget = this;
        var resultado = [];
        for (var i = 0; i < widget.options.listadoPlayas.length; i++) {
            var playa = widget.options.listadoPlayas[i];
            if (!(widget._verificarQueExistePlayaEnArray(playa, resultado))) {
                resultado.push(playa);
            }
        }
        return resultado;
    },
    _verificarQueExistePlayaEnArray: function (playa, array) {
        for (var j = 0; j < array.length; j++) {
            if (playa.Id === array[j].Id) {
                return true;
            }
        }
        return false;
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
        var uri = obtenerURLServer() + 'api/Precios/PostObtenerPreciosPlayas';
        var datos = {
            idPlayas : idPlayas.toString(),
            idTipoVehiculo : parseInt(widget._obtenerTipoVehiculoPredeterminado())
        };
        var precios;
        $.ajax({
            type: "POST",
            url: uri,
            dataType: "json",
            content: "application/json; charset=utf-8",
            data : datos,
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
        var preciosDePlaya = []
        for (var i = 0; i < precios.length; i++) {
            if (precios[i].IdPlaya === playaId) {
                preciosDePlaya.push(precios[i]);
            }
        }
        return preciosDePlaya;
    },
    /**
     * Obtiene la playa elegida (este metodo es publico)
     */
    obtenerPlayaElegida: function () {
        var widget = this;
        return widget.options.playaElegida;
    },
    _empezarLoading: function () {
        cargandoConMensaje("Cargando Listado");
    },
    _terminarLoading: function () {
        quitarCargando();
    }
});