
var drawingManager;
var selectedShape;
var colors = ['#1E90FF', '#FF1493', '#32CD32', '#FF8C00', '#4B0082'];
var selectedColor;
var colorButtons = {};
var map;
var zonaNueva;
var nombre;
var zonas = new Array();
var accion; //creando, editando

function clearSelection() {
    if (selectedShape) {
        $('#txtNombreZona').val("");
        $('#txtNombreZona').prop('disabled', true);
        selectedShape.setEditable(false);
        selectedShape = null;

        configurarCancelarZona();
    }
}

function setSelection(shape) {
    if (selectedShape != shape) {
        clearSelection();
        selectedShape = shape;
        shape.setEditable(false);
        //selectColor(shape.get('fillColor') || shape.get('strokeColor'));

        configurarSeleccionarZona();
    }
}

function setSelectedShapeEditable(editable) {
    if (selectedShape) {
        selectedShape.setEditable(editable);
    }
}

function deleteSelectedShape() {
    if (selectedShape) {
        selectedShape.setMap(null);
    }
}

function selectColor(color) {
    selectedColor = color;
    for (var i = 0; i < colors.length; ++i) {
        var currColor = colors[i];
        colorButtons[currColor].style.border = currColor == color ? '2px solid #789' : '2px solid #fff';
    }

    // Retrieves the current options from the drawing manager and replaces the
    // stroke or fill color as appropriate.

    var polygonOptions = drawingManager.get('polygonOptions');
    polygonOptions.fillColor = color;
    drawingManager.set('polygonOptions', polygonOptions);
}

function setSelectedShapeColor(color) {
    if (selectedShape) {
        if (selectedShape.type == google.maps.drawing.OverlayType.POLYLINE) {
            selectedShape.set('strokeColor', color);
        } else {
            selectedShape.set('fillColor', color);
        }
    }
}

function makeColorButton(color) {
    var button = document.createElement('span');
    button.className = 'color-button';
    button.style.backgroundColor = color;
    google.maps.event.addDomListener(button, 'click', function () {
        selectColor(color);
        setSelectedShapeColor(color);
    });

    return button;
}

function buildColorPalette() {
    //var colorPalette = document.getElementById('color-palette');
    for (var i = 0; i < colors.length; ++i) {
        var currColor = colors[i];
        var colorButton = makeColorButton(currColor);
        //colorPalette.appendChild(colorButton);
        colorButtons[currColor] = colorButton;
    }
    selectColor(colors[0]);
}

function initialize() {
    map = new google.maps.Map(document.getElementById('map-canvas'), {
        zoom: 12,
        center: new google.maps.LatLng(-31.416756, -64.183501),
        mapTypeId: google.maps.MapTypeId.ROADMAP,
        disableDefaultUI: true,
        zoomControl: true
    });
    cargarZonas($.parseJSON($('[id*=hdZonas]').val()));
}

google.maps.event.addDomListener(window, 'load', initialize);

function cargarZonas(zonasJSON) {
    zonas = new Array();
    $.each(zonasJSON, function (i, zona) {
        var wkt = zona.Poligono.Geography.WellKnownText;
        var poly = toGMPolygon(wkt);
        poly.Id = zona.Id;
        poly.Nombre = zona.Nombre;
        zonas.push(poly);
    });
    mostrarZonas();
    selectedShape = null;

};

function mostrarZona(shape) {
    shape.setMap(map);
}

function mostrarZonas() {
    $.each(zonas, function (i, zona) {
        zona.setMap(map);
    });
}

