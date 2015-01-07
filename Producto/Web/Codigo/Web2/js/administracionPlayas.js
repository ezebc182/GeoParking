var playaCargada;

var playas = {
    habilitarEdicion: true,
    iniciar: function () {
        var me = this;
        $('#tabDireccion').on("click", function () {
            direcciones.iniciar();
            setTimeout(function () { GoogleMaps.resize(); }, 200);
        });

        $('[id*=btnGuardar]').on("click", function () {
            me.guardar();
        });

        $('.checkbox :checkbox').on("change", function () {
            var checked = $('.checkbox :checkbox:checked').length > 0;
            $('[id*=txtDesde] input').prop("disabled", checked);
            $('[id*=txtHasta] input').prop("disabled", checked);
            $('[id*=txtDesde] input').prop("readonly", !checked);
            $('[id*=txtHasta] input').prop("readonly", !checked);
            $('[id*=txtDesde] input').prop("readonly", false);
            $('[id*=txtHasta] input').prop("readonly", false);
            if (checked) {
                $('[id*=txtDesde] .bfh-timepicker-popover').addClass('hidden');
                $('[id*=txtHasta] .bfh-timepicker-popover').addClass('hidden');
            }
            else {
                $('[id*=txtDesde] .bfh-timepicker-popover').removeClass('hidden');
                $('[id*=txtHasta] .bfh-timepicker-popover').removeClass('hidden');
            }
        });

        servicios.iniciar();
        $('#modificarPlaya').modal({
            backdrop: false,
            keyboard: false,
            show: true
        });
    },
    buscar: function (ciudad) {
        var me = this;
        me.vaciarTabla();
        $.ajax({
            type: "POST",
            url: "AdministracionPlayas.aspx/BuscarPlayas",
            data: "{'ciudad': '" + ciudad + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var resultado = $.parseJSON(response.d);
                $.each(resultado, function (i, playa) {
                    me.agregar(playa);
                });
                $('[id*=pnlResultados]').show();
                $('[id*=tbPlayas]').first().DataTable({
                    language: {
                        url: '//cdn.datatables.net/plug-ins/3cfcc339e89/i18n/Spanish.json'
                    }
                });
            },
            error: function (result) {
                var errores = result.responseText.substr('0', result.responseText.indexOf('{'));
                $('#lblMensajeError').html(errores);
                $('#lblMensajeError').parent().removeClass('hidden');
            }
        });
    },
    vaciarTabla: function () {
        var $trs = $('[id*=tbPlayasBody] tr');

        $.each($trs, function (i, item) { item.remove(); });
    },
    agregar: function (playa) {
        var me = this;
        var $tableBody = $('[id*=tbPlayasBody]');
        var $tr = $('<tr idPlaya="' + playa.Id + '"> </tr>');

        $tr.append('<td>' + playa.Nombre + ' </td>');
        $tr.append('<td tipoPlayaId="' + playa.TipoPlayaId + '">' + playa.TipoPlayaStr + ' </td>');
        $tr.append('<td>' + playa.Calle + ' </td>');
        $tr.append('<td>' + playa.Numero + ' </td>');
        $tr.append('<td>' + playa.Ciudad + ' </td>');
        $tr.append('<td>' + playa.Extras + ' </td>');

        $tr.append('<td> <a id="btnVerPlaya" class="glyphicon glyphicon-search"></a>  <a id="btnEditarPlaya" class="glyphicon glyphicon-edit"></a>  <a id="btnEliminarPlaya" class="glyphicon glyphicon-remove"></a></td>');
        $tableBody.append($tr);

        $('[id*=btnVerPlaya]').click(function () {
            me.ver(playa);
        });

        $('[id*=btnEditarPlaya]').click(function () {
            me.editar(playa);
        });

        $('[id*=btnEliminarPlaya]').click(function () {
            var mensaje = "¿Esta seguro que desea eliminar la playa " + playa.Nombre + "?";
            var titulo = "Eliminar Playa";
            var funcionSi = function () { me.eliminar(playa) };
            Alerta_openModalConfirmacion(mensaje, titulo, funcionSi);
        });
    },
    limpiar: function () {
        $('[id*=txtNombre]').val("");
        $('[id*=txtMail]').val("");
        $('[id*=txtTelefono]').val("");
        $('[id*=ddlTipoPlaya] [value=0]').prop("selected", true);
        $('[id*=txtDesde]').val("08:00");
        $('[id*=txtHasta]').val("22:00");
        $('[id*=ddlDias] [value=0]').prop("selected", true);
        servicios.limpiar();
        direcciones.limpiar();
        $('#lblMensajeError').text("");
        $('#lblMensajeError').parent().addClass('hidden');
        $('#lblMensajeExito').text("");
        $('#lblMensajeExito').parent().addClass('hidden');

        $('[id*=tabDatosGrales]').tab('show');
    },
    cargar: function (playa) {
        $('[id*=txtNombre]').val(playa.Nombre);
        $('[id*=txtMail]').val(playa.Mail);
        $('[id*=txtTelefono]').val(playa.Telefono);
        $('[id*=ddlTipoPlaya] [value="' + playa.TipoPlayaId + '"]').prop("selected", true);
        $('[id*=txtDesde]').val(playa.Horario.HoraDesde);
        $('[id*=txtHasta]').val(playa.Horario.HoraHasta);
        $('[id*=ddlDias] [value="' + playa.Horario.DiaAtencionId + '"]').prop("selected", true);
        servicios.cargar(playa.Servicios);
        direcciones.cargar(playa.Direcciones);
    },
    registrar: function () {
        this.limpiar();
        this.habilitarEdicion = true;
        $('[id*=modificarPlaya] .modal-title').text('Registrar Playa');
        $('[id*=txtNombre]').prop("disabled", false);
        $('[id*=txtMail]').prop("disabled", false);
        $('[id*=txtTelefono]').prop("disabled", false);
        $('[id*=ddlTipoPlaya]').prop("disabled", false);
        $('.checkbox').show();
        $('[id*=txtDesde] input').prop("disabled", true);
        $('[id*=txtHasta] input').prop("disabled", true);
        $('[id*=txtDesde] input').prop("readonly", false);
        $('[id*=txtHasta] input').prop("readonly", false);
        $('[id*=txtDesde] .bfh-timepicker-popover').addClass('hidden');
        $('[id*=txtHasta] .bfh-timepicker-popover').addClass('hidden');
        $('[id*=ddlDias]').prop("disabled", false);
        $('[id*=btnCerrarPlaya]').hide();
        $('[id*=btnCancelarPlaya]').show();
        $('[id*=btnGuardarPlaya]').show();

        direcciones.registrar();
        servicios.registrar();
        this.iniciar();
    },
    ver: function (playa) {
        this.limpiar();
        this.habilitarEdicion = false;
        this.cargar(playa);
        $('[id*=modificarPlaya] .modal-title').text('Ver Playa');

        $('[id*=txtNombre]').prop("disabled", true);
        $('[id*=txtMail]').prop("disabled", true);
        $('[id*=txtTelefono]').prop("disabled", true);
        $('[id*=ddlTipoPlaya]').prop("disabled", true);
        $('.checkbox').hide();
        $('[id*=txtDesde] input').prop("disabled", true);
        $('[id*=txtHasta] input').prop("disabled", true);
        $('[id*=txtDesde] input').prop("readonly", false);
        $('[id*=txtHasta] input').prop("readonly", false);
        $('[id*=txtDesde] .bfh-timepicker-popover').addClass('hidden');
        $('[id*=txtHasta] .bfh-timepicker-popover').addClass('hidden');
        $('[id*=ddlDias]').prop("disabled", true);
        $('[id*=btnCerrarPlaya]').show();
        $('[id*=btnCancelarPlaya]').hide();
        $('[id*=btnGuardarPlaya]').hide();

        servicios.ver();
        direcciones.ver();
        this.iniciar();
    },
    editar: function (playa) {
        var me = this;
        me.limpiar();
        me.habilitarEdicion = true;
        me.cargar(playa);
        $('[id*=modificarPlaya] .modal-title').text('Editar Playa');
        $('[id*=txtNombre]').prop("disabled", false);
        $('[id*=txtMail]').prop("disabled", false);
        $('[id*=txtTelefono]').prop("disabled", false);
        $('[id*=ddlTipoPlaya]').prop("disabled", false);
        $('.checkbox').show();
        $('[id*=txtDesde] .input-group input').prop("disabled", true);
        $('[id*=txtHasta] .input-group input').prop("disabled", true);
        $('[id*=txtDesde] input-group input').prop("readonly", false);
        $('[id*=txtHasta] input-group input').prop("readonly", false);
        $('[id*=txtDesde] .bfh-timepicker-popover').addClass('hidden');
        $('[id*=txtHasta] .bfh-timepicker-popover').addClass('hidden');
        $('[id*=ddlDias]').prop("disabled", false);
        $('[id*=btnCerrarPlaya]').hide();
        $('[id*=btnCancelarPlaya]').show();
        $('[id*=btnGuardarPlaya]').show();

        direcciones.editar();
        servicios.editar();
        me.iniciar();
    },
    guardar: function () {
        var me = this;
        var id;
        var nombre = $('#modificarPlaya [id*=txtNombre]').val();
        var mail = $('[id*=txtMail]').val();
        var telefono = $('[id*=txtTelefono]').val();
        var tipoPlayaId = $('[id*=ddlTipoPlaya]').find(':selected').val();
        var horarioTemp = new horario(0, $('[id*=txtDesde]').val(), $('[id*=txtHasta]').val(), $('[id*=ddlDias]').find(':selected').val());
        var direccionesTemp = direcciones.lista();
        var serviciosTemp = servicios.lista();

        playaTemp = new playaDeEstacionamiento(id, nombre, mail, telefono, tipoPlayaId, horarioTemp, direccionesTemp, serviciosTemp)

        $.ajax({
            type: "POST",
            url: "AdministracionPlayas.aspx/GuardarPlaya",
            data: "{'playaJSON': '" + JSON.stringify(playaTemp) + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var resultado = response.d;
                if (resultado == "true") {
                    $('#modificarPlaya #lblMensajeError').parent().addClass('hidden');
                    $('#modificarPlaya').modal('hide');
                    Alerta_openModalInfo("La playa " + playaTemp.Nombre + " se registro con exito!", "Playa Registrada");
                    me.actualizar();
                }
            },
            error: function (result) {
                var errores = result.responseText.substr('0', result.responseText.indexOf('{'));
                $('#modificarPlaya #lblMensajeError').html(errores);
                $('#modificarPlaya #lblMensajeError').parent().removeClass('hidden');
            }
        });

    },
    eliminar: function (playa) {
        var me = this;
        $.ajax({
            type: "POST",
            url: "AdministracionPlayas.aspx/EliminarPlaya",
            data: "{'id': '" + playa.Id + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var resultado = response.d;
                if (resultado == "true") {
                    var mensaje = "La playa " + playa.Nombre + " se ha eliminado con exito!";
                    var titulo = "Playa Eliminada";
                    Alerta_openModalInfo(mensaje, titulo, true);
                    me.actualizar();
                }
            },
            error: function (result) {
                var mensaje = result.responseText.substr('0', result.responseText.indexOf('{'));
                var titulo = "Eliminar Playa";
                Alerta_openModalError(mensaje, titulo, true);
            }
        });

    },
    actualizar: function () {
        if ($('[id*=pnlResu]').css('display') != "none") {
            $('[id*=btnBuscarPlayas]').click();
        }
    }
};

