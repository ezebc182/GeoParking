$.widget("geoparking.historialWidget", {
    /**
     * Opciones del widget, se usan para tener un acceso
     * global a estas variables y son seteadas al iniciar el widget.
     */
    options: {
        contenedor: $("#listadoHistorial"),
        cantidadHistorial: null,
        playaElegida: null,
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
        } else {
            widget.destroy();
        }
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
            $("#listadoHistorial").append("<p>El historial está vacío</p>");
        } else {
            widget.crearEstructuraHistorial();
        }
    },
    _crearEventoClickAPlayaSinGuardarConsulta: function (playa) {
        var widget = this;
        var posicionPlayaGoogle = new google.maps.LatLng(playa.Latitud, playa.Longitud);
        var eventoClick = function () {
            widget.destroy();
            ir(posicionActual, posicionPlayaGoogle, "DRIVING", "METRIC");
            widget.options.playaElegida = posicionPlayaGoogle;
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
        var listado = document.createElement("ul");
        listado.className = "ui-listview";
        listado.id = "listado-historial";
        $(".historial").remove();
        $.each(arrayPlayas.reverse(), function (indX, playa) {

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
            var precio = playa.Precios[0].Tiempo;
            precio += ": $";
            precio += playa.Precios[0].Monto;
            strongPrecio.innerHTML = precio;
            //Todos los append
            parrafoPrecioa.appendChild(strongPrecio);
            itemA.appendChild(header);
            itemA.appendChild(parrafoDireccion);
            itemA.appendChild(parrafoPrecioa);
            itemListado.appendChild(itemA);
            listado.appendChild(itemListado);
        })
        $("#listadoHistorial").append(listado);
    },
    retornarCantidadPlayasAGuardar: function () {
        var widget = this;
        return widget.options.cantidadHistorial;
    }

});