function ocultarZonas() {
    $.each(zonas, function (i, zona) {
        zona.setMap(null);
    });
}
function toGMPolygon(wkt) {
    var coordenadas = new Array();
    var coords = wkt.substr(10, wkt.indexOf('))') - 10);
    var coordsArray = coords.trim().replace(/,/g, ' ').split(/ +/g);
    for (var j = 0; j < coordsArray.length; j++) {
        coordenadas.push(new google.maps.LatLng(coordsArray[j + 1], coordsArray[j]));
        j++;
    }

    var poly = new google.maps.Polygon({
        paths: coordenadas,
        strokeWeight: 0,
        fillColor: '#1E90FF',
        fillOpacity: 0.45
    });
    poly.wkt = wkt;
    google.maps.event.addListener(poly, 'click', function (event) {
        setSelection(poly);
    });
    return poly;
};

function nuevaZona() {
    clearSelection();
    ocultarZonas();
    var polyOptions = {
        strokeWeight: 0,
        fillOpacity: 0.45,
        editable: true
    };
    // Creates a drawing manager attached to the map that allows the user to draw
    // markers, lines, and shapes.
    drawingManager = new google.maps.drawing.DrawingManager({
        drawingMode: google.maps.drawing.OverlayType.POLYGON,
        drawingControl: true,
        drawingControlOptions: {
            position: google.maps.ControlPosition.TOP_CENTER,
            drawingModes: [
              google.maps.drawing.OverlayType.POLYGON
            ]
        },
        polygonOptions: polyOptions,
        map: map
    });

    google.maps.event.addListener(drawingManager, 'overlaycomplete', function (e) {

        if (e.type != google.maps.drawing.OverlayType.MARKER) {
            // Switch back to non-drawing mode after drawing a shape.
            drawingManager.setDrawingMode(null);

            // Add an event listener that selects the newly-drawn shape when the user
            // mouses down on it.
            var poly = e.overlay;
            poly.type = e.type;
            poly.Id = 0;
            poly.Nombre = $('#txtNombreZona').val();
            poly.wkt = toWKT(poly);
            zonaNueva = poly;
            google.maps.event.addListener(poly, 'click', function () {
                setSelection(poly);
            });
            selectedShape = poly;

            //Borrar los controles para que no se pueda dibujar otra zona!!
            drawingManager.setOptions({
                drawingControl: false
            });


        }
    });

    //// Clear the current selection when the drawing mode is changed, or when the
    //// map is clicked.
    //google.maps.event.addListener(drawingManager, 'drawingmode_changed', clearSelection);
    google.maps.event.addListener(map, 'click', clearSelection);

    buildColorPalette();

};
function guardarZona() {
    nombre = $('#txtNombreZona').val();
    datos = new zona(selectedShape.Id, nombre, selectedShape.wkt);

    $.ajax({
        type: "POST",
        url: "Zonas.aspx/GuardarZona",
        data: "{'zonaJSON': '" + JSON.stringify(datos) + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var resultado = response.d;
            if (resultado == "true") {
                zonas.push(selectedShape);
                setSelectedShapeEditable(false);
                ocultarZonas();
                Alerta_openModalInfo("La zona " + datos.Nombre + " se registro con exito!", "Zona Registrada");
                recargarZonas();
                $('#txtNombreZona').val('');
                configurarGuardarZona();
            }
        },
        error: function (result) {
            var errores = result.responseText.substr('0', result.responseText.indexOf('{'));
            Alerta_openModalError(errores, "Error en el registro de zonas", true);
        }
    });
};

function eliminarZona() {
    $.ajax({
        type: "POST",
        url: "Zonas.aspx/EliminarZona",
        data: "{'zonaId': '" + selectedShape.Id + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "text",
        success: function (response) {
            var resultado = $.parseJSON(response).d;
            if (resultado == "true") {
                ocultarZonas();
                Alerta_openModalInfo("La zona se elimino con exito!", "Zona Eliminada");
                recargarZonas();
                $('#txtNombreZona').val('');
                configurarEliminarZona();
            }
        },
        error: function (result) {
            var errores = result.responseText.substr('0', result.responseText.indexOf('{'));
            Alerta_openModalError(errores, "Error en el registro de zonas", true);
        }
    });
};



