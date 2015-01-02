<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Confirmacion.ascx.cs" Inherits="SIRAD.Web2.Mensajes.Confirmacion" %>

<div class="modal fade" id="MensajeModalConfirmacion">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header  alert alert-warning">
                <a class="close" data-dismiss="MensajeModalConfirmacion">×</a>
                <p id="lblTituloConfirmacion"></p>
            </div>
            <div class="modal-body">
                <p id="lblMensajeModalConfirmacion"></p>
            </div>
            <div class="modal-footer">
                <button type="button" id="btnConfirmacionModalSi" class="btn btn-info" >Si</button>
                <button type="button" id="btnConfirmacionModalNo" class="btn btn-info" >No</button>
            </div>
        </div>
    </div>
</div>

<script type="text/javascript">


    function Alerta_openModalConfirmacion() {
        $('#MensajeModalConfirmacion').modal('show');
    }
    
    function Alerta_openModalConfirmacion(mensajeConfirmacion, tituloConfirmacion, funcionSi) {
        $('#MensajeModalConfirmacion').modal('show');
        $('[id*=lblTituloConfirmacion]').html(tituloConfirmacion);
        $('[id*=lblMensajeModalConfirmacion]').html(mensajeConfirmacion);
        $('[id*=btnConfirmacionModalSi]').on("click", function ()
        {
            Alerta_cerrarModalConfirmacion();
            funcionSi();
        });
        $('[id*=btnConfirmacionModalNo]').on("click", Alerta_cerrarModalConfirmacion);
    }

    function Alerta_cerrarModalConfirmacion() {
        $('#MensajeModalConfirmacion').modal('hide');
    }
</script>
