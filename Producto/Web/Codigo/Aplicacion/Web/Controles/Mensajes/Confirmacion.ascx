<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Confirmacion.ascx.cs" Inherits="SIRAD.Web.Controls.Alerts.Confirmacion" %>

<div class="alert alert-warning" runat="server" id="Alert">
    <button type="button" class="close" data-dismiss="alert">&times;</button>
    <span runat="server" id="lblMensaje"></span>
</div>
<div class="modal fade" id="MensajeModalConfirmacion">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <a class="close" data-dismiss="MensajeModalConfirmacion">×</a>
                <span runat="server" id="lblTitulo"></span>
            </div>
            <div class="modal-body">
                <span runat="server" id="lblMensajeModal"></span>
            </div>
            <div class="modal-footer">
                <asp:Button runat="server" ID="btnSi" CssClass="btn btn-info" OnClick="btnSi_Click" OnClientClick="Alerta_cerrarModalConfirmacion()" Text="Si" />
                <asp:Button runat="server" ID="btnNo" CssClass="btn btn-info" OnClick="btnNo_Click" data-dismiss="modal" aria-hidden="true" Text="No" />
            </div>
        </div>
    </div>
</div>

<script type="text/javascript">


    function Alerta_openModalConfirmacion() {
        $('#MensajeModalConfirmacion').modal('show');


    }

    function Alerta_cerrarModalConfirmacion() {
        $('#MensajeModalConfirmacion').modal('hide');
    }
</script>
