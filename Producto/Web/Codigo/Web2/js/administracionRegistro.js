function guardarDatosUsuario(usuario) {
    $.ajax({
        type: "POST",
        url: "AdministracionRolesyPermisos.aspx/GuardarDatosUsuario",
        data: "{'usuario': '" + usuario + "'}",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        async: true,
        success: function (response) {
            var resultado = response.d;
            if (resultado == "true") {
                Alerta_openModalInfo("Se actualizaron los datos correctamente!", "Actualización de Datos");
                selectIndexchangedRolUsuario($('[id*=Main_ddlUsuario').val());
            }
        },
        error: function (result) {
            var errores = result.responseText.substr('0', result.responseText.indexOf('{'));
            Alerta_openModalError(errores, "Error en la actualizacion de Datos de Usuario", true);
        }
    });
};