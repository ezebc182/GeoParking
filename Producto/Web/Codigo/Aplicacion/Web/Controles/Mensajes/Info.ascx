﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Info.ascx.cs" Inherits="SIRAD.Web.Controls.Alerts.InfoAlert" %>


<div class="alert alert-info" runat="server" id="Alert">
    <button type="button" class="close" data-dismiss="alert">&times;</button>
    <span runat="server" id="lblMensaje"></span>
</div>
<div id="MensajeModalInfo" class="modal hide fade" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-header">
        <a class="close" data-dismiss="modal">×</a>

        <h3>
            <span runat="server" id="lblTitulo"></span>
        </h3>
    </div>
    <div class="modal-body">
        <span runat="server" id="lblMensajeModal"></span>
    </div>
    <div class="modal-footer">
        <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Aceptar</button>
    </div>
</div>
<script type="text/javascript">


    function Alerta_openModalInfo() {
        $('#MensajeModalInfo').modal('show');


    }

</script>