var servicios = {
    cantidad: 0,
    tiempos: $.parseJSON($('[id*=hfTiempos]').val()),

    agregar: function (servicio) {
        var me = this;
        var $tableBody = $('[id*=tbServiciosBody]');
        var $tr = $('<tr idServicio="' + servicio.Id + '"> </tr>');

        $tr.append('<td tipoVehiculoId=' + '"' + servicio.TipoVehiculoId + '"' + '>' + $('[id*=ddlTipoVehiculo]').find('[value=' + servicio.TipoVehiculoId + ']').text(), +' </td>');
        $tr.append('<td> <a id="txtEditableCapacidad" data-type="text" data-title="Ingrese capacidad" data-value="' + servicio.Capacidad.Cantidad + '" ></a> </td>');

        var cantidadPreciosEncontrados = 0;
        $.each(this.tiempos, function (i, tiempo) {
            var tiempoId = $('th[idTiempo]').eq(i).attr('idTiempo');
            var precioEncontrado = false;
            if (cantidadPreciosEncontrados < servicio.Precios.length) {
                $.each(servicio.Precios, function (j, precioServicio) {
                    if (servicio.Id == precioServicio.ServicioId && tiempoId == precioServicio.TiempoId) {
                        $tr.append('<td> ' + '<a href="#" id="txtEditablePrecio" servicioId="' + servicio.Id + '" tiempoId="' + tiempoId + '" precioId="' + precioServicio.Id + '" data-type="text" data-pk="" data-value="' + precioServicio.Monto + '" data-url="" data-title="Ingrese el precio"></a>' + '</td>');
                        precioEncontrado = true;
                        cantidadPreciosEncontrados++;
                        return false;
                    }
                });
            }
            if (!precioEncontrado) {
                $tr.append('<td> <a id="txtEditablePrecio" data-type="text" data-emptytext="Ingrese Precio" data-title="Ingrese precio" data-pk="' + tiempoId + '"</a> </td>');
            }

        });
        $tr.append('<td> <a id="btnQuitarServicio" class="glyphicon glyphicon-remove"></a></td>');
        $tableBody.append($tr);
        this.cantidad++;
        this.OcultarTipoVehiculoEnCombo(servicio.TipoVehiculoId);
        $('[id*=txtCapacidad]').val('');
        $('[id*=ddlTipoVehiculo] [value=0]').prop("selected", true);
        this.verificarCombo();

        if (playas.habilitarEdicion) {
            $('[id*=Editable]').editable({
                mode: 'inline',
                disabled: false
            });
        }

        $('[id*=btnQuitarServicio]').click(function () { me.eliminar(servicio); });
    },
    eliminar: function (servicio) {
        var $tr = $('[id*=tbServicios] [tipoVehiculoId=' + servicio.TipoVehiculoId + ']').parents('tr').first();
        var idTipoVehiculo = $tr.find('[tipoVehiculoId]').attr('tipoVehiculoId');
        this.MostrarTipoVehiculoEnCombo(idTipoVehiculo);
        $tr.remove();
    },
    MostrarTipoVehiculoEnCombo: function (id) {
        $('[id*=ddlTipoVehiculo] [value=' + id + ']').toggle();
    },
    OcultarTipoVehiculoEnCombo: function (id) {
        $('[id*=ddlTipoVehiculo] [value=' + id + ']').toggle();
    },
    limpiar: function () {
        var me = this;
        $.each(this.lista(), function (i, servicio) {
            me.eliminar(servicio);
        });
        var $tableHeadTrs = $('[id*=tbServiciosHead] tr');
        $tableHeadTrs.remove();
    },
    iniciar: function (servicios) {
        //llenar la tabla con el head de hfPrecios y los servicios en el hfServicios
        var me = this;
        var $table = $('[id*=tbServicios]');
        var $tableHead = $('[id*=tbServiciosHead]');
        var $tr = $('<tr> </tr>');

        $tr.append('<th>Tipo de Vehiculo</th>');
        $tr.append('<th>Capacidad</th>');

        $.each(this.tiempos, function (i, tiempo) {
            $tr.append('<th idTiempo="' + tiempo.Id + '"> $ x ' + tiempo.Nombre + '</th>');
        });

        $tableHead.append($tr);

        $('[id*=txtCapacidad]').val('');
        $('[id*=ddlTipoVehiculo] [value=0]').prop("selected", true);

        //eventos
        $('[id*=btnAgregarServicio]').on("click", function () {

            var capacidadNueva = new capacidad(0, $('[id*=txtCapacidad]').val());
            var servicioNuevo = new servicio(0, 0, $('[id*=ddlTipoVehiculo]').val(), capacidadNueva, {});

            me.agregar(servicioNuevo);
        });
        $('[id*=ddlTipoVehiculo]').on("change", function (e) {
            me.verificarCombo();
        });

    },
    verificarCombo: function () {
        var valor = $('[id*=ddlTipoVehiculo]').find(':selected').val();
        if (valor > 0) {
            $('[id*=btnAgregarServicio]').prop("disabled", false);
        }
        else $('[id*=btnAgregarServicio]').prop("disabled", true);
    },
    cargar: function (servicios) {
        me = this;
        if (servicios !== undefined) {
            //se esta editando una playa, cargar los servicios en la tabla
            $.each(servicios, function () {
                me.agregar(this);
            });
        }
    },
    registrar: function () {
        $('[id*=divAgregarServicio]').show();
        $('[id*=btnQuitarServicio]').show()
        $('[id*=Editable]').editable({
            mode: 'inline',
            disabled: false
        });

    },
    ver: function () {
        $('[id*=divAgregarServicio]').hide();
        $('[id*=btnQuitarServicio]').hide()
        $('[id*=Editable]').editable({
            mode: 'inline',
            disabled: true
        });

    },
    editar: function () {
        $('[id*=divAgregarServicio]').show();
        $('[id*=btnQuitarServicio]').show()
        $('[id*=Editable]').editable({
            mode: 'inline',
            disabled: false
        });
    },
    lista: function () {
        //JSON de lista de servicios en la tabla
        var servicios = new Array();
        var $filas = $('#tbServicios>tBody>tr');
        $.each($filas, function (i, fila) {
            var id = $(fila).attr('idServicio'),
                playaId,
                tipoVehiculoId = $(fila).find('[TipoVehiculoId]').first().attr('TipoVehiculoId'),
                capacidadTemp = new capacidad(id, $(fila).find('[id*=txtEditableCapacidad]').text()),
                precios = new Array(),
                $celdasPrecio = $(fila).find('a[id*=txtEditablePrecio]');

            $.each($celdasPrecio, function (j, celda) {
                var monto = celda.innerHTML;
                if (monto !== "Ingrese Precio") {
                    var precioTemp = new precio(id, $(celda).attr('data-pk'), monto);
                    precios.push(precioTemp);
                }
            });
            var servicioTemp = new servicio(id, playaId, tipoVehiculoId, capacidadTemp, precios);

            servicios.push(servicioTemp);
        });
        return servicios;
    }
};

