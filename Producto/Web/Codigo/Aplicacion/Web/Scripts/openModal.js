function openModal() {

    if ($('#TopContent_tabPrecios').hasClass('active') || $('#TopContent_tabHorarios').hasClass('active')) {
        $('#TopContent_tabPrecios').removeClass('active');
        $('#TopContent_tabHorarios').removeClass('active');
        $('.tab-pane#precios').removeClass('active in');
        $('.tab-pane#horarios').removeClass('active in');
        $('#TopContent_tabDatosGrales').addClass('active');
        $('.tab-pane#datosGrales').addClass('active in');
    }
    else {
        $('#TopContent_tabDatosGrales').addClass('active');
        $('.tab-pane#datosGrales').addClass('active in');
    }
    
    $('#modificarPlaya').modal('show');
    $('#TopContent_txtNombre').focus();
    


}