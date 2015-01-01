var usuarios = {
    buscar: function (usuario) {
        var me = this;
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