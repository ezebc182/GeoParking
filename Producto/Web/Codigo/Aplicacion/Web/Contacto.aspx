<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="Web.Contacto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="page-header">
                <h2>Contacto <small>envíanos tu consulta</small></h2>
            </div>
            <div class="jumbotron">                
                <div class="form-horizontal formulario" role="form">
                    <div class="form-group">
                        <label for="nombre">Nombre:</label>
                        <input type="text" class="form-control" id="nombre" />
                    </div>
                    <div class="form-group">
                        <label for="apellido">Apellido:</label>
                        <input type="text" class="form-control" id="apellido" />
                    </div>
                    <div class="form-group">
                        <label for="email">E-mail:</label>
                        <input type="email" class="form-control" id="email" />
                    </div>
                    <div class="form-group">
                        <label for="nombre">Mensaje:</label>
                        <textarea  class="form-control" id="mensaje"></textarea>
                    </div>
                    <div class="form-group pull-right">
                        <button class="btn btn-success">Enviar mensaje!</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
