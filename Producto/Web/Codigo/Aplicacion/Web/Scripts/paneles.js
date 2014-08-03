function mostrarPanel(e) {
    $(e).parents("[id *= divPanel]").first().find("[id *= divSeccionFormulario]").removeClass("hidden")
    $(e).parents("[id *= divPanel]").first().find("[id *= divSeccionGrilla]").addClass("hidden")
    $(e).addClass("hidden")
}

function ocultarPanel(e) {
    $(e).parents("[id *= divPanel]").first().find("[id *= divSeccionFormulario]").addClass("hidden")
    $(e).parents("[id *= divPanel]").first().find("[id *= divSeccionGrilla]").removeClass("hidden")
    $(e).parents("[id *= divPanel]").first().find("[id *= btnAgregar]").removeClass("hidden")

}
        