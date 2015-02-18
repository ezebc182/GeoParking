function RegistrarUsuario() {
    $.ajax({
        type: "POST",
        url: "DatosDeRegistro.aspx/RegistrarUsuario",
        data: "{'email': '" + $('[id=Main_txtEmailEditar]').val() + "' , 'nombre': '" + $('[id=Main_txtNombreEditar]').val() + "', 'apellido': '" + $('[id=Main_txtApellidoEditar]').val() + "', 'fecha': '" + $('[id=Main_txtfechaNacimiento]').val() + "', 'dni': '" + $('[id=Main_txtDni]').val() + "', 'direccion': '" + $('[id=Main_txtDireccion]').val() + "', 'usuario': '" + $('[id=Main_txtUsuario]').val() + "', 'contraseña': '" + $('[id=Main_txtContraseñaNueva]').val() + "'}",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        async: true,
        success: function (response) {
            var resultado = response.d;
            if (resultado == "true") {
                Alerta_openModalInfo("El usuario se registro correctamente! Revise su casilla de e-mail para activar la cuenta", "Registro de Usuario");
                limpiarValidaciones();
                limpiarCampos();
            }
        },
        error: function (result) {
            var errores = result.responseText.substr('0', result.responseText.indexOf('{'));
            Alerta_openModalError(errores, "Error en el Registro de Usuario", true);
        }
    });
};

function limpiarEmailEditar() {
    validarCampoVacioYMail($('[id=valEmailEditar]').attr("id"), $('[id=Main_txtEmailEditar]').attr("id"));
}

function limpiarUsuario() {
    validarCampoVacio($('[id=valUsuario]').attr("id"), $('[id=Main_txtUsuario]').attr("id"));
}

function limpiarNombreEditar() {
    validarCampoVacio($('[id=valNombreEditar]').attr("id"), $('[id=Main_txtNombreEditar]').attr("id"));
}

function limpiarApellidoEditar() {
    validarCampoVacio($('[id=valApellidoEditar]').attr("id"), $('[id=Main_txtApellidoEditar]').attr("id"));
}

function limpiarFechaEditar() {
    validarCampoVacio($('[id=valFechaEditar]').attr("id"), $('[id=Main_txtfechaNacimiento]').attr("id"));
}

function limpiarDNIEditar() {
    validarCampoVacioYNumero($('[id=valDNIEditar]').attr("id"), $('[id=Main_txtDni]').attr("id"));
}

function limpiarDireccionEditar() {
    validarCampoVacio($('[id=valDireccionEditar]').attr("id"), $('[id=Main_txtDireccion]').attr("id"));
}

function limpiarContraseñaNueva() {
    validarCampoVacioYLongitud($('[id=valContraseñaNueva]').attr("id"), $('[id=Main_txtContraseñaNueva]').attr("id"), 6);
}

function limpiarRepetirContraseñaNueva() {
    validarCampoVacioYLongitud($('[id=valRepetirContraseñaNueva]').attr("id"), $('[id=Main_txtRepetirContraseñaNueva]').attr("id"), 6);
}

function ValidarRegistro() {
    var val1 = ValidarEmailUsuario();
    var val2 = validarCampoVacio($('[id=valNombreEditar]').attr("id"), $('[id=Main_txtNombreEditar]').attr("id"));
    var val3 = validarCampoVacio($('[id=valApellidoEditar]').attr("id"), $('[id=Main_txtApellidoEditar]').attr("id"));
    var val4 = validarCampoVacio($('[id=valFechaEditar]').attr("id"), $('[id=Main_txtfechaNacimiento]').attr("id"));
    var val5 = validarCampoVacioYNumero($('[id=valDNIEditar]').attr("id"), $('[id=Main_txtDni]').attr("id"));
    var val6 = validarCampoVacio($('[id=valDireccionEditar]').attr("id"), $('[id=Main_txtDireccion]').attr("id"));
    var val7 = false;
    if ($('[id=Main_txtUsuario]').attr("disabled") != "disabled") {
        val7 = ValidarNombreUsuario();
    }
    if ($('[id=Main_hfNuevo]').val() == "true") {
        var val8 = validarCampoVacioYLongitud($('[id=valContraseñaNueva]').attr("id"), $('[id=Main_txtContraseñaNueva]').attr("id"), 6);
        var val9 = validarCampoVacioYLongitud($('[id=valRepetirContraseñaNueva]').attr("id"), $('[id=Main_txtRepetirContraseñaNueva]').attr("id"), 6);
        if (!validarCamposUsuarioNuevo(val1, val2, val3, val4, val5, val6, val7, val8, val9)) {
            if (!ValidacionDeContraseñas()) {
                    RegistrarUsuario();
            }
        }
    }
}

