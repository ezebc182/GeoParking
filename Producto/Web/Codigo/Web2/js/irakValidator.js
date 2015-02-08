function validarCampoVacio(div, name)
{
    var formDiv = $('[id=' + div + ']');
    var campo = $('[id=' + name + "]");
    var icon = $('[id= icon' + name + ']');
    var small = $('[id= small' + name + ']');
    var error = $('[id= error' + name + ']');
    var label = $('[id= lbl' + name + ']');
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