function configurarNuevaZona() {
    accion = "creando";
    $('#btnEditarZona').hide();
    $('#btnNuevaZona').hide();
    $('#btnGuardarZona').show();
    $('#btnCancelar').show();
    $('#txtNombreZona').prop('disabled', false);

    clearSelection();
    ocultarZonas();

}

function configurarEditarZona() {
    accion = "editando";
    $('#btnEditarZona').hide();
    $('#btnNuevaZona').hide();
    $('#btnGuardarZona').show();
    $('#btnEliminarZona').hide();
    $('#btnCancelar').show();
    $('#txtNombreZona').prop('disabled', false);

    var zonaTemp = toGMPolygon(selectedShape.wkt);
    zonaTemp.Nombre = selectedShape.Nombre;
    zonaTemp.Id = selectedShape.Id;
    selectedShape = zonaTemp;    
    mostrarZona(selectedShape);
    ocultarZonas();
    mostrarZona(selectedShape);
    setSelectedShapeEditable(true);

}

function configurarGuardarZona() {
    $('#btnEditarZona').hide();
    $('#btnNuevaZona').show();
    $('#btnGuardarZona').hide();
    $('#btnEliminarZona').hide();
    $('#btnCancelar').hide();
    $('#txtNombreZona').prop('disabled', true);
}

function configurarEliminarZona() {
    $('#btnEditarZona').hide();
    $('#btnNuevaZona').show();
    $('#btnGuardarZona').hide();
    $('#btnEliminarZona').hide();
    $('#btnCancelar').hide();
    $('#txtNombreZona').prop('disabled', true);
}

function configurarCancelarZona() {
    if (drawingManager) {
        drawingManager.setDrawingMode(null);
    }
        deleteSelectedShape(); //borro del mapa la zona que se estaba creando o editando
    
    $('#btnEditarZona').hide();
    $('#btnNuevaZona').show();
    $('#btnGuardarZona').hide();
    $('#btnEliminarZona').hide();
    $('#btnCancelar').hide();
    $('#txtNombreZona').prop('disabled', true);

    clearSelection();
    ocultarZonas();
    mostrarZonas();
}

function configurarSeleccionarZona() {
    $('#btnEditarZona').show();
    $('#btnNuevaZona').show();
    $('#btnGuardarZona').hide();
    $('#btnEliminarZona').show();
    $('#btnCancelar').hide();
    $('#txtNombreZona').prop('disabled', true);

    $('#txtNombreZona').val(selectedShape.Nombre);
}

function recargarZonas() {
    $.ajax({
        type: "POST",
        url: "Zonas.aspx/RecargarZonas",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            var resultado = response.d;
            $('[id*=hdZonas]').val(resultado);
            cargarZonas($.parseJSON($('[id*=hdZonas]').val()));
        },
        error: function (result) {
            var errores = result.responseText.substr('0', result.responseText.indexOf('{'));
            Alerta_openModalError(errores, "Error recuperando las zonas", true);
        }
    });

}

function toWKT(poly) {
    // Start the Polygon Well Known Text (WKT) expression
    var wkt = "POLYGON(";

    var paths = poly.getPaths();
    for (var i = 0; i < paths.getLength() ; i++) {
        var path = paths.getAt(i);

        // Open a ring grouping in the Polygon Well Known Text
        wkt += "(";
        for (var j = 0; j < path.getLength() ; j++) {
            // add each vertice and anticipate another vertice (trailing comma)
            wkt += path.getAt(j).lng().toString() + " " + path.getAt(j).lat().toString() + ",";
        }

        // Google's approach assumes the closing point is the same as the opening
        // point for any given ring, so we have to refer back to the initial point
        // and append it to the end of our polygon wkt, properly closing it.
        // Also close the ring grouping and anticipate another ring (trailing comma)
            wkt += path.getAt(0).lng().toString() + " " + path.getAt(0).lat().toString() + "),";
    }

    // resolve the last trailing "," and close the Polygon
    wkt = wkt.substring(0, wkt.length - 1) + ")";

    return wkt;
}