function ValidarNombreUsuario() {
    $.ajax({
        type: "POST",
        url: "DatosDeRegistro.aspx/ValidarNombreUsuario",
        data: "{'nombre': '" + $('[id=Main_txtUsuario]').val() + "'}",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        async: true,
        success: function (response) {
            var resultado = response.d;
            var formDiv = $('[id=valUsuario]');
            var campo = $('[id=Main_txtUsuario]');
            var icon = $('[id= iconMain_txtUsuario]');
            var small = $('[id= smallMain_txtUsuario]');
            var error = $('[id= errorMain_txtUsuario]');
            if (resultado == true) {
                formDiv.attr("class", "form-group has-feedback has-error");
                icon.attr("style", "display:block");
                icon.attr("class", "form-control-feedback glyphicon glyphicon-remove");
                small.attr("style", "display:block");
                error.text("Ya existe un usuario registrado con el nombre ingresado")
                return true;
            }
            else {
                if (campo.val() === '') {
                    formDiv.attr("class", "form-group has-feedback has-error");
                    icon.attr("style", "display:block");
                    icon.attr("class", "form-control-feedback glyphicon glyphicon-remove");
                    small.attr("style", "display:block");
                    error.text("El campo es requerido")
                    return true;
                }
                else {
                    formDiv.attr("class", "form-group has-feedback has-success");
                    icon.attr("style", "display:block");
                    icon.attr("class", "form-control-feedback glyphicon glyphicon-ok");
                    small.attr("style", "display:none");
                    return false;
                }
            }
        },
        error: function (result) {
            var errores = result.responseText.substr('0', result.responseText.indexOf('{'));
        }
    });
};

function ValidarEmailUsuario() {
    $.ajax({
        type: "POST",
        url: "DatosDeRegistro.aspx/ValidarEmailUsuario",
        data: "{'email': '" + $('[id=Main_txtEmailEditar]').val() + "'}",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        async: true,
        success: function (response) {
            var resultado = response.d;
            var formDiv = $('[id=valEmailEditar]');
            var campo = $('[id=Main_txtEmailEditar]');
            var icon = $('[id= iconMain_txtEmailEditar]');
            var small = $('[id= smallMain_txtEmailEditar]');
            var error = $('[id= errorMain_txtEmailEditar]');
            var regex = /[\w-\.]{2,}@([\w-]{2,}\.)*([\w-]{2,}\.)[\w-]{2,4}/;
            if (resultado == true) {
                formDiv.attr("class", "form-group has-feedback has-error");
                icon.attr("style", "display:block");
                icon.attr("class", "form-control-feedback glyphicon glyphicon-remove");
                small.attr("style", "display:block");
                error.text("Ya existe un usuario registrado con el e-mail ingresado")
                return true;
            }
            else {
                if (campo.val() === '' || !(regex.test(campo.val().trim()))) {
                    formDiv.attr("class", "form-group has-feedback has-error");
                    icon.attr("style", "display:block");
                    icon.attr("class", "form-control-feedback glyphicon glyphicon-remove");
                    small.attr("style", "display:block");
                    error.text("El campo es requerido y debe ser un e-mail válido")
                    return true;
                }
                else {
                    formDiv.attr("class", "form-group has-feedback has-success");
                    icon.attr("style", "display:block");
                    icon.attr("class", "form-control-feedback glyphicon glyphicon-ok");
                    small.attr("style", "display:none");
                    return false;
                }
            }
        },
        error: function (result) {
            var errores = result.responseText.substr('0', result.responseText.indexOf('{'));
        }
    });
};

function limpiarCampos() {
    $('[id=Main_txtEmailEditar]').val("");
    $('[id=Main_txtNombreEditar]').val("");
    $('[id=Main_txtApellidoEditar]').val("");
    $('[id=Main_txtfechaNacimiento]').val("");
    $('[id=Main_txtDni]').val("");
    $('[id=Main_txtDireccion]').val("");
    $('[id=Main_txtUsuario]').val("");
    $('[id=Main_txtContraseñaNueva]').val("");
    $('[id=Main_txtRepetirContraseñaNueva]').val("");
}