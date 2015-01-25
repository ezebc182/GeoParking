var tiposPlaya = new Array();
var tiposVehiculo = new Array();
var diasAtencion = new Array();

function quitar(id) {
    boton = document.getElementById(id.attributes[2].value);
    if (!boton) {
        alert("El elemento selecionado no existe");
    } else {
        padre = boton.parentNode;
        padre.removeChild(boton);
        mostrarElementosEnCombo(id.attributes[2].value);
    }
}

function mostrarElementosEnCombo(id) {
    if (id.indexOf("vehiculo") > -1) {
        MostrarTipoVehiculoEnCombo(id.substring(8, 9));
    }
    if (id.indexOf("tipoPlaya") > -1) {
        MostrarTipoPlayaEnCombo(id.substring(9, 10));
    }
    if (id.indexOf("dia") > -1) {
        MostrarDiaEnCombo(id.substring(3, 4));
    }           
}

function MostrarTipoVehiculoEnCombo(id) {
    $('[id*=ddlTipoVehiculo] [value=' + id + ']').toggle();
    for (var i = 0; i < tiposVehiculo.length; i++) {
        if (tiposVehiculo[i] == id)
            tiposVehiculo.splice(i, 1);
    }
    document.getElementById("tiposVehiculo").innerHTML = tiposVehiculo;
}
function MostrarTipoPlayaEnCombo(id) {
    $('[id*=ddlTipoPlaya] [value=' + id + ']').toggle();
    for (var i = 0; i < tiposPlaya.length; i++) {
        if (tiposPlaya[i] == id)
            tiposPlaya.splice(i, 1);
    }
    document.getElementById("tiposPlaya").innerHTML = tiposPlaya;
}
function MostrarDiaEnCombo(id) {
    $('[id*=ddlDiasAtencion] [value=' + id + ']').toggle();
    for (var i = 0; i < diasAtencion.length; i++) {
        if (diasAtencion[i] == id)
            diasAtencion.splice(i, 1);
    }         
    document.getElementById("diasAtencion").innerHTML = diasAtencion;
}

function OcultarTipoVehiculoEnCombo(id) {
    $('[id*=ddlTipoVehiculo] [value=' + id + ']').toggle();
           
}
function OcultarTipoPlayaEnCombo(id) {
    $('[id*=ddlTipoPlaya] [value=' + id + ']').toggle();            
}
function OcultarDiaEnCombo(id) {
    $('[id*=ddlDiasAtencion] [value=' + id + ']').toggle();
           
}

function agregarTagsTipoPlaya(){
    filtros = document.getElementById("tags").innerHTML;
    var s = document.getElementById("ddlTipoPlaya");
    var id = s.options[s.selectedIndex].value;
    if (id != 0) {
        OcultarTipoPlayaEnCombo(id);
        var nuevoFiltro = s.options[s.selectedIndex].text;
        document.getElementById("tags").innerHTML = filtros + "<span class='btn btn-default btn-xs btn-info' type='button' id='tipoPlaya" + id + "' onClick='quitar(tipoPlaya" + id + ")' >" + nuevoFiltro + " x</span> ";
        s.selectedIndex = 0;
        tiposPlaya.push(id);//agrego a la lista
        document.getElementById("tiposPlaya").innerHTML = tiposPlaya;

    }
}

function agregarTagsDiasAtencion() {
    filtros = document.getElementById("tags").innerHTML;
    var s = document.getElementById("ddlDiasAtencion");
    var id = s.options[s.selectedIndex].value;
    if (id != 0) {
        OcultarDiaEnCombo(id)
        var nuevoFiltro = s.options[s.selectedIndex].text;
        document.getElementById("tags").innerHTML = filtros + "<button class='btn btn-default btn-xs btn-info' type='button' id='dia" + id + "' onClick='quitar(dia" + id + ")'>" + nuevoFiltro + " x</button> ";
        s.selectedIndex = 0;
        diasAtencion.push(id);
        document.getElementById("diasAtencion").innerHTML = diasAtencion;
    }
}

function agregarTagsTipoVehiculo() {
    filtros = document.getElementById("tags").innerHTML;
    var s = document.getElementById("ddlTipoVehiculo");
    var id = s.options[s.selectedIndex].value;
    if (id != 0) {
        OcultarTipoVehiculoEnCombo(id)               
        var nuevoFiltro = s.options[s.selectedIndex].text;
        document.getElementById("tags").innerHTML = filtros + "<button class='btn btn-default btn-xs btn-info' type='button' id='vehiculo" + id + "' onClick='quitar(vehiculo" + id + ")' >" + nuevoFiltro + " x</button> ";
        s.selectedIndex = 0;
        tiposVehiculo.push(id);
        document.getElementById("tiposVehiculo").innerHTML = tiposVehiculo;
    }
}

function agregarTags(tipoTags) {
    switch (tipoTags) {
        case 1: agregarTagsTipoPlaya();
            break;
        case 2: agregarTagsTipoVehiculo();
            break;
        case 3: agregarTagsDiasAtencion();
            break;
        default:

    }
}


