﻿<%@ Page Title="Datos Personales" Language="C#" MasterPageFile="~/MasterUsuario.master" AutoEventWireup="true" CodeBehind="DatosPersonales.aspx.cs" Inherits="Web2.DatosPersonales" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="./css/bootstrap-fileupload.min.css" type="text/css" />
    <script src="js/administracionRegistro.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3 class="panel-title">Usuario
                <asp:Label ID="lblUsuarioEditar" runat="server"></asp:Label>
                - Datos personales</h3>
        </div>
        <div class="panel-body">
            <asp:HiddenField ID="hfIdUsuario" runat="server" />
            <div class="row col-lg-10">
                <div class="col-lg-6">
                    <div class="form-group" id="valEmailEditar">
                        <label for="ctl00$Main$txtEmailEditar" class="control-label">(*) E-mail:</label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-envelope"></i></span>
                            <asp:TextBox ID="txtEmailEditar" placeholder="Email"
                                CssClass="form-control input-lg" runat="server" type="email"
                                TabIndex="1" oninput="javascript: limpiarEmailEditar();"></asp:TextBox>
                            <i id="iconMain_txtEmailEditar" style="display: none" class="form-control-feedback" data-bv-icon-for="ctl00$Main$txtEmailEditar"></i>
                        </div>
                        <small id="smallMain_txtEmailEditar" class="help-block" style="display: none;" data-bv-validator="notEmpty" data-bv-icon-for="ctl00$Main$txtEmailEditar" data-bv-result="INVALID">
                            <label id="errorMain_txtEmailEditar"></label>
                        </small>
                    </div>
                    <div class="form-group" id="valNombreEditar">
                        <label for="ctl00$Main$txtNombreEditar" class="control-label">(*) Nombre:</label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-pencil-square-o"></i></span>
                            <asp:TextBox ID="txtNombreEditar" placeholder="Nombre" CssClass="form-control input-lg"
                                runat="server" TabIndex="2" oninput="javascript: limpiarNombreEditar();"></asp:TextBox>
                            <i id="iconMain_txtNombreEditar" style="display: none" class="form-control-feedback" data-bv-icon-for="ctl00$Main$txtNombreEditar"></i>
                        </div>
                        <small id="smallMain_txtNombreEditar" class="help-block" style="display: none;" data-bv-validator="notEmpty" data-bv-icon-for="ctl00$Main$txtNombreEditar" data-bv-result="INVALID">
                            <label id="errorMain_txtNombreEditar"></label>
                        </small>
                    </div>
                    <div class="form-group" id="valApellidoEditar">
                        <label for="ctl00$Main$txtApellidoEditar" class="control-label">(*) Apellido:</label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-pencil-square-o"></i></span>
                            <asp:TextBox ID="txtApellidoEditar" placeholder="Apellido" CssClass="form-control input-lg"
                                runat="server" TabIndex="3" oninput="javascript: limpiarApellidoEditar();"></asp:TextBox>
                            <i id="iconMain_txtApellidoEditar" style="display: none" class="form-control-feedback" data-bv-icon-for="ctl00$Main$txtApellidoEditar"></i>
                        </div>
                        <small id="smallMain_txtApellidoEditar" class="help-block" style="display: none;" data-bv-validator="notEmpty" data-bv-icon-for="ctl00$Main$txtApellidoEditar" data-bv-result="INVALID">
                            <label id="errorMain_txtApellidoEditar"></label>
                        </small>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="form-group" id="valDNIEditar">
                        <label for="ctl00$Main$txtDni" class="control-label">(*) DNI:</label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-pencil-square-o"></i></span>
                            <asp:TextBox ID="txtDni" placeholder="DNI" CssClass="form-control input-lg"
                                runat="server" TabIndex="3" TextMode="Number" oninput="javascript: limpiarDNIEditar();"></asp:TextBox>
                            <i id="iconMain_txtDni" style="display: none" class="form-control-feedback" data-bv-icon-for="ctl00$Main$txtDni"></i>
                        </div>
                        <small id="smallMain_txtDni" class="help-block" style="display: none;" data-bv-validator="notEmpty" data-bv-icon-for="ctl00$Main$txtDni" data-bv-result="INVALID">
                            <label id="errorMain_txtDni"></label>
                        </small>
                    </div>
                    <div class="form-group" id="valFechaEditar">
                        <label for="ctl00$Main$txtfechaNacimiento" class="control-label">(*) Fecha de Nacimiento:</label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                            <asp:TextBox ID="txtfechaNacimiento" placeholder="dd/mm/yyyy" TabIndex="4" TextMode="Date" CssClass="form-control date-picker input-lg"
                                runat="server" oninput="javascript: limpiarFechaEditar();"></asp:TextBox>
                        <i id="iconMain_txtfechaNacimiento" style="display: none" class="form-control-feedback" data-bv-icon-for="ctl00$Main$txtfechaNacimiento"></i>
                        </div>
                        <small id="smallMain_txtfechaNacimiento" class="help-block" style="display: none;" data-bv-validator="notEmpty" data-bv-icon-for="ctl00$Main$txtfechaNacimiento" data-bv-result="INVALID">
                            <label id="errorMain_txtfechaNacimiento"></label>
                        </small>
                    </div>
                    <div class="form-group" id="valDireccionEditar">
                        <label for="ctl00$Main$txtDireccion" class="control-label">(*) Direccion:</label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-map-marker"></i></span>
                            <asp:TextBox ID="txtDireccion" TabIndex="5" placeholder="Direccion" CssClass="form-control input-lg"
                                runat="server" oninput="javascript: limpiarDireccionEditar();"></asp:TextBox>
                        <i id="iconMain_txtDireccion" style="display: none" class="form-control-feedback" data-bv-icon-for="ctl00$Main$txtDireccion"></i>
                        </div>
                        <small id="smallMain_txtDireccion" class="help-block" style="display: none;" data-bv-validator="notEmpty" data-bv-icon-for="ctl00$Main$txtDireccion" data-bv-result="INVALID">
                            <label id="errorMain_txtDireccion"></label>
                        </small>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div id="valContraseñaVieja" class="form-group">
                        <label for="ctl00$Main$txtContraseñaVieja" class="control-label">Ingrese su antigua Contraseña:</label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-unlock-alt"></i></span>
                            <asp:TextBox ID="txtContraseñaVieja" placeholder="Contraseña" CssClass="form-control input-lg"
                                runat="server" TextMode="Password" TabIndex="6"></asp:TextBox>
                            <i id="icontxtContraseñaVieja" style="display: none" class="form-control-feedback" data-bv-icon-for="ctl00$Main$txtContraseñaVieja"></i>
                        </div>
                        <small id="smalltxtContraseñaVieja" class="help-block" style="display: none;" data-bv-validator="notEmpty" data-bv-icon-for="ctl00$Main$txtContraseñaVieja" data-bv-result="INVALID">
                            <label id="errortxtContraseñaVieja"></label>
                        </small>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div id="valContraseñaNueva" class="form-group">
                        <label for="ctl00$Main$txtContraseñaNueva" class="control-label">Contraseña:</label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                            <asp:TextBox ID="txtContraseñaNueva" placeholder="Contraseña" CssClass="form-control input-lg"
                                runat="server" TextMode="Password" TabIndex="7"></asp:TextBox>
                            <i id="icontxtContraseñaNueva" style="display: none" class="form-control-feedback" data-bv-icon-for="ctl00$Main$txtContraseñaNueva"></i>
                        </div>
                        <small id="smalltxtContraseñaNueva" class="help-block" style="display: none;" data-bv-validator="notEmpty" data-bv-icon-for="ctl00$Main$txtContraseñaNueva" data-bv-result="INVALID">
                            <label id="errortxtContraseñaNueva"></label>
                        </small>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div id="valRepetirContraseñaNueva" class="form-group">
                        <label for="ctl00$Main$txtRepetirContraseñaNueva" class="control-label">Repetir Contraseña</label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                            <asp:TextBox ID="txtRepetirContraseñaNueva" placeholder="Contraseña" CssClass="form-control input-lg"
                                runat="server" TextMode="Password" TabIndex="8"></asp:TextBox>
                            <i id="icontxtRepetirContraseñaNueva" style="display: none" class="form-control-feedback" data-bv-icon-for="ctl00$Main$txtRepetirContraseñaNueva"></i>
                        </div>
                        <small id="smalltxtRepetirContraseñaNueva" class="help-block" style="display: none;" data-bv-validator="notEmpty" data-bv-icon-for="ctl00$Main$txtRepetirContraseñaNueva" data-bv-result="INVALID">
                            <label id="errortxtRepetirContraseñaNueva"></label>
                        </small>
                    </div>
                </div>
            </div>
            <div class="row col-lg-2">
                <div class="form-group" style="text-align: center">
                    <label class="control-label">Foto de Perfil:</label>
                    <div class="fileupload fileupload-new" data-provides="fileupload">
                        <div class="fileupload-new thumbnail" style="width: 180px; height: 180px;">
                            <img src="../img/fotosPerfil/demoUpload.jpg" alt="">
                        </div>
                        <div class="fileupload-preview fileupload-exists thumbnail" style="max-width: 180px; max-height: 180px; line-height: 20px;"></div>
                        <div>
                            <span class="btn btn-file btn-primary"><span class="fileupload-new">Seleccionar Imagen</span><span class="fileupload-exists">Cambiar</span><input type="file"></span>
                            <a href="#" class="btn btn-danger fileupload-exists" data-dismiss="fileupload">Borrar</a>
                        </div>
                    </div>
                </div>
            </div>
            <asp:Panel ID="panelBotones" class="col-md-12" runat="server" Style="margin-top: 20px;">
                <div id="divBotones" class="form-group col-md-4 col-md-offset-4">
                        <button type="button" class="btn btn-primary btn-md pull-left" id="btnGuardar">Guardar</button>
                        <button type="button" onclick="javascript:window.location.href='/web.aspx'" class="btn btn-md pull-right" id="btnCancelar">Cancelar</button>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript">
        function limpiarEmailEditar() {
            validarCampoVacio($('[id=valEmailEditar]').attr("id"), $('[id=Main_txtEmailEditar]').attr("id"));
        }

        function limpiarNombreEditar() {
            validarCampoVacio($('[id=valNombreEditar]').attr("id"), $('[id=Main_txtNombreEditar]').attr("id"));
        }

        function limpiarApellidoEditar() {
            validarCampoVacio($('[id=valApellidoEditar]').attr("id"), $('[id=Main_txtApellidoEditar]').attr("id"));
        }

        function limpiarFechaEditar() {
            validarCampoVacio($('[id=valFechaEditar]').attr("id"), $('[id=Main_txtfechaNacimiento]').attr("id"));
        }

        function limpiarDNIEditar() {
            validarCampoVacioYNumero($('[id=valDNIEditar]').attr("id"), $('[id=Main_txtDni]').attr("id"));
        }

        function limpiarDireccionEditar() {
            validarCampoVacio($('[id=valDireccionEditar]').attr("id"), $('[id=Main_txtDireccion]').attr("id"));
        }
        $('#btnCancelar').click(function () {
            $('[id=Main_txtEmailEditar]').val("");
            $('[id=Main_txtNombreEditar]').val("");
            $('[id=Main_txtApellidoEditar]').val("");
            $('[id=Main_txtDireccionEditar]').val("");
            $('[id=Main_txtDni]').val("");
            $('[id=Main_txtDireccion]').val("");
            $('[id=Main_txtfechaNacimiento]').val("");
            limpiarValidaciones();
        });

        $('#btnGuardar').click(function () {
            var val1 = validarCampoVacio($('[id=valEmailEditar]').attr("id"), $('[id=Main_txtEmailEditar]').attr("id"));
            var val2 = validarCampoVacio($('[id=valNombreEditar]').attr("id"), $('[id=Main_txtNombreEditar]').attr("id"));
            var val3 = validarCampoVacio($('[id=valApellidoEditar]').attr("id"), $('[id=Main_txtApellidoEditar]').attr("id"));
            var val4 = validarCampoVacio($('[id=valFechaEditar]').attr("id"), $('[id=Main_txtfechaNacimiento]').attr("id"));
            var val5 = validarCampoVacioYNumero($('[id=valDNIEditar]').attr("id"), $('[id=Main_txtDni]').attr("id"));
            var val6 = validarCampoVacio($('[id=valDireccionEditar]').attr("id"), $('[id=Main_txtDireccion]').attr("id"));

            if (!validar6Campos(val1, val2, val3, val4, val5, val6)) {
                guardarDatosUsuario();
                limpiarValidaciones();
            }
        });

    </script>
</asp:Content>