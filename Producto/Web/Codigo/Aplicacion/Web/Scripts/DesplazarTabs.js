/* Desplaza los tabs del formulario*/

function abrirTab() {
    $('#btnPaso1').click(function () {
        $('.nav-tabs > .active').next('li').find('a').trigger('click');
    });
}