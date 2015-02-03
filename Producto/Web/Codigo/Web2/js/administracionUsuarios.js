
function cargarPermisosPorRol(listaPermisos) {
    var listaJSON = jQuery.parseJSON(listaPermisos);
    var check;
    $("input[id*=Main_cbl]").each(function (i, valor) {
        check = false;
        $.each(listaJSON, function (i, permiso) {
            if (valor.value == permiso.Id) {
                check = true;
            }
        });
        if (check == true) {
            $(valor).prop('checked', true);
        }
        else 
            {
            $(valor).prop('checked', false);
        }
    });
};

function selectIndexchangedRolPermisos(idPermiso) {
    $.ajax({
        type: "POST",
        url: "AdministracionUsuarios.aspx/Permisos",
        data: "{'idPermiso': '" + idPermiso + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function (response) {
            var resultado = response.d;
            $('[id*=hdPermisos]').val(resultado);
           cargarPermisosPorRol($('[id*=hdPermisos]').val());
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(textStatus + ": " + XMLHttpRequest.responseText);
        }
    });
};

function guardarRolPermisos(idPermiso) {
    var lista = "";
    $("input[id*=Main_cbl]:checked").each(function (i, valor) {
        lista = lista.concat("-");
        lista = lista.concat(valor.value);
    });
    $.ajax({
        type: "POST",
        url: "AdministracionUsuarios.aspx/GuardarPermisos",
        data: "{'idRol': '" + idPermiso + "' , 'listaPermisos': '" + lista + "'}",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        async: true,
        success: function (response) {
            var resultado = response.d;
            Alerta_openModalInfo("El rol se actualizo con éxito!", "Administración de Roles y Permisos");
            if (resultado == "true") {
                selectIndexchangedRolPermisos($("[id*=Main_ddlRolPermisos]").val());
            }
        },
        error: function (result) {
            var errores = result.responseText.substr('0', result.responseText.indexOf('{'));
            Alerta_openModalError(errores, "Error en la actualizacion de Roles y Permisos", true);
        }
    });
};

function crearRol(nombre, descripcion) {
    $.ajax({
        type: "POST",
        url: "AdministracionUsuarios.aspx/CrearRol",
        data: "{'nombre': '" + nombre + "' , 'descripcion': '" + descripcion + "'}",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        async: true,
        success: function (response) {
            var resultado = response.d;          
            if (resultado == "true") {
                Alerta_openModalInfo("El rol se creó con éxito!", "Administración de Roles y Permisos");
            }
        },
        error: function (result) {
            var errores = result.responseText.substr('0', result.responseText.indexOf('{'));
            Alerta_openModalError(errores, "Error en la actualizacion de Roles y Permisos", true);
        }
    });
};

function selectIndexchangedRolUsuario(idUsuario) {
    $.ajax({
        type: "POST",
        url: "AdministracionUsuarios.aspx/CargarComboRol",
        data: "{'idUsuario': '" + idUsuario + "'}",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        async: true,
        success: function (response) {
            var resultado = response.d;
            $('[id*=Main_ddlRol]').val(resultado);
        },
        error: function (result) {
            var errores = result.responseText.substr('0', result.responseText.indexOf('{'));
            Alerta_openModalError(errores, "Error en la actualizacion de Roles y Permisos", true);
        }
    });
};

function guardarRolUsuario(usuario, rol) {
    $.ajax({
        type: "POST",
        url: "AdministracionUsuarios.aspx/GuardarRolUsuario",
        data: "{'usuario': '" + usuario + "' , 'rol': '" + rol + "'}",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        async: true,
        success: function (response) {
            var resultado = response.d;   
            if (resultado == "true") {
                Alerta_openModalInfo("El rol se asigno correctamente!", "Administración de Roles y Permisos");
                selectIndexchangedRolUsuario($('[id*=Main_ddlUsuario').val());
            }
        },
        error: function (result) {
            var errores = result.responseText.substr('0', result.responseText.indexOf('{'));
            Alerta_openModalError(errores, "Error en la actualizacion de Roles y Permisos", true);
        }
    });
};