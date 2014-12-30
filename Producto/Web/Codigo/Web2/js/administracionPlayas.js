﻿var playaCargada;

var playas = {
    iniciar: function () {
        this.limpiar();
        servicios.iniciar();
        direcciones.iniciar();
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
        $tr.append('<td tipoPlayaId="'+playa.TipoPlayaId+'">' + playa.TipoPlayaStr + ' </td>');
        $tr.append('<td>' + playa.Calle + ' </td>');
        $tr.append('<td>' + playa.Numero + ' </td>');
        $tr.append('<td>' + playa.Ciudad + ' </td>');
        $tr.append('<td>' + playa.Extras + ' </td>');

        $tr.append('<td> <a id="btnVerPlaya" class="glyphicon glyphicon-search"></a>  <a id="btnEditarPlaya" class="glyphicon glyphicon-edit"></a>  <a id="btnEliminarPlaya" class="glyphicon glyphicon-remove"></a></td>');
        $tableBody.append($tr);
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
    },
    guardar: function () {
        var id;
        var nombre = $('[id*=txtNombre]').val();
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
                    $('#lblMensajeError').parent().addClass('hidden');
                    $('#modificarPlaya').modal('hide');
                    Alerta_openModalInfo("La playa se registro con exito!", "Playa Registrada");
                }
            },
            error: function (result) {
                var errores = result.responseText.substr('0', result.responseText.indexOf('{'));
                $('#lblMensajeError').html(errores);
                $('#lblMensajeError').parent().removeClass('hidden');
            }
        });

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
        $tr.append('<td> <a id="txtEditableCapacidad" data-type="text" data-title="Ingrese capacidad" data-value="' + servicio.Capacidad + '" ></a> </td>');
        $.each(this.tiempos, function (i, tiempo) {
            var tiempoId = tiempo.Id//$tr.find('th[idTiempo]').eq(i).attr('idTiempo');
            var precioEncontrado = false;
            //$.each(servicio.Precios, function (j, precioServicio) {
            //    if (servicio.id == precioServicio.servicioId && tiempoId == precioServicio.tiempoId) {
            //        $tr.append('<td> ' + '<a href="#" id="editable-' + servicio.id + '-' + tiempoId + '" data-type="text" data-pk="' + precioServicio.id + '"data-value="' + precioServicio.monto + '" data-url="" data-title="Ingrese el precio"></a>' + '</td>');
            //        precioEncontrado = true;
            //        return false;
            //    }
            //});
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

        $('[id*=Editable]').editable({ mode: 'inline' });
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
    iniciar: function () {
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

        if (playaCargada !== undefined) {
            //se esta editando una playa, cargar los servicios en la tabla
            $.each(playaCargada.Servicios, function () {
                me.agregar(this);
            });
        }

        $('[id*=txtCapacidad]').val('');
        $('[id*=ddlTipoVehiculo] [value=0]').prop("selected", true);
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
    iniciar: function () {
        GoogleMaps.initialize();
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

        $('[id*=btnQuitarDireccion]').click(function () {
            me.eliminar($tr);
        });
        $('[id*=btnEditarDireccion]').click(function () {
            me.editar($tr, direccion);
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
    editar: function ($tr, direccion) {
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
