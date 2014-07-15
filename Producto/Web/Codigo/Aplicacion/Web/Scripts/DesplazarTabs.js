
function abrirTab(id) {

    switch (id) {
        case ("btnPaso1_2"):

            $("#TopContent_tabDatosGrales").removeClass("active");
            $("#TopContent_datosGrales>tab-pane").removeClass("active in");
            $("#TopContent_tabHorarios").addClass("active");
            $("#TopContent_horarios>tab-pane").addClass("active in");
            $("#TopContent_tabPrecios").removeClass("active");
            $("#TopContent_precios>tab-pane").removeClass("active in");
            break;
    
        case ("btnPaso2_3"):
            $("#TopContent_tabPrecios").addClass("active");
            $("#TopContent_precios>tab-pane").addClass("active in");
            $("#TopContent_tabHorarios").removeClass("active");
            $("#TopContent_horarios>tab-pane").removeClass("active in");
            $("#TopContent_btnGuardar").removeClass("disabled");
            $("#TopContent_tabDatosGrales").removeClass("active");
            $("#TopContent_datosGrales>tab-pane").removeClass("active in");
            break;
        case ("btnPaso3_2"):
            $("#TopContent_tabPrecios").removeClass("active");
            $("#TopContent_precios>tab-pane").removeClass("active in");
            $("#TopContent_tabHorarios").addClass("active");
            $("#TopContent_horarios>tab-pane").addClass("active in");
            $("#TopContent_btnGuardar").addClass("disabled");
            $("#TopContent_tabDatosGrales").removeClass("active");
            $("#TopContent_datosGrales>tab-pane").removeClass("active in");
            break;
        case ("btnPaso2_1"):
            $("#TopContent_tabDatosGrales").addClass("active");
            $("#TopContent_datosGrales>tab-pane").addClass("active in");
            $("#TopContent_tabHorarios").removeClass("active");
            $("#TopContent_horarios>tab-pane").removeClass("active in");
            $("#TopContent_tabPrecios").removeClass("active");
            $("#TopContent_precios>tab-pane").removeClass("active in");
            break;
        case ("MainContent_btnNuevo"):
            if ($("#TopContent_tabHorarios").hasClass("active") || $("#TopContent_tabPrecios").hasClass("active")) {
                $("#TopContent_tabDatosGrales").addClass("active");
                $("#TopContent_datosGrales>tab-pane").addClass("active in");
                $("#TopContent_tabHorarios").removeClass("active");
                $("#TopContent_horarios>tab-pane").removeClass("active in");
                $("#TopContent_tabPrecios").removeClass("active");
                $("#TopContent_precios>tab-pane").removeClass("active in");
            }
            
            break;
        default:
            alert("LA CONCHA DE TU MADRE ALL BOYS");
            
            
    }


}
