<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Contacto.aspx.cs" Inherits="Web2.Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="page-header">
                <h2>Contacto&nbsp;<small>envianos tu consulta</small></h2>
            </div>
            <div class="col-md-12">

                <div class="well well-sm" style="margin: 0;">
                    <div class="form-horizontal">


                        <div class="form-group" style="margin-top: 2%;">
                            <%--                     <div class="input-group input-group-lg">
                                                            <span class="input-group-addon">@</span>
                                                            <input type="text" class="form-control" placeholder="Username">
                                                            </div>--%>

                            <span class="col-md-1 col-md-offset-2 text-center" style="font-size: 20px;"><span
                                class="glyphicon glyphicon-user"></span></span>
                            <div class="col-md-4">
                                <input id="txtNombreContacto" name="name" type="text" placeholder="Nombre" class="input-lg form-control"
                                    required autofocus>
                            </div>

                            <div class="col-md-4">
                                <input id="txtApellidoContacto" name="name" type="text" placeholder="Apellido" class="input-lg form-control"
                                    required>
                            </div>
                        </div>

                        <div class="form-group">
                            <span class="col-md-1 col-md-offset-2 text-center" style="font-size: 20px;"><span
                                class="glyphicon glyphicon-envelope"></span></span>
                            <div class="col-md-8">
                                <input id="txtEmailContacto" name="email" type="email" placeholder="Email" class="input-lg form-control"
                                    required>
                            </div>
                        </div>
                        <%--<div class="form-group">
                                <span class="col-md-1 col-md-offset-2 text-center"><span class="glyphicon glyphicon-phone">
                                </span></span>
                                <div class="col-md-4">
                                    <input id="txtTelefonoContacto" name="phone" type="tel" placeholder="Teléfono" class="input-lg form-control"
                                        pattern="\b\d{3,5}[-.]?\d{3}[-.]?\d*\b">
                                </div>
                            </div>--%>

                        <div class="form-group">
                            <span class="col-md-1 col-md-offset-2 text-center" style="font-size: 20px;"><span
                                class="glyphicon glyphicon-edit"></span></span>
                            <div class="col-md-8">
                                <textarea class="input-lg form-control" id="txtMensajeContacto" name="message" placeholder="Ingrese su mensaje"
                                    rows="7" required></textarea>
                            </div>
                        </div>

                        <div class="form-group">
                            <span class="col-md-1 col-md-offset-2 text-center" style="font-size: 20px;"></span>
                            <div class="col-md-8 ">
                                <button type="submit" class=" pull-right btn btn-success btn-lg">Enviar</button>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
