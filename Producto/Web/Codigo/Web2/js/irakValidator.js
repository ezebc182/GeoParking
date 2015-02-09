function validarCampoVacio(div, id)
{
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
}