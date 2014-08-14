<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Error.ascx.cs" Inherits="SIRAD.Web.Controls.Alerts.ErrorAlert" %>

<div class="alert alert-danger" runat="server" id="Alert">
    <button type="button" class="close" data-dismiss="alert">&times;</button>
    <span runat="server" id="lblMensaje"></span>
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
                <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Aceptar</button>
            </div>
        </>
    </div>
</div>

<script type="text/javascript">


    function Alerta_openModalError() {
        $('#MensajeModalError').modal('show');


    }

</script>
