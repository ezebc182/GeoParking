
function abrirTab(origen) {
    var currentId = origen.attr('id');


    if (currentId == "#TopContent_btnPaso1") {


        $('#TopContent_tabDatosGrales').removeClass('active');
        $('.tab-pane#datosGrales').removeClass('active in');
        $('#TopContent_tabPrecios').removeClass('active');
        $('.tab-pane#precios').removeClass('active in');
        $('#TopContent_tabHorarios').addClass('active');
        $('.tab-pane#horarios').addClass('active in');

    }
    else if (currentId == "#TopContent_btnPaso2") {
        $('#TopContent_tabDatosGrales').removeClass('active');
        $('.tab-pane#datosGrales').removeClass('active in');
        $('#TopContent_tabPrecios').removeClass('active');
        $('.tab-pane#precios').removeClass('active in');
        $('#TopContent_tabPrecios').addClass('active');
        $('.tab-pane#precios').addClass('active in');

    }

}