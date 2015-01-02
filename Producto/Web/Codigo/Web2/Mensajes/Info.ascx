<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Info.ascx.cs" Inherits="SIRAD.Web2.Mensajes.InfoAlert" %>


<div class="alert alert-info" id="AlertaInfo" style="display: none;">
    <button type="button" class="close" data-dismiss="alert">&times;</button>
    <span runat="server" id="lblMensaje"></span>
</div>
<div class="modal fade" id="MensajeModalInfo">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header  alert alert-info">
                <a class="close" data-dismiss="MensajeModalInfo">×</a>
                <span runat="server" id="lblTitulo"></span>
            </div>
            <div class="modal-body">
                <span runat="server" id="lblMensajeModal"></span>
            </div>
            <div class="modal-footer">
                <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Aceptar</button>
            </div>
        </div>
    </div>
</div>

<script type="text/javascript">


    function Alerta_openModalInfo() {
        $('#MensajeModalInfo').modal('show');

    }

    function Alerta_openModalInfo(mensajeInfo, tituloInfo, mostrarAlertaInfo) {
        $('#msjeInfo_lblMensaje').text(mensajeInfo);
        $('#msjeInfo_lblMensajeModal').text(mensajeInfo);
        $('#msjeInfo_lblTitulo').text(tituloInfo);
        $('#MensajeModalInfo').modal('show');

        if (mostrarAlertaInfo) {
            $('[id*=AlertaInfo]').show();
        }
    }

    function Alerta_cerrarModalInfo() {
        $('#msjeInfo_lblMensaje').text("");
        $('#msjeInfo_lblMensajeModal').text("");
        $('#msjeInfo_lblTitulo').text("");
        $('#MensajeModalInfo').modal('hide');

        if (mostrarAlerta) {
            $('[id*=AlertaInfo]').hide();
        }
    }
</script>
