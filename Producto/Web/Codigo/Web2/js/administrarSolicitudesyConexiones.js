
function validar() {
    validarCampoVacio($('[id=valPlaya]').attr("id"), $('[id=Main_txtPlaya]').attr("id"));
}

function validarSolicitud() {
    var val = validarCampoVacio($('[id=valPlaya]').attr("id"), $('[id=Main_txtPlaya]').attr("id"));
    if (!val) {
        return true;
    }
    else {
        return false;
    }
}

function RegistrarSolicitud() {
    $.ajax({
        type: "POST",
        url: "DatosDeRegistro.aspx/RegistrarSolicitud",
        contentType: "application/json; charset=utf-8",
        async: true,
        success: function (response) {
            var resultado = response.d;
            if (resultado == "true") {
                Alerta_openModalInfo("La solicitud se creo correctamente! Revise su casilla de e-mail", "Registro de Usuario");
            }
        },
        error: function (result) {
            var errores = result.responseText.substr('0', result.responseText.indexOf('{'));
            Alerta_openModalError(errores, "Error en la creacion de Solicitud", true);
        }
    });
}