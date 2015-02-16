
function validar() {
    validarCampoVacio($('[id=valPlaya]').attr("id"), $('[id=Main_txtPlaya]').attr("id"));
}

function validarSolicitud() {
    var val = validarCampoVacio($('[id=valPlaya]').attr("id"), $('[id=Main_txtPlaya]').attr("id"));
    if (!val) {

    }
}