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
    var val1 = validarCampoVacioYMail($('[id=valEmailEditar]').attr("id"), $('[id=Main_txtEmailEditar]').attr("id"));
    var val2 = validarCampoVacio($('[id=valNombreEditar]').attr("id"), $('[id=Main_txtNombreEditar]').attr("id"));
    var val3 = validarCampoVacio($('[id=valApellidoEditar]').attr("id"), $('[id=Main_txtApellidoEditar]').attr("id"));
    var val4 = validarCampoVacio($('[id=valFechaEditar]').attr("id"), $('[id=Main_txtfechaNacimiento]').attr("id"));
    var val5 = validarCampoVacioYNumero($('[id=valDNIEditar]').attr("id"), $('[id=Main_txtDni]').attr("id"));
    var val6 = validarCampoVacio($('[id=valDireccionEditar]').attr("id"), $('[id=Main_txtDireccion]').attr("id"));
    var val7 = false;
    if ($('[id=Main_txtUsuario]').attr("disabled") != "disabled") {
        val7 = validarCampoVacio($('[id=valUsuario]').attr("id"), $('[id=Main_txtUsuario]').attr("id"));
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