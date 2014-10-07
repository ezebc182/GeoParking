$(document).ready(function () {

    var blockUI = function () {
        $.blockUI({
            message: 'Procesando...',
            css: {
                border: 'none',
                padding: '15px',

                backgroundColor: '#000',
                opacity: .5,
                color: '#fff',
                'font-size': '1.3em',
                'z-index':'110000',
                '-webkit-border-radius': '5px',
                '-moz-border-radius': '5px',
                'border-radius': '5px'
            },
            overlayCSS: {
                opacity: .3,
                'z-index':'105000',
            }
        });
    };

    var unblockUI = function () {
        $.unblockUI();
    };
    
    // Bloqueo de update panel
    var prm = Sys.WebForms.PageRequestManager.getInstance();

    prm.add_beginRequest(BeginRequestHandler);
    prm.add_endRequest(EndRequestHandler);

    function BeginRequestHandler(sender, args) {
        blockUI();
    }

    function EndRequestHandler(sender, args) {
        unblockUI();
    }
}); 