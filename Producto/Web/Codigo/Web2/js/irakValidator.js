function validarCampoVacio(div, id) {
    var formDiv = $('[id=' + div + ']');
    var campo = $('[id=' + id + ']');
    var icon = $('[id= icon' + id + ']');
    var small = $('[id= small' + id + ']');
    var error = $('[id= error' + id + ']');
    var label = $('[id= lbl' + id + ']');
    if (campo.val() === '') {
        formDiv.attr("class", "form-group has-feedback has-error");
        icon.attr("style", "display:block");
        icon.attr("class", "form-control-feedback glyphicon glyphicon-remove");
        small.attr("style", "display:block");
        error.text("El campo " + label.text() + " es requerido")
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

function ValidarUsuarioYContraseña(nombre, contraseña) {
    $.ajax({
        type: "POST",
        url: "web.aspx/ValidarLogin",
        data: "{'nombre': '" + nombre + "' , 'contraseña': '" + contraseña + "'}",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        async: true,
        success: function (response) {
            var resultado = response.d;
            if (resultado == true) {
                var formDiv = $('[id=valtxtUsuarioLogin]');
                var campo = $('[id=txtUsuarioLogin');
                var icon = $('[id= icontxtUsuarioLogin]');
                var small = $('[id= smalltxtUsuarioLogin]');
                var error = $('[id= errortxtUsuarioLogin]');
                formDiv.attr("class", "form-group has-feedback has-error");
                icon.attr("style", "display:block");
                icon.attr("class", "form-control-feedback glyphicon glyphicon-remove");
                small.attr("style", "display:block");
                error.text("Usuario o contraseña invalidos")
                var formDiv1 = $('[id=valtxtContraseñaLogin]');
                var campo1 = $('[id=txtContraseñaLogin');
                var icon1 = $('[id= icontxtContraseñaLogin]');
                var small1 = $('[id= smalltxtContraseñaLogin]');
                var error1 = $('[id= errortxtContraseñaLogin]');
                formDiv1.attr("class", "form-group has-feedback has-error");
                icon1.attr("style", "display:block");
                icon1.attr("class", "form-control-feedback glyphicon glyphicon-remove");
                small1.attr("style", "display:block");
                error1.text("Usuario o contraseña invalidos");
                return true;
            }
            else {
                return false;
            }
        },
        error: function (result) {
            var errores = result.responseText.substr('0', result.responseText.indexOf('{'));
            Alerta_openModalError(errores, "Error en la actualizacion de Roles y Permisos", true);
        }
    });
};




function limpiarValidaciones() {
    var formDiv = $('[id*=val]');
    var icon = $('[id*= icon]');
    var small = $('[id*= small]');
    icon.attr("style", "display:none");
    small.attr("style", "display:none");
    formDiv.attr("class", "form-group");
}

function validar2Campos(campo1, campo2) {
    if (campo1 == false && campo2 == false) {
        return false;
    }
    else {
        return true;
    }
}

function validar3Campos(campo1, campo2, campo3) {
    if (campo1 == false && campo2 == false && campo3 == false) {
        return false;
    }
    else {
        return true;
    }
}

function validar7Campos(campo1, campo2, campo3, campo4, campo5, campo6, campo7) {
    if (campo1 == false && campo2 == false && campo3 == false && campo4 == false && campo5 == false && campo6 == false && campo7 == false) {
        return false;
    }
    else {
        return true;
    }
}

function validarCamposUsuarioNuevo(campo1, campo2, campo3, campo4, campo5, campo6, campo7, campo8, campo9) {
    if (campo1 == false && campo2 == false && campo3 == false && campo4 == false && campo5 == false && campo6 == false && campo7 == false && campo8 == false && campo9 == false) {
        return false;
    }
    else {
        return true;
    }
}

function validarUsuarioVacio(div, id) {
    var formDiv = $('[id=' + div + ']');
    var campo = $('[id=' + id + "]");
    var icon = $('[id= icon' + id + ']');
    var small = $('[id= small' + id + ']');
    var error = $('[id= error' + id + ']');
    var label = $('[id= lbl' + id + ']');
    if (campo.val() === '') {
        formDiv.attr("class", "form-group has-feedback has-error");
        icon.attr("style", "display:block");
        icon.attr("class", "form-control-feedback glyphicon glyphicon-remove");
        small.attr("style", "display:block");
        error.text("Debe ingresar su usuario o e-mail")
        return true;
    }
    else {
        formDiv.attr("class", "form-group");
        icon.attr("style", "display:none");
        small.attr("style", "display:none");
        return false;
    }
}

function validarContraseñaVacia(div, id) {
    var formDiv = $('[id=' + div + ']');
    var campo = $('[id=' + id + "]");
    var icon = $('[id= icon' + id + ']');
    var small = $('[id= small' + id + ']');
    var error = $('[id= error' + id + ']');
    var label = $('[id= lbl' + id + ']');
    if (campo.val() === '') {
        formDiv.attr("class", "form-group has-feedback has-error");
        icon.attr("style", "display:block");
        icon.attr("class", "form-control-feedback glyphicon glyphicon-remove");
        small.attr("style", "display:block");
        error.text("Debe ingresar su contraseña")
        return true;
    }
    else {
        formDiv.attr("class", "form-group");
        icon.attr("style", "display:none");
        small.attr("style", "display:none");
        return false;
    }
}

function limpiarValidacionesLogin() {
    var formDiv = $('[id*=val]');
    var icon = $('[id*= icon]');
    var small = $('[id*= small]');
    icon.attr("style", "display:none");
    small.attr("style", "display:none");
    formDiv.attr("class", "form-group");
    $('[id=hfInicioSession]').val("");
}

function conectarPlaya() {
    var formDiv = $('[id*=val]');
    var icon = $('[id*= icon]');
    var small = $('[id*= small]');
    icon.attr("style", "display:none");
    small.attr("style", "display:none");
    formDiv.attr("class", "form-group");
    $('[id=hfInicioSession]').val("true");
}

function validarCampoVacioYNumero(div, id) {
    var formDiv = $('[id=' + div + ']');
    var campo = $('[id=' + id + "]");
    var icon = $('[id= icon' + id + ']');
    var small = $('[id= small' + id + ']');
    var error = $('[id= error' + id + ']');
    var label = $('[id= lbl' + id + ']');
    if (campo.val() === '') {
        formDiv.attr("class", "form-group has-feedback has-error");
        icon.attr("style", "display:block");
        icon.attr("class", "form-control-feedback glyphicon glyphicon-remove");
        small.attr("style", "display:block");
        error.text("El campo " + label.text() + " es requerido y debe ser numerico")
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

function validarCampoVacioYLongitud(div, id, long) {
    var formDiv = $('[id=' + div + ']');
    var campo = $('[id=' + id + "]");
    var icon = $('[id= icon' + id + ']');
    var small = $('[id= small' + id + ']');
    var error = $('[id= error' + id + ']');
    var label = $('[id= lbl' + id + ']');
    if (campo.val() === '' || campo.val().length < long) {
        formDiv.attr("class", "form-group has-feedback has-error");
        icon.attr("style", "display:block");
        icon.attr("class", "form-control-feedback glyphicon glyphicon-remove");
        small.attr("style", "display:block");
        error.text("El campo " + label.text() + " es requerido y debe tener 6 o mas caracteres")
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

function ValidacionDeContraseñas() {
    var cont1 = $('[id=Main_txtContraseñaNueva]');
    var cont2 = $('[id=Main_txtRepetirContraseñaNueva]');
    var formDiv = $('[id=valRepetirContraseñaNueva]');
    var icon = $('[id= iconMain_txtRepetirContraseñaNueva]');
    var small = $('[id= smallMain_txtRepetirContraseñaNueva]');
    var error = $('[id= errorMain_txtRepetirContraseñaNueva]');
    if (cont1.val() != cont2.val()) {
        formDiv.attr("class", "form-group has-feedback has-error");
        icon.attr("style", "display:block");
        icon.attr("class", "form-control-feedback glyphicon glyphicon-remove");
        small.attr("style", "display:block");
        error.text("Las contraseñas ingresadas no coinciden")
        formDiv.attr("class", "form-group has-feedback has-error");
        icon.attr("style", "display:block");
        icon.attr("class", "form-control-feedback glyphicon glyphicon-remove");
        small.attr("style", "display:block");
        error.text("Las contraseñas ingresadas no coinciden")
        return true;
    }
    else {
        return false;
    }
}

function validarCampoVacioYMail(div, id) {
    var formDiv = $('[id=' + div + ']');
    var campo = $('[id=' + id + "]");
    var icon = $('[id= icon' + id + ']');
    var small = $('[id= small' + id + ']');
    var error = $('[id= error' + id + ']');
    var label = $('[id= lbl' + id + ']');
    var regex = /[\w-\.]{2,}@([\w-]{2,}\.)*([\w-]{2,}\.)[\w-]{2,4}/;
    if (campo.val() === '' || !(regex.test(campo.val().trim()))) {
        formDiv.attr("class", "form-group has-feedback has-error");
        icon.attr("style", "display:block");
        icon.attr("class", "form-control-feedback glyphicon glyphicon-remove");
        small.attr("style", "display:block");
        error.text("El campo " + label.text() + " es requerido y debe ser un e-mail válido")
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