var direcciones = {
    //parecido a servicios
    iniciar: function (direcciones) {
        var me = this;

        GoogleMaps.initialize();

        $('[id*=btnAgregarDireccion]').on("click", function () {
            var calle = $('[id*=txtCalle]').first().val();
            var numero = $('[id*=txtNumero]').first().val();
            var ciudad = $('[id*=txtBuscar]').first().val();
            var latitud = $('[id*=latitud]').first().val();
            var longitud = $('[id*=longitud]').first().val();
            var direccionNueva = new direccion(0, calle, numero, ciudad, latitud, longitud);

            me.agregar(direccionNueva);
        });

    },
    limpiar: function () {
        var me = this;
        $('[id*=txtBuscarCiudades]').val("");
        $('[id*=txtBuscarCiudades]').prop('disabled', false);
        $('[id*=txtCalle]').val("");
        $('[id*=txtNumero]').val("");

        $.each($('#tbDirecciones>tBody>tr'), function (i, direccion) {
            me.eliminar(direccion);
        });
    },
    registrar: function () {
        $('[id*=divCargarNuevaDireccion]').show();
        $('[id*=tbDirecciones] td [id*=btn]').show();
    },
    ver: function () {
        $('[id*=divCargarNuevaDireccion]').hide();
        $('[id*=tbDirecciones] td [id*=btn]').hide();
    },
    editar: function () {
        $('[id*=divCargarNuevaDireccion]').show();
        $('[id*=tbDirecciones] td [id*=btn]').show();
    },
    cargar: function (direcciones) {
        me = this;
        if (direcciones !== undefined) {
            $.each(direcciones, function (i, direccion) {
                me.agregar(direccion);
            });
        }
    },
    agregar: function (direccion) {
        var me = this;
        var $tableBody = $('[id*=tbDireccionesBody]');
        var $tr = $('<tr idDireccion="' + direccion.Id + '"> </tr>');

        $tr.append('<td>' + direccion.Calle + ' </td>');
        $tr.append('<td>' + direccion.Numero + ' </td>');
        $tr.append('<td>' + direccion.Ciudad + ' </td>');
        $tr.append('<td style="display:none;">' + direccion.Latitud + ' </td>');
        $tr.append('<td style="display:none;">' + direccion.Longitud + ' </td>');

        $tr.append('<td><a id="btnEditarDireccion" class="glyphicon glyphicon-edit"></a>   <a id="btnQuitarDireccion" class="glyphicon glyphicon-remove"></a></td>');

        $tableBody.append($tr);
        $('[id*=txtBuscarCiudades]').prop('disabled', true);
        $('[id*=txtBuscarCiudades]').val(direccion.Ciudad);

        $('[id*=btnQuitarDireccion]').click(function () {
            me.eliminar($tr);
        });
        $('[id*=btnEditarDireccion]').click(function () {
            me.editarDireccion($tr, direccion);
        });
        $('[id*=txtCalle]').val("");
        $('[id*=txtNumero]').val("");

    },
    cargarCampos: function (direccion) {
        $('[id*=txtBuscarCiudades]').val(direccion.Ciudad);
        $('[id*=txtCalle]').first().val(direccion.Calle);
        $('[id*=txtNumero]').first().val(direccion.Numero);
        $('[id*=txtBuscarCiudades]').first().val(direccion.Ciudad);
        $('[id*=latitud]').first().val(direccion.Latitud);
        $('[id*=longitud]').first().val(direccion.Longitud);
    },
    editarDireccion: function ($tr, direccion) {
        var me = this;
        me.cargarCampos(direccion);
        var cantidad = $('[id*=tbDireccionesBody] tr').length;

        if (cantidad == 1) {
            $('[id*=txtBuscarCiudades]').prop('disabled', false);
            $('[id*=txtBuscarCiudades]').focus();
        }
        else {
            $('[id*=txtCalle]').focus();
        }

        $('[id*=btnAgregarDireccion]').hide();
        $('[id*=btnAceptarEdicionDireccion]').css("visibility", "visible");
        $('[id*=btnCancelarEdicionDireccion]').show();
        $('[id*=btnAceptarEdicionDireccion]').click(function () {
            $tr.remove();
            $('[id*=btnAgregarDireccion]').click();
            $('[id*=btnAgregarDireccion]').show();
            $('[id*=btnAceptarEdicionDireccion]').css("visibility", "hidden");
            $('[id*=btnCancelarEdicionDireccion]').hide();
        });
    },
    eliminar: function ($tr) {
        $tr.remove();
        var cantidad = $('[id*=tbDireccionesBody] tr').length;
        if (cantidad == 0) {
            $('[id*=txtBuscarCiudades]').val("");
            $('[id*=txtBuscarCiudades]').prop('disabled', false);
        }
    },
    lista: function () {
        //JSON de lista de direcciones en la tabla
        var direcciones = new Array();
        var $filas = $('#tbDirecciones>tBody>tr');
        $.each($filas, function (i, fila) {
            var id = $(fila).attr('idDireccion');
            var playaId;
            var calle = $(fila).find('td').eq(0).text();
            var numero = $(fila).find('td').eq(1).text();
            var ciudad = $(fila).find('td').eq(2).text();
            var latitud = $(fila).find('td').eq(3).text();
            var longitud = $(fila).find('td').eq(4).text();

            var direccionTemp = new direccion(id, calle, numero, ciudad, latitud, longitud);

            direcciones.push(direccionTemp);
        });
        return direcciones;
    }
};
