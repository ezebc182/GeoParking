<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Error.ascx.cs" Inherits="SIRAD.Web2.Mensajes.ErrorAlert" %>

<div class="alert alert-danger " id="AlertaError" style="display:none;">
    <button type="button" class="close" data-dismiss="alert">&times;</button>
    <span runat="server" id="lblMensajeAlert"></span>
</div>
<div class="modal fade" id="MensajeModalError">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header  alert alert-danger">
                <a class="close" data-dismiss="MensajeModalError">×</a>
                <span runat="server" id="lblTitulo"></span>
            </div>
            <div class="modal-body">
                <span runat="server" id="lblMensajeModal"></span>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-info" data-dismiss="modal" aria-hidden="true">Aceptar</button>
            </div>
            </>
        </div>
    </div>
</div>

<script type="text/javascript">


    function Alerta_openModalError() {
        $('#MensajeModalError').modal('show');
    }
    function Alerta_openModalError(mensaje, titulo, mostrarAlerta) {
        $('#msjeError_lblMensajeModal').text(mensaje);
        $('#msjeError_lblTitulo').text(titulo);
        $('#MensajeModalError').modal('show');

        if (mostrarAlerta) {
            $('[id*=lblMensajeAlert]').text(mensaje);
            $('[id*=AlertaError]').show();
        }
    }
    function Alerta_cerrarModalError() {
        $('#msjeError_lblMensajeModal').text("");
        $('#msjeError_lblTitulo').text("");
        $('#MensajeModalError').modal('hide');

        if (mostrarAlerta) {
            $('[id*=AlertaError]').hide();
        }
    }
